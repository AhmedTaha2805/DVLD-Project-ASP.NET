using CurrentUserInformation;
using DTOs;
using DVLD_project.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_project
{
    public partial class frmChangePassword : Form
    {
        private readonly UserClientService _userClientService;
        public frmChangePassword()
        {
            InitializeComponent();
            _userClientService = new UserClientService();   
        }

        private async void txtCurrentPass_Validating(object sender, CancelEventArgs e)
        {
            if (txtCurrentPass.Text!=CurrentUser.user.Password)
            {
                e.Cancel = true;
                txtCurrentPass.Focus();
                errorProvider1.SetError(txtCurrentPass, "Current password is not correct");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtCurrentPass, "");
            }
        }

        private void txtConfirmPass_Validating(object sender, CancelEventArgs e)
        {
            if (txtNewPass.Text != txtConfirmPass.Text )
            {
                e.Cancel = true;
                txtConfirmPass.Focus();
                errorProvider1.SetError(txtConfirmPass, "passwords don't match");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPass, "");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPass.Text) || string.IsNullOrEmpty(txtCurrentPass.Text))
            {
                MessageBox.Show("Enter a valid password","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                await _userClientService.UpdateUserAsync(new UserDTO
                {
                    UserId = CurrentUser.user.UserId,
                    UserName = CurrentUser.user.UserName,
                    Password = txtNewPass.Text,
                    IsActive = CurrentUser.user.IsActive
                });
                MessageBox.Show("Password Updated Successfully", "Congratulations", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private async void frmChangePassword_Load(object sender, EventArgs e)
        {
            await userDetailsControl1.LoadUserInfo(CurrentUser.user.UserId);
        }
    }
}
