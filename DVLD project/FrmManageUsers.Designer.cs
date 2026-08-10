namespace DVLD_project
{
    partial class FrmManageUsers
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
            this.label4 = new System.Windows.Forms.Label();
            this.cbFilters = new System.Windows.Forms.ComboBox();
            this.lbRecord = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Usersdatagrid = new System.Windows.Forms.DataGridView();
            this.cbActive = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.callPhoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddPerson = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Usersdatagrid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(424, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(199, 30);
            this.label5.TabIndex = 18;
            this.label5.Text = "Manage users";
            // 
            // txtFilters
            // 
            this.txtFilters.Location = new System.Drawing.Point(386, 163);
            this.txtFilters.Name = "txtFilters";
            this.txtFilters.Size = new System.Drawing.Size(132, 22);
            this.txtFilters.TabIndex = 15;
            this.txtFilters.Visible = false;
            this.txtFilters.TextChanged += new System.EventHandler(this.txtFilters_TextChanged);
            this.txtFilters.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilters_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(118, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Filter By";
            // 
            // cbFilters
            // 
            this.cbFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilters.FormattingEnabled = true;
            this.cbFilters.Items.AddRange(new object[] {
            "UserID",
            "PersonID",
            "FullName",
            "UserName",
            "IsActive"});
            this.cbFilters.Location = new System.Drawing.Point(214, 161);
            this.cbFilters.Name = "cbFilters";
            this.cbFilters.Size = new System.Drawing.Size(114, 24);
            this.cbFilters.TabIndex = 13;
            this.cbFilters.SelectedIndexChanged += new System.EventHandler(this.cbFilters_SelectedIndexChanged);
            // 
            // lbRecord
            // 
            this.lbRecord.AutoSize = true;
            this.lbRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecord.Location = new System.Drawing.Point(221, 461);
            this.lbRecord.Name = "lbRecord";
            this.lbRecord.Size = new System.Drawing.Size(19, 20);
            this.lbRecord.TabIndex = 12;
            this.lbRecord.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(118, 461);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Records : ";
            // 
            // Usersdatagrid
            // 
            this.Usersdatagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Usersdatagrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.Usersdatagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Usersdatagrid.Location = new System.Drawing.Point(122, 196);
            this.Usersdatagrid.Name = "Usersdatagrid";
            this.Usersdatagrid.RowHeadersWidth = 51;
            this.Usersdatagrid.RowTemplate.Height = 24;
            this.Usersdatagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Usersdatagrid.Size = new System.Drawing.Size(825, 246);
            this.Usersdatagrid.TabIndex = 10;
            this.Usersdatagrid.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Usersdatagrid_CellMouseDown);
            // 
            // cbActive
            // 
            this.cbActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActive.FormattingEnabled = true;
            this.cbActive.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbActive.Location = new System.Drawing.Point(386, 161);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(121, 24);
            this.cbActive.TabIndex = 19;
            this.cbActive.Visible = false;
            this.cbActive.SelectedIndexChanged += new System.EventHandler(this.cbActive_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonDetailsToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.sendEmailToolStripMenuItem,
            this.callPhoneToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(250, 194);
            // 
            // showPersonDetailsToolStripMenuItem
            // 
            this.showPersonDetailsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPersonDetailsToolStripMenuItem.Image = global::DVLD_project.Properties.Resources.PersonDetails_32;
            this.showPersonDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showPersonDetailsToolStripMenuItem.Name = "showPersonDetailsToolStripMenuItem";
            this.showPersonDetailsToolStripMenuItem.Size = new System.Drawing.Size(249, 38);
            this.showPersonDetailsToolStripMenuItem.Text = "Show User Details";
            this.showPersonDetailsToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.showPersonDetailsToolStripMenuItem.Click += new System.EventHandler(this.showPersonDetailsToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editToolStripMenuItem.Image = global::DVLD_project.Properties.Resources.Edit_User_32;
            this.editToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(249, 38);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteToolStripMenuItem.Image = global::DVLD_project.Properties.Resources.Delete_User_32;
            this.deleteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(249, 38);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // sendEmailToolStripMenuItem
            // 
            this.sendEmailToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendEmailToolStripMenuItem.Image = global::DVLD_project.Properties.Resources.send_email_32;
            this.sendEmailToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sendEmailToolStripMenuItem.Name = "sendEmailToolStripMenuItem";
            this.sendEmailToolStripMenuItem.Size = new System.Drawing.Size(249, 38);
            this.sendEmailToolStripMenuItem.Text = "Send Email";
            // 
            // callPhoneToolStripMenuItem
            // 
            this.callPhoneToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.callPhoneToolStripMenuItem.Image = global::DVLD_project.Properties.Resources.call_32;
            this.callPhoneToolStripMenuItem.Name = "callPhoneToolStripMenuItem";
            this.callPhoneToolStripMenuItem.Size = new System.Drawing.Size(249, 38);
            this.callPhoneToolStripMenuItem.Text = "Call Phone";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_project.Properties.Resources.Users_2_400;
            this.pictureBox1.Location = new System.Drawing.Point(442, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(155, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_project.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(790, 448);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(157, 46);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddPerson.Image = global::DVLD_project.Properties.Resources.Add_New_User_72;
            this.btnAddPerson.Location = new System.Drawing.Point(878, 101);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(82, 89);
            this.btnAddPerson.TabIndex = 16;
            this.btnAddPerson.UseVisualStyleBackColor = false;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // FrmManageUsers
            // 
            this.AcceptButton = this.btnAddPerson;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1100, 506);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbActive);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.txtFilters);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbFilters);
            this.Controls.Add(this.lbRecord);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Usersdatagrid);
            this.Name = "FrmManageUsers";
            this.Text = "Manage Users";
            this.Load += new System.EventHandler(this.FrmManageUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Usersdatagrid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.TextBox txtFilters;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbFilters;
        private System.Windows.Forms.Label lbRecord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView Usersdatagrid;
        private System.Windows.Forms.ComboBox cbActive;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem callPhoneToolStripMenuItem;
    }
}