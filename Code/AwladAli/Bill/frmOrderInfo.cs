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
        clsCustomer _Customer;

        private bool _showCloseConfirmation = true; // Flag to control the close confirmation dialog

        private bool _IsShowOrder = false; // Flag to track if the order was saved/confirmed
        public bool IsShowOrder
        {
            get { return _IsShowOrder; }
            set { _IsShowOrder = value; }
        }

        private bool _OrderConfirmed = false; // Flag to track if the order was confirmed/saved


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
            if(_IsShowOrder)//get ture will do this
            {
                btnSaveAndPrint.Enabled = false; // Disable the button if order is not saved yet
                btnIgnore.Enabled = false; // Disable the ignore button as well

                btnSaveAndPrint.Visible = false; // Hide the Save & Print button
                btnIgnore.Visible = false; // Hide the Ignore button
            }
            // 1. Find the main Order info
            _Order = clsOrder.Find(_OrderID);

            if (_Order == null)
            {
                MessageBox.Show("لم يتم العثور على الطلب!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _showCloseConfirmation = false; // Disable the close confirmation dialog since we're closing due to an error
                this.Close();
                return;
            }

            // 2. Fill Header Labels
            lblOrderID.Text = _Order.OrderID.ToString();
            lblOrderDate.Text = _Order.OrderDate.ToString("yyyy-MM-dd HH:mm:ss");
            lblMealPrice.Text = _Order.TotalAmount.ToString("0.00");
            lblDeliveryFee.Text = _Order.DeliveryFee.ToString("0.00");
            lblTotalAmount.Text = (_Order.TotalAmount + _Order.DeliveryFee).ToString("0.00");


            if (_Order.OrderType == clsOrder.enOrderType.Takeaway)
            {
                lblTitleStatus.Text = "(Takeaway) إستلام من المحل";
                lblCustomerName.Text = "N/A"; // No customer name for takeaway orders
                lblPhoneNumber.Text = "N/A"; // No phone number for takeaway orders
                pbIconStatus.Image = Properties.Resources.takeaway32; // Assuming you have an icon for takeaway
            }
            else if(_Order.OrderType == clsOrder.enOrderType.Delivery)
            {
                //get customer name if available
                pbIconStatus.Image = Properties.Resources.delivery32; // Assuming you have an icon for delivery
                _Customer = clsCustomer.FindByCustomerID(_Order.CustomerID ?? -1);
                lblTitleStatus.Text = "(Delivery) توصيل للمنزل";
                if (_Customer == null)
                {
                    MessageBox.Show("لم يتم العثور على بيانات العميل!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                lblCustomerName.Text = _Customer.FullName;
                lblPhoneNumber.Text = _Customer.PhoneNumber;
            }

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
            if (System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count == 0)
            {
                MessageBox.Show("لم يتم العثور على طابعات في هذا النظام!", "خطأ في الطباعة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Graphics g = e.Graphics;

            Font fontTitle = new Font("Tahoma", 24, FontStyle.Bold);
            Font fontHeader = new Font("Tahoma", 18, FontStyle.Bold);
            Font fontBody = new Font("Tahoma", 16);

            float pageWidth = e.PageBounds.Width;
            float margin = 20;
            float y = 20;
            float rowHeight = 35;

            float usableWidth = pageWidth - (margin * 2);

            StringFormat right = new StringFormat() { Alignment = StringAlignment.Far };
            StringFormat center = new StringFormat() { Alignment = StringAlignment.Center };

            // ===== Header =====
            g.DrawString("أولاد علي - Awlad Ali", fontTitle, Brushes.Black, pageWidth / 2, y, center);
            y += rowHeight + 20;

            g.DrawString($"رقم الفاتورة: {_OrderID}", fontBody, Brushes.Black, pageWidth - margin, y, right);
            y += rowHeight + 10;

            g.DrawString($"التاريخ: {_Order.OrderDate:yyyy-MM-dd HH:mm}", fontBody, Brushes.Black, pageWidth - margin, y, right);
            y += rowHeight + 15;

            g.DrawLine(Pens.Black, margin, y, pageWidth - margin, y);
            y += 15;

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

            y += rowHeight + 10;
            g.DrawLine(Pens.Black, margin, y, pageWidth - margin, y);
            y += 15;

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
                g.DrawString(qty.ToString(), fontBody, Brushes.Black, colQtyX - 20, y, right);
                g.DrawString(total.ToString("0.00"), fontBody, Brushes.Black, colTotalX - 20, y, right);

                y += rowHeight;
            }

            y += 15;
            g.DrawLine(Pens.Black, margin, y, pageWidth - margin, y);
            y += rowHeight;

            if (_Order.OrderType == clsOrder.enOrderType.Takeaway)
            {
                g.DrawString("(Takeaway) " + "نوع الطلب: إستلام من المحل", fontBody, Brushes.Black, pageWidth - margin, y, right);
                y += rowHeight; 
                g.DrawString($"الإجمالي: {lblTotalAmount.Text}", fontTitle, Brushes.Black, pageWidth - margin, y, right);
            }
            else if (_Order.OrderType == clsOrder.enOrderType.Delivery)
            {
                g.DrawString("(Delivery) " + "نوع الطلب: توصيل للمنزل", fontBody, Brushes.Black, pageWidth - margin, y, right);
                y += rowHeight;

                string customerName = _Customer != null ? _Customer.FullName : "N/A";
                g.DrawString($"اسم العميل: {customerName}", fontBody, Brushes.Black, pageWidth - margin, y, right);
                y += rowHeight;

                // طباعة رقم تليفون العميل
                string customerPhone = _Customer != null ? _Customer.PhoneNumber : "N/A";
                g.DrawString($"رقم العميل: {customerPhone}", fontBody, Brushes.Black, pageWidth - margin, y, right);
                y += rowHeight;

                g.DrawString($"العنوان: {_Customer.Address}", fontBody, Brushes.Black, pageWidth - margin, y, right);
                y += rowHeight;

                if (_Order.DeliveryFee > 0)
                {
                    g.DrawString($"سعر الوجبة: {lblMealPrice.Text} ج.م", fontBody, Brushes.Black, pageWidth - margin, y, right);
                    y += rowHeight;
                    g.DrawString($"مصاريف التوصيل: {lblDeliveryFee.Text} ج.م", fontBody, Brushes.Black, pageWidth - margin, y, right);
                }
                else
                {
                    g.DrawString($"مصاريف التوصيل: الحساب مع المندوب", fontBody, Brushes.Black, pageWidth - margin, y, right);
                }
                y += rowHeight;
                if (decimal.TryParse(lblTotalAmount.Text.ToString(), out decimal totalAmount))
                {
                    string totalWithDelivery = (totalAmount).ToString("0.00");
                    g.DrawString($"الإجمالي: {totalWithDelivery} ج.م", fontTitle, Brushes.Black, pageWidth - margin, y, right);
                }
            }

            y += 20; // مسافة أمان إضافية قبل الـ Footer

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
            _OrderConfirmed = true; // Set the flag to indicate the order was confirmed/saved

            this.Close();
        }

        private void btnIgnore_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmOrderInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_OrderConfirmed && !_IsShowOrder && _showCloseConfirmation)
            {
                if(MessageBox.Show("هل أنت متأكد أنك تريد إلغاء الطلب؟ سيتم حذف الطلب من النظام.", "تأكيد الإلغاء", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true; // Cancel the form closing
                    return;
                }
                if (clsOrder.DeleteOrder(_OrderID))
                {
                    MessageBox.Show("تم إلغاء الطلب وحذفه من النظام.", "تنبيه",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}