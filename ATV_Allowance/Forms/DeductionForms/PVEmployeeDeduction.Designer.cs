﻿namespace ATV_Allowance.Forms.DeductionForms
{
    partial class PVEmployeeDeduction
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
            this.gbAction = new System.Windows.Forms.GroupBox();
            this.gbList = new System.Windows.Forms.GroupBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.dtpMonth = new System.Windows.Forms.DateTimePicker();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.adgvDeduction = new System.Windows.Forms.DataGridView();
            this.gbAction.SuspendLayout();
            this.gbList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvDeduction)).BeginInit();
            this.SuspendLayout();
            // 
            // gbAction
            // 
            this.gbAction.Controls.Add(this.lblYear);
            this.gbAction.Controls.Add(this.lblMonth);
            this.gbAction.Controls.Add(this.dtpMonth);
            this.gbAction.Controls.Add(this.dtp);
            this.gbAction.Location = new System.Drawing.Point(12, 12);
            this.gbAction.Name = "gbAction";
            this.gbAction.Size = new System.Drawing.Size(775, 62);
            this.gbAction.TabIndex = 0;
            this.gbAction.TabStop = false;
            this.gbAction.Text = "Bộ lọc";
            // 
            // gbList
            // 
            this.gbList.Controls.Add(this.adgvDeduction);
            this.gbList.Location = new System.Drawing.Point(12, 80);
            this.gbList.Name = "gbList";
            this.gbList.Size = new System.Drawing.Size(775, 383);
            this.gbList.TabIndex = 1;
            this.gbList.TabStop = false;
            this.gbList.Text = "Danh sách";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(391, 18);
            this.lblYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(42, 20);
            this.lblYear.TabIndex = 17;
            this.lblYear.Text = "Năm";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(239, 18);
            this.lblMonth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(54, 20);
            this.lblMonth.TabIndex = 16;
            this.lblMonth.Text = "Tháng";
            // 
            // dtpMonth
            // 
            this.dtpMonth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpMonth.CustomFormat = "MM";
            this.dtpMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonth.Location = new System.Drawing.Point(311, 18);
            this.dtpMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpMonth.Name = "dtpMonth";
            this.dtpMonth.ShowUpDown = true;
            this.dtpMonth.Size = new System.Drawing.Size(64, 26);
            this.dtpMonth.TabIndex = 15;
            // 
            // dtp
            // 
            this.dtp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtp.CustomFormat = "yyyy";
            this.dtp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp.Location = new System.Drawing.Point(439, 18);
            this.dtp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtp.Name = "dtp";
            this.dtp.ShowUpDown = true;
            this.dtp.Size = new System.Drawing.Size(96, 26);
            this.dtp.TabIndex = 14;
            // 
            // adgvDeduction
            // 
            this.adgvDeduction.AllowUserToAddRows = false;
            this.adgvDeduction.AllowUserToDeleteRows = false;
            this.adgvDeduction.AllowUserToOrderColumns = true;
            this.adgvDeduction.AllowUserToResizeColumns = false;
            this.adgvDeduction.AllowUserToResizeRows = false;
            this.adgvDeduction.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.adgvDeduction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvDeduction.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.adgvDeduction.Location = new System.Drawing.Point(7, 27);
            this.adgvDeduction.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.adgvDeduction.MultiSelect = false;
            this.adgvDeduction.Name = "adgvDeduction";
            this.adgvDeduction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.adgvDeduction.Size = new System.Drawing.Size(761, 348);
            this.adgvDeduction.TabIndex = 9;
            // 
            // PVEmployeeDeduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 475);
            this.Controls.Add(this.gbList);
            this.Controls.Add(this.gbAction);
            this.Name = "PVEmployeeDeduction";
            this.Text = "Nhập giảm trừ phóng viên";
            this.gbAction.ResumeLayout(false);
            this.gbAction.PerformLayout();
            this.gbList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adgvDeduction)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAction;
        private System.Windows.Forms.GroupBox gbList;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.DateTimePicker dtpMonth;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.DataGridView adgvDeduction;
    }
}