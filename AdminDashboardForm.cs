// =============================================================================
// Forms/AdminDashboardForm.cs
// Blue Horizons Tours – Administrator Dashboard (Stage 4 Complete)
//
// Features:
//   1. Security check: Role = Admin required; visitors redirected to VisitorDashboardForm.
//   2. Inactivity timer: Auto-logout after 5 minutes of no activity.
//   3. Side Menu: Overview, Manage Activities, All Bookings, Attendance, Reports, Change Password, Log Out.
//   4. Overview: Tiles for total bookings, revenue, upcoming events, seats remaining.
//   5. Manage Activities: Add, Edit, Delete (categories: Safari, Adventure, Event, Hiking Trail).
//      Validates positive price and whole number seats >= 0. Saves to activities.txt.
//   6. All Bookings: Grid of ALL visitor bookings with search & filter by visitor name, activity, or date.
//   7. Attendance: Mark bookings as Attended, No-Show, or Pending. Saves to bookings.txt.
//   8. Reports: Calculates total bookings, revenue, attendance rate %, bookings per activity.
//      Displays on screen and exports report to /Data/Reports/ folder.
//   9. Change Password: Verifies current password, hashes & saves new password to users.txt.
//   10. Log Out: Closes dashboard and returns to SignInForm.
// =============================================================================

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PROJECTT.Models;
using PROJECTT.Services;

namespace PROJECTT.Forms
{
    public partial class AdminDashboardForm : Form, IMessageFilter
    {
        // ── State & Security ───────────────────────────────────────────────
        private User _adminUser;
        private Activity _selectedActivity = null;
        private Booking _selectedBooking = null;

        // Inactivity Timer (5 Minutes = 300,000 ms)
        private System.Windows.Forms.Timer _inactivityTimer;
        private const int InactivityTimeoutMs = 300000;

        // Auto-refresh Timer (5 Seconds = 5,000 ms)
        private System.Windows.Forms.Timer _refreshTimer;

        // Animated Beam Hub Timer (~33 FPS) & Interactive Node State
        private System.Windows.Forms.Timer _beamTimer;
        private float _beamTick = 0f;
        private int _hoveredNodeIndex = -1;
        private RectangleF[] _nodeRects = new RectangleF[7];

        // ── Shared Styling Constants ───────────────────────────────────────
        private static readonly Color Teal        = Color.FromArgb(104, 92, 255);  // Kexsio Electric Violet (#685CFF)
        private static readonly Color DarkTeal    = Color.FromArgb(9, 9, 16);      // Dark Obsidian Sidebar (#090910)
        private static readonly Color SidebarTop  = Color.FromArgb(14, 14, 24);    // Sidebar Header (#0E0E18)
        private static readonly Color LogoutRed   = Color.FromArgb(190, 38, 60);   // Crimson Logout
        private static readonly Color LightGray   = Color.FromArgb(5, 5, 9);       // Cosmic Dark Canvas (#050509)
        private static readonly Color TextGray    = Color.FromArgb(165, 165, 190); // Muted Silver Label
        private static readonly Font  FontHeading = new Font("Arial", 18F, FontStyle.Bold);
        private static readonly Font  FontLabel   = new Font("Arial",  9F, FontStyle.Bold);
        private static readonly Font  FontField   = new Font("Arial", 10F);
        private static readonly Font  FontBtn     = new Font("Arial", 10.5F, FontStyle.Bold);
        private static readonly Font  FontNav     = new Font("Arial", 10F);
        private static readonly Font  FontSmall   = new Font("Arial",  8.5F);

        // ── Public Property ────────────────────────────────────────────────
        public User LoggedInUser => _adminUser;

        // ── Constructors (Parameterless constructor enables Visual Studio GUI Designer) ──
        public AdminDashboardForm()
        {
            InitializeComponent();
            FileService.AutoUpdateNoShowBookings();
            SetupRuntimeGridAndCombos();
            ApplyDarkGlassThemeAndBeams();
            ConfigureResponsiveScaling();
        }

        public AdminDashboardForm(User user) : this()
        {
            _adminUser = user;

            // Security Check: Enforce Role = Admin
            if (user == null || !string.Equals(user.Role, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                // Redirect non-admin user to VisitorDashboardForm
                this.Load += (s, e) =>
                {
                    MessageBox.Show("Access denied. Admin privileges required.", "Security Alert",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Hide();
                    var visitorDash = new VisitorDashboardForm(user);
                    visitorDash.FormClosed += (s2, e2) => this.Close();
                    visitorDash.Show();
                };
                return;
            }

            this.Text = $"Blue Horizons Tours – Admin Dashboard ({user.FirstName} {user.LastName})";
            lblSidebarUser.Text = $"Admin: {user.FirstName}";
            lblOverviewSub.Text = $"Welcome back, {user.FirstName} {user.LastName} ({user.Email})";

            // Register Message Filter for 5-Minute Inactivity Auto-Logout
            Application.AddMessageFilter(this);
            InitInactivityTimer();

            // 5-second automatic refresh timer for All Bookings & Overview
            _refreshTimer = new System.Windows.Forms.Timer { Interval = 5000 };
            _refreshTimer.Tick += (s, e) =>
            {
                FileService.AutoUpdateNoShowBookings();
                if (pnlBookings != null && pnlBookings.Visible) LoadAllBookings();
                if (pnlOverview != null && pnlOverview.Visible) RefreshOverviewStats();
                if (pnlAttendance != null && pnlAttendance.Visible) LoadAttendanceBookings();
            };
            _refreshTimer.Start();

            this.Activated += (s, e) =>
            {
                FileService.AutoUpdateNoShowBookings();
                if (pnlBookings != null && pnlBookings.Visible) LoadAllBookings();
                if (pnlOverview != null && pnlOverview.Visible) RefreshOverviewStats();
                if (pnlAttendance != null && pnlAttendance.Visible) LoadAttendanceBookings();
            };

            ShowPanel(pnlOverview);
            RefreshOverviewStats();
        }

        private void SetupRuntimeGridAndCombos()
        {
            if (cboCategory != null && cboCategory.Items.Count == 0)
            {
                cboCategory.Items.AddRange(new object[] { "Safari", "Adventure", "Event", "Hiking Trail" });
                cboCategory.SelectedIndex = 0;
            }

            if (cboActImagePreset != null && cboActImagePreset.Items.Count == 0)
            {
                cboActImagePreset.Items.AddRange(SafariThemeEngine.BuiltInPresetNames);
                cboActImagePreset.SelectedIndex = 0;
            }

            if (cboAttendanceStatus != null && cboAttendanceStatus.Items.Count == 0)
            {
                cboAttendanceStatus.Items.AddRange(new object[] { "Attended", "No Show", "Pending" });
                cboAttendanceStatus.SelectedIndex = 0;
            }

            if (dtpDate != null)
            {
                dtpDate.MinDate = DateTime.Today;
                dtpDate.Value = DateTime.Today.AddDays(7);
            }

            if (dtpBookingDateFilter != null)
            {
                dtpBookingDateFilter.Value = DateTime.Today;
            }

            if (dgvActivities != null && dgvActivities.Columns.Count == 0)
            {
                ConfigureGridStyle(dgvActivities, Color.FromArgb(244, 252, 250));
                dgvActivities.Columns.Add(new DataGridViewTextBoxColumn { Name = "ActivityID", Visible = false });
                dgvActivities.Columns.Add(new DataGridViewTextBoxColumn { Name = "Category",   HeaderText = "Category",     FillWeight = 85 });
                dgvActivities.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name",       HeaderText = "Activity Name",FillWeight = 140 });
                dgvActivities.Columns.Add(new DataGridViewTextBoxColumn { Name = "Description",HeaderText = "Description",  FillWeight = 200 });
                dgvActivities.Columns.Add(new DataGridViewTextBoxColumn { Name = "Price",      HeaderText = "Price (ZAR)",  FillWeight = 80 });
                dgvActivities.Columns.Add(new DataGridViewTextBoxColumn { Name = "Date",       HeaderText = "Date",         FillWeight = 90 });
                dgvActivities.Columns.Add(new DataGridViewTextBoxColumn { Name = "TotalSeats", HeaderText = "Total Seats",  FillWeight = 75 });
                dgvActivities.Columns.Add(new DataGridViewTextBoxColumn { Name = "Available",  HeaderText = "Seats Left",   FillWeight = 75 });
                dgvActivities.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            if (dgvAllBookings != null && dgvAllBookings.Columns.Count == 0)
            {
                ConfigureGridStyle(dgvAllBookings, Color.FromArgb(244, 252, 250));
                dgvAllBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "BookingID",  Visible = false });
                dgvAllBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "Visitor",    HeaderText = "Visitor Name", FillWeight = 140 });
                dgvAllBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "Activity",   HeaderText = "Activity",     FillWeight = 160 });
                dgvAllBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "Date",       HeaderText = "Activity Date",FillWeight = 90 });
                dgvAllBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "Pax",        HeaderText = "Pax",          FillWeight = 50 });
                dgvAllBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total",      HeaderText = "Total (ZAR)",  FillWeight = 85 });
                dgvAllBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "Payment",    HeaderText = "Payment",      FillWeight = 80 });
                dgvAllBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "Attendance", HeaderText = "Attendance",   FillWeight = 90 });
                dgvAllBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            if (dgvAttendanceBookings != null && dgvAttendanceBookings.Columns.Count == 0)
            {
                ConfigureGridStyle(dgvAttendanceBookings, Color.FromArgb(244, 252, 250));
                dgvAttendanceBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "BookingID",  Visible = false });
                dgvAttendanceBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "Visitor",    HeaderText = "Visitor Name",  FillWeight = 150 });
                dgvAttendanceBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "Activity",   HeaderText = "Activity",      FillWeight = 180 });
                dgvAttendanceBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "Date",       HeaderText = "Date",          FillWeight = 100 });
                dgvAttendanceBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "Pax",        HeaderText = "Pax",           FillWeight = 60 });
                dgvAttendanceBookings.Columns.Add(new DataGridViewTextBoxColumn { Name = "Attendance", HeaderText = "Current Status",FillWeight = 110 });
                dgvAttendanceBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            if (dgvMessages != null)
            {
                ConfigureGridStyle(dgvMessages, Color.FromArgb(244, 252, 250));
            }

            if (dgvApiGuide != null && dgvApiGuide.Columns.Count == 0)
            {
                ConfigureGridStyle(dgvApiGuide, Color.FromArgb(244, 252, 250));
                dgvApiGuide.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvApiGuide.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvApiGuide.RowTemplate.Height = 38;
                dgvApiGuide.Columns.Add(new DataGridViewTextBoxColumn { Name = "Provider",        HeaderText = "Applicable API / Engine", FillWeight = 135 });
                dgvApiGuide.Columns.Add(new DataGridViewTextBoxColumn { Name = "KeyPrefix",       HeaderText = "Key Format",              FillWeight = 90 });
                dgvApiGuide.Columns.Add(new DataGridViewTextBoxColumn { Name = "ModelUsed",       HeaderText = "Model & Speed",           FillWeight = 120 });
                dgvApiGuide.Columns.Add(new DataGridViewTextBoxColumn { Name = "Situation",       HeaderText = "Best Situation / When to Apply", FillWeight = 230 });
                dgvApiGuide.Columns.Add(new DataGridViewTextBoxColumn { Name = "CostAndNetwork",  HeaderText = "Internet & Cost",         FillWeight = 95 });
                dgvApiGuide.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                PopulateApiGuideGrid();
            }
        }

        private void ConfigureGridStyle(DataGridView dgv, Color altRowColor)
        {
            dgv.BackgroundColor                         = Color.FromArgb(12, 12, 20);
            dgv.GridColor                               = Color.FromArgb(36, 36, 54);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(24, 24, 40);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(214, 201, 255);
            dgv.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Padding   = new Padding(4, 0, 0, 0);
            dgv.ColumnHeadersHeight                     = 36;
            dgv.RowsDefaultCellStyle.BackColor          = Color.FromArgb(16, 16, 26);
            dgv.RowsDefaultCellStyle.ForeColor          = Color.FromArgb(235, 235, 245);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(22, 22, 36);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(235, 235, 245);
            dgv.DefaultCellStyle.BackColor              = Color.FromArgb(16, 16, 26);
            dgv.DefaultCellStyle.ForeColor              = Color.FromArgb(235, 235, 245);
            dgv.DefaultCellStyle.SelectionBackColor     = Color.FromArgb(88, 62, 195);
            dgv.DefaultCellStyle.SelectionForeColor     = Color.White;
            dgv.DefaultCellStyle.Font                   = new Font("Segoe UI", 9F);
            dgv.DefaultCellStyle.Padding                = new Padding(4, 2, 4, 2);
            dgv.RowTemplate.Height                      = 30;
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
            _beamTimer?.Stop();
            _beamTimer?.Dispose();
            base.OnFormClosed(e);
        }

        // =================================================================
        //  DESIGNER EVENT HANDLER BRIDGES
        // =================================================================

        private void btnNavOverview_Click(object sender, EventArgs e) { RefreshOverviewStats(); ShowPanel(pnlOverview); }
        private void btnNavActivities_Click(object sender, EventArgs e) { LoadActivities(); ShowPanel(pnlActivities); }
        private void btnNavBookings_Click(object sender, EventArgs e) { LoadAllBookings(); ShowPanel(pnlBookings); }
        private void btnNavAttendance_Click(object sender, EventArgs e) { LoadAttendanceBookings(); ShowPanel(pnlAttendance); }
        private void btnNavReports_Click(object sender, EventArgs e) { GenerateReport(); ShowPanel(pnlReports); }
        private void btnNavChangePass_Click(object sender, EventArgs e) { ClearPasswordFields(); ShowPanel(pnlChangePassword); }
        private void btnNavAiSettings_Click(object sender, EventArgs e) { LoadAdminAiSettings(); ShowPanel(pnlAiSettings); }
        private void btnNavNotifications_Click(object sender, EventArgs e) { LoadNotificationData(); ShowPanel(pnlNotifications); }
        private void btnNavLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Log Out",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void btnActClear_Click(object sender, EventArgs e) => ClearActivityForm();
        private void txtBookingSearch_TextChanged(object sender, EventArgs e) => LoadAllBookings();
        private void cboBookingActivityFilter_SelectedIndexChanged(object sender, EventArgs e) => LoadAllBookings();
        private void chkEnableDateFilter_CheckedChanged(object sender, EventArgs e) => LoadAllBookings();
        private void dtpBookingDateFilter_ValueChanged(object sender, EventArgs e) { if (chkEnableDateFilter.Checked) LoadAllBookings(); }
        private void btnGenerateReport_Click(object sender, EventArgs e) => GenerateReport();

        // =================================================================
        //  NAVIGATION & OVERVIEW LOGIC
        // =================================================================

        private void ShowPanel(Panel target)
        {
            Panel[] all = { pnlOverview, pnlActivities, pnlBookings, pnlAttendance, pnlReports, pnlChangePassword, pnlAiSettings, pnlNotifications };
            foreach (var p in all)
            {
                if (p != null) p.Visible = (p == target);
            }

            SetNavActive(btnNavOverview,   target == pnlOverview);
            SetNavActive(btnNavActivities, target == pnlActivities);
            SetNavActive(btnNavBookings,   target == pnlBookings);
            SetNavActive(btnNavAttendance, target == pnlAttendance);
            SetNavActive(btnNavReports,    target == pnlReports);
            SetNavActive(btnNavChangePass, target == pnlChangePassword);
            if (btnNavAiSettings != null)    SetNavActive(btnNavAiSettings,    target == pnlAiSettings);
            if (btnNavNotifications != null) SetNavActive(btnNavNotifications, target == pnlNotifications);
            if (btnNavLogout != null)        btnNavLogout.Invalidate();
            ApplyResponsiveLayout();
        }

        private void SetNavActive(Button btn, bool active)
        {
            if (btn != null)
            {
                btn.Invalidate();
            }
        }

        private void RefreshOverviewStats()
        {
            try
            {
                var bookings   = FileService.GetAllBookings();
                var activities = FileService.GetAllActivities();
                var invoices   = FileService.GetAllInvoices();

                lblTileBookings.Text  = bookings.Count.ToString();
                lblTileRevenue.Text   = $"R{invoices.Sum(i => i.Total):N2}";
                lblTileUpcoming.Text  = activities.Count(a => a.Date >= DateTime.Today).ToString();
                lblTileSeatsLeft.Text = activities.Sum(a => a.SeatsAvailable).ToString();
            }
            catch { }
        }

        // =================================================================
        //  2. MANAGE ACTIVITIES LOGIC
        // =================================================================

        private void LoadActivities()
        {
            if (dgvActivities == null || dgvActivities.Columns.Count == 0) return;
            dgvActivities.Rows.Clear();
            List<Activity> list;
            try { list = FileService.GetAllActivities(); }
            catch { return; }

            foreach (var a in list)
            {
                dgvActivities.Rows.Add(
                    a.ActivityID,
                    a.Category,
                    a.Name,
                    a.Description,
                    $"R{a.Price:N2}",
                    a.Date.ToString("dd MMM yyyy"),
                    a.TotalSeats,
                    a.SeatsAvailable);
            }
        }

        private void dgvActivities_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvActivities.SelectedRows.Count == 0) return;
            string actId = dgvActivities.SelectedRows[0].Cells["ActivityID"].Value?.ToString();
            if (string.IsNullOrEmpty(actId)) return;

            try
            {
                var list = FileService.GetAllActivities();
                _selectedActivity = list.FirstOrDefault(a => a.ActivityID == actId);
                if (_selectedActivity != null)
                {
                    cboCategory.SelectedItem = _selectedActivity.Category;
                    txtActName.Text         = _selectedActivity.Name;
                    txtActDescription.Text  = _selectedActivity.Description;
                    nudPrice.Value          = Math.Min(nudPrice.Maximum, Math.Max(nudPrice.Minimum, _selectedActivity.Price));
                    dtpDate.MinDate         = DateTime.Today;
                    dtpDate.Value           = _selectedActivity.Date >= DateTime.Today ? _selectedActivity.Date : DateTime.Today;
                    nudTotalSeats.Value     = Math.Min(nudTotalSeats.Maximum, Math.Max(0, _selectedActivity.TotalSeats));
                    nudAvailableSeats.Value = Math.Min(nudAvailableSeats.Maximum, Math.Max(0, _selectedActivity.SeatsAvailable));
                    LoadActivityImageEditorForSelected(_selectedActivity);
                }
            }
            catch { }
        }

        private bool ValidateActivityForm(out string errorMsg)
        {
            errorMsg = "";
            string name = txtActName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                errorMsg = "Activity Name is required.";
                MessageBox.Show(errorMsg, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (nudPrice.Value <= 0)
            {
                errorMsg = "Price must be a positive number greater than 0.";
                MessageBox.Show(errorMsg, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Admin Event Date Validation: Must only accept future dates (or today)
            if (dtpDate.Value.Date < DateTime.Today)
            {
                errorMsg = "Event date cannot be in the past. Please select a valid future date.";
                MessageBox.Show("Event date cannot be in the past. Please select a valid future date.",
                    "Event Date Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (nudTotalSeats.Value < 0 || nudAvailableSeats.Value < 0)
            {
                errorMsg = "Seat counts must be a whole number of zero or more.";
                MessageBox.Show(errorMsg, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (nudAvailableSeats.Value > nudTotalSeats.Value)
            {
                errorMsg = "Seats available cannot exceed total seats.";
                MessageBox.Show(errorMsg, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnActAdd_Click(object sender, EventArgs e)
        {
            lblActError.Visible = false;
            if (!ValidateActivityForm(out string err))
            {
                lblActError.Text = err; lblActError.Visible = true; return;
            }

            var newAct = new Activity
            {
                ActivityID     = Guid.NewGuid().ToString(),
                Category       = cboCategory.SelectedItem?.ToString() ?? "Safari",
                Name           = txtActName.Text.Trim(),
                Description    = txtActDescription.Text.Trim(),
                Price          = nudPrice.Value,
                Date           = dtpDate.Value,
                TotalSeats     = (int)nudTotalSeats.Value,
                SeatsAvailable = (int)nudAvailableSeats.Value
            };

            try
            {
                FileService.AddActivity(newAct);
                SavePendingImageForActivity(newAct.ActivityID);
                MessageBox.Show("New activity added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearActivityForm();
                LoadActivities();
            }
            catch (Exception ex)
            {
                lblActError.Text = "Failed to save: " + ex.Message; lblActError.Visible = true;
            }
        }

        private void btnActSave_Click(object sender, EventArgs e)
        {
            if (_selectedActivity == null)
            {
                MessageBox.Show("Please select an activity from the grid first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lblActError.Visible = false;
            if (!ValidateActivityForm(out string err))
            {
                lblActError.Text = err; lblActError.Visible = true; return;
            }

            try
            {
                var list = FileService.GetAllActivities();
                foreach (var a in list)
                {
                    if (a.ActivityID != _selectedActivity.ActivityID) continue;
                    a.Category       = cboCategory.SelectedItem?.ToString() ?? a.Category;
                    a.Name           = txtActName.Text.Trim();
                    a.Description    = txtActDescription.Text.Trim();
                    a.Price          = nudPrice.Value;
                    a.Date           = dtpDate.Value;
                    a.TotalSeats     = (int)nudTotalSeats.Value;
                    a.SeatsAvailable = (int)nudAvailableSeats.Value;
                    break;
                }
                FileService.SaveAllActivities(list);
                SavePendingImageForActivity(_selectedActivity.ActivityID);
                MessageBox.Show("Activity updated successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearActivityForm();
                LoadActivities();
            }
            catch (Exception ex)
            {
                lblActError.Text = "Failed to update: " + ex.Message; lblActError.Visible = true;
            }
        }

        private void btnActDelete_Click(object sender, EventArgs e)
        {
            if (_selectedActivity == null)
            {
                MessageBox.Show("Please select an activity to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Block delete if activity has existing bookings
            try
            {
                var bookings = FileService.GetAllBookings();
                bool hasBookings = bookings.Any(b => b.ActivityID == _selectedActivity.ActivityID);
                if (hasBookings)
                {
                    MessageBox.Show("This activity has existing bookings and cannot be deleted", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch { }

            if (MessageBox.Show($"Are you sure you want to delete '{_selectedActivity.Name}'?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    var list = FileService.GetAllActivities();
                    list.RemoveAll(a => a.ActivityID == _selectedActivity.ActivityID);
                    FileService.SaveAllActivities(list);
                    MessageBox.Show("Activity deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearActivityForm();
                    LoadActivities();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to delete activity: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearActivityForm()
        {
            _selectedActivity = null;
            txtActName.Clear();
            txtActDescription.Clear();
            cboCategory.SelectedIndex = 0;
            nudPrice.Value = 350;
            if (dtpDate != null)
            {
                dtpDate.MinDate = DateTime.Today;
                dtpDate.Value = DateTime.Today.AddDays(7);
            }
            nudTotalSeats.Value = 20;
            nudAvailableSeats.Value = 20;
            lblActError.Visible = false;
            _pendingActivityImageSetting = null;
            _pendingUploadedSourceFile = null;
            _suppressPresetComboEvent = true;
            if (cboActImagePreset != null && cboActImagePreset.Items.Count > 0) cboActImagePreset.SelectedIndex = 0;
            _suppressPresetComboEvent = false;
            RefreshActivityImagePreviewBox();
        }

        // =================================================================
        //  3. ALL BOOKINGS LOGIC
        // =================================================================

        private void LoadAllBookings()
        {
            if (dgvAllBookings == null || dgvAllBookings.Columns.Count == 0) return;
            dgvAllBookings.Rows.Clear();
            FileService.AutoUpdateNoShowBookings();

            // Populate activity filter dropdown if empty
            if (cboBookingActivityFilter.Items.Count == 0)
            {
                cboBookingActivityFilter.Items.Add("All Activities");
                try
                {
                    foreach (var act in FileService.GetAllActivities())
                        cboBookingActivityFilter.Items.Add(act.Name);
                }
                catch { }
                cboBookingActivityFilter.SelectedIndex = 0;
            }

            try
            {
                var bookings   = FileService.GetAllBookings();
                var users      = FileService.GetAllUsers().ToDictionary(u => u.UserID, u => $"{u.FirstName} {u.LastName}");
                var activities = FileService.GetAllActivities().ToDictionary(a => a.ActivityID, a => a);

                string search    = txtBookingSearch.Text.Trim().ToLower();
                string actFilter = cboBookingActivityFilter.SelectedItem?.ToString() ?? "All Activities";
                bool dateFilter  = chkEnableDateFilter.Checked;
                DateTime dt      = dtpBookingDateFilter.Value.Date;

                foreach (var b in bookings)
                {
                    string visitorName = users.ContainsKey(b.UserID) ? users[b.UserID] : "Unknown Visitor";
                    Activity act = activities.ContainsKey(b.ActivityID) ? activities[b.ActivityID] : null;
                    string actName = act != null ? act.Name : "Unknown Activity";
                    DateTime actDate = act != null ? act.Date : b.BookingDate;

                    bool searchOk = string.IsNullOrEmpty(search) ||
                                    visitorName.ToLower().Contains(search) ||
                                    actName.ToLower().Contains(search);
                    bool actOk    = actFilter == "All Activities" || actName.Equals(actFilter, StringComparison.OrdinalIgnoreCase);
                    bool dateOk   = !dateFilter || actDate.Date == dt;

                    if (!searchOk || !actOk || !dateOk) continue;

                    dgvAllBookings.Rows.Add(
                        b.BookingID,
                        visitorName,
                        actName,
                        actDate.ToString("dd MMM yyyy"),
                        b.ParticipantCount,
                        $"R{b.TotalCost:N2}",
                        b.PaymentStatus,
                        b.Attendance);
                }
            }
            catch { }
        }

        // =================================================================
        //  4. ATTENDANCE LOGIC
        // =================================================================

        private void LoadAttendanceBookings()
        {
            dgvAttendanceBookings.Rows.Clear();
            try
            {
                FileService.AutoUpdateNoShowBookings();
                var bookings   = FileService.GetAllBookings();
                var users      = FileService.GetAllUsers().ToDictionary(u => u.UserID, u => $"{u.FirstName} {u.LastName}");
                var activities = FileService.GetAllActivities().ToDictionary(a => a.ActivityID, a => a);

                foreach (var b in bookings)
                {
                    string visitorName = users.ContainsKey(b.UserID) ? users[b.UserID] : "Unknown Visitor";
                    string actName     = activities.ContainsKey(b.ActivityID) ? activities[b.ActivityID].Name : "Unknown Activity";
                    DateTime actDate   = activities.ContainsKey(b.ActivityID) ? activities[b.ActivityID].Date : b.BookingDate;

                    dgvAttendanceBookings.Rows.Add(
                        b.BookingID,
                        visitorName,
                        actName,
                        actDate.ToString("dd MMM yyyy"),
                        b.ParticipantCount,
                        b.Attendance);
                }
            }
            catch { }
        }

        private void dgvAttendanceBookings_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAttendanceBookings.SelectedRows.Count == 0)
            {
                lblSelectedBookingInfo.Text = "Select a booking row above to mark attendance.";
                _selectedBooking = null;
                return;
            }

            string bId = dgvAttendanceBookings.SelectedRows[0].Cells["BookingID"].Value?.ToString();
            if (string.IsNullOrEmpty(bId)) return;

            try
            {
                var list = FileService.GetAllBookings();
                _selectedBooking = list.FirstOrDefault(b => b.BookingID == bId);
                if (_selectedBooking != null)
                {
                    string vis = dgvAttendanceBookings.SelectedRows[0].Cells["Visitor"].Value?.ToString();
                    string act = dgvAttendanceBookings.SelectedRows[0].Cells["Activity"].Value?.ToString();
                    lblSelectedBookingInfo.Text = $"Selected: {vis}  –  {act}  (Current: {_selectedBooking.Attendance})";

                    string attVal = _selectedBooking.Attendance;
                    if (attVal == "No-Show") attVal = "No Show";

                    if (cboAttendanceStatus.Items.Contains(attVal))
                        cboAttendanceStatus.SelectedItem = attVal;
                    else
                        cboAttendanceStatus.SelectedIndex = 0;
                }
            }
            catch { }
        }

        private void btnSaveAttendance_Click(object sender, EventArgs e)
        {
            if (_selectedBooking == null)
            {
                MessageBox.Show("Please select a booking from the list above.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string newAtt = cboAttendanceStatus.SelectedItem?.ToString() ?? "Attended";

            try
            {
                var bookings = FileService.GetAllBookings();
                foreach (var b in bookings)
                {
                    if (b.BookingID != _selectedBooking.BookingID) continue;
                    b.Attendance = newAtt;
                    break;
                }
                FileService.SaveAllBookings(bookings);
                MessageBox.Show($"Attendance marked as '{newAtt}' successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAttendanceBookings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save attendance: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =================================================================
        //  5. REPORTS LOGIC
        // =================================================================

        private void GenerateReport()
        {
            try
            {
                var bookings   = FileService.GetAllBookings();
                var activities = FileService.GetAllActivities();
                var invoices   = FileService.GetAllInvoices();
                var users      = FileService.GetAllUsers();

                int totalBookings = bookings.Count;
                decimal totalRevenue = invoices.Sum(i => i.Total);
                int totalAttended = bookings.Count(b => string.Equals(b.Attendance, "Attended", StringComparison.OrdinalIgnoreCase));
                double attendanceRate = totalBookings > 0 ? ((double)totalAttended / totalBookings) * 100.0 : 0.0;

                var sb = new StringBuilder();
                sb.AppendLine("================================================================");
                sb.AppendLine("                BLUE HORIZONS TOURS");
                sb.AppendLine("       SYSTEM-WIDE BOOKING & ATTENDANCE REPORT");
                sb.AppendLine("================================================================");
                sb.AppendLine($" Generated On   : {DateTime.Now:dd MMMM yyyy  HH:mm:ss}");
                sb.AppendLine($" Generated By   : {_adminUser.FirstName} {_adminUser.LastName} ({_adminUser.Role})");
                sb.AppendLine("----------------------------------------------------------------");
                sb.AppendLine(" 1. EXECUTIVE SUMMARY");
                sb.AppendLine($"    Total Registered Users : {users.Count}");
                sb.AppendLine($"    Total Activities       : {activities.Count}");
                sb.AppendLine($"    Total Visitor Bookings : {totalBookings}");
                sb.AppendLine($"    Total Invoiced Revenue : R{totalRevenue:N2}");
                sb.AppendLine($"    Attended Bookings      : {totalAttended}");
                sb.AppendLine($"    Attendance Rate        : {attendanceRate:F1}%");
                sb.AppendLine("----------------------------------------------------------------");
                sb.AppendLine(" 2. BOOKINGS PER ACTIVITY BREAKDOWN");
                sb.AppendLine(string.Format(" {0,-32} | {1,-10} | {2,-12}", "Activity Name", "Bookings", "Total Pax"));
                sb.AppendLine(" --------------------------------------------------------------");

                var actMap = activities.ToDictionary(a => a.ActivityID, a => a.Name);
                var actBookings = bookings.GroupBy(b => b.ActivityID);

                foreach (var group in actBookings)
                {
                    string name = actMap.ContainsKey(group.Key) ? actMap[group.Key] : "Unknown";
                    int count = group.Count();
                    int pax = group.Sum(b => b.ParticipantCount);
                    sb.AppendLine(string.Format(" {0,-32} | {1,-10} | {2,-12}", name.Length > 32 ? name.Substring(0, 29) + "..." : name, count, pax));
                }

                sb.AppendLine("================================================================");
                sb.AppendLine(" End of Report");
                sb.AppendLine("================================================================");

                rtbReportOutput.Text = sb.ToString();
                RefreshReportCharts(activities, bookings, invoices, users);
            }
            catch (Exception ex)
            {
                rtbReportOutput.Text = "Failed to generate report: " + ex.Message;
            }
        }

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            try
            {
                string reportsFolder = Path.Combine(FileService.DataFolder, "Reports");
                if (!Directory.Exists(reportsFolder))
                    Directory.CreateDirectory(reportsFolder);

                string fileName = $"Admin_Report_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                string fullPath = Path.Combine(reportsFolder, fileName);

                File.WriteAllText(fullPath, rtbReportOutput.Text);
                MessageBox.Show($"Report exported successfully!\r\n\r\nSaved to: {fullPath}", "Report Exported",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to export report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =================================================================
        //  6. CHANGE PASSWORD LOGIC
        // =================================================================

        private void ClearPasswordFields()
        {
            txtCurrentPassword.Clear();
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
            lblPassError.Visible = false;
        }

        private void btnSavePassword_Click(object sender, EventArgs e)
        {
            lblPassError.Visible = false;
            string current = txtCurrentPassword.Text;
            string newPass = txtNewPassword.Text;
            string confirm = txtConfirmPassword.Text;

            if (string.IsNullOrEmpty(current) || string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(confirm))
            {
                ShowPassError("All fields are required."); return;
            }

            // Verify current password
            if (!PasswordHelper.VerifyPassword(current, _adminUser.PasswordHash))
            {
                ShowPassError("Current password is incorrect."); return;
            }

            // Validate new password rules (>= 8 chars, uppercase, lowercase, digit)
            if (!System.Text.RegularExpressions.Regex.IsMatch(newPass, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$"))
            {
                ShowPassError("New password must be >= 8 chars with uppercase, lowercase and a digit."); return;
            }

            if (newPass != confirm)
            {
                ShowPassError("New passwords do not match."); return;
            }

            // Save new password hash
            try
            {
                var users = FileService.GetAllUsers();
                foreach (var u in users)
                {
                    if (u.UserID != _adminUser.UserID) continue;
                    u.PasswordHash = PasswordHelper.HashNewPassword(newPass);
                    _adminUser = u; // update in-memory reference
                    break;
                }
                FileService.SaveAllUsers(users);
                ClearPasswordFields();
                MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowPassError("Failed to update password: " + ex.Message);
            }
        }

        private void ShowPassError(string msg)
        {
            lblPassError.Text = msg;
            lblPassError.Visible = true;
        }

        // =================================================================
        //  WIDGET FACTORY HELPERS
        // =================================================================

        private Panel ContentPanel() => new Panel
        {
            Location  = new Point(0, 0),
            Size      = new Size(980, 750),
            BackColor = Color.White,
            Visible   = false
        };

        private Label MakeLabel(string text, Font font, Color fore, Color back,
                                Point loc, Size size, ContentAlignment align = ContentAlignment.TopLeft)
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
                Size      = new Size(220, 48),
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
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(244, 252, 250);
            dgv.DefaultCellStyle.SelectionBackColor     = Color.FromArgb(178, 235, 226);
            dgv.DefaultCellStyle.SelectionForeColor     = Color.Black;
            dgv.DefaultCellStyle.Font                   = FontSmall;
            dgv.DefaultCellStyle.Padding                = new Padding(4, 2, 4, 2);
            dgv.RowTemplate.Height                      = 28;
            return dgv;
        }

        private Panel BuildStatTile(int x, int y, string count, string caption, Color accent)
        {
            var tile = new Panel
            {
                Location    = new Point(x, y),
                Size        = new Size(210, 128),
                BackColor   = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            var lblCount = new Label
            {
                Text      = count,
                Font      = new Font("Arial", 28F, FontStyle.Bold),
                ForeColor = accent,
                Location  = new Point(8, 12),
                Size      = new Size(194, 56),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize  = false
            };

            var lblCaption = new Label
            {
                Text      = caption,
                Font      = FontSmall,
                ForeColor = TextGray,
                Location  = new Point(8, 76),
                Size      = new Size(194, 30),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize  = false
            };

            tile.Controls.Add(lblCount);
            tile.Controls.Add(lblCaption);
            return tile;
        }

        // =================================================================
        //  7. SAFARISCOUT AI API KEY MANAGEMENT (ADMIN ONLY)
        // =================================================================

        private void LoadAdminAiSettings()
        {
            string currentKey = SafariChatbotService.GetApiKey();
            txtAdminApiKey.Text = currentKey;
            lblAdminApiKeyMsg.Visible = false;
            RefreshAdminAiStatusCard(currentKey);
        }

        private void RefreshAdminAiStatusCard(string key)
        {
            if (!string.IsNullOrWhiteSpace(key))
            {
                string provider = key.StartsWith("AIza") ? "Google Gemini AI (gemini-2.5-flash)"
                                : key.StartsWith("gsk_") ? "Groq Cloud LPU AI (llama-3.3-70b)"
                                : key.StartsWith("sk-or-") ? "OpenRouter Universal AI"
                                : "OpenAI ChatGPT API (gpt-4o-mini)";
                string masked = key.Length > 8
                    ? key.Substring(0, 4) + new string('*', Math.Min(16, key.Length - 8)) + key.Substring(key.Length - 4)
                    : "Configured";
                lblAiCurrentStatus.Text = $"Active Provider: {provider}  |  Key: {masked}";
                lblAiCurrentStatus.ForeColor = Color.FromArgb(110, 255, 173);
            }
            else
            {
                lblAiCurrentStatus.Text = "Active Provider: Built-in Offline Safari Engine (No Cloud API Key set)";
                lblAiCurrentStatus.ForeColor = Color.FromArgb(214, 201, 255);
            }
        }

        private void chkShowAdminApiKey_CheckedChanged(object sender, EventArgs e)
        {
            txtAdminApiKey.UseSystemPasswordChar = !chkShowAdminApiKey.Checked;
        }

        private void btnSaveAdminApiKey_Click(object sender, EventArgs e)
        {
            try
            {
                string newKey = txtAdminApiKey.Text.Trim();
                SafariChatbotService.SaveApiKey(newKey, _adminUser);
                RefreshAdminAiStatusCard(newKey);

                lblAdminApiKeyMsg.ForeColor = Color.FromArgb(110, 255, 173);
                lblAdminApiKeyMsg.Text = !string.IsNullOrEmpty(newKey)
                    ? "✔ SafariScout AI API Key saved! Visitors will now use this cloud AI key."
                    : "✔ API Key cleared. Visitors will now use the built-in offline Safari Engine.";
                lblAdminApiKeyMsg.Visible = true;
            }
            catch (Exception ex)
            {
                lblAdminApiKeyMsg.ForeColor = Color.Red;
                lblAdminApiKeyMsg.Text = "Error saving API Key: " + ex.Message;
                lblAdminApiKeyMsg.Visible = true;
            }
        }

        private void btnClearAdminApiKey_Click(object sender, EventArgs e)
        {
            try
            {
                txtAdminApiKey.Text = string.Empty;
                SafariChatbotService.SaveApiKey(string.Empty, _adminUser);
                RefreshAdminAiStatusCard(string.Empty);

                lblAdminApiKeyMsg.ForeColor = Color.FromArgb(180, 165, 255);
                lblAdminApiKeyMsg.Text = "✔ Cloud API Key removed. SafariScout AI is now running on the built-in offline Safari Engine.";
                lblAdminApiKeyMsg.Visible = true;
            }
            catch (Exception ex)
            {
                lblAdminApiKeyMsg.ForeColor = Color.Red;
                lblAdminApiKeyMsg.Text = "Error clearing API Key: " + ex.Message;
                lblAdminApiKeyMsg.Visible = true;
            }
        }


        private void PopulateApiGuideGrid()
        {
            if (dgvApiGuide == null || dgvApiGuide.Columns.Count == 0) return;
            dgvApiGuide.Rows.Clear();

            dgvApiGuide.Rows.Add(
                "1. Built-in Offline Safari Engine",
                "(Leave Blank)",
                "Local NLP Engine (Instant 0ms)",
                "University labs, exam/marking PCs without internet, or zero-cost testing",
                "100% Offline / Free");

            dgvApiGuide.Rows.Add(
                "2. Google Gemini API",
                "AIzaSy...",
                "gemini-2.5-flash (Fast Cloud)",
                "Best everyday cloud AI: natural multi-turn safari recommendations & free quota",
                "Internet / Free Tier");

            dgvApiGuide.Rows.Add(
                "3. Groq Cloud LPU API",
                "gsk_...",
                "llama-3.3-70b (Ultra-Fast <0.3s)",
                "Live classroom presentations & high-speed interactive Q&A with zero waiting",
                "Internet / Free Tier");

            dgvApiGuide.Rows.Add(
                "4. OpenAI ChatGPT API",
                "sk-...",
                "gpt-4o-mini (High Precision)",
                "Complex visitor itineraries, strict budget comparisons & production deployment",
                "Internet / Paid Credits");

            dgvApiGuide.Rows.Add(
                "5. OpenRouter Universal API",
                "sk-or-v1-...",
                "llama-3.1-8b:free / Auto-Route",
                "Backup failover when primary provider rate-limits are hit or testing multiple LLMs",
                "Internet / Free & Paid");
        }

        private void dgvApiGuide_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvApiGuide == null || dgvApiGuide.SelectedRows.Count == 0 || lblSelectedApiGuideDetail == null) return;
            int idx = dgvApiGuide.SelectedRows[0].Index;

            switch (idx)
            {
                case 0:
                    lblSelectedApiGuideDetail.Text =
                        "📌 1. BUILT-IN OFFLINE SAFARI ENGINE (Key: Leave Blank / Click 'Clear Key')\r\n" +
                        "• WHEN TO APPLY: Use this during university practical marking, on lab computers without Wi-Fi, or whenever you want 100% guaranteed offline reliability.\r\n" +
                        "• WHAT IT DOES: Reads live Data/activities.txt and Data/bookings.txt locally, answers Safari/Adventure/Hiking/Event queries, and executes full bookings & invoices with zero internet required.";
                    break;
                case 1:
                    lblSelectedApiGuideDetail.Text =
                        "📌 2. GOOGLE GEMINI API (Key Prefix: 'AIzaSy...' from aistudio.google.com)\r\n" +
                        "• WHEN TO APPLY: Recommended default when internet is available and you want rich, conversational AI answers without paying per token.\r\n" +
                        "• WHAT IT DOES: Uses 'gemini-2.5-flash' injected with your live Blue Horizons activities and visitor bookings to give personalized Cape Town safari advice and trigger [BOOK_NOW] actions.";
                    break;
                case 2:
                    lblSelectedApiGuideDetail.Text =
                        "📌 3. GROQ CLOUD LPU API (Key Prefix: 'gsk_...' from console.groq.com)\r\n" +
                        "• WHEN TO APPLY: Use during live timed demonstrations or high-traffic testing where instant (<300 ms) response speed is critical.\r\n" +
                        "• WHAT IT DOES: Runs Meta's 'llama-3.3-70b-versatile' on Groq LPUs for near-instant conversational safari scouting and automated booking execution.";
                    break;
                case 3:
                    lblSelectedApiGuideDetail.Text =
                        "📌 4. OPENAI CHATGPT API (Key Prefix: 'sk-...' from platform.openai.com)\r\n" +
                        "• WHEN TO APPLY: Use in production customer-service environments or when visitors ask complex, multi-constraint group/budget questions.\r\n" +
                        "• WHAT IT DOES: Uses 'gpt-4o-mini' for industry-standard instruction following, strict off-topic refusal, and accurate multi-seat booking calculations.";
                    break;
                case 4:
                    lblSelectedApiGuideDetail.Text =
                        "📌 5. OPENROUTER UNIVERSAL API (Key Prefix: 'sk-or-v1-...' from openrouter.ai)\r\n" +
                        "• WHEN TO APPLY: Use as a universal backup key when regional/provider rate limits occur, or when switching between free open-source models.\r\n" +
                        "• WHAT IT DOES: Automatically routes SafariScout AI prompts through OpenRouter's free Llama 3.1 endpoint with full live FileService context.";
                    break;
            }
        }

        // =================================================================
        //  RESPONSIVE SCALING & FULL-WINDOW MAXIMIZE ENGINE
        // =================================================================

        private void ConfigureResponsiveScaling()
        {
            foreach (Panel p in new[] { pnlOverview, pnlActivities, pnlBookings, pnlAttendance, pnlReports, pnlChangePassword, pnlAiSettings, pnlNotifications })
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
                btnNavLogout.Location = new Point(0, Math.Max(468, clientH - btnNavLogout.Height));
            }

            int contentW = Math.Max(720, clientW - sideW);
            int contentH = clientH;
            pnlContent.Location = new Point(sideW, 0);
            pnlContent.Size = new Size(contentW, contentH);

            foreach (Panel p in new[] { pnlOverview, pnlActivities, pnlBookings, pnlAttendance, pnlReports, pnlChangePassword, pnlAiSettings, pnlNotifications })
            {
                if (p != null)
                {
                    p.Location = new Point(0, 0);
                    p.Size = new Size(contentW, contentH);
                }
            }

            int padX = 24;
            int availW = contentW - (padX * 2);

            // 1. Overview Panel (Full-bleed Kexsio AnimatedBeam Hub + 4 sleek bottom KPI cards)
            if (pnlOverview != null)
            {
                if (lblOverviewHeading != null) lblOverviewHeading.Visible = false;
                if (lblOverviewSub != null)     lblOverviewSub.Visible     = false;

                int tileH = 86;
                int tileY = contentH - tileH - 18;
                int hubH  = Math.Max(380, tileY - 8);

                if (pnlShortcuts != null)
                {
                    pnlShortcuts.Location = new Point(0, 0);
                    pnlShortcuts.Size = new Size(contentW, hubH);
                    pnlShortcuts.Invalidate();
                }

                int gap = 16;
                int tileW = (availW - (gap * 3)) / 4;
                Panel[] tiles = { tileBookings, tileRevenue, tileUpcoming, tileSeatsLeft };
                Label[] counts = { lblTileBookings, lblTileRevenue, lblTileUpcoming, lblTileSeatsLeft };
                Label[] caps = { lblTileBookingsCap, lblTileRevenueCap, lblTileUpcomingCap, lblTileSeatsLeftCap };
                for (int i = 0; i < 4; i++)
                {
                    if (tiles[i] != null)
                    {
                        tiles[i].Location = new Point(padX + i * (tileW + gap), tileY);
                        tiles[i].Size = new Size(tileW, tileH);
                        tiles[i].BringToFront();
                    }
                    if (counts[i] != null) { counts[i].Location = new Point(12, 10); counts[i].Size = new Size(Math.Max(50, tileW - 56), 40); }
                    if (caps[i] != null)   { caps[i].Location   = new Point(12, 52); caps[i].Size   = new Size(Math.Max(50, tileW - 56), 24); }
                }
            }

            // 2. Manage Activities Panel (Grid + Form)
            if (pnlActivities != null && dgvActivities != null && pnlActivityForm != null)
            {
                int formH = 290;
                int gridH = Math.Max(160, contentH - formH - 82);
                dgvActivities.Location = new Point(padX, 54);
                dgvActivities.Size = new Size(availW, gridH);

                pnlActivityForm.Location = new Point(padX, 54 + gridH + 12);
                pnlActivityForm.Size = new Size(availW, formH);

                int imgColW = 252;
                int imgColX = Math.Max(680, availW - imgColW - 14);
                int leftW   = Math.Max(640, imgColX - 32);

                if (txtActDescription != null) txtActDescription.Size = new Size(leftW, 26);
                if (txtActName != null)        txtActName.Size        = new Size(Math.Max(260, leftW - 336), 26);
                if (lblPriceCap != null && txtActName != null) lblPriceCap.Location = new Point(txtActName.Right + 16, 38);
                if (nudPrice != null && txtActName != null)    nudPrice.Location    = new Point(txtActName.Right + 16, 56);

                if (lblActImageCap != null)    lblActImageCap.Location    = new Point(imgColX, 12);
                if (picActImagePreview != null)picActImagePreview.Location= new Point(imgColX, 34);
                if (cboActImagePreset != null) cboActImagePreset.Location = new Point(imgColX + 110, 34);
                if (btnUploadActImage != null) btnUploadActImage.Location = new Point(imgColX + 110, 66);
                if (btnResetActImage != null)  btnResetActImage.Location  = new Point(imgColX + 110, 108);
                if (lblActImageStatus != null) lblActImageStatus.Location = new Point(imgColX, 176);

                if (dtpDate != null)           dtpDate.Size = new Size(200, 26);
                if (lblTotalSeatsCap != null)  lblTotalSeatsCap.Location = new Point(232, 146);
                if (nudTotalSeats != null)     nudTotalSeats.Location = new Point(232, 164);
                if (lblAvailSeatsCap != null)  lblAvailSeatsCap.Location = new Point(410, 146);
                if (nudAvailableSeats != null) nudAvailableSeats.Location = new Point(410, 164);
            }

            // 3. All Bookings Panel
            if (pnlBookings != null && dgvAllBookings != null)
            {
                int rightBtnW = btnBookingEditImage != null ? btnBookingEditImage.Width + 16 : 0;
                int filterAreaW = availW - rightBtnW;

                int searchW = Math.Max(180, Math.Min(280, (filterAreaW - 32) / 3));
                if (txtBookingSearch != null)
                {
                    txtBookingSearch.Location = new Point(padX, 74);
                    txtBookingSearch.Size = new Size(searchW, 26);
                }
                if (lblBookingSearchCap != null) lblBookingSearchCap.Location = new Point(padX, 56);

                int nextX = padX + searchW + 16;
                int filterW = Math.Max(180, Math.Min(260, (filterAreaW - 32) / 3));
                if (lblBookingFilterCap != null)       lblBookingFilterCap.Location = new Point(nextX, 56);
                if (cboBookingActivityFilter != null)
                {
                    cboBookingActivityFilter.Location = new Point(nextX, 74);
                    cboBookingActivityFilter.Size = new Size(filterW, 26);
                }

                int chkX = nextX + filterW + 16;
                if (chkEnableDateFilter != null)  chkEnableDateFilter.Location = new Point(chkX, 74);
                if (dtpBookingDateFilter != null && chkEnableDateFilter != null)
                    dtpBookingDateFilter.Location = new Point(chkEnableDateFilter.Right + 8, 74);

                if (btnBookingEditImage != null)
                {
                    btnBookingEditImage.Location = new Point(Math.Max(808, padX + availW - btnBookingEditImage.Width), 68);
                }
                dgvAllBookings.Location = new Point(padX, 112);
                dgvAllBookings.Size = new Size(availW, Math.Max(220, contentH - 132));
            }

            // 4. Attendance Panel
            if (pnlAttendance != null && dgvAttendanceBookings != null && pnlAttendanceUpdate != null)
            {
                int updH = 136;
                int gridH = Math.Max(190, contentH - updH - 84);
                dgvAttendanceBookings.Location = new Point(padX, 58);
                dgvAttendanceBookings.Size = new Size(availW, gridH);

                pnlAttendanceUpdate.Location = new Point(padX, 58 + gridH + 12);
                pnlAttendanceUpdate.Size = new Size(availW, updH);
                if (lblSelectedBookingInfo != null)
                    lblSelectedBookingInfo.Size = new Size(Math.Max(400, availW - 32), 24);
            }

            // 5. Reports Panel (3 Bklit UI Chart Cards + Detailed Text Report + Action Buttons)
            if (pnlReports != null && rtbReportOutput != null)
            {
                if (lblReportsHeading != null)
                {
                    lblReportsHeading.Location = new Point(padX, 12);
                    lblReportsHeading.Size = new Size(availW, 34);
                }

                int gap = 12;
                int chartW = Math.Max(220, (availW - gap * 2) / 3);
                int chartH = Math.Max(235, Math.Min(340, (int)((contentH - 132) * 0.50)));
                int topY = 52;

                if (pnlChartBar != null)
                {
                    pnlChartBar.Location = new Point(padX, topY);
                    pnlChartBar.Size = new Size(chartW, chartH);
                    pnlChartBar.Invalidate();
                }
                if (pnlChartFunnel != null)
                {
                    pnlChartFunnel.Location = new Point(padX + chartW + gap, topY);
                    pnlChartFunnel.Size = new Size(chartW, chartH);
                    pnlChartFunnel.Invalidate();
                }
                if (pnlChartArea != null)
                {
                    int thirdW = Math.Max(220, availW - (chartW + gap) * 2);
                    pnlChartArea.Location = new Point(padX + (chartW + gap) * 2, topY);
                    pnlChartArea.Size = new Size(thirdW, chartH);
                    pnlChartArea.Invalidate();
                }

                int rtbTop = topY + chartH + 12;
                int rtbH = Math.Max(140, contentH - rtbTop - 68);
                rtbReportOutput.Location = new Point(padX, rtbTop);
                rtbReportOutput.Size = new Size(availW, rtbH);

                int btnY = rtbTop + rtbH + 10;
                if (btnGenerateReport != null) btnGenerateReport.Location = new Point(padX, btnY);
                if (btnExportReport != null)   btnExportReport.Location   = new Point(padX + 240, btnY);
            }

            // 6. Change Password Panel
            if (pnlChangePassword != null)
            {
                int fieldW = Math.Min(560, Math.Max(380, availW / 2));
                if (txtCurrentPassword != null) txtCurrentPassword.Size = new Size(fieldW, 32);
                if (txtNewPassword != null)     txtNewPassword.Size     = new Size(fieldW, 32);
                if (txtConfirmPassword != null) txtConfirmPassword.Size = new Size(fieldW, 32);
            }

            // 7. SafariScout AI Key & Provider Guide Panel
            if (pnlAiSettings != null)
            {
                if (lblAiSettingsHeading != null)
                {
                    lblAiSettingsHeading.Location = new Point(padX, 12);
                    lblAiSettingsHeading.Size = new Size(availW, 32);
                }
                if (lblAiSettingsSub != null)
                {
                    lblAiSettingsSub.Location = new Point(padX, 46);
                    lblAiSettingsSub.Size = new Size(availW, 20);
                }

                if (pnlAiStatusCard != null)
                {
                    pnlAiStatusCard.Location = new Point(padX, 70);
                    pnlAiStatusCard.Size = new Size(availW, 60);
                    if (lblAiStatusCardTitle != null) lblAiStatusCardTitle.Size = new Size(availW - 28, 18);
                    if (lblAiCurrentStatus != null)   lblAiCurrentStatus.Size   = new Size(availW - 28, 22);
                }

                if (lblAdminApiKeyCap != null)
                {
                    lblAdminApiKeyCap.Location = new Point(padX, 138);
                    lblAdminApiKeyCap.Size = new Size(availW, 18);
                }

                int chkW = 196;
                int txtW = Math.Max(320, availW - chkW - 16);
                if (txtAdminApiKey != null)
                {
                    txtAdminApiKey.Location = new Point(padX, 158);
                    txtAdminApiKey.Size = new Size(txtW, 28);
                }
                if (chkShowAdminApiKey != null)
                {
                    chkShowAdminApiKey.Location = new Point(padX + txtW + 16, 162);
                }

                if (btnSaveAdminApiKey != null)  btnSaveAdminApiKey.Location  = new Point(padX, 194);
                if (btnClearAdminApiKey != null) btnClearAdminApiKey.Location = new Point(padX + 274, 194);
                if (lblAdminApiKeyMsg != null)
                {
                    lblAdminApiKeyMsg.Location = new Point(padX, 240);
                    lblAdminApiKeyMsg.Size = new Size(availW, 20);
                }

                if (lblApiGuideHeading != null)
                {
                    lblApiGuideHeading.Location = new Point(padX, 264);
                    lblApiGuideHeading.Size = new Size(availW, 22);
                }

                int topOfGrid = 290;
                int detailH = Math.Max(92, Math.Min(128, (contentH - topOfGrid - 24) / 3));
                int gridH = Math.Max(150, contentH - topOfGrid - detailH - 22);

                if (dgvApiGuide != null)
                {
                    dgvApiGuide.Location = new Point(padX, topOfGrid);
                    dgvApiGuide.Size = new Size(availW, gridH);
                }

                if (pnlApiDetailBox != null)
                {
                    pnlApiDetailBox.Location = new Point(padX, topOfGrid + gridH + 8);
                    pnlApiDetailBox.Size = new Size(availW, detailH);
                    if (lblSelectedApiGuideDetail != null)
                    {
                        lblSelectedApiGuideDetail.Location = new Point(12, 8);
                        lblSelectedApiGuideDetail.Size = new Size(availW - 24, detailH - 16);
                    }
                }
            }
        }


        // =================================================================
        //  KEXSIO DARK GLASS THEME & ANIMATED BEAM INTEGRATION HUB
        // =================================================================

        private void ApplyDarkGlassThemeAndBeams()
        {
            this.BackColor = LightGray;
            if (pnlSidebar != null) pnlSidebar.BackColor = DarkTeal;
            if (pnlTop != null)     pnlTop.BackColor     = SidebarTop;
            if (lblAdminPortalSub != null) lblAdminPortalSub.ForeColor = Color.FromArgb(180, 165, 255);

            // Style all content panels recursively for the #050509 / #101016 dark glass theme
            Panel[] pages = { pnlOverview, pnlActivities, pnlBookings, pnlAttendance, pnlReports, pnlChangePassword, pnlAiSettings, pnlNotifications };
            foreach (Panel page in pages)
            {
                if (page == null) continue;
                page.BackColor = Color.FromArgb(5, 5, 9);
                EnableControlDoubleBuffering(page);
                page.Paint += PageDarkGrid_Paint;
                StyleChildControlsDark(page);
            }

            // Style stat tiles on Overview with glowing neon accent colors and button-theme icon badges
            StyleStatTileDark(tileBookings,  lblTileBookings,  lblTileBookingsCap,  Color.FromArgb(155, 108, 255), SafariThemeEngine.AdminDashboardIcon.Bookings,       SafariThemeEngine.RoyalViolet,   SafariThemeEngine.HorizonCyan);
            StyleStatTileDark(tileRevenue,   lblTileRevenue,   lblTileRevenueCap,   Color.FromArgb(62, 225, 142),  SafariThemeEngine.AdminDashboardIcon.Revenue,        SafariThemeEngine.SafariEmerald, SafariThemeEngine.HorizonCyan);
            StyleStatTileDark(tileUpcoming,  lblTileUpcoming,  lblTileUpcomingCap,  Color.FromArgb(74, 168, 255),  SafariThemeEngine.AdminDashboardIcon.Upcoming,       SafariThemeEngine.HorizonCyan,   SafariThemeEngine.SunsetAmber);
            StyleStatTileDark(tileSeatsLeft, lblTileSeatsLeft, lblTileSeatsLeftCap, Color.FromArgb(255, 157, 61),  SafariThemeEngine.AdminDashboardIcon.SeatsAvailable, SafariThemeEngine.SunsetAmber,   SafariThemeEngine.CrimsonCoral);

            // Turn pnlShortcuts on pnlOverview into the interactive AnimatedBeam Hub Canvas
            if (pnlShortcuts != null)
            {
                pnlShortcuts.BackColor = Color.FromArgb(8, 8, 15);
                pnlShortcuts.BackgroundImage = null;
                pnlShortcuts.BorderStyle = BorderStyle.None;
                EnableControlDoubleBuffering(pnlShortcuts);

                if (lblShortcutsHeading != null) lblShortcutsHeading.Visible = false;
                foreach (Button b in new[] { btnShortcutActivities, btnShortcutBookings, btnShortcutAttendance, btnShortcutReports, btnShortcutAiSettings })
                {
                    if (b != null) b.Visible = false;
                }

                pnlShortcuts.MouseMove += PnlBeamHub_MouseMove;
                pnlShortcuts.MouseLeave += (s, e) => { _hoveredNodeIndex = -1; pnlShortcuts.Cursor = Cursors.Default; pnlShortcuts.Invalidate(); };
                pnlShortcuts.MouseClick += PnlBeamHub_MouseClick;
            }

            InitializeBklitReportCharts();

            // Attach Uiverse Button Theme to Sidebar Navigation Buttons & Icons
            SafariThemeEngine.AttachAdminNavButtonTheme(btnNavOverview,   SafariThemeEngine.AdminDashboardIcon.Overview,       SafariThemeEngine.RoyalViolet,   SafariThemeEngine.HorizonCyan, () => pnlOverview != null && pnlOverview.Visible, "Overview");
            SafariThemeEngine.AttachAdminNavButtonTheme(btnNavActivities, SafariThemeEngine.AdminDashboardIcon.Activities,     SafariThemeEngine.RoyalViolet,   SafariThemeEngine.HorizonCyan, () => pnlActivities != null && pnlActivities.Visible, "Manage Activities");
            SafariThemeEngine.AttachAdminNavButtonTheme(btnNavBookings,   SafariThemeEngine.AdminDashboardIcon.Bookings,       SafariThemeEngine.SafariEmerald, SafariThemeEngine.HorizonCyan, () => pnlBookings != null && pnlBookings.Visible, "All Bookings");
            SafariThemeEngine.AttachAdminNavButtonTheme(btnNavAttendance, SafariThemeEngine.AdminDashboardIcon.Attendance,     SafariThemeEngine.SafariEmerald, SafariThemeEngine.HorizonCyan, () => pnlAttendance != null && pnlAttendance.Visible, "Attendance");
            SafariThemeEngine.AttachAdminNavButtonTheme(btnNavReports,    SafariThemeEngine.AdminDashboardIcon.Reports,        SafariThemeEngine.RoyalViolet,   SafariThemeEngine.HorizonCyan, () => pnlReports != null && pnlReports.Visible, "Reports");
            SafariThemeEngine.AttachAdminNavButtonTheme(btnNavChangePass, SafariThemeEngine.AdminDashboardIcon.ChangePassword, SafariThemeEngine.RoyalViolet,   SafariThemeEngine.SunsetAmber, () => pnlChangePassword != null && pnlChangePassword.Visible, "Change Password");
            SafariThemeEngine.AttachAdminNavButtonTheme(btnNavAiSettings,    SafariThemeEngine.AdminDashboardIcon.AiSettings,     SafariThemeEngine.SunsetAmber,   SafariThemeEngine.HorizonCyan, () => pnlAiSettings != null && pnlAiSettings.Visible, "SafariScout AI Key");
            SafariThemeEngine.AttachAdminNavButtonTheme(btnNavNotifications, SafariThemeEngine.AdminDashboardIcon.Bookings,       SafariThemeEngine.HorizonCyan,   SafariThemeEngine.SafariEmerald, () => pnlNotifications != null && pnlNotifications.Visible, "Notifications");
            SafariThemeEngine.AttachAdminNavButtonTheme(btnNavLogout,     SafariThemeEngine.AdminDashboardIcon.Logout,         SafariThemeEngine.CrimsonCoral,  SafariThemeEngine.SunsetAmber, () => false, "Log Out");

            // Attach Uiverse.io Gradient Glow Pill Buttons across Admin action controls
            SafariThemeEngine.AttachUiverseButtonGlow(btnActAdd,            SafariThemeEngine.RoyalViolet,   SafariThemeEngine.HorizonCyan);
            SafariThemeEngine.AttachUiverseButtonGlow(btnActSave,           SafariThemeEngine.SafariEmerald, SafariThemeEngine.HorizonCyan);
            SafariThemeEngine.AttachUiverseButtonGlow(btnActDelete,         SafariThemeEngine.CrimsonCoral,  SafariThemeEngine.SunsetAmber);
            SafariThemeEngine.AttachUiverseButtonGlow(btnActClear,          SafariThemeEngine.RoyalViolet,   SafariThemeEngine.HorizonCyan, true);
            SafariThemeEngine.AttachUiverseButtonGlow(btnSaveAttendance,    SafariThemeEngine.SafariEmerald, SafariThemeEngine.HorizonCyan);
            SafariThemeEngine.AttachUiverseButtonGlow(btnGenerateReport,    SafariThemeEngine.RoyalViolet,   SafariThemeEngine.HorizonCyan);
            SafariThemeEngine.AttachUiverseButtonGlow(btnExportReport,      SafariThemeEngine.SafariEmerald, SafariThemeEngine.SunsetAmber);
            SafariThemeEngine.AttachUiverseButtonGlow(btnSavePassword,      SafariThemeEngine.RoyalViolet,   SafariThemeEngine.SunsetAmber);
            SafariThemeEngine.AttachUiverseButtonGlow(btnSaveAdminApiKey,   SafariThemeEngine.SafariEmerald, SafariThemeEngine.HorizonCyan);
            SafariThemeEngine.AttachUiverseButtonGlow(btnClearAdminApiKey,  SafariThemeEngine.RoyalViolet,   SafariThemeEngine.SunsetAmber, true);
            SafariThemeEngine.AttachUiverseButtonGlow(btnUploadActImage,    SafariThemeEngine.SafariEmerald, SafariThemeEngine.HorizonCyan);
            SafariThemeEngine.AttachUiverseButtonGlow(btnResetActImage,     SafariThemeEngine.RoyalViolet,   SafariThemeEngine.HorizonCyan, true);
            SafariThemeEngine.AttachUiverseButtonGlow(btnBookingEditImage,  SafariThemeEngine.RoyalViolet,   SafariThemeEngine.SunsetAmber);
            RefreshActivityImagePreviewBox();

            _beamTimer = new System.Windows.Forms.Timer { Interval = 35 };
            _beamTimer.Tick += (s, e) =>
            {
                _beamTick += 0.035f;
                if (pnlOverview != null && pnlOverview.Visible && pnlShortcuts != null)
                {
                    pnlShortcuts.Invalidate();
                }
            };
            _beamTimer.Start();
        }

        private static void EnableControlDoubleBuffering(Control ctrl)
        {
            if (ctrl == null) return;
            try
            {
                typeof(Control).InvokeMember("DoubleBuffered",
                    System.Reflection.BindingFlags.SetProperty |
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic,
                    null, ctrl, new object[] { true });
            }
            catch { }
        }

        private void StyleStatTileDark(
            Panel tile,
            Label lblCount,
            Label lblCap,
            Color accent,
            SafariThemeEngine.AdminDashboardIcon icon,
            Color gradStart,
            Color gradEnd)
        {
            if (tile == null) return;
            tile.BackColor = Color.FromArgb(16, 16, 24);
            tile.BorderStyle = BorderStyle.None;
            EnableControlDoubleBuffering(tile);
            tile.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (var pen = new Pen(Color.FromArgb(48, 255, 255, 255), 1f))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, tile.Width - 1, tile.Height - 1);
                }
                using (var topAccent = new Pen(accent, 2f))
                {
                    e.Graphics.DrawLine(topAccent, 1, 1, tile.Width - 2, 1);
                }

                // Draw button-theme icon badge on right of KPI card
                float badgeSize = 34f;
                float badgeX = tile.Width - badgeSize - 14f;
                float badgeY = (tile.Height - badgeSize) / 2f;
                if (badgeX > 60f)
                {
                    RectangleF badgeRect = new RectangleF(badgeX, badgeY, badgeSize, badgeSize);
                    SafariThemeEngine.DrawAdminDashboardIcon(e.Graphics, badgeRect, icon, gradStart, gradEnd, drawPillBackground: true, isHovered: false);
                }
            };
            if (lblCount != null)
            {
                lblCount.ForeColor = accent;
                lblCount.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
            }
            if (lblCap != null)
            {
                lblCap.ForeColor = Color.FromArgb(160, 160, 185);
                lblCap.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            }
        }

        private void StyleChildControlsDark(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Label lbl)
                {
                    if (lbl.ForeColor == Color.Red) continue;
                    if (lbl.Font.Size >= 15F)
                        lbl.ForeColor = Color.White;
                    else if (lbl.Font.Bold)
                        lbl.ForeColor = Color.FromArgb(214, 201, 255);
                    else
                        lbl.ForeColor = Color.FromArgb(165, 165, 190);
                }
                else if (c is TextBox txt)
                {
                    txt.BackColor = Color.FromArgb(20, 20, 32);
                    txt.ForeColor = Color.White;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (c is RichTextBox rtb)
                {
                    rtb.BackColor = Color.FromArgb(14, 14, 22);
                    rtb.ForeColor = Color.FromArgb(230, 230, 245);
                    rtb.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (c is ComboBox cbo)
                {
                    cbo.BackColor = Color.FromArgb(20, 20, 32);
                    cbo.ForeColor = Color.White;
                }
                else if (c is NumericUpDown nud)
                {
                    nud.BackColor = Color.FromArgb(20, 20, 32);
                    nud.ForeColor = Color.White;
                }
                else if (c is CheckBox chk)
                {
                    chk.ForeColor = Color.FromArgb(200, 200, 220);
                }
                else if (c is Button btn)
                {
                    if (btn.BackColor == Color.Black || btn.BackColor == Color.FromArgb(62, 74, 43))
                    {
                        btn.BackColor = Color.FromArgb(104, 92, 255);
                        btn.ForeColor = Color.White;
                    }
                    else if (btn.BackColor == Color.White)
                    {
                        btn.BackColor = Color.FromArgb(24, 24, 38);
                        if (btn.ForeColor != LogoutRed && btn.ForeColor != Color.FromArgb(180, 30, 30))
                            btn.ForeColor = Color.FromArgb(214, 201, 255);
                    }
                }
                else if (c is Panel subPanel)
                {
                    subPanel.BackColor = Color.FromArgb(16, 16, 24);
                    StyleChildControlsDark(subPanel);
                }
            }
        }

        private void PageDarkGrid_Paint(object sender, PaintEventArgs e)
        {
            var pnl = sender as Panel;
            if (pnl == null) return;
            Graphics g = e.Graphics;

            // Subtle 44px x 44px grid lines (rgba(255,255,255,0.035))
            using (var gridPen = new Pen(Color.FromArgb(9, 255, 255, 255), 1f))
            {
                for (int x = 0; x < pnl.Width; x += 44)
                    g.DrawLine(gridPen, x, 0, x, pnl.Height);
                for (int y = 0; y < pnl.Height; y += 44)
                    g.DrawLine(gridPen, 0, y, pnl.Width, y);
            }
        }

        // ---------------------------------------------------------------------
        // Interactive AnimatedBeam + IntegrationNode Canvas Renderer
        // ---------------------------------------------------------------------

        private void PnlBeamHub_MouseMove(object sender, MouseEventArgs e)
        {
            int hit = -1;
            for (int i = 0; i < _nodeRects.Length; i++)
            {
                if (_nodeRects[i].Contains(e.Location))
                {
                    hit = i;
                    break;
                }
            }
            if (hit != _hoveredNodeIndex)
            {
                _hoveredNodeIndex = hit;
                pnlShortcuts.Cursor = hit >= 0 ? Cursors.Hand : Cursors.Default;
                pnlShortcuts.Invalidate();
            }
        }

        private void PnlBeamHub_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < _nodeRects.Length; i++)
            {
                if (_nodeRects[i].Contains(e.Location))
                {
                    switch (i)
                    {
                        case 0: btnNavActivities_Click(this, EventArgs.Empty); break;
                        case 1: btnNavBookings_Click(this, EventArgs.Empty); break;
                        case 2: btnNavAttendance_Click(this, EventArgs.Empty); break;
                        case 3: btnNavReports_Click(this, EventArgs.Empty); break;
                        case 4: btnNavAiSettings_Click(this, EventArgs.Empty); break;
                        case 5: btnNavChangePass_Click(this, EventArgs.Empty); break;
                        case 6: RefreshOverviewStats(); break;
                    }
                    break;
                }
            }
        }

        private void PnlBeamHub_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            int w = pnlShortcuts.ClientSize.Width;
            int h = pnlShortcuts.ClientSize.Height;
            if (w < 200 || h < 200) return;

            // 1. Subtle 44x44 grid + outer border
            using (var gridPen = new Pen(Color.FromArgb(11, 255, 255, 255), 1f))
            {
                for (int x = 0; x < w; x += 44) g.DrawLine(gridPen, x, 0, x, h);
                for (int y = 0; y < h; y += 44) g.DrawLine(gridPen, 0, y, w, y);
            }
            // Outer border removed to match .kb-card { border: none; }

            // 2. Ambient radial glow orbs (.kb-orb)
            float pulse = 0.96f + 0.08f * (float)Math.Sin(_beamTick * 1.3f);
            DrawRadialOrb(g, w * 0.50f, h * 0.56f, Math.Min(w, h) * 0.42f * pulse, Color.FromArgb(46, 128, 84, 255));
            DrawRadialOrb(g, w * 0.16f, h * 0.22f, Math.Min(w, h) * 0.26f, Color.FromArgb(24, 255, 145, 62));
            DrawRadialOrb(g, w * 0.84f, h * 0.78f, Math.Min(w, h) * 0.28f, Color.FromArgb(26, 84, 117, 255));

            // 3. Header (.kb-eyebrow, .kb-title, .kb-description)
            DrawBeamHubHeader(g, w);

            // 4. Calculate 3-column network node positions (.kb-network)
            float netTop = 122f;
            float netBot = h - 46f;
            float netMidY = (netTop + netBot) / 2f;
            float colSpanY = Math.Max(150f, (netBot - netTop) * 0.78f);
            float topNodeY = netMidY - colSpanY / 2f;
            float botNodeY = netMidY + colSpanY / 2f;

            float leftX   = Math.Max(90f, w * 0.16f);
            float rightX  = Math.Min(w - 90f, w * 0.84f);
            float centerX = w * 0.50f;

            float smallSize = 62f;
            float largeSize = 92f;

            PointF[] centers = new PointF[7]
            {
                new PointF(leftX,   topNodeY), // 0: Activities (DriveIcon)
                new PointF(leftX,   netMidY),  // 1: Bookings (NotionIcon)
                new PointF(leftX,   botNodeY), // 2: Attendance (WhatsAppIcon)
                new PointF(rightX,  topNodeY), // 3: Reports (DocsIcon)
                new PointF(rightX,  netMidY),  // 4: SafariScout AI (ZapierIcon)
                new PointF(rightX,  botNodeY), // 5: Security (MessengerIcon)
                new PointF(centerX, netMidY)   // 6: Center Hub (KexsioIcon)
            };

            for (int i = 0; i < 6; i++)
                _nodeRects[i] = new RectangleF(centers[i].X - smallSize / 2f, centers[i].Y - smallSize / 2f, smallSize, smallSize);
            _nodeRects[6] = new RectangleF(centers[6].X - largeSize / 2f, centers[6].Y - largeSize / 2f, largeSize, largeSize);

            // 5. Draw the 6 AnimatedBeams connecting outer nodes to Center Hub (matching button theme gradients)
            DrawAnimatedBeam(g, centers[0], new PointF(centerX, netMidY - 8f), -72f, false, 4.8f, 0.0f, SafariThemeEngine.RoyalViolet, SafariThemeEngine.HorizonCyan);
            DrawAnimatedBeam(g, centers[1], centers[6],                          0f, false, 4.0f, 0.3f, SafariThemeEngine.SafariEmerald, SafariThemeEngine.HorizonCyan);
            DrawAnimatedBeam(g, centers[2], new PointF(centerX, netMidY + 8f),  72f, false, 5.2f, 0.7f, SafariThemeEngine.SafariEmerald, SafariThemeEngine.HorizonCyan);

            DrawAnimatedBeam(g, centers[3], new PointF(centerX, netMidY - 8f), -72f, true,  5.0f, 0.2f, SafariThemeEngine.RoyalViolet, SafariThemeEngine.HorizonCyan);
            DrawAnimatedBeam(g, centers[4], centers[6],                          0f, true,  4.2f, 0.5f, SafariThemeEngine.SunsetAmber, SafariThemeEngine.HorizonCyan);
            DrawAnimatedBeam(g, centers[5], new PointF(centerX, netMidY + 8f),  72f, true,  5.4f, 0.9f, SafariThemeEngine.RoyalViolet, SafariThemeEngine.SunsetAmber);

            // 6. Draw the 6 outer IntegrationNodes + Center Kexsio Hub Node
            string[] nodeLabels = {
                "ACTIVITIES",
                "ALL BOOKINGS",
                "ATTENDANCE",
                "REPORTS",
                "SAFARISCOUT AI",
                "SECURITY",
                "BLUE HORIZONS"
            };

            for (int i = 0; i < 7; i++)
            {
                bool hovered = (_hoveredNodeIndex == i);
                bool isLarge = (i == 6);
                RectangleF rect = _nodeRects[i];
                if (hovered)
                {
                    rect.Y -= 4f;
                    rect.Inflate(2.5f, 2.5f);
                }
                DrawIntegrationNode(g, rect, i, nodeLabels[i], isLarge, hovered);
            }

            // 7. Bottom Status Light (.kb-status)
            DrawBottomStatusBar(g, w, h);
        }

        private void DrawRadialOrb(Graphics g, float cx, float cy, float radius, Color centerColor)
        {
            if (radius <= 4f) return;
            RectangleF r = new RectangleF(cx - radius, cy - radius, radius * 2f, radius * 2f);
            using (var path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddEllipse(r);
                using (var pgb = new System.Drawing.Drawing2D.PathGradientBrush(path))
                {
                    pgb.CenterPoint = new PointF(cx, cy);
                    pgb.CenterColor = centerColor;
                    pgb.SurroundColors = new[] { Color.FromArgb(0, centerColor.R, centerColor.G, centerColor.B) };
                    g.FillPath(pgb, path);
                }
            }
        }

        private void DrawBeamHubHeader(Graphics g, int w)
        {
            float cx = w / 2f;

            // .kb-eyebrow pill
            RectangleF pillRect = new RectangleF(cx - 86f, 14f, 172f, 24f);
            using (var pillPath = CreateRoundRect(pillRect, 12f))
            using (var pillFill = new SolidBrush(Color.FromArgb(14, 255, 255, 255)))
            using (var pillPen  = new Pen(Color.FromArgb(30, 255, 255, 255), 1f))
            {
                g.FillPath(pillFill, pillPath);
                g.DrawPath(pillPen, pillPath);
            }
            using (var dotBrush = new SolidBrush(Color.FromArgb(155, 108, 255)))
            {
                g.FillEllipse(dotBrush, cx - 74f, 23f, 6f, 6f);
            }
            using (var eyeFont = new Font("Segoe UI", 7.5F, FontStyle.Bold))
            using (var eyeBrush = new SolidBrush(Color.FromArgb(175, 255, 255, 255)))
            {
                var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                g.DrawString("LIVE INTEGRATIONS", eyeFont, eyeBrush, new RectangleF(cx - 62f, 14f, 140f, 24f), sf);
            }

            // .kb-title: "Everything connects to one intelligent system."
            using (var titleFont = new Font("Segoe UI", 20F, FontStyle.Bold))
            {
                string part1 = "Everything connects to ";
                string part2 = "one intelligent system.";
                SizeF s1 = g.MeasureString(part1, titleFont);
                SizeF s2 = g.MeasureString(part2, titleFont);
                float totalW = s1.Width + s2.Width - 8f;
                float startX = cx - totalW / 2f;

                using (var whiteBrush = new SolidBrush(Color.White))
                {
                    g.DrawString(part1, titleFont, whiteBrush, startX, 44f);
                }
                RectangleF gradRect = new RectangleF(startX + s1.Width - 8f, 44f, Math.Max(40f, s2.Width), 40f);
                using (var gradBrush = new System.Drawing.Drawing2D.LinearGradientBrush(
                    gradRect, Color.FromArgb(214, 201, 255), Color.FromArgb(255, 206, 158), 0f))
                {
                    g.DrawString(part2, titleFont, gradBrush, gradRect.X, 44f);
                }
            }

            // .kb-description
            using (var descFont = new Font("Segoe UI", 9.25F, FontStyle.Regular))
            using (var descBrush = new SolidBrush(Color.FromArgb(135, 255, 255, 255)))
            {
                var sf = new StringFormat { Alignment = StringAlignment.Center };
                g.DrawString(
                    "Watch live tourism data flow smoothly between your modules through animated connections. Click any node to open it.",
                    descFont, descBrush, new RectangleF(40f, 84f, w - 80f, 24f), sf);
            }
        }

        private void DrawAnimatedBeam(
            Graphics g, PointF start, PointF end, float curvature,
            bool reverse, float duration, float delay,
            Color gradStart, Color gradStop)
        {
            PointF ctrl = new PointF((start.X + end.X) / 2f, start.Y - curvature);

            // Sample 36 points along the Quadratic Bezier curve M start Q ctrl end
            const int N = 36;
            PointF[] pts = new PointF[N + 1];
            for (int i = 0; i <= N; i++)
            {
                float t = i / (float)N;
                float u = 1f - t;
                pts[i] = new PointF(
                    u * u * start.X + 2f * u * t * ctrl.X + t * t * end.X,
                    u * u * start.Y + 2f * u * t * ctrl.Y + t * t * end.Y);
            }

            // 1. Base subtle path (rgba(255,255,255,0.16), width 2)
            using (var basePen = new Pen(Color.FromArgb(40, 255, 255, 255), 2f))
            {
                basePen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                basePen.EndCap   = System.Drawing.Drawing2D.LineCap.Round;
                g.DrawLines(basePen, pts);
            }

            // 2. Animated traveling gradient pulse along the curve
            float cycle = ((_beamTick + delay) % duration) / duration;
            if (reverse) cycle = 1f - cycle;

            float headPos = -0.2f + cycle * 1.4f;
            float tailLen = 0.36f;

            for (int i = 0; i < N; i++)
            {
                float segT = (i + 0.5f) / N;
                float dist = Math.Abs(segT - headPos);
                if (dist > tailLen) continue;

                float intensity = 1f - (dist / tailLen);
                intensity = intensity * intensity;

                Color segColor = InterpolateColor(gradStart, gradStop, segT);
                int alpha = Math.Min(255, (int)(255 * intensity));

                // Outer glow + core beam
                using (var glowPen = new Pen(Color.FromArgb(alpha / 3, segColor), 6f))
                {
                    glowPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                    glowPen.EndCap   = System.Drawing.Drawing2D.LineCap.Round;
                    g.DrawLine(glowPen, pts[i], pts[i + 1]);
                }
                using (var beamPen = new Pen(Color.FromArgb(alpha, segColor), 2.7f))
                {
                    beamPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                    beamPen.EndCap   = System.Drawing.Drawing2D.LineCap.Round;
                    g.DrawLine(beamPen, pts[i], pts[i + 1]);
                }
            }
        }

        private void DrawIntegrationNode(Graphics g, RectangleF rect, int nodeIndex, string label, bool isLarge, bool hovered)
        {
            float radius = isLarge ? 26f : 18f;

            Color gradStart;
            Color gradEnd;
            SafariThemeEngine.AdminDashboardIcon icon;

            switch (nodeIndex)
            {
                case 0: // Activities (btnActAdd)
                    gradStart = SafariThemeEngine.RoyalViolet;
                    gradEnd   = SafariThemeEngine.HorizonCyan;
                    icon      = SafariThemeEngine.AdminDashboardIcon.Activities;
                    break;
                case 1: // All Bookings (btnActSave)
                    gradStart = SafariThemeEngine.SafariEmerald;
                    gradEnd   = SafariThemeEngine.HorizonCyan;
                    icon      = SafariThemeEngine.AdminDashboardIcon.Bookings;
                    break;
                case 2: // Attendance (btnSaveAttendance)
                    gradStart = SafariThemeEngine.SafariEmerald;
                    gradEnd   = SafariThemeEngine.HorizonCyan;
                    icon      = SafariThemeEngine.AdminDashboardIcon.Attendance;
                    break;
                case 3: // Reports (btnGenerateReport)
                    gradStart = SafariThemeEngine.RoyalViolet;
                    gradEnd   = SafariThemeEngine.HorizonCyan;
                    icon      = SafariThemeEngine.AdminDashboardIcon.Reports;
                    break;
                case 4: // SafariScout AI (btnSaveAdminApiKey)
                    gradStart = SafariThemeEngine.SunsetAmber;
                    gradEnd   = SafariThemeEngine.HorizonCyan;
                    icon      = SafariThemeEngine.AdminDashboardIcon.AiSettings;
                    break;
                case 5: // Security (btnSavePassword)
                    gradStart = SafariThemeEngine.RoyalViolet;
                    gradEnd   = SafariThemeEngine.SunsetAmber;
                    icon      = SafariThemeEngine.AdminDashboardIcon.ChangePassword;
                    break;
                default: // Center Core Hub (Blue Horizons Tours)
                    gradStart = SafariThemeEngine.RoyalViolet;
                    gradEnd   = SafariThemeEngine.HorizonCyan;
                    icon      = SafariThemeEngine.AdminDashboardIcon.BlueHorizonsCore;
                    break;
            }

            // Outer glow shadow in button theme color
            if (isLarge || hovered)
            {
                RectangleF glowRect = rect;
                glowRect.Inflate(8f, 8f);
                using (var glowPath = CreateRoundRect(glowRect, radius + 6f))
                using (var glowBrush = new SolidBrush(Color.FromArgb(hovered ? 75 : 40, gradStart)))
                {
                    g.FillPath(glowBrush, glowPath);
                }
            }

            using (var nodePath = CreateRoundRect(rect, radius))
            {
                // Dark glass body (#101016 + subtle 145deg white sheen)
                using (var bodyBrush = new System.Drawing.Drawing2D.LinearGradientBrush(
                    rect, Color.FromArgb(34, 34, 48), Color.FromArgb(16, 16, 22), 145f))
                {
                    g.FillPath(bodyBrush, nodePath);
                }

                // Border tinted with the button gradient color, brighter on hover
                using (var borderPen = new Pen(Color.FromArgb(hovered ? 210 : 70, gradStart), isLarge ? 1.8f : 1.2f))
                {
                    g.DrawPath(borderPen, nodePath);
                }
            }

            // Draw the matching button-theme vector icon badge inside the node
            float iconSize = rect.Width * (isLarge ? 0.62f : 0.58f);
            RectangleF iconRect = new RectangleF(
                rect.X + (rect.Width - iconSize) / 2f,
                rect.Y + (rect.Height - iconSize) / 2f,
                iconSize, iconSize);

            SafariThemeEngine.DrawAdminDashboardIcon(g, iconRect, icon, gradStart, gradEnd, drawPillBackground: true, isHovered: hovered);

            // Node label (.kb-node-name)
            using (var lblFont = new Font("Segoe UI", 7.5F, FontStyle.Bold))
            using (var lblBrush = new SolidBrush(Color.FromArgb(hovered ? 245 : 140, 255, 255, 255)))
            {
                var sf = new StringFormat { Alignment = StringAlignment.Center };
                g.DrawString(label, lblFont, lblBrush, new PointF(rect.X + rect.Width / 2f, rect.Bottom + 6f), sf);
            }
        }

        private void DrawBottomStatusBar(Graphics g, int w, int h)
        {
            float cx = w / 2f;
            float y = h - 24f;
            float pulseAlpha = 0.55f + 0.45f * (float)Math.Sin(_beamTick * 2.2f);
            int a = (int)(255 * pulseAlpha);

            using (var glowBrush = new SolidBrush(Color.FromArgb(a / 3, 110, 255, 173)))
                g.FillEllipse(glowBrush, cx - 78f, y - 1f, 13f, 13f);
            using (var dotBrush = new SolidBrush(Color.FromArgb(a, 110, 255, 173)))
                g.FillEllipse(dotBrush, cx - 75f, y + 2f, 7f, 7f);

            using (var stFont = new Font("Segoe UI", 8.5F, FontStyle.Regular))
            using (var stBrush = new SolidBrush(Color.FromArgb(130, 255, 255, 255)))
            {
                g.DrawString("All systems connected", stFont, stBrush, cx - 62f, y - 2f);
            }
        }

        private static System.Drawing.Drawing2D.GraphicsPath CreateRoundRect(RectangleF rect, float radius)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            float d = radius * 2f;
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private static Color InterpolateColor(Color a, Color b, float t)
        {
            t = Math.Max(0f, Math.Min(1f, t));
            return Color.FromArgb(
                (int)(a.R + (b.R - a.R) * t),
                (int)(a.G + (b.G - a.G) * t),
                (int)(a.B + (b.B - a.B) * t));
        }

        // =================================================================
        //  BKLIT UI ANALYTICS CHARTS FOR ACTIVITY & SYSTEM REPORTS
        //  1. Bar Chart    (bklit.com/charts/bar-chart)    — Bookings & Pax per Activity
        //  2. Funnel Chart (bklit.com/charts/funnel-chart) — Capacity -> Booked -> Paid -> Attended
        //  3. Area Chart   (bklit.com/charts/area-chart)   — Cumulative Revenue & Seat Utilization Trend
        // =================================================================

        private sealed class BklitBarItem
        {
            public string Label { get; set; }
            public string FullName { get; set; }
            public string Category { get; set; }
            public int BookingsCount { get; set; }
            public int ParticipantCount { get; set; }
            public decimal Revenue { get; set; }
            public RectangleF HitBounds { get; set; }
        }

        private sealed class BklitFunnelStage
        {
            public string StageName { get; set; }
            public int Value { get; set; }
            public double ConversionPct { get; set; }
            public string Subtext { get; set; }
            public Color StartColor { get; set; }
            public Color EndColor { get; set; }
            public RectangleF HitBounds { get; set; }
        }

        private sealed class BklitAreaPoint
        {
            public string ShortLabel { get; set; }
            public string FullTitle { get; set; }
            public decimal RealizedRevenue { get; set; }
            public decimal ProjectedFullRevenue { get; set; }
            public double OccupancyPct { get; set; }
            public bool IsProjected { get; set; }
            public PointF ScreenPoint { get; set; }
            public RectangleF HitBounds { get; set; }
        }

        private readonly List<BklitBarItem> _barChartData = new List<BklitBarItem>();
        private readonly List<BklitFunnelStage> _funnelChartData = new List<BklitFunnelStage>();
        private readonly List<BklitAreaPoint> _areaChartData = new List<BklitAreaPoint>();

        private int _hoveredBarIndex = -1;
        private int _hoveredFunnelIndex = -1;
        private int _hoveredAreaIndex = -1;

        private void InitializeBklitReportCharts()
        {
            if (pnlChartBar != null)
            {
                pnlChartBar.BackColor = Color.FromArgb(14, 14, 23);
                EnableControlDoubleBuffering(pnlChartBar);
                pnlChartBar.Paint -= PnlChartBar_Paint; pnlChartBar.Paint += PnlChartBar_Paint;
                pnlChartBar.MouseMove += PnlChartBar_MouseMove;
                pnlChartBar.MouseLeave += (s, e) => { _hoveredBarIndex = -1; pnlChartBar.Invalidate(); };
            }

            if (pnlChartFunnel != null)
            {
                pnlChartFunnel.BackColor = Color.FromArgb(14, 14, 23);
                EnableControlDoubleBuffering(pnlChartFunnel);
                pnlChartFunnel.Paint -= PnlChartFunnel_Paint; pnlChartFunnel.Paint += PnlChartFunnel_Paint;
                pnlChartFunnel.MouseMove += PnlChartFunnel_MouseMove;
                pnlChartFunnel.MouseLeave += (s, e) => { _hoveredFunnelIndex = -1; pnlChartFunnel.Invalidate(); };
            }

            if (pnlChartArea != null)
            {
                pnlChartArea.BackColor = Color.FromArgb(14, 14, 23);
                EnableControlDoubleBuffering(pnlChartArea);
                pnlChartArea.Paint -= PnlChartArea_Paint; pnlChartArea.Paint += PnlChartArea_Paint;
                pnlChartArea.MouseMove += PnlChartArea_MouseMove;
                pnlChartArea.MouseLeave += (s, e) => { _hoveredAreaIndex = -1; pnlChartArea.Invalidate(); };
            }

            GenerateReport();
        }

        private void RefreshReportCharts(
            List<Activity> activities,
            List<Booking> bookings,
            List<Invoice> invoices,
            List<User> users)
        {
            if (activities == null) activities = new List<Activity>();
            if (bookings == null)   bookings   = new List<Booking>();
            if (invoices == null)   invoices   = new List<Invoice>();

            // -------------------------------------------------------------
            // 1. Bklit Bar Chart Data: Top Activities by Bookings & Pax
            // -------------------------------------------------------------
            _barChartData.Clear();
            var bookingsByAct = bookings
                .Where(b => !string.Equals(b.PaymentStatus, "Cancelled", StringComparison.OrdinalIgnoreCase))
                .GroupBy(b => b.ActivityID)
                .ToDictionary(g => g.Key, g => g.ToList());

            var orderedActs = activities
                .Select(a =>
                {
                    var list = bookingsByAct.ContainsKey(a.ActivityID) ? bookingsByAct[a.ActivityID] : new List<Booking>();
                    int bCount = list.Count;
                    int pax = list.Sum(x => x.ParticipantCount);
                    if (pax == 0 && a.TotalSeats > a.SeatsAvailable)
                    {
                        pax = Math.Max(0, a.TotalSeats - a.SeatsAvailable);
                        bCount = Math.Max(1, pax / 2);
                    }
                    decimal rev = list.Count > 0 ? list.Sum(x => x.TotalCost) : pax * a.Price;
                    string shortLbl = a.Name.Length > 10 ? a.Name.Substring(0, 9) + "…" : a.Name;
                    return new BklitBarItem
                    {
                        Label = shortLbl,
                        FullName = a.Name,
                        Category = a.Category,
                        BookingsCount = bCount,
                        ParticipantCount = pax,
                        Revenue = rev
                    };
                })
                .OrderByDescending(x => x.ParticipantCount)
                .ThenByDescending(x => x.Revenue)
                .Take(6)
                .ToList();

            _barChartData.AddRange(orderedActs);

            // -------------------------------------------------------------
            // 2. Bklit Funnel Chart Data: Capacity -> Booked -> Paid -> Attended
            // -------------------------------------------------------------
            _funnelChartData.Clear();
            int totalCapacity = Math.Max(1, activities.Sum(a => a.TotalSeats));
            int seatsFromDiff = activities.Sum(a => Math.Max(0, a.TotalSeats - a.SeatsAvailable));
            int activePax = bookings
                .Where(b => !string.Equals(b.PaymentStatus, "Cancelled", StringComparison.OrdinalIgnoreCase))
                .Sum(b => b.ParticipantCount);
            int totalBookedPax = Math.Max(seatsFromDiff, activePax);

            int paidPax = bookings
                .Where(b => string.Equals(b.PaymentStatus, "Paid", StringComparison.OrdinalIgnoreCase))
                .Sum(b => b.ParticipantCount);
            if (paidPax == 0 && totalBookedPax > 0) paidPax = totalBookedPax;

            int attendedPax = bookings
                .Where(b => string.Equals(b.Attendance, "Attended", StringComparison.OrdinalIgnoreCase))
                .Sum(b => b.ParticipantCount);
            int pendingPax = bookings
                .Where(b => string.Equals(b.Attendance, "Pending", StringComparison.OrdinalIgnoreCase))
                .Sum(b => b.ParticipantCount);
            int noShowPax = bookings
                .Where(b => string.Equals(b.Attendance, "No-Show", StringComparison.OrdinalIgnoreCase))
                .Sum(b => b.ParticipantCount);

            _funnelChartData.Add(new BklitFunnelStage
            {
                StageName = "Capacity Seats",
                Value = totalCapacity,
                ConversionPct = 100.0,
                Subtext = $"{activities.Count} active tours",
                StartColor = Color.FromArgb(139, 92, 246),
                EndColor = Color.FromArgb(99, 102, 241)
            });
            _funnelChartData.Add(new BklitFunnelStage
            {
                StageName = "Reserved Pax",
                Value = totalBookedPax,
                ConversionPct = Math.Min(100.0, (totalBookedPax * 100.0) / totalCapacity),
                Subtext = $"{bookings.Count} total bookings",
                StartColor = Color.FromArgb(59, 130, 246),
                EndColor = Color.FromArgb(6, 182, 212)
            });
            _funnelChartData.Add(new BklitFunnelStage
            {
                StageName = "Paid Confirmed",
                Value = paidPax,
                ConversionPct = totalBookedPax > 0 ? Math.Min(100.0, (paidPax * 100.0) / totalCapacity) : 0.0,
                Subtext = $"{invoices.Count} invoices issued",
                StartColor = Color.FromArgb(16, 185, 129),
                EndColor = Color.FromArgb(52, 211, 153)
            });
            _funnelChartData.Add(new BklitFunnelStage
            {
                StageName = "Attended Pax",
                Value = attendedPax,
                ConversionPct = totalBookedPax > 0 ? Math.Min(100.0, (attendedPax * 100.0) / Math.Max(1, totalBookedPax)) : 0.0,
                Subtext = $"Pending: {pendingPax} | No-Show: {noShowPax}",
                StartColor = Color.FromArgb(245, 158, 11),
                EndColor = Color.FromArgb(251, 191, 36)
            });

            // -------------------------------------------------------------
            // 3. Bklit Area Chart Data: Cumulative Revenue & Schedule Trend
            // -------------------------------------------------------------
            _areaChartData.Clear();
            var actsByDate = activities.OrderBy(a => a.Date).Take(6).ToList();
            decimal runningRealized = 0m;
            for (int i = 0; i < actsByDate.Count; i++)
            {
                var a = actsByDate[i];
                var list = bookingsByAct.ContainsKey(a.ActivityID) ? bookingsByAct[a.ActivityID] : new List<Booking>();
                int pax = list.Sum(x => x.ParticipantCount);
                if (pax == 0 && a.TotalSeats > a.SeatsAvailable)
                    pax = Math.Max(0, a.TotalSeats - a.SeatsAvailable);

                decimal actRev = list.Count > 0 ? list.Sum(x => x.TotalCost) : pax * a.Price;
                runningRealized += actRev;
                decimal potentialRev = runningRealized + (a.SeatsAvailable * a.Price * 0.35m);
                double occ = a.TotalSeats > 0 ? (pax * 100.0) / a.TotalSeats : 0.0;

                _areaChartData.Add(new BklitAreaPoint
                {
                    ShortLabel = a.Date.ToString("dd MMM"),
                    FullTitle = $"{a.Name} ({a.Date:dd MMM yyyy})",
                    RealizedRevenue = runningRealized,
                    ProjectedFullRevenue = potentialRev,
                    OccupancyPct = occ,
                    IsProjected = (i >= actsByDate.Count - 2)
                });
            }

            pnlChartBar?.Invalidate();
            pnlChartFunnel?.Invalidate();
            pnlChartArea?.Invalidate();
        }

        // -----------------------------------------------------------------
        // Shared Bklit UI Card Frame + Dot Grid Background + Tooltip Helper
        // -----------------------------------------------------------------
        private void DrawBklitCardChrome(
            Graphics g, int w, int h,
            string badgeText, Color badgeAccent,
            string title, string subtitle, string footerText)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            RectangleF cardRect = new RectangleF(1f, 1f, w - 2f, h - 2f);
            using (var cardPath = CreateRoundRect(cardRect, 14f))
            {
                using (var bgBrush = new System.Drawing.Drawing2D.LinearGradientBrush(
                    cardRect, Color.FromArgb(18, 18, 29), Color.FromArgb(11, 11, 18), 135f))
                {
                    g.FillPath(bgBrush, cardPath);
                }

                // Bklit Dot-Grid Background texture inside plot area
                using (var dotBrush = new SolidBrush(Color.FromArgb(18, 255, 255, 255)))
                {
                    for (int x = 22; x < w - 18; x += 18)
                    {
                        for (int y = 58; y < h - 32; y += 18)
                        {
                            g.FillEllipse(dotBrush, x, y, 2f, 2f);
                        }
                    }
                }

                using (var borderPen = new Pen(Color.FromArgb(36, 255, 255, 255), 1f))
                {
                    g.DrawPath(borderPen, cardPath);
                }
            }

            // Top glowing accent bar
            using (var topPen = new Pen(badgeAccent, 2f))
            {
                g.DrawLine(topPen, 16f, 1.5f, w - 16f, 1.5f);
            }

            // Header Title & Subtitle
            using (var titleFont = new Font("Segoe UI", 10F, FontStyle.Bold))
            using (var subFont = new Font("Segoe UI", 7.75F, FontStyle.Regular))
            using (var whiteBrush = new SolidBrush(Color.FromArgb(245, 245, 255)))
            using (var subBrush = new SolidBrush(Color.FromArgb(145, 148, 175)))
            {
                g.DrawString(title, titleFont, whiteBrush, 14f, 10f);
                g.DrawString(subtitle, subFont, subBrush, 14f, 29f);
            }

            // Bklit Component Pill Badge in Top-Right
            using (var badgeFont = new Font("Segoe UI", 7F, FontStyle.Bold))
            {
                SizeF bSize = g.MeasureString(badgeText, badgeFont);
                RectangleF bRect = new RectangleF(w - bSize.Width - 24f, 10f, bSize.Width + 12f, 18f);
                using (var bPath = CreateRoundRect(bRect, 9f))
                using (var bFill = new SolidBrush(Color.FromArgb(35, badgeAccent)))
                using (var bPen = new Pen(Color.FromArgb(120, badgeAccent), 1f))
                using (var bText = new SolidBrush(Color.FromArgb(225, 230, 255)))
                {
                    g.FillPath(bFill, bPath);
                    g.DrawPath(bPen, bPath);
                    var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    g.DrawString(badgeText, badgeFont, bText, bRect, sf);
                }
            }

            // Footer Trend Status Line
            using (var footFont = new Font("Segoe UI", 7.5F, FontStyle.Bold))
            using (var footBrush = new SolidBrush(Color.FromArgb(165, 175, 205)))
            using (var dotBrush = new SolidBrush(badgeAccent))
            {
                g.FillEllipse(dotBrush, 14f, h - 19f, 6f, 6f);
                g.DrawString(footerText, footFont, footBrush, 24f, h - 23f);
            }
        }

        private void DrawBklitTooltip(Graphics g, int panelW, int panelH, PointF anchor, string title, string line1, string line2, Color accent)
        {
            using (var fTitle = new Font("Segoe UI", 8F, FontStyle.Bold))
            using (var fBody = new Font("Segoe UI", 7.5F, FontStyle.Regular))
            {
                float w1 = g.MeasureString(title, fTitle).Width;
                float w2 = g.MeasureString(line1, fBody).Width;
                float w3 = g.MeasureString(line2, fBody).Width;
                float boxW = Math.Max(w1, Math.Max(w2, w3)) + 22f;
                float boxH = 52f;

                float tx = Math.Max(8f, Math.Min(panelW - boxW - 8f, anchor.X - boxW / 2f));
                float ty = anchor.Y - boxH - 10f;
                if (ty < 46f) ty = Math.Min(panelH - boxH - 8f, anchor.Y + 12f);

                RectangleF rect = new RectangleF(tx, ty, boxW, boxH);
                using (var path = CreateRoundRect(rect, 8f))
                using (var bg = new SolidBrush(Color.FromArgb(242, 9, 9, 15)))
                using (var border = new Pen(Color.FromArgb(160, accent), 1.2f))
                {
                    g.FillPath(bg, path);
                    g.DrawPath(border, path);
                }

                using (var accentBrush = new SolidBrush(accent))
                using (var whiteBrush = new SolidBrush(Color.White))
                using (var mutedBrush = new SolidBrush(Color.FromArgb(195, 200, 225)))
                {
                    g.FillEllipse(accentBrush, tx + 8f, ty + 8f, 6f, 6f);
                    g.DrawString(title, fTitle, whiteBrush, tx + 17f, ty + 4f);
                    g.DrawString(line1, fBody, mutedBrush, tx + 8f, ty + 20f);
                    g.DrawString(line2, fBody, accentBrush, tx + 8f, ty + 34f);
                }
            }
        }

        // -----------------------------------------------------------------
        // CHART 1: Bklit UI Bar Chart (Bookings & Pax per Activity)
        // -----------------------------------------------------------------
        private void PnlChartBar_MouseMove(object sender, MouseEventArgs e)
        {
            int hit = -1;
            for (int i = 0; i < _barChartData.Count; i++)
            {
                if (_barChartData[i].HitBounds.Contains(e.Location))
                {
                    hit = i;
                    break;
                }
            }
            if (hit != _hoveredBarIndex)
            {
                _hoveredBarIndex = hit;
                pnlChartBar.Cursor = hit >= 0 ? Cursors.Hand : Cursors.Default;
                pnlChartBar.Invalidate();
            }
        }

        private void PnlChartBar_Paint(object sender, PaintEventArgs e)
        {
            if (pnlChartBar == null) return;
            int w = pnlChartBar.Width;
            int h = pnlChartBar.Height;
            Graphics g = e.Graphics;

            string topAct = _barChartData.Count > 0 ? _barChartData[0].FullName : "No activities";
            if (topAct.Length > 24) topAct = topAct.Substring(0, 22) + "…";

            DrawBklitCardChrome(
                g, w, h,
                "BKLIT BAR CHART", Color.FromArgb(139, 92, 246),
                "Bookings & Pax by Activity",
                "Grouped rounded bars (Pax vs Bookings)",
                $"Top activity: {topAct}");

            if (_barChartData.Count == 0) return;

            float plotLeft = 36f;
            float plotRight = w - 14f;
            float plotTop = 56f;
            float plotBottom = h - 46f;
            float plotW = Math.Max(60f, plotRight - plotLeft);
            float plotH = Math.Max(60f, plotBottom - plotTop);

            int maxPax = Math.Max(4, _barChartData.Max(x => Math.Max(x.ParticipantCount, x.BookingsCount)));

            // Horizontal dashed gridlines + Left Y-axis ticks
            using (var gridPen = new Pen(Color.FromArgb(26, 255, 255, 255), 1f))
            using (var axisFont = new Font("Segoe UI", 6.75F, FontStyle.Regular))
            using (var axisBrush = new SolidBrush(Color.FromArgb(130, 135, 160)))
            {
                gridPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                for (int step = 0; step <= 3; step++)
                {
                    float ratio = step / 3f;
                    float y = plotBottom - ratio * plotH;
                    g.DrawLine(gridPen, plotLeft, y, plotRight, y);
                    int val = (int)Math.Round(ratio * maxPax);
                    g.DrawString(val.ToString(), axisFont, axisBrush, 8f, y - 6f);
                }
            }

            int n = _barChartData.Count;
            float slotW = plotW / n;
            float barW = Math.Max(7f, Math.Min(18f, (slotW - 12f) / 2f));

            using (var lblFont = new Font("Segoe UI", 6.75F, FontStyle.Bold))
            using (var lblBrush = new SolidBrush(Color.FromArgb(170, 175, 200)))
            {
                var sfCenter = new StringFormat { Alignment = StringAlignment.Center };

                for (int i = 0; i < n; i++)
                {
                    var item = _barChartData[i];
                    float slotX = plotLeft + i * slotW;
                    item.HitBounds = new RectangleF(slotX, plotTop, slotW, plotH + 18f);

                    // Hover column highlight band
                    if (i == _hoveredBarIndex)
                    {
                        using (var hovBrush = new SolidBrush(Color.FromArgb(22, 139, 92, 246)))
                        using (var hovPath = CreateRoundRect(new RectangleF(slotX + 2f, plotTop, slotW - 4f, plotH), 6f))
                        {
                            g.FillPath(hovBrush, hovPath);
                        }
                    }

                    // Bar 1: Participant Count (Blue -> Purple Bklit Gradient)
                    float paxRatio = Math.Min(1f, item.ParticipantCount / (float)maxPax);
                    float paxH = Math.Max(6f, paxRatio * (plotH - 8f));
                    float bx1 = slotX + (slotW / 2f) - barW - 1.5f;
                    RectangleF rectPax = new RectangleF(bx1, plotBottom - paxH, barW, paxH);

                    using (var paxPath = CreateRoundRect(rectPax, 4f))
                    using (var paxBrush = new System.Drawing.Drawing2D.LinearGradientBrush(
                        rectPax, Color.FromArgb(59, 130, 246), Color.FromArgb(139, 92, 246), 90f))
                    {
                        g.FillPath(paxBrush, paxPath);
                    }

                    // Bar 2: Bookings Count (Emerald -> Cyan Bklit Gradient)
                    float bkRatio = Math.Min(1f, item.BookingsCount / (float)maxPax);
                    float bkH = Math.Max(6f, bkRatio * (plotH - 8f));
                    float bx2 = slotX + (slotW / 2f) + 1.5f;
                    RectangleF rectBk = new RectangleF(bx2, plotBottom - bkH, barW, bkH);

                    using (var bkPath = CreateRoundRect(rectBk, 4f))
                    using (var bkBrush = new System.Drawing.Drawing2D.LinearGradientBrush(
                        rectBk, Color.FromArgb(16, 185, 129), Color.FromArgb(6, 182, 212), 90f))
                    {
                        g.FillPath(bkBrush, bkPath);
                    }

                    // X-axis label
                    g.DrawString(item.Label, lblFont, lblBrush, new RectangleF(slotX - 2f, plotBottom + 4f, slotW + 4f, 16f), sfCenter);
                }
            }

            // Interactive Bklit Tooltip on Hover
            if (_hoveredBarIndex >= 0 && _hoveredBarIndex < _barChartData.Count)
            {
                var hItem = _barChartData[_hoveredBarIndex];
                PointF anchor = new PointF(hItem.HitBounds.X + hItem.HitBounds.Width / 2f, plotTop + 24f);
                DrawBklitTooltip(
                    g, w, h, anchor,
                    hItem.FullName,
                    $"Pax: {hItem.ParticipantCount}  •  Bookings: {hItem.BookingsCount}",
                    $"Revenue: R{hItem.Revenue:N2} ({hItem.Category})",
                    Color.FromArgb(139, 92, 246));
            }
        }

        // -----------------------------------------------------------------
        // CHART 2: Bklit UI Funnel Chart (Capacity -> Booked -> Paid -> Attended)
        // -----------------------------------------------------------------
        private void PnlChartFunnel_MouseMove(object sender, MouseEventArgs e)
        {
            int hit = -1;
            for (int i = 0; i < _funnelChartData.Count; i++)
            {
                if (_funnelChartData[i].HitBounds.Contains(e.Location))
                {
                    hit = i;
                    break;
                }
            }
            if (hit != _hoveredFunnelIndex)
            {
                _hoveredFunnelIndex = hit;
                pnlChartFunnel.Cursor = hit >= 0 ? Cursors.Hand : Cursors.Default;
                pnlChartFunnel.Invalidate();
            }
        }

        private void PnlChartFunnel_Paint(object sender, PaintEventArgs e)
        {
            if (pnlChartFunnel == null) return;
            int w = pnlChartFunnel.Width;
            int h = pnlChartFunnel.Height;
            Graphics g = e.Graphics;

            double attPct = _funnelChartData.Count >= 4 ? _funnelChartData[3].ConversionPct : 0.0;
            DrawBklitCardChrome(
                g, w, h,
                "BKLIT FUNNEL", Color.FromArgb(16, 185, 129),
                "Visitor Conversion & Attendance",
                "Multi-stage capacity-to-attendance funnel",
                $"Attendance conversion: {attPct:F1}% of booked pax");

            if (_funnelChartData.Count == 0) return;

            float plotLeft = 16f;
            float plotRight = w - 16f;
            float plotTop = 54f;
            float plotBottom = h - 32f;
            float plotW = Math.Max(80f, plotRight - plotLeft);
            float plotH = Math.Max(80f, plotBottom - plotTop);

            int stages = _funnelChartData.Count;
            float rowGap = 6f;
            float rowH = (plotH - rowGap * (stages - 1)) / stages;
            float centerX = plotLeft + plotW / 2f;

            // Tapered funnel widths per stage (Bklit Funnel style with halo glow)
            float[] widthRatios = { 0.96f, 0.78f, 0.62f, 0.48f };

            using (var stageFont = new Font("Segoe UI", 8F, FontStyle.Bold))
            using (var valFont = new Font("Segoe UI", 7.25F, FontStyle.Bold))
            using (var whiteBrush = new SolidBrush(Color.White))
            {
                var sfCenter = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

                for (int i = 0; i < stages; i++)
                {
                    var st = _funnelChartData[i];
                    float y1 = plotTop + i * (rowH + rowGap);
                    float y2 = y1 + rowH;

                    float topW = plotW * widthRatios[Math.Min(i, widthRatios.Length - 1)];
                    float botW = plotW * widthRatios[Math.Min(i + 1, widthRatios.Length - 1)] * (i == stages - 1 ? 0.92f : 1.0f);

                    PointF[] trap = {
                        new PointF(centerX - topW / 2f, y1),
                        new PointF(centerX + topW / 2f, y1),
                        new PointF(centerX + botW / 2f, y2),
                        new PointF(centerX - botW / 2f, y2)
                    };

                    st.HitBounds = new RectangleF(centerX - topW / 2f, y1, topW, rowH);

                    // Outer halo ring on hover
                    if (i == _hoveredFunnelIndex)
                    {
                        using (var haloPen = new Pen(Color.FromArgb(140, st.StartColor), 3.5f))
                        {
                            g.DrawPolygon(haloPen, trap);
                        }
                    }

                    using (var gradBrush = new System.Drawing.Drawing2D.LinearGradientBrush(
                        new RectangleF(plotLeft, y1, plotW, rowH),
                        Color.FromArgb(i == _hoveredFunnelIndex ? 235 : 195, st.StartColor),
                        Color.FromArgb(i == _hoveredFunnelIndex ? 235 : 195, st.EndColor),
                        0f))
                    using (var borderPen = new Pen(Color.FromArgb(95, 255, 255, 255), 1f))
                    {
                        g.FillPolygon(gradBrush, trap);
                        g.DrawPolygon(borderPen, trap);
                    }

                    string labelLine = $"{st.StageName}: {st.Value} ({st.ConversionPct:F0}%)";
                    g.DrawString(labelLine, i == 0 ? stageFont : valFont, whiteBrush, new RectangleF(plotLeft, y1, plotW, rowH), sfCenter);
                }
            }

            if (_hoveredFunnelIndex >= 0 && _hoveredFunnelIndex < _funnelChartData.Count)
            {
                var hStage = _funnelChartData[_hoveredFunnelIndex];
                PointF anchor = new PointF(centerX, hStage.HitBounds.Y + 6f);
                DrawBklitTooltip(
                    g, w, h, anchor,
                    hStage.StageName,
                    $"Volume: {hStage.Value} seats/pax ({hStage.ConversionPct:F1}%)",
                    hStage.Subtext,
                    hStage.StartColor);
            }
        }

        // -----------------------------------------------------------------
        // CHART 3: Bklit UI Area Chart (Cumulative Revenue & Schedule Trend)
        // -----------------------------------------------------------------
        private void PnlChartArea_MouseMove(object sender, MouseEventArgs e)
        {
            int hit = -1;
            float bestDist = 28f;
            for (int i = 0; i < _areaChartData.Count; i++)
            {
                float dx = Math.Abs(e.X - _areaChartData[i].ScreenPoint.X);
                if (dx < bestDist && e.Y >= 48 && e.Y <= pnlChartArea.Height - 28)
                {
                    bestDist = dx;
                    hit = i;
                }
            }
            if (hit != _hoveredAreaIndex)
            {
                _hoveredAreaIndex = hit;
                pnlChartArea.Cursor = hit >= 0 ? Cursors.Hand : Cursors.Default;
                pnlChartArea.Invalidate();
            }
        }

        private void PnlChartArea_Paint(object sender, PaintEventArgs e)
        {
            if (pnlChartArea == null) return;
            int w = pnlChartArea.Width;
            int h = pnlChartArea.Height;
            Graphics g = e.Graphics;

            decimal totalRev = _areaChartData.Count > 0 ? _areaChartData[_areaChartData.Count - 1].RealizedRevenue : 0m;
            DrawBklitCardChrome(
                g, w, h,
                "BKLIT AREA CHART", Color.FromArgb(56, 189, 248),
                "Revenue & Capacity Trajectory",
                "Gradient area curve + dashed projection tail",
                $"Cumulative revenue: R{totalRev:N2}");

            if (_areaChartData.Count == 0) return;

            float plotLeft = 44f;
            float plotRight = w - 16f;
            float plotTop = 56f;
            float plotBottom = h - 46f;
            float plotW = Math.Max(60f, plotRight - plotLeft);
            float plotH = Math.Max(60f, plotBottom - plotTop);

            decimal maxRev = Math.Max(1000m, _areaChartData.Max(x => Math.Max(x.RealizedRevenue, x.ProjectedFullRevenue)));

            // Reference band + horizontal dashed lines
            using (var gridPen = new Pen(Color.FromArgb(26, 255, 255, 255), 1f))
            using (var axisFont = new Font("Segoe UI", 6.5F, FontStyle.Regular))
            using (var axisBrush = new SolidBrush(Color.FromArgb(130, 135, 160)))
            {
                gridPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                for (int step = 0; step <= 3; step++)
                {
                    float ratio = step / 3f;
                    float y = plotBottom - ratio * plotH;
                    g.DrawLine(gridPen, plotLeft, y, plotRight, y);
                    decimal val = (decimal)ratio * maxRev;
                    string lbl = val >= 1000m ? $"R{(val / 1000m):F1}k" : $"R{val:F0}";
                    g.DrawString(lbl, axisFont, axisBrush, 6f, y - 6f);
                }
            }

            int n = _areaChartData.Count;
            PointF[] pts = new PointF[n];
            for (int i = 0; i < n; i++)
            {
                float x = n == 1 ? plotLeft + plotW / 2f : plotLeft + (i / (float)(n - 1)) * plotW;
                float ratio = (float)(_areaChartData[i].RealizedRevenue / maxRev);
                float y = plotBottom - Math.Max(4f, ratio * (plotH - 10f));
                pts[i] = new PointF(x, y);
                _areaChartData[i].ScreenPoint = pts[i];
            }

            if (n >= 2)
            {
                // Bklit Gradient Fill under the curve
                using (var areaPath = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    areaPath.AddLine(pts[0].X, plotBottom, pts[0].X, pts[0].Y);
                    areaPath.AddCurve(pts, 0.35f);
                    areaPath.AddLine(pts[n - 1].X, pts[n - 1].Y, pts[n - 1].X, plotBottom);
                    areaPath.CloseFigure();

                    using (var areaGrad = new System.Drawing.Drawing2D.LinearGradientBrush(
                        new RectangleF(plotLeft, plotTop, plotW, plotH),
                        Color.FromArgb(115, 56, 189, 248),
                        Color.FromArgb(8, 139, 92, 246),
                        90f))
                    {
                        g.FillPath(areaGrad, areaPath);
                    }
                }

                // Solid primary stroke up to dashFromIndex, then dashed projection tail (Bklit Area Chart - Dashed Tail)
                int splitIdx = Math.Max(1, n - 2);
                PointF[] solidPts = pts.Take(splitIdx + 1).ToArray();
                if (solidPts.Length >= 2)
                {
                    using (var strokePen = new Pen(Color.FromArgb(56, 189, 248), 2.4f))
                    {
                        g.DrawCurve(strokePen, solidPts, 0.35f);
                    }
                }

                PointF[] dashPts = pts.Skip(splitIdx).ToArray();
                if (dashPts.Length >= 2)
                {
                    using (var dashPen = new Pen(Color.FromArgb(195, 168, 85, 247), 2.2f))
                    {
                        dashPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        g.DrawLines(dashPen, dashPts);
                    }
                }
            }

            // Bklit Scatter-style Ring Markers + X-axis date labels
            using (var lblFont = new Font("Segoe UI", 6.75F, FontStyle.Bold))
            using (var lblBrush = new SolidBrush(Color.FromArgb(170, 175, 200)))
            {
                var sfCenter = new StringFormat { Alignment = StringAlignment.Center };
                for (int i = 0; i < n; i++)
                {
                    PointF pt = pts[i];
                    bool hovered = (i == _hoveredAreaIndex);

                    if (hovered)
                    {
                        // Vertical crosshair scrubber line
                        using (var crossPen = new Pen(Color.FromArgb(110, 56, 189, 248), 1f))
                        {
                            crossPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                            g.DrawLine(crossPen, pt.X, plotTop, pt.X, plotBottom);
                        }
                    }

                    float rOuter = hovered ? 6.5f : 4.5f;
                    using (var glowBrush = new SolidBrush(Color.FromArgb(hovered ? 90 : 40, 56, 189, 248)))
                        g.FillEllipse(glowBrush, pt.X - rOuter - 2f, pt.Y - rOuter - 2f, (rOuter + 2f) * 2f, (rOuter + 2f) * 2f);

                    using (var coreBrush = new SolidBrush(Color.FromArgb(14, 14, 23)))
                    using (var ringPen = new Pen(i >= n - 2 ? Color.FromArgb(168, 85, 247) : Color.FromArgb(56, 189, 248), 2.2f))
                    {
                        g.FillEllipse(coreBrush, pt.X - rOuter, pt.Y - rOuter, rOuter * 2f, rOuter * 2f);
                        g.DrawEllipse(ringPen, pt.X - rOuter, pt.Y - rOuter, rOuter * 2f, rOuter * 2f);
                    }

                    g.DrawString(_areaChartData[i].ShortLabel, lblFont, lblBrush, new RectangleF(pt.X - 26f, plotBottom + 4f, 52f, 16f), sfCenter);
                }
            }

            if (_hoveredAreaIndex >= 0 && _hoveredAreaIndex < _areaChartData.Count)
            {
                var hPt = _areaChartData[_hoveredAreaIndex];
                DrawBklitTooltip(
                    g, w, h, hPt.ScreenPoint,
                    hPt.FullTitle,
                    $"Cumulative Rev: R{hPt.RealizedRevenue:N2}",
                    $"Seat Utilization: {hPt.OccupancyPct:F1}% {(hPt.IsProjected ? "(Projected Tail)" : "(Confirmed)")}",
                    Color.FromArgb(56, 189, 248));
            }
        }

        // =================================================================
        //  GALLERY PANEL IMAGE EDITOR & CUSTOM IMAGE UPLOADER
        //  Available in both Manage Activities (pnlActivityForm) and
        //  All Bookings (btnBookingEditImage modal editor).
        // =================================================================

        private string _pendingActivityImageSetting = null;
        private string _pendingUploadedSourceFile = null;
        private bool _suppressPresetComboEvent = false;

        private void LoadActivityImageEditorForSelected(Activity act)
        {
            _pendingUploadedSourceFile = null;
            if (act == null)
            {
                _pendingActivityImageSetting = null;
                RefreshActivityImagePreviewBox();
                return;
            }

            string setting = SafariThemeEngine.GetActivityImageSetting(act.ActivityID);
            _pendingActivityImageSetting = setting;

            _suppressPresetComboEvent = true;
            if (cboActImagePreset != null && cboActImagePreset.Items.Count > 0)
            {
                int foundIdx = 0;
                if (!string.IsNullOrEmpty(setting))
                {
                    for (int i = 0; i < cboActImagePreset.Items.Count; i++)
                    {
                        if (string.Equals(cboActImagePreset.Items[i].ToString(), setting, StringComparison.OrdinalIgnoreCase))
                        {
                            foundIdx = i;
                            break;
                        }
                    }
                }
                cboActImagePreset.SelectedIndex = foundIdx;
            }
            _suppressPresetComboEvent = false;

            RefreshActivityImagePreviewBox();
        }

        private void RefreshActivityImagePreviewBox()
        {
            if (picActImagePreview == null) return;

            Activity previewAct = _selectedActivity ?? new Activity
            {
                ActivityID = "preview",
                Category = cboCategory?.SelectedItem?.ToString() ?? "Safari",
                Name = string.IsNullOrWhiteSpace(txtActName?.Text) ? "Big Five Sunrise Safari" : txtActName.Text.Trim()
            };

            string effectiveSetting = _pendingUploadedSourceFile ?? _pendingActivityImageSetting;
            picActImagePreview.Image = SafariThemeEngine.GetOrCreateTourImage(previewAct, effectiveSetting);

            if (lblActImageStatus != null)
            {
                if (!string.IsNullOrEmpty(_pendingUploadedSourceFile))
                    lblActImageStatus.Text = "Uploaded: " + Path.GetFileName(_pendingUploadedSourceFile);
                else if (!string.IsNullOrEmpty(_pendingActivityImageSetting))
                {
                    bool isPreset = _pendingActivityImageSetting.StartsWith("Preset ", StringComparison.OrdinalIgnoreCase);
                    lblActImageStatus.Text = isPreset
                        ? _pendingActivityImageSetting
                        : "Custom: " + Path.GetFileName(_pendingActivityImageSetting);
                }
                else
                {
                    lblActImageStatus.Text = "Active: Auto (Match Tour Name)";
                }
            }
        }

        private void SavePendingImageForActivity(string activityId)
        {
            if (string.IsNullOrWhiteSpace(activityId)) return;
            try
            {
                if (!string.IsNullOrWhiteSpace(_pendingUploadedSourceFile) && File.Exists(_pendingUploadedSourceFile))
                {
                    string savedPath = SafariThemeEngine.SaveUploadedActivityImage(activityId, _pendingUploadedSourceFile);
                    _pendingActivityImageSetting = savedPath;
                    _pendingUploadedSourceFile = null;
                }
                else
                {
                    SafariThemeEngine.SetActivityImageSetting(activityId, _pendingActivityImageSetting);
                }
            }
            catch { }
        }

        private void cboActImagePreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suppressPresetComboEvent || cboActImagePreset == null) return;
            string chosen = cboActImagePreset.SelectedItem?.ToString() ?? "Auto (Match Tour Name)";
            _pendingUploadedSourceFile = null;
            _pendingActivityImageSetting = chosen == "Auto (Match Tour Name)" ? null : chosen;

            if (_selectedActivity != null)
            {
                SafariThemeEngine.SetActivityImageSetting(_selectedActivity.ActivityID, _pendingActivityImageSetting);
            }
            RefreshActivityImagePreviewBox();
        }

        private void btnUploadActImage_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Select Custom Tour Image for AccordionGallery Panel";
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                if (ofd.ShowDialog(this) != DialogResult.OK) return;

                try
                {
                    if (_selectedActivity != null)
                    {
                        string savedPath = SafariThemeEngine.SaveUploadedActivityImage(_selectedActivity.ActivityID, ofd.FileName);
                        _pendingActivityImageSetting = savedPath;
                        _pendingUploadedSourceFile = null;
                        RefreshActivityImagePreviewBox();
                        MessageBox.Show(
                            $"Custom panel image uploaded for '{_selectedActivity.Name}'!\n\n" +
                            "Visitors browsing the interactive AccordionGallery will immediately see your uploaded image.",
                            "Panel Image Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        _pendingUploadedSourceFile = ofd.FileName;
                        RefreshActivityImagePreviewBox();
                        MessageBox.Show(
                            "Custom image staged! Click 'Add Activity' to save the new activity along with this panel image.",
                            "Image Staged", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to upload image: " + ex.Message, "Upload Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnResetActImage_Click(object sender, EventArgs e)
        {
            _pendingUploadedSourceFile = null;
            _pendingActivityImageSetting = null;
            _suppressPresetComboEvent = true;
            if (cboActImagePreset != null && cboActImagePreset.Items.Count > 0)
                cboActImagePreset.SelectedIndex = 0;
            _suppressPresetComboEvent = false;

            if (_selectedActivity != null)
            {
                SafariThemeEngine.SetActivityImageSetting(_selectedActivity.ActivityID, null);
            }
            RefreshActivityImagePreviewBox();
        }

        private void btnBookingEditImage_Click(object sender, EventArgs e)
        {
            List<Activity> allActs;
            try { allActs = FileService.GetAllActivities(); }
            catch { allActs = new List<Activity>(); }

            if (allActs.Count == 0)
            {
                MessageBox.Show("No activities found to edit images for.", "No Activities",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Try to match the activity from the selected row in dgvAllBookings or cboBookingActivityFilter
            Activity initialAct = allActs[0];
            if (dgvAllBookings != null && dgvAllBookings.SelectedRows.Count > 0)
            {
                string rowActName = dgvAllBookings.SelectedRows[0].Cells["Activity"].Value?.ToString();
                var matched = allActs.FirstOrDefault(a => string.Equals(a.Name, rowActName, StringComparison.OrdinalIgnoreCase));
                if (matched != null) initialAct = matched;
            }
            else if (cboBookingActivityFilter != null && cboBookingActivityFilter.SelectedIndex > 0)
            {
                string filterName = cboBookingActivityFilter.SelectedItem?.ToString();
                var matched = allActs.FirstOrDefault(a => string.Equals(a.Name, filterName, StringComparison.OrdinalIgnoreCase));
                if (matched != null) initialAct = matched;
            }

            OpenBookingPanelImageDialog(allActs, initialAct);
        }

        private void OpenBookingPanelImageDialog(List<Activity> allActs, Activity initialAct)
        {
            using (Form dlg = new Form())
            {
                dlg.Text = "Edit / Upload AccordionGallery Panel Images";
                dlg.Size = new Size(560, 420);
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.MaximizeBox = false;
                dlg.MinimizeBox = false;
                dlg.BackColor = SafariThemeEngine.ObsidianBg;
                dlg.ForeColor = Color.White;

                var lblHeading = new Label
                {
                    Text = "🖼  Customize Tour Panel Image (Browse Activities Gallery)",
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                    ForeColor = Color.White,
                    Location = new Point(20, 16),
                    Size = new Size(500, 28)
                };

                var lblPickAct = new Label
                {
                    Text = "SELECT TOUR / ACTIVITY PANEL:",
                    Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                    ForeColor = SafariThemeEngine.TextSecondary,
                    Location = new Point(20, 52),
                    Size = new Size(260, 18)
                };

                var cboAct = new ComboBox
                {
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Font = new Font("Segoe UI", 10F),
                    BackColor = SafariThemeEngine.InputBg,
                    ForeColor = Color.White,
                    Location = new Point(20, 72),
                    Size = new Size(500, 28)
                };
                foreach (var a in allActs) cboAct.Items.Add(a.Name);

                var picPreview = new PictureBox
                {
                    Location = new Point(20, 114),
                    Size = new Size(180, 240),
                    BackColor = Color.FromArgb(12, 16, 26),
                    BorderStyle = BorderStyle.FixedSingle,
                    SizeMode = PictureBoxSizeMode.Zoom
                };

                var lblPresetCap = new Label
                {
                    Text = "CHOOSE BUILT-IN SCENIC THEME:",
                    Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                    ForeColor = SafariThemeEngine.TextSecondary,
                    Location = new Point(220, 114),
                    Size = new Size(290, 18)
                };

                var cboPreset = new ComboBox
                {
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Font = new Font("Segoe UI", 9.5F),
                    BackColor = SafariThemeEngine.InputBg,
                    ForeColor = Color.White,
                    Location = new Point(220, 136),
                    Size = new Size(300, 28)
                };
                cboPreset.Items.AddRange(SafariThemeEngine.BuiltInPresetNames);

                var btnUpload = new Button
                {
                    Text = "📁  Upload Custom Image from PC...",
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    Location = new Point(220, 180),
                    Size = new Size(300, 42)
                };
                SafariThemeEngine.AttachUiverseButtonGlow(btnUpload, SafariThemeEngine.SafariEmerald, SafariThemeEngine.HorizonCyan);

                var btnReset = new Button
                {
                    Text = "↺  Reset Panel to Default Artwork",
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    Location = new Point(220, 232),
                    Size = new Size(300, 38)
                };
                SafariThemeEngine.AttachUiverseButtonGlow(btnReset, SafariThemeEngine.RoyalViolet, SafariThemeEngine.HorizonCyan, true);

                var lblStatus = new Label
                {
                    Text = "Active Image: Auto",
                    Font = new Font("Segoe UI", 8.5F),
                    ForeColor = SafariThemeEngine.SafariEmerald,
                    Location = new Point(220, 280),
                    Size = new Size(300, 34)
                };

                var btnClose = new Button
                {
                    Text = "Done",
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    Location = new Point(400, 320),
                    Size = new Size(120, 36),
                    DialogResult = DialogResult.OK
                };
                SafariThemeEngine.AttachUiverseButtonGlow(btnClose, SafariThemeEngine.RoyalViolet, SafariThemeEngine.SunsetAmber);

                bool suppressModalPreset = false;

                Action refreshModal = () =>
                {
                    int idx = Math.Max(0, cboAct.SelectedIndex);
                    Activity cur = allActs[idx];
                    string st = SafariThemeEngine.GetActivityImageSetting(cur.ActivityID);
                    picPreview.Image = SafariThemeEngine.GetOrCreateTourImage(cur);

                    suppressModalPreset = true;
                    int pIdx = 0;
                    if (!string.IsNullOrEmpty(st))
                    {
                        for (int i = 0; i < cboPreset.Items.Count; i++)
                        {
                            if (string.Equals(cboPreset.Items[i].ToString(), st, StringComparison.OrdinalIgnoreCase))
                            {
                                pIdx = i;
                                break;
                            }
                        }
                    }
                    cboPreset.SelectedIndex = pIdx;
                    suppressModalPreset = false;

                    if (string.IsNullOrEmpty(st))
                        lblStatus.Text = "Active: Auto (Match Tour Name)";
                    else if (st.StartsWith("Preset ", StringComparison.OrdinalIgnoreCase))
                        lblStatus.Text = "Active: " + st;
                    else
                        lblStatus.Text = "Custom Upload: " + Path.GetFileName(st);
                };

                cboAct.SelectedIndexChanged += (s2, e2) => refreshModal();

                cboPreset.SelectedIndexChanged += (s2, e2) =>
                {
                    if (suppressModalPreset) return;
                    Activity cur = allActs[Math.Max(0, cboAct.SelectedIndex)];
                    string chosen = cboPreset.SelectedItem?.ToString();
                    SafariThemeEngine.SetActivityImageSetting(cur.ActivityID, chosen == "Auto (Match Tour Name)" ? null : chosen);
                    refreshModal();
                    if (_selectedActivity != null && _selectedActivity.ActivityID == cur.ActivityID)
                        LoadActivityImageEditorForSelected(_selectedActivity);
                };

                btnUpload.Click += (s2, e2) =>
                {
                    using (var ofd = new OpenFileDialog())
                    {
                        ofd.Title = "Select Custom Tour Panel Image";
                        ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                        if (ofd.ShowDialog(dlg) == DialogResult.OK)
                        {
                            try
                            {
                                Activity cur = allActs[Math.Max(0, cboAct.SelectedIndex)];
                                SafariThemeEngine.SaveUploadedActivityImage(cur.ActivityID, ofd.FileName);
                                refreshModal();
                                if (_selectedActivity != null && _selectedActivity.ActivityID == cur.ActivityID)
                                    LoadActivityImageEditorForSelected(_selectedActivity);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Failed to upload image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                };

                btnReset.Click += (s2, e2) =>
                {
                    Activity cur = allActs[Math.Max(0, cboAct.SelectedIndex)];
                    SafariThemeEngine.SetActivityImageSetting(cur.ActivityID, null);
                    refreshModal();
                    if (_selectedActivity != null && _selectedActivity.ActivityID == cur.ActivityID)
                        LoadActivityImageEditorForSelected(_selectedActivity);
                };

                int initIdx = allActs.FindIndex(a => a.ActivityID == initialAct.ActivityID);
                cboAct.SelectedIndex = initIdx >= 0 ? initIdx : 0;

                dlg.Controls.AddRange(new Control[]
                {
                    lblHeading, lblPickAct, cboAct, picPreview,
                    lblPresetCap, cboPreset, btnUpload, btnReset, lblStatus, btnClose
                });

                dlg.ShowDialog(this);
            }
        }


        // =================================================================
        //  NOTIFICATIONS & CONTACT US INBOX (Incorporated from Tourist/Notifications.cs)
        // =================================================================

        private void LoadNotificationData()
        {
            if (dgvMessages == null) return;
            Cursor = Cursors.WaitCursor;
            try
            {
                var messages = ContactService.GetAllMessages();

                int totalCount  = messages.Count;
                int unreadCount = messages.Count(m => !m.IsRead);
                int readCount   = messages.Count(m => m.IsRead);

                if (lblNotifTotal != null)  lblNotifTotal.Text  = totalCount.ToString();
                if (lblNotifUnread != null) lblNotifUnread.Text = unreadCount.ToString();
                if (lblNotifRead != null)   lblNotifRead.Text   = readCount.ToString();

                dgvMessages.DataSource = null;
                dgvMessages.DataSource = messages;

                if (dgvMessages.Columns["Id"] != null) dgvMessages.Columns["Id"].Visible = false;
                dgvMessages.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load notifications: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void dgvMessages_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvMessages.Rows[e.RowIndex].DataBoundItem == null) return;

            var selectedMessage = dgvMessages.Rows[e.RowIndex].DataBoundItem as ContactMessage;
            if (selectedMessage == null) return;

            if (!selectedMessage.IsRead)
            {
                ContactService.MarkAsRead(selectedMessage.Id);
                LoadNotificationData();
            }

            MessageBox.Show(
                $"From: {selectedMessage.Name} ({selectedMessage.Email})\n" +
                $"Subject: {selectedMessage.Subject}\n" +
                $"Sent: {selectedMessage.DateSent:dd MMM yyyy HH:mm}\n\n" +
                $"{selectedMessage.Message}",
                "Message Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
