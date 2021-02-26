namespace CustomerManagement.Forms
{
    partial class AppointmentsReport
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
            this.pageHeader = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.reportTable = new System.Windows.Forms.DataGridView();
            this.yearSelect = new System.Windows.Forms.ListBox();
            this.closeBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.reportTable)).BeginInit();
            this.SuspendLayout();
            // 
            // pageHeader
            // 
            this.pageHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageHeader.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pageHeader.Location = new System.Drawing.Point(40, 45);
            this.pageHeader.Name = "pageHeader";
            this.pageHeader.Size = new System.Drawing.Size(359, 52);
            this.pageHeader.TabIndex = 0;
            this.pageHeader.Text = "Appointments Report";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // reportTable
            // 
            this.reportTable.AllowUserToAddRows = false;
            this.reportTable.AllowUserToDeleteRows = false;
            this.reportTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportTable.Location = new System.Drawing.Point(47, 160);
            this.reportTable.Name = "reportTable";
            this.reportTable.ReadOnly = true;
            this.reportTable.RowHeadersVisible = false;
            this.reportTable.RowHeadersWidth = 82;
            this.reportTable.RowTemplate.Height = 33;
            this.reportTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.reportTable.ShowEditingIcon = false;
            this.reportTable.ShowRowErrors = false;
            this.reportTable.Size = new System.Drawing.Size(352, 564);
            this.reportTable.TabIndex = 1;
            // 
            // yearSelect
            // 
            this.yearSelect.FormattingEnabled = true;
            this.yearSelect.ItemHeight = 25;
            this.yearSelect.Location = new System.Drawing.Point(47, 113);
            this.yearSelect.Name = "yearSelect";
            this.yearSelect.Size = new System.Drawing.Size(120, 29);
            this.yearSelect.TabIndex = 2;
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.closeBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.closeBtn.Location = new System.Drawing.Point(280, 772);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(119, 39);
            this.closeBtn.TabIndex = 3;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // AppointmentsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 851);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.yearSelect);
            this.Controls.Add(this.reportTable);
            this.Controls.Add(this.pageHeader);
            this.Name = "AppointmentsReport";
            this.Text = "AppointmentsReport";
            ((System.ComponentModel.ISupportInitialize)(this.reportTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label pageHeader;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView reportTable;
        private System.Windows.Forms.ListBox yearSelect;
        private System.Windows.Forms.Button closeBtn;
    }
}