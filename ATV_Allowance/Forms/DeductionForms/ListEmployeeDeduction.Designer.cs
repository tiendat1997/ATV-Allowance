using System.Windows.Forms;

namespace ATV_Allowance.Forms.DeductionForms
{
    partial class ListEmployeeDeduction
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
            this.cbArticleType = new System.Windows.Forms.ComboBox();
            this.cbEmpRole = new System.Windows.Forms.ComboBox();
            this.dtpMonth = new System.Windows.Forms.DateTimePicker();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.adgvDeduction = new DataGridView();
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblArticleType = new System.Windows.Forms.Label();
            this.lblEmpType = new System.Windows.Forms.Label();
            this.gbList = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.adgvDeduction)).BeginInit();
            this.gbControl.SuspendLayout();
            this.gbList.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbArticleType
            // 
            this.cbArticleType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbArticleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbArticleType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbArticleType.FormattingEnabled = true;
            this.cbArticleType.Items.AddRange(new object[] {
            "Thời sự",
            "Phát thanh"});
            this.cbArticleType.Location = new System.Drawing.Point(80, 189);
            this.cbArticleType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbArticleType.Name = "cbArticleType";
            this.cbArticleType.Size = new System.Drawing.Size(224, 28);
            this.cbArticleType.TabIndex = 6;
            this.cbArticleType.SelectedIndexChanged += new System.EventHandler(this.cbArticleType_SelectedIndexChanged);
            // 
            // cbEmpRole
            // 
            this.cbEmpRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEmpRole.FormattingEnabled = true;
            this.cbEmpRole.Items.AddRange(new object[] {
            "PV",
            "PTV"});
            this.cbEmpRole.Location = new System.Drawing.Point(80, 117);
            this.cbEmpRole.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbEmpRole.Name = "cbEmpRole";
            this.cbEmpRole.Size = new System.Drawing.Size(122, 28);
            this.cbEmpRole.TabIndex = 7;
            this.cbEmpRole.SelectedIndexChanged += new System.EventHandler(this.cbEmpRole_SelectedIndexChanged);
            // 
            // dtpMonth
            // 
            this.dtpMonth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpMonth.CustomFormat = "MM";
            this.dtpMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonth.Location = new System.Drawing.Point(80, 32);
            this.dtpMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpMonth.Name = "dtpMonth";
            this.dtpMonth.ShowUpDown = true;
            this.dtpMonth.Size = new System.Drawing.Size(64, 26);
            this.dtpMonth.TabIndex = 9;
            this.dtpMonth.ValueChanged += new System.EventHandler(this.dtpMonth_ValueChanged);
            // 
            // dtp
            // 
            this.dtp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtp.CustomFormat = "yyyy";
            this.dtp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp.Location = new System.Drawing.Point(208, 32);
            this.dtp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtp.Name = "dtp";
            this.dtp.ShowUpDown = true;
            this.dtp.Size = new System.Drawing.Size(96, 26);
            this.dtp.TabIndex = 5;
            this.dtp.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
            // 
            // adgvDeduction
            // 
            this.adgvDeduction.AllowUserToAddRows = false;
            this.adgvDeduction.AllowUserToDeleteRows = false;
            this.adgvDeduction.AllowUserToOrderColumns = true;
            this.adgvDeduction.AllowUserToResizeColumns = false;
            this.adgvDeduction.AllowUserToResizeRows = false;
            this.adgvDeduction.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.adgvDeduction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvDeduction.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.adgvDeduction.Location = new System.Drawing.Point(9, 32);
            this.adgvDeduction.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.adgvDeduction.MultiSelect = false;
            this.adgvDeduction.Name = "adgvDeduction";
            this.adgvDeduction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.adgvDeduction.Size = new System.Drawing.Size(398, 568);
            this.adgvDeduction.TabIndex = 8;
            // 
            // gbControl
            // 
            this.gbControl.Controls.Add(this.lblYear);
            this.gbControl.Controls.Add(this.lblMonth);
            this.gbControl.Controls.Add(this.lblArticleType);
            this.gbControl.Controls.Add(this.lblEmpType);
            this.gbControl.Controls.Add(this.cbEmpRole);
            this.gbControl.Controls.Add(this.cbArticleType);
            this.gbControl.Controls.Add(this.dtpMonth);
            this.gbControl.Controls.Add(this.dtp);
            this.gbControl.Location = new System.Drawing.Point(18, 18);
            this.gbControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbControl.Name = "gbControl";
            this.gbControl.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbControl.Size = new System.Drawing.Size(317, 397);
            this.gbControl.TabIndex = 9;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Bộ lọc";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(160, 32);
            this.lblYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(42, 20);
            this.lblYear.TabIndex = 13;
            this.lblYear.Text = "Năm";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(8, 32);
            this.lblMonth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(54, 20);
            this.lblMonth.TabIndex = 12;
            this.lblMonth.Text = "Tháng";
            // 
            // lblArticleType
            // 
            this.lblArticleType.AutoSize = true;
            this.lblArticleType.Location = new System.Drawing.Point(8, 189);
            this.lblArticleType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblArticleType.Name = "lblArticleType";
            this.lblArticleType.Size = new System.Drawing.Size(64, 20);
            this.lblArticleType.TabIndex = 11;
            this.lblArticleType.Text = "Loại Tin";
            // 
            // lblEmpType
            // 
            this.lblEmpType.AutoSize = true;
            this.lblEmpType.Location = new System.Drawing.Point(8, 117);
            this.lblEmpType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmpType.Name = "lblEmpType";
            this.lblEmpType.Size = new System.Drawing.Size(65, 20);
            this.lblEmpType.TabIndex = 10;
            this.lblEmpType.Text = "Loại NV";
            // 
            // gbList
            // 
            this.gbList.Controls.Add(this.adgvDeduction);
            this.gbList.Location = new System.Drawing.Point(343, 18);
            this.gbList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbList.Name = "gbList";
            this.gbList.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbList.Size = new System.Drawing.Size(417, 628);
            this.gbList.TabIndex = 10;
            this.gbList.TabStop = false;
            this.gbList.Text = "Danh sách";
            // 
            // ListEmployeeDeduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 666);
            this.Controls.Add(this.gbList);
            this.Controls.Add(this.gbControl);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "ListEmployeeDeduction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý giảm trừ";
            ((System.ComponentModel.ISupportInitialize)(this.adgvDeduction)).EndInit();
            this.gbControl.ResumeLayout(false);
            this.gbControl.PerformLayout();
            this.gbList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cbArticleType;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.ComboBox cbEmpRole;
        private System.Windows.Forms.DateTimePicker dtpMonth;
        private DataGridView adgvDeduction;
        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.GroupBox gbList;
        private System.Windows.Forms.Label lblArticleType;
        private System.Windows.Forms.Label lblEmpType;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblMonth;
    }
}