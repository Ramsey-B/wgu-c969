namespace CustomerManagement.Forms
{
    partial class CustomerSelect
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
            this.customersTable = new System.Windows.Forms.DataGridView();
            this.selectBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.customersTable)).BeginInit();
            this.SuspendLayout();
            // 
            // pageHeader
            // 
            this.pageHeader.AutoSize = true;
            this.pageHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageHeader.Location = new System.Drawing.Point(49, 23);
            this.pageHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pageHeader.Name = "pageHeader";
            this.pageHeader.Size = new System.Drawing.Size(190, 17);
            this.pageHeader.TabIndex = 0;
            this.pageHeader.Text = "Please select a customer";
            // 
            // customersTable
            // 
            this.customersTable.AllowUserToAddRows = false;
            this.customersTable.AllowUserToDeleteRows = false;
            this.customersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customersTable.Location = new System.Drawing.Point(52, 57);
            this.customersTable.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.customersTable.Name = "customersTable";
            this.customersTable.ReadOnly = true;
            this.customersTable.RowHeadersVisible = false;
            this.customersTable.RowHeadersWidth = 82;
            this.customersTable.RowTemplate.Height = 33;
            this.customersTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customersTable.ShowEditingIcon = false;
            this.customersTable.ShowRowErrors = false;
            this.customersTable.Size = new System.Drawing.Size(256, 177);
            this.customersTable.TabIndex = 1;
            // 
            // selectBtn
            // 
            this.selectBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.selectBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.selectBtn.Location = new System.Drawing.Point(252, 257);
            this.selectBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(56, 26);
            this.selectBtn.TabIndex = 2;
            this.selectBtn.Text = "Select";
            this.selectBtn.UseVisualStyleBackColor = false;
            this.selectBtn.Click += new System.EventHandler(this.selectBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.Red;
            this.cancelBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cancelBtn.Location = new System.Drawing.Point(170, 257);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(56, 26);
            this.cancelBtn.TabIndex = 3;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // CustomerSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 385);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.selectBtn);
            this.Controls.Add(this.customersTable);
            this.Controls.Add(this.pageHeader);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CustomerSelect";
            this.Text = "CustomerSelect";
            ((System.ComponentModel.ISupportInitialize)(this.customersTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pageHeader;
        private System.Windows.Forms.DataGridView customersTable;
        private System.Windows.Forms.Button selectBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}