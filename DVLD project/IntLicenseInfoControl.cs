
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
    public partial class IntLicenseInfoControl : UserControl
    {
        private readonly InternationalLicenseClientService _internationalLicenseClientService;
        private readonly DriverClientService _driverClientService;
        private readonly PeopleClientService _peopleClientService;
        public IntLicenseInfoControl()
        {
            InitializeComponent();
            _driverClientService = new DriverClientService();
            _internationalLicenseClientService = new InternationalLicenseClientService();
            _peopleClientService = new PeopleClientService();
        }

        public async Task LoadLicenseInfo(int IntLicenseID)
        {
            var License = await _internationalLicenseClientService.FindLicenseByLicenseIdAsync(IntLicenseID);
            var Driver = await _driverClientService.FindDriverByIDAsync(License.DriverId);
            var Person = await _peopleClientService.FindPersonAsync(Driver.PersonId);
            lbName.Text = $"{Person.FirstName} {Person.SecondName} {Person.ThirdName} {Person.LastName}";
            lbIntLicenseID.Text = IntLicenseID.ToString();
            lbLicenseID.Text = License.IssuedUsingLocalLicenseId.ToString();
            lbNationalNo.Text = Person.NationalNo.ToString();
            lbAppID.Text = License.ApplicationId.ToString();
            lbDateOfBirth.Text = Person.DateOfBirth.ToString();
            lbDriverID.Text = License.DriverId.ToString();
            lbIssueDate.Text = License.IssueDate.ToString();
            lbExpirationDate.Text = License.ExpirationDate.ToString();
            if (Person.Gendor == 0)
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
