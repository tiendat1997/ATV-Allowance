namespace ATV_Allowance.Forms.DeductionForms
{
    partial class KTDEmployeeDeduction
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
            this.gbFilters = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.dtpMonth = new System.Windows.Forms.DateTimePicker();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.adgvDeduction = new System.Windows.Forms.DataGridView();
            this.gbFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvDeduction)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilters
            // 
            this.gbFilters.Controls.Add(this.btnSave);
            this.gbFilters.Controls.Add(this.lblYear);
            this.gbFilters.Controls.Add(this.lblMonth);
            this.gbFilters.Controls.Add(this.dtpMonth);
            this.gbFilters.Controls.Add(this.dtp);
            this.gbFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbFilters.Location = new System.Drawing.Point(0, 0);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.Size = new System.Drawing.Size(800, 68);
            this.gbFilters.TabIndex = 0;
            this.gbFilters.TabStop = false;
            this.gbFilters.Text = "Bộ lọc";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(699, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 35);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(143, 30);
            this.lblYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(42, 20);
            this.lblYear.TabIndex = 17;
            this.lblYear.Text = "Năm";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(12, 30);
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
            this.dtpMonth.Location = new System.Drawing.Point(71, 27);
            this.dtpMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpMonth.Name = "dtpMonth";
            this.dtpMonth.ShowUpDown = true;
            this.dtpMonth.Size = new System.Drawing.Size(64, 26);
            this.dtpMonth.TabIndex = 15;
            this.dtpMonth.ValueChanged += new System.EventHandler(this.dtpMonth_ValueChanged);
            // 
            // dtp
            // 
            this.dtp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtp.CustomFormat = "yyyy";
            this.dtp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp.Location = new System.Drawing.Point(193, 27);
            this.dtp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtp.Name = "dtp";
            this.dtp.ShowUpDown = true;
            this.dtp.Size = new System.Drawing.Size(96, 26);
            this.dtp.TabIndex = 14;
            this.dtp.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
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
            this.adgvDeduction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adgvDeduction.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.adgvDeduction.Location = new System.Drawing.Point(0, 68);
            this.adgvDeduction.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.adgvDeduction.MultiSelect = false;
            this.adgvDeduction.Name = "adgvDeduction";
            this.adgvDeduction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.adgvDeduction.Size = new System.Drawing.Size(800, 393);
            this.adgvDeduction.TabIndex = 9;
            this.adgvDeduction.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.adgvDeduction_CellEnter);
            this.adgvDeduction.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.adgvDeduction_DataError);
            // 
            // KTDEmployeeDeduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 461);
            this.Controls.Add(this.adgvDeduction);
            this.Controls.Add(this.gbFilters);
            this.Name = "KTDEmployeeDeduction";
            this.Text = "Nhập giảm trừ kĩ thuật dựng";
            this.gbFilters.ResumeLayout(false);
            this.gbFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvDeduction)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilters;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.DateTimePicker dtpMonth;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.DataGridView adgvDeduction;
        private System.Windows.Forms.Button btnSave;
    }
}