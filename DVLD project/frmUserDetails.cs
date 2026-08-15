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
    public partial class frmUserDetails : Form
    {
        int _userId;
        public frmUserDetails(int id)
        {
            InitializeComponent();
            _userId = id;         
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void frmUserDetails_Load(object sender, EventArgs e)
        {
            await userDetailsControl1.LoadUserInfo(_userId);
        }
    }
}
