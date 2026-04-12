using AwladAli_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AwladAli.Category
{
    public partial class frmAddUpdateProduct : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        private int _ProductID = -1;
        private int _CategoryID = -1;
        private clsProduct _Product;

        // Constructor للإضافة (محتاجين رقم القسم اللي هنضيف فيه)
        public frmAddUpdateProduct(int CategoryID)
        {
            InitializeComponent();
            _CategoryID = CategoryID;
            _Mode = enMode.AddNew;
        }

        public frmAddUpdateProduct(int CategoryID,int ProductID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _CategoryID = CategoryID;
            _ProductID = ProductID;

            _Product = clsProduct.Find(_ProductID);
        }

        // Constructor للتعديل (محتاجين رقم المنتج)
        

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "اضافة أكلة جديدة";
                _Product = new clsProduct();
                _Product.CategoryID = _CategoryID;
                label7.Text = _CategoryID.ToString();
                
            }
            else
            {
                lblTitle.Text = "تعديل بيانات الأكلة";
            }
            txtFoodName.Text = "";
                txtSmallSize.Text = null;
                txtMeduimSize.Text = null;
                txtLargeSize.Text = null;
                txtXlargeSize.Text = null;
                btnSave.Enabled = true;
            
        }

        private void _LoadData()
        {
            _Product = clsProduct.Find(_ProductID);

            if (_Product == null)
            {
                MessageBox.Show("هذا المنتج غير موجود!");
                this.Close();
                return;
            }

            label6.Text = _Product.ProductID.ToString();
            label7.Text = _Product.CategoryID.ToString();
            txtFoodName.Text = _Product.ProductName;

            // تحميل الأسعار من جدول الـ ProductSizes
            // افترضنا وجود دالة في البيزنس بتجيب الأسعار مرتبطة بالـ ProductID
            DataTable dtPrices = clsProductSize.GetPricesByProductID(_ProductID);

            foreach (DataRow row in dtPrices.Rows)
            {
                string sizeName = row["SizeName"].ToString();
                string price = row["Price"].ToString();

                if (sizeName == "S") txtSmallSize.Text = price;
                if (sizeName == "M") txtMeduimSize.Text = price;
                if (sizeName == "L") txtLargeSize.Text = price;
                if (sizeName == "XL") txtXlargeSize.Text = price;
            }
        }

        private void frmAddUpdateProduct_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        // --- Validation Logic ---

        

        private void txtFoodName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFoodName.Text.Trim()))
            {
                e.Cancel = true;
                MessageBox.Show("يجب ادخال اسم الأكلة");
            }
        }

        // --- Action Buttons ---

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren()) return;

            _Product.ProductName = txtFoodName.Text.Trim();
            _Product.CategoryID = int.Parse(label7.Text);

            if (_Product.Save())
            {
                // بعد حفظ الأكلة، نحفظ الأسعار في جدول ProductSizes
                _SaveProductPrices(_Product.ProductID);

                _Mode = enMode.Update;
                label6.Text = _Product.ProductID.ToString();
                lblTitle.Text = "تعديل بيانات الأكلة";

                MessageBox.Show("تم حفظ البيانات بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("فشل حفظ البيانات!");
            }
        }

        private void _SaveProductPrices(int ProductID)
        {
            // دالة تقوم بمسح الأسعار القديمة وإضافة الجديدة أو عمل Update
            // دي خطوة مهمة عشان نضمن إن الأسعار مربوطة بالـ ProductID الصح
            clsProductSize.UpdateProductPrices(ProductID,
                txtSmallSize.Text.Trim(),
                txtMeduimSize.Text.Trim(),
                txtLargeSize.Text.Trim(),
                txtXlargeSize.Text.Trim());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            char decimalSeparator = '.';

            // 1. السماح بالأرقام، الـ Backspace، والعلامة العشرية
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != decimalSeparator))
            {
                e.Handled = true;
                return;
            }

            // 2. منع كتابة علامة عشرية تانية لو موجودة أصلاً
            if ((e.KeyChar == decimalSeparator) && (txt.Text.IndexOf(decimalSeparator) > -1))
            {
                e.Handled = true;
                return;
            }

            // 3. منع كتابة أكتر من رقمين بعد العلامة العشرية
            if (txt.Text.Contains(decimalSeparator))
            {
                // بنشوف مكان العلامة العشرية فين
                int index = txt.Text.IndexOf(decimalSeparator);
                // بنشوف طول النص بعد العلامة
                int lengthAfterDecimal = txt.Text.Length - index - 1;

                // لو المستخدم بيحاول يكتب (مش بيمسح) وكان المؤشر بعد العلامة، نعد الأرقام
                if (!char.IsControl(e.KeyChar) && lengthAfterDecimal >= 2 && txt.SelectionStart > index)
                {
                    e.Handled = true;
                }
            }
        }

    }
}