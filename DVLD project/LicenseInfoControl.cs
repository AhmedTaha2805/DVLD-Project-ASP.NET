using ApplicationBuisnessLayer;
using DriversBuisnessLayer;
using DVLD_project.Services;
using LicenseClassesBuisnessLayer;
using LicensesBuisnessLayer;
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

namespace DVLD_project
{
    public partial class LicenseInfoControl : UserControl
    {
        private readonly LicenseClassClientService _licenseClassClientService;
        private readonly ApplicationClientService _applicationClientService;
        private readonly LicenseClientService _licenseClientService;
        private readonly DriverClientService _driverClientService;
        public LicenseInfoControl()
        {
            InitializeComponent();
            _licenseClientService = new LicenseClientService();
            _applicationClientService = new ApplicationClientService();
            _licenseClassClientService = new LicenseClassClientService();
            _driverClientService = new DriverClientService();
        }

        public async void LoadLicenseInfo(int LicenseID)
        {
            var license = await _licenseClientService.FindLicenseByLicenseIDAsync(LicenseID);
            var driver = await _driverClientService.FindDriverByIDAsync(license.DriverId);
            clsPeople person = clsPeople.FindPerson(driver.PersonId);
            lbClass.Text = await _licenseClassClientService.GetLicenseClassNameById(license.LicenseClass);
            lbName.Text = person.FullName();
            lbNationalNo.Text = person.NationalNum;
            if (person.Gender == 0)
            {
                lbGender.Text = "Male";
            }
            else
            {
                lbGender.Text = "Female";
            }
            
            lbLicenseID.Text = license.LicenseId.ToString();
            lbIssueDate.Text = license.IssueDate.ToString();
            lbExpirationDate.Text = license.ExpirationDate.ToString();
            lbNotes.Text = license.Notes;
            lbIsActive.Text = license.IsActive.ToString();
            lbDateOfBirth.Text = person.DateOfBirth.ToString();
            lbDriverID.Text = license.DriverId.ToString();
            lbIsDetained.Text = await _licenseClientService.IsDetainedAsync(license.LicenseId) ? "Yes" : "No";
            lbIssueReason.Text = await _licenseClientService.GetIssueReasonAsync(license.IssueReason);
            if (!(person.ImagePath == ""))
            {
                PersonPicture.ImageLocation = person.ImagePath;
            }
        }

        public async Task<bool> LoadLicenseInfoByID(int LicenseID)
        {
            var license = await _licenseClientService.FindLicenseByLicenseIDAsync(LicenseID);
            if (license == null)
            {
                MessageBox.Show("License Not Found","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            lbClass.Text = await _licenseClassClientService.GetLicenseClassNameById(license.LicenseClass);
            var App = await _applicationClientService.FindApplication(license.ApplicationId);
            clsPeople person = clsPeople.FindPerson(App.ApplicantPersonId);
            lbName.Text = person.FullName();
            lbNationalNo.Text = person.NationalNum;
            if (person.Gender == 0)
            {
                lbGender.Text = "Male";
            }
            else
            {
                lbGender.Text = "Female";
            }
            
            lbLicenseID.Text = license.LicenseId.ToString();
            lbIssueDate.Text = license.IssueDate.ToString();
            lbExpirationDate.Text = license.ExpirationDate.ToString();
            lbNotes.Text = license.Notes;
            lbIsActive.Text = license.IsActive.ToString();
            lbDateOfBirth.Text = person.DateOfBirth.ToString();
            lbDriverID.Text = license.DriverId.ToString();
            lbIsDetained.Text = await _licenseClientService.IsDetainedAsync(license.LicenseId) ? "Yes" : "No";
            lbIssueReason.Text = await _licenseClientService.GetIssueReasonAsync(license.IssueReason);
            if (!(person.ImagePath == ""))
            {
                PersonPicture.ImageLocation = person.ImagePath;
            }
            else
            {
                PersonPicture.ImageLocation = null;
            }
            return true;
        }

        public bool IsNull()
        {
            return (lbLicenseID.Text == "?????");
        }
    }
}
