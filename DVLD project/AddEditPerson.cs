using DVLD_project;
using DVLD_project.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_project
{
    enum enMode {AddNew , Update }
    public partial class AddEditPersonForm : Form
    {
        enMode Mode = enMode.AddNew;

        int ID;

        public delegate void DataBackEventHandler(object sender , int PersonID);

        public static event DataBackEventHandler DataBack;


        public AddEditPersonForm(int mode, int id = -1)
        {
            InitializeComponent();
            this.AcceptButton = addPersonControl1.BtnSave();
            this.CancelButton = addPersonControl1.BtnClose();
            if (mode == 0)
            {
                Mode = enMode.AddNew;
            }
            else
            {
                Mode = enMode.Update;
            }
            if (id != -1)
            {
                ID = id;
                
                lbPersonID.Text = ID.ToString();
            }
        }

        private async void AddEditPersonForm_Load(object sender, EventArgs e)
        {
            if (Mode == enMode.Update)
            {
                lbMode.Text = "Update Person";
            }
            await addPersonControl1.LoadCountries();
            addPersonControl1.GetMode((int)Mode);
            if(Mode == enMode.Update)
                await addPersonControl1.GetID(ID);
        }

        private void addPersonControl1_OnSaveClick(int obj)
        {
            if (obj == -1)
            {
                MessageBox.Show("person Updated successfully ", "Congratulations", MessageBoxButtons.OK);
                
            }
            else
            {
                lbMode.Text = "Update Person";
                lbPersonID.Text = obj.ToString();
                MessageBox.Show($"person added successfully with id = {obj}", "Congratulations", MessageBoxButtons.OK);
                addPersonControl1.GetMode(1);
                Mode = enMode.Update;
            }
            
        }

        private void addPersonControl1_OnCloseClick(int obj)
        {
            if (!int.TryParse(lbPersonID.Text, out int id))
            {
                this.Close();
                return;
            }

            int PersonID = int.Parse(lbPersonID.Text);

            DataBack?.Invoke(this, PersonID);

            this.Close();
        }
    }
}
