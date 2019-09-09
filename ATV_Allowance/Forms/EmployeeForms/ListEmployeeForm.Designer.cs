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
            this.adgvEmployee = new ADGV.AdvancedDataGridView();
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
            this.gbEmployeeList.Controls.Add(this.adgvEmployee);
            this.gbEmployeeList.Location = new System.Drawing.Point(12, 25);
            this.gbEmployeeList.Name = "gbEmployeeList";
            this.gbEmployeeList.Size = new System.Drawing.Size(776, 297);
            this.gbEmployeeList.TabIndex = 0;
            this.gbEmployeeList.TabStop = false;
            this.gbEmployeeList.Text = "Danh sách";
            // 
            // adgvEmployee
            // 
            this.adgvEmployee.AutoGenerateContextFilters = true;
            this.adgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvEmployee.DateWithTime = false;
            this.adgvEmployee.Location = new System.Drawing.Point(7, 20);
            this.adgvEmployee.Name = "adgvEmployee";
            this.adgvEmployee.Size = new System.Drawing.Size(763, 271);
            this.adgvEmployee.TabIndex = 0;
            this.adgvEmployee.TimeFilter = false;
            this.adgvEmployee.SortStringChanged += new System.EventHandler(this.adgvEmployee_SortStringChanged);
            this.adgvEmployee.FilterStringChanged += new System.EventHandler(this.adgvEmployee_FilterStringChanged);
            // 
            // gbControl
            // 
            this.gbControl.Controls.Add(this.btnRemove);
            this.gbControl.Controls.Add(this.btnEdit);
            this.gbControl.Controls.Add(this.btnAdd);
            this.gbControl.Location = new System.Drawing.Point(12, 328);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(776, 49);
            this.gbControl.TabIndex = 1;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Thao tác";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(243, 19);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Xóa";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(126, 19);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Xem";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(6, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ListEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 389);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.gbEmployeeList);
            this.Name = "ListEmployeeForm";
            this.Text = "Quản lý nhân viên";
            this.gbEmployeeList.ResumeLayout(false);
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
    }
}