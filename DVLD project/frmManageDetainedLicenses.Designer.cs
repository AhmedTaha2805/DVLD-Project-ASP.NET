namespace DVLD_project
{
    partial class frmManageDetainedLicenses
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
            this.label5 = new System.Windows.Forms.Label();
            this.txtFilters = new System.Windows.Forms.TextBox();
            this.Detainsdatagrid = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.cbFilters = new System.Windows.Forms.ComboBox();
            this.cbActive = new System.Windows.Forms.ComboBox();
            this.lbRecord = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDetain = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRelease = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseDetainedLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Detainsdatagrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(533, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(323, 32);
            this.label5.TabIndex = 15;
            this.label5.Text = "List Detained Licenses";
            // 
            // txtFilters
            // 
            this.txtFilters.Location = new System.Drawing.Point(258, 176);
            this.txtFilters.Name = "txtFilters";
            this.txtFilters.Size = new System.Drawing.Size(164, 22);
            this.txtFilters.TabIndex = 12;
            this.txtFilters.Visible = false;
            this.txtFilters.TextChanged += new System.EventHandler(this.txtFilters_TextChanged);
            this.txtFilters.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilters_KeyPress);
            // 
            // Detainsdatagrid
            // 
            this.Detainsdatagrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.Detainsdatagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Detainsdatagrid.Location = new System.Drawing.Point(5, 204);
            this.Detainsdatagrid.Name = "Detainsdatagrid";
            this.Detainsdatagrid.RowHeadersWidth = 51;
            this.Detainsdatagrid.RowTemplate.Height = 24;
            this.Detainsdatagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Detainsdatagrid.Size = new System.Drawing.Size(1376, 342);
            this.Detainsdatagrid.TabIndex = 10;
            this.Detainsdatagrid.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Detainsdatagrid_CellMouseDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Filter By";
            // 
            // cbFilters
            // 
            this.cbFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilters.FormattingEnabled = true;
            this.cbFilters.Items.AddRange(new object[] {
            "D.ID",
            "L.ID",
            "D.Date",
            "Is Released",
            "Fine Fees",
            "Release Date",
            "N.No",
            "Full Name",
            "Release App ID"});
            this.cbFilters.Location = new System.Drawing.Point(101, 174);
            this.cbFilters.Name = "cbFilters";
            this.cbFilters.Size = new System.Drawing.Size(141, 24);
            this.cbFilters.TabIndex = 16;
            this.cbFilters.SelectedIndexChanged += new System.EventHandler(this.cbFilters_SelectedIndexChanged);
            // 
            // cbActive
            // 
            this.cbActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActive.FormattingEnabled = true;
            this.cbActive.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbActive.Location = new System.Drawing.Point(258, 176);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(121, 24);
            this.cbActive.TabIndex = 20;
            this.cbActive.Visible = false;
            this.cbActive.SelectedIndexChanged += new System.EventHandler(this.cbActive_SelectedIndexChanged);
            // 
            // lbRecord
            // 
            this.lbRecord.AutoSize = true;
            this.lbRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecord.Location = new System.Drawing.Point(108, 568);
            this.lbRecord.Name = "lbRecord";
            this.lbRecord.Size = new System.Drawing.Size(19, 20);
            this.lbRecord.TabIndex = 22;
            this.lbRecord.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 568);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Records : ";
            // 
            // btnDetain
            // 
            this.btnDetain.BackColor = System.Drawing.Color.White;
            this.btnDetain.Image = global::DVLD_project.Properties.Resources.Detain_641;
            this.btnDetain.Location = new System.Drawing.Point(1301, 136);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.Size = new System.Drawing.Size(80, 64);
            this.btnDetain.TabIndex = 23;
            this.btnDetain.UseVisualStyleBackColor = false;
            this.btnDetain.Click += new System.EventHandler(this.btnDetain_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_project.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1229, 552);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(152, 52);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRelease
            // 
            this.btnRelease.BackColor = System.Drawing.Color.White;
            this.btnRelease.Image = global::DVLD_project.Properties.Resources.Release_Detained_License_64;
            this.btnRelease.Location = new System.Drawing.Point(1205, 136);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(80, 64);
            this.btnRelease.TabIndex = 13;
            this.btnRelease.UseVisualStyleBackColor = false;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_project.Properties.Resources.Detain_512;
            this.pictureBox2.Location = new System.Drawing.Point(604, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(191, 110);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonDetailsToolStripMenuItem,
            this.showLicenseDetailsToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem,
            this.releaseDetainedLicenseToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(341, 156);
            // 
            // showPersonDetailsToolStripMenuItem
            // 
            this.showPersonDetailsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPersonDetailsToolStripMenuItem.Image = global::DVLD_project.Properties.Resources.PersonDetails_32;
            this.showPersonDetailsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.showPersonDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showPersonDetailsToolStripMenuItem.Name = "showPersonDetailsToolStripMenuItem";
            this.showPersonDetailsToolStripMenuItem.Size = new System.Drawing.Size(340, 38);
            this.showPersonDetailsToolStripMenuItem.Text = "Show Person Details";
            this.showPersonDetailsToolStripMenuItem.Click += new System.EventHandler(this.showPersonDetailsToolStripMenuItem_Click);
            // 
            // showLicenseDetailsToolStripMenuItem
            // 
            this.showLicenseDetailsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showLicenseDetailsToolStripMenuItem.Image = global::DVLD_project.Properties.Resources.License_View_32;
            this.showLicenseDetailsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.showLicenseDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLicenseDetailsToolStripMenuItem.Name = "showLicenseDetailsToolStripMenuItem";
            this.showLicenseDetailsToolStripMenuItem.Size = new System.Drawing.Size(340, 38);
            this.showLicenseDetailsToolStripMenuItem.Text = "Show License Details";
            this.showLicenseDetailsToolStripMenuItem.Click += new System.EventHandler(this.showLicenseDetailsToolStripMenuItem_Click);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::DVLD_project.Properties.Resources.PersonLicenseHistory_32;
            this.showPersonLicenseHistoryToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.showPersonLicenseHistoryToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(340, 38);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // releaseDetainedLicenseToolStripMenuItem
            // 
            this.releaseDetainedLicenseToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.releaseDetainedLicenseToolStripMenuItem.Image = global::DVLD_project.Properties.Resources.Release_Detained_License_32;
            this.releaseDetainedLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.releaseDetainedLicenseToolStripMenuItem.Name = "releaseDetainedLicenseToolStripMenuItem";
            this.releaseDetainedLicenseToolStripMenuItem.Size = new System.Drawing.Size(340, 38);
            this.releaseDetainedLicenseToolStripMenuItem.Text = "Release Detained License";
            this.releaseDetainedLicenseToolStripMenuItem.Click += new System.EventHandler(this.releaseDetainedLicenseToolStripMenuItem_Click);
            // 
            // frmManageDetainedLicenses
            // 
            this.AcceptButton = this.btnDetain;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1395, 608);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.lbRecord);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbActive);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbFilters);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.txtFilters);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.Detainsdatagrid);
            this.Name = "frmManageDetainedLicenses";
            this.Text = "frmManageDetainedLicenses";
            this.Load += new System.EventHandler(this.frmManageDetainedLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Detainsdatagrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.TextBox txtFilters;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView Detainsdatagrid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbFilters;
        private System.Windows.Forms.ComboBox cbActive;
        private System.Windows.Forms.Label lbRecord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDetain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseDetainedLicenseToolStripMenuItem;
    }
}