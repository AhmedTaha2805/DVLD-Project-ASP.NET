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
        public LicenseInfoControl()
        {
            InitializeComponent();
            _applicationClientService = new ApplicationClientService();
            _licenseClassClientService = new LicenseClassClientService();
        }

        public async void LoadLicenseInfo(int LicenseID)
        {
            clsLicenses license = clsLicenses.FindLicenseByLicenseID(LicenseID);
            clsDrivers driver = clsDrivers.FindDriverByID(license.DriverID);
            clsPeople person = clsPeople.FindPerson(driver.PersonID);
            lbClass.Text = await _licenseClassClientService.GetLicenseClassNameById(license.LicenseClassID);
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
            
            lbLicenseID.Text = license.LicenseID.ToString();
            lbIssueDate.Text = license.IssueDate.ToString();
            lbExpirationDate.Text = license.ExpirationDate.ToString();
            lbNotes.Text = license.notes;
            lbIsActive.Text = license.IsActive.ToString();
            lbDateOfBirth.Text = person.DateOfBirth.ToString();
            lbDriverID.Text = license.DriverID.ToString();
            lbIsDetained.Text = license.IsDetained() ? "Yes" : "No";
            lbIssueReason.Text = clsLicenses.GetIssueReason(license.IssueReason);
            if (!(person.ImagePath == ""))
            {
                PersonPicture.ImageLocation = person.ImagePath;
            }
        }

        public async Task<bool> LoadLicenseInfoByID(int LicenseID)
        {
            clsLicenses license = clsLicenses.FindLicenseByLicenseID(LicenseID);
            if (license == null)
            {
                MessageBox.Show("License Not Found","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            lbClass.Text = await _licenseClassClientService.GetLicenseClassNameById(license.LicenseClassID);
            var App = await _applicationClientService.FindApplication(license.AppID);
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
            
            lbLicenseID.Text = license.LicenseID.ToString();
            lbIssueDate.Text = license.IssueDate.ToString();
            lbExpirationDate.Text = license.ExpirationDate.ToString();
            lbNotes.Text = license.notes;
            lbIsActive.Text = license.IsActive.ToString();
            lbDateOfBirth.Text = person.DateOfBirth.ToString();
            lbDriverID.Text = license.DriverID.ToString();
            lbIsDetained.Text = license.IsDetained() ? "Yes" : "No";
            lbIssueReason.Text = clsLicenses.GetIssueReason(license.IssueReason);
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
