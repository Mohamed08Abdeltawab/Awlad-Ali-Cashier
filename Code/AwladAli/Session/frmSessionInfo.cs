using AwladAli_Buisness;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace AwladAli.Session
{
    public partial class frmSessionInfo : Form
    {
        private int _SessionID = -1;
        private clsSession _Session;

        // تعديل الـ Constructor لاستقبال المعرف
        public frmSessionInfo(int SessionID)
        {
            InitializeComponent();
            _SessionID = SessionID;
        }

        PrintDocument printDoc = new PrintDocument();


        private void _LoadData()
        {
            // جلب بيانات الجلسة من طبقة الـ Business
            _Session = clsSession.Find(_SessionID);

            if (_Session == null)
            {
                MessageBox.Show("عفواً، لا توجد بيانات لهذه الجلسة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // عرض البيانات في الـ Labels
            lblSessionID.Text = _Session.SessionID.ToString();

            // هنا بنجيب اسم المستخدم (يفضل إضافة خاصية UserName في clsSession)
            // أو جلبها عن طريق كلاس المستخدمين
            lblUserName.Text = clsUser.Find(_Session.UserID).UserName;

            lblStartTime.Text = _Session.StartTime.ToString("dd/MM/yyyy hh:mm tt");

            // التعامل مع وقت النهاية في حالة كانت الجلسة لسه نشطة
            lblEndTime.Text = (_Session.IsActive) ? "لا تزال نشطة" : _Session.EndTime?.ToString("dd/MM/yyyy hh:mm tt");

            lblFinalCash.Text = _Session.TotalCash.ToString("0.00");
        }

        private void frmSessionInfo_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowRelatedOrders_Click(object sender, EventArgs e)
        {
            frmListOrdersForSession frm = new frmListOrdersForSession(_SessionID);
            frm.ShowDialog();

        }

        private void PrintSessionPage(object sender, PrintPageEventArgs e)
        {
            if (System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count == 0)
            {
                MessageBox.Show("لم يتم العثور على طابعات في هذا النظام!", "خطأ في الطباعة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Graphics g = e.Graphics;

            // 🏆 Exact micro-fonts configuration from the verified order receipt layout
            Font fontTitle = new Font("Tahoma", 13, FontStyle.Bold);
            Font fontHeader = new Font("Tahoma", 9, FontStyle.Bold);
            Font fontBody = new Font("Tahoma", 8);
            Font fontFooter = new Font("Tahoma", 8, FontStyle.Italic);

            float pageWidth = e.PageBounds.Width;
            float margin = 10;
            float y = 15;
            float rowHeight = 28;

            float usableWidth = pageWidth - (margin * 2);

            StringFormat alignRight = new StringFormat() { Alignment = StringAlignment.Far };
            StringFormat alignCenter = new StringFormat() { Alignment = StringAlignment.Center };
            StringFormat alignLeft = new StringFormat() { Alignment = StringAlignment.Near };

            // ===== 1. Header Section =====
            g.DrawString("أولاد علي - Awlad Ali", fontTitle, Brushes.Black, pageWidth / 2, y, alignCenter);
            y += rowHeight + 15;

            g.DrawString($"رقم الجلسة: {_Session.SessionID}", fontBody, Brushes.Black, pageWidth - margin, y, alignRight);
            y += rowHeight;

            g.DrawString($"تاريخ الطباعة: {DateTime.Now:yyyy-MM-dd HH:mm}", fontBody, Brushes.Black, pageWidth - margin, y, alignRight);
            y += rowHeight + 10;

            g.DrawLine(Pens.Black, margin, y, pageWidth - margin, y);
            y += 15;

            // ===== 2. Detailed Metadata Symmetrical Layout =====
            float labelWidth = 70; // Label allocation spacing outside the box boundary
            float boxWidth = usableWidth - labelWidth;

            float xLabel = pageWidth - margin;
            float xBoxStart = margin;
            float textPaddingY = 4;

            // Row 1: Username
            g.DrawString(":المستخدم", fontBody, Brushes.DimGray, xLabel, y + textPaddingY, alignRight);
            g.DrawRectangle(Pens.Black, xBoxStart, y, boxWidth, rowHeight);
            g.DrawString(lblUserName.Text, fontBody, Brushes.Black, xBoxStart + boxWidth - 5, y + textPaddingY, alignRight);
            y += rowHeight + 5;

            // Row 2: Start Time
            g.DrawString(":وقت البداية", fontBody, Brushes.DimGray, xLabel, y + textPaddingY, alignRight);
            g.DrawRectangle(Pens.Black, xBoxStart, y, boxWidth, rowHeight);
            g.DrawString(_Session.StartTime.ToString("yyyy-MM-dd HH:mm"), fontBody, Brushes.Black, xBoxStart + boxWidth - 5, y + textPaddingY, alignRight);
            y += rowHeight + 5;

            // Row 3: End Time
            string endTimeStr = (_Session.IsActive) ? "لا تزال نشطة" : _Session.EndTime?.ToString("yyyy-MM-dd HH:mm");
            g.DrawString(":وقت النهاية", fontBody, Brushes.DimGray, xLabel, y + textPaddingY, alignRight);
            g.DrawRectangle(Pens.Black, xBoxStart, y, boxWidth, rowHeight);
            g.DrawString(endTimeStr, fontBody, Brushes.Black, xBoxStart + boxWidth - 5, y + textPaddingY, alignRight);
            y += rowHeight + 5;

            // Row 4: Orders Count
            int ordersCount = clsOrder.GetOrdersCountBySessionID(_Session.SessionID);
            g.DrawString(":عدد الطلبات", fontBody, Brushes.DimGray, xLabel, y + textPaddingY, alignRight);
            g.DrawRectangle(Pens.Black, xBoxStart, y, boxWidth, rowHeight);
            g.DrawString(ordersCount.ToString(), fontBody, Brushes.Black, xBoxStart + boxWidth - 5, y + textPaddingY, alignRight);
            y += rowHeight + 20;

            e.HasMorePages = false;

            // ===== 3. Session Total Cash Summary (Bold & Distinctive) =====
            g.DrawString(":إجمالي المبيعات", fontHeader, Brushes.Black, pageWidth - margin, y, alignRight);
            g.DrawString($"{_Session.TotalCash:0.00} EGP", fontTitle, Brushes.Black, margin, y - 3, alignLeft);
            y += rowHeight;

            g.DrawLine(new Pen(Color.Black, 1.5f), margin, y + 5, pageWidth - margin, y + 5);
            y += 25;

            // ===== 4. Footer =====
            g.DrawString("تقرير ملخص الوردية", fontFooter, Brushes.Black, pageWidth / 2, y, alignCenter);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Bind the print drawing canvas event method
            printDoc.PrintPage += new PrintPageEventHandler(PrintSessionPage);

            // 🏆 Balanced precise height configuration: fits the 4 boxes and summary smoothly
            int approximateHeight = 250 + 400;

            // 🎯 Lock the paper scaling properties cleanly to 300px thermal roll standards
            System.Drawing.Printing.PaperSize receiptSize = new System.Drawing.Printing.PaperSize("CustomReceipt", 300, approximateHeight);
            printDoc.DefaultPageSettings.PaperSize = receiptSize;

            // Fire the print viewing dialog component
            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDoc;
            preview.ShowDialog();

            this.Close();
        }
    }
}