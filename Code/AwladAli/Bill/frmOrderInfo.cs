using AwladAli_Buisness;
using System;
using System.Data;
using System.Windows.Forms;

namespace AwladAli.Bill
{
    public partial class frmOrderInfo : Form
    {
        // Private variable to store the Order ID passed from the Main Form
        private int _OrderID = -1;
        private clsOrder _Order;

        // Constructor that accepts the OrderID
        public frmOrderInfo(int OrderID)
        {
            InitializeComponent();
            _OrderID = OrderID;
        }

        private void frmOrderInfo_Load(object sender, EventArgs e)
        {
            _LoadOrderData();
        }

        private void _LoadOrderData()
        {
            // 1. Find the main Order info
            _Order = clsOrder.Find(_OrderID);

            if (_Order == null)
            {
                MessageBox.Show("Order not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // 2. Fill Header Labels
            lblOrderID.Text = "رقم الفاتورة: #" + _Order.OrderID.ToString();
            lblOrderDate.Text = "التاريخ: " + _Order.OrderDate.ToString("yyyy-MM-dd HH:mm");
            lblTotalAmount.Text = _Order.TotalAmount.ToString("0.00") + " ج.م";

            // 3. Load Order Details (The Items)
            _LoadOrderItems();
        }

        private void _LoadOrderItems()
        {
            // Clear existing items just in case
            flpOrderItems.Controls.Clear();

            // Get all details for this order from Business Layer
            DataTable dtOrderItems = clsOrderDetail.GetOrderItems(_OrderID);

            foreach (DataRow row in dtOrderItems.Rows)
            {
                // Create a new instance of our UserControl
                ctrlOrderLine ctrl = new ctrlOrderLine();

                // Get the DetailID from the row
                int detailID = Convert.ToInt32(row["DetailID"]);

                // Use the LoadData method we built to fetch product/extra names
                ctrl.LoadData(detailID);

                // Add the control to the FlowLayoutPanel
                flpOrderItems.Controls.Add(ctrl);
            }
        }

        private void btnSaveAndPrint_Click(object sender, EventArgs e)
        {
            // Here you will call the Print Logic later
            MessageBox.Show("جاري تجهيز الطباعة...");
            this.Close();
        }
    }
}