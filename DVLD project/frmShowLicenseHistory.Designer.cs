namespace DVLD_project
{
    partial class frmShowLicenseHistory
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbMode = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LicensesTab = new System.Windows.Forms.TabControl();
            this.LocalTab = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.Localdatagrid = new System.Windows.Forms.DataGridView();
            this.InternationalTab = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.IntDataGrid = new System.Windows.Forms.DataGridView();
            this.lbRecord = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personDetailsWithFilter1 = new DVLD_project.PersonDetailsWithFilter();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.LicensesTab.SuspendLayout();
            this.LocalTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Localdatagrid)).BeginInit();
            this.InternationalTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IntDataGrid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_project.Properties.Resources.PersonLicenseHistory_512;
            this.pictureBox1.Location = new System.Drawing.Point(28, 191);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(187, 214);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lbMode
            // 
            this.lbMode.AutoSize = true;
            this.lbMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbMode.Location = new System.Drawing.Point(542, 29);
            this.lbMode.Name = "lbMode";
            this.lbMode.Size = new System.Drawing.Size(192, 29);
            this.lbMode.TabIndex = 6;
            this.lbMode.Text = "License History";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LicensesTab);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(28, 477);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1134, 323);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Licenses";
            // 
            // LicensesTab
            // 
            this.LicensesTab.Controls.Add(this.LocalTab);
            this.LicensesTab.Controls.Add(this.InternationalTab);
            this.LicensesTab.Location = new System.Drawing.Point(6, 29);
            this.LicensesTab.Name = "LicensesTab";
            this.LicensesTab.SelectedIndex = 0;
            this.LicensesTab.Size = new System.Drawing.Size(1122, 288);
            this.LicensesTab.TabIndex = 9;
            this.LicensesTab.SelectedIndexChanged += new System.EventHandler(this.LicensesTab_SelectedIndexChanged);
            // 
            // LocalTab
            // 
            this.LocalTab.Controls.Add(this.label5);
            this.LocalTab.Controls.Add(this.Localdatagrid);
            this.LocalTab.Location = new System.Drawing.Point(4, 27);
            this.LocalTab.Name = "LocalTab";
            this.LocalTab.Padding = new System.Windows.Forms.Padding(3);
            this.LocalTab.Size = new System.Drawing.Size(1114, 257);
            this.LocalTab.TabIndex = 0;
            this.LocalTab.Text = "Local";
            this.LocalTab.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(204, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Local Licenses History";
            // 
            // Localdatagrid
            // 
            this.Localdatagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Localdatagrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.Localdatagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Localdatagrid.Location = new System.Drawing.Point(6, 50);
            this.Localdatagrid.Name = "Localdatagrid";
            this.Localdatagrid.RowHeadersWidth = 51;
            this.Localdatagrid.RowTemplate.Height = 24;
            this.Localdatagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Localdatagrid.Size = new System.Drawing.Size(1102, 201);
            this.Localdatagrid.TabIndex = 37;
            this.Localdatagrid.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Localdatagrid_CellMouseDown);
            // 
            // InternationalTab
            // 
            this.InternationalTab.Controls.Add(this.label1);
            this.InternationalTab.Controls.Add(this.IntDataGrid);
            this.InternationalTab.Location = new System.Drawing.Point(4, 27);
            this.InternationalTab.Name = "InternationalTab";
            this.InternationalTab.Padding = new System.Windows.Forms.Padding(3);
            this.InternationalTab.Size = new System.Drawing.Size(1114, 257);
            this.InternationalTab.TabIndex = 1;
            this.InternationalTab.Text = "International";
            this.InternationalTab.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "International Licenses History";
            // 
            // IntDataGrid
            // 
            this.IntDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.IntDataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.IntDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IntDataGrid.Location = new System.Drawing.Point(9, 50);
            this.IntDataGrid.Name = "IntDataGrid";
            this.IntDataGrid.RowHeadersWidth = 51;
            this.IntDataGrid.RowTemplate.Height = 24;
            this.IntDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.IntDataGrid.Size = new System.Drawing.Size(1099, 201);
            this.IntDataGrid.TabIndex = 38;
            this.IntDataGrid.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.IntDataGrid_CellMouseDown);
            // 
            // lbRecord
            // 
            this.lbRecord.AutoSize = true;
            this.lbRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecord.Location = new System.Drawing.Point(147, 803);
            this.lbRecord.Name = "lbRecord";
            this.lbRecord.Size = new System.Drawing.Size(19, 20);
            this.lbRecord.TabIndex = 9;
            this.lbRecord.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 803);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Records : ";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(251, 42);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showLicenseInfoToolStripMenuItem.Image = global::DVLD_project.Properties.Resources.License_View_32;
            this.showLicenseInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(250, 38);
            this.showLicenseInfoToolStripMenuItem.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem_Click);
            // 
            // personDetailsWithFilter1
            // 
            this.personDetailsWithFilter1.Location = new System.Drawing.Point(235, 61);
            this.personDetailsWithFilter1.Name = "personDetailsWithFilter1";
            this.personDetailsWithFilter1.Size = new System.Drawing.Size(970, 434);
            this.personDetailsWithFilter1.TabIndex = 0;
            // 
            // frmShowLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 851);
            this.Controls.Add(this.lbRecord);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbMode);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.personDetailsWithFilter1);
            this.Name = "frmShowLicenseHistory";
            this.Text = "License History";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.LicensesTab.ResumeLayout(false);
            this.LocalTab.ResumeLayout(false);
            this.LocalTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Localdatagrid)).EndInit();
            this.InternationalTab.ResumeLayout(false);
            this.InternationalTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IntDataGrid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PersonDetailsWithFilter personDetailsWithFilter1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbMode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl LicensesTab;
        private System.Windows.Forms.TabPage LocalTab;
        private System.Windows.Forms.TabPage InternationalTab;
        private System.Windows.Forms.DataGridView Localdatagrid;
        private System.Windows.Forms.DataGridView IntDataGrid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbRecord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
    }
}