using PROJECTT.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJECTT
{
    public partial class frmResetPassword : Form
    {
        private string verifiedEmail; // This variable will hold the verified email address from the previous form

        public frmResetPassword(string ForgotEmail)
        {
            // This constructor takes the verified email address as a parameter and initializes the form
            InitializeComponent();
            // Load embedded resources at runtime (keeps Designer CodeDomSerializer 100% error-free)
            try
            {
                this.BackgroundImage = global::PROJECTT.Properties.Resources.bg_forgot_reset;
            }
            catch { }
            SafariThemeEngine.ApplyAuthFormTheme(this, "CREATE NEW SAFARI PASSWORD", SafariThemeEngine.SafariEmerald);
            verifiedEmail = ForgotEmail;
        }


        public frmResetPassword()
        {
            InitializeComponent();
            // Load embedded resources at runtime (keeps Designer CodeDomSerializer 100% error-free)
            try
            {
                this.BackgroundImage = global::PROJECTT.Properties.Resources.bg_forgot_reset;
            }
            catch { }
            SafariThemeEngine.ApplyAuthFormTheme(this, "CREATE NEW SAFARI PASSWORD", SafariThemeEngine.SafariEmerald);
        }

        private void txtCreatePassword_TextChanged(object sender, EventArgs e)
        {
            // This method is called when the user types in the create password textbox. It checks if the password meets the requirements and shows or hides the warning label accordingly.
            string Resetpassword = txtCreatePassword.Text;
            bool PasswordCheck = Regex.IsMatch(Resetpassword, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$");

            // 1. Check for missing character requirements
            bool hasUpper = Resetpassword.Any(char.IsUpper);
            bool hasNumber = Resetpassword.Any(char.IsDigit);
            bool hasSpecial = Resetpassword.Any(c => !char.IsLetterOrDigit(c));

            if (string.IsNullOrWhiteSpace(Resetpassword))
            {
                lblLength.Text = "";
            }
            // Does not meet the baseline character types OR is too short
            else if (!hasUpper || !hasNumber || !hasSpecial || Resetpassword.Length < 8)
            {
                lblLength.Text = "Weak password!";
                lblLength.ForeColor = Color.Red;
            }
            // Meets the requirements perfectly (Exactly 8 characters + all required types)
            else if (Resetpassword.Length == 8)
            {
                lblLength.Text = "Medium password!";
                lblLength.ForeColor = Color.Orange;
            }
            // Exceeds the requirements (More than 8 characters + all required types)
            else
            {
                lblLength.Text = "Strong password!";
                lblLength.ForeColor = Color.Green;
            }


            if (string.IsNullOrWhiteSpace(Resetpassword))
            {
                
                lblCreatePasswordViolation.Text = ("Password must be at least 8 characters long, contain an uppercase letter, a lowercase letter, and a number!");
                lblCreatePasswordViolation.Visible = false;
                //block the user from continuing with registration
                return;
            }

            // Check if the password meets the requirements
            if (!PasswordCheck)
            {
                lblCreatePasswordViolation.Text = ("Password must be at least 8 characters long, contain an uppercase letter, a lowercase letter, and a number!");
                lblCreatePasswordViolation.Visible = true;
            }
            else
            {
                lblCreatePasswordViolation.Visible = false;
            }
        }

        private void txtConfirmForgotPassword_TextChanged(object sender, EventArgs e)
        {
            string Resetpassword = txtCreatePassword.Text;
            string confirmResetPassword = txtConfirmForgotPassword.Text;

            // 1. Check for missing character requirements
            bool hasUpper = confirmResetPassword.Any(char.IsUpper);
            bool hasNumber = confirmResetPassword.Any(char.IsDigit);
            bool hasSpecial = confirmResetPassword.Any(c => !char.IsLetterOrDigit(c));

            if (string.IsNullOrWhiteSpace(confirmResetPassword))
            {
                lblLength.Text = "";
            }/*
            // Does not meet the baseline character types OR is too short
            else if (!hasUpper || !hasNumber || !hasSpecial || confirmResetPassword.Length < 8)
            {
                lblLength.Text = "Weak password!";
                lblLength.ForeColor = Color.Red;
            }
            // Meets the requirements perfectly (Exactly 8 characters + all required types)
            else if (confirmResetPassword.Length == 8)
            {
                lblLength.Text = "Medium password!";
                lblLength.ForeColor = Color.Orange;
            }
            // Exceeds the requirements (More than 8 characters + all required types)
            else
            {
                lblLength.Text = "Strong password!";
                lblLength.ForeColor = Color.Green;
            }*/


            // Rule 1: If both are completely empty, keep things clean (no warning)
            if (string.IsNullOrEmpty(Resetpassword) && string.IsNullOrEmpty(confirmResetPassword))
            {
                lblConfirmForgotPasswordViolation.Visible = false;
                //block the user from continuing with registration
                return;
            }

            // Rule 2: Check if the text matches exactly
            if (Resetpassword == confirmResetPassword)
            {
                // The moment they match, the warning sign disappears instantly!
                lblConfirmForgotPasswordViolation.Visible = false;
            }
            else
            {
                // Show warning instantly if they do not match
                lblConfirmForgotPasswordViolation.Text = "Password do not match!please re - type your password";
                lblConfirmForgotPasswordViolation.Visible = true;
            }
        }


        // This method is called when the user checks or unchecks the "Show Password" checkbox. It toggles the visibility of the password characters in the create and confirm password textboxes.
        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShow.Checked)
            {
                txtCreatePassword.PasswordChar = '\0';
                txtConfirmForgotPassword.PasswordChar = '\0';
            }
            else
            {
                txtCreatePassword.PasswordChar = '*';
                txtConfirmForgotPassword.PasswordChar = '*';
            }
        }

        // This method is called when the user clicks the "Create" button. It validates the input, hashes the new password, and updates the password in the Visitor.txt file if the verified email is found.
        private void btnCreate_Click(object sender, EventArgs e)
        {
            lblCreatePasswordViolation.Visible = false;
            lblConfirmForgotPasswordViolation.Visible = false;

            if (string.IsNullOrWhiteSpace(txtCreatePassword.Text))
            {
                lblCreatePasswordViolation.Visible = true;
                return;
            }
            if (string.IsNullOrWhiteSpace(txtConfirmForgotPassword.Text))
            {
                lblConfirmForgotPasswordViolation.Visible = true;
                return;
            }

            if (!Regex.IsMatch(txtCreatePassword.Text, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$"))
            {
                lblCreatePasswordViolation.Visible = true;
                return;
            }
            if (txtCreatePassword.Text != txtConfirmForgotPassword.Text)
            {
                lblConfirmForgotPasswordViolation.Visible = true;
                return;
            }

            string projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
            string filePath = Path.Combine(projectDirectory, "Text Files", "Visitor.txt");
            string tempFilepath = Path.Combine(projectDirectory, "Text Files", "TempVisitor.txt");
            bool userFound = false;

            string newPassword = txtCreatePassword.Text;
            string newHashPassword = HashPassword(newPassword);

            try
            {
                // Read the Visitor.txt file line by line, split each line by tab, and check if the email matches the verified email. If it does, update the password hash and write to a temporary file. Otherwise, write the original line to the temporary file.
                using (StreamReader reader = new StreamReader(filePath))
                using (StreamWriter writer = new StreamWriter(tempFilepath))
                {
                    string line;
                    line = reader.ReadLine();
                    while (line != null)
                    {
                        string[] lineArray = line.Split('\t');
                        if (lineArray.Length >= 8)
                        {
                            if (lineArray[2].Trim().Equals(verifiedEmail.Trim(), StringComparison.OrdinalIgnoreCase))
                            {
                                lineArray[7] = newHashPassword;
                                userFound = true;
                            }
                            writer.WriteLine(lineArray[0] + "\t" + lineArray[1] + "\t" + lineArray[2] + "\t" + lineArray[3] + "\t" + lineArray[4] + "\t" + lineArray[5] + "\t" + lineArray[6] + "\t" + lineArray[7] + "\t" + lineArray[8]);
                        }
                        else
                        {
                            writer.WriteLine(line);
                        }
                        line = reader.ReadLine();
                    }
                    

                    
                }
                // If the user was found and the password was updated, replace the original file with the temporary file. Otherwise, delete the temporary file and show an error message.
                if (userFound)
                {
                    File.Delete(filePath);
                    File.Move(tempFilepath, filePath);
                    MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCreatePassword.Clear();
                    txtConfirmForgotPassword.Clear();
                    frmLogin nextform = new frmLogin();
                    nextform.WindowState = this.WindowState;
                    // Match the starting position if its retuened to normal
                    nextform.StartPosition = FormStartPosition.Manual;
                    nextform.Location = this.Location;
                    nextform.Size = this.Size;

                    nextform.Show();

                    this.Hide();
                }
                else
                {
                    if (File.Exists(tempFilepath))
                    {
                        File.Delete(tempFilepath);
                    }
                    MessageBox.Show("Error: Verified email was not found in the file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

          
            }
            catch(Exception ex)
            {

                MessageBox.Show("An error occurred: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder result = new StringBuilder();

                foreach (byte b in hash)
                {
                    result.Append(b.ToString("x2"));
                }

                return result.ToString();
            }
        }

        private void frmResetPassword_Load(object sender, EventArgs e)
        {

        }
    }   }
