using DriversBuisnessLayer;
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
using UsersBuisnessLayer;

namespace DVLD_project
{
    public partial class frmManageDrivers : Form
    {
        private readonly DriverClientService _driverClientService;
        public frmManageDrivers()
        {
            InitializeComponent();
            _driverClientService = new DriverClientService();
        }

        private async Task RefreshDataGrid()
        {
            Driversdatagrid.DataSource = await _driverClientService.ListAllDriversAsync();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void frmManageDrivers_Load(object sender, EventArgs e)
        {
            await RefreshDataGrid();
            lbRecord.Text = (Driversdatagrid.RowCount - 1).ToString();
        }

        private void txtFilters_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilters.Text == "Driver ID" || cbFilters.Text == "Person ID" || cbFilters.Text == "Active Licenses")
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

        private async void txtFilters_TextChanged(object sender, EventArgs e)
        {
            DataView dv = (await _driverClientService.ListAllDriversDataTableAsync()).DefaultView;

            dv.RowFilter = $"Convert([{cbFilters.Text}],'System.String') like '{txtFilters.Text}%'";

            Driversdatagrid.DataSource = dv;
        }

        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilters.Visible = true;
        }
    }
}
