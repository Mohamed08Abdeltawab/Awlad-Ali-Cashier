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
            Graphics g = e.Graphics;

            Font fontTitle = new Font("Tahoma", 16, FontStyle.Bold);
            Font fontHeader = new Font("Tahoma", 12, FontStyle.Bold);
            Font fontBody = new Font("Tahoma", 11);

            float pageWidth = e.PageBounds.Width;
            float margin = 20;
            float y = 20;
            float rowHeight = 30;

            float usableWidth = pageWidth - (margin * 2);

            StringFormat right = new StringFormat() { Alignment = StringAlignment.Far };
            StringFormat center = new StringFormat() { Alignment = StringAlignment.Center };

            // ===== Header =====
            g.DrawString("أولاد علي - Awlad Ali", fontTitle, Brushes.Black, pageWidth / 2, y, center);
            y += rowHeight + 10;

            g.DrawString($"رقم الفاتورة: {_OrderID}", fontBody, Brushes.Black, pageWidth - margin, y, right);
            y += rowHeight;

            g.DrawString($"التاريخ: {DateTime.Now:yyyy-MM-dd HH:mm}", fontBody, Brushes.Black, pageWidth - margin, y, right);
            y += rowHeight + 10;

            g.DrawLine(Pens.Black, margin, y, pageWidth - margin, y);
            y += 10;

            // ===== Column Widths =====
            float colItemWidth = usableWidth * 0.40f;
            float colPriceWidth = usableWidth * 0.20f;
            float colQtyWidth = usableWidth * 0.15f;
            float colTotalWidth = usableWidth * 0.25f;

            // ===== RTL Positions (ابدأ من اليمين) =====
            float x = pageWidth - margin;

            float colItemX = x;                    // الصنف (أول عمود يمين)
            x -= colItemWidth;

            float colPriceX = x;
            x -= colPriceWidth;

            float colQtyX = x;
            x -= colQtyWidth;

            float colTotalX = x;                   // آخر عمود شمال

            // ===== Headers =====
            g.DrawString("الصنف", fontHeader, Brushes.Black, colItemX, y, right);
            g.DrawString("السعر", fontHeader, Brushes.Black, colPriceX, y, right);
            g.DrawString("الكمية", fontHeader, Brushes.Black, colQtyX, y, right);
            g.DrawString("الإجمالي", fontHeader, Brushes.Black, colTotalX, y, right);

            y += rowHeight;
            g.DrawLine(Pens.Black, margin, y, pageWidth - margin, y);
            y += 10;

            // ===== Items =====
            DataTable dtItems = clsOrderDetail.GetOrderItemsForPrinting(_OrderID);

            foreach (DataRow row in dtItems.Rows)
            {
                string name = row["ItemDescription"].ToString();
                int qty = Convert.ToInt32(row["Quantity"]);
                decimal price = Convert.ToDecimal(row["UnitPrice"]);
                decimal total = qty * price;

                g.DrawString(name, fontBody, Brushes.Black, colItemX, y, right);
                g.DrawString(price.ToString("0.00"), fontBody, Brushes.Black, colPriceX, y, right);
                g.DrawString(qty.ToString(), fontBody, Brushes.Black, colQtyX, y, right);
                g.DrawString(total.ToString("0.00"), fontBody, Brushes.Black, colTotalX, y, right);

                y += rowHeight;
            }

            y += 10;
            g.DrawLine(Pens.Black, margin, y, pageWidth - margin, y);
            y += rowHeight;

            // ===== Total =====
            g.DrawString($"الإجمالي: {lblTotalAmount.Text} ج.م", fontTitle, Brushes.Black, pageWidth - margin, y, right);

            y += rowHeight + 10;

            // ===== Footer =====
            g.DrawString("شكراً لزيارتكم", fontBody, Brushes.Black, pageWidth / 2, y, center);
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