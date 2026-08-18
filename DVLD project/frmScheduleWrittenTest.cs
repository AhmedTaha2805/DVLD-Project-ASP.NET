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
    public partial class frmScheduleWrittenTest : Form
    {
        int CLDLAppID;
        private readonly TestClientService _testClient;
        private readonly TestAppointmentClientService _testAppointmentClient;

        public frmScheduleWrittenTest(int LDLAppID)
        {
            InitializeComponent();
            _testClient = new TestClientService();
            _testAppointmentClient = new TestAppointmentClientService();
            CLDLAppID = LDLAppID;
        }

        private async Task RefreshDataGrid(int AppID)
        {
            Appointmentsdatagrid.DataSource =await _testAppointmentClient.GetTestAppointmentsByLDLAppId(AppID, 2);
        }

        private async void frmScheduleWrittenTest_Load(object sender, EventArgs e)
        {
            var AppTask = applicationInfoControl1.LoadAppInfo(CLDLAppID);
            var RefreshTask = RefreshDataGrid(CLDLAppID);
            await Task.WhenAll(AppTask, RefreshTask);
            lbRecord.Text = Appointmentsdatagrid.RowCount.ToString();
        }

        private async void btnSchedule_Click(object sender, EventArgs e)
        {
            if (await _testAppointmentClient.HasUnLockedAppointment(CLDLAppID, 2))
            {
                MessageBox.Show("Person has an unlocked appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (await _testClient.PersonPassedThisTestBefore(CLDLAppID, 2))
            {
                MessageBox.Show("Person passed this test before", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (await _testClient.PersonFailedThisTestBefore(CLDLAppID, 2))
            {
                frmWrittenTest frm = new frmWrittenTest(CLDLAppID,-1, true, applicationInfoControl1.AppID());
                frm.ShowDialog();
            }
            else
            {
                frmWrittenTest frm = new frmWrittenTest(CLDLAppID);
                frm.ShowDialog();
            }
            
            await RefreshDataGrid(CLDLAppID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private async void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Appointmentsdatagrid.SelectedRows[0].Cells["IsLocked"].Value))
            {
                MessageBox.Show("This Appointment Is Locked", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int id = int.Parse(Appointmentsdatagrid.SelectedRows[0].Cells["TestAppointmentID"].Value.ToString());
            string date = Appointmentsdatagrid.SelectedRows[0].Cells["AppointmentDate"].Value.ToString();
            frmTakeWrittenTest frm = new frmTakeWrittenTest(CLDLAppID, id, date);
            frm.ShowDialog();
            var AppTask = applicationInfoControl1.LoadAppInfo(CLDLAppID);
            var RefreshTask = RefreshDataGrid(CLDLAppID);
            await Task.WhenAll(AppTask, RefreshTask);
        }

        private async void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Appointmentsdatagrid.SelectedRows[0].Cells["TestAppointmentID"].Value.ToString());
            if(Convert.ToBoolean( Appointmentsdatagrid.SelectedRows[0].Cells["IsLocked"].Value))
            {
                MessageBox.Show("You Cannot edit a locked Appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmWrittenTest frm = new frmWrittenTest(CLDLAppID, id);
            frm.ShowDialog();
            await RefreshDataGrid(CLDLAppID);
            
            
        }
    }
}
