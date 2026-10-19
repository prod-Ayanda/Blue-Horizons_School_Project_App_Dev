// =============================================================================
// Services/SafariThemeEngine.cs
// Unified UI Component & Theme Engine for Blue Horizons Tours.
//
// Synthesizes signature components from 4 modern UI libraries:
//   1. Uiverse.io    (https://uiverse.io/)          – Gradient Glow CTA Buttons, Dark Glass Inputs, Neon Loaders
//   2. Kexsio UI     (Kexsio Dark Glass & Beams)    – #06080E 44px Grid Canvas, AnimatedBeam Journey Pipelines
//   3. Kokonut UI    (https://kokonutui.com/)       – Background Paths, Apple Activity Rings, Spotlight Cards,
//                                                     Action Search Bar, Currency Transfer Checkout, Morphic Nav
//   4. Bklit UI      (https://bklit.com/)           – Dot-Grid Analytics Cards, Rounded Gradient Bars, Tooltips
// =============================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using PROJECTT.Models;

namespace PROJECTT.Services
{
    public static class SafariThemeEngine
    {
        // ── Safari Sunset & Midnight Glass Palette ─────────────────────────
        public static readonly Color ObsidianBg     = Color.FromArgb(6, 8, 14);
        public static readonly Color SidebarBg      = Color.FromArgb(9, 12, 20);
        public static readonly Color SidebarHeader  = Color.FromArgb(13, 17, 28);
        public static readonly Color GlassSurface   = Color.FromArgb(15, 19, 30);
        public static readonly Color GlassCard      = Color.FromArgb(20, 25, 40);
        public static readonly Color InputBg        = Color.FromArgb(24, 30, 48);
        public static readonly Color SafariEmerald  = Color.FromArgb(16, 185, 129);
        public static readonly Color SunsetAmber    = Color.FromArgb(245, 158, 11);
        public static readonly Color HorizonCyan    = Color.FromArgb(56, 189, 248);
        public static readonly Color RoyalViolet    = Color.FromArgb(139, 92, 246);
        public static readonly Color CrimsonCoral   = Color.FromArgb(239, 68, 68);
        public static readonly Color TextPrimary    = Color.FromArgb(245, 247, 255);
        public static readonly Color TextSecondary  = Color.FromArgb(165, 175, 205);

        public static void EnableDoubleBuffering(Control ctrl)
        {
            if (ctrl == null) return;
            try
            {
                typeof(Control).InvokeMember("DoubleBuffered",
                    BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                    null, ctrl, new object[] { true });
            }
            catch { }
        }

        public static GraphicsPath CreateRoundRect(RectangleF rect, float radius)
        {
            var path = new GraphicsPath();
            float d = Math.Max(2f, radius * 2f);
            if (d > rect.Width)  d = rect.Width;
            if (d > rect.Height) d = rect.Height;
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        public static Color Interpolate(Color a, Color b, float t)
        {
            t = Math.Max(0f, Math.Min(1f, t));
            return Color.FromArgb(
                (int)(a.R + (b.R - a.R) * t),
                (int)(a.G + (b.G - a.G) * t),
                (int)(a.B + (b.B - a.B) * t));
        }

        // =================================================================
        //  1. ENTRY & AUTHENTICATION FORM REDESIGN ENGINE
        //     (Welcome, Login, Register, Passkey, AdminLogin, Forgot/Reset, Terms)
        // =================================================================

        public static void ApplyAuthFormTheme(Form form, string pillBadge, Color primaryAccent)
        {
            if (form == null) return;
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            EnableDoubleBuffering(form);
            form.BackColor = ObsidianBg;
            form.ForeColor = TextPrimary;

            form.Paint += (s, e) =>
            {
                if (form.BackgroundImage == null)
                {
                    PaintKokonutBackgroundPathsAndGrid(e.Graphics, form.ClientSize.Width, form.ClientSize.Height, primaryAccent, pillBadge);
                }
            };
            form.Resize += (s, e) => form.Invalidate();

            StyleAuthControlsRecursive(form, primaryAccent);
        }

        private static void StyleAuthControlsRecursive(Control parent, Color accent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Panel pnl)
                {
                    EnableDoubleBuffering(pnl);
                    // Preserve background image if it's a photo panel, but add glass frame
                    if (pnl.BackgroundImage == null)
                    {
                        pnl.BackColor = GlassSurface;
                    }
                    pnl.Paint += (s, e) =>
                    {
                        if (pnl.Width < 20 || pnl.Height < 20) return;
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        if (pnl.BackgroundImage == null)
                        {
                            using (var grad = new LinearGradientBrush(
                                new Rectangle(0, 0, pnl.Width, pnl.Height),
                                Color.FromArgb(215, 22, 28, 45),
                                Color.FromArgb(230, 12, 15, 26),
                                135f))
                            {
                                e.Graphics.FillRectangle(grad, 0, 0, pnl.Width, pnl.Height);
                            }
                        }
                        using (var borderPen = new Pen(Color.FromArgb(55, 255, 255, 255), 1f))
                        {
                            e.Graphics.DrawRectangle(borderPen, 0, 0, pnl.Width - 1, pnl.Height - 1);
                        }
                        using (var topGlow = new Pen(accent, 2.5f))
                        {
                            e.Graphics.DrawLine(topGlow, 1, 1, pnl.Width - 2, 1);
                        }
                    };
                    StyleAuthControlsRecursive(pnl, accent);
                }
                else if (c is Button btn)
                {
                    bool isSecondary = btn.Name.IndexOf("Cancel", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                       btn.Name.IndexOf("Admin", StringComparison.OrdinalIgnoreCase) >= 0 && btn.Text.IndexOf("Log", StringComparison.OrdinalIgnoreCase) < 0;
                    Color c1 = isSecondary ? RoyalViolet : accent;
                    Color c2 = isSecondary ? HorizonCyan : SunsetAmber;
                    AttachUiverseButtonGlow(btn, c1, c2);
                }
                else if (c is TextBox txt)
                {
                    txt.BackColor = InputBg;
                    txt.ForeColor = Color.White;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (c is ComboBox cmb)
                {
                    cmb.BackColor = InputBg;
                    cmb.ForeColor = Color.White;
                    cmb.FlatStyle = FlatStyle.Flat;
                }
                else if (c is CheckBox chk)
                {
                    chk.BackColor = Color.Transparent;
                    chk.ForeColor = TextSecondary;
                }
                else if (c is RadioButton rad)
                {
                    rad.BackColor = Color.Transparent;
                    rad.ForeColor = TextPrimary;
                }
                else if (c is LinkLabel lnk)
                {
                    lnk.BackColor = Color.Transparent;
                    lnk.LinkColor = HorizonCyan;
                    lnk.ActiveLinkColor = SunsetAmber;
                    lnk.VisitedLinkColor = HorizonCyan;
                }
                else if (c is Label lbl)
                {
                    lbl.BackColor = Color.Transparent;
                    bool isViolation = lbl.Name.IndexOf("Violation", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                       lbl.Name.IndexOf("Error", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                       lbl.ForeColor == Color.Red || lbl.ForeColor == Color.DarkRed;
                    bool isAvailable = lbl.Name.IndexOf("Available", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                       lbl.ForeColor == Color.Green || lbl.ForeColor == Color.DarkGreen;

                    if (isViolation)
                        lbl.ForeColor = Color.FromArgb(255, 110, 110);
                    else if (isAvailable)
                        lbl.ForeColor = SafariEmerald;
                    else if (lbl.Font.Size >= 14F || lbl.Font.Bold)
                        lbl.ForeColor = TextPrimary;
                    else
                        lbl.ForeColor = TextSecondary;
                }
            }
        }

        // =================================================================
        //  2. UIVERSE.IO GRADIENT GLOW & SHIMMER BUTTON STYLER
        // =================================================================

        public static void AttachUiverseButtonGlow(Button btn, Color gradStart, Color gradEnd, bool isOutline = false)
        {
            if (btn == null) return;
            EnableDoubleBuffering(btn);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.UseVisualStyleBackColor = false;
            btn.Cursor = Cursors.Hand;
            btn.BackColor = isOutline ? Color.FromArgb(22, 27, 42) : gradStart;
            btn.ForeColor = Color.White;

            bool hovered = false;
            btn.MouseEnter += (s, e) => { hovered = true; btn.Invalidate(); };
            btn.MouseLeave += (s, e) => { hovered = false; btn.Invalidate(); };

            btn.Paint += (s, e) =>
            {
                if (btn.Width < 10 || btn.Height < 10) return;
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

                // Clear parent edge corners cleanly
                Color parentBg = btn.Parent != null && btn.Parent.BackColor != Color.Transparent
                    ? btn.Parent.BackColor
                    : ObsidianBg;
                using (var clearBrush = new SolidBrush(parentBg))
                {
                    g.FillRectangle(clearBrush, -1, -1, btn.Width + 2, btn.Height + 2);
                }

                RectangleF rect = new RectangleF(1.5f, 1.5f, btn.Width - 3f, btn.Height - 3f);
                float radius = Math.Min(12f, rect.Height / 2f);

                using (var path = CreateRoundRect(rect, radius))
                {
                    if (!btn.Enabled)
                    {
                        using (var disBrush = new SolidBrush(Color.FromArgb(40, 45, 62)))
                            g.FillPath(disBrush, path);
                        using (var disPen = new Pen(Color.FromArgb(60, 255, 255, 255), 1f))
                            g.DrawPath(disPen, path);
                    }
                    else if (isOutline)
                    {
                        using (var bgBrush = new SolidBrush(hovered ? Color.FromArgb(34, 42, 66) : Color.FromArgb(20, 25, 39)))
                            g.FillPath(bgBrush, path);
                        using (var borderPen = new Pen(hovered ? gradEnd : Color.FromArgb(140, gradStart), hovered ? 1.8f : 1.2f))
                            g.DrawPath(borderPen, path);
                    }
                    else
                    {
                        Color c1 = hovered ? Interpolate(gradStart, Color.White, 0.16f) : gradStart;
                        Color c2 = hovered ? Interpolate(gradEnd, Color.White, 0.16f) : gradEnd;
                        using (var grad = new LinearGradientBrush(rect, c1, c2, 18f))
                        {
                            g.FillPath(grad, path);
                        }
                        using (var borderPen = new Pen(Color.FromArgb(hovered ? 170 : 75, 255, 255, 255), 1.2f))
                        {
                            g.DrawPath(borderPen, path);
                        }
                    }
                }

                var sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center,
                    Trimming = StringTrimming.EllipsisCharacter
                };
                using (var txtBrush = new SolidBrush(btn.Enabled ? Color.White : Color.FromArgb(135, 140, 160)))
                {
                    g.DrawString(btn.Text, btn.Font, txtBrush, rect, sf);
                }
            };
        }

        // =================================================================
        //  2B. ADMIN DASHBOARD ICON & NAVIGATION SUITE (BUTTON-THEME MATCHED)
        // =================================================================

        public enum AdminDashboardIcon
        {
            Overview,
            Activities,
            Bookings,
            Attendance,
            Reports,
            AiSettings,
            ChangePassword,
            Logout,
            BlueHorizonsCore,
            Revenue,
            Upcoming,
            SeatsAvailable
        }

        public static void DrawAdminDashboardIcon(
            Graphics g,
            RectangleF bounds,
            AdminDashboardIcon icon,
            Color gradStart,
            Color gradEnd,
            bool drawPillBackground = true,
            bool isHovered = false)
        {
            if (bounds.Width < 8 || bounds.Height < 8) return;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            RectangleF iconArea = bounds;

            if (drawPillBackground)
            {
                float radius = Math.Min(bounds.Width, bounds.Height) * 0.28f;
                // Outer glow shadow on hover
                if (isHovered)
                {
                    RectangleF glowRect = bounds;
                    glowRect.Inflate(3f, 3f);
                    using (var gp = CreateRoundRect(glowRect, radius + 2f))
                    using (var gb = new SolidBrush(Color.FromArgb(60, gradStart)))
                        g.FillPath(gb, gp);
                }

                using (var path = CreateRoundRect(bounds, radius))
                {
                    Color c1 = isHovered ? Interpolate(gradStart, Color.White, 0.16f) : gradStart;
                    Color c2 = isHovered ? Interpolate(gradEnd, Color.White, 0.16f) : gradEnd;

                    using (var grad = new LinearGradientBrush(bounds, c1, c2, 45f))
                    {
                        g.FillPath(grad, path);
                    }
                    using (var borderPen = new Pen(Color.FromArgb(isHovered ? 210 : 110, 255, 255, 255), 1.2f))
                    {
                        g.DrawPath(borderPen, path);
                    }
                }

                // Inner glyph target area (scaled proportionally)
                float pad = Math.Max(3f, bounds.Width * 0.22f);
                iconArea = new RectangleF(bounds.X + pad, bounds.Y + pad, bounds.Width - pad * 2f, bounds.Height - pad * 2f);
            }

            float cx = iconArea.X + iconArea.Width / 2f;
            float cy = iconArea.Y + iconArea.Height / 2f;
            float w = iconArea.Width;
            float h = iconArea.Height;
            float stroke = Math.Max(1.4f, Math.Min(w, h) * 0.095f);

            using (var pen = new Pen(Color.White, stroke))
            using (var fillBrush = new SolidBrush(Color.White))
            using (var semiBrush = new SolidBrush(Color.FromArgb(190, 255, 255, 255)))
            {
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
                pen.LineJoin = LineJoin.Round;

                switch (icon)
                {
                    case AdminDashboardIcon.Overview:
                    {
                        // 4 rounded dashboard module tiles
                        float gap = Math.Max(1.5f, w * 0.12f);
                        float tw = (w - gap) / 2f;
                        float th = (h - gap) / 2f;
                        float r = Math.Max(1.5f, tw * 0.24f);

                        RectangleF t1 = new RectangleF(iconArea.X, iconArea.Y, tw, th);
                        RectangleF t2 = new RectangleF(iconArea.X + tw + gap, iconArea.Y, tw, th);
                        RectangleF t3 = new RectangleF(iconArea.X, iconArea.Y + th + gap, tw, th);
                        RectangleF t4 = new RectangleF(iconArea.X + tw + gap, iconArea.Y + th + gap, tw, th);

                        using (var p1 = CreateRoundRect(t1, r)) g.FillPath(fillBrush, p1);
                        using (var p2 = CreateRoundRect(t2, r)) g.FillPath(semiBrush, p2);
                        using (var p3 = CreateRoundRect(t3, r)) g.FillPath(semiBrush, p3);
                        using (var p4 = CreateRoundRect(t4, r)) g.FillPath(fillBrush, p4);
                        break;
                    }
                    case AdminDashboardIcon.Activities:
                    {
                        // Safari adventure: Twin mountain peaks with summit flag & compass sun
                        PointF[] leftPeak = {
                            new PointF(cx - w * 0.44f, cy + h * 0.38f),
                            new PointF(cx - w * 0.12f, cy - h * 0.14f),
                            new PointF(cx + w * 0.16f, cy + h * 0.38f)
                        };
                        PointF[] rightPeak = {
                            new PointF(cx - w * 0.08f, cy + h * 0.38f),
                            new PointF(cx + w * 0.20f, cy - h * 0.32f),
                            new PointF(cx + w * 0.46f, cy + h * 0.38f)
                        };
                        g.DrawLines(pen, leftPeak);
                        g.DrawLines(pen, rightPeak);

                        // Summit flag
                        float fx = cx + w * 0.20f;
                        float fy = cy - h * 0.32f;
                        g.DrawLine(pen, fx, fy, fx, fy - h * 0.16f);
                        PointF[] flag = {
                            new PointF(fx, fy - h * 0.16f),
                            new PointF(fx + w * 0.20f, fy - h * 0.08f),
                            new PointF(fx, fy)
                        };
                        g.FillPolygon(fillBrush, flag);

                        // Sun / compass star
                        g.FillEllipse(fillBrush, cx - w * 0.32f, cy - h * 0.36f, w * 0.22f, h * 0.22f);
                        break;
                    }
                    case AdminDashboardIcon.Bookings:
                    {
                        // Ticket pass voucher with calendar notches & checkmark
                        float tw = w * 0.86f;
                        float th = h * 0.94f;
                        RectangleF tRect = new RectangleF(cx - tw / 2f, cy - th / 2f, tw, th);
                        float r = Math.Max(2f, tw * 0.16f);

                        using (var tPath = CreateRoundRect(tRect, r))
                        {
                            g.DrawPath(pen, tPath);
                        }

                        // Perforation / divider line
                        float divY = tRect.Y + th * 0.42f;
                        using (var dashPen = new Pen(Color.White, Math.Max(1f, stroke * 0.8f)))
                        {
                            dashPen.DashStyle = DashStyle.Dash;
                            g.DrawLine(dashPen, tRect.Left + 2f, divY, tRect.Right - 2f, divY);
                        }

                        // Calendar grid header bar
                        g.DrawLine(pen, tRect.Left + tw * 0.22f, tRect.Y + th * 0.22f, tRect.Right - tw * 0.22f, tRect.Y + th * 0.22f);

                        // Ticket Checkmark in bottom section
                        PointF[] chk = {
                            new PointF(cx - tw * 0.22f, cy + th * 0.18f),
                            new PointF(cx - tw * 0.04f, cy + th * 0.32f),
                            new PointF(cx + tw * 0.24f, cy + th * 0.08f)
                        };
                        g.DrawLines(pen, chk);
                        break;
                    }
                    case AdminDashboardIcon.Attendance:
                    {
                        // Verified Checkmark Shield
                        PointF[] shield = {
                            new PointF(cx - w * 0.40f, cy - h * 0.38f),
                            new PointF(cx + w * 0.40f, cy - h * 0.38f),
                            new PointF(cx + w * 0.40f, cy + h * 0.04f),
                            new PointF(cx, cy + h * 0.44f),
                            new PointF(cx - w * 0.40f, cy + h * 0.04f)
                        };
                        using (var sPath = new GraphicsPath())
                        {
                            sPath.AddLines(shield);
                            sPath.CloseFigure();
                            g.DrawPath(pen, sPath);
                        }

                        // Bold checkmark inside shield
                        using (var chkPen = new Pen(Color.White, stroke * 1.3f))
                        {
                            chkPen.StartCap = LineCap.Round;
                            chkPen.EndCap = LineCap.Round;
                            PointF[] chk = {
                                new PointF(cx - w * 0.20f, cy + h * 0.02f),
                                new PointF(cx - w * 0.04f, cy + h * 0.18f),
                                new PointF(cx + w * 0.22f, cy - h * 0.12f)
                            };
                            g.DrawLines(chkPen, chk);
                        }
                        break;
                    }
                    case AdminDashboardIcon.Reports:
                    {
                        // Rising analytics bar chart + ascending trend arrow
                        float bw = w * 0.20f;
                        float baseY = cy + h * 0.38f;

                        // 3 bars
                        RectangleF b1 = new RectangleF(cx - w * 0.42f, baseY - h * 0.34f, bw, h * 0.34f);
                        RectangleF b2 = new RectangleF(cx - bw / 2f,   baseY - h * 0.54f, bw, h * 0.54f);
                        RectangleF b3 = new RectangleF(cx + w * 0.22f, baseY - h * 0.74f, bw, h * 0.74f);

                        float br = Math.Max(1.5f, bw * 0.3f);
                        using (var p1 = CreateRoundRect(b1, br)) g.FillPath(semiBrush, p1);
                        using (var p2 = CreateRoundRect(b2, br)) g.FillPath(fillBrush, p2);
                        using (var p3 = CreateRoundRect(b3, br)) g.FillPath(fillBrush, p3);

                        // Trend line with arrow
                        using (var trendPen = new Pen(Color.White, Math.Max(1.2f, stroke * 0.9f)))
                        {
                            trendPen.StartCap = LineCap.Round;
                            trendPen.EndCap = LineCap.Round;
                            PointF pStart = new PointF(cx - w * 0.40f, baseY - h * 0.42f);
                            PointF pMid   = new PointF(cx, baseY - h * 0.62f);
                            PointF pEnd   = new PointF(cx + w * 0.38f, baseY - h * 0.86f);
                            g.DrawLine(trendPen, pStart, pMid);
                            g.DrawLine(trendPen, pMid, pEnd);

                            // Arrow head
                            g.DrawLine(trendPen, pEnd.X - w * 0.12f, pEnd.Y, pEnd.X, pEnd.Y);
                            g.DrawLine(trendPen, pEnd.X, pEnd.Y + h * 0.12f, pEnd.X, pEnd.Y);
                        }
                        break;
                    }
                    case AdminDashboardIcon.AiSettings:
                    {
                        // Neural AI Scout Bot Visor & Compass Spark
                        RectangleF faceRect = new RectangleF(cx - w * 0.38f, cy - h * 0.18f, w * 0.76f, h * 0.56f);
                        using (var fPath = CreateRoundRect(faceRect, Math.Max(2f, faceRect.Width * 0.22f)))
                        {
                            g.DrawPath(pen, fPath);
                        }

                        // Eyes visor
                        float eyeY = cy + h * 0.08f;
                        g.FillEllipse(fillBrush, cx - w * 0.22f, eyeY - h * 0.08f, w * 0.16f, h * 0.16f);
                        g.FillEllipse(fillBrush, cx + w * 0.06f, eyeY - h * 0.08f, w * 0.16f, h * 0.16f);

                        // Antenna & AI Spark star
                        g.DrawLine(pen, cx, faceRect.Top, cx, faceRect.Top - h * 0.14f);
                        float starY = faceRect.Top - h * 0.22f;
                        g.DrawLine(pen, cx - w * 0.12f, starY, cx + w * 0.12f, starY);
                        g.DrawLine(pen, cx, starY - h * 0.12f, cx, starY + h * 0.12f);
                        break;
                    }
                    case AdminDashboardIcon.ChangePassword:
                    {
                        // Security Padlock
                        float bodyW = w * 0.68f;
                        float bodyH = h * 0.48f;
                        RectangleF body = new RectangleF(cx - bodyW / 2f, cy - h * 0.02f, bodyW, bodyH);
                        using (var bPath = CreateRoundRect(body, Math.Max(2f, bodyW * 0.18f)))
                        {
                            g.FillPath(fillBrush, bPath);
                        }

                        // Shackle arch above
                        float shackleW = bodyW * 0.60f;
                        float shackleH = h * 0.34f;
                        RectangleF shackle = new RectangleF(cx - shackleW / 2f, body.Top - shackleH + stroke, shackleW, shackleH * 1.5f);
                        using (var shacklePen = new Pen(Color.White, Math.Max(1.8f, stroke * 1.25f)))
                        {
                            shacklePen.StartCap = LineCap.Round;
                            shacklePen.EndCap = LineCap.Round;
                            g.DrawArc(shacklePen, shackle, 180, 180);
                        }

                        // Keyhole inside body
                        using (var darkBrush = new SolidBrush(Color.FromArgb(16, 16, 24)))
                        {
                            g.FillEllipse(darkBrush, cx - w * 0.08f, body.Top + bodyH * 0.25f, w * 0.16f, h * 0.16f);
                            PointF[] keySlot = {
                                new PointF(cx - w * 0.05f, body.Top + bodyH * 0.35f),
                                new PointF(cx + w * 0.05f, body.Top + bodyH * 0.35f),
                                new PointF(cx + w * 0.07f, body.Top + bodyH * 0.68f),
                                new PointF(cx - w * 0.07f, body.Top + bodyH * 0.68f)
                            };
                            g.FillPolygon(darkBrush, keySlot);
                        }
                        break;
                    }
                    case AdminDashboardIcon.Logout:
                    {
                        // Power / Exit Door Symbol
                        float r = w * 0.40f;
                        RectangleF arcRect = new RectangleF(cx - r, cy - r + h * 0.06f, r * 2f, r * 2f);
                        using (var powerPen = new Pen(Color.White, stroke * 1.2f))
                        {
                            powerPen.StartCap = LineCap.Round;
                            powerPen.EndCap = LineCap.Round;
                            g.DrawArc(powerPen, arcRect, -50, 280);
                            // Vertical power stroke
                            g.DrawLine(powerPen, cx, cy - h * 0.40f, cx, cy + h * 0.02f);
                        }
                        break;
                    }
                    case AdminDashboardIcon.BlueHorizonsCore:
                    {
                        // Central Core Hub: Rising Safari Sun, Horizon Curve & 8-point compass star
                        // Sun arc
                        float sunR = w * 0.28f;
                        g.FillEllipse(fillBrush, cx - sunR, cy - h * 0.08f - sunR, sunR * 2f, sunR * 2f);

                        // Horizon wave curves
                        using (var wavePen = new Pen(Color.White, Math.Max(1.6f, stroke)))
                        {
                            wavePen.StartCap = LineCap.Round;
                            wavePen.EndCap = LineCap.Round;
                            g.DrawLine(wavePen, cx - w * 0.44f, cy + h * 0.16f, cx + w * 0.44f, cy + h * 0.16f);
                            g.DrawLine(wavePen, cx - w * 0.32f, cy + h * 0.32f, cx + w * 0.32f, cy + h * 0.32f);
                        }

                        // Compass 4 rays emitting from sun
                        using (var rayPen = new Pen(Color.White, stroke * 0.9f))
                        {
                            rayPen.StartCap = LineCap.Round;
                            rayPen.EndCap = LineCap.Round;
                            g.DrawLine(rayPen, cx, cy - h * 0.42f, cx, cy - h * 0.24f);
                            g.DrawLine(rayPen, cx - w * 0.38f, cy - h * 0.08f, cx - w * 0.20f, cy - h * 0.08f);
                            g.DrawLine(rayPen, cx + w * 0.20f, cy - h * 0.08f, cx + w * 0.38f, cy - h * 0.08f);
                            g.DrawLine(rayPen, cx - w * 0.26f, cy - h * 0.28f, cx - w * 0.14f, cy - h * 0.18f);
                            g.DrawLine(rayPen, cx + w * 0.14f, cy - h * 0.18f, cx + w * 0.26f, cy - h * 0.28f);
                        }
                        break;
                    }
                    case AdminDashboardIcon.Revenue:
                    {
                        // Currency Rand (R) symbol styled with clean bold typography
                        using (var rFnt = new Font("Arial", w * 0.70f, FontStyle.Bold))
                        {
                            var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                            g.DrawString("R", rFnt, fillBrush, iconArea, sf);
                        }
                        break;
                    }
                    case AdminDashboardIcon.Upcoming:
                    {
                        // Calendar Clock
                        float cw = w * 0.78f;
                        float ch = h * 0.78f;
                        RectangleF cal = new RectangleF(cx - cw / 2f, cy - ch / 2f + h * 0.06f, cw, ch);
                        using (var cPath = CreateRoundRect(cal, Math.Max(2f, cw * 0.2f)))
                        {
                            g.DrawPath(pen, cPath);
                        }
                        // Top calendar clips
                        g.DrawLine(pen, cal.Left + cw * 0.26f, cal.Top - h * 0.08f, cal.Left + cw * 0.26f, cal.Top + h * 0.04f);
                        g.DrawLine(pen, cal.Right - cw * 0.26f, cal.Top - h * 0.08f, cal.Right - cw * 0.26f, cal.Top + h * 0.04f);
                        // Clock hands inside
                        g.DrawLine(pen, cx, cy + h * 0.06f, cx, cy - h * 0.08f);
                        g.DrawLine(pen, cx, cy + h * 0.06f, cx + w * 0.14f, cy + h * 0.06f);
                        break;
                    }
                    case AdminDashboardIcon.SeatsAvailable:
                    {
                        // Users / Seat Capacity silhouette
                        float headR = w * 0.16f;
                        g.FillEllipse(fillBrush, cx - headR, cy - h * 0.34f, headR * 2f, headR * 2f);
                        // Body arch
                        RectangleF bodyArch = new RectangleF(cx - w * 0.34f, cy - h * 0.04f, w * 0.68f, h * 0.52f);
                        using (var bodyPen = new Pen(Color.White, stroke * 1.2f))
                        {
                            bodyPen.StartCap = LineCap.Round;
                            bodyPen.EndCap = LineCap.Round;
                            g.DrawArc(bodyPen, bodyArch, 180, 180);
                        }
                        break;
                    }
                }
            }
        }

        public static void AttachAdminNavButtonTheme(
            Button btn,
            AdminDashboardIcon icon,
            Color gradStart,
            Color gradEnd,
            Func<bool> isActive,
            string explicitText = null)
        {
            if (btn == null) return;
            EnableDoubleBuffering(btn);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.UseVisualStyleBackColor = false;
            btn.Cursor = Cursors.Hand;
            btn.BackColor = Color.FromArgb(9, 9, 16);

            bool hovered = false;
            btn.MouseEnter += (s, e) => { hovered = true; btn.Invalidate(); };
            btn.MouseLeave += (s, e) => { hovered = false; btn.Invalidate(); };

            string label = explicitText ?? btn.Text.Trim();
            // Remove any leading emojis or symbols
            label = System.Text.RegularExpressions.Regex.Replace(label, @"^[^\w\s]+\s*", "").Trim();

            btn.Paint += (s, e) =>
            {
                if (btn.Width < 10 || btn.Height < 10) return;
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

                bool active = isActive != null && isActive();

                // 1. Clear background cleanly
                using (var clearBrush = new SolidBrush(Color.FromArgb(9, 9, 16)))
                {
                    g.FillRectangle(clearBrush, 0, 0, btn.Width, btn.Height);
                }

                // 2. Container pill
                RectangleF pillRect = new RectangleF(8f, 3f, btn.Width - 16f, btn.Height - 6f);
                float radius = 10f;

                if (active)
                {
                    using (var path = CreateRoundRect(pillRect, radius))
                    {
                        using (var grad = new LinearGradientBrush(
                            pillRect, Color.FromArgb(46, 38, 78), Color.FromArgb(24, 20, 44), 90f))
                        {
                            g.FillPath(grad, path);
                        }
                        using (var borderPen = new Pen(Color.FromArgb(140, gradStart), 1.2f))
                        {
                            g.DrawPath(borderPen, path);
                        }
                    }

                    // Left neon indicator bar
                    RectangleF barRect = new RectangleF(8f, (btn.Height - 24f) / 2f, 3.5f, 24f);
                    using (var barPath = CreateRoundRect(barRect, 1.75f))
                    using (var barBrush = new LinearGradientBrush(barRect, gradStart, gradEnd, 90f))
                    {
                        g.FillPath(barBrush, barPath);
                    }
                }
                else if (hovered)
                {
                    using (var path = CreateRoundRect(pillRect, radius))
                    {
                        using (var hoverBrush = new SolidBrush(
                            icon == AdminDashboardIcon.Logout ? Color.FromArgb(40, 16, 24) : Color.FromArgb(22, 22, 34)))
                        {
                            g.FillPath(hoverBrush, path);
                        }
                        using (var borderPen = new Pen(Color.FromArgb(50, 255, 255, 255), 1f))
                        {
                            g.DrawPath(borderPen, path);
                        }
                    }
                }

                // 3. Glowing Icon Badge matching button theme
                float badgeSize = 30f;
                float badgeX = 18f;
                float badgeY = (btn.Height - badgeSize) / 2f;
                RectangleF badgeRect = new RectangleF(badgeX, badgeY, badgeSize, badgeSize);

                DrawAdminDashboardIcon(g, badgeRect, icon, gradStart, gradEnd, drawPillBackground: true, isHovered: hovered || active);

                // 4. Nav label text
                float textX = badgeRect.Right + 12f;
                RectangleF textRect = new RectangleF(textX, 0, btn.Width - textX - 6f, btn.Height);
                using (var navFont = new Font("Segoe UI", active ? 9.75F : 9.5F, active ? FontStyle.Bold : FontStyle.Regular))
                using (var txtBrush = new SolidBrush(active ? Color.White : (hovered ? Color.FromArgb(245, 247, 255) : Color.FromArgb(165, 172, 195))))
                {
                    var sf = new StringFormat
                    {
                        Alignment = StringAlignment.Near,
                        LineAlignment = StringAlignment.Center,
                        Trimming = StringTrimming.EllipsisCharacter
                    };
                    g.DrawString(label, navFont, txtBrush, textRect, sf);
                }
            };
        }

        // =================================================================
        //  3. KOKONUT UI BACKGROUND PATHS + KEXSIO DARK GRID CANVAS
        // =================================================================

        public static void PaintKokonutBackgroundPathsAndGrid(
            Graphics g, int w, int h, Color accent, string badgeText = null)
        {
            if (w <= 0 || h <= 0) return;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // 1. Subtle 44px Kexsio dark grid
            using (var gridPen = new Pen(Color.FromArgb(10, 255, 255, 255), 1f))
            {
                for (int x = 0; x < w; x += 44) g.DrawLine(gridPen, x, 0, x, h);
                for (int y = 0; y < h; y += 44) g.DrawLine(gridPen, 0, y, w, y);
            }

            // 2. Kokonut UI "shape-hero" ambient glow orbs
            using (var orb1 = new SolidBrush(Color.FromArgb(18, accent)))
            using (var orb2 = new SolidBrush(Color.FromArgb(14, SunsetAmber)))
            {
                g.FillEllipse(orb1, -60, -50, 320, 320);
                g.FillEllipse(orb2, w - 280, h - 260, 340, 340);
            }

            // 3. Kokonut UI "background-paths" flowing topographic safari wave lines
            for (int wave = 0; wave < 4; wave++)
            {
                PointF[] pts = new PointF[6];
                float baseY = h * (0.18f + wave * 0.20f);
                for (int i = 0; i < 6; i++)
                {
                    float px = (w / 5f) * i;
                    float py = baseY + (float)Math.Sin(i * 1.1 + wave * 0.8) * 28f;
                    pts[i] = new PointF(px, py);
                }
                using (var wavePen = new Pen(Color.FromArgb(14 - wave * 2, accent), 1.3f))
                {
                    g.DrawCurve(wavePen, pts, 0.5f);
                }
            }

            // 4. Optional top-right pill badge
            if (!string.IsNullOrEmpty(badgeText))
            {
                using (var fnt = new Font("Segoe UI", 7.5F, FontStyle.Bold))
                {
                    SizeF sz = g.MeasureString(badgeText, fnt);
                    RectangleF pill = new RectangleF(w - sz.Width - 28f, 12f, sz.Width + 16f, 22f);
                    using (var path = CreateRoundRect(pill, 11f))
                    using (var fill = new SolidBrush(Color.FromArgb(32, accent)))
                    using (var pen = new Pen(Color.FromArgb(110, accent), 1f))
                    using (var brush = new SolidBrush(Color.FromArgb(225, 235, 255)))
                    {
                        g.FillPath(fill, path);
                        g.DrawPath(pen, path);
                        var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                        g.DrawString(badgeText, fnt, brush, pill, sf);
                    }
                }
            }
        }

        // =================================================================
        //  4. KOKONUT UI "APPLE-ACTIVITY-CARD" + BKLIT UI LIVE SAFARI WIDGET
        //     (Rendered on VisitorDashboardForm Home Screen)
        // =================================================================

        public static void DrawVisitorAnalyticsHub(
            Graphics g, int w, int h,
            int totalBookings, int upcomingBookings, decimal totalSpent,
            List<Activity> activities, float animTick)
        {
            if (w < 120 || h < 120) return;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            int gap = 14;
            int leftW = Math.Max(220, (w - gap) * 46 / 100);
            int rightW = Math.Max(220, w - leftW - gap);

            // ── Left Card: Kokonut UI Apple Activity Rings ("Safari Explorer Rings") ──
            RectangleF leftCard = new RectangleF(1f, 1f, leftW - 2f, h - 2f);
            DrawDarkGlassCardFrame(g, leftCard, "KOKONUT ACTIVITY RINGS", SafariEmerald,
                "Safari Explorer Progress", "Live booking, upcoming & loyalty tier rings");

            float ringSize = Math.Min(leftCard.Width * 0.42f, leftCard.Height - 78f);
            ringSize = Math.Max(76f, Math.Min(140f, ringSize));
            float rcx = leftCard.X + 20f + ringSize / 2f;
            float rcy = leftCard.Y + 52f + (leftCard.Height - 64f) / 2f;

            float pctBookings = Math.Min(1f, Math.Max(0.15f, totalBookings / 5f));
            float pctUpcoming = Math.Min(1f, Math.Max(0.15f, upcomingBookings / 3f));
            float pctExplorer = Math.Min(1f, Math.Max(0.20f, (float)(totalSpent / 4500m)));

            DrawConcentricRing(g, rcx, rcy, ringSize * 0.46f, 8.5f, pctBookings, SafariEmerald);
            DrawConcentricRing(g, rcx, rcy, ringSize * 0.33f, 8.5f, pctUpcoming, HorizonCyan);
            DrawConcentricRing(g, rcx, rcy, ringSize * 0.20f, 8.5f, pctExplorer, SunsetAmber);

            float legX = leftCard.X + ringSize + 34f;
            float legY = leftCard.Y + 62f;
            string tierName = totalBookings >= 4 ? "Gold Ranger" : totalBookings >= 2 ? "Silver Scout" : "Bronze Explorer";
            DrawRingLegendRow(g, legX, legY,       SafariEmerald, "BOOKINGS",  $"{totalBookings} confirmed");
            DrawRingLegendRow(g, legX, legY + 38f, HorizonCyan,   "UPCOMING",  $"{upcomingBookings} scheduled");
            DrawRingLegendRow(g, legX, legY + 76f, SunsetAmber,   "TIER SPEND", $"R{totalSpent:N0} • {tierName}");

            // ── Right Card: Bklit UI Category Seat Availability & Price Bar Chart ──
            RectangleF rightCard = new RectangleF(leftW + gap, 1f, rightW - 2f, h - 2f);
            DrawDarkGlassCardFrame(g, rightCard, "BKLIT LIVE BAR CHART", RoyalViolet,
                "Live Seats Available by Safari Category", "Real-time seat inventory from Data/activities.txt");

            string[] cats = { "Safari", "Adventure", "Event", "Hiking Trail" };
            Color[] catColors = { SunsetAmber, SafariEmerald, RoyalViolet, HorizonCyan };

            float barTop = rightCard.Y + 58f;
            float barBottom = rightCard.Bottom - 22f;
            float availH = Math.Max(60f, barBottom - barTop);
            float rowH = availH / cats.Length;

            int maxSeats = 10;
            int[] catSeats = new int[cats.Length];
            decimal[] catMinPrice = new decimal[cats.Length];

            if (activities != null)
            {
                for (int i = 0; i < cats.Length; i++)
                {
                    int sumSeats = 0;
                    decimal minP = 0m;
                    foreach (var a in activities)
                    {
                        if (string.Equals(a.Category, cats[i], StringComparison.OrdinalIgnoreCase))
                        {
                            sumSeats += Math.Max(0, a.SeatsAvailable);
                            if (minP == 0m || a.Price < minP) minP = a.Price;
                        }
                    }
                    catSeats[i] = sumSeats;
                    catMinPrice[i] = minP;
                    if (sumSeats > maxSeats) maxSeats = sumSeats;
                }
            }

            using (var fCat = new Font("Segoe UI", 8F, FontStyle.Bold))
            using (var fVal = new Font("Segoe UI", 7.5F, FontStyle.Bold))
            using (var txtBrush = new SolidBrush(TextPrimary))
            using (var subBrush = new SolidBrush(TextSecondary))
            {
                for (int i = 0; i < cats.Length; i++)
                {
                    float ry = barTop + i * rowH;
                    g.DrawString(cats[i], fCat, txtBrush, rightCard.X + 14f, ry + 2f);

                    float trackX = rightCard.X + 102f;
                    float trackW = Math.Max(60f, rightCard.Width - 218f);
                    RectangleF trackRect = new RectangleF(trackX, ry + 5f, trackW, 12f);

                    using (var trackPath = CreateRoundRect(trackRect, 6f))
                    using (var trackBrush = new SolidBrush(Color.FromArgb(28, 34, 52)))
                    {
                        g.FillPath(trackBrush, trackPath);
                    }

                    float fillRatio = Math.Min(1f, catSeats[i] / (float)Math.Max(1, maxSeats));
                    float fillW = Math.Max(10f, trackW * fillRatio);
                    RectangleF fillRect = new RectangleF(trackX, ry + 5f, fillW, 12f);

                    using (var fillPath = CreateRoundRect(fillRect, 6f))
                    using (var grad = new LinearGradientBrush(fillRect, catColors[i], Interpolate(catColors[i], Color.White, 0.25f), 0f))
                    {
                        g.FillPath(grad, fillPath);
                    }

                    string rightLbl = $"{catSeats[i]} seats (from R{catMinPrice[i]:N0})";
                    g.DrawString(rightLbl, fVal, subBrush, trackX + trackW + 8f, ry + 2f);
                }
            }
        }

        private static void DrawConcentricRing(Graphics g, float cx, float cy, float radius, float thickness, float pct, Color color)
        {
            RectangleF r = new RectangleF(cx - radius, cy - radius, radius * 2f, radius * 2f);
            using (var bgPen = new Pen(Color.FromArgb(32, color), thickness))
            {
                g.DrawEllipse(bgPen, r);
            }
            using (var fgPen = new Pen(color, thickness))
            {
                fgPen.StartCap = LineCap.Round;
                fgPen.EndCap = LineCap.Round;
                g.DrawArc(fgPen, r, -90f, Math.Max(18f, pct * 360f));
            }
        }

        private static void DrawRingLegendRow(Graphics g, float x, float y, Color color, string title, string value)
        {
            using (var dotBrush = new SolidBrush(color))
            using (var fCap = new Font("Segoe UI", 7F, FontStyle.Bold))
            using (var fVal = new Font("Segoe UI", 8.5F, FontStyle.Bold))
            using (var bCap = new SolidBrush(color))
            using (var bVal = new SolidBrush(TextPrimary))
            {
                g.FillEllipse(dotBrush, x, y + 3f, 8f, 8f);
                g.DrawString(title, fCap, bCap, x + 13f, y);
                g.DrawString(value, fVal, bVal, x + 13f, y + 13f);
            }
        }

        public static void DrawDarkGlassCardFrame(
            Graphics g, RectangleF rect, string badgeText, Color accent, string title, string subtitle)
        {
            using (var path = CreateRoundRect(rect, 12f))
            {
                using (var bg = new LinearGradientBrush(rect, Color.FromArgb(20, 25, 40), Color.FromArgb(12, 15, 25), 135f))
                {
                    g.FillPath(bg, path);
                }
                using (var border = new Pen(Color.FromArgb(40, 255, 255, 255), 1f))
                {
                    g.DrawPath(border, path);
                }
            }
            using (var topPen = new Pen(accent, 2f))
            {
                g.DrawLine(topPen, rect.X + 14f, rect.Y + 1f, rect.Right - 14f, rect.Y + 1f);
            }
            using (var fTitle = new Font("Segoe UI", 9.5F, FontStyle.Bold))
            using (var fSub = new Font("Segoe UI", 7.5F, FontStyle.Regular))
            using (var bTitle = new SolidBrush(TextPrimary))
            using (var bSub = new SolidBrush(TextSecondary))
            {
                g.DrawString(title, fTitle, bTitle, rect.X + 14f, rect.Y + 10f);
                g.DrawString(subtitle, fSub, bSub, rect.X + 14f, rect.Y + 28f);
            }
            if (!string.IsNullOrEmpty(badgeText))
            {
                using (var fBadge = new Font("Segoe UI", 6.75F, FontStyle.Bold))
                {
                    SizeF sz = g.MeasureString(badgeText, fBadge);
                    RectangleF bRect = new RectangleF(rect.Right - sz.Width - 20f, rect.Y + 10f, sz.Width + 10f, 17f);
                    using (var bPath = CreateRoundRect(bRect, 8f))
                    using (var bFill = new SolidBrush(Color.FromArgb(35, accent)))
                    using (var bPen = new Pen(Color.FromArgb(120, accent), 1f))
                    using (var bTxt = new SolidBrush(Color.White))
                    {
                        g.FillPath(bFill, bPath);
                        g.DrawPath(bPen, bPath);
                        var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                        g.DrawString(badgeText, fBadge, bTxt, bRect, sf);
                    }
                }
            }
        }

        // =================================================================
        //  4B. KEXSIO & UIVERSE SIGNATURE NEO-GLASS WELCOME SCREEN TEMPLATE
        // =================================================================

        public static void ApplyKexsioUiverseWelcomeTemplate(
            Form form, Panel containerPanel, Button btnVisitor, Button btnAdmin, Label lblOr, bool isAdminLocked)
        {
            ApplyKexsioUiverseWelcomeTemplate(form, containerPanel, btnVisitor, btnAdmin, lblOr, () => isAdminLocked);
        }

        public static void ApplyKexsioUiverseWelcomeTemplate(
            Form form, Panel containerPanel, Button btnVisitor, Button btnAdmin, Label lblOr, Func<bool> isLockedProvider)
        {
            if (form == null || containerPanel == null) return;
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            EnableDoubleBuffering(form);
            EnableDoubleBuffering(containerPanel);

            form.BackColor = ObsidianBg;
            form.ForeColor = TextPrimary;
            containerPanel.Dock = DockStyle.Fill;
            containerPanel.BackgroundImage = null;

            // Hide old raw text labels to let the modern Kexsio & Uiverse canvas shine
            foreach (Control c in containerPanel.Controls)
            {
                if (c != btnVisitor && c != btnAdmin)
                {
                    c.Visible = false;
                }
            }

            int hoveredGateway = 0; // 0: none, 1: visitor, 2: admin

            // Track card rectangles for interactive hover
            RectangleF lastLeftCard = RectangleF.Empty;
            RectangleF lastRightCard = RectangleF.Empty;

            containerPanel.MouseMove += (s, e) =>
            {
                int next = 0;
                if (!lastLeftCard.IsEmpty && lastLeftCard.Contains(e.Location)) next = 1;
                else if (!lastRightCard.IsEmpty && lastRightCard.Contains(e.Location)) next = 2;

                if (next != hoveredGateway)
                {
                    hoveredGateway = next;
                    containerPanel.Invalidate();
                }
            };

            containerPanel.MouseLeave += (s, e) =>
            {
                if (hoveredGateway != 0)
                {
                    hoveredGateway = 0;
                    containerPanel.Invalidate();
                }
            };

            // Custom dynamic layout handler
            Action updateLayout = () =>
            {
                if (containerPanel.ClientSize.Width <= 0 || containerPanel.ClientSize.Height <= 0) return;
                int w = containerPanel.ClientSize.Width;
                int h = containerPanel.ClientSize.Height;

                float heroW = Math.Min(1020f, Math.Max(660f, w - 48f));
                float heroH = Math.Min(470f, Math.Max(430f, h - 44f));
                float heroX = (w - heroW) / 2f;
                float heroY = Math.Max(12f, (h - heroH) / 2f);

                float cardGap = 26f;
                float gatewayW = (heroW - 76f - cardGap) / 2f;
                float gatewayH = 188f;
                float leftCardX = heroX + 38f;
                float rightCardX = leftCardX + gatewayW + cardGap;
                float gatewayY = heroY + heroH - gatewayH - 48f;

                lastLeftCard = new RectangleF(leftCardX, gatewayY, gatewayW, gatewayH);
                lastRightCard = new RectangleF(rightCardX, gatewayY, gatewayW, gatewayH);

                int btnW = (int)(gatewayW - 36f);
                int btnH = 44;

                if (btnVisitor != null)
                {
                    btnVisitor.Visible = true;
                    btnVisitor.Size = new Size(btnW, btnH);
                    btnVisitor.Location = new Point((int)(leftCardX + 18f), (int)(gatewayY + gatewayH - btnH - 14f));
                    btnVisitor.Text = "Start Safari Journey   →";
                    btnVisitor.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                }

                if (btnAdmin != null)
                {
                    bool locked = isLockedProvider != null && isLockedProvider();
                    btnAdmin.Visible = true;
                    btnAdmin.Size = new Size(btnW, btnH);
                    btnAdmin.Location = new Point((int)(rightCardX + 18f), (int)(gatewayY + gatewayH - btnH - 14f));
                    btnAdmin.Text = locked ? "Ranger Portal Locked   ■" : "Ranger Access Portal   ✦";
                    btnAdmin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                }
            };

            // Hook responsive layout events
            form.Load += (s, e) => { updateLayout(); containerPanel.Invalidate(); };
            form.Shown += (s, e) => { updateLayout(); containerPanel.Invalidate(); };
            form.Resize += (s, e) => { updateLayout(); containerPanel.Invalidate(); };
            containerPanel.Resize += (s, e) => { updateLayout(); containerPanel.Invalidate(); };

            // Attach Uiverse signature glowing buttons
            if (btnVisitor != null)
            {
                AttachUiverseButtonGlow(btnVisitor, SafariEmerald, HorizonCyan);
            }

            if (btnAdmin != null)
            {
                // Dynamic styler depending on locked state
                btnAdmin.Paint += (s, e) =>
                {
                    // Update text if state changed
                    bool locked = isLockedProvider != null && isLockedProvider();
                    string expected = locked ? "Ranger Portal Locked   ■" : "Ranger Access Portal   ✦";
                    if (btnAdmin.Text != expected) btnAdmin.Text = expected;
                };
                AttachUiverseButtonGlow(btnAdmin, RoyalViolet, SunsetAmber);
            }

            // Main Kexsio & Uiverse Canvas Painter
            containerPanel.Paint += (s, e) =>
            {
                bool locked = isLockedProvider != null && isLockedProvider();
                PaintWelcomeHeroSurface(e.Graphics, containerPanel.ClientSize.Width, containerPanel.ClientSize.Height, locked, hoveredGateway, containerPanel.BackgroundImage);
            };

            updateLayout();
        }

        public static void PaintWelcomeHeroSurface(
            Graphics g, int w, int h, bool locked, int hoveredGateway = 0, Image bgImage = null)
        {
            if (g == null || w <= 0 || h <= 0) return;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            {

                // 1. Draw base photo if available, or obsidian background
                if (bgImage != null)
                {
                    g.DrawImage(bgImage, new Rectangle(0, 0, w, h));
                    // Dark cinematic obsidian vignette overlay
                    using (var vig = new LinearGradientBrush(
                        new Rectangle(0, 0, w, h),
                        Color.FromArgb(205, 6, 8, 14),
                        Color.FromArgb(240, 6, 8, 14),
                        90f))
                    {
                        g.FillRectangle(vig, 0, 0, w, h);
                    }
                }
                else
                {
                    using (var bgBrush = new SolidBrush(ObsidianBg))
                    {
                        g.FillRectangle(bgBrush, 0, 0, w, h);
                    }
                }

                // 2. Kexsio 44px geometric grid
                using (var gridPen = new Pen(Color.FromArgb(12, 255, 255, 255), 1f))
                {
                    for (int x = 0; x < w; x += 44) g.DrawLine(gridPen, x, 0, x, h);
                    for (int y = 0; y < h; y += 44) g.DrawLine(gridPen, 0, y, w, y);
                }

                // 3. Ambient Kexsio glowing radial orbs
                using (var orb1 = new SolidBrush(Color.FromArgb(28, SafariEmerald)))
                using (var orb2 = new SolidBrush(Color.FromArgb(22, HorizonCyan)))
                using (var orb3 = new SolidBrush(Color.FromArgb(24, SunsetAmber)))
                {
                    g.FillEllipse(orb1, -80, -60, 420, 420);
                    g.FillEllipse(orb2, w - 380, -40, 440, 440);
                    g.FillEllipse(orb3, (w - 480) / 2, h - 260, 480, 320);
                }

                // 4. Subtle flowing topographic safari curves
                for (int wave = 0; wave < 3; wave++)
                {
                    PointF[] pts = new PointF[6];
                    float baseY = h * (0.22f + wave * 0.26f);
                    for (int i = 0; i < 6; i++)
                    {
                        float px = (w / 5f) * i;
                        float py = baseY + (float)Math.Sin(i * 1.2 + wave * 0.9) * 26f;
                        pts[i] = new PointF(px, py);
                    }
                    using (var wavePen = new Pen(Color.FromArgb(10 - wave * 2, SafariEmerald), 1.2f))
                    {
                        g.DrawCurve(wavePen, pts, 0.5f);
                    }
                }

                // 5. Compute Hero Card dimensions
                float heroW = Math.Min(1020f, Math.Max(660f, w - 48f));
                float heroH = Math.Min(470f, Math.Max(430f, h - 44f));
                float heroX = (w - heroW) / 2f;
                float heroY = Math.Max(12f, (h - heroH) / 2f);
                RectangleF heroRect = new RectangleF(heroX, heroY, heroW, heroH);

                // Deep ambient shadow behind hero card
                RectangleF shadowRect = heroRect;
                shadowRect.Offset(0, 14f);
                using (var sPath = CreateRoundRect(shadowRect, 24f))
                using (var sBrush = new SolidBrush(Color.FromArgb(85, 0, 0, 0)))
                {
                    g.FillPath(sBrush, sPath);
                }

                // Uiverse Frosted Neo-Glass Hero Card body
                using (var heroPath = CreateRoundRect(heroRect, 22f))
                {
                    using (var glassBrush = new LinearGradientBrush(
                        heroRect,
                        Color.FromArgb(235, 12, 16, 28),
                        Color.FromArgb(246, 7, 9, 16),
                        135f))
                    {
                        g.FillPath(glassBrush, heroPath);
                    }

                    // Frosted edge highlight
                    using (var borderPen = new Pen(Color.FromArgb(50, 255, 255, 255), 1.2f))
                    {
                        g.DrawPath(borderPen, heroPath);
                    }
                }

                // Top neon shimmer highlight line
                using (var topPen = new LinearGradientBrush(
                    new RectangleF(heroRect.X + 20f, heroRect.Y, heroRect.Width - 40f, 3f),
                    SafariEmerald,
                    HorizonCyan,
                    0f))
                using (var pen = new Pen(topPen, 2.5f))
                {
                    g.DrawLine(pen, heroRect.X + 24f, heroRect.Y + 1.2f, heroRect.Right - 24f, heroRect.Y + 1.2f);
                }

                float curY = heroRect.Y + 26f;

                // 6. Kexsio Pill Eyebrow Badge
                string eyebrow = "✦  BLUE HORIZONS • LUXURY EXPEDITION PORTAL 2026";
                using (var fEye = new Font("Segoe UI", 7.75F, FontStyle.Bold))
                {
                    SizeF sz = g.MeasureString(eyebrow, fEye);
                    float pillW = sz.Width + 24f;
                    float pillH = 25f;
                    RectangleF pillRect = new RectangleF(heroRect.X + (heroW - pillW) / 2f, curY, pillW, pillH);

                    using (var pillPath = CreateRoundRect(pillRect, 12.5f))
                    using (var pillBg = new SolidBrush(Color.FromArgb(38, SafariEmerald)))
                    using (var pillBorder = new Pen(Color.FromArgb(130, SafariEmerald), 1f))
                    using (var pillTxt = new SolidBrush(Color.FromArgb(235, 255, 245)))
                    {
                        g.FillPath(pillBg, pillPath);
                        g.DrawPath(pillBorder, pillPath);

                        // Pulsing status dot
                        float dotX = pillRect.X + 9f;
                        float dotY = pillRect.Y + 9f;
                        using (var dotGlow = new SolidBrush(Color.FromArgb(90, SafariEmerald)))
                        using (var dotCore = new SolidBrush(SafariEmerald))
                        {
                            g.FillEllipse(dotGlow, dotX - 2f, dotY - 2f, 11f, 11f);
                            g.FillEllipse(dotCore, dotX, dotY, 7f, 7f);
                        }

                        var sf = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center };
                        RectangleF textBounds = new RectangleF(pillRect.X, pillRect.Y, pillRect.Width - 10f, pillRect.Height);
                        g.DrawString(eyebrow, fEye, pillTxt, textBounds, sf);
                    }
                }

                curY += 34f;

                // 7. Hero Brand Title
                string brandTitle = "BLUE HORIZON EXPEDITIONS";
                using (var fTitle = new Font("Trebuchet MS", Math.Max(20F, Math.Min(26F, heroW / 36F)), FontStyle.Bold))
                using (var bTitle = new SolidBrush(TextPrimary))
                {
                    var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    g.DrawString(brandTitle, fTitle, bTitle, new RectangleF(heroRect.X, curY, heroW, 36f), sf);
                }

                curY += 38f;

                // 8. Hero Subtitle
                string subTitle = "EXPLORE THE UNTAMED AFRICAN WILDERNESS";
                using (var fSub = new Font("Segoe UI", 10F, FontStyle.Bold))
                using (var bSub = new SolidBrush(HorizonCyan))
                {
                    var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    g.DrawString(subTitle, fSub, bSub, new RectangleF(heroRect.X, curY, heroW, 22f), sf);
                }

                curY += 26f;

                // 9. Narrative Paragraph
                string narrative = "Witness the breathtaking Big Five in their natural habitat, reserve exclusive game drives, and savor golden sundowners under an African sky. Your bucket-list adventure is just a click away.";
                using (var fDesc = new Font("Segoe UI", 9.25F, FontStyle.Regular))
                using (var bDesc = new SolidBrush(TextSecondary))
                {
                    var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    RectangleF descRect = new RectangleF(heroRect.X + 40f, curY, heroW - 80f, 38f);
                    g.DrawString(narrative, fDesc, bDesc, descRect, sf);
                }

                curY += 42f;

                // 10. Kexsio Bento Feature Chips Row
                string[] chips = { "✦ Big Five Reserves", "☼ Luxury Sundowners", "⚡ Live Sightings", "★ 4.9 Explorer Rated" };
                using (var fChip = new Font("Segoe UI", 8F, FontStyle.Bold))
                using (var bChip = new SolidBrush(Color.FromArgb(220, 230, 250)))
                {
                    float totalChipsW = 0f;
                    float[] chipWidths = new float[chips.Length];
                    for (int i = 0; i < chips.Length; i++)
                    {
                        chipWidths[i] = g.MeasureString(chips[i], fChip).Width + 20f;
                        totalChipsW += chipWidths[i];
                    }
                    float gapBetweenChips = 12f;
                    totalChipsW += gapBetweenChips * (chips.Length - 1);
                    float startChipX = heroRect.X + (heroW - totalChipsW) / 2f;

                    for (int i = 0; i < chips.Length; i++)
                    {
                        RectangleF cRect = new RectangleF(startChipX, curY, chipWidths[i], 26f);
                        using (var cPath = CreateRoundRect(cRect, 13f))
                        using (var cFill = new SolidBrush(Color.FromArgb(24, 255, 255, 255)))
                        using (var cBorder = new Pen(Color.FromArgb(48, 255, 255, 255), 1f))
                        {
                            g.FillPath(cFill, cPath);
                            g.DrawPath(cBorder, cPath);
                            var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                            g.DrawString(chips[i], fChip, bChip, cRect, sf);
                        }
                        startChipX += chipWidths[i] + gapBetweenChips;
                    }
                }

                // 11. Dual Gateway Bento Action Cards (Uiverse Card Template)
                float cardGap = 26f;
                float gatewayW = (heroW - 76f - cardGap) / 2f;
                float gatewayH = 188f;
                float leftCardX = heroRect.X + 38f;
                float rightCardX = leftCardX + gatewayW + cardGap;
                float gatewayY = heroRect.Y + heroH - gatewayH - 48f;

                RectangleF vCard = new RectangleF(leftCardX, gatewayY, gatewayW, gatewayH);
                RectangleF aCard = new RectangleF(rightCardX, gatewayY, gatewayW, gatewayH);

                // --- Left Gateway: Traveler Expedition ---
                bool vHover = hoveredGateway == 1;
                using (var vPath = CreateRoundRect(vCard, 16f))
                {
                    using (var vFill = new LinearGradientBrush(
                        vCard,
                        vHover ? Color.FromArgb(220, 22, 30, 48) : Color.FromArgb(195, 16, 22, 36),
                        Color.FromArgb(225, 10, 14, 24),
                        135f))
                    {
                        g.FillPath(vFill, vPath);
                    }
                    using (var vBorder = new Pen(vHover ? SafariEmerald : Color.FromArgb(60, SafariEmerald), vHover ? 1.6f : 1.2f))
                    {
                        g.DrawPath(vBorder, vPath);
                    }
                }
                // Emerald top highlight
                using (var vTop = new Pen(SafariEmerald, 2f))
                {
                    g.DrawLine(vTop, vCard.X + 16f, vCard.Y + 1f, vCard.Right - 16f, vCard.Y + 1f);
                }

                // Visitor Card Header & Subtitle
                using (var fCardTag = new Font("Segoe UI", 7.25F, FontStyle.Bold))
                using (var fCardHead = new Font("Segoe UI", 11.5F, FontStyle.Bold))
                using (var fCardSub = new Font("Segoe UI", 8F, FontStyle.Regular))
                using (var fBullet = new Font("Segoe UI", 7.75F, FontStyle.Regular))
                using (var bTag = new SolidBrush(SafariEmerald))
                using (var bHead = new SolidBrush(TextPrimary))
                using (var bSub = new SolidBrush(TextSecondary))
                using (var bBullet = new SolidBrush(Color.FromArgb(200, 215, 240)))
                {
                    g.DrawString("✦  TRAVELER EXPEDITION", fCardTag, bTag, vCard.X + 16f, vCard.Y + 12f);
                    g.DrawString("Start Your Safari Journey", fCardHead, bHead, vCard.X + 16f, vCard.Y + 27f);
                    RectangleF subRect = new RectangleF(vCard.X + 16f, vCard.Y + 49f, vCard.Width - 32f, 32f);
                    g.DrawString("Browse curated game drives, reserve luxury lodges, and register your tourist pass.", fCardSub, bSub, subRect);

                    // Feature checklist bullets
                    g.DrawString("✓ Instant Game Drive Bookings", fBullet, bBullet, vCard.X + 18f, vCard.Y + 84f);
                    g.DrawString("✓ Live Wildlife Sightings & Map", fBullet, bBullet, vCard.X + (vCard.Width / 2f), vCard.Y + 84f);
                }

                // --- Right Gateway: Ranger Operations / Management ---
                bool aHover = hoveredGateway == 2;
                Color aAccent = locked ? CrimsonCoral : RoyalViolet;
                using (var aPath = CreateRoundRect(aCard, 16f))
                {
                    using (var aFill = new LinearGradientBrush(
                        aCard,
                        aHover ? Color.FromArgb(220, 28, 24, 46) : Color.FromArgb(195, 18, 16, 32),
                        Color.FromArgb(225, 10, 10, 20),
                        135f))
                    {
                        g.FillPath(aFill, aPath);
                    }
                    using (var aBorder = new Pen(aHover ? aAccent : Color.FromArgb(60, aAccent), aHover ? 1.6f : 1.2f))
                    {
                        g.DrawPath(aBorder, aPath);
                    }
                }
                // Accent top highlight
                using (var aTop = new Pen(aAccent, 2f))
                {
                    g.DrawLine(aTop, aCard.X + 16f, aCard.Y + 1f, aCard.Right - 16f, aCard.Y + 1f);
                }

                // Admin Card Header & Subtitle
                using (var fCardTag = new Font("Segoe UI", 7.25F, FontStyle.Bold))
                using (var fCardHead = new Font("Segoe UI", 11.5F, FontStyle.Bold))
                using (var fCardSub = new Font("Segoe UI", 8F, FontStyle.Regular))
                using (var fBullet = new Font("Segoe UI", 7.75F, FontStyle.Regular))
                using (var bTag = new SolidBrush(aAccent))
                using (var bHead = new SolidBrush(TextPrimary))
                using (var bSub = new SolidBrush(TextSecondary))
                using (var bBullet = new SolidBrush(Color.FromArgb(200, 215, 240)))
                {
                    string tagText = locked ? "■  ADMIN ACCESS RESTRICTED" : "◆  RANGER OPERATIONS";
                    string headText = locked ? "Security Passkey Active" : "Ranger & Park Management";
                    string descText = locked
                        ? "Passkey attempts exceeded. Ranger & Park Management access is currently locked by security policy."
                        : "Authorized portal for park rangers, activity pricing, attendance manifests & AI settings.";

                    g.DrawString(tagText, fCardTag, bTag, aCard.X + 16f, aCard.Y + 12f);
                    g.DrawString(headText, fCardHead, bHead, aCard.X + 16f, aCard.Y + 27f);
                    RectangleF subRect = new RectangleF(aCard.X + 16f, aCard.Y + 49f, aCard.Width - 32f, 32f);
                    g.DrawString(descText, fCardSub, bSub, subRect);

                    // Feature checklist bullets
                    string b1 = locked ? "• 6-Digit Protection Active" : "✓ Fleet Dispatch & Pricing";
                    string b2 = locked ? "• System Admin Override" : "✓ Attendance & AI Console";
                    g.DrawString(b1, fBullet, bBullet, aCard.X + 18f, aCard.Y + 84f);
                    g.DrawString(b2, fBullet, bBullet, aCard.X + (aCard.Width / 2f), aCard.Y + 84f);
                }

                // Center "OR" Badge between the two gateway cards
                float orCenterX = leftCardX + gatewayW + cardGap / 2f;
                float orCenterY = gatewayY + gatewayH / 2f;
                float orR = 14f;
                RectangleF orRect = new RectangleF(orCenterX - orR, orCenterY - orR, orR * 2f, orR * 2f);

                // Hairline rules above and below OR badge
                using (var linePen = new Pen(Color.FromArgb(40, 255, 255, 255), 1f))
                {
                    g.DrawLine(linePen, orCenterX, gatewayY + 10f, orCenterX, orRect.Top - 6f);
                    g.DrawLine(linePen, orCenterX, orRect.Bottom + 6f, orCenterX, gatewayY + gatewayH - 10f);
                }

                using (var orBg = new SolidBrush(Color.FromArgb(220, 18, 22, 36)))
                using (var orPen = new Pen(Color.FromArgb(70, 255, 255, 255), 1f))
                using (var fOr = new Font("Segoe UI", 7F, FontStyle.Bold))
                using (var bOr = new SolidBrush(Color.FromArgb(180, 195, 220)))
                {
                    g.FillEllipse(orBg, orRect);
                    g.DrawEllipse(orPen, orRect);
                    var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    g.DrawString("OR", fOr, bOr, orRect, sf);
                }

                // 12. Bottom Security & Status Footer
                string footer = "●  256-BIT ENCRYPTED PASSKEY GATEWAY  •  OFFICIAL SOUTH AFRICA SAFARI SYSTEM  •  PORTAL V4.2";
                using (var fFoot = new Font("Segoe UI", 7.5F, FontStyle.Bold))
                using (var bFoot = new SolidBrush(Color.FromArgb(135, 145, 175)))
                {
                    var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    g.DrawString(footer, fFoot, bFoot, new RectangleF(heroRect.X, heroRect.Bottom - 26f, heroW, 20f), sf);
                }
            }
        }

        // =================================================================
        //  5. KOKONUT UI CHECKOUT STEPPER & RECEIPT PRINTER BANNER
        //     (Rendered on pnlBook, pnlPayment, and pnlInvoice)
        // =================================================================

        public static void DrawBookingProgressStepper(Graphics g, int w, int activeStep)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            string[] steps = { "1. Select & Configure Safari", "2. Kokonut ZAR Checkout", "3. Verified Tax Invoice" };
            Color[] colors = { HorizonCyan, SunsetAmber, SafariEmerald };

            float totalW = Math.Min(680f, w - 60f);
            float startX = 30f;
            float y = 50f;
            float pillW = (totalW - 36f) / 3f;

            using (var fStep = new Font("Segoe UI", 8F, FontStyle.Bold))
            {
                var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                for (int i = 0; i < 3; i++)
                {
                    bool doneOrActive = (i + 1) <= activeStep;
                    bool isCurrent = (i + 1) == activeStep;
                    Color c = colors[i];

                    RectangleF r = new RectangleF(startX + i * (pillW + 18f), y, pillW, 24f);
                    using (var path = CreateRoundRect(r, 12f))
                    using (var fill = new SolidBrush(isCurrent ? Color.FromArgb(55, c) : doneOrActive ? Color.FromArgb(28, c) : Color.FromArgb(18, 22, 34)))
                    using (var pen = new Pen(doneOrActive ? Color.FromArgb(180, c) : Color.FromArgb(45, 255, 255, 255), isCurrent ? 1.6f : 1f))
                    using (var txtBrush = new SolidBrush(doneOrActive ? Color.White : TextSecondary))
                    {
                        g.FillPath(fill, path);
                        g.DrawPath(pen, path);
                        g.DrawString(steps[i], fStep, txtBrush, r, sf);
                    }
                }
            }
        }

        // =================================================================
        //  6. BESPOKE TOUR ARTWORK GENERATOR FOR ACCORDION GALLERY
        //     Creates high-resolution portrait (3:4, 900x1200 ratio) tour
        //     illustrations tailored to each Blue Horizons Tours activity.
        //     Supports Custom Uploads, Presets & Disk Persisted Config.
        // =================================================================

        public static readonly string[] BuiltInPresetNames = new[]
        {
            "Auto (Match Tour Name)",
            "Preset 1: Savanna Sunrise Safari",
            "Preset 2: Night Safari & Bush Braai",
            "Preset 3: Cape Winelands Valley",
            "Preset 4: Table Mountain Abseil",
            "Preset 5: Shark Cage Diving",
            "Preset 6: Atlantis Sand Dunes",
            "Preset 7: Cape Town Jazz Stage",
            "Preset 8: Atlantic Sunset Cruise",
            "Preset 9: Lion's Head Sunrise",
            "Preset 10: Cape Point & Boulders"
        };

        private static readonly Dictionary<string, Bitmap> _tourImageCache =
            new Dictionary<string, Bitmap>(StringComparer.OrdinalIgnoreCase);

        private static string ActivityImagesConfigPath =>
            Path.Combine(FileService.DataFolder, "activity_images.txt");

        private static string ActivityImagesFolderPath =>
            Path.Combine(FileService.DataFolder, "ActivityImages");

        public static void InvalidateTourImageCache()
        {
            _tourImageCache.Clear();
        }

        public static Dictionary<string, string> LoadActivityImageSettings()
        {
            var map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            try
            {
                if (!File.Exists(ActivityImagesConfigPath)) return map;
                foreach (string line in File.ReadAllLines(ActivityImagesConfigPath))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    int sep = line.IndexOf('|');
                    if (sep <= 0) continue;
                    string id = line.Substring(0, sep).Trim();
                    string val = line.Substring(sep + 1).Trim();
                    if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(val))
                        map[id] = val;
                }
            }
            catch { }
            return map;
        }

        public static string GetActivityImageSetting(string activityId)
        {
            if (string.IsNullOrWhiteSpace(activityId)) return null;
            var map = LoadActivityImageSettings();
            return map.TryGetValue(activityId, out string val) ? val : null;
        }

        public static void SetActivityImageSetting(string activityId, string setting)
        {
            if (string.IsNullOrWhiteSpace(activityId)) return;
            try
            {
                FileService.EnsureDataFolder();
                var map = LoadActivityImageSettings();
                if (string.IsNullOrWhiteSpace(setting) ||
                    string.Equals(setting, "Auto (Match Tour Name)", StringComparison.OrdinalIgnoreCase))
                {
                    map.Remove(activityId);
                }
                else
                {
                    map[activityId] = setting.Trim();
                }

                var lines = new List<string>();
                foreach (var kv in map)
                    lines.Add($"{kv.Key}|{kv.Value}");
                File.WriteAllLines(ActivityImagesConfigPath, lines);
                InvalidateTourImageCache();
            }
            catch { }
        }

        public static string SaveUploadedActivityImage(string activityId, string sourceFilePath)
        {
            if (string.IsNullOrWhiteSpace(sourceFilePath) || !File.Exists(sourceFilePath))
                throw new FileNotFoundException("Selected image file was not found.");

            FileService.EnsureDataFolder();
            if (!Directory.Exists(ActivityImagesFolderPath))
                Directory.CreateDirectory(ActivityImagesFolderPath);

            string safeId = string.IsNullOrWhiteSpace(activityId) ? "temp" : activityId;
            string ext = Path.GetExtension(sourceFilePath);
            if (string.IsNullOrEmpty(ext)) ext = ".png";

            string destFileName = $"{safeId}_{DateTime.Now:yyyyMMddHHmmss}{ext}";
            string destFullPath = Path.Combine(ActivityImagesFolderPath, destFileName);
            File.Copy(sourceFilePath, destFullPath, true);

            if (!string.IsNullOrWhiteSpace(activityId))
                SetActivityImageSetting(activityId, destFullPath);

            InvalidateTourImageCache();
            return destFullPath;
        }

        public static Bitmap GetOrCreateTourImage(Activity act, string overrideSetting = null)
        {
            if (act == null) return null;
            string setting = !string.IsNullOrWhiteSpace(overrideSetting)
                ? overrideSetting
                : GetActivityImageSetting(act.ActivityID);

            string key = $"{act.ActivityID}|{act.Name}|{act.Category}|{setting ?? "auto"}";
            if (_tourImageCache.TryGetValue(key, out Bitmap cached) && cached != null)
                return cached;

            int w = 480;
            int h = 640; // 3:4 portrait aspect ratio matching 900x1200 in AccordionGallery

            // 1. Check if setting is a custom uploaded file path on disk
            if (!string.IsNullOrWhiteSpace(setting) && !setting.StartsWith("Preset ", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(setting, "Auto (Match Tour Name)", StringComparison.OrdinalIgnoreCase))
            {
                string resolvedPath = setting;
                if (!Path.IsPathRooted(resolvedPath))
                    resolvedPath = Path.Combine(FileService.DataFolder, resolvedPath);

                if (File.Exists(resolvedPath))
                {
                    try
                    {
                        byte[] bytes = File.ReadAllBytes(resolvedPath);
                        using (var ms = new MemoryStream(bytes))
                        using (var srcImg = Image.FromStream(ms))
                        {
                            var customBmp = new Bitmap(w, h);
                            using (Graphics g = Graphics.FromImage(customBmp))
                            {
                                g.SmoothingMode = SmoothingMode.AntiAlias;
                                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                float scale = Math.Max(w / (float)srcImg.Width, h / (float)srcImg.Height);
                                float dw = srcImg.Width * scale;
                                float dh = srcImg.Height * scale;
                                float dx = (w - dw) / 2f;
                                float dy = (h - dh) / 2f;
                                g.DrawImage(srcImg, new RectangleF(dx, dy, dw, dh));
                            }
                            _tourImageCache[key] = customBmp;
                            return customBmp;
                        }
                    }
                    catch { /* Fall through to scenic renderer if custom file is unreadable */ }
                }
            }

            var bmp = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

                string target = !string.IsNullOrWhiteSpace(setting) && setting.StartsWith("Preset ", StringComparison.OrdinalIgnoreCase)
                    ? setting.ToLowerInvariant()
                    : $"{act.Name} {act.Category}".ToLowerInvariant();

                if (target.Contains("preset 1:") || target.Contains("sunrise") && target.Contains("safari") || target.Contains("big five"))
                    PaintSunriseSafariScene(g, w, h);
                else if (target.Contains("preset 2:") || target.Contains("night") || target.Contains("braai"))
                    PaintNightSafariBraaiScene(g, w, h);
                else if (target.Contains("preset 3:") || target.Contains("winelands") || target.Contains("wine"))
                    PaintWinelandsWildlifeScene(g, w, h);
                else if (target.Contains("preset 4:") || target.Contains("abseil") || target.Contains("table mountain"))
                    PaintTableMountainAbseilScene(g, w, h);
                else if (target.Contains("preset 5:") || target.Contains("shark") || target.Contains("gansbaai") || target.Contains("cage"))
                    PaintSharkCageDivingScene(g, w, h);
                else if (target.Contains("preset 6:") || target.Contains("dune") || target.Contains("atlantis"))
                    PaintAtlantisDunesScene(g, w, h);
                else if (target.Contains("preset 7:") || target.Contains("jazz") || target.Contains("festival"))
                    PaintJazzFestivalScene(g, w, h);
                else if (target.Contains("preset 8:") || target.Contains("cruise") || target.Contains("atlantic") || target.Contains("sunset"))
                    PaintSunsetCruiseScene(g, w, h);
                else if (target.Contains("preset 9:") || target.Contains("lion") || target.Contains("hike"))
                    PaintLionsHeadHikeScene(g, w, h);
                else if (target.Contains("preset 10:") || target.Contains("cape point") || target.Contains("boulders") || target.Contains("penguin"))
                    PaintCapePointBouldersScene(g, w, h);
                else if ((act.Category ?? "").IndexOf("safari", StringComparison.OrdinalIgnoreCase) >= 0)
                    PaintSunriseSafariScene(g, w, h);
                else if ((act.Category ?? "").IndexOf("adventure", StringComparison.OrdinalIgnoreCase) >= 0)
                    PaintTableMountainAbseilScene(g, w, h);
                else if ((act.Category ?? "").IndexOf("event", StringComparison.OrdinalIgnoreCase) >= 0)
                    PaintSunsetCruiseScene(g, w, h);
                else
                    PaintLionsHeadHikeScene(g, w, h);
            }

            _tourImageCache[key] = bmp;
            return bmp;
        }

        private static void PaintThreeStopSky(Graphics g, int w, int h, Color cTop, Color cMid, Color cBot)
        {
            Rectangle r = new Rectangle(0, 0, w, h);
            using (var grad = new LinearGradientBrush(r, cTop, cBot, 90f))
            {
                var blend = new ColorBlend
                {
                    Positions = new[] { 0f, 0.54f, 1f },
                    Colors = new[] { cTop, cMid, cBot }
                };
                grad.InterpolationColors = blend;
                g.FillRectangle(grad, r);
            }
        }

        private static void PaintSunriseSafariScene(Graphics g, int w, int h)
        {
            PaintThreeStopSky(g, w, h, Color.FromArgb(42, 16, 56), Color.FromArgb(238, 108, 38), Color.FromArgb(255, 202, 88));

            // Glowing dawn sun disc
            using (var halo = new SolidBrush(Color.FromArgb(55, 255, 235, 150)))
                g.FillEllipse(halo, w * 0.22f, h * 0.20f, w * 0.56f, w * 0.56f);
            using (var sun = new SolidBrush(Color.FromArgb(235, 255, 242, 175)))
                g.FillEllipse(sun, w * 0.32f, h * 0.27f, w * 0.36f, w * 0.36f);

            // Distant kopje hills
            PointF[] hills = {
                new PointF(0, h * 0.58f), new PointF(w * 0.25f, h * 0.50f),
                new PointF(w * 0.55f, h * 0.54f), new PointF(w * 0.82f, h * 0.47f),
                new PointF(w, h * 0.53f), new PointF(w, h), new PointF(0, h)
            };
            using (var hillBrush = new SolidBrush(Color.FromArgb(68, 28, 24)))
                g.FillPolygon(hillBrush, hills);

            // Foreground savanna ground
            g.FillRectangle(new SolidBrush(Color.FromArgb(20, 12, 14)), 0, h * 0.64f, w, h * 0.36f);

            // Acacia tree silhouette
            using (var trunkPen = new Pen(Color.FromArgb(20, 12, 14), 7f))
            {
                g.DrawLine(trunkPen, w * 0.24f, h * 0.65f, w * 0.26f, h * 0.41f);
                g.DrawLine(trunkPen, w * 0.26f, h * 0.46f, w * 0.14f, h * 0.38f);
                g.DrawLine(trunkPen, w * 0.26f, h * 0.43f, w * 0.39f, h * 0.36f);
            }
            using (var canopyBrush = new SolidBrush(Color.FromArgb(20, 12, 14)))
            {
                g.FillEllipse(canopyBrush, w * 0.05f, h * 0.34f, w * 0.24f, 22f);
                g.FillEllipse(canopyBrush, w * 0.18f, h * 0.31f, w * 0.32f, 26f);
                g.FillEllipse(canopyBrush, w * 0.30f, h * 0.35f, w * 0.22f, 20f);

                // Elephant silhouette on horizon
                float ex = w * 0.62f, ey = h * 0.58f;
                g.FillEllipse(canopyBrush, ex, ey, 64f, 42f);
                g.FillEllipse(canopyBrush, ex + 46f, ey - 8f, 32f, 30f);
                g.FillRectangle(canopyBrush, ex + 6f, ey + 28f, 10f, 26f);
                g.FillRectangle(canopyBrush, ex + 22f, ey + 28f, 10f, 26f);
                g.FillRectangle(canopyBrush, ex + 42f, ey + 28f, 10f, 26f);
                g.FillRectangle(canopyBrush, ex + 56f, ey + 26f, 8f, 28f);
                using (var tuskPen = new Pen(Color.FromArgb(255, 235, 190), 2.5f))
                    g.DrawArc(tuskPen, ex + 68f, ey + 6f, 18f, 14f, 20f, 110f);
            }
        }

        private static void PaintNightSafariBraaiScene(Graphics g, int w, int h)
        {
            PaintThreeStopSky(g, w, h, Color.FromArgb(5, 8, 22), Color.FromArgb(18, 24, 58), Color.FromArgb(38, 18, 32));

            // Stars & Milky Way
            var rng = new Random(102);
            using (var starBrush = new SolidBrush(Color.FromArgb(215, 255, 255, 255)))
            {
                for (int i = 0; i < 85; i++)
                {
                    float sx = (float)(rng.NextDouble() * w);
                    float sy = (float)(rng.NextDouble() * h * 0.55);
                    float sr = (i % 6 == 0) ? 3f : 1.6f;
                    g.FillEllipse(starBrush, sx, sy, sr, sr);
                }
            }

            // Crescent moon
            using (var moonBrush = new SolidBrush(Color.FromArgb(245, 255, 248, 210)))
                g.FillEllipse(moonBrush, w * 0.72f, h * 0.11f, 54f, 54f);
            using (var cutBrush = new SolidBrush(Color.FromArgb(10, 14, 34)))
                g.FillEllipse(cutBrush, w * 0.75f, h * 0.09f, 50f, 50f);

            // Spotlight beams across the bush
            PointF[] beam = {
                new PointF(w * 0.12f, h * 0.62f),
                new PointF(w * 0.85f, h * 0.30f),
                new PointF(w * 0.95f, h * 0.46f)
            };
            using (var beamBrush = new SolidBrush(Color.FromArgb(28, 255, 240, 180)))
                g.FillPolygon(beamBrush, beam);

            // Bush horizon
            g.FillRectangle(new SolidBrush(Color.FromArgb(10, 10, 16)), 0, h * 0.62f, w, h * 0.38f);

            // Glowing Bush Braai Campfire in center-foreground
            float fx = w * 0.50f, fy = h * 0.63f;
            using (var glow = new SolidBrush(Color.FromArgb(65, 255, 115, 25)))
                g.FillEllipse(glow, fx - 75f, fy - 55f, 150f, 110f);
            PointF[] outerFlame = {
                new PointF(fx - 28f, fy + 16f), new PointF(fx - 12f, fy - 36f),
                new PointF(fx, fy - 14f), new PointF(fx + 14f, fy - 44f),
                new PointF(fx + 28f, fy + 16f)
            };
            using (var fBrush = new SolidBrush(Color.FromArgb(240, 255, 110, 20)))
                g.FillPolygon(fBrush, outerFlame);
            PointF[] innerFlame = {
                new PointF(fx - 14f, fy + 16f), new PointF(fx, fy - 24f), new PointF(fx + 14f, fy + 16f)
            };
            using (var yBrush = new SolidBrush(Color.FromArgb(250, 255, 220, 90)))
                g.FillPolygon(yBrush, innerFlame);
        }

        private static void PaintWinelandsWildlifeScene(Graphics g, int w, int h)
        {
            PaintThreeStopSky(g, w, h, Color.FromArgb(28, 38, 76), Color.FromArgb(148, 92, 145), Color.FromArgb(245, 178, 112));

            // Dramatic Cape Fold Mountains (Simonsberg)
            PointF[] mtns = {
                new PointF(0, h * 0.52f), new PointF(w * 0.22f, h * 0.31f),
                new PointF(w * 0.44f, h * 0.43f), new PointF(w * 0.72f, h * 0.27f),
                new PointF(w, h * 0.45f), new PointF(w, h), new PointF(0, h)
            };
            using (var mtnBrush = new SolidBrush(Color.FromArgb(52, 44, 82)))
                g.FillPolygon(mtnBrush, mtns);

            // Lush green vineyard valley
            g.FillRectangle(new SolidBrush(Color.FromArgb(22, 58, 42)), 0, h * 0.52f, w, h * 0.48f);

            // Converging perspective vineyard rows
            float vx = w * 0.50f, vy = h * 0.50f;
            using (var rowPen = new Pen(Color.FromArgb(140, 52, 168, 98), 4f))
            {
                for (int r = -6; r <= 6; r++)
                {
                    g.DrawLine(rowPen, vx + r * 12f, vy + 8f, vx + r * 85f, h);
                }
            }
        }

        private static void PaintTableMountainAbseilScene(Graphics g, int w, int h)
        {
            PaintThreeStopSky(g, w, h, Color.FromArgb(10, 48, 92), Color.FromArgb(45, 158, 212), Color.FromArgb(16, 88, 128));

            // Atlantic ocean & Camps Bay below
            g.FillRectangle(new SolidBrush(Color.FromArgb(12, 72, 110)), 0, h * 0.56f, w, h * 0.44f);

            // Sheer vertical sandstone cliff of Table Mountain on the right
            PointF[] cliff = {
                new PointF(w * 0.36f, h * 0.14f), new PointF(w, h * 0.12f),
                new PointF(w, h), new PointF(w * 0.52f, h),
                new PointF(w * 0.42f, h * 0.58f), new PointF(w * 0.34f, h * 0.32f)
            };
            using (var cliffBrush = new SolidBrush(Color.FromArgb(44, 52, 68)))
                g.FillPolygon(cliffBrush, cliff);

            // Cloud tablecloth spilling over the top
            using (var cloudBrush = new SolidBrush(Color.FromArgb(190, 245, 250, 255)))
            {
                g.FillEllipse(cloudBrush, w * 0.32f, h * 0.10f, 140f, 36f);
                g.FillEllipse(cloudBrush, w * 0.52f, h * 0.08f, 180f, 42f);
            }

            // Abseil rope & climber silhouette
            using (var ropePen = new Pen(Color.FromArgb(220, 255, 200, 90), 2f))
                g.DrawLine(ropePen, w * 0.38f, h * 0.15f, w * 0.28f, h * 0.65f);
            using (var climberBrush = new SolidBrush(Color.FromArgb(245, 158, 11)))
                g.FillEllipse(climberBrush, w * 0.31f, h * 0.34f, 18f, 18f);
        }

        private static void PaintSharkCageDivingScene(Graphics g, int w, int h)
        {
            PaintThreeStopSky(g, w, h, Color.FromArgb(8, 108, 148), Color.FromArgb(6, 56, 96), Color.FromArgb(3, 18, 38));

            // Underwater sun rays
            for (int i = 0; i < 5; i++)
            {
                float rx = w * (0.12f + i * 0.18f);
                PointF[] ray = {
                    new PointF(rx, 0), new PointF(rx + 42f, 0),
                    new PointF(rx + 110f, h * 0.78f), new PointF(rx - 28f, h * 0.78f)
                };
                using (var rayBrush = new SolidBrush(Color.FromArgb(24, 125, 240, 255)))
                    g.FillPolygon(rayBrush, ray);
            }

            // Protective dive cage on left
            using (var cagePen = new Pen(Color.FromArgb(145, 180, 225, 245), 2.2f))
            {
                RectangleF cage = new RectangleF(24f, h * 0.18f, 96f, 165f);
                g.DrawRectangle(cagePen, cage.X, cage.Y, cage.Width, cage.Height);
                for (float x = cage.X + 16f; x < cage.Right; x += 16f)
                    g.DrawLine(cagePen, x, cage.Y, x, cage.Bottom);
            }

            // Great White Shark silhouette gliding through center-right
            float sx = w * 0.56f, sy = h * 0.40f;
            PointF[] sharkBody = {
                new PointF(sx - 95f, sy),
                new PointF(sx - 20f, sy - 24f),
                new PointF(sx + 5f, sy - 58f), // Dorsal fin
                new PointF(sx + 22f, sy - 20f),
                new PointF(sx + 95f, sy - 6f),
                new PointF(sx + 125f, sy - 36f), // Tail top
                new PointF(sx + 110f, sy),
                new PointF(sx + 122f, sy + 32f), // Tail bottom
                new PointF(sx + 92f, sy + 8f),
                new PointF(sx + 15f, sy + 22f),
                new PointF(sx - 18f, sy + 48f), // Pectoral fin
                new PointF(sx - 35f, sy + 20f)
            };
            using (var sBrush = new SolidBrush(Color.FromArgb(14, 32, 54)))
                g.FillPolygon(sBrush, sharkBody);
        }

        private static void PaintAtlantisDunesScene(Graphics g, int w, int h)
        {
            PaintThreeStopSky(g, w, h, Color.FromArgb(18, 78, 158), Color.FromArgb(68, 148, 218), Color.FromArgb(245, 208, 138));

            // Sweeping sunlit & shadowed sand dunes
            PointF[] dune1 = {
                new PointF(0, h * 0.48f), new PointF(w * 0.42f, h * 0.36f),
                new PointF(w, h * 0.52f), new PointF(w, h), new PointF(0, h)
            };
            using (var d1 = new SolidBrush(Color.FromArgb(238, 192, 118)))
                g.FillPolygon(d1, dune1);

            PointF[] dune2 = {
                new PointF(0, h * 0.62f), new PointF(w * 0.35f, h * 0.54f),
                new PointF(w * 0.78f, h * 0.42f), new PointF(w, h * 0.48f),
                new PointF(w, h), new PointF(0, h)
            };
            using (var d2 = new SolidBrush(Color.FromArgb(196, 136, 64)))
                g.FillPolygon(d2, dune2);
        }

        private static void PaintJazzFestivalScene(Graphics g, int w, int h)
        {
            PaintThreeStopSky(g, w, h, Color.FromArgb(14, 6, 32), Color.FromArgb(88, 22, 92), Color.FromArgb(18, 10, 28));

            // Dual stage spotlights
            PointF[] spot1 = { new PointF(w * 0.15f, 0), new PointF(w * 0.35f, 0), new PointF(w * 0.75f, h * 0.75f), new PointF(0, h * 0.75f) };
            PointF[] spot2 = { new PointF(w * 0.85f, 0), new PointF(w * 0.65f, 0), new PointF(w * 0.25f, h * 0.75f), new PointF(w, h * 0.75f) };
            using (var b1 = new SolidBrush(Color.FromArgb(38, 245, 158, 11))) g.FillPolygon(b1, spot1);
            using (var b2 = new SolidBrush(Color.FromArgb(38, 168, 85, 247))) g.FillPolygon(b2, spot2);

            // Bokeh lights
            var rng = new Random(707);
            for (int i = 0; i < 24; i++)
            {
                float bx = (float)(rng.NextDouble() * w);
                float by = (float)(h * 0.25 + rng.NextDouble() * h * 0.45);
                float br = 12f + (i % 4) * 10f;
                Color bc = (i % 2 == 0) ? Color.FromArgb(35, 255, 190, 70) : Color.FromArgb(35, 236, 72, 153);
                using (var bBrush = new SolidBrush(bc))
                    g.FillEllipse(bBrush, bx - br, by - br, br * 2f, br * 2f);
            }
        }

        private static void PaintSunsetCruiseScene(Graphics g, int w, int h)
        {
            PaintThreeStopSky(g, w, h, Color.FromArgb(38, 16, 68), Color.FromArgb(242, 88, 54), Color.FromArgb(255, 196, 82));

            // Setting sun on the Atlantic horizon
            float horizonY = h * 0.54f;
            using (var sunBrush = new SolidBrush(Color.FromArgb(230, 255, 235, 150)))
                g.FillEllipse(sunBrush, w * 0.34f, horizonY - w * 0.16f, w * 0.32f, w * 0.32f);

            // Ocean water below horizon
            using (var seaGrad = new LinearGradientBrush(
                new RectangleF(0, horizonY, w, h - horizonY),
                Color.FromArgb(92, 32, 68), Color.FromArgb(10, 18, 38), 90f))
            {
                g.FillRectangle(seaGrad, 0, horizonY, w, h - horizonY);
            }

            // Shimmering sunset reflections on water
            using (var shimmerPen = new Pen(Color.FromArgb(160, 255, 200, 110), 2.5f))
            {
                for (int i = 0; i < 9; i++)
                {
                    float sy = horizonY + 12f + i * 14f;
                    float sw = Math.Max(24f, 110f - i * 8f);
                    g.DrawLine(shimmerPen, w * 0.50f - sw / 2f, sy, w * 0.50f + sw / 2f, sy);
                }
            }

            // Catamaran sailboat silhouette
            float cx = w * 0.54f, cy = horizonY;
            PointF[] mainSail = {
                new PointF(cx, cy - 88f), new PointF(cx, cy - 6f), new PointF(cx - 46f, cy - 10f)
            };
            PointF[] jibSail = {
                new PointF(cx + 4f, cy - 76f), new PointF(cx + 38f, cy - 10f), new PointF(cx + 4f, cy - 8f)
            };
            using (var sailBrush = new SolidBrush(Color.FromArgb(22, 14, 32)))
            {
                g.FillPolygon(sailBrush, mainSail);
                g.FillPolygon(sailBrush, jibSail);
                g.FillRectangle(sailBrush, cx - 52f, cy - 6f, 96f, 9f);
            }
        }

        private static void PaintLionsHeadHikeScene(Graphics g, int w, int h)
        {
            PaintThreeStopSky(g, w, h, Color.FromArgb(24, 22, 64), Color.FromArgb(218, 102, 112), Color.FromArgb(252, 186, 118));

            // Iconic Lion's Head conical peak silhouette
            PointF[] peak = {
                new PointF(0, h * 0.64f),
                new PointF(w * 0.28f, h * 0.48f),
                new PointF(w * 0.46f, h * 0.24f), // Lion's Head spire
                new PointF(w * 0.56f, h * 0.26f),
                new PointF(w * 0.72f, h * 0.46f),
                new PointF(w, h * 0.42f),
                new PointF(w, h),
                new PointF(0, h)
            };
            using (var peakBrush = new SolidBrush(Color.FromArgb(26, 28, 48)))
                g.FillPolygon(peakBrush, peak);
        }

        private static void PaintCapePointBouldersScene(Graphics g, int w, int h)
        {
            PaintThreeStopSky(g, w, h, Color.FromArgb(14, 68, 112), Color.FromArgb(38, 182, 178), Color.FromArgb(18, 48, 68));

            // Distant Cape Point cliffs & lighthouse
            PointF[] cape = {
                new PointF(0, h * 0.46f), new PointF(w * 0.35f, h * 0.30f),
                new PointF(w * 0.62f, h * 0.44f), new PointF(0, h * 0.46f)
            };
            using (var cBrush = new SolidBrush(Color.FromArgb(32, 58, 78)))
                g.FillPolygon(cBrush, cape);

            // Lighthouse on the promontory
            g.FillRectangle(Brushes.White, w * 0.34f, h * 0.25f, 8f, 22f);
            g.FillRectangle(Brushes.Crimson, w * 0.33f, h * 0.23f, 10f, 5f);

            // Boulders Beach giant granite boulders in foreground
            using (var bBrush = new SolidBrush(Color.FromArgb(62, 68, 82)))
            {
                g.FillEllipse(bBrush, -30f, h * 0.54f, 190f, 140f);
                g.FillEllipse(bBrush, w * 0.58f, h * 0.52f, 220f, 160f);
            }
        }
    }
}
