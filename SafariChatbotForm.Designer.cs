// =============================================================================
// Forms/SafariChatbotForm.Designer.cs
// Visual Studio Windows Forms Designer layout matching the "SafariScout AI"
// design (Dark Olive Header, Robot Ranger & Explorer Avatars, Tan & Cream
// Rounded Chat Bubbles, Pill Action Chips, Scouting Indicator, and Rounded
// White Input Pill with Circular Orange Send Button).
// =============================================================================

namespace PROJECTT.Forms
{
    partial class SafariChatbotForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.picHeaderBot = new System.Windows.Forms.PictureBox();
            this.lblBotTitle = new System.Windows.Forms.Label();
            this.lblModeStatus = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClosePopup = new System.Windows.Forms.Button();
            this.picCompass = new System.Windows.Forms.PictureBox();
            this.pnlChatFeed = new System.Windows.Forms.Panel();
            this.pnlWelcomeUserRow = new System.Windows.Forms.Panel();
            this.pnlWelcomeUserBubble = new System.Windows.Forms.Panel();
            this.lblWelcomeUserText = new System.Windows.Forms.Label();
            this.picWelcomeUserAvatar = new System.Windows.Forms.PictureBox();
            this.pnlWelcomeBotRow = new System.Windows.Forms.Panel();
            this.picWelcomeBotAvatar = new System.Windows.Forms.PictureBox();
            this.pnlWelcomeBotBubble = new System.Windows.Forms.Panel();
            this.lblWelcomeBotText = new System.Windows.Forms.Label();
            this.pnlQuickChips = new System.Windows.Forms.Panel();
            this.btnChipSafaris = new System.Windows.Forms.Button();
            this.btnChipAllTours = new System.Windows.Forms.Button();
            this.btnChipFamilyDrives = new System.Windows.Forms.Button();
            this.btnChipMyBookings = new System.Windows.Forms.Button();
            this.btnChipQuickBook = new System.Windows.Forms.Button();
            this.pnlScoutingRow = new System.Windows.Forms.Panel();
            this.pnlNeonSpinner = new System.Windows.Forms.Panel();
            this.lblWaveBars = new System.Windows.Forms.Label();
            this.lblScoutingText = new System.Windows.Forms.Label();
            this.pnlQuickBook = new System.Windows.Forms.Panel();
            this.lblQuickBookTitle = new System.Windows.Forms.Label();
            this.cboQuickActivity = new System.Windows.Forms.ComboBox();
            this.lblPaxCap = new System.Windows.Forms.Label();
            this.nudQuickPax = new System.Windows.Forms.NumericUpDown();
            this.btnQuickBookNow = new System.Windows.Forms.Button();
            this.btnOpenInDash = new System.Windows.Forms.Button();
            this.pnlBottomArea = new System.Windows.Forms.Panel();
            this.pnlInputPill = new System.Windows.Forms.Panel();
            this.btnAttachBook = new System.Windows.Forms.Button();
            this.txtUserMessage = new System.Windows.Forms.TextBox();
            this.picSendBtn = new System.Windows.Forms.PictureBox();
            this.lblFooterTagline = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHeaderBot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCompass)).BeginInit();
            this.pnlChatFeed.SuspendLayout();
            this.pnlWelcomeUserRow.SuspendLayout();
            this.pnlWelcomeUserBubble.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWelcomeUserAvatar)).BeginInit();
            this.pnlWelcomeBotRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWelcomeBotAvatar)).BeginInit();
            this.pnlWelcomeBotBubble.SuspendLayout();
            this.pnlQuickChips.SuspendLayout();
            this.pnlScoutingRow.SuspendLayout();
            this.pnlQuickBook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuickPax)).BeginInit();
            this.pnlBottomArea.SuspendLayout();
            this.pnlInputPill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSendBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(74)))), ((int)(((byte)(43)))));
            this.pnlHeader.Controls.Add(this.picHeaderBot);
            this.pnlHeader.Controls.Add(this.lblBotTitle);
            this.pnlHeader.Controls.Add(this.lblModeStatus);
            this.pnlHeader.Controls.Add(this.btnMinimize);
            this.pnlHeader.Controls.Add(this.btnClosePopup);
            this.pnlHeader.Controls.Add(this.picCompass);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(440, 96);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlHeader_MouseDown);
            // 
            // picHeaderBot
            // 
            this.picHeaderBot.Location = new System.Drawing.Point(20, 16);
            this.picHeaderBot.Name = "picHeaderBot";
            this.picHeaderBot.Size = new System.Drawing.Size(64, 64);
            this.picHeaderBot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHeaderBot.TabIndex = 0;
            this.picHeaderBot.TabStop = false;
            this.picHeaderBot.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlHeader_MouseDown);
            // 
            // lblBotTitle
            // 
            this.lblBotTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblBotTitle.ForeColor = System.Drawing.Color.White;
            this.lblBotTitle.Location = new System.Drawing.Point(94, 20);
            this.lblBotTitle.Name = "lblBotTitle";
            this.lblBotTitle.Size = new System.Drawing.Size(260, 32);
            this.lblBotTitle.TabIndex = 1;
            this.lblBotTitle.Text = "SafariScout AI";
            this.lblBotTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlHeader_MouseDown);
            // 
            // lblModeStatus
            // 
            this.lblModeStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.lblModeStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(235)))), ((int)(((byte)(175)))));
            this.lblModeStatus.Location = new System.Drawing.Point(96, 53);
            this.lblModeStatus.Name = "lblModeStatus";
            this.lblModeStatus.Size = new System.Drawing.Size(268, 22);
            this.lblModeStatus.TabIndex = 2;
            this.lblModeStatus.Text = "🟢 Online && Tracking 🟢";
            this.lblModeStatus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlHeader_MouseDown);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(74)))), ((int)(((byte)(43)))));
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(374, 6);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(28, 26);
            this.btnMinimize.TabIndex = 3;
            this.btnMinimize.Text = "—";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClosePopup
            // 
            this.btnClosePopup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(74)))), ((int)(((byte)(43)))));
            this.btnClosePopup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClosePopup.FlatAppearance.BorderSize = 0;
            this.btnClosePopup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClosePopup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClosePopup.ForeColor = System.Drawing.Color.White;
            this.btnClosePopup.Location = new System.Drawing.Point(404, 6);
            this.btnClosePopup.Name = "btnClosePopup";
            this.btnClosePopup.Size = new System.Drawing.Size(28, 26);
            this.btnClosePopup.TabIndex = 4;
            this.btnClosePopup.Text = "✕";
            this.btnClosePopup.UseVisualStyleBackColor = false;
            this.btnClosePopup.Click += new System.EventHandler(this.btnClosePopup_Click);
            // 
            // picCompass
            // 
            this.picCompass.Location = new System.Drawing.Point(380, 42);
            this.picCompass.Name = "picCompass";
            this.picCompass.Size = new System.Drawing.Size(40, 40);
            this.picCompass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCompass.TabIndex = 5;
            this.picCompass.TabStop = false;
            // 
            // pnlChatFeed
            // 
            this.pnlChatFeed.AutoScroll = true;
            this.pnlChatFeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.pnlChatFeed.Controls.Add(this.pnlWelcomeUserRow);
            this.pnlChatFeed.Controls.Add(this.pnlWelcomeBotRow);
            this.pnlChatFeed.Controls.Add(this.pnlQuickChips);
            this.pnlChatFeed.Controls.Add(this.pnlScoutingRow);
            this.pnlChatFeed.Location = new System.Drawing.Point(0, 96);
            this.pnlChatFeed.Name = "pnlChatFeed";
            this.pnlChatFeed.Size = new System.Drawing.Size(440, 462);
            this.pnlChatFeed.TabIndex = 2;
            // 
            // pnlWelcomeUserRow
            // 
            this.pnlWelcomeUserRow.BackColor = System.Drawing.Color.Transparent;
            this.pnlWelcomeUserRow.Controls.Add(this.pnlWelcomeUserBubble);
            this.pnlWelcomeUserRow.Controls.Add(this.picWelcomeUserAvatar);
            this.pnlWelcomeUserRow.Location = new System.Drawing.Point(10, 12);
            this.pnlWelcomeUserRow.Name = "pnlWelcomeUserRow";
            this.pnlWelcomeUserRow.Size = new System.Drawing.Size(400, 88);
            this.pnlWelcomeUserRow.TabIndex = 0;
            // 
            // pnlWelcomeUserBubble
            // 
            this.pnlWelcomeUserBubble.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(192)))), ((int)(((byte)(139)))));
            this.pnlWelcomeUserBubble.Controls.Add(this.lblWelcomeUserText);
            this.pnlWelcomeUserBubble.Location = new System.Drawing.Point(34, 4);
            this.pnlWelcomeUserBubble.Name = "pnlWelcomeUserBubble";
            this.pnlWelcomeUserBubble.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlWelcomeUserBubble.Size = new System.Drawing.Size(312, 78);
            this.pnlWelcomeUserBubble.TabIndex = 0;
            this.pnlWelcomeUserBubble.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlWelcomeUserBubble_Paint);
            // 
            // lblWelcomeUserText
            // 
            this.lblWelcomeUserText.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcomeUserText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular);
            this.lblWelcomeUserText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(30)))), ((int)(((byte)(20)))));
            this.lblWelcomeUserText.Location = new System.Drawing.Point(12, 8);
            this.lblWelcomeUserText.Name = "lblWelcomeUserText";
            this.lblWelcomeUserText.Size = new System.Drawing.Size(288, 62);
            this.lblWelcomeUserText.TabIndex = 0;
            this.lblWelcomeUserText.Text = "Jambo! 🦒 I\'m looking for a Cape Town safari. Do you have any budget-friendly recommendations?";
            // 
            // picWelcomeUserAvatar
            // 
            this.picWelcomeUserAvatar.Location = new System.Drawing.Point(354, 4);
            this.picWelcomeUserAvatar.Name = "picWelcomeUserAvatar";
            this.picWelcomeUserAvatar.Size = new System.Drawing.Size(42, 42);
            this.picWelcomeUserAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picWelcomeUserAvatar.TabIndex = 1;
            this.picWelcomeUserAvatar.TabStop = false;
            // 
            // pnlWelcomeBotRow
            // 
            this.pnlWelcomeBotRow.BackColor = System.Drawing.Color.Transparent;
            this.pnlWelcomeBotRow.Controls.Add(this.picWelcomeBotAvatar);
            this.pnlWelcomeBotRow.Controls.Add(this.pnlWelcomeBotBubble);
            this.pnlWelcomeBotRow.Location = new System.Drawing.Point(10, 108);
            this.pnlWelcomeBotRow.Name = "pnlWelcomeBotRow";
            this.pnlWelcomeBotRow.Size = new System.Drawing.Size(400, 132);
            this.pnlWelcomeBotRow.TabIndex = 1;
            // 
            // picWelcomeBotAvatar
            // 
            this.picWelcomeBotAvatar.Location = new System.Drawing.Point(4, 8);
            this.picWelcomeBotAvatar.Name = "picWelcomeBotAvatar";
            this.picWelcomeBotAvatar.Size = new System.Drawing.Size(42, 42);
            this.picWelcomeBotAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picWelcomeBotAvatar.TabIndex = 0;
            this.picWelcomeBotAvatar.TabStop = false;
            // 
            // pnlWelcomeBotBubble
            // 
            this.pnlWelcomeBotBubble.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(236)))), ((int)(((byte)(216)))));
            this.pnlWelcomeBotBubble.Controls.Add(this.lblWelcomeBotText);
            this.pnlWelcomeBotBubble.Location = new System.Drawing.Point(54, 4);
            this.pnlWelcomeBotBubble.Name = "pnlWelcomeBotBubble";
            this.pnlWelcomeBotBubble.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.pnlWelcomeBotBubble.Size = new System.Drawing.Size(320, 122);
            this.pnlWelcomeBotBubble.TabIndex = 1;
            this.pnlWelcomeBotBubble.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlWelcomeBotBubble_Paint);
            // 
            // lblWelcomeBotText
            // 
            this.lblWelcomeBotText.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcomeBotText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular);
            this.lblWelcomeBotText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(22)))));
            this.lblWelcomeBotText.Location = new System.Drawing.Point(12, 10);
            this.lblWelcomeBotText.Name = "lblWelcomeBotText";
            this.lblWelcomeBotText.Size = new System.Drawing.Size(296, 102);
            this.lblWelcomeBotText.TabIndex = 0;
            this.lblWelcomeBotText.Text = "Habari! 🦁 I can certainly help you track down the perfect adventure! Ask me about our Safaris, check live ZAR prices & seats, or type \"Book [Tour] for 2\"! ⛺🐆🐾";
            // 
            // pnlQuickChips
            // 
            this.pnlQuickChips.BackColor = System.Drawing.Color.Transparent;
            this.pnlQuickChips.Controls.Add(this.btnChipSafaris);
            this.pnlQuickChips.Controls.Add(this.btnChipAllTours);
            this.pnlQuickChips.Controls.Add(this.btnChipFamilyDrives);
            this.pnlQuickChips.Controls.Add(this.btnChipMyBookings);
            this.pnlQuickChips.Controls.Add(this.btnChipQuickBook);
            this.pnlQuickChips.Location = new System.Drawing.Point(56, 246);
            this.pnlQuickChips.Name = "pnlQuickChips";
            this.pnlQuickChips.Size = new System.Drawing.Size(348, 82);
            this.pnlQuickChips.TabIndex = 2;
            // 
            // btnChipSafaris
            // 
            this.btnChipSafaris.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(185)))), ((int)(((byte)(128)))));
            this.btnChipSafaris.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChipSafaris.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(115)))), ((int)(((byte)(68)))));
            this.btnChipSafaris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChipSafaris.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnChipSafaris.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(28)))), ((int)(((byte)(16)))));
            this.btnChipSafaris.Location = new System.Drawing.Point(4, 4);
            this.btnChipSafaris.Name = "btnChipSafaris";
            this.btnChipSafaris.Size = new System.Drawing.Size(156, 34);
            this.btnChipSafaris.TabIndex = 0;
            this.btnChipSafaris.Text = "⛺ Budget Safaris";
            this.btnChipSafaris.UseVisualStyleBackColor = false;
            this.btnChipSafaris.Click += new System.EventHandler(this.btnChipSafaris_Click);
            // 
            // btnChipAllTours
            // 
            this.btnChipAllTours.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(185)))), ((int)(((byte)(128)))));
            this.btnChipAllTours.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChipAllTours.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(115)))), ((int)(((byte)(68)))));
            this.btnChipAllTours.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChipAllTours.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnChipAllTours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(28)))), ((int)(((byte)(16)))));
            this.btnChipAllTours.Location = new System.Drawing.Point(168, 4);
            this.btnChipAllTours.Name = "btnChipAllTours";
            this.btnChipAllTours.Size = new System.Drawing.Size(156, 34);
            this.btnChipAllTours.TabIndex = 1;
            this.btnChipAllTours.Text = "🦓 Wildlife Tours";
            this.btnChipAllTours.UseVisualStyleBackColor = false;
            this.btnChipAllTours.Click += new System.EventHandler(this.btnChipAllTours_Click);
            // 
            // btnChipFamilyDrives
            // 
            this.btnChipFamilyDrives.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(185)))), ((int)(((byte)(128)))));
            this.btnChipFamilyDrives.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChipFamilyDrives.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(115)))), ((int)(((byte)(68)))));
            this.btnChipFamilyDrives.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChipFamilyDrives.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnChipFamilyDrives.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(28)))), ((int)(((byte)(16)))));
            this.btnChipFamilyDrives.Location = new System.Drawing.Point(4, 44);
            this.btnChipFamilyDrives.Name = "btnChipFamilyDrives";
            this.btnChipFamilyDrives.Size = new System.Drawing.Size(134, 34);
            this.btnChipFamilyDrives.TabIndex = 2;
            this.btnChipFamilyDrives.Text = "🚗 Family Drives";
            this.btnChipFamilyDrives.UseVisualStyleBackColor = false;
            this.btnChipFamilyDrives.Click += new System.EventHandler(this.btnChipFamilyDrives_Click);
            // 
            // btnChipMyBookings
            // 
            this.btnChipMyBookings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(185)))), ((int)(((byte)(128)))));
            this.btnChipMyBookings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChipMyBookings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(115)))), ((int)(((byte)(68)))));
            this.btnChipMyBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChipMyBookings.Font = new System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Regular);
            this.btnChipMyBookings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(28)))), ((int)(((byte)(16)))));
            this.btnChipMyBookings.Location = new System.Drawing.Point(144, 44);
            this.btnChipMyBookings.Name = "btnChipMyBookings";
            this.btnChipMyBookings.Size = new System.Drawing.Size(108, 34);
            this.btnChipMyBookings.TabIndex = 3;
            this.btnChipMyBookings.Text = "📋 Bookings";
            this.btnChipMyBookings.UseVisualStyleBackColor = false;
            this.btnChipMyBookings.Click += new System.EventHandler(this.btnChipMyBookings_Click);
            // 
            // btnChipQuickBook
            // 
            this.btnChipQuickBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(78)))), ((int)(((byte)(33)))));
            this.btnChipQuickBook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChipQuickBook.FlatAppearance.BorderSize = 0;
            this.btnChipQuickBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChipQuickBook.Font = new System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Bold);
            this.btnChipQuickBook.ForeColor = System.Drawing.Color.White;
            this.btnChipQuickBook.Location = new System.Drawing.Point(258, 44);
            this.btnChipQuickBook.Name = "btnChipQuickBook";
            this.btnChipQuickBook.Size = new System.Drawing.Size(84, 34);
            this.btnChipQuickBook.TabIndex = 4;
            this.btnChipQuickBook.Text = "⚡ Book";
            this.btnChipQuickBook.UseVisualStyleBackColor = false;
            this.btnChipQuickBook.Click += new System.EventHandler(this.btnAttachBook_Click);
            // 
            // pnlScoutingRow
            // 
            this.pnlScoutingRow.BackColor = System.Drawing.Color.Transparent;
            this.pnlScoutingRow.Controls.Add(this.lblWaveBars);
            this.pnlScoutingRow.Controls.Add(this.lblScoutingText);
            this.pnlScoutingRow.Location = new System.Drawing.Point(16, 336);
            this.pnlScoutingRow.Name = "pnlScoutingRow";
            this.pnlScoutingRow.Size = new System.Drawing.Size(390, 32);
            this.pnlScoutingRow.TabIndex = 3;
            // 
            // lblWaveBars
            // 
            this.lblWaveBars.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblWaveBars.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(169)))), ((int)(((byte)(114)))));
            this.lblWaveBars.Location = new System.Drawing.Point(4, 2);
            this.lblWaveBars.Name = "lblWaveBars";
            this.lblWaveBars.Size = new System.Drawing.Size(32, 32);
            this.lblWaveBars.TabIndex = 0;
            this.lblWaveBars.Text = "";
            this.lblWaveBars.Paint += new System.Windows.Forms.PaintEventHandler(this.lblWaveBars_Paint);
            // 
            // lblScoutingText
            // 
            this.lblScoutingText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular);
            this.lblScoutingText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(50)))), ((int)(((byte)(40)))));
            this.lblScoutingText.Location = new System.Drawing.Point(52, 5);
            this.lblScoutingText.Name = "lblScoutingText";
            this.lblScoutingText.Size = new System.Drawing.Size(330, 24);
            this.lblScoutingText.TabIndex = 1;
            this.lblScoutingText.Text = "SafariScout AI is scouting trails... 🐾";
            // 
            // pnlNeonSpinner
            // 
            this.pnlNeonSpinner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.pnlNeonSpinner.Location = new System.Drawing.Point(160, 260);
            this.pnlNeonSpinner.Name = "pnlNeonSpinner";
            this.pnlNeonSpinner.Size = new System.Drawing.Size(120, 120);
            this.pnlNeonSpinner.TabIndex = 10;
            this.pnlNeonSpinner.Visible = false;
            this.pnlNeonSpinner.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlNeonSpinner_Paint);
            // 
            // pnlQuickBook
            // 
            this.pnlQuickBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(226)))), ((int)(((byte)(204)))));
            this.pnlQuickBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlQuickBook.Controls.Add(this.lblQuickBookTitle);
            this.pnlQuickBook.Controls.Add(this.cboQuickActivity);
            this.pnlQuickBook.Controls.Add(this.lblPaxCap);
            this.pnlQuickBook.Controls.Add(this.nudQuickPax);
            this.pnlQuickBook.Controls.Add(this.btnQuickBookNow);
            this.pnlQuickBook.Controls.Add(this.btnOpenInDash);
            this.pnlQuickBook.Location = new System.Drawing.Point(12, 464);
            this.pnlQuickBook.Name = "pnlQuickBook";
            this.pnlQuickBook.Size = new System.Drawing.Size(416, 90);
            this.pnlQuickBook.TabIndex = 3;
            this.pnlQuickBook.Visible = false;
            // 
            // lblQuickBookTitle
            // 
            this.lblQuickBookTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblQuickBookTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(74)))), ((int)(((byte)(43)))));
            this.lblQuickBookTitle.Location = new System.Drawing.Point(8, 4);
            this.lblQuickBookTitle.Name = "lblQuickBookTitle";
            this.lblQuickBookTitle.Size = new System.Drawing.Size(396, 16);
            this.lblQuickBookTitle.TabIndex = 0;
            this.lblQuickBookTitle.Text = "⚡ INSTANT SAFARI && TOUR BOOKING DESK";
            // 
            // cboQuickActivity
            // 
            this.cboQuickActivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuickActivity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboQuickActivity.Location = new System.Drawing.Point(8, 23);
            this.cboQuickActivity.Name = "cboQuickActivity";
            this.cboQuickActivity.Size = new System.Drawing.Size(306, 23);
            this.cboQuickActivity.TabIndex = 1;
            // 
            // lblPaxCap
            // 
            this.lblPaxCap.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblPaxCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(74)))), ((int)(((byte)(43)))));
            this.lblPaxCap.Location = new System.Drawing.Point(320, 6);
            this.lblPaxCap.Name = "lblPaxCap";
            this.lblPaxCap.Size = new System.Drawing.Size(45, 14);
            this.lblPaxCap.TabIndex = 2;
            this.lblPaxCap.Text = "PAX:";
            // 
            // nudQuickPax
            // 
            this.nudQuickPax.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudQuickPax.Location = new System.Drawing.Point(320, 23);
            this.nudQuickPax.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            this.nudQuickPax.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudQuickPax.Name = "nudQuickPax";
            this.nudQuickPax.Size = new System.Drawing.Size(86, 23);
            this.nudQuickPax.TabIndex = 3;
            this.nudQuickPax.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnQuickBookNow
            // 
            this.btnQuickBookNow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(78)))), ((int)(((byte)(33)))));
            this.btnQuickBookNow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickBookNow.FlatAppearance.BorderSize = 0;
            this.btnQuickBookNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickBookNow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnQuickBookNow.ForeColor = System.Drawing.Color.White;
            this.btnQuickBookNow.Location = new System.Drawing.Point(8, 52);
            this.btnQuickBookNow.Name = "btnQuickBookNow";
            this.btnQuickBookNow.Size = new System.Drawing.Size(214, 30);
            this.btnQuickBookNow.TabIndex = 4;
            this.btnQuickBookNow.Text = "⚡ Book && Pay in Chat";
            this.btnQuickBookNow.UseVisualStyleBackColor = false;
            this.btnQuickBookNow.Click += new System.EventHandler(this.btnQuickBookNow_Click);
            // 
            // btnOpenInDash
            // 
            this.btnOpenInDash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(74)))), ((int)(((byte)(43)))));
            this.btnOpenInDash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenInDash.FlatAppearance.BorderSize = 0;
            this.btnOpenInDash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenInDash.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnOpenInDash.ForeColor = System.Drawing.Color.White;
            this.btnOpenInDash.Location = new System.Drawing.Point(228, 52);
            this.btnOpenInDash.Name = "btnOpenInDash";
            this.btnOpenInDash.Size = new System.Drawing.Size(178, 30);
            this.btnOpenInDash.TabIndex = 5;
            this.btnOpenInDash.Text = "↗ Open in Dashboard";
            this.btnOpenInDash.UseVisualStyleBackColor = false;
            this.btnOpenInDash.Click += new System.EventHandler(this.btnOpenInDash_Click);
            // 
            // pnlBottomArea
            // 
            this.pnlBottomArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(235)))), ((int)(((byte)(220)))));
            this.pnlBottomArea.Controls.Add(this.pnlInputPill);
            this.pnlBottomArea.Controls.Add(this.lblFooterTagline);
            this.pnlBottomArea.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomArea.Location = new System.Drawing.Point(0, 558);
            this.pnlBottomArea.Name = "pnlBottomArea";
            this.pnlBottomArea.Size = new System.Drawing.Size(440, 92);
            this.pnlBottomArea.TabIndex = 4;
            this.pnlBottomArea.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBottomArea_Paint);
            // 
            // pnlInputPill
            // 
            this.pnlInputPill.BackColor = System.Drawing.Color.White;
            this.pnlInputPill.Controls.Add(this.btnAttachBook);
            this.pnlInputPill.Controls.Add(this.txtUserMessage);
            this.pnlInputPill.Controls.Add(this.picSendBtn);
            this.pnlInputPill.Location = new System.Drawing.Point(18, 10);
            this.pnlInputPill.Name = "pnlInputPill";
            this.pnlInputPill.Size = new System.Drawing.Size(404, 50);
            this.pnlInputPill.TabIndex = 0;
            this.pnlInputPill.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlInputPill_Paint);
            // 
            // btnAttachBook
            // 
            this.btnAttachBook.BackColor = System.Drawing.Color.White;
            this.btnAttachBook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAttachBook.FlatAppearance.BorderSize = 0;
            this.btnAttachBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttachBook.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnAttachBook.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(74)))), ((int)(((byte)(43)))));
            this.btnAttachBook.Location = new System.Drawing.Point(10, 8);
            this.btnAttachBook.Name = "btnAttachBook";
            this.btnAttachBook.Size = new System.Drawing.Size(36, 34);
            this.btnAttachBook.TabIndex = 0;
            this.btnAttachBook.Text = "📎";
            this.btnAttachBook.UseVisualStyleBackColor = false;
            this.btnAttachBook.Click += new System.EventHandler(this.btnAttachBook_Click);
            // 
            // txtUserMessage
            // 
            this.txtUserMessage.BackColor = System.Drawing.Color.White;
            this.txtUserMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserMessage.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUserMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(115)))), ((int)(((byte)(105)))));
            this.txtUserMessage.Location = new System.Drawing.Point(54, 15);
            this.txtUserMessage.Name = "txtUserMessage";
            this.txtUserMessage.Size = new System.Drawing.Size(288, 20);
            this.txtUserMessage.TabIndex = 1;
            this.txtUserMessage.Text = "Ask SafariScout...";
            this.txtUserMessage.Enter += new System.EventHandler(this.txtUserMessage_Enter);
            this.txtUserMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserMessage_KeyDown);
            this.txtUserMessage.Leave += new System.EventHandler(this.txtUserMessage_Leave);
            // 
            // picSendBtn
            // 
            this.picSendBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSendBtn.Location = new System.Drawing.Point(354, 4);
            this.picSendBtn.Name = "picSendBtn";
            this.picSendBtn.Size = new System.Drawing.Size(42, 42);
            this.picSendBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSendBtn.TabIndex = 2;
            this.picSendBtn.TabStop = false;
            this.picSendBtn.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // lblFooterTagline
            // 
            this.lblFooterTagline.BackColor = System.Drawing.Color.Transparent;
            this.lblFooterTagline.Font = new System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Regular);
            this.lblFooterTagline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(60)))), ((int)(((byte)(50)))));
            this.lblFooterTagline.Location = new System.Drawing.Point(60, 65);
            this.lblFooterTagline.Name = "lblFooterTagline";
            this.lblFooterTagline.Size = new System.Drawing.Size(320, 20);
            this.lblFooterTagline.TabIndex = 1;
            this.lblFooterTagline.Text = "Exploring with SafariScout AI 🐆";
            this.lblFooterTagline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SafariChatbotForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(440, 650);
            this.Controls.Add(this.pnlNeonSpinner);
            this.Controls.Add(this.pnlQuickBook);
            this.Controls.Add(this.pnlChatFeed);
            this.Controls.Add(this.pnlBottomArea);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "SafariChatbotForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SafariScout AI";
            this.TopMost = true;
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picHeaderBot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCompass)).EndInit();
            this.pnlChatFeed.ResumeLayout(false);
            this.pnlWelcomeUserRow.ResumeLayout(false);
            this.pnlWelcomeUserBubble.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picWelcomeUserAvatar)).EndInit();
            this.pnlWelcomeBotRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picWelcomeBotAvatar)).EndInit();
            this.pnlWelcomeBotBubble.ResumeLayout(false);
            this.pnlQuickChips.ResumeLayout(false);
            this.pnlScoutingRow.ResumeLayout(false);
            this.pnlQuickBook.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudQuickPax)).EndInit();
            this.pnlBottomArea.ResumeLayout(false);
            this.pnlInputPill.ResumeLayout(false);
            this.pnlInputPill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSendBtn)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox picHeaderBot;
        private System.Windows.Forms.Label lblBotTitle;
        private System.Windows.Forms.Label lblModeStatus;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClosePopup;
        private System.Windows.Forms.PictureBox picCompass;
        private System.Windows.Forms.Panel pnlChatFeed;
        private System.Windows.Forms.Panel pnlWelcomeUserRow;
        private System.Windows.Forms.Panel pnlWelcomeUserBubble;
        private System.Windows.Forms.Label lblWelcomeUserText;
        private System.Windows.Forms.PictureBox picWelcomeUserAvatar;
        private System.Windows.Forms.Panel pnlWelcomeBotRow;
        private System.Windows.Forms.PictureBox picWelcomeBotAvatar;
        private System.Windows.Forms.Panel pnlWelcomeBotBubble;
        private System.Windows.Forms.Label lblWelcomeBotText;
        private System.Windows.Forms.Panel pnlQuickChips;
        private System.Windows.Forms.Button btnChipSafaris;
        private System.Windows.Forms.Button btnChipAllTours;
        private System.Windows.Forms.Button btnChipFamilyDrives;
        private System.Windows.Forms.Button btnChipMyBookings;
        private System.Windows.Forms.Button btnChipQuickBook;
        private System.Windows.Forms.Panel pnlScoutingRow;
        private System.Windows.Forms.Panel pnlNeonSpinner;
        private System.Windows.Forms.Label lblWaveBars;
        private System.Windows.Forms.Label lblScoutingText;
        private System.Windows.Forms.Panel pnlQuickBook;
        private System.Windows.Forms.Label lblQuickBookTitle;
        private System.Windows.Forms.ComboBox cboQuickActivity;
        private System.Windows.Forms.Label lblPaxCap;
        private System.Windows.Forms.NumericUpDown nudQuickPax;
        private System.Windows.Forms.Button btnQuickBookNow;
        private System.Windows.Forms.Button btnOpenInDash;
        private System.Windows.Forms.Panel pnlBottomArea;
        private System.Windows.Forms.Panel pnlInputPill;
        private System.Windows.Forms.Button btnAttachBook;
        private System.Windows.Forms.TextBox txtUserMessage;
        private System.Windows.Forms.PictureBox picSendBtn;
        private System.Windows.Forms.Label lblFooterTagline;
    }
}
