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
using LicensesBuisnessLayer;
using LocalDrivingLicenseApplicationsBuisnessLayer;
using TestAppointmentsBuisnessLayer;
using TestsBuisnessLayer;


namespace DVLD_project
{
    public partial class frmLocalDrivingLicenseApplications : Form
    {
        public frmLocalDrivingLicenseApplications()
        {
            InitializeComponent();
            
        }

        private void RefreshDataGrid()
        {
            LocalAppsdatagrid.DataSource = clsLocalLicenseApplication.GetAllLocalApps();
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

        private void txtFilters_TextChanged(object sender, EventArgs e)
        {
            DataView dv = clsLocalLicenseApplication.GetAllLocalApps().DefaultView;

            dv.RowFilter = $"Convert([{cbFilters.Text}],'System.String') like '{txtFilters.Text}%'";

            LocalAppsdatagrid.DataSource = dv;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilters.Visible = true;
        }

        private void btnAddApp_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicenseApplication frm = new frmNewLocalDrivingLicenseApplication();
            frm.ShowDialog();
            RefreshDataGrid();
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

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
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
            clsLocalLicenseApplication app = clsLocalLicenseApplication.FindApplication(id);
            clsApplications.CancelApplication(app.AppId);
            MessageBox.Show($"Application with id = {id} is cancelled", "Congratulations", MessageBoxButtons.OK);
            RefreshDataGrid();  
        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(LocalAppsdatagrid.SelectedRows[0].Cells["L.D.L AppID"].Value.ToString());
            frmScheduleVisionTest frm = new frmScheduleVisionTest(id);
            frm.ShowDialog();
            RefreshDataGrid();
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(LocalAppsdatagrid.SelectedRows[0].Cells["L.D.L AppID"].Value.ToString());
            frmScheduleWrittenTest frm = new frmScheduleWrittenTest(id);
            frm.ShowDialog();
            RefreshDataGrid();
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(LocalAppsdatagrid.SelectedRows[0].Cells["L.D.L AppID"].Value.ToString());
            FrmScheduleStreetTest frm = new FrmScheduleStreetTest(id);
            frm.ShowDialog();
            RefreshDataGrid();
        }

        private void showApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(LocalAppsdatagrid.SelectedRows[0].Cells["L.D.L AppID"].Value.ToString());
            frmShowApplicationDetails frm = new frmShowApplicationDetails(id);
            frm.ShowDialog();


        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(LocalAppsdatagrid.SelectedRows[0].Cells["L.D.L AppID"].Value.ToString());
            frmNewLocalDrivingLicenseApplication frm = new frmNewLocalDrivingLicenseApplication(id);
            frm.ShowDialog();
            RefreshDataGrid();
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string status = LocalAppsdatagrid.SelectedRows[0].Cells["Status"].Value.ToString();
            if (status == "Completed")
            {
                MessageBox.Show("You can't delete a completed Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int id = int.Parse(LocalAppsdatagrid.SelectedRows[0].Cells["L.D.L AppID"].Value.ToString());
            DataTable dt = clsTestAppointments.GetAllAppointmentsWithID(id);
            foreach (DataRow row in dt.Rows)
            {
                clsTests.DeleteTestWithAppointmentID(Convert.ToInt32(row["Appointment ID"].ToString()));
            }
            clsTestAppointments.DeleteAppointmentsWithAppID(id);
            clsLocalLicenseApplication application = clsLocalLicenseApplication.FindApplication(id);
            clsLocalLicenseApplication.DeleteApplication(id);
           
            clsApplications.DeleteApplication(application.AppId);

            if(MessageBox.Show("Are You sure you want to delete this application?","Confirm",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                MessageBox.Show("Application deleted successfully", "Congratulations", MessageBoxButtons.OK);
            }
            RefreshDataGrid();

        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(LocalAppsdatagrid.SelectedRows[0].Cells["L.D.L AppID"].Value.ToString());
            frmIssueDrivingLicenseFirstTime frm = new frmIssueDrivingLicenseFirstTime(id);
            frm.ShowDialog();
            RefreshDataGrid();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(LocalAppsdatagrid.SelectedRows[0].Cells["L.D.L AppID"].Value.ToString());
            clsLocalLicenseApplication LApp = clsLocalLicenseApplication.FindApplication(id);
            clsLicenses License = clsLicenses.FindLicenseByApplicationID(LApp.LocalAppID);
            frmLicenseInfo frm = new frmLicenseInfo(License.LicenseID);  
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
