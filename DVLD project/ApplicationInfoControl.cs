using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_project.Services;

namespace DVLD_project
{
    public partial class ApplicationInfoControl : UserControl
    {
        private readonly ApplicationTypeClientService _applicationtypeClientService;
        private readonly LicenseClassClientService _licenseClassClientService;
        private readonly ApplicationClientService _applicationClientService;
        private readonly LocalDrivingLicenseApplicationClientService _localDrivingLicenseApplicationClientService;
        private readonly UserClientService _userClientService;
        private readonly PeopleClientService _peopleClientService;
        public ApplicationInfoControl()
        {
            InitializeComponent();  
            _applicationtypeClientService = new ApplicationTypeClientService();
            _licenseClassClientService = new LicenseClassClientService();
            _applicationClientService = new ApplicationClientService();
            _userClientService = new UserClientService();
            _peopleClientService = new PeopleClientService();
            _localDrivingLicenseApplicationClientService = new LocalDrivingLicenseApplicationClientService();
        }

        public async Task LoadAppInfo(int LDLAppID)
        {
            lbLoading.Visible = true;
            var licenseApplication = await _localDrivingLicenseApplicationClientService.FindApplicationAsync(LDLAppID);
            lbLDLAppID.Text = LDLAppID.ToString();
            var lbLicenseTask = _licenseClassClientService.GetLicenseClassNameById(licenseApplication.LicenseClassId);
            var lbPassedTask = _localDrivingLicenseApplicationClientService.FindNumberOfPassedTestsAsync(LDLAppID);
            var AppTask = _applicationClientService.FindApplication(licenseApplication.ApplicationId);
            await Task.WhenAll(lbLicenseTask, lbPassedTask, AppTask);
            lbLicenseClass.Text = lbLicenseTask.Result;
            lbPassedTests.Text = $"{lbPassedTask.Result.ToString()}/3";
            var App = AppTask.Result;
            lbAppID.Text = App.ApplicationId.ToString();
            lbStatus.Text = _applicationClientService.GetStatus(App.ApplicationStatus);
            lbFees.Text = App.PaidFees.ToString();
            var LbTypeTask = _applicationtypeClientService.GetApplicationTypeTitleById(App.ApplicationTypeId);
            var PersonTask = _peopleClientService.FindPersonAsync(App.ApplicantPersonId);
            var UserTask = _userClientService.FindUserAsync(App.CreatedByUserId);
            await Task.WhenAll(LbTypeTask,PersonTask,UserTask);
            lbType.Text = LbTypeTask.Result; 
            var person = PersonTask.Result;
            lbApplicantName.Text = $"{person.FirstName} {person.SecondName} {person.ThirdName} {person.LastName} ";
            lbDate.Text = App.ApplicationDate.ToString();
            lbStatusDate.Text = App.LastStatusDate.ToString();
            var User = UserTask.Result;
            lbUserName.Text = User.UserName;
            if(lbStatus.Text == "Completed"){
                lnkShowLicense.Enabled = true;
            }
            lbLoading.Visible = false;
        }

        private async Task<int> GetPersonID()
        {
            var App = await _applicationClientService.FindApplication(int.Parse(lbAppID.Text));
            return App.ApplicantPersonId;
        }

        public int AppID()
        {
            return Convert.ToInt32(lbAppID.Text);
        }


        private async void lnkViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(await GetPersonID());
            frm.ShowDialog();
        }

        private void lnkShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(int.Parse(lbLDLAppID.Text));
            frm.ShowDialog();

        }
    }
}
