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
    public partial class UserDetailsControl : UserControl
    {
        private readonly UserClientService _userClientService;
        public UserDetailsControl()
        {
            InitializeComponent();
            _userClientService = new UserClientService();
        }

        public async Task LoadUserInfo(int id)
        {
            var User = await _userClientService.FindUserAsync(id);
            await personDetailsControl1.LoadPersonInfo(User.PersonId);
            lbUserID.Text = id.ToString();
            lbUserName.Text = User.UserName;
            lbIsActive.Text = User.IsActive ? "yes" : "no";
        }
    }
}
