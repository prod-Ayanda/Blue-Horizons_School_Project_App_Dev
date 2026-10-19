// =============================================================================
// Forms/SafariChatbotForm.cs
// "SafariScout AI" – Floating Safari & Booking AI Concierge for Blue Horizons Tours.
//
// Matches the SafariScout AI aesthetic:
//   - Deep Safari Olive header (#3E4A2B) with Robot Ranger avatar, green
//     "Online & Tracking" badge, Compass settings icon, and Minimize/Close buttons.
//   - Warm Cream chat canvas (#F9F5EB) with tan right-aligned User bubbles +
//     User Explorer avatar, and cream left-aligned Bot bubbles with 2px dark
//     olive rounded borders + Robot Ranger avatar.
//   - Tan pill-shaped quick-reply chips (Budget Safaris, Wildlife Tours,
//     Family Drives, Bookings, Instant Book).
//   - "SafariScout AI is scouting trails... 🐾" status bar.
//   - Rounded white pill input bar ("Ask SafariScout...") with paperclip
//     booking-desk toggle and circular burnt-orange Send button.
// =============================================================================

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using PROJECTT.Models;
using PROJECTT.Services;

namespace PROJECTT.Forms
{
    public partial class SafariChatbotForm : Form
    {
        private const string PlaceholderText = "Ask SafariScout...";

        private static readonly Color OliveHeader   = Color.FromArgb(62, 74, 43);
        private static readonly Color CreamCanvas   = Color.FromArgb(249, 245, 235);
        private static readonly Color UserTanBubble = Color.FromArgb(223, 192, 139);
        private static readonly Color BotCreamBubble= Color.FromArgb(244, 236, 216);
        private static readonly Color ChipTanFill   = Color.FromArgb(218, 185, 128);
        private static readonly Color ChipTanBorder = Color.FromArgb(145, 115, 68);
        private static readonly Color LeafGreen     = Color.FromArgb(88, 110, 56);

        private readonly User _currentUser;
        private readonly VisitorDashboardForm _parentDashboard;
        private readonly SafariChatbotService _chatService;
        private List<Activity> _cachedActivities = new List<Activity>();
        private int _nextBubbleY = 374;
        private System.Windows.Forms.Timer _spinnerTimer;
        private float _spinnerAngle = 0f;

        // Win32 drag support for borderless popup header
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION       = 0x2;

        /// <summary>Fired whenever a booking is completed inside the chatbot.</summary>
        public event Action<Booking, Invoice, Activity> BookingCompleted;

        // Parameterless constructor required by Visual Studio Windows Forms Designer
        public SafariChatbotForm()
        {
            InitializeComponent();
            // Load embedded resources at runtime (keeps Designer CodeDomSerializer 100% error-free)
            try
            {
                this.picHeaderBot.Image = global::PROJECTT.Properties.Resources.safariscout_bot_header;
                this.picCompass.Image = global::PROJECTT.Properties.Resources.safariscout_compass;
                this.picWelcomeUserAvatar.Image = global::PROJECTT.Properties.Resources.safariscout_user_avatar;
                this.picWelcomeBotAvatar.Image = global::PROJECTT.Properties.Resources.safariscout_bot_small;
                this.picSendBtn.Image = global::PROJECTT.Properties.Resources.safariscout_send_btn;
            }
            catch { }
            ApplyRoundedShapes();
            InitNeonSpinnerTimer();
        }

        public SafariChatbotForm(User currentUser, VisitorDashboardForm parentDashboard = null) : this()
        {
            _currentUser     = currentUser;
            _parentDashboard = parentDashboard;
            _chatService     = new SafariChatbotService(currentUser);

            PositionFloatingPopup(parentDashboard);
            UpdateApiStatusLabel();
            LoadActivitiesDropdown();

            if (currentUser != null && !string.IsNullOrWhiteSpace(currentUser.FirstName))
            {
                lblWelcomeBotText.Text =
                    $"Habari, {currentUser.FirstName}! 🦁 I can certainly help you track down the perfect adventure! " +
                    "Ask me about our Safaris, check live ZAR prices & seats, or type \"Book [Tour] for 2\"! ⛺🐆🐾";
            }
        }

        private void ApplyRoundedShapes()
        {
            try
            {
                this.Region = CreateRoundedRegion(this.ClientSize.Width, this.ClientSize.Height, 22);
                pnlInputPill.Region = CreateRoundedRegion(pnlInputPill.Width, pnlInputPill.Height, 24);
                if (pnlNeonSpinner != null) pnlNeonSpinner.Region = CreateRoundedRegion(pnlNeonSpinner.Width, pnlNeonSpinner.Height, 60);
                pnlWelcomeUserBubble.Region = CreateRoundedRegion(pnlWelcomeUserBubble.Width, pnlWelcomeUserBubble.Height, 16);
                pnlWelcomeBotBubble.Region  = CreateRoundedRegion(pnlWelcomeBotBubble.Width, pnlWelcomeBotBubble.Height, 16);

                foreach (Button chip in new[] { btnChipSafaris, btnChipAllTours, btnChipFamilyDrives, btnChipMyBookings, btnChipQuickBook })
                {
                    if (chip != null)
                        chip.Region = CreateRoundedRegion(chip.Width, chip.Height, 16);
                }
            }
            catch { }
        }


        // ---------------------------------------------------------------------
        // Neon Gradient Blurred Spinner (Matches React styled-components Loader)
        //   .spinner  : linear-gradient(rgb(186, 66, 255) 35%, rgb(0, 225, 255))
        //               width: 100px; height: 100px; border-radius: 50px;
        //               animation: spinning82341 1.7s linear infinite;
        //               box-shadow: 0px -5px 20px rgb(186, 66, 255), 0px 5px 20px rgb(0, 225, 255);
        //   .spinner1 : background-color: rgb(36, 36, 36); filter: blur(10px);
        // ---------------------------------------------------------------------

        private void InitNeonSpinnerTimer()
        {
            // Enable double buffering on the spinner controls to prevent flicker
            EnableDoubleBuffering(pnlNeonSpinner);
            EnableDoubleBuffering(lblWaveBars);

            // 1.7s per 360 degrees -> at 30ms interval (33.33 fps), 360 / (1700 / 30) = 6.3529 degrees per tick
            _spinnerTimer = new System.Windows.Forms.Timer { Interval = 30 };
            _spinnerTimer.Tick += (s, e) =>
            {
                _spinnerAngle = (_spinnerAngle + 6.35f) % 360f;
                if (pnlNeonSpinner != null && pnlNeonSpinner.Visible)
                    pnlNeonSpinner.Invalidate();
                if (lblWaveBars != null && lblWaveBars.Visible)
                    lblWaveBars.Invalidate();
            };
            _spinnerTimer.Start();
        }

        private static void EnableDoubleBuffering(Control ctrl)
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

        private void pnlNeonSpinner_Paint(object sender, PaintEventArgs e)
        {
            // Render the full 100x100 spinner centered inside the 120x120 container (leaving 10px margin for the 20px glow)
            PaintNeonGradientSpinner(e.Graphics, pnlNeonSpinner.Width, pnlNeonSpinner.Height, 100f, _spinnerAngle);
        }

        private void lblWaveBars_Paint(object sender, PaintEventArgs e)
        {
            // Render a compact 24x24 version of the exact same neon spinner inline next to "SafariScout AI is scouting trails..."
            PaintNeonGradientSpinner(e.Graphics, lblWaveBars.Width, lblWaveBars.Height, 24f, _spinnerAngle);
        }

        private static void PaintNeonGradientSpinner(Graphics g, int canvasW, int canvasH, float diameter, float angleDeg)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            float cx = canvasW / 2f;
            float cy = canvasH / 2f;
            float r  = diameter / 2f;

            var state = g.Save();
            g.TranslateTransform(cx, cy);
            g.RotateTransform(angleDeg);

            Color neonPurple = Color.FromArgb(186, 66, 255);
            Color neonCyan   = Color.FromArgb(0, 225, 255);
            Color darkCore   = Color.FromArgb(36, 36, 36);

            // 1. Outer Box-Shadow Glow: 0px -5px 20px rgb(186, 66, 255), 0px 5px 20px rgb(0, 225, 255)
            float glowScale = diameter / 100f;
            for (int i = 4; i >= 1; i--)
            {
                float spread = i * 2.5f * glowScale;
                int alpha = (int)(28 / i);
                using (var topGlowBrush = new SolidBrush(Color.FromArgb(alpha, 186, 66, 255)))
                {
                    g.FillEllipse(topGlowBrush, -r - spread, -r - (4f * glowScale) - spread, (r + spread) * 2f, (r + spread) * 2f);
                }
                using (var botGlowBrush = new SolidBrush(Color.FromArgb(alpha, 0, 225, 255)))
                {
                    g.FillEllipse(botGlowBrush, -r - spread, -r + (4f * glowScale) - spread, (r + spread) * 2f, (r + spread) * 2f);
                }
            }

            // 2. Main .spinner circle: linear-gradient(rgb(186, 66, 255) 35%, rgb(0, 225, 255))
            RectangleF spinnerRect = new RectangleF(-r, -r, diameter, diameter);
            using (var gradBrush = new LinearGradientBrush(
                new PointF(0, -r),
                new PointF(0, r),
                neonPurple,
                neonCyan))
            {
                var blend = new ColorBlend
                {
                    Positions = new[] { 0.0f, 0.35f, 1.0f },
                    Colors    = new[] { neonPurple, neonPurple, neonCyan }
                };
                gradBrush.InterpolationColors = blend;
                g.FillEllipse(gradBrush, spinnerRect);
            }

            // 3. Inner .spinner1 circle: background-color: rgb(36, 36, 36); border-radius: 50px; filter: blur(10px)
            using (var innerPath = new GraphicsPath())
            {
                innerPath.AddEllipse(spinnerRect);
                using (var pgb = new PathGradientBrush(innerPath))
                {
                    pgb.CenterPoint = new PointF(0, 0);
                    pgb.CenterColor = darkCore;
                    pgb.SurroundColors = new[] { Color.FromArgb(0, 36, 36, 36) };
                    pgb.FocusScales = new PointF(0.70f, 0.70f);
                    g.FillPath(pgb, innerPath);
                }
            }

            g.Restore(state);
        }

        private static Region CreateRoundedRegion(int w, int h, int radius)
        {
            var path = CreateRoundedPath(new Rectangle(0, 0, w, h), radius);
            return new Region(path);
        }

        private static GraphicsPath CreateRoundedPath(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            int d = radius * 2;
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        // ---------------------------------------------------------------------
        // Custom Paint Handlers for Rounded Bubbles, Pill Input & Leaf Accents
        // ---------------------------------------------------------------------

        private void pnlWelcomeUserBubble_Paint(object sender, PaintEventArgs e)
        {
            var pnl = sender as Panel;
            if (pnl == null) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = CreateRoundedPath(new Rectangle(1, 1, pnl.Width - 3, pnl.Height - 3), 15))
            using (var pen = new Pen(Color.FromArgb(198, 165, 110), 1.2f))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        private void pnlWelcomeBotBubble_Paint(object sender, PaintEventArgs e)
        {
            var pnl = sender as Panel;
            if (pnl == null) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = CreateRoundedPath(new Rectangle(1, 1, pnl.Width - 3, pnl.Height - 3), 15))
            using (var pen = new Pen(OliveHeader, 2.0f))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        private void pnlInputPill_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = CreateRoundedPath(new Rectangle(1, 1, pnlInputPill.Width - 3, pnlInputPill.Height - 3), 23))
            using (var pen = new Pen(Color.FromArgb(215, 205, 185), 1.2f))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        private void pnlBottomArea_Paint(object sender, PaintEventArgs e)
        {
            // Subtle safari botanical leaf accents in bottom-left and bottom-right corners
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var brush = new SolidBrush(Color.FromArgb(90, 88, 110, 56)))
            {
                // Left corner leaves
                e.Graphics.FillEllipse(brush, new Rectangle(-8, 52, 28, 14));
                e.Graphics.FillEllipse(brush, new Rectangle(6, 66, 28, 12));
                e.Graphics.FillEllipse(brush, new Rectangle(22, 74, 24, 12));
                // Right corner leaves
                e.Graphics.FillEllipse(brush, new Rectangle(416, 52, 28, 14));
                e.Graphics.FillEllipse(brush, new Rectangle(404, 66, 28, 12));
                e.Graphics.FillEllipse(brush, new Rectangle(390, 74, 24, 12));
            }
        }

        // ---------------------------------------------------------------------
        // Window Dragging, Minimize, Close & Positioning
        // ---------------------------------------------------------------------

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClosePopup_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _spinnerTimer?.Stop();
            _spinnerTimer?.Dispose();
            base.OnFormClosed(e);
        }

        private void PositionFloatingPopup(Form owner)
        {
            try
            {
                Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
                if (owner != null && owner.Visible)
                {
                    int x = Math.Min(workingArea.Right - this.Width - 16, owner.Right - this.Width - 20);
                    int y = Math.Max(workingArea.Top + 16, owner.Bottom - this.Height - 20);
                    this.Location = new Point(Math.Max(workingArea.Left + 16, x), y);
                }
                else
                {
                    this.Location = new Point(
                        workingArea.Right - this.Width - 24,
                        workingArea.Bottom - this.Height - 24);
                }
            }
            catch
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }
        }

        private void UpdateApiStatusLabel()
        {
            lblModeStatus.Text = "🟢 Online && Tracking 🟢";
        }

        public void LoadActivitiesDropdown()
        {
            try
            {
                _cachedActivities = FileService.GetAllActivities();
                cboQuickActivity.Items.Clear();
                foreach (var a in _cachedActivities)
                {
                    string seatTag = a.SeatsAvailable > 0 ? $"{a.SeatsAvailable} seats" : "SOLD OUT";
                    cboQuickActivity.Items.Add($"{a.Name} (R{a.Price:N0} | {seatTag})");
                }
                if (cboQuickActivity.Items.Count > 0)
                    cboQuickActivity.SelectedIndex = 0;
            }
            catch { }
        }

        // ---------------------------------------------------------------------
        // Placeholder Text Handling ("Ask SafariScout...")
        // ---------------------------------------------------------------------

        private void txtUserMessage_Enter(object sender, EventArgs e)
        {
            if (txtUserMessage.Text == PlaceholderText)
            {
                txtUserMessage.Text = string.Empty;
                txtUserMessage.ForeColor = Color.FromArgb(30, 30, 30);
            }
        }

        private void txtUserMessage_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserMessage.Text))
            {
                txtUserMessage.Text = PlaceholderText;
                txtUserMessage.ForeColor = Color.FromArgb(120, 115, 105);
            }
        }

        // ---------------------------------------------------------------------
        // Dynamic Chat Bubble Creation (Matches Reference Screenshot)
        // ---------------------------------------------------------------------

        private void AppendUserMessage(string text)
        {
            pnlChatFeed.SuspendLayout();
            Point scrollOffset = pnlChatFeed.AutoScrollPosition;

            Font msgFont = new Font("Segoe UI", 9.75F, FontStyle.Regular);
            Size measured = TextRenderer.MeasureText(text, msgFont, new Size(288, 2000), TextFormatFlags.WordBreak);
            int bubbleH = Math.Max(52, measured.Height + 22);
            int rowH    = bubbleH + 10;

            var row = new Panel
            {
                BackColor = Color.Transparent,
                Location  = new Point(10, _nextBubbleY + scrollOffset.Y),
                Size      = new Size(400, rowH)
            };

            var bubble = new Panel
            {
                BackColor = UserTanBubble,
                Location  = new Point(34, 4),
                Size      = new Size(312, bubbleH)
            };
            bubble.Region = CreateRoundedRegion(bubble.Width, bubble.Height, 16);
            bubble.Paint += pnlWelcomeUserBubble_Paint;

            var lbl = new Label
            {
                BackColor = Color.Transparent,
                Font      = msgFont,
                ForeColor = Color.FromArgb(35, 30, 20),
                Location  = new Point(12, 10),
                Size      = new Size(288, bubbleH - 16),
                Text      = text
            };
            bubble.Controls.Add(lbl);

            var avatar = new PictureBox
            {
                Image    = global::PROJECTT.Properties.Resources.safariscout_user_avatar,
                Location = new Point(354, 4),
                Size     = new Size(42, 42),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            row.Controls.Add(bubble);
            row.Controls.Add(avatar);
            pnlChatFeed.Controls.Add(row);

            _nextBubbleY += rowH + 6;
            RepositionScoutingIndicator(scrollOffset);

            pnlChatFeed.ResumeLayout();
            pnlChatFeed.ScrollControlIntoView(pnlScoutingRow);
        }

        private void AppendBotMessage(string text, bool isBookingConfirmation = false)
        {
            pnlChatFeed.SuspendLayout();
            Point scrollOffset = pnlChatFeed.AutoScrollPosition;

            Font msgFont = isBookingConfirmation
                ? new Font("Consolas", 8.5F, FontStyle.Regular)
                : new Font("Segoe UI", 9.75F, FontStyle.Regular);

            Size measured = TextRenderer.MeasureText(text, msgFont, new Size(294, 4000), TextFormatFlags.WordBreak);
            int bubbleH = Math.Max(60, measured.Height + 26);
            int rowH    = bubbleH + 10;

            var row = new Panel
            {
                BackColor = Color.Transparent,
                Location  = new Point(10, _nextBubbleY + scrollOffset.Y),
                Size      = new Size(400, rowH)
            };

            var avatar = new PictureBox
            {
                Image    = global::PROJECTT.Properties.Resources.safariscout_bot_small,
                Location = new Point(4, 6),
                Size     = new Size(42, 42),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            var bubble = new Panel
            {
                BackColor = isBookingConfirmation ? Color.FromArgb(232, 245, 232) : BotCreamBubble,
                Location  = new Point(54, 4),
                Size      = new Size(320, bubbleH)
            };
            bubble.Region = CreateRoundedRegion(bubble.Width, bubble.Height, 16);
            bubble.Paint += pnlWelcomeBotBubble_Paint;

            var lbl = new Label
            {
                BackColor = Color.Transparent,
                Font      = msgFont,
                ForeColor = Color.FromArgb(30, 28, 22),
                Location  = new Point(12, 10),
                Size      = new Size(296, bubbleH - 18),
                Text      = text
            };
            bubble.Controls.Add(lbl);

            row.Controls.Add(avatar);
            row.Controls.Add(bubble);
            pnlChatFeed.Controls.Add(row);

            _nextBubbleY += rowH + 6;
            RepositionScoutingIndicator(scrollOffset);

            pnlChatFeed.ResumeLayout();
            pnlChatFeed.ScrollControlIntoView(pnlScoutingRow);
        }

        private void RepositionScoutingIndicator(Point scrollOffset)
        {
            pnlScoutingRow.Location = new Point(16, _nextBubbleY + scrollOffset.Y);
        }

        // ---------------------------------------------------------------------
        // Sending Messages & Processing Responses
        // ---------------------------------------------------------------------

        private async void SendUserQueryAsync(string query)
        {
            string trimmed = (query ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(trimmed) || trimmed == PlaceholderText) return;

            txtUserMessage.Text = string.Empty;
            AppendUserMessage(trimmed);

            lblScoutingText.Text = "SafariScout AI is scouting trails... 🐾";
            pnlScoutingRow.Visible = true;
            pnlNeonSpinner.Visible = true;
            pnlNeonSpinner.BringToFront();
            picSendBtn.Enabled = false;

            try
            {
                var delayTask = System.Threading.Tasks.Task.Delay(950);
                ChatbotResponse resp = await _chatService.ProcessMessageAsync(trimmed);
                await delayTask;
                pnlNeonSpinner.Visible = false;
                AppendBotMessage(resp.ReplyText, resp.BookingCreated);

                if (resp.BookingCreated)
                {
                    LoadActivitiesDropdown();
                    BookingCompleted?.Invoke(resp.CreatedBooking, resp.CreatedInvoice, resp.BookedActivity);
                }
            }
            catch (Exception ex)
            {
                AppendBotMessage("Sorry, I hit a bump on the safari trail: " + ex.Message);
            }
            finally
            {
                if (pnlNeonSpinner != null) pnlNeonSpinner.Visible = false;
                lblScoutingText.Text = "SafariScout AI is scouting trails... 🐾";
                picSendBtn.Enabled = true;
                txtUserMessage.Focus();
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            SendUserQueryAsync(txtUserMessage.Text);
        }

        private void txtUserMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendUserQueryAsync(txtUserMessage.Text);
            }
        }

        // ---------------------------------------------------------------------
        // Quick-Action Pill Chips
        // ---------------------------------------------------------------------

        private void btnChipSafaris_Click(object sender, EventArgs e)
            => SendUserQueryAsync("Show available Safaris and budget-friendly prices");

        private void btnChipAllTours_Click(object sender, EventArgs e)
            => SendUserQueryAsync("List all Wildlife Tours, Adventures, dates, and seats");

        private void btnChipFamilyDrives_Click(object sender, EventArgs e)
            => SendUserQueryAsync("Show Hiking Trails and Special Events for families");

        private void btnChipMyBookings_Click(object sender, EventArgs e)
            => SendUserQueryAsync("Show my bookings");

        // ---------------------------------------------------------------------
        // Instant Safari Booking Desk Drawer
        // ---------------------------------------------------------------------

        private void btnAttachBook_Click(object sender, EventArgs e)
        {
            pnlQuickBook.Visible = !pnlQuickBook.Visible;
            if (pnlQuickBook.Visible)
            {
                LoadActivitiesDropdown();
                pnlQuickBook.BringToFront();
            }
        }

        private void btnQuickBookNow_Click(object sender, EventArgs e)
        {
            int idx = cboQuickActivity.SelectedIndex;
            if (idx < 0 || idx >= _cachedActivities.Count)
            {
                MessageBox.Show("Please select a safari or tour from the dropdown first.", "Select Activity",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Activity selected = _cachedActivities[idx];
            int pax = (int)nudQuickPax.Value;

            if (MessageBox.Show(
                $"Confirm instant SafariScout booking & payment?\r\n\r\n" +
                $"Activity: {selected.Name} ({selected.Category})\r\n" +
                $"Date: {selected.Date:dd MMM yyyy}\r\n" +
                $"Participants: {pax}\r\n" +
                $"Total Amount: R{selected.Price * pax:N2}",
                "SafariScout AI – Confirm Booking",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            pnlQuickBook.Visible = false;
            AppendUserMessage($"Book {selected.Name} for {pax} participant(s)");
            ChatbotResponse resp = _chatService.ExecuteBooking(selected.ActivityID, pax);
            AppendBotMessage(resp.ReplyText, resp.BookingCreated);

            if (resp.BookingCreated)
            {
                LoadActivitiesDropdown();
                BookingCompleted?.Invoke(resp.CreatedBooking, resp.CreatedInvoice, resp.BookedActivity);
            }
        }

        private void btnOpenInDash_Click(object sender, EventArgs e)
        {
            int idx = cboQuickActivity.SelectedIndex;
            if (idx < 0 || idx >= _cachedActivities.Count) return;

            Activity selected = _cachedActivities[idx];
            int pax = (int)nudQuickPax.Value;

            pnlQuickBook.Visible = false;
            if (_parentDashboard != null && !_parentDashboard.IsDisposed)
            {
                _parentDashboard.OpenBookingFromChatbot(selected.ActivityID, pax);
                _parentDashboard.Activate();
            }
        }

    }
}
