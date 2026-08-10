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
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void RefreshDataGrid()
        {
            TestTypesdatagrid.DataSource = clsTestTypes.GetAllTestTypes();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
            lbRecord.Text = (TestTypesdatagrid.RowCount - 1).ToString();
        }

        private void TestTypesdatagrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.Button == MouseButtons.Right)
            {
                TestTypesdatagrid.ClearSelection();
                TestTypesdatagrid.Rows[e.RowIndex].Selected = true;

                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e) { 
        int id = int.Parse(TestTypesdatagrid.SelectedRows[0].Cells["TestTypeID"].Value.ToString());
        frmEditTestType frm = new frmEditTestType(id);
        frm.ShowDialog();
        RefreshDataGrid();

    }
    }
}
