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
        public FrmManageUsers()
        {
            InitializeComponent();
        }

        private void RefreshDataGrid()
        {
            Usersdatagrid.DataSource = clsUsers.GetAllUsers();
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

        private void FrmManageUsers_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
            lbRecord.Text = (Usersdatagrid.RowCount - 1).ToString();
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

        private void txtFilters_TextChanged(object sender, EventArgs e)
        {
            DataView dv = clsUsers.GetAllUsers().DefaultView;

            dv.RowFilter = $"Convert({cbFilters.Text},'System.String') like '{txtFilters.Text}%'";

            Usersdatagrid.DataSource = dv;
        }

        private void cbActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbActive.Text == "All")
            {
                RefreshDataGrid();
            }
            else if(cbActive.Text == "Yes")
            {
                DataView dv = clsUsers.GetAllUsers().DefaultView;

                dv.RowFilter = $"IsActive = 1";

                Usersdatagrid.DataSource = dv;
            }
            else if(cbActive.Text == "No")
            {
                DataView dv = clsUsers.GetAllUsers().DefaultView;

                dv.RowFilter = $"IsActive = 0";

                Usersdatagrid.DataSource = dv;
            }

        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            Form frm = new FrmAddEditUser(0);
            frm.ShowDialog();
            RefreshDataGrid();
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

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Usersdatagrid.SelectedRows[0].Cells["UserID"].Value.ToString());
            FrmAddEditUser frm = new FrmAddEditUser(1,id);
            frm.ShowDialog();
            RefreshDataGrid();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Usersdatagrid.SelectedRows[0].Cells["UserID"].Value.ToString());
            if (clsUsers.DeleteUser(id))
            {
                RefreshDataGrid();
                MessageBox.Show($"User deleted successfully with id = {id}", "Congratulations", MessageBoxButtons.OK);
            }
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Usersdatagrid.SelectedRows[0].Cells["UserID"].Value.ToString());
            frmUserDetails frm = new frmUserDetails(id);
            frm.ShowDialog();
            RefreshDataGrid();
        }
    }
}
