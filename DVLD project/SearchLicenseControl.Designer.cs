namespace DVLD_project
{
    partial class SearchLicenseControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchLicense = new System.Windows.Forms.Button();
            this.licenseInfoControl1 = new DVLD_project.LicenseInfoControl();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearchLicense);
            this.groupBox1.Controls.Add(this.txtFind);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(36, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(666, 66);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(138, 23);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(410, 24);
            this.txtFind.TabIndex = 3;
            this.txtFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFind_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "LicenseID:";
            // 
            // btnSearchLicense
            // 
            this.btnSearchLicense.BackColor = System.Drawing.Color.White;
            this.btnSearchLicense.Image = global::DVLD_project.Properties.Resources.License_View_321;
            this.btnSearchLicense.Location = new System.Drawing.Point(593, 12);
            this.btnSearchLicense.Name = "btnSearchLicense";
            this.btnSearchLicense.Size = new System.Drawing.Size(43, 47);
            this.btnSearchLicense.TabIndex = 9;
            this.btnSearchLicense.UseVisualStyleBackColor = false;
            this.btnSearchLicense.Click += new System.EventHandler(this.btnSearchLicense_Click);
            // 
            // licenseInfoControl1
            // 
            this.licenseInfoControl1.Location = new System.Drawing.Point(25, 87);
            this.licenseInfoControl1.Name = "licenseInfoControl1";
            this.licenseInfoControl1.Size = new System.Drawing.Size(982, 416);
            this.licenseInfoControl1.TabIndex = 0;
            // 
            // SearchLicenseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.licenseInfoControl1);
            this.Name = "SearchLicenseControl";
            this.Size = new System.Drawing.Size(1026, 496);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private LicenseInfoControl licenseInfoControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearchLicense;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Label label1;
    }
}
