namespace ATV_Allowance.Forms.CriteriaForms
{
    partial class CriteriaDetailForm
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
            this.gbCriterias = new System.Windows.Forms.GroupBox();
            this.fpCriteriaList = new System.Windows.Forms.FlowLayoutPanel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.gbCriterias.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCriterias
            // 
            this.gbCriterias.Controls.Add(this.fpCriteriaList);
            this.gbCriterias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCriterias.Location = new System.Drawing.Point(1, 12);
            this.gbCriterias.Name = "gbCriterias";
            this.gbCriterias.Size = new System.Drawing.Size(797, 503);
            this.gbCriterias.TabIndex = 5;
            this.gbCriterias.TabStop = false;
            this.gbCriterias.Text = "Quản lý chỉ tiêu tháng 9 / 2018";
            // 
            // fpCriteriaList
            // 
            this.fpCriteriaList.AutoSize = true;
            this.fpCriteriaList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpCriteriaList.Location = new System.Drawing.Point(3, 19);
            this.fpCriteriaList.Name = "fpCriteriaList";
            this.fpCriteriaList.Size = new System.Drawing.Size(791, 481);
            this.fpCriteriaList.TabIndex = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(720, 518);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 33);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Lưu";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // CriteriaDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 557);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.gbCriterias);
            this.Name = "CriteriaDetailForm";
            this.Text = "Chi tiết chỉ tiêu";
            this.gbCriterias.ResumeLayout(false);
            this.gbCriterias.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCriterias;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.FlowLayoutPanel fpCriteriaList;
    }
}