namespace ATV_Allowance.Forms.PrintReportForms
{
    partial class ReportBroadcastForm
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
            this.btnDeduction = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.edtPrice = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpEnddate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartdate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpYear = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpMonth = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDeductionPTV = new System.Windows.Forms.Button();
            this.btnEditCriteria = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.edtPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeduction
            // 
            this.btnDeduction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeduction.Location = new System.Drawing.Point(346, 83);
            this.btnDeduction.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeduction.Name = "btnDeduction";
            this.btnDeduction.Size = new System.Drawing.Size(140, 35);
            this.btnDeduction.TabIndex = 2;
            this.btnDeduction.Text = "Giảm trừ PV";
            this.btnDeduction.UseVisualStyleBackColor = true;
            this.btnDeduction.Click += new System.EventHandler(this.btnDeduction_Click);
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(347, 197);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(139, 35);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "In báo cáo";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(190, 210);
            this.label7.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 18);
            this.label7.TabIndex = 9;
            this.label7.Text = "vnđ / điểm";
            // 
            // edtPrice
            // 
            this.edtPrice.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.edtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtPrice.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.edtPrice.Location = new System.Drawing.Point(120, 208);
            this.edtPrice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edtPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.edtPrice.Name = "edtPrice";
            this.edtPrice.Size = new System.Drawing.Size(58, 24);
            this.edtPrice.TabIndex = 16;
            this.edtPrice.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.edtPrice.ValueChanged += new System.EventHandler(this.edtPrice_ValueChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(81, 208);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 18);
            this.label6.TabIndex = 7;
            this.label6.Text = "Giá";
            // 
            // dtpEnddate
            // 
            this.dtpEnddate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpEnddate.CustomFormat = "dd/MM/yyyy";
            this.dtpEnddate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnddate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnddate.Location = new System.Drawing.Point(120, 128);
            this.dtpEnddate.Margin = new System.Windows.Forms.Padding(0);
            this.dtpEnddate.Name = "dtpEnddate";
            this.dtpEnddate.Size = new System.Drawing.Size(146, 24);
            this.dtpEnddate.TabIndex = 5;
            this.dtpEnddate.ValueChanged += new System.EventHandler(this.dtpEnddate_ValueChanged);
            // 
            // dtpStartdate
            // 
            this.dtpStartdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpStartdate.CustomFormat = "dd/MM/yyyy";
            this.dtpStartdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartdate.Location = new System.Drawing.Point(120, 83);
            this.dtpStartdate.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.dtpStartdate.Name = "dtpStartdate";
            this.dtpStartdate.Size = new System.Drawing.Size(146, 24);
            this.dtpStartdate.TabIndex = 6;
            this.dtpStartdate.ValueChanged += new System.EventHandler(this.dtpStartdate_ValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(52, 83);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Từ ngày";
            // 
            // dtpYear
            // 
            this.dtpYear.CustomFormat = "yyyy";
            this.dtpYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYear.Location = new System.Drawing.Point(195, 36);
            this.dtpYear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpYear.Name = "dtpYear";
            this.dtpYear.ShowUpDown = true;
            this.dtpYear.Size = new System.Drawing.Size(70, 24);
            this.dtpYear.TabIndex = 14;
            this.dtpYear.ValueChanged += new System.EventHandler(this.dtpYear_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(176, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "‒";
            // 
            // dtpMonth
            // 
            this.dtpMonth.CustomFormat = "MM";
            this.dtpMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonth.Location = new System.Drawing.Point(120, 36);
            this.dtpMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpMonth.Name = "dtpMonth";
            this.dtpMonth.ShowUpDown = true;
            this.dtpMonth.Size = new System.Drawing.Size(52, 24);
            this.dtpMonth.TabIndex = 13;
            this.dtpMonth.ValueChanged += new System.EventHandler(this.dtpMonth_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tháng - Năm";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(42, 128);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 18);
            this.label5.TabIndex = 17;
            this.label5.Text = "Đến ngày";
            // 
            // btnDeductionPTV
            // 
            this.btnDeductionPTV.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeductionPTV.Location = new System.Drawing.Point(346, 128);
            this.btnDeductionPTV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeductionPTV.Name = "btnDeductionPTV";
            this.btnDeductionPTV.Size = new System.Drawing.Size(140, 35);
            this.btnDeductionPTV.TabIndex = 18;
            this.btnDeductionPTV.Text = "Giảm từ PTV";
            this.btnDeductionPTV.UseVisualStyleBackColor = true;
            this.btnDeductionPTV.Click += new System.EventHandler(this.btnDeductionPTV_Click);
            // 
            // btnEditCriteria
            // 
            this.btnEditCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditCriteria.Location = new System.Drawing.Point(347, 36);
            this.btnEditCriteria.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditCriteria.Name = "btnEditCriteria";
            this.btnEditCriteria.Size = new System.Drawing.Size(139, 35);
            this.btnEditCriteria.TabIndex = 19;
            this.btnEditCriteria.Text = "Nhập chỉ tiêu";
            this.btnEditCriteria.UseVisualStyleBackColor = true;
            this.btnEditCriteria.Click += new System.EventHandler(this.btnEditCriteria_Click);
            // 
            // ReportBroadcastForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(514, 282);
            this.Controls.Add(this.btnEditCriteria);
            this.Controls.Add(this.btnDeductionPTV);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDeduction);
            this.Controls.Add(this.dtpMonth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpYear);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.edtPrice);
            this.Controls.Add(this.dtpEnddate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpStartdate);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "ReportBroadcastForm";
            this.Text = "Báo cáo tin thời sự";
            ((System.ComponentModel.ISupportInitialize)(this.edtPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpMonth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpStartdate;
        private System.Windows.Forms.DateTimePicker dtpEnddate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown edtPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnDeduction;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDeductionPTV;
        private System.Windows.Forms.Button btnEditCriteria;
    }
}