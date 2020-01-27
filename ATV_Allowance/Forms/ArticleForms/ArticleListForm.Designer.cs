namespace ATV_Allowance.Forms.ArticleForms
{
    partial class ArticleListForm
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
            this.adgvList = new ADGV.AdvancedDataGridView();
            this.btnSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.adgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // adgvList
            // 
            this.adgvList.AllowUserToAddRows = false;
            this.adgvList.AllowUserToDeleteRows = false;
            this.adgvList.AutoGenerateContextFilters = true;
            this.adgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvList.DateWithTime = false;
            this.adgvList.Location = new System.Drawing.Point(13, 14);
            this.adgvList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.adgvList.Name = "adgvList";
            this.adgvList.ReadOnly = true;
            this.adgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.adgvList.Size = new System.Drawing.Size(848, 412);
            this.adgvList.TabIndex = 1;
            this.adgvList.TimeFilter = false;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(762, 434);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 32);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "Chọn";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // ArticleListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 476);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.adgvList);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "ArticleListForm";
            this.Text = "ArticleListForm";
            ((System.ComponentModel.ISupportInitialize)(this.adgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ADGV.AdvancedDataGridView adgvList;
        private System.Windows.Forms.Button btnSelect;
    }
}