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
        // 🛑 CRITICAL: Define this variable outside the method (at the class level)
        // This tracking index ensures the printer knows where it left off on the next page.
        private int _currentItemIndex = 0;

        private void PrintOrderPage(object sender, PrintPageEventArgs e)
        {
            if (System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count == 0)
            {
                MessageBox.Show("لم يتم العثور على طابعات في هذا النظام!", "خطأ في الطباعة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Graphics g = e.Graphics;

            // 🏆 صغرنا حجوم الخطوط قليلاً لتناسب عرض الرول وتظهر شيك جداً كالمطاعم الكبرى
            Font fontTitle = new Font("Tahoma", 13, FontStyle.Bold);
            Font fontHeader = new Font("Tahoma", 9, FontStyle.Bold);
            Font fontBody = new Font("Tahoma", 8);
            Font fontFooter = new Font("Tahoma", 8, FontStyle.Italic);

            float pageWidth = e.PageBounds.Width;
            float margin = 10; // تقليل الهامش لزيادة المساحة المتاحة
            float y = 15;
            float rowHeight = 28;

            float usableWidth = pageWidth - (margin * 2);

            // أدوات التحكم في اتجاه نصوص كل عمود بالمسطرة
            StringFormat alignRight = new StringFormat() { Alignment = StringAlignment.Far };
            StringFormat alignCenter = new StringFormat() { Alignment = StringAlignment.Center };
            StringFormat alignLeft = new StringFormat() { Alignment = StringAlignment.Near };

            // ===== 1. Header Section =====
            g.DrawString("أولاد علي - Awlad Ali", fontTitle, Brushes.Black, pageWidth / 2, y, alignCenter);
            y += rowHeight + 15;

            g.DrawString($"رقم الفاتورة: {_OrderID}", fontBody, Brushes.Black, pageWidth - margin, y, alignRight);
            y += rowHeight;

            g.DrawString($"التاريخ: {_Order.OrderDate:yyyy-MM-dd HH:mm}", fontBody, Brushes.Black, pageWidth - margin, y, alignRight);
            y += rowHeight + 10;

            g.DrawLine(Pens.Black, margin, y, pageWidth - margin, y);
            y += 10;

            // ===== 2. الأعمدة وحساب إحداثياتها بدقة منعاً للتداخل =====
            // تقسيم المساحة المتاحة: الصنف 45%، السعر 18%، الكمية 12%، الإجمالي 25%
            float colItemWidth = usableWidth * 0.45f;
            float colPriceWidth = usableWidth * 0.18f;
            float colQtyWidth = usableWidth * 0.12f;
            float colTotalWidth = usableWidth * 0.25f;

            // نقاط الـ X الثابتة لكل عمود (التحرك من اليسار إلى اليمين بناءً على نوع المحاذاة)
            float xTotal = margin;                           // الإجمالي في أقصى الشمال
            float xQty = xTotal + colTotalWidth;           // الكمية بعد الإجمالي
            float xPrice = xQty + colQtyWidth;               // السعر بعد الكمية
            float xItem = pageWidth - margin;               // الصنف يبدأ محاذاته من أقصى اليمين

            // ===== طباعة عناوين الجدول =====
            g.DrawString("الصنف", fontHeader, Brushes.Black, xItem, y, alignRight);
            g.DrawString("السعر", fontHeader, Brushes.Black, xPrice, y, alignLeft);
            g.DrawString("الكمية", fontHeader, Brushes.Black, xQty + (colQtyWidth / 2) - 4, y, alignCenter);
            g.DrawString("الإجمالي", fontHeader, Brushes.Black, xTotal, y, alignLeft);

            y += rowHeight;
            g.DrawLine(Pens.Black, margin, y, pageWidth - margin, y);
            y += 10;

            // ===== 3. Items List Loop =====
            DataTable dtItems = clsOrderDetail.GetOrderItemsForPrinting(_OrderID);

            foreach (DataRow row in dtItems.Rows)
            {
                string name = row["ItemDescription"].ToString();
                int qty = Convert.ToInt32(row["Quantity"]);
                decimal price = Convert.ToDecimal(row["UnitPrice"]);
                decimal total = qty * price;

                // طباعة كل عمود بمحاذاته المستقلة المستحيل تخليه يركب فوق العمود التاني
                g.DrawString(name, fontBody, Brushes.Black, xItem, y, alignRight);
                g.DrawString(price.ToString("0.00"), fontBody, Brushes.Black, xPrice, y, alignLeft);
                g.DrawString(qty.ToString(), fontBody, Brushes.Black, xQty + (colQtyWidth / 2), y, alignCenter);
                g.DrawString(total.ToString("0.00"), fontBody, Brushes.Black, xTotal, y, alignLeft);

                y += rowHeight;
            }

            e.HasMorePages = false;

            // ===== 4. Totals & Customer Info =====
            y += 10;
            g.DrawLine(Pens.Black, margin, y, pageWidth - margin, y);
            y += 15;

            Pen thinPen = new Pen(Color.LightGray, 1);

            if (_Order.OrderType == clsOrder.enOrderType.Takeaway)
            {
                g.DrawString(":نوع الطلب", fontBody, Brushes.Black, pageWidth - margin, y, alignRight);
                g.DrawString("تيك أواي (Takeaway)", fontHeader, Brushes.Black, margin, y, alignLeft);
                y += rowHeight + 10;

                g.DrawLine(Pens.Black, margin, y, pageWidth - margin, y);
                y += 15;

                g.DrawString(":الإجمالي النهائي", fontHeader, Brushes.Black, pageWidth - margin, y, alignRight);
                g.DrawString($"{_Order.TotalAmount.ToString("0.00")} EGP", fontTitle, Brushes.Blue, margin, y - 5, alignLeft);
                y += rowHeight;
            }
            else if (_Order.OrderType == clsOrder.enOrderType.Delivery)
            {
                g.DrawString("بيانات التوصيل والعميل", fontHeader, Brushes.Black, pageWidth - margin, y, alignRight);
                y += rowHeight + 8;

                float boxTop = y;
                float boxHeight = rowHeight * 3;
                g.DrawRectangle(Pens.Black, margin, boxTop, usableWidth, boxHeight);

                float textPaddingY = 4;

                string customerName = _Customer != null ? _Customer.FullName : "N/A";
                g.DrawString(":اسم العميل", fontBody, Brushes.DimGray, pageWidth - margin - 5, y + textPaddingY, alignRight);
                g.DrawString(customerName, fontBody, Brushes.Black, margin + 5, y + textPaddingY, alignLeft);

                y += rowHeight;
                g.DrawLine(thinPen, margin, y, pageWidth - margin, y);

                string customerPhone = _Customer != null ? _Customer.PhoneNumber : "N/A";
                g.DrawString(":رقم الهاتف", fontBody, Brushes.DimGray, pageWidth - margin - 5, y + textPaddingY, alignRight);
                g.DrawString(customerPhone, fontBody, Brushes.Black, margin + 5, y + textPaddingY, alignLeft);

                y += rowHeight;
                g.DrawLine(thinPen, margin, y, pageWidth - margin, y);

                string customerAddress = _Customer != null ? _Customer.Address : "N/A";
                g.DrawString(":العنوان", fontBody, Brushes.DimGray, pageWidth - margin - 5, y + textPaddingY, alignRight);
                g.DrawString(customerAddress, fontBody, Brushes.Black, margin + 5, y + textPaddingY, alignLeft);

                y = boxTop + boxHeight + 20;

                decimal subTotal = lblMealPrice.Text != "N/A" ? _Order.TotalAmount : 0;
                decimal deliveryFee = lblDeliveryFee.Text != "N/A" ? _Order.DeliveryFee : 0;
                decimal grandTotal = subTotal + deliveryFee;

                g.DrawString(":إجمالي الوجبات", fontBody, Brushes.Black, pageWidth - margin, y, alignRight);
                g.DrawString($"{subTotal.ToString("0.00")} EGP", fontBody, Brushes.Black, margin, y, alignLeft);
                y += rowHeight;

                g.DrawString(":رسوم التوصيل", fontBody, Brushes.Black, pageWidth - margin, y, alignRight);
                if (deliveryFee > 0)
                {
                    g.DrawString($"{deliveryFee.ToString("0.00")} EGP", fontBody, Brushes.Black, margin, y, alignLeft);
                }
                else
                {
                    g.DrawString("الحساب مع المندوب", fontBody, Brushes.Black, margin, y, alignLeft);
                }
                y += rowHeight;

                g.DrawLine(new Pen(Color.Black, 1.5f), margin, y + 5, pageWidth - margin, y + 5);
                y += 15;

                g.DrawString(":الإجمالي الكلي", fontHeader, Brushes.Black, pageWidth - margin, y, alignRight);
                g.DrawString($"{grandTotal.ToString("0.00")} EGP", fontTitle, Brushes.Black, margin, y - 5, alignLeft);
                y += rowHeight;
            }

            y += 30;
            g.DrawString("شكراً لزيارتكم", fontFooter, Brushes.Black, pageWidth / 2, y, alignCenter);
        }

        private void btnSaveAndPrint_Click(object sender, EventArgs e)
        {
            // Attach the drawing event method to the print document instance
            printDoc.PrintPage += new PrintPageEventHandler(PrintOrderPage);

            // 📄 Fetch the items first to calculate the exact dynamic height required for the thermal roll
            DataTable dtItems = clsOrderDetail.GetOrderItemsForPrinting(_OrderID);
            int itemCount = dtItems.Rows.Count;

            // Calculate approximate visual height: 
            // 250px (Header/Logo) + 400px (Totals/Delivery Box/Footer) + (Items Count * Row Height)
            int approximateHeight = 250 + 400 + (itemCount * 35);

            // Set custom paper size for thermal printers inside the preview window 
            // Width: 300px (standard 80mm scaling), Height: completely dynamic based on items
            System.Drawing.Printing.PaperSize receiptSize = new System.Drawing.Printing.PaperSize("CustomReceipt", 300, approximateHeight);
            printDoc.DefaultPageSettings.PaperSize = receiptSize;

            // Initialize and display the structured Print Preview Dialog
            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDoc;
            preview.ShowDialog();

            // Set the flag to indicate the order was confirmed/saved successfully
            _OrderConfirmed = true;

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