namespace ATV_Allowance.Forms.CommonForms
{
    partial class GlobalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GlobalForm));
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.reportBroadcast1 = new ATV_Allowance.Forms.ReportBroadcast();
            this.SuspendLayout();
            // 
            // reportBroadcast1
            // 
            this.reportBroadcast1.AutoSize = true;
            this.reportBroadcast1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportBroadcast1.Font = new System.Drawing.Font("Candara", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportBroadcast1.Location = new System.Drawing.Point(0, 0);
            this.reportBroadcast1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.reportBroadcast1.Name = "reportBroadcast1";
            this.reportBroadcast1.Size = new System.Drawing.Size(665, 348);
            this.reportBroadcast1.TabIndex = 1;
            // 
            // GlobalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(665, 348);
            this.Controls.Add(this.reportBroadcast1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Menu = this.mainMenu;
            this.Name = "GlobalForm";
            this.Text = "Quản lý thù lao";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GlobalForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MainMenu mainMenu;
        private ReportBroadcast reportBroadcast1;
    }
}