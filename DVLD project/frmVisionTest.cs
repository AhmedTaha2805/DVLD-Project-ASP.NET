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


namespace DVLD_project
{
    public partial class frmVisionTest : Form
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
        public frmVisionTest(int id,int Appointid = -1,bool Retake = false,int RTAppID = -1)
        {
            InitializeComponent();
            _applicationClientService = new ApplicationClientService();
            _licenseClassClientService = new LicenseClassClientService();
            _testAppointmentClientService = new TestAppointmentClientService();
            _localDrivingLicenseApplicationClientService = new LocalDrivingLicenseApplicationClientService();
            AppointID = Appointid;
            _Retake = Retake;
            _AppID = id;
        }

        private async void frmVisionTest_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Now;
            var LDLApp = await _localDrivingLicenseApplicationClientService.FindApplicationAsync(_AppID);
            var App = await _applicationClientService.FindApplication(LDLApp.ApplicationId);
            lbAppID.Text = _AppID.ToString();
            lbClass.Text = await _licenseClassClientService.GetLicenseClassNameById(LDLApp.LicenseClassId);
            clsPeople person = clsPeople.FindPerson(App.ApplicantPersonId);
            Person_ID = person.Id;
            lbName.Text = person.FullName();
            lbTrial.Text = (await _testAppointmentClientService.GetNumberOfTrials(LDLApp.LocalDrivingLicenseApplicationId, 1)).ToString();
            lbFees.Text = "10";
            if (_Retake)
            {
                groupBox2.Enabled = true;
                lbTitle.Text = "Schedule Retake Test";
                lbRetakeAppID.Text =(await _applicationClientService.GetNextId()).ToString();
                int total = Convert.ToInt32(lbFees.Text) + 5;
                lbTotalFees.Text = total.ToString();
            }

            IsDone = true;

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if(AppointID != -1)
            {
                await _testAppointmentClientService.UpdateAppointmentDate(AppointID, dateTimePicker1.Value);
                MessageBox.Show("Appointment Updated Successfully", "Congratulations", MessageBoxButtons.OK);
            }
            else if (IsDone)
            {
                TestAppointmentDTO dto = new TestAppointmentDTO
                {
                    TestTypeId = 1,
                    PaidFees = 10,
                    LocalDrivingLicenseApplicationId = int.Parse(lbAppID.Text),
                    AppointmentDate = dateTimePicker1.Value,
                    CreatedByUserId = CurrentUser.user.UserId,
                };
                if (_Retake)
                {
                    var App = await _applicationClientService.AddApplication(new ApplicationDTO
                    {
                        ApplicantPersonId = Person_ID,
                        PaidFees = 5,
                        ApplicationStatus = 3,
                        ApplicationDate = DateTime.Now,
                        ApplicationTypeId = 7,
                        LastStatusDate = DateTime.Now,
                        CreatedByUserId = CurrentUser.user.UserId
                    });
                    dto.RetakeTestApplicationId = int.Parse(lbRetakeAppID.Text);
                }
                await _testAppointmentClientService.AddTestAppointment(dto);
                MessageBox.Show("Appointment Added Successfully", "Congratulations", MessageBoxButtons.OK);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
