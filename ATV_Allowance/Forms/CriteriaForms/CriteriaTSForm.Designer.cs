namespace ATV_Allowance.Forms.CriteriaForms
{
    partial class CriteriaTSForm
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
            this.btnCopyCriteria = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpYear = new System.Windows.Forms.DateTimePicker();
            this.adgvCriterias = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvCriterias)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ CHỈ TIÊU THỜI SỰ";
            // 
            // btnCopyCriteria
            // 
            this.btnCopyCriteria.Location = new System.Drawing.Point(624, 18);
            this.btnCopyCriteria.Name = "btnCopyCriteria";
            this.btnCopyCriteria.Size = new System.Drawing.Size(226, 29);
            this.btnCopyCriteria.TabIndex = 10;
            this.btnCopyCriteria.Text = "Copy chỉ tiêu từ năm cũ qua";
            this.btnCopyCriteria.UseVisualStyleBackColor = true;
            this.btnCopyCriteria.Click += new System.EventHandler(this.btnCopyCriteria_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.dtpYear);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(407, 33);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(230, 6);
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
            this.dtpYear.Location = new System.Drawing.Point(278, 3);
            this.dtpYear.Name = "dtpYear";
            this.dtpYear.ShowUpDown = true;
            this.dtpYear.Size = new System.Drawing.Size(65, 26);
            this.dtpYear.TabIndex = 5;
            this.dtpYear.ValueChanged += new System.EventHandler(this.dtpYear_ValueChanged);
            // 
            // adgvCriterias
            // 
            this.adgvCriterias.AllowUserToAddRows = false;
            this.adgvCriterias.AllowUserToDeleteRows = false;
            this.adgvCriterias.AllowUserToOrderColumns = true;
            this.adgvCriterias.AllowUserToResizeRows = false;
            this.adgvCriterias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.adgvCriterias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvCriterias.Location = new System.Drawing.Point(3, 60);
            this.adgvCriterias.MultiSelect = false;
            this.adgvCriterias.Name = "adgvCriterias";
            this.adgvCriterias.ReadOnly = true;
            this.adgvCriterias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.adgvCriterias.Size = new System.Drawing.Size(855, 366);
            this.adgvCriterias.TabIndex = 8;
            this.adgvCriterias.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.adgvCriterias_CellDoubleClick);
            // 
            // CriteriaTSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 430);
            this.Controls.Add(this.btnCopyCriteria);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.adgvCriterias);
            this.Name = "CriteriaTSForm";
            this.Text = "Quản lý chỉ tiêu thời sự truyền hình";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvCriterias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCopyCriteria;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpYear;
        private System.Windows.Forms.DataGridView adgvCriterias;
    }
}