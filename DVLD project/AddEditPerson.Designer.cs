namespace DVLD_project
{
    partial class AddEditPersonForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbPersonID = new System.Windows.Forms.Label();
            this.addPersonControl1 = new DVLD_project.AddPersonControl();
            this.lbMode = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(125, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Person ID : ";
            // 
            // lbPersonID
            // 
            this.lbPersonID.AutoSize = true;
            this.lbPersonID.Location = new System.Drawing.Point(218, 37);
            this.lbPersonID.Name = "lbPersonID";
            this.lbPersonID.Size = new System.Drawing.Size(30, 16);
            this.lbPersonID.TabIndex = 2;
            this.lbPersonID.Text = "N/A";
            // 
            // addPersonControl1
            // 
            this.addPersonControl1.Location = new System.Drawing.Point(140, 87);
            this.addPersonControl1.Name = "addPersonControl1";
            this.addPersonControl1.Size = new System.Drawing.Size(828, 300);
            this.addPersonControl1.TabIndex = 3;
            this.addPersonControl1.OnSaveClick += new System.Action<int>(this.addPersonControl1_OnSaveClick);
            this.addPersonControl1.OnCloseClick += new System.Action<int>(this.addPersonControl1_OnCloseClick);
            // 
            // lbMode
            // 
            this.lbMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbMode.Location = new System.Drawing.Point(490, 9);
            this.lbMode.Name = "lbMode";
            this.lbMode.Size = new System.Drawing.Size(249, 43);
            this.lbMode.TabIndex = 4;
            this.lbMode.Text = "Add New Person";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // AddEditPersonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 450);
            this.Controls.Add(this.lbMode);
            this.Controls.Add(this.addPersonControl1);
            this.Controls.Add(this.lbPersonID);
            this.Controls.Add(this.label1);
            this.Name = "AddEditPersonForm";
            this.Text = "Add/Edit Person Info";
            this.Load += new System.EventHandler(this.AddEditPersonForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbPersonID;
        private AddPersonControl addPersonControl1;
        private System.Windows.Forms.Label lbMode;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}