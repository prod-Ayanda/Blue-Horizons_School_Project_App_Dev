// =============================================================================
// Forms/VisitorDashboardForm.cs
// Blue Horizons Tours – Visitor Dashboard (Stage 3)
//
// All UI is built in code (no Designer involvement) via BuildUI() so the
// Designer.cs stays minimal.  Navigation is sidebar-driven; one content
// panel is visible at a time.
//
// Panels
//   pnlHome        – welcome stats, quick-browse button
//   pnlBrowse      – activity DataGridView + category filter + search
//   pnlBook        – activity details, participant count, seat check
//   pnlPayment     – booking summary, simulated Pay Now
//   pnlInvoice     – formatted invoice + Print / Save-as-text
//   pnlMyBookings  – user's bookings DataGridView
//   pnlProfile     – update email, phone, password
// =============================================================================

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PROJECTT.Models;
using PROJECTT.Services;

namespace PROJECTT.Forms
{
    /// <summary>
    /// Full visitor dashboard: browse, book, pay, invoice, bookings, profile.
    /// </summary>
    public partial class VisitorDashboardForm : Form, IMessageFilter
    {
        // ── State ──────────────────────────────────────────────────────────
        private readonly User _currentUser;
        private Activity     _selectedActivity;  // set when user picks an activity
        private Booking      _currentBooking;    // set after payment
        private Invoice      _currentInvoice;    // set after payment
        private List<string> _lastTicketNumbers = new List<string>();
        private string _lastTicketsFolder = "";
        private bool _paymentBusy = false;
        private SafariChatbotForm _chatbotPopup; // floating AI Safari Concierge popup

        // Inactivity Timer (5 Minutes = 300,000 ms)
        private System.Windows.Forms.Timer _inactivityTimer;
        private const int InactivityTimeoutMs = 300000;

        // Auto-refresh Timer (5 Seconds = 5,000 ms)
        private System.Windows.Forms.Timer _refreshTimer;

        // Real-time clock Timer (1 Second = 1,000 ms)
        private System.Windows.Forms.Timer _clockTimer;

        // ── Shared colour / font constants (Kexsio + Kokonut + Bklit Safari Dark Glass) ──
        private static readonly Color Teal        = Color.FromArgb(16, 185, 129);
        private static readonly Color DarkTeal    = Color.FromArgb(9,  12,  20);
        private static readonly Color SidebarTop  = Color.FromArgb(13, 17,  28);
        private static readonly Color LogoutRed   = Color.FromArgb(190, 38,  52);
        private static readonly Color LightGray   = Color.FromArgb(6,   8,  14);
        private static readonly Color TextGray    = Color.FromArgb(165, 175, 205);

        private int _cachedTotalBookings = 0;
        private int _cachedUpcomingBookings = 0;
        private decimal _cachedTotalSpent = 0m;
        private List<Activity> _cachedActivities = new List<Activity>();
        private static readonly Font  FontHeading = new Font("Arial", 18F, FontStyle.Bold);
        private static readonly Font  FontLabel   = new Font("Arial",  9F, FontStyle.Bold);
        private static readonly Font  FontField   = new Font("Arial", 10F);
        private static readonly Font  FontBtn     = new Font("Arial", 11F, FontStyle.Bold);
        private static readonly Font  FontNav     = new Font("Arial", 10F);
        private static readonly Font  FontSmall   = new Font("Arial",  8.5F);

        // ── Constructors (Parameterless constructor enables Visual Studio GUI Designer) ──

        /// <summary>The visitor currently signed in.</summary>
        public User LoggedInUser => _currentUser;

        public VisitorDashboardForm()
        {
            InitializeComponent();
            FileService.AutoUpdateNoShowBookings();
            InitClockTimer();
            SetupRuntimeGridAndCombos();
            ConfigureResponsiveScaling();
            ApplySafariDarkGlassTheme();
        }

        private void InitClockTimer()
        {
            if (lblDashboardLocation != null)
            {
                lblDashboardLocation.Text = "📍 Durban, KwaZulu-Natal";
            }

            _clockTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            _clockTimer.Tick += (s, e) => UpdateDashboardClock();
            _clockTimer.Start();
            UpdateDashboardClock();
        }

        private void UpdateDashboardClock()
        {
            if (lblDashboardClock != null)
            {
                lblDashboardClock.Text = DateTime.Now.ToString("dddd, dd MMM yyyy • HH:mm:ss");
            }
            if (lblDashboardLocation != null && (string.IsNullOrEmpty(lblDashboardLocation.Text) || lblDashboardLocation.Text == "Label"))
            {
                lblDashboardLocation.Text = "📍 Durban, KwaZulu-Natal";
            }
        }

        public VisitorDashboardForm(User user) : this()
        {
            _currentUser = user;

            // Security Check: Enforce Role = Visitor/User (Admin can NEVER open VisitorDashboardForm)
            if (user != null && string.Equals(user.Role, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                this.Load += (s, e) =>
                {
                    MessageBox.Show("Access denied. Administrators cannot access the visitor portal.", "Security Alert",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Hide();
                    var adminDash = new AdminDashboardForm(user);
                    adminDash.FormClosed += (s2, e2) => this.Close();
                    adminDash.Show();
                };
                return;
            }

            this.Text = $"Blue Horizons Tours – {user?.FirstName} {user?.LastName}";
            lblSidebarUser.Text = $"Welcome, {user?.FirstName}";
            lblHomeWelcome.Text = $"Welcome back, {user?.FirstName}!";

            // Register Message Filter for 5-Minute Inactivity Auto-Logout
            Application.AddMessageFilter(this);
            InitInactivityTimer();

            // 5-second automatic refresh timer for Browse Activities and bookings
            _refreshTimer = new System.Windows.Forms.Timer { Interval = 5000 };
            _refreshTimer.Tick += (s, e) =>
            {
                FileService.AutoUpdateNoShowBookings();
                if (pnlBrowse != null && pnlBrowse.Visible) LoadActivities();
                if (pnlHome != null && pnlHome.Visible) RefreshHomeStats();
                if (pnlMyBookings != null && pnlMyBookings.Visible) LoadMyBookings();
            };
            _refreshTimer.Start();

            this.Activated += (s, e) =>
            {
                FileService.AutoUpdateNoShowBookings();
                if (pnlBrowse != null && pnlBrowse.Visible) LoadActivities();
                RefreshHomeStats();
            };

            ShowPanel(pnlHome);
            RefreshHomeStats();
        }

        private void SetupRuntimeGridAndCombos()
        {
            if (cboCategoryFilter != null && cboCategoryFilter.Items.Count == 0)
            {
                cboCategoryFilter.Items.AddRange(new object[] { "All", "Safari", "Adventure", "Event", "Hiking Trail" });
                cboCategoryFilter.SelectedIndex = 0;
            }

            if (cmbContactSubject != null && cmbContactSubject.Items.Count == 0)
            {
                cmbContactSubject.Items.AddRange(new object[]
                {
                    "General Inquiry",
                    "Safari Booking Assistance",
                    "Group / Private Tour Request",
                    "Payment & Ticket Support",
                    "Feedback & Suggestions"
                });
                cmbContactSubject.SelectedIndex = 0;
            }

            SetupTouristBookingValidation();

            if (dgvActivities != null && dgvActivities.Columns.Count == 0)
            {
                ConfigureGridStyle(dgvActivities, Color.FromArgb(246, 252, 250));
                dgvActivities.Columns.Add(new DataGridViewTextBoxColumn { Name = "ActivityID", Visible = false });
                dgvActivities.Columns.Add(new DataGridViewTextBoxColumn { Name = "Category",   HeaderText = "Category",    FillWeight = 80 });
                dgvActivities.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name",       HeaderText = "Activity",    FillWeight = 140 });
                dgvActivities.Columns.Add(new DataGridViewTextBoxColumn { Name = "Description",HeaderText = "Description", FillWeight = 200 });
                dgvActivities.Columns.Add(new DataGridViewTextBoxColumn { Name = "Price",      HeaderText = "Price (ZAR)", FillWeight = 75 });
                dgvActivities.Columns.Add(new DataGridViewTextBoxColumn { Name = "Date",       HeaderText = "Date",        FillWeight = 90 });
                dgvActivities.Columns.Add(new DataGridViewTextBoxColumn { Name = "Seats",      HeaderText = "Seats Left",  FillWeight = 75 });
                dgvActivities.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            if (dgvMyBookings != null && dgvMyBookings.Columns.Count == 0)
            {
                ConfigureGridStyle(dgvMyBookings, Color.FromArgb(246, 252, 250));
                dgvMyBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "Activity",  HeaderText = "Activity",        FillWeight = 190 });
                dgvMyBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "ActDate",   HeaderText = "Activity Date",   FillWeight = 100 });
                dgvMyBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "Pax",       HeaderText = "Participants",    FillWeight = 80 });
                dgvMyBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total",     HeaderText = "Total (ZAR)",     FillWeight = 90 });
                dgvMyBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "Payment",   HeaderText = "Payment",         FillWeight = 90 });
                dgvMyBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "Attend",    HeaderText = "Attendance",      FillWeight = 80 });
                dgvMyBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "BookDate",  HeaderText = "Booked On",       FillWeight = 100 });
                dgvMyBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void ConfigureGridStyle(DataGridView dgv, Color altRowColor)
        {
            dgv.BackgroundColor                         = Color.FromArgb(12, 15, 24);
            dgv.GridColor                               = Color.FromArgb(32, 38, 58);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 26, 42);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(110, 231, 183);
            dgv.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Padding   = new Padding(6, 0, 0, 0);
            dgv.ColumnHeadersHeight                     = 36;
            dgv.RowsDefaultCellStyle.BackColor          = Color.FromArgb(15, 19, 30);
            dgv.RowsDefaultCellStyle.ForeColor          = Color.FromArgb(238, 242, 255);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 39);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(238, 242, 255);
            dgv.DefaultCellStyle.SelectionBackColor     = Color.FromArgb(16, 120, 92);
            dgv.DefaultCellStyle.SelectionForeColor     = Color.White;
            dgv.DefaultCellStyle.Font                   = new Font("Segoe UI", 9F);
            dgv.DefaultCellStyle.Padding                = new Padding(6, 2, 6, 2);
            dgv.RowTemplate.Height                      = 32;
        }

        // =================================================================
        //  SECURITY: 5-MINUTE INACTIVITY AUTO-LOGOUT
        // =================================================================

        private void InitInactivityTimer()
        {
            _inactivityTimer = new System.Windows.Forms.Timer();
            _inactivityTimer.Interval = InactivityTimeoutMs;
            _inactivityTimer.Tick += InactivityTimer_Tick;
            _inactivityTimer.Start();
        }

        private void ResetInactivityTimer()
        {
            if (_inactivityTimer != null && _inactivityTimer.Enabled)
            {
                _inactivityTimer.Stop();
                _inactivityTimer.Start();
            }
        }

        private void InactivityTimer_Tick(object sender, EventArgs e)
        {
            _inactivityTimer.Stop();
            Application.RemoveMessageFilter(this);
            MessageBox.Show("You have been automatically logged out due to 5 minutes of inactivity.",
                "Auto Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        public bool PreFilterMessage(ref Message m)
        {
            const int WM_MOUSEMOVE = 0x0200;
            const int WM_LBUTTONDOWN = 0x0201;
            const int WM_RBUTTONDOWN = 0x0204;
            const int WM_KEYDOWN = 0x0100;

            if (m.Msg == WM_MOUSEMOVE || m.Msg == WM_LBUTTONDOWN ||
                m.Msg == WM_RBUTTONDOWN || m.Msg == WM_KEYDOWN)
            {
                ResetInactivityTimer();
            }
            return false;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Application.RemoveMessageFilter(this);
            _inactivityTimer?.Stop();
            _inactivityTimer?.Dispose();
            _refreshTimer?.Stop();
            _refreshTimer?.Dispose();
            _accordionAnimTimer?.Stop();
            _accordionAnimTimer?.Dispose();
            if (_chatbotPopup != null && !_chatbotPopup.IsDisposed) _chatbotPopup.Close();
            base.OnFormClosed(e);
        }

        // =================================================================
        //  DESIGNER EVENT HANDLER BRIDGES
        // =================================================================

        private void btnNavHome_Click(object sender, EventArgs e) => ShowPanel(pnlHome);
        private void btnNavBrowse_Click(object sender, EventArgs e) { LoadActivities(); ShowPanel(pnlBrowse); }
        private void btnNavMyBookings_Click(object sender, EventArgs e) { LoadMyBookings(); ShowPanel(pnlMyBookings); }
        private void btnNavProfile_Click(object sender, EventArgs e) { PopulateProfile(); ShowPanel(pnlProfile); }
        private void btnNavContactUs_Click(object sender, EventArgs e) { PopulateContactUs(); ShowPanel(pnlContactUs); }
        private void btnQuickBrowse_Click(object sender, EventArgs e) { LoadActivities(); ShowPanel(pnlBrowse); }
        private void cboCategoryFilter_SelectedIndexChanged(object sender, EventArgs e) => LoadActivities();
        private void txtSearch_TextChanged(object sender, EventArgs e) => LoadActivities();
        private void btnCancelBook_Click(object sender, EventArgs e) { LoadActivities(); ShowPanel(pnlBrowse); }
        private void btnCancelPay_Click(object sender, EventArgs e) => ShowPanel(pnlBook);
        private void btnMakeAnother_Click(object sender, EventArgs e) { LoadActivities(); ShowPanel(pnlBrowse); }
        private void btnBackToDash_Click(object sender, EventArgs e) { RefreshHomeStats(); ShowPanel(pnlHome); }

        private void btnNavChatbot_Click(object sender, EventArgs e)
        {
            OpenSafariChatbot();
        }

        public void OpenSafariChatbot()
        {
            if (_chatbotPopup == null || _chatbotPopup.IsDisposed)
            {
                _chatbotPopup = new SafariChatbotForm(_currentUser, this);
                _chatbotPopup.BookingCompleted += (booking, invoice, activity) =>
                {
                    RefreshHomeStats();
                    if (pnlBrowse != null && pnlBrowse.Visible) LoadActivities();
                    if (pnlMyBookings != null && pnlMyBookings.Visible) LoadMyBookings();
                };
                _chatbotPopup.Show(this);
            }
            else
            {
                _chatbotPopup.LoadActivitiesDropdown();
                _chatbotPopup.Show();
                _chatbotPopup.BringToFront();
                _chatbotPopup.Activate();
            }
        }

        public void OpenBookingFromChatbot(string activityId, int participants)
        {
            try
            {
                Activity picked = null;
                foreach (var a in FileService.GetAllActivities())
                {
                    if (a.ActivityID == activityId) { picked = a; break; }
                }
                if (picked == null || picked.SeatsAvailable <= 0) return;

                _selectedActivity = picked;
                PopulateBookPanel();
                nudParticipants.Value = Math.Min(nudParticipants.Maximum, Math.Max(nudParticipants.Minimum, participants));
                ShowPanel(pnlBook);
            }
            catch { }
        }

        // =================================================================
        //  NAVIGATION
        // =================================================================

        private void ShowPanel(Panel target)
        {
            Panel[] all = { pnlHome, pnlBrowse, pnlBook, pnlPayment,
                            pnlInvoice, pnlMyBookings, pnlProfile, pnlContactUs };
            foreach (var p in all)
            {
                if (p != null) p.Visible = (p == target);
            }
            if (btnFloatingChat != null) btnFloatingChat.BringToFront();
            ApplyResponsiveLayout();

            // Highlight the matching nav button
            bool browsing = (target == pnlBrowse || target == pnlBook ||
                             target == pnlPayment || target == pnlInvoice);

            SetNavActive(btnNavHome,       target == pnlHome);
            SetNavActive(btnNavBrowse,     browsing);
            SetNavActive(btnNavMyBookings, target == pnlMyBookings);
            SetNavActive(btnNavProfile,    target == pnlProfile);
            if (btnNavContactUs != null)
                SetNavActive(btnNavContactUs, target == pnlContactUs);
        }

        private void SetNavActive(Button btn, bool active)
        {
            btn.BackColor = active ? Teal : DarkTeal;
            btn.Font      = active ? new Font("Arial", 10F, FontStyle.Bold) : FontNav;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to sign out?", "Sign Out",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close(); // SignInForm.FormClosed handler shows SignInForm again
            }
        }

        // =================================================================
        //  HOME PANEL LOGIC
        // =================================================================

        private void RefreshHomeStats()
        {
            if (_currentUser == null) return;
            try
            {
                FileService.AutoUpdateNoShowBookings();
                var bookings   = FileService.GetAllBookings();
                var activities = FileService.GetAllActivities();

                // Build quick lookup: ActivityID → Date
                var dateMap = new Dictionary<string, DateTime>();
                foreach (var a in activities) dateMap[a.ActivityID] = a.Date;

                int total    = 0;
                int upcoming = 0;
                decimal spent = 0m;
                foreach (var b in bookings)
                {
                    if (b.UserID != _currentUser.UserID || b.PaymentStatus == "Cancelled") continue;
                    total++;
                    spent += b.TotalCost;
                    if (dateMap.TryGetValue(b.ActivityID, out DateTime d) && d >= DateTime.Today)
                        upcoming++;
                }

                _cachedTotalBookings = total;
                _cachedUpcomingBookings = upcoming;
                _cachedTotalSpent = spent;
                _cachedActivities = activities;

                lblHomeBookingsCount.Text  = total.ToString();
                lblHomeUpcomingCount.Text  = upcoming.ToString();
                pnlHomeAnalytics?.Invalidate();
            }
            catch { /* leave displayed values as "0" */ }
        }

        // =================================================================
        //  BROWSE ACTIVITIES LOGIC
        // =================================================================

        private void LoadActivities()
        {
            if (dgvActivities == null || dgvActivities.Columns.Count == 0) return;
            List<Activity> activities;
            try { activities = FileService.GetAllActivities(); }
            catch
            {
                MessageBox.Show("Unable to load activities. Please try again later.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string category  = cboCategoryFilter.SelectedItem?.ToString() ?? "All";
            string search    = txtSearch.Text.Trim().ToLower();

            dgvActivities.Rows.Clear();
            _filteredBrowseActivities.Clear();

            foreach (var a in activities)
            {
                bool catOk = category == "All" ||
                             a.Category.Equals(category, StringComparison.OrdinalIgnoreCase);
                bool srchOk = string.IsNullOrEmpty(search) ||
                              a.Name.ToLower().Contains(search) ||
                              a.Description.ToLower().Contains(search);
                if (!catOk || !srchOk) continue;

                _filteredBrowseActivities.Add(a);

                int rowIdx = dgvActivities.Rows.Add(
                    a.ActivityID,
                    a.Category,
                    a.Name,
                    a.Description,
                    $"R{a.Price:N2}",
                    a.Date.ToString("dd MMM yyyy"),
                    a.SeatsAvailable > 0 ? a.SeatsAvailable.ToString() : "SOLD OUT");

                if (a.SeatsAvailable <= 0)
                {
                    dgvActivities.Rows[rowIdx].DefaultCellStyle.BackColor = Color.FromArgb(48, 20, 28);
                    dgvActivities.Rows[rowIdx].DefaultCellStyle.ForeColor = Color.FromArgb(255, 130, 130);
                }
            }

            bool hasRows = _filteredBrowseActivities.Count > 0;
            lblNoActivities.Visible = !hasRows;
            if (pnlAccordionGallery != null) pnlAccordionGallery.Visible = hasRows;
            btnBookNow.Enabled      = hasRows;

            RebuildAccordionGalleryItems();
        }

        private void btnBookNow_Click(object sender, EventArgs e)
        {
            if (dgvActivities.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an activity from the list first.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string actId = dgvActivities.SelectedRows[0].Cells["ActivityID"].Value?.ToString();
            if (string.IsNullOrEmpty(actId)) return;

            // Re-read from disk to get the latest seat count.
            Activity picked = null;
            try
            {
                foreach (var a in FileService.GetAllActivities())
                    if (a.ActivityID == actId) { picked = a; break; }
            }
            catch
            {
                MessageBox.Show("Unable to load activity details. Please try again.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (picked == null) return;

            if (picked.SeatsAvailable <= 0)
            {
                MessageBox.Show("Sorry, this activity is sold out.", "Sold Out",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Populate the booking panel and navigate.
            _selectedActivity = picked;
            PopulateBookPanel();
            ShowPanel(pnlBook);
        }

        // =================================================================
        //  BOOKING PANEL LOGIC  (Step 1)
        // =================================================================

        private void PopulateBookPanel()
        {
            lblBookName.Text     = _selectedActivity.Name;
            lblBookCat.Text      = $"Category: {_selectedActivity.Category}";
            lblBookDate.Text     = $"Date: {_selectedActivity.Date:dddd, dd MMMM yyyy}";
            lblBookPrice.Text    = $"Price per person: {BookingService.FormatZar(_selectedActivity.Price)}";
            lblBookSeatsVal.Text = $"Seats available: {_selectedActivity.SeatsAvailable}";

            nudParticipants.Minimum = 1;
            nudParticipants.Maximum = 1000; // High on purpose; nudParticipants_ValueChanged warns & clamps if > SeatsAvailable (from Tourist/Booking.cs)
            nudParticipants.Value   = 1;

            lblBookTotal.Text    = $"Total: {BookingService.FormatZar(_selectedActivity.Price)}";
            lblBookError.Visible = false;
        }

        private void nudParticipants_ValueChanged(object sender, EventArgs e)
        {
            if (_selectedActivity == null) return;

            int seats = _selectedActivity.SeatsAvailable;
            int wanted = (int)nudParticipants.Value;

            if (seats > 0 && wanted > seats)
            {
                nudParticipants.Value = seats;
                MessageBox.Show(
                    "Sorry, we only have " + seats + " seat" + (seats == 1 ? "" : "s") +
                    " left for this event. You asked for " + wanted +
                    ", so the number of guests has been set to " + seats + ".",
                    "Not enough seats", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal total     = _selectedActivity.Price * (int)nudParticipants.Value;
            lblBookTotal.Text = $"Total: {BookingService.FormatZar(total)}";
        }

        private void btnProceedPayment_Click(object sender, EventArgs e)
        {
            int pax = (int)nudParticipants.Value;

            // Re-read seats in case someone else booked in the meantime.
            try
            {
                foreach (var a in FileService.GetAllActivities())
                {
                    if (a.ActivityID != _selectedActivity.ActivityID) continue;
                    _selectedActivity = a; // refresh
                    break;
                }
            }
            catch { /* use cached; payment step will catch real problems */ }

            if (pax > _selectedActivity.SeatsAvailable)
            {
                lblBookError.Text    = $"Not enough tickets available. Only {_selectedActivity.SeatsAvailable} seat(s) remain.";
                lblBookError.Visible = true;
                if (_selectedActivity.SeatsAvailable > 0)
                    nudParticipants.Value = _selectedActivity.SeatsAvailable;
                return;
            }

            lblBookError.Visible = false;

            // Pre-fill guest name & email from logged-in user if empty or placeholder
            if (txtPayFullName != null && string.IsNullOrEmpty(RealText(txtPayFullName)))
            {
                string fullName = $"{_currentUser?.FirstName} {_currentUser?.LastName}".Trim();
                if (!string.IsNullOrEmpty(fullName))
                {
                    txtPayFullName.Text = fullName;
                    txtPayFullName.ForeColor = Color.White;
                }
            }
            if (txtPayEmail != null && string.IsNullOrEmpty(RealText(txtPayEmail)))
            {
                if (!string.IsNullOrEmpty(_currentUser?.Email))
                {
                    txtPayEmail.Text = _currentUser.Email;
                    txtPayEmail.ForeColor = Color.White;
                }
            }

            ClearPaymentErrors();

            // Populate the payment panel.
            decimal total      = _selectedActivity.Price * pax;
            lblPaySummary.Text =
                $"Activity : {_selectedActivity.Name}   •   Category: {_selectedActivity.Category}\r\n" +
                $"Date      : {_selectedActivity.Date:dddd, dd MMMM yyyy}   •   Guests: {pax}   •   Price / guest: {BookingService.FormatZar(_selectedActivity.Price)}";
            lblPayTotal.Text = $"TOTAL DUE:  {BookingService.FormatZar(total)}";

            ShowPanel(pnlPayment);
        }

        // =================================================================
        //  PAYMENT PANEL LOGIC  (Step 2 — Tourist Booking + Luhn + PDF Tickets + EmailService)
        // =================================================================

        private void SetupTouristBookingValidation()
        {
            if (txtPayFullName == null || txtCardNumber == null) return;

            SetPlaceholder(txtPayFullName, "Full name");
            SetPlaceholder(txtPayEmail, "Email address");
            SetPlaceholder(txtCardNumber, "1234 1234 1234 1234");
            SetPlaceholder(txtCardMonth, "MM");
            SetPlaceholder(txtCardYear, "YY");
            SetPlaceholder(txtCardCvc, "CVC");

            WatchField(txtPayFullName, lblPayNameErr, () => BookingService.CheckName(RealText(txtPayFullName)));
            WatchField(txtPayEmail, lblPayEmailErr, () => BookingService.CheckEmail(RealText(txtPayEmail)));
            WatchField(txtCardNumber, lblPayCardErr, () => BookingService.CheckCard(RealText(txtCardNumber)));
            WatchField(txtCardCvc, lblPayCvcErr, () => BookingService.CheckCvc(RealText(txtCardCvc)));

            EventHandler expiryTyping = (s, e) =>
            {
                string m = RealText(txtCardMonth);
                string y = RealText(txtCardYear);
                if (m.Length == 0 && y.Length == 0)
                    ShowFieldError(lblPayExpiryErr, null, txtCardMonth, txtCardYear);
                else if (y.Length == 0)
                    ShowFieldError(lblPayExpiryErr, BookingService.MonthRx.IsMatch(m) ? null : "Month must be 1 to 12.", txtCardMonth);
                else
                    ShowFieldError(lblPayExpiryErr, BookingService.CheckExpiry(m, y), txtCardMonth, txtCardYear);
            };
            txtCardMonth.TextChanged += expiryTyping;
            txtCardYear.TextChanged += expiryTyping;
            txtCardYear.Leave += (s, e) => ShowFieldError(lblPayExpiryErr, BookingService.CheckExpiry(RealText(txtCardMonth), RealText(txtCardYear)), txtCardMonth, txtCardYear);

            OnlyDigits(txtCardMonth);
            OnlyDigits(txtCardYear);
            OnlyDigits(txtCardCvc);
            OnlyDigits(txtCardNumber, " -");
        }

        private void SetPlaceholder(TextBox box, string placeholder)
        {
            if (box == null) return;
            box.Tag = placeholder;
            box.Text = placeholder;
            box.ForeColor = Color.FromArgb(130, 140, 165);
            box.Enter += (s, e) =>
            {
                if (box.Text == (string)box.Tag)
                {
                    box.Text = "";
                    box.ForeColor = Color.White;
                }
            };
            box.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(box.Text))
                {
                    box.Text = (string)box.Tag;
                    box.ForeColor = Color.FromArgb(130, 140, 165);
                }
            };
        }

        private string RealText(TextBox box)
        {
            if (box == null) return "";
            string tag = box.Tag as string;
            return (tag != null && box.Text == tag) ? "" : box.Text.Trim();
        }

        private void OnlyDigits(TextBox box, string extra = "")
        {
            if (box == null) return;
            box.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && extra.IndexOf(e.KeyChar) < 0)
                    e.Handled = true;
            };
        }

        private void ShowFieldError(Label lbl, string message, params TextBox[] boxes)
        {
            bool bad = !string.IsNullOrEmpty(message);
            if (lbl != null)
            {
                lbl.Text = bad ? message : "";
                lbl.Visible = bad;
            }
            foreach (var b in boxes)
            {
                if (b != null)
                    b.BackColor = bad ? Color.FromArgb(56, 22, 32) : SafariThemeEngine.InputBg;
            }
        }

        private void WatchField(TextBox box, Label lbl, Func<string> check)
        {
            if (box == null) return;
            box.TextChanged += (s, e) =>
            {
                if (RealText(box).Length == 0)
                    ShowFieldError(lbl, null, box);
                else
                    ShowFieldError(lbl, check(), box);
            };
            box.Leave += (s, e) => ShowFieldError(lbl, check(), box);
        }

        private void ClearPaymentErrors()
        {
            ShowFieldError(lblPayNameErr, null, txtPayFullName);
            ShowFieldError(lblPayEmailErr, null, txtPayEmail);
            ShowFieldError(lblPayCardErr, null, txtCardNumber);
            ShowFieldError(lblPayExpiryErr, null, txtCardMonth, txtCardYear);
            ShowFieldError(lblPayCvcErr, null, txtCardCvc);
        }

        private bool ValidatePaymentCardAndGuest()
        {
            string n = BookingService.CheckName(RealText(txtPayFullName));
            string m = BookingService.CheckEmail(RealText(txtPayEmail));
            string c = BookingService.CheckCard(RealText(txtCardNumber));
            string x = BookingService.CheckExpiry(RealText(txtCardMonth), RealText(txtCardYear));
            string v = BookingService.CheckCvc(RealText(txtCardCvc));

            ShowFieldError(lblPayNameErr, n, txtPayFullName);
            ShowFieldError(lblPayEmailErr, m, txtPayEmail);
            ShowFieldError(lblPayCardErr, c, txtCardNumber);
            ShowFieldError(lblPayExpiryErr, x, txtCardMonth, txtCardYear);
            ShowFieldError(lblPayCvcErr, v, txtCardCvc);

            return n == null && m == null && c == null && x == null && v == null;
        }

        private void btnFillDemoCard_Click(object sender, EventArgs e)
        {
            if (txtPayFullName != null && string.IsNullOrEmpty(RealText(txtPayFullName)))
            {
                txtPayFullName.Text = $"{_currentUser?.FirstName} {_currentUser?.LastName}".Trim();
                txtPayFullName.ForeColor = Color.White;
            }
            if (txtPayEmail != null && string.IsNullOrEmpty(RealText(txtPayEmail)))
            {
                txtPayEmail.Text = _currentUser?.Email ?? "visitor@bluehorizon.co.za";
                txtPayEmail.ForeColor = Color.White;
            }
            if (txtCardNumber != null)
            {
                txtCardNumber.Text = "4532 0151 1283 0366";
                txtCardNumber.ForeColor = Color.White;
            }
            if (txtCardMonth != null)
            {
                txtCardMonth.Text = "12";
                txtCardMonth.ForeColor = Color.White;
            }
            if (txtCardYear != null)
            {
                txtCardYear.Text = "28";
                txtCardYear.ForeColor = Color.White;
            }
            if (txtCardCvc != null)
            {
                txtCardCvc.Text = "123";
                txtCardCvc.ForeColor = Color.White;
            }
            ClearPaymentErrors();
        }

        private async void btnPayNow_Click(object sender, EventArgs e)
        {
            if (_paymentBusy || _selectedActivity == null) return;
            if (!ValidatePaymentCardAndGuest()) return;

            int     pax        = (int)nudParticipants.Value;
            decimal total      = _selectedActivity.Price * pax;
            string  guestName  = RealText(txtPayFullName);
            string  guestEmail = RealText(txtPayEmail);

            _paymentBusy = true;
            btnPayNow.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                // Re-verify seat availability atomically
                var activities = FileService.GetAllActivities();
                var freshAct = activities.FirstOrDefault(a => a.ActivityID == _selectedActivity.ActivityID);
                if (freshAct == null || freshAct.SeatsAvailable < pax)
                {
                    MessageBox.Show(
                        freshAct == null || freshAct.SeatsAvailable <= 0
                            ? "Sorry, this event is sold out."
                            : $"Only {freshAct.SeatsAvailable} seat(s) left for this event.",
                        "Booking not completed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create and persist the Booking.
                _currentBooking = new Booking
                {
                    BookingID        = Guid.NewGuid().ToString(),
                    UserID           = _currentUser.UserID,
                    ActivityID       = _selectedActivity.ActivityID,
                    BookingDate      = DateTime.Now,
                    ParticipantCount = pax,
                    TotalCost        = total,
                    PaymentStatus    = "Paid",
                    Attendance       = "Pending"
                };

                FileService.AddBooking(_currentBooking);

                // Decrement SeatsAvailable in activities.txt.
                freshAct.SeatsAvailable = Math.Max(0, freshAct.SeatsAvailable - pax);
                _selectedActivity.SeatsAvailable = freshAct.SeatsAvailable;
                FileService.SaveAllActivities(activities);

                // Generate unique ticket numbers per guest (BH-000001-01-XXXX) and PDF tickets
                int bookingSeq = FileService.GetAllBookings().Count;
                _lastTicketNumbers = BookingService.GenerateTicketNumbers(bookingSeq, pax);

                var actSnap = _selectedActivity;
                var ticketNumsSnap = new List<string>(_lastTicketNumbers);
                var pdfs = await System.Threading.Tasks.Task.Run(() =>
                {
                    var list = new List<byte[]>();
                    for (int i = 0; i < ticketNumsSnap.Count; i++)
                    {
                        list.Add(TicketPdfService.CreateTicket(
                            actSnap, guestName, ticketNumsSnap[i],
                            i + 1, ticketNumsSnap.Count, actSnap.Price));
                    }
                    return list;
                });

                _lastTicketsFolder = TicketPdfService.SaveCopies(_lastTicketNumbers, pdfs);

                // Generate and persist the Invoice.
                _currentInvoice = new Invoice
                {
                    InvoiceNo = "INV-" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                    BookingID = _currentBooking.BookingID,
                    UserID    = _currentUser.UserID,
                    IssueDate = DateTime.Now,
                    Details   = $"{_selectedActivity.Name} \u00d7{pax} @ R{_selectedActivity.Price:N2} | Tickets: {string.Join(", ", _lastTicketNumbers)}",
                    Total     = total
                };

                try { FileService.AddInvoice(_currentInvoice); }
                catch { /* non-fatal */ }

                string emailStatusMessage;
                try
                {
                    await EmailService.SendTicketsAsync(guestEmail, guestName, _selectedActivity, _lastTicketNumbers, pdfs);
                    emailStatusMessage =
                        "Payment successful!\n\n" + pax + " ticket" + (pax == 1 ? "" : "s") +
                        " sent to " + guestEmail + ".\nTotal paid: " + BookingService.FormatZar(total) +
                        "\n\nLocal PDF copies also saved to:\n" + _lastTicketsFolder;
                }
                catch (Exception ex)
                {
                    emailStatusMessage =
                        "Your booking is confirmed (total " + BookingService.FormatZar(total) + "), " +
                        "but the email could not be sent:\n" + ex.Message +
                        "\n\nYour PDF tickets were saved here:\n" + _lastTicketsFolder;
                }

                BookingService.NotifyBookingCompleted();
                RefreshHomeStats();

                // Render invoice and show it.
                rtbInvoice.Text = FormatInvoice(_currentInvoice, _currentBooking, _selectedActivity, guestName, guestEmail, _lastTicketNumbers, _lastTicketsFolder);
                ShowPanel(pnlInvoice);

                MessageBox.Show(emailStatusMessage, "Booking complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message, "Blue Horizon",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                _paymentBusy = false;
                if (btnPayNow != null) btnPayNow.Enabled = true;
            }
        }

        private void btnOpenTicketsFolder_Click(object sender, EventArgs e)
        {
            try
            {
                string folder = !string.IsNullOrEmpty(_lastTicketsFolder) && Directory.Exists(_lastTicketsFolder)
                    ? _lastTicketsFolder
                    : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Blue Horizon Tickets");
                Directory.CreateDirectory(folder);
                System.Diagnostics.Process.Start("explorer.exe", folder);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tickets folder: " + _lastTicketsFolder + "\n" + ex.Message,
                    "PDF Tickets Folder", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // =================================================================
        //  INVOICE PANEL LOGIC  (Step 3)
        // =================================================================

        private string FormatInvoice(
            Invoice inv,
            Booking bk,
            Activity act,
            string guestName = null,
            string guestEmail = null,
            List<string> ticketNumbers = null,
            string ticketsFolder = null)
        {
            var sb = new StringBuilder();
            sb.AppendLine("================================================");
            sb.AppendLine("        BLUE HORIZONS TOURS");
            sb.AppendLine("        Cape Town, South Africa");
            sb.AppendLine("        OFFICIAL INVOICE & E-TICKETS");
            sb.AppendLine("================================================");
            sb.AppendLine($"  Invoice No    : {inv.InvoiceNo}");
            sb.AppendLine($"  Date Issued   : {inv.IssueDate:dd MMMM yyyy  HH:mm}");
            sb.AppendLine($"  Booking ID    : {bk.BookingID}");
            sb.AppendLine("------------------------------------------------");
            sb.AppendLine("  CUSTOMER / TICKET HOLDER");
            sb.AppendLine($"  Name          : {(string.IsNullOrWhiteSpace(guestName) ? (_currentUser.FirstName + " " + _currentUser.LastName) : guestName)}");
            sb.AppendLine($"  Email         : {(string.IsNullOrWhiteSpace(guestEmail) ? _currentUser.Email : guestEmail)}");
            sb.AppendLine($"  Phone         : {_currentUser.Phone}");
            sb.AppendLine("------------------------------------------------");
            sb.AppendLine("  ACTIVITY");
            sb.AppendLine($"  Name          : {act.Name}");
            sb.AppendLine($"  Category      : {act.Category}");
            sb.AppendLine($"  Activity Date : {act.Date:dddd, dd MMMM yyyy}");
            sb.AppendLine($"  Participants  : {bk.ParticipantCount}");
            sb.AppendLine($"  Price / Person: {BookingService.FormatZar(act.Price)}");
            if (ticketNumbers != null && ticketNumbers.Count > 0)
            {
                sb.AppendLine("------------------------------------------------");
                sb.AppendLine("  ISSUED PDF TICKET NUMBERS");
                for (int i = 0; i < ticketNumbers.Count; i++)
                {
                    sb.AppendLine($"  Ticket {i + 1} of {ticketNumbers.Count} : {ticketNumbers[i]}");
                }
                if (!string.IsNullOrEmpty(ticketsFolder))
                    sb.AppendLine($"  Saved Folder  : {ticketsFolder}");
            }
            sb.AppendLine("------------------------------------------------");
            sb.AppendLine($"  TOTAL AMOUNT  : {BookingService.FormatZar(inv.Total)}");
            sb.AppendLine($"  Payment Status: {bk.PaymentStatus.ToUpper()}  \u2714");
            sb.AppendLine($"  Attendance    : {bk.Attendance}");
            sb.AppendLine("================================================");
            sb.AppendLine("  Thank you for booking with Blue Horizons Tours!");
            sb.AppendLine("  Present your PDF ticket(s) at the entrance.");
            sb.AppendLine("  info@bluehorizonstours.co.za");
            sb.AppendLine("================================================");
            return sb.ToString();
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            var pd = new PrintDocument();
            pd.PrintPage += (s, pe) =>
            {
                using (var fnt = new Font("Courier New", 9F))
                    pe.Graphics.DrawString(rtbInvoice.Text, fnt, Brushes.Black,
                        new RectangleF(40, 40, pe.PageBounds.Width - 80, pe.PageBounds.Height - 80));
            };

            using (var ppd = new PrintPreviewDialog { Document = pd, Width = 820, Height = 660 })
                ppd.ShowDialog(this);
        }

        private void btnSaveInvoice_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter   = "Text Files (*.txt)|*.txt";
                sfd.FileName = _currentInvoice != null ? $"{_currentInvoice.InvoiceNo}.txt" : "Invoice.txt";

                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllText(sfd.FileName, rtbInvoice.Text);
                        MessageBox.Show("Invoice saved successfully!", "Saved",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Failed to save the file. Please try again.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // =================================================================
        //  MY BOOKINGS PANEL LOGIC
        // =================================================================

        private void LoadMyBookings()
        {
            dgvMyBookings.Rows.Clear();

            List<Booking>  bookings;
            List<Activity> activities;
            try
            {
                FileService.AutoUpdateNoShowBookings();
                bookings   = FileService.GetAllBookings();
                activities = FileService.GetAllActivities();
            }
            catch
            {
                MessageBox.Show("Unable to load bookings. Please try again later.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Build activity lookup: ActivityID → Activity
            var actMap = new Dictionary<string, Activity>();
            foreach (var a in activities) actMap[a.ActivityID] = a;

            int rowCount = 0;
            foreach (var b in bookings)
            {
                if (b.UserID != _currentUser.UserID) continue;

                string actName = actMap.ContainsKey(b.ActivityID) ? actMap[b.ActivityID].Name : "Unknown";
                string actDate = actMap.ContainsKey(b.ActivityID) ? actMap[b.ActivityID].Date.ToString("dd MMM yyyy") : "-";

                int ri = dgvMyBookings.Rows.Add(
                    actName,
                    actDate,
                    b.ParticipantCount,
                    $"R{b.TotalCost:N2}",
                    b.PaymentStatus,
                    b.Attendance,
                    b.BookingDate.ToString("dd MMM yyyy"));

                // Colour-code by payment status (Dark Glass palette)
                Color rowColor =
                    b.PaymentStatus == "Paid"      ? Color.FromArgb(14, 38, 32) :
                    b.PaymentStatus == "Cancelled" ? Color.FromArgb(46, 18, 26) :
                                                     Color.FromArgb(18, 23, 36);
                dgvMyBookings.Rows[ri].DefaultCellStyle.BackColor = rowColor;
                dgvMyBookings.Rows[ri].DefaultCellStyle.ForeColor =
                    b.PaymentStatus == "Paid"      ? Color.FromArgb(167, 243, 208) :
                    b.PaymentStatus == "Cancelled" ? Color.FromArgb(252, 165, 165) :
                                                     Color.FromArgb(238, 242, 255);
                rowCount++;
            }

            lblNoBookings.Visible = rowCount == 0;
        }

        // =================================================================
        //  PROFILE PANEL LOGIC
        // =================================================================

        private void PopulateProfile()
        {
            txtProfileEmail.Text   = _currentUser.Email;
            txtProfilePhone.Text   = _currentUser.Phone;
            txtProfileNewPass.Clear();
            txtProfileConfirm.Clear();
            lblProfileError.Visible = false;
        }

        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            lblProfileError.Visible = false;

            string email   = txtProfileEmail.Text.Trim();
            string phone   = txtProfilePhone.Text.Trim();
            string newPass = txtProfileNewPass.Text;
            string confirm = txtProfileConfirm.Text;

            // Email format
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                ShowProfileError("Please enter a valid email address."); return;
            }

            // Phone format (SA 10 digits starting with 0, or +countryCode format from Register.cs)
            if (!Regex.IsMatch(phone, @"^(0[0-9]{9}|\+[0-9]{7,15})$"))
            {
                ShowProfileError("Phone must be 10 digits starting with 0, or include country code (e.g. +27...)."); return;
            }

            // Optional password change
            if (!string.IsNullOrEmpty(newPass))
            {
                if (!Regex.IsMatch(newPass, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$"))
                {
                    ShowProfileError("Password must be ≥ 8 chars with uppercase, lowercase and a digit."); return;
                }
                if (newPass != confirm)
                {
                    ShowProfileError("Passwords do not match."); return;
                }
            }

            // Email uniqueness (must not be used by another account)
            List<User> users;
            try { users = FileService.GetAllUsers(); }
            catch { ShowProfileError("Unable to reach the system. Please try again."); return; }

            foreach (var u in users)
            {
                if (!u.UserID.Equals(_currentUser.UserID) &&
                    u.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
                {
                    ShowProfileError("Email is already in use by another account."); return;
                }
            }

            // Apply changes
            foreach (var u in users)
            {
                if (u.UserID != _currentUser.UserID) continue;
                u.Email = email;
                u.Phone = phone;
                if (!string.IsNullOrEmpty(newPass))
                    u.PasswordHash = PasswordHelper.HashNewPassword(newPass);
                break;
            }

            try { FileService.SaveAllUsers(users); }
            catch { ShowProfileError("Failed to save changes. Please try again later."); return; }

            // Also sync updated email, phone, and password back to Text Files/Visitor.txt
            try
            {
                string oldEmail = _currentUser.Email;
                string projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
                string visitorFile = Path.Combine(projectDirectory, "Text Files", "Visitor.txt");
                if (File.Exists(visitorFile))
                {
                    string[] lines = File.ReadAllLines(visitorFile);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (string.IsNullOrWhiteSpace(lines[i])) continue;
                        string[] parts = lines[i].Split('\t');
                        if (parts.Length >= 8 && parts[2].Trim().Equals(oldEmail, StringComparison.OrdinalIgnoreCase))
                        {
                            parts[2] = email;
                            parts[6] = phone;
                            if (!string.IsNullOrEmpty(newPass))
                            {
                                using (SHA256 sha256 = SHA256.Create())
                                {
                                    byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(newPass));
                                    StringBuilder sbHash = new StringBuilder();
                                    foreach (byte b in hashBytes) sbHash.Append(b.ToString("x2"));
                                    parts[7] = sbHash.ToString();
                                }
                            }
                            lines[i] = string.Join("\t", parts);
                            break;
                        }
                    }
                    File.WriteAllLines(visitorFile, lines);
                }
            }
            catch { /* non-fatal if Visitor.txt is not present in standalone build */ }

            // Update the in-memory user so the sidebar greeting reflects changes.
            _currentUser.Email = email;
            _currentUser.Phone = phone;

            txtProfileNewPass.Clear();
            txtProfileConfirm.Clear();

            MessageBox.Show("Profile updated successfully!", "Saved",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowProfileError(string msg)
        {
            lblProfileError.Text    = msg;
            lblProfileError.Visible = true;
        }

        // =================================================================
        //  CONTACT US PANEL LOGIC (Incorporated from Tourist/ContactUs.cs)
        // =================================================================

        private void PopulateContactUs()
        {
            if (txtContactName != null && string.IsNullOrWhiteSpace(txtContactName.Text))
                txtContactName.Text = $"{_currentUser?.FirstName} {_currentUser?.LastName}".Trim();
            if (txtContactEmail != null && string.IsNullOrWhiteSpace(txtContactEmail.Text))
                txtContactEmail.Text = _currentUser?.Email ?? "";
            if (cmbContactSubject != null && cmbContactSubject.Items.Count > 0 && cmbContactSubject.SelectedIndex < 0)
                cmbContactSubject.SelectedIndex = 0;
        }

        private async void btnSendContactMessage_Click(object sender, EventArgs e)
        {
            string name    = txtContactName.Text.Trim();
            string email   = txtContactEmail.Text.Trim();
            string subject = cmbContactSubject.SelectedItem?.ToString() ?? "General Inquiry";
            string message = txtContactMessage.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(message))
            {
                MessageBox.Show(
                    "Please fill in all required fields (Name, Email, and Message).",
                    "Incomplete Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!BookingService.EmailRx.IsMatch(email))
            {
                MessageBox.Show(
                    "Please enter a valid email address (e.g. name@example.com).",
                    "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnSendContactMessage.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                bool success = await System.Threading.Tasks.Task.Run(() =>
                    ContactService.SaveMessage(name, email, subject, message));

                if (success)
                {
                    try
                    {
                        await EmailService.SendContactConfirmationAsync(email, name, subject, message);
                    }
                    catch { /* Offline or SMTP blocked — message is safely saved in ContactService */ }

                    MessageBox.Show(
                        "Thank you! Your message has been sent successfully.",
                        "Message Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtContactMessage.Clear();
                    if (cmbContactSubject.Items.Count > 0) cmbContactSubject.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show(
                        "Could not send your message. Please try again later.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnSendContactMessage.Enabled = true;
            }
        }

        // =================================================================
        //  WIDGET FACTORY HELPERS  (keep Designer-independent controls DRY)
        // =================================================================

        /// <summary>Creates a blank content Panel sized to fill the content area.</summary>
        private Panel ContentPanel() => new Panel
        {
            Location  = new Point(0, 0),
            Size      = new Size(980, 750),
            BackColor = Color.White,
            Visible   = false
        };

        private Label MakeLabel(string text, Font font, Color fore, Color back,
                                Point loc, Size size,
                                ContentAlignment align = ContentAlignment.TopLeft)
            => new Label
            {
                Text      = text,
                Font      = font,
                ForeColor = fore,
                BackColor = back,
                Location  = loc,
                Size      = size,
                TextAlign = align,
                AutoSize  = false
            };

        private TextBox MakeTextBox(Point loc, Size size) => new TextBox
        {
            Location    = loc,
            Size        = size,
            Font        = FontField,
            BorderStyle = BorderStyle.FixedSingle
        };

        private Button MakePrimaryButton(string text, Point loc, Size size)
        {
            var btn = new Button
            {
                Text      = text,
                Location  = loc,
                Size      = size,
                Font      = FontBtn,
                BackColor = Color.Black,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor    = Cursors.Hand,
                UseVisualStyleBackColor = false
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        private Button MakeOutlineButton(string text, Point loc, Size size)
        {
            var btn = new Button
            {
                Text      = text,
                Location  = loc,
                Size      = size,
                Font      = FontNav,
                BackColor = Color.White,
                ForeColor = DarkTeal,
                FlatStyle = FlatStyle.Flat,
                Cursor    = Cursors.Hand,
                UseVisualStyleBackColor = false
            };
            btn.FlatAppearance.BorderColor = DarkTeal;
            btn.FlatAppearance.BorderSize  = 1;
            return btn;
        }

        private Button MakeNavButton(string text, Point loc, EventHandler onClick)
        {
            var btn = new Button
            {
                Text      = text,
                Location  = loc,
                Size      = new Size(220, 52),
                Font      = FontNav,
                BackColor = DarkTeal,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding   = new Padding(16, 0, 0, 0),
                Cursor    = Cursors.Hand,
                UseVisualStyleBackColor = false
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Click += onClick;
            return btn;
        }

        private DataGridView BuildDataGrid(Point loc, Size size)
        {
            var dgv = new DataGridView
            {
                Location              = loc,
                Size                  = size,
                ReadOnly              = true,
                AllowUserToAddRows    = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                SelectionMode         = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect           = false,
                BorderStyle           = BorderStyle.None,
                CellBorderStyle       = DataGridViewCellBorderStyle.SingleHorizontal,
                GridColor             = Color.FromArgb(220, 220, 220),
                BackgroundColor       = Color.White,
                RowHeadersVisible     = false,
                EnableHeadersVisualStyles = false
            };
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Teal;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font      = new Font("Arial", 9.5F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Padding   = new Padding(4, 0, 0, 0);
            dgv.ColumnHeadersHeight                     = 34;
            dgv.RowsDefaultCellStyle.BackColor          = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(246, 252, 250);
            dgv.DefaultCellStyle.SelectionBackColor     = Color.FromArgb(178, 235, 226);
            dgv.DefaultCellStyle.SelectionForeColor     = Color.Black;
            dgv.DefaultCellStyle.Font                   = FontSmall;
            dgv.DefaultCellStyle.Padding                = new Padding(4, 2, 4, 2);
            dgv.RowTemplate.Height                      = 28;
            return dgv;
        }

        /// <summary>Builds a stat card panel used on the Home screen.</summary>
        private Panel BuildStatCard(int x, int y, string count, string caption, Color accent)
        {
            var card = new Panel
            {
                Location    = new Point(x, y),
                Size        = new Size(240, 128),
                BackColor   = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            var lblCount = new Label
            {
                Text      = count,
                Font      = new Font("Arial", 34F, FontStyle.Bold),
                ForeColor = accent,
                Location  = new Point(8, 10),
                Size      = new Size(224, 60),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize  = false
            };

            var lblCaption = new Label
            {
                Text      = caption,
                Font      = FontSmall,
                ForeColor = TextGray,
                Location  = new Point(8, 76),
                Size      = new Size(224, 30),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize  = false
            };

            card.Controls.Add(lblCount);
            card.Controls.Add(lblCaption);
            return card;
        }

        // =================================================================
        //  RESPONSIVE SCALING & FULL-WINDOW MAXIMIZE ENGINE
        // =================================================================

        private void ConfigureResponsiveScaling()
        {
            foreach (Panel p in new[] { pnlHome, pnlBrowse, pnlBook, pnlPayment, pnlInvoice, pnlMyBookings, pnlProfile, pnlContactUs })
            {
                if (p != null)
                {
                    p.AutoScroll = true;
                }
            }

            this.Load += (s, e) =>
            {
                FitWindowToWorkingArea();
                ApplyResponsiveLayout();
            };
            this.Shown += (s, e) => ApplyResponsiveLayout();
            this.Resize += (s, e) => ApplyResponsiveLayout();
            this.SizeChanged += (s, e) => ApplyResponsiveLayout();
        }

        private void FitWindowToWorkingArea()
        {
            try
            {
                if (this.WindowState == FormWindowState.Maximized) return;
                Rectangle workArea = Screen.FromControl(this).WorkingArea;
                int targetW = Math.Min(1220, workArea.Width - 20);
                int targetH = Math.Min(770, workArea.Height - 20);
                this.Size = new Size(Math.Max(960, targetW), Math.Max(620, targetH));
                this.Location = new Point(
                    workArea.Left + Math.Max(0, (workArea.Width - this.Width) / 2),
                    workArea.Top + Math.Max(0, (workArea.Height - this.Height) / 2));
            }
            catch { }
        }

        private void ApplyResponsiveLayout()
        {
            if (pnlContent == null || pnlSidebar == null) return;
            if (this.WindowState == FormWindowState.Minimized) return;

            int clientW = Math.Max(940, this.ClientSize.Width);
            int clientH = Math.Max(580, this.ClientSize.Height);
            int sideW = 220;

            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Size = new Size(sideW, clientH);

            if (btnNavLogout != null)
            {
                int logoutY = Math.Max(400, clientH - btnNavLogout.Height);
                btnNavLogout.Location = new Point(0, logoutY);
                if (pnlDivider != null)
                    pnlDivider.Location = new Point(10, logoutY - 4);
            }

            int contentW = Math.Max(720, clientW - sideW);
            int contentH = clientH;
            pnlContent.Location = new Point(sideW, 0);
            pnlContent.Size = new Size(contentW, contentH);

            foreach (Panel p in new[] { pnlHome, pnlBrowse, pnlBook, pnlPayment, pnlInvoice, pnlMyBookings, pnlProfile, pnlContactUs })
            {
                if (p != null)
                {
                    p.Location = new Point(0, 0);
                    p.Size = new Size(contentW, contentH);
                }
            }

            int padX = 24;
            int availW = contentW - (padX * 2);

            // Pin floating SafariScout AI button to bottom-right of pnlContent
            if (btnFloatingChat != null)
            {
                btnFloatingChat.Location = new Point(
                    contentW - btnFloatingChat.Width - 24,
                    contentH - btnFloatingChat.Height - 18);
                btnFloatingChat.BringToFront();
            }

            // Top-right Home Meta Box (Location + Live Clock)
            if (pnlHomeMeta != null)
            {
                int metaW = 360;
                int metaX = Math.Max(padX + 380, contentW - metaW - padX);
                pnlHomeMeta.Location = new Point(metaX, 22);
                pnlHomeMeta.Size = new Size(metaW, 78);
                pnlHomeMeta.BringToFront();
            }

            // Home panel stat cards + Kokonut Activity Rings + Bklit Category Chart
            if (pnlHome != null && cardBookings != null && cardUpcoming != null)
            {
                int cardW = Math.Min(560, Math.Max(240, (availW - 24) / 2));
                cardBookings.Location = new Point(padX, 134);
                cardBookings.Size = new Size(cardW, 122);
                if (lblHomeBookingsCount != null) lblHomeBookingsCount.Size = new Size(cardW - 16, 60);
                if (lblHomeBookingsCap != null)   lblHomeBookingsCap.Size   = new Size(cardW - 16, 30);

                cardUpcoming.Location = new Point(padX + cardW + 24, 134);
                cardUpcoming.Size = new Size(cardW, 122);
                if (lblHomeUpcomingCount != null) lblHomeUpcomingCount.Size = new Size(cardW - 16, 60);
                if (lblHomeUpcomingCap != null)   lblHomeUpcomingCap.Size   = new Size(cardW - 16, 30);

                if (lblHomePrompt != null)  lblHomePrompt.Location  = new Point(padX, 272);
                if (btnQuickBrowse != null) btnQuickBrowse.Location = new Point(padX, 304);

                if (pnlHomeAnalytics != null)
                {
                    int anaTop = 370;
                    int anaH = Math.Max(215, contentH - anaTop - 32);
                    pnlHomeAnalytics.Location = new Point(padX, anaTop);
                    pnlHomeAnalytics.Size = new Size(availW, anaH);
                    pnlHomeAnalytics.Invalidate();
                }
            }

            // Browse panel (Interactive AccordionGallery)
            if (pnlBrowse != null && btnBookNow != null)
            {
                int gridH = Math.Max(250, contentH - 196);
                if (pnlAccordionGallery != null)
                {
                    pnlAccordionGallery.Location = new Point(padX, 126);
                    pnlAccordionGallery.Size = new Size(availW, gridH);
                    pnlAccordionGallery.Invalidate();
                }
                if (dgvActivities != null)
                {
                    dgvActivities.Location = new Point(padX, 126);
                    dgvActivities.Size = new Size(availW, gridH);
                    dgvActivities.Visible = false;
                }
                btnBookNow.Location = new Point(padX, 126 + gridH + 12);
            }

            // Book & Payment cards (shifted below the 3-Step Kokonut Progress Stepper at Y=50)
            if (pnlBook != null && pnlBookCard != null)
            {
                int cardW = Math.Min(980, Math.Max(560, availW - 32));
                pnlBookCard.Location = new Point(padX, 88);
                pnlBookCard.Size = new Size(cardW, 210);
                if (lblBookName != null)     lblBookName.Size     = new Size(cardW - 30, 36);
                if (lblBookCat != null)      lblBookCat.Size      = new Size(cardW - 30, 22);
                if (lblBookDate != null)     lblBookDate.Size     = new Size(cardW - 30, 22);
                if (lblBookPrice != null)    lblBookPrice.Size    = new Size(cardW - 30, 28);
                if (lblBookSeatsVal != null) lblBookSeatsVal.Size = new Size(cardW - 30, 22);

                if (lblBookPaxCap != null)     lblBookPaxCap.Location     = new Point(padX, 314);
                if (nudParticipants != null)   nudParticipants.Location   = new Point(padX, 336);
                if (lblBookTotal != null)      lblBookTotal.Location      = new Point(padX + 140, 336);
                if (lblBookError != null)      lblBookError.Location      = new Point(padX, 376);
                if (btnProceedPayment != null) btnProceedPayment.Location = new Point(padX, 404);
                if (btnCancelBook != null)     btnCancelBook.Location     = new Point(padX + 318, 404);
                pnlBookCard.Invalidate();
            }

            if (pnlPayment != null && pnlPaySummaryCard != null)
            {
                int cardW = Math.Min(980, Math.Max(680, availW - 32));
                pnlPaySummaryCard.Location = new Point(padX, 84);
                pnlPaySummaryCard.Size = new Size(cardW, 118);
                if (lblPaySummary != null)
                {
                    lblPaySummary.Location = new Point(16, 12);
                    lblPaySummary.Size = new Size(cardW - 32, 52);
                }
                if (lblPayTotal != null)
                {
                    lblPayTotal.Location = new Point(16, 68);
                    lblPayTotal.Size   = new Size(cardW - 32, 38);
                }
                if (pnlCardEntry != null)
                {
                    pnlCardEntry.Location = new Point(padX, 212);
                    pnlCardEntry.Size = new Size(cardW, 206);
                    pnlCardEntry.Invalidate();
                }
                if (lblPayNotice != null)  lblPayNotice.Location  = new Point(padX, 428);
                if (btnPayNow != null)     btnPayNow.Location     = new Point(padX, 456);
                if (btnCancelPay != null)  btnCancelPay.Location  = new Point(padX + 318, 462);
                pnlPaySummaryCard.Invalidate();
            }

            // My Bookings panel
            if (pnlMyBookings != null && dgvMyBookings != null)
            {
                dgvMyBookings.Location = new Point(padX, 68);
                dgvMyBookings.Size = new Size(availW, Math.Max(240, contentH - 140));
            }

            // Invoice panel (shifted below the 3-Step Kokonut Progress Stepper at Y=50..74)
            if (pnlInvoice != null && rtbInvoice != null)
            {
                if (lblInvHeading != null) lblInvHeading.Location = new Point(padX, 12);
                if (lblInvSub != null)     lblInvSub.Location     = new Point(padX, 80);
                int rtbTop = 106;
                int rtbH = Math.Max(200, contentH - rtbTop - 122);
                rtbInvoice.Location = new Point(padX, rtbTop);
                rtbInvoice.Size = new Size(Math.Min(980, availW - 20), rtbH);
                int row1Y = rtbTop + rtbH + 10;
                int row2Y = row1Y + 50;
                if (btnPrintInvoice != null)      btnPrintInvoice.Location      = new Point(padX, row1Y);
                if (btnSaveInvoice != null)       btnSaveInvoice.Location       = new Point(padX + 214, row1Y);
                if (btnOpenTicketsFolder != null) btnOpenTicketsFolder.Location = new Point(padX + 428, row1Y);
                if (btnMakeAnother != null)  btnMakeAnother.Location  = new Point(padX, row2Y);
                if (btnBackToDash != null)   btnBackToDash.Location   = new Point(padX + 274, row2Y);
            }

            // Profile panel
            if (pnlProfile != null)
            {
                int fieldW = Math.Min(600, Math.Max(420, availW / 2));
                if (txtProfileEmail != null)   txtProfileEmail.Size   = new Size(fieldW, 32);
                if (txtProfilePhone != null)   txtProfilePhone.Size   = new Size(fieldW, 32);
                if (txtProfileNewPass != null) txtProfileNewPass.Size = new Size(fieldW, 32);
                if (txtProfileConfirm != null) txtProfileConfirm.Size = new Size(fieldW, 32);
            }

            // Contact Us panel
            if (pnlContactUs != null && pnlContactCard != null)
            {
                int cardW = Math.Min(820, Math.Max(580, availW - 32));
                pnlContactCard.Location = new Point(padX, 96);
                pnlContactCard.Size = new Size(cardW, 520);
                int innerW = cardW - 48;
                if (txtContactName != null)        txtContactName.Size        = new Size(innerW, 30);
                if (txtContactEmail != null)       txtContactEmail.Size       = new Size(innerW, 30);
                if (txtContactMessage != null)     txtContactMessage.Size     = new Size(innerW, 168);
                if (btnSendContactMessage != null) btnSendContactMessage.Size = new Size(innerW, 48);
                pnlContactCard.Invalidate();
            }
        }

        // =================================================================
        //  UIVERSE.IO + KEXSIO + KOKONUT UI + BKLIT UI VISITOR THEME
        // =================================================================

        private void ApplySafariDarkGlassTheme()
        {
            this.BackColor = SafariThemeEngine.ObsidianBg;
            if (pnlSidebar != null) pnlSidebar.BackColor = SafariThemeEngine.SidebarBg;
            if (pnlTop != null)     pnlTop.BackColor     = SafariThemeEngine.SidebarHeader;
            if (lblSidebarUser != null) lblSidebarUser.ForeColor = SafariThemeEngine.SafariEmerald;

            Panel[] pages = { pnlHome, pnlBrowse, pnlBook, pnlPayment, pnlInvoice, pnlMyBookings, pnlProfile, pnlContactUs };
            foreach (Panel page in pages)
            {
                if (page == null) continue;
                page.BackColor = SafariThemeEngine.ObsidianBg;
                SafariThemeEngine.EnableDoubleBuffering(page);
                page.Paint += VisitorPage_Paint;
                StyleVisitorControlsDark(page);
            }

            // Style Home Bento Stat Cards (Kokonut UI Bento Grid + Spotlight Card)
            StyleVisitorStatCard(cardBookings, lblHomeBookingsCount, lblHomeBookingsCap, SafariThemeEngine.SafariEmerald);
            StyleVisitorStatCard(cardUpcoming, lblHomeUpcomingCount, lblHomeUpcomingCap, SafariThemeEngine.HorizonCyan);

            // Style Home Location & Live Clock Glass Widget
            if (pnlHomeMeta != null)
            {
                pnlHomeMeta.BackColor = Color.FromArgb(14, 18, 30);
                pnlHomeMeta.BorderStyle = BorderStyle.None;
                SafariThemeEngine.EnableDoubleBuffering(pnlHomeMeta);
                pnlHomeMeta.Paint += (s, e) =>
                {
                    Graphics g = e.Graphics;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    RectangleF r = new RectangleF(1f, 1f, pnlHomeMeta.Width - 2f, pnlHomeMeta.Height - 2f);
                    using (var path = SafariThemeEngine.CreateRoundRect(r, 12f))
                    using (var bg = new System.Drawing.Drawing2D.LinearGradientBrush(
                        r, Color.FromArgb(20, 26, 42), Color.FromArgb(12, 16, 26), 135f))
                    using (var border = new Pen(Color.FromArgb(50, 0, 229, 255), 1.2f))
                    {
                        g.FillPath(bg, path);
                        g.DrawPath(border, path);
                    }
                    using (var topPen = new Pen(SafariThemeEngine.HorizonCyan, 2.5f))
                    {
                        g.DrawLine(topPen, 12f, 1.5f, pnlHomeMeta.Width - 12f, 1.5f);
                    }
                };
            }

            // Style Home Analytics Hub (Kokonut UI Activity Rings + Bklit UI Category Bar Chart)
            if (pnlHomeAnalytics != null)
            {
                pnlHomeAnalytics.BackColor = Color.Transparent;
                SafariThemeEngine.EnableDoubleBuffering(pnlHomeAnalytics);
                pnlHomeAnalytics.Paint -= PnlHomeAnalytics_Paint;
                pnlHomeAnalytics.Paint += PnlHomeAnalytics_Paint;
            }

            // Style Step 1 Booking Spotlight Card (pnlBookCard) with Live Seat Capacity Meter
            if (pnlBookCard != null)
            {
                pnlBookCard.BackColor = SafariThemeEngine.GlassCard;
                pnlBookCard.BorderStyle = BorderStyle.None;
                SafariThemeEngine.EnableDoubleBuffering(pnlBookCard);
                pnlBookCard.Paint += (s, e) =>
                {
                    Graphics g = e.Graphics;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    RectangleF r = new RectangleF(1f, 1f, pnlBookCard.Width - 2f, pnlBookCard.Height - 2f);
                    using (var path = SafariThemeEngine.CreateRoundRect(r, 12f))
                    using (var bg = new System.Drawing.Drawing2D.LinearGradientBrush(
                        r, Color.FromArgb(22, 28, 45), Color.FromArgb(14, 18, 30), 135f))
                    using (var border = new Pen(Color.FromArgb(55, 255, 255, 255), 1f))
                    {
                        g.FillPath(bg, path);
                        g.DrawPath(border, path);
                    }
                    using (var topPen = new Pen(SafariThemeEngine.HorizonCyan, 2.5f))
                        g.DrawLine(topPen, 12f, 1.5f, pnlBookCard.Width - 12f, 1.5f);

                    if (_selectedActivity != null && _selectedActivity.TotalSeats > 0)
                    {
                        float barX = 16f;
                        float barY = pnlBookCard.Height - 30f;
                        float barW = Math.Max(120f, pnlBookCard.Width - 32f);
                        RectangleF track = new RectangleF(barX, barY, barW, 10f);
                        using (var tPath = SafariThemeEngine.CreateRoundRect(track, 5f))
                        using (var tBrush = new SolidBrush(Color.FromArgb(30, 36, 56)))
                            g.FillPath(tBrush, tPath);

                        float ratio = Math.Min(1f, Math.Max(0.05f, _selectedActivity.SeatsAvailable / (float)_selectedActivity.TotalSeats));
                        RectangleF fill = new RectangleF(barX, barY, barW * ratio, 10f);
                        using (var fPath = SafariThemeEngine.CreateRoundRect(fill, 5f))
                        using (var fBrush = new System.Drawing.Drawing2D.LinearGradientBrush(
                            fill, SafariThemeEngine.SafariEmerald, SafariThemeEngine.HorizonCyan, 0f))
                            g.FillPath(fBrush, fPath);
                    }
                };
            }

            // Style Step 2 Kokonut UI Currency Transfer Checkout Card (pnlPaySummaryCard)
            if (pnlPaySummaryCard != null)
            {
                pnlPaySummaryCard.BackColor = SafariThemeEngine.GlassCard;
                pnlPaySummaryCard.BorderStyle = BorderStyle.None;
                SafariThemeEngine.EnableDoubleBuffering(pnlPaySummaryCard);
                pnlPaySummaryCard.Paint += (s, e) =>
                {
                    Graphics g = e.Graphics;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    RectangleF r = new RectangleF(1f, 1f, pnlPaySummaryCard.Width - 2f, pnlPaySummaryCard.Height - 2f);
                    using (var path = SafariThemeEngine.CreateRoundRect(r, 12f))
                    using (var bg = new System.Drawing.Drawing2D.LinearGradientBrush(
                        r, Color.FromArgb(24, 30, 48), Color.FromArgb(14, 18, 29), 135f))
                    using (var border = new Pen(Color.FromArgb(65, SafariThemeEngine.SunsetAmber), 1.2f))
                    {
                        g.FillPath(bg, path);
                        g.DrawPath(border, path);
                    }
                    using (var topPen = new Pen(SafariThemeEngine.SunsetAmber, 2.5f))
                        g.DrawLine(topPen, 12f, 1.5f, pnlPaySummaryCard.Width - 12f, 1.5f);
                };
            }

            InitializeAccordionGallery();

            // Attach Uiverse.io Gradient Glow CTA Buttons across the entire visitor journey
            SafariThemeEngine.AttachUiverseButtonGlow(btnQuickBrowse,    SafariThemeEngine.SafariEmerald, SafariThemeEngine.HorizonCyan);
            SafariThemeEngine.AttachUiverseButtonGlow(btnBookNow,        SafariThemeEngine.SafariEmerald, SafariThemeEngine.RoyalViolet);
            SafariThemeEngine.AttachUiverseButtonGlow(btnProceedPayment, SafariThemeEngine.HorizonCyan,   SafariThemeEngine.RoyalViolet);
            SafariThemeEngine.AttachUiverseButtonGlow(btnCancelBook,     SafariThemeEngine.HorizonCyan,   SafariThemeEngine.RoyalViolet, true);
            SafariThemeEngine.AttachUiverseButtonGlow(btnPayNow,         SafariThemeEngine.SafariEmerald, SafariThemeEngine.SunsetAmber);
            SafariThemeEngine.AttachUiverseButtonGlow(btnCancelPay,      SafariThemeEngine.SunsetAmber,   SafariThemeEngine.HorizonCyan, true);
            SafariThemeEngine.AttachUiverseButtonGlow(btnPrintInvoice,   SafariThemeEngine.RoyalViolet,   SafariThemeEngine.HorizonCyan);
            SafariThemeEngine.AttachUiverseButtonGlow(btnSaveInvoice,    SafariThemeEngine.HorizonCyan,   SafariThemeEngine.SafariEmerald, true);
            SafariThemeEngine.AttachUiverseButtonGlow(btnMakeAnother,    SafariThemeEngine.SafariEmerald, SafariThemeEngine.SunsetAmber);
            SafariThemeEngine.AttachUiverseButtonGlow(btnBackToDash,     SafariThemeEngine.RoyalViolet,   SafariThemeEngine.HorizonCyan, true);
            SafariThemeEngine.AttachUiverseButtonGlow(btnSaveProfile,    SafariThemeEngine.SafariEmerald, SafariThemeEngine.HorizonCyan);
            SafariThemeEngine.AttachUiverseButtonGlow(btnFloatingChat,      SafariThemeEngine.RoyalViolet,   SafariThemeEngine.SunsetAmber);
            SafariThemeEngine.AttachUiverseButtonGlow(btnFillDemoCard,      SafariThemeEngine.HorizonCyan,   SafariThemeEngine.RoyalViolet, true);
            SafariThemeEngine.AttachUiverseButtonGlow(btnOpenTicketsFolder, SafariThemeEngine.SunsetAmber,   SafariThemeEngine.SafariEmerald);
            SafariThemeEngine.AttachUiverseButtonGlow(btnSendContactMessage,SafariThemeEngine.SafariEmerald, SafariThemeEngine.HorizonCyan);
        }

        private void StyleVisitorStatCard(Panel card, Label lblCount, Label lblCap, Color accent)
        {
            if (card == null) return;
            card.BackColor = SafariThemeEngine.GlassSurface;
            card.BorderStyle = BorderStyle.None;
            SafariThemeEngine.EnableDoubleBuffering(card);
            card.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                RectangleF r = new RectangleF(1f, 1f, card.Width - 2f, card.Height - 2f);
                using (var path = SafariThemeEngine.CreateRoundRect(r, 12f))
                using (var bg = new System.Drawing.Drawing2D.LinearGradientBrush(
                    r, Color.FromArgb(20, 26, 42), Color.FromArgb(13, 17, 28), 135f))
                using (var pen = new Pen(Color.FromArgb(45, 255, 255, 255), 1f))
                {
                    e.Graphics.FillPath(bg, path);
                    e.Graphics.DrawPath(pen, path);
                }
                using (var topPen = new Pen(accent, 2.5f))
                    e.Graphics.DrawLine(topPen, 12f, 1.5f, card.Width - 12f, 1.5f);
            };
            if (lblCount != null)
            {
                lblCount.BackColor = Color.Transparent;
                lblCount.ForeColor = accent;
            }
            if (lblCap != null)
            {
                lblCap.BackColor = Color.Transparent;
                lblCap.ForeColor = SafariThemeEngine.TextSecondary;
            }
        }

        private void StyleVisitorControlsDark(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Label lbl)
                {
                    lbl.BackColor = Color.Transparent;
                    if (lbl.ForeColor == Color.Red)
                        lbl.ForeColor = Color.FromArgb(255, 110, 110);
                    else if (lbl == lblBookTotal || lbl == lblPayTotal || lbl == lblInvHeading)
                        lbl.ForeColor = SafariThemeEngine.SafariEmerald;
                    else if (lbl == lblBookName)
                        lbl.ForeColor = SafariThemeEngine.HorizonCyan;
                    else if (lbl.Font.Size >= 14F || lbl.Font.Bold)
                        lbl.ForeColor = SafariThemeEngine.TextPrimary;
                    else
                        lbl.ForeColor = SafariThemeEngine.TextSecondary;
                }
                else if (c is TextBox txt)
                {
                    txt.BackColor = SafariThemeEngine.InputBg;
                    txt.ForeColor = Color.White;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (c is ComboBox cbo)
                {
                    cbo.BackColor = SafariThemeEngine.InputBg;
                    cbo.ForeColor = Color.White;
                    cbo.FlatStyle = FlatStyle.Flat;
                }
                else if (c is NumericUpDown nud)
                {
                    nud.BackColor = SafariThemeEngine.InputBg;
                    nud.ForeColor = Color.White;
                }
                else if (c is RichTextBox rtb)
                {
                    rtb.BackColor = Color.FromArgb(12, 16, 26);
                    rtb.ForeColor = Color.FromArgb(225, 240, 255);
                    rtb.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (c is Panel subPanel)
                {
                    StyleVisitorControlsDark(subPanel);
                }
            }
        }

        private void VisitorPage_Paint(object sender, PaintEventArgs e)
        {
            var pnl = sender as Panel;
            if (pnl == null) return;

            Color accent = SafariThemeEngine.SafariEmerald;
            string badge = "KOKONUT & BKLIT SAFARI PORTAL";
            if (pnl == pnlBrowse)      { accent = SafariThemeEngine.HorizonCyan; badge = "KOKONUT ACTION SEARCH & CATALOG"; }
            else if (pnl == pnlBook)   { accent = SafariThemeEngine.HorizonCyan; badge = "STEP 1 • SAFARI CONFIGURATOR"; }
            else if (pnl == pnlPayment){ accent = SafariThemeEngine.SunsetAmber; badge = "STEP 2 • KOKONUT ZAR CHECKOUT"; }
            else if (pnl == pnlInvoice){ accent = SafariThemeEngine.SafariEmerald; badge = "STEP 3 • VERIFIED RECEIPT PRINTER"; }
            else if (pnl == pnlMyBookings) { accent = SafariThemeEngine.RoyalViolet; badge = "VISITOR BOOKING LEDGER"; }
            else if (pnl == pnlProfile){ accent = SafariThemeEngine.SunsetAmber; badge = "EXPLORER PROFILE & SECURITY"; }

            SafariThemeEngine.PaintKokonutBackgroundPathsAndGrid(e.Graphics, pnl.Width, pnl.Height, accent, badge);

            if (pnl == pnlBook)
                SafariThemeEngine.DrawBookingProgressStepper(e.Graphics, pnl.Width, 1);
            else if (pnl == pnlPayment)
                SafariThemeEngine.DrawBookingProgressStepper(e.Graphics, pnl.Width, 2);
            else if (pnl == pnlInvoice)
                SafariThemeEngine.DrawBookingProgressStepper(e.Graphics, pnl.Width, 3);
        }

        // =================================================================
        //  INTERACTIVE ACCORDION GALLERY (<AccordionGallery defaultIndex={2} expandRatio={0.52} trigger="hover" />)
        // =================================================================

        private sealed class AccordionGalleryItem
        {
            public Activity Activity { get; set; }
            public string ShortLabel { get; set; }
            public float CurrentRatio { get; set; }
            public float TargetRatio { get; set; }
            public RectangleF CardBounds { get; set; }
            public RectangleF BookBtnBounds { get; set; }
        }

        private readonly List<Activity> _filteredBrowseActivities = new List<Activity>();
        private readonly List<AccordionGalleryItem> _galleryItems = new List<AccordionGalleryItem>();
        private readonly List<RectangleF> _galleryPageBtnBounds = new List<RectangleF>();

        private const int AccordionDefaultIndex = 2;
        private const float AccordionExpandRatio = 0.52f;

        private int _accordionActiveIndex = AccordionDefaultIndex;
        private int _accordionPageMode = 0; // 0 = Page 1 (1-5), 1 = Page 2 (6-10), 2 = All
        private string _selectedGalleryActivityId = null;
        private System.Windows.Forms.Timer _accordionAnimTimer;

        private void InitializeAccordionGallery()
        {
            if (pnlAccordionGallery == null) return;
            pnlAccordionGallery.BackColor = Color.Transparent;
            pnlAccordionGallery.BackgroundImage = null;
            SafariThemeEngine.EnableDoubleBuffering(pnlAccordionGallery);

            pnlAccordionGallery.Paint -= PnlAccordionGallery_Paint;
            pnlAccordionGallery.Paint += PnlAccordionGallery_Paint;
            pnlAccordionGallery.MouseMove += PnlAccordionGallery_MouseMove;
            pnlAccordionGallery.MouseDown += PnlAccordionGallery_MouseDown;
            pnlAccordionGallery.MouseWheel += PnlAccordionGallery_MouseWheel;
            pnlAccordionGallery.MouseEnter += (s, e) => pnlAccordionGallery.Focus();

            _accordionAnimTimer = new System.Windows.Forms.Timer { Interval = 16 };
            _accordionAnimTimer.Tick += AccordionAnimTimer_Tick;
            _accordionAnimTimer.Start();
        }

        private void RebuildAccordionGalleryItems()
        {
            if (_filteredBrowseActivities.Count == 0)
            {
                _galleryItems.Clear();
                pnlAccordionGallery?.Invalidate();
                return;
            }

            // Determine visible slice (5 items per page by default to match the 5-item AccordionGallery snippet)
            List<Activity> slice;
            if (_filteredBrowseActivities.Count <= 5 || _accordionPageMode == 2)
            {
                slice = new List<Activity>(_filteredBrowseActivities);
            }
            else if (_accordionPageMode == 1)
            {
                slice = _filteredBrowseActivities.GetRange(5, _filteredBrowseActivities.Count - 5);
            }
            else
            {
                slice = _filteredBrowseActivities.GetRange(0, Math.Min(5, _filteredBrowseActivities.Count));
            }

            // Preserve hovered/selected activity across 5-second auto-refreshes if still in slice
            int preservedIdx = -1;
            if (!string.IsNullOrEmpty(_selectedGalleryActivityId))
            {
                for (int i = 0; i < slice.Count; i++)
                {
                    if (slice[i].ActivityID == _selectedGalleryActivityId)
                    {
                        preservedIdx = i;
                        break;
                    }
                }
            }

            bool sameCount = (_galleryItems.Count == slice.Count);
            if (!sameCount)
            {
                _galleryItems.Clear();
                for (int i = 0; i < slice.Count; i++)
                {
                    _galleryItems.Add(new AccordionGalleryItem
                    {
                        Activity = slice[i],
                        ShortLabel = GetShortGalleryLabel(slice[i]),
                        CurrentRatio = 1f / slice.Count,
                        TargetRatio = 1f / slice.Count
                    });
                }
            }
            else
            {
                for (int i = 0; i < slice.Count; i++)
                {
                    _galleryItems[i].Activity = slice[i];
                    _galleryItems[i].ShortLabel = GetShortGalleryLabel(slice[i]);
                }
            }

            if (preservedIdx >= 0)
                _accordionActiveIndex = preservedIdx;
            else
                _accordionActiveIndex = Math.Min(AccordionDefaultIndex, _galleryItems.Count - 1);

            UpdateAccordionTargetRatios(!sameCount);
            SyncGallerySelectionToGrid();
            pnlAccordionGallery?.Invalidate();
        }

        private static string GetShortGalleryLabel(Activity a)
        {
            if (a == null || string.IsNullOrEmpty(a.Name)) return "Tour";
            string n = a.Name;
            if (n.IndexOf("Sunrise Safari", StringComparison.OrdinalIgnoreCase) >= 0) return "Savanna";
            if (n.IndexOf("Night Safari", StringComparison.OrdinalIgnoreCase) >= 0)   return "Bushfire";
            if (n.IndexOf("Winelands", StringComparison.OrdinalIgnoreCase) >= 0)      return "Winelands";
            if (n.IndexOf("Abseil", StringComparison.OrdinalIgnoreCase) >= 0)         return "Cliffside";
            if (n.IndexOf("Shark", StringComparison.OrdinalIgnoreCase) >= 0)          return "Deep Reef";
            if (n.IndexOf("Dune", StringComparison.OrdinalIgnoreCase) >= 0)           return "Sand Dunes";
            if (n.IndexOf("Jazz", StringComparison.OrdinalIgnoreCase) >= 0)           return "Skyline";
            if (n.IndexOf("Cruise", StringComparison.OrdinalIgnoreCase) >= 0)         return "Harbour";
            if (n.IndexOf("Lion", StringComparison.OrdinalIgnoreCase) >= 0)           return "Ridgeline";
            if (n.IndexOf("Cape Point", StringComparison.OrdinalIgnoreCase) >= 0)     return "Boulders";
            return n.Length > 12 ? n.Substring(0, 11) + "…" : n;
        }

        private void UpdateAccordionTargetRatios(bool snapImmediately = false)
        {
            int n = _galleryItems.Count;
            if (n == 0) return;

            if (n == 1)
            {
                _galleryItems[0].TargetRatio = 1f;
                if (snapImmediately) _galleryItems[0].CurrentRatio = 1f;
                return;
            }

            float exp = n <= 6 ? AccordionExpandRatio : 0.42f;
            float collapsed = (1f - exp) / (n - 1);

            for (int i = 0; i < n; i++)
            {
                float target = (i == _accordionActiveIndex) ? exp : collapsed;
                _galleryItems[i].TargetRatio = target;
                if (snapImmediately)
                    _galleryItems[i].CurrentRatio = target;
            }
        }

        private void SyncGallerySelectionToGrid()
        {
            if (_accordionActiveIndex < 0 || _accordionActiveIndex >= _galleryItems.Count) return;
            var activeAct = _galleryItems[_accordionActiveIndex].Activity;
            if (activeAct == null) return;

            _selectedGalleryActivityId = activeAct.ActivityID;

            if (dgvActivities != null && dgvActivities.Rows.Count > 0)
            {
                dgvActivities.ClearSelection();
                foreach (DataGridViewRow row in dgvActivities.Rows)
                {
                    if (row.Cells["ActivityID"].Value?.ToString() == activeAct.ActivityID)
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }

            if (btnBookNow != null)
            {
                btnBookNow.Text = activeAct.SeatsAvailable > 0
                    ? $"Book Selected: {activeAct.Name} (R{activeAct.Price:N2})  →"
                    : $"SOLD OUT: {activeAct.Name}";
                btnBookNow.Enabled = activeAct.SeatsAvailable > 0;
            }
        }

        private void AccordionAnimTimer_Tick(object sender, EventArgs e)
        {
            if (pnlBrowse == null || !pnlBrowse.Visible || _galleryItems.Count <= 1) return;

            bool needsRedraw = false;
            float sum = 0f;
            for (int i = 0; i < _galleryItems.Count; i++)
            {
                float diff = _galleryItems[i].TargetRatio - _galleryItems[i].CurrentRatio;
                if (Math.Abs(diff) > 0.0015f)
                {
                    _galleryItems[i].CurrentRatio += diff * 0.26f;
                    needsRedraw = true;
                }
                else
                {
                    _galleryItems[i].CurrentRatio = _galleryItems[i].TargetRatio;
                }
                sum += _galleryItems[i].CurrentRatio;
            }

            if (sum > 0.001f)
            {
                for (int i = 0; i < _galleryItems.Count; i++)
                    _galleryItems[i].CurrentRatio /= sum;
            }

            if (needsRedraw)
                pnlAccordionGallery?.Invalidate();
        }

        private void PnlAccordionGallery_MouseMove(object sender, MouseEventArgs e)
        {
            // Check if hovering over page mode pills at top-right
            for (int p = 0; p < _galleryPageBtnBounds.Count; p++)
            {
                if (_galleryPageBtnBounds[p].Contains(e.Location))
                {
                    pnlAccordionGallery.Cursor = Cursors.Hand;
                    return;
                }
            }

            // trigger="hover": Expand whichever accordion slice the cursor hovers over
            int hit = -1;
            for (int i = 0; i < _galleryItems.Count; i++)
            {
                if (_galleryItems[i].CardBounds.Contains(e.Location))
                {
                    hit = i;
                    break;
                }
            }

            if (hit >= 0)
            {
                pnlAccordionGallery.Cursor = Cursors.Hand;
                if (hit != _accordionActiveIndex)
                {
                    _accordionActiveIndex = hit;
                    UpdateAccordionTargetRatios(false);
                    SyncGallerySelectionToGrid();
                    pnlAccordionGallery.Invalidate();
                }
            }
            else
            {
                pnlAccordionGallery.Cursor = Cursors.Default;
            }
        }

        private void PnlAccordionGallery_MouseDown(object sender, MouseEventArgs e)
        {
            // Check page mode selector pills first
            for (int p = 0; p < _galleryPageBtnBounds.Count; p++)
            {
                if (_galleryPageBtnBounds[p].Contains(e.Location))
                {
                    _accordionPageMode = p;
                    _selectedGalleryActivityId = null;
                    RebuildAccordionGalleryItems();
                    return;
                }
            }

            // Check if user clicked an accordion card or its embedded "Book This Tour ->" button
            for (int i = 0; i < _galleryItems.Count; i++)
            {
                var item = _galleryItems[i];
                if (item.CardBounds.Contains(e.Location))
                {
                    _accordionActiveIndex = i;
                    UpdateAccordionTargetRatios(false);
                    SyncGallerySelectionToGrid();

                    if (item.BookBtnBounds.Contains(e.Location) || e.Clicks >= 1)
                    {
                        btnBookNow_Click(this, EventArgs.Empty);
                    }
                    return;
                }
            }
        }

        private void PnlAccordionGallery_MouseWheel(object sender, MouseEventArgs e)
        {
            if (_filteredBrowseActivities.Count > 5 && _accordionPageMode < 2)
            {
                _accordionPageMode = e.Delta < 0 ? 1 : 0;
                _selectedGalleryActivityId = null;
                RebuildAccordionGalleryItems();
            }
        }

        private void PnlHomeAnalytics_Paint(object sender, PaintEventArgs e)
        {
            if (pnlHomeAnalytics == null) return;
            SafariThemeEngine.DrawVisitorAnalyticsHub(
                e.Graphics,
                pnlHomeAnalytics.Width,
                pnlHomeAnalytics.Height,
                _cachedTotalBookings,
                _cachedUpcomingBookings,
                _cachedTotalSpent,
                _cachedActivities,
                0f);
        }

        private void SeedDesignTimeGalleryPreview()
        {
            var sample = new[]
            {
                new Activity { ActivityID = "1", Category = "Safari", Name = "Big Five Sunrise Safari", Description = "Witness the Big Five at dawn in their natural habitat with a guide and breakfast.", Price = 1850m, Date = DateTime.Today.AddDays(14), TotalSeats = 12, SeatsAvailable = 8 },
                new Activity { ActivityID = "2", Category = "Safari", Name = "Night Safari & Bush Braai", Description = "Explore the bush after dark with spotlight drives and a traditional South African braai.", Price = 2200m, Date = DateTime.Today.AddDays(17), TotalSeats = 10, SeatsAvailable = 10 },
                new Activity { ActivityID = "3", Category = "Safari", Name = "Cape Winelands & Wildlife Drive", Description = "Combine a game drive through a private reserve with a curated wine tasting.", Price = 1650m, Date = DateTime.Today.AddDays(19), TotalSeats = 16, SeatsAvailable = 16 },
                new Activity { ActivityID = "4", Category = "Adventure", Name = "Abseil Table Mountain", Description = "Descend 112 metres down the face of Table Mountain with certified instructors.", Price = 950m, Date = DateTime.Today.AddDays(16), TotalSeats = 20, SeatsAvailable = 20 },
                new Activity { ActivityID = "5", Category = "Adventure", Name = "Shark Cage Diving – Gansbaai", Description = "Come face to face with great white sharks in a supervised shark cage.", Price = 2400m, Date = DateTime.Today.AddDays(21), TotalSeats = 8, SeatsAvailable = 8 }
            };
            _filteredBrowseActivities.Clear();
            _filteredBrowseActivities.AddRange(sample);
            RebuildAccordionGalleryItems();
        }

        private void PnlAccordionGallery_Paint(object sender, PaintEventArgs e)
        {
            if (pnlAccordionGallery == null) return;
            if (_galleryItems.Count == 0 && System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
            {
                SeedDesignTimeGalleryPreview();
            }
            if (_galleryItems.Count == 0) return;

            int w = pnlAccordionGallery.Width;
            int h = pnlAccordionGallery.Height;
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Top bar inside gallery: instruction + page switcher pills when > 5 items
            float headerH = 34f;
            using (var infoFont = new Font("Segoe UI", 8.5F, FontStyle.Bold))
            using (var infoBrush = new SolidBrush(SafariThemeEngine.TextSecondary))
            {
                g.DrawString(
                    "✨ Hover across panels to expand (52% ratio) & read full tour description on the image • Click any panel to book",
                    infoFont, infoBrush, 4f, 6f);
            }

            _galleryPageBtnBounds.Clear();
            if (_filteredBrowseActivities.Count > 5)
            {
                string[] pillLabels = { "Tours 1–5", $"Tours 6–{_filteredBrowseActivities.Count}", $"All {_filteredBrowseActivities.Count}" };
                float px = w - 282f;
                using (var pFont = new Font("Segoe UI", 7.75F, FontStyle.Bold))
                {
                    var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    for (int p = 0; p < pillLabels.Length; p++)
                    {
                        RectangleF pRect = new RectangleF(px + p * 92f, 2f, 86f, 24f);
                        _galleryPageBtnBounds.Add(pRect);
                        bool active = (_accordionPageMode == p);
                        using (var path = SafariThemeEngine.CreateRoundRect(pRect, 12f))
                        using (var fill = new SolidBrush(active ? Color.FromArgb(65, SafariThemeEngine.SafariEmerald) : Color.FromArgb(22, 28, 44)))
                        using (var pen = new Pen(active ? SafariThemeEngine.SafariEmerald : Color.FromArgb(55, 255, 255, 255), active ? 1.5f : 1f))
                        using (var txtBrush = new SolidBrush(active ? Color.White : SafariThemeEngine.TextSecondary))
                        {
                            g.FillPath(fill, path);
                            g.DrawPath(pen, path);
                            g.DrawString(pillLabels[p], pFont, txtBrush, pRect, sf);
                        }
                    }
                }
            }

            int n = _galleryItems.Count;
            float gap = 10f;
            float availW = Math.Max(200f, w - gap * (n - 1) - 4f);
            float cardY = headerH;
            float cardH = Math.Max(180f, h - headerH - 4f);

            float curX = 2f;
            for (int i = 0; i < n; i++)
            {
                var item = _galleryItems[i];
                float cardW = (i == n - 1)
                    ? Math.Max(48f, (w - 2f) - curX)
                    : Math.Max(48f, availW * item.CurrentRatio);

                RectangleF cardRect = new RectangleF(curX, cardY, cardW, cardH);
                item.CardBounds = cardRect;
                bool isExpanded = (i == _accordionActiveIndex);

                PaintSingleAccordionSlice(g, item, cardRect, isExpanded);
                curX += cardW + gap;
            }
        }

        private void PaintSingleAccordionSlice(
            Graphics g, AccordionGalleryItem item, RectangleF rect, bool isExpanded)
        {
            Activity act = item.Activity;
            if (act == null || rect.Width < 12f || rect.Height < 40f) return;

            Color catAccent = GetCategoryAccentColor(act.Category);

            using (var clipPath = SafariThemeEngine.CreateRoundRect(rect, 16f))
            {
                System.Drawing.Drawing2D.GraphicsState state = g.Save();
                g.SetClip(clipPath, System.Drawing.Drawing2D.CombineMode.Intersect);

                // 1. Center-crop draw the custom portrait tour image (900x1200 ratio)
                Bitmap bmp = SafariThemeEngine.GetOrCreateTourImage(act);
                if (bmp != null)
                {
                    float scale = Math.Max(rect.Width / bmp.Width, rect.Height / bmp.Height);
                    float drawW = bmp.Width * scale;
                    float drawH = bmp.Height * scale;
                    float drawX = rect.X + (rect.Width - drawW) / 2f;
                    float drawY = rect.Y + (rect.Height - drawH) / 2f;
                    g.DrawImage(bmp, new RectangleF(drawX, drawY, drawW, drawH));
                }

                // 2. Subtle dark vignette on collapsed cards vs rich frosted glass panel on expanded card
                if (!isExpanded)
                {
                    using (var dimBrush = new SolidBrush(Color.FromArgb(88, 6, 8, 16)))
                        g.FillRectangle(dimBrush, rect);

                    RectangleF botGradRect = new RectangleF(rect.X, rect.Bottom - 160f, rect.Width, 162f);
                    using (var botGrad = new System.Drawing.Drawing2D.LinearGradientBrush(
                        botGradRect, Color.FromArgb(0, 6, 8, 14), Color.FromArgb(235, 6, 8, 14), 90f))
                    {
                        g.FillRectangle(botGrad, botGradRect);
                    }

                    // Category color dot at top
                    using (var dotBrush = new SolidBrush(catAccent))
                        g.FillEllipse(dotBrush, rect.X + rect.Width / 2f - 5f, rect.Y + 16f, 10f, 10f);

                    // Compact label + price at bottom (or rotated if slice is narrow)
                    using (var lblFont = new Font("Segoe UI", 10F, FontStyle.Bold))
                    using (var priceFont = new Font("Segoe UI", 8F, FontStyle.Bold))
                    using (var whiteBrush = new SolidBrush(Color.White))
                    using (var accentBrush = new SolidBrush(catAccent))
                    {
                        var sf = new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center,
                            Trimming = StringTrimming.EllipsisCharacter
                        };
                        g.DrawString(item.ShortLabel, lblFont, whiteBrush,
                            new RectangleF(rect.X + 4f, rect.Bottom - 62f, rect.Width - 8f, 26f), sf);
                        g.DrawString($"R{act.Price:N0}", priceFont, accentBrush,
                            new RectangleF(rect.X + 4f, rect.Bottom - 34f, rect.Width - 8f, 20f), sf);
                    }
                    item.BookBtnBounds = RectangleF.Empty;
                }
                else
                {
                    // Top category pill + live seat badge on expanded card
                    using (var pillFont = new Font("Segoe UI", 8F, FontStyle.Bold))
                    {
                        string catText = act.Category.ToUpperInvariant();
                        SizeF catSz = g.MeasureString(catText, pillFont);
                        RectangleF catPill = new RectangleF(rect.X + 18f, rect.Y + 16f, catSz.Width + 18f, 24f);
                        using (var cPath = SafariThemeEngine.CreateRoundRect(catPill, 12f))
                        using (var cFill = new SolidBrush(Color.FromArgb(215, 10, 14, 24)))
                        using (var cPen = new Pen(catAccent, 1.4f))
                        using (var cTxt = new SolidBrush(catAccent))
                        {
                            g.FillPath(cFill, cPath);
                            g.DrawPath(cPen, cPath);
                            var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                            g.DrawString(catText, pillFont, cTxt, catPill, sf);
                        }

                        string seatText = act.SeatsAvailable > 0 ? $"{act.SeatsAvailable} SEATS LEFT" : "SOLD OUT";
                        Color seatColor = act.SeatsAvailable > 0 ? SafariThemeEngine.SafariEmerald : SafariThemeEngine.CrimsonCoral;
                        SizeF seatSz = g.MeasureString(seatText, pillFont);
                        RectangleF seatPill = new RectangleF(rect.Right - seatSz.Width - 36f, rect.Y + 16f, seatSz.Width + 18f, 24f);
                        using (var sPath = SafariThemeEngine.CreateRoundRect(seatPill, 12f))
                        using (var sFill = new SolidBrush(Color.FromArgb(215, 10, 14, 24)))
                        using (var sPen = new Pen(seatColor, 1.4f))
                        using (var sTxt = new SolidBrush(seatColor))
                        {
                            g.FillPath(sFill, sPath);
                            g.DrawPath(sPen, sPath);
                            var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                            g.DrawString(seatText, pillFont, sTxt, seatPill, sf);
                        }
                    }

                    // Frosted dark-glass overlay card at the bottom of the hovered image showing the full Tour Description!
                    float overlayH = Math.Min(215f, rect.Height * 0.48f);
                    RectangleF overlayRect = new RectangleF(rect.X + 14f, rect.Bottom - overlayH - 14f, Math.Max(80f, rect.Width - 28f), overlayH);

                    using (var ovPath = SafariThemeEngine.CreateRoundRect(overlayRect, 14f))
                    using (var ovGrad = new System.Drawing.Drawing2D.LinearGradientBrush(
                        overlayRect, Color.FromArgb(228, 12, 16, 28), Color.FromArgb(245, 7, 9, 16), 90f))
                    using (var ovPen = new Pen(Color.FromArgb(90, catAccent), 1.2f))
                    {
                        g.FillPath(ovGrad, ovPath);
                        g.DrawPath(ovPen, ovPath);
                    }

                    using (var titleFont = new Font("Segoe UI", 13.5F, FontStyle.Bold))
                    using (var descFont = new Font("Segoe UI", 9.25F, FontStyle.Regular))
                    using (var metaFont = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                    using (var whiteBrush = new SolidBrush(Color.White))
                    using (var descBrush = new SolidBrush(Color.FromArgb(218, 226, 245)))
                    using (var accentBrush = new SolidBrush(catAccent))
                    {
                        // Tour Title
                        g.DrawString(act.Name, titleFont, whiteBrush,
                            new RectangleF(overlayRect.X + 16f, overlayRect.Y + 12f, overlayRect.Width - 32f, 28f));

                        // Full Tour Description on the image when hovered
                        RectangleF descRect = new RectangleF(
                            overlayRect.X + 16f,
                            overlayRect.Y + 44f,
                            overlayRect.Width - 32f,
                            Math.Max(36f, overlayRect.Height - 102f));
                        g.DrawString(act.Description, descFont, descBrush, descRect);

                        // Date & Price footer + Embedded "Book This Tour ->" CTA Pill
                        float footY = overlayRect.Bottom - 44f;
                        g.DrawString($"📅 {act.Date:dd MMM yyyy}   •   R{act.Price:N2} / person",
                            metaFont, accentBrush, overlayRect.X + 16f, footY + 6f);

                        if (overlayRect.Width >= 290f && act.SeatsAvailable > 0)
                        {
                            RectangleF btnRect = new RectangleF(overlayRect.Right - 154f, footY, 138f, 32f);
                            item.BookBtnBounds = btnRect;
                            using (var bPath = SafariThemeEngine.CreateRoundRect(btnRect, 16f))
                            using (var bGrad = new System.Drawing.Drawing2D.LinearGradientBrush(
                                btnRect, SafariThemeEngine.SafariEmerald, SafariThemeEngine.HorizonCyan, 15f))
                            {
                                g.FillPath(bGrad, bPath);
                                var sfBtn = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                                g.DrawString("Book Tour  →", new Font("Segoe UI", 8.75F, FontStyle.Bold), whiteBrush, btnRect, sfBtn);
                            }
                        }
                        else
                        {
                            item.BookBtnBounds = overlayRect;
                        }
                    }
                }

                g.Restore(state);

                // Card outer border (glowing accent when expanded)
                using (var borderPen = new Pen(
                    isExpanded ? catAccent : Color.FromArgb(55, 255, 255, 255),
                    isExpanded ? 2.2f : 1.1f))
                {
                    g.DrawPath(borderPen, clipPath);
                }
            }
        }

        private static Color GetCategoryAccentColor(string category)
        {
            if (string.IsNullOrEmpty(category)) return SafariThemeEngine.SafariEmerald;
            if (category.IndexOf("Safari", StringComparison.OrdinalIgnoreCase) >= 0)    return SafariThemeEngine.SunsetAmber;
            if (category.IndexOf("Adventure", StringComparison.OrdinalIgnoreCase) >= 0) return SafariThemeEngine.HorizonCyan;
            if (category.IndexOf("Event", StringComparison.OrdinalIgnoreCase) >= 0)     return SafariThemeEngine.RoyalViolet;
            return SafariThemeEngine.SafariEmerald;
        }

    }
}
