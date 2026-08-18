
using CurrentUserInformation;
using DTOs;
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
    public partial class frmTakeWrittenTest : Form
    {
        int AppointID;
        int _LDLAppID;
        private readonly LicenseClassClientService _licenseClassClientService;
        private readonly TestClientService _testClient;
        private readonly TestAppointmentClientService _testAppointmentClientService;
        private readonly ApplicationClientService _applicationClientService;
        private readonly LocalDrivingLicenseApplicationClientService _localDrivingLicenseApplicationClientService;
        private readonly PeopleClientService _peopleClientService;
        public frmTakeWrittenTest(int LDLAppID, int AppointmentID, string Date)
        {
            InitializeComponent();
            _applicationClientService = new ApplicationClientService();
            _licenseClassClientService = new LicenseClassClientService();
            _testClient = new TestClientService();
            _testAppointmentClientService = new TestAppointmentClientService();
            _localDrivingLicenseApplicationClientService = new LocalDrivingLicenseApplicationClientService();
            _peopleClientService = new PeopleClientService();
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
                CreatedByUserId = CurrentUser.user.UserId,
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
            var AppTask = _applicationClientService.FindApplication(LDLApp.ApplicationId);
            var ClassTask = _licenseClassClientService.GetLicenseClassNameById(LDLApp.LicenseClassId);
            await Task.WhenAll(AppTask, ClassTask);
            var App = AppTask.Result;
            lbAppID.Text = _LDLAppID.ToString();
            lbClass.Text = ClassTask.Result.ToString();
            var persontask = _peopleClientService.FindPersonAsync(App.ApplicantPersonId);
            var TrialTask = _testAppointmentClientService.GetNumberOfTrials(LDLApp.LocalDrivingLicenseApplicationId, 2);
            await Task.WhenAll(AppTask, TrialTask);
            var person = persontask.Result;
            lbName.Text = $"{person.FirstName} {person.SecondName} {person.ThirdName} {person.LastName}";
            lbTrial.Text = TrialTask.Result.ToString();
            lbFees.Text = "20";
        }
    }
}
