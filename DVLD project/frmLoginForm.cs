using CurrentUserInformation;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsersBuisnessLayer;

namespace DVLD_project
{
    public partial class frmLoginForm : Form
    {
        public frmLoginForm()
        {
            InitializeComponent();
            string UserName = Registry.GetValue(CurrentUser.LoginRegisteryPath, "Username", null) as string;
            string Password = Registry.GetValue(CurrentUser.LoginRegisteryPath, "Password", null) as string;
            if (!string.IsNullOrEmpty(UserName))
            {
                chkRemember.Checked = true;
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool Remember = false;
            clsUsers user = clsUsers.FindUser(txtUserName.Text,txtPassword.Text);
            if (user != null)
            {
                Registry.SetValue(CurrentUser.LoginRegisteryPath, "Username", string.Empty, RegistryValueKind.String);
                Registry.SetValue(CurrentUser.LoginRegisteryPath, "Password", string.Empty, RegistryValueKind.String);
                if (chkRemember.Checked)
                {
                    Remember = true;
                    Registry.SetValue(CurrentUser.LoginRegisteryPath, "UserName", user.UserName, RegistryValueKind.String);
                    Registry.SetValue(CurrentUser.LoginRegisteryPath, "Password", user.Password, RegistryValueKind.String);
                }
                CurrentUser.user = user;
                FrmMain frm = new FrmMain();
                this.Hide();
                frm.ShowDialog();
                this.Show();
                if (!Remember)
                {
                    txtUserName.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    chkRemember.Checked = false;
                }
                

            }
            else
            {
                MessageBox.Show("Username/Password are not correct","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
