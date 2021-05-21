
namespace CustomerManagement.Forms
{
    partial class Reports
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
            this.reportsBtn = new System.Windows.Forms.Button();
            this.customersBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.calendarBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.customerReportBtn = new System.Windows.Forms.Button();
            this.consultantReportBtn = new System.Windows.Forms.Button();
            this.apptNumReportBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.reportsBtn);
            this.panel1.Controls.Add(this.customersBtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.calendarBtn);
            this.panel1.Controls.Add(this.exitBtn);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(974, 41);
            this.panel1.TabIndex = 12;
            // 
            // reportsBtn
            // 
            this.reportsBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.reportsBtn.Cursor = System.Windows.Forms.Cursors.No;
            this.reportsBtn.Enabled = false;
            this.reportsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.reportsBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.reportsBtn.Location = new System.Drawing.Point(417, 1);
            this.reportsBtn.Margin = new System.Windows.Forms.Padding(2);
            this.reportsBtn.Name = "reportsBtn";
            this.reportsBtn.Size = new System.Drawing.Size(81, 39);
            this.reportsBtn.TabIndex = 13;
            this.reportsBtn.Text = "Reports";
            this.reportsBtn.UseVisualStyleBackColor = false;
            // 
            // customersBtn
            // 
            this.customersBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.customersBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.customersBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.customersBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.customersBtn.Location = new System.Drawing.Point(258, 1);
            this.customersBtn.Margin = new System.Windows.Forms.Padding(2);
            this.customersBtn.Name = "customersBtn";
            this.customersBtn.Size = new System.Drawing.Size(81, 39);
            this.customersBtn.TabIndex = 12;
            this.customersBtn.Text = "Customers";
            this.customersBtn.UseVisualStyleBackColor = false;
            this.customersBtn.Click += new System.EventHandler(this.customersBtn_Click);
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
            // calendarBtn
            // 
            this.calendarBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.calendarBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.calendarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.calendarBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.calendarBtn.Location = new System.Drawing.Point(337, 1);
            this.calendarBtn.Margin = new System.Windows.Forms.Padding(2);
            this.calendarBtn.Name = "calendarBtn";
            this.calendarBtn.Size = new System.Drawing.Size(81, 39);
            this.calendarBtn.TabIndex = 5;
            this.calendarBtn.Text = "Calendar";
            this.calendarBtn.UseVisualStyleBackColor = false;
            this.calendarBtn.Click += new System.EventHandler(this.calendarBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.Red;
            this.exitBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.exitBtn.Location = new System.Drawing.Point(502, 2);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(2);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(84, 39);
            this.exitBtn.TabIndex = 7;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // customerReportBtn
            // 
            this.customerReportBtn.Location = new System.Drawing.Point(31, 172);
            this.customerReportBtn.Margin = new System.Windows.Forms.Padding(2);
            this.customerReportBtn.Name = "customerReportBtn";
            this.customerReportBtn.Size = new System.Drawing.Size(150, 23);
            this.customerReportBtn.TabIndex = 15;
            this.customerReportBtn.Text = "Customer Report";
            this.customerReportBtn.UseVisualStyleBackColor = true;
            this.customerReportBtn.Click += new System.EventHandler(this.customerReportBtn_Click);
            // 
            // consultantReportBtn
            // 
            this.consultantReportBtn.Location = new System.Drawing.Point(31, 121);
            this.consultantReportBtn.Margin = new System.Windows.Forms.Padding(2);
            this.consultantReportBtn.Name = "consultantReportBtn";
            this.consultantReportBtn.Size = new System.Drawing.Size(151, 23);
            this.consultantReportBtn.TabIndex = 14;
            this.consultantReportBtn.Text = "Consultant Schedules";
            this.consultantReportBtn.UseVisualStyleBackColor = true;
            this.consultantReportBtn.Click += new System.EventHandler(this.consultantReportBtn_Click);
            // 
            // apptNumReportBtn
            // 
            this.apptNumReportBtn.Location = new System.Drawing.Point(31, 70);
            this.apptNumReportBtn.Margin = new System.Windows.Forms.Padding(2);
            this.apptNumReportBtn.Name = "apptNumReportBtn";
            this.apptNumReportBtn.Size = new System.Drawing.Size(151, 23);
            this.apptNumReportBtn.TabIndex = 13;
            this.apptNumReportBtn.Text = "Number of Appointments";
            this.apptNumReportBtn.UseVisualStyleBackColor = true;
            this.apptNumReportBtn.Click += new System.EventHandler(this.apptNumReportBtn_Click);
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 450);
            this.Controls.Add(this.customerReportBtn);
            this.Controls.Add(this.consultantReportBtn);
            this.Controls.Add(this.apptNumReportBtn);
            this.Controls.Add(this.panel1);
            this.Name = "Reports";
            this.Text = "Reports";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button reportsBtn;
        private System.Windows.Forms.Button customersBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button calendarBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button customerReportBtn;
        private System.Windows.Forms.Button consultantReportBtn;
        private System.Windows.Forms.Button apptNumReportBtn;
    }
}