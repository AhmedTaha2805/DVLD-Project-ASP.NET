using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocalDrivingLicenseApplicationsBuisnessLayer;
using ApplicationBuisnessLayer;
using ApplicationTypesBuisnessLayer;
using LicenseClassesBuisnessLayer;
using PeopleBuisnessLayer;
using UsersBuisnessLayer;
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
            lbLicenseClass.Text = await _licenseClassClientService.GetLicenseClassNameById(licenseApplication.LicenseClassId);
            lbPassedTests.Text = $"{(await _localDrivingLicenseApplicationClientService.FindNumberOfPassedTestsAsync(LDLAppID)).ToString()}/3";
            var App = await _applicationClientService.FindApplication(licenseApplication.ApplicationId);
            lbAppID.Text = App.ApplicationId.ToString();
            lbStatus.Text = _applicationClientService.GetStatus(App.ApplicationStatus);
            lbFees.Text = App.PaidFees.ToString();
            lbType.Text = await _applicationtypeClientService.GetApplicationTypeTitleById(App.ApplicationTypeId);
            var person = await _peopleClientService.FindPersonAsync(App.ApplicantPersonId);
            lbApplicantName.Text = $"{person.FirstName} {person.SecondName} {person.ThirdName} {person.LastName} ";
            lbDate.Text = App.ApplicationDate.ToString();
            lbStatusDate.Text = App.LastStatusDate.ToString();
            var User = await _userClientService.FindUserAsync(App.CreatedByUserId);
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
