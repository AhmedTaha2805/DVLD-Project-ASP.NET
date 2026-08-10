using DriversBuisnessLayer;
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
        public frmManageDrivers()
        {
            InitializeComponent();
        }

        private void RefreshDataGrid()
        {
            Driversdatagrid.DataSource = clsDrivers.ListAllDrivers();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
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

        private void txtFilters_TextChanged(object sender, EventArgs e)
        {
            DataView dv = clsDrivers.ListAllDrivers().DefaultView;

            dv.RowFilter = $"Convert([{cbFilters.Text}],'System.String') like '{txtFilters.Text}%'";

            Driversdatagrid.DataSource = dv;
        }

        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilters.Visible = true;
        }
    }
}
