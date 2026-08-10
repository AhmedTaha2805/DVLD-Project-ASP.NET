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
    public partial class frmShowApplicationDetails : Form
    {
        public frmShowApplicationDetails(int id)
        {
            InitializeComponent();
            applicationInfoControl1.LoadAppInfo(id);
        }
    }
}
