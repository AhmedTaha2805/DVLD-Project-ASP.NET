using ApplicationBuisnessLayer;
using CurrentUserInformation;
using DTOs;
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
    public partial class frmTakeWrittenTest : Form
    {
        int AppointID;
        int _LDLAppID;
        private readonly LicenseClassClientService _licenseClassClientService;
        private readonly TestClientService _testClient;
        private readonly TestAppointmentClientService _testAppointmentClientService;
        private readonly ApplicationClientService _applicationClientService;
        private readonly LocalDrivingLicenseApplicationClientService _localDrivingLicenseApplicationClientService;
        public frmTakeWrittenTest(int LDLAppID, int AppointmentID, string Date)
        {
            InitializeComponent();
            _applicationClientService = new ApplicationClientService();
            _licenseClassClientService = new LicenseClassClientService();
            _testClient = new TestClientService();
            _testAppointmentClientService = new TestAppointmentClientService();
            _localDrivingLicenseApplicationClientService = new LocalDrivingLicenseApplicationClientService();
            AppointID = AppointmentID;
            lbDate.Text = Date;
            _LDLAppID = LDLAppID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!rbPass.Checked && !rbFail.Checked)
            {
                MessageBox.Show("Choose The Result", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //clsTests Test = new clsTests();
            //Test.TestAppointmentID = AppointID;
            //Test.CreatedByUserID = CurrentUser.user.UserID;
            //Test.notes = txtnotes.Text;
            //Test.TestResult = rbPass.Checked ? 1 : 0;
            //Test.AddTest();
            var Test = await _testClient.AddTest(new TestDTO
            {
                TestAppointmentId = AppointID,
                CreatedByUserId = CurrentUser.user.UserID,
                Notes = txtnotes.Text,
                TestResult = rbPass.Checked ? true : false
            });
            await _testAppointmentClientService.LockAppointment(AppointID);
            btnSave.Enabled = false;
            lbTestID.Text = Test.TestId.ToString();
            MessageBox.Show("Test Done Successfully", "Congratulations", MessageBoxButtons.OK);
        }

        private async void frmTakeWrittenTest_Load(object sender, EventArgs e)
        {
            var LDLApp = await _localDrivingLicenseApplicationClientService.FindApplicationAsync(_LDLAppID);
            var App = await _applicationClientService.FindApplication(LDLApp.ApplicationId);
            lbAppID.Text = _LDLAppID.ToString();
            lbClass.Text = await _licenseClassClientService.GetLicenseClassNameById(LDLApp.LicenseClassId);
            clsPeople person = clsPeople.FindPerson(App.ApplicantPersonId);
            lbName.Text = person.FullName();
            lbTrial.Text = (await _testAppointmentClientService.GetNumberOfTrials(LDLApp.LocalDrivingLicenseApplicationId, 2)).ToString();
            lbFees.Text = "20";
        }
    }
}
