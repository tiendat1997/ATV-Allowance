namespace ATV_Allowance.Forms.OrganizationForms
{
    partial class AddOrganizationForm
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
            this.gbOrgInfo = new System.Windows.Forms.GroupBox();
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gbOrgInfo.SuspendLayout();
            this.gbControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbOrgInfo
            // 
            this.gbOrgInfo.Controls.Add(this.txtName);
            this.gbOrgInfo.Controls.Add(this.lblName);
            this.gbOrgInfo.Location = new System.Drawing.Point(13, 3);
            this.gbOrgInfo.Name = "gbOrgInfo";
            this.gbOrgInfo.Size = new System.Drawing.Size(389, 87);
            this.gbOrgInfo.TabIndex = 0;
            this.gbOrgInfo.TabStop = false;
            this.gbOrgInfo.Text = "Thông tin";
            // 
            // gbControl
            // 
            this.gbControl.Controls.Add(this.btnAdd);
            this.gbControl.Location = new System.Drawing.Point(13, 96);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(389, 62);
            this.gbControl.TabIndex = 1;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Thao tác";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 31);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(81, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Tên đơn vị";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(10, 54);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(373, 26);
            this.txtName.TabIndex = 1;
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
            // AddOrganizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 170);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.gbOrgInfo);
            this.Name = "AddOrganizationForm";
            this.Text = "AddOrganizationForm";
            this.gbOrgInfo.ResumeLayout(false);
            this.gbOrgInfo.PerformLayout();
            this.gbControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOrgInfo;
        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnAdd;
    }
}