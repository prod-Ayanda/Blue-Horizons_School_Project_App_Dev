using PROJECTT.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PROJECTT
{
    public partial class Welcome_page_Admin_locked : Form
    {
        // 1. Class-level boolean flag
        private bool isAdminLocked = true;

        public Welcome_page_Admin_locked()
        {
            InitializeComponent();
            // Load embedded resources at runtime (keeps Designer CodeDomSerializer 100% error-free)
            try
            {
                this.pictureBox1.BackgroundImage = global::PROJECTT.Properties.Resources.welcome_pic1_bg;
            }
            catch { }
            SafariThemeEngine.ApplyKexsioUiverseWelcomeTemplate(this, panel3, btnVisitor, btnAdmin, lblOR, () => isAdminLocked);

            // Set KeyPreview to true so form captures shortcut keys
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Welcome_page_Admin_locked_KeyDown);
        }

        // 4. KeyDown event handler: Ctrl + Shift + A unlocks admin PIN prompt
        private void Welcome_page_Admin_locked_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.A)
            {
                e.SuppressKeyPress = true;
                PromptSystemAdminPin();
            }
        }

        private void PromptSystemAdminPin()
        {
            using (Form pinForm = new Form())
            {
                pinForm.Text = "System Admin Verification";
                pinForm.Size = new Size(350, 175);
                pinForm.StartPosition = FormStartPosition.CenterParent;
                pinForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                pinForm.MaximizeBox = false;
                pinForm.MinimizeBox = false;

                Label lblPrompt = new Label()
                {
                    Text = "Enter System Admin PIN:",
                    Left = 20,
                    Top = 20,
                    Width = 290
                };

                TextBox txtPin = new TextBox()
                {
                    Left = 20,
                    Top = 48,
                    Width = 290,
                    UseSystemPasswordChar = true
                };

                Button btnOk = new Button()
                {
                    Text = "OK",
                    Left = 140,
                    Top = 85,
                    Width = 80,
                    DialogResult = DialogResult.OK
                };

                Button btnCancel = new Button()
                {
                    Text = "Cancel",
                    Left = 230,
                    Top = 85,
                    Width = 80,
                    DialogResult = DialogResult.Cancel
                };

                pinForm.Controls.Add(lblPrompt);
                pinForm.Controls.Add(txtPin);
                pinForm.Controls.Add(btnOk);
                pinForm.Controls.Add(btnCancel);
                pinForm.AcceptButton = btnOk;
                pinForm.CancelButton = btnCancel;

                if (pinForm.ShowDialog(this) == DialogResult.OK)
                {
                    string enteredPin = txtPin.Text.Trim();
                    if (enteredPin == "sysadmin")
                    {
                        isAdminLocked = false;
                        panel3?.Invalidate();
                        btnAdmin?.Invalidate();
                        MessageBox.Show("Admin access unlocked. You can now access the Ranger Portal.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Invalid System Admin PIN.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // 3. btnAdmin_Click handler based on isAdminLocked state
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            if (isAdminLocked)
            {
                MessageBox.Show("Admin access is locked.");
            }
            else
            {
                MessageBox.Show("Access Granted. Redirecting to Admin dashboard...");
                Welcome unlocked = new Welcome();
                unlocked.StartPosition = FormStartPosition.Manual;
                unlocked.StartPosition = FormStartPosition.CenterParent;
                unlocked.FormBorderStyle = FormBorderStyle.FixedDialog;
                unlocked.MaximizeBox = false;
                unlocked.MinimizeBox = false;
                unlocked.Show();
                this.Hide();
            }
        }

        /// <summary>
        /// Visitor route: straight to the registration form, no passkey needed.
        /// </summary>
        private void btnVisitor_Click(object sender, EventArgs e)
        {
            AdminSession.Reset();
            //link to visitor registration form
            frmRegister nextform = new frmRegister();
            // Set the WindowState of the new form to match the current form's WindowState
            nextform.WindowState = this.WindowState;
            // Match the starting position if its retuened to normal
            nextform.StartPosition = FormStartPosition.Manual;
            nextform.Location = this.Location;
            nextform.Size = this.Size;

            nextform.Show();

            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
            {
                SafariThemeEngine.PaintWelcomeHeroSurface(e.Graphics, panel3.ClientSize.Width, panel3.ClientSize.Height, isAdminLocked, 0, null);
            }
        }
    }
}
