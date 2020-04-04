namespace ATV_Allowance.Controls
{
    partial class ImportArticleUserControl
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
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbArticle = new System.Windows.Forms.ComboBox();
            this.lblIndex = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblOrdinal = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.adgvList = new System.Windows.Forms.DataGridView();
            this.epTitle = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnDeleteArticle = new System.Windows.Forms.Button();
            this.gbArticleTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // gbArticleTitle
            // 
            this.gbArticleTitle.Controls.Add(this.btnDeleteArticle);
            this.gbArticleTitle.Controls.Add(this.lblSearch);
            this.gbArticleTitle.Controls.Add(this.lblTitle);
            this.gbArticleTitle.Controls.Add(this.btnAdd);
            this.gbArticleTitle.Controls.Add(this.cbArticle);
            this.gbArticleTitle.Controls.Add(this.lblIndex);
            this.gbArticleTitle.Controls.Add(this.dtpDate);
            this.gbArticleTitle.Controls.Add(this.lblOrdinal);
            this.gbArticleTitle.Controls.Add(this.txtTitle);
            this.gbArticleTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbArticleTitle.Location = new System.Drawing.Point(0, 0);
            this.gbArticleTitle.Margin = new System.Windows.Forms.Padding(2);
            this.gbArticleTitle.Name = "gbArticleTitle";
            this.gbArticleTitle.Padding = new System.Windows.Forms.Padding(2);
            this.gbArticleTitle.Size = new System.Drawing.Size(604, 74);
            this.gbArticleTitle.TabIndex = 0;
            this.gbArticleTitle.TabStop = false;
            this.gbArticleTitle.Text = "Thao tác";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(124, 50);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(49, 13);
            this.lblSearch.TabIndex = 11;
            this.lblSearch.Text = "Tìm kiếm";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(129, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(44, 13);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "Tiêu đề";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(515, 14);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 22);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbArticle
            // 
            this.cbArticle.FormattingEnabled = true;
            this.cbArticle.Location = new System.Drawing.Point(178, 47);
            this.cbArticle.Name = "cbArticle";
            this.cbArticle.Size = new System.Drawing.Size(332, 21);
            this.cbArticle.TabIndex = 6;
            this.cbArticle.SelectedIndexChanged += new System.EventHandler(this.cbArticle_SelectedIndexChanged);
            this.cbArticle.SelectionChangeCommitted += new System.EventHandler(this.cbArticle_SelectionChangeCommitted);
            // 
            // lblIndex
            // 
            this.lblIndex.AutoSize = true;
            this.lblIndex.Location = new System.Drawing.Point(99, 50);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(16, 13);
            this.lblIndex.TabIndex = 5;
            this.lblIndex.Text = "or";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(10, 16);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(89, 20);
            this.dtpDate.TabIndex = 6;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // lblOrdinal
            // 
            this.lblOrdinal.AutoSize = true;
            this.lblOrdinal.Location = new System.Drawing.Point(68, 50);
            this.lblOrdinal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOrdinal.Name = "lblOrdinal";
            this.lblOrdinal.Size = new System.Drawing.Size(31, 13);
            this.lblOrdinal.TabIndex = 4;
            this.lblOrdinal.Text = "STT:";
            this.lblOrdinal.Click += new System.EventHandler(this.lblOrdinal_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(178, 16);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(2);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(332, 20);
            this.txtTitle.TabIndex = 2;
            this.txtTitle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTitle_KeyPress);
            // 
            // adgvList
            // 
            this.adgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adgvList.Location = new System.Drawing.Point(0, 74);
            this.adgvList.Margin = new System.Windows.Forms.Padding(2);
            this.adgvList.MultiSelect = false;
            this.adgvList.Name = "adgvList";
            this.adgvList.Size = new System.Drawing.Size(604, 314);
            this.adgvList.TabIndex = 0;
            this.adgvList.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.adgvList_DataError);
            this.adgvList.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.adgvList_EditingControlShowing);
            this.adgvList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.adgvList_RowEnter);
            this.adgvList.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.adgvList_RowValidated);
            this.adgvList.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.adgvList_RowValidating);
            this.adgvList.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.adgvList_UserDeletingRow);
            // 
            // epTitle
            // 
            this.epTitle.ContainerControl = this;
            // 
            // btnDeleteArticle
            // 
            this.btnDeleteArticle.Location = new System.Drawing.Point(515, 46);
            this.btnDeleteArticle.Name = "btnDeleteArticle";
            this.btnDeleteArticle.Size = new System.Drawing.Size(75, 22);
            this.btnDeleteArticle.TabIndex = 12;
            this.btnDeleteArticle.Text = "Xóa tin";
            this.btnDeleteArticle.UseVisualStyleBackColor = true;
            this.btnDeleteArticle.Click += new System.EventHandler(this.btnDeleteArticle_Click);
            // 
            // ImportArticleUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.adgvList);
            this.Controls.Add(this.gbArticleTitle);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ImportArticleUserControl";
            this.Size = new System.Drawing.Size(604, 388);
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
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.ErrorProvider epTitle;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblOrdinal;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblIndex;
        private System.Windows.Forms.ComboBox cbArticle;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnDeleteArticle;
    }
}
