namespace DVLD_project
{
    partial class FrmAddEditUser
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.PersonalInfoTab = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.LoginTab = new System.Windows.Forms.TabPage();
            this.chIsActive = new System.Windows.Forms.CheckBox();
            this.lbUserID = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbMode = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.personDetailsWithFilter1 = new DVLD_project.PersonDetailsWithFilter();
            this.tabControl1.SuspendLayout();
            this.PersonalInfoTab.SuspendLayout();
            this.LoginTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.PersonalInfoTab);
            this.tabControl1.Controls.Add(this.LoginTab);
            this.tabControl1.Location = new System.Drawing.Point(88, 83);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1008, 530);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 0;
            // 
            // PersonalInfoTab
            // 
            this.PersonalInfoTab.Controls.Add(this.btnNext);
            this.PersonalInfoTab.Controls.Add(this.personDetailsWithFilter1);
            this.PersonalInfoTab.Location = new System.Drawing.Point(4, 25);
            this.PersonalInfoTab.Name = "PersonalInfoTab";
            this.PersonalInfoTab.Padding = new System.Windows.Forms.Padding(3);
            this.PersonalInfoTab.Size = new System.Drawing.Size(1000, 501);
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
            this.btnNext.Location = new System.Drawing.Point(806, 441);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(135, 44);
            this.btnNext.TabIndex = 30;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // LoginTab
            // 
            this.LoginTab.Controls.Add(this.chIsActive);
            this.LoginTab.Controls.Add(this.lbUserID);
            this.LoginTab.Controls.Add(this.txtConfirmPassword);
            this.LoginTab.Controls.Add(this.txtPassword);
            this.LoginTab.Controls.Add(this.txtUsername);
            this.LoginTab.Controls.Add(this.label4);
            this.LoginTab.Controls.Add(this.label3);
            this.LoginTab.Controls.Add(this.label2);
            this.LoginTab.Controls.Add(this.label1);
            this.LoginTab.Location = new System.Drawing.Point(4, 25);
            this.LoginTab.Name = "LoginTab";
            this.LoginTab.Padding = new System.Windows.Forms.Padding(3);
            this.LoginTab.Size = new System.Drawing.Size(1000, 501);
            this.LoginTab.TabIndex = 1;
            this.LoginTab.Text = "Login Info";
            this.LoginTab.UseVisualStyleBackColor = true;
            // 
            // chIsActive
            // 
            this.chIsActive.AutoSize = true;
            this.chIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chIsActive.Location = new System.Drawing.Point(198, 244);
            this.chIsActive.Name = "chIsActive";
            this.chIsActive.Size = new System.Drawing.Size(88, 20);
            this.chIsActive.TabIndex = 38;
            this.chIsActive.Text = "Is Active";
            this.chIsActive.UseVisualStyleBackColor = true;
            // 
            // lbUserID
            // 
            this.lbUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserID.Location = new System.Drawing.Point(193, 68);
            this.lbUserID.Name = "lbUserID";
            this.lbUserID.Size = new System.Drawing.Size(100, 23);
            this.lbUserID.TabIndex = 37;
            this.lbUserID.Text = "????";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(209, 192);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(152, 22);
            this.txtConfirmPassword.TabIndex = 36;
            this.txtConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPassword_Validating);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(209, 153);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(152, 22);
            this.txtPassword.TabIndex = 35;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(209, 108);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(152, 22);
            this.txtUsername.TabIndex = 34;
            this.txtUsername.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(70, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 20);
            this.label4.TabIndex = 33;
            this.label4.Text = "UserName:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(73, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 32;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "Confirm Password:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 30;
            this.label1.Text = "User ID:";
            // 
            // lbMode
            // 
            this.lbMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbMode.Location = new System.Drawing.Point(511, 37);
            this.lbMode.Name = "lbMode";
            this.lbMode.Size = new System.Drawing.Size(234, 43);
            this.lbMode.TabIndex = 5;
            this.lbMode.Text = "Add New User";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLD_project.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(963, 619);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 44);
            this.btnSave.TabIndex = 29;
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
            this.btnClose.Location = new System.Drawing.Point(805, 619);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 44);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // personDetailsWithFilter1
            // 
            this.personDetailsWithFilter1.Location = new System.Drawing.Point(17, 16);
            this.personDetailsWithFilter1.Name = "personDetailsWithFilter1";
            this.personDetailsWithFilter1.Size = new System.Drawing.Size(961, 442);
            this.personDetailsWithFilter1.TabIndex = 1;
            // 
            // FrmAddEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1168, 675);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbMode);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmAddEditUser";
            this.Text = "FrmAddEditUser";
            this.Load += new System.EventHandler(this.FrmAddEditUser_Load);
            this.tabControl1.ResumeLayout(false);
            this.PersonalInfoTab.ResumeLayout(false);
            this.LoginTab.ResumeLayout(false);
            this.LoginTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage PersonalInfoTab;
        private System.Windows.Forms.TabPage LoginTab;
        private PersonDetailsWithFilter personDetailsWithFilter1;
        private System.Windows.Forms.Label lbMode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chIsActive;
        private System.Windows.Forms.Label lbUserID;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnNext;
    }
}