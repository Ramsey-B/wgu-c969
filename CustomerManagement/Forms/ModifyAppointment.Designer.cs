namespace CustomerManagement.Forms
{
    partial class ModifyAppointment
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
            this.components = new System.ComponentModel.Container();
            this.titleInput = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.descriptionInput = new System.Windows.Forms.TextBox();
            this.locationInput = new System.Windows.Forms.TextBox();
            this.contactInput = new System.Windows.Forms.TextBox();
            this.typeInput = new System.Windows.Forms.TextBox();
            this.urlInput = new System.Windows.Forms.TextBox();
            this.startInput = new System.Windows.Forms.DateTimePicker();
            this.endInput = new System.Windows.Forms.DateTimePicker();
            this.titleLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.locationLabel = new System.Windows.Forms.Label();
            this.contactLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.urlLabel = new System.Windows.Forms.Label();
            this.startLabel = new System.Windows.Forms.Label();
            this.endLabel = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.submitBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.pageTitle = new System.Windows.Forms.Label();
            this.customerSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleInput
            // 
            this.titleInput.Location = new System.Drawing.Point(257, 153);
            this.titleInput.Name = "titleInput";
            this.titleInput.Size = new System.Drawing.Size(282, 31);
            this.titleInput.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // descriptionInput
            // 
            this.descriptionInput.Location = new System.Drawing.Point(257, 204);
            this.descriptionInput.Name = "descriptionInput";
            this.descriptionInput.Size = new System.Drawing.Size(282, 31);
            this.descriptionInput.TabIndex = 2;
            // 
            // locationInput
            // 
            this.locationInput.Location = new System.Drawing.Point(257, 255);
            this.locationInput.Name = "locationInput";
            this.locationInput.Size = new System.Drawing.Size(282, 31);
            this.locationInput.TabIndex = 3;
            // 
            // contactInput
            // 
            this.contactInput.Location = new System.Drawing.Point(257, 304);
            this.contactInput.Name = "contactInput";
            this.contactInput.Size = new System.Drawing.Size(282, 31);
            this.contactInput.TabIndex = 4;
            // 
            // typeInput
            // 
            this.typeInput.Location = new System.Drawing.Point(257, 357);
            this.typeInput.Name = "typeInput";
            this.typeInput.Size = new System.Drawing.Size(282, 31);
            this.typeInput.TabIndex = 5;
            // 
            // urlInput
            // 
            this.urlInput.Location = new System.Drawing.Point(257, 412);
            this.urlInput.Name = "urlInput";
            this.urlInput.Size = new System.Drawing.Size(282, 31);
            this.urlInput.TabIndex = 6;
            // 
            // startInput
            // 
            this.startInput.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.startInput.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startInput.Location = new System.Drawing.Point(257, 461);
            this.startInput.Name = "startInput";
            this.startInput.Size = new System.Drawing.Size(282, 31);
            this.startInput.TabIndex = 7;
            // 
            // endInput
            // 
            this.endInput.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.endInput.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endInput.Location = new System.Drawing.Point(257, 512);
            this.endInput.Name = "endInput";
            this.endInput.Size = new System.Drawing.Size(282, 31);
            this.endInput.TabIndex = 8;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(153, 153);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(53, 25);
            this.titleLabel.TabIndex = 9;
            this.titleLabel.Text = "Title";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(90, 207);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(120, 25);
            this.descriptionLabel.TabIndex = 10;
            this.descriptionLabel.Text = "Description";
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(112, 255);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(94, 25);
            this.locationLabel.TabIndex = 11;
            this.locationLabel.Text = "Location";
            // 
            // contactLabel
            // 
            this.contactLabel.AutoSize = true;
            this.contactLabel.Location = new System.Drawing.Point(124, 304);
            this.contactLabel.Name = "contactLabel";
            this.contactLabel.Size = new System.Drawing.Size(86, 25);
            this.contactLabel.TabIndex = 12;
            this.contactLabel.Text = "Contact";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(153, 357);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(60, 25);
            this.typeLabel.TabIndex = 13;
            this.typeLabel.Text = "Type";
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(171, 412);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(39, 25);
            this.urlLabel.TabIndex = 14;
            this.urlLabel.Text = "Url";
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Location = new System.Drawing.Point(153, 461);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(57, 25);
            this.startLabel.TabIndex = 15;
            this.startLabel.Text = "Start";
            // 
            // endLabel
            // 
            this.endLabel.AutoSize = true;
            this.endLabel.Location = new System.Drawing.Point(156, 512);
            this.endLabel.Name = "endLabel";
            this.endLabel.Size = new System.Drawing.Size(50, 25);
            this.endLabel.TabIndex = 16;
            this.endLabel.Text = "End";
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(252, 564);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(199, 25);
            this.errorLabel.TabIndex = 17;
            this.errorLabel.Text = "* An Error Occurred";
            this.errorLabel.Visible = false;
            // 
            // submitBtn
            // 
            this.submitBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.submitBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.submitBtn.Location = new System.Drawing.Point(436, 611);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(103, 40);
            this.submitBtn.TabIndex = 18;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = false;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.Red;
            this.cancelBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cancelBtn.Location = new System.Drawing.Point(257, 611);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(103, 40);
            this.cancelBtn.TabIndex = 19;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // pageTitle
            // 
            this.pageTitle.AutoSize = true;
            this.pageTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageTitle.Location = new System.Drawing.Point(179, 26);
            this.pageTitle.Name = "pageTitle";
            this.pageTitle.Size = new System.Drawing.Size(378, 37);
            this.pageTitle.TabIndex = 20;
            this.pageTitle.Text = "Appointment for {{name}}";
            // 
            // customerSelect
            // 
            this.customerSelect.Location = new System.Drawing.Point(257, 97);
            this.customerSelect.Name = "customerSelect";
            this.customerSelect.Size = new System.Drawing.Size(282, 33);
            this.customerSelect.TabIndex = 21;
            this.customerSelect.Text = "Select Customer";
            this.customerSelect.UseVisualStyleBackColor = true;
            this.customerSelect.Click += new System.EventHandler(this.customerSelect_Click);
            // 
            // ModifyAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 736);
            this.Controls.Add(this.customerSelect);
            this.Controls.Add(this.pageTitle);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.endLabel);
            this.Controls.Add(this.startLabel);
            this.Controls.Add(this.urlLabel);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.contactLabel);
            this.Controls.Add(this.locationLabel);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.endInput);
            this.Controls.Add(this.startInput);
            this.Controls.Add(this.urlInput);
            this.Controls.Add(this.typeInput);
            this.Controls.Add(this.contactInput);
            this.Controls.Add(this.locationInput);
            this.Controls.Add(this.descriptionInput);
            this.Controls.Add(this.titleInput);
            this.Name = "ModifyAppointment";
            this.Text = "ModifyAppointment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox titleInput;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox descriptionInput;
        private System.Windows.Forms.TextBox locationInput;
        private System.Windows.Forms.TextBox contactInput;
        private System.Windows.Forms.TextBox typeInput;
        private System.Windows.Forms.TextBox urlInput;
        private System.Windows.Forms.DateTimePicker startInput;
        private System.Windows.Forms.DateTimePicker endInput;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.Label contactLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.Label endLabel;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label pageTitle;
        private System.Windows.Forms.Button customerSelect;
    }
}