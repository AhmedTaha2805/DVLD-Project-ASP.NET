namespace DVLD_project
{
    partial class frmPersonDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.personDetailsControl1 = new DVLD_project.PersonDetailsControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(289, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Person Details";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_project.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(682, 392);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(119, 46);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // personDetailsControl1
            // 
            this.personDetailsControl1.Location = new System.Drawing.Point(29, 52);
            this.personDetailsControl1.Name = "personDetailsControl1";
            this.personDetailsControl1.Size = new System.Drawing.Size(772, 334);
            this.personDetailsControl1.TabIndex = 2;
            this.personDetailsControl1.Load += new System.EventHandler(this.personDetailsControl1_Load);
            // 
            // frmPersonDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(837, 450);
            this.Controls.Add(this.personDetailsControl1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Name = "frmPersonDetails";
            this.Text = "Person Details";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private PersonDetailsControl personDetailsControl1;
    }
}