namespace ATV_Allowance.Forms.ArticleForms
{
    partial class ImportBSTTNMForm
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
            this.tcImportArticle = new System.Windows.Forms.TabControl();
            this.tpArticle = new System.Windows.Forms.TabPage();
            this.tpPostProduction = new System.Windows.Forms.TabPage();
            this.tcImportArticle.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcImportArticle
            // 
            this.tcImportArticle.Controls.Add(this.tpArticle);
            this.tcImportArticle.Controls.Add(this.tpPostProduction);
            this.tcImportArticle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcImportArticle.Location = new System.Drawing.Point(0, 0);
            this.tcImportArticle.Name = "tcImportArticle";
            this.tcImportArticle.SelectedIndex = 0;
            this.tcImportArticle.Size = new System.Drawing.Size(934, 561);
            this.tcImportArticle.TabIndex = 0;
            // 
            // tpArticle
            // 
            this.tpArticle.Location = new System.Drawing.Point(4, 29);
            this.tpArticle.Name = "tpArticle";
            this.tpArticle.Size = new System.Drawing.Size(926, 528);
            this.tpArticle.TabIndex = 0;
            this.tpArticle.Text = "Tin";
            this.tpArticle.UseVisualStyleBackColor = true;
            // 
            // tpPostProduction
            // 
            this.tpPostProduction.Location = new System.Drawing.Point(4, 29);
            this.tpPostProduction.Name = "tpPostProduction";
            this.tpPostProduction.Size = new System.Drawing.Size(886, 528);
            this.tpPostProduction.TabIndex = 1;
            this.tpPostProduction.Text = "Khối hậu kỳ";
            this.tpPostProduction.UseVisualStyleBackColor = true;
            // 
            // ImportBSTTNMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 561);
            this.Controls.Add(this.tcImportArticle);
            this.KeyPreview = true;
            this.Name = "ImportBSTTNMForm";
            this.Text = "Nhập tin biên soạn trên từng cây số";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ImportBSTTNMForm_KeyDown);
            this.tcImportArticle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcImportArticle;
        private System.Windows.Forms.TabPage tpArticle;
        private System.Windows.Forms.TabPage tpPostProduction;
    }
}