namespace CustomerManagement.Forms
{
    partial class ConsultantSchedules
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
            this.reportTable = new System.Windows.Forms.DataGridView();
            this.closeBtn = new System.Windows.Forms.Button();
            this.weekRadio = new System.Windows.Forms.RadioButton();
            this.monthRadio = new System.Windows.Forms.RadioButton();
            this.dayRadio = new System.Windows.Forms.RadioButton();
            this.crewSelect = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.reportTable)).BeginInit();
            this.SuspendLayout();
            // 
            // pageHeader
            // 
            this.pageHeader.AutoSize = true;
            this.pageHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageHeader.Location = new System.Drawing.Point(44, 23);
            this.pageHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pageHeader.Name = "pageHeader";
            this.pageHeader.Size = new System.Drawing.Size(138, 20);
            this.pageHeader.TabIndex = 0;
            this.pageHeader.Text = "Crew Schedules";
            // 
            // reportTable
            // 
            this.reportTable.AllowUserToAddRows = false;
            this.reportTable.AllowUserToDeleteRows = false;
            this.reportTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportTable.Location = new System.Drawing.Point(48, 107);
            this.reportTable.Margin = new System.Windows.Forms.Padding(2);
            this.reportTable.Name = "reportTable";
            this.reportTable.ReadOnly = true;
            this.reportTable.RowHeadersVisible = false;
            this.reportTable.RowHeadersWidth = 82;
            this.reportTable.RowTemplate.Height = 33;
            this.reportTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.reportTable.ShowCellErrors = false;
            this.reportTable.ShowCellToolTips = false;
            this.reportTable.ShowEditingIcon = false;
            this.reportTable.Size = new System.Drawing.Size(485, 248);
            this.reportTable.TabIndex = 1;
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.closeBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.closeBtn.Location = new System.Drawing.Point(468, 380);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(2);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(64, 26);
            this.closeBtn.TabIndex = 2;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // weekRadio
            // 
            this.weekRadio.AutoSize = true;
            this.weekRadio.Location = new System.Drawing.Point(120, 78);
            this.weekRadio.Margin = new System.Windows.Forms.Padding(2);
            this.weekRadio.Name = "weekRadio";
            this.weekRadio.Size = new System.Drawing.Size(54, 17);
            this.weekRadio.TabIndex = 9;
            this.weekRadio.Text = "Week";
            this.weekRadio.UseVisualStyleBackColor = true;
            // 
            // monthRadio
            // 
            this.monthRadio.AutoSize = true;
            this.monthRadio.Checked = true;
            this.monthRadio.Location = new System.Drawing.Point(48, 78);
            this.monthRadio.Margin = new System.Windows.Forms.Padding(2);
            this.monthRadio.Name = "monthRadio";
            this.monthRadio.Size = new System.Drawing.Size(55, 17);
            this.monthRadio.TabIndex = 8;
            this.monthRadio.TabStop = true;
            this.monthRadio.Text = "Month";
            this.monthRadio.UseVisualStyleBackColor = true;
            // 
            // dayRadio
            // 
            this.dayRadio.AutoSize = true;
            this.dayRadio.Location = new System.Drawing.Point(190, 78);
            this.dayRadio.Margin = new System.Windows.Forms.Padding(2);
            this.dayRadio.Name = "dayRadio";
            this.dayRadio.Size = new System.Drawing.Size(44, 17);
            this.dayRadio.TabIndex = 12;
            this.dayRadio.Text = "Day";
            this.dayRadio.UseVisualStyleBackColor = true;
            // 
            // crewSelect
            // 
            this.crewSelect.FormattingEnabled = true;
            this.crewSelect.Location = new System.Drawing.Point(446, 78);
            this.crewSelect.Margin = new System.Windows.Forms.Padding(2);
            this.crewSelect.Name = "crewSelect";
            this.crewSelect.Size = new System.Drawing.Size(87, 17);
            this.crewSelect.TabIndex = 13;
            // 
            // ConsultantSchedules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 460);
            this.Controls.Add(this.crewSelect);
            this.Controls.Add(this.dayRadio);
            this.Controls.Add(this.weekRadio);
            this.Controls.Add(this.monthRadio);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.reportTable);
            this.Controls.Add(this.pageHeader);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ConsultantSchedules";
            this.Text = "ConsultantSchedules";
            ((System.ComponentModel.ISupportInitialize)(this.reportTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pageHeader;
        private System.Windows.Forms.DataGridView reportTable;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.RadioButton weekRadio;
        private System.Windows.Forms.RadioButton monthRadio;
        private System.Windows.Forms.RadioButton dayRadio;
        private System.Windows.Forms.ListBox crewSelect;
    }
}