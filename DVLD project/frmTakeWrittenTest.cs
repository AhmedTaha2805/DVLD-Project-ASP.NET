using ApplicationBuisnessLayer;
using CurrentUserInformation;
using LicenseClassesBuisnessLayer;
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
using TestAppointmentsBuisnessLayer;
using TestsBuisnessLayer;

namespace DVLD_project
{
    public partial class frmTakeWrittenTest : Form
    {
        int AppointID;
        public frmTakeWrittenTest(int LDLAppID, int AppointmentID, string Date)
        {
            InitializeComponent();
            AppointID = AppointmentID;
            lbDate.Text = Date;
            clsLocalLicenseApplication LDLApp = clsLocalLicenseApplication.FindApplication(LDLAppID);
            clsApplications App = clsApplications.FindApplication(LDLApp.AppId);
            lbAppID.Text = LDLAppID.ToString();
            lbClass.Text = clsLicenseClasses.GetLicenseClassName(LDLApp.LicenseClassID);
            clsPeople person = clsPeople.FindPerson(App.PersonID);
            lbName.Text = person.FullName();
            lbTrial.Text = clsTestAppointments.GetNumberOfTrials(LDLApp.LocalAppID, 2).ToString();
            lbFees.Text = "20";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!rbPass.Checked && !rbFail.Checked)
            {
                MessageBox.Show("Choose The Result", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clsTests Test = new clsTests();
            Test.TestAppointmentID = AppointID;
            Test.CreatedByUserID = CurrentUser.user.UserID;
            Test.notes = txtnotes.Text;
            Test.TestResult = rbPass.Checked ? 1 : 0;
            Test.AddTest();
            clsTestAppointments.LockAppointment(AppointID);
            btnSave.Enabled = false;
            lbTestID.Text = Test.TestID.ToString();
            MessageBox.Show("Test Done Successfully", "Congratulations", MessageBoxButtons.OK);
        }
    }
}
