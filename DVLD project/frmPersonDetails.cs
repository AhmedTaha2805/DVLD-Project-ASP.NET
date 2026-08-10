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
    public partial class frmPersonDetails : Form
    {
        int _id;
        public frmPersonDetails(int id)
        {
            InitializeComponent();
            _id = id;
            personDetailsControl1.LoadPersonInfo(id);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
