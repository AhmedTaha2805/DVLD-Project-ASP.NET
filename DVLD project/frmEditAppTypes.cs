using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationTypesBuisnessLayer;

namespace DVLD_project
{
    public partial class frmEditAppTypes : Form
    {
        int currentid;
        public frmEditAppTypes(int id)
        {
            InitializeComponent();
            currentid = id;
            clsApplicationTypes apptype = clsApplicationTypes.FindApplicationType(currentid);
            txtTitle.Text = apptype.title;
            txtFees.Text = apptype.fees.ToString();
            lbID.Text = id.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTitle.Text) && !string.IsNullOrEmpty(txtFees.Text))
            {
                clsApplicationTypes apptype = new clsApplicationTypes(currentid, txtTitle.Text,int.Parse(txtFees.Text));
                apptype.Save();
                MessageBox.Show("Application Type Updated Successfully", "Congratulations", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Enter Full Data","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditAppTypes_Load(object sender, EventArgs e)
        {

        }
    }
}
