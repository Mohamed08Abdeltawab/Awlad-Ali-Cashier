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
            // التحقق من وجود طابعة
            if (PrinterSettings.InstalledPrinters.Count == 0)
            {
                MessageBox.Show("No printers found on this system!", "Printing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Graphics g = e.Graphics;

            // نفس إعدادات الخطوط التي استخدمتها
            Font fontTitle = new Font("Tahoma", 24, FontStyle.Bold);
            Font fontHeader = new Font("Tahoma", 18, FontStyle.Bold);
            Font fontBody = new Font("Tahoma", 16);

            float pageWidth = e.PageBounds.Width;
            float margin = 20;
            float y = 20;
            float rowHeight = 40; // زدنا الارتفاع قليلاً لراحة العين في تقارير الجلسات

            StringFormat right = new StringFormat() { Alignment = StringAlignment.Far };
            StringFormat center = new StringFormat() { Alignment = StringAlignment.Center };
            StringFormat left = new StringFormat() { Alignment = StringAlignment.Near };

            // ===== Header (العنوان كما هو) =====
            g.DrawString("أولاد علي - Awlad Ali", fontTitle, Brushes.Black, pageWidth / 2, y, center);
            y += rowHeight + 20;

            // ===== رقم الجلسة وتاريخ الطباعة =====
            // رقم الجلسة (يمين)
            g.DrawString($"رقم الجلسة: {_Session.SessionID}", fontBody, Brushes.Black, pageWidth - margin, y, right);
            // تاريخ الطباعة الآن (شمال)
            g.DrawString($"تاريخ الطباعة: {DateTime.Now:yyyy-MM-dd HH:mm}", fontBody, Brushes.Black, margin, y, left);

            y += rowHeight;
            g.DrawLine(Pens.Black, margin, y, pageWidth - margin, y);
            y += 20;

            // ===== بيانات الجلسة التفصيلية =====

            // اسم المستخدم
            g.DrawString($":اسم المستخدم", fontHeader, Brushes.Black, pageWidth - margin, y, right);
            g.DrawString(lblUserName.Text, fontBody, Brushes.Black, pageWidth - margin - 220, y, right);
            y += rowHeight;

            // وقت البداية
            g.DrawString($":وقت البداية", fontHeader, Brushes.Black, pageWidth - margin, y, right);
            g.DrawString(_Session.StartTime.ToString("yyyy-MM-dd HH:mm"), fontBody, Brushes.Black, pageWidth - margin - 180, y, right);
            y += rowHeight;

            // وقت النهاية
            string endTimeStr = (_Session.IsActive) ? "لا تزال نشطة" : _Session.EndTime?.ToString("yyyy-MM-dd HH:mm");
            g.DrawString($":وقت النهاية", fontHeader, Brushes.Black, pageWidth - margin, y, right);
            g.DrawString(endTimeStr, fontBody, Brushes.Black, pageWidth - margin - 180, y, right);
            y += rowHeight;

            // عدد الأوردرات (بافتراض أنك قمت بحسابها في الـ UI أو البزنس)
            // ملاحظة: يمكنك جلب عدد الصفوف من الـ DataTable الخاصة بالأوردرات المتعلقة بالجلسة
            int ordersCount = clsOrder.GetOrdersCountBySessionID(_Session.SessionID);
            g.DrawString($":عدد الطلبات", fontHeader, Brushes.Black, pageWidth - margin, y, right);
            g.DrawString(ordersCount.ToString(), fontBody, Brushes.Black, pageWidth - margin - 180, y, right);

            y += rowHeight + 10;
            g.DrawLine(Pens.Black, margin, y, pageWidth - margin, y);
            y += 20;

            // ===== المبلغ الكلي (بخط عريض ومميز) =====
            g.DrawString($"إجمالي مبيعات الجلسة: {_Session.TotalCash:0.00} ج.م", fontTitle, Brushes.Black, pageWidth - margin, y, right);

            y += rowHeight + 40;

            // ===== Footer =====
            g.DrawString("تقرير ملخص الوردية", fontBody, Brushes.Black, pageWidth / 2, y, center);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printDoc.PrintPage += new PrintPageEventHandler(PrintSessionPage);

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDoc;
            preview.ShowDialog(); // للمعاينة قبل الطباعة (اختياري)

            this.Close();
        }
    }
}