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
            this.crewInput = new System.Windows.Forms.TextBox();
            this.typeInput = new System.Windows.Forms.TextBox();
            this.startInput = new System.Windows.Forms.DateTimePicker();
            this.endInput = new System.Windows.Forms.DateTimePicker();
            this.titleLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.locationLabel = new System.Windows.Forms.Label();
            this.crewLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
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
            this.titleInput.Location = new System.Drawing.Point(128, 80);
            this.titleInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.titleInput.Name = "titleInput";
            this.titleInput.Size = new System.Drawing.Size(143, 20);
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
            this.descriptionInput.Location = new System.Drawing.Point(128, 106);
            this.descriptionInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.descriptionInput.Name = "descriptionInput";
            this.descriptionInput.Size = new System.Drawing.Size(143, 20);
            this.descriptionInput.TabIndex = 2;
            // 
            // locationInput
            // 
            this.locationInput.Location = new System.Drawing.Point(128, 133);
            this.locationInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.locationInput.Name = "locationInput";
            this.locationInput.Size = new System.Drawing.Size(143, 20);
            this.locationInput.TabIndex = 3;
            // 
            // crewInput
            // 
            this.crewInput.Location = new System.Drawing.Point(128, 158);
            this.crewInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.crewInput.Name = "crewInput";
            this.crewInput.Size = new System.Drawing.Size(143, 20);
            this.crewInput.TabIndex = 4;
            // 
            // typeInput
            // 
            this.typeInput.Location = new System.Drawing.Point(128, 186);
            this.typeInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.typeInput.Name = "typeInput";
            this.typeInput.Size = new System.Drawing.Size(143, 20);
            this.typeInput.TabIndex = 5;
            // 
            // startInput
            // 
            this.startInput.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.startInput.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startInput.Location = new System.Drawing.Point(129, 216);
            this.startInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.startInput.Name = "startInput";
            this.startInput.Size = new System.Drawing.Size(143, 20);
            this.startInput.TabIndex = 7;
            // 
            // endInput
            // 
            this.endInput.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.endInput.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endInput.Location = new System.Drawing.Point(129, 245);
            this.endInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.endInput.Name = "endInput";
            this.endInput.Size = new System.Drawing.Size(143, 20);
            this.endInput.TabIndex = 8;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(80, 80);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(27, 13);
            this.titleLabel.TabIndex = 9;
            this.titleLabel.Text = "Title";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(47, 106);
            this.descriptionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.descriptionLabel.TabIndex = 10;
            this.descriptionLabel.Text = "Description";
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(59, 133);
            this.locationLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(48, 13);
            this.locationLabel.TabIndex = 11;
            this.locationLabel.Text = "Location";
            // 
            // crewLabel
            // 
            this.crewLabel.AutoSize = true;
            this.crewLabel.Location = new System.Drawing.Point(72, 158);
            this.crewLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.crewLabel.Name = "crewLabel";
            this.crewLabel.Size = new System.Drawing.Size(31, 13);
            this.crewLabel.TabIndex = 12;
            this.crewLabel.Text = "Crew";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(76, 186);
            this.typeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(31, 13);
            this.typeLabel.TabIndex = 13;
            this.typeLabel.Text = "Type";
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Location = new System.Drawing.Point(76, 219);
            this.startLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(29, 13);
            this.startLabel.TabIndex = 15;
            this.startLabel.Text = "Start";
            // 
            // endLabel
            // 
            this.endLabel.AutoSize = true;
            this.endLabel.Location = new System.Drawing.Point(78, 249);
            this.endLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.endLabel.Name = "endLabel";
            this.endLabel.Size = new System.Drawing.Size(26, 13);
            this.endLabel.TabIndex = 16;
            this.endLabel.Text = "End";
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(126, 274);
            this.errorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(99, 13);
            this.errorLabel.TabIndex = 17;
            this.errorLabel.Text = "* An Error Occurred";
            this.errorLabel.Visible = false;
            // 
            // submitBtn
            // 
            this.submitBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.submitBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.submitBtn.Location = new System.Drawing.Point(218, 299);
            this.submitBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(52, 21);
            this.submitBtn.TabIndex = 18;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = false;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.Red;
            this.cancelBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cancelBtn.Location = new System.Drawing.Point(128, 299);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(52, 21);
            this.cancelBtn.TabIndex = 19;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // pageTitle
            // 
            this.pageTitle.AutoSize = true;
            this.pageTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageTitle.Location = new System.Drawing.Point(90, 14);
            this.pageTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pageTitle.Name = "pageTitle";
            this.pageTitle.Size = new System.Drawing.Size(187, 20);
            this.pageTitle.TabIndex = 20;
            this.pageTitle.Text = "Appointment for {{name}}";
            // 
            // customerSelect
            // 
            this.customerSelect.Location = new System.Drawing.Point(128, 47);
            this.customerSelect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.customerSelect.Name = "customerSelect";
            this.customerSelect.Size = new System.Drawing.Size(141, 21);
            this.customerSelect.TabIndex = 21;
            this.customerSelect.Text = "Select Customer";
            this.customerSelect.UseVisualStyleBackColor = true;
            this.customerSelect.Click += new System.EventHandler(this.customerSelect_Click);
            // 
            // ModifyAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 383);
            this.Controls.Add(this.customerSelect);
            this.Controls.Add(this.pageTitle);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.endLabel);
            this.Controls.Add(this.startLabel);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.crewLabel);
            this.Controls.Add(this.locationLabel);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.endInput);
            this.Controls.Add(this.startInput);
            this.Controls.Add(this.typeInput);
            this.Controls.Add(this.crewInput);
            this.Controls.Add(this.locationInput);
            this.Controls.Add(this.descriptionInput);
            this.Controls.Add(this.titleInput);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.TextBox crewInput;
        private System.Windows.Forms.TextBox typeInput;
        private System.Windows.Forms.DateTimePicker startInput;
        private System.Windows.Forms.DateTimePicker endInput;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.Label crewLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.Label endLabel;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label pageTitle;
        private System.Windows.Forms.Button customerSelect;
    }
}