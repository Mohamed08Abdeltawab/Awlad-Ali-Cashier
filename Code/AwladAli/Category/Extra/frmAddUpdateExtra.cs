using AwladAli_Buisness; // تأكد من اسم الـ namespace الخاص بطبقة البيزنس
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AwladAli.Category.Extra
{
    public partial class frmAddUpdateExtra : Form
    {
        // تعريف الحالات (إضافة أو تعديل)
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        private int _ExtraID = -1;
        private clsExtra _Extra;


        public frmAddUpdateExtra()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdateExtra(int ExtraID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _ExtraID = ExtraID;
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "إضافة إضافة جديدة";
                this.Text = "Add New Extra";
                _Extra = new clsExtra();
            }
            else
            {
                lblTitle.Text = "تعديل إضافة";
                this.Text = "Update Extra";
            }

            txtFoodName.Text = "";
            txtPrice.Text = ""; // هذا يمثل السعر في تصميمك
        }

        private void _LoadData()
        {
            _Extra = clsExtra.Find(_ExtraID);

            if (_Extra == null)
            {
                MessageBox.Show("لا توجد إضافة بهذا الرقم ID = " + _ExtraID, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblExtraID.Text = _Extra.ExtraID.ToString();
            txtFoodName.Text = _Extra.ExtraName;
            txtPrice.Text = _Extra.Price.ToString("0.00");
        }

        private void frmAddUpdateExtra_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void txtFoodName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFoodName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFoodName, "يجب إدخال اسم الإضافة!");
            }
            else
            {
                errorProvider1.SetError(txtFoodName, null);
            }
        }

        private void txtSmallSize_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPrice.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPrice, "يجب إدخال السعر!");
            }
            else if (!decimal.TryParse(txtPrice.Text.Trim(), out _))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPrice, "الرجاء إدخال رقم صحيح للسعر!");
            }
            else
            {
                errorProvider1.SetError(txtPrice, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("بعض الحقول غير صحيحة، يرجى فحصها.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _Extra.ExtraName = txtFoodName.Text.Trim();
            _Extra.Price = Convert.ToDecimal(txtPrice.Text.Trim());

            if (_Extra.Save())
            {
                lblTitle.Text = "تعديل إضافة";
                _Mode = enMode.Update;
                lblExtraID.Text = _Extra.ExtraID.ToString();

                MessageBox.Show("تم حفظ البيانات بنجاح.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("فشل في حفظ البيانات.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ملاحظة: تأكد من تفعيل زر الحفظ عند الكتابة في الـ TextBoxes
        private void txt_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }
    }
}