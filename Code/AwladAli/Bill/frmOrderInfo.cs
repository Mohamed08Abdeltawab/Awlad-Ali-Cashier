using AwladAli_Buisness;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace AwladAli.Bill
{
    public partial class frmOrderInfo : Form
    {
        // Private variable to store the Order ID passed from the Main Form
        private int _OrderID = -1;
        private clsOrder _Order;

        private bool _IsOrderConfirmed = false;

        PrintDocument printDoc = new PrintDocument();

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
            DataTable dtOrderItems = clsOrderDetail.GetOrderItemsForPrinting(_OrderID);

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


        // 2. الدالة المسؤولة عن "رسم" شكل الفاتورة
        private void PrintOrderPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font fontTitle = new Font("Arial", 14, FontStyle.Bold);
            Font fontBody = new Font("Arial", 10);
            Font fontHeader = new Font("Arial", 10, FontStyle.Bold);

            float startX = 10;
            float startY = 10;
            float Offset = 40;

            // رسم اللوجو أو اسم المطعم
            graphics.DrawString("Awlad Ali - أولاد علي", fontTitle, Brushes.Black, startX + 50, startY);
            graphics.DrawString("رقم الفاتورة: " + _OrderID, fontBody, Brushes.Black, startX, startY + Offset);
            Offset += 20;
            graphics.DrawString("التاريخ: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm"), fontBody, Brushes.Black, startX, startY + Offset);
            Offset += 30;

            // رسم خط فاصل
            graphics.DrawString("----------------------------------------------------------", fontBody, Brushes.Black, startX, startY + Offset);
            Offset += 20;

            // رسم العناوين
            graphics.DrawString("الصنف", fontHeader, Brushes.Black, startX, startY + Offset);
            graphics.DrawString("الكمية", fontHeader, Brushes.Black, startX + 150, startY + Offset);
            graphics.DrawString("السعر", fontHeader, Brushes.Black, startX + 220, startY + Offset);
            Offset += 20;

            // رسم الأصناف (Loop on Order Details)
            DataTable dtItems = clsOrderDetail.GetOrderItemsForPrinting(_OrderID);
            foreach (DataRow row in dtItems.Rows)
            {
                string name = row["ItemDescription"].ToString();
                string qty = row["Quantity"].ToString();
                string price = Convert.ToDecimal(row["UnitPrice"]).ToString("0.00");

                graphics.DrawString(name, fontBody, Brushes.Black, startX, startY + Offset);
                graphics.DrawString(qty, fontBody, Brushes.Black, startX + 150, startY + Offset);
                graphics.DrawString(price, fontBody, Brushes.Black, startX + 220, startY + Offset);

                Offset += 20;
            }

            Offset += 20;
            graphics.DrawString("----------------------------------------------------------", fontBody, Brushes.Black, startX, startY + Offset);
            Offset += 20;

            // رسم الإجمالي النهائي
            graphics.DrawString("الإجمالي النهائي: " + lblTotalAmount.Text, fontTitle, Brushes.Black, startX, startY + Offset);

            Offset += 40;
            graphics.DrawString("شكراً لزيارتكم - أولاد علي", fontBody, Brushes.Black, startX + 60, startY + Offset);
        }


        private void btnSaveAndPrint_Click(object sender, EventArgs e)
        {
            // ربط حدث الرسم بدالة الطباعة
            printDoc.PrintPage += new PrintPageEventHandler(PrintOrderPage);

            // إظهار مربع حوار الطباعة أو الطباعة مباشرة
            // printDoc.Print(); // للطباعة المباشرة على البرنتر الافتراضي

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDoc;
            preview.ShowDialog(); // للمعاينة قبل الطباعة (اختياري)

            _IsOrderConfirmed = true;
            this.Close();
        }

        private void btnIgnore_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmOrderInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_IsOrderConfirmed)
            {
                // 1. حذف الأوردر وتفاصيله من الداتا بيز
                // لاحظ أن الـ Delete في الـ Business Layer لازم تمسح الـ Details الأول ثم الـ Order
                if (clsOrder.DeleteOrder(_OrderID))
                {
                    MessageBox.Show("تم إلغاء الطلب وحذفه من النظام.", "تنبيه",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}