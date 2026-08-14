using DriversBuisnessLayer;
using DVLD_project.Services;
using InternationalLicensesBuisnessLayer;
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
    public partial class frmManageInternationalLicensesApplications : Form
    {
        private readonly InternationalLicenseClientService _internationalLicenseClientService;
        public frmManageInternationalLicensesApplications()
        {
            InitializeComponent();
            _internationalLicenseClientService = new InternationalLicenseClientService();
            
        }
        
        private async Task RefreshDataGrid()
        {
            IntAppsdatagrid.DataSource = await _internationalLicenseClientService.ListAllIntLicensesAsync();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilters.Text != "Is Active")
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

        private void txtFilters_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilters.Text == "Int License ID" || cbFilters.Text == "Application ID" || cbFilters.Text == "Driver ID" || cbFilters.Text == "L.License ID")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private async void txtFilters_TextChanged(object sender, EventArgs e)
        {
            DataView dv = (await _internationalLicenseClientService.ListAllIntLicensesAsDataTableAsync()).DefaultView;

            dv.RowFilter = $"Convert({cbFilters.Text},'System.String') like '{txtFilters.Text}%'";

            IntAppsdatagrid.DataSource = dv;
        }

        private async void cbActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbActive.Text == "All")
            {
                await RefreshDataGrid();
            }
            else if (cbActive.Text == "Yes")
            {
                DataView dv = (await _internationalLicenseClientService.ListAllIntLicensesAsDataTableAsync()).DefaultView;

                dv.RowFilter = $"Is Active = 1";

                IntAppsdatagrid.DataSource = dv;
            }
            else if (cbActive.Text == "No")
            {
                DataView dv = (await _internationalLicenseClientService.ListAllIntLicensesAsDataTableAsync()).DefaultView;

                dv.RowFilter = $"Is Active = 0";

                IntAppsdatagrid.DataSource = dv;
            }
        }

        private void btnAddApp_Click(object sender, EventArgs e)
        {
            frmInternationLicenseApplication frm = new frmInternationLicenseApplication();
            frm.ShowDialog();
            RefreshDataGrid();
        }

        private void IntAppsdatagrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.Button == MouseButtons.Right)
            {
                IntAppsdatagrid.ClearSelection();
                IntAppsdatagrid.Rows[e.RowIndex].Selected = true;

                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = int.Parse(IntAppsdatagrid.SelectedRows[0].Cells["Driver ID"].Value.ToString());
            clsDrivers Driver = clsDrivers.FindDriverByID(DriverID);
            clsPeople Person = clsPeople.FindPerson(Driver.PersonID);
            frmPersonDetails frm = new frmPersonDetails(Person.Id);
            frm.ShowDialog();

        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = int.Parse(IntAppsdatagrid.SelectedRows[0].Cells["Int License ID"].Value.ToString());
            frmShowIntLicense frm = new frmShowIntLicense(LicenseID);
            frm.ShowDialog();

        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = int.Parse(IntAppsdatagrid.SelectedRows[0].Cells["Driver ID"].Value.ToString());
            clsDrivers Driver = clsDrivers.FindDriverByID(DriverID);
            clsPeople Person = clsPeople.FindPerson(Driver.PersonID);
            frmShowLicenseHistory frm = new frmShowLicenseHistory(Person.NationalNum);
            frm.ShowDialog();

        }

        private async void frmManageInternationalLicensesApplications_Load(object sender, EventArgs e)
        {
            await RefreshDataGrid();
            lbRecord.Text = (IntAppsdatagrid.RowCount - 1).ToString();
        }
    }
}
