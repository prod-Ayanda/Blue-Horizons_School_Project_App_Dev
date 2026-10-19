using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJECTT
{
    public partial class AdminDashboard2 : Form
    {
        public AdminDashboard2()
        {
            InitializeComponent();
            // Load embedded resources at runtime (keeps Designer CodeDomSerializer 100% error-free)
            try
            {
                this.picLogo.Image = global::PROJECTT.Properties.Resources.blue_horizon_610x703;
                this.BackgroundImage = global::PROJECTT.Properties.Resources.home_Background;
            }
            catch { }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Change this line if admins should land somewhere else.
            Welcome nextform = new Welcome();
            // Set the WindowState of the new form to match the current form's WindowState
            nextform.WindowState = this.WindowState;
            // Match the starting position if its retuened to normal
            nextform.StartPosition = FormStartPosition.Manual;
            nextform.Location = this.Location;
            nextform.Size = this.Size;

            nextform.Show();

            this.Hide();
        }

                
        private void btnEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
               "Edit is coming in.",
               "Phase 2", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                MessageBox.Show(
                   "Update About Us is coming in.",
                   "Phase 2", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                MessageBox.Show(
                   "Booking History is coming in.",
                   "Phase 2", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                MessageBox.Show(
                    "Update Events is coming in.",
                    "Phase 2", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AdminDashboard2_Load(object sender, EventArgs e)
        {

        }
    }
}
