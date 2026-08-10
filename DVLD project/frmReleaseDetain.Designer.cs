namespace DVLD_project
{
    partial class frmReleaseDetain
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lnkShowLicense = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbReleaseAppID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbTotalFees = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbAppFees = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.lbLicenseID = new System.Windows.Forms.Label();
            this.lbFinefees = new System.Windows.Forms.Label();
            this.lbDetainDate = new System.Windows.Forms.Label();
            this.lbDetainID = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lnkShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.searchLicenseControl1 = new DVLD_project.SearchLicenseControl();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLD_project.Properties.Resources.IssueDrivingLicense_321;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(897, 765);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 52);
            this.btnSave.TabIndex = 91;
            this.btnSave.Text = "Release";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.btnClose.Location = new System.Drawing.Point(760, 765);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 52);
            this.btnClose.TabIndex = 92;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lnkShowLicense
            // 
            this.lnkShowLicense.AutoSize = true;
            this.lnkShowLicense.Enabled = false;
            this.lnkShowLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkShowLicense.Location = new System.Drawing.Point(208, 781);
            this.lnkShowLicense.Name = "lnkShowLicense";
            this.lnkShowLicense.Size = new System.Drawing.Size(129, 18);
            this.lnkShowLicense.TabIndex = 90;
            this.lnkShowLicense.TabStop = true;
            this.lnkShowLicense.Text = "Show License Info";
            this.lnkShowLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowLicense_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbReleaseAppID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lbTotalFees);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lbAppFees);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbUserName);
            this.groupBox1.Controls.Add(this.lbLicenseID);
            this.groupBox1.Controls.Add(this.lbFinefees);
            this.groupBox1.Controls.Add(this.lbDetainDate);
            this.groupBox1.Controls.Add(this.lbDetainID);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(42, 546);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(813, 213);
            this.groupBox1.TabIndex = 89;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detain Info";
            // 
            // lbReleaseAppID
            // 
            this.lbReleaseAppID.AutoSize = true;
            this.lbReleaseAppID.Location = new System.Drawing.Point(658, 167);
            this.lbReleaseAppID.Name = "lbReleaseAppID";
            this.lbReleaseAppID.Size = new System.Drawing.Size(54, 20);
            this.lbReleaseAppID.TabIndex = 35;
            this.lbReleaseAppID.Text = "?????";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(414, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "R.D Application ID:";
            // 
            // lbTotalFees
            // 
            this.lbTotalFees.AutoSize = true;
            this.lbTotalFees.Location = new System.Drawing.Point(213, 167);
            this.lbTotalFees.Name = "lbTotalFees";
            this.lbTotalFees.Size = new System.Drawing.Size(54, 20);
            this.lbTotalFees.TabIndex = 33;
            this.lbTotalFees.Text = "?????";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 32;
            this.label3.Text = "Total Fees:";
            // 
            // lbAppFees
            // 
            this.lbAppFees.AutoSize = true;
            this.lbAppFees.Location = new System.Drawing.Point(213, 116);
            this.lbAppFees.Name = "lbAppFees";
            this.lbAppFees.Size = new System.Drawing.Size(54, 20);
            this.lbAppFees.TabIndex = 31;
            this.lbAppFees.Text = "?????";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 20);
            this.label2.TabIndex = 30;
            this.label2.Text = "Application Fees:";
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(658, 74);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(54, 20);
            this.lbUserName.TabIndex = 29;
            this.lbUserName.Text = "?????";
            // 
            // lbLicenseID
            // 
            this.lbLicenseID.AutoSize = true;
            this.lbLicenseID.Location = new System.Drawing.Point(658, 38);
            this.lbLicenseID.Name = "lbLicenseID";
            this.lbLicenseID.Size = new System.Drawing.Size(54, 20);
            this.lbLicenseID.TabIndex = 25;
            this.lbLicenseID.Text = "?????";
            // 
            // lbFinefees
            // 
            this.lbFinefees.AutoSize = true;
            this.lbFinefees.Location = new System.Drawing.Point(658, 116);
            this.lbFinefees.Name = "lbFinefees";
            this.lbFinefees.Size = new System.Drawing.Size(54, 20);
            this.lbFinefees.TabIndex = 22;
            this.lbFinefees.Text = "?????";
            // 
            // lbDetainDate
            // 
            this.lbDetainDate.AutoSize = true;
            this.lbDetainDate.Location = new System.Drawing.Point(213, 74);
            this.lbDetainDate.Name = "lbDetainDate";
            this.lbDetainDate.Size = new System.Drawing.Size(54, 20);
            this.lbDetainDate.TabIndex = 21;
            this.lbDetainDate.Text = "?????";
            // 
            // lbDetainID
            // 
            this.lbDetainID.AutoSize = true;
            this.lbDetainID.Location = new System.Drawing.Point(213, 38);
            this.lbDetainID.Name = "lbDetainID";
            this.lbDetainID.Size = new System.Drawing.Size(54, 20);
            this.lbDetainID.TabIndex = 12;
            this.lbDetainID.Text = "?????";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "Detain Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(414, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Fine Fees:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(414, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Created By:";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(414, 38);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(106, 20);
            this.label.TabIndex = 4;
            this.label.Text = "License ID:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 20);
            this.label10.TabIndex = 1;
            this.label10.Text = "Detain ID:";
            // 
            // lnkShowLicenseHistory
            // 
            this.lnkShowLicenseHistory.AutoSize = true;
            this.lnkShowLicenseHistory.Enabled = false;
            this.lnkShowLicenseHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkShowLicenseHistory.Location = new System.Drawing.Point(28, 781);
            this.lnkShowLicenseHistory.Name = "lnkShowLicenseHistory";
            this.lnkShowLicenseHistory.Size = new System.Drawing.Size(160, 18);
            this.lnkShowLicenseHistory.TabIndex = 88;
            this.lnkShowLicenseHistory.TabStop = true;
            this.lnkShowLicenseHistory.Text = "Show Licenses History";
            this.lnkShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowLicenseHistory_LinkClicked);
            // 
            // searchLicenseControl1
            // 
            this.searchLicenseControl1.Location = new System.Drawing.Point(6, 55);
            this.searchLicenseControl1.Name = "searchLicenseControl1";
            this.searchLicenseControl1.Size = new System.Drawing.Size(1014, 496);
            this.searchLicenseControl1.TabIndex = 87;
            this.searchLicenseControl1.OnSearchClick += new System.Action<int>(this.searchLicenseControl1_OnSearchClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(334, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(371, 32);
            this.label6.TabIndex = 93;
            this.label6.Text = "Release Detained License";
            // 
            // frmReleaseDetain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1032, 829);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lnkShowLicense);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lnkShowLicenseHistory);
            this.Controls.Add(this.searchLicenseControl1);
            this.Name = "frmReleaseDetain";
            this.Text = "frmReleaseDetain";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel lnkShowLicense;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbTotalFees;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbAppFees;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Label lbLicenseID;
        private System.Windows.Forms.Label lbFinefees;
        private System.Windows.Forms.Label lbDetainDate;
        private System.Windows.Forms.Label lbDetainID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.LinkLabel lnkShowLicenseHistory;
        private SearchLicenseControl searchLicenseControl1;
        private System.Windows.Forms.Label lbReleaseAppID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
    }
}