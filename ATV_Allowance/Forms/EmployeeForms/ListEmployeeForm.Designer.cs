namespace ATV_Allowance.Forms.EmployeeForms
{
    partial class ListEmployeeForm
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
            this.gbEmployeeList = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.adgvEmployee = new ADGV.AdvancedDataGridView();
            this.lblSearch = new System.Windows.Forms.Label();
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gbEmployeeList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvEmployee)).BeginInit();
            this.gbControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEmployeeList
            // 
            this.gbEmployeeList.Controls.Add(this.lblTotal);
            this.gbEmployeeList.Controls.Add(this.txtSearch);
            this.gbEmployeeList.Controls.Add(this.adgvEmployee);
            this.gbEmployeeList.Controls.Add(this.lblSearch);
            this.gbEmployeeList.Location = new System.Drawing.Point(13, 14);
            this.gbEmployeeList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbEmployeeList.Name = "gbEmployeeList";
            this.gbEmployeeList.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbEmployeeList.Size = new System.Drawing.Size(908, 512);
            this.gbEmployeeList.TabIndex = 0;
            this.gbEmployeeList.TabStop = false;
            this.gbEmployeeList.Text = "Danh sách";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(795, 486);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(89, 20);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "Số lượng: 0";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(390, 1);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(510, 26);
            this.txtSearch.TabIndex = 10;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // adgvEmployee
            // 
            this.adgvEmployee.AllowUserToAddRows = false;
            this.adgvEmployee.AllowUserToDeleteRows = false;
            this.adgvEmployee.AutoGenerateContextFilters = true;
            this.adgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvEmployee.DateWithTime = false;
            this.adgvEmployee.Location = new System.Drawing.Point(8, 41);
            this.adgvEmployee.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.adgvEmployee.MultiSelect = false;
            this.adgvEmployee.Name = "adgvEmployee";
            this.adgvEmployee.ReadOnly = true;
            this.adgvEmployee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.adgvEmployee.Size = new System.Drawing.Size(892, 431);
            this.adgvEmployee.TabIndex = 0;
            this.adgvEmployee.TimeFilter = false;
            this.adgvEmployee.SortStringChanged += new System.EventHandler(this.adgvEmployee_SortStringChanged);
            this.adgvEmployee.FilterStringChanged += new System.EventHandler(this.adgvEmployee_FilterStringChanged);
            this.adgvEmployee.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.adgvEmployee_CellDoubleClick);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(313, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(71, 20);
            this.lblSearch.TabIndex = 9;
            this.lblSearch.Text = "Tìm kiếm";
            // 
            // gbControl
            // 
            this.gbControl.Controls.Add(this.btnRemove);
            this.gbControl.Controls.Add(this.btnEdit);
            this.gbControl.Controls.Add(this.btnAdd);
            this.gbControl.Location = new System.Drawing.Point(13, 525);
            this.gbControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbControl.Name = "gbControl";
            this.gbControl.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbControl.Size = new System.Drawing.Size(908, 67);
            this.gbControl.TabIndex = 1;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Thao tác";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(365, 29);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(112, 28);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Xóa";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(190, 29);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(112, 28);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Xem";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(10, 29);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 28);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ListEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 597);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.gbEmployeeList);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "ListEmployeeForm";
            this.Text = "Quản lý nhân viên";
            this.gbEmployeeList.ResumeLayout(false);
            this.gbEmployeeList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvEmployee)).EndInit();
            this.gbControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEmployeeList;
        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private ADGV.AdvancedDataGridView adgvEmployee;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblTotal;
    }
}