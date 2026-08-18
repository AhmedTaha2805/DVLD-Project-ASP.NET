
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
    public partial class frmManageTestTypes : Form
    {
        private readonly TestTypeClientService _testTypeClientService;
        public frmManageTestTypes()
        {
            InitializeComponent();
            _testTypeClientService = new TestTypeClientService();
            lbLoading.Visible = true;
        }

        private async Task RefreshDataGrid()
        {
            lbLoading.Visible = true;
            TestTypesdatagrid.DataSource = await _testTypeClientService.GetAllTestTypes();
            lbLoading.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            await RefreshDataGrid();
            lbRecord.Text = (TestTypesdatagrid.RowCount).ToString();
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

        private async void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e) { 
        int id = int.Parse(TestTypesdatagrid.SelectedRows[0].Cells["TestTypeID"].Value.ToString());
        frmEditTestType frm = new frmEditTestType(id);
        frm.ShowDialog();
        await RefreshDataGrid();
    }
    }
}
