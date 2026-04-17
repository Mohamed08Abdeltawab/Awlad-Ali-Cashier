using AwladAli.Bill;
using AwladAli.Category.Extra;
using AwladAli.GlobalClasses;
using AwladAli.Login;
using AwladAli.Product;
using AwladAli.User;
using AwladAli_Buisness; 
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AwladAli
{
    public partial class frmMain : Form
    {
        frmLogin _frmLogin;

        private int _OrderID = -1;
        private clsOrder _Order;//new order object to hold current order data until saving to DB

        private int _OrderDetailsID = -1;
        private clsOrderDetail _OrderDetails;
        public frmMain(frmLogin frm)
        {
            InitializeComponent();
            this._frmLogin = frm;
        }

        private void _CheckAdmin()
        {
            if (!clsUser.IsUserAdmin(clsGlobal.CurrentUser.UserID))
            {
                btnSettings.Enabled = false;
                btnSettings.Visible = false;
            }
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            _CheckAdmin();
            lblUsername.Text = clsGlobal.CurrentUser.UserName;
            _LoadRestaurantMenu();
            _LoadExtraAddons();
        }

        private void _LoadRestaurantMenu()
        {
            flpProductCards.Controls.Clear();
            lblTotalPrice.Text = "0.00";

            DataTable dtCategories = clsCategory.GetAllCategories();

            if (dtCategories == null || dtCategories.Rows.Count == 0)
            {
                MessageBox.Show("No Categories found in Database!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            flpProductCards.SuspendLayout();

            foreach (DataRow row in dtCategories.Rows)
            {
                // إنشاء كارت جديد لكل قسم
                ctrlCategoryCard categoryCard = new ctrlCategoryCard();

                // الحصول على الـ ID من الصف
                int categoryID = Convert.ToInt32(row["CategoryID"]);

                categoryCard.LoadCategoryData(categoryID);

                flpProductCards.Controls.Add(categoryCard);
                categoryCard.OnOrderChanged += UpdateGrandTotal;

            }

            // استئناف التحديث البصري
            flpProductCards.ResumeLayout();
        }

        // 1. دي الدالة الموحدة اللي هتجمع كل شيء
        private void UpdateGrandTotal()
        {
            decimal productsTotal = 0;
            decimal extrasTotal = 0;

            // جمع إجمالي الأكلات
            foreach (Control ctrl in flpProductCards.Controls)
            {
                if (ctrl is ctrlCategoryCard card)
                    productsTotal += card.GetCategoryTotal();
            }

            // جمع إجمالي الإضافات
            foreach (Control ctrl in flpAddonsContainer.Controls)
            {
                if (ctrl is ctrlExtraRow extra)
                    extrasTotal += extra.TotalRowPrice;
            }

            // عرض المجموع النهائي في الليبل
            lblTotalPrice.Text = (productsTotal + extrasTotal).ToString("0.00");
        }

        // 2. تعديل دالة تحميل الإضافات عشان تستخدم الدالة الموحدة
        private void _LoadExtraAddons()
        {
            flpAddonsContainer.Controls.Clear();
            DataTable dtAllExtras = clsExtra.GetAllExtras();

            foreach (DataRow row in dtAllExtras.Rows)
            {
                ctrlExtraRow rowControl = new ctrlExtraRow();
                rowControl.LoadData(Convert.ToInt32(row["ExtraID"]));

                // الاشتراك في الحدث: لما أي إضافة تتغير، نادي دالة الجمع الموحدة
                rowControl.OnExtraAmountChanged += (totalRowAmount) => {
                    UpdateGrandTotal();
                };

                flpAddonsContainer.Controls.Add(rowControl);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettings frm = new frmSettings();
            frm.ShowDialog();
            frmMain_Load(null, null); // إعادة تحميل البيانات بعد إغلاق الإعدادات
        }

        //reset order
        private void _ClearCurrentOrder()
        {
            // 1. تصفير المنتجات داخل كروت الأقسام
            foreach (Control ctrlCategory in flpProductCards.Controls)
            {
                if (ctrlCategory is ctrlCategoryCard card)
                {
                    // نمر على كل سطر منتج جوه الكارد ونصفره
                    foreach (Control ctrlProduct in card.Controls.Find("flpItemsContainer", true))
                    {
                        if (ctrlProduct is FlowLayoutPanel flp)
                        {
                            foreach (Control row in flp.Controls)
                            {
                                if (row is ctrlProductRow productRow)
                                    productRow.Reset();
                            }
                        }
                    }
                }
            }

            // 2. تصفير الإضافات
            foreach (Control ctrl in flpAddonsContainer.Controls)
            {
                if (ctrl is ctrlExtraRow extraRow)
                {
                    extraRow.Reset();
                }
            }

            // 3. تصفير إجمالي السعر في الشاشة الرئيسية
            lblTotalPrice.Text = "0.00";

            // 4. إعادة تهيئة كائن الأوردر
            _Order = new clsOrder();
            _OrderID = -1;
        }

        private void llReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ClearCurrentOrder();
        }


        //save order
        private void _SaveProductsFromCard(ctrlCategoryCard card, int OrderID)
        {
            // 1. طلب قائمة الأصناف المختارة من الكارد
            List<clsOrderDetail> itemsToSave = card.GetSelectedItems(OrderID);

            // 2. اللف على القائمة وحفظ كل سطر في الداتا بيز
            foreach (clsOrderDetail detail in itemsToSave)
            {
                if (!detail.Save())
                {
                    // لو حصل مشكلة في سطر معين ممكن تظهر رسالة أو تسجل Log
                    MessageBox.Show($"فشل حفظ الصنف رقم {detail.ProductID}");
                }
            }
        }

        private void _SaveOrder()
        {
            // 1. حساب الإجمالي النهائي قبل الحفظ
            decimal totalAmount = Convert.ToDecimal(lblTotalPrice.Text);

            if (totalAmount <= 0)
            {
                MessageBox.Show("لا يمكن حفظ طلب فارغ!");
                return;
            }

            // 2. تجهيز بيانات الأوردر الأساسي
            _Order = new clsOrder();
            _Order.UserID = clsGlobal.CurrentUser.UserID; // المستخدم اللي سجل دخول
            _Order.TotalAmount = totalAmount;
            _Order.OrderDate = DateTime.Now;

            // 3. حفظ الأوردر (Header)
            if (_Order.Save())
            {
                _OrderID = _Order.OrderID; // دلوقتى معانا الـ ID الحقيقي

                // 4. حفظ تفاصيل الأكلات من الـ CategoryCards
                foreach (Control ctrl in flpProductCards.Controls)
                {
                    if (ctrl is ctrlCategoryCard card)
                    {
                        // افترضنا إن الكارد عنده دالة بترجع قائمة بالأصناف اللي تم اختيارها
                        // أو بنلف على الـ Products اللي جوه الكارد
                        _SaveProductsFromCard(card, _OrderID);
                    }
                }

                // 5. حفظ الإضافات (Extras)
                foreach (Control ctrl in flpAddonsContainer.Controls)
                {
                    if (ctrl is ctrlExtraRow extraRow && extraRow.Quantity > 0)
                    {
                        clsOrderDetail detail = new clsOrderDetail();
                        detail.OrderID = _OrderID;
                        detail.ExtraID = extraRow.ExtraID;
                        detail.Quantity = extraRow.Quantity;
                        detail.UnitPrice = extraRow.Price;
                        detail.ProductID = null; // لأنه Extra
                        detail.SizeID = null;

                        detail.Save();
                    }
                }

            }
        }

        private void _ShowOrderInfo()
        {
            //get current order ID from _Order class 
            if (_Order == null || _Order.OrderID == -1)
            {
                MessageBox.Show("برجاء إتمام الطلب أولاً أو اختيار طلب لعرضه.", "تنبيه",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmOrderInfo frm = new frmOrderInfo(_OrderID);

            frm.ShowDialog();
            //reload data after closing order info form (in case of any changes)
            frmMain_Load(null, null);
        }


        private void btnSaveandShowOrderInfo_Click(object sender, EventArgs e)
        {
            _SaveOrder();

            _ShowOrderInfo();
        }


    }
}