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
    public partial class FrmPeople : Form
    {
        private readonly PeopleClientService _peopleClientService;
        
        public FrmPeople()
        {
            InitializeComponent();
            _peopleClientService = new PeopleClientService();
        }      

        private async Task RefreshDataGrid()
        {
            peoplesdatagrid.DataSource = await _peopleClientService.GetAllPeopleAsync();
        }

        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilters.Visible = true;
            
        }

        private async void Form1_Load_1(object sender, EventArgs e)
        {
            await RefreshDataGrid();
            lbRecord.Text = (peoplesdatagrid.RowCount).ToString();
        }

        private async void txtFilters_TextChanged(object sender, EventArgs e)
        {
            DataView dv = (await _peopleClientService.GetAllPeopleDataTableAsync()).DefaultView;

            dv.RowFilter = $"Convert({cbFilters.Text},'System.String') like '{txtFilters.Text}%'";

            peoplesdatagrid.DataSource = dv;

            
        }

        private void txtFilters_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilters.Text == "PersonID" || cbFilters.Text == "Gendor" || cbFilters.Text == "NationalityCountryID")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnAddPerson_Click(object sender, EventArgs e)
        {
            Form frm = new AddEditPersonForm(0);
            frm.ShowDialog();
            await RefreshDataGrid();
        }

        private void peoplesdatagrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.Button == MouseButtons.Right)
            {
                peoplesdatagrid.ClearSelection();
                peoplesdatagrid.Rows[e.RowIndex].Selected = true;

                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(peoplesdatagrid.SelectedRows[0].Cells["PersonID"].Value.ToString());
            await _peopleClientService.DeletePersonAsync(id);
            await RefreshDataGrid();
            MessageBox.Show($"Person deleted successfully with id = {id}", "Congratulations", MessageBoxButtons.OK);
            
        }

        private async void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditPersonForm frm = new AddEditPersonForm(1);
            frm.ShowDialog();
            await RefreshDataGrid();
        }

        private async void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(peoplesdatagrid.SelectedRows[0].Cells["PersonID"].Value.ToString());
            frmPersonDetails frm = new frmPersonDetails(id);
            frm.ShowDialog();
            await RefreshDataGrid();
        }
    }
}
