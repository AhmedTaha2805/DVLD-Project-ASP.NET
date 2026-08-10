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
        public frmPersonDetails(int id)
        {
            InitializeComponent();
            personDetailsControl1.LoadPersonInfo(id);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void personDetailsControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
