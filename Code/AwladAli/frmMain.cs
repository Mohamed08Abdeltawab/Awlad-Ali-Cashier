using AwladAli.Bill;
using AwladAli.Category.Extra;
using AwladAli.GlobalClasses;
using AwladAli.Login;
using AwladAli.Product;
using AwladAli.Properties;
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

        private int _SessionID = -1;
        private clsSession _CurrentSession;
        private DateTime _SessionStartTime;

        private int ErrorFlage = 1;//1 error in Session, 2 error in order

        private void _CheckAdmin()
        {
            if (!clsUser.IsUserAdmin(clsGlobal.CurrentUser.UserID))
            {
                btnSettings.Enabled = false;
                btnSettings.Visible = false;
            }
        }
        private void _EnableMainScreen()
        {
            if(clsGlobal.CurrentSessionID == -1)
            {
                flpAddonsContainer.Enabled = false;
                flpProductCards.Enabled = false;
            }
            else
            {
                flpAddonsContainer.Enabled = true;
                flpProductCards.Enabled = true;
            }
        }
        private void _RefreshMainScreenData()
        {
            _CheckAdmin();
            _EnableMainScreen();
            lblUsername.Text = clsGlobal.CurrentUser.UserName;
            _LoadRestaurantMenu();
            _LoadExtraAddons();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            _RefreshMainScreenData();
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
                int categoryID = Convert.ToInt32(row["CategoryID"]);

                // التأكد أولاً أن التصنيف يحتوي على منتجات
                // نفترض وجود دالة HasProducts في كلاس clsProduct
                if (clsProduct.DoesCategoryHaveProducts(categoryID))
                {
                    ctrlCategoryCard categoryCard = new ctrlCategoryCard();

                    categoryCard.LoadCategoryData(categoryID);

                    flpProductCards.Controls.Add(categoryCard);
                    categoryCard.OnOrderChanged += UpdateGrandTotal;
                }
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
            if(_SessionID != -1)
            {
                if (MessageBox.Show("هل أنت متأكد من إنهاء الجلسة قبل الخروج؟", "تأكيد", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _EndSessionWhenFormClosing();
                    //no return here because we want to close the form after ending session
                }
                else
                {
                    e.Cancel = true;
                    return;
                }
            }
            clsSession.CloseAnyActiveSession(); // تأكد من إغلاق أي جلسة مفتوحة قبل الخروج
            Application.Exit();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmAdminDashBoard frm = new frmAdminDashBoard();
            frm.ShowDialog();
                _RefreshMainScreenData(); // إعادة تحميل البيانات بعد إغلاق الإعدادات
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

        private bool _SaveOrder()
        {
            ErrorFlage = 0;
            // 1. حساب الإجمالي النهائي قبل الحفظ
            decimal totalAmount = Convert.ToDecimal(lblTotalPrice.Text);
            if(clsGlobal.CurrentSessionID == -1)
            {
                ErrorFlage = 1;
                return false;
            }
            if (totalAmount <= 0)
            {
                ErrorFlage = 2;
                return false;
            }

            // 2. تجهيز بيانات الأوردر الأساسي
            _Order = new clsOrder();
            _Order.UserID = clsGlobal.CurrentUser.UserID; // المستخدم اللي سجل دخول
            _Order.SessionID = clsGlobal.CurrentSessionID; // الجلسة الحالية
            _Order.TotalAmount = totalAmount;
            _Order.OrderDate = DateTime.Now;

            // 3. حفظ الأوردر (Header)
            if (_Order.Save())
            {
                _OrderID = _Order.OrderID; // دلوقتى معانا الـ ID الحقيقي
                _CurrentSession.TotalCash += totalAmount; // تحديث إجمالي المبيعات في الجلسة الحالية

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
                return true;
            }
            return false;
        }

        private void _ShowOrderInfo()
        {
            //get current order ID from _Order class 
            if (_Order == null || _OrderID == -1 || Convert.ToDecimal(lblTotalPrice.Text) <=0)
            {
                MessageBox.Show("برجاء إتمام الطلب أولا", "تنبيه",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmOrderInfo frm = new frmOrderInfo(_OrderID);

            frm.ShowDialog();
            //reload data after closing order info form (in case of any changes)
            _RefreshMainScreenData();
        }


        private void btnSaveandShowOrderInfo_Click(object sender, EventArgs e)
        {
            if (_SaveOrder())
            {
                _ShowOrderInfo();
                _ClearCurrentOrder();
            }
            else if(ErrorFlage == 1)
            {
                MessageBox.Show("برجاء بدء جلسة قبل حفظ الطلب", "تنبيه",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(ErrorFlage == 2)
            {
                MessageBox.Show("برجاء إتمام الطلب أولا", "تنبيه",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("فشل حفظ الطلب، حاول مرة أخرى", "خطأ",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btnStartSession_Click(object sender, EventArgs e)
        {
            if (_SessionID == -1)//if no active session then start new session
            {

                _CurrentSession = new clsSession();
                _CurrentSession.UserID = clsGlobal.CurrentUser.UserID; //current user
                _CurrentSession.StartTime = DateTime.Now;//set start time to now

                if (_CurrentSession.Save())//try to save session to DB
                {
                    btnStartSession.Image = Resources.session_2_64;
                    _SessionID = _CurrentSession.SessionID; //get session ID after saving
                    clsGlobal.CurrentSessionID = _CurrentSession.SessionID;

                    _SessionStartTime = _CurrentSession.StartTime;
                    sessionTimer.Start();

                    _EnableMainScreen();

                    btnStartSession.Text = "إنهاء الجلسة";
                    //my be change in ui to show session is active or not
                    MessageBox.Show("تم بدء الجلسة بنجاح", "أولاد علي", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("فشل بدء الجلسة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //if user click button while active session then end the session
                _EndSession();
            }
        }

        private void _EndSessionWhenFormClosing()
        {
            sessionTimer.Stop();
            // هنا ممكن تفتح شاشة تطلب منه يدخل المبلغ اللي في الدرج حالياً
            _CurrentSession.TotalCash = _CurrentSession.GetCurrentSales();

            if (_CurrentSession.Save())
            {
                _CurrentSession = null;
                _SessionID = -1;
                clsGlobal.CurrentSessionID = -1;
            }
        }

        private void _EndSession()
        {
            if (MessageBox.Show("هل أنت متأكد من إنهاء الجلسة؟", "تأكيد", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sessionTimer.Stop();

                // هنا ممكن تفتح شاشة تطلب منه يدخل المبلغ اللي في الدرج حالياً
                _CurrentSession.TotalCash = _CurrentSession.GetCurrentSales();

                if (_CurrentSession.Save())
                {
                    btnStartSession.Image = Resources.start_session_64;
                    _CurrentSession = null;
                    _SessionID = -1;
                    clsGlobal.CurrentSessionID = -1;

                    btnStartSession.Text = "بدء جلسة";
                    lblSessionTimer.Text = "00:00:00";
                    //my be change in ui and show in screen
                    MessageBox.Show("تم إنهاء الجلسة وحفظ المبيعات", "أولاد علي", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshMainScreenData(); // إعادة تحميل البيانات بعد إنهاء الجلسة
                }
                else
                {
                    MessageBox.Show("فشل إنهاء الجلسة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void sessionTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan duration = DateTime.Now - _SessionStartTime;

            lblSessionTimer.Text = duration.ToString(@"hh\:mm\:ss");
        }

    }
}