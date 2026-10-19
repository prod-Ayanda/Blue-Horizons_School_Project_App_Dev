using System;
using System.Windows.Forms;

namespace PROJECTT
{
    public partial class Browse_Attractions : Form
    {
        private string selectedAttraction = null;

        public Browse_Attractions()
        {
            InitializeComponent();
            // Load embedded resources at runtime (keeps Designer CodeDomSerializer 100% error-free)
            try
            {
                this.BackgroundImage = global::PROJECTT.Properties.Resources.bg_admin_dashboard;
            }
            catch { }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //link to dashboard form
            Dashboard homeForm = new Dashboard();
            // Set the WindowState of the new form to match the current form's WindowState
            homeForm.WindowState = this.WindowState;
            // Match the starting position if its retuened to normal
            homeForm.StartPosition = FormStartPosition.Manual;
            homeForm.Location = this.Location;
            homeForm.Size = this.Size;

            homeForm.Show();
            this.Hide();
        }

        private void btnSelect1_Click(object sender, EventArgs e)
        {
            selectedAttraction = lblName1.Text;
            HighlightSelectedCard(pnlCard1);
        }

        private void btnSelect2_Click(object sender, EventArgs e)
        {
            selectedAttraction = lblName2.Text;
            HighlightSelectedCard(pnlCard2);
        }

        private void btnSelect3_Click(object sender, EventArgs e)
        {
            selectedAttraction = lblName3.Text;
            HighlightSelectedCard(pnlCard3);
        }

        private void HighlightSelectedCard(Panel selectedPanel)
        {
            // Reset all three cards back to the normal colour, then
            // highlight only the one that was just selected
            pnlCard1.BackColor = System.Drawing.Color.FromArgb(20, 32, 48);
            pnlCard2.BackColor = System.Drawing.Color.FromArgb(20, 32, 48);
            pnlCard3.BackColor = System.Drawing.Color.FromArgb(20, 32, 48);

            selectedPanel.BackColor = System.Drawing.Color.FromArgb(30, 55, 75);

            btnSelect1.Text = "Select";
            btnSelect2.Text = "Select";
            btnSelect3.Text = "Select";

            if (selectedPanel == pnlCard1) btnSelect1.Text = "Selected";
            if (selectedPanel == pnlCard2) btnSelect2.Text = "Selected";
            if (selectedPanel == pnlCard3) btnSelect3.Text = "Selected";

            btnProceedToPayment.Enabled = true;
        }

        private void btnProceedToPayment_Click(object sender, EventArgs e)
        {
            // Full booking, payment, and invoice logic is Phase 2 work —
            // this stub confirms the navigation and selection flow works.
            MessageBox.Show(
                "You selected: " + selectedAttraction + "\n\nPayment & Booking is coming in Phase 2.",
                "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
