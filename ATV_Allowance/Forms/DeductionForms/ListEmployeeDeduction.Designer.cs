namespace ATV_Allowance.Forms.DeductionForms
{
    partial class ListEmployeeDeduction
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbArticleType = new System.Windows.Forms.ComboBox();
            this.cbEmpRole = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpMonth = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.adgvDeduction = new ADGV.AdvancedDataGridView();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvDeduction)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.cbArticleType);
            this.flowLayoutPanel1.Controls.Add(this.cbEmpRole);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.dtpMonth);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.dtp);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(690, 33);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ GIẢM TRỪ";
            // 
            // cbArticleType
            // 
            this.cbArticleType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbArticleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbArticleType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbArticleType.FormattingEnabled = true;
            this.cbArticleType.Items.AddRange(new object[] {
            "Thời sự",
            "Phát thanh"});
            this.cbArticleType.Location = new System.Drawing.Point(171, 3);
            this.cbArticleType.Name = "cbArticleType";
            this.cbArticleType.Size = new System.Drawing.Size(121, 28);
            this.cbArticleType.TabIndex = 6;
            this.cbArticleType.SelectedIndexChanged += new System.EventHandler(this.cbArticleType_SelectedIndexChanged);
            // 
            // cbEmpRole
            // 
            this.cbEmpRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEmpRole.FormattingEnabled = true;
            this.cbEmpRole.Items.AddRange(new object[] {
            "PV",
            "PTV"});
            this.cbEmpRole.Location = new System.Drawing.Point(298, 3);
            this.cbEmpRole.Name = "cbEmpRole";
            this.cbEmpRole.Size = new System.Drawing.Size(121, 28);
            this.cbEmpRole.TabIndex = 7;
            this.cbEmpRole.SelectedIndexChanged += new System.EventHandler(this.cbEmpRole_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(425, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tháng";
            // 
            // dtpMonth
            // 
            this.dtpMonth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpMonth.CustomFormat = "MM";
            this.dtpMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonth.Location = new System.Drawing.Point(485, 4);
            this.dtpMonth.Name = "dtpMonth";
            this.dtpMonth.ShowUpDown = true;
            this.dtpMonth.Size = new System.Drawing.Size(44, 26);
            this.dtpMonth.TabIndex = 9;
            this.dtpMonth.ValueChanged += new System.EventHandler(this.dtpMonth_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(535, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Năm";
            // 
            // dtp
            // 
            this.dtp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtp.CustomFormat = "yyyy";
            this.dtp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp.Location = new System.Drawing.Point(583, 4);
            this.dtp.Name = "dtp";
            this.dtp.ShowUpDown = true;
            this.dtp.Size = new System.Drawing.Size(65, 26);
            this.dtp.TabIndex = 5;
            this.dtp.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
            // 
            // adgvDeduction
            // 
            this.adgvDeduction.AllowUserToAddRows = false;
            this.adgvDeduction.AllowUserToDeleteRows = false;
            this.adgvDeduction.AllowUserToOrderColumns = true;
            this.adgvDeduction.AllowUserToResizeColumns = false;
            this.adgvDeduction.AllowUserToResizeRows = false;
            this.adgvDeduction.AutoGenerateContextFilters = true;
            this.adgvDeduction.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.adgvDeduction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvDeduction.DateWithTime = false;
            this.adgvDeduction.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.adgvDeduction.Location = new System.Drawing.Point(12, 51);
            this.adgvDeduction.MultiSelect = false;
            this.adgvDeduction.Name = "adgvDeduction";
            this.adgvDeduction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.adgvDeduction.Size = new System.Drawing.Size(648, 314);
            this.adgvDeduction.TabIndex = 8;
            this.adgvDeduction.TimeFilter = false;
            // 
            // ListEmployeeDeduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 377);
            this.Controls.Add(this.adgvDeduction);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ListEmployeeDeduction";
            this.Text = "ListEmployeeDeduction";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvDeduction)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbArticleType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.ComboBox cbEmpRole;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpMonth;
        private ADGV.AdvancedDataGridView adgvDeduction;
    }
}