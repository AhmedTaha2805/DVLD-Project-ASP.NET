namespace DVLD_project
{
    partial class frmNewLocalDrivingLicenseApplication
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.PersonalInfoTab = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.personDetailsWithFilter1 = new DVLD_project.PersonDetailsWithFilter();
            this.ApplicationInfoTab = new System.Windows.Forms.TabPage();
            this.cbLicenseClass = new System.Windows.Forms.ComboBox();
            this.lbAppID = new System.Windows.Forms.Label();
            this.lbDate = new System.Windows.Forms.Label();
            this.lbFees = new System.Windows.Forms.Label();
            this.lbUsername = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.PersonalInfoTab.SuspendLayout();
            this.ApplicationInfoTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.PersonalInfoTab);
            this.tabControl1.Controls.Add(this.ApplicationInfoTab);
            this.tabControl1.Location = new System.Drawing.Point(28, 100);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(965, 519);
            this.tabControl1.TabIndex = 0;
            // 
            // PersonalInfoTab
            // 
            this.PersonalInfoTab.Controls.Add(this.btnNext);
            this.PersonalInfoTab.Controls.Add(this.personDetailsWithFilter1);
            this.PersonalInfoTab.Location = new System.Drawing.Point(4, 25);
            this.PersonalInfoTab.Name = "PersonalInfoTab";
            this.PersonalInfoTab.Padding = new System.Windows.Forms.Padding(3);
            this.PersonalInfoTab.Size = new System.Drawing.Size(957, 490);
            this.PersonalInfoTab.TabIndex = 0;
            this.PersonalInfoTab.Text = "Personal Info";
            this.PersonalInfoTab.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.SystemColors.Control;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = global::DVLD_project.Properties.Resources.Next_32;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(786, 436);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(135, 44);
            this.btnNext.TabIndex = 31;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // personDetailsWithFilter1
            // 
            this.personDetailsWithFilter1.Location = new System.Drawing.Point(16, 17);
            this.personDetailsWithFilter1.Name = "personDetailsWithFilter1";
            this.personDetailsWithFilter1.Size = new System.Drawing.Size(905, 413);
            this.personDetailsWithFilter1.TabIndex = 0;
            // 
            // ApplicationInfoTab
            // 
            this.ApplicationInfoTab.Controls.Add(this.cbLicenseClass);
            this.ApplicationInfoTab.Controls.Add(this.lbAppID);
            this.ApplicationInfoTab.Controls.Add(this.lbDate);
            this.ApplicationInfoTab.Controls.Add(this.lbFees);
            this.ApplicationInfoTab.Controls.Add(this.lbUsername);
            this.ApplicationInfoTab.Controls.Add(this.label5);
            this.ApplicationInfoTab.Controls.Add(this.label4);
            this.ApplicationInfoTab.Controls.Add(this.label3);
            this.ApplicationInfoTab.Controls.Add(this.label2);
            this.ApplicationInfoTab.Controls.Add(this.label1);
            this.ApplicationInfoTab.Location = new System.Drawing.Point(4, 25);
            this.ApplicationInfoTab.Name = "ApplicationInfoTab";
            this.ApplicationInfoTab.Padding = new System.Windows.Forms.Padding(3);
            this.ApplicationInfoTab.Size = new System.Drawing.Size(957, 490);
            this.ApplicationInfoTab.TabIndex = 1;
            this.ApplicationInfoTab.Text = "Application Info";
            this.ApplicationInfoTab.UseVisualStyleBackColor = true;
            // 
            // cbLicenseClass
            // 
            this.cbLicenseClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLicenseClass.FormattingEnabled = true;
            this.cbLicenseClass.Location = new System.Drawing.Point(284, 142);
            this.cbLicenseClass.Name = "cbLicenseClass";
            this.cbLicenseClass.Size = new System.Drawing.Size(222, 24);
            this.cbLicenseClass.TabIndex = 40;
            // 
            // lbAppID
            // 
            this.lbAppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAppID.Location = new System.Drawing.Point(280, 45);
            this.lbAppID.Name = "lbAppID";
            this.lbAppID.Size = new System.Drawing.Size(129, 23);
            this.lbAppID.TabIndex = 39;
            this.lbAppID.Text = "[???]";
            // 
            // lbDate
            // 
            this.lbDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDate.Location = new System.Drawing.Point(280, 93);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(135, 23);
            this.lbDate.TabIndex = 38;
            this.lbDate.Text = "date";
            // 
            // lbFees
            // 
            this.lbFees.AutoSize = true;
            this.lbFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFees.Location = new System.Drawing.Point(289, 193);
            this.lbFees.Name = "lbFees";
            this.lbFees.Size = new System.Drawing.Size(50, 20);
            this.lbFees.TabIndex = 37;
            this.lbFees.Text = "Fees";
            // 
            // lbUsername
            // 
            this.lbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsername.Location = new System.Drawing.Point(286, 244);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(129, 23);
            this.lbUsername.TabIndex = 36;
            this.lbUsername.Text = "username";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(67, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 23);
            this.label5.TabIndex = 35;
            this.label5.Text = "Application Date:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(67, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 23);
            this.label4.TabIndex = 34;
            this.label4.Text = "License Class:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(67, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 20);
            this.label3.TabIndex = 33;
            this.label3.Text = "Application Fees:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(67, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 23);
            this.label2.TabIndex = 32;
            this.label2.Text = "Created By:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 23);
            this.label1.TabIndex = 31;
            this.label1.Text = "D.L Application ID:";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLD_project.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(858, 644);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 44);
            this.btnSave.TabIndex = 33;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_project.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(700, 644);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 44);
            this.btnClose.TabIndex = 32;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(289, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(485, 30);
            this.label6.TabIndex = 34;
            this.label6.Text = "New Local Driving License Application";
            // 
            // frmNewLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1015, 705);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClose);
            this.Name = "frmNewLocalDrivingLicenseApplication";
            this.Text = "New Local Driving License Application";
            this.tabControl1.ResumeLayout(false);
            this.PersonalInfoTab.ResumeLayout(false);
            this.ApplicationInfoTab.ResumeLayout(false);
            this.ApplicationInfoTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage PersonalInfoTab;
        private PersonDetailsWithFilter personDetailsWithFilter1;
        private System.Windows.Forms.TabPage ApplicationInfoTab;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbLicenseClass;
        private System.Windows.Forms.Label lbAppID;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Label lbFees;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
    }
}