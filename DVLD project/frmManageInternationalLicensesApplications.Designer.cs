namespace DVLD_project
{
    partial class frmManageInternationalLicensesApplications
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
            this.txtFilters = new System.Windows.Forms.TextBox();
            this.cbFilters = new System.Windows.Forms.ComboBox();
            this.IntAppsdatagrid = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAddApp = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lbRecord = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbActive = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.IntAppsdatagrid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilters
            // 
            this.txtFilters.Location = new System.Drawing.Point(347, 166);
            this.txtFilters.Name = "txtFilters";
            this.txtFilters.Size = new System.Drawing.Size(260, 22);
            this.txtFilters.TabIndex = 45;
            this.txtFilters.Visible = false;
            this.txtFilters.TextChanged += new System.EventHandler(this.txtFilters_TextChanged);
            this.txtFilters.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilters_KeyPress);
            // 
            // cbFilters
            // 
            this.cbFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilters.FormattingEnabled = true;
            this.cbFilters.Items.AddRange(new object[] {
            "Int License ID",
            "Application ID",
            "Driver ID",
            "L.License ID",
            "Issue Date",
            "Expiration Date",
            "Is Active"});
            this.cbFilters.Location = new System.Drawing.Point(104, 166);
            this.cbFilters.Name = "cbFilters";
            this.cbFilters.Size = new System.Drawing.Size(211, 24);
            this.cbFilters.TabIndex = 44;
            this.cbFilters.SelectedIndexChanged += new System.EventHandler(this.cbFilters_SelectedIndexChanged);
            // 
            // IntAppsdatagrid
            // 
            this.IntAppsdatagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.IntAppsdatagrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.IntAppsdatagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IntAppsdatagrid.Location = new System.Drawing.Point(12, 203);
            this.IntAppsdatagrid.Name = "IntAppsdatagrid";
            this.IntAppsdatagrid.RowHeadersWidth = 51;
            this.IntAppsdatagrid.RowTemplate.Height = 24;
            this.IntAppsdatagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.IntAppsdatagrid.Size = new System.Drawing.Size(1312, 335);
            this.IntAppsdatagrid.TabIndex = 43;
            this.IntAppsdatagrid.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.IntAppsdatagrid_CellMouseDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(417, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(405, 29);
            this.label6.TabIndex = 42;
            this.label6.Text = "International License Applications";
            // 
            // btnAddApp
            // 
            this.btnAddApp.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddApp.Image = global::DVLD_project.Properties.Resources.New_Application_64;
            this.btnAddApp.Location = new System.Drawing.Point(1229, 88);
            this.btnAddApp.Name = "btnAddApp";
            this.btnAddApp.Size = new System.Drawing.Size(95, 82);
            this.btnAddApp.TabIndex = 47;
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
            this.btnClose.Location = new System.Drawing.Point(1189, 556);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 44);
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 48;
            this.label4.Text = "Filter By";
            // 
            // lbRecord
            // 
            this.lbRecord.AutoSize = true;
            this.lbRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecord.Location = new System.Drawing.Point(111, 553);
            this.lbRecord.Name = "lbRecord";
            this.lbRecord.Size = new System.Drawing.Size(19, 20);
            this.lbRecord.TabIndex = 50;
            this.lbRecord.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 553);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 49;
            this.label3.Text = "Records : ";
            // 
            // cbActive
            // 
            this.cbActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActive.FormattingEnabled = true;
            this.cbActive.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbActive.Location = new System.Drawing.Point(347, 164);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(166, 24);
            this.cbActive.TabIndex = 51;
            this.cbActive.Visible = false;
            this.cbActive.SelectedIndexChanged += new System.EventHandler(this.cbActive_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonDetailsToolStripMenuItem,
            this.showLicenseDetailsToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(341, 118);
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
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_project.Properties.Resources.Applications;
            this.pictureBox1.Location = new System.Drawing.Point(510, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(192, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
            // 
            // frmManageInternationalLicensesApplications
            // 
            this.AcceptButton = this.btnAddApp;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1343, 612);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbActive);
            this.Controls.Add(this.lbRecord);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAddApp);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtFilters);
            this.Controls.Add(this.cbFilters);
            this.Controls.Add(this.IntAppsdatagrid);
            this.Controls.Add(this.label6);
            this.Name = "frmManageInternationalLicensesApplications";
            this.Text = "frmManageInternationalLicensesApplications";
            ((System.ComponentModel.ISupportInitialize)(this.IntAppsdatagrid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddApp;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtFilters;
        private System.Windows.Forms.ComboBox cbFilters;
        private System.Windows.Forms.DataGridView IntAppsdatagrid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbRecord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbActive;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}