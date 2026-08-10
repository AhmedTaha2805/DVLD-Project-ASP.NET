using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PeopleBuisnessLayer;
using CountriesBuisnessLayer;
using System.Text.RegularExpressions;
using System.IO;
using DVLD_project.Services;

namespace DVLD_project
{
    public partial class AddPersonControl : UserControl
    {
        public event Action<int> OnSaveClick;

        public event Action<int> OnCloseClick;

        protected virtual void CloseClicked(int PersonID)
        {
            Action<int> handler = OnCloseClick;
            if (handler != null)
            {
                handler(PersonID);
            }
        }

        protected virtual void SaveClicked(int PersonID)
        {
            Action<int> handler = OnSaveClick;
            if (handler != null)
            {
                handler(PersonID);
            }
        }

        public Button BtnSave()
        {
            return (btnSave);
        }
        public Button BtnClose()
        {
            return(btnClose);
        }


        int _mode = 0;
        int CurrentID;
        string CurrentImageState = "Male";
        bool PictureExists = false;
        private readonly CountryClientService _countryClientService;
        public AddPersonControl()
        {                    
            InitializeComponent(); 
             _countryClientService = new CountryClientService();
            dateofbirthPicker.MaxDate = DateTime.Now.AddYears(-18);
        }
        

        private string MoveImage(string imagepath)
        {
            string folder = "C:\\DVLD people pictures";
            string extension = Path.GetExtension(imagepath);
            Guid GuidNumber = Guid.NewGuid();

            string newpath = Path.Combine(folder,GuidNumber.ToString() + extension);
            File.Copy(imagepath, newpath,true);
            return newpath;
        }

        public void GetMode(int mode)
        {
            _mode = mode;
            if (_mode == 1)
            {
                if (PersonPicture.ImageLocation != null)
                {
                    lnkRemove.Visible = true;
                }
            }
            else
            {
                cbCountry.SelectedIndex = 50;
            }
        }

        public void GetID(int ID)
        {
            CurrentID = ID;
            clsPeople Person = clsPeople.FindPerson(CurrentID);
            txtAddress.Text = Person.Address;
            txtFirstName.Text = Person.FirstName;
            txtLastName.Text = Person.LastName;
            txtEmail.Text = Person.Email;
            txtSecondName.Text = Person.SecondName;
            txtThirdName.Text = Person.ThirdName;
            txtNationalNo.Text = Person.NationalNum;
            dateofbirthPicker.Value = Person.DateOfBirth;
            cbCountry.SelectedIndex = Person.CountryId - 1;
            txtPhone.Text = Person.Phone;
            if(Person.ImagePath != "")
            {
                PersonPicture.ImageLocation = Person.ImagePath;
                PictureExists = true;
                lnkRemove.Visible = true;
                //PersonPicture.Load(Person.ImagePath);
            }
            else
            {
                PersonPicture.ImageLocation = null;
            }
            if (Person.Gender == 0)
            {
                rbMale.Checked = true;
                CurrentImageState = "Male";
            }
            else
            {
                rbFemale.Checked = true;
                CurrentImageState = "Female";
            }
        }

        private void AddPerson()
        {
            clsPeople Person = new clsPeople();
            Person.NationalNum = txtNationalNo.Text;
            Person.FirstName = txtFirstName.Text;
            Person.SecondName = txtSecondName.Text;
            Person.ThirdName = txtThirdName.Text;
            Person.LastName = txtLastName.Text;
            Person.Email = txtEmail.Text;
            Person.Phone = txtPhone.Text;
            Person.Address = txtAddress.Text;
            Person.DateOfBirth = dateofbirthPicker.Value;
            Person.CountryId = cbCountry.SelectedIndex + 1;
            Person.Gender = rbMale.Checked ? 0 : 1;
            if (PictureExists)
            {
                string newpath = MoveImage(PersonPicture.ImageLocation);
                Person.ImagePath = newpath;
                
            }
            else
            {
                Person.ImagePath = "";
            }
            Person.Save();
            CurrentID = Person.Id;
            SaveClicked(Person.Id);
        }

        private void UpdatePerson()
        {
            clsPeople Person = clsPeople.FindPerson(CurrentID);
            Person.NationalNum = txtNationalNo.Text;
            Person.FirstName = txtFirstName.Text;
            Person.SecondName = txtSecondName.Text;
            Person.ThirdName = txtThirdName.Text;
            Person.LastName = txtLastName.Text;
            Person.Email = txtEmail.Text;
            Person.Phone = txtPhone.Text;
            Person.Address = txtAddress.Text;
            Person.DateOfBirth = dateofbirthPicker.Value;
            Person.CountryId = cbCountry.SelectedIndex + 1;
            Person.Gender = rbMale.Checked ? 0 : 1;
            
            if (PictureExists)
            {
                if(PersonPicture.ImageLocation!= Person.ImagePath)
                    {
                        string newpath = MoveImage((PersonPicture.ImageLocation));
                        Person.ImagePath = newpath;
                    }
                

            }
            else
            {
                if(Person.ImagePath != "")
                {
                    File.Delete(Person.ImagePath);
                    Person.ImagePath = "";
                }         
                
            }
            Person.Save();
            SaveClicked(-1);

        }

        private bool ThereIsNull()
        {
            if(string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtSecondName.Text) || string.IsNullOrEmpty(txtThirdName.Text) || string.IsNullOrEmpty(txtLastName.Text) || string.IsNullOrEmpty(txtNationalNo.Text) ||
                string.IsNullOrEmpty(txtPhone.Text) || string.IsNullOrEmpty(txtAddress.Text) 
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (ThereIsNull())
            {
                MessageBox.Show("Fill Empty Fields", "error", MessageBoxButtons.OK);
                return;
            }
            if(errorProvider1.GetError(txtEmail) != "")
            {
                MessageBox.Show("Fill Email Correctly", "error", MessageBoxButtons.OK);
                return;
            }

            if(!rbMale.Checked && !rbFemale.Checked)
            {
                MessageBox.Show("choose a gender", "error", MessageBoxButtons.OK);
                return;
            }
            if(_mode == 0)
            {
                AddPerson();
            }
            else
            {
                UpdatePerson();
            }
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if(CurrentImageState != "Male" && !PictureExists)
            {
                PersonPicture.Image = Properties.Resources.Male_512;
                CurrentImageState = "Male";
                PictureExists = false;
            }
            
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (CurrentImageState != "Female" && !PictureExists)
            {
                PersonPicture.Image = Properties.Resources.Female_512;
                CurrentImageState = "Female";
                PictureExists = false;
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseClicked(CurrentID);

            //Form CurrentForm = this.FindForm();
            //CurrentForm.Close();
        }
   
        private void lnkSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {              
                string selectedFilePath = openFileDialog1.FileName;               

                PersonPicture.Load(selectedFilePath);               
                PictureExists = true;

                lnkRemove.Visible = true;
            }
        }

        private void lnkRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            PersonPicture.ImageLocation = null;
            if (rbFemale.Checked)
            {
                PersonPicture.Image = Properties.Resources.Female_512;
                CurrentImageState = "Female";
            }
            else
            {
                PersonPicture.Image = Properties.Resources.Male_512;
                CurrentImageState = "Male";
            }
            lnkRemove.Visible = false;

            }

        private void txt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(((TextBox)sender).Text))
            {
                e.Cancel = true;
                ((TextBox)sender).Focus();
                errorProvider1.SetError((TextBox) sender, "This field is required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError((TextBox)sender, "");
            }
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text))
            {
                e.Cancel = true;
                txtNationalNo.Focus();
                errorProvider1.SetError(txtNationalNo, "This field is required");
            }
            else if (clsPeople.NationalNumExists(txtNationalNo.Text))
            {
                e.Cancel = true;
                txtNationalNo.Focus();
                errorProvider1.SetError(txtNationalNo, "National number exists");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNationalNo, "");
            }

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, "");
                return;
            }
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(txtEmail.Text, pattern))
            {
                e.Cancel= true;
                txtEmail.Focus();
                errorProvider1.SetError(txtEmail, "wrong email format");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, "");
            }
        }

        private void AddPersonControl_Load(object sender, EventArgs e)
        {
            
        }

        public async Task LoadCountries()
        {
            var Countries = await _countryClientService.GetAllCountries();
            foreach (var c in Countries)
            {
                cbCountry.Items.Add(c.CountryName);
            }
        }
    }
}
