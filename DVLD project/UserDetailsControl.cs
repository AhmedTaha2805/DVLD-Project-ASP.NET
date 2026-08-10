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
    public partial class UserDetailsControl : UserControl
    {
        public UserDetailsControl()
        {
            InitializeComponent();
        }

        public void LoadUserInfo(int id)
        {
            clsUsers User = clsUsers.FindUser(id);
            personDetailsControl1.LoadPersonInfo(User.PersonID);
            lbUserID.Text = id.ToString();
            lbUserName.Text = User.UserName;
            lbIsActive.Text = User.IsActive ? "yes" : "no";
        }
    }
}
