namespace ATV_Allowance.Forms.EmployeeForms
{
    partial class AddEmployeeForm
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
            this.gbStudentInfo = new System.Windows.Forms.GroupBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cbOrganizationId = new System.Windows.Forms.ComboBox();
            this.gbPosition = new System.Windows.Forms.GroupBox();
            this.rbKTD = new System.Windows.Forms.RadioButton();
            this.rbPV = new System.Windows.Forms.RadioButton();
            this.rbBTV = new System.Windows.Forms.RadioButton();
            this.rbPTV = new System.Windows.Forms.RadioButton();
            this.rbCTV = new System.Windows.Forms.RadioButton();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblOrganization = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gbStudentInfo.SuspendLayout();
            this.gbPosition.SuspendLayout();
            this.gbControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbStudentInfo
            // 
            this.gbStudentInfo.Controls.Add(this.txtTitle);
            this.gbStudentInfo.Controls.Add(this.lblTitle);
            this.gbStudentInfo.Controls.Add(this.cbOrganizationId);
            this.gbStudentInfo.Controls.Add(this.gbPosition);
            this.gbStudentInfo.Controls.Add(this.txtCode);
            this.gbStudentInfo.Controls.Add(this.txtName);
            this.gbStudentInfo.Controls.Add(this.lblPosition);
            this.gbStudentInfo.Controls.Add(this.lblOrganization);
            this.gbStudentInfo.Controls.Add(this.lblCode);
            this.gbStudentInfo.Controls.Add(this.lblName);
            this.gbStudentInfo.Location = new System.Drawing.Point(20, 20);
            this.gbStudentInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbStudentInfo.Name = "gbStudentInfo";
            this.gbStudentInfo.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbStudentInfo.Size = new System.Drawing.Size(567, 357);
            this.gbStudentInfo.TabIndex = 0;
            this.gbStudentInfo.TabStop = false;
            this.gbStudentInfo.Text = "Thông tin nhân viên";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(168, 236);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(264, 26);
            this.txtTitle.TabIndex = 14;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(14, 242);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(64, 20);
            this.lblTitle.TabIndex = 13;
            this.lblTitle.Text = "Ghi chú";
            // 
            // cbOrganizationId
            // 
            this.cbOrganizationId.FormattingEnabled = true;
            this.cbOrganizationId.Location = new System.Drawing.Point(168, 175);
            this.cbOrganizationId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbOrganizationId.Name = "cbOrganizationId";
            this.cbOrganizationId.Size = new System.Drawing.Size(373, 28);
            this.cbOrganizationId.TabIndex = 12;
            this.cbOrganizationId.TextUpdate += new System.EventHandler(this.cbOrganizationId_TextUpdate);
            // 
            // gbPosition
            // 
            this.gbPosition.Controls.Add(this.rbKTD);
            this.gbPosition.Controls.Add(this.rbPV);
            this.gbPosition.Controls.Add(this.rbBTV);
            this.gbPosition.Controls.Add(this.rbPTV);
            this.gbPosition.Controls.Add(this.rbCTV);
            this.gbPosition.Location = new System.Drawing.Point(166, 274);
            this.gbPosition.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbPosition.Name = "gbPosition";
            this.gbPosition.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbPosition.Size = new System.Drawing.Size(393, 75);
            this.gbPosition.TabIndex = 11;
            this.gbPosition.TabStop = false;
            // 
            // rbKTD
            // 
            this.rbKTD.AutoSize = true;
            this.rbKTD.Location = new System.Drawing.Point(327, 29);
            this.rbKTD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbKTD.Name = "rbKTD";
            this.rbKTD.Size = new System.Drawing.Size(58, 24);
            this.rbKTD.TabIndex = 9;
            this.rbKTD.Text = "KTD";
            this.rbKTD.UseVisualStyleBackColor = true;
            // 
            // rbPV
            // 
            this.rbPV.AutoSize = true;
            this.rbPV.Checked = true;
            this.rbPV.Location = new System.Drawing.Point(9, 29);
            this.rbPV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbPV.Name = "rbPV";
            this.rbPV.Size = new System.Drawing.Size(48, 24);
            this.rbPV.TabIndex = 5;
            this.rbPV.TabStop = true;
            this.rbPV.Text = "PV";
            this.rbPV.UseVisualStyleBackColor = true;
            // 
            // rbBTV
            // 
            this.rbBTV.AutoSize = true;
            this.rbBTV.Location = new System.Drawing.Point(82, 29);
            this.rbBTV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbBTV.Name = "rbBTV";
            this.rbBTV.Size = new System.Drawing.Size(58, 24);
            this.rbBTV.TabIndex = 6;
            this.rbBTV.Text = "BTV";
            this.rbBTV.UseVisualStyleBackColor = true;
            // 
            // rbPTV
            // 
            this.rbPTV.AutoSize = true;
            this.rbPTV.Location = new System.Drawing.Point(165, 29);
            this.rbPTV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbPTV.Name = "rbPTV";
            this.rbPTV.Size = new System.Drawing.Size(57, 24);
            this.rbPTV.TabIndex = 7;
            this.rbPTV.Text = "PTV";
            this.rbPTV.UseVisualStyleBackColor = true;
            // 
            // rbCTV
            // 
            this.rbCTV.AutoSize = true;
            this.rbCTV.Location = new System.Drawing.Point(247, 29);
            this.rbCTV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbCTV.Name = "rbCTV";
            this.rbCTV.Size = new System.Drawing.Size(58, 24);
            this.rbCTV.TabIndex = 8;
            this.rbCTV.Text = "CTV";
            this.rbCTV.UseVisualStyleBackColor = true;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(168, 50);
            this.txtCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(126, 26);
            this.txtCode.TabIndex = 10;
            this.txtCode.Leave += new System.EventHandler(this.txtCode_Leave);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(168, 114);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(264, 26);
            this.txtName.TabIndex = 9;
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(10, 303);
            this.lblPosition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(86, 20);
            this.lblPosition.TabIndex = 3;
            this.lblPosition.Text = "Chức danh";
            // 
            // lblOrganization
            // 
            this.lblOrganization.AutoSize = true;
            this.lblOrganization.Location = new System.Drawing.Point(10, 175);
            this.lblOrganization.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrganization.Name = "lblOrganization";
            this.lblOrganization.Size = new System.Drawing.Size(53, 20);
            this.lblOrganization.TabIndex = 2;
            this.lblOrganization.Text = "Đơn vị";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(14, 50);
            this.lblCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(57, 20);
            this.lblCode.TabIndex = 1;
            this.lblCode.Text = "Mã NV";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(10, 114);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(77, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Họ và tên";
            // 
            // gbControl
            // 
            this.gbControl.Controls.Add(this.btnAdd);
            this.gbControl.Location = new System.Drawing.Point(20, 379);
            this.gbControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbControl.Name = "gbControl";
            this.gbControl.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbControl.Size = new System.Drawing.Size(567, 88);
            this.gbControl.TabIndex = 1;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Thao tác";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(9, 43);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 35);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // AddEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 485);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.gbStudentInfo);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "AddEmployeeForm";
            this.Text = "Quản lý nhân viên - Thêm mới";
            this.Load += new System.EventHandler(this.AddEmployeeForm_Load);
            this.gbStudentInfo.ResumeLayout(false);
            this.gbStudentInfo.PerformLayout();
            this.gbPosition.ResumeLayout(false);
            this.gbPosition.PerformLayout();
            this.gbControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbStudentInfo;
        private System.Windows.Forms.RadioButton rbBTV;
        private System.Windows.Forms.RadioButton rbPV;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblOrganization;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.RadioButton rbCTV;
        private System.Windows.Forms.RadioButton rbPTV;
        private System.Windows.Forms.GroupBox gbPosition;
        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cbOrganizationId;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RadioButton rbKTD;
    }
}