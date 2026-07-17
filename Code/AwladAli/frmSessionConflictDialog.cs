using AwladAli.GlobalClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AwladAli
{
    public partial class frmSessionConflictDialog : Form
    {
        public frmSessionConflictDialog(string activeUserName)
        {
            InitializeComponent();
            lblMessage.Text = $"({activeUserName}) " + "توجد جلسة مفتوحة حالياً باسم المستخدم\n\n" +
                          $"برجاء اختيار إجراء للمتابعة";
        }

        private void frmSessionConflictDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 🛡️ المطب الذكي: لو قفل الشاشة من زرار الـ X (ولم يضغط على أي زرار)
            if (this.DialogResult == DialogResult.Cancel || this.DialogResult == DialogResult.None)
            {
                // إجبار النتيجة لتكون 'No' ليفهم السيستم أنه اختار تسجيل خروج
                this.DialogResult = DialogResult.No;
            }
        }

        private void btnCloseOldSession_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes; // سنعتبر 'Yes' تعني إغلاق الجلسات المتاحة
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No; // سنعتبر 'No' تعني تسجيل الخروج
            clsGlobal.IsLoggingOut = true;
            this.Close();
        }
    }
}
