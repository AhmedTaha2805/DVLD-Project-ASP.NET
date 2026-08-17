using DVLD_project.Services;
using Microsoft.Extensions.DependencyInjection;
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
    public partial class PersonDetailsWithFilter : UserControl
    {
        public PersonDetailsWithFilter()
        {
            InitializeComponent();
        }

        public Button BtnSearch()
        {
            return (btnSearchPerson);
        }

        private void PersonDetailsWithFilter_Load(object sender, EventArgs e)
        {

        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFind.Visible = true;
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Person ID")
            {
                if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            
        }

        private async void btnSearchPerson_Click(object sender, EventArgs e)
        {
            if(cbFilter.Text == "Person ID")
            {
                await personDetailsControl1.LoadPersonInfo(int.Parse(txtFind.Text));
            }
            else
            {
                await personDetailsControl1.LoadPersonInfo(txtFind.Text);
            }
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            AddEditPersonForm frm = new AddEditPersonForm(0);
            AddEditPersonForm.DataBack += AddEditPersonForm_DataBack;
            frm.ShowDialog();
            
        }

        private async void AddEditPersonForm_DataBack(object sender , int PersonID)
        {
            await personDetailsControl1.LoadPersonInfo(PersonID);
        }

        public async Task LoadPersonInfo(int PersonID,bool Disabled = false)
        {
            await personDetailsControl1.LoadPersonInfo(PersonID);
            txtFind.Text = PersonID.ToString();
            txtFind.Enabled = true;
            cbFilter.SelectedIndex = 0;
            if (Disabled)
            {              
                groupBox1.Enabled = false;
            }
        }

        public int GetPersonID()
        {
            return(personDetailsControl1.GetPersonID());
        }

        public void DisableFilterPersonControls()
        {
            cbFilter.Enabled = false;
            btnAddPerson.Enabled = false;
            btnSearchPerson.Enabled = false;
        }

        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchPerson.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}
