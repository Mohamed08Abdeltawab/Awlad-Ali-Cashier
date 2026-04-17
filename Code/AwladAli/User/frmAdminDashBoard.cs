using AwladAli.Category;
using AwladAli.Category.Extra;
using AwladAli_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AwladAli.User
{
    public partial class frmAdminDashBoard : Form
    {
        private DataTable _dtAllOrders;

        public frmAdminDashBoard()
        {
            InitializeComponent();
        }


        private void _FillGride()
        {
            _dtAllOrders = clsOrder.GetAllOrders();
            dgvOrders.DataSource = _dtAllOrders;
            lblRecordsCount.Text = dgvOrders.Rows.Count.ToString();

            dgvOrders.Columns[0].HeaderText = "Order ID";
            dgvOrders.Columns[0].Width = 130;

            dgvOrders.Columns[1].HeaderText = "User ID";
            dgvOrders.Columns[1].Width = 110;

            dgvOrders.Columns[2].HeaderText = "Date Time";
            dgvOrders.Columns[2].Width = 220;

            dgvOrders.Columns[3].HeaderText = "Total Price";
            dgvOrders.Columns[3].Width = 150;
        }
        private void frmAdminDashBoard_Load(object sender, EventArgs e)
        {
            _FillGride();
        }

        private void btnUsersList_Click(object sender, EventArgs e)
        {
            frmListUsers frm = new frmListUsers();
            frm.ShowDialog();
        }

        private void btnCategoriesList_Click(object sender, EventArgs e)
        {
            frmListCategories frm = new frmListCategories();
            frm.ShowDialog();
        }

        private void btnExtraLists_Click(object sender, EventArgs e)
        {
            frmListExtra frm = new frmListExtra();
            frm.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRefreshAll_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
