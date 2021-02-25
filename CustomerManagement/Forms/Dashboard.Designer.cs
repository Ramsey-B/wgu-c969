namespace CustomerManagement.Forms.Customers
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
            this.customersTable = new System.Windows.Forms.DataGridView();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.appointmentsBtn = new System.Windows.Forms.Button();
            this.calendarBtn = new System.Windows.Forms.Button();
            this.pageHeader = new System.Windows.Forms.Label();
            this.exitBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.customersTable)).BeginInit();
            this.SuspendLayout();
            // 
            // customersTable
            // 
            this.customersTable.AllowUserToAddRows = false;
            this.customersTable.AllowUserToDeleteRows = false;
            this.customersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customersTable.Location = new System.Drawing.Point(82, 218);
            this.customersTable.Name = "customersTable";
            this.customersTable.ReadOnly = true;
            this.customersTable.RowHeadersVisible = false;
            this.customersTable.RowHeadersWidth = 82;
            this.customersTable.RowTemplate.Height = 33;
            this.customersTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customersTable.ShowEditingIcon = false;
            this.customersTable.ShowRowErrors = false;
            this.customersTable.Size = new System.Drawing.Size(945, 341);
            this.customersTable.TabIndex = 0;
            // 
            // deleteBtn
            // 
            this.deleteBtn.BackColor = System.Drawing.Color.Red;
            this.deleteBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.deleteBtn.Location = new System.Drawing.Point(629, 591);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(108, 49);
            this.deleteBtn.TabIndex = 1;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = false;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.BackColor = System.Drawing.Color.Green;
            this.editBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.editBtn.Location = new System.Drawing.Point(777, 592);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(108, 48);
            this.editBtn.TabIndex = 2;
            this.editBtn.Text = "Edit";
            this.editBtn.UseVisualStyleBackColor = false;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.addBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.addBtn.Location = new System.Drawing.Point(919, 590);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(108, 50);
            this.addBtn.TabIndex = 3;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // appointmentsBtn
            // 
            this.appointmentsBtn.BackColor = System.Drawing.Color.Green;
            this.appointmentsBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.appointmentsBtn.Location = new System.Drawing.Point(82, 591);
            this.appointmentsBtn.Name = "appointmentsBtn";
            this.appointmentsBtn.Size = new System.Drawing.Size(217, 49);
            this.appointmentsBtn.TabIndex = 4;
            this.appointmentsBtn.Text = "View Appointments";
            this.appointmentsBtn.UseVisualStyleBackColor = false;
            this.appointmentsBtn.Click += new System.EventHandler(this.appointmentsBtn_Click);
            // 
            // calendarBtn
            // 
            this.calendarBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.calendarBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.calendarBtn.Location = new System.Drawing.Point(82, 139);
            this.calendarBtn.Name = "calendarBtn";
            this.calendarBtn.Size = new System.Drawing.Size(217, 47);
            this.calendarBtn.TabIndex = 5;
            this.calendarBtn.Text = "Calendar";
            this.calendarBtn.UseVisualStyleBackColor = false;
            this.calendarBtn.Click += new System.EventHandler(this.calendarBtn_Click);
            // 
            // pageHeader
            // 
            this.pageHeader.AutoSize = true;
            this.pageHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageHeader.Location = new System.Drawing.Point(77, 55);
            this.pageHeader.Name = "pageHeader";
            this.pageHeader.Size = new System.Drawing.Size(291, 37);
            this.pageHeader.TabIndex = 6;
            this.pageHeader.Text = "Welcome {Name}!";
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.Red;
            this.exitBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.exitBtn.Location = new System.Drawing.Point(919, 1023);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(108, 48);
            this.exitBtn.TabIndex = 7;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(82, 728);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(302, 45);
            this.button1.TabIndex = 8;
            this.button1.Text = "Number of Appointments";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 1115);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.pageHeader);
            this.Controls.Add(this.calendarBtn);
            this.Controls.Add(this.appointmentsBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.customersTable);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.customersTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView customersTable;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button appointmentsBtn;
        private System.Windows.Forms.Button calendarBtn;
        private System.Windows.Forms.Label pageHeader;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button button1;
    }
}