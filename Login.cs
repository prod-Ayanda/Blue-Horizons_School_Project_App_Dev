using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using PROJECTT.Forms;
using PROJECTT.Models;
using PROJECTT.Services;

namespace PROJECTT
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            // Load embedded resources at runtime (keeps Designer CodeDomSerializer 100% error-free)
            try
            {
                this.pictureBox4.Image = global::PROJECTT.Properties.Resources.passworddd;
                this.pictureBox3.Image = global::PROJECTT.Properties.Resources.login_pic3;
                this.panel3.BackgroundImage = global::PROJECTT.Properties.Resources.login_panel3_bg;
                this.pictureBoxaLogo.Image = global::PROJECTT.Properties.Resources.ChatGPT_Image_Aug_29__2026__03_30_30_PM;
                this.object_ec93ebce_c74e_4598_a7d9_58d744e0d435.Image = global::PROJECTT.Properties.Resources.emaill;
            }
            catch { }
            SafariThemeEngine.ApplyAuthFormTheme(this, "VISITOR SIGN IN • KOKONUT & UIVERSE", SafariThemeEngine.SafariEmerald);
            this.Load += (s, e) => ApplyResponsiveLayout();
            this.Shown += (s, e) => ApplyResponsiveLayout();
            this.Resize += (s, e) => ApplyResponsiveLayout();
            this.SizeChanged += (s, e) => ApplyResponsiveLayout();
        }

        private void ApplyResponsiveLayout()
        {
            if (this.WindowState == FormWindowState.Minimized) return;
            int clientW = this.ClientSize.Width;
            int clientH = this.ClientSize.Height;

            // Left decorative panel takes ~38-42% of width (clamped between 360 and 680)
            int leftW = Math.Max(360, Math.Min(680, (int)(clientW * 0.40)));
            if (panel3 != null)
            {
                panel3.Location = new Point(0, 0);
                panel3.Size = new Size(leftW, clientH);
            }

            if (linkLabel1 != null)
            {
                linkLabel1.Location = new Point(leftW + 20, 20);
            }

            // Right side area
            int rightAreaW = clientW - leftW;
            int rightCenterX = leftW + rightAreaW / 2;

            int colW = Math.Min(540, Math.Max(380, rightAreaW - 60));
            int startX = rightCenterX - colW / 2;
            int inputX = startX + 44; // room for 34px icon + 10px gap
            int inputW = colW - 44;

            // Compute vertical offset to keep content centered if tall
            int totalBlockH = 580;
            int topOffset = Math.Max(30, (clientH - totalBlockH) / 2);

            if (pictureBoxaLogo != null)
            {
                pictureBoxaLogo.Location = new Point(rightCenterX - pictureBoxaLogo.Width / 2, topOffset);
            }

            int curY = topOffset + (pictureBoxaLogo != null ? pictureBoxaLogo.Height + 14 : 90);

            if (label1 != null)
            {
                label1.Location = new Point(rightCenterX - label1.Width / 2, curY);
                curY += label1.Height + 4;
            }

            if (label2 != null)
            {
                label2.Location = new Point(rightCenterX - label2.Width / 2, curY);
                curY += label2.Height + 18;
            }

            if (lblEmailAddress != null)
            {
                lblEmailAddress.Location = new Point(startX, curY);
                curY += lblEmailAddress.Height + 4;
            }

            if (pictureBox3 != null)
            {
                pictureBox3.Location = new Point(startX, curY);
            }
            if (txtEmailAddress != null)
            {
                txtEmailAddress.Location = new Point(inputX, curY);
                txtEmailAddress.Size = new Size(inputW, 26);
                curY += 32;
            }

            if (lblEmailAdresssViolation != null)
            {
                lblEmailAdresssViolation.Location = new Point(inputX, curY);
                curY += 18;
            }

            if (lblPassword != null)
            {
                lblPassword.Location = new Point(startX, curY);
                curY += lblPassword.Height + 4;
            }

            if (pictureBox4 != null)
            {
                pictureBox4.Location = new Point(startX, curY);
            }
            if (txtLoginPassword != null)
            {
                txtLoginPassword.Location = new Point(inputX, curY);
                txtLoginPassword.Size = new Size(inputW, 26);
                curY += 32;
            }

            if (chkLoginShow != null)
            {
                chkLoginShow.Location = new Point(inputX, curY);
            }
            if (linkForgotPassword != null)
            {
                linkForgotPassword.Location = new Point(startX + colW - linkForgotPassword.Width, curY);
                curY += 28;
            }

            if (lblLoginPasswordViolation != null)
            {
                lblLoginPasswordViolation.Location = new Point(inputX, curY);
                curY += 20;
            }

            if (btnLogIn != null)
            {
                btnLogIn.Location = new Point(rightCenterX - btnLogIn.Width / 2, curY);
                curY += btnLogIn.Height + 18;
            }

            if (panel1 != null)
            {
                panel1.Location = new Point(rightCenterX - panel1.Width / 2, curY);
            }
        }

        private void linkRegister2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Link to register form
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

        private void txtEmailAddress_TextChanged(object sender, EventArgs e)
        {
            string Email = txtEmailAddress.Text;
            bool EmailCheck = Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+(?:\.[^@\s]+)*$");
            //Checking if the email is valid 
            if (string.IsNullOrWhiteSpace(Email))
            {
                lblEmailAdresssViolation.Visible = false;
                //block the user from continuing with registration
                return;
            }


            if (!EmailCheck)
            {

                lblEmailAdresssViolation.Text = ("Please enter valid email address!");
                //Shows the warning sign if the user type the incorrect email without @ and .
                lblEmailAdresssViolation.Visible = true;
            }
            else
            {
                //Remove the warning sign if the user type the correct email with @ and .
                lblEmailAdresssViolation.Visible = false;
            }
        }


        private void txtLoginPassword_TextChanged(object sender, EventArgs e)
        {
            string Password = txtLoginPassword.Text;
            bool PasswordCheck = Regex.IsMatch(Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$");
            
            // 1. Check for missing character requirements
            bool hasUpper = Password.Any(char.IsUpper);
            bool hasNumber = Password.Any(char.IsDigit);
            bool hasSpecial = Password.Any(c => !char.IsLetterOrDigit(c));
            /*
            if (string.IsNullOrWhiteSpace(Password))
            {
                lblLength.Text = "";
            }
            // Does not meet the baseline character types OR is too short
            else if (!hasUpper || !hasNumber || !hasSpecial || Password.Length < 8)
            {
                lblLength.Text = "Weak password!";
                lblLength.ForeColor = Color.Red;
            }
            // Meets the requirements perfectly (Exactly 8 characters + all required types)
            else if (Password.Length == 8)
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



            if (string.IsNullOrWhiteSpace(Password))
            {
                lblLoginPasswordViolation.Visible = false;
                lblLoginPasswordViolation.Text = ("Password must be at least 8 characters long, contain an uppercase letter, a lowercase letter, and a number!");
                //block the user from continuing with registration
                return;
            }


            if (!PasswordCheck)
            {
                lblLoginPasswordViolation.Text = ("Password must be at least 8 characters long, contain an uppercase letter, a lowercase letter, and a number!");
                lblLoginPasswordViolation.Visible = true;
            }
            else
            {
                lblLoginPasswordViolation.Visible = false;
            }
        }

     
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            lblEmailAdresssViolation.Visible = false;
            lblLoginPasswordViolation.Visible = false;
            lblUserViolation.Visible = false;

            string enteredEmail = txtEmailAddress.Text.Trim();
            string enteredPassword = txtLoginPassword.Text.Trim();
            bool isValid = true;

            // 3. Email Validation
            if (string.IsNullOrWhiteSpace(enteredEmail))
            {
                lblEmailAdresssViolation.Text = "Please fill in your email!";
                lblEmailAdresssViolation.Visible = true;
                isValid = false;
            }
            else if (!Regex.IsMatch(enteredEmail, @"^[^@\s]+@[^@\s]+\.[^@\s]+(?:\.[^@\s]+)*$"))
            {
                lblEmailAdresssViolation.Text = "Please enter valid email address!";
                lblEmailAdresssViolation.Visible = true;
                isValid = true;
            }

            if (string.IsNullOrWhiteSpace(enteredPassword))
            {
                lblLoginPasswordViolation.Text = "Please fill in your password!";
                lblLoginPasswordViolation.Visible = true;
                isValid = false;
            }
            else if (!Regex.IsMatch(enteredPassword, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$"))
            {
                lblLoginPasswordViolation.Text = "Password must be at least 8 characters long, contain an uppercase letter, a lowercase letter, and a number!";
                lblLoginPasswordViolation.Visible = true;
                isValid = true;
            }
            else
            {
                lblLoginPasswordViolation.Visible = false;
            }


            // Stop execution if any of the above validations failed
            if (!isValid)
            {
                return;
            }


           

            bool valid = false;

            // Visitors only - the single admin is verified in frmAdminLogin
            // against the variables in AdminSession, not from a text file.
            string projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
            string filePath = Path.Combine(projectDirectory, "Text Files", "Visitor.txt");

            //Visitor Login
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Database file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string enteredPasswordHash = HashPassword(enteredPassword);
            string matchedFirstName = "";
            string matchedSurname = "";
            string matchedEmail = enteredEmail;
            string matchedMobile = "";

            // Read the file line by line and check for matching email and password 
            using (StreamReader reader = new StreamReader(filePath))
            {
                string myLine;

                while ((myLine = reader.ReadLine()) != null)
                {
                    string[] parts = myLine.Split('\t');


                    if (parts.Length >= 8)
                    {
                        string fileEmail = parts[2].Trim();
                        string filePasswordHash = parts[7].Trim();


                        if (fileEmail.Equals(enteredEmail, StringComparison.OrdinalIgnoreCase) && filePasswordHash == enteredPasswordHash)
                        {
                            valid = true;
                            matchedFirstName = parts[0].Trim();
                            matchedSurname = parts[1].Trim();
                            matchedEmail = fileEmail;
                            matchedMobile = parts[6].Trim();
                            break;
                        }
                    }
                }
            }
            if (valid)
            {
               
                txtEmailAddress.Clear();
                txtLoginPassword.Clear();

                lblEmailAdresssViolation.Visible = false;
                lblLoginPasswordViolation.Visible = false;
                AdminSession.Reset();

                // Ensure visitor exists in Data/users.txt with a persistent UserID for the Dashboard
                FileService.EnsureDataFolder();
                List<User> allUsers = FileService.GetAllUsers();
                User loggedInVisitor = allUsers.FirstOrDefault(u =>
                    u.Email.Equals(matchedEmail, StringComparison.OrdinalIgnoreCase));

                if (loggedInVisitor == null)
                {
                    loggedInVisitor = new User
                    {
                        UserID       = Guid.NewGuid().ToString(),
                        FirstName    = matchedFirstName,
                        LastName     = matchedSurname,
                        Email        = matchedEmail,
                        Phone        = matchedMobile,
                        Gender       = "Prefer not to say",
                        PasswordHash = PasswordHelper.HashNewPassword(enteredPassword),
                        Role         = "Visitor"
                    };
                    FileService.AddUser(loggedInVisitor);
                }
                else
                {
                    loggedInVisitor.FirstName    = matchedFirstName;
                    loggedInVisitor.LastName     = matchedSurname;
                    loggedInVisitor.Phone        = matchedMobile;
                    loggedInVisitor.PasswordHash = PasswordHelper.HashNewPassword(enteredPassword);
                    FileService.SaveAllUsers(allUsers);
                }

                //Link to VisitorDashboardForm
                VisitorDashboardForm attractionsForm = new VisitorDashboardForm(loggedInVisitor);
                attractionsForm.WindowState = this.WindowState;
                if (this.WindowState == FormWindowState.Normal)
                {
                    attractionsForm.StartPosition = FormStartPosition.Manual;
                    attractionsForm.Location = this.Location;
                    attractionsForm.Size = this.Size;
                }
                attractionsForm.FormClosed += (s, args) =>
                {
                    Welcome welcomeForm = new Welcome();
                    welcomeForm.WindowState = attractionsForm.WindowState;
                    if (attractionsForm.WindowState == FormWindowState.Normal)
                    {
                        welcomeForm.StartPosition = FormStartPosition.Manual;
                        welcomeForm.Location = attractionsForm.Location;
                        welcomeForm.Size = attractionsForm.Size;
                    }
                    welcomeForm.Show();
                };

                attractionsForm.Show();
                this.Hide();
            }
            else
            {
                txtEmailAddress.Clear();
                txtLoginPassword.Clear();
                lblEmailAdresssViolation.Text = "Invalid email or password. Please try again.";
                lblEmailAdresssViolation.Visible = true;
                lblLoginPasswordViolation.Text = "Invalid password or email. Please try again.";
                lblLoginPasswordViolation.Visible = true;

            }

        }


        // Hashing the password using SHA256 algorithm
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

        private void chkLoginShow_CheckedChanged(object sender, EventArgs e)
        {
            //Showing and hiding password 
            if (chkLoginShow.Checked)
            {
                txtLoginPassword.PasswordChar = '\0';
            }
            else
            {
                txtLoginPassword.PasswordChar = '*';
            }
        }


        //Link to go back to home page
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Link to welcome page
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

        //Link to go to forgot password page
        private void linkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Link to forgot password page
            frmForgot_Password nextform = new frmForgot_Password();
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
