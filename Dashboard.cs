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
    public partial class Dashboard : Form
    {
        private System.Windows.Forms.Timer _clockTimer;
        private Label lblLocation;
        private Label lblClock;

        public Dashboard()
        {
            InitializeComponent();
            // Load embedded resources at runtime (keeps Designer CodeDomSerializer 100% error-free)
            try
            {
                this.picLogo.Image = global::PROJECTT.Properties.Resources.blue_horizon_610x703;
                this.BackgroundImage = global::PROJECTT.Properties.Resources.bg_dashboard;
            }
            catch { }
            InitLocationAndClock();
            Services.FileService.AutoUpdateNoShowBookings();
        }

        private void InitLocationAndClock()
        {
            lblLocation = new Label
            {
                Text = "📍 Durban, KwaZulu-Natal",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 120, 130),
                AutoSize = true,
                Location = new Point(56, 115)
            };
            this.Controls.Add(lblLocation);
            lblLocation.BringToFront();

            lblClock = new Label
            {
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(16, 140, 90),
                AutoSize = true,
                Location = new Point(270, 115)
            };
            this.Controls.Add(lblClock);
            lblClock.BringToFront();

            _clockTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            _clockTimer.Tick += (s, e) =>
            {
                lblClock.Text = DateTime.Now.ToString("dddd, dd MMM yyyy • HH:mm:ss");
            };
            _clockTimer.Start();
            lblClock.Text = DateTime.Now.ToString("dddd, dd MMM yyyy • HH:mm:ss");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Welcome welcomeForm = new Welcome();
            welcomeForm.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowseAttractions_Click(object sender, EventArgs e)
        {
            //Link to browse attractions form
            Browse_Attractions attractionsForm = new Browse_Attractions();
            // Set the WindowState of the new form to match the current form's WindowState
            attractionsForm.WindowState = this.WindowState;
            // Match the starting position if its retuened to normal
            attractionsForm.StartPosition = FormStartPosition.Manual;
            attractionsForm.Location = this.Location;
            attractionsForm.Size = this.Size;

            attractionsForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //link to attractions form
            frmLogin attractionsForm = new frmLogin();
            // Set the WindowState of the new form to match the current form's WindowState
            attractionsForm.WindowState = this.WindowState;
            // Match the starting position if its retuened to normal
            attractionsForm.StartPosition = FormStartPosition.Manual;
            attractionsForm.Location = this.Location;
            attractionsForm.Size = this.Size;

            attractionsForm.Show();
            this.Hide();
        }

        private void btnMyProfile_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
               "Profile is coming in.",
               "Phase", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}