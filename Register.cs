using PROJECTT.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;



namespace PROJECTT
{
    public partial class frmRegister : Form
    {
        public class Country
        {
            public string CountryName { get; set; }
            public string Code { get; set; }
            public int MaxDigits { get; set; }


            public override string ToString() => CountryName;

        }
        private List<Country> southAfricanList;
        private List<Country> internationalList;
        private bool isFormatting = false;

        public frmRegister()
        {
            InitializeComponent();
            // Load embedded resources at runtime (keeps Designer CodeDomSerializer 100% error-free)
            try
            {
                this.panelPhotoBlueHorizon.BackgroundImage = global::PROJECTT.Properties.Resources.blue_horizon_610x703;
            }
            catch { }
            SafariThemeEngine.ApplyAuthFormTheme(this, "SAFARI EXPLORER REGISTRATION", SafariThemeEngine.SunsetAmber);
            InitializeCountryData();
            SetupEventHandlers();
            txtPassword.TextChanged += txtPassword_TextChanged;
            txtMobileNumber.Enabled = false; // Disable the mobile number textbox initially

            this.AutoScroll = true;
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

            int leftW = Math.Max(360, Math.Min(560, (int)(clientW * 0.38)));
            if (panelPhotoBlueHorizon != null)
            {
                panelPhotoBlueHorizon.Location = new Point(0, 0);
                panelPhotoBlueHorizon.Size = new Size(leftW, Math.Max(clientH, 880));
            }

            if (linkBack != null)
            {
                linkBack.Location = new Point(leftW + 20, 16);
            }

            int rightAreaW = clientW - leftW;
            int rightCenterX = leftW + rightAreaW / 2;

            // Width of form inputs
            int colW = Math.Min(560, Math.Max(400, rightAreaW - 60));
            int startX = rightCenterX - colW / 2;
            int halfW = (colW - 20) / 2;

            int curY = Math.Max(40, (clientH - 740) / 3);

            if (lblNewAccount != null)
            {
                lblNewAccount.Location = new Point(startX, curY);
                curY += lblNewAccount.Height + 4;
            }

            if (lblAlready != null)
            {
                lblAlready.Location = new Point(startX, curY);
                if (linkLogIn2 != null)
                    linkLogIn2.Location = new Point(lblAlready.Right + 8, curY);
                curY += lblAlready.Height + 14;
            }

            // Names row
            if (lblFirstName != null) lblFirstName.Location = new Point(startX, curY);
            if (lblSurname != null)   lblSurname.Location   = new Point(startX + halfW + 20, curY);
            curY += 24;

            if (txtFirstName != null)
            {
                txtFirstName.Location = new Point(startX, curY);
                txtFirstName.Size = new Size(halfW, 28);
            }
            if (txtSurname != null)
            {
                txtSurname.Location = new Point(startX + halfW + 20, curY);
                txtSurname.Size = new Size(halfW, 28);
            }
            curY += 34;

            if (lblNameViolation != null)    lblNameViolation.Location    = new Point(startX, curY);
            if (lblSurnameViolation != null) lblSurnameViolation.Location = new Point(startX + halfW + 20, curY);
            curY += 16;

            // Email row
            if (lblName != null) lblName.Location = new Point(startX, curY);
            curY += 24;
            if (txtEmail != null)
            {
                txtEmail.Location = new Point(startX, curY);
                txtEmail.Size = new Size(colW, 28);
            }
            curY += 34;
            if (lblEmailViolation != null) lblEmailViolation.Location = new Point(startX, curY);
            if (lblEmailAvailable != null) lblEmailAvailable.Location = new Point(startX, curY);
            curY += 16;

            // Country selection row
            if (lblChoose != null) lblChoose.Location = new Point(startX, curY);
            if (radSA != null)     radSA.Location     = new Point(startX + 180, curY);
            if (radInt != null)    radInt.Location    = new Point(startX + 310, curY);
            curY += 26;

            if (lblCountry != null) lblCountry.Location = new Point(startX, curY);
            if (lblCity != null)    lblCity.Location    = new Point(startX + halfW + 20, curY);
            curY += 24;

            if (cmbCountry != null)
            {
                cmbCountry.Location = new Point(startX, curY);
                cmbCountry.Size = new Size(halfW, 28);
            }
            if (txtCity != null)
            {
                txtCity.Location = new Point(startX + halfW + 20, curY);
                txtCity.Size = new Size(halfW, 28);
            }
            curY += 34;

            if (lblCountryViolation != null) lblCountryViolation.Location = new Point(startX, curY);
            if (lblCityViolation != null)    lblCityViolation.Location    = new Point(startX + halfW + 20, curY);
            curY += 16;

            // Mobile number row
            if (lblMobileNumber != null) lblMobileNumber.Location = new Point(startX, curY);
            curY += 24;
            int codeW = 68;
            if (lblCountryCode != null)
            {
                lblCountryCode.Location = new Point(startX, curY + 4);
                lblCountryCode.Size = new Size(codeW, 24);
            }
            if (txtMobileNumber != null)
            {
                txtMobileNumber.Location = new Point(startX + codeW + 4, curY);
                txtMobileNumber.Size = new Size(colW - codeW - 4, 28);
            }
            curY += 34;
            if (lblMobileNumberViolation != null) lblMobileNumberViolation.Location = new Point(startX, curY);
            curY += 16;

            // Password row
            if (lblPassword != null) lblPassword.Location = new Point(startX, curY);
            if (chkShow != null)     chkShow.Location     = new Point(startX + colW - chkShow.Width, curY);
            curY += 24;
            if (txtPassword != null)
            {
                txtPassword.Location = new Point(startX, curY);
                txtPassword.Size = new Size(colW, 28);
            }
            curY += 34;
            if (lblPasswordViolation != null)  lblPasswordViolation.Location  = new Point(startX, curY);
            if (lblPasswordViolation1 != null) lblPasswordViolation1.Location = new Point(startX, curY);
            if (lblLength != null)             lblLength.Location             = new Point(startX + colW - 60, curY);
            curY += 16;

            // Confirm password row
            if (lblConfirmPassword != null) lblConfirmPassword.Location = new Point(startX, curY);
            curY += 24;
            if (txtConfirmPassword != null)
            {
                txtConfirmPassword.Location = new Point(startX, curY);
                txtConfirmPassword.Size = new Size(colW, 28);
            }
            curY += 34;
            if (lblConfirmPasswordViolation != null) lblConfirmPasswordViolation.Location = new Point(startX, curY);
            curY += 16;

            // Terms row
            if (chkTerms != null)
            {
                chkTerms.Location = new Point(startX, curY);
                if (linkTerms != null) linkTerms.Location = new Point(chkTerms.Right + 4, curY + 2);
            }
            curY += 28;
            if (lblTermsViolation != null) lblTermsViolation.Location = new Point(startX, curY);
            curY += 14;

            // Register button
            if (btnRegister != null)
            {
                btnRegister.Location = new Point(startX, curY);
                btnRegister.Size = new Size(colW, 46);
            }
        }

        private void InitializeCountryData()
        {
            southAfricanList = new List<Country>
            {
                new Country { CountryName = "South Africa", Code = "+27", MaxDigits = 9}
            };
            internationalList = new List<Country>
            {
                            // A
    new Country { CountryName = "Afghanistan", Code = "+93", MaxDigits = 9 },
    new Country { CountryName = "Albania", Code = "+355", MaxDigits = 9 },
    new Country { CountryName = "Algeria", Code = "+213", MaxDigits = 9 },
    new Country { CountryName = "American Samoa", Code = "+1", MaxDigits = 10 },
    new Country { CountryName = "Andorra", Code = "+376", MaxDigits = 9 },
    new Country { CountryName = "Angola", Code = "+244", MaxDigits = 9 },
    new Country { CountryName = "Anguilla", Code = "+1", MaxDigits = 10 },
    new Country { CountryName = "Antigua and Barbuda", Code = "+1", MaxDigits = 10 },
    new Country { CountryName = "Argentina", Code = "+54", MaxDigits = 11 },
    new Country { CountryName = "Armenia", Code = "+374", MaxDigits = 8 },
    new Country { CountryName = "Aruba", Code = "+297", MaxDigits = 7 },
    new Country { CountryName = "Australia", Code = "+61", MaxDigits = 9 },
    new Country { CountryName = "Austria", Code = "+43", MaxDigits = 13 },
    new Country { CountryName = "Azerbaijan", Code = "+994", MaxDigits = 9 },

    // B
    new Country { CountryName = "Bahamas", Code = "+1", MaxDigits = 10 },
    new Country { CountryName = "Bahrain", Code = "+973", MaxDigits = 8 },
    new Country { CountryName = "Bangladesh", Code = "+880", MaxDigits = 10 },
    new Country { CountryName = "Barbados", Code = "+1", MaxDigits = 10 },
    new Country { CountryName = "Belarus", Code = "+375", MaxDigits = 9 },
    new Country { CountryName = "Belgium", Code = "+32", MaxDigits = 9 },
    new Country { CountryName = "Belize", Code = "+501", MaxDigits = 7 },
    new Country { CountryName = "Benin", Code = "+229", MaxDigits = 8 },
    new Country { CountryName = "Bermuda", Code = "+1", MaxDigits = 10 },
    new Country { CountryName = "Bhutan", Code = "+975", MaxDigits = 8 },
    new Country { CountryName = "Bolivia", Code = "+591", MaxDigits = 8 },
    new Country { CountryName = "Bosnia and Herzegovina", Code = "+387", MaxDigits = 8 },
    new Country { CountryName = "Botswana", Code = "+267", MaxDigits = 8 },
    new Country { CountryName = "Brazil", Code = "+55", MaxDigits = 11 },
    new Country { CountryName = "British Virgin Islands", Code = "+1", MaxDigits = 10 },
    new Country { CountryName = "Brunei", Code = "+673", MaxDigits = 7 },
    new Country { CountryName = "Bulgaria", Code = "+359", MaxDigits = 9 },
    new Country { CountryName = "Burkina Faso", Code = "+226", MaxDigits = 8 },
    new Country { CountryName = "Burundi", Code = "+257", MaxDigits = 8 },

    // C
    new Country { CountryName = "Cabo Verde", Code = "+238", MaxDigits = 7 },
    new Country { CountryName = "Cambodia", Code = "+855", MaxDigits = 9 },
    new Country { CountryName = "Cameroon", Code = "+237", MaxDigits = 9 },
    new Country { CountryName = "Canada", Code = "+1", MaxDigits = 10 },
    new Country { CountryName = "Cayman Islands", Code = "+1", MaxDigits = 10 },
    new Country { CountryName = "Central African Republic", Code = "+236", MaxDigits = 8 },
    new Country { CountryName = "Chad", Code = "+235", MaxDigits = 8 },
    new Country { CountryName = "Chile", Code = "+56", MaxDigits = 9 },
    new Country { CountryName = "China", Code = "+86", MaxDigits = 12 },
    new Country { CountryName = "Colombia", Code = "+57", MaxDigits = 10 },
    new Country { CountryName = "Comoros", Code = "+269", MaxDigits = 7 },
    new Country { CountryName = "Congo (ROC)", Code = "+242", MaxDigits = 9 },
    new Country { CountryName = "Congo (DRC)", Code = "+243", MaxDigits = 9 },
    new Country { CountryName = "Cook Islands", Code = "+682", MaxDigits = 5 },
    new Country { CountryName = "Costa Rica", Code = "+506", MaxDigits = 8 },
    new Country { CountryName = "Côte d'Ivoire", Code = "+225", MaxDigits = 10 },
    new Country { CountryName = "Croatia", Code = "+385", MaxDigits = 9 },
    new Country { CountryName = "Cuba", Code = "+53", MaxDigits = 8 },
    new Country { CountryName = "Curaçao", Code = "+599", MaxDigits = 8 },
    new Country { CountryName = "Cyprus", Code = "+357", MaxDigits = 8 },
    new Country { CountryName = "Czechia", Code = "+420", MaxDigits = 12 },

    // D
    new Country { CountryName = "Denmark", Code = "+45", MaxDigits = 8 },
    new Country { CountryName = "Djibouti", Code = "+253", MaxDigits = 8 },
    new Country { CountryName = "Dominica", Code = "+1", MaxDigits = 10 },
    new Country { CountryName = "Dominican Republic", Code = "+1", MaxDigits = 10 },

    // E
    new Country { CountryName = "Ecuador", Code = "+593", MaxDigits = 9 },
    new Country { CountryName = "Egypt", Code = "+20", MaxDigits = 10 },
    new Country { CountryName = "El Salvador", Code = "+503", MaxDigits = 8 },
    new Country { CountryName = "Equatorial Guinea", Code = "+240", MaxDigits = 9 },
    new Country { CountryName = "Eritrea", Code = "+291", MaxDigits = 7 },
    new Country { CountryName = "Estonia", Code = "+372", MaxDigits = 10 },
    new Country { CountryName = "Eswatini", Code = "+268", MaxDigits = 8 },
    new Country { CountryName = "Ethiopia", Code = "+251", MaxDigits = 9 },

    // F
    new Country { CountryName = "Falkland Islands", Code = "+500", MaxDigits = 5 },
    new Country { CountryName = "Faroe Islands", Code = "+298", MaxDigits = 6 },
    new Country { CountryName = "Fiji", Code = "+679", MaxDigits = 7 },
    new Country { CountryName = "Finland", Code = "+358", MaxDigits = 10 },
    new Country { CountryName = "France", Code = "+33", MaxDigits = 9 },
    new Country { CountryName = "French Guiana", Code = "+594", MaxDigits = 9 },
    new Country { CountryName = "French Polynesia", Code = "+689", MaxDigits = 6 },

    // G
    new Country { CountryName = "Gabon", Code = "+241", MaxDigits = 8 },
    new Country { CountryName = "Gambia", Code = "+220", MaxDigits = 7 },
    new Country { CountryName = "Georgia", Code = "+995", MaxDigits = 9 },
    new Country { CountryName = "Germany", Code = "+49", MaxDigits = 13 },
    new Country { CountryName = "Ghana", Code = "+233", MaxDigits = 9 },
    new Country { CountryName = "Gibraltar", Code = "+350", MaxDigits = 8 },
    new Country { CountryName = "Greece", Code = "+30", MaxDigits = 10 },
    new Country { CountryName = "Greenland", Code = "+299", MaxDigits = 6 },
    new Country { CountryName = "Grenada", Code = "+1", MaxDigits = 10 },
    new Country { CountryName = "Guadeloupe", Code = "+590", MaxDigits = 9 },
    new Country { CountryName = "Guam", Code = "+1", MaxDigits = 10 },
    new Country { CountryName = "Guatemala", Code = "+502", MaxDigits = 8 },
    new Country { CountryName = "Guinea", Code = "+224", MaxDigits = 8 },
    new Country { CountryName = "Guinea-Bissau", Code = "+245", MaxDigits = 9 },
    new Country { CountryName = "Guyana", Code = "+592", MaxDigits = 7 },

    // H
    new Country { CountryName = "Haiti", Code = "+509", MaxDigits = 8 },
    new Country { CountryName = "Honduras", Code = "+504", MaxDigits = 8 },
    new Country { CountryName = "Hong Kong", Code = "+852", MaxDigits = 9 },
    new Country { CountryName = "Hungary", Code = "+36", MaxDigits = 9 },

    // I
    new Country { CountryName = "Iceland", Code = "+354", MaxDigits = 9 },
    new Country { CountryName = "India", Code = "+91", MaxDigits = 10 },
    new Country { CountryName = "Indonesia", Code = "+62", MaxDigits = 11 },
    new Country { CountryName = "Iran", Code = "+98", MaxDigits = 10 },
    new Country { CountryName = "Iraq", Code = "+964", MaxDigits = 10 },
    new Country { CountryName = "Ireland", Code = "+353", MaxDigits = 9 },
    new Country { CountryName = "Israel", Code = "+972", MaxDigits = 9 },
    new Country { CountryName = "Italy", Code = "+39", MaxDigits = 11 },

    // J
    new Country { CountryName = "Jamaica", Code = "+1", MaxDigits = 10 },
    new Country { CountryName = "Japan", Code = "+81", MaxDigits = 10 },
    new Country { CountryName = "Jordan", Code = "+962", MaxDigits = 9 },

    // K
    new Country { CountryName = "Kazakhstan", Code = "+7", MaxDigits = 10 },
    new Country { CountryName = "Kenya", Code = "+254", MaxDigits = 9 },
    new Country { CountryName = "Kiribati", Code = "+686", MaxDigits = 8 },
    new Country { CountryName = "Kosovo", Code = "+383", MaxDigits = 8 },
    new Country { CountryName = "Kuwait", Code = "+965", MaxDigits = 8 },
    new Country { CountryName = "Kyrgyzstan", Code = "+996", MaxDigits = 9 },

    // L
    new Country { CountryName = "Laos", Code = "+856", MaxDigits = 10 },
    new Country { CountryName = "Latvia", Code = "+371", MaxDigits = 8 },
    new Country { CountryName = "Lebanon", Code = "+961", MaxDigits = 8 },
    new Country { CountryName = "Lesotho", Code = "+266", MaxDigits = 8 },
    new Country { CountryName = "Liberia", Code = "+231", MaxDigits = 8 },
    new Country { CountryName = "Libya", Code = "+218", MaxDigits = 9 },
    new Country { CountryName = "Liechtenstein", Code = "+423", MaxDigits = 9 },
    new Country { CountryName = "Lithuania", Code = "+370", MaxDigits = 8 },
    new Country { CountryName = "Luxembourg", Code = "+352", MaxDigits = 9 },

    // M
    new Country { CountryName = "Macau", Code = "+853", MaxDigits = 8 },
    new Country { CountryName = "Madagascar", Code = "+261", MaxDigits = 9 },
    new Country { CountryName = "Malawi", Code = "+265", MaxDigits = 9 },
    new Country { CountryName = "Malaysia", Code = "+60", MaxDigits = 10 },
    new Country { CountryName = "Maldives", Code = "+960", MaxDigits = 7 },
    new Country { CountryName = "Mali", Code = "+223", MaxDigits = 8 },
    new Country { CountryName = "Malta", Code = "+356", MaxDigits = 8 },
    new Country { CountryName = "Marshall Islands", Code = "+692", MaxDigits = 7 },
    new Country { CountryName = "Mauritania", Code = "+222", MaxDigits = 8 },
    new Country { CountryName = "Mauritius", Code = "+230", MaxDigits = 8 },

                   new Country { CountryName = "Mexico", Code = "+52", MaxDigits = 10 },
new Country { CountryName = "Micronesia", Code = "+691", MaxDigits = 7 },
new Country { CountryName = "Moldova", Code = "+373", MaxDigits = 8 },
new Country { CountryName = "Monaco", Code = "+377", MaxDigits = 9 },
new Country { CountryName = "Mongolia", Code = "+976", MaxDigits = 8 },
new Country { CountryName = "Montenegro", Code = "+382", MaxDigits = 8 },
new Country { CountryName = "Montserrat", Code = "+1", MaxDigits = 10 },
new Country { CountryName = "Morocco", Code = "+212", MaxDigits = 9 },
new Country { CountryName = "Mozambique", Code = "+258", MaxDigits = 9 },
new Country { CountryName = "Myanmar", Code = "+95", MaxDigits = 10 },
// N
new Country { CountryName = "Namibia", Code = "+264", MaxDigits = 9 },
new Country { CountryName = "Nauru", Code = "+674", MaxDigits = 7 },
new Country { CountryName = "Nepal", Code = "+977", MaxDigits = 10 },
new Country { CountryName = "Netherlands", Code = "+31", MaxDigits = 9 },
new Country { CountryName = "New Caledonia", Code = "+687", MaxDigits = 6 },
new Country { CountryName = "New Zealand", Code = "+64", MaxDigits = 10 },
new Country { CountryName = "Nicaragua", Code = "+505", MaxDigits = 8 },
new Country { CountryName = "Niger", Code = "+227", MaxDigits = 8 },
new Country { CountryName = "Nigeria", Code = "+234", MaxDigits = 10 },
new Country { CountryName = "Niue", Code = "+683", MaxDigits = 4 },
new Country { CountryName = "North Korea", Code = "+850", MaxDigits = 10 },
new Country { CountryName = "North Macedonia", Code = "+389", MaxDigits = 8 },
new Country { CountryName = "Northern Mariana Islands", Code = "+1", MaxDigits = 10 },
new Country { CountryName = "Norway", Code = "+47", MaxDigits = 8 },
// O
new Country { CountryName = "Oman", Code = "+968", MaxDigits = 8 },
// P
new Country { CountryName = "Pakistan", Code = "+92", MaxDigits = 10 },
new Country { CountryName = "Palau", Code = "+680", MaxDigits = 7 },
new Country { CountryName = "Palestine", Code = "+970", MaxDigits = 9 },
new Country { CountryName = "Panama", Code = "+507", MaxDigits = 8 },
new Country { CountryName = "Papua New Guinea", Code = "+675", MaxDigits = 11 },
new Country { CountryName = "Paraguay", Code = "+595", MaxDigits = 9 },
new Country { CountryName = "Peru", Code = "+51", MaxDigits = 9 },
new Country { CountryName = "Philippines", Code = "+63", MaxDigits = 10 },
new Country { CountryName = "Poland", Code = "+48", MaxDigits = 9 },
new Country { CountryName = "Portugal", Code = "+351", MaxDigits = 9 },
new Country { CountryName = "Puerto Rico", Code = "+1", MaxDigits = 10 },
// Q
new Country { CountryName = "Qatar", Code = "+974", MaxDigits = 8 },
// R
new Country { CountryName = "Réunion", Code = "+262", MaxDigits = 9 },
new Country { CountryName = "Romania", Code = "+40", MaxDigits = 9 },
new Country { CountryName = "Russia", Code = "+7", MaxDigits = 10 },
new Country { CountryName = "Rwanda", Code = "+250", MaxDigits = 9 },
// S
new Country { CountryName = "Saint Kitts and Nevis", Code = "+1", MaxDigits = 10 },
new Country { CountryName = "Saint Lucia", Code = "+1", MaxDigits = 10 },
new Country { CountryName = "Saint Vincent and the Grenadines", Code = "+1", MaxDigits = 10 },
new Country { CountryName = "Samoa", Code = "+685", MaxDigits = 7 },
new Country { CountryName = "San Marino", Code = "+378", MaxDigits = 10 },
new Country { CountryName = "São Tomé and Príncipe", Code = "+239", MaxDigits = 7 },
new Country { CountryName = "Saudi Arabia", Code = "+966", MaxDigits = 9 },
new Country { CountryName = "Senegal", Code = "+221", MaxDigits = 9 },
new Country { CountryName = "Serbia", Code = "+381", MaxDigits = 12 },
new Country { CountryName = "Seychelles", Code = "+248", MaxDigits = 7 },
new Country { CountryName = "Sierra Leone", Code = "+232", MaxDigits = 8 },
new Country { CountryName = "Singapore", Code = "+65", MaxDigits = 8 },
new Country { CountryName = "Sint Maarten", Code = "+1", MaxDigits = 10 },
new Country { CountryName = "Slovakia", Code = "+421", MaxDigits = 9 },
new Country { CountryName = "Slovenia", Code = "+386", MaxDigits = 8 },
new Country { CountryName = "Solomon Islands", Code = "+677", MaxDigits = 7 },
new Country { CountryName = "Somalia", Code = "+252", MaxDigits = 8 },
new Country { CountryName = "South Korea", Code = "+82", MaxDigits = 11 },
new Country { CountryName = "South Sudan", Code = "+211", MaxDigits = 9 },
new Country { CountryName = "Spain", Code = "+34", MaxDigits = 9 },
new Country { CountryName = "Sri Lanka", Code = "+94", MaxDigits = 9 },
new Country { CountryName = "Sudan", Code = "+249", MaxDigits = 9 },
new Country { CountryName = "Suriname", Code = "+597", MaxDigits = 7 },
new Country { CountryName = "Sweden", Code = "+46", MaxDigits = 13 },
new Country { CountryName = "Switzerland", Code = "+41", MaxDigits = 12 },
new Country { CountryName = "Syria", Code = "+963", MaxDigits = 9 },
// T
new Country { CountryName = "Taiwan", Code = "+886", MaxDigits = 9 },
new Country { CountryName = "Tajikistan", Code = "+992", MaxDigits = 9 },
new Country { CountryName = "Tanzania", Code = "+255", MaxDigits = 9 },
new Country { CountryName = "Thailand", Code = "+66", MaxDigits = 9 },
new Country { CountryName = "Timor-Leste", Code = "+670", MaxDigits = 8 },
new Country { CountryName = "Togo", Code = "+228", MaxDigits = 8 },
new Country { CountryName = "Tokelau", Code = "+690", MaxDigits = 4 },
new Country { CountryName = "Tonga", Code = "+676", MaxDigits = 7 },
new Country { CountryName = "Trinidad and Tobago", Code = "+1", MaxDigits = 10 },
new Country { CountryName = "Tunisia", Code = "+216", MaxDigits = 8 },
new Country { CountryName = "Turkey", Code = "+90", MaxDigits = 10 },
new Country { CountryName = "Turkmenistan", Code = "+993", MaxDigits = 8 },
new Country { CountryName = "Turks and Caicos Islands", Code = "+1", MaxDigits = 10 },
new Country { CountryName = "Tuvalu", Code = "+688", MaxDigits = 6 },
// U
new Country { CountryName = "Uganda", Code = "+256", MaxDigits = 9 },
new Country { CountryName = "Ukraine", Code = "+380", MaxDigits = 9 },
new Country { CountryName = "United Arab Emirates", Code = "+971", MaxDigits = 9 },
new Country { CountryName = "United Kingdom", Code = "+44", MaxDigits = 10 },
new Country { CountryName = "United States", Code = "+1", MaxDigits = 10 },
new Country { CountryName = "Uruguay", Code = "+598", MaxDigits = 8 },
new Country { CountryName = "Uzbekistan", Code = "+998", MaxDigits = 9 },
// V
new Country { CountryName = "Vanuatu", Code = "+678", MaxDigits = 7 },
new Country { CountryName = "Vatican City", Code = "+39", MaxDigits = 11 },
new Country { CountryName = "Venezuela", Code = "+58", MaxDigits = 10 },
new Country { CountryName = "Vietnam", Code = "+84", MaxDigits = 10 },
new Country { CountryName = "Virgin Islands (U.S.)", Code = "+1", MaxDigits = 10 },
// W & Y & Z
new Country { CountryName = "Wallis and Futuna", Code = "+681", MaxDigits = 6 },
new Country { CountryName = "Yemen", Code = "+967", MaxDigits = 9 },
new Country { CountryName = "Zambia", Code = "+260", MaxDigits = 9 },
new Country { CountryName = "Zimbabwe", Code = "+263", MaxDigits = 9 }





            };
            internationalList = internationalList.OrderBy(c => c.CountryName).ToList();


        }

        private void ResetFormToBlankState()
        {
            // 1. Ensure radio buttons are physically unselected
            radSA.Checked = false;
            radInt.Checked = false;

            // 2. Clear out the dropdown lists and text variables
            cmbCountry.DataSource = null;
            lblCountryCode.Text = "";
            txtMobileNumber.Clear();

            // 3. Keep all inputs safely locked until a radio option is ticked
            cmbCountry.Enabled = false;
            txtMobileNumber.Enabled = false;
        }
        private void SetupEventHandlers()
        {
            cmbCountry.SelectedIndexChanged += cmbCountry_SelectedIndexChanged_1;
            //txtMobileNumber.TextChanged += txtMobileNumber_TextChanged;
            radInt.CheckedChanged += RadInt_CheckedChanged;
            radSA.CheckedChanged += RadSA_CheckedChanged;
            txtMobileNumber.KeyPress += txtMobileNumber_KeyPress;

        }

        private void Radiobuttons_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCountryComboBox(radSA.Checked ? southAfricanList : internationalList);
        }



        private void UpdateCountryComboBox(List<Country> countries)
        {
            cmbCountry.DataSource = null;
            cmbCountry.DataSource = countries;
            cmbCountry.DisplayMember = "CountryName";

            if (radInt.Checked)
            {
                cmbCountry.SelectedIndex = -1;
                lblCountryCode.Text = "";
                txtMobileNumber.Clear();
            }
        }

        private void RadSA_CheckedChanged(object sender, EventArgs e)
        {
            if (radSA.Checked)
            {
                UpdateCountryComboBox(southAfricanList);
                cmbCountry.Enabled = false;
                txtMobileNumber.Enabled = true;
            }
        }

        // Event handler for the International Radio Button
        private void RadInt_CheckedChanged(object sender, EventArgs e)
        {
            if (radInt.Checked)
            {
                UpdateCountryComboBox(internationalList);
                cmbCountry.Enabled = true;
                //txtMobileNumber.Enabled = true;
                cmbCountry.SelectedIndex = -1;
                lblCountryCode.Text = "";
                txtMobileNumber.Clear();
                txtMobileNumber.Enabled = false;
            }

        }



        private void txtMobileNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Restrict input exclusively to numbers and basic control keys (like backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cmbCountry_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbCountry.SelectedIndex != -1 && cmbCountry.SelectedItem is Country selectedCountry)
            {
                lblCountryCode.Text = selectedCountry.Code;
                txtMobileNumber.MaxLength = selectedCountry.MaxDigits;
                txtMobileNumber.Clear();
                txtMobileNumber.Enabled = true;
            }
            else
            {
                txtMobileNumber.Clear();
                txtMobileNumber.Enabled = false;
                lblCountryCode.Text = "";
            }
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Moving to the next page or form
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



        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

            string FirstName = txtFirstName.Text;
            bool isValid = Regex.IsMatch(FirstName, @"^[a-zA-Z]+(?: [a-zA-Z]+)*$");
            //Checking if the first name is valid and does't have any special symbols
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                lblNameViolation.Visible = false;
                //block the user from continuing with registration
                return;
            }

            if (!isValid)
            {
                lblNameViolation.Text = ("Invalid symbols! Please put valid name");
                //Remove the warning sign if the user type the correct name 
                lblNameViolation.Visible = true;
            }
            else
            {
                lblNameViolation.Visible = false;
            }

        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {

            string Surname = txtSurname.Text;
            bool SurnameCheck = Regex.IsMatch(Surname, @"^[a-zA-Z]+(?: [a-zA-Z]+)*$");
            //Checking if the surname is valid and does't have any special symbols
            if (string.IsNullOrWhiteSpace(Surname))
            {
                lblSurnameViolation.Visible = false;
                //block the user from continuing with registration
                return;
            }

            if (!SurnameCheck)
            {
                lblSurnameViolation.Text = ("Invalid symbols! Please put valid surname");
                //Remove the warning sign if the user type the correct surname
                lblSurnameViolation.Visible = true;
            }
            else
            {
                lblSurnameViolation.Visible = false;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            string Email = txtEmail.Text;
            bool EmailCheck = Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+(?:\.[^@\s]+)*$");
            //Checking if the email is valid 
            if (string.IsNullOrWhiteSpace(Email))
            {
                lblEmailViolation.Visible = false;
                //block the user from continuing with registration
                return;
            }

            if (!EmailCheck)
            {

                lblEmailViolation.Text = ("Please enter valid email address!");
                //Remove the warning sign if the user type the correct email with @ and .
                lblEmailViolation.Visible = true;
            }
            else
            {
                lblEmailViolation.Visible = false;
            }
        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            string city = txtCity.Text;
            bool isValid = Regex.IsMatch(city, @"^[a-zA-Z]+(?: [a-zA-Z]+)*$");
            if (!string.IsNullOrWhiteSpace(city) && !isValid)
            {
                lblCityViolation.Text = "Invalid symbols, city must have alphabets only! Please put valid city name";
                lblCityViolation.Visible = true;
            }
            else
            {
                lblCityViolation.Visible = false;
            }
        }

        private void txtPassword_TextChanged_1(object sender, EventArgs e)
        {
            string Password = txtPassword.Text;
            bool PasswordCheck = Regex.IsMatch(Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$");

            // 1. Check for missing character requirements
            bool hasUpper = Password.Any(char.IsUpper);
            bool hasNumber = Password.Any(char.IsDigit);
            bool hasSpecial = Password.Any(c => !char.IsLetterOrDigit(c));

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
            }


            if (string.IsNullOrWhiteSpace(Password))
            {

                lblPasswordViolation1.Visible = false;
                //block the user from continuing with registration
                return;
            }

            else if (!PasswordCheck)
            {
                lblPasswordViolation1.Text = ("Password must be at least 8 characters long, contain an uppercase letter, a lowercase letter, and a number!");
                lblPasswordViolation1.Visible = true;

            }
            else
            {
                lblPasswordViolation1.Visible = false;
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // 1. Check for missing character requirements
            bool hasUpper = confirmPassword.Any(char.IsUpper);
            bool hasNumber = confirmPassword.Any(char.IsDigit);
            bool hasSpecial = confirmPassword.Any(c => !char.IsLetterOrDigit(c));

            if (string.IsNullOrWhiteSpace(confirmPassword))
            {
                lblLength.Text = "";
            }/*
            // Does not meet the baseline character types OR is too short
            else if (!hasUpper || !hasNumber || !hasSpecial || confirmPassword.Length < 8)
            {
                lblLength.Text = "Weak password!";
                lblLength.ForeColor = Color.Red;
            }
            // Meets the requirements perfectly (Exactly 8 characters + all required types)
            else if (confirmPassword.Length == 8)
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
            if (string.IsNullOrEmpty(password) && string.IsNullOrEmpty(confirmPassword))
            {
                lblConfirmPasswordViolation.Visible = false;
                //block the user from continuing with registration
                return;
            }

            // Rule 2: Check if the text matches exactly
            if (password == confirmPassword)
            {
                // The moment they match, the warning sign disappears instantly!
                lblConfirmPasswordViolation.Visible = false;
            }
            else
            {
                // Show warning instantly if they do not match
                lblConfirmPasswordViolation.Text = ("Password do not match!please re - type your password");
                lblConfirmPasswordViolation.Visible = true;
            }
        }




        private void btnRegister_Click_1(object sender, EventArgs e)
        {

            try
            {
                //Reset all violation labels at the start so old errors don't stay visible


                //Checking first if all the textboxes are empty and show a warning for each textbox
                lblChoose.Text = ""; // Assuming lblChoose is the region error label
                lblCountryViolation.Visible = false;
                lblNameViolation.Visible = false;
                lblSurnameViolation.Visible = false;
                lblEmailViolation.Visible = false;
                lblCityViolation.Visible = false; // Added to reset on click
                lblMobileNumberViolation.Visible = false;
                lblPasswordViolation1.Visible = false;
                lblConfirmPasswordViolation.Visible = false;
                lblTermsViolation.Visible = false;


                bool isValid = true;

                // 1. Check if the user completely skipped selecting a region
                if (!radSA.Checked && !radInt.Checked)
                {
                    lblChoose.Text = "Please select a region!";
                    txtMobileNumber.Enabled = false;

                    isValid = false;

                }

                // 2. Country Dropdown Selection Check
                Country selectedCountry = cmbCountry.SelectedItem as Country;
                if (selectedCountry == null || string.IsNullOrEmpty(lblCountryCode.Text))
                {
                    lblCountryViolation.Text = "Please select a country!";
                    lblCountryViolation.Visible = true;
                    txtMobileNumber.Enabled = false; // Disable mobile number input if no country is selected
                    isValid = false;
                }

                if (string.IsNullOrWhiteSpace(txtMobileNumber.Text))
                {
                    lblMobileNumberViolation.Text = "Please fill in your mobile number!";
                    lblMobileNumberViolation.Visible = true;
                    isValid = false;
                }
                else if (!Regex.IsMatch(txtMobileNumber.Text, @"^\d+$"))
                {
                    lblMobileNumberViolation.Text = "Invalid symbols! Please put valid mobile number";
                    lblMobileNumberViolation.Visible = true;
                    isValid = false;
                }
                // ONLY check length if a country selection was successfully resolved above
                else if (selectedCountry != null && txtMobileNumber.Text.Length != selectedCountry.MaxDigits)
                {
                    lblMobileNumberViolation.Text = $"Please enter a valid mobile number with {selectedCountry.MaxDigits} digits.";
                    lblMobileNumberViolation.Visible = true;
                    isValid = false;
                }



                // 1. First Name Validation
                if (string.IsNullOrWhiteSpace(txtFirstName.Text))
                {
                    lblNameViolation.Text = "Please fill in your name!";
                    lblNameViolation.Visible = true;
                    isValid = false;
                }
                else if (!Regex.IsMatch(txtFirstName.Text, @"^[a-zA-Z]+(?: [a-zA-Z]+)*$"))
                {
                    lblNameViolation.Text = "Invalid symbols! Please put valid name";
                    lblNameViolation.Visible = true;
                    isValid = false;
                }

                // 2. Surname Validation
                if (string.IsNullOrWhiteSpace(txtSurname.Text))
                {
                    lblSurnameViolation.Text = "Please fill in your surname!";
                    lblSurnameViolation.Visible = true;
                    isValid = false;
                }
                else if (!Regex.IsMatch(txtSurname.Text, @"^[a-zA-Z]+(?: [a-zA-Z]+)*$"))
                {
                    lblSurnameViolation.Text = "Invalid symbols! Please put valid surname";
                    lblSurnameViolation.Visible = true;
                    isValid = false;
                }

                // 3. Email Validation
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    lblEmailViolation.Text = "Please fill in your email!";
                    lblEmailViolation.Visible = true;
                    isValid = false;
                }
                else if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+(?:\.[^@\s]+)*$"))
                {
                    lblEmailViolation.Text = "Please enter valid email address!";
                    lblEmailViolation.Visible = true;
                    isValid = false;
                }

                if (string.IsNullOrWhiteSpace(txtCity.Text))
                {
                    lblCityViolation.Text = "Please fill in your city!";
                    lblCityViolation.Visible = true;
                    isValid = false;
                }
                else if (!Regex.IsMatch(txtCity.Text, @"^[a-zA-Z]+(?: [a-zA-Z]+)*$"))
                {
                    lblCityViolation.Text = "Invalid symbols, city must have alphabets only! Please put valid city name";
                    lblCityViolation.Visible = true;
                    isValid = false;
                }

                // 5. Password Validation
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    lblPasswordViolation1.Text = "Please fill in the password!";
                    lblPasswordViolation1.Visible = true;
                    isValid = false;
                }
                else if (!Regex.IsMatch(txtPassword.Text, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$"))
                {
                    lblPasswordViolation1.Text = "Password must be at least 8 characters long, contain an uppercase letter, a lowercase letter, and a number!";
                    lblPasswordViolation1.Visible = true;
                    isValid = false;
                }
                else
                {
                    lblPasswordViolation1.Visible = false;
                }

                // 6. Confirm Password Validation
                if (string.IsNullOrEmpty(txtConfirmPassword.Text))
                {
                    lblConfirmPasswordViolation.Text = "Please fill in confirm password!";
                    lblConfirmPasswordViolation.Visible = true;
                    isValid = false;
                }
                else if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    lblConfirmPasswordViolation.Text = "Passwords do not match! Please re-type your password";
                    lblConfirmPasswordViolation.Visible = true;
                    isValid = false;
                }

                // 7. Terms and Conditions Validation
                if (!chkTerms.Checked)
                {
                    lblTermsViolation.Text = "Please agree to terms and conditions!";
                    lblTermsViolation.Visible = true;
                    isValid = false;
                }

                // Stop execution if any of the above validations failed
                if (!isValid)
                {
                    return;
                }




                //Declaring variables and giving it values
                string FirstName, Surname, Email, Password;

                FirstName = txtFirstName.Text.Trim();
                Surname = txtSurname.Text.Trim();
                Email = txtEmail.Text.Trim();
                Password = HashPassword(txtPassword.Text);
                string city = txtCity.Text.Trim();
                string selectedRegion = radSA.Checked ? "South African" : "International";
                string country = (selectedCountry != null) ? selectedCountry.CountryName : "Unknown";
                string fullMobile = lblCountryCode.Text + txtMobileNumber.Text.Trim();
                //Come back here
                string projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
                string filepath = Path.Combine(projectDirectory, "Text Files", "Visitor.txt");
                //Reading and checking if the phone number and email already exist in the system or they are not available 


                string line;
                string[] lineArray = new string[10];

                if (File.Exists(filepath))
                {
                    //Looping around cheking line to line in the 2 and 3 index 
                    using (StreamReader Read = new StreamReader(filepath))
                    {
                        line = Read.ReadLine();
                        while (line != null)
                        {
                            if (!string.IsNullOrWhiteSpace(line))
                            {
                                lineArray = line.Split('\t');
                                if (lineArray.Length >= 7)
                                {
                                    //checking if the email entered is already registered or not
                                    if (Email.Equals(lineArray[2], StringComparison.OrdinalIgnoreCase))
                                    {
                                        //but if it not registered or you changed it when it showed a warning,it won't show a warning 
                                        lblEmailViolation.Text = ("Email already registered");
                                        lblEmailViolation.Visible = true;

                                        return;
                                    }

                                    //3 index
                                    //checking if the mobile number entered is already registered or not
                                    if (fullMobile.Equals(lineArray[6], StringComparison.OrdinalIgnoreCase))
                                    {
                                        //if it is registered show this warning
                                        lblMobileNumberViolation.Text = ("Mobile number already registered.");
                                        lblMobileNumberViolation.Visible = true;
                                        return;
                                    }
                                    else
                                    {
                                        //but if it not registered or you changed it when it showed a warning,it won't show a warning 
                                        lblMobileNumberViolation.Visible = false;
                                    }

                                }

                            }

                            line = Read.ReadLine();
                        }
                    }

                }
                //Writing and saving the data because the user meets the requirements that system wants
                StreamWriter Store = new StreamWriter(filepath, true);

                string Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                using (Store)
                {
                    Store.WriteLine(FirstName + "\t" + Surname + "\t" + Email + "\t" + selectedRegion + "\t" + country + "\t" + city + "\t" + fullMobile + "\t" + Password + "\t" + "Agreed" + "\t" + Time);
                }

                //Showing that the data is already saved


                //Clearing the textboxes,checkbox and labels after saving a member
                txtFirstName.Clear();
                txtSurname.Clear();
                txtEmail.Clear();
                txtMobileNumber.Clear();
                txtPassword.Clear();
                txtConfirmPassword.Clear();
                chkTerms.Checked = false;

                lblNameViolation.Visible = false;
                lblSurnameViolation.Visible = false;
                lblEmailViolation.Visible = false;
                lblEmailAvailable.Visible = false;
                lblMobileNumberViolation.Visible = false;
                lblPasswordViolation.Visible = false;
                lblConfirmPasswordViolation.Visible = false;
                lblTermsViolation.Visible = false;

                MessageBox.Show("Your registration is successful! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Navigate to the next form or to Login form
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
            catch (Exception ex)
            {
                //Show an error warning if the system crashes
                MessageBox.Show("An error occured: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            // 1. Get the current text from the password box
            string password = txtPassword.Text;

            // 2. Check if it matches your security rules
            bool passwordCheck = Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$");

            // 3. If it is valid and not empty, hide the warning label immediately!
            if (!string.IsNullOrWhiteSpace(password) && passwordCheck)
            {
                lblPasswordViolation1.Visible = false;
            }
        }

        private string HashPassword(string password)
        {
            //Open the SHA256 engine and make sure it cleans up after it is done
            using (SHA256 sha256 = SHA256.Create())
            {
                //Open the SHA256 engine and make sure it cleans up after it is done
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                //Run the math to create a unique 32-byte digital fingerprint (the hash)
                byte[] hash = sha256.ComputeHash(bytes);

                //Create an empty text box to build our final readable scrambled text
                StringBuilder result = new StringBuilder();
                // Look at each number in the 32-byte fingerprint one by one
                foreach (byte b in hash)
                {
                    //Turn the number into a 2 - letter / number code(hexadecimal) and add it to our text box
                    result.Append(b.ToString("x2"));
                }
                //Give back the final 64-character long scrambled text string
                return result.ToString();
            }
        }
        //Hiding and showing password using checkbox if it checked it show the password but if it unchecked it hide a password 
        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShow.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtConfirmPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtConfirmPassword.PasswordChar = '*';
            }
        }

        //Moving to the next page or form when the user click on the link label
        private void linkTerms_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Link to terms and conditions form
            // frmTerms nextform = new frmTerms();
            // Set the WindowState of the new form to match the current form's WindowState
            // nextform.WindowState = this.WindowState;
            // Match the starting position if its retuened to normal
            //nextform.StartPosition = FormStartPosition.Manual;
            //nextform.Location = this.Location;
            //nextform.Size = this.Size;

            //nextform.Show();

            //this.Hide();
            MessageBox.Show("\r\nWelcome to Blue Horizon. These Terms and Conditions govern your use of the Blue Horizon booking system and your participation in any safari events, tours, or activities organized by Blue Horizon.\r\nBy ticking the \"I Agree to the Terms and Conditions\" checkbox on our System, you provide a legally binding digital \r\nsignature acknowledging that you have read, understood, and agreed to this Agreement.\r\n\r\n1. Booking and Payments\r\nReservation Validity: A booking is only considered confirmed once Blue Horizon issues a formal confirmation receipt via email and payment reflects in our account.\r\nPricing Fluctuations: All prices listed are subject to change due to fluctuating South African National Parks (SANParks) fees, government levies, or fuel price changes until the booking is fully paid.\r\n\r\n2. Cancellation and Refund Policy\r\n7-Day Rule: Blue Horizon enforces a strict cancellation window. No refunds will be issued for any cancellations made less than 7 days prior to the booked event date.\r\nClient Cancellations: Cancellations outside the 7-day window must be submitted in writing to our official email address.\r\nCompany Cancellations: Blue Horizon reserves the right to cancel or reschedule any event due to extreme weather, safety tracking risks, civil unrest, or force majeure events. \r\nIn such cases, clients will be offered an alternative date or a full refund minus unrecoverable third-party conservation fees.\r\nNo-Shows: Failure to arrive at the designated departure point at the scheduled time will result in immediate cancellation by default and total forfeiture of the booking fee.\r\n\r\n3. Safari Safety, Health, and Client Conduct\r\nInherent Risks: You acknowledge that participating in a South African safari involves inherent risks, including but not limited to rough terrain, unpredictable wild animals,\r\n and remote areas with limited medical facilities.Medical Requirements: Clients are responsible for ensuring they are medically fit to travel. \r\nYou must secure any necessary vaccinations or prophylactic medications (such as malaria precautions for specific regions) prior to the event.\r\nGuide Authority: Clients must strictly adhere to all rules set out by Blue Horizon guides and game rangers. Failure to comply, or behavior that endangers oneself, others, or wildlife, \r\nwill result in immediate expulsion from the safari without refund.\r\n\r\n4. Liability and Insurance\r\nLimitation of Liability: To the maximum extent permitted by South African law, Blue Horizon, its directors, and employees shall not be liable for any personal injury, illness, death, property damage, loss, \r\nor delay during the event.\r\nTravel Insurance: It is highly recommended that all clients obtain comprehensive travel and medical insurance covering trip cancellation and emergency medical evacuation before attending.\r\n\r\n5. Data Privacy and POPIA Compliance\r\nInformation Collection: In compliance with the Protection of Personal Information Act (POPIA) of South Africa, Blue Horizon collects your personal data (such as names, contact details) solely to process bookings\r\n and ensure event safety.Third-Party Sharing: Your data will only be shared with necessary third parties (e.g., national park authorities, private game lodges) to fulfill your booking and will never be sold or used maliciously.\r\n\r\n6. Governing Law\r\nThis Agreement is governed by and construed in accordance with the laws of the Republic of South Africa. Any disputes arising from these terms will be subject to the exclusive jurisdiction of South African courts.\r\n\r\n7. Company Contact Information\r\nFor any cancellations, queries, or amendments, please contact Blue Horizon via:\r\nEmail: BlueHorizon@gmail.com\r\nPhone / WhatsApp: 069 752 5854 or 060 374 2650\r\n");
        }


        private void linkBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void txtMobileNumber_TextChanged_1(object sender, EventArgs e)
        {
            string input = txtMobileNumber.Text;

            // 1. Empty box: clear the warning and stop
            if (string.IsNullOrEmpty(input))
            {
                lblMobileNumberViolation.Visible = false;
                return;
            }

            // 2. Digits only
            if (!Regex.IsMatch(input, @"^\d+$"))
            {
                lblMobileNumberViolation.Text = "The mobile number can only contain digits.";
                lblMobileNumberViolation.Visible = true;
                return;
            }

            // 3. First digit must be 6, 7 or 8 (South Africa only)
            if (radSA.Checked && !Regex.IsMatch(input, @"^[678]"))
            {
                lblMobileNumberViolation.Text = "Mobile number must start with a valid digit (6, 7 or 8).";
                lblMobileNumberViolation.Visible = true;
                return;
            }

            // 4. All checks passed
            lblMobileNumberViolation.Visible = false;
        }



    }
}