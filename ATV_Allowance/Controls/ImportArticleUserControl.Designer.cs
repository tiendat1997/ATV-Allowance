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
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.nudOrdinal = new System.Windows.Forms.NumericUpDown();
            this.lblOrdinal = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.gbList = new System.Windows.Forms.GroupBox();
            this.adgvList = new System.Windows.Forms.DataGridView();
            this.epTitle = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbArticleTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOrdinal)).BeginInit();
            this.gbList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // gbArticleTitle
            // 
            this.gbArticleTitle.Controls.Add(this.dtpDate);
            this.gbArticleTitle.Controls.Add(this.nudOrdinal);
            this.gbArticleTitle.Controls.Add(this.lblOrdinal);
            this.gbArticleTitle.Controls.Add(this.txtTitle);
            this.gbArticleTitle.Location = new System.Drawing.Point(9, 8);
            this.gbArticleTitle.Margin = new System.Windows.Forms.Padding(2);
            this.gbArticleTitle.Name = "gbArticleTitle";
            this.gbArticleTitle.Padding = new System.Windows.Forms.Padding(2);
            this.gbArticleTitle.Size = new System.Drawing.Size(820, 44);
            this.gbArticleTitle.TabIndex = 0;
            this.gbArticleTitle.TabStop = false;
            this.gbArticleTitle.Text = "Thao tác";
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
            // nudOrdinal
            // 
            this.nudOrdinal.Location = new System.Drawing.Point(363, 16);
            this.nudOrdinal.Margin = new System.Windows.Forms.Padding(2);
            this.nudOrdinal.Name = "nudOrdinal";
            this.nudOrdinal.Size = new System.Drawing.Size(35, 20);
            this.nudOrdinal.TabIndex = 5;
            this.nudOrdinal.ValueChanged += new System.EventHandler(this.nudOrdinal_ValueChanged);
            this.nudOrdinal.Enter += new System.EventHandler(this.nudOrdinal_Enter);
            // 
            // lblOrdinal
            // 
            this.lblOrdinal.AutoSize = true;
            this.lblOrdinal.Location = new System.Drawing.Point(333, 18);
            this.lblOrdinal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOrdinal.Name = "lblOrdinal";
            this.lblOrdinal.Size = new System.Drawing.Size(28, 13);
            this.lblOrdinal.TabIndex = 4;
            this.lblOrdinal.Text = "STT";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(408, 16);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(2);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(403, 20);
            this.txtTitle.TabIndex = 2;
            this.txtTitle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTitle_KeyPress);
            // 
            // gbList
            // 
            this.gbList.Controls.Add(this.adgvList);
            this.gbList.Location = new System.Drawing.Point(9, 62);
            this.gbList.Margin = new System.Windows.Forms.Padding(2);
            this.gbList.Name = "gbList";
            this.gbList.Padding = new System.Windows.Forms.Padding(2);
            this.gbList.Size = new System.Drawing.Size(824, 194);
            this.gbList.TabIndex = 1;
            this.gbList.TabStop = false;
            this.gbList.Text = "Danh sách";
            // 
            // adgvList
            // 
            this.adgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvList.Location = new System.Drawing.Point(4, 16);
            this.adgvList.Margin = new System.Windows.Forms.Padding(2);
            this.adgvList.Name = "adgvList";
            this.adgvList.Size = new System.Drawing.Size(816, 167);
            this.adgvList.TabIndex = 0;
            this.adgvList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.adgvList_CellFormatting);
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
            this.Size = new System.Drawing.Size(846, 268);
            this.Load += new System.EventHandler(this.EditTSForm_Load);
            this.gbArticleTitle.ResumeLayout(false);
            this.gbArticleTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOrdinal)).EndInit();
            this.gbList.ResumeLayout(false);
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
        private System.Windows.Forms.NumericUpDown nudOrdinal;
        private System.Windows.Forms.Label lblOrdinal;
    }
}
