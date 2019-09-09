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
            this.components = new System.ComponentModel.Container();
            this.gbStudentInfo = new System.Windows.Forms.GroupBox();
            this.cbOrganizationId = new System.Windows.Forms.ComboBox();
            this.gbPosition = new System.Windows.Forms.GroupBox();
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbStudentInfo.SuspendLayout();
            this.gbPosition.SuspendLayout();
            this.gbControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbStudentInfo
            // 
            this.gbStudentInfo.Controls.Add(this.cbOrganizationId);
            this.gbStudentInfo.Controls.Add(this.gbPosition);
            this.gbStudentInfo.Controls.Add(this.txtCode);
            this.gbStudentInfo.Controls.Add(this.txtName);
            this.gbStudentInfo.Controls.Add(this.lblPosition);
            this.gbStudentInfo.Controls.Add(this.lblOrganization);
            this.gbStudentInfo.Controls.Add(this.lblCode);
            this.gbStudentInfo.Controls.Add(this.lblName);
            this.gbStudentInfo.Location = new System.Drawing.Point(13, 13);
            this.gbStudentInfo.Name = "gbStudentInfo";
            this.gbStudentInfo.Size = new System.Drawing.Size(378, 217);
            this.gbStudentInfo.TabIndex = 0;
            this.gbStudentInfo.TabStop = false;
            this.gbStudentInfo.Text = "Thông tin nhân viên";
            // 
            // cbOrganizationId
            // 
            this.cbOrganizationId.FormattingEnabled = true;
            this.cbOrganizationId.Location = new System.Drawing.Point(112, 117);
            this.cbOrganizationId.Name = "cbOrganizationId";
            this.cbOrganizationId.Size = new System.Drawing.Size(250, 21);
            this.cbOrganizationId.TabIndex = 12;
            // 
            // gbPosition
            // 
            this.gbPosition.Controls.Add(this.rbPV);
            this.gbPosition.Controls.Add(this.rbBTV);
            this.gbPosition.Controls.Add(this.rbPTV);
            this.gbPosition.Controls.Add(this.rbCTV);
            this.gbPosition.Location = new System.Drawing.Point(112, 156);
            this.gbPosition.Name = "gbPosition";
            this.gbPosition.Size = new System.Drawing.Size(250, 49);
            this.gbPosition.TabIndex = 11;
            this.gbPosition.TabStop = false;
            // 
            // rbPV
            // 
            this.rbPV.AutoSize = true;
            this.rbPV.Checked = true;
            this.rbPV.Location = new System.Drawing.Point(6, 19);
            this.rbPV.Name = "rbPV";
            this.rbPV.Size = new System.Drawing.Size(39, 17);
            this.rbPV.TabIndex = 5;
            this.rbPV.TabStop = true;
            this.rbPV.Text = "PV";
            this.rbPV.UseVisualStyleBackColor = true;
            // 
            // rbBTV
            // 
            this.rbBTV.AutoSize = true;
            this.rbBTV.Location = new System.Drawing.Point(61, 19);
            this.rbBTV.Name = "rbBTV";
            this.rbBTV.Size = new System.Drawing.Size(46, 17);
            this.rbBTV.TabIndex = 6;
            this.rbBTV.Text = "BTV";
            this.rbBTV.UseVisualStyleBackColor = true;
            // 
            // rbPTV
            // 
            this.rbPTV.AutoSize = true;
            this.rbPTV.Location = new System.Drawing.Point(131, 19);
            this.rbPTV.Name = "rbPTV";
            this.rbPTV.Size = new System.Drawing.Size(46, 17);
            this.rbPTV.TabIndex = 7;
            this.rbPTV.Text = "PTV";
            this.rbPTV.UseVisualStyleBackColor = true;
            // 
            // rbCTV
            // 
            this.rbCTV.AutoSize = true;
            this.rbCTV.Location = new System.Drawing.Point(198, 19);
            this.rbCTV.Name = "rbCTV";
            this.rbCTV.Size = new System.Drawing.Size(46, 17);
            this.rbCTV.TabIndex = 8;
            this.rbCTV.Text = "CTV";
            this.rbCTV.UseVisualStyleBackColor = true;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(112, 82);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(85, 20);
            this.txtCode.TabIndex = 10;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(112, 42);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(177, 20);
            this.txtName.TabIndex = 9;
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(7, 156);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(59, 13);
            this.lblPosition.TabIndex = 3;
            this.lblPosition.Text = "Chức danh";
            // 
            // lblOrganization
            // 
            this.lblOrganization.AutoSize = true;
            this.lblOrganization.Location = new System.Drawing.Point(7, 117);
            this.lblOrganization.Name = "lblOrganization";
            this.lblOrganization.Size = new System.Drawing.Size(38, 13);
            this.lblOrganization.TabIndex = 2;
            this.lblOrganization.Text = "Đơn vị";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(7, 82);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(40, 13);
            this.lblCode.TabIndex = 1;
            this.lblCode.Text = "Mã NV";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(7, 42);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(54, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Họ và tên";
            // 
            // gbControl
            // 
            this.gbControl.Controls.Add(this.btnAdd);
            this.gbControl.Location = new System.Drawing.Point(13, 237);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(378, 66);
            this.gbControl.TabIndex = 1;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Thao tác";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(6, 28);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 315);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.gbStudentInfo);
            this.Name = "AddEmployeeForm";
            this.Text = "Quản lý nhân viên - Thêm mới";
            this.Load += new System.EventHandler(this.AddEmployeeForm_Load);
            this.gbStudentInfo.ResumeLayout(false);
            this.gbStudentInfo.PerformLayout();
            this.gbPosition.ResumeLayout(false);
            this.gbPosition.PerformLayout();
            this.gbControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
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
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}