﻿namespace ATV_Allowance.Forms.ArticleForms
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
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.gbList = new System.Windows.Forms.GroupBox();
            this.adgvList = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.epTitle = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbArticleTitle.SuspendLayout();
            this.gbList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // gbArticleTitle
            // 
            this.gbArticleTitle.Controls.Add(this.btnSave);
            this.gbArticleTitle.Controls.Add(this.txtTitle);
            this.gbArticleTitle.Controls.Add(this.txtDate);
            this.gbArticleTitle.Location = new System.Drawing.Point(13, 12);
            this.gbArticleTitle.Name = "gbArticleTitle";
            this.gbArticleTitle.Size = new System.Drawing.Size(1019, 56);
            this.gbArticleTitle.TabIndex = 0;
            this.gbArticleTitle.TabStop = false;
            this.gbArticleTitle.Text = "Tiêu đề";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(7, 22);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(606, 26);
            this.txtTitle.TabIndex = 2;
            // 
            // txtDate
            // 
            this.txtDate.Enabled = false;
            this.txtDate.Location = new System.Drawing.Point(661, 22);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(119, 26);
            this.txtDate.TabIndex = 1;
            // 
            // gbList
            // 
            this.gbList.Controls.Add(this.adgvList);
            this.gbList.Location = new System.Drawing.Point(12, 74);
            this.gbList.Name = "gbList";
            this.gbList.Size = new System.Drawing.Size(1020, 302);
            this.gbList.TabIndex = 1;
            this.gbList.TabStop = false;
            this.gbList.Text = "Danh sách";
            // 
            // adgvList
            // 
            this.adgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvList.Location = new System.Drawing.Point(1, 26);
            this.adgvList.Name = "adgvList";
            this.adgvList.Size = new System.Drawing.Size(1019, 270);
            this.adgvList.TabIndex = 0;
            this.adgvList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.adgvList_CellFormatting);
            this.adgvList.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.adgvList_DataError);
            this.adgvList.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.adgvList_EditingControlShowing);
            this.adgvList.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.adgvList_RowValidated);
            this.adgvList.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.adgvList_RowValidating);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(857, 20);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(156, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // epTitle
            // 
            this.epTitle.ContainerControl = this;
            // 
            // EditTSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 385);
            this.Controls.Add(this.gbList);
            this.Controls.Add(this.gbArticleTitle);
            this.Name = "EditTSForm";
            this.Text = "Nhập tin thời sự";
            this.Load += new System.EventHandler(this.EditTSForm_Load);
            this.gbArticleTitle.ResumeLayout(false);
            this.gbArticleTitle.PerformLayout();
            this.gbList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adgvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTitle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbArticleTitle;
        private System.Windows.Forms.GroupBox gbList;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView adgvList;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.ErrorProvider epTitle;
    }
}