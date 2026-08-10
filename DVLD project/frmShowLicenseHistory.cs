using ApplicationBuisnessLayer;
using DriversBuisnessLayer;
using InternationalLicensesBuisnessLayer;
using LicensesBuisnessLayer;
using LocalDrivingLicenseApplicationsBuisnessLayer;
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

namespace DVLD_project
{
    public partial class frmShowLicenseHistory : Form
    {
        public frmShowLicenseHistory(string NationalNo)
        {
            InitializeComponent();
            this.AcceptButton = personDetailsWithFilter1.BtnSearch();
            clsPeople person = clsPeople.FindPerson(NationalNo);
            personDetailsWithFilter1.LoadPersonInfo(person.Id, true);
            clsDrivers Driver = clsDrivers.FindDriverBypersonID(person.Id);
            Localdatagrid.DataSource = clsLicenses.ListLocalLicenses(Driver.DriverID);
            IntDataGrid.DataSource = clsIntLicenses.ListIntLicenses(Driver.DriverID);
            lbRecord.Text = Localdatagrid.RowCount.ToString();
        }

        private void LicensesTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(LicensesTab.SelectedTab == LocalTab)
            {
                lbRecord.Text = (Localdatagrid.RowCount - 1).ToString();
            }
            else
            {
                lbRecord.Text = (IntDataGrid.RowCount-1).ToString();
            }
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(LicensesTab.SelectedTab == LocalTab)
            {
                int LicenseID = int.Parse(Localdatagrid.SelectedRows[0].Cells["Lic ID"].Value.ToString());
                frmLicenseInfo frm = new frmLicenseInfo(LicenseID);
                frm.ShowDialog();
            }
            else
            {
                int LicenseID = int.Parse(IntDataGrid.SelectedRows[0].Cells["Int License ID"].Value.ToString());
                frmShowIntLicense frm = new frmShowIntLicense(LicenseID);
                frm.ShowDialog();
            }        
        }

        private void Localdatagrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.Button == MouseButtons.Right)
            {
                Localdatagrid.ClearSelection();
                Localdatagrid.Rows[e.RowIndex].Selected = true;

                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void IntDataGrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.Button == MouseButtons.Right)
            {
                IntDataGrid.ClearSelection();
                IntDataGrid.Rows[e.RowIndex].Selected = true;

                contextMenuStrip1.Show(Cursor.Position);
            }
        }
    }
}
