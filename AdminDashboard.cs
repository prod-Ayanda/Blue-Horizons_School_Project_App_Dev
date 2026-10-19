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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
            // Load embedded resources at runtime (keeps Designer CodeDomSerializer 100% error-free)
            try
            {
                this.BackgroundImage = global::PROJECTT.Properties.Resources.bg_admin_dashboard;
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Welcome attractionsForm = new Welcome();
            // Set the WindowState of the new form to match the current form's WindowState
            attractionsForm.WindowState = this.WindowState;
            // Match the starting position if its retuened to normal
            attractionsForm.StartPosition = FormStartPosition.Manual;
            attractionsForm.Location = this.Location;
            attractionsForm.Size = this.Size;

            attractionsForm.Show();
            this.Hide();
        }
    }
}
