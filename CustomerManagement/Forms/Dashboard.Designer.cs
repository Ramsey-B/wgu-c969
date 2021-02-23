namespace CustomerManagement.Forms
{
    partial class Dashboard
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
            this.viewCustomersBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // viewCustomersBtn
            // 
            this.viewCustomersBtn.Location = new System.Drawing.Point(133, 50);
            this.viewCustomersBtn.Name = "viewCustomersBtn";
            this.viewCustomersBtn.Size = new System.Drawing.Size(181, 43);
            this.viewCustomersBtn.TabIndex = 0;
            this.viewCustomersBtn.Text = "View Customers";
            this.viewCustomersBtn.UseVisualStyleBackColor = true;
            this.viewCustomersBtn.Click += new System.EventHandler(this.viewCustomersBtn_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1638, 835);
            this.Controls.Add(this.viewCustomersBtn);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button viewCustomersBtn;
    }
}