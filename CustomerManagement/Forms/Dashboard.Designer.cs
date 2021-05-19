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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.customersTable = new System.Windows.Forms.DataGridView();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.appointmentsBtn = new System.Windows.Forms.Button();
            this.calendarBtn = new System.Windows.Forms.Button();
            this.pageHeader = new System.Windows.Forms.Label();
            this.exitBtn = new System.Windows.Forms.Button();
            this.apptNumReportBtn = new System.Windows.Forms.Button();
            this.consultantReportBtn = new System.Windows.Forms.Button();
            this.customerReportBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reportsBtn = new System.Windows.Forms.Button();
            this.customersBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tableHeader = new System.Windows.Forms.Label();
            this.searchInput = new System.Windows.Forms.TextBox();
            this.searchBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.customersTable)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // customersTable
            // 
            this.customersTable.AllowUserToAddRows = false;
            this.customersTable.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.customersTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.customersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.customersTable.DefaultCellStyle = dataGridViewCellStyle8;
            this.customersTable.Location = new System.Drawing.Point(41, 159);
            this.customersTable.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.customersTable.Name = "customersTable";
            this.customersTable.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.customersTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.customersTable.RowHeadersVisible = false;
            this.customersTable.RowHeadersWidth = 82;
            this.customersTable.RowTemplate.Height = 33;
            this.customersTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customersTable.ShowEditingIcon = false;
            this.customersTable.ShowRowErrors = false;
            this.customersTable.Size = new System.Drawing.Size(472, 177);
            this.customersTable.TabIndex = 0;
            // 
            // deleteBtn
            // 
            this.deleteBtn.BackColor = System.Drawing.Color.Red;
            this.deleteBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.deleteBtn.Location = new System.Drawing.Point(314, 353);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(54, 25);
            this.deleteBtn.TabIndex = 1;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = false;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.BackColor = System.Drawing.Color.Green;
            this.editBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.editBtn.Location = new System.Drawing.Point(388, 353);
            this.editBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(54, 25);
            this.editBtn.TabIndex = 2;
            this.editBtn.Text = "Edit";
            this.editBtn.UseVisualStyleBackColor = false;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.addBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.addBtn.Location = new System.Drawing.Point(460, 352);
            this.addBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(54, 26);
            this.addBtn.TabIndex = 3;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // appointmentsBtn
            // 
            this.appointmentsBtn.BackColor = System.Drawing.Color.Green;
            this.appointmentsBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.appointmentsBtn.Location = new System.Drawing.Point(41, 353);
            this.appointmentsBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.appointmentsBtn.Name = "appointmentsBtn";
            this.appointmentsBtn.Size = new System.Drawing.Size(108, 25);
            this.appointmentsBtn.TabIndex = 4;
            this.appointmentsBtn.Text = "View Appointments";
            this.appointmentsBtn.UseVisualStyleBackColor = false;
            this.appointmentsBtn.Click += new System.EventHandler(this.appointmentsBtn_Click);
            // 
            // calendarBtn
            // 
            this.calendarBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.calendarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.calendarBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.calendarBtn.Location = new System.Drawing.Point(337, 2);
            this.calendarBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.calendarBtn.Name = "calendarBtn";
            this.calendarBtn.Size = new System.Drawing.Size(81, 39);
            this.calendarBtn.TabIndex = 5;
            this.calendarBtn.Text = "Calendar";
            this.calendarBtn.UseVisualStyleBackColor = false;
            this.calendarBtn.Click += new System.EventHandler(this.calendarBtn_Click);
            // 
            // pageHeader
            // 
            this.pageHeader.AutoSize = true;
            this.pageHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageHeader.Location = new System.Drawing.Point(38, 66);
            this.pageHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pageHeader.Name = "pageHeader";
            this.pageHeader.Size = new System.Drawing.Size(150, 20);
            this.pageHeader.TabIndex = 6;
            this.pageHeader.Text = "Welcome {Name}!";
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.Red;
            this.exitBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.exitBtn.Location = new System.Drawing.Point(495, 2);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(84, 39);
            this.exitBtn.TabIndex = 7;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // apptNumReportBtn
            // 
            this.apptNumReportBtn.Location = new System.Drawing.Point(48, 426);
            this.apptNumReportBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.apptNumReportBtn.Name = "apptNumReportBtn";
            this.apptNumReportBtn.Size = new System.Drawing.Size(151, 23);
            this.apptNumReportBtn.TabIndex = 8;
            this.apptNumReportBtn.Text = "Number of Appointments";
            this.apptNumReportBtn.UseVisualStyleBackColor = true;
            this.apptNumReportBtn.Click += new System.EventHandler(this.apptNumReportBtn_Click);
            // 
            // consultantReportBtn
            // 
            this.consultantReportBtn.Location = new System.Drawing.Point(231, 426);
            this.consultantReportBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.consultantReportBtn.Name = "consultantReportBtn";
            this.consultantReportBtn.Size = new System.Drawing.Size(151, 23);
            this.consultantReportBtn.TabIndex = 9;
            this.consultantReportBtn.Text = "Consultant Schedules";
            this.consultantReportBtn.UseVisualStyleBackColor = true;
            this.consultantReportBtn.Click += new System.EventHandler(this.consultantReportBtn_Click);
            // 
            // customerReportBtn
            // 
            this.customerReportBtn.Location = new System.Drawing.Point(49, 467);
            this.customerReportBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.customerReportBtn.Name = "customerReportBtn";
            this.customerReportBtn.Size = new System.Drawing.Size(150, 23);
            this.customerReportBtn.TabIndex = 10;
            this.customerReportBtn.Text = "Customer Report";
            this.customerReportBtn.UseVisualStyleBackColor = true;
            this.customerReportBtn.Click += new System.EventHandler(this.customerReportBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.reportsBtn);
            this.panel1.Controls.Add(this.customersBtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.calendarBtn);
            this.panel1.Controls.Add(this.exitBtn);
            this.panel1.Location = new System.Drawing.Point(1, -2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(580, 41);
            this.panel1.TabIndex = 11;
            // 
            // reportsBtn
            // 
            this.reportsBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.reportsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.reportsBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.reportsBtn.Location = new System.Drawing.Point(417, 1);
            this.reportsBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.reportsBtn.Name = "reportsBtn";
            this.reportsBtn.Size = new System.Drawing.Size(81, 39);
            this.reportsBtn.TabIndex = 13;
            this.reportsBtn.Text = "Reports";
            this.reportsBtn.UseVisualStyleBackColor = false;
            this.reportsBtn.Click += new System.EventHandler(this.reportsBtn_Click);
            // 
            // customersBtn
            // 
            this.customersBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.customersBtn.Cursor = System.Windows.Forms.Cursors.No;
            this.customersBtn.Enabled = false;
            this.customersBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.customersBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.customersBtn.Location = new System.Drawing.Point(258, 1);
            this.customersBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.customersBtn.Name = "customersBtn";
            this.customersBtn.Size = new System.Drawing.Size(81, 39);
            this.customersBtn.TabIndex = 12;
            this.customersBtn.Text = "Customers";
            this.customersBtn.UseVisualStyleBackColor = false;
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
            // tableHeader
            // 
            this.tableHeader.AutoSize = true;
            this.tableHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableHeader.Location = new System.Drawing.Point(38, 133);
            this.tableHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tableHeader.Name = "tableHeader";
            this.tableHeader.Size = new System.Drawing.Size(97, 20);
            this.tableHeader.TabIndex = 12;
            this.tableHeader.Text = "tableHeader";
            // 
            // searchInput
            // 
            this.searchInput.Location = new System.Drawing.Point(300, 135);
            this.searchInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.searchInput.Name = "searchInput";
            this.searchInput.Size = new System.Drawing.Size(144, 20);
            this.searchInput.TabIndex = 13;
            // 
            // searchBtn
            // 
            this.searchBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.searchBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.searchBtn.Location = new System.Drawing.Point(450, 133);
            this.searchBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(64, 22);
            this.searchBtn.TabIndex = 14;
            this.searchBtn.Text = "searchBtn";
            this.searchBtn.UseVisualStyleBackColor = false;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 508);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.searchInput);
            this.Controls.Add(this.tableHeader);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.customerReportBtn);
            this.Controls.Add(this.consultantReportBtn);
            this.Controls.Add(this.apptNumReportBtn);
            this.Controls.Add(this.pageHeader);
            this.Controls.Add(this.appointmentsBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.customersTable);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.customersTable)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Button apptNumReportBtn;
        private System.Windows.Forms.Button consultantReportBtn;
        private System.Windows.Forms.Button customerReportBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button customersBtn;
        private System.Windows.Forms.Button reportsBtn;
        private System.Windows.Forms.Label tableHeader;
        private System.Windows.Forms.TextBox searchInput;
        private System.Windows.Forms.Button searchBtn;
    }
}