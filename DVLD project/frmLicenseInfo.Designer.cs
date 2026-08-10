namespace DVLD_project
{
    partial class frmLicenseInfo
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
            this.lbMode = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.licenseInfoControl1 = new DVLD_project.LicenseInfoControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMode
            // 
            this.lbMode.AutoSize = true;
            this.lbMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbMode.Location = new System.Drawing.Point(376, 129);
            this.lbMode.Name = "lbMode";
            this.lbMode.Size = new System.Drawing.Size(231, 29);
            this.lbMode.TabIndex = 6;
            this.lbMode.Text = "Driver License Info";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_project.Properties.Resources.LicenseView_400;
            this.pictureBox1.Location = new System.Drawing.Point(410, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(155, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // licenseInfoControl1
            // 
            this.licenseInfoControl1.Location = new System.Drawing.Point(21, 161);
            this.licenseInfoControl1.Name = "licenseInfoControl1";
            this.licenseInfoControl1.Size = new System.Drawing.Size(973, 416);
            this.licenseInfoControl1.TabIndex = 33;
            // 
            // frmLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 589);
            this.Controls.Add(this.licenseInfoControl1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbMode);
            this.Name = "frmLicenseInfo";
            this.Text = "frmLicenseInfo";
            this.Load += new System.EventHandler(this.frmLicenseInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMode;
        private System.Windows.Forms.PictureBox pictureBox1;
        private LicenseInfoControl licenseInfoControl1;
    }
}