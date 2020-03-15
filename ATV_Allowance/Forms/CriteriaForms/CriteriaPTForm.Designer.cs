namespace ATV_Allowance.Forms.CriteriaForms
{
    partial class CriteriaPTForm
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
            this.btnCopyCriteria = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbArticleType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpYear = new System.Windows.Forms.DateTimePicker();
            this.adgvCriterias = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvCriterias)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCopyCriteria
            // 
            this.btnCopyCriteria.Location = new System.Drawing.Point(407, 3);
            this.btnCopyCriteria.Name = "btnCopyCriteria";
            this.btnCopyCriteria.Size = new System.Drawing.Size(226, 35);
            this.btnCopyCriteria.TabIndex = 13;
            this.btnCopyCriteria.Text = "Copy chỉ tiêu từ năm cũ qua";
            this.btnCopyCriteria.UseVisualStyleBackColor = true;
            this.btnCopyCriteria.Click += new System.EventHandler(this.btnCopyCriteria_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.cbArticleType);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.dtpYear);
            this.flowLayoutPanel1.Controls.Add(this.btnCopyCriteria);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(894, 42);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ CHỈ TIÊU";
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
            this.cbArticleType.Location = new System.Drawing.Point(161, 6);
            this.cbArticleType.Name = "cbArticleType";
            this.cbArticleType.Size = new System.Drawing.Size(121, 28);
            this.cbArticleType.TabIndex = 6;
            this.cbArticleType.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(288, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Năm";
            // 
            // dtpYear
            // 
            this.dtpYear.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpYear.CustomFormat = "yyyy";
            this.dtpYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYear.Location = new System.Drawing.Point(336, 7);
            this.dtpYear.Name = "dtpYear";
            this.dtpYear.ShowUpDown = true;
            this.dtpYear.Size = new System.Drawing.Size(65, 26);
            this.dtpYear.TabIndex = 5;
            // 
            // adgvCriterias
            // 
            this.adgvCriterias.AllowUserToAddRows = false;
            this.adgvCriterias.AllowUserToDeleteRows = false;
            this.adgvCriterias.AllowUserToOrderColumns = true;
            this.adgvCriterias.AllowUserToResizeRows = false;
            this.adgvCriterias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.adgvCriterias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvCriterias.Location = new System.Drawing.Point(0, 44);
            this.adgvCriterias.MultiSelect = false;
            this.adgvCriterias.Name = "adgvCriterias";
            this.adgvCriterias.ReadOnly = true;
            this.adgvCriterias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.adgvCriterias.Size = new System.Drawing.Size(894, 397);
            this.adgvCriterias.TabIndex = 11;
            this.adgvCriterias.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.adgvCriterias_CellDoubleClick);
            // 
            // CriteriaPTForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 441);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.adgvCriterias);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "CriteriaPTForm";
            this.Text = "Quản lý chỉ tiêu phát thanh";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvCriterias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCopyCriteria;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbArticleType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpYear;
        private System.Windows.Forms.DataGridView adgvCriterias;
    }
}