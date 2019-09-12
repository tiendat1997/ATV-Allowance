namespace ATV_Allowance.Forms.ArticleForms
{
    partial class AddTSForm
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
            this.gbArticleTitle = new System.Windows.Forms.GroupBox();
            this.btnAddArticle = new System.Windows.Forms.Button();
            this.cbTitle = new System.Windows.Forms.ComboBox();
            this.dgvList = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.adgvList = new System.Windows.Forms.DataGridView();
            this.gbArticleTitle.SuspendLayout();
            this.dgvList.SuspendLayout();
            this.gbControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // gbArticleTitle
            // 
            this.gbArticleTitle.Controls.Add(this.btnAddArticle);
            this.gbArticleTitle.Controls.Add(this.cbTitle);
            this.gbArticleTitle.Location = new System.Drawing.Point(13, 12);
            this.gbArticleTitle.Name = "gbArticleTitle";
            this.gbArticleTitle.Size = new System.Drawing.Size(775, 56);
            this.gbArticleTitle.TabIndex = 0;
            this.gbArticleTitle.TabStop = false;
            this.gbArticleTitle.Text = "Tìm kiếm";
            // 
            // btnAddArticle
            // 
            this.btnAddArticle.Location = new System.Drawing.Point(676, 22);
            this.btnAddArticle.Name = "btnAddArticle";
            this.btnAddArticle.Size = new System.Drawing.Size(93, 28);
            this.btnAddArticle.TabIndex = 1;
            this.btnAddArticle.Text = "Thêm tin";
            this.btnAddArticle.UseVisualStyleBackColor = true;
            this.btnAddArticle.Click += new System.EventHandler(this.btnAddArticle_Click);
            // 
            // cbTitle
            // 
            this.cbTitle.FormattingEnabled = true;
            this.cbTitle.Location = new System.Drawing.Point(6, 22);
            this.cbTitle.Name = "cbTitle";
            this.cbTitle.Size = new System.Drawing.Size(630, 28);
            this.cbTitle.TabIndex = 0;
            // 
            // dgvList
            // 
            this.dgvList.Controls.Add(this.adgvList);
            this.dgvList.Location = new System.Drawing.Point(12, 74);
            this.dgvList.Name = "dgvList";
            this.dgvList.Size = new System.Drawing.Size(775, 302);
            this.dgvList.TabIndex = 1;
            this.dgvList.TabStop = false;
            this.dgvList.Text = "Danh sách";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(7, 26);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(156, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // gbControl
            // 
            this.gbControl.Controls.Add(this.btnSave);
            this.gbControl.Location = new System.Drawing.Point(12, 382);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(775, 64);
            this.gbControl.TabIndex = 2;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Thao tác";
            // 
            // adgvList
            // 
            this.adgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvList.Location = new System.Drawing.Point(1, 26);
            this.adgvList.Name = "adgvList";
            this.adgvList.Size = new System.Drawing.Size(775, 270);
            this.adgvList.TabIndex = 0;
            // 
            // AddTSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.gbArticleTitle);
            this.Name = "AddTSForm";
            this.Text = "Nhập tin thời sự";
            this.gbArticleTitle.ResumeLayout(false);
            this.dgvList.ResumeLayout(false);
            this.gbControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbArticleTitle;
        private System.Windows.Forms.Button btnAddArticle;
        private System.Windows.Forms.ComboBox cbTitle;
        private System.Windows.Forms.GroupBox dgvList;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.DataGridView adgvList;
    }
}