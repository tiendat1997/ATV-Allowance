namespace ATV_Allowance.Forms.ArticleForms
{
    partial class EditTSForm
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
            this.txtDate = new System.Windows.Forms.TextBox();
            this.dgvList = new System.Windows.Forms.GroupBox();
            this.adgvList = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.gbArticleTitle.SuspendLayout();
            this.dgvList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvList)).BeginInit();
            this.gbControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbArticleTitle
            // 
            this.gbArticleTitle.Controls.Add(this.txtTitle);
            this.gbArticleTitle.Controls.Add(this.txtDate);
            this.gbArticleTitle.Location = new System.Drawing.Point(13, 12);
            this.gbArticleTitle.Name = "gbArticleTitle";
            this.gbArticleTitle.Size = new System.Drawing.Size(775, 56);
            this.gbArticleTitle.TabIndex = 0;
            this.gbArticleTitle.TabStop = false;
            this.gbArticleTitle.Text = "Tiêu đề";
            // 
            // txtDate
            // 
            this.txtDate.Enabled = false;
            this.txtDate.Location = new System.Drawing.Point(650, 22);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(119, 26);
            this.txtDate.TabIndex = 1;
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
            // adgvList
            // 
            this.adgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvList.Location = new System.Drawing.Point(1, 26);
            this.adgvList.Name = "adgvList";
            this.adgvList.Size = new System.Drawing.Size(775, 270);
            this.adgvList.TabIndex = 0;
            this.adgvList.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.adgvList_EditingControlShowing);
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
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(7, 22);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(606, 26);
            this.txtTitle.TabIndex = 2;
            // 
            // EditTSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.gbArticleTitle);
            this.Name = "EditTSForm";
            this.Text = "Nhập tin thời sự";
            this.Load += new System.EventHandler(this.EditTSForm_Load);
            this.gbArticleTitle.ResumeLayout(false);
            this.gbArticleTitle.PerformLayout();
            this.dgvList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adgvList)).EndInit();
            this.gbControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbArticleTitle;
        private System.Windows.Forms.GroupBox dgvList;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.DataGridView adgvList;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtTitle;
    }
}