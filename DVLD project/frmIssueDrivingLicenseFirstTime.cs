using ApplicationBuisnessLayer;
using CurrentUserInformation;
using DriversBuisnessLayer;
using DVLD_project.Services;
using LicenseClassesBuisnessLayer;
using LicensesBuisnessLayer;
using LocalDrivingLicenseApplicationsBuisnessLayer;
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
    public partial class frmIssueDrivingLicenseFirstTime : Form
    {
        int CLDLAppID;
        private readonly LicenseClassClientService _licenseClassClientService;
        private readonly ApplicationClientService _applicationClientService;
        public frmIssueDrivingLicenseFirstTime(int LDLAppID)
        {
            InitializeComponent();
            _licenseClassClientService = new LicenseClassClientService();
            _applicationClientService = new ApplicationClientService();
            CLDLAppID = LDLAppID;
            applicationInfoControl1.LoadAppInfo(LDLAppID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            clsLocalLicenseApplication LApp = clsLocalLicenseApplication.FindApplication(CLDLAppID);
            var App = await _applicationClientService.FindApplication(LApp.AppId);
            clsLicenses license = new clsLicenses();
            license.AppID = LApp.AppId;
            license.LicenseClassID = LApp.LicenseClassID;
            license.IssueDate = DateTime.Now;
            Byte length = await _licenseClassClientService.GetLicenseClassValidityLengthById(license.LicenseClassID);
            license.ExpirationDate = DateTime.Now.AddYears(length);
            license.notes = txtnotes.Text;
            license.PaidFees = (int)await _licenseClassClientService.GetLicenseClassFeesById(license.LicenseClassID);
            license.IsActive = true;
            license.IssueReason = 1;
            license.CreatedByUserID = CurrentUser.user.UserID;
            clsDrivers driver = new clsDrivers();
            driver.PersonID = App.ApplicantPersonId;
            driver.CreatedByUserID = CurrentUser.user.UserID;
            driver.CreatedDate = DateTime.Now;
            driver.AddDriver();
            license.DriverID = driver.DriverID;
            license.AddLicense();
            App.LastStatusDate = DateTime.Now;
            App.ApplicationStatus = 3;
            await _applicationClientService.UpdateApplication(App);
            
            MessageBox.Show("License Added Successfully","Congratulations",MessageBoxButtons.OK);
        }
    }
}
