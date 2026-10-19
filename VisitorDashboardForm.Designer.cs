// =============================================================================
// Forms/VisitorDashboardForm.Designer.cs
// Standard Visual Studio Windows Forms Designer layout so the full GUI is
// displayable and editable in the Visual Studio Form Designer.
// =============================================================================

namespace PROJECTT.Forms
{
    partial class VisitorDashboardForm
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
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblBrandTitle = new System.Windows.Forms.Label();
            this.lblPortalSub = new System.Windows.Forms.Label();
            this.lblSidebarUser = new System.Windows.Forms.Label();
            this.btnNavHome = new System.Windows.Forms.Button();
            this.btnNavBrowse = new System.Windows.Forms.Button();
            this.btnNavMyBookings = new System.Windows.Forms.Button();
            this.btnNavProfile = new System.Windows.Forms.Button();
            this.btnNavChatbot = new System.Windows.Forms.Button();
            this.btnNavContactUs = new System.Windows.Forms.Button();
            this.pnlCardEntry = new System.Windows.Forms.Panel();
            this.lblPayGuestNameCap = new System.Windows.Forms.Label();
            this.txtPayFullName = new System.Windows.Forms.TextBox();
            this.lblPayNameErr = new System.Windows.Forms.Label();
            this.lblPayGuestEmailCap = new System.Windows.Forms.Label();
            this.txtPayEmail = new System.Windows.Forms.TextBox();
            this.lblPayEmailErr = new System.Windows.Forms.Label();
            this.lblPayCardCap = new System.Windows.Forms.Label();
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.btnFillDemoCard = new System.Windows.Forms.Button();
            this.lblPayCardErr = new System.Windows.Forms.Label();
            this.lblPayExpiryCap = new System.Windows.Forms.Label();
            this.txtCardMonth = new System.Windows.Forms.TextBox();
            this.txtCardYear = new System.Windows.Forms.TextBox();
            this.lblPayExpiryErr = new System.Windows.Forms.Label();
            this.lblPayCvcCap = new System.Windows.Forms.Label();
            this.txtCardCvc = new System.Windows.Forms.TextBox();
            this.lblPayCvcErr = new System.Windows.Forms.Label();
            this.btnOpenTicketsFolder = new System.Windows.Forms.Button();
            this.pnlContactUs = new System.Windows.Forms.Panel();
            this.lblContactHeading = new System.Windows.Forms.Label();
            this.lblContactSub = new System.Windows.Forms.Label();
            this.pnlContactCard = new System.Windows.Forms.Panel();
            this.lblContactNameCap = new System.Windows.Forms.Label();
            this.txtContactName = new System.Windows.Forms.TextBox();
            this.lblContactEmailCap = new System.Windows.Forms.Label();
            this.txtContactEmail = new System.Windows.Forms.TextBox();
            this.lblContactSubjectCap = new System.Windows.Forms.Label();
            this.cmbContactSubject = new System.Windows.Forms.ComboBox();
            this.lblContactMsgCap = new System.Windows.Forms.Label();
            this.txtContactMessage = new System.Windows.Forms.TextBox();
            this.btnSendContactMessage = new System.Windows.Forms.Button();
            this.btnFloatingChat = new System.Windows.Forms.Button();
            this.pnlDivider = new System.Windows.Forms.Panel();
            this.btnNavLogout = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlHome = new System.Windows.Forms.Panel();
            this.lblHomeWelcome = new System.Windows.Forms.Label();
            this.lblHomeSub = new System.Windows.Forms.Label();
            this.pnlHomeMeta = new System.Windows.Forms.Panel();
            this.lblDashboardLocation = new System.Windows.Forms.Label();
            this.lblDashboardClock = new System.Windows.Forms.Label();
            this.cardBookings = new System.Windows.Forms.Panel();
            this.lblHomeBookingsCount = new System.Windows.Forms.Label();
            this.lblHomeBookingsCap = new System.Windows.Forms.Label();
            this.cardUpcoming = new System.Windows.Forms.Panel();
            this.lblHomeUpcomingCount = new System.Windows.Forms.Label();
            this.lblHomeUpcomingCap = new System.Windows.Forms.Label();
            this.lblHomePrompt = new System.Windows.Forms.Label();
            this.btnQuickBrowse = new System.Windows.Forms.Button();
            this.pnlHomeAnalytics = new System.Windows.Forms.Panel();
            this.pnlBrowse = new System.Windows.Forms.Panel();
            this.lblBrowseHeading = new System.Windows.Forms.Label();
            this.lblBrowseCatCap = new System.Windows.Forms.Label();
            this.cboCategoryFilter = new System.Windows.Forms.ComboBox();
            this.lblBrowseSearchCap = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlAccordionGallery = new System.Windows.Forms.Panel();
            this.dgvActivities = new System.Windows.Forms.DataGridView();
            this.lblNoActivities = new System.Windows.Forms.Label();
            this.btnBookNow = new System.Windows.Forms.Button();
            this.pnlBook = new System.Windows.Forms.Panel();
            this.lblBookHeading = new System.Windows.Forms.Label();
            this.pnlBookCard = new System.Windows.Forms.Panel();
            this.lblBookName = new System.Windows.Forms.Label();
            this.lblBookCat = new System.Windows.Forms.Label();
            this.lblBookDate = new System.Windows.Forms.Label();
            this.lblBookPrice = new System.Windows.Forms.Label();
            this.lblBookSeatsVal = new System.Windows.Forms.Label();
            this.lblBookPaxCap = new System.Windows.Forms.Label();
            this.nudParticipants = new System.Windows.Forms.NumericUpDown();
            this.lblBookTotal = new System.Windows.Forms.Label();
            this.lblBookError = new System.Windows.Forms.Label();
            this.btnProceedPayment = new System.Windows.Forms.Button();
            this.btnCancelBook = new System.Windows.Forms.Button();
            this.pnlPayment = new System.Windows.Forms.Panel();
            this.lblPayHeading = new System.Windows.Forms.Label();
            this.pnlPaySummaryCard = new System.Windows.Forms.Panel();
            this.lblPaySummary = new System.Windows.Forms.Label();
            this.lblPayTotal = new System.Windows.Forms.Label();
            this.lblPayNotice = new System.Windows.Forms.Label();
            this.btnPayNow = new System.Windows.Forms.Button();
            this.btnCancelPay = new System.Windows.Forms.Button();
            this.pnlInvoice = new System.Windows.Forms.Panel();
            this.lblInvHeading = new System.Windows.Forms.Label();
            this.lblInvSub = new System.Windows.Forms.Label();
            this.rtbInvoice = new System.Windows.Forms.RichTextBox();
            this.btnPrintInvoice = new System.Windows.Forms.Button();
            this.btnSaveInvoice = new System.Windows.Forms.Button();
            this.btnMakeAnother = new System.Windows.Forms.Button();
            this.btnBackToDash = new System.Windows.Forms.Button();
            this.pnlMyBookings = new System.Windows.Forms.Panel();
            this.lblMyBookingsHeading = new System.Windows.Forms.Label();
            this.dgvMyBookings = new System.Windows.Forms.DataGridView();
            this.lblNoBookings = new System.Windows.Forms.Label();
            this.pnlProfile = new System.Windows.Forms.Panel();
            this.lblProfileHeading = new System.Windows.Forms.Label();
            this.lblProfileSub = new System.Windows.Forms.Label();
            this.lblProfileEmailCap = new System.Windows.Forms.Label();
            this.txtProfileEmail = new System.Windows.Forms.TextBox();
            this.lblProfilePhoneCap = new System.Windows.Forms.Label();
            this.txtProfilePhone = new System.Windows.Forms.TextBox();
            this.lblProfileNewPassCap = new System.Windows.Forms.Label();
            this.txtProfileNewPass = new System.Windows.Forms.TextBox();
            this.lblProfileConfirmCap = new System.Windows.Forms.Label();
            this.txtProfileConfirm = new System.Windows.Forms.TextBox();
            this.lblProfileError = new System.Windows.Forms.Label();
            this.btnSaveProfile = new System.Windows.Forms.Button();
            this.pnlSidebar.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlHome.SuspendLayout();
            this.cardBookings.SuspendLayout();
            this.cardUpcoming.SuspendLayout();
            this.pnlBrowse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivities)).BeginInit();
            this.pnlBook.SuspendLayout();
            this.pnlBookCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudParticipants)).BeginInit();
            this.pnlPayment.SuspendLayout();
            this.pnlPaySummaryCard.SuspendLayout();
            this.pnlInvoice.SuspendLayout();
            this.pnlMyBookings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyBookings)).BeginInit();
            this.pnlProfile.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(12)))), ((int)(((byte)(20)))));
            this.pnlSidebar.Controls.Add(this.pnlTop);
            this.pnlSidebar.Controls.Add(this.btnNavHome);
            this.pnlSidebar.Controls.Add(this.btnNavBrowse);
            this.pnlSidebar.Controls.Add(this.btnNavMyBookings);
            this.pnlSidebar.Controls.Add(this.btnNavProfile);
            this.pnlSidebar.Controls.Add(this.btnNavChatbot);
            this.pnlSidebar.Controls.Add(this.btnNavContactUs);
            this.pnlSidebar.Controls.Add(this.pnlDivider);
            this.pnlSidebar.Controls.Add(this.btnNavLogout);
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(16)))));
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(220, 750);
            this.pnlSidebar.TabIndex = 0;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(28)))));
            this.pnlTop.Controls.Add(this.lblBrandTitle);
            this.pnlTop.Controls.Add(this.lblPortalSub);
            this.pnlTop.Controls.Add(this.lblSidebarUser);
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(220, 130);
            this.pnlTop.TabIndex = 0;
            // 
            // lblBrandTitle
            // 
            this.lblBrandTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBrandTitle.ForeColor = System.Drawing.Color.White;
            this.lblBrandTitle.Location = new System.Drawing.Point(10, 14);
            this.lblBrandTitle.Name = "lblBrandTitle";
            this.lblBrandTitle.Size = new System.Drawing.Size(200, 28);
            this.lblBrandTitle.TabIndex = 0;
            this.lblBrandTitle.Text = "Blue Horizons Tours";
            this.lblBrandTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPortalSub
            // 
            this.lblPortalSub.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPortalSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.lblPortalSub.Location = new System.Drawing.Point(10, 46);
            this.lblPortalSub.Name = "lblPortalSub";
            this.lblPortalSub.Size = new System.Drawing.Size(200, 18);
            this.lblPortalSub.TabIndex = 1;
            this.lblPortalSub.Text = "VISITOR PORTAL";
            this.lblPortalSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSidebarUser
            // 
            this.lblSidebarUser.AutoEllipsis = true;
            this.lblSidebarUser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSidebarUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblSidebarUser.Location = new System.Drawing.Point(10, 74);
            this.lblSidebarUser.Name = "lblSidebarUser";
            this.lblSidebarUser.Size = new System.Drawing.Size(200, 40);
            this.lblSidebarUser.TabIndex = 2;
            this.lblSidebarUser.Text = "Welcome, Visitor";
            this.lblSidebarUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNavHome
            // 
            this.btnNavHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(44)))));
            this.btnNavHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavHome.FlatAppearance.BorderSize = 0;
            this.btnNavHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavHome.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNavHome.ForeColor = System.Drawing.Color.White;
            this.btnNavHome.Location = new System.Drawing.Point(0, 130);
            this.btnNavHome.Name = "btnNavHome";
            this.btnNavHome.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnNavHome.Size = new System.Drawing.Size(220, 52);
            this.btnNavHome.TabIndex = 1;
            this.btnNavHome.Text = "🏠  Home";
            this.btnNavHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavHome.UseVisualStyleBackColor = false;
            this.btnNavHome.Click += new System.EventHandler(this.btnNavHome_Click);
            // 
            // btnNavBrowse
            // 
            this.btnNavBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(16)))));
            this.btnNavBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavBrowse.FlatAppearance.BorderSize = 0;
            this.btnNavBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavBrowse.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavBrowse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(201)))), ((int)(((byte)(255)))));
            this.btnNavBrowse.Location = new System.Drawing.Point(0, 182);
            this.btnNavBrowse.Name = "btnNavBrowse";
            this.btnNavBrowse.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnNavBrowse.Size = new System.Drawing.Size(220, 52);
            this.btnNavBrowse.TabIndex = 2;
            this.btnNavBrowse.Text = "🌍  Browse Activities";
            this.btnNavBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavBrowse.UseVisualStyleBackColor = false;
            this.btnNavBrowse.Click += new System.EventHandler(this.btnNavBrowse_Click);
            // 
            // btnNavMyBookings
            // 
            this.btnNavMyBookings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(16)))));
            this.btnNavMyBookings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavMyBookings.FlatAppearance.BorderSize = 0;
            this.btnNavMyBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavMyBookings.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavMyBookings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(201)))), ((int)(((byte)(255)))));
            this.btnNavMyBookings.Location = new System.Drawing.Point(0, 234);
            this.btnNavMyBookings.Name = "btnNavMyBookings";
            this.btnNavMyBookings.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnNavMyBookings.Size = new System.Drawing.Size(220, 52);
            this.btnNavMyBookings.TabIndex = 3;
            this.btnNavMyBookings.Text = "📋  My Bookings";
            this.btnNavMyBookings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavMyBookings.UseVisualStyleBackColor = false;
            this.btnNavMyBookings.Click += new System.EventHandler(this.btnNavMyBookings_Click);
            // 
            // btnNavProfile
            // 
            this.btnNavProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(16)))));
            this.btnNavProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavProfile.FlatAppearance.BorderSize = 0;
            this.btnNavProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavProfile.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(201)))), ((int)(((byte)(255)))));
            this.btnNavProfile.Location = new System.Drawing.Point(0, 286);
            this.btnNavProfile.Name = "btnNavProfile";
            this.btnNavProfile.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnNavProfile.Size = new System.Drawing.Size(220, 52);
            this.btnNavProfile.TabIndex = 4;
            this.btnNavProfile.Text = "👤  My Profile";
            this.btnNavProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavProfile.UseVisualStyleBackColor = false;
            this.btnNavProfile.Click += new System.EventHandler(this.btnNavProfile_Click);
            // 
            // btnNavChatbot
            // 
            this.btnNavChatbot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(24)))), ((int)(((byte)(40)))));
            this.btnNavChatbot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavChatbot.FlatAppearance.BorderSize = 0;
            this.btnNavChatbot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavChatbot.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNavChatbot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.btnNavChatbot.Location = new System.Drawing.Point(0, 338);
            this.btnNavChatbot.Name = "btnNavChatbot";
            this.btnNavChatbot.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnNavChatbot.Size = new System.Drawing.Size(220, 52);
            this.btnNavChatbot.TabIndex = 7;
            this.btnNavChatbot.Text = "🦁  SafariScout AI";
            this.btnNavChatbot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavChatbot.UseVisualStyleBackColor = false;
            this.btnNavChatbot.Click += new System.EventHandler(this.btnNavChatbot_Click);
            // 
            // btnNavContactUs
            // 
            this.btnNavContactUs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(16)))));
            this.btnNavContactUs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavContactUs.FlatAppearance.BorderSize = 0;
            this.btnNavContactUs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavContactUs.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavContactUs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(201)))), ((int)(((byte)(255)))));
            this.btnNavContactUs.Location = new System.Drawing.Point(0, 390);
            this.btnNavContactUs.Name = "btnNavContactUs";
            this.btnNavContactUs.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnNavContactUs.Size = new System.Drawing.Size(220, 52);
            this.btnNavContactUs.TabIndex = 8;
            this.btnNavContactUs.Text = "✉  Contact Us";
            this.btnNavContactUs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavContactUs.UseVisualStyleBackColor = false;
            this.btnNavContactUs.Click += new System.EventHandler(this.btnNavContactUs_Click);
            // 
            // btnFloatingChat
            // 
            this.btnFloatingChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.btnFloatingChat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFloatingChat.FlatAppearance.BorderSize = 0;
            this.btnFloatingChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFloatingChat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnFloatingChat.ForeColor = System.Drawing.Color.White;
            this.btnFloatingChat.Location = new System.Drawing.Point(736, 686);
            this.btnFloatingChat.Name = "btnFloatingChat";
            this.btnFloatingChat.Size = new System.Drawing.Size(224, 48);
            this.btnFloatingChat.TabIndex = 99;
            this.btnFloatingChat.Text = "🧭 SafariScout AI Chat";
            this.btnFloatingChat.UseVisualStyleBackColor = false;
            this.btnFloatingChat.Click += new System.EventHandler(this.btnNavChatbot_Click);
            // 
            // pnlDivider
            // 
            this.pnlDivider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(56)))));
            this.pnlDivider.Location = new System.Drawing.Point(10, 690);
            this.pnlDivider.Name = "pnlDivider";
            this.pnlDivider.Size = new System.Drawing.Size(200, 1);
            this.pnlDivider.TabIndex = 5;
            // 
            // btnNavLogout
            // 
            this.btnNavLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(38)))), ((int)(((byte)(52)))));
            this.btnNavLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavLogout.FlatAppearance.BorderSize = 0;
            this.btnNavLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNavLogout.ForeColor = System.Drawing.Color.White;
            this.btnNavLogout.Location = new System.Drawing.Point(0, 698);
            this.btnNavLogout.Name = "btnNavLogout";
            this.btnNavLogout.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnNavLogout.Size = new System.Drawing.Size(220, 52);
            this.btnNavLogout.TabIndex = 6;
            this.btnNavLogout.Text = "🚪  Sign Out";
            this.btnNavLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavLogout.UseVisualStyleBackColor = false;
            this.btnNavLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(16)))));
            this.pnlContent.Controls.Add(this.btnFloatingChat);
            this.pnlContent.Controls.Add(this.pnlHome);
            this.pnlContent.Controls.Add(this.pnlBrowse);
            this.pnlContent.Controls.Add(this.pnlBook);
            this.pnlContent.Controls.Add(this.pnlPayment);
            this.pnlContent.Controls.Add(this.pnlInvoice);
            this.pnlContent.Controls.Add(this.pnlMyBookings);
            this.pnlContent.Controls.Add(this.pnlProfile);
            this.pnlContent.Controls.Add(this.pnlContactUs);
            this.pnlContent.Location = new System.Drawing.Point(220, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(980, 750);
            this.pnlContent.TabIndex = 1;
            // 
            // pnlHome
            // 
            this.pnlHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(16)))));
            this.pnlHome.Controls.Add(this.lblHomeWelcome);
            this.pnlHome.Controls.Add(this.lblHomeSub);
            this.pnlHome.Controls.Add(this.pnlHomeMeta);
            this.pnlHome.Controls.Add(this.cardBookings);
            this.pnlHome.Controls.Add(this.cardUpcoming);
            this.pnlHome.Controls.Add(this.lblHomePrompt);
            this.pnlHome.Controls.Add(this.btnQuickBrowse);
            this.pnlHome.Controls.Add(this.pnlHomeAnalytics);
            this.pnlHome.Location = new System.Drawing.Point(0, 0);
            this.pnlHome.Name = "pnlHome";
            this.pnlHome.Size = new System.Drawing.Size(980, 750);
            this.pnlHome.TabIndex = 0;
            this.pnlHome.Visible = true;
            // 
            // lblHomeWelcome
            // 
            this.lblHomeWelcome.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblHomeWelcome.ForeColor = System.Drawing.Color.White;
            this.lblHomeWelcome.Location = new System.Drawing.Point(40, 40);
            this.lblHomeWelcome.Name = "lblHomeWelcome";
            this.lblHomeWelcome.Size = new System.Drawing.Size(520, 44);
            this.lblHomeWelcome.TabIndex = 0;
            this.lblHomeWelcome.Text = "Welcome back!";
            // 
            // lblHomeSub
            // 
            this.lblHomeSub.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHomeSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(205)))));
            this.lblHomeSub.Location = new System.Drawing.Point(40, 88);
            this.lblHomeSub.Name = "lblHomeSub";
            this.lblHomeSub.Size = new System.Drawing.Size(520, 26);
            this.lblHomeSub.TabIndex = 1;
            this.lblHomeSub.Text = "Explore Cape Town\'s finest tours and experiences.";
            // 
            // pnlHomeMeta
            // 
            this.pnlHomeMeta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(20)))), ((int)(((byte)(34)))));
            this.pnlHomeMeta.Controls.Add(this.lblDashboardLocation);
            this.pnlHomeMeta.Controls.Add(this.lblDashboardClock);
            this.pnlHomeMeta.Location = new System.Drawing.Point(580, 36);
            this.pnlHomeMeta.Name = "pnlHomeMeta";
            this.pnlHomeMeta.Size = new System.Drawing.Size(360, 78);
            this.pnlHomeMeta.TabIndex = 7;
            // 
            // lblDashboardLocation
            // 
            this.lblDashboardLocation.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDashboardLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.lblDashboardLocation.Location = new System.Drawing.Point(10, 8);
            this.lblDashboardLocation.Name = "lblDashboardLocation";
            this.lblDashboardLocation.Size = new System.Drawing.Size(340, 24);
            this.lblDashboardLocation.TabIndex = 0;
            this.lblDashboardLocation.Text = "📍 Durban, KwaZulu-Natal";
            this.lblDashboardLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDashboardClock
            // 
            this.lblDashboardClock.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDashboardClock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblDashboardClock.Location = new System.Drawing.Point(10, 34);
            this.lblDashboardClock.Name = "lblDashboardClock";
            this.lblDashboardClock.Size = new System.Drawing.Size(340, 34);
            this.lblDashboardClock.TabIndex = 1;
            this.lblDashboardClock.Text = "12:00:00";
            this.lblDashboardClock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cardBookings
            // 
            this.cardBookings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
            this.cardBookings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cardBookings.Controls.Add(this.lblHomeBookingsCount);
            this.cardBookings.Controls.Add(this.lblHomeBookingsCap);
            this.cardBookings.Location = new System.Drawing.Point(40, 150);
            this.cardBookings.Name = "cardBookings";
            this.cardBookings.Size = new System.Drawing.Size(240, 128);
            this.cardBookings.TabIndex = 2;
            // 
            // lblHomeBookingsCount
            // 
            this.lblHomeBookingsCount.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblHomeBookingsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblHomeBookingsCount.Location = new System.Drawing.Point(8, 10);
            this.lblHomeBookingsCount.Name = "lblHomeBookingsCount";
            this.lblHomeBookingsCount.Size = new System.Drawing.Size(224, 60);
            this.lblHomeBookingsCount.TabIndex = 0;
            this.lblHomeBookingsCount.Text = "0";
            this.lblHomeBookingsCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHomeBookingsCap
            // 
            this.lblHomeBookingsCap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHomeBookingsCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(205)))));
            this.lblHomeBookingsCap.Location = new System.Drawing.Point(8, 76);
            this.lblHomeBookingsCap.Name = "lblHomeBookingsCap";
            this.lblHomeBookingsCap.Size = new System.Drawing.Size(224, 30);
            this.lblHomeBookingsCap.TabIndex = 1;
            this.lblHomeBookingsCap.Text = "Total Bookings";
            this.lblHomeBookingsCap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardUpcoming
            // 
            this.cardUpcoming.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
            this.cardUpcoming.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cardUpcoming.Controls.Add(this.lblHomeUpcomingCount);
            this.cardUpcoming.Controls.Add(this.lblHomeUpcomingCap);
            this.cardUpcoming.Location = new System.Drawing.Point(310, 150);
            this.cardUpcoming.Name = "cardUpcoming";
            this.cardUpcoming.Size = new System.Drawing.Size(240, 128);
            this.cardUpcoming.TabIndex = 3;
            // 
            // lblHomeUpcomingCount
            // 
            this.lblHomeUpcomingCount.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblHomeUpcomingCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.lblHomeUpcomingCount.Location = new System.Drawing.Point(8, 10);
            this.lblHomeUpcomingCount.Name = "lblHomeUpcomingCount";
            this.lblHomeUpcomingCount.Size = new System.Drawing.Size(224, 60);
            this.lblHomeUpcomingCount.TabIndex = 0;
            this.lblHomeUpcomingCount.Text = "0";
            this.lblHomeUpcomingCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHomeUpcomingCap
            // 
            this.lblHomeUpcomingCap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHomeUpcomingCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(205)))));
            this.lblHomeUpcomingCap.Location = new System.Drawing.Point(8, 76);
            this.lblHomeUpcomingCap.Name = "lblHomeUpcomingCap";
            this.lblHomeUpcomingCap.Size = new System.Drawing.Size(224, 30);
            this.lblHomeUpcomingCap.TabIndex = 1;
            this.lblHomeUpcomingCap.Text = "Upcoming Activities";
            this.lblHomeUpcomingCap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHomePrompt
            // 
            this.lblHomePrompt.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblHomePrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(205)))));
            this.lblHomePrompt.Location = new System.Drawing.Point(40, 320);
            this.lblHomePrompt.Name = "lblHomePrompt";
            this.lblHomePrompt.Size = new System.Drawing.Size(880, 26);
            this.lblHomePrompt.TabIndex = 4;
            this.lblHomePrompt.Text = "Ready to plan your next adventure?";
            // 
            // btnQuickBrowse
            // 
            this.btnQuickBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnQuickBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickBrowse.FlatAppearance.BorderSize = 0;
            this.btnQuickBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickBrowse.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnQuickBrowse.ForeColor = System.Drawing.Color.White;
            this.btnQuickBrowse.Location = new System.Drawing.Point(40, 356);
            this.btnQuickBrowse.Name = "btnQuickBrowse";
            this.btnQuickBrowse.Size = new System.Drawing.Size(360, 50);
            this.btnQuickBrowse.TabIndex = 5;
            this.btnQuickBrowse.Text = "   Browse && Book Activities  →";
            this.btnQuickBrowse.UseVisualStyleBackColor = false;
            this.btnQuickBrowse.Click += new System.EventHandler(this.btnQuickBrowse_Click);
            // 
            // pnlHomeAnalytics
            // 
            this.pnlHomeAnalytics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(19)))), ((int)(((byte)(30)))));
            this.pnlHomeAnalytics.Location = new System.Drawing.Point(40, 420);
            this.pnlHomeAnalytics.Name = "pnlHomeAnalytics";
            this.pnlHomeAnalytics.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlHomeAnalytics_Paint);
            this.pnlHomeAnalytics.Size = new System.Drawing.Size(900, 260);
            this.pnlHomeAnalytics.TabIndex = 6;
            // 
            // pnlBrowse
            // 
            this.pnlBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(16)))));
            this.pnlBrowse.Controls.Add(this.lblBrowseHeading);
            this.pnlBrowse.Controls.Add(this.lblBrowseCatCap);
            this.pnlBrowse.Controls.Add(this.cboCategoryFilter);
            this.pnlBrowse.Controls.Add(this.lblBrowseSearchCap);
            this.pnlBrowse.Controls.Add(this.txtSearch);
            this.pnlBrowse.Controls.Add(this.pnlAccordionGallery);
            this.pnlBrowse.Controls.Add(this.dgvActivities);
            this.pnlBrowse.Controls.Add(this.lblNoActivities);
            this.pnlBrowse.Controls.Add(this.btnBookNow);
            this.pnlBrowse.Location = new System.Drawing.Point(0, 0);
            this.pnlBrowse.Name = "pnlBrowse";
            this.pnlBrowse.Size = new System.Drawing.Size(980, 750);
            this.pnlBrowse.TabIndex = 1;
            this.pnlBrowse.Visible = false;
            // 
            // lblBrowseHeading
            // 
            this.lblBrowseHeading.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblBrowseHeading.ForeColor = System.Drawing.Color.White;
            this.lblBrowseHeading.Location = new System.Drawing.Point(20, 18);
            this.lblBrowseHeading.Name = "lblBrowseHeading";
            this.lblBrowseHeading.Size = new System.Drawing.Size(600, 40);
            this.lblBrowseHeading.TabIndex = 0;
            this.lblBrowseHeading.Text = "Browse Activities";
            // 
            // lblBrowseCatCap
            // 
            this.lblBrowseCatCap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBrowseCatCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(205)))));
            this.lblBrowseCatCap.Location = new System.Drawing.Point(20, 68);
            this.lblBrowseCatCap.Name = "lblBrowseCatCap";
            this.lblBrowseCatCap.Size = new System.Drawing.Size(110, 18);
            this.lblBrowseCatCap.TabIndex = 1;
            this.lblBrowseCatCap.Text = "CATEGORY";
            // 
            // cboCategoryFilter
            // 
            this.cboCategoryFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.cboCategoryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoryFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCategoryFilter.ForeColor = System.Drawing.Color.White;
            this.cboCategoryFilter.Location = new System.Drawing.Point(20, 88);
            this.cboCategoryFilter.Name = "cboCategoryFilter";
            this.cboCategoryFilter.Size = new System.Drawing.Size(200, 30);
            this.cboCategoryFilter.TabIndex = 2;
            this.cboCategoryFilter.SelectedIndexChanged += new System.EventHandler(this.cboCategoryFilter_SelectedIndexChanged);
            // 
            // lblBrowseSearchCap
            // 
            this.lblBrowseSearchCap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBrowseSearchCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(205)))));
            this.lblBrowseSearchCap.Location = new System.Drawing.Point(240, 68);
            this.lblBrowseSearchCap.Name = "lblBrowseSearchCap";
            this.lblBrowseSearchCap.Size = new System.Drawing.Size(110, 18);
            this.lblBrowseSearchCap.TabIndex = 3;
            this.lblBrowseSearchCap.Text = "SEARCH";
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.ForeColor = System.Drawing.Color.White;
            this.txtSearch.Location = new System.Drawing.Point(240, 88);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(280, 30);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // pnlAccordionGallery
            // 
            this.pnlAccordionGallery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(14)))), ((int)(((byte)(24)))));
            this.pnlAccordionGallery.Location = new System.Drawing.Point(20, 126);
            this.pnlAccordionGallery.Name = "pnlAccordionGallery";
            this.pnlAccordionGallery.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlAccordionGallery_Paint);
            this.pnlAccordionGallery.Size = new System.Drawing.Size(940, 556);
            this.pnlAccordionGallery.TabIndex = 8;
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
            this.dgvActivities.EnableHeadersVisualStyles = false;
            this.dgvActivities.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(56)))));
            this.dgvActivities.Location = new System.Drawing.Point(20, 130);
            this.dgvActivities.MultiSelect = false;
            this.dgvActivities.Name = "dgvActivities";
            this.dgvActivities.ReadOnly = true;
            this.dgvActivities.RowHeadersVisible = false;
            this.dgvActivities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActivities.Size = new System.Drawing.Size(940, 556);
            this.dgvActivities.TabIndex = 5;
            this.dgvActivities.Visible = false;
            // 
            // lblNoActivities
            // 
            this.lblNoActivities.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNoActivities.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(205)))));
            this.lblNoActivities.Location = new System.Drawing.Point(20, 340);
            this.lblNoActivities.Name = "lblNoActivities";
            this.lblNoActivities.Size = new System.Drawing.Size(940, 30);
            this.lblNoActivities.TabIndex = 6;
            this.lblNoActivities.Text = "No activities match your filter.";
            this.lblNoActivities.Visible = false;
            // 
            // btnBookNow
            // 
            this.btnBookNow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnBookNow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBookNow.FlatAppearance.BorderSize = 0;
            this.btnBookNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookNow.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBookNow.ForeColor = System.Drawing.Color.White;
            this.btnBookNow.Location = new System.Drawing.Point(20, 696);
            this.btnBookNow.Name = "btnBookNow";
            this.btnBookNow.Size = new System.Drawing.Size(400, 44);
            this.btnBookNow.TabIndex = 7;
            this.btnBookNow.Text = "Book Selected Activity";
            this.btnBookNow.UseVisualStyleBackColor = false;
            this.btnBookNow.Click += new System.EventHandler(this.btnBookNow_Click);
            // 
            // pnlBook
            // 
            this.pnlBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(16)))));
            this.pnlBook.Controls.Add(this.lblBookHeading);
            this.pnlBook.Controls.Add(this.pnlBookCard);
            this.pnlBook.Controls.Add(this.lblBookPaxCap);
            this.pnlBook.Controls.Add(this.nudParticipants);
            this.pnlBook.Controls.Add(this.lblBookTotal);
            this.pnlBook.Controls.Add(this.lblBookError);
            this.pnlBook.Controls.Add(this.btnProceedPayment);
            this.pnlBook.Controls.Add(this.btnCancelBook);
            this.pnlBook.Location = new System.Drawing.Point(0, 0);
            this.pnlBook.Name = "pnlBook";
            this.pnlBook.Size = new System.Drawing.Size(980, 750);
            this.pnlBook.TabIndex = 2;
            this.pnlBook.Visible = false;
            // 
            // lblBookHeading
            // 
            this.lblBookHeading.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblBookHeading.ForeColor = System.Drawing.Color.White;
            this.lblBookHeading.Location = new System.Drawing.Point(30, 20);
            this.lblBookHeading.Name = "lblBookHeading";
            this.lblBookHeading.Size = new System.Drawing.Size(700, 42);
            this.lblBookHeading.TabIndex = 0;
            this.lblBookHeading.Text = "Book Activity";
            // 
            // pnlBookCard
            // 
            this.pnlBookCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
            this.pnlBookCard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlBookCard.Controls.Add(this.lblBookName);
            this.pnlBookCard.Controls.Add(this.lblBookCat);
            this.pnlBookCard.Controls.Add(this.lblBookDate);
            this.pnlBookCard.Controls.Add(this.lblBookPrice);
            this.pnlBookCard.Controls.Add(this.lblBookSeatsVal);
            this.pnlBookCard.Location = new System.Drawing.Point(30, 72);
            this.pnlBookCard.Name = "pnlBookCard";
            this.pnlBookCard.Size = new System.Drawing.Size(560, 220);
            this.pnlBookCard.TabIndex = 1;
            // 
            // lblBookName
            // 
            this.lblBookName.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblBookName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.lblBookName.Location = new System.Drawing.Point(14, 12);
            this.lblBookName.Name = "lblBookName";
            this.lblBookName.Size = new System.Drawing.Size(530, 36);
            this.lblBookName.TabIndex = 0;
            // 
            // lblBookCat
            // 
            this.lblBookCat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBookCat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(205)))));
            this.lblBookCat.Location = new System.Drawing.Point(14, 52);
            this.lblBookCat.Name = "lblBookCat";
            this.lblBookCat.Size = new System.Drawing.Size(530, 22);
            this.lblBookCat.TabIndex = 1;
            // 
            // lblBookDate
            // 
            this.lblBookDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBookDate.ForeColor = System.Drawing.Color.White;
            this.lblBookDate.Location = new System.Drawing.Point(14, 78);
            this.lblBookDate.Name = "lblBookDate";
            this.lblBookDate.Size = new System.Drawing.Size(530, 22);
            this.lblBookDate.TabIndex = 2;
            // 
            // lblBookPrice
            // 
            this.lblBookPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBookPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblBookPrice.Location = new System.Drawing.Point(14, 108);
            this.lblBookPrice.Name = "lblBookPrice";
            this.lblBookPrice.Size = new System.Drawing.Size(530, 28);
            this.lblBookPrice.TabIndex = 3;
            // 
            // lblBookSeatsVal
            // 
            this.lblBookSeatsVal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBookSeatsVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(205)))));
            this.lblBookSeatsVal.Location = new System.Drawing.Point(14, 140);
            this.lblBookSeatsVal.Name = "lblBookSeatsVal";
            this.lblBookSeatsVal.Size = new System.Drawing.Size(530, 22);
            this.lblBookSeatsVal.TabIndex = 4;
            // 
            // lblBookPaxCap
            // 
            this.lblBookPaxCap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBookPaxCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(205)))));
            this.lblBookPaxCap.Location = new System.Drawing.Point(30, 308);
            this.lblBookPaxCap.Name = "lblBookPaxCap";
            this.lblBookPaxCap.Size = new System.Drawing.Size(300, 18);
            this.lblBookPaxCap.TabIndex = 2;
            this.lblBookPaxCap.Text = "NUMBER OF PARTICIPANTS";
            // 
            // nudParticipants
            // 
            this.nudParticipants.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.nudParticipants.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudParticipants.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudParticipants.ForeColor = System.Drawing.Color.White;
            this.nudParticipants.Location = new System.Drawing.Point(30, 328);
            this.nudParticipants.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudParticipants.Name = "nudParticipants";
            this.nudParticipants.Size = new System.Drawing.Size(120, 32);
            this.nudParticipants.TabIndex = 3;
            this.nudParticipants.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudParticipants.ValueChanged += new System.EventHandler(this.nudParticipants_ValueChanged);
            // 
            // lblBookTotal
            // 
            this.lblBookTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBookTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblBookTotal.Location = new System.Drawing.Point(170, 328);
            this.lblBookTotal.Name = "lblBookTotal";
            this.lblBookTotal.Size = new System.Drawing.Size(340, 32);
            this.lblBookTotal.TabIndex = 4;
            this.lblBookTotal.Text = "Total: R0.00";
            // 
            // lblBookError
            // 
            this.lblBookError.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblBookError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.lblBookError.Location = new System.Drawing.Point(30, 372);
            this.lblBookError.Name = "lblBookError";
            this.lblBookError.Size = new System.Drawing.Size(600, 20);
            this.lblBookError.TabIndex = 5;
            this.lblBookError.Visible = false;
            // 
            // btnProceedPayment
            // 
            this.btnProceedPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.btnProceedPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProceedPayment.FlatAppearance.BorderSize = 0;
            this.btnProceedPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProceedPayment.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnProceedPayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(16)))));
            this.btnProceedPayment.Location = new System.Drawing.Point(30, 400);
            this.btnProceedPayment.Name = "btnProceedPayment";
            this.btnProceedPayment.Size = new System.Drawing.Size(300, 46);
            this.btnProceedPayment.TabIndex = 6;
            this.btnProceedPayment.Text = "Proceed to Payment  →";
            this.btnProceedPayment.UseVisualStyleBackColor = false;
            this.btnProceedPayment.Click += new System.EventHandler(this.btnProceedPayment_Click);
            // 
            // btnCancelBook
            // 
            this.btnCancelBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(44)))));
            this.btnCancelBook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelBook.FlatAppearance.BorderSize = 0;
            this.btnCancelBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelBook.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancelBook.ForeColor = System.Drawing.Color.White;
            this.btnCancelBook.Location = new System.Drawing.Point(348, 400);
            this.btnCancelBook.Name = "btnCancelBook";
            this.btnCancelBook.Size = new System.Drawing.Size(130, 46);
            this.btnCancelBook.TabIndex = 7;
            this.btnCancelBook.Text = "Cancel";
            this.btnCancelBook.UseVisualStyleBackColor = false;
            this.btnCancelBook.Click += new System.EventHandler(this.btnCancelBook_Click);
            // 
            // pnlPayment
            // 
            this.pnlPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(16)))));
            this.pnlPayment.Controls.Add(this.lblPayHeading);
            this.pnlPayment.Controls.Add(this.pnlPaySummaryCard);
            this.pnlPayment.Controls.Add(this.pnlCardEntry);
            this.pnlPayment.Controls.Add(this.lblPayNotice);
            this.pnlPayment.Controls.Add(this.btnPayNow);
            this.pnlPayment.Controls.Add(this.btnCancelPay);
            this.pnlPayment.Location = new System.Drawing.Point(0, 0);
            this.pnlPayment.Name = "pnlPayment";
            this.pnlPayment.Size = new System.Drawing.Size(980, 750);
            this.pnlPayment.TabIndex = 3;
            this.pnlPayment.Visible = false;
            // 
            // lblPayHeading
            // 
            this.lblPayHeading.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblPayHeading.ForeColor = System.Drawing.Color.White;
            this.lblPayHeading.Location = new System.Drawing.Point(30, 20);
            this.lblPayHeading.Name = "lblPayHeading";
            this.lblPayHeading.Size = new System.Drawing.Size(700, 42);
            this.lblPayHeading.TabIndex = 0;
            this.lblPayHeading.Text = "Complete Payment";
            // 
            // pnlPaySummaryCard
            // 
            this.pnlPaySummaryCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
            this.pnlPaySummaryCard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlPaySummaryCard.Controls.Add(this.lblPaySummary);
            this.pnlPaySummaryCard.Controls.Add(this.lblPayTotal);
            this.pnlPaySummaryCard.Location = new System.Drawing.Point(30, 76);
            this.pnlPaySummaryCard.Name = "pnlPaySummaryCard";
            this.pnlPaySummaryCard.Size = new System.Drawing.Size(580, 220);
            this.pnlPaySummaryCard.TabIndex = 1;
            // 
            // lblPaySummary
            // 
            this.lblPaySummary.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblPaySummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblPaySummary.Location = new System.Drawing.Point(16, 16);
            this.lblPaySummary.Name = "lblPaySummary";
            this.lblPaySummary.Size = new System.Drawing.Size(548, 140);
            this.lblPaySummary.TabIndex = 0;
            // 
            // lblPayTotal
            // 
            this.lblPayTotal.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblPayTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblPayTotal.Location = new System.Drawing.Point(16, 158);
            this.lblPayTotal.Name = "lblPayTotal";
            this.lblPayTotal.Size = new System.Drawing.Size(548, 46);
            this.lblPayTotal.TabIndex = 1;
            this.lblPayTotal.Text = "TOTAL: R0.00";
            // 
            // lblPayNotice
            // 
            this.lblPayNotice.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPayNotice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(205)))));
            this.lblPayNotice.Location = new System.Drawing.Point(30, 308);
            this.lblPayNotice.Name = "lblPayNotice";
            this.lblPayNotice.Size = new System.Drawing.Size(600, 20);
            this.lblPayNotice.TabIndex = 2;
            this.lblPayNotice.Text = "🔒  This is a simulated payment – no real charges will be made.";
            // 
            // btnPayNow
            // 
            this.btnPayNow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnPayNow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPayNow.FlatAppearance.BorderSize = 0;
            this.btnPayNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayNow.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnPayNow.ForeColor = System.Drawing.Color.White;
            this.btnPayNow.Location = new System.Drawing.Point(30, 340);
            this.btnPayNow.Name = "btnPayNow";
            this.btnPayNow.Size = new System.Drawing.Size(300, 56);
            this.btnPayNow.TabIndex = 3;
            this.btnPayNow.Text = "  💳  PAY NOW";
            this.btnPayNow.UseVisualStyleBackColor = false;
            this.btnPayNow.Click += new System.EventHandler(this.btnPayNow_Click);
            // 
            // btnCancelPay
            // 
            this.btnCancelPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(44)))));
            this.btnCancelPay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelPay.FlatAppearance.BorderSize = 0;
            this.btnCancelPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelPay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancelPay.ForeColor = System.Drawing.Color.White;
            this.btnCancelPay.Location = new System.Drawing.Point(348, 348);
            this.btnCancelPay.Name = "btnCancelPay";
            this.btnCancelPay.Size = new System.Drawing.Size(180, 46);
            this.btnCancelPay.TabIndex = 4;
            this.btnCancelPay.Text = "Back to Activity";
            this.btnCancelPay.UseVisualStyleBackColor = false;
            this.btnCancelPay.Click += new System.EventHandler(this.btnCancelPay_Click);
            // 
            // pnlInvoice
            // 
            this.pnlInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(16)))));
            this.pnlInvoice.Controls.Add(this.lblInvHeading);
            this.pnlInvoice.Controls.Add(this.lblInvSub);
            this.pnlInvoice.Controls.Add(this.rtbInvoice);
            this.pnlInvoice.Controls.Add(this.btnPrintInvoice);
            this.pnlInvoice.Controls.Add(this.btnSaveInvoice);
            this.pnlInvoice.Controls.Add(this.btnOpenTicketsFolder);
            this.pnlInvoice.Controls.Add(this.btnMakeAnother);
            this.pnlInvoice.Controls.Add(this.btnBackToDash);
            this.pnlInvoice.Location = new System.Drawing.Point(0, 0);
            this.pnlInvoice.Name = "pnlInvoice";
            this.pnlInvoice.Size = new System.Drawing.Size(980, 750);
            this.pnlInvoice.TabIndex = 4;
            this.pnlInvoice.Visible = false;
            // 
            // lblInvHeading
            // 
            this.lblInvHeading.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblInvHeading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblInvHeading.Location = new System.Drawing.Point(30, 16);
            this.lblInvHeading.Name = "lblInvHeading";
            this.lblInvHeading.Size = new System.Drawing.Size(700, 42);
            this.lblInvHeading.TabIndex = 0;
            this.lblInvHeading.Text = "✅  Booking Confirmed!";
            // 
            // lblInvSub
            // 
            this.lblInvSub.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInvSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(205)))));
            this.lblInvSub.Location = new System.Drawing.Point(30, 58);
            this.lblInvSub.Name = "lblInvSub";
            this.lblInvSub.Size = new System.Drawing.Size(880, 22);
            this.lblInvSub.TabIndex = 1;
            this.lblInvSub.Text = "Your invoice has been saved. You can print or download it below.";
            // 
            // rtbInvoice
            // 
            this.rtbInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(16)))), ((int)(((byte)(26)))));
            this.rtbInvoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbInvoice.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.rtbInvoice.ForeColor = System.Drawing.Color.White;
            this.rtbInvoice.Location = new System.Drawing.Point(30, 88);
            this.rtbInvoice.Name = "rtbInvoice";
            this.rtbInvoice.ReadOnly = true;
            this.rtbInvoice.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbInvoice.Size = new System.Drawing.Size(620, 488);
            this.rtbInvoice.TabIndex = 2;
            this.rtbInvoice.Text = "";
            this.rtbInvoice.WordWrap = false;
            // 
            // btnPrintInvoice
            // 
            this.btnPrintInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.btnPrintInvoice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintInvoice.FlatAppearance.BorderSize = 0;
            this.btnPrintInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintInvoice.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnPrintInvoice.ForeColor = System.Drawing.Color.White;
            this.btnPrintInvoice.Location = new System.Drawing.Point(30, 590);
            this.btnPrintInvoice.Name = "btnPrintInvoice";
            this.btnPrintInvoice.Size = new System.Drawing.Size(200, 44);
            this.btnPrintInvoice.TabIndex = 3;
            this.btnPrintInvoice.Text = "🖨  Print Invoice";
            this.btnPrintInvoice.UseVisualStyleBackColor = false;
            this.btnPrintInvoice.Click += new System.EventHandler(this.btnPrintInvoice_Click);
            // 
            // btnSaveInvoice
            // 
            this.btnSaveInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.btnSaveInvoice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveInvoice.FlatAppearance.BorderSize = 0;
            this.btnSaveInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveInvoice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveInvoice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(16)))));
            this.btnSaveInvoice.Location = new System.Drawing.Point(244, 590);
            this.btnSaveInvoice.Name = "btnSaveInvoice";
            this.btnSaveInvoice.Size = new System.Drawing.Size(200, 44);
            this.btnSaveInvoice.TabIndex = 4;
            this.btnSaveInvoice.Text = "💾  Save as Text";
            this.btnSaveInvoice.UseVisualStyleBackColor = false;
            this.btnSaveInvoice.Click += new System.EventHandler(this.btnSaveInvoice_Click);
            // 
            // btnMakeAnother
            // 
            this.btnMakeAnother.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnMakeAnother.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMakeAnother.FlatAppearance.BorderSize = 0;
            this.btnMakeAnother.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMakeAnother.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnMakeAnother.ForeColor = System.Drawing.Color.White;
            this.btnMakeAnother.Location = new System.Drawing.Point(30, 648);
            this.btnMakeAnother.Name = "btnMakeAnother";
            this.btnMakeAnother.Size = new System.Drawing.Size(260, 44);
            this.btnMakeAnother.TabIndex = 5;
            this.btnMakeAnother.Text = "➕  Make Another Booking";
            this.btnMakeAnother.UseVisualStyleBackColor = false;
            this.btnMakeAnother.Click += new System.EventHandler(this.btnMakeAnother_Click);
            // 
            // btnBackToDash
            // 
            this.btnBackToDash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(44)))));
            this.btnBackToDash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackToDash.FlatAppearance.BorderSize = 0;
            this.btnBackToDash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackToDash.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBackToDash.ForeColor = System.Drawing.Color.White;
            this.btnBackToDash.Location = new System.Drawing.Point(304, 648);
            this.btnBackToDash.Name = "btnBackToDash";
            this.btnBackToDash.Size = new System.Drawing.Size(220, 44);
            this.btnBackToDash.TabIndex = 6;
            this.btnBackToDash.Text = "🏠  Back to Dashboard";
            this.btnBackToDash.UseVisualStyleBackColor = false;
            this.btnBackToDash.Click += new System.EventHandler(this.btnBackToDash_Click);
            // 
            // pnlMyBookings
            // 
            this.pnlMyBookings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(16)))));
            this.pnlMyBookings.Controls.Add(this.lblMyBookingsHeading);
            this.pnlMyBookings.Controls.Add(this.dgvMyBookings);
            this.pnlMyBookings.Controls.Add(this.lblNoBookings);
            this.pnlMyBookings.Location = new System.Drawing.Point(0, 0);
            this.pnlMyBookings.Name = "pnlMyBookings";
            this.pnlMyBookings.Size = new System.Drawing.Size(980, 750);
            this.pnlMyBookings.TabIndex = 5;
            this.pnlMyBookings.Visible = false;
            // 
            // lblMyBookingsHeading
            // 
            this.lblMyBookingsHeading.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblMyBookingsHeading.ForeColor = System.Drawing.Color.White;
            this.lblMyBookingsHeading.Location = new System.Drawing.Point(20, 18);
            this.lblMyBookingsHeading.Name = "lblMyBookingsHeading";
            this.lblMyBookingsHeading.Size = new System.Drawing.Size(700, 40);
            this.lblMyBookingsHeading.TabIndex = 0;
            this.lblMyBookingsHeading.Text = "My Bookings";
            // 
            // dgvMyBookings
            // 
            this.dgvMyBookings.AllowUserToAddRows = false;
            this.dgvMyBookings.AllowUserToDeleteRows = false;
            this.dgvMyBookings.AllowUserToResizeRows = false;
            this.dgvMyBookings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMyBookings.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(12)))), ((int)(((byte)(20)))));
            this.dgvMyBookings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMyBookings.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMyBookings.ColumnHeadersHeight = 34;
            this.dgvMyBookings.EnableHeadersVisualStyles = false;
            this.dgvMyBookings.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(56)))));
            this.dgvMyBookings.Location = new System.Drawing.Point(20, 68);
            this.dgvMyBookings.MultiSelect = false;
            this.dgvMyBookings.Name = "dgvMyBookings";
            this.dgvMyBookings.ReadOnly = true;
            this.dgvMyBookings.RowHeadersVisible = false;
            this.dgvMyBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMyBookings.Size = new System.Drawing.Size(940, 640);
            this.dgvMyBookings.TabIndex = 1;
            // 
            // lblNoBookings
            // 
            this.lblNoBookings.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNoBookings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(205)))));
            this.lblNoBookings.Location = new System.Drawing.Point(20, 380);
            this.lblNoBookings.Name = "lblNoBookings";
            this.lblNoBookings.Size = new System.Drawing.Size(940, 30);
            this.lblNoBookings.TabIndex = 2;
            this.lblNoBookings.Text = "You have no bookings yet.  Click \'Browse Activities\' to get started!";
            this.lblNoBookings.Visible = false;
            // 
            // pnlProfile
            // 
            this.pnlProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(16)))));
            this.pnlProfile.Controls.Add(this.lblProfileHeading);
            this.pnlProfile.Controls.Add(this.lblProfileSub);
            this.pnlProfile.Controls.Add(this.lblProfileEmailCap);
            this.pnlProfile.Controls.Add(this.txtProfileEmail);
            this.pnlProfile.Controls.Add(this.lblProfilePhoneCap);
            this.pnlProfile.Controls.Add(this.txtProfilePhone);
            this.pnlProfile.Controls.Add(this.lblProfileNewPassCap);
            this.pnlProfile.Controls.Add(this.txtProfileNewPass);
            this.pnlProfile.Controls.Add(this.lblProfileConfirmCap);
            this.pnlProfile.Controls.Add(this.txtProfileConfirm);
            this.pnlProfile.Controls.Add(this.lblProfileError);
            this.pnlProfile.Controls.Add(this.btnSaveProfile);
            this.pnlProfile.Location = new System.Drawing.Point(0, 0);
            this.pnlProfile.Name = "pnlProfile";
            this.pnlProfile.Size = new System.Drawing.Size(980, 750);
            this.pnlProfile.TabIndex = 6;
            this.pnlProfile.Visible = false;
            // 
            // lblProfileHeading
            // 
            this.lblProfileHeading.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblProfileHeading.ForeColor = System.Drawing.Color.White;
            this.lblProfileHeading.Location = new System.Drawing.Point(30, 20);
            this.lblProfileHeading.Name = "lblProfileHeading";
            this.lblProfileHeading.Size = new System.Drawing.Size(700, 42);
            this.lblProfileHeading.TabIndex = 0;
            this.lblProfileHeading.Text = "My Profile";
            // 
            // lblProfileSub
            // 
            this.lblProfileSub.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblProfileSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(205)))));
            this.lblProfileSub.Location = new System.Drawing.Point(30, 62);
            this.lblProfileSub.Name = "lblProfileSub";
            this.lblProfileSub.Size = new System.Drawing.Size(700, 24);
            this.lblProfileSub.TabIndex = 1;
            this.lblProfileSub.Text = "Update your contact details and optionally change your password.";
            // 
            // lblProfileEmailCap
            // 
            this.lblProfileEmailCap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProfileEmailCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(205)))));
            this.lblProfileEmailCap.Location = new System.Drawing.Point(30, 106);
            this.lblProfileEmailCap.Name = "lblProfileEmailCap";
            this.lblProfileEmailCap.Size = new System.Drawing.Size(200, 18);
            this.lblProfileEmailCap.TabIndex = 2;
            this.lblProfileEmailCap.Text = "EMAIL ADDRESS";
            // 
            // txtProfileEmail
            // 
            this.txtProfileEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.txtProfileEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProfileEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtProfileEmail.ForeColor = System.Drawing.Color.White;
            this.txtProfileEmail.Location = new System.Drawing.Point(30, 126);
            this.txtProfileEmail.Name = "txtProfileEmail";
            this.txtProfileEmail.Size = new System.Drawing.Size(500, 32);
            this.txtProfileEmail.TabIndex = 3;
            // 
            // lblProfilePhoneCap
            // 
            this.lblProfilePhoneCap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProfilePhoneCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(205)))));
            this.lblProfilePhoneCap.Location = new System.Drawing.Point(30, 178);
            this.lblProfilePhoneCap.Name = "lblProfilePhoneCap";
            this.lblProfilePhoneCap.Size = new System.Drawing.Size(200, 18);
            this.lblProfilePhoneCap.TabIndex = 4;
            this.lblProfilePhoneCap.Text = "PHONE NUMBER";
            // 
            // txtProfilePhone
            // 
            this.txtProfilePhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.txtProfilePhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProfilePhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtProfilePhone.ForeColor = System.Drawing.Color.White;
            this.txtProfilePhone.Location = new System.Drawing.Point(30, 198);
            this.txtProfilePhone.Name = "txtProfilePhone";
            this.txtProfilePhone.Size = new System.Drawing.Size(500, 32);
            this.txtProfilePhone.TabIndex = 5;
            // 
            // lblProfileNewPassCap
            // 
            this.lblProfileNewPassCap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProfileNewPassCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(205)))));
            this.lblProfileNewPassCap.Location = new System.Drawing.Point(30, 250);
            this.lblProfileNewPassCap.Name = "lblProfileNewPassCap";
            this.lblProfileNewPassCap.Size = new System.Drawing.Size(460, 18);
            this.lblProfileNewPassCap.TabIndex = 6;
            this.lblProfileNewPassCap.Text = "NEW PASSWORD  (leave blank to keep current)";
            // 
            // txtProfileNewPass
            // 
            this.txtProfileNewPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.txtProfileNewPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProfileNewPass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtProfileNewPass.ForeColor = System.Drawing.Color.White;
            this.txtProfileNewPass.Location = new System.Drawing.Point(30, 270);
            this.txtProfileNewPass.Name = "txtProfileNewPass";
            this.txtProfileNewPass.Size = new System.Drawing.Size(500, 32);
            this.txtProfileNewPass.TabIndex = 7;
            this.txtProfileNewPass.UseSystemPasswordChar = true;
            // 
            // lblProfileConfirmCap
            // 
            this.lblProfileConfirmCap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProfileConfirmCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(205)))));
            this.lblProfileConfirmCap.Location = new System.Drawing.Point(30, 322);
            this.lblProfileConfirmCap.Name = "lblProfileConfirmCap";
            this.lblProfileConfirmCap.Size = new System.Drawing.Size(300, 18);
            this.lblProfileConfirmCap.TabIndex = 8;
            this.lblProfileConfirmCap.Text = "CONFIRM NEW PASSWORD";
            // 
            // txtProfileConfirm
            // 
            this.txtProfileConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.txtProfileConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProfileConfirm.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtProfileConfirm.ForeColor = System.Drawing.Color.White;
            this.txtProfileConfirm.Location = new System.Drawing.Point(30, 342);
            this.txtProfileConfirm.Name = "txtProfileConfirm";
            this.txtProfileConfirm.Size = new System.Drawing.Size(500, 32);
            this.txtProfileConfirm.TabIndex = 9;
            this.txtProfileConfirm.UseSystemPasswordChar = true;
            // 
            // lblProfileError
            // 
            this.lblProfileError.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblProfileError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.lblProfileError.Location = new System.Drawing.Point(30, 394);
            this.lblProfileError.Name = "lblProfileError";
            this.lblProfileError.Size = new System.Drawing.Size(600, 20);
            this.lblProfileError.TabIndex = 10;
            this.lblProfileError.Visible = false;
            // 
            // btnSaveProfile
            // 
            this.btnSaveProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnSaveProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveProfile.FlatAppearance.BorderSize = 0;
            this.btnSaveProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveProfile.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSaveProfile.ForeColor = System.Drawing.Color.White;
            this.btnSaveProfile.Location = new System.Drawing.Point(30, 424);
            this.btnSaveProfile.Name = "btnSaveProfile";
            this.btnSaveProfile.Size = new System.Drawing.Size(260, 48);
            this.btnSaveProfile.TabIndex = 11;
            this.btnSaveProfile.Text = "Save Changes";
            this.btnSaveProfile.UseVisualStyleBackColor = false;
            this.btnSaveProfile.Click += new System.EventHandler(this.btnSaveProfile_Click);
            // 
            // pnlCardEntry
            // 
            this.pnlCardEntry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
            this.pnlCardEntry.Controls.Add(this.lblPayGuestNameCap);
            this.pnlCardEntry.Controls.Add(this.txtPayFullName);
            this.pnlCardEntry.Controls.Add(this.lblPayNameErr);
            this.pnlCardEntry.Controls.Add(this.lblPayGuestEmailCap);
            this.pnlCardEntry.Controls.Add(this.txtPayEmail);
            this.pnlCardEntry.Controls.Add(this.lblPayEmailErr);
            this.pnlCardEntry.Controls.Add(this.lblPayCardCap);
            this.pnlCardEntry.Controls.Add(this.txtCardNumber);
            this.pnlCardEntry.Controls.Add(this.btnFillDemoCard);
            this.pnlCardEntry.Controls.Add(this.lblPayCardErr);
            this.pnlCardEntry.Controls.Add(this.lblPayExpiryCap);
            this.pnlCardEntry.Controls.Add(this.txtCardMonth);
            this.pnlCardEntry.Controls.Add(this.txtCardYear);
            this.pnlCardEntry.Controls.Add(this.lblPayExpiryErr);
            this.pnlCardEntry.Controls.Add(this.lblPayCvcCap);
            this.pnlCardEntry.Controls.Add(this.txtCardCvc);
            this.pnlCardEntry.Controls.Add(this.lblPayCvcErr);
            this.pnlCardEntry.Location = new System.Drawing.Point(24, 282);
            this.pnlCardEntry.Name = "pnlCardEntry";
            this.pnlCardEntry.Size = new System.Drawing.Size(760, 224);
            this.pnlCardEntry.TabIndex = 10;
            // 
            // lblPayGuestNameCap
            // 
            this.lblPayGuestNameCap.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPayGuestNameCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(205)))));
            this.lblPayGuestNameCap.Location = new System.Drawing.Point(16, 12);
            this.lblPayGuestNameCap.Name = "lblPayGuestNameCap";
            this.lblPayGuestNameCap.Size = new System.Drawing.Size(320, 18);
            this.lblPayGuestNameCap.Text = "FULL NAME (TICKET HOLDER)";
            // 
            // txtPayFullName
            // 
            this.txtPayFullName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.txtPayFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPayFullName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPayFullName.ForeColor = System.Drawing.Color.White;
            this.txtPayFullName.Location = new System.Drawing.Point(16, 32);
            this.txtPayFullName.Name = "txtPayFullName";
            this.txtPayFullName.Size = new System.Drawing.Size(340, 28);
            // 
            // lblPayNameErr
            // 
            this.lblPayNameErr.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblPayNameErr.ForeColor = System.Drawing.Color.Red;
            this.lblPayNameErr.Location = new System.Drawing.Point(16, 62);
            this.lblPayNameErr.Name = "lblPayNameErr";
            this.lblPayNameErr.Size = new System.Drawing.Size(340, 16);
            this.lblPayNameErr.Visible = false;
            // 
            // lblPayGuestEmailCap
            // 
            this.lblPayGuestEmailCap.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPayGuestEmailCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(205)))));
            this.lblPayGuestEmailCap.Location = new System.Drawing.Point(380, 12);
            this.lblPayGuestEmailCap.Name = "lblPayGuestEmailCap";
            this.lblPayGuestEmailCap.Size = new System.Drawing.Size(340, 18);
            this.lblPayGuestEmailCap.Text = "EMAIL ADDRESS (FOR PDF TICKETS)";
            // 
            // txtPayEmail
            // 
            this.txtPayEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.txtPayEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPayEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPayEmail.ForeColor = System.Drawing.Color.White;
            this.txtPayEmail.Location = new System.Drawing.Point(380, 32);
            this.txtPayEmail.Name = "txtPayEmail";
            this.txtPayEmail.Size = new System.Drawing.Size(360, 28);
            // 
            // lblPayEmailErr
            // 
            this.lblPayEmailErr.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblPayEmailErr.ForeColor = System.Drawing.Color.Red;
            this.lblPayEmailErr.Location = new System.Drawing.Point(380, 62);
            this.lblPayEmailErr.Name = "lblPayEmailErr";
            this.lblPayEmailErr.Size = new System.Drawing.Size(360, 16);
            this.lblPayEmailErr.Visible = false;
            // 
            // lblPayCardCap
            // 
            this.lblPayCardCap.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPayCardCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(205)))));
            this.lblPayCardCap.Location = new System.Drawing.Point(16, 86);
            this.lblPayCardCap.Name = "lblPayCardCap";
            this.lblPayCardCap.Size = new System.Drawing.Size(340, 18);
            this.lblPayCardCap.Text = "CARD NUMBER (13-19 DIGITS • LUHN CHECK)";
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.txtCardNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCardNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCardNumber.ForeColor = System.Drawing.Color.White;
            this.txtCardNumber.Location = new System.Drawing.Point(16, 106);
            this.txtCardNumber.MaxLength = 23;
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Size = new System.Drawing.Size(340, 28);
            // 
            // btnFillDemoCard
            // 
            this.btnFillDemoCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(34)))), ((int)(((byte)(54)))));
            this.btnFillDemoCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFillDemoCard.FlatAppearance.BorderSize = 0;
            this.btnFillDemoCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFillDemoCard.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnFillDemoCard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.btnFillDemoCard.Location = new System.Drawing.Point(16, 158);
            this.btnFillDemoCard.Name = "btnFillDemoCard";
            this.btnFillDemoCard.Size = new System.Drawing.Size(210, 32);
            this.btnFillDemoCard.Text = "⚡ Fill Valid Demo Card";
            this.btnFillDemoCard.UseVisualStyleBackColor = false;
            this.btnFillDemoCard.Click += new System.EventHandler(this.btnFillDemoCard_Click);
            // 
            // lblPayCardErr
            // 
            this.lblPayCardErr.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblPayCardErr.ForeColor = System.Drawing.Color.Red;
            this.lblPayCardErr.Location = new System.Drawing.Point(16, 136);
            this.lblPayCardErr.Name = "lblPayCardErr";
            this.lblPayCardErr.Size = new System.Drawing.Size(340, 18);
            this.lblPayCardErr.Visible = false;
            // 
            // lblPayExpiryCap
            // 
            this.lblPayExpiryCap.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPayExpiryCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(205)))));
            this.lblPayExpiryCap.Location = new System.Drawing.Point(380, 86);
            this.lblPayExpiryCap.Name = "lblPayExpiryCap";
            this.lblPayExpiryCap.Size = new System.Drawing.Size(170, 18);
            this.lblPayExpiryCap.Text = "EXPIRY (MM / YY)";
            // 
            // txtCardMonth
            // 
            this.txtCardMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.txtCardMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCardMonth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCardMonth.ForeColor = System.Drawing.Color.White;
            this.txtCardMonth.Location = new System.Drawing.Point(380, 106);
            this.txtCardMonth.MaxLength = 2;
            this.txtCardMonth.Name = "txtCardMonth";
            this.txtCardMonth.Size = new System.Drawing.Size(72, 28);
            // 
            // txtCardYear
            // 
            this.txtCardYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.txtCardYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCardYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCardYear.ForeColor = System.Drawing.Color.White;
            this.txtCardYear.Location = new System.Drawing.Point(464, 106);
            this.txtCardYear.MaxLength = 4;
            this.txtCardYear.Name = "txtCardYear";
            this.txtCardYear.Size = new System.Drawing.Size(82, 28);
            // 
            // lblPayExpiryErr
            // 
            this.lblPayExpiryErr.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblPayExpiryErr.ForeColor = System.Drawing.Color.Red;
            this.lblPayExpiryErr.Location = new System.Drawing.Point(380, 136);
            this.lblPayExpiryErr.Name = "lblPayExpiryErr";
            this.lblPayExpiryErr.Size = new System.Drawing.Size(200, 18);
            this.lblPayExpiryErr.Visible = false;
            // 
            // lblPayCvcCap
            // 
            this.lblPayCvcCap.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPayCvcCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(205)))));
            this.lblPayCvcCap.Location = new System.Drawing.Point(588, 86);
            this.lblPayCvcCap.Name = "lblPayCvcCap";
            this.lblPayCvcCap.Size = new System.Drawing.Size(120, 18);
            this.lblPayCvcCap.Text = "CVC (3-4 DIGITS)";
            // 
            // txtCardCvc
            // 
            this.txtCardCvc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.txtCardCvc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCardCvc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCardCvc.ForeColor = System.Drawing.Color.White;
            this.txtCardCvc.Location = new System.Drawing.Point(588, 106);
            this.txtCardCvc.MaxLength = 4;
            this.txtCardCvc.Name = "txtCardCvc";
            this.txtCardCvc.Size = new System.Drawing.Size(96, 28);
            // 
            // lblPayCvcErr
            // 
            this.lblPayCvcErr.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblPayCvcErr.ForeColor = System.Drawing.Color.Red;
            this.lblPayCvcErr.Location = new System.Drawing.Point(588, 136);
            this.lblPayCvcErr.Name = "lblPayCvcErr";
            this.lblPayCvcErr.Size = new System.Drawing.Size(160, 18);
            this.lblPayCvcErr.Visible = false;
            // 
            // btnOpenTicketsFolder
            // 
            this.btnOpenTicketsFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.btnOpenTicketsFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenTicketsFolder.FlatAppearance.BorderSize = 0;
            this.btnOpenTicketsFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenTicketsFolder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOpenTicketsFolder.ForeColor = System.Drawing.Color.White;
            this.btnOpenTicketsFolder.Location = new System.Drawing.Point(458, 590);
            this.btnOpenTicketsFolder.Name = "btnOpenTicketsFolder";
            this.btnOpenTicketsFolder.Size = new System.Drawing.Size(210, 44);
            this.btnOpenTicketsFolder.TabIndex = 7;
            this.btnOpenTicketsFolder.Text = "🎫  Open PDF Tickets";
            this.btnOpenTicketsFolder.UseVisualStyleBackColor = false;
            this.btnOpenTicketsFolder.Click += new System.EventHandler(this.btnOpenTicketsFolder_Click);
            // 
            // pnlContactUs
            // 
            this.pnlContactUs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(16)))));
            this.pnlContactUs.Controls.Add(this.lblContactHeading);
            this.pnlContactUs.Controls.Add(this.lblContactSub);
            this.pnlContactUs.Controls.Add(this.pnlContactCard);
            this.pnlContactUs.Location = new System.Drawing.Point(0, 0);
            this.pnlContactUs.Name = "pnlContactUs";
            this.pnlContactUs.Size = new System.Drawing.Size(980, 750);
            this.pnlContactUs.TabIndex = 9;
            this.pnlContactUs.Visible = false;
            // 
            // lblContactHeading
            // 
            this.lblContactHeading.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblContactHeading.ForeColor = System.Drawing.Color.White;
            this.lblContactHeading.Location = new System.Drawing.Point(30, 20);
            this.lblContactHeading.Name = "lblContactHeading";
            this.lblContactHeading.Size = new System.Drawing.Size(700, 40);
            this.lblContactHeading.Text = "Contact Us";
            // 
            // lblContactSub
            // 
            this.lblContactSub.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblContactSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(205)))));
            this.lblContactSub.Location = new System.Drawing.Point(30, 60);
            this.lblContactSub.Name = "lblContactSub";
            this.lblContactSub.Size = new System.Drawing.Size(750, 24);
            this.lblContactSub.Text = "We are here to help you explore South Africa — send our ranger concierge team a message.";
            // 
            // pnlContactCard
            // 
            this.pnlContactCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
            this.pnlContactCard.Controls.Add(this.lblContactNameCap);
            this.pnlContactCard.Controls.Add(this.txtContactName);
            this.pnlContactCard.Controls.Add(this.lblContactEmailCap);
            this.pnlContactCard.Controls.Add(this.txtContactEmail);
            this.pnlContactCard.Controls.Add(this.lblContactSubjectCap);
            this.pnlContactCard.Controls.Add(this.cmbContactSubject);
            this.pnlContactCard.Controls.Add(this.lblContactMsgCap);
            this.pnlContactCard.Controls.Add(this.txtContactMessage);
            this.pnlContactCard.Controls.Add(this.btnSendContactMessage);
            this.pnlContactCard.Location = new System.Drawing.Point(30, 96);
            this.pnlContactCard.Name = "pnlContactCard";
            this.pnlContactCard.Size = new System.Drawing.Size(680, 520);
            // 
            // lblContactNameCap
            // 
            this.lblContactNameCap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblContactNameCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(205)))));
            this.lblContactNameCap.Location = new System.Drawing.Point(24, 22);
            this.lblContactNameCap.Name = "lblContactNameCap";
            this.lblContactNameCap.Size = new System.Drawing.Size(260, 18);
            this.lblContactNameCap.Text = "YOUR NAME";
            // 
            // txtContactName
            // 
            this.txtContactName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.txtContactName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContactName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtContactName.ForeColor = System.Drawing.Color.White;
            this.txtContactName.Location = new System.Drawing.Point(24, 44);
            this.txtContactName.Name = "txtContactName";
            this.txtContactName.Size = new System.Drawing.Size(610, 30);
            // 
            // lblContactEmailCap
            // 
            this.lblContactEmailCap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblContactEmailCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(205)))));
            this.lblContactEmailCap.Location = new System.Drawing.Point(24, 92);
            this.lblContactEmailCap.Name = "lblContactEmailCap";
            this.lblContactEmailCap.Size = new System.Drawing.Size(260, 18);
            this.lblContactEmailCap.Text = "EMAIL ADDRESS";
            // 
            // txtContactEmail
            // 
            this.txtContactEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.txtContactEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContactEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtContactEmail.ForeColor = System.Drawing.Color.White;
            this.txtContactEmail.Location = new System.Drawing.Point(24, 114);
            this.txtContactEmail.Name = "txtContactEmail";
            this.txtContactEmail.Size = new System.Drawing.Size(610, 30);
            // 
            // lblContactSubjectCap
            // 
            this.lblContactSubjectCap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblContactSubjectCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(205)))));
            this.lblContactSubjectCap.Location = new System.Drawing.Point(24, 162);
            this.lblContactSubjectCap.Name = "lblContactSubjectCap";
            this.lblContactSubjectCap.Size = new System.Drawing.Size(260, 18);
            this.lblContactSubjectCap.Text = "SUBJECT";
            // 
            // cmbContactSubject
            // 
            this.cmbContactSubject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.cmbContactSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContactSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbContactSubject.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbContactSubject.ForeColor = System.Drawing.Color.White;
            this.cmbContactSubject.Location = new System.Drawing.Point(24, 184);
            this.cmbContactSubject.Name = "cmbContactSubject";
            this.cmbContactSubject.Size = new System.Drawing.Size(340, 28);
            // 
            // lblContactMsgCap
            // 
            this.lblContactMsgCap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblContactMsgCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(205)))));
            this.lblContactMsgCap.Location = new System.Drawing.Point(24, 232);
            this.lblContactMsgCap.Name = "lblContactMsgCap";
            this.lblContactMsgCap.Size = new System.Drawing.Size(260, 18);
            this.lblContactMsgCap.Text = "MESSAGE";
            // 
            // txtContactMessage
            // 
            this.txtContactMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.txtContactMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContactMessage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtContactMessage.ForeColor = System.Drawing.Color.White;
            this.txtContactMessage.Location = new System.Drawing.Point(24, 254);
            this.txtContactMessage.Multiline = true;
            this.txtContactMessage.Name = "txtContactMessage";
            this.txtContactMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContactMessage.Size = new System.Drawing.Size(610, 168);
            // 
            // btnSendContactMessage
            // 
            this.btnSendContactMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnSendContactMessage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendContactMessage.FlatAppearance.BorderSize = 0;
            this.btnSendContactMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendContactMessage.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSendContactMessage.ForeColor = System.Drawing.Color.White;
            this.btnSendContactMessage.Location = new System.Drawing.Point(24, 442);
            this.btnSendContactMessage.Name = "btnSendContactMessage";
            this.btnSendContactMessage.Size = new System.Drawing.Size(610, 48);
            this.btnSendContactMessage.Text = "📨  Send Message";
            this.btnSendContactMessage.UseVisualStyleBackColor = false;
            this.btnSendContactMessage.Click += new System.EventHandler(this.btnSendContactMessage_Click);
            // 
            // VisitorDashboardForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimumSize = new System.Drawing.Size(960, 620);
            this.Name = "VisitorDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blue Horizons Tours – Dashboard";
            this.pnlSidebar.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlHome.ResumeLayout(false);
            this.cardBookings.ResumeLayout(false);
            this.cardUpcoming.ResumeLayout(false);
            this.pnlBrowse.ResumeLayout(false);
            this.pnlBrowse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivities)).EndInit();
            this.pnlBook.ResumeLayout(false);
            this.pnlBookCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudParticipants)).EndInit();
            this.pnlPayment.ResumeLayout(false);
            this.pnlPaySummaryCard.ResumeLayout(false);
            this.pnlInvoice.ResumeLayout(false);
            this.pnlMyBookings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyBookings)).EndInit();
            this.pnlProfile.ResumeLayout(false);
            this.pnlProfile.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblBrandTitle;
        private System.Windows.Forms.Label lblPortalSub;
        private System.Windows.Forms.Label lblSidebarUser;
        private System.Windows.Forms.Button btnNavHome;
        private System.Windows.Forms.Button btnNavBrowse;
        private System.Windows.Forms.Button btnNavMyBookings;
        private System.Windows.Forms.Button btnNavProfile;
        private System.Windows.Forms.Panel pnlDivider;
        private System.Windows.Forms.Button btnNavLogout;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlHome;
        private System.Windows.Forms.Label lblHomeWelcome;
        private System.Windows.Forms.Label lblHomeSub;
        private System.Windows.Forms.Panel cardBookings;
        private System.Windows.Forms.Label lblHomeBookingsCount;
        private System.Windows.Forms.Label lblHomeBookingsCap;
        private System.Windows.Forms.Panel cardUpcoming;
        private System.Windows.Forms.Label lblHomeUpcomingCount;
        private System.Windows.Forms.Label lblHomeUpcomingCap;
        private System.Windows.Forms.Label lblHomePrompt;
        private System.Windows.Forms.Button btnQuickBrowse;
        private System.Windows.Forms.Panel pnlHomeAnalytics;
        private System.Windows.Forms.Panel pnlBrowse;
        private System.Windows.Forms.Label lblBrowseHeading;
        private System.Windows.Forms.Label lblBrowseCatCap;
        private System.Windows.Forms.ComboBox cboCategoryFilter;
        private System.Windows.Forms.Label lblBrowseSearchCap;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel pnlAccordionGallery;
        private System.Windows.Forms.DataGridView dgvActivities;
        private System.Windows.Forms.Label lblNoActivities;
        private System.Windows.Forms.Button btnBookNow;
        private System.Windows.Forms.Panel pnlBook;
        private System.Windows.Forms.Label lblBookHeading;
        private System.Windows.Forms.Panel pnlBookCard;
        private System.Windows.Forms.Label lblBookName;
        private System.Windows.Forms.Label lblBookCat;
        private System.Windows.Forms.Label lblBookDate;
        private System.Windows.Forms.Label lblBookPrice;
        private System.Windows.Forms.Label lblBookSeatsVal;
        private System.Windows.Forms.Label lblBookPaxCap;
        private System.Windows.Forms.NumericUpDown nudParticipants;
        private System.Windows.Forms.Label lblBookTotal;
        private System.Windows.Forms.Label lblBookError;
        private System.Windows.Forms.Button btnProceedPayment;
        private System.Windows.Forms.Button btnCancelBook;
        private System.Windows.Forms.Panel pnlPayment;
        private System.Windows.Forms.Label lblPayHeading;
        private System.Windows.Forms.Panel pnlPaySummaryCard;
        private System.Windows.Forms.Label lblPaySummary;
        private System.Windows.Forms.Label lblPayTotal;
        private System.Windows.Forms.Label lblPayNotice;
        private System.Windows.Forms.Button btnPayNow;
        private System.Windows.Forms.Button btnCancelPay;
        private System.Windows.Forms.Panel pnlInvoice;
        private System.Windows.Forms.Label lblInvHeading;
        private System.Windows.Forms.Label lblInvSub;
        private System.Windows.Forms.RichTextBox rtbInvoice;
        private System.Windows.Forms.Button btnPrintInvoice;
        private System.Windows.Forms.Button btnSaveInvoice;
        private System.Windows.Forms.Button btnMakeAnother;
        private System.Windows.Forms.Button btnBackToDash;
        private System.Windows.Forms.Panel pnlMyBookings;
        private System.Windows.Forms.Label lblMyBookingsHeading;
        private System.Windows.Forms.DataGridView dgvMyBookings;
        private System.Windows.Forms.Label lblNoBookings;
        private System.Windows.Forms.Panel pnlProfile;
        private System.Windows.Forms.Label lblProfileHeading;
        private System.Windows.Forms.Label lblProfileSub;
        private System.Windows.Forms.Label lblProfileEmailCap;
        private System.Windows.Forms.TextBox txtProfileEmail;
        private System.Windows.Forms.Label lblProfilePhoneCap;
        private System.Windows.Forms.TextBox txtProfilePhone;
        private System.Windows.Forms.Label lblProfileNewPassCap;
        private System.Windows.Forms.TextBox txtProfileNewPass;
        private System.Windows.Forms.Label lblProfileConfirmCap;
        private System.Windows.Forms.TextBox txtProfileConfirm;
        private System.Windows.Forms.Label lblProfileError;
        private System.Windows.Forms.Button btnSaveProfile;
        private System.Windows.Forms.Button btnNavChatbot;
        private System.Windows.Forms.Button btnFloatingChat;
        private System.Windows.Forms.Panel pnlHomeMeta;
        private System.Windows.Forms.Label lblDashboardLocation;
        private System.Windows.Forms.Label lblDashboardClock;
        private System.Windows.Forms.Button btnNavContactUs;
        private System.Windows.Forms.Panel pnlCardEntry;
        private System.Windows.Forms.Label lblPayGuestNameCap;
        private System.Windows.Forms.TextBox txtPayFullName;
        private System.Windows.Forms.Label lblPayNameErr;
        private System.Windows.Forms.Label lblPayGuestEmailCap;
        private System.Windows.Forms.TextBox txtPayEmail;
        private System.Windows.Forms.Label lblPayEmailErr;
        private System.Windows.Forms.Label lblPayCardCap;
        private System.Windows.Forms.TextBox txtCardNumber;
        private System.Windows.Forms.Button btnFillDemoCard;
        private System.Windows.Forms.Label lblPayCardErr;
        private System.Windows.Forms.Label lblPayExpiryCap;
        private System.Windows.Forms.TextBox txtCardMonth;
        private System.Windows.Forms.TextBox txtCardYear;
        private System.Windows.Forms.Label lblPayExpiryErr;
        private System.Windows.Forms.Label lblPayCvcCap;
        private System.Windows.Forms.TextBox txtCardCvc;
        private System.Windows.Forms.Label lblPayCvcErr;
        private System.Windows.Forms.Button btnOpenTicketsFolder;
        private System.Windows.Forms.Panel pnlContactUs;
        private System.Windows.Forms.Label lblContactHeading;
        private System.Windows.Forms.Label lblContactSub;
        private System.Windows.Forms.Panel pnlContactCard;
        private System.Windows.Forms.Label lblContactNameCap;
        private System.Windows.Forms.TextBox txtContactName;
        private System.Windows.Forms.Label lblContactEmailCap;
        private System.Windows.Forms.TextBox txtContactEmail;
        private System.Windows.Forms.Label lblContactSubjectCap;
        private System.Windows.Forms.ComboBox cmbContactSubject;
        private System.Windows.Forms.Label lblContactMsgCap;
        private System.Windows.Forms.TextBox txtContactMessage;
        private System.Windows.Forms.Button btnSendContactMessage;
    }
}
