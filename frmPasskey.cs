using System.Drawing;
using PROJECTT.Services;
using System;
using System.Windows.Forms;

namespace PROJECTT
{
    /// <summary>
    /// Small pop-up box that asks for the admin passkey.
    /// Returns DialogResult.OK only when the correct passkey was typed.
    /// </summary>
    public partial class frmPasskey : Form
    {
        private int attemptsUsed = 0;

        public frmPasskey()
        {
            InitializeComponent();
            SafariThemeEngine.ApplyAuthFormTheme(this, "6-DIGIT ADMIN PASSKEY GATE", SafariThemeEngine.RoyalViolet);

            // Only allow as many characters as the passkey actually has.
            txtPasskey.MaxLength = AdminSession.PasskeyLength;

            lblPrompt.Text = "Enter the " + AdminSession.PasskeyLength +
                "-digit admin passkey to continue:";
        }

        // Digits only - block letters, spaces and symbols as they are typed.
        private void txtPasskey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Hide the warning again as soon as the user starts retyping.
        private void txtPasskey_TextChanged(object sender, EventArgs e)
        {
            lblPasskeyViolation.Visible = false;
        }

        private void chkShowPasskey_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPasskey.Checked)
            {
                txtPasskey.PasswordChar = '\0';
            }
            else
            {
                txtPasskey.PasswordChar = '*';
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string entered = txtPasskey.Text.Trim();

            if (string.IsNullOrWhiteSpace(entered))
            {
                ShowWarning("Please enter the admin passkey.");
                return;
            }

            if (entered.Length != AdminSession.PasskeyLength)
            {
                ShowWarning("The passkey must be exactly " +
                    AdminSession.PasskeyLength + " digits.");
                return;
            }

            if (AdminSession.IsPasskeyCorrect(entered))
            {
                AdminSession.PasskeyVerified = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            // Wrong passkey
            attemptsUsed++;
            txtPasskey.Clear();

            int attemptsLeft = AdminSession.MaxPasskeyAttempts - attemptsUsed;

            if (attemptsLeft <= 0)
            {
                MessageBox.Show("Incorrect passkey entered " +
                    AdminSession.MaxPasskeyAttempts + " times. Admin access denied.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.DialogResult = DialogResult.Abort;
                this.Close();
                return;
            }

            ShowWarning("Incorrect passkey. You have " + attemptsLeft +
                " attempt(s) left.");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ShowWarning(string message)
        {
            lblPasskeyViolation.Text = message;
            lblPasskeyViolation.Visible = true;
            txtPasskey.Focus();
        }
    }
}
