using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationBuisnessLayer;
using DVLD_project.Services;
using LicensesBuisnessLayer;
using LocalDrivingLicenseApplicationsBuisnessLayer;
using TestAppointmentsBuisnessLayer;
using TestsBuisnessLayer;


namespace DVLD_project
{
    public partial class frmLocalDrivingLicenseApplications : Form
    {
        private readonly TestClientService _testClient;
        private readonly TestAppointmentClientService _testAppointmentClient;
        private readonly ApplicationClientService _applicationClientService;
        private readonly LocalDrivingLicenseApplicationClientService _localDrivingLicenseApplicationClientService;
        private readonly LicenseClientService _licenseClientService;
        public frmLocalDrivingLicenseApplications()
        {
            InitializeComponent();
            _licenseClientService = new LicenseClientService();
            _testAppointmentClient = new TestAppointmentClientService();
            _applicationClientService = new ApplicationClientService();
            _localDrivingLicenseApplicationClientService = new LocalDrivingLicenseApplicationClientService();
            _testClient = new TestClientService();
        }

        private async Task RefreshDataGrid()
        {
            LocalAppsdatagrid.DataSource = await _localDrivingLicenseApplicationClientService.GetAllLocalAppsAsync();
        }

        private void txtFilters_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilters.Text == "L.D.L.AppID" || cbFilters.Text == "Passed Tests")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (cbFilters.Text == "Full Name" || cbFilters.Text == "Status")
            {
                if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private async void txtFilters_TextChanged(object sender, EventArgs e)
        {
            DataView dv = (await _localDrivingLicenseApplicationClientService.GetAllLocalAppsAsDataTableAsync()).DefaultView;

            dv.RowFilter = $"Convert([{cbFilters.Text}],'System.String') like '{txtFilters.Text}%'";

            LocalAppsdatagrid.DataSource = dv;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void frmLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            await RefreshDataGrid();
        }

        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilters.Visible = true;
        }

        private async void btnAddApp_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicenseApplication frm = new frmNewLocalDrivingLicenseApplication();
            frm.ShowDialog();
            await RefreshDataGrid();
        }

        private void LocalAppsdatagrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.Button == MouseButtons.Right)
            {
                LocalAppsdatagrid.ClearSelection();
                LocalAppsdatagrid.Rows[e.RowIndex].Selected = true;

                contextMenuStrip1.Show(Cursor.Position);
                if (LocalAppsdatagrid.SelectedRows[0].Cells["Status"].Value.ToString() == "Cancelled")
                {
                    editApplicationToolStripMenuItem.Enabled = false;
                    cancelApplicationToolStripMenuItem.Enabled = false;                  
                    showLicenseToolStripMenuItem.Enabled = false;
                    showPersonLicenseHistoryToolStripMenuItem.Enabled = false;
                    deleteApplicationToolStripMenuItem.Enabled = false;
                    issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                    scheduleTestsToolStripMenuItem.Enabled = false;
                    return;
                }
                else
                {
                    editApplicationToolStripMenuItem.Enabled = true;
                    cancelApplicationToolStripMenuItem.Enabled = true;
                    showLicenseToolStripMenuItem.Enabled = true;
                    showPersonLicenseHistoryToolStripMenuItem.Enabled = true;
                    deleteApplicationToolStripMenuItem.Enabled = true;
                    issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
                    scheduleTestsToolStripMenuItem.Enabled = true;
                }
                if (LocalAppsdatagrid.SelectedRows[0].Cells["Status"].Value.ToString() == "Completed")
                {
                    editApplicationToolStripMenuItem.Enabled = false;
                    cancelApplicationToolStripMenuItem.Enabled = false;
                    showLicenseToolStripMenuItem.Enabled = true;
                    showPersonLicenseHistoryToolStripMenuItem.Enabled = true;
                    deleteApplicationToolStripMenuItem.Enabled = false;
                    issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                    scheduleTestsToolStripMenuItem.Enabled = false;
                    return;
                }
                else
                {
                    editApplicationToolStripMenuItem.Enabled = true;
                    cancelApplicationToolStripMenuItem.Enabled = true;
                    showLicenseToolStripMenuItem.Enabled = true;
                    showPersonLicenseHistoryToolStripMenuItem.Enabled = true;
                    deleteApplicationToolStripMenuItem.Enabled = true;
                    issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
                    scheduleTestsToolStripMenuItem.Enabled = true;
                }
                if (int.Parse(LocalAppsdatagrid.SelectedRows[0].Cells["Passed Tests"].Value.ToString()) != 3)
                {
                    issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                    showLicenseToolStripMenuItem.Enabled = false;
                    showPersonLicenseHistoryToolStripMenuItem.Enabled = false;
                }
                else
                {
                    issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
                    showLicenseToolStripMenuItem.Enabled = true;
                    showPersonLicenseHistoryToolStripMenuItem.Enabled = true;
                }
                if(int.Parse(LocalAppsdatagrid.SelectedRows[0].Cells["Passed Tests"].Value.ToString()) != 0)
                {
                    scheduleVisionTestToolStripMenuItem.Enabled = false;
                }
                else
                {
                    scheduleVisionTestToolStripMenuItem.Enabled = true;
                }
                if (int.Parse(LocalAppsdatagrid.SelectedRows[0].Cells["Passed Tests"].Value.ToString()) != 1)
                {
                    scheduleWrittenTestToolStripMenuItem.Enabled = false;
                }
                else
                {
                    scheduleWrittenTestToolStripMenuItem.Enabled = true;
                }
                if (int.Parse(LocalAppsdatagrid.SelectedRows[0].Cells["Passed Tests"].Value.ToString()) != 2)
                {
                    scheduleStreetTestToolStripMenuItem.Enabled = false;
                }
                else
                {
                    scheduleStreetTestToolStripMenuItem.Enabled = true;
                }
                


            }
        }

        private async void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string status = LocalAppsdatagrid.SelectedRows[0].Cells["Status"].Value.ToString();
            if(status == "Cancelled"){
                MessageBox.Show("Application is already cancelled", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (status == "Completed")
            {
                MessageBox.Show("You can't cancel a completed Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int id = int.Parse(LocalAppsdatagrid.SelectedRows[0].Cells["L.D.L AppID"].Value.ToString());
            var app = await _localDrivingLicenseApplicationClientService.FindApplicationAsync(id);
            await _applicationClientService.CancelApplication(app.ApplicationId);
            MessageBox.Show($"Application with id = {id} is cancelled", "Congratulations", MessageBoxButtons.OK);
            await RefreshDataGrid();  
        }

        private async void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(LocalAppsdatagrid.SelectedRows[0].Cells["L.D.L AppID"].Value.ToString());
            frmScheduleVisionTest frm = new frmScheduleVisionTest(id);
            frm.ShowDialog();
            await RefreshDataGrid();
        }

        private async void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(LocalAppsdatagrid.SelectedRows[0].Cells["L.D.L AppID"].Value.ToString());
            frmScheduleWrittenTest frm = new frmScheduleWrittenTest(id);
            frm.ShowDialog();
            await RefreshDataGrid();
        }

        private async void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(LocalAppsdatagrid.SelectedRows[0].Cells["L.D.L AppID"].Value.ToString());
            FrmScheduleStreetTest frm = new FrmScheduleStreetTest(id);
            frm.ShowDialog();
            await RefreshDataGrid();
        }

        private void showApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(LocalAppsdatagrid.SelectedRows[0].Cells["L.D.L AppID"].Value.ToString());
            frmShowApplicationDetails frm = new frmShowApplicationDetails(id);
            frm.ShowDialog();
        }

        private async void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(LocalAppsdatagrid.SelectedRows[0].Cells["L.D.L AppID"].Value.ToString());
            frmNewLocalDrivingLicenseApplication frm = new frmNewLocalDrivingLicenseApplication(id);
            frm.ShowDialog();
            await RefreshDataGrid();
        }

        private async void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string status = LocalAppsdatagrid.SelectedRows[0].Cells["Status"].Value.ToString();
            if (status == "Completed")
            {
                MessageBox.Show("You can't delete a completed Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int id = int.Parse(LocalAppsdatagrid.SelectedRows[0].Cells["L.D.L AppID"].Value.ToString());
            var list = await _testAppointmentClient.GetTestAppointmentsIdsByLDLAppId(id);
            foreach (var n in list)
            {
                await _testClient.DeleteTestWithAppointmentId(n);
            }
            await _testAppointmentClient.DeleteAppointmentsWithLDLAppId(id);
            var application = await _localDrivingLicenseApplicationClientService.FindApplicationAsync(id);
            await _localDrivingLicenseApplicationClientService.DeleteApplicationAsync(id);
           
            await _applicationClientService.DeleteApplication(application.ApplicationId);

            if(MessageBox.Show("Are You sure you want to delete this application?","Confirm",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                MessageBox.Show("Application deleted successfully", "Congratulations", MessageBoxButtons.OK);
            }
            await RefreshDataGrid();

        }

        private async void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(LocalAppsdatagrid.SelectedRows[0].Cells["L.D.L AppID"].Value.ToString());
            frmIssueDrivingLicenseFirstTime frm = new frmIssueDrivingLicenseFirstTime(id);
            frm.ShowDialog();
            await RefreshDataGrid();
        }

        private async void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(LocalAppsdatagrid.SelectedRows[0].Cells["L.D.L AppID"].Value.ToString());
            var LApp = await _localDrivingLicenseApplicationClientService.FindApplicationAsync(id);
            var License = await _licenseClientService.FindLicenseByApplicationIDAsync(LApp.LocalDrivingLicenseApplicationId);
            frmLicenseInfo frm = new frmLicenseInfo(License.LicenseId);  
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nationalno = LocalAppsdatagrid.SelectedRows[0].Cells["National No"].Value.ToString();
            frmShowLicenseHistory frm = new frmShowLicenseHistory(nationalno);
            frm.ShowDialog();

        }
    }
}
