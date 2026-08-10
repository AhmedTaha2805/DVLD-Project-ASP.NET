using DetainedLicensesBuisnessLayer;
using DriversBuisnessLayer;
using PeopleBuisnessLayer;
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
    public partial class frmManageDetainedLicenses : Form
    {
        public frmManageDetainedLicenses()
        {
            InitializeComponent();
        }
        private void RefreshDataGrid()
        {
            Detainsdatagrid.DataSource = clsDetainedLicenses.ListDetainedLicenses();
        }

        private void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
            lbRecord.Text = (Detainsdatagrid.RowCount - 1).ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilters_TextChanged(object sender, EventArgs e)
        {
            DataView dv = clsDetainedLicenses.ListDetainedLicenses().DefaultView;

            dv.RowFilter = $"Convert({cbFilters.Text},'System.String') like '{txtFilters.Text}%'";

            Detainsdatagrid.DataSource = dv;
        }

        private void txtFilters_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilters.Text == "D.ID" || cbFilters.Text == "L.ID" || cbFilters.Text == "Release App ID")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (cbFilters.Text == "Full Name")
            {
                if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbFilters.Text != "Is Released")
            {
                cbActive.Visible = false;
                txtFilters.Visible = true;
            }
            else
            {
                cbActive.Visible = true;
                txtFilters.Visible = false;
            }
            
            
        }

        private void cbActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbActive.Text == "All")
            {
                RefreshDataGrid();
            }
            else if (cbActive.Text == "Yes")
            {
                DataView dv = clsDetainedLicenses.ListDetainedLicenses().DefaultView;

                dv.RowFilter = $"[Is Released] = 1";

                Detainsdatagrid.DataSource = dv; ;
            }
            else if (cbActive.Text == "No")
            {
                DataView dv = clsDetainedLicenses.ListDetainedLicenses().DefaultView;

                dv.RowFilter = $"[Is Released] = 0";

                Detainsdatagrid.DataSource = dv;
            }
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NationalNo = Detainsdatagrid.SelectedRows[0].Cells["N.No"].Value.ToString();          
            clsPeople Person = clsPeople.FindPerson(NationalNo);
            frmPersonDetails frm = new frmPersonDetails(Person.Id);
            frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = int.Parse(Detainsdatagrid.SelectedRows[0].Cells["L.ID"].Value.ToString());
            frmLicenseInfo frm = new frmLicenseInfo(LicenseID);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NationalNo = Detainsdatagrid.SelectedRows[0].Cells["N.No"].Value.ToString();           
            frmShowLicenseHistory frm = new frmShowLicenseHistory(NationalNo);
            frm.ShowDialog();
        }

        private void Detainsdatagrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.Button == MouseButtons.Right)
            {
                Detainsdatagrid.ClearSelection();
                Detainsdatagrid.Rows[e.RowIndex].Selected = true;

                contextMenuStrip1.Show(Cursor.Position);
            }
            if (Convert.ToBoolean(Detainsdatagrid.SelectedRows[0].Cells["Is Released"].Value))
            {
                releaseDetainedLicenseToolStripMenuItem.Enabled = false;
            }
            else
            {
                releaseDetainedLicenseToolStripMenuItem.Enabled= true;
            }
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DetainID = int.Parse(Detainsdatagrid.SelectedRows[0].Cells["D.ID"].Value.ToString());
            frmReleaseDetain frm = new frmReleaseDetain(DetainID);
            frm.ShowDialog();
            RefreshDataGrid();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseDetain frm = new frmReleaseDetain();
            frm.ShowDialog();
            RefreshDataGrid();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
            RefreshDataGrid();
        }
    }
}
