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

        public frmListOrdersForSession(int SessionID)
        {
            InitializeComponent();
            _SessionID = SessionID;
        }

        private void _LoadOrders()
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

        private void frmListOrdersForSession_Load(object sender, EventArgs e)
        {
            _LoadOrders();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedOrderID = Convert.ToInt32(dgvOrders.CurrentRow.Cells["OrderID"].Value);
            frmOrderInfo frm = new frmOrderInfo(selectedOrderID);
            frm.IsShowOrder = true;
            frm.ShowDialog();   
        }
    }
}
