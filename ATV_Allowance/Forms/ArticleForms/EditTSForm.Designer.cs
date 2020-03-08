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
            this.components = new System.ComponentModel.Container();
            this.gbArticleTitle = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.adgvList = new System.Windows.Forms.DataGridView();
            this.epTitle = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbArticleTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // gbArticleTitle
            // 
            this.gbArticleTitle.Controls.Add(this.btnSave);
            this.gbArticleTitle.Controls.Add(this.btnRemove);
            this.gbArticleTitle.Controls.Add(this.txtTitle);
            this.gbArticleTitle.Controls.Add(this.txtDate);
            this.gbArticleTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbArticleTitle.Location = new System.Drawing.Point(0, 0);
            this.gbArticleTitle.Name = "gbArticleTitle";
            this.gbArticleTitle.Size = new System.Drawing.Size(894, 56);
            this.gbArticleTitle.TabIndex = 0;
            this.gbArticleTitle.TabStop = false;
            this.gbArticleTitle.Text = "Tiêu đề";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(678, 21);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 28);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(791, 21);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(95, 28);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Xóa";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(8, 22);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(525, 26);
            this.txtTitle.TabIndex = 2;
            // 
            // txtDate
            // 
            this.txtDate.Enabled = false;
            this.txtDate.Location = new System.Drawing.Point(539, 22);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(119, 26);
            this.txtDate.TabIndex = 1;
            // 
            // adgvList
            // 
            this.adgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adgvList.Location = new System.Drawing.Point(0, 56);
            this.adgvList.MultiSelect = false;
            this.adgvList.Name = "adgvList";
            this.adgvList.Size = new System.Drawing.Size(894, 505);
            this.adgvList.TabIndex = 0;
            this.adgvList.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.adgvList_DataError);
            this.adgvList.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.adgvList_EditingControlShowing);
            this.adgvList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.adgvList_RowEnter);
            this.adgvList.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.adgvList_RowValidated);
            this.adgvList.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.adgvList_RowValidating);
            this.adgvList.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.adgvList_UserDeletedRow);
            this.adgvList.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.adgvList_UserDeletingRow);
            this.adgvList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.adgvList_KeyDown);
            // 
            // epTitle
            // 
            this.epTitle.ContainerControl = this;
            // 
            // EditTSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 561);
            this.Controls.Add(this.adgvList);
            this.Controls.Add(this.gbArticleTitle);
            this.Name = "EditTSForm";
            this.Text = "Nhập tin thời sự";
            this.Load += new System.EventHandler(this.EditTSForm_Load);
            this.gbArticleTitle.ResumeLayout(false);
            this.gbArticleTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTitle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbArticleTitle;
        private System.Windows.Forms.DataGridView adgvList;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.ErrorProvider epTitle;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSave;
    }
}