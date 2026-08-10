namespace DVLD_project
{
    partial class frmUserDetails
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
            this.userDetailsControl1 = new DVLD_project.UserDetailsControl();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userDetailsControl1
            // 
            this.userDetailsControl1.Location = new System.Drawing.Point(12, 12);
            this.userDetailsControl1.Name = "userDetailsControl1";
            this.userDetailsControl1.Size = new System.Drawing.Size(954, 459);
            this.userDetailsControl1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_project.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(786, 472);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(145, 48);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(959, 532);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.userDetailsControl1);
            this.Name = "frmUserDetails";
            this.Text = "frmUserDetails";
            this.ResumeLayout(false);

        }

        #endregion

        private UserDetailsControl userDetailsControl1;
        private System.Windows.Forms.Button btnClose;
    }
}