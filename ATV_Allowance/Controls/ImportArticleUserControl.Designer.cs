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
            this.btnAdd = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblOrdinal = new System.Windows.Forms.Label();
            this.gbList = new System.Windows.Forms.GroupBox();
            this.cbArticle = new System.Windows.Forms.ComboBox();
            this.lblIndex = new System.Windows.Forms.Label();
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
            this.gbArticleTitle.Location = new System.Drawing.Point(2, 2);
            this.gbArticleTitle.Margin = new System.Windows.Forms.Padding(2);
            this.gbArticleTitle.Name = "gbArticleTitle";
            this.gbArticleTitle.Padding = new System.Windows.Forms.Padding(2);
            this.gbArticleTitle.Size = new System.Drawing.Size(622, 44);
            this.gbArticleTitle.TabIndex = 0;
            this.gbArticleTitle.TabStop = false;
            this.gbArticleTitle.Text = "Thao tác";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(542, 16);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(229, 16);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(2);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(308, 20);
            this.txtTitle.TabIndex = 2;
            this.txtTitle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTitle_KeyPress);
            // 
            // lblOrdinal
            // 
            this.lblOrdinal.AutoSize = true;
            this.lblOrdinal.Location = new System.Drawing.Point(551, 10);
            this.lblOrdinal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOrdinal.Name = "lblOrdinal";
            this.lblOrdinal.Size = new System.Drawing.Size(31, 13);
            this.lblOrdinal.TabIndex = 4;
            this.lblOrdinal.Text = "STT:";
            this.lblOrdinal.Click += new System.EventHandler(this.lblOrdinal_Click);
            // 
            // gbList
            // 
            this.gbList.Controls.Add(this.cbArticle);
            this.gbList.Controls.Add(this.lblIndex);
            this.gbList.Controls.Add(this.adgvList);
            this.gbList.Controls.Add(this.lblOrdinal);
            this.gbList.Location = new System.Drawing.Point(2, 59);
            this.gbList.Margin = new System.Windows.Forms.Padding(2);
            this.gbList.Name = "gbList";
            this.gbList.Padding = new System.Windows.Forms.Padding(2);
            this.gbList.Size = new System.Drawing.Size(622, 327);
            this.gbList.TabIndex = 1;
            this.gbList.TabStop = false;
            this.gbList.Text = "Danh sách";
            // 
            // cbArticle
            // 
            this.cbArticle.FormattingEnabled = true;
            this.cbArticle.Location = new System.Drawing.Point(229, 7);
            this.cbArticle.Name = "cbArticle";
            this.cbArticle.Size = new System.Drawing.Size(308, 21);
            this.cbArticle.TabIndex = 6;
            this.cbArticle.SelectedIndexChanged += new System.EventHandler(this.cbArticle_SelectedIndexChanged);
            // 
            // lblIndex
            // 
            this.lblIndex.AutoSize = true;
            this.lblIndex.Location = new System.Drawing.Point(584, 10);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(35, 13);
            this.lblIndex.TabIndex = 5;
            this.lblIndex.Text = "label1";
            // 
            // adgvList
            // 
            this.adgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvList.Location = new System.Drawing.Point(4, 32);
            this.adgvList.Margin = new System.Windows.Forms.Padding(2);
            this.adgvList.MultiSelect = false;
            this.adgvList.Name = "adgvList";
            this.adgvList.Size = new System.Drawing.Size(614, 291);
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
            // ImportArticleUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbList);
            this.Controls.Add(this.gbArticleTitle);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ImportArticleUserControl";
            this.Size = new System.Drawing.Size(626, 388);
            this.Load += new System.EventHandler(this.EditTSForm_Load);
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
        private System.Windows.Forms.Label lblIndex;
        private System.Windows.Forms.ComboBox cbArticle;
    }
}
