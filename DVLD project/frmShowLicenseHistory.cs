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
    public partial class frmShowLicenseHistory : Form
    {
        private readonly InternationalLicenseClientService _internationalLicenseClientService;
        private readonly LicenseClientService _licenseClientService;
        private readonly DriverClientService _driverClientService;
        private readonly PeopleClientService _peopleClientService;
        int _driverid;
        int _personid;
        string _NationalNo;
        public frmShowLicenseHistory(string NationalNo)
        {
            InitializeComponent();
            _licenseClientService = new LicenseClientService();
            _internationalLicenseClientService = new InternationalLicenseClientService();
            _driverClientService = new DriverClientService();
            _peopleClientService = new PeopleClientService();
            this.AcceptButton = personDetailsWithFilter1.BtnSearch();
            _NationalNo = NationalNo;
            
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

        private async void frmShowLicenseHistory_Load(object sender, EventArgs e)
        {
            var person = await _peopleClientService.FindPersonByNationalNoAsync(_NationalNo);
            _personid = person.PersonId;
            var LoadPersonTask = personDetailsWithFilter1.LoadPersonInfo(person.PersonId, true);   
            var DriverTask = _driverClientService.FindDriverByPersonIDAsync(_personid);
            await Task.WhenAll(LoadPersonTask, DriverTask);
            _driverid = DriverTask.Result.DriverId; 
            var ListIntLicensesTask = _internationalLicenseClientService.ListIntLicensesAsync(_driverid);
            var ListLocalLicensesTask = _licenseClientService.ListLocalLicensesAsync(_driverid);
            await Task.WhenAll(ListIntLicensesTask, ListLocalLicensesTask);
            IntDataGrid.DataSource = ListIntLicensesTask.Result;
            Localdatagrid.DataSource = ListLocalLicensesTask.Result; 
            lbRecord.Text = Localdatagrid.RowCount.ToString();
        }
    }
}
