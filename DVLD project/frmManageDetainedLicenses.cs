using DetainedLicensesBuisnessLayer;
using DriversBuisnessLayer;
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
    public partial class frmManageDetainedLicenses : Form
    {
        private readonly DetainedLicenseClientService _detainedLicenseClientService;
        private readonly PeopleClientService _peopleClientService;
        public frmManageDetainedLicenses()
        {
            InitializeComponent();
            _detainedLicenseClientService = new DetainedLicenseClientService();
            _peopleClientService = new PeopleClientService();
        }
        private async Task RefreshDataGrid()
        {
            Detainsdatagrid.DataSource = await _detainedLicenseClientService.GetAllAsDataTableAsync();
        }

        private async void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            await RefreshDataGrid();
            lbRecord.Text = (Detainsdatagrid.RowCount).ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void txtFilters_TextChanged(object sender, EventArgs e)
        {
            DataView dv = (await _detainedLicenseClientService.GetAllAsDataTableAsync()).DefaultView;

            dv.RowFilter = $"Convert({cbFilters.Text},'System.String') like '{txtFilters.Text}%'";

            Detainsdatagrid.DataSource = dv;
        }

        private void txtFilters_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilters.Text == "D.ID" || cbFilters.Text == "L.ID" || cbFilters.Text == "Release App ID")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (cbFilters.Text == "Full Name")
            {
                if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbFilters.Text != "Is Released")
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

        private async void cbActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbActive.Text == "All")
            {
                await RefreshDataGrid();
            }
            else if (cbActive.Text == "Yes")
            {
                DataView dv = (await _detainedLicenseClientService.GetAllAsDataTableAsync()).DefaultView;

                dv.RowFilter = $"[Is Released] = 1";

                Detainsdatagrid.DataSource = dv; ;
            }
            else if (cbActive.Text == "No")
            {
                DataView dv = (await _detainedLicenseClientService.GetAllAsDataTableAsync()).DefaultView;

                dv.RowFilter = $"[Is Released] = 0";

                Detainsdatagrid.DataSource = dv;
            }
        }

        private async void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NationalNo = Detainsdatagrid.SelectedRows[0].Cells["N.No"].Value.ToString();          
            var Person = await _peopleClientService.FindPersonByNationalNoAsync(NationalNo);
            frmPersonDetails frm = new frmPersonDetails(Person.PersonId);
            frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = int.Parse(Detainsdatagrid.SelectedRows[0].Cells["L.ID"].Value.ToString());
            frmLicenseInfo frm = new frmLicenseInfo(LicenseID);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NationalNo = Detainsdatagrid.SelectedRows[0].Cells["N.No"].Value.ToString();           
            frmShowLicenseHistory frm = new frmShowLicenseHistory(NationalNo);
            frm.ShowDialog();
        }

        private void Detainsdatagrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.Button == MouseButtons.Right)
            {
                Detainsdatagrid.ClearSelection();
                Detainsdatagrid.Rows[e.RowIndex].Selected = true;

                contextMenuStrip1.Show(Cursor.Position);
            }
            if (Convert.ToBoolean(Detainsdatagrid.SelectedRows[0].Cells["Is Released"].Value))
            {
                releaseDetainedLicenseToolStripMenuItem.Enabled = false;
            }
            else
            {
                releaseDetainedLicenseToolStripMenuItem.Enabled= true;
            }
        }

        private async void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DetainID = int.Parse(Detainsdatagrid.SelectedRows[0].Cells["D.ID"].Value.ToString());
            frmReleaseDetain frm = new frmReleaseDetain(DetainID);
            frm.ShowDialog();
            await RefreshDataGrid();
        }

        private async void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseDetain frm = new frmReleaseDetain();
            frm.ShowDialog();
            await RefreshDataGrid();
        }

        private async void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
            await RefreshDataGrid();
        }
    }
}
