// =============================================================================
// Forms/AdminDashboardForm.Designer.cs
// Standard Visual Studio Windows Forms Designer layout so the full GUI is
// displayable and editable in the Visual Studio Form Designer.
// =============================================================================

namespace PROJECTT.Forms
{
    partial class AdminDashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblAdminBrand = new System.Windows.Forms.Label();
            this.lblAdminPortalSub = new System.Windows.Forms.Label();
            this.lblSidebarUser = new System.Windows.Forms.Label();
            this.btnNavOverview = new System.Windows.Forms.Button();
            this.btnNavActivities = new System.Windows.Forms.Button();
            this.btnNavBookings = new System.Windows.Forms.Button();
            this.btnNavAttendance = new System.Windows.Forms.Button();
            this.btnNavReports = new System.Windows.Forms.Button();
            this.btnNavChangePass = new System.Windows.Forms.Button();
            this.btnNavAiSettings = new System.Windows.Forms.Button();
            this.btnNavNotifications = new System.Windows.Forms.Button();
            this.btnNavLogout = new System.Windows.Forms.Button();
            this.pnlNotifications = new System.Windows.Forms.Panel();
            this.lblNotifHeading = new System.Windows.Forms.Label();
            this.lblNotifSub = new System.Windows.Forms.Label();
            this.cardNotifTotal = new System.Windows.Forms.Panel();
            this.lblNotifTotal = new System.Windows.Forms.Label();
            this.lblNotifTotalCap = new System.Windows.Forms.Label();
            this.cardNotifUnread = new System.Windows.Forms.Panel();
            this.lblNotifUnread = new System.Windows.Forms.Label();
            this.lblNotifUnreadCap = new System.Windows.Forms.Label();
            this.cardNotifRead = new System.Windows.Forms.Panel();
            this.lblNotifRead = new System.Windows.Forms.Label();
            this.lblNotifReadCap = new System.Windows.Forms.Label();
            this.lblNotifGridHeading = new System.Windows.Forms.Label();
            this.dgvMessages = new System.Windows.Forms.DataGridView();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlOverview = new System.Windows.Forms.Panel();
            this.tileBookings = new System.Windows.Forms.Panel();
            this.lblTileBookings = new System.Windows.Forms.Label();
            this.lblTileBookingsCap = new System.Windows.Forms.Label();
            this.tileRevenue = new System.Windows.Forms.Panel();
            this.lblTileRevenue = new System.Windows.Forms.Label();
            this.lblTileRevenueCap = new System.Windows.Forms.Label();
            this.tileUpcoming = new System.Windows.Forms.Panel();
            this.lblTileUpcoming = new System.Windows.Forms.Label();
            this.lblTileUpcomingCap = new System.Windows.Forms.Label();
            this.tileSeatsLeft = new System.Windows.Forms.Panel();
            this.lblTileSeatsLeft = new System.Windows.Forms.Label();
            this.lblTileSeatsLeftCap = new System.Windows.Forms.Label();
            this.pnlShortcuts = new System.Windows.Forms.Panel();
            this.btnShortcutActivities = new System.Windows.Forms.Button();
            this.btnShortcutBookings = new System.Windows.Forms.Button();
            this.btnShortcutAttendance = new System.Windows.Forms.Button();
            this.btnShortcutReports = new System.Windows.Forms.Button();
            this.btnShortcutAiSettings = new System.Windows.Forms.Button();
            this.pnlActivities = new System.Windows.Forms.Panel();
            this.lblActivitiesHeading = new System.Windows.Forms.Label();
            this.dgvActivities = new System.Windows.Forms.DataGridView();
            this.pnlActivityForm = new System.Windows.Forms.Panel();
            this.lblActivityFormTitle = new System.Windows.Forms.Label();
            this.lblCatCap = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblActNameCap = new System.Windows.Forms.Label();
            this.txtActName = new System.Windows.Forms.TextBox();
            this.lblPriceCap = new System.Windows.Forms.Label();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.lblDescCap = new System.Windows.Forms.Label();
            this.txtActDescription = new System.Windows.Forms.TextBox();
            this.lblDateCap = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblTotalSeatsCap = new System.Windows.Forms.Label();
            this.nudTotalSeats = new System.Windows.Forms.NumericUpDown();
            this.lblAvailSeatsCap = new System.Windows.Forms.Label();
            this.nudAvailableSeats = new System.Windows.Forms.NumericUpDown();
            this.lblActError = new System.Windows.Forms.Label();
            this.btnActAdd = new System.Windows.Forms.Button();
            this.btnActSave = new System.Windows.Forms.Button();
            this.btnActDelete = new System.Windows.Forms.Button();
            this.btnActClear = new System.Windows.Forms.Button();
            this.lblActImageCap = new System.Windows.Forms.Label();
            this.picActImagePreview = new System.Windows.Forms.PictureBox();
            this.cboActImagePreset = new System.Windows.Forms.ComboBox();
            this.btnUploadActImage = new System.Windows.Forms.Button();
            this.btnResetActImage = new System.Windows.Forms.Button();
            this.lblActImageStatus = new System.Windows.Forms.Label();
            this.pnlBookings = new System.Windows.Forms.Panel();
            this.lblBookingsHeading = new System.Windows.Forms.Label();
            this.lblBookingSearchCap = new System.Windows.Forms.Label();
            this.txtBookingSearch = new System.Windows.Forms.TextBox();
            this.lblBookingFilterCap = new System.Windows.Forms.Label();
            this.cboBookingActivityFilter = new System.Windows.Forms.ComboBox();
            this.chkEnableDateFilter = new System.Windows.Forms.CheckBox();
            this.dtpBookingDateFilter = new System.Windows.Forms.DateTimePicker();
            this.btnBookingEditImage = new System.Windows.Forms.Button();
            this.dgvAllBookings = new System.Windows.Forms.DataGridView();
            this.pnlAttendance = new System.Windows.Forms.Panel();
            this.lblAttendanceHeading = new System.Windows.Forms.Label();
            this.dgvAttendanceBookings = new System.Windows.Forms.DataGridView();
            this.pnlAttendanceUpdate = new System.Windows.Forms.Panel();
            this.lblSelectedBookingInfo = new System.Windows.Forms.Label();
            this.lblMarkAttCap = new System.Windows.Forms.Label();
            this.cboAttendanceStatus = new System.Windows.Forms.ComboBox();
            this.btnSaveAttendance = new System.Windows.Forms.Button();
            this.pnlReports = new System.Windows.Forms.Panel();
            this.lblReportsHeading = new System.Windows.Forms.Label();
            this.pnlChartBar = new System.Windows.Forms.Panel();
            this.pnlChartFunnel = new System.Windows.Forms.Panel();
            this.pnlChartArea = new System.Windows.Forms.Panel();
            this.rtbReportOutput = new System.Windows.Forms.RichTextBox();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.btnExportReport = new System.Windows.Forms.Button();
            this.pnlChangePassword = new System.Windows.Forms.Panel();
            this.lblChangePassHeading = new System.Windows.Forms.Label();
            this.lblChangePassSub = new System.Windows.Forms.Label();
            this.lblCurrPassCap = new System.Windows.Forms.Label();
            this.txtCurrentPassword = new System.Windows.Forms.TextBox();
            this.lblNewPassCap = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblConfPassCap = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblPassError = new System.Windows.Forms.Label();
            this.btnSavePassword = new System.Windows.Forms.Button();
            this.pnlAiSettings = new System.Windows.Forms.Panel();
            this.lblAiSettingsHeading = new System.Windows.Forms.Label();
            this.lblAiSettingsSub = new System.Windows.Forms.Label();
            this.pnlAiStatusCard = new System.Windows.Forms.Panel();
            this.lblAiStatusCardTitle = new System.Windows.Forms.Label();
            this.lblAiCurrentStatus = new System.Windows.Forms.Label();
            this.lblAdminApiKeyCap = new System.Windows.Forms.Label();
            this.txtAdminApiKey = new System.Windows.Forms.TextBox();
            this.chkShowAdminApiKey = new System.Windows.Forms.CheckBox();
            this.lblAdminApiKeyMsg = new System.Windows.Forms.Label();
            this.btnSaveAdminApiKey = new System.Windows.Forms.Button();
            this.btnClearAdminApiKey = new System.Windows.Forms.Button();
            this.lblApiGuideHeading = new System.Windows.Forms.Label();
            this.dgvApiGuide = new System.Windows.Forms.DataGridView();
            this.pnlApiDetailBox = new System.Windows.Forms.Panel();
            this.lblSelectedApiGuideDetail = new System.Windows.Forms.Label();
            this.pnlSidebar.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlNotifications.SuspendLayout();
            this.cardNotifTotal.SuspendLayout();
            this.cardNotifUnread.SuspendLayout();
            this.cardNotifRead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessages)).BeginInit();
            this.pnlContent.SuspendLayout();
            this.pnlOverview.SuspendLayout();
            this.tileBookings.SuspendLayout();
            this.tileRevenue.SuspendLayout();
            this.tileUpcoming.SuspendLayout();
            this.tileSeatsLeft.SuspendLayout();
            this.pnlShortcuts.SuspendLayout();
            this.pnlActivities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivities)).BeginInit();
            this.pnlActivityForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalSeats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAvailableSeats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picActImagePreview)).BeginInit();
            this.pnlBookings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllBookings)).BeginInit();
            this.pnlAttendance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceBookings)).BeginInit();
            this.pnlAttendanceUpdate.SuspendLayout();
            this.pnlReports.SuspendLayout();
            this.pnlChangePassword.SuspendLayout();
            this.pnlAiSettings.SuspendLayout();
            this.pnlAiStatusCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApiGuide)).BeginInit();
            this.pnlApiDetailBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(16)))));
            this.pnlSidebar.Controls.Add(this.pnlTop);
            this.pnlSidebar.Controls.Add(this.btnNavOverview);
            this.pnlSidebar.Controls.Add(this.btnNavActivities);
            this.pnlSidebar.Controls.Add(this.btnNavBookings);
            this.pnlSidebar.Controls.Add(this.btnNavAttendance);
            this.pnlSidebar.Controls.Add(this.btnNavReports);
            this.pnlSidebar.Controls.Add(this.btnNavChangePass);
            this.pnlSidebar.Controls.Add(this.btnNavAiSettings);
            this.pnlSidebar.Controls.Add(this.btnNavNotifications);
            this.pnlSidebar.Controls.Add(this.btnNavLogout);
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(220, 750);
            this.pnlSidebar.TabIndex = 0;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(24)))));
            this.pnlTop.Controls.Add(this.lblAdminBrand);
            this.pnlTop.Controls.Add(this.lblAdminPortalSub);
            this.pnlTop.Controls.Add(this.lblSidebarUser);
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(220, 130);
            this.pnlTop.TabIndex = 0;
            // 
            // lblAdminBrand
            // 
            this.lblAdminBrand.Font = new System.Drawing.Font("Arial", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblAdminBrand.ForeColor = System.Drawing.Color.White;
            this.lblAdminBrand.Location = new System.Drawing.Point(10, 14);
            this.lblAdminBrand.Name = "lblAdminBrand";
            this.lblAdminBrand.Size = new System.Drawing.Size(200, 28);
            this.lblAdminBrand.TabIndex = 0;
            this.lblAdminBrand.Text = "Blue Horizons Tours";
            this.lblAdminBrand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAdminPortalSub
            // 
            this.lblAdminPortalSub.Font = new System.Drawing.Font("Arial", 8.5F);
            this.lblAdminPortalSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(240)))), ((int)(((byte)(235)))));
            this.lblAdminPortalSub.Location = new System.Drawing.Point(10, 46);
            this.lblAdminPortalSub.Name = "lblAdminPortalSub";
            this.lblAdminPortalSub.Size = new System.Drawing.Size(200, 18);
            this.lblAdminPortalSub.TabIndex = 1;
            this.lblAdminPortalSub.Text = "ADMINISTRATOR PORTAL";
            this.lblAdminPortalSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSidebarUser
            // 
            this.lblSidebarUser.AutoEllipsis = true;
            this.lblSidebarUser.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblSidebarUser.ForeColor = System.Drawing.Color.White;
            this.lblSidebarUser.Location = new System.Drawing.Point(10, 74);
            this.lblSidebarUser.Name = "lblSidebarUser";
            this.lblSidebarUser.Size = new System.Drawing.Size(200, 40);
            this.lblSidebarUser.TabIndex = 2;
            this.lblSidebarUser.Text = "Admin: Blue Horizons";
            this.lblSidebarUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNavOverview
            // 
            this.btnNavOverview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(44)))));
            this.btnNavOverview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavOverview.FlatAppearance.BorderSize = 0;
            this.btnNavOverview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavOverview.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNavOverview.ForeColor = System.Drawing.Color.White;
            this.btnNavOverview.Location = new System.Drawing.Point(0, 130);
            this.btnNavOverview.Name = "btnNavOverview";
            this.btnNavOverview.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnNavOverview.Size = new System.Drawing.Size(220, 48);
            this.btnNavOverview.TabIndex = 1;
            this.btnNavOverview.Text = "📊  Overview";
            this.btnNavOverview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavOverview.UseVisualStyleBackColor = false;
            this.btnNavOverview.Click += new System.EventHandler(this.btnNavOverview_Click);
            // 
            // btnNavActivities
            // 
            this.btnNavActivities.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(16)))));
            this.btnNavActivities.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavActivities.FlatAppearance.BorderSize = 0;
            this.btnNavActivities.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavActivities.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavActivities.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(201)))), ((int)(((byte)(255)))));
            this.btnNavActivities.Location = new System.Drawing.Point(0, 178);
            this.btnNavActivities.Name = "btnNavActivities";
            this.btnNavActivities.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnNavActivities.Size = new System.Drawing.Size(220, 48);
            this.btnNavActivities.TabIndex = 2;
            this.btnNavActivities.Text = "📅  Manage Activities";
            this.btnNavActivities.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavActivities.UseVisualStyleBackColor = false;
            this.btnNavActivities.Click += new System.EventHandler(this.btnNavActivities_Click);
            // 
            // btnNavBookings
            // 
            this.btnNavBookings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(16)))));
            this.btnNavBookings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavBookings.FlatAppearance.BorderSize = 0;
            this.btnNavBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavBookings.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavBookings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(201)))), ((int)(((byte)(255)))));
            this.btnNavBookings.Location = new System.Drawing.Point(0, 226);
            this.btnNavBookings.Name = "btnNavBookings";
            this.btnNavBookings.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnNavBookings.Size = new System.Drawing.Size(220, 48);
            this.btnNavBookings.TabIndex = 3;
            this.btnNavBookings.Text = "🎟  All Bookings";
            this.btnNavBookings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavBookings.UseVisualStyleBackColor = false;
            this.btnNavBookings.Click += new System.EventHandler(this.btnNavBookings_Click);
            // 
            // btnNavAttendance
            // 
            this.btnNavAttendance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(16)))));
            this.btnNavAttendance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavAttendance.FlatAppearance.BorderSize = 0;
            this.btnNavAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavAttendance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavAttendance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(201)))), ((int)(((byte)(255)))));
            this.btnNavAttendance.Location = new System.Drawing.Point(0, 274);
            this.btnNavAttendance.Name = "btnNavAttendance";
            this.btnNavAttendance.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnNavAttendance.Size = new System.Drawing.Size(220, 48);
            this.btnNavAttendance.TabIndex = 4;
            this.btnNavAttendance.Text = "📋  Attendance";
            this.btnNavAttendance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavAttendance.UseVisualStyleBackColor = false;
            this.btnNavAttendance.Click += new System.EventHandler(this.btnNavAttendance_Click);
            // 
            // btnNavReports
            // 
            this.btnNavReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(16)))));
            this.btnNavReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavReports.FlatAppearance.BorderSize = 0;
            this.btnNavReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavReports.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavReports.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(201)))), ((int)(((byte)(255)))));
            this.btnNavReports.Location = new System.Drawing.Point(0, 322);
            this.btnNavReports.Name = "btnNavReports";
            this.btnNavReports.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnNavReports.Size = new System.Drawing.Size(220, 48);
            this.btnNavReports.TabIndex = 5;
            this.btnNavReports.Text = "📈  Reports";
            this.btnNavReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavReports.UseVisualStyleBackColor = false;
            this.btnNavReports.Click += new System.EventHandler(this.btnNavReports_Click);
            // 
            // btnNavChangePass
            // 
            this.btnNavChangePass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(16)))));
            this.btnNavChangePass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavChangePass.FlatAppearance.BorderSize = 0;
            this.btnNavChangePass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavChangePass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavChangePass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(201)))), ((int)(((byte)(255)))));
            this.btnNavChangePass.Location = new System.Drawing.Point(0, 370);
            this.btnNavChangePass.Name = "btnNavChangePass";
            this.btnNavChangePass.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnNavChangePass.Size = new System.Drawing.Size(220, 48);
            this.btnNavChangePass.TabIndex = 6;
            this.btnNavChangePass.Text = "🔑  Change Password";
            this.btnNavChangePass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavChangePass.UseVisualStyleBackColor = false;
            this.btnNavChangePass.Click += new System.EventHandler(this.btnNavChangePass_Click);
            // 
            // btnNavAiSettings
            // 
            this.btnNavAiSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(16)))));
            this.btnNavAiSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavAiSettings.FlatAppearance.BorderSize = 0;
            this.btnNavAiSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavAiSettings.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavAiSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(201)))), ((int)(((byte)(255)))));
            this.btnNavAiSettings.Location = new System.Drawing.Point(0, 418);
            this.btnNavAiSettings.Name = "btnNavAiSettings";
            this.btnNavAiSettings.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnNavAiSettings.Size = new System.Drawing.Size(220, 48);
            this.btnNavAiSettings.TabIndex = 7;
            this.btnNavAiSettings.Text = "⚡  SafariScout AI Key";
            this.btnNavAiSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavAiSettings.UseVisualStyleBackColor = false;
            this.btnNavAiSettings.Click += new System.EventHandler(this.btnNavAiSettings_Click);
            // 
            // btnNavNotifications
            // 
            this.btnNavNotifications.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(16)))));
            this.btnNavNotifications.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavNotifications.FlatAppearance.BorderSize = 0;
            this.btnNavNotifications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavNotifications.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavNotifications.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(201)))), ((int)(((byte)(255)))));
            this.btnNavNotifications.Location = new System.Drawing.Point(0, 466);
            this.btnNavNotifications.Name = "btnNavNotifications";
            this.btnNavNotifications.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnNavNotifications.Size = new System.Drawing.Size(220, 48);
            this.btnNavNotifications.TabIndex = 8;
            this.btnNavNotifications.Text = "🔔  Notifications";
            this.btnNavNotifications.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavNotifications.UseVisualStyleBackColor = false;
            this.btnNavNotifications.Click += new System.EventHandler(this.btnNavNotifications_Click);
            // 
            // btnNavLogout
            // 
            this.btnNavLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(16)))));
            this.btnNavLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavLogout.FlatAppearance.BorderSize = 0;
            this.btnNavLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavLogout.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(190)))));
            this.btnNavLogout.Location = new System.Drawing.Point(0, 698);
            this.btnNavLogout.Name = "btnNavLogout";
            this.btnNavLogout.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnNavLogout.Size = new System.Drawing.Size(220, 52);
            this.btnNavLogout.TabIndex = 7;
            this.btnNavLogout.Text = "🟠  Log Out";
            this.btnNavLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavLogout.UseVisualStyleBackColor = false;
            this.btnNavLogout.Click += new System.EventHandler(this.btnNavLogout_Click);
            // 
            // pnlNotifications
            // 
            this.pnlNotifications.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(9)))));
            this.pnlNotifications.Controls.Add(this.lblNotifHeading);
            this.pnlNotifications.Controls.Add(this.lblNotifSub);
            this.pnlNotifications.Controls.Add(this.cardNotifTotal);
            this.pnlNotifications.Controls.Add(this.cardNotifUnread);
            this.pnlNotifications.Controls.Add(this.cardNotifRead);
            this.pnlNotifications.Controls.Add(this.lblNotifGridHeading);
            this.pnlNotifications.Controls.Add(this.dgvMessages);
            this.pnlNotifications.Location = new System.Drawing.Point(0, 0);
            this.pnlNotifications.Name = "pnlNotifications";
            this.pnlNotifications.Size = new System.Drawing.Size(980, 750);
            this.pnlNotifications.TabIndex = 8;
            this.pnlNotifications.Visible = false;
            // 
            // lblNotifHeading
            // 
            this.lblNotifHeading.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblNotifHeading.ForeColor = System.Drawing.Color.White;
            this.lblNotifHeading.Location = new System.Drawing.Point(24, 18);
            this.lblNotifHeading.Name = "lblNotifHeading";
            this.lblNotifHeading.Size = new System.Drawing.Size(700, 36);
            this.lblNotifHeading.TabIndex = 0;
            this.lblNotifHeading.Text = "Notifications & Contact Us Messages";
            // 
            // lblNotifSub
            // 
            this.lblNotifSub.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNotifSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(190)))));
            this.lblNotifSub.Location = new System.Drawing.Point(24, 56);
            this.lblNotifSub.Name = "lblNotifSub";
            this.lblNotifSub.Size = new System.Drawing.Size(820, 22);
            this.lblNotifSub.TabIndex = 1;
            this.lblNotifSub.Text = "Visitor inquiries submitted via Contact Us. Double-click any message row to read " +
    "full details and mark it as read.";
            // 
            // cardNotifTotal
            // 
            this.cardNotifTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
            this.cardNotifTotal.Controls.Add(this.lblNotifTotal);
            this.cardNotifTotal.Controls.Add(this.lblNotifTotalCap);
            this.cardNotifTotal.Location = new System.Drawing.Point(24, 92);
            this.cardNotifTotal.Name = "cardNotifTotal";
            this.cardNotifTotal.Size = new System.Drawing.Size(220, 88);
            this.cardNotifTotal.TabIndex = 2;
            // 
            // lblNotifTotal
            // 
            this.lblNotifTotal.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblNotifTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.lblNotifTotal.Location = new System.Drawing.Point(10, 8);
            this.lblNotifTotal.Name = "lblNotifTotal";
            this.lblNotifTotal.Size = new System.Drawing.Size(200, 44);
            this.lblNotifTotal.TabIndex = 0;
            this.lblNotifTotal.Text = "0";
            this.lblNotifTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNotifTotalCap
            // 
            this.lblNotifTotalCap.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNotifTotalCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(185)))));
            this.lblNotifTotalCap.Location = new System.Drawing.Point(10, 54);
            this.lblNotifTotalCap.Name = "lblNotifTotalCap";
            this.lblNotifTotalCap.Size = new System.Drawing.Size(200, 24);
            this.lblNotifTotalCap.TabIndex = 1;
            this.lblNotifTotalCap.Text = "Total Messages";
            this.lblNotifTotalCap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardNotifUnread
            // 
            this.cardNotifUnread.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
            this.cardNotifUnread.Controls.Add(this.lblNotifUnread);
            this.cardNotifUnread.Controls.Add(this.lblNotifUnreadCap);
            this.cardNotifUnread.Location = new System.Drawing.Point(264, 92);
            this.cardNotifUnread.Name = "cardNotifUnread";
            this.cardNotifUnread.Size = new System.Drawing.Size(220, 88);
            this.cardNotifUnread.TabIndex = 3;
            // 
            // lblNotifUnread
            // 
            this.lblNotifUnread.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblNotifUnread.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.lblNotifUnread.Location = new System.Drawing.Point(10, 8);
            this.lblNotifUnread.Name = "lblNotifUnread";
            this.lblNotifUnread.Size = new System.Drawing.Size(200, 44);
            this.lblNotifUnread.TabIndex = 0;
            this.lblNotifUnread.Text = "0";
            this.lblNotifUnread.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNotifUnreadCap
            // 
            this.lblNotifUnreadCap.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNotifUnreadCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(185)))));
            this.lblNotifUnreadCap.Location = new System.Drawing.Point(10, 54);
            this.lblNotifUnreadCap.Name = "lblNotifUnreadCap";
            this.lblNotifUnreadCap.Size = new System.Drawing.Size(200, 24);
            this.lblNotifUnreadCap.TabIndex = 1;
            this.lblNotifUnreadCap.Text = "Unread";
            this.lblNotifUnreadCap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardNotifRead
            // 
            this.cardNotifRead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
            this.cardNotifRead.Controls.Add(this.lblNotifRead);
            this.cardNotifRead.Controls.Add(this.lblNotifReadCap);
            this.cardNotifRead.Location = new System.Drawing.Point(504, 92);
            this.cardNotifRead.Name = "cardNotifRead";
            this.cardNotifRead.Size = new System.Drawing.Size(220, 88);
            this.cardNotifRead.TabIndex = 4;
            // 
            // lblNotifRead
            // 
            this.lblNotifRead.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblNotifRead.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblNotifRead.Location = new System.Drawing.Point(10, 8);
            this.lblNotifRead.Name = "lblNotifRead";
            this.lblNotifRead.Size = new System.Drawing.Size(200, 44);
            this.lblNotifRead.TabIndex = 0;
            this.lblNotifRead.Text = "0";
            this.lblNotifRead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNotifReadCap
            // 
            this.lblNotifReadCap.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNotifReadCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(185)))));
            this.lblNotifReadCap.Location = new System.Drawing.Point(10, 54);
            this.lblNotifReadCap.Name = "lblNotifReadCap";
            this.lblNotifReadCap.Size = new System.Drawing.Size(200, 24);
            this.lblNotifReadCap.TabIndex = 1;
            this.lblNotifReadCap.Text = "Read";
            this.lblNotifReadCap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNotifGridHeading
            // 
            this.lblNotifGridHeading.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblNotifGridHeading.ForeColor = System.Drawing.Color.White;
            this.lblNotifGridHeading.Location = new System.Drawing.Point(24, 196);
            this.lblNotifGridHeading.Name = "lblNotifGridHeading";
            this.lblNotifGridHeading.Size = new System.Drawing.Size(340, 24);
            this.lblNotifGridHeading.TabIndex = 5;
            this.lblNotifGridHeading.Text = "Recent Messages";
            // 
            // dgvMessages
            // 
            this.dgvMessages.AllowUserToAddRows = false;
            this.dgvMessages.AllowUserToDeleteRows = false;
            this.dgvMessages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMessages.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(20)))));
            this.dgvMessages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMessages.ColumnHeadersHeight = 29;
            this.dgvMessages.Location = new System.Drawing.Point(24, 228);
            this.dgvMessages.Name = "dgvMessages";
            this.dgvMessages.ReadOnly = true;
            this.dgvMessages.RowHeadersVisible = false;
            this.dgvMessages.RowHeadersWidth = 51;
            this.dgvMessages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMessages.Size = new System.Drawing.Size(930, 480);
            this.dgvMessages.TabIndex = 6;
            this.dgvMessages.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMessages_CellDoubleClick);
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(9)))));
            this.pnlContent.Controls.Add(this.pnlOverview);
            this.pnlContent.Controls.Add(this.pnlActivities);
            this.pnlContent.Controls.Add(this.pnlBookings);
            this.pnlContent.Controls.Add(this.pnlAttendance);
            this.pnlContent.Controls.Add(this.pnlReports);
            this.pnlContent.Controls.Add(this.pnlChangePassword);
            this.pnlContent.Controls.Add(this.pnlAiSettings);
            this.pnlContent.Controls.Add(this.pnlNotifications);
            this.pnlContent.Location = new System.Drawing.Point(220, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(980, 750);
            this.pnlContent.TabIndex = 1;
            // 
            // pnlOverview
            // 
            this.pnlOverview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(9)))));
            this.pnlOverview.Controls.Add(this.tileBookings);
            this.pnlOverview.Controls.Add(this.tileRevenue);
            this.pnlOverview.Controls.Add(this.tileUpcoming);
            this.pnlOverview.Controls.Add(this.tileSeatsLeft);
            this.pnlOverview.Controls.Add(this.pnlShortcuts);
            this.pnlOverview.Location = new System.Drawing.Point(0, 0);
            this.pnlOverview.Name = "pnlOverview";
            this.pnlOverview.Size = new System.Drawing.Size(980, 750);
            this.pnlOverview.TabIndex = 0;
            // 
            // tileBookings
            // 
            this.tileBookings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
            this.tileBookings.Controls.Add(this.lblTileBookings);
            this.tileBookings.Controls.Add(this.lblTileBookingsCap);
            this.tileBookings.Location = new System.Drawing.Point(24, 646);
            this.tileBookings.Name = "tileBookings";
            this.tileBookings.Size = new System.Drawing.Size(221, 86);
            this.tileBookings.TabIndex = 2;
            // 
            // lblTileBookings
            // 
            this.lblTileBookings.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTileBookings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.lblTileBookings.Location = new System.Drawing.Point(8, 8);
            this.lblTileBookings.Name = "lblTileBookings";
            this.lblTileBookings.Size = new System.Drawing.Size(205, 42);
            this.lblTileBookings.TabIndex = 0;
            this.lblTileBookings.Text = "3";
            this.lblTileBookings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTileBookingsCap
            // 
            this.lblTileBookingsCap.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTileBookingsCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(185)))));
            this.lblTileBookingsCap.Location = new System.Drawing.Point(8, 52);
            this.lblTileBookingsCap.Name = "lblTileBookingsCap";
            this.lblTileBookingsCap.Size = new System.Drawing.Size(205, 24);
            this.lblTileBookingsCap.TabIndex = 1;
            this.lblTileBookingsCap.Text = "Total Bookings";
            this.lblTileBookingsCap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tileRevenue
            // 
            this.tileRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
            this.tileRevenue.Controls.Add(this.lblTileRevenue);
            this.tileRevenue.Controls.Add(this.lblTileRevenueCap);
            this.tileRevenue.Location = new System.Drawing.Point(261, 646);
            this.tileRevenue.Name = "tileRevenue";
            this.tileRevenue.Size = new System.Drawing.Size(221, 86);
            this.tileRevenue.TabIndex = 3;
            // 
            // lblTileRevenue
            // 
            this.lblTileRevenue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTileRevenue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblTileRevenue.Location = new System.Drawing.Point(8, 8);
            this.lblTileRevenue.Name = "lblTileRevenue";
            this.lblTileRevenue.Size = new System.Drawing.Size(205, 42);
            this.lblTileRevenue.TabIndex = 0;
            this.lblTileRevenue.Text = "R27,500.00";
            this.lblTileRevenue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTileRevenueCap
            // 
            this.lblTileRevenueCap.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTileRevenueCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(185)))));
            this.lblTileRevenueCap.Location = new System.Drawing.Point(8, 52);
            this.lblTileRevenueCap.Name = "lblTileRevenueCap";
            this.lblTileRevenueCap.Size = new System.Drawing.Size(205, 24);
            this.lblTileRevenueCap.TabIndex = 1;
            this.lblTileRevenueCap.Text = "Total Revenue";
            this.lblTileRevenueCap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tileUpcoming
            // 
            this.tileUpcoming.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
            this.tileUpcoming.Controls.Add(this.lblTileUpcoming);
            this.tileUpcoming.Controls.Add(this.lblTileUpcomingCap);
            this.tileUpcoming.Location = new System.Drawing.Point(498, 646);
            this.tileUpcoming.Name = "tileUpcoming";
            this.tileUpcoming.Size = new System.Drawing.Size(221, 86);
            this.tileUpcoming.TabIndex = 4;
            // 
            // lblTileUpcoming
            // 
            this.lblTileUpcoming.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTileUpcoming.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.lblTileUpcoming.Location = new System.Drawing.Point(8, 8);
            this.lblTileUpcoming.Name = "lblTileUpcoming";
            this.lblTileUpcoming.Size = new System.Drawing.Size(205, 42);
            this.lblTileUpcoming.TabIndex = 0;
            this.lblTileUpcoming.Text = "12";
            this.lblTileUpcoming.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTileUpcomingCap
            // 
            this.lblTileUpcomingCap.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTileUpcomingCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(185)))));
            this.lblTileUpcomingCap.Location = new System.Drawing.Point(8, 52);
            this.lblTileUpcomingCap.Name = "lblTileUpcomingCap";
            this.lblTileUpcomingCap.Size = new System.Drawing.Size(205, 24);
            this.lblTileUpcomingCap.TabIndex = 1;
            this.lblTileUpcomingCap.Text = "Upcoming Events";
            this.lblTileUpcomingCap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tileSeatsLeft
            // 
            this.tileSeatsLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
            this.tileSeatsLeft.Controls.Add(this.lblTileSeatsLeft);
            this.tileSeatsLeft.Controls.Add(this.lblTileSeatsLeftCap);
            this.tileSeatsLeft.Location = new System.Drawing.Point(735, 646);
            this.tileSeatsLeft.Name = "tileSeatsLeft";
            this.tileSeatsLeft.Size = new System.Drawing.Size(221, 86);
            this.tileSeatsLeft.TabIndex = 5;
            // 
            // lblTileSeatsLeft
            // 
            this.lblTileSeatsLeft.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTileSeatsLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.lblTileSeatsLeft.Location = new System.Drawing.Point(8, 8);
            this.lblTileSeatsLeft.Name = "lblTileSeatsLeft";
            this.lblTileSeatsLeft.Size = new System.Drawing.Size(205, 42);
            this.lblTileSeatsLeft.TabIndex = 0;
            this.lblTileSeatsLeft.Text = "174";
            this.lblTileSeatsLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTileSeatsLeftCap
            // 
            this.lblTileSeatsLeftCap.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTileSeatsLeftCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(185)))));
            this.lblTileSeatsLeftCap.Location = new System.Drawing.Point(8, 52);
            this.lblTileSeatsLeftCap.Name = "lblTileSeatsLeftCap";
            this.lblTileSeatsLeftCap.Size = new System.Drawing.Size(205, 24);
            this.lblTileSeatsLeftCap.TabIndex = 1;
            this.lblTileSeatsLeftCap.Text = "Seats Remaining";
            this.lblTileSeatsLeftCap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlShortcuts
            // 
            this.pnlShortcuts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(7)))), ((int)(((byte)(12)))));
            this.pnlShortcuts.Controls.Add(this.btnShortcutActivities);
            this.pnlShortcuts.Controls.Add(this.btnShortcutBookings);
            this.pnlShortcuts.Controls.Add(this.btnShortcutAttendance);
            this.pnlShortcuts.Controls.Add(this.btnShortcutReports);
            this.pnlShortcuts.Controls.Add(this.btnShortcutAiSettings);
            this.pnlShortcuts.Location = new System.Drawing.Point(0, 0);
            this.pnlShortcuts.Name = "pnlShortcuts";
            this.pnlShortcuts.Size = new System.Drawing.Size(980, 628);
            this.pnlShortcuts.TabIndex = 6;
            this.pnlShortcuts.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlBeamHub_Paint);
            // 
            // btnShortcutActivities
            // 
            this.btnShortcutActivities.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(28)))));
            this.btnShortcutActivities.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShortcutActivities.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.btnShortcutActivities.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShortcutActivities.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.btnShortcutActivities.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(210)))));
            this.btnShortcutActivities.Location = new System.Drawing.Point(112, 142);
            this.btnShortcutActivities.Name = "btnShortcutActivities";
            this.btnShortcutActivities.Size = new System.Drawing.Size(104, 76);
            this.btnShortcutActivities.TabIndex = 1;
            this.btnShortcutActivities.Text = "⛰\r\nACTIVITIES";
            this.btnShortcutActivities.UseVisualStyleBackColor = false;
            this.btnShortcutActivities.Visible = false;
            this.btnShortcutActivities.Click += new System.EventHandler(this.btnNavActivities_Click);
            // 
            // btnShortcutBookings
            // 
            this.btnShortcutBookings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(28)))));
            this.btnShortcutBookings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShortcutBookings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.btnShortcutBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShortcutBookings.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.btnShortcutBookings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(210)))));
            this.btnShortcutBookings.Location = new System.Drawing.Point(112, 292);
            this.btnShortcutBookings.Name = "btnShortcutBookings";
            this.btnShortcutBookings.Size = new System.Drawing.Size(104, 76);
            this.btnShortcutBookings.TabIndex = 2;
            this.btnShortcutBookings.Text = "📋\r\nALL BOOKINGS";
            this.btnShortcutBookings.UseVisualStyleBackColor = false;
            this.btnShortcutBookings.Visible = false;
            this.btnShortcutBookings.Click += new System.EventHandler(this.btnNavBookings_Click);
            // 
            // btnShortcutAttendance
            // 
            this.btnShortcutAttendance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(28)))));
            this.btnShortcutAttendance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShortcutAttendance.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.btnShortcutAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShortcutAttendance.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.btnShortcutAttendance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(210)))));
            this.btnShortcutAttendance.Location = new System.Drawing.Point(112, 442);
            this.btnShortcutAttendance.Name = "btnShortcutAttendance";
            this.btnShortcutAttendance.Size = new System.Drawing.Size(104, 76);
            this.btnShortcutAttendance.TabIndex = 3;
            this.btnShortcutAttendance.Text = "🛡\r\nATTENDANCE";
            this.btnShortcutAttendance.UseVisualStyleBackColor = false;
            this.btnShortcutAttendance.Visible = false;
            this.btnShortcutAttendance.Click += new System.EventHandler(this.btnNavAttendance_Click);
            // 
            // btnShortcutReports
            // 
            this.btnShortcutReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(28)))));
            this.btnShortcutReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShortcutReports.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.btnShortcutReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShortcutReports.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.btnShortcutReports.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(210)))));
            this.btnShortcutReports.Location = new System.Drawing.Point(764, 142);
            this.btnShortcutReports.Name = "btnShortcutReports";
            this.btnShortcutReports.Size = new System.Drawing.Size(104, 76);
            this.btnShortcutReports.TabIndex = 4;
            this.btnShortcutReports.Text = "📊\r\nREPORTS";
            this.btnShortcutReports.UseVisualStyleBackColor = false;
            this.btnShortcutReports.Visible = false;
            this.btnShortcutReports.Click += new System.EventHandler(this.btnNavReports_Click);
            // 
            // btnShortcutAiSettings
            // 
            this.btnShortcutAiSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(28)))));
            this.btnShortcutAiSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShortcutAiSettings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.btnShortcutAiSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShortcutAiSettings.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.btnShortcutAiSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(210)))));
            this.btnShortcutAiSettings.Location = new System.Drawing.Point(764, 292);
            this.btnShortcutAiSettings.Name = "btnShortcutAiSettings";
            this.btnShortcutAiSettings.Size = new System.Drawing.Size(104, 76);
            this.btnShortcutAiSettings.TabIndex = 5;
            this.btnShortcutAiSettings.Text = "🤖\r\nSAFARISCOUT AI";
            this.btnShortcutAiSettings.UseVisualStyleBackColor = false;
            this.btnShortcutAiSettings.Visible = false;
            this.btnShortcutAiSettings.Click += new System.EventHandler(this.btnNavAiSettings_Click);
            // 
            // pnlActivities
            // 
            this.pnlActivities.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(9)))));
            this.pnlActivities.Controls.Add(this.lblActivitiesHeading);
            this.pnlActivities.Controls.Add(this.dgvActivities);
            this.pnlActivities.Controls.Add(this.pnlActivityForm);
            this.pnlActivities.Location = new System.Drawing.Point(0, 0);
            this.pnlActivities.Name = "pnlActivities";
            this.pnlActivities.Size = new System.Drawing.Size(980, 750);
            this.pnlActivities.TabIndex = 1;
            this.pnlActivities.Visible = false;
            // 
            // lblActivitiesHeading
            // 
            this.lblActivitiesHeading.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblActivitiesHeading.ForeColor = System.Drawing.Color.White;
            this.lblActivitiesHeading.Location = new System.Drawing.Point(20, 16);
            this.lblActivitiesHeading.Name = "lblActivitiesHeading";
            this.lblActivitiesHeading.Size = new System.Drawing.Size(500, 36);
            this.lblActivitiesHeading.TabIndex = 0;
            this.lblActivitiesHeading.Text = "Manage Activities && Events";
            // 
            // dgvActivities
            // 
            this.dgvActivities.AllowUserToAddRows = false;
            this.dgvActivities.AllowUserToDeleteRows = false;
            this.dgvActivities.AllowUserToResizeRows = false;
            this.dgvActivities.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvActivities.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(12)))), ((int)(((byte)(20)))));
            this.dgvActivities.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvActivities.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvActivities.ColumnHeadersHeight = 34;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(16)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(92)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvActivities.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvActivities.EnableHeadersVisualStyles = false;
            this.dgvActivities.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(32)))), ((int)(((byte)(48)))));
            this.dgvActivities.Location = new System.Drawing.Point(20, 56);
            this.dgvActivities.MultiSelect = false;
            this.dgvActivities.Name = "dgvActivities";
            this.dgvActivities.ReadOnly = true;
            this.dgvActivities.RowHeadersVisible = false;
            this.dgvActivities.RowHeadersWidth = 51;
            this.dgvActivities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActivities.Size = new System.Drawing.Size(940, 320);
            this.dgvActivities.TabIndex = 1;
            this.dgvActivities.SelectionChanged += new System.EventHandler(this.dgvActivities_SelectionChanged);
            // 
            // pnlActivityForm
            // 
            this.pnlActivityForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
            this.pnlActivityForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlActivityForm.Controls.Add(this.lblActivityFormTitle);
            this.pnlActivityForm.Controls.Add(this.lblCatCap);
            this.pnlActivityForm.Controls.Add(this.cboCategory);
            this.pnlActivityForm.Controls.Add(this.lblActNameCap);
            this.pnlActivityForm.Controls.Add(this.txtActName);
            this.pnlActivityForm.Controls.Add(this.lblPriceCap);
            this.pnlActivityForm.Controls.Add(this.nudPrice);
            this.pnlActivityForm.Controls.Add(this.lblDescCap);
            this.pnlActivityForm.Controls.Add(this.txtActDescription);
            this.pnlActivityForm.Controls.Add(this.lblDateCap);
            this.pnlActivityForm.Controls.Add(this.dtpDate);
            this.pnlActivityForm.Controls.Add(this.lblTotalSeatsCap);
            this.pnlActivityForm.Controls.Add(this.nudTotalSeats);
            this.pnlActivityForm.Controls.Add(this.lblAvailSeatsCap);
            this.pnlActivityForm.Controls.Add(this.nudAvailableSeats);
            this.pnlActivityForm.Controls.Add(this.lblActError);
            this.pnlActivityForm.Controls.Add(this.btnActAdd);
            this.pnlActivityForm.Controls.Add(this.btnActSave);
            this.pnlActivityForm.Controls.Add(this.btnActDelete);
            this.pnlActivityForm.Controls.Add(this.btnActClear);
            this.pnlActivityForm.Controls.Add(this.lblActImageCap);
            this.pnlActivityForm.Controls.Add(this.picActImagePreview);
            this.pnlActivityForm.Controls.Add(this.cboActImagePreset);
            this.pnlActivityForm.Controls.Add(this.btnUploadActImage);
            this.pnlActivityForm.Controls.Add(this.btnResetActImage);
            this.pnlActivityForm.Controls.Add(this.lblActImageStatus);
            this.pnlActivityForm.Location = new System.Drawing.Point(20, 386);
            this.pnlActivityForm.Name = "pnlActivityForm";
            this.pnlActivityForm.Size = new System.Drawing.Size(940, 344);
            this.pnlActivityForm.TabIndex = 2;
            // 
            // lblActivityFormTitle
            // 
            this.lblActivityFormTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblActivityFormTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(201)))), ((int)(((byte)(255)))));
            this.lblActivityFormTitle.Location = new System.Drawing.Point(16, 12);
            this.lblActivityFormTitle.Name = "lblActivityFormTitle";
            this.lblActivityFormTitle.Size = new System.Drawing.Size(600, 20);
            this.lblActivityFormTitle.TabIndex = 0;
            this.lblActivityFormTitle.Text = "Activity Form (Add new activity or select row to edit)";
            // 
            // lblCatCap
            // 
            this.lblCatCap.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCatCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(190)))));
            this.lblCatCap.Location = new System.Drawing.Point(16, 38);
            this.lblCatCap.Name = "lblCatCap";
            this.lblCatCap.Size = new System.Drawing.Size(120, 16);
            this.lblCatCap.TabIndex = 1;
            this.lblCatCap.Text = "CATEGORY";
            // 
            // cboCategory
            // 
            this.cboCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCategory.ForeColor = System.Drawing.Color.White;
            this.cboCategory.Location = new System.Drawing.Point(16, 56);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(160, 31);
            this.cboCategory.TabIndex = 2;
            // 
            // lblActNameCap
            // 
            this.lblActNameCap.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblActNameCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(190)))));
            this.lblActNameCap.Location = new System.Drawing.Point(192, 38);
            this.lblActNameCap.Name = "lblActNameCap";
            this.lblActNameCap.Size = new System.Drawing.Size(200, 16);
            this.lblActNameCap.TabIndex = 3;
            this.lblActNameCap.Text = "ACTIVITY NAME";
            // 
            // txtActName
            // 
            this.txtActName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.txtActName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtActName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtActName.ForeColor = System.Drawing.Color.White;
            this.txtActName.Location = new System.Drawing.Point(192, 56);
            this.txtActName.Name = "txtActName";
            this.txtActName.Size = new System.Drawing.Size(420, 30);
            this.txtActName.TabIndex = 4;
            // 
            // lblPriceCap
            // 
            this.lblPriceCap.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPriceCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(190)))));
            this.lblPriceCap.Location = new System.Drawing.Point(628, 38);
            this.lblPriceCap.Name = "lblPriceCap";
            this.lblPriceCap.Size = new System.Drawing.Size(140, 16);
            this.lblPriceCap.TabIndex = 5;
            this.lblPriceCap.Text = "PRICE (ZAR > 0)";
            // 
            // nudPrice
            // 
            this.nudPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.nudPrice.DecimalPlaces = 2;
            this.nudPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudPrice.ForeColor = System.Drawing.Color.White;
            this.nudPrice.Location = new System.Drawing.Point(628, 56);
            this.nudPrice.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(140, 30);
            this.nudPrice.TabIndex = 6;
            this.nudPrice.Value = new decimal(new int[] {
            350,
            0,
            0,
            0});
            // 
            // lblDescCap
            // 
            this.lblDescCap.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDescCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(190)))));
            this.lblDescCap.Location = new System.Drawing.Point(16, 92);
            this.lblDescCap.Name = "lblDescCap";
            this.lblDescCap.Size = new System.Drawing.Size(200, 16);
            this.lblDescCap.TabIndex = 7;
            this.lblDescCap.Text = "DESCRIPTION";
            // 
            // txtActDescription
            // 
            this.txtActDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.txtActDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtActDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtActDescription.ForeColor = System.Drawing.Color.White;
            this.txtActDescription.Location = new System.Drawing.Point(16, 110);
            this.txtActDescription.Name = "txtActDescription";
            this.txtActDescription.Size = new System.Drawing.Size(752, 30);
            this.txtActDescription.TabIndex = 8;
            // 
            // lblDateCap
            // 
            this.lblDateCap.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDateCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(190)))));
            this.lblDateCap.Location = new System.Drawing.Point(16, 146);
            this.lblDateCap.Name = "lblDateCap";
            this.lblDateCap.Size = new System.Drawing.Size(120, 16);
            this.lblDateCap.TabIndex = 9;
            this.lblDateCap.Text = "DATE";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(16, 164);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 30);
            this.dtpDate.TabIndex = 10;
            // 
            // lblTotalSeatsCap
            // 
            this.lblTotalSeatsCap.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalSeatsCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(190)))));
            this.lblTotalSeatsCap.Location = new System.Drawing.Point(232, 146);
            this.lblTotalSeatsCap.Name = "lblTotalSeatsCap";
            this.lblTotalSeatsCap.Size = new System.Drawing.Size(160, 16);
            this.lblTotalSeatsCap.TabIndex = 11;
            this.lblTotalSeatsCap.Text = "TOTAL CAPACITY";
            // 
            // nudTotalSeats
            // 
            this.nudTotalSeats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.nudTotalSeats.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudTotalSeats.ForeColor = System.Drawing.Color.White;
            this.nudTotalSeats.Location = new System.Drawing.Point(232, 164);
            this.nudTotalSeats.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudTotalSeats.Name = "nudTotalSeats";
            this.nudTotalSeats.Size = new System.Drawing.Size(150, 30);
            this.nudTotalSeats.TabIndex = 12;
            this.nudTotalSeats.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // lblAvailSeatsCap
            // 
            this.lblAvailSeatsCap.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblAvailSeatsCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(190)))));
            this.lblAvailSeatsCap.Location = new System.Drawing.Point(400, 146);
            this.lblAvailSeatsCap.Name = "lblAvailSeatsCap";
            this.lblAvailSeatsCap.Size = new System.Drawing.Size(160, 16);
            this.lblAvailSeatsCap.TabIndex = 13;
            this.lblAvailSeatsCap.Text = "AVAILABLE SEATS";
            // 
            // nudAvailableSeats
            // 
            this.nudAvailableSeats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.nudAvailableSeats.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudAvailableSeats.ForeColor = System.Drawing.Color.White;
            this.nudAvailableSeats.Location = new System.Drawing.Point(400, 164);
            this.nudAvailableSeats.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudAvailableSeats.Name = "nudAvailableSeats";
            this.nudAvailableSeats.Size = new System.Drawing.Size(150, 30);
            this.nudAvailableSeats.TabIndex = 14;
            this.nudAvailableSeats.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // lblActError
            // 
            this.lblActError.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblActError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.lblActError.Location = new System.Drawing.Point(16, 202);
            this.lblActError.Name = "lblActError";
            this.lblActError.Size = new System.Drawing.Size(750, 20);
            this.lblActError.TabIndex = 15;
            this.lblActError.Visible = false;
            // 
            // btnActAdd
            // 
            this.btnActAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(92)))), ((int)(((byte)(255)))));
            this.btnActAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActAdd.FlatAppearance.BorderSize = 0;
            this.btnActAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnActAdd.ForeColor = System.Drawing.Color.White;
            this.btnActAdd.Location = new System.Drawing.Point(16, 234);
            this.btnActAdd.Name = "btnActAdd";
            this.btnActAdd.Size = new System.Drawing.Size(160, 42);
            this.btnActAdd.TabIndex = 16;
            this.btnActAdd.Text = "➕  Add Activity";
            this.btnActAdd.UseVisualStyleBackColor = false;
            this.btnActAdd.Click += new System.EventHandler(this.btnActAdd_Click);
            // 
            // btnActSave
            // 
            this.btnActSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnActSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActSave.FlatAppearance.BorderSize = 0;
            this.btnActSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnActSave.ForeColor = System.Drawing.Color.White;
            this.btnActSave.Location = new System.Drawing.Point(190, 234);
            this.btnActSave.Name = "btnActSave";
            this.btnActSave.Size = new System.Drawing.Size(160, 42);
            this.btnActSave.TabIndex = 17;
            this.btnActSave.Text = "💾  Save Edits";
            this.btnActSave.UseVisualStyleBackColor = false;
            this.btnActSave.Click += new System.EventHandler(this.btnActSave_Click);
            // 
            // btnActDelete
            // 
            this.btnActDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnActDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActDelete.FlatAppearance.BorderSize = 0;
            this.btnActDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnActDelete.ForeColor = System.Drawing.Color.White;
            this.btnActDelete.Location = new System.Drawing.Point(364, 234);
            this.btnActDelete.Name = "btnActDelete";
            this.btnActDelete.Size = new System.Drawing.Size(160, 42);
            this.btnActDelete.TabIndex = 18;
            this.btnActDelete.Text = "🗑  Delete Activity";
            this.btnActDelete.UseVisualStyleBackColor = false;
            this.btnActDelete.Click += new System.EventHandler(this.btnActDelete_Click);
            // 
            // btnActClear
            // 
            this.btnActClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(44)))));
            this.btnActClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActClear.FlatAppearance.BorderSize = 0;
            this.btnActClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActClear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnActClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(201)))), ((int)(((byte)(255)))));
            this.btnActClear.Location = new System.Drawing.Point(538, 234);
            this.btnActClear.Name = "btnActClear";
            this.btnActClear.Size = new System.Drawing.Size(130, 42);
            this.btnActClear.TabIndex = 19;
            this.btnActClear.Text = "↺ Clear Form";
            this.btnActClear.UseVisualStyleBackColor = false;
            this.btnActClear.Click += new System.EventHandler(this.btnActClear_Click);
            // 
            // lblActImageCap
            // 
            this.lblActImageCap.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblActImageCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(201)))), ((int)(((byte)(255)))));
            this.lblActImageCap.Location = new System.Drawing.Point(684, 12);
            this.lblActImageCap.Name = "lblActImageCap";
            this.lblActImageCap.Size = new System.Drawing.Size(244, 18);
            this.lblActImageCap.TabIndex = 20;
            this.lblActImageCap.Text = "GALLERY PANEL IMAGE (EDIT / UPLOAD)";
            // 
            // picActImagePreview
            // 
            this.picActImagePreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(12)))), ((int)(((byte)(20)))));
            this.picActImagePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picActImagePreview.Location = new System.Drawing.Point(684, 34);
            this.picActImagePreview.Name = "picActImagePreview";
            this.picActImagePreview.Size = new System.Drawing.Size(102, 136);
            this.picActImagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picActImagePreview.TabIndex = 21;
            this.picActImagePreview.TabStop = false;
            // 
            // cboActImagePreset
            // 
            this.cboActImagePreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboActImagePreset.Font = new System.Drawing.Font("Arial", 8.5F);
            this.cboActImagePreset.Location = new System.Drawing.Point(794, 34);
            this.cboActImagePreset.Name = "cboActImagePreset";
            this.cboActImagePreset.Size = new System.Drawing.Size(134, 24);
            this.cboActImagePreset.TabIndex = 22;
            this.cboActImagePreset.SelectedIndexChanged += new System.EventHandler(this.cboActImagePreset_SelectedIndexChanged);
            // 
            // btnUploadActImage
            // 
            this.btnUploadActImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnUploadActImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUploadActImage.FlatAppearance.BorderSize = 0;
            this.btnUploadActImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadActImage.Font = new System.Drawing.Font("Arial", 8.75F, System.Drawing.FontStyle.Bold);
            this.btnUploadActImage.ForeColor = System.Drawing.Color.White;
            this.btnUploadActImage.Location = new System.Drawing.Point(794, 66);
            this.btnUploadActImage.Name = "btnUploadActImage";
            this.btnUploadActImage.Size = new System.Drawing.Size(134, 34);
            this.btnUploadActImage.TabIndex = 23;
            this.btnUploadActImage.Text = "📁 Upload Image...";
            this.btnUploadActImage.UseVisualStyleBackColor = false;
            this.btnUploadActImage.Click += new System.EventHandler(this.btnUploadActImage_Click);
            // 
            // btnResetActImage
            // 
            this.btnResetActImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(44)))));
            this.btnResetActImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetActImage.FlatAppearance.BorderSize = 0;
            this.btnResetActImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetActImage.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnResetActImage.ForeColor = System.Drawing.Color.White;
            this.btnResetActImage.Location = new System.Drawing.Point(794, 108);
            this.btnResetActImage.Name = "btnResetActImage";
            this.btnResetActImage.Size = new System.Drawing.Size(134, 30);
            this.btnResetActImage.TabIndex = 24;
            this.btnResetActImage.Text = "↺ Reset to Default";
            this.btnResetActImage.UseVisualStyleBackColor = false;
            this.btnResetActImage.Click += new System.EventHandler(this.btnResetActImage_Click);
            // 
            // lblActImageStatus
            // 
            this.lblActImageStatus.Font = new System.Drawing.Font("Arial", 7.75F);
            this.lblActImageStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(205)))));
            this.lblActImageStatus.Location = new System.Drawing.Point(684, 174);
            this.lblActImageStatus.Name = "lblActImageStatus";
            this.lblActImageStatus.Size = new System.Drawing.Size(244, 24);
            this.lblActImageStatus.TabIndex = 25;
            this.lblActImageStatus.Text = "Active: Auto (Match Tour Name)";
            // 
            // pnlBookings
            // 
            this.pnlBookings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(9)))));
            this.pnlBookings.Controls.Add(this.lblBookingsHeading);
            this.pnlBookings.Controls.Add(this.lblBookingSearchCap);
            this.pnlBookings.Controls.Add(this.txtBookingSearch);
            this.pnlBookings.Controls.Add(this.lblBookingFilterCap);
            this.pnlBookings.Controls.Add(this.cboBookingActivityFilter);
            this.pnlBookings.Controls.Add(this.chkEnableDateFilter);
            this.pnlBookings.Controls.Add(this.dtpBookingDateFilter);
            this.pnlBookings.Controls.Add(this.btnBookingEditImage);
            this.pnlBookings.Controls.Add(this.dgvAllBookings);
            this.pnlBookings.Location = new System.Drawing.Point(0, 0);
            this.pnlBookings.Name = "pnlBookings";
            this.pnlBookings.Size = new System.Drawing.Size(980, 750);
            this.pnlBookings.TabIndex = 2;
            this.pnlBookings.Visible = false;
            // 
            // lblBookingsHeading
            // 
            this.lblBookingsHeading.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblBookingsHeading.ForeColor = System.Drawing.Color.White;
            this.lblBookingsHeading.Location = new System.Drawing.Point(20, 16);
            this.lblBookingsHeading.Name = "lblBookingsHeading";
            this.lblBookingsHeading.Size = new System.Drawing.Size(500, 36);
            this.lblBookingsHeading.TabIndex = 0;
            this.lblBookingsHeading.Text = "All Visitor Bookings";
            // 
            // lblBookingSearchCap
            // 
            this.lblBookingSearchCap.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblBookingSearchCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(190)))));
            this.lblBookingSearchCap.Location = new System.Drawing.Point(20, 56);
            this.lblBookingSearchCap.Name = "lblBookingSearchCap";
            this.lblBookingSearchCap.Size = new System.Drawing.Size(220, 16);
            this.lblBookingSearchCap.TabIndex = 1;
            this.lblBookingSearchCap.Text = "SEARCH (VISITOR / ACTIVITY)";
            // 
            // txtBookingSearch
            // 
            this.txtBookingSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBookingSearch.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBookingSearch.Location = new System.Drawing.Point(20, 74);
            this.txtBookingSearch.Name = "txtBookingSearch";
            this.txtBookingSearch.Size = new System.Drawing.Size(240, 27);
            this.txtBookingSearch.TabIndex = 2;
            this.txtBookingSearch.TextChanged += new System.EventHandler(this.txtBookingSearch_TextChanged);
            // 
            // lblBookingFilterCap
            // 
            this.lblBookingFilterCap.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblBookingFilterCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(190)))));
            this.lblBookingFilterCap.Location = new System.Drawing.Point(280, 56);
            this.lblBookingFilterCap.Name = "lblBookingFilterCap";
            this.lblBookingFilterCap.Size = new System.Drawing.Size(150, 16);
            this.lblBookingFilterCap.TabIndex = 3;
            this.lblBookingFilterCap.Text = "ACTIVITY FILTER";
            // 
            // cboBookingActivityFilter
            // 
            this.cboBookingActivityFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBookingActivityFilter.Font = new System.Drawing.Font("Arial", 10F);
            this.cboBookingActivityFilter.Location = new System.Drawing.Point(280, 74);
            this.cboBookingActivityFilter.Name = "cboBookingActivityFilter";
            this.cboBookingActivityFilter.Size = new System.Drawing.Size(220, 27);
            this.cboBookingActivityFilter.TabIndex = 4;
            this.cboBookingActivityFilter.SelectedIndexChanged += new System.EventHandler(this.cboBookingActivityFilter_SelectedIndexChanged);
            // 
            // chkEnableDateFilter
            // 
            this.chkEnableDateFilter.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.chkEnableDateFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(190)))));
            this.chkEnableDateFilter.Location = new System.Drawing.Point(520, 74);
            this.chkEnableDateFilter.Name = "chkEnableDateFilter";
            this.chkEnableDateFilter.Size = new System.Drawing.Size(140, 26);
            this.chkEnableDateFilter.TabIndex = 5;
            this.chkEnableDateFilter.Text = "FILTER BY DATE:";
            this.chkEnableDateFilter.CheckedChanged += new System.EventHandler(this.chkEnableDateFilter_CheckedChanged);
            // 
            // dtpBookingDateFilter
            // 
            this.dtpBookingDateFilter.Font = new System.Drawing.Font("Arial", 10F);
            this.dtpBookingDateFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBookingDateFilter.Location = new System.Drawing.Point(660, 74);
            this.dtpBookingDateFilter.Name = "dtpBookingDateFilter";
            this.dtpBookingDateFilter.Size = new System.Drawing.Size(140, 27);
            this.dtpBookingDateFilter.TabIndex = 6;
            this.dtpBookingDateFilter.ValueChanged += new System.EventHandler(this.dtpBookingDateFilter_ValueChanged);
            // 
            // btnBookingEditImage
            // 
            this.btnBookingEditImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(92)))), ((int)(((byte)(255)))));
            this.btnBookingEditImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBookingEditImage.FlatAppearance.BorderSize = 0;
            this.btnBookingEditImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookingEditImage.Font = new System.Drawing.Font("Arial", 8.75F, System.Drawing.FontStyle.Bold);
            this.btnBookingEditImage.ForeColor = System.Drawing.Color.White;
            this.btnBookingEditImage.Location = new System.Drawing.Point(808, 68);
            this.btnBookingEditImage.Name = "btnBookingEditImage";
            this.btnBookingEditImage.Size = new System.Drawing.Size(152, 34);
            this.btnBookingEditImage.TabIndex = 8;
            this.btnBookingEditImage.Text = "🖼 Edit Panel Image";
            this.btnBookingEditImage.UseVisualStyleBackColor = false;
            this.btnBookingEditImage.Click += new System.EventHandler(this.btnBookingEditImage_Click);
            // 
            // dgvAllBookings
            // 
            this.dgvAllBookings.AllowUserToAddRows = false;
            this.dgvAllBookings.AllowUserToDeleteRows = false;
            this.dgvAllBookings.AllowUserToResizeRows = false;
            this.dgvAllBookings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllBookings.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(12)))), ((int)(((byte)(20)))));
            this.dgvAllBookings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAllBookings.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAllBookings.ColumnHeadersHeight = 34;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(16)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(92)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAllBookings.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAllBookings.EnableHeadersVisualStyles = false;
            this.dgvAllBookings.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(32)))), ((int)(((byte)(48)))));
            this.dgvAllBookings.Location = new System.Drawing.Point(20, 114);
            this.dgvAllBookings.MultiSelect = false;
            this.dgvAllBookings.Name = "dgvAllBookings";
            this.dgvAllBookings.ReadOnly = true;
            this.dgvAllBookings.RowHeadersVisible = false;
            this.dgvAllBookings.RowHeadersWidth = 51;
            this.dgvAllBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllBookings.Size = new System.Drawing.Size(940, 606);
            this.dgvAllBookings.TabIndex = 7;
            // 
            // pnlAttendance
            // 
            this.pnlAttendance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(9)))));
            this.pnlAttendance.Controls.Add(this.lblAttendanceHeading);
            this.pnlAttendance.Controls.Add(this.dgvAttendanceBookings);
            this.pnlAttendance.Controls.Add(this.pnlAttendanceUpdate);
            this.pnlAttendance.Location = new System.Drawing.Point(0, 0);
            this.pnlAttendance.Name = "pnlAttendance";
            this.pnlAttendance.Size = new System.Drawing.Size(980, 750);
            this.pnlAttendance.TabIndex = 3;
            this.pnlAttendance.Visible = false;
            // 
            // lblAttendanceHeading
            // 
            this.lblAttendanceHeading.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblAttendanceHeading.ForeColor = System.Drawing.Color.White;
            this.lblAttendanceHeading.Location = new System.Drawing.Point(20, 16);
            this.lblAttendanceHeading.Name = "lblAttendanceHeading";
            this.lblAttendanceHeading.Size = new System.Drawing.Size(500, 36);
            this.lblAttendanceHeading.TabIndex = 0;
            this.lblAttendanceHeading.Text = "Mark Booking Attendance";
            // 
            // dgvAttendanceBookings
            // 
            this.dgvAttendanceBookings.AllowUserToAddRows = false;
            this.dgvAttendanceBookings.AllowUserToDeleteRows = false;
            this.dgvAttendanceBookings.AllowUserToResizeRows = false;
            this.dgvAttendanceBookings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAttendanceBookings.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(12)))), ((int)(((byte)(20)))));
            this.dgvAttendanceBookings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAttendanceBookings.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAttendanceBookings.ColumnHeadersHeight = 34;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(16)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAttendanceBookings.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAttendanceBookings.EnableHeadersVisualStyles = false;
            this.dgvAttendanceBookings.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(32)))), ((int)(((byte)(48)))));
            this.dgvAttendanceBookings.Location = new System.Drawing.Point(20, 60);
            this.dgvAttendanceBookings.MultiSelect = false;
            this.dgvAttendanceBookings.Name = "dgvAttendanceBookings";
            this.dgvAttendanceBookings.ReadOnly = true;
            this.dgvAttendanceBookings.RowHeadersVisible = false;
            this.dgvAttendanceBookings.RowHeadersWidth = 51;
            this.dgvAttendanceBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttendanceBookings.Size = new System.Drawing.Size(940, 480);
            this.dgvAttendanceBookings.TabIndex = 1;
            this.dgvAttendanceBookings.SelectionChanged += new System.EventHandler(this.dgvAttendanceBookings_SelectionChanged);
            // 
            // pnlAttendanceUpdate
            // 
            this.pnlAttendanceUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
            this.pnlAttendanceUpdate.Controls.Add(this.lblSelectedBookingInfo);
            this.pnlAttendanceUpdate.Controls.Add(this.lblMarkAttCap);
            this.pnlAttendanceUpdate.Controls.Add(this.cboAttendanceStatus);
            this.pnlAttendanceUpdate.Controls.Add(this.btnSaveAttendance);
            this.pnlAttendanceUpdate.Location = new System.Drawing.Point(20, 554);
            this.pnlAttendanceUpdate.Name = "pnlAttendanceUpdate";
            this.pnlAttendanceUpdate.Size = new System.Drawing.Size(940, 170);
            this.pnlAttendanceUpdate.TabIndex = 2;
            // 
            // lblSelectedBookingInfo
            // 
            this.lblSelectedBookingInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSelectedBookingInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(201)))), ((int)(((byte)(255)))));
            this.lblSelectedBookingInfo.Location = new System.Drawing.Point(16, 14);
            this.lblSelectedBookingInfo.Name = "lblSelectedBookingInfo";
            this.lblSelectedBookingInfo.Size = new System.Drawing.Size(700, 24);
            this.lblSelectedBookingInfo.TabIndex = 0;
            this.lblSelectedBookingInfo.Text = "Select a booking row above to mark attendance.";
            // 
            // lblMarkAttCap
            // 
            this.lblMarkAttCap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMarkAttCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(190)))));
            this.lblMarkAttCap.Location = new System.Drawing.Point(16, 50);
            this.lblMarkAttCap.Name = "lblMarkAttCap";
            this.lblMarkAttCap.Size = new System.Drawing.Size(200, 18);
            this.lblMarkAttCap.TabIndex = 1;
            this.lblMarkAttCap.Text = "MARK ATTENDANCE STATUS:";
            // 
            // cboAttendanceStatus
            // 
            this.cboAttendanceStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.cboAttendanceStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAttendanceStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboAttendanceStatus.ForeColor = System.Drawing.Color.White;
            this.cboAttendanceStatus.Location = new System.Drawing.Point(16, 72);
            this.cboAttendanceStatus.Name = "cboAttendanceStatus";
            this.cboAttendanceStatus.Size = new System.Drawing.Size(240, 31);
            this.cboAttendanceStatus.TabIndex = 2;
            // 
            // btnSaveAttendance
            // 
            this.btnSaveAttendance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnSaveAttendance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveAttendance.FlatAppearance.BorderSize = 0;
            this.btnSaveAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAttendance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveAttendance.ForeColor = System.Drawing.Color.White;
            this.btnSaveAttendance.Location = new System.Drawing.Point(280, 68);
            this.btnSaveAttendance.Name = "btnSaveAttendance";
            this.btnSaveAttendance.Size = new System.Drawing.Size(260, 44);
            this.btnSaveAttendance.TabIndex = 3;
            this.btnSaveAttendance.Text = "💾  Save Attendance Status";
            this.btnSaveAttendance.UseVisualStyleBackColor = false;
            this.btnSaveAttendance.Click += new System.EventHandler(this.btnSaveAttendance_Click);
            // 
            // pnlReports
            // 
            this.pnlReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(9)))));
            this.pnlReports.Controls.Add(this.lblReportsHeading);
            this.pnlReports.Controls.Add(this.pnlChartBar);
            this.pnlReports.Controls.Add(this.pnlChartFunnel);
            this.pnlReports.Controls.Add(this.pnlChartArea);
            this.pnlReports.Controls.Add(this.rtbReportOutput);
            this.pnlReports.Controls.Add(this.btnGenerateReport);
            this.pnlReports.Controls.Add(this.btnExportReport);
            this.pnlReports.Location = new System.Drawing.Point(0, 0);
            this.pnlReports.Name = "pnlReports";
            this.pnlReports.Size = new System.Drawing.Size(980, 750);
            this.pnlReports.TabIndex = 4;
            this.pnlReports.Visible = false;
            // 
            // lblReportsHeading
            // 
            this.lblReportsHeading.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblReportsHeading.ForeColor = System.Drawing.Color.White;
            this.lblReportsHeading.Location = new System.Drawing.Point(20, 14);
            this.lblReportsHeading.Name = "lblReportsHeading";
            this.lblReportsHeading.Size = new System.Drawing.Size(760, 34);
            this.lblReportsHeading.TabIndex = 0;
            this.lblReportsHeading.Text = "Booking && Attendance Reports — Bklit UI System Analytics";
            // 
            // pnlChartBar
            // 
            this.pnlChartBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(23)))));
            this.pnlChartBar.Location = new System.Drawing.Point(20, 54);
            this.pnlChartBar.Name = "pnlChartBar";
            this.pnlChartBar.Size = new System.Drawing.Size(304, 290);
            this.pnlChartBar.TabIndex = 4;
            this.pnlChartBar.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlChartBar_Paint);
            // 
            // pnlChartFunnel
            // 
            this.pnlChartFunnel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(23)))));
            this.pnlChartFunnel.Location = new System.Drawing.Point(338, 54);
            this.pnlChartFunnel.Name = "pnlChartFunnel";
            this.pnlChartFunnel.Size = new System.Drawing.Size(304, 290);
            this.pnlChartFunnel.TabIndex = 5;
            this.pnlChartFunnel.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlChartFunnel_Paint);
            // 
            // pnlChartArea
            // 
            this.pnlChartArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(23)))));
            this.pnlChartArea.Location = new System.Drawing.Point(656, 54);
            this.pnlChartArea.Name = "pnlChartArea";
            this.pnlChartArea.Size = new System.Drawing.Size(304, 290);
            this.pnlChartArea.TabIndex = 6;
            this.pnlChartArea.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlChartArea_Paint);
            // 
            // rtbReportOutput
            // 
            this.rtbReportOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(22)))));
            this.rtbReportOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbReportOutput.Font = new System.Drawing.Font("Consolas", 10F);
            this.rtbReportOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
            this.rtbReportOutput.Location = new System.Drawing.Point(20, 356);
            this.rtbReportOutput.Name = "rtbReportOutput";
            this.rtbReportOutput.ReadOnly = true;
            this.rtbReportOutput.Size = new System.Drawing.Size(940, 288);
            this.rtbReportOutput.TabIndex = 1;
            this.rtbReportOutput.Text = "";
            this.rtbReportOutput.WordWrap = false;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(92)))), ((int)(((byte)(255)))));
            this.btnGenerateReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateReport.FlatAppearance.BorderSize = 0;
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGenerateReport.ForeColor = System.Drawing.Color.White;
            this.btnGenerateReport.Location = new System.Drawing.Point(20, 656);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(220, 46);
            this.btnGenerateReport.TabIndex = 2;
            this.btnGenerateReport.Text = "🔄  Refresh Report";
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // btnExportReport
            // 
            this.btnExportReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnExportReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportReport.FlatAppearance.BorderSize = 0;
            this.btnExportReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportReport.ForeColor = System.Drawing.Color.White;
            this.btnExportReport.Location = new System.Drawing.Point(260, 656);
            this.btnExportReport.Name = "btnExportReport";
            this.btnExportReport.Size = new System.Drawing.Size(280, 46);
            this.btnExportReport.TabIndex = 3;
            this.btnExportReport.Text = "💾  Export to /Data/Reports";
            this.btnExportReport.UseVisualStyleBackColor = false;
            this.btnExportReport.Click += new System.EventHandler(this.btnExportReport_Click);
            // 
            // pnlChangePassword
            // 
            this.pnlChangePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(9)))));
            this.pnlChangePassword.Controls.Add(this.lblChangePassHeading);
            this.pnlChangePassword.Controls.Add(this.lblChangePassSub);
            this.pnlChangePassword.Controls.Add(this.lblCurrPassCap);
            this.pnlChangePassword.Controls.Add(this.txtCurrentPassword);
            this.pnlChangePassword.Controls.Add(this.lblNewPassCap);
            this.pnlChangePassword.Controls.Add(this.txtNewPassword);
            this.pnlChangePassword.Controls.Add(this.lblConfPassCap);
            this.pnlChangePassword.Controls.Add(this.txtConfirmPassword);
            this.pnlChangePassword.Controls.Add(this.lblPassError);
            this.pnlChangePassword.Controls.Add(this.btnSavePassword);
            this.pnlChangePassword.Location = new System.Drawing.Point(0, 0);
            this.pnlChangePassword.Name = "pnlChangePassword";
            this.pnlChangePassword.Size = new System.Drawing.Size(980, 750);
            this.pnlChangePassword.TabIndex = 5;
            this.pnlChangePassword.Visible = false;
            // 
            // lblChangePassHeading
            // 
            this.lblChangePassHeading.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblChangePassHeading.ForeColor = System.Drawing.Color.White;
            this.lblChangePassHeading.Location = new System.Drawing.Point(30, 20);
            this.lblChangePassHeading.Name = "lblChangePassHeading";
            this.lblChangePassHeading.Size = new System.Drawing.Size(500, 36);
            this.lblChangePassHeading.TabIndex = 0;
            this.lblChangePassHeading.Text = "Change Admin Password";
            // 
            // lblChangePassSub
            // 
            this.lblChangePassSub.Font = new System.Drawing.Font("Arial", 10F);
            this.lblChangePassSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(190)))));
            this.lblChangePassSub.Location = new System.Drawing.Point(30, 60);
            this.lblChangePassSub.Name = "lblChangePassSub";
            this.lblChangePassSub.Size = new System.Drawing.Size(600, 24);
            this.lblChangePassSub.TabIndex = 1;
            this.lblChangePassSub.Text = "Enter your current password and set a new password.";
            // 
            // lblCurrPassCap
            // 
            this.lblCurrPassCap.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblCurrPassCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(190)))));
            this.lblCurrPassCap.Location = new System.Drawing.Point(30, 104);
            this.lblCurrPassCap.Name = "lblCurrPassCap";
            this.lblCurrPassCap.Size = new System.Drawing.Size(200, 18);
            this.lblCurrPassCap.TabIndex = 2;
            this.lblCurrPassCap.Text = "CURRENT PASSWORD";
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.txtCurrentPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrentPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCurrentPassword.ForeColor = System.Drawing.Color.White;
            this.txtCurrentPassword.Location = new System.Drawing.Point(30, 124);
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.Size = new System.Drawing.Size(460, 30);
            this.txtCurrentPassword.TabIndex = 3;
            this.txtCurrentPassword.UseSystemPasswordChar = true;
            // 
            // lblNewPassCap
            // 
            this.lblNewPassCap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNewPassCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(190)))));
            this.lblNewPassCap.Location = new System.Drawing.Point(30, 176);
            this.lblNewPassCap.Name = "lblNewPassCap";
            this.lblNewPassCap.Size = new System.Drawing.Size(200, 18);
            this.lblNewPassCap.TabIndex = 4;
            this.lblNewPassCap.Text = "NEW PASSWORD";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.txtNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNewPassword.ForeColor = System.Drawing.Color.White;
            this.txtNewPassword.Location = new System.Drawing.Point(30, 196);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(460, 30);
            this.txtNewPassword.TabIndex = 5;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // lblConfPassCap
            // 
            this.lblConfPassCap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblConfPassCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(190)))));
            this.lblConfPassCap.Location = new System.Drawing.Point(30, 248);
            this.lblConfPassCap.Name = "lblConfPassCap";
            this.lblConfPassCap.Size = new System.Drawing.Size(200, 18);
            this.lblConfPassCap.TabIndex = 6;
            this.lblConfPassCap.Text = "CONFIRM NEW PASSWORD";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtConfirmPassword.ForeColor = System.Drawing.Color.White;
            this.txtConfirmPassword.Location = new System.Drawing.Point(30, 268);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(460, 30);
            this.txtConfirmPassword.TabIndex = 7;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lblPassError
            // 
            this.lblPassError.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPassError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.lblPassError.Location = new System.Drawing.Point(30, 320);
            this.lblPassError.Name = "lblPassError";
            this.lblPassError.Size = new System.Drawing.Size(600, 20);
            this.lblPassError.TabIndex = 8;
            this.lblPassError.Visible = false;
            // 
            // btnSavePassword
            // 
            this.btnSavePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(92)))), ((int)(((byte)(255)))));
            this.btnSavePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSavePassword.FlatAppearance.BorderSize = 0;
            this.btnSavePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavePassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSavePassword.ForeColor = System.Drawing.Color.White;
            this.btnSavePassword.Location = new System.Drawing.Point(30, 350);
            this.btnSavePassword.Name = "btnSavePassword";
            this.btnSavePassword.Size = new System.Drawing.Size(240, 48);
            this.btnSavePassword.TabIndex = 9;
            this.btnSavePassword.Text = "Update Password";
            this.btnSavePassword.UseVisualStyleBackColor = false;
            this.btnSavePassword.Click += new System.EventHandler(this.btnSavePassword_Click);
            // 
            // pnlAiSettings
            // 
            this.pnlAiSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(9)))));
            this.pnlAiSettings.Controls.Add(this.lblAiSettingsHeading);
            this.pnlAiSettings.Controls.Add(this.lblAiSettingsSub);
            this.pnlAiSettings.Controls.Add(this.pnlAiStatusCard);
            this.pnlAiSettings.Controls.Add(this.lblAdminApiKeyCap);
            this.pnlAiSettings.Controls.Add(this.txtAdminApiKey);
            this.pnlAiSettings.Controls.Add(this.chkShowAdminApiKey);
            this.pnlAiSettings.Controls.Add(this.lblAdminApiKeyMsg);
            this.pnlAiSettings.Controls.Add(this.btnSaveAdminApiKey);
            this.pnlAiSettings.Controls.Add(this.btnClearAdminApiKey);
            this.pnlAiSettings.Controls.Add(this.lblApiGuideHeading);
            this.pnlAiSettings.Controls.Add(this.dgvApiGuide);
            this.pnlAiSettings.Controls.Add(this.pnlApiDetailBox);
            this.pnlAiSettings.Location = new System.Drawing.Point(0, 0);
            this.pnlAiSettings.Name = "pnlAiSettings";
            this.pnlAiSettings.Size = new System.Drawing.Size(980, 750);
            this.pnlAiSettings.TabIndex = 6;
            this.pnlAiSettings.Visible = false;
            // 
            // lblAiSettingsHeading
            // 
            this.lblAiSettingsHeading.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblAiSettingsHeading.ForeColor = System.Drawing.Color.White;
            this.lblAiSettingsHeading.Location = new System.Drawing.Point(30, 16);
            this.lblAiSettingsHeading.Name = "lblAiSettingsHeading";
            this.lblAiSettingsHeading.Size = new System.Drawing.Size(800, 34);
            this.lblAiSettingsHeading.TabIndex = 0;
            this.lblAiSettingsHeading.Text = "SafariScout AI – Administrator API Key && Provider Guide";
            // 
            // lblAiSettingsSub
            // 
            this.lblAiSettingsSub.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lblAiSettingsSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(190)))));
            this.lblAiSettingsSub.Location = new System.Drawing.Point(30, 52);
            this.lblAiSettingsSub.Name = "lblAiSettingsSub";
            this.lblAiSettingsSub.Size = new System.Drawing.Size(900, 22);
            this.lblAiSettingsSub.TabIndex = 1;
            this.lblAiSettingsSub.Text = "Only Administrators can configure the SafariScout AI key. Review the Applicable A" +
    "PIs table below to choose the right engine for your situation.";
            // 
            // pnlAiStatusCard
            // 
            this.pnlAiStatusCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(26)))));
            this.pnlAiStatusCard.Controls.Add(this.lblAiStatusCardTitle);
            this.pnlAiStatusCard.Controls.Add(this.lblAiCurrentStatus);
            this.pnlAiStatusCard.Location = new System.Drawing.Point(30, 82);
            this.pnlAiStatusCard.Name = "pnlAiStatusCard";
            this.pnlAiStatusCard.Size = new System.Drawing.Size(920, 72);
            this.pnlAiStatusCard.TabIndex = 2;
            // 
            // lblAiStatusCardTitle
            // 
            this.lblAiStatusCardTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblAiStatusCardTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(155)))), ((int)(((byte)(255)))));
            this.lblAiStatusCardTitle.Location = new System.Drawing.Point(14, 10);
            this.lblAiStatusCardTitle.Name = "lblAiStatusCardTitle";
            this.lblAiStatusCardTitle.Size = new System.Drawing.Size(880, 20);
            this.lblAiStatusCardTitle.TabIndex = 0;
            this.lblAiStatusCardTitle.Text = "🧭 CURRENT SAFARISCOUT AI ENGINE STATUS";
            // 
            // lblAiCurrentStatus
            // 
            this.lblAiCurrentStatus.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblAiCurrentStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(255)))), ((int)(((byte)(173)))));
            this.lblAiCurrentStatus.Location = new System.Drawing.Point(14, 34);
            this.lblAiCurrentStatus.Name = "lblAiCurrentStatus";
            this.lblAiCurrentStatus.Size = new System.Drawing.Size(880, 26);
            this.lblAiCurrentStatus.TabIndex = 1;
            this.lblAiCurrentStatus.Text = "Active Mode: Built-in Offline Safari Engine (No Cloud API Key configured)";
            // 
            // lblAdminApiKeyCap
            // 
            this.lblAdminApiKeyCap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAdminApiKeyCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(190)))));
            this.lblAdminApiKeyCap.Location = new System.Drawing.Point(30, 168);
            this.lblAdminApiKeyCap.Name = "lblAdminApiKeyCap";
            this.lblAdminApiKeyCap.Size = new System.Drawing.Size(920, 18);
            this.lblAdminApiKeyCap.TabIndex = 3;
            this.lblAdminApiKeyCap.Text = "ENTER CLOUD AI API KEY (GEMINI \'AIza...\', GROQ \'gsk_...\', OPENAI \'sk-...\', OR OPE" +
    "NROUTER \'sk-or-...\')";
            // 
            // txtAdminApiKey
            // 
            this.txtAdminApiKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.txtAdminApiKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdminApiKey.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtAdminApiKey.ForeColor = System.Drawing.Color.White;
            this.txtAdminApiKey.Location = new System.Drawing.Point(30, 190);
            this.txtAdminApiKey.Name = "txtAdminApiKey";
            this.txtAdminApiKey.Size = new System.Drawing.Size(680, 31);
            this.txtAdminApiKey.TabIndex = 4;
            this.txtAdminApiKey.UseSystemPasswordChar = true;
            // 
            // chkShowAdminApiKey
            // 
            this.chkShowAdminApiKey.AutoSize = true;
            this.chkShowAdminApiKey.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkShowAdminApiKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.chkShowAdminApiKey.Location = new System.Drawing.Point(726, 194);
            this.chkShowAdminApiKey.Name = "chkShowAdminApiKey";
            this.chkShowAdminApiKey.Size = new System.Drawing.Size(211, 25);
            this.chkShowAdminApiKey.TabIndex = 5;
            this.chkShowAdminApiKey.Text = "Show API Key in plain text";
            this.chkShowAdminApiKey.UseVisualStyleBackColor = true;
            this.chkShowAdminApiKey.CheckedChanged += new System.EventHandler(this.chkShowAdminApiKey_CheckedChanged);
            // 
            // lblAdminApiKeyMsg
            // 
            this.lblAdminApiKeyMsg.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblAdminApiKeyMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblAdminApiKeyMsg.Location = new System.Drawing.Point(30, 276);
            this.lblAdminApiKeyMsg.Name = "lblAdminApiKeyMsg";
            this.lblAdminApiKeyMsg.Size = new System.Drawing.Size(920, 22);
            this.lblAdminApiKeyMsg.TabIndex = 8;
            this.lblAdminApiKeyMsg.Visible = false;
            // 
            // btnSaveAdminApiKey
            // 
            this.btnSaveAdminApiKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnSaveAdminApiKey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveAdminApiKey.FlatAppearance.BorderSize = 0;
            this.btnSaveAdminApiKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAdminApiKey.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveAdminApiKey.ForeColor = System.Drawing.Color.White;
            this.btnSaveAdminApiKey.Location = new System.Drawing.Point(30, 228);
            this.btnSaveAdminApiKey.Name = "btnSaveAdminApiKey";
            this.btnSaveAdminApiKey.Size = new System.Drawing.Size(260, 42);
            this.btnSaveAdminApiKey.TabIndex = 6;
            this.btnSaveAdminApiKey.Text = "💾  Save SafariScout API Key";
            this.btnSaveAdminApiKey.UseVisualStyleBackColor = false;
            this.btnSaveAdminApiKey.Click += new System.EventHandler(this.btnSaveAdminApiKey_Click);
            // 
            // btnClearAdminApiKey
            // 
            this.btnClearAdminApiKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(44)))));
            this.btnClearAdminApiKey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearAdminApiKey.FlatAppearance.BorderSize = 0;
            this.btnClearAdminApiKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearAdminApiKey.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnClearAdminApiKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(201)))), ((int)(((byte)(255)))));
            this.btnClearAdminApiKey.Location = new System.Drawing.Point(306, 228);
            this.btnClearAdminApiKey.Name = "btnClearAdminApiKey";
            this.btnClearAdminApiKey.Size = new System.Drawing.Size(280, 42);
            this.btnClearAdminApiKey.TabIndex = 7;
            this.btnClearAdminApiKey.Text = "↺  Clear Key (Use Offline Engine)";
            this.btnClearAdminApiKey.UseVisualStyleBackColor = false;
            this.btnClearAdminApiKey.Click += new System.EventHandler(this.btnClearAdminApiKey_Click);
            // 
            // lblApiGuideHeading
            // 
            this.lblApiGuideHeading.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblApiGuideHeading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(201)))), ((int)(((byte)(255)))));
            this.lblApiGuideHeading.Location = new System.Drawing.Point(30, 308);
            this.lblApiGuideHeading.Name = "lblApiGuideHeading";
            this.lblApiGuideHeading.Size = new System.Drawing.Size(920, 24);
            this.lblApiGuideHeading.TabIndex = 9;
            this.lblApiGuideHeading.Text = "📋 Applicable AI APIs && When to Apply Each (Click any row for full guidance)";
            // 
            // dgvApiGuide
            // 
            this.dgvApiGuide.AllowUserToAddRows = false;
            this.dgvApiGuide.AllowUserToDeleteRows = false;
            this.dgvApiGuide.AllowUserToResizeRows = false;
            this.dgvApiGuide.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(12)))), ((int)(((byte)(20)))));
            this.dgvApiGuide.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvApiGuide.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvApiGuide.ColumnHeadersHeight = 34;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(16)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(92)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvApiGuide.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvApiGuide.EnableHeadersVisualStyles = false;
            this.dgvApiGuide.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(32)))), ((int)(((byte)(48)))));
            this.dgvApiGuide.Location = new System.Drawing.Point(30, 338);
            this.dgvApiGuide.MultiSelect = false;
            this.dgvApiGuide.Name = "dgvApiGuide";
            this.dgvApiGuide.ReadOnly = true;
            this.dgvApiGuide.RowHeadersVisible = false;
            this.dgvApiGuide.RowHeadersWidth = 51;
            this.dgvApiGuide.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApiGuide.Size = new System.Drawing.Size(920, 246);
            this.dgvApiGuide.TabIndex = 10;
            this.dgvApiGuide.SelectionChanged += new System.EventHandler(this.dgvApiGuide_SelectionChanged);
            // 
            // pnlApiDetailBox
            // 
            this.pnlApiDetailBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(26)))));
            this.pnlApiDetailBox.Controls.Add(this.lblSelectedApiGuideDetail);
            this.pnlApiDetailBox.Location = new System.Drawing.Point(30, 598);
            this.pnlApiDetailBox.Name = "pnlApiDetailBox";
            this.pnlApiDetailBox.Size = new System.Drawing.Size(920, 126);
            this.pnlApiDetailBox.TabIndex = 11;
            // 
            // lblSelectedApiGuideDetail
            // 
            this.lblSelectedApiGuideDetail.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lblSelectedApiGuideDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblSelectedApiGuideDetail.Location = new System.Drawing.Point(14, 10);
            this.lblSelectedApiGuideDetail.Name = "lblSelectedApiGuideDetail";
            this.lblSelectedApiGuideDetail.Size = new System.Drawing.Size(892, 106);
            this.lblSelectedApiGuideDetail.TabIndex = 0;
            this.lblSelectedApiGuideDetail.Text = "Select an API provider row above to view its exact use-case, key prefix, and when" +
    " to apply it.";
            // 
            // AdminDashboardForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(9)))));
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.MinimumSize = new System.Drawing.Size(960, 620);
            this.Name = "AdminDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blue Horizons Tours – Admin Dashboard";
            this.pnlSidebar.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlNotifications.ResumeLayout(false);
            this.cardNotifTotal.ResumeLayout(false);
            this.cardNotifUnread.ResumeLayout(false);
            this.cardNotifRead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessages)).EndInit();
            this.pnlContent.ResumeLayout(false);
            this.pnlOverview.ResumeLayout(false);
            this.tileBookings.ResumeLayout(false);
            this.tileRevenue.ResumeLayout(false);
            this.tileUpcoming.ResumeLayout(false);
            this.tileSeatsLeft.ResumeLayout(false);
            this.pnlShortcuts.ResumeLayout(false);
            this.pnlActivities.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivities)).EndInit();
            this.pnlActivityForm.ResumeLayout(false);
            this.pnlActivityForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalSeats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAvailableSeats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picActImagePreview)).EndInit();
            this.pnlBookings.ResumeLayout(false);
            this.pnlBookings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllBookings)).EndInit();
            this.pnlAttendance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceBookings)).EndInit();
            this.pnlAttendanceUpdate.ResumeLayout(false);
            this.pnlReports.ResumeLayout(false);
            this.pnlChangePassword.ResumeLayout(false);
            this.pnlChangePassword.PerformLayout();
            this.pnlAiSettings.ResumeLayout(false);
            this.pnlAiSettings.PerformLayout();
            this.pnlAiStatusCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApiGuide)).EndInit();
            this.pnlApiDetailBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblAdminBrand;
        private System.Windows.Forms.Label lblAdminPortalSub;
        private System.Windows.Forms.Label lblSidebarUser;
        private System.Windows.Forms.Button btnNavOverview;
        private System.Windows.Forms.Button btnNavActivities;
        private System.Windows.Forms.Button btnNavBookings;
        private System.Windows.Forms.Button btnNavAttendance;
        private System.Windows.Forms.Button btnNavReports;
        private System.Windows.Forms.Button btnNavChangePass;
        private System.Windows.Forms.Button btnNavLogout;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlOverview;
        private System.Windows.Forms.Panel tileBookings;
        private System.Windows.Forms.Label lblTileBookings;
        private System.Windows.Forms.Label lblTileBookingsCap;
        private System.Windows.Forms.Panel tileRevenue;
        private System.Windows.Forms.Label lblTileRevenue;
        private System.Windows.Forms.Label lblTileRevenueCap;
        private System.Windows.Forms.Panel tileUpcoming;
        private System.Windows.Forms.Label lblTileUpcoming;
        private System.Windows.Forms.Label lblTileUpcomingCap;
        private System.Windows.Forms.Panel tileSeatsLeft;
        private System.Windows.Forms.Label lblTileSeatsLeft;
        private System.Windows.Forms.Label lblTileSeatsLeftCap;
        private System.Windows.Forms.Panel pnlShortcuts;
        private System.Windows.Forms.Button btnShortcutActivities;
        private System.Windows.Forms.Button btnShortcutBookings;
        private System.Windows.Forms.Button btnShortcutAttendance;
        private System.Windows.Forms.Button btnShortcutReports;
        private System.Windows.Forms.Panel pnlActivities;
        private System.Windows.Forms.Label lblActivitiesHeading;
        private System.Windows.Forms.DataGridView dgvActivities;
        private System.Windows.Forms.Panel pnlActivityForm;
        private System.Windows.Forms.Label lblActivityFormTitle;
        private System.Windows.Forms.Label lblCatCap;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblActNameCap;
        private System.Windows.Forms.TextBox txtActName;
        private System.Windows.Forms.Label lblPriceCap;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.Label lblDescCap;
        private System.Windows.Forms.TextBox txtActDescription;
        private System.Windows.Forms.Label lblDateCap;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblTotalSeatsCap;
        private System.Windows.Forms.NumericUpDown nudTotalSeats;
        private System.Windows.Forms.Label lblAvailSeatsCap;
        private System.Windows.Forms.NumericUpDown nudAvailableSeats;
        private System.Windows.Forms.Label lblActError;
        private System.Windows.Forms.Button btnActAdd;
        private System.Windows.Forms.Button btnActSave;
        private System.Windows.Forms.Button btnActDelete;
        private System.Windows.Forms.Button btnActClear;
        private System.Windows.Forms.Label lblActImageCap;
        private System.Windows.Forms.PictureBox picActImagePreview;
        private System.Windows.Forms.ComboBox cboActImagePreset;
        private System.Windows.Forms.Button btnUploadActImage;
        private System.Windows.Forms.Button btnResetActImage;
        private System.Windows.Forms.Label lblActImageStatus;
        private System.Windows.Forms.Button btnBookingEditImage;
        private System.Windows.Forms.Button btnNavNotifications;
        private System.Windows.Forms.Panel pnlNotifications;
        private System.Windows.Forms.Label lblNotifHeading;
        private System.Windows.Forms.Label lblNotifSub;
        private System.Windows.Forms.Panel cardNotifTotal;
        private System.Windows.Forms.Label lblNotifTotal;
        private System.Windows.Forms.Label lblNotifTotalCap;
        private System.Windows.Forms.Panel cardNotifUnread;
        private System.Windows.Forms.Label lblNotifUnread;
        private System.Windows.Forms.Label lblNotifUnreadCap;
        private System.Windows.Forms.Panel cardNotifRead;
        private System.Windows.Forms.Label lblNotifRead;
        private System.Windows.Forms.Label lblNotifReadCap;
        private System.Windows.Forms.Label lblNotifGridHeading;
        private System.Windows.Forms.DataGridView dgvMessages;
        private System.Windows.Forms.Panel pnlBookings;
        private System.Windows.Forms.Label lblBookingsHeading;
        private System.Windows.Forms.Label lblBookingSearchCap;
        private System.Windows.Forms.TextBox txtBookingSearch;
        private System.Windows.Forms.Label lblBookingFilterCap;
        private System.Windows.Forms.ComboBox cboBookingActivityFilter;
        private System.Windows.Forms.CheckBox chkEnableDateFilter;
        private System.Windows.Forms.DateTimePicker dtpBookingDateFilter;
        private System.Windows.Forms.DataGridView dgvAllBookings;
        private System.Windows.Forms.Panel pnlAttendance;
        private System.Windows.Forms.Label lblAttendanceHeading;
        private System.Windows.Forms.DataGridView dgvAttendanceBookings;
        private System.Windows.Forms.Panel pnlAttendanceUpdate;
        private System.Windows.Forms.Label lblSelectedBookingInfo;
        private System.Windows.Forms.Label lblMarkAttCap;
        private System.Windows.Forms.ComboBox cboAttendanceStatus;
        private System.Windows.Forms.Button btnSaveAttendance;
        private System.Windows.Forms.Panel pnlReports;
        private System.Windows.Forms.Label lblReportsHeading;
        private System.Windows.Forms.Panel pnlChartBar;
        private System.Windows.Forms.Panel pnlChartFunnel;
        private System.Windows.Forms.Panel pnlChartArea;
        private System.Windows.Forms.RichTextBox rtbReportOutput;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Button btnExportReport;
        private System.Windows.Forms.Panel pnlChangePassword;
        private System.Windows.Forms.Label lblChangePassHeading;
        private System.Windows.Forms.Label lblChangePassSub;
        private System.Windows.Forms.Label lblCurrPassCap;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.Label lblNewPassCap;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label lblConfPassCap;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblPassError;
        private System.Windows.Forms.Button btnSavePassword;
        private System.Windows.Forms.Button btnNavAiSettings;
        private System.Windows.Forms.Button btnShortcutAiSettings;
        private System.Windows.Forms.Panel pnlAiSettings;
        private System.Windows.Forms.Label lblAiSettingsHeading;
        private System.Windows.Forms.Label lblAiSettingsSub;
        private System.Windows.Forms.Panel pnlAiStatusCard;
        private System.Windows.Forms.Label lblAiStatusCardTitle;
        private System.Windows.Forms.Label lblAiCurrentStatus;
        private System.Windows.Forms.Label lblAdminApiKeyCap;
        private System.Windows.Forms.TextBox txtAdminApiKey;
        private System.Windows.Forms.CheckBox chkShowAdminApiKey;
        private System.Windows.Forms.Label lblAdminApiKeyMsg;
        private System.Windows.Forms.Button btnSaveAdminApiKey;
        private System.Windows.Forms.Button btnClearAdminApiKey;
        private System.Windows.Forms.Label lblApiGuideHeading;
        private System.Windows.Forms.DataGridView dgvApiGuide;
        private System.Windows.Forms.Panel pnlApiDetailBox;
        private System.Windows.Forms.Label lblSelectedApiGuideDetail;
    }
}
