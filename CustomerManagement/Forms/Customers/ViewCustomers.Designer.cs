﻿namespace CustomerManagement.Forms.Customers
{
    partial class ViewCustomers
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
            ((System.ComponentModel.ISupportInitialize)(this.customersTable)).BeginInit();
            this.SuspendLayout();
            // 
            // customersTable
            // 
            this.customersTable.AllowUserToAddRows = false;
            this.customersTable.AllowUserToDeleteRows = false;
            this.customersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customersTable.Location = new System.Drawing.Point(73, 131);
            this.customersTable.Name = "customersTable";
            this.customersTable.RowHeadersVisible = false;
            this.customersTable.RowHeadersWidth = 82;
            this.customersTable.RowTemplate.Height = 33;
            this.customersTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customersTable.Size = new System.Drawing.Size(792, 262);
            this.customersTable.TabIndex = 0;
            // 
            // deleteBtn
            // 
            this.deleteBtn.BackColor = System.Drawing.Color.Red;
            this.deleteBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.deleteBtn.Location = new System.Drawing.Point(455, 424);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(108, 42);
            this.deleteBtn.TabIndex = 1;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = false;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.BackColor = System.Drawing.Color.Green;
            this.editBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.editBtn.Location = new System.Drawing.Point(607, 425);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(108, 41);
            this.editBtn.TabIndex = 2;
            this.editBtn.Text = "Edit";
            this.editBtn.UseVisualStyleBackColor = false;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.addBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.addBtn.Location = new System.Drawing.Point(757, 425);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(108, 42);
            this.addBtn.TabIndex = 3;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // ViewCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 546);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.customersTable);
            this.Name = "ViewCustomers";
            this.Text = "Customers";
            ((System.ComponentModel.ISupportInitialize)(this.customersTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView customersTable;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button addBtn;
    }
}