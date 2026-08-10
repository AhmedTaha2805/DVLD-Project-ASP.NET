namespace DVLD_project
{
    partial class frmShowApplicationDetails
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
            this.applicationInfoControl1 = new DVLD_project.ApplicationInfoControl();
            this.lbMode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // applicationInfoControl1
            // 
            this.applicationInfoControl1.Location = new System.Drawing.Point(12, 69);
            this.applicationInfoControl1.Name = "applicationInfoControl1";
            this.applicationInfoControl1.Size = new System.Drawing.Size(886, 409);
            this.applicationInfoControl1.TabIndex = 0;
            // 
            // lbMode
            // 
            this.lbMode.AutoSize = true;
            this.lbMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbMode.Location = new System.Drawing.Point(317, 27);
            this.lbMode.Name = "lbMode";
            this.lbMode.Size = new System.Drawing.Size(231, 29);
            this.lbMode.TabIndex = 5;
            this.lbMode.Text = "Application Details";
            // 
            // frmShowApplicationDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 490);
            this.Controls.Add(this.lbMode);
            this.Controls.Add(this.applicationInfoControl1);
            this.Name = "frmShowApplicationDetails";
            this.Text = "Show Application Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ApplicationInfoControl applicationInfoControl1;
        private System.Windows.Forms.Label lbMode;
    }
}