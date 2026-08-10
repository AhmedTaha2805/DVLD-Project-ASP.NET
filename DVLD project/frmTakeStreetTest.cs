using ApplicationBuisnessLayer;
using CurrentUserInformation;
using DVLD_project.Services;
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
    public partial class frmTakeStreetTest : Form
    {
        int AppointID;
        int _LDLAppID;
        private readonly LicenseClassClientService _licenseClassClientService;
        public frmTakeStreetTest(int LDLAppID, int AppointmentID, string Date)
        {
            InitializeComponent();
            _licenseClassClientService = new LicenseClassClientService();
            lbDate.Text = Date;
            AppointID = AppointmentID;
            _LDLAppID = LDLAppID;   
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

        private async void frmTakeStreetTest_Load(object sender, EventArgs e)
        {
            clsLocalLicenseApplication LDLApp = clsLocalLicenseApplication.FindApplication(_LDLAppID);
            clsApplications App = clsApplications.FindApplication(LDLApp.AppId);
            lbAppID.Text = _LDLAppID.ToString();
            lbClass.Text = await _licenseClassClientService.GetLicenseClassNameById(LDLApp.LicenseClassID);
            clsPeople person = clsPeople.FindPerson(App.PersonID);
            lbName.Text = person.FullName();
            lbTrial.Text = clsTestAppointments.GetNumberOfTrials(LDLApp.LocalAppID, 3).ToString();
            lbFees.Text = "30";
        }
    }
}
