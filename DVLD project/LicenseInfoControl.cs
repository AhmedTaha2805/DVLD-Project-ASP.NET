using ApplicationBuisnessLayer;
using DriversBuisnessLayer;
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

        public LicenseInfoControl()
        {
            InitializeComponent();
        }

        public void LoadLicenseInfo(int LicenseID)
        {
            clsLicenses license = clsLicenses.FindLicenseByLicenseID(LicenseID);
            clsDrivers driver = clsDrivers.FindDriverByID(license.DriverID);
            clsPeople person = clsPeople.FindPerson(driver.PersonID);
            lbClass.Text = clsLicenseClasses.GetLicenseClassName(license.LicenseClassID);
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

        public bool LoadLicenseInfoByID(int LicenseID)
        {
            clsLicenses license = clsLicenses.FindLicenseByLicenseID(LicenseID);
            if (license == null)
            {
                MessageBox.Show("License Not Found","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            lbClass.Text = clsLicenseClasses.GetLicenseClassName(license.LicenseClassID);
            clsApplications App = clsApplications.FindApplication(license.AppID);
            clsPeople person = clsPeople.FindPerson(App.PersonID);
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
