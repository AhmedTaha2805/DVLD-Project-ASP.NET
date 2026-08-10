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
        
        public FrmScheduleStreetTest(int LDLAppID)
        {
            InitializeComponent();
            CLDLAppID = LDLAppID;
            applicationInfoControl1.LoadAppInfo(LDLAppID);
        }

        private void RefreshDataGrid(int AppID)
        {
            Appointmentsdatagrid.DataSource = clsTestAppointments.GetAppointments(AppID, 3);
        }

        private void FrmScheduleStreetTest_Load(object sender, EventArgs e)
        {
            RefreshDataGrid(CLDLAppID);
            lbRecord.Text = Appointmentsdatagrid.RowCount.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            if (clsTestAppointments.HasUnlockedAppointment(CLDLAppID, 3))
            {
                MessageBox.Show("Person has an unlocked appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (clsTests.PersonPassedThisTestBefore(CLDLAppID, 3))
            {
                MessageBox.Show("Person passed this test before", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (clsTests.PersonFailedThisTest(CLDLAppID, 3))
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
