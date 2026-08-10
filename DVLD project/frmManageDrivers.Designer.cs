namespace DVLD_project
{
    partial class frmManageDrivers
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
            this.label5 = new System.Windows.Forms.Label();
            this.txtFilters = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbFilters = new System.Windows.Forms.ComboBox();
            this.lbRecord = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Driversdatagrid = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Driversdatagrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(333, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(196, 29);
            this.label5.TabIndex = 29;
            this.label5.Text = "Manage Drivers";
            // 
            // txtFilters
            // 
            this.txtFilters.Location = new System.Drawing.Point(374, 188);
            this.txtFilters.Name = "txtFilters";
            this.txtFilters.Size = new System.Drawing.Size(155, 22);
            this.txtFilters.TabIndex = 26;
            this.txtFilters.Visible = false;
            this.txtFilters.TextChanged += new System.EventHandler(this.txtFilters_TextChanged);
            this.txtFilters.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilters_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "Filter By";
            // 
            // cbFilters
            // 
            this.cbFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilters.FormattingEnabled = true;
            this.cbFilters.Items.AddRange(new object[] {
            "DriverID",
            "PersonID",
            "NationalNo",
            "FullName",
            "CreatedDate",
            "NumberOfActiveLicenses"});
            this.cbFilters.Location = new System.Drawing.Point(123, 186);
            this.cbFilters.Name = "cbFilters";
            this.cbFilters.Size = new System.Drawing.Size(222, 24);
            this.cbFilters.TabIndex = 24;
            this.cbFilters.SelectedIndexChanged += new System.EventHandler(this.cbFilters_SelectedIndexChanged);
            // 
            // lbRecord
            // 
            this.lbRecord.AutoSize = true;
            this.lbRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecord.Location = new System.Drawing.Point(130, 486);
            this.lbRecord.Name = "lbRecord";
            this.lbRecord.Size = new System.Drawing.Size(19, 20);
            this.lbRecord.TabIndex = 23;
            this.lbRecord.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 486);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Records : ";
            // 
            // Driversdatagrid
            // 
            this.Driversdatagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Driversdatagrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.Driversdatagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Driversdatagrid.Location = new System.Drawing.Point(31, 221);
            this.Driversdatagrid.Name = "Driversdatagrid";
            this.Driversdatagrid.RowHeadersWidth = 51;
            this.Driversdatagrid.RowTemplate.Height = 24;
            this.Driversdatagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Driversdatagrid.Size = new System.Drawing.Size(825, 246);
            this.Driversdatagrid.TabIndex = 21;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_project.Properties.Resources.Driver_Main;
            this.pictureBox1.Location = new System.Drawing.Point(351, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(155, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_project.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(699, 473);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(157, 46);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmManageDrivers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(897, 542);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtFilters);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbFilters);
            this.Controls.Add(this.lbRecord);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Driversdatagrid);
            this.Name = "frmManageDrivers";
            this.Text = "frmManageDrivers";
            this.Load += new System.EventHandler(this.frmManageDrivers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Driversdatagrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtFilters;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbFilters;
        private System.Windows.Forms.Label lbRecord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView Driversdatagrid;
    }
}