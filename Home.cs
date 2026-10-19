using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJECTT
{
    public partial class Home : Form
    {
        private static readonly string storyFilePath =
            Path.Combine(Application.StartupPath, "CompanyStory.txt");

        private System.Windows.Forms.Timer _clockTimer;
        private Label lblLocation;
        private Label lblClock;

        public Home()
        {
            InitializeComponent();
            // Load embedded resources at runtime (keeps Designer CodeDomSerializer 100% error-free)
            try
            {
                this.picLogo.Image = global::PROJECTT.Properties.Resources.blue_horizon_610x703;
                this.BackgroundImage = global::PROJECTT.Properties.Resources.safari_elephants_moving;
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
                Location = new Point(48, 60)
            };
            this.Controls.Add(lblLocation);
            lblLocation.BringToFront();

            lblClock = new Label
            {
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(16, 140, 90),
                AutoSize = true,
                Location = new Point(260, 60)
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

        private void Home_Load(object sender, EventArgs e)
        {
            lblStoryBody.Text = LoadCompanyStory();
        }

        private string LoadCompanyStory()
        {
            string defaultStory = "Blue Horizon was founded to bring Cape Town's untamed " +
                "beauty within reach of every traveller. From dust-trail safaris " +
                "beneath Table Mountain's shadow to golden-hour drives along the " +
                "Cape Peninsula, we've spent years curating unforgettable journeys " +
                "into the wild heart of South Africa.";

            if (!File.Exists(storyFilePath))
            {
                File.WriteAllText(storyFilePath, defaultStory);
                return defaultStory;
            }

            return File.ReadAllText(storyFilePath);
        }

        private void SaveCompanyStory(string newText)
        {
            File.WriteAllText(storyFilePath, newText);
        }

        private void btnEditStory_Click(object sender, EventArgs e)
        {
            // NOTE: there is no Admin/Visitor role check here yet — role-based
            // permissions haven't been built in Phase 1.
            //Link to edit story form
            EditStory editForm = new EditStory();
            editForm.StoryText = lblStoryBody.Text;

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                lblStoryBody.Text = editForm.StoryText;
                SaveCompanyStory(editForm.StoryText);
            }
        }

        private void btnBrowseAttractions_Click(object sender, EventArgs e)
        {
            //Link to dashboard form
            Dashboard attractionsForm = new Dashboard();
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
            MessageBox.Show("My Profile is coming in Phase 2.", "Coming Soon",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //Link to welcome form
            Welcome welcomeForm = new Welcome();
            // Set the WindowState of the new form to match the current form's WindowState
            welcomeForm.WindowState = this.WindowState;
            // Match the starting position if its retuened to normal
            welcomeForm.StartPosition = FormStartPosition.Manual;
            welcomeForm.Location = this.Location;
            welcomeForm.Size = this.Size;

            welcomeForm.Show();
            this.Hide();
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }

        private void lblStoryHeading_Click(object sender, EventArgs e)
        {

        }
    }
}