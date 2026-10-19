using System.Drawing;
using PROJECTT.Services;
using System;
using System.Windows.Forms;

namespace PROJECTT
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
            // Load embedded resources at runtime (keeps Designer CodeDomSerializer 100% error-free)
            try
            {
                this.pictureBox1.BackgroundImage = global::PROJECTT.Properties.Resources.welcome_pic1_bg;
            }
            catch { }
            SafariThemeEngine.ApplyKexsioUiverseWelcomeTemplate(this, panel3, btnVisitor, btnAdmin, lblOR, false);
        }

        /// <summary>
        /// Admin route: ask for the 6-digit passkey first. Only if it is correct
        /// does the admin's own login form open.
        /// </summary>
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminSession.Reset();

            DialogResult passkeyResult;

            using (frmPasskey passkeyBox = new frmPasskey())
            {
                passkeyResult = passkeyBox.ShowDialog(this);
            }

            if (passkeyResult == DialogResult.Cancel)
            {
                return;
            }

            if (passkeyResult != DialogResult.OK)
            {
                Welcome_page_Admin_locked locked = new Welcome_page_Admin_locked();
                // Set the WindowState of the new form to match the current form's WindowState
                locked.WindowState = this.WindowState;
                locked.StartPosition = FormStartPosition.Manual;
                locked.Location = this.Location;
                locked.Size = this.Size;
                locked.Show();
                this.Hide();
                return;
            }
            // Link to admin login form, after passkey is accepted.
            DialogResult loginResult;
            using (frmAdminLogin nextform = new frmAdminLogin())
            {
                // Set the WindowState of the new form to match the current form's WindowState
                nextform.WindowState = this.WindowState;
                // Match the starting position if its retuened to normal
                nextform.StartPosition = FormStartPosition.Manual;
                nextform.Location = this.Location;
                nextform.Size = this.Size;

                loginResult = nextform.ShowDialog(this);
            }

            if (loginResult == DialogResult.Cancel)
            {
                return;
            }

            this.Hide();
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
                SafariThemeEngine.PaintWelcomeHeroSurface(e.Graphics, panel3.ClientSize.Width, panel3.ClientSize.Height, false, 0, null);
            }
        }
    }
}
