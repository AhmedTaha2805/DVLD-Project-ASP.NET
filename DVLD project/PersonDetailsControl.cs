
using DVLD_project.Services;
using Microsoft.Extensions.DependencyInjection;

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
    public partial class PersonDetailsControl : UserControl
    {
        int Currentid = -1;
        private  CountryClientService _countryClientService;
        private readonly PeopleClientService _peopleClientService;
        public PersonDetailsControl()
        {
            InitializeComponent();
            _countryClientService = new CountryClientService();
            _peopleClientService = new PeopleClientService();
        }

        public async Task LoadPersonInfo(int id)
        {
            
            var Person = await _peopleClientService.FindPersonAsync(id);
            if (Person == null)
            {
                MessageBox.Show("person Not Found", "Error",MessageBoxButtons.OK);
                return;

            }
            Currentid = id;
            lnkEditPersonInfo.Enabled = true;
            lbPersonID.Text = id.ToString();
            lbName.Text = $"{Person.FirstName} {Person.SecondName} {Person.ThirdName} {Person.LastName}";
            lbNationalNo.Text = Person.NationalNo;
            lbPhone.Text = Person.Phone;
            lbEmail.Text = Person.Email;
            lbAddress.Text = Person.Address;
            lbDateOfBirth.Text = Person.DateOfBirth.ToString();
            lbGender.Text = Person.Gendor == 0 ? "Male" : "Female";
            lbCountry.Text = await _countryClientService.GetCountryName(Person.NationalityCountryId);
            if (!(Person.ImagePath == ""))
            {
                PersonPicture.ImageLocation = Person.ImagePath;                 
            }
            else if (Person.Gendor == 0)
            {
                PersonPicture.Image = Properties.Resources.Male_512;
            }
            else
            {
                PersonPicture.Image = Properties.Resources.Female_512;
            }
                    
        }

        public async Task LoadPersonInfo(string NationalNo)
        {
            
            var Person = await _peopleClientService.FindPersonByNationalNoAsync(NationalNo);
            if (Person == null)
            {
                MessageBox.Show("person Not Found", "Error", MessageBoxButtons.OK);
                return;

            }
            lnkEditPersonInfo.Enabled = true;
            Currentid = Person.PersonId;           
            lbPersonID.Text = Currentid.ToString();
            lbName.Text = $"{Person.FirstName} {Person.SecondName} {Person.ThirdName} {Person.LastName}";
            lbNationalNo.Text = Person.NationalNo;
            lbPhone.Text = Person.Phone;
            lbEmail.Text = Person.Email;
            lbAddress.Text = Person.Address;
            lbDateOfBirth.Text = Person.DateOfBirth.ToString();
            lbGender.Text = Person.Gendor == 0 ? "Male" : "Female";
            lbCountry.Text = await _countryClientService.GetCountryName(Person.NationalityCountryId);
            if (!(Person.ImagePath == ""))
            {
                PersonPicture.ImageLocation = Person.ImagePath;
            }
            else if (Person.Gendor == 0)
            {
                PersonPicture.Image = Properties.Resources.Male_512;
            }
            else
            {
                PersonPicture.Image = Properties.Resources.Female_512;
            }
        }

        private async void lnkEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddEditPersonForm frm = new AddEditPersonForm(1, Currentid);
            frm.ShowDialog();
            await LoadPersonInfo(Currentid);
        }

        public int GetPersonID()
        {
            return Currentid;
        }
    }
}
