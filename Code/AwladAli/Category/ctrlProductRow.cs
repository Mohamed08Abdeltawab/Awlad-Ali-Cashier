using System;
using System.Windows.Forms;

namespace AwladAli.Product
{
    public partial class ctrlProductRow : UserControl
    {
        public ctrlProductRow()
        {
            InitializeComponent();
            // تأمين أن الكمية لا تفتح إلا عند اختيار الصنف
            _ResetQuantityState();
        }

        // دالة لإعادة ضبط حالة مربعات الكمية (تعطيلها)
        private void _ResetQuantityState()
        {
            numQuantityS.Enabled = false;
            numQuantityM.Enabled = false;
            numQuantityL.Enabled = false;
            numQuantityXl.Enabled = false;
        }

        // دالة تعبئة البيانات من قاعدة البيانات
        public void SetInfo(string productName, object priceS, object priceM, object priceL, object priceXl)
        {
            lblProductName.Text = productName;

            // معالجة السعر والحجم S
            _UpdateSizeUI(chkSelectPriceS, numQuantityS, priceS);

            // معالجة السعر والحجم M
            _UpdateSizeUI(chkSelectPriceM, numQuantityM, priceM);

            // معالجة السعر والحجم L
            _UpdateSizeUI(chkSelectPriceL, numQuantityL, priceL);

            // معالجة السعر والحجم XL
            _UpdateSizeUI(chkSelectPriceXL, numQuantityXl, priceXl);
        }

        // دالة مساعدة لتحديث الواجهة لكل حجم
        private void _UpdateSizeUI(CheckBox chk, NumericUpDown num, object price)
        {
            if (price != DBNull.Value && price != null)
            {
                chk.Text = Convert.ToDecimal(price).ToString("0.00");
                chk.Visible = true;
                num.Visible = true;
                chk.Enabled = true; // نضمن إنه شغال لو كان مخفي قبل كدة
            }
            else
            {
                // إخفاء العناصر تماماً يعطي مظهراً أنظف للشاشة
                chk.Visible = false;
                num.Visible = false;
                chk.Checked = false;
                num.Value = 1;
            }
        }

        // أحداث تغيير حالة الـ Checkbox لفتح/غلق الكمية
        private void chkSelectPriceS_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectPriceS.Checked)
            {
                numQuantityS.Enabled = true;
                numQuantityS.Value = 1; // تعيين القيمة الافتراضية إلى 1 عند التمكين
            }
            else
            {
                numQuantityS.Enabled = false;
                numQuantityS.Value = 0; // إعادة تعيين القيمة إلى 0 عند التعطيل 
            }
        }

        private void chkSelectPriceM_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectPriceM.Checked)
            {
                numQuantityM.Enabled = true;
                numQuantityM.Value = 1; // تعيين القيمة الافتراضية إلى 1 عند التمكين
            }
            else
            {
                numQuantityM.Enabled = false;
                numQuantityM.Value = 0; // إعادة تعيين القيمة إلى 0 عند التعطيل 
            }
        }

        private void chkSelectPriceL_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectPriceL.Checked)
            {
                numQuantityL.Enabled = true;
                numQuantityL.Value = 1; // تعيين القيمة الافتراضية إلى 1 عند التمكين
            }
            else
            {
                numQuantityL.Enabled = false;
                numQuantityL.Value = 0; // إعادة تعيين القيمة إلى 0 عند التعطيل 
            }
        }

        private void chkSelectPriceXL_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectPriceXL.Checked)
            {
                numQuantityXl.Enabled = true;
                numQuantityXl.Value = 1; // تعيين القيمة الافتراضية إلى 1 عند التمكين
            }
            else
            {
                numQuantityXl.Enabled = false;
                numQuantityXl.Value = 0; // إعادة تعيين القيمة إلى 0 عند التعطيل 
            }
        }
    }
}