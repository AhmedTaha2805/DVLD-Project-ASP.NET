namespace DVLD_project
{
    partial class PersonDetailsWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearchPerson = new System.Windows.Forms.Button();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.personDetailsControl1 = new DVLD_project.PersonDetailsControl();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearchPerson);
            this.groupBox1.Controls.Add(this.btnAddPerson);
            this.groupBox1.Controls.Add(this.txtFind);
            this.groupBox1.Controls.Add(this.cbFilter);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(37, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(795, 66);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // btnSearchPerson
            // 
            this.btnSearchPerson.BackColor = System.Drawing.Color.White;
            this.btnSearchPerson.Image = global::DVLD_project.Properties.Resources.SearchPerson;
            this.btnSearchPerson.Location = new System.Drawing.Point(682, 13);
            this.btnSearchPerson.Name = "btnSearchPerson";
            this.btnSearchPerson.Size = new System.Drawing.Size(43, 47);
            this.btnSearchPerson.TabIndex = 9;
            this.btnSearchPerson.UseVisualStyleBackColor = false;
            this.btnSearchPerson.Click += new System.EventHandler(this.btnSearchPerson_Click);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.BackColor = System.Drawing.Color.White;
            this.btnAddPerson.Image = global::DVLD_project.Properties.Resources.AddPerson_32;
            this.btnAddPerson.Location = new System.Drawing.Point(744, 12);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(45, 47);
            this.btnAddPerson.TabIndex = 8;
            this.btnAddPerson.UseVisualStyleBackColor = false;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(325, 22);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(260, 24);
            this.txtFind.TabIndex = 3;
            this.txtFind.Visible = false;
            this.txtFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFind_KeyDown);
            this.txtFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFind_KeyPress);
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "Person ID",
            "National No"});
            this.cbFilter.Location = new System.Drawing.Point(96, 20);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(207, 26);
            this.cbFilter.TabIndex = 2;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find By";
            // 
            // personDetailsControl1
            // 
            this.personDetailsControl1.Location = new System.Drawing.Point(37, 84);
            this.personDetailsControl1.Name = "personDetailsControl1";
            this.personDetailsControl1.Size = new System.Drawing.Size(898, 334);
            this.personDetailsControl1.TabIndex = 0;
            // 
            // PersonDetailsWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.personDetailsControl1);
            this.Name = "PersonDetailsWithFilter";
            this.Size = new System.Drawing.Size(970, 434);
            this.Load += new System.EventHandler(this.PersonDetailsWithFilter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PersonDetailsControl personDetailsControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.Button btnSearchPerson;
    }
}
