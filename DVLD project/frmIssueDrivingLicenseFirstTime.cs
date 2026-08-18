
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
    public partial class frmIssueDrivingLicenseFirstTime : Form
    {
        int CLDLAppID;
        private readonly LicenseClassClientService _licenseClassClientService;
        private readonly ApplicationClientService _applicationClientService;
        private readonly LocalDrivingLicenseApplicationClientService _localDrivingLicenseApplicationClientService;
        private readonly LicenseClientService _licenseClientService;
        private readonly DriverClientService _driverClientService;
        public frmIssueDrivingLicenseFirstTime(int LDLAppID)
        {
            InitializeComponent();
            _licenseClientService = new LicenseClientService();
            _licenseClassClientService = new LicenseClassClientService();
            _applicationClientService = new ApplicationClientService();
            _driverClientService = new DriverClientService();
            _localDrivingLicenseApplicationClientService = new LocalDrivingLicenseApplicationClientService();
            CLDLAppID = LDLAppID;
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var LApp = await _localDrivingLicenseApplicationClientService.FindApplicationAsync(CLDLAppID);
                var App = await _applicationClientService.FindApplication(LApp.ApplicationId);
                var driver = await _driverClientService.AddDriverAsync(new DriverDTO
                {
                    PersonId = App.ApplicantPersonId,
                    CreatedByUserId = CurrentUser.user.UserId,
                    CreatedDate = DateTime.Now
                });
                Byte length = await _licenseClassClientService.GetLicenseClassValidityLengthById(LApp.LicenseClassId);
                var license = await _licenseClientService.AddLicenseAsync(new LicenseDTO
                {
                    ApplicationId = LApp.ApplicationId,
                    LicenseClass = LApp.LicenseClassId,
                    IssueDate = DateTime.Now,
                    ExpirationDate = DateTime.Now.AddYears(length),
                    Notes = txtnotes.Text,
                    PaidFees = await _licenseClassClientService.GetLicenseClassFeesById(LApp.LicenseClassId),
                    IsActive = true,
                    IssueReason = 1,
                    CreatedByUserId = CurrentUser.user.UserId,
                    DriverId = driver.DriverId,
                });
                App.LastStatusDate = DateTime.Now;
                App.ApplicationStatus = 3;
                await _applicationClientService.UpdateApplication(App);

                MessageBox.Show("License Added Successfully", "Congratulations", MessageBoxButtons.OK);
            }
            catch(Exception ex)
            {

            }
        }

        private async void frmIssueDrivingLicenseFirstTime_Load(object sender, EventArgs e)
        {
            await applicationInfoControl1.LoadAppInfo(CLDLAppID);
        }
    }
}
