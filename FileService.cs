// =============================================================================
// Services/FileService.cs
// All file I/O for the Tourism & Visitor Information Management System.
//
// Data folder: <ExecutableDirectory>\Data\
// Files       : users.txt | activities.txt | bookings.txt | invoices.txt
//
// Every public method re-reads from disk so that both dashboards always
// see the most up-to-date data (no in-memory caching).
// Fields are pipe-delimited (|). Pipe characters inside field values are
// escaped as \PIPE\ on write and unescaped on read.
// =============================================================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using PROJECTT.Models;

namespace PROJECTT.Services
{
    /// <summary>
    /// Handles all reading and writing of pipe-delimited flat files.
    /// Call <see cref="EnsureDataFolder"/> once at application start-up.
    /// </summary>
    public static class FileService
    {
        // -----------------------------------------------------------------------
        // Paths
        // -----------------------------------------------------------------------

        /// <summary>
        /// Absolute path to the Data folder beside the executable.
        /// Created automatically if it does not exist.
        /// </summary>
        public static string DataFolder
        {
            get
            {
                string asmDir = Path.GetDirectoryName(typeof(FileService).Assembly.Location);
                if (!string.IsNullOrEmpty(asmDir) && Directory.Exists(Path.Combine(asmDir, "Data")))
                {
                    return Path.Combine(asmDir, "Data");
                }
                return Path.Combine(Application.StartupPath, "Data");
            }
        }

        // Convenience path helpers – used internally and by SeedService.
        public static string UsersFile      => Path.Combine(DataFolder, "users.txt");
        public static string ActivitiesFile => Path.Combine(DataFolder, "activities.txt");
        public static string BookingsFile   => Path.Combine(DataFolder, "bookings.txt");
        public static string InvoicesFile   => Path.Combine(DataFolder, "invoices.txt");

        // Pipe character and its escape sequence.
        private const string PipeEscape = @"\PIPE\";

        // -----------------------------------------------------------------------
        // Initialisation
        // -----------------------------------------------------------------------

        /// <summary>
        /// Creates the Data folder and all four empty data files if any are missing.
        /// Call this from Program.Main before opening any form.
        /// </summary>
        public static void EnsureDataFolder()
        {
            // Create the folder hierarchy if it does not already exist.
            if (!Directory.Exists(DataFolder))
                Directory.CreateDirectory(DataFolder);

            // Create each file as empty if it does not yet exist.
            EnsureFile(UsersFile);
            EnsureFile(ActivitiesFile);
            EnsureFile(BookingsFile);
            EnsureFile(InvoicesFile);
        }

        // -----------------------------------------------------------------------
        // USER CRUD
        // -----------------------------------------------------------------------

        /// <summary>
        /// Reads and returns all users from users.txt.
        /// Every call re-reads from disk.
        /// </summary>
        public static List<User> GetAllUsers()
        {
            var list = new List<User>();

            foreach (string line in SafeReadLines(UsersFile))
            {
                string[] p = SplitLine(line, 8);
                if (p == null) continue;

                list.Add(new User
                {
                    UserID       = p[0],
                    FirstName    = p[1],
                    LastName     = p[2],
                    Email        = p[3],
                    Phone        = p[4],
                    Gender       = p[5],
                    PasswordHash = p[6],
                    Role         = p[7]
                });
            }

            return list;
        }

        /// <summary>
        /// Appends a new user record to users.txt.
        /// </summary>
        public static void AddUser(User user)
        {
            string line = JoinFields(
                user.UserID,
                user.FirstName,
                user.LastName,
                user.Email,
                user.Phone,
                user.Gender,
                user.PasswordHash,
                user.Role);

            File.AppendAllText(UsersFile, line + Environment.NewLine);
        }

        /// <summary>
        /// Overwrites the entire users.txt with the supplied list.
        /// Use when updating or deleting a user record.
        /// </summary>
        public static void SaveAllUsers(List<User> users)
        {
            var lines = new List<string>();
            foreach (var u in users)
            {
                lines.Add(JoinFields(
                    u.UserID,
                    u.FirstName,
                    u.LastName,
                    u.Email,
                    u.Phone,
                    u.Gender,
                    u.PasswordHash,
                    u.Role));
            }
            File.WriteAllLines(UsersFile, lines);
        }

        // -----------------------------------------------------------------------
        // ACTIVITY CRUD
        // -----------------------------------------------------------------------

        /// <summary>
        /// Reads and returns all activities from activities.txt.
        /// Every call re-reads from disk.
        /// </summary>
        public static List<Activity> GetAllActivities()
        {
            var list = new List<Activity>();

            foreach (string line in SafeReadLines(ActivitiesFile))
            {
                string[] p = SplitLine(line, 8);
                if (p == null) continue;

                list.Add(new Activity
                {
                    ActivityID     = p[0],
                    Category       = p[1],
                    Name           = p[2],
                    Description    = p[3],
                    Price          = ParseDecimal(p[4]),
                    Date           = ParseDateTime(p[5]),
                    TotalSeats     = ParseInt(p[6]),
                    SeatsAvailable = ParseInt(p[7])
                });
            }

            return list;
        }

        /// <summary>
        /// Appends a new activity record to activities.txt.
        /// </summary>
        public static void AddActivity(Activity activity)
        {
            string line = JoinFields(
                activity.ActivityID,
                activity.Category,
                activity.Name,
                activity.Description,
                activity.Price.ToString("F2"),
                activity.Date.ToString("o"),        // ISO 8601
                activity.TotalSeats.ToString(),
                activity.SeatsAvailable.ToString());

            File.AppendAllText(ActivitiesFile, line + Environment.NewLine);
        }

        /// <summary>
        /// Overwrites activities.txt with the supplied list.
        /// Use when editing seat counts or other fields.
        /// </summary>
        public static void SaveAllActivities(List<Activity> activities)
        {
            var lines = new List<string>();
            foreach (var a in activities)
            {
                lines.Add(JoinFields(
                    a.ActivityID,
                    a.Category,
                    a.Name,
                    a.Description,
                    a.Price.ToString("F2"),
                    a.Date.ToString("o"),
                    a.TotalSeats.ToString(),
                    a.SeatsAvailable.ToString()));
            }
            File.WriteAllLines(ActivitiesFile, lines);
        }

        // -----------------------------------------------------------------------
        // BOOKING CRUD
        // -----------------------------------------------------------------------

        /// <summary>
        /// Reads and returns all bookings from bookings.txt.
        /// Every call re-reads from disk.
        /// </summary>
        public static List<Booking> GetAllBookings()
        {
            var list = new List<Booking>();

            foreach (string line in SafeReadLines(BookingsFile))
            {
                string[] p = SplitLine(line, 8);
                if (p == null) continue;

                list.Add(new Booking
                {
                    BookingID        = p[0],
                    UserID           = p[1],
                    ActivityID       = p[2],
                    BookingDate      = ParseDateTime(p[3]),
                    ParticipantCount = ParseInt(p[4]),
                    TotalCost        = ParseDecimal(p[5]),
                    PaymentStatus    = p[6],
                    Attendance       = p[7]
                });
            }

            return list;
        }

        /// <summary>
        /// Appends a new booking record to bookings.txt.
        /// </summary>
        public static void AddBooking(Booking booking)
        {
            string line = JoinFields(
                booking.BookingID,
                booking.UserID,
                booking.ActivityID,
                booking.BookingDate.ToString("o"),
                booking.ParticipantCount.ToString(),
                booking.TotalCost.ToString("F2"),
                booking.PaymentStatus,
                booking.Attendance);

            File.AppendAllText(BookingsFile, line + Environment.NewLine);
        }

        /// <summary>
        /// Overwrites bookings.txt with the supplied list.
        /// Use when updating payment or attendance status.
        /// </summary>
        public static void SaveAllBookings(List<Booking> bookings)
        {
            var lines = new List<string>();
            foreach (var b in bookings)
            {
                lines.Add(JoinFields(
                    b.BookingID,
                    b.UserID,
                    b.ActivityID,
                    b.BookingDate.ToString("o"),
                    b.ParticipantCount.ToString(),
                    b.TotalCost.ToString("F2"),
                    b.PaymentStatus,
                    b.Attendance));
            }
            File.WriteAllLines(BookingsFile, lines);
        }

        /// <summary>
        /// Automated 'No Show' Status Check:
        /// If an activity's scheduled date has passed and a booked user's status
        /// is not currently marked as 'Attended', automatically updates and saves
        /// their status to 'No Show' in the data store (bookings.txt).
        /// Returns the number of bookings updated.
        /// </summary>
        public static int AutoUpdateNoShowBookings()
        {
            try
            {
                var activities = GetAllActivities();
                if (activities == null || activities.Count == 0) return 0;

                var actDict = new Dictionary<string, Activity>(StringComparer.OrdinalIgnoreCase);
                foreach (var a in activities)
                {
                    if (!string.IsNullOrEmpty(a.ActivityID))
                        actDict[a.ActivityID] = a;
                }

                var bookings = GetAllBookings();
                if (bookings == null || bookings.Count == 0) return 0;

                bool modified = false;
                int updatedCount = 0;
                DateTime now = DateTime.Now;

                foreach (var b in bookings)
                {
                    if (string.IsNullOrEmpty(b.ActivityID)) continue;

                    if (actDict.TryGetValue(b.ActivityID, out var act))
                    {
                        // Check if event's scheduled date has passed
                        if (act.Date < now)
                        {
                            // If booked user's status is not currently marked as 'Attended'
                            if (!string.Equals(b.Attendance, "Attended", StringComparison.OrdinalIgnoreCase))
                            {
                                if (!string.Equals(b.Attendance, "No Show", StringComparison.OrdinalIgnoreCase))
                                {
                                    b.Attendance = "No Show";
                                    modified = true;
                                    updatedCount++;
                                }
                            }
                        }
                    }
                }

                if (modified)
                {
                    SaveAllBookings(bookings);
                }

                return updatedCount;
            }
            catch
            {
                return 0;
            }
        }

        // -----------------------------------------------------------------------
        // INVOICE CRUD
        // -----------------------------------------------------------------------

        /// <summary>
        /// Reads and returns all invoices from invoices.txt.
        /// Every call re-reads from disk.
        /// </summary>
        public static List<Invoice> GetAllInvoices()
        {
            var list = new List<Invoice>();

            foreach (string line in SafeReadLines(InvoicesFile))
            {
                string[] p = SplitLine(line, 6);
                if (p == null) continue;

                list.Add(new Invoice
                {
                    InvoiceNo  = p[0],
                    BookingID  = p[1],
                    UserID     = p[2],
                    IssueDate  = ParseDateTime(p[3]),
                    Details    = p[4],
                    Total      = ParseDecimal(p[5])
                });
            }

            return list;
        }

        /// <summary>
        /// Appends a new invoice record to invoices.txt.
        /// </summary>
        public static void AddInvoice(Invoice invoice)
        {
            string line = JoinFields(
                invoice.InvoiceNo,
                invoice.BookingID,
                invoice.UserID,
                invoice.IssueDate.ToString("o"),
                invoice.Details,
                invoice.Total.ToString("F2"));

            File.AppendAllText(InvoicesFile, line + Environment.NewLine);
        }

        /// <summary>
        /// Overwrites invoices.txt with the supplied list.
        /// </summary>
        public static void SaveAllInvoices(List<Invoice> invoices)
        {
            var lines = new List<string>();
            foreach (var inv in invoices)
            {
                lines.Add(JoinFields(
                    inv.InvoiceNo,
                    inv.BookingID,
                    inv.UserID,
                    inv.IssueDate.ToString("o"),
                    inv.Details,
                    inv.Total.ToString("F2")));
            }
            File.WriteAllLines(InvoicesFile, lines);
        }

        // -----------------------------------------------------------------------
        // Private helpers
        // -----------------------------------------------------------------------

        /// <summary>Creates an empty file if it does not already exist.</summary>
        private static void EnsureFile(string path)
        {
            if (!File.Exists(path))
                File.WriteAllText(path, string.Empty);
        }

        /// <summary>
        /// Reads all non-empty lines from a file.
        /// Returns an empty array if the file does not exist or cannot be read.
        /// </summary>
        private static IEnumerable<string> SafeReadLines(string path)
        {
            if (!File.Exists(path))
                return new string[0];

            try
            {
                return File.ReadAllLines(path);
            }
            catch
            {
                return new string[0];
            }
        }

        /// <summary>
        /// Splits a pipe-delimited line and unescapes \PIPE\ sequences.
        /// Returns null if the line is blank or has fewer fields than expected.
        /// </summary>
        private static string[] SplitLine(string line, int expectedFields)
        {
            if (string.IsNullOrWhiteSpace(line))
                return null;

            string[] parts = line.Split('|');
            if (parts.Length < expectedFields)
                return null;

            // Unescape \PIPE\ back to a literal pipe character in every field.
            for (int i = 0; i < parts.Length; i++)
                parts[i] = parts[i].Replace(PipeEscape, "|");

            return parts;
        }

        /// <summary>
        /// Joins field values with pipe delimiters, escaping any pipe characters
        /// that appear inside a field value.
        /// </summary>
        private static string JoinFields(params string[] fields)
        {
            string[] escaped = new string[fields.Length];
            for (int i = 0; i < fields.Length; i++)
                escaped[i] = (fields[i] ?? string.Empty).Replace("|", PipeEscape);

            return string.Join("|", escaped);
        }

        // Parsing helpers – return safe defaults rather than throwing.
        private static decimal  ParseDecimal(string s)  { decimal  v; return decimal.TryParse(s, out v)  ? v : 0m; }
        private static int      ParseInt(string s)       { int      v; return int.TryParse(s, out v)      ? v : 0;  }
        private static DateTime ParseDateTime(string s)  { DateTime v; return DateTime.TryParse(s, out v) ? v : DateTime.MinValue; }
    }
}
