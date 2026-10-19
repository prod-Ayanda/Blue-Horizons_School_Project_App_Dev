using System;
using System.Windows.Forms;

namespace PROJECTT
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
            // Load embedded resources at runtime (keeps Designer CodeDomSerializer 100% error-free)
            try
            {
                this.panel3.BackgroundImage = global::PROJECTT.Properties.Resources.ChatGPT_Image_Aug_29__2026__02_55_26_AM;
            }
            catch { }
        }

        /// <summary>
        /// Admin route: ask for the 6-digit passkey first. Only if it is correct
        /// does the admin's own login form open.
        /// </summary>
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminSession.Reset();

            bool passkeyAccepted;

            using (frmPasskey passkeyBox = new frmPasskey())
            {
                passkeyAccepted = (passkeyBox.ShowDialog(this) == DialogResult.OK);
            }

            if (!passkeyAccepted)
            {
                // Wrong passkey or cancelled - stay on the Welcome form.
                return;
            }

            frmAdminLogin nextform = new frmAdminLogin();
            // Set the WindowState of the new form to match the current form's WindowState
            nextform.WindowState = this.WindowState;
            // Match the starting position if its retuened to normal
            nextform.StartPosition = FormStartPosition.Manual;
            nextform.Location = this.Location;
            nextform.Size = this.Size;

            nextform.Show();

            this.Hide();
        }

        /// <summary>
        /// Visitor route: straight to the registration form, no passkey needed.
        /// </summary>
        private void btnVisitor_Click(object sender, EventArgs e)
        {
            AdminSession.Reset();
            //Link to registration
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
    }
}
