namespace DVLD_project
{
    partial class frmLocalDrivingLicenseApplications
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
            this.label6 = new System.Windows.Forms.Label();
            this.LocalAppsdatagrid = new System.Windows.Forms.DataGridView();
            this.txtFilters = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbFilters = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleVisionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleWrittenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleStreetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueDrivingLicenseFirstTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddApp = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LocalAppsdatagrid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(411, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(445, 30);
            this.label6.TabIndex = 35;
            this.label6.Text = "Local Driving License Applications";
            // 
            // LocalAppsdatagrid
            // 
            this.LocalAppsdatagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LocalAppsdatagrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.LocalAppsdatagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LocalAppsdatagrid.Location = new System.Drawing.Point(12, 116);
            this.LocalAppsdatagrid.Name = "LocalAppsdatagrid";
            this.LocalAppsdatagrid.RowHeadersWidth = 51;
            this.LocalAppsdatagrid.RowTemplate.Height = 24;
            this.LocalAppsdatagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LocalAppsdatagrid.Size = new System.Drawing.Size(1312, 335);
            this.LocalAppsdatagrid.TabIndex = 36;
            this.LocalAppsdatagrid.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.LocalAppsdatagrid_CellMouseDown);
            // 
            // txtFilters
            // 
            this.txtFilters.Location = new System.Drawing.Point(355, 78);
            this.txtFilters.Name = "txtFilters";
            this.txtFilters.Size = new System.Drawing.Size(260, 22);
            this.txtFilters.TabIndex = 39;
            this.txtFilters.Visible = false;
            this.txtFilters.TextChanged += new System.EventHandler(this.txtFilters_TextChanged);
            this.txtFilters.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilters_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 38;
            this.label4.Text = "Filter By";
            // 
            // cbFilters
            // 
            this.cbFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilters.FormattingEnabled = true;
            this.cbFilters.Items.AddRange(new object[] {
            "L.D.L AppID",
            "Driving Class",
            "National No",
            "Full Name",
            "Application Date",
            "Passed Tests",
            "Status"});
            this.cbFilters.Location = new System.Drawing.Point(106, 76);
            this.cbFilters.Name = "cbFilters";
            this.cbFilters.Size = new System.Drawing.Size(211, 24);
            this.cbFilters.TabIndex = 37;
            this.cbFilters.SelectedIndexChanged += new System.EventHandler(this.cbFilters_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationToolStripMenuItem,
            this.editApplicationToolStripMenuItem,
            this.deleteApplicationToolStripMenuItem,
            this.cancelApplicationToolStripMenuItem,
            this.scheduleTestsToolStripMenuItem,
            this.issueDrivingLicenseFirstTimeToolStripMenuItem,
            this.showLicenseToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(377, 308);
            // 
            // showApplicationToolStripMenuItem
            // 
            this.showApplicationToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showApplicationToolStripMenuItem.Image = global::DVLD_project.Properties.Resources.PersonDetails_321;
            this.showApplicationToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.showApplicationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showApplicationToolStripMenuItem.Name = "showApplicationToolStripMenuItem";
            this.showApplicationToolStripMenuItem.Size = new System.Drawing.Size(376, 38);
            this.showApplicationToolStripMenuItem.Text = "Show Application Details";
            this.showApplicationToolStripMenuItem.Click += new System.EventHandler(this.showApplicationToolStripMenuItem_Click);
            // 
            // editApplicationToolStripMenuItem
            // 
            this.editApplicationToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editApplicationToolStripMenuItem.Image = global::DVLD_project.Properties.Resources.edit_32;
            this.editApplicationToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editApplicationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editApplicationToolStripMenuItem.Name = "editApplicationToolStripMenuItem";
            this.editApplicationToolStripMenuItem.Size = new System.Drawing.Size(376, 38);
            this.editApplicationToolStripMenuItem.Text = "Edit Application";
            this.editApplicationToolStripMenuItem.Click += new System.EventHandler(this.editApplicationToolStripMenuItem_Click);
            // 
            // deleteApplicationToolStripMenuItem
            // 
            this.deleteApplicationToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteApplicationToolStripMenuItem.Image = global::DVLD_project.Properties.Resources.Delete_32_2;
            this.deleteApplicationToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteApplicationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            this.deleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(376, 38);
            this.deleteApplicationToolStripMenuItem.Text = "Delete Application";
            this.deleteApplicationToolStripMenuItem.Click += new System.EventHandler(this.deleteApplicationToolStripMenuItem_Click);
            // 
            // cancelApplicationToolStripMenuItem
            // 
            this.cancelApplicationToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelApplicationToolStripMenuItem.Image = global::DVLD_project.Properties.Resources.Delete_32;
            this.cancelApplicationToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelApplicationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            this.cancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(376, 38);
            this.cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            this.cancelApplicationToolStripMenuItem.Click += new System.EventHandler(this.cancelApplicationToolStripMenuItem_Click);
            // 
            // scheduleTestsToolStripMenuItem
            // 
            this.scheduleTestsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scheduleVisionTestToolStripMenuItem,
            this.scheduleWrittenTestToolStripMenuItem,
            this.scheduleStreetTestToolStripMenuItem});
            this.scheduleTestsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scheduleTestsToolStripMenuItem.Image = global::DVLD_project.Properties.Resources.Schedule_Test_32;
            this.scheduleTestsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.scheduleTestsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.scheduleTestsToolStripMenuItem.Name = "scheduleTestsToolStripMenuItem";
            this.scheduleTestsToolStripMenuItem.Size = new System.Drawing.Size(376, 38);
            this.scheduleTestsToolStripMenuItem.Text = "Schedule Tests";
            // 
            // scheduleVisionTestToolStripMenuItem
            // 
            this.scheduleVisionTestToolStripMenuItem.Name = "scheduleVisionTestToolStripMenuItem";
            this.scheduleVisionTestToolStripMenuItem.Size = new System.Drawing.Size(284, 30);
            this.scheduleVisionTestToolStripMenuItem.Text = "Schedule Vision Test";
            this.scheduleVisionTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleVisionTestToolStripMenuItem_Click);
            // 
            // scheduleWrittenTestToolStripMenuItem
            // 
            this.scheduleWrittenTestToolStripMenuItem.Name = "scheduleWrittenTestToolStripMenuItem";
            this.scheduleWrittenTestToolStripMenuItem.Size = new System.Drawing.Size(284, 30);
            this.scheduleWrittenTestToolStripMenuItem.Text = "Schedule Written Test";
            this.scheduleWrittenTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleWrittenTestToolStripMenuItem_Click);
            // 
            // scheduleStreetTestToolStripMenuItem
            // 
            this.scheduleStreetTestToolStripMenuItem.Name = "scheduleStreetTestToolStripMenuItem";
            this.scheduleStreetTestToolStripMenuItem.Size = new System.Drawing.Size(284, 30);
            this.scheduleStreetTestToolStripMenuItem.Text = "Schedule Street Test";
            this.scheduleStreetTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleStreetTestToolStripMenuItem_Click);
            // 
            // issueDrivingLicenseFirstTimeToolStripMenuItem
            // 
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Image = global::DVLD_project.Properties.Resources.IssueDrivingLicense_32;
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Name = "issueDrivingLicenseFirstTimeToolStripMenuItem";
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Size = new System.Drawing.Size(376, 38);
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Text = "Issue Driving License (First Time)";
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Click += new System.EventHandler(this.issueDrivingLicenseFirstTimeToolStripMenuItem_Click);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showLicenseToolStripMenuItem.Image = global::DVLD_project.Properties.Resources.License_View_32;
            this.showLicenseToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.showLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(376, 38);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::DVLD_project.Properties.Resources.PersonLicenseHistory_32;
            this.showPersonLicenseHistoryToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.showPersonLicenseHistoryToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(376, 38);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // btnAddApp
            // 
            this.btnAddApp.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddApp.Image = global::DVLD_project.Properties.Resources.New_Application_64;
            this.btnAddApp.Location = new System.Drawing.Point(1220, 28);
            this.btnAddApp.Name = "btnAddApp";
            this.btnAddApp.Size = new System.Drawing.Size(95, 82);
            this.btnAddApp.TabIndex = 41;
            this.btnAddApp.UseVisualStyleBackColor = false;
            this.btnAddApp.Click += new System.EventHandler(this.btnAddApp_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_project.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1189, 469);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 44);
            this.btnClose.TabIndex = 40;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmLocalDrivingLicenseApplications
            // 
            this.AcceptButton = this.btnAddApp;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1336, 525);
            this.Controls.Add(this.btnAddApp);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtFilters);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbFilters);
            this.Controls.Add(this.LocalAppsdatagrid);
            this.Controls.Add(this.label6);
            this.Name = "frmLocalDrivingLicenseApplications";
            this.Text = "Local Driving License Applications";
            this.Load += new System.EventHandler(this.frmLocalDrivingLicenseApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LocalAppsdatagrid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView LocalAppsdatagrid;
        private System.Windows.Forms.TextBox txtFilters;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbFilters;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddApp;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicenseFirstTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleVisionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleWrittenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleStreetTestToolStripMenuItem;
    }
}