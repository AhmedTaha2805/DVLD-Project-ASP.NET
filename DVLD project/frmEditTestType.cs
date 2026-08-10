using ApplicationTypesBuisnessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestTypesBuisnessLayer;

namespace DVLD_project
{

    public partial class frmEditTestType : Form
    {
        int currentid;
        public frmEditTestType(int id)
        {
            InitializeComponent();
            currentid = id;
            clsTestTypes TestType = clsTestTypes.FindTestType(id);
            txtTitle.Text = TestType.title;
            txtDescription.Text = TestType.description;
            txtFees.Text = TestType.fees.ToString();
            lbID.Text = id.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTitle.Text) && !string.IsNullOrEmpty(txtFees.Text) && !string.IsNullOrEmpty(txtDescription.Text))
            {
                clsTestTypes TestType = new clsTestTypes(currentid, txtTitle.Text,txtDescription.Text, int.Parse(txtFees.Text));
                TestType.Save();
                MessageBox.Show("Test Type Updated Successfully", "Congratulations", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Enter Full Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
