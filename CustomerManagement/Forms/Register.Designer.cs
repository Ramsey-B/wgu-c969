namespace CustomerManagement.Forms
{
    partial class Register
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pageHeader = new System.Windows.Forms.Label();
            this.loginError = new System.Windows.Forms.Label();
            this.passwordError = new System.Windows.Forms.Label();
            this.usernameError = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.createBtn = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.confirmError = new System.Windows.Forms.Label();
            this.confirmPasswordLabel = new System.Windows.Forms.Label();
            this.confirmPasswordInput = new System.Windows.Forms.TextBox();
            this.langSelect = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(580, 41);
            this.panel1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Jim\'s Landscaping";
            // 
            // pageHeader
            // 
            this.pageHeader.AutoSize = true;
            this.pageHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageHeader.Location = new System.Drawing.Point(42, 65);
            this.pageHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pageHeader.Name = "pageHeader";
            this.pageHeader.Size = new System.Drawing.Size(229, 17);
            this.pageHeader.TabIndex = 22;
            this.pageHeader.Text = "Welcome! Create your account";
            // 
            // loginError
            // 
            this.loginError.AutoSize = true;
            this.loginError.ForeColor = System.Drawing.Color.Red;
            this.loginError.Location = new System.Drawing.Point(55, 302);
            this.loginError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.loginError.Name = "loginError";
            this.loginError.Size = new System.Drawing.Size(190, 13);
            this.loginError.TabIndex = 21;
            this.loginError.Text = "* Login attempt failed. Please try again.";
            this.loginError.Visible = false;
            // 
            // passwordError
            // 
            this.passwordError.AutoSize = true;
            this.passwordError.ForeColor = System.Drawing.Color.Red;
            this.passwordError.Location = new System.Drawing.Point(59, 188);
            this.passwordError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.passwordError.Name = "passwordError";
            this.passwordError.Size = new System.Drawing.Size(131, 13);
            this.passwordError.TabIndex = 20;
            this.passwordError.Text = "* Please enter a Password";
            this.passwordError.Visible = false;
            // 
            // usernameError
            // 
            this.usernameError.AutoSize = true;
            this.usernameError.ForeColor = System.Drawing.Color.Red;
            this.usernameError.Location = new System.Drawing.Point(61, 136);
            this.usernameError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.usernameError.Name = "usernameError";
            this.usernameError.Size = new System.Drawing.Size(133, 13);
            this.usernameError.TabIndex = 19;
            this.usernameError.Text = "* Please enter a Username";
            this.usernameError.Visible = false;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(59, 152);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 18;
            this.passwordLabel.Text = "Password";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(59, 96);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(55, 13);
            this.usernameLabel.TabIndex = 17;
            this.usernameLabel.Text = "Username";
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.Red;
            this.cancelBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cancelBtn.Location = new System.Drawing.Point(58, 266);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(2);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(56, 29);
            this.cancelBtn.TabIndex = 16;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // createBtn
            // 
            this.createBtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.createBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.createBtn.Location = new System.Drawing.Point(164, 266);
            this.createBtn.Margin = new System.Windows.Forms.Padding(2);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(60, 29);
            this.createBtn.TabIndex = 15;
            this.createBtn.Text = "Create";
            this.createBtn.UseVisualStyleBackColor = false;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(62, 167);
            this.password.Margin = new System.Windows.Forms.Padding(2);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(164, 20);
            this.password.TabIndex = 14;
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(62, 115);
            this.username.Margin = new System.Windows.Forms.Padding(2);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(164, 20);
            this.username.TabIndex = 13;
            // 
            // confirmError
            // 
            this.confirmError.AutoSize = true;
            this.confirmError.ForeColor = System.Drawing.Color.Red;
            this.confirmError.Location = new System.Drawing.Point(59, 241);
            this.confirmError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.confirmError.Name = "confirmError";
            this.confirmError.Size = new System.Drawing.Size(122, 13);
            this.confirmError.TabIndex = 25;
            this.confirmError.Text = "* Passwords must match";
            this.confirmError.Visible = false;
            // 
            // confirmPasswordLabel
            // 
            this.confirmPasswordLabel.AutoSize = true;
            this.confirmPasswordLabel.Location = new System.Drawing.Point(59, 205);
            this.confirmPasswordLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.confirmPasswordLabel.Name = "confirmPasswordLabel";
            this.confirmPasswordLabel.Size = new System.Drawing.Size(91, 13);
            this.confirmPasswordLabel.TabIndex = 24;
            this.confirmPasswordLabel.Text = "Confirm Password";
            // 
            // confirmPasswordInput
            // 
            this.confirmPasswordInput.Location = new System.Drawing.Point(62, 220);
            this.confirmPasswordInput.Margin = new System.Windows.Forms.Padding(2);
            this.confirmPasswordInput.Name = "confirmPasswordInput";
            this.confirmPasswordInput.PasswordChar = '*';
            this.confirmPasswordInput.Size = new System.Drawing.Size(164, 20);
            this.confirmPasswordInput.TabIndex = 23;
            // 
            // langSelect
            // 
            this.langSelect.FormattingEnabled = true;
            this.langSelect.Location = new System.Drawing.Point(58, 334);
            this.langSelect.Margin = new System.Windows.Forms.Padding(2);
            this.langSelect.Name = "langSelect";
            this.langSelect.Size = new System.Drawing.Size(84, 17);
            this.langSelect.TabIndex = 26;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 398);
            this.Controls.Add(this.langSelect);
            this.Controls.Add(this.confirmError);
            this.Controls.Add(this.confirmPasswordLabel);
            this.Controls.Add(this.confirmPasswordInput);
            this.Controls.Add(this.pageHeader);
            this.Controls.Add(this.loginError);
            this.Controls.Add(this.passwordError);
            this.Controls.Add(this.usernameError);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Register";
            this.Text = "Register";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label pageHeader;
        private System.Windows.Forms.Label loginError;
        private System.Windows.Forms.Label passwordError;
        private System.Windows.Forms.Label usernameError;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label confirmError;
        private System.Windows.Forms.Label confirmPasswordLabel;
        private System.Windows.Forms.TextBox confirmPasswordInput;
        private System.Windows.Forms.ListBox langSelect;
    }
}