namespace ATV_Allowance.Forms.ArticleForms
{
    partial class AddArticleForm
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
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gbOrgInfo = new System.Windows.Forms.GroupBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbControl.SuspendLayout();
            this.gbOrgInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbControl
            // 
            this.gbControl.Controls.Add(this.btnAdd);
            this.gbControl.Location = new System.Drawing.Point(14, 169);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(587, 62);
            this.gbControl.TabIndex = 3;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Thao tác";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(10, 26);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 30);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gbOrgInfo
            // 
            this.gbOrgInfo.Controls.Add(this.dtpDate);
            this.gbOrgInfo.Controls.Add(this.lblDate);
            this.gbOrgInfo.Controls.Add(this.txtTitle);
            this.gbOrgInfo.Controls.Add(this.lblTitle);
            this.gbOrgInfo.Location = new System.Drawing.Point(12, 12);
            this.gbOrgInfo.Name = "gbOrgInfo";
            this.gbOrgInfo.Size = new System.Drawing.Size(588, 139);
            this.gbOrgInfo.TabIndex = 2;
            this.gbOrgInfo.TabStop = false;
            this.gbOrgInfo.Text = "Thông tin";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(78, 37);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(125, 26);
            this.dtpDate.TabIndex = 3;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(8, 37);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(45, 20);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Ngày";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(78, 81);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(504, 26);
            this.txtTitle.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(8, 84);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(61, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Tiêu đề";
            // 
            // AddArticleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 244);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.gbOrgInfo);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "AddArticleForm";
            this.Text = "Thêm tin thời sự";
            this.Load += new System.EventHandler(this.AddArticleForm_Load);
            this.gbControl.ResumeLayout(false);
            this.gbOrgInfo.ResumeLayout(false);
            this.gbOrgInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox gbOrgInfo;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDate;
    }
}