namespace DVLD_project
{
    partial class UserDetailsControl
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
            this.personDetailsControl1 = new DVLD_project.PersonDetailsControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbUserID = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.lbIsActive = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // personDetailsControl1
            // 
            this.personDetailsControl1.Location = new System.Drawing.Point(29, 32);
            this.personDetailsControl1.Name = "personDetailsControl1";
            this.personDetailsControl1.Size = new System.Drawing.Size(903, 334);
            this.personDetailsControl1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbIsActive);
            this.groupBox1.Controls.Add(this.lbUserName);
            this.groupBox1.Controls.Add(this.lbUserID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(29, 372);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(889, 80);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login Information";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(143, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "User ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(644, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Is Active:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(355, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Username:";
            // 
            // lbUserID
            // 
            this.lbUserID.AutoSize = true;
            this.lbUserID.Location = new System.Drawing.Point(229, 39);
            this.lbUserID.Name = "lbUserID";
            this.lbUserID.Size = new System.Drawing.Size(45, 20);
            this.lbUserID.TabIndex = 5;
            this.lbUserID.Text = "????";
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(461, 39);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(45, 20);
            this.lbUserName.TabIndex = 6;
            this.lbUserName.Text = "????";
            // 
            // lbIsActive
            // 
            this.lbIsActive.AutoSize = true;
            this.lbIsActive.Location = new System.Drawing.Point(738, 39);
            this.lbIsActive.Name = "lbIsActive";
            this.lbIsActive.Size = new System.Drawing.Size(45, 20);
            this.lbIsActive.TabIndex = 7;
            this.lbIsActive.Text = "????";
            // 
            // UserDetailsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.personDetailsControl1);
            this.Name = "UserDetailsControl";
            this.Size = new System.Drawing.Size(983, 478);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PersonDetailsControl personDetailsControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbIsActive;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Label lbUserID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
