namespace DVLD_project
{
    partial class frmShowIntLicense
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
            this.intLicenseInfoControl1 = new DVLD_project.IntLicenseInfoControl();
            this.lbMode = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // intLicenseInfoControl1
            // 
            this.intLicenseInfoControl1.Location = new System.Drawing.Point(12, 133);
            this.intLicenseInfoControl1.Name = "intLicenseInfoControl1";
            this.intLicenseInfoControl1.Size = new System.Drawing.Size(960, 410);
            this.intLicenseInfoControl1.TabIndex = 0;
            // 
            // lbMode
            // 
            this.lbMode.AutoSize = true;
            this.lbMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbMode.Location = new System.Drawing.Point(293, 110);
            this.lbMode.Name = "lbMode";
            this.lbMode.Size = new System.Drawing.Size(382, 29);
            this.lbMode.TabIndex = 6;
            this.lbMode.Text = "Driver International License Info";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_project.Properties.Resources.LicenseView_400;
            this.pictureBox1.Location = new System.Drawing.Point(405, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(152, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 54;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_project.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(846, 544);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 44);
            this.btnClose.TabIndex = 55;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowIntLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(984, 600);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbMode);
            this.Controls.Add(this.intLicenseInfoControl1);
            this.Name = "frmShowIntLicense";
            this.Text = "frmShowIntLicense";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IntLicenseInfoControl intLicenseInfoControl1;
        private System.Windows.Forms.Label lbMode;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnClose;
    }
}