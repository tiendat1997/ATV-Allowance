namespace ATV_Allowance.Forms.CriteriaForms
{
    partial class ListCriteriaForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.adgvCriterias = new ADGV.AdvancedDataGridView();
            this.gbCriterias = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.fpCriteriaList = new System.Windows.Forms.FlowLayoutPanel();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbArticleType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.adgvCriterias)).BeginInit();
            this.gbCriterias.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ CHỈ TIÊU";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(288, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Năm";
            // 
            // adgvCriterias
            // 
            this.adgvCriterias.AllowUserToAddRows = false;
            this.adgvCriterias.AllowUserToDeleteRows = false;
            this.adgvCriterias.AllowUserToOrderColumns = true;
            this.adgvCriterias.AllowUserToResizeColumns = false;
            this.adgvCriterias.AllowUserToResizeRows = false;
            this.adgvCriterias.AutoGenerateContextFilters = true;
            this.adgvCriterias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvCriterias.DateWithTime = false;
            this.adgvCriterias.Location = new System.Drawing.Point(17, 60);
            this.adgvCriterias.MultiSelect = false;
            this.adgvCriterias.Name = "adgvCriterias";
            this.adgvCriterias.ReadOnly = true;
            this.adgvCriterias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.adgvCriterias.Size = new System.Drawing.Size(481, 324);
            this.adgvCriterias.TabIndex = 3;
            this.adgvCriterias.TimeFilter = false;
            this.adgvCriterias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.adgvCriterias_CellClick);
            // 
            // gbCriterias
            // 
            this.gbCriterias.Controls.Add(this.panel1);
            this.gbCriterias.Controls.Add(this.fpCriteriaList);
            this.gbCriterias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCriterias.Location = new System.Drawing.Point(517, 13);
            this.gbCriterias.Name = "gbCriterias";
            this.gbCriterias.Size = new System.Drawing.Size(318, 382);
            this.gbCriterias.TabIndex = 4;
            this.gbCriterias.TabStop = false;
            this.gbCriterias.Text = "Quản lý chỉ tiêu tháng 9 / 2018";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 356);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 23);
            this.panel1.TabIndex = 1;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(216, 0);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Lưu";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // fpCriteriaList
            // 
            this.fpCriteriaList.AutoSize = true;
            this.fpCriteriaList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpCriteriaList.Location = new System.Drawing.Point(3, 19);
            this.fpCriteriaList.Name = "fpCriteriaList";
            this.fpCriteriaList.Size = new System.Drawing.Size(312, 360);
            this.fpCriteriaList.TabIndex = 0;
            // 
            // dtp
            // 
            this.dtp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtp.CustomFormat = "yyyy";
            this.dtp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp.Location = new System.Drawing.Point(336, 3);
            this.dtp.Name = "dtp";
            this.dtp.ShowUpDown = true;
            this.dtp.Size = new System.Drawing.Size(65, 26);
            this.dtp.TabIndex = 5;
            this.dtp.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.cbArticleType);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.dtp);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(17, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(454, 33);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // cbArticleType
            // 
            this.cbArticleType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbArticleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbArticleType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbArticleType.FormattingEnabled = true;
            this.cbArticleType.Items.AddRange(new object[] {
            "Phát thanh trực tiếp",
            "Phát thanh",
            "Thời sự"});
            this.cbArticleType.Location = new System.Drawing.Point(161, 5);
            this.cbArticleType.Name = "cbArticleType";
            this.cbArticleType.Size = new System.Drawing.Size(121, 28);
            this.cbArticleType.TabIndex = 6;
            this.cbArticleType.Visible = false;
            this.cbArticleType.SelectedIndexChanged += new System.EventHandler(this.cbArticleType_SelectedIndexChanged);
            // 
            // ListCriteriaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 407);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.gbCriterias);
            this.Controls.Add(this.adgvCriterias);
            this.Name = "ListCriteriaForm";
            this.Text = "ListCriteriaForm";
            ((System.ComponentModel.ISupportInitialize)(this.adgvCriterias)).EndInit();
            this.gbCriterias.ResumeLayout(false);
            this.gbCriterias.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ADGV.AdvancedDataGridView adgvCriterias;
        private System.Windows.Forms.GroupBox gbCriterias;
        private System.Windows.Forms.FlowLayoutPanel fpCriteriaList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox cbArticleType;
    }
}