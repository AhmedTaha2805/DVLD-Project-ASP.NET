
using DTOs;
using DVLD_project.Services;
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

    public partial class frmEditTestType : Form
    {
        int currentid;
        private readonly TestTypeClientService _testTypeClientService;
        public frmEditTestType(int id)
        {
            InitializeComponent();
            _testTypeClientService = new TestTypeClientService();
            currentid = id;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTitle.Text) && !string.IsNullOrEmpty(txtFees.Text) && !string.IsNullOrEmpty(txtDescription.Text))
            {
                await _testTypeClientService.UpdateTestType(new TestTypeDTO {
                    TestTypeId = currentid,
                    TestTypeTitle = txtTitle.Text,
                    TestTypeDescription = txtDescription.Text,
                    TestTypeFees = decimal.Parse(txtFees.Text)

                });
                MessageBox.Show("Test Type Updated Successfully", "Congratulations", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Enter Full Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void frmEditTestType_Load(object sender, EventArgs e)
        {
            var TestType = await _testTypeClientService.GetTestTypeByID(currentid);
            txtTitle.Text = TestType.TestTypeTitle;
            txtDescription.Text = TestType.TestTypeDescription;
            txtFees.Text = TestType.TestTypeFees.ToString();
            lbID.Text = currentid.ToString();
        }
    }
}
