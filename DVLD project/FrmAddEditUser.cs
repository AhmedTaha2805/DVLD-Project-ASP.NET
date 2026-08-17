using DTOs;
using DVLD_project.Services;
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
using UsersBuisnessLayer;

namespace DVLD_project
{
       
    public partial class FrmAddEditUser : Form
    {
        enMode Mode = enMode.AddNew;

        int UserID;
        private readonly UserClientService _userClientService;
        public FrmAddEditUser(int mode , int id = -1)
        {
            InitializeComponent();
            _userClientService = new UserClientService();
            this.AcceptButton = personDetailsWithFilter1.BtnSearch();
            if(mode == 0)
            {
                Mode = enMode.AddNew;
            }
            else
            {
                personDetailsWithFilter1.DisableFilterPersonControls();
                Mode = enMode.Update;
                lbMode.Text = "Update User";
            }
            UserID = id;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ThereIsNull()
        {
            if (string.IsNullOrEmpty(txtUsername.Text)|| string.IsNullOrEmpty(txtPassword.Text)|| string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        

        private async void FrmAddEditUser_Load(object sender, EventArgs e)
        {
            if (Mode == enMode.Update)
            {
                lbMode.Text = "Update User";
            }
            if (UserID != -1)
            {

                var User = await _userClientService.FindUserAsync(UserID);
                await personDetailsWithFilter1.LoadPersonInfo(User.PersonId);
                lbUserID.Text = User.UserId.ToString();
                txtUsername.Text = User.UserName;
                txtPassword.Text = User.Password;
                txtConfirmPassword.Text = User.Password;
                chIsActive.Checked = User.IsActive;
            }
        }

        private async Task AddUser()
        {
            var user = await _userClientService.AddUserAsync(new UserDTO
            {
                PersonId = personDetailsWithFilter1.GetPersonID(),
                UserName = txtUsername.Text,
                Password = txtPassword.Text,
                IsActive = chIsActive.Checked
            });          
            UserID = user.UserId;
        }

        private async Task UpdateUser()
        {
            await _userClientService.UpdateUserAsync(new UserDTO
            {
                UserId = UserID,
                UserName = txtUsername.Text,
                Password = txtPassword.Text,
                IsActive = chIsActive.Checked
            });
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            
            if (personDetailsWithFilter1.GetPersonID() == -1)
            {
                MessageBox.Show("choose a person", "error", MessageBoxButtons.OK); return;
            }
            if (ThereIsNull())
            {
                MessageBox.Show("Fill Empty Fields", "error", MessageBoxButtons.OK);
                return;
            }
            if (errorProvider1.GetError(txtUsername)!= "" || errorProvider1.GetError(txtPassword) != "" || errorProvider1.GetError(txtConfirmPassword) != "")
            {
                MessageBox.Show("Enter Correct Data", "error", MessageBoxButtons.OK); return;
            }
            
            
            
            if (Mode == enMode.AddNew)
            {
                if (await _userClientService.FindUserByPersonIDAsync(personDetailsWithFilter1.GetPersonID()))
                {
                    MessageBox.Show("This Person is already a user", "error", MessageBoxButtons.OK);
                    return;
                }
                await AddUser();
                personDetailsWithFilter1.DisableFilterPersonControls();
                lbMode.Text = "Update User";
                lbUserID.Text = UserID.ToString();
                Mode = enMode.Update;
                MessageBox.Show($"user added successfully with id = {UserID}", "Congratulations", MessageBoxButtons.OK);
            }
            else
            {
                await UpdateUser();
                MessageBox.Show("User Updated successfully ", "Congratulations", MessageBoxButtons.OK);
            }
        }

        private void txt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(((TextBox)sender).Text) && tabControl1.SelectedTab == LoginTab)
            {
                e.Cancel = true;
                ((TextBox)sender).Focus();
                errorProvider1.SetError((TextBox)sender, "This field is required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError((TextBox)sender, "");
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text != txtConfirmPassword.Text && tabControl1.SelectedTab == LoginTab)
            {
                e.Cancel = true;
                txtConfirmPassword.Focus();
                errorProvider1.SetError(txtConfirmPassword, "passwords don't match");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, "");
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = LoginTab;
        }
    }
}
