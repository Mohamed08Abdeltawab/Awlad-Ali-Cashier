using AwladAli_Buisness;
using System;
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

        private void btnSaveAndPrint_Click(object sender, EventArgs e)
        {

        }
    }
}