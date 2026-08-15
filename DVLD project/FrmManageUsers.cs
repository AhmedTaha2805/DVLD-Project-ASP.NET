using DVLD_project.Services;
using PeopleBuisnessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsersBuisnessLayer;

namespace DVLD_project
{
    public partial class FrmManageUsers : Form
    {
        private readonly UserClientService _userClientService;
        public FrmManageUsers()
        {
            InitializeComponent();
            _userClientService = new UserClientService();
        }

        private async Task RefreshDataGrid()
        {
            Usersdatagrid.DataSource = await _userClientService.GetAllUsersAsync();
        }

        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilters.Text != "IsActive")
            {              
                cbActive.Visible = false;
                txtFilters.Visible = true;
            }
            else
            {
                cbActive.Visible = true;
                txtFilters.Visible = false;
            }          
        }
     
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void FrmManageUsers_Load(object sender, EventArgs e)
        {
            await RefreshDataGrid();
            lbRecord.Text = (Usersdatagrid.RowCount).ToString();
        }

        private void txtFilters_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilters.Text == "PersonID" || cbFilters.Text == "UserID")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if(cbFilters.Text == "FullName")
            {
                if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private async void txtFilters_TextChanged(object sender, EventArgs e)
        {
            DataView dv = (await _userClientService.GetAllUsersDataTableAsync()).DefaultView;

            dv.RowFilter = $"Convert({cbFilters.Text},'System.String') like '{txtFilters.Text}%'";

            Usersdatagrid.DataSource = dv;
        }

        private async void cbActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbActive.Text == "All")
            {
                await RefreshDataGrid();
            }
            else if(cbActive.Text == "Yes")
            {
                DataView dv = (await _userClientService.GetAllUsersDataTableAsync()).DefaultView;

                dv.RowFilter = $"IsActive = 1";

                Usersdatagrid.DataSource = dv;
            }
            else if(cbActive.Text == "No")
            {
                DataView dv = (await _userClientService.GetAllUsersDataTableAsync()).DefaultView;

                dv.RowFilter = $"IsActive = 0";

                Usersdatagrid.DataSource = dv;
            }

        }

        private async void btnAddPerson_Click(object sender, EventArgs e)
        {
            Form frm = new FrmAddEditUser(0);
            frm.ShowDialog();
            await RefreshDataGrid();
        }

        private void Usersdatagrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.Button == MouseButtons.Right)
            {
                Usersdatagrid.ClearSelection();
                Usersdatagrid.Rows[e.RowIndex].Selected = true;

                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private async void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Usersdatagrid.SelectedRows[0].Cells["UserID"].Value.ToString());
            FrmAddEditUser frm = new FrmAddEditUser(1,id);
            frm.ShowDialog();
            await RefreshDataGrid();
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Usersdatagrid.SelectedRows[0].Cells["UserID"].Value.ToString());  
            await _userClientService.DeleteUserAsync(id);
            await RefreshDataGrid();
            MessageBox.Show($"User deleted successfully with id = {id}", "Congratulations", MessageBoxButtons.OK);
            
        }

        private async void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Usersdatagrid.SelectedRows[0].Cells["UserID"].Value.ToString());
            frmUserDetails frm = new frmUserDetails(id);
            frm.ShowDialog();
            await RefreshDataGrid();
        }
    }
}
