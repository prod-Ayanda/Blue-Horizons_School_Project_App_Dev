using PROJECTT.Services;
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
    public partial class frmTerms : Form
    {
        public frmTerms()
        {
            InitializeComponent();
            SafariThemeEngine.ApplyAuthFormTheme(this, "BLUE HORIZONS TERMS & CONDITIONS", SafariThemeEngine.SunsetAmber);
        }

        private void linkBackRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Link to register form
            frmRegister nextform = new frmRegister();
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
