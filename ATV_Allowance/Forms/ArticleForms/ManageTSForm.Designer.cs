namespace ATV_Allowance.Forms.ArticleForms
{
    partial class ManageTSForm
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
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.cbArticleType = new System.Windows.Forms.ComboBox();
            this.lblArticleType = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.cbEmployee = new System.Windows.Forms.ComboBox();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.gbArticleInfo = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.adgvList = new ADGV.AdvancedDataGridView();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.gbFilter.SuspendLayout();
            this.gbArticleInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvList)).BeginInit();
            this.gbControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.cbArticleType);
            this.gbFilter.Controls.Add(this.lblArticleType);
            this.gbFilter.Controls.Add(this.lblEmployee);
            this.gbFilter.Controls.Add(this.cbEmployee);
            this.gbFilter.Controls.Add(this.lblEndDate);
            this.gbFilter.Controls.Add(this.dtpEndDate);
            this.gbFilter.Controls.Add(this.lblStartDate);
            this.gbFilter.Controls.Add(this.dtpStartDate);
            this.gbFilter.Location = new System.Drawing.Point(12, 12);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(217, 293);
            this.gbFilter.TabIndex = 0;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Bộ lọc";
            // 
            // cbArticleType
            // 
            this.cbArticleType.FormattingEnabled = true;
            this.cbArticleType.Location = new System.Drawing.Point(10, 50);
            this.cbArticleType.Name = "cbArticleType";
            this.cbArticleType.Size = new System.Drawing.Size(193, 28);
            this.cbArticleType.TabIndex = 7;
            this.cbArticleType.SelectedIndexChanged += new System.EventHandler(this.cbArticleType_SelectedIndexChanged);
            // 
            // lblArticleType
            // 
            this.lblArticleType.AutoSize = true;
            this.lblArticleType.Location = new System.Drawing.Point(8, 27);
            this.lblArticleType.Name = "lblArticleType";
            this.lblArticleType.Size = new System.Drawing.Size(72, 20);
            this.lblArticleType.TabIndex = 6;
            this.lblArticleType.Text = "Nhóm tin";
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(4, 223);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(79, 20);
            this.lblEmployee.TabIndex = 5;
            this.lblEmployee.Text = "Nhân viên";
            // 
            // cbEmployee
            // 
            this.cbEmployee.FormattingEnabled = true;
            this.cbEmployee.Location = new System.Drawing.Point(8, 246);
            this.cbEmployee.Name = "cbEmployee";
            this.cbEmployee.Size = new System.Drawing.Size(201, 28);
            this.cbEmployee.TabIndex = 4;
            this.cbEmployee.SelectedIndexChanged += new System.EventHandler(this.cbEmployee_SelectedIndexChanged);
            this.cbEmployee.TextUpdate += new System.EventHandler(this.cbEmployee_TextUpdate);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(4, 154);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(77, 20);
            this.lblEndDate.TabIndex = 3;
            this.lblEndDate.Text = "Đến ngày";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(8, 177);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(134, 26);
            this.dtpEndDate.TabIndex = 2;
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.dtpEndDate_ValueChanged);
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(2, 95);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(69, 20);
            this.lblStartDate.TabIndex = 1;
            this.lblStartDate.Text = "Từ  ngày";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(8, 118);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(132, 26);
            this.dtpStartDate.TabIndex = 0;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // gbArticleInfo
            // 
            this.gbArticleInfo.Controls.Add(this.txtSearch);
            this.gbArticleInfo.Controls.Add(this.lblSearch);
            this.gbArticleInfo.Controls.Add(this.adgvList);
            this.gbArticleInfo.Location = new System.Drawing.Point(235, 12);
            this.gbArticleInfo.Name = "gbArticleInfo";
            this.gbArticleInfo.Size = new System.Drawing.Size(947, 499);
            this.gbArticleInfo.TabIndex = 1;
            this.gbArticleInfo.TabStop = false;
            this.gbArticleInfo.Text = "Danh sách tin";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(260, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(678, 26);
            this.txtSearch.TabIndex = 8;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(182, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(71, 20);
            this.lblSearch.TabIndex = 7;
            this.lblSearch.Text = "Tìm kiếm";
            // 
            // adgvList
            // 
            this.adgvList.AllowUserToAddRows = false;
            this.adgvList.AllowUserToDeleteRows = false;
            this.adgvList.AutoGenerateContextFilters = true;
            this.adgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvList.DateWithTime = false;
            this.adgvList.Location = new System.Drawing.Point(8, 38);
            this.adgvList.Name = "adgvList";
            this.adgvList.ReadOnly = true;
            this.adgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.adgvList.Size = new System.Drawing.Size(930, 455);
            this.adgvList.TabIndex = 0;
            this.adgvList.TimeFilter = false;
            this.adgvList.SelectionChanged += new System.EventHandler(this.adgvList_SelectionChanged);
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // gbControl
            // 
            this.gbControl.Controls.Add(this.btnRemove);
            this.gbControl.Controls.Add(this.btnEdit);
            this.gbControl.Location = new System.Drawing.Point(12, 322);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(217, 121);
            this.gbControl.TabIndex = 2;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Thao tác";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(6, 76);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(197, 29);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Xóa tin";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(6, 25);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(197, 29);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Xem tin";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // ManageTSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 523);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.gbArticleInfo);
            this.Controls.Add(this.gbFilter);
            this.Name = "ManageTSForm";
            this.Text = "Tin Thời sự hằng ngày";
            this.Load += new System.EventHandler(this.ManageTSForm_Load);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.gbArticleInfo.ResumeLayout(false);
            this.gbArticleInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvList)).EndInit();
            this.gbControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.GroupBox gbArticleInfo;
        private ADGV.AdvancedDataGridView adgvList;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.ComboBox cbEmployee;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ComboBox cbArticleType;
        private System.Windows.Forms.Label lblArticleType;
    }
}