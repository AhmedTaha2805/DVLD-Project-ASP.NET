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
using DTOs;
using DVLD_project.Services;

namespace DVLD_project
{
    public partial class frmEditAppTypes : Form
    {
        int currentid;
        private readonly ApplicationTypeClientService _applicationTypeClientService;
        public frmEditAppTypes(int id)
        {
            InitializeComponent();
            _applicationTypeClientService = new ApplicationTypeClientService();
            currentid = id;
            
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTitle.Text) && !string.IsNullOrEmpty(txtFees.Text))
            {
                await _applicationTypeClientService.UpdateApplicationType(new ApplicationTypeDTO
                {
                    ApplicationTypeId = currentid,
                    ApplicationTypeTitle = txtTitle.Text,
                    ApplicationFees = decimal.Parse(txtFees.Text)
                });
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

        private async void frmEditAppTypes_Load(object sender, EventArgs e)
        {
            var apptype = await _applicationTypeClientService.GetApplicationTypeById(currentid);
            txtTitle.Text = apptype.ApplicationTypeTitle;
            txtFees.Text = apptype.ApplicationFees.ToString();
            lbID.Text = currentid.ToString();
        }
    }
}
