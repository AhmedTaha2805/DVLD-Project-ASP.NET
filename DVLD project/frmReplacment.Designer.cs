namespace DVLD_project
{
    partial class frmReplacment
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
            this.lbOldLicense = new System.Windows.Forms.Label();
            this.lbOldLicenseID = new System.Windows.Forms.Label();
            this.lbReplacedLicenseID = new System.Windows.Forms.Label();
            this.lbUsername = new System.Windows.Forms.Label();
            this.lbAppfees = new System.Windows.Forms.Label();
            this.lbAppDate = new System.Windows.Forms.Label();
            this.lbReplacmentAppID = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.searchLicenseControl1 = new DVLD_project.SearchLicenseControl();
            this.lnkShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.lbMode = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbLost = new System.Windows.Forms.RadioButton();
            this.rbDamaged = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLD_project.Properties.Resources.IssueDrivingLicense_321;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(706, 776);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(182, 52);
            this.btnSave.TabIndex = 80;
            this.btnSave.Text = "  Issue Replacment";
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
            this.btnClose.Location = new System.Drawing.Point(528, 776);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(153, 52);
            this.btnClose.TabIndex = 81;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lnkShowLicense
            // 
            this.lnkShowLicense.AutoSize = true;
            this.lnkShowLicense.Enabled = false;
            this.lnkShowLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkShowLicense.Location = new System.Drawing.Point(259, 792);
            this.lnkShowLicense.Name = "lnkShowLicense";
            this.lnkShowLicense.Size = new System.Drawing.Size(135, 18);
            this.lnkShowLicense.TabIndex = 79;
            this.lnkShowLicense.TabStop = true;
            this.lnkShowLicense.Text = "Show New License";
            this.lnkShowLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowLicense_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbOldLicense);
            this.groupBox1.Controls.Add(this.lbOldLicenseID);
            this.groupBox1.Controls.Add(this.lbReplacedLicenseID);
            this.groupBox1.Controls.Add(this.lbUsername);
            this.groupBox1.Controls.Add(this.lbAppfees);
            this.groupBox1.Controls.Add(this.lbAppDate);
            this.groupBox1.Controls.Add(this.lbReplacmentAppID);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(64, 587);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(813, 172);
            this.groupBox1.TabIndex = 78;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application Info";
            // 
            // lbOldLicense
            // 
            this.lbOldLicense.AutoSize = true;
            this.lbOldLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOldLicense.Location = new System.Drawing.Point(414, 74);
            this.lbOldLicense.Name = "lbOldLicense";
            this.lbOldLicense.Size = new System.Drawing.Size(141, 20);
            this.lbOldLicense.TabIndex = 30;
            this.lbOldLicense.Text = "Old License ID:";
            // 
            // lbOldLicenseID
            // 
            this.lbOldLicenseID.AutoSize = true;
            this.lbOldLicenseID.Location = new System.Drawing.Point(658, 74);
            this.lbOldLicenseID.Name = "lbOldLicenseID";
            this.lbOldLicenseID.Size = new System.Drawing.Size(54, 20);
            this.lbOldLicenseID.TabIndex = 29;
            this.lbOldLicenseID.Text = "?????";
            // 
            // lbReplacedLicenseID
            // 
            this.lbReplacedLicenseID.AutoSize = true;
            this.lbReplacedLicenseID.Location = new System.Drawing.Point(658, 38);
            this.lbReplacedLicenseID.Name = "lbReplacedLicenseID";
            this.lbReplacedLicenseID.Size = new System.Drawing.Size(54, 20);
            this.lbReplacedLicenseID.TabIndex = 25;
            this.lbReplacedLicenseID.Text = "?????";
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Location = new System.Drawing.Point(658, 116);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(54, 20);
            this.lbUsername.TabIndex = 24;
            this.lbUsername.Text = "?????";
            // 
            // lbAppfees
            // 
            this.lbAppfees.AutoSize = true;
            this.lbAppfees.Location = new System.Drawing.Point(213, 116);
            this.lbAppfees.Name = "lbAppfees";
            this.lbAppfees.Size = new System.Drawing.Size(54, 20);
            this.lbAppfees.TabIndex = 22;
            this.lbAppfees.Text = "?????";
            // 
            // lbAppDate
            // 
            this.lbAppDate.AutoSize = true;
            this.lbAppDate.Location = new System.Drawing.Point(213, 74);
            this.lbAppDate.Name = "lbAppDate";
            this.lbAppDate.Size = new System.Drawing.Size(54, 20);
            this.lbAppDate.TabIndex = 21;
            this.lbAppDate.Text = "?????";
            // 
            // lbReplacmentAppID
            // 
            this.lbReplacmentAppID.AutoSize = true;
            this.lbReplacmentAppID.Location = new System.Drawing.Point(213, 38);
            this.lbReplacmentAppID.Name = "lbReplacmentAppID";
            this.lbReplacmentAppID.Size = new System.Drawing.Size(54, 20);
            this.lbReplacmentAppID.TabIndex = 12;
            this.lbReplacmentAppID.Text = "?????";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(154, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "Application Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Application Fees";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(414, 116);
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
            this.label.Size = new System.Drawing.Size(190, 20);
            this.label.TabIndex = 4;
            this.label.Text = "Replaced License ID:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(168, 20);
            this.label10.TabIndex = 1;
            this.label10.Text = "L.R Application ID:";
            // 
            // searchLicenseControl1
            // 
            this.searchLicenseControl1.Location = new System.Drawing.Point(22, 85);
            this.searchLicenseControl1.Name = "searchLicenseControl1";
            this.searchLicenseControl1.Size = new System.Drawing.Size(992, 496);
            this.searchLicenseControl1.TabIndex = 76;
            this.searchLicenseControl1.OnSearchClick += new System.Action<int>(this.searchLicenseControl1_OnSearchClick);
            // 
            // lnkShowLicenseHistory
            // 
            this.lnkShowLicenseHistory.AutoSize = true;
            this.lnkShowLicenseHistory.Enabled = false;
            this.lnkShowLicenseHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkShowLicenseHistory.Location = new System.Drawing.Point(71, 792);
            this.lnkShowLicenseHistory.Name = "lnkShowLicenseHistory";
            this.lnkShowLicenseHistory.Size = new System.Drawing.Size(160, 18);
            this.lnkShowLicenseHistory.TabIndex = 77;
            this.lnkShowLicenseHistory.TabStop = true;
            this.lnkShowLicenseHistory.Text = "Show Licenses History";
            this.lnkShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowLicenseHistory_LinkClicked);
            // 
            // lbMode
            // 
            this.lbMode.AutoSize = true;
            this.lbMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbMode.Location = new System.Drawing.Point(294, 36);
            this.lbMode.Name = "lbMode";
            this.lbMode.Size = new System.Drawing.Size(416, 29);
            this.lbMode.TabIndex = 82;
            this.lbMode.Text = "Replacment For Damaged License";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbLost);
            this.groupBox2.Controls.Add(this.rbDamaged);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(755, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 81);
            this.groupBox2.TabIndex = 83;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Replacment For";
            // 
            // rbLost
            // 
            this.rbLost.AutoSize = true;
            this.rbLost.Location = new System.Drawing.Point(20, 51);
            this.rbLost.Name = "rbLost";
            this.rbLost.Size = new System.Drawing.Size(113, 22);
            this.rbLost.TabIndex = 85;
            this.rbLost.Text = "Lost License";
            this.rbLost.UseVisualStyleBackColor = true;
            this.rbLost.CheckedChanged += new System.EventHandler(this.rbLost_CheckedChanged);
            // 
            // rbDamaged
            // 
            this.rbDamaged.AutoSize = true;
            this.rbDamaged.Checked = true;
            this.rbDamaged.Location = new System.Drawing.Point(19, 23);
            this.rbDamaged.Name = "rbDamaged";
            this.rbDamaged.Size = new System.Drawing.Size(148, 22);
            this.rbDamaged.TabIndex = 84;
            this.rbDamaged.TabStop = true;
            this.rbDamaged.Text = "Damaged License";
            this.rbDamaged.UseVisualStyleBackColor = true;
            // 
            // frmReplacment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1015, 841);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lbMode);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lnkShowLicense);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.searchLicenseControl1);
            this.Controls.Add(this.lnkShowLicenseHistory);
            this.Name = "frmReplacment";
            this.Text = "License Replacment";
            this.Load += new System.EventHandler(this.frmReplacment_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel lnkShowLicense;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbOldLicenseID;
        private System.Windows.Forms.Label lbReplacedLicenseID;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.Label lbAppfees;
        private System.Windows.Forms.Label lbAppDate;
        private System.Windows.Forms.Label lbReplacmentAppID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label10;
        private SearchLicenseControl searchLicenseControl1;
        private System.Windows.Forms.LinkLabel lnkShowLicenseHistory;
        private System.Windows.Forms.Label lbMode;
        private System.Windows.Forms.Label lbOldLicense;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbLost;
        private System.Windows.Forms.RadioButton rbDamaged;
    }
}