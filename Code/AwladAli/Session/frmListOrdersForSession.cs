using AwladAli.Bill;
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

namespace AwladAli.Session
{
    public partial class frmListOrdersForSession : Form
    {
        private int _SessionID;
        DataTable _dtAllOrdersBySession;

        private int _PageNumber = 1;
        private int _PageSize = 10;

        public frmListOrdersForSession(int SessionID)
        {
            InitializeComponent();
            _SessionID = SessionID;
        }

        private void _LoadAllOrders()
        {
            dgvOrders.DataSource = clsOrder.GetAllOrdersRelatedBySessionID(_SessionID);

            // تنسيق العناوين
            if (dgvOrders.Rows.Count > 0)
            {
                dgvOrders.Columns["SessionID"].HeaderText = "رقم الجلسة";
                dgvOrders.Columns["SessionID"].Width = 110;

                dgvOrders.Columns["OrderID"].HeaderText = "رقم الطلب";
                dgvOrders.Columns["OrderID"].Width = 110;

                dgvOrders.Columns["OrderDate"].HeaderText = "تاريخ الطلب";
                dgvOrders.Columns["OrderDate"].Width = 200;

                dgvOrders.Columns["TotalAmount"].HeaderText = "إجمالي السعر";
                dgvOrders.Columns["TotalAmount"].Width = 200;
            }
        }

        private void _LoadOrdersWithPagination(int PageNumber, int PageSize)
        {
            dgvOrders.DataSource = clsOrder.GetOrdersRelatedBySessionIDWithPagination(_SessionID, PageNumber, PageSize);

            if (dgvOrders.Rows.Count > 0)
            {
                dgvOrders.Columns["SessionID"].HeaderText = "رقم الجلسة";
                dgvOrders.Columns["SessionID"].Width = 110;

                dgvOrders.Columns["OrderID"].HeaderText = "رقم الطلب";
                dgvOrders.Columns["OrderID"].Width = 110;

                dgvOrders.Columns["OrderDate"].HeaderText = "تاريخ الطلب";
                dgvOrders.Columns["OrderDate"].Width = 200;

                dgvOrders.Columns["TotalAmount"].HeaderText = "إجمالي السعر";
                dgvOrders.Columns["TotalAmount"].Width = 200;
            }
        }

        private void frmListOrdersForSession_Load(object sender, EventArgs e)
        {
            _LoadOrdersWithPagination(_PageNumber, _PageSize);
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedOrderID = Convert.ToInt32(dgvOrders.CurrentRow.Cells["OrderID"].Value);
            frmOrderInfo frm = new frmOrderInfo(selectedOrderID);
            frm.IsShowOrder = true;
            frm.ShowDialog();   
        }

        private DataTable _dtOrdersMerge = new DataTable();
        private void btnMore_Click(object sender, EventArgs e)
        {
            _PageNumber++;

            DataTable dtNextPage = clsOrder.GetOrdersRelatedBySessionIDWithPagination(_SessionID, _PageNumber, _PageSize);

            if (dtNextPage != null && dtNextPage.Rows.Count > 0)
            {
                if (_dtOrdersMerge.Rows.Count == 0)
                    _dtOrdersMerge = ((DataTable)dgvOrders.DataSource).Copy();//copy already data to merge with next page data

                _dtOrdersMerge.Merge(dtNextPage);
                dgvOrders.DataSource = _dtOrdersMerge;//merge data and show in datagridview
            }
            else
            {
                //no data
                btnMore.Enabled = false;
                MessageBox.Show("لا توجد طلبات إضافية لهذه الجلسة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _PageNumber--;
            }
        }

        private void llShowAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _LoadAllOrders();
            btnMore.Enabled = false;
        }

        private void llReturnDefault_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _PageNumber = 1;
            btnMore.Enabled = true;
            _dtOrdersMerge.Clear();
            _LoadOrdersWithPagination(_PageNumber, _PageSize);
        }
    }
}
