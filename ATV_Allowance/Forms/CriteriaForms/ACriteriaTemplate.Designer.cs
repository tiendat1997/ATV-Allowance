namespace ATV_Allowance.Forms.CriteriaForms
{
    partial class ACriteriaTemplate
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.CriteriaName = new System.Windows.Forms.Label();
            this.CriteriaValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CriteriaUnit = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.CriteriaName);
            this.flowLayoutPanel1.Controls.Add(this.CriteriaValue);
            this.flowLayoutPanel1.Controls.Add(this.CriteriaUnit);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(326, 33);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // CriteriaName
            // 
            this.CriteriaName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CriteriaName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CriteriaName.Location = new System.Drawing.Point(3, 3);
            this.CriteriaName.Name = "CriteriaName";
            this.CriteriaName.Size = new System.Drawing.Size(199, 23);
            this.CriteriaName.TabIndex = 0;
            this.CriteriaName.Text = "Tên tiêu chí:";
            this.CriteriaName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CriteriaValue
            // 
            this.CriteriaValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CriteriaValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CriteriaValue.Location = new System.Drawing.Point(208, 3);
            this.CriteriaValue.Name = "CriteriaValue";
            this.CriteriaValue.Size = new System.Drawing.Size(52, 23);
            this.CriteriaValue.TabIndex = 1;
            this.CriteriaValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(0, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.MaximumSize = new System.Drawing.Size(300, 2);
            this.label1.MinimumSize = new System.Drawing.Size(300, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 2);
            this.label1.TabIndex = 3;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CriteriaUnit
            // 
            this.CriteriaUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CriteriaUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CriteriaUnit.Location = new System.Drawing.Point(266, 3);
            this.CriteriaUnit.Name = "CriteriaUnit";
            this.CriteriaUnit.Size = new System.Drawing.Size(49, 23);
            this.CriteriaUnit.TabIndex = 2;
            this.CriteriaUnit.Text = "Đơn vị";
            this.CriteriaUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ACriteriaTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.Name = "ACriteriaTemplate";
            this.Size = new System.Drawing.Size(330, 36);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label CriteriaName;
        private System.Windows.Forms.TextBox CriteriaValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CriteriaUnit;
    }
}
