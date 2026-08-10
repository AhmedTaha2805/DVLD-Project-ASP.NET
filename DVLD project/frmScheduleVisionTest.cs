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
    public partial class frmScheduleVisionTest : Form
    {
        int CLDLAppID;
        public frmScheduleVisionTest(int LDLAppID)
        {
            InitializeComponent();
            CLDLAppID = LDLAppID;
            RefreshDataGrid();
            applicationInfoControl1.LoadAppInfo(LDLAppID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshDataGrid()
        {
            Appointmentsdatagrid.DataSource = clsTestAppointments.GetAppointments(CLDLAppID,1);
        }

        private void frmScheduleVisionTest_Load(object sender, EventArgs e)
        {
            
            lbRecord.Text = Appointmentsdatagrid.RowCount.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (clsTestAppointments.HasUnlockedAppointment(CLDLAppID, 1))
            {
                MessageBox.Show("Person has an unlocked appointment","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (clsTests.PersonPassedThisTestBefore(CLDLAppID, 1))
            {
                MessageBox.Show("Person passed this test before", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (clsTests.PersonFailedThisTest(CLDLAppID, 1))
            {
                frmVisionTest frm = new frmVisionTest(CLDLAppID,-1, true,applicationInfoControl1.AppID());
                frm.ShowDialog();
            }
            else
            {
                frmVisionTest frm = new frmVisionTest(CLDLAppID);
                frm.ShowDialog();
            }
            RefreshDataGrid();
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
            RefreshDataGrid();
            applicationInfoControl1.LoadAppInfo(CLDLAppID);

        }

        private void applicationInfoControl1_Load(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Appointmentsdatagrid.SelectedRows[0].Cells["Appointment ID"].Value.ToString());
            if (Convert.ToBoolean(Appointmentsdatagrid.SelectedRows[0].Cells["Is Locked"].Value))
            {
                MessageBox.Show("You Cannot edit a locked Appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmVisionTest frm = new frmVisionTest(CLDLAppID, id);
            frm.ShowDialog();
            RefreshDataGrid();
        }
    }
}
