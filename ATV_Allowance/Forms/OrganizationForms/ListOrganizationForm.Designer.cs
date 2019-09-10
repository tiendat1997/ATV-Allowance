namespace ATV_Allowance.Forms.OrganizationForms
{
    partial class ListOrganizationForm
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
            this.gbOrgInfo = new System.Windows.Forms.GroupBox();
            this.adgvOrg = new ADGV.AdvancedDataGridView();
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gbOrgInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvOrg)).BeginInit();
            this.gbControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbOrgInfo
            // 
            this.gbOrgInfo.Controls.Add(this.adgvOrg);
            this.gbOrgInfo.Location = new System.Drawing.Point(5, 14);
            this.gbOrgInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbOrgInfo.Name = "gbOrgInfo";
            this.gbOrgInfo.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbOrgInfo.Size = new System.Drawing.Size(387, 463);
            this.gbOrgInfo.TabIndex = 0;
            this.gbOrgInfo.TabStop = false;
            this.gbOrgInfo.Text = "Danh sách";
            // 
            // adgvOrg
            // 
            this.adgvOrg.AllowUserToAddRows = false;
            this.adgvOrg.AllowUserToDeleteRows = false;
            this.adgvOrg.AutoGenerateContextFilters = true;
            this.adgvOrg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvOrg.DateWithTime = false;
            this.adgvOrg.Location = new System.Drawing.Point(8, 31);
            this.adgvOrg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.adgvOrg.Name = "adgvOrg";
            this.adgvOrg.ReadOnly = true;
            this.adgvOrg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.adgvOrg.Size = new System.Drawing.Size(370, 422);
            this.adgvOrg.TabIndex = 0;
            this.adgvOrg.TimeFilter = false;
            this.adgvOrg.SortStringChanged += new System.EventHandler(this.adgvOrg_SortStringChanged);
            this.adgvOrg.FilterStringChanged += new System.EventHandler(this.adgvOrg_FilterStringChanged);
            this.adgvOrg.SelectionChanged += new System.EventHandler(this.adgvOrg_SelectionChanged);
            // 
            // gbControl
            // 
            this.gbControl.Controls.Add(this.btnEdit);
            this.gbControl.Controls.Add(this.btnAdd);
            this.gbControl.Location = new System.Drawing.Point(5, 487);
            this.gbControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbControl.Name = "gbControl";
            this.gbControl.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbControl.Size = new System.Drawing.Size(387, 75);
            this.gbControl.TabIndex = 1;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Thao tác";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(190, 31);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(112, 35);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Xem";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(10, 31);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 35);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ListOrganizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 569);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.gbOrgInfo);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "ListOrganizationForm";
            this.Text = "Quản lý đơn vị";
            this.gbOrgInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adgvOrg)).EndInit();
            this.gbControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOrgInfo;
        private ADGV.AdvancedDataGridView adgvOrg;
        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
    }
}