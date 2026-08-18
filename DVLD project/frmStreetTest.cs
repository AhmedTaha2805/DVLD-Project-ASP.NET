
using CurrentUserInformation;
using DTOs;
using DVLD_project.Services;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DVLD_project
{
    public partial class frmStreetTest : Form
    {
        bool IsDone = false;
        bool _Retake = false;
        int Person_ID;
        int AppointID;
        int _AppID;
        private readonly LicenseClassClientService _licenseClassClientService;
        private readonly TestAppointmentClientService _testAppointmentClientService;
        private readonly ApplicationClientService _applicationClientService;
        private readonly LocalDrivingLicenseApplicationClientService _localDrivingLicenseApplicationClientService;
        private readonly PeopleClientService _peopleClientService;
        public frmStreetTest(int id,int Appointid = -1, bool Retake = false, int RTAppID = -1)
        {
            InitializeComponent(); 
            _applicationClientService = new ApplicationClientService();
            _licenseClassClientService = new LicenseClassClientService();
            _testAppointmentClientService = new TestAppointmentClientService();
            _localDrivingLicenseApplicationClientService = new LocalDrivingLicenseApplicationClientService();
            _peopleClientService = new PeopleClientService();
            AppointID = Appointid;
            _AppID = id;
            _Retake = Retake;
        }

        private async void frmStreetTest_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Now;
            var LDLApp = await _localDrivingLicenseApplicationClientService.FindApplicationAsync(_AppID);
            var App = await _applicationClientService.FindApplication(LDLApp.ApplicationId);
            lbAppID.Text = _AppID.ToString();
            lbClass.Text = await _licenseClassClientService.GetLicenseClassNameById(LDLApp.LicenseClassId);
            var persontask =  _peopleClientService.FindPersonAsync(App.ApplicantPersonId);
            var TrialTask = _testAppointmentClientService.GetNumberOfTrials(LDLApp.LocalDrivingLicenseApplicationId, 3);
            await Task.WhenAll(persontask, TrialTask);
            var person = persontask.Result;
            Person_ID = person.PersonId;
            lbName.Text =  $"{person.FirstName} {person.SecondName} {person.ThirdName} {person.LastName}";
            lbTrial.Text = TrialTask.Result.ToString();
            lbFees.Text = "30";
            if (_Retake)
            {
                groupBox2.Enabled = true;
                lbTitle.Text = "Schedule Retake Test";
                lbRetakeAppID.Text = (await _applicationClientService.GetNextId()).ToString();
                int total = Convert.ToInt32(lbFees.Text) + 5;
                lbTotalFees.Text = total.ToString();
            }
            IsDone = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (AppointID != -1)
            {
                await _testAppointmentClientService.UpdateAppointmentDate(AppointID, dateTimePicker1.Value);
                MessageBox.Show("Appointment Updated Successfully", "Congratulations", MessageBoxButtons.OK);
            }
            if (IsDone)
            {
                TestAppointmentDTO dto = new TestAppointmentDTO
                {
                    TestTypeId = 3,
                    PaidFees = 30,
                    LocalDrivingLicenseApplicationId = int.Parse(lbAppID.Text),
                    AppointmentDate = dateTimePicker1.Value,
                    CreatedByUserId = CurrentUser.user.UserId,
                };
                if (_Retake)
                {
                    var App = await _applicationClientService.AddApplication(new ApplicationDTO
                    {
                        ApplicantPersonId = Person_ID,
                        ApplicationDate = DateTime.Now,
                        ApplicationTypeId = 7,
                        ApplicationStatus = 3,
                        LastStatusDate = DateTime.Now,
                        PaidFees = 5,
                        CreatedByUserId = CurrentUser.user.UserId
                    });
                    dto.RetakeTestApplicationId = App.ApplicationId;
                }
                await _testAppointmentClientService.AddTestAppointment(dto);
                MessageBox.Show("Appointment Added Successfully", "Congratulations", MessageBoxButtons.OK);
            }
        }
    }
}
