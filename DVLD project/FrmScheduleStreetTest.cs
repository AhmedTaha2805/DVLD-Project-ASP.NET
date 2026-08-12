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
using TestAppointmentsBuisnessLayer;
using TestsBuisnessLayer;

namespace DVLD_project
{
    public partial class FrmScheduleStreetTest : Form
    {
        int CLDLAppID;
        private readonly TestClientService _testClient;
        private readonly TestAppointmentClientService _testAppointmentClientService;
        public FrmScheduleStreetTest(int LDLAppID)
        {
            InitializeComponent();
            _testClient = new TestClientService();
            _testAppointmentClientService = new TestAppointmentClientService();
            CLDLAppID = LDLAppID;
            applicationInfoControl1.LoadAppInfo(LDLAppID);
        }

        private async Task RefreshDataGrid(int AppID)
        {
            Appointmentsdatagrid.DataSource = await _testAppointmentClientService.GetTestAppointmentsByLDLAppId(AppID, 3);
        }

        private async void FrmScheduleStreetTest_Load(object sender, EventArgs e)
        {
            await RefreshDataGrid(CLDLAppID);
            lbRecord.Text = Appointmentsdatagrid.RowCount.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSchedule_Click(object sender, EventArgs e)
        {
            if (await _testAppointmentClientService.HasUnLockedAppointment(CLDLAppID, 3))
            {
                MessageBox.Show("Person has an unlocked appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (await _testClient.PersonPassedThisTestBefore(CLDLAppID, 3))
            {
                MessageBox.Show("Person passed this test before", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (await _testClient.PersonFailedThisTestBefore(CLDLAppID, 3))
            {
                frmStreetTest frm = new frmStreetTest(CLDLAppID,-1, true, applicationInfoControl1.AppID());
                frm.ShowDialog();
            }
            else
            {
                frmStreetTest frm = new frmStreetTest(CLDLAppID);
                frm.ShowDialog();
            }

            RefreshDataGrid(CLDLAppID);
        }

        private void Appointmentsdatagrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.Button == MouseButtons.Right)
            {
                Appointmentsdatagrid.ClearSelection();
                Appointmentsdatagrid.Rows[e.RowIndex].Selected = true;

                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Appointmentsdatagrid.SelectedRows[0].Cells["Is Locked"].Value))
            {
                MessageBox.Show("This Appointment Is Locked", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int id = int.Parse(Appointmentsdatagrid.SelectedRows[0].Cells["Appointment ID"].Value.ToString());
            string date = Appointmentsdatagrid.SelectedRows[0].Cells["Appointment Date"].Value.ToString();
            frmTakeVisionTest frm = new frmTakeVisionTest(CLDLAppID, id, date);
            frm.ShowDialog();
            RefreshDataGrid(CLDLAppID);
            applicationInfoControl1.LoadAppInfo(CLDLAppID);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Appointmentsdatagrid.SelectedRows[0].Cells["Appointment ID"].Value.ToString());
            if (Convert.ToBoolean(Appointmentsdatagrid.SelectedRows[0].Cells["Is Locked"].Value))
            {
                MessageBox.Show("You Cannot edit a locked Appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmStreetTest frm = new frmStreetTest(CLDLAppID, id);
            frm.ShowDialog();
            RefreshDataGrid(CLDLAppID);
        }

       
    }
}
