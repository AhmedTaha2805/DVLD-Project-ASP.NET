using DriversBuisnessLayer;
using DVLD_project.Services;
using InternationalLicensesBuisnessLayer;
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
    public partial class IntLicenseInfoControl : UserControl
    {
        private readonly InternationalLicenseClientService _internationalLicenseClientService;
        private readonly DriverClientService _driverClientService;
        public IntLicenseInfoControl()
        {
            InitializeComponent();
            _driverClientService = new DriverClientService();
            _internationalLicenseClientService = new InternationalLicenseClientService();
        }

        public async void LoadLicenseInfo(int IntLicenseID)
        {
            var License = await _internationalLicenseClientService.FindLicenseByLicenseIdAsync(IntLicenseID);
            var Driver = await _driverClientService.FindDriverByIDAsync(License.DriverId);
            clsPeople Person = clsPeople.FindPerson(Driver.PersonId);
            lbName.Text = Person.FullName();
            lbIntLicenseID.Text = IntLicenseID.ToString();
            lbLicenseID.Text = License.IssuedUsingLocalLicenseId.ToString();
            lbNationalNo.Text = Person.NationalNum.ToString();
            lbAppID.Text = License.ApplicationId.ToString();
            lbDateOfBirth.Text = Person.DateOfBirth.ToString();
            lbDriverID.Text = License.DriverId.ToString();
            lbIssueDate.Text = License.IssueDate.ToString();
            lbExpirationDate.Text = License.ExpirationDate.ToString();
            if (Person.Gender == 0)
            {
                lbGender.Text = "Male";
            }
            else
            {
                lbGender.Text = "Female";
            }
            if (License.IsActive)
            {
                lbIsActive.Text = "Yes";
            }
            else
            {
                lbIsActive.Text = "No";
            }
            if (!(Person.ImagePath == ""))
            {
                PersonPicture.ImageLocation = Person.ImagePath;
            }
        }
    }
}
