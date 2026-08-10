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
    public partial class frmApplicationTypes : Form
    {
        public frmApplicationTypes()
        {
            InitializeComponent();
        }

        private void RefreshDataGrid()
        {
            AppTypesdatagrid.DataSource = clsApplicationTypes.GetAllApplicationsTypes();
        }

        private void frmApplicationTypes_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
            lbRecord.Text = (AppTypesdatagrid.RowCount - 1).ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AppTypesdatagrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.Button == MouseButtons.Right)
            {
                AppTypesdatagrid.ClearSelection();
                AppTypesdatagrid.Rows[e.RowIndex].Selected = true;

                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            int id = int.Parse(AppTypesdatagrid.SelectedRows[0].Cells["ApplicationTypeID"].Value.ToString());
            frmEditAppTypes frm = new frmEditAppTypes(id);
            frm.ShowDialog();
            RefreshDataGrid();
        }
    }
}
