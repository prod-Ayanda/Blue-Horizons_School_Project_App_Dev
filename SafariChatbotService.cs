// =============================================================================
// Services/SafariChatbotService.cs
// Blue Horizons Tours – AI-Powered Safari & Tour Booking Concierge Service
//
// Capabilities:
//   1. AI API Integration (Google Gemini API & OpenAI/Groq-compatible REST APIs)
//      with live system context injected from Data/activities.txt & bookings.txt.
//   2. Strict Safari & Tour Booking theme enforcement (refuses off-topic queries).
//   3. Natural-language & direct booking execution (creates Booking + Invoice,
//      deducts SeatsAvailable in Data/activities.txt, and returns formatted invoice).
//   4. Seamless offline fallback engine if no API key is configured or offline.
// =============================================================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PROJECTT.Models;

namespace PROJECTT.Services
{
    public class ChatbotResponse
    {
        public string ReplyText { get; set; }
        public bool BookingCreated { get; set; }
        public Booking CreatedBooking { get; set; }
        public Invoice CreatedInvoice { get; set; }
        public Activity BookedActivity { get; set; }
        public string FormattedInvoice { get; set; }
    }

    public class SafariChatbotService
    {
        private static readonly HttpClient _http = new HttpClient { Timeout = TimeSpan.FromSeconds(20) };
        private readonly User _currentUser;
        private Activity _pendingActivityForBooking;

        public static string ApiKeyFilePath => Path.Combine(FileService.DataFolder, "chatbot_apikey.txt");

        public SafariChatbotService(User currentUser)
        {
            _currentUser = currentUser;
            try
            {
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
            }
            catch { }
        }

        // ---------------------------------------------------------------------
        // API Key Management
        // ---------------------------------------------------------------------

        public static string GetApiKey()
        {
            try
            {
                if (File.Exists(ApiKeyFilePath))
                {
                    string key = File.ReadAllText(ApiKeyFilePath).Trim();
                    if (!string.IsNullOrEmpty(key)) return key;
                }
            }
            catch { }

            string envGemini = Environment.GetEnvironmentVariable("GEMINI_API_KEY");
            if (!string.IsNullOrWhiteSpace(envGemini)) return envGemini.Trim();

            string envOpenAi = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
            if (!string.IsNullOrWhiteSpace(envOpenAi)) return envOpenAi.Trim();

            return string.Empty;
        }

        public static void SaveApiKey(string apiKey, User adminUser)
        {
            if (adminUser == null || !string.Equals(adminUser.Role, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                throw new UnauthorizedAccessException("Access Denied: Only an Administrator can configure the SafariScout AI API key.");
            }
            FileService.EnsureDataFolder();
            File.WriteAllText(ApiKeyFilePath, (apiKey ?? string.Empty).Trim());
        }

        public static bool HasApiKey() => !string.IsNullOrWhiteSpace(GetApiKey());

        // ---------------------------------------------------------------------
        // Main Entry Point: Process User Message (Natural Language Booking + AI API)
        // ---------------------------------------------------------------------

        public async Task<ChatbotResponse> ProcessMessageAsync(string userMessage)
        {
            string msg = (userMessage ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(msg))
            {
                return new ChatbotResponse
                {
                    ReplyText = "Please type a question about our safaris, tour prices, available seats, or tell me which activity you'd like to book!"
                };
            }

            // 1. Check if the user is answering a pending "How many participants?" booking prompt
            if (_pendingActivityForBooking != null)
            {
                if (Regex.IsMatch(msg, @"^(cancel|no|nevermind|stop)\b", RegexOptions.IgnoreCase))
                {
                    var cancelledName = _pendingActivityForBooking.Name;
                    _pendingActivityForBooking = null;
                    return new ChatbotResponse
                    {
                        ReplyText = $"No problem! I've cancelled the pending booking request for '{cancelledName}'. Let me know if you'd like to explore other safaris or tours."
                    };
                }

                var numMatch = Regex.Match(msg, @"\b([1-9][0-9]?)\b");
                if (numMatch.Success && int.TryParse(numMatch.Groups[1].Value, out int paxFromPending))
                {
                    var targetAct = _pendingActivityForBooking;
                    _pendingActivityForBooking = null;
                    return ExecuteBooking(targetAct.ActivityID, paxFromPending);
                }
            }

            // 2. Check if the user is explicitly asking to book a specific activity right now
            if (TryParseNaturalBookingIntent(msg, out Activity matchedActivity, out int requestedPax))
            {
                if (requestedPax <= 0)
                {
                    _pendingActivityForBooking = matchedActivity;
                    return new ChatbotResponse
                    {
                        ReplyText = $"Great choice! '{matchedActivity.Name}' ({matchedActivity.Category}) is scheduled for {matchedActivity.Date:dd MMM yyyy} at R{matchedActivity.Price:N2} per person ({matchedActivity.SeatsAvailable} seats remaining).\r\n\r\n" +
                                    "How many participants would you like to book for? (Reply with a number like '2', or use the Quick-Book bar below!)"
                    };
                }

                return ExecuteBooking(matchedActivity.ActivityID, requestedPax);
            }

            // 3. If an AI API key is configured, query the AI API with strict Safari system instructions + live data
            string apiKey = GetApiKey();
            if (!string.IsNullOrWhiteSpace(apiKey))
            {
                try
                {
                    string aiReply = await CallAiApiAsync(apiKey, msg);
                    if (!string.IsNullOrWhiteSpace(aiReply))
                    {
                        // Check if the AI emitted a structured booking command [BOOK_NOW: <ActivityID> | <Pax>]
                        var bookTag = Regex.Match(aiReply, @"\[BOOK_NOW:\s*([^|\]]+?)\s*\|\s*(\d+)\s*\]", RegexOptions.IgnoreCase);
                        if (bookTag.Success)
                        {
                            string actId = bookTag.Groups[1].Value.Trim();
                            int pax = int.Parse(bookTag.Groups[2].Value.Trim());
                            return ExecuteBooking(actId, pax);
                        }

                        return new ChatbotResponse { ReplyText = aiReply.Trim() };
                    }
                }
                catch (Exception ex)
                {
                    // Fall back gracefully to the local Safari engine and note the API error briefly
                    var fallback = GenerateLocalSafariReply(msg);
                    fallback.ReplyText = $"[AI API Notice: {ex.Message} — switched to built-in Safari Engine]\r\n\r\n" + fallback.ReplyText;
                    return fallback;
                }
            }

            // 4. Built-in Smart Safari & Booking Engine (works 100% offline with live FileService data)
            return GenerateLocalSafariReply(msg);
        }

        // ---------------------------------------------------------------------
        // Direct Booking Execution (Persists Booking + Invoice + Updates Seats)
        // ---------------------------------------------------------------------

        public ChatbotResponse ExecuteBooking(string activityId, int participants)
        {
            if (_currentUser == null)
            {
                return new ChatbotResponse
                {
                    ReplyText = "Please sign in as a Visitor first so I can link the safari booking and official invoice to your account."
                };
            }

            List<Activity> activities;
            try
            {
                activities = FileService.GetAllActivities();
            }
            catch
            {
                return new ChatbotResponse { ReplyText = "Sorry, I couldn't read the activities file right now. Please try again." };
            }

            var activity = activities.FirstOrDefault(a =>
                string.Equals(a.ActivityID, activityId, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(a.Name, activityId, StringComparison.OrdinalIgnoreCase));

            if (activity == null)
            {
                return new ChatbotResponse { ReplyText = "I couldn't find that safari or tour activity in our schedule. Please check the activity name and try again." };
            }

            if (activity.SeatsAvailable <= 0)
            {
                return new ChatbotResponse
                {
                    ReplyText = $"Sorry, '{activity.Name}' on {activity.Date:dd MMM yyyy} is currently SOLD OUT (0 seats left). Would you like me to suggest another Safari or Adventure with open seats?"
                };
            }

            if (participants <= 0)
            {
                return new ChatbotResponse { ReplyText = "Please specify at least 1 participant for your booking." };
            }

            if (participants > activity.SeatsAvailable)
            {
                return new ChatbotResponse
                {
                    ReplyText = $"Only {activity.SeatsAvailable} seat(s) remain for '{activity.Name}' on {activity.Date:dd MMM yyyy}. Please book {activity.SeatsAvailable} or fewer participants."
                };
            }

            decimal totalCost = activity.Price * participants;

            var booking = new Booking
            {
                BookingID        = Guid.NewGuid().ToString(),
                UserID           = _currentUser.UserID,
                ActivityID       = activity.ActivityID,
                BookingDate      = DateTime.Now,
                ParticipantCount = participants,
                TotalCost        = totalCost,
                PaymentStatus    = "Paid",
                Attendance       = "Pending"
            };

            try
            {
                FileService.AddBooking(booking);
            }
            catch
            {
                return new ChatbotResponse { ReplyText = "An error occurred while saving your booking to Data/bookings.txt." };
            }

            // Deduct seats and persist
            activity.SeatsAvailable = Math.Max(0, activity.SeatsAvailable - participants);
            try
            {
                FileService.SaveAllActivities(activities);
            }
            catch { }

            var invoice = new Invoice
            {
                InvoiceNo = "INV-" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                BookingID = booking.BookingID,
                UserID    = _currentUser.UserID,
                IssueDate = DateTime.Now,
                Details   = $"{activity.Name} x{participants} @ R{activity.Price:N2}",
                Total     = totalCost
            };

            try
            {
                FileService.AddInvoice(invoice);
            }
            catch { }

            string formattedInv = FormatInvoiceText(invoice, booking, activity);

            return new ChatbotResponse
            {
                BookingCreated   = true,
                CreatedBooking   = booking,
                CreatedInvoice   = invoice,
                BookedActivity   = activity,
                FormattedInvoice = formattedInv,
                ReplyText        = $"Booking Confirmed! I have booked {participants} seat(s) for '{activity.Name}' ({activity.Category}) on {activity.Date:dd MMMM yyyy}.\r\n" +
                                   $"Total Paid: R{totalCost:N2} | Invoice No: {invoice.InvoiceNo} | Remaining Seats: {activity.SeatsAvailable}\r\n\r\n" +
                                   formattedInv
            };
        }

        private string FormatInvoiceText(Invoice inv, Booking bk, Activity act)
        {
            var sb = new StringBuilder();
            sb.AppendLine("================================================");
            sb.AppendLine("        BLUE HORIZONS TOURS - SAFARI DESK");
            sb.AppendLine("        OFFICIAL CHATBOT BOOKING INVOICE");
            sb.AppendLine("================================================");
            sb.AppendLine($"  Invoice No    : {inv.InvoiceNo}");
            sb.AppendLine($"  Date Issued   : {inv.IssueDate:dd MMMM yyyy HH:mm}");
            sb.AppendLine($"  Booking ID    : {bk.BookingID}");
            sb.AppendLine("------------------------------------------------");
            sb.AppendLine($"  Visitor       : {_currentUser?.FirstName} {_currentUser?.LastName}");
            sb.AppendLine($"  Email         : {_currentUser?.Email}");
            sb.AppendLine("------------------------------------------------");
            sb.AppendLine($"  Activity      : {act.Name}");
            sb.AppendLine($"  Category      : {act.Category}");
            sb.AppendLine($"  Activity Date : {act.Date:dd MMMM yyyy}");
            sb.AppendLine($"  Participants  : {bk.ParticipantCount}");
            sb.AppendLine($"  Price / Person: R{act.Price:N2}");
            sb.AppendLine($"  TOTAL PAID    : R{inv.Total:N2} (PAID)");
            sb.AppendLine("================================================");
            return sb.ToString();
        }

        // ---------------------------------------------------------------------
        // Natural-Language Booking Intent Parser
        // ---------------------------------------------------------------------

        private bool TryParseNaturalBookingIntent(string message, out Activity matchedActivity, out int pax)
        {
            matchedActivity = null;
            pax = 0;

            string lower = message.ToLowerInvariant();

            // Must contain a booking verb such as "book", "reserve", "buy ticket", "sign me up for"
            bool hasBookVerb = Regex.IsMatch(lower, @"\b(book|reserve|booking|buy\s+tickets?|sign\s+me\s+up)\b");
            if (!hasBookVerb) return false;

            // Ignore pure questions like "how do i book?" or "show my bookings" or "can i cancel a booking"
            if (Regex.IsMatch(lower, @"\b(how\s+do\s+i|how\s+to|my\s+bookings?|view\s+bookings?|show\s+bookings?|what\s+bookings?|cancel)\b"))
                return false;

            List<Activity> activities;
            try { activities = FileService.GetAllActivities(); }
            catch { return false; }

            // Score each activity by how many significant words from its Name appear in the user's message
            int bestScore = 0;
            foreach (var act in activities)
            {
                if (lower.Contains(act.Name.ToLowerInvariant()))
                {
                    matchedActivity = act;
                    bestScore = 100;
                    break;
                }

                string[] words = Regex.Split(act.Name.ToLowerInvariant(), @"\W+")
                    .Where(w => w.Length >= 3 && w != "the" && w != "and" && w != "tour" && w != "day")
                    .ToArray();

                int hits = words.Count(w => lower.Contains(w));
                if (hits > bestScore && hits >= 1)
                {
                    bestScore = hits;
                    matchedActivity = act;
                }
            }

            if (matchedActivity == null) return false;

            // Extract participant count if present (e.g., "for 2", "2 people", "3 pax", "2 seats", "x2")
            var paxMatch = Regex.Match(lower, @"(?:for\s+|x\s*)(\d{1,2})\b|\b(\d{1,2})\s*(?:people|person|pax|guests?|seats?|tickets?|participants?|adults?)");
            if (paxMatch.Success)
            {
                string val = !string.IsNullOrEmpty(paxMatch.Groups[1].Value)
                    ? paxMatch.Groups[1].Value
                    : paxMatch.Groups[2].Value;
                int.TryParse(val, out pax);
            }

            return true;
        }

        // ---------------------------------------------------------------------
        // External AI API Caller (Google Gemini / OpenAI / Groq REST APIs)
        // ---------------------------------------------------------------------

        private async Task<string> CallAiApiAsync(string apiKey, string userMessage)
        {
            string systemPrompt = BuildSafariSystemPrompt();

            if (apiKey.StartsWith("AIza", StringComparison.Ordinal))
            {
                // Google Gemini REST API
                string url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent?key={ Uri.EscapeDataString(apiKey) }";
                string combinedPrompt = systemPrompt + "\n\nVisitor Message: " + userMessage;
                string jsonBody = "{\"contents\":[{\"parts\":[{\"text\":\"" + EscapeJson(combinedPrompt) + "\"}]}],\"generationConfig\":{\"temperature\":0.3,\"maxOutputTokens\":600}}";

                using (var content = new StringContent(jsonBody, Encoding.UTF8, "application/json"))
                {
                    var resp = await _http.PostAsync(url, content);
                    string respText = await resp.Content.ReadAsStringAsync();
                    if (!resp.IsSuccessStatusCode)
                        throw new Exception($"Gemini HTTP {(int)resp.StatusCode}");

                    return ExtractJsonTextValue(respText, "text");
                }
            }
            else
            {
                // OpenAI, Groq, or OpenRouter Chat Completions API
                string endpoint = apiKey.StartsWith("gsk_", StringComparison.Ordinal)
                    ? "https://api.groq.com/openai/v1/chat/completions"
                    : apiKey.StartsWith("sk-or-", StringComparison.Ordinal)
                        ? "https://openrouter.ai/api/v1/chat/completions"
                        : "https://api.openai.com/v1/chat/completions";
                string model = apiKey.StartsWith("gsk_", StringComparison.Ordinal)
                    ? "llama-3.3-70b-versatile"
                    : apiKey.StartsWith("sk-or-", StringComparison.Ordinal)
                        ? "meta-llama/llama-3.1-8b-instruct:free"
                        : "gpt-4o-mini";

                string jsonBody = "{" +
                    "\"model\":\"" + model + "\"," +
                    "\"temperature\":0.3," +
                    "\"messages\":[" +
                        "{\"role\":\"system\",\"content\":\"" + EscapeJson(systemPrompt) + "\"}," +
                        "{\"role\":\"user\",\"content\":\"" + EscapeJson(userMessage) + "\"}" +
                    "]}";

                using (var req = new HttpRequestMessage(HttpMethod.Post, endpoint))
                {
                    req.Headers.Add("Authorization", "Bearer " + apiKey);
                    req.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                    var resp = await _http.SendAsync(req);
                    string respText = await resp.Content.ReadAsStringAsync();
                    if (!resp.IsSuccessStatusCode)
                        throw new Exception($"AI API HTTP {(int)resp.StatusCode}");

                    return ExtractJsonTextValue(respText, "content");
                }
            }
        }

        private string BuildSafariSystemPrompt()
        {
            var sb = new StringBuilder();
            sb.AppendLine("You are 'SafariScout AI', the official Safari & Tour Booking AI Concierge inside the Blue Horizons Tours application (Cape Town, South Africa).");
            sb.AppendLine("STRICT THEME & DOMAIN RULES:");
            sb.AppendLine("1. You ONLY assist with Blue Horizons Tours: Safari tours, Adventures, Hiking Trails, Events, prices (in ZAR / R), dates, available seats, making bookings, checking the visitor's bookings, invoices, and profile/login help.");
            sb.AppendLine("2. If the user asks about ANYTHING unrelated to safaris, tourism, Cape Town tours, or Blue Horizons bookings (e.g., general math, coding, essays, politics, sports, cooking), politely refuse in 1-2 sentences and steer them back to Blue Horizons Safari & Tour bookings.");
            sb.AppendLine("3. Keep answers friendly, concise, and easy to read in plain text (avoid heavy markdown tables).");
            sb.AppendLine("4. If the user asks to book a specific activity AND specifies the number of participants, include this exact tag at the end of your reply: [BOOK_NOW: <ActivityID> | <Participants>]");
            sb.AppendLine();

            if (_currentUser != null)
            {
                sb.AppendLine($"CURRENT LOGGED-IN VISITOR: {_currentUser.FirstName} {_currentUser.LastName} ({_currentUser.Email})");
            }

            try
            {
                var activities = FileService.GetAllActivities();
                sb.AppendLine("LIVE ACTIVITIES IN SYSTEM (Data/activities.txt):");
                foreach (var a in activities)
                {
                    sb.AppendLine($"- ID: {a.ActivityID} | Category: {a.Category} | Name: {a.Name} | Price: R{a.Price:N2} | Date: {a.Date:dd MMM yyyy} | Seats Left: {a.SeatsAvailable}/{a.TotalSeats} | Desc: {a.Description}");
                }

                if (_currentUser != null)
                {
                    var bookings = FileService.GetAllBookings()
                        .Where(b => b.UserID == _currentUser.UserID)
                        .ToList();
                    sb.AppendLine($"VISITOR'S CURRENT BOOKINGS ({bookings.Count}):");
                    foreach (var b in bookings)
                    {
                        var act = activities.FirstOrDefault(x => x.ActivityID == b.ActivityID);
                        string actName = act != null ? act.Name : b.ActivityID;
                        sb.AppendLine($"- BookingID: {b.BookingID} | Activity: {actName} | Pax: {b.ParticipantCount} | Total: R{b.TotalCost:N2} | Payment: {b.PaymentStatus} | Attendance: {b.Attendance}");
                    }
                }
            }
            catch { }

            return sb.ToString();
        }

        // ---------------------------------------------------------------------
        // Built-in Smart Safari & Booking Engine (Offline / Zero-Key Support)
        // ---------------------------------------------------------------------

        private ChatbotResponse GenerateLocalSafariReply(string userMessage)
        {
            string lower = userMessage.ToLowerInvariant();

            // 1. Check for off-topic queries outside Safari / Blue Horizons Tours
            if (IsOffTopicQuery(lower))
            {
                return new ChatbotResponse
                {
                    ReplyText = "Habari! I'm SafariScout AI, your dedicated Blue Horizons Tours & Safari Concierge! 🦁\r\n" +
                                "I'm themed exclusively to help with our Safari tours, Adventures, Hiking Trails, Events, pricing, and bookings.\r\n\r\n" +
                                "Try asking me:\r\n" +
                                "• 'What safaris are available?'\r\n" +
                                "• 'Show all tours and prices'\r\n" +
                                "• 'Book Big Five Morning Safari for 2'\r\n" +
                                "• 'Show my bookings'"
                };
            }

            List<Activity> activities = new List<Activity>();
            try { activities = FileService.GetAllActivities(); } catch { }

            // 2. Greeting / Help
            if (Regex.IsMatch(lower, @"^(hi|hello|hey|sawubona|good\s+(morning|afternoon|evening)|help|menu|start)\b"))
            {
                string name = _currentUser != null ? _currentUser.FirstName : "Explorer";
                return new ChatbotResponse
                {
                    ReplyText = $"Jambo & Habari, {name}! 🦁 I'm your Blue Horizons Safari & Booking Assistant.\r\n\r\n" +
                                "Here is what I can do for you right here in chat:\r\n" +
                                "1. List live Safaris, Adventures, Hiking Trails & Events with ZAR prices and remaining seats.\r\n" +
                                "2. Book any tour for you immediately — just type:\r\n" +
                                "   \"Book [Activity Name] for [Number] people\"\r\n" +
                                "   (or use the Quick-Book bar right below this chat!).\r\n" +
                                "3. Check your existing confirmed bookings and invoices.\r\n\r\n" +
                                "Which safari or tour experience are you interested in today?"
                };
            }

            // 3. User's own bookings ("my bookings", "my reservations", "my invoices")
            if (Regex.IsMatch(lower, @"\b(my\s+bookings?|my\s+reservations?|my\s+trips?|my\s+tickets?|what\s+have\s+i\s+booked|my\s+invoices?)\b"))
            {
                if (_currentUser == null)
                {
                    return new ChatbotResponse { ReplyText = "Please log in to your Visitor account to view your personal safari bookings." };
                }

                var myBookings = FileService.GetAllBookings()
                    .Where(b => b.UserID == _currentUser.UserID && b.PaymentStatus != "Cancelled")
                    .OrderByDescending(b => b.BookingDate)
                    .ToList();

                if (myBookings.Count == 0)
                {
                    return new ChatbotResponse
                    {
                        ReplyText = $"You don't have any active bookings yet, {_currentUser.FirstName}.\r\n" +
                                    "Would you like to book one now? Try typing 'Show Safaris' or 'Book Big Five Morning Safari for 2'!"
                    };
                }

                var sb = new StringBuilder();
                sb.AppendLine($"You have {myBookings.Count} confirmed booking(s) with Blue Horizons Tours:\r\n");
                foreach (var b in myBookings)
                {
                    var act = activities.FirstOrDefault(a => a.ActivityID == b.ActivityID);
                    string actName = act != null ? act.Name : "Tour Activity";
                    string actDate = act != null ? act.Date.ToString("dd MMM yyyy") : "TBA";
                    sb.AppendLine($"• {actName} ({actDate})");
                    sb.AppendLine($"  Participants: {b.ParticipantCount} | Total: R{b.TotalCost:N2} | Status: {b.PaymentStatus} | Attendance: {b.Attendance}");
                }
                return new ChatbotResponse { ReplyText = sb.ToString().Trim() };
            }

            // 4. How to book / payment / invoice questions
            if (Regex.IsMatch(lower, @"\b(how\s+do\s+i\s+book|how\s+to\s+book|payment|pay|invoice|refund|cancel)\b"))
            {
                return new ChatbotResponse
                {
                    ReplyText = "Booking a Safari or Tour with Blue Horizons is super easy:\r\n\r\n" +
                                "• Option 1 (Right here in Chat): Type \"Book [Activity Name] for [Number]\" (for example: \"Book Big Five Morning Safari for 2\") OR select an activity in the Quick-Book bar below and click '⚡ Book & Pay'.\r\n" +
                                "• Option 2 (Step-by-Step Dashboard): Click '↗ Open in Step-by-Step' below (or 'Browse Activities' on the left sidebar) to review seats, proceed to payment, and print/save your official invoice."
                };
            }

            // 5. Specific activity match (if user asks about a specific tour's price, date, seats, description)
            foreach (var act in activities)
            {
                string[] keywords = Regex.Split(act.Name.ToLowerInvariant(), @"\W+")
                    .Where(w => w.Length >= 4 && w != "tour" && w != "safari" && w != "trail" && w != "cape")
                    .ToArray();

                if (lower.Contains(act.Name.ToLowerInvariant()) || keywords.Any(k => lower.Contains(k)))
                {
                    string seatStatus = act.SeatsAvailable > 0 ? $"{act.SeatsAvailable} of {act.TotalSeats} seats available" : "SOLD OUT";
                    return new ChatbotResponse
                    {
                        ReplyText = $"🦁 {act.Name} ({act.Category})\r\n" +
                                    $"• Description: {act.Description}\r\n" +
                                    $"• Date: {act.Date:dddd, dd MMMM yyyy}\r\n" +
                                    $"• Price: R{act.Price:N2} per person\r\n" +
                                    $"• Availability: {seatStatus}\r\n\r\n" +
                                    (act.SeatsAvailable > 0
                                        ? $"To book this right now, reply:\r\n\"Book {act.Name} for 2\" (or pick it in the Quick-Book bar below!)"
                                        : "Unfortunately this session is sold out, but I can show you other available safaris!")
                    };
                }
            }

            // 6. Category filters (Safari, Adventure, Hiking Trail, Event, Cheap/Budget)
            if (lower.Contains("safari") || lower.Contains("game drive") || lower.Contains("big five") || lower.Contains("wildlife") || lower.Contains("animal"))
            {
                var safaris = activities.Where(a => a.Category.Equals("Safari", StringComparison.OrdinalIgnoreCase)).ToList();
                return FormatActivityListReply("🦁 Available Safari Experiences:", safaris);
            }

            if (lower.Contains("hik") || lower.Contains("mountain") || lower.Contains("trail"))
            {
                var hikes = activities.Where(a => a.Category.Equals("Hiking Trail", StringComparison.OrdinalIgnoreCase)).ToList();
                return FormatActivityListReply("🥾 Available Hiking Trails:", hikes);
            }

            if (lower.Contains("adventure") || lower.Contains("kayak") || lower.Contains("shark") || lower.Contains("dive"))
            {
                var advs = activities.Where(a => a.Category.Equals("Adventure", StringComparison.OrdinalIgnoreCase)).ToList();
                return FormatActivityListReply("🌊 Available Adventure Tours:", advs);
            }

            if (lower.Contains("event") || lower.Contains("wine") || lower.Contains("festival") || lower.Contains("sunset") || lower.Contains("jazz"))
            {
                var events = activities.Where(a => a.Category.Equals("Event", StringComparison.OrdinalIgnoreCase)).ToList();
                return FormatActivityListReply("🎉 Available Special Events:", events);
            }

            if (lower.Contains("price") || lower.Contains("cost") || lower.Contains("cheap") || lower.Contains("how much") ||
                lower.Contains("available") || lower.Contains("seat") || lower.Contains("all") || lower.Contains("tour") || lower.Contains("activity") || lower.Contains("activities") || lower.Contains("list"))
            {
                return FormatActivityListReply("🌍 All Live Blue Horizons Safaris & Tours:", activities);
            }

            // 7. Default Safari-themed guidance
            return new ChatbotResponse
            {
                ReplyText = "I specialize in Blue Horizons Tours & Safari bookings! 🦁\r\n\r\n" +
                            "You can ask me about:\r\n" +
                            "• 'Show available Safaris'\r\n" +
                            "• 'Show all tours and prices'\r\n" +
                            "• 'My bookings'\r\n" +
                            "• Or book directly by typing: 'Book Big Five Morning Safari for 2'!"
            };
        }

        private ChatbotResponse FormatActivityListReply(string heading, List<Activity> list)
        {
            if (list == null || list.Count == 0)
            {
                return new ChatbotResponse { ReplyText = "No matching activities were found in Data/activities.txt right now." };
            }

            var sb = new StringBuilder();
            sb.AppendLine(heading);
            sb.AppendLine();
            foreach (var a in list)
            {
                string seats = a.SeatsAvailable > 0 ? $"{a.SeatsAvailable} seats left" : "SOLD OUT";
                sb.AppendLine($"• {a.Name} [{a.Category}]");
                sb.AppendLine($"  Date: {a.Date:dd MMM yyyy} | Price: R{a.Price:N2} pp | {seats}");
                sb.AppendLine($"  \"{a.Description}\"");
                sb.AppendLine();
            }
            sb.AppendLine("💡 Tip: Reply \"Book <Activity Name> for <Pax>\" (e.g., \"Book " + list[0].Name + " for 2\") or use the Quick-Book bar below to book immediately!");
            return new ChatbotResponse { ReplyText = sb.ToString().Trim() };
        }

        private bool IsOffTopicQuery(string lower)
        {
            // Common off-topic domains unrelated to safari/tourism/bookings
            return Regex.IsMatch(lower, @"\b(write\s+code|python|javascript|c\+\+|java\b|homework|calculus|algebra|solve\s+this\s+equation|president|prime\s+minister|election|bitcoin|crypto|stock\s+market|recipe\s+for|football|soccer\s+score|champions\s+league|fortnite|minecraft)\b");
        }

        // ---------------------------------------------------------------------
        // Minimal Dependency-Free JSON Helpers (.NET Framework 4.7.2)
        // ---------------------------------------------------------------------

        private static string EscapeJson(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            return s
                .Replace("\\", "\\\\")
                .Replace("\"", "\\\"")
                .Replace("\r", "\\r")
                .Replace("\n", "\\n")
                .Replace("\t", "\\t");
        }

        private static string ExtractJsonTextValue(string json, string fieldName)
        {
            if (string.IsNullOrEmpty(json)) return string.Empty;
            var match = Regex.Match(json, "\"" + Regex.Escape(fieldName) + "\"\\s*:\\s*\"((?:\\\\.|[^\"\\\\])*)\"");
            if (!match.Success) return string.Empty;

            string raw = match.Groups[1].Value;
            return raw
                .Replace("\\r\\n", "\r\n")
                .Replace("\\n", "\r\n")
                .Replace("\\r", "\r\n")
                .Replace("\\t", "\t")
                .Replace("\\\"", "\"")
                .Replace("\\\\", "\\");
        }
    }
}
