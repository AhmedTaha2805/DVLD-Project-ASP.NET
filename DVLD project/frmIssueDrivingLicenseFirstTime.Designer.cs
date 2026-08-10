namespace DVLD_project
{
    partial class frmIssueDrivingLicenseFirstTime
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
            this.txtnotes = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // applicationInfoControl1
            // 
            this.applicationInfoControl1.Location = new System.Drawing.Point(12, 28);
            this.applicationInfoControl1.Name = "applicationInfoControl1";
            this.applicationInfoControl1.Size = new System.Drawing.Size(879, 409);
            this.applicationInfoControl1.TabIndex = 0;
            // 
            // txtnotes
            // 
            this.txtnotes.Location = new System.Drawing.Point(121, 443);
            this.txtnotes.Multiline = true;
            this.txtnotes.Name = "txtnotes";
            this.txtnotes.Size = new System.Drawing.Size(731, 144);
            this.txtnotes.TabIndex = 69;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(37, 445);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 20);
            this.label11.TabIndex = 68;
            this.label11.Text = "notes:";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLD_project.Properties.Resources.IssueDrivingLicense_321;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(719, 602);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 52);
            this.btnSave.TabIndex = 66;
            this.btnSave.Text = "  Issue";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_project.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(570, 602);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 52);
            this.btnClose.TabIndex = 67;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmIssueDrivingLicenseFirstTime
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(914, 675);
            this.Controls.Add(this.txtnotes);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.applicationInfoControl1);
            this.Name = "frmIssueDrivingLicenseFirstTime";
            this.Text = "Issue Driving License for the First Time";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ApplicationInfoControl applicationInfoControl1;
        private System.Windows.Forms.TextBox txtnotes;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}