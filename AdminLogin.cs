using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PROJECTT.Forms;
using PROJECTT.Models;
using PROJECTT.Services;

namespace PROJECTT
{
    /// <summary>
    /// The admin's own login form. There is only one admin, so the email and
    /// password are checked against the variables in AdminSession - no text
    /// file is read here. Visitors use frmLogin instead.
    /// </summary>
    public partial class frmAdminLogin : Form
    {
        private const string EmailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+(?:\.[^@\s]+)*$";

        public frmAdminLogin()
        {
            InitializeComponent();
            // Load embedded resources at runtime (keeps Designer CodeDomSerializer 100% error-free)
            try
            {
                this.BackgroundImage = global::PROJECTT.Properties.Resources.i_safarii;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch { }
            SafariThemeEngine.ApplyAuthFormTheme(this, "ADMIN PORTAL AUTHENTICATION", SafariThemeEngine.RoyalViolet);

            // Safety net: this form should only ever be reached through the
            // passkey box on the Welcome form.
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime && !AdminSession.PasskeyVerified)
            {
                MessageBox.Show("Admin passkey has not been verified.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.Load += new EventHandler(CloseImmediately);
            }

            this.Load += (s, e) => ApplyResponsiveLayout();
            this.Resize += (s, e) => ApplyResponsiveLayout();
        }

        private void ApplyResponsiveLayout()
        {
            if (panelCard == null) return;
            panelCard.Location = new Point(
                Math.Max(20, (this.ClientSize.Width - panelCard.Width) / 2),
                Math.Max(20, (this.ClientSize.Height - panelCard.Height) / 2));
            if (linkAdminBack != null)
            {
                linkAdminBack.Location = new Point(18, 16);
            }
        }

        private void CloseImmediately(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtAdminEmail_TextChanged(object sender, EventArgs e)
        {
            string email = txtAdminEmail.Text.Trim();

            // Nothing typed yet - say nothing.
            if (string.IsNullOrWhiteSpace(email))
            {
                lblAdminEmailViolation.Visible = false;
                return;
            }

            // Warn as they type if the address does not end with .co.za
            if (!AdminSession.HasAllowedEmailEnding(email))
            {
                ShowEmailWarning("Admin email must end with " +
                    AdminSession.RequiredEmailEnding + "!");
            }
            else
            {
                lblAdminEmailViolation.Visible = false;
            }
        }

        private void txtAdminPassword_TextChanged(object sender, EventArgs e)
        {
            lblAdminPasswordViolation.Visible = false;
        }

        private void chkAdminShow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAdminShow.Checked)
            {
                txtAdminPassword.PasswordChar = '\0';
            }
            else
            {
                txtAdminPassword.PasswordChar = '*';
            }
        }

        private void btnAdminLogIn_Click(object sender, EventArgs e)
        {
            lblAdminEmailViolation.Visible = false;
            lblAdminPasswordViolation.Visible = false;

            string enteredEmail = txtAdminEmail.Text.Trim();
            string enteredPassword = txtAdminPassword.Text.Trim();
            bool isValid = true;

            // Email checks
            if (string.IsNullOrWhiteSpace(enteredEmail))
            {
                ShowEmailWarning("Please fill in your email!");
                isValid = false;
            }
            else if (!Regex.IsMatch(enteredEmail, EmailPattern))
            {
                ShowEmailWarning("Please enter a valid email address!");
                isValid = false;
            }
            else if (!AdminSession.HasAllowedEmailEnding(enteredEmail))
            {
                ShowEmailWarning("Admin email must end with " +
                    AdminSession.RequiredEmailEnding + "!");
                isValid = false;
            }

            // Password checks
            if (string.IsNullOrWhiteSpace(enteredPassword))
            {
                ShowPasswordWarning("Please fill in your password!");
                isValid = false;
            }

            if (!isValid)
            {
                return;
            }

            // Check against AdminSession OR updated admin credentials in Data/users.txt
            FileService.EnsureDataFolder();
            SeedService.SeedIfEmpty();
            List<User> users = FileService.GetAllUsers();
            User fileAdmin = users.FirstOrDefault(u =>
                u.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase) &&
                u.Email.Equals(enteredEmail, StringComparison.OrdinalIgnoreCase));

            bool validAdmin = AdminSession.AreAdminCredentialsCorrect(enteredEmail, enteredPassword) ||
                              (fileAdmin != null && PasswordHelper.VerifyPassword(enteredPassword, fileAdmin.PasswordHash));

            if (validAdmin)
            {
                AdminSession.IsAdminLoggedIn = true;

                txtAdminEmail.Clear();
                txtAdminPassword.Clear();

                MessageBox.Show("Welcome back, Admin!", "Login Successful",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                User adminUser = fileAdmin ?? users.FirstOrDefault(u =>
                    u.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase));

                if (adminUser == null)
                {
                    adminUser = new User
                    {
                        UserID       = Guid.NewGuid().ToString(),
                        FirstName    = "Blue Horizons",
                        LastName     = "Admin",
                        Email        = enteredEmail,
                        Phone        = "0210000000",
                        Gender       = "N/A",
                        PasswordHash = PasswordHelper.HashNewPassword(enteredPassword),
                        Role         = "Admin"
                    };
                    FileService.AddUser(adminUser);
                }

                AdminDashboardForm nextform = new AdminDashboardForm(adminUser);
                nextform.WindowState = this.WindowState;
                if (this.WindowState == FormWindowState.Normal)
                {
                    nextform.StartPosition = FormStartPosition.Manual;
                    nextform.Location = this.Location;
                    nextform.Size = this.Size;
                }
                nextform.FormClosed += (s, args) =>
                {
                    AdminSession.Reset();
                    Welcome welcomeForm = new Welcome();
                    welcomeForm.WindowState = nextform.WindowState;
                    if (nextform.WindowState == FormWindowState.Normal)
                    {
                        welcomeForm.StartPosition = FormStartPosition.Manual;
                        welcomeForm.Location = nextform.Location;
                        welcomeForm.Size = nextform.Size;
                    }
                    welcomeForm.Show();
                };

                nextform.Show();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                txtAdminEmail.Clear();
                txtAdminPassword.Clear();
                ShowEmailWarning("Invalid admin email or password. Please try again.");
                ShowPasswordWarning("Invalid admin email or password. Please try again.");
            }
        }

        private void linkAdminBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AdminSession.Reset();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            AdminSession.Reset();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmAdminLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            // If the admin never actually logged in, drop the passkey flag so the
            // form cannot be reopened without entering the passkey again.
            if (!AdminSession.IsAdminLoggedIn)
            {
                AdminSession.Reset();
            }
        }

        private void ShowEmailWarning(string message)
        {
            lblAdminEmailViolation.Text = message;
            lblAdminEmailViolation.Visible = true;
        }

        private void ShowPasswordWarning(string message)
        {
            lblAdminPasswordViolation.Text = message;
            lblAdminPasswordViolation.Visible = true;
        }
    }
}
