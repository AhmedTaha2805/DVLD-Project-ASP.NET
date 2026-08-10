namespace DVLD_project
{
    partial class frmApplicationTypes
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
            this.label3 = new System.Windows.Forms.Label();
            this.lbRecord = new System.Windows.Forms.Label();
            this.AppTypesdatagrid = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editApplicationTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AppTypesdatagrid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 459);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Records : ";
            // 
            // lbRecord
            // 
            this.lbRecord.AutoSize = true;
            this.lbRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecord.Location = new System.Drawing.Point(128, 459);
            this.lbRecord.Name = "lbRecord";
            this.lbRecord.Size = new System.Drawing.Size(19, 20);
            this.lbRecord.TabIndex = 13;
            this.lbRecord.Text = "0";
            // 
            // AppTypesdatagrid
            // 
            this.AppTypesdatagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AppTypesdatagrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.AppTypesdatagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AppTypesdatagrid.Location = new System.Drawing.Point(29, 183);
            this.AppTypesdatagrid.Name = "AppTypesdatagrid";
            this.AppTypesdatagrid.RowHeadersWidth = 51;
            this.AppTypesdatagrid.RowTemplate.Height = 24;
            this.AppTypesdatagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AppTypesdatagrid.Size = new System.Drawing.Size(825, 246);
            this.AppTypesdatagrid.TabIndex = 19;
            this.AppTypesdatagrid.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.AppTypesdatagrid_CellMouseDown);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(266, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(364, 30);
            this.label5.TabIndex = 20;
            this.label5.Text = "Manage Application Types";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editApplicationTypeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(256, 42);
            // 
            // editApplicationTypeToolStripMenuItem
            // 
            this.editApplicationTypeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editApplicationTypeToolStripMenuItem.Image = global::DVLD_project.Properties.Resources.edit_32;
            this.editApplicationTypeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editApplicationTypeToolStripMenuItem.Name = "editApplicationTypeToolStripMenuItem";
            this.editApplicationTypeToolStripMenuItem.Size = new System.Drawing.Size(255, 38);
            this.editApplicationTypeToolStripMenuItem.Text = "Edit Application Type";
            this.editApplicationTypeToolStripMenuItem.Click += new System.EventHandler(this.editApplicationTypeToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_project.Properties.Resources.Application_Types_512;
            this.pictureBox1.Location = new System.Drawing.Point(332, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(192, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_project.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(697, 446);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(157, 46);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmApplicationTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(897, 504);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AppTypesdatagrid);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbRecord);
            this.Controls.Add(this.label3);
            this.Name = "frmApplicationTypes";
            this.Text = "Application Types";
            this.Load += new System.EventHandler(this.frmApplicationTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AppTypesdatagrid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbRecord;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView AppTypesdatagrid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editApplicationTypeToolStripMenuItem;
    }
}