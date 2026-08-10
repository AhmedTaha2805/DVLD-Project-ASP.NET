namespace DVLD_project
{
    partial class frmScheduleWrittenTest
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
            this.lbRecord = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Appointmentsdatagrid = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSchedule = new System.Windows.Forms.Button();
            this.applicationInfoControl1 = new DVLD_project.ApplicationInfoControl();
            ((System.ComponentModel.ISupportInitialize)(this.Appointmentsdatagrid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbRecord
            // 
            this.lbRecord.AutoSize = true;
            this.lbRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecord.Location = new System.Drawing.Point(108, 773);
            this.lbRecord.Name = "lbRecord";
            this.lbRecord.Size = new System.Drawing.Size(19, 20);
            this.lbRecord.TabIndex = 50;
            this.lbRecord.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 773);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 49;
            this.label3.Text = "Records : ";
            // 
            // Appointmentsdatagrid
            // 
            this.Appointmentsdatagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Appointmentsdatagrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.Appointmentsdatagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Appointmentsdatagrid.Location = new System.Drawing.Point(9, 585);
            this.Appointmentsdatagrid.Name = "Appointmentsdatagrid";
            this.Appointmentsdatagrid.RowHeadersWidth = 51;
            this.Appointmentsdatagrid.RowTemplate.Height = 24;
            this.Appointmentsdatagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Appointmentsdatagrid.Size = new System.Drawing.Size(792, 160);
            this.Appointmentsdatagrid.TabIndex = 48;
            this.Appointmentsdatagrid.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Appointmentsdatagrid_CellMouseDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(5, 559);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 20);
            this.label8.TabIndex = 46;
            this.label8.Text = "Appointments:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(235, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(320, 29);
            this.label6.TabIndex = 52;
            this.label6.Text = "Written Test Appointments";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.takeTestToolStripMenuItem,
            this.editToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(163, 80);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.takeTestToolStripMenuItem.Image = global::DVLD_project.Properties.Resources.Test_32;
            this.takeTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(162, 38);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editToolStripMenuItem.Image = global::DVLD_project.Properties.Resources.edit_32;
            this.editToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(162, 38);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_project.Properties.Resources.Written_Test_512;
            this.pictureBox1.Location = new System.Drawing.Point(314, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(152, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_project.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(644, 763);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(157, 40);
            this.btnClose.TabIndex = 51;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSchedule
            // 
            this.btnSchedule.BackColor = System.Drawing.SystemColors.Control;
            this.btnSchedule.BackgroundImage = global::DVLD_project.Properties.Resources.AddAppointment_32;
            this.btnSchedule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSchedule.Location = new System.Drawing.Point(746, 533);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(55, 46);
            this.btnSchedule.TabIndex = 47;
            this.btnSchedule.UseVisualStyleBackColor = false;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // applicationInfoControl1
            // 
            this.applicationInfoControl1.Location = new System.Drawing.Point(-1, 125);
            this.applicationInfoControl1.Name = "applicationInfoControl1";
            this.applicationInfoControl1.Size = new System.Drawing.Size(802, 402);
            this.applicationInfoControl1.TabIndex = 45;
            // 
            // frmScheduleWrittenTest
            // 
            this.AcceptButton = this.btnSchedule;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(817, 815);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbRecord);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Appointmentsdatagrid);
            this.Controls.Add(this.btnSchedule);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.applicationInfoControl1);
            this.Name = "frmScheduleWrittenTest";
            this.Text = "Schedule Written Test";
            this.Load += new System.EventHandler(this.frmScheduleWrittenTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Appointmentsdatagrid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbRecord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView Appointmentsdatagrid;
        private System.Windows.Forms.Button btnSchedule;
        private System.Windows.Forms.Label label8;
        private ApplicationInfoControl applicationInfoControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    }
}