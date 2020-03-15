namespace ATV_Allowance.Forms.ArticleForms
{
    partial class ImportArticleFormAdvance
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
            this.lblIndex = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbArticle = new System.Windows.Forms.ComboBox();
            this.lblOrdinal = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.epTitle = new System.Windows.Forms.ErrorProvider(this.components);
            this.adgvList = new System.Windows.Forms.DataGridView();
            this.gbArticleTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // gbArticleTitle
            // 
            this.gbArticleTitle.Controls.Add(this.lblSearch);
            this.gbArticleTitle.Controls.Add(this.lblTitle);
            this.gbArticleTitle.Controls.Add(this.lblIndex);
            this.gbArticleTitle.Controls.Add(this.btnAdd);
            this.gbArticleTitle.Controls.Add(this.cbArticle);
            this.gbArticleTitle.Controls.Add(this.lblOrdinal);
            this.gbArticleTitle.Controls.Add(this.dtpDate);
            this.gbArticleTitle.Controls.Add(this.txtTitle);
            this.gbArticleTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbArticleTitle.Location = new System.Drawing.Point(0, 0);
            this.gbArticleTitle.Name = "gbArticleTitle";
            this.gbArticleTitle.Size = new System.Drawing.Size(934, 98);
            this.gbArticleTitle.TabIndex = 0;
            this.gbArticleTitle.TabStop = false;
            this.gbArticleTitle.Text = "Thao tác";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(208, 67);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(71, 20);
            this.lblSearch.TabIndex = 9;
            this.lblSearch.Text = "Tìm kiếm";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(218, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(61, 20);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Tiêu đề";
            // 
            // lblIndex
            // 
            this.lblIndex.AutoSize = true;
            this.lblIndex.Location = new System.Drawing.Point(829, 64);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(42, 20);
            this.lblIndex.TabIndex = 5;
            this.lblIndex.Text = "label";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(792, 21);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 28);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnArticleList_Click);
            // 
            // cbArticle
            // 
            this.cbArticle.FormattingEnabled = true;
            this.cbArticle.Location = new System.Drawing.Point(285, 64);
            this.cbArticle.Name = "cbArticle";
            this.cbArticle.Size = new System.Drawing.Size(497, 28);
            this.cbArticle.TabIndex = 1;
            this.cbArticle.SelectedIndexChanged += new System.EventHandler(this.cbArticle_SelectedIndexChanged);
            this.cbArticle.SelectionChangeCommitted += new System.EventHandler(this.cbArticle_SelectionChangeCommitted);
            // 
            // lblOrdinal
            // 
            this.lblOrdinal.AutoSize = true;
            this.lblOrdinal.Location = new System.Drawing.Point(788, 64);
            this.lblOrdinal.Name = "lblOrdinal";
            this.lblOrdinal.Size = new System.Drawing.Size(42, 20);
            this.lblOrdinal.TabIndex = 4;
            this.lblOrdinal.Text = "STT:";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(15, 25);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(132, 26);
            this.dtpDate.TabIndex = 6;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(285, 22);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(497, 26);
            this.txtTitle.TabIndex = 2;
            this.txtTitle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTitle_KeyPress);
            // 
            // epTitle
            // 
            this.epTitle.ContainerControl = this;
            // 
            // adgvList
            // 
            this.adgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adgvList.Location = new System.Drawing.Point(0, 98);
            this.adgvList.MultiSelect = false;
            this.adgvList.Name = "adgvList";
            this.adgvList.Size = new System.Drawing.Size(934, 463);
            this.adgvList.TabIndex = 0;
            this.adgvList.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.adgvList_DataError);
            this.adgvList.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.adgvList_EditingControlShowing);
            this.adgvList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.adgvList_RowEnter);
            this.adgvList.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.adgvList_RowValidated);
            this.adgvList.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.adgvList_RowValidating);
            this.adgvList.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.adgvList_UserDeletingRow);
            this.adgvList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.adgvList_KeyDown);
            // 
            // ImportArticleFormAdvance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 561);
            this.Controls.Add(this.adgvList);
            this.Controls.Add(this.gbArticleTitle);
            this.KeyPreview = true;
            this.Name = "ImportArticleFormAdvance";
            this.Text = "Nhập tin thời sự hàng ngày";
            this.Load += new System.EventHandler(this.EditTSForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ImportArticleFormAdvance_KeyDown);
            this.gbArticleTitle.ResumeLayout(false);
            this.gbArticleTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbArticleTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.ErrorProvider epTitle;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblOrdinal;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblIndex;
        private System.Windows.Forms.ComboBox cbArticle;
        private System.Windows.Forms.DataGridView adgvList;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblTitle;
    }
}