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
            this.btnAdd = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblOrdinal = new System.Windows.Forms.Label();
            this.gbList = new System.Windows.Forms.GroupBox();
            this.lblIndex = new System.Windows.Forms.Label();
            this.cbArticle = new System.Windows.Forms.ComboBox();
            this.adgvList = new System.Windows.Forms.DataGridView();
            this.epTitle = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbArticleTitle.SuspendLayout();
            this.gbList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // gbArticleTitle
            // 
            this.gbArticleTitle.Controls.Add(this.btnAdd);
            this.gbArticleTitle.Controls.Add(this.dtpDate);
            this.gbArticleTitle.Controls.Add(this.txtTitle);
            this.gbArticleTitle.Location = new System.Drawing.Point(19, 12);
            this.gbArticleTitle.Name = "gbArticleTitle";
            this.gbArticleTitle.Size = new System.Drawing.Size(899, 67);
            this.gbArticleTitle.TabIndex = 0;
            this.gbArticleTitle.TabStop = false;
            this.gbArticleTitle.Text = "Thao tác";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(816, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(76, 31);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnArticleList_Click);
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
            this.txtTitle.Location = new System.Drawing.Point(313, 22);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(497, 26);
            this.txtTitle.TabIndex = 2;
            this.txtTitle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTitle_KeyPress);
            // 
            // lblOrdinal
            // 
            this.lblOrdinal.AutoSize = true;
            this.lblOrdinal.Location = new System.Drawing.Point(827, 13);
            this.lblOrdinal.Name = "lblOrdinal";
            this.lblOrdinal.Size = new System.Drawing.Size(42, 20);
            this.lblOrdinal.TabIndex = 4;
            this.lblOrdinal.Text = "STT:";
            // 
            // gbList
            // 
            this.gbList.Controls.Add(this.lblIndex);
            this.gbList.Controls.Add(this.cbArticle);
            this.gbList.Controls.Add(this.adgvList);
            this.gbList.Controls.Add(this.lblOrdinal);
            this.gbList.Location = new System.Drawing.Point(13, 101);
            this.gbList.Name = "gbList";
            this.gbList.Size = new System.Drawing.Size(905, 299);
            this.gbList.TabIndex = 1;
            this.gbList.TabStop = false;
            this.gbList.Text = "Danh sách";
            // 
            // lblIndex
            // 
            this.lblIndex.AutoSize = true;
            this.lblIndex.Location = new System.Drawing.Point(871, 13);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(0, 20);
            this.lblIndex.TabIndex = 5;
            // 
            // cbArticle
            // 
            this.cbArticle.FormattingEnabled = true;
            this.cbArticle.Location = new System.Drawing.Point(319, 5);
            this.cbArticle.Name = "cbArticle";
            this.cbArticle.Size = new System.Drawing.Size(497, 28);
            this.cbArticle.TabIndex = 1;
            this.cbArticle.SelectedIndexChanged += new System.EventHandler(this.cbArticle_SelectedIndexChanged);
            // 
            // adgvList
            // 
            this.adgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvList.Location = new System.Drawing.Point(6, 36);
            this.adgvList.MultiSelect = false;
            this.adgvList.Name = "adgvList";
            this.adgvList.Size = new System.Drawing.Size(892, 257);
            this.adgvList.TabIndex = 0;
            this.adgvList.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.adgvList_DataError);
            this.adgvList.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.adgvList_EditingControlShowing);
            this.adgvList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.adgvList_RowEnter);
            this.adgvList.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.adgvList_RowValidated);
            this.adgvList.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.adgvList_RowValidating);
            this.adgvList.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.adgvList_UserDeletingRow);
            this.adgvList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.adgvList_KeyDown);
            // 
            // epTitle
            // 
            this.epTitle.ContainerControl = this;
            // 
            // ImportArticleFormAdvance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 412);
            this.Controls.Add(this.gbList);
            this.Controls.Add(this.gbArticleTitle);
            this.KeyPreview = true;
            this.Name = "ImportArticleFormAdvance";
            this.Text = "Nhập tin thời sự hàng ngày";
            this.Load += new System.EventHandler(this.EditTSForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ImportArticleFormAdvance_KeyDown);
            this.gbArticleTitle.ResumeLayout(false);
            this.gbArticleTitle.PerformLayout();
            this.gbList.ResumeLayout(false);
            this.gbList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTitle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbArticleTitle;
        private System.Windows.Forms.GroupBox gbList;
        private System.Windows.Forms.DataGridView adgvList;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.ErrorProvider epTitle;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblOrdinal;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cbArticle;
        private System.Windows.Forms.Label lblIndex;
    }
}