namespace PROJECTT
{
    partial class frmRegister
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNewAccount = new System.Windows.Forms.Label();
            this.lblAlready = new System.Windows.Forms.Label();
            this.linkLogIn2 = new System.Windows.Forms.LinkLabel();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblSurname = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblMobileNumber = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtMobileNumber = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.linkTerms = new System.Windows.Forms.LinkLabel();
            this.chkTerms = new System.Windows.Forms.CheckBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblNameViolation = new System.Windows.Forms.Label();
            this.lblEmailViolation = new System.Windows.Forms.Label();
            this.lblMobileNumberViolation = new System.Windows.Forms.Label();
            this.lblPasswordViolation = new System.Windows.Forms.Label();
            this.lblConfirmPasswordViolation = new System.Windows.Forms.Label();
            this.lblTermsViolation = new System.Windows.Forms.Label();
            this.lblEmailAvailable = new System.Windows.Forms.Label();
            this.panelPhotoBlueHorizon = new System.Windows.Forms.Panel();
            this.chkShow = new System.Windows.Forms.CheckBox();
            this.lblSurnameViolation = new System.Windows.Forms.Label();
            this.lblPasswordViolation1 = new System.Windows.Forms.Label();
            this.lblLength = new System.Windows.Forms.Label();
            this.radSA = new System.Windows.Forms.RadioButton();
            this.radInt = new System.Windows.Forms.RadioButton();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblCountryCode = new System.Windows.Forms.Label();
            this.lblChoose = new System.Windows.Forms.Label();
            this.lblCountryViolation = new System.Windows.Forms.Label();
            this.lblCityViolation = new System.Windows.Forms.Label();
            this.linkBack = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblNewAccount
            // 
            this.lblNewAccount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNewAccount.AutoSize = true;
            this.lblNewAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewAccount.Location = new System.Drawing.Point(575, 196);
            this.lblNewAccount.Name = "lblNewAccount";
            this.lblNewAccount.Size = new System.Drawing.Size(533, 69);
            this.lblNewAccount.TabIndex = 3;
            this.lblNewAccount.Text = "Create an account";
            // 
            // lblAlready
            // 
            this.lblAlready.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAlready.AutoSize = true;
            this.lblAlready.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlready.Location = new System.Drawing.Point(584, 265);
            this.lblAlready.Name = "lblAlready";
            this.lblAlready.Size = new System.Drawing.Size(201, 20);
            this.lblAlready.TabIndex = 4;
            this.lblAlready.Text = "Already have an account?";
            // 
            // linkLogIn2
            // 
            this.linkLogIn2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.linkLogIn2.AutoSize = true;
            this.linkLogIn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLogIn2.LinkColor = System.Drawing.Color.Blue;
            this.linkLogIn2.Location = new System.Drawing.Point(782, 265);
            this.linkLogIn2.Name = "linkLogIn2";
            this.linkLogIn2.Size = new System.Drawing.Size(55, 20);
            this.linkLogIn2.TabIndex = 5;
            this.linkLogIn2.TabStop = true;
            this.linkLogIn2.Text = "Log In";
            this.linkLogIn2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lblFirstName
            // 
            this.lblFirstName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(584, 307);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(143, 25);
            this.lblFirstName.TabIndex = 6;
            this.lblFirstName.Text = "First Name(s)";
            // 
            // lblSurname
            // 
            this.lblSurname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSurname.AutoSize = true;
            this.lblSurname.Location = new System.Drawing.Point(887, 307);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(99, 25);
            this.lblSurname.TabIndex = 7;
            this.lblSurname.Text = "Surname";
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(585, 390);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(65, 25);
            this.lblName.TabIndex = 8;
            this.lblName.Text = "Email";
            // 
            // lblMobileNumber
            // 
            this.lblMobileNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMobileNumber.AutoSize = true;
            this.lblMobileNumber.Location = new System.Drawing.Point(582, 668);
            this.lblMobileNumber.Name = "lblMobileNumber";
            this.lblMobileNumber.Size = new System.Drawing.Size(157, 25);
            this.lblMobileNumber.TabIndex = 9;
            this.lblMobileNumber.Text = "Mobile Number";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.txtFirstName.Location = new System.Drawing.Point(588, 335);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(217, 30);
            this.txtFirstName.TabIndex = 10;
            this.txtFirstName.TextChanged += new System.EventHandler(this.txtFirstName_TextChanged);
            // 
            // txtSurname
            // 
            this.txtSurname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSurname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSurname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.txtSurname.Location = new System.Drawing.Point(892, 335);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(217, 30);
            this.txtSurname.TabIndex = 11;
            this.txtSurname.TextChanged += new System.EventHandler(this.txtSurname_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.txtEmail.Location = new System.Drawing.Point(588, 418);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(521, 30);
            this.txtEmail.TabIndex = 12;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // txtMobileNumber
            // 
            this.txtMobileNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMobileNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMobileNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.txtMobileNumber.Location = new System.Drawing.Point(660, 696);
            this.txtMobileNumber.MaxLength = 10;
            this.txtMobileNumber.Name = "txtMobileNumber";
            this.txtMobileNumber.Size = new System.Drawing.Size(448, 30);
            this.txtMobileNumber.TabIndex = 13;
            this.txtMobileNumber.TextChanged += new System.EventHandler(this.txtMobileNumber_TextChanged_1);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.txtPassword.Location = new System.Drawing.Point(587, 779);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(521, 30);
            this.txtPassword.TabIndex = 14;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged_1);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.txtConfirmPassword.Location = new System.Drawing.Point(587, 864);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(521, 30);
            this.txtConfirmPassword.TabIndex = 15;
            this.txtConfirmPassword.TextChanged += new System.EventHandler(this.txtConfirmPassword_TextChanged);
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(582, 825);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(187, 25);
            this.lblConfirmPassword.TabIndex = 16;
            this.lblConfirmPassword.Text = "Confirm Password";
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(584, 751);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(106, 25);
            this.lblPassword.TabIndex = 17;
            this.lblPassword.Text = "Password";
            // 
            // linkTerms
            // 
            this.linkTerms.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.linkTerms.AutoSize = true;
            this.linkTerms.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkTerms.LinkColor = System.Drawing.Color.Blue;
            this.linkTerms.Location = new System.Drawing.Point(681, 901);
            this.linkTerms.Name = "linkTerms";
            this.linkTerms.Size = new System.Drawing.Size(173, 20);
            this.linkTerms.TabIndex = 18;
            this.linkTerms.TabStop = true;
            this.linkTerms.Text = "Terms and Conditions";
            this.linkTerms.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkTerms_LinkClicked);
            // 
            // chkTerms
            // 
            this.chkTerms.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkTerms.AutoSize = true;
            this.chkTerms.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTerms.Location = new System.Drawing.Point(587, 900);
            this.chkTerms.Name = "chkTerms";
            this.chkTerms.Size = new System.Drawing.Size(108, 24);
            this.chkTerms.TabIndex = 19;
            this.chkTerms.Text = "I Agree to ";
            this.chkTerms.UseVisualStyleBackColor = true;
            // 
            // btnRegister
            // 
            this.btnRegister.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRegister.BackColor = System.Drawing.Color.Blue;
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(587, 943);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(522, 50);
            this.btnRegister.TabIndex = 20;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click_1);
            // 
            // lblNameViolation
            // 
            this.lblNameViolation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNameViolation.AutoSize = true;
            this.lblNameViolation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameViolation.ForeColor = System.Drawing.Color.Red;
            this.lblNameViolation.Location = new System.Drawing.Point(587, 368);
            this.lblNameViolation.Name = "lblNameViolation";
            this.lblNameViolation.Size = new System.Drawing.Size(0, 16);
            this.lblNameViolation.TabIndex = 21;
            // 
            // lblEmailViolation
            // 
            this.lblEmailViolation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEmailViolation.AutoSize = true;
            this.lblEmailViolation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailViolation.ForeColor = System.Drawing.Color.Red;
            this.lblEmailViolation.Location = new System.Drawing.Point(587, 451);
            this.lblEmailViolation.Name = "lblEmailViolation";
            this.lblEmailViolation.Size = new System.Drawing.Size(0, 16);
            this.lblEmailViolation.TabIndex = 22;
            // 
            // lblMobileNumberViolation
            // 
            this.lblMobileNumberViolation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMobileNumberViolation.AutoSize = true;
            this.lblMobileNumberViolation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMobileNumberViolation.ForeColor = System.Drawing.Color.Red;
            this.lblMobileNumberViolation.Location = new System.Drawing.Point(584, 729);
            this.lblMobileNumberViolation.Name = "lblMobileNumberViolation";
            this.lblMobileNumberViolation.Size = new System.Drawing.Size(0, 16);
            this.lblMobileNumberViolation.TabIndex = 23;
            // 
            // lblPasswordViolation
            // 
            this.lblPasswordViolation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPasswordViolation.AutoSize = true;
            this.lblPasswordViolation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordViolation.ForeColor = System.Drawing.Color.Red;
            this.lblPasswordViolation.Location = new System.Drawing.Point(586, 809);
            this.lblPasswordViolation.Name = "lblPasswordViolation";
            this.lblPasswordViolation.Size = new System.Drawing.Size(0, 16);
            this.lblPasswordViolation.TabIndex = 24;
            // 
            // lblConfirmPasswordViolation
            // 
            this.lblConfirmPasswordViolation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblConfirmPasswordViolation.AutoSize = true;
            this.lblConfirmPasswordViolation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPasswordViolation.ForeColor = System.Drawing.Color.Red;
            this.lblConfirmPasswordViolation.Location = new System.Drawing.Point(586, 845);
            this.lblConfirmPasswordViolation.Name = "lblConfirmPasswordViolation";
            this.lblConfirmPasswordViolation.Size = new System.Drawing.Size(0, 16);
            this.lblConfirmPasswordViolation.TabIndex = 25;
            // 
            // lblTermsViolation
            // 
            this.lblTermsViolation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTermsViolation.AutoSize = true;
            this.lblTermsViolation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTermsViolation.ForeColor = System.Drawing.Color.Red;
            this.lblTermsViolation.Location = new System.Drawing.Point(585, 924);
            this.lblTermsViolation.Name = "lblTermsViolation";
            this.lblTermsViolation.Size = new System.Drawing.Size(0, 16);
            this.lblTermsViolation.TabIndex = 26;
            // 
            // lblEmailAvailable
            // 
            this.lblEmailAvailable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEmailAvailable.AutoSize = true;
            this.lblEmailAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailAvailable.ForeColor = System.Drawing.Color.Red;
            this.lblEmailAvailable.Location = new System.Drawing.Point(586, 278);
            this.lblEmailAvailable.Name = "lblEmailAvailable";
            this.lblEmailAvailable.Size = new System.Drawing.Size(0, 16);
            this.lblEmailAvailable.TabIndex = 27;
            // 
            // panelPhotoBlueHorizon
            // 
            this.panelPhotoBlueHorizon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelPhotoBlueHorizon.AutoScroll = true;
            this.panelPhotoBlueHorizon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelPhotoBlueHorizon.Location = new System.Drawing.Point(-96, 53);
            this.panelPhotoBlueHorizon.Name = "panelPhotoBlueHorizon";
            this.panelPhotoBlueHorizon.Size = new System.Drawing.Size(610, 1082);
            this.panelPhotoBlueHorizon.TabIndex = 30;
            // 
            // chkShow
            // 
            this.chkShow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkShow.AutoSize = true;
            this.chkShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShow.Location = new System.Drawing.Point(959, 754);
            this.chkShow.Name = "chkShow";
            this.chkShow.Size = new System.Drawing.Size(149, 24);
            this.chkShow.TabIndex = 31;
            this.chkShow.Text = "Show password";
            this.chkShow.UseVisualStyleBackColor = true;
            this.chkShow.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            // 
            // lblSurnameViolation
            // 
            this.lblSurnameViolation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSurnameViolation.AutoSize = true;
            this.lblSurnameViolation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurnameViolation.ForeColor = System.Drawing.Color.Red;
            this.lblSurnameViolation.Location = new System.Drawing.Point(892, 368);
            this.lblSurnameViolation.Name = "lblSurnameViolation";
            this.lblSurnameViolation.Size = new System.Drawing.Size(0, 16);
            this.lblSurnameViolation.TabIndex = 32;
            // 
            // lblPasswordViolation1
            // 
            this.lblPasswordViolation1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPasswordViolation1.AutoSize = true;
            this.lblPasswordViolation1.BackColor = System.Drawing.Color.White;
            this.lblPasswordViolation1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordViolation1.ForeColor = System.Drawing.Color.Red;
            this.lblPasswordViolation1.Location = new System.Drawing.Point(585, 809);
            this.lblPasswordViolation1.Name = "lblPasswordViolation1";
            this.lblPasswordViolation1.Size = new System.Drawing.Size(0, 16);
            this.lblPasswordViolation1.TabIndex = 5;
            // 
            // lblLength
            // 
            this.lblLength.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLength.AutoSize = true;
            this.lblLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLength.Location = new System.Drawing.Point(985, 834);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(0, 16);
            this.lblLength.TabIndex = 0;
            // 
            // radSA
            // 
            this.radSA.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radSA.AutoSize = true;
            this.radSA.Location = new System.Drawing.Point(587, 470);
            this.radSA.Name = "radSA";
            this.radSA.Size = new System.Drawing.Size(164, 29);
            this.radSA.TabIndex = 33;
            this.radSA.TabStop = true;
            this.radSA.Text = "South African";
            this.radSA.UseVisualStyleBackColor = true;
            // 
            // radInt
            // 
            this.radInt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radInt.AutoSize = true;
            this.radInt.Location = new System.Drawing.Point(833, 470);
            this.radInt.Name = "radInt";
            this.radInt.Size = new System.Drawing.Size(152, 29);
            this.radInt.TabIndex = 34;
            this.radInt.TabStop = true;
            this.radInt.Text = "International";
            this.radInt.UseVisualStyleBackColor = true;
            // 
            // cmbCountry
            // 
            this.cmbCountry.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(587, 546);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(521, 33);
            this.cmbCountry.TabIndex = 35;
            // 
            // lblCountry
            // 
            this.lblCountry.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(584, 518);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(88, 25);
            this.lblCountry.TabIndex = 37;
            this.lblCountry.Text = "Country";
            // 
            // txtCity
            // 
            this.txtCity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.txtCity.Location = new System.Drawing.Point(587, 623);
            this.txtCity.MaxLength = 10;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(521, 30);
            this.txtCity.TabIndex = 14;
            this.txtCity.TextChanged += new System.EventHandler(this.txtCity_TextChanged);
            // 
            // lblCity
            // 
            this.lblCity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(583, 596);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(50, 25);
            this.lblCity.TabIndex = 38;
            this.lblCity.Text = "City";
            // 
            // lblCountryCode
            // 
            this.lblCountryCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCountryCode.AutoSize = true;
            this.lblCountryCode.Location = new System.Drawing.Point(585, 701);
            this.lblCountryCode.Name = "lblCountryCode";
            this.lblCountryCode.Size = new System.Drawing.Size(0, 25);
            this.lblCountryCode.TabIndex = 38;
            // 
            // lblChoose
            // 
            this.lblChoose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblChoose.AutoSize = true;
            this.lblChoose.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChoose.ForeColor = System.Drawing.Color.Red;
            this.lblChoose.Location = new System.Drawing.Point(587, 502);
            this.lblChoose.Name = "lblChoose";
            this.lblChoose.Size = new System.Drawing.Size(0, 16);
            this.lblChoose.TabIndex = 0;
            // 
            // lblCountryViolation
            // 
            this.lblCountryViolation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCountryViolation.AutoSize = true;
            this.lblCountryViolation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountryViolation.ForeColor = System.Drawing.Color.Red;
            this.lblCountryViolation.Location = new System.Drawing.Point(586, 580);
            this.lblCountryViolation.Name = "lblCountryViolation";
            this.lblCountryViolation.Size = new System.Drawing.Size(0, 16);
            this.lblCountryViolation.TabIndex = 0;
            // 
            // lblCityViolation
            // 
            this.lblCityViolation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCityViolation.AutoSize = true;
            this.lblCityViolation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCityViolation.ForeColor = System.Drawing.Color.Red;
            this.lblCityViolation.Location = new System.Drawing.Point(584, 656);
            this.lblCityViolation.Name = "lblCityViolation";
            this.lblCityViolation.Size = new System.Drawing.Size(0, 16);
            this.lblCityViolation.TabIndex = 1;
            // 
            // linkBack
            // 
            this.linkBack.AutoSize = true;
            this.linkBack.BackColor = System.Drawing.Color.White;
            this.linkBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linkBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkBack.LinkColor = System.Drawing.Color.Black;
            this.linkBack.Location = new System.Drawing.Point(606, 53);
            this.linkBack.Name = "linkBack";
            this.linkBack.Size = new System.Drawing.Size(70, 22);
            this.linkBack.TabIndex = 39;
            this.linkBack.TabStop = true;
            this.linkBack.Text = "< Back";
            this.linkBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBack_LinkClicked);
            // 
            // frmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(800, 1000);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(8)))), ((int)(((byte)(14)))));
            this.ClientSize = new System.Drawing.Size(1272, 749);
            this.Controls.Add(this.linkBack);
            this.Controls.Add(this.lblCityViolation);
            this.Controls.Add(this.lblCountryViolation);
            this.Controls.Add(this.lblChoose);
            this.Controls.Add(this.lblCountryCode);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.cmbCountry);
            this.Controls.Add(this.radInt);
            this.Controls.Add(this.radSA);
            this.Controls.Add(this.lblLength);
            this.Controls.Add(this.lblPasswordViolation1);
            this.Controls.Add(this.lblSurnameViolation);
            this.Controls.Add(this.chkShow);
            this.Controls.Add(this.panelPhotoBlueHorizon);
            this.Controls.Add(this.lblEmailAvailable);
            this.Controls.Add(this.lblTermsViolation);
            this.Controls.Add(this.lblConfirmPasswordViolation);
            this.Controls.Add(this.lblPasswordViolation);
            this.Controls.Add(this.lblMobileNumberViolation);
            this.Controls.Add(this.lblEmailViolation);
            this.Controls.Add(this.lblNameViolation);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.chkTerms);
            this.Controls.Add(this.linkTerms);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtMobileNumber);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblMobileNumber);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblSurname);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.linkLogIn2);
            this.Controls.Add(this.lblAlready);
            this.Controls.Add(this.lblNewAccount);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmRegister";
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNewAccount;
        private System.Windows.Forms.Label lblAlready;
        private System.Windows.Forms.LinkLabel linkLogIn2;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblMobileNumber;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtMobileNumber;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.LinkLabel linkTerms;
        private System.Windows.Forms.CheckBox chkTerms;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblNameViolation;
        private System.Windows.Forms.Label lblEmailViolation;
        private System.Windows.Forms.Label lblMobileNumberViolation;
        private System.Windows.Forms.Label lblPasswordViolation;
        private System.Windows.Forms.Label lblConfirmPasswordViolation;
        private System.Windows.Forms.Label lblTermsViolation;
        private System.Windows.Forms.Label lblEmailAvailable;
        private System.Windows.Forms.Panel panelPhotoBlueHorizon;
        private System.Windows.Forms.CheckBox chkShow;
        private System.Windows.Forms.Label lblSurnameViolation;
        private System.Windows.Forms.Label lblPasswordViolation1;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.RadioButton radSA;
        private System.Windows.Forms.RadioButton radInt;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblCountryCode;
        private System.Windows.Forms.Label lblChoose;
        private System.Windows.Forms.Label lblCountryViolation;
        private System.Windows.Forms.Label lblCityViolation;
        private System.Windows.Forms.LinkLabel linkBack;
    }
}
