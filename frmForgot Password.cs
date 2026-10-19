using PROJECTT.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJECTT
{
    public partial class frmForgot_Password : Form
    {  // This is the code for the forgot password form, where the user can enter their email address to receive a reset code via email. The user can then enter the code to verify their identity and reset their password.
        string randomCode;
        public static String to;

        public frmForgot_Password()
        {
            InitializeComponent();
            // Load embedded resources at runtime (keeps Designer CodeDomSerializer 100% error-free)
            try
            {
                this.BackgroundImage = global::PROJECTT.Properties.Resources.bg_forgot_reset;
            }
            catch { }
            SafariThemeEngine.ApplyAuthFormTheme(this, "ACCOUNT RECOVERY • OTP VERIFICATION", SafariThemeEngine.HorizonCyan);
        }

        private void txtForgotEmail_TextChanged(object sender, EventArgs e)
        {   // This method is called when the user types in the email address textbox. It checks if the email address is valid and enables or disables the submit button accordingly.
            string ForgotEmail = txtForgotEmail.Text.Trim();
            if (string.IsNullOrWhiteSpace(txtForgotEmail.Text))
            {
                lblForgotEmailViolation.Visible = false;
                btnSubmit.Enabled = false;
            }
            else if (!Regex.IsMatch(ForgotEmail, @"^[^@\s]+@[^@\s]+\.[^@\s]+(?:\.[^@\s]+)*$"))
            {
                lblForgotEmailViolation.Text = "Please enter a valid email address.";
                lblForgotEmailViolation.Visible = true;
                btnSubmit.Enabled = false;
            }
            else
            {
                lblForgotEmailViolation.Visible = false;
                btnSubmit.Enabled = true;
            }
        }

        private void txtOTP_TextChanged(object sender, EventArgs e)
        {   // This method is called when the user types in the OTP textbox. It checks if the OTP is valid and enables or disables the submit button accordingly.
            string OTP = txtOTP.Text;
            if (Regex.IsMatch(OTP, @"^\d{6}$"))
            {
                lblOTPViolation.Visible = false;
                btnSubmit.Enabled = true;

            }
            else
            {
                lblOTPViolation.Text = "Please enter a valid 6-digit OTP.";
                lblOTPViolation.Visible = true;
                btnSubmit.Enabled = false;
            }
            // Check if the OTP is empty or invalid
            if (string.IsNullOrWhiteSpace(OTP))
            {
                // Handle empty OTP
                lblOTPViolation.Text = "Please enter the OTP.";
                lblOTPViolation.Visible = false;
                btnSubmit.Enabled = false;
            }
            // Check if the OTP is invalid
            if (!string.IsNullOrWhiteSpace(OTP) && OTP != randomCode)
            {
                // Handle invalid OTP
                lblOTPViolation.Text = "Invalid OTP. Please try again.";
                lblOTPViolation.Visible = true;
                btnSubmit.Enabled = false;
            }
            else
            {
                btnSubmit.Enabled = true;
                lblOTPViolation.Visible = false;

            }
        }

        // This method is called when the user clicks the "Send OTP" button. It generates a random 6-digit code, sends it to the user's email address, and displays a message box to inform the user that the code has been sent.
        private void btnSendOTP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtForgotEmail.Text)|| !Regex.IsMatch(txtForgotEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+(?:\.[^@\s]+)*$"))
            {
                lblForgotEmailViolation.Text = "Please enter a valid email address.";
                lblForgotEmailViolation.Visible = true;
                return;
            }
           
            string from, pass, messageBody;
            string projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
            string filepath = Path.Combine(projectDirectory, "Text Files", "Visitor.txt");
            //Reading and checking if the phone number and email already exist in the system or they are not available 
            StreamReader Read = new StreamReader(filepath);

            string line;
            string[] lineArray = new string[5];
            string ForgotEmail = txtForgotEmail.Text.Trim();
            bool emailExists = false;
            //Looping around cheking line to line in the 2 and 3 index 
            using (Read)
            {
                line = Read.ReadLine();
                while (line != null)
                {
                    //2 index
                    lineArray = line.Split('\t');
                    if (lineArray.Length >= 4)
                    {
                        //checking if the email entered is already registered or not
                        if (ForgotEmail.Equals(lineArray[2].Trim(), StringComparison.OrdinalIgnoreCase))
                        {
                            //but if it not registered or you changed it when it showed a warning,it won't show a warning 
                            emailExists = true;
                            break;

                        }
                       
                        

                    }
                    line = Read.ReadLine();

                }

            }
            //If the email does not exist in the system, show a warning message and return
            if (!emailExists)
            {
                lblForgotEmailViolation.Text = "Email not found. Please try again.";
                lblForgotEmailViolation.Visible = true;
                return;
            }
           
            try
            {

                    // If the email exists, send the OTP to the user's email address
                    lblForgotEmailViolation.Visible = false;
                    Random rand = new Random();
                    randomCode = rand.Next(100000, 999999).ToString();
                    MailMessage message = new MailMessage();
                    to = ForgotEmail;
                    from = "lungelobhengu987@gmail.com";
                    pass = "ghinehpfsuxchihv";
                    messageBody = "Your reset code is " + randomCode;
                    message.To.Add(to);
                    message.Body = messageBody;
                    message.From = new MailAddress(from);
                    message.Subject = "Password Reseting Code";
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.EnableSsl = true;
                    smtp.Port = 587;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new System.Net.NetworkCredential(from, pass);
                    smtp.Send(message);

                    MessageBox.Show("The code has been sent to your email, please check and verify", "Code Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);



                
            }
            // If there is an error sending the email, show an error message
            catch (Exception ex)
            {
                MessageBox.Show("Error sending email: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // This method is called when the user clicks the "Verify OTP" button. It checks if the OTP entered by the user matches the code sent to their email address. If it does, it opens the reset password form. If it doesn't, it displays an error message.
        private void btnVerifyOTP_Click(object sender, EventArgs e)
        {
            string OTP = txtOTP.Text;
            if (!Regex.IsMatch(OTP, @"^\d{6}$"))
            {
                lblOTPViolation.Text = "Invalid OTP. Please enter a 6-digit code.";
                lblOTPViolation.Visible = true;
                btnSubmit.Enabled = false;
                return;

            }
            string ForgotEmail= txtForgotEmail.Text.Trim();
            
            if (OTP == randomCode)
            {
               
                btnVerifyOTP.Enabled = true;

                //Link to forgot password
                frmResetPassword resetPasswordForm = new frmResetPassword(ForgotEmail);
                // Set the WindowState of the new form to match the current form's WindowState
                resetPasswordForm.WindowState = this.WindowState;
                // Match the starting position if its retuened to normal
                resetPasswordForm.StartPosition = FormStartPosition.Manual;
                resetPasswordForm.Location = this.Location;
                resetPasswordForm.Size = this.Size;

                resetPasswordForm.Show();
                this.Hide();
            }
            else
            {
                lblOTPViolation.Text = "Invalid OTP. Please try again.";
            }
        }

        // This method is called when the user clicks the "Back to Login" link. It opens the login form and hides the forgot password form.
        private void linkBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Link to login
            frmLogin nextform = new frmLogin();
            // Set the WindowState of the new form to match the current form's WindowState
            nextform.WindowState = this.WindowState;
            // Match the starting position if its retuened to normal
            nextform.StartPosition = FormStartPosition.Manual;
            nextform.Location = this.Location;
            nextform.Size = this.Size;

            nextform.Show();

            this.Hide();
        }
}   }