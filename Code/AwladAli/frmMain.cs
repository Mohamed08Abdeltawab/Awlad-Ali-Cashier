using AwladAli.Bill;
using AwladAli.Category.Extra;
using AwladAli.Customer;
using AwladAli.GlobalClasses;
using AwladAli.Login;
using AwladAli.Product;
using AwladAli.Properties;
using AwladAli.User;
using AwladAli_Buisness; 
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Security.Policy;
using System.Windows.Forms;

namespace AwladAli
{
    public partial class frmMain : Form
    {
        frmLogin _frmLogin;

        private int _OrderID = -1;
        private clsOrder _Order;//new order object to hold current order data until saving to DB
        private clsCustomer _Customer; //to hold customer data if order type is delivery

        clsGlobal.CustomerDetailsInfo _CustomerDetailsInfo;

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
        // Added a boolean flag (isNewSession) to prevent overriding the start time on brand new sessions
        private void _EnableMainScreen(bool isNewSession = false)
        {
            _CurrentSession = clsSession.FindAnyActiveSessionWithUserInfo();

            if (_CurrentSession != null)
            {
                clsUser sessionUser = clsUser.Find(_CurrentSession.UserID);

                if (sessionUser != null)
                {
                    if (sessionUser.UserID == clsGlobal.CurrentUser.UserID)
                    {
                        flpAddonsContainer.Enabled = true;
                        flpProductCards.Enabled = true;
                        pnlTakeawayDelivery.Enabled = true;

                        // Inside _EnableMainScreen (Back to normal structure)
                        _SessionID = _CurrentSession.SessionID;
                        clsGlobal.CurrentSessionID = _CurrentSession.SessionID;

                        btnStartSession.Image = Resources.session_2_64;
                        btnStartSession.Text = "إنهاء الجلسة";

                        _ResumeSessionTimer(); // This will work flawlessly now because AppExitTime resets to MinValue!
                    }
                    else
                    {
                        _DisableMainScreenControls();

                        using (frmSessionConflictDialog dialog = new frmSessionConflictDialog(sessionUser.UserName))
                        {
                            DialogResult result = dialog.ShowDialog();

                            if (result == DialogResult.Yes)
                            {
                                _CurrentSession.EndTime = DateTime.Now;
                                _CurrentSession.IsActive = false;

                                clsSession.CloseAnyActiveSession();

                                if (_CurrentSession.Save())
                                {
                                    MessageBox.Show("تم إغلاق الجلسة القديمة المعلقة بنجاح. يمكنك الآن بدء ورديتك الجديدة.",
                                                    "تأكيد الإجراء", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else if (result == DialogResult.No)
                            {
                                sessionTimer.Stop();
                                this.Hide();

                                using (frmLogin loginForm = new frmLogin())
                                {
                                    if (loginForm.ShowDialog() == DialogResult.OK)
                                    {
                                        _EnableMainScreen(false);
                                        this.Show();
                                    }
                                    else
                                    {
                                        Environment.Exit(0);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    _DisableMainScreenControls();
                    MessageBox.Show("يوجد جلسة نشطة لممستخدم غير معروف. لا يمكنك بدء جلسة جديدة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                _DisableMainScreenControls();
            }
        }
        private void _DisableMainScreenControls()
        {
            flpAddonsContainer.Enabled = false;
            flpProductCards.Enabled = false;
            pnlTakeawayDelivery.Enabled = false;

            _SessionID = -1;
            clsGlobal.CurrentSessionID = -1;
            sessionTimer.Stop();
            btnStartSession.Image = Resources.start_session_64;
            btnStartSession.Text = "بدء جلسة";
            lblSessionTimer.Text = "00:00:00";
        }


        private void _ResumeSessionTimer()
        {
            DateTime lastExitTime = Properties.Settings.Default.AppExitTime;

            // Safety check: if it's a valid old date and session is active
            if (lastExitTime != DateTime.MinValue && _CurrentSession.IsActive)
            {
                TimeSpan elapsedClosedTime = DateTime.Now - lastExitTime;
                _SessionStartTime = _CurrentSession.StartTime.Add(elapsedClosedTime);

                // 🎯 CRITICAL FIX: Reset the setting immediately so subsequent refreshes won't trigger this loop
                Properties.Settings.Default.AppExitTime = DateTime.MinValue;
                Properties.Settings.Default.Save();
            }
            else
            {
                // Default normal startup fallback
                _SessionStartTime = _CurrentSession.StartTime;
            }

            sessionTimer.Start();
        }


        private void _RefreshMainScreenData()
        {
            _CheckAdmin();
            lblUsername.Text = clsGlobal.CurrentUser.UserName;
            _LoadRestaurantMenu();
            _LoadExtraAddons();
            _EnableMainScreen(false);
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            _RefreshMainScreenData();
        }


        private void _LoadRestaurantMenu()
        {
            flpProductCards.Controls.Clear();
            lblTotalPrice.Text = "0.00";
            rbTakeaway.Checked = true; // Set default order type to Takeaway

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
                    categoryCard.OnOrderChanged += UpdateGrandTotal;//subscribe to order changed event 
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
            decimal deliveryFee = 0;

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

            if (rbDelivery.Checked &&!string.IsNullOrWhiteSpace(_CustomerDetailsInfo.DeliveryFee))
            {
                deliveryFee = decimal.TryParse(_CustomerDetailsInfo.DeliveryFee, out decimal fee)? fee: 0;
            }

            // عرض المجموع النهائي في الليبل
            lblMealPrice.Text = (productsTotal + extrasTotal).ToString("0.00");
            lblDeliveryFee.Text = deliveryFee.ToString("0.00");
            lblTotalPrice.Text = (productsTotal + extrasTotal + deliveryFee).ToString("0.00");
        }

        // 2. تعديل دالة تحميل الإضافات عشان تستخدم الدالة الموحدة
        private void _LoadExtraAddons()
        {
            flpAddonsContainer.Controls.Clear();
            DataTable dtAllExtras = clsExtra.GetAllExtras();

            if (dtAllExtras == null || dtAllExtras.Rows.Count == 0) return;

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
            // Stop the timer immediately to prevent any background ticks
            sessionTimer.Stop();
            if (_CurrentSession != null)
            {
                // Ask the user if they want to end their active session before exiting
                DialogResult result = MessageBox.Show("هل تريد إنهاء الجلسة الحالية قبل الخروج؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // End the session normally (updates EndTime and IsActive in DB)
                    _EndSessionWhenFormClosing();
                }
                // ✅ If they press 'No', we don't do anything. 
                // The form will continue its closing process naturally without loops.
                Properties.Settings.Default.AppExitTime = DateTime.Now;
                Properties.Settings.Default.Save();
            }

            // 🛡️ CRITICAL FIX: If the user closed the window from the X button, 
            // shutdown the entire process safely without triggering infinite loops.
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Environment.Exit(0);
            }
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
            lblMealPrice.Text = "0.00";
            lblDeliveryFee.Text = "0.00";

            // 4. إعادة تهيئة كائن الأوردر
            _Order = new clsOrder();
            _OrderID = -1;
        }

        private void llReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ClearCurrentOrder();
            rbTakeaway.Checked = true;
        }

        public string ConnectionString = $@"Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AwladAli.db")};Version=3;";
        private bool _SaveOrder()
        {
            ErrorFlage = 0;
            decimal totalAmount = Convert.ToDecimal(lblMealPrice.Text);

            if (clsGlobal.CurrentSessionID == -1)
            {
                ErrorFlage = 1;
                return false;
            }
            if (totalAmount <= 0)
            {
                ErrorFlage = 2;
                return false;
            }


            // 1. Establish the main database connection manually to control transaction scope
            using (System.Data.SQLite.SQLiteConnection connection = new System.Data.SQLite.SQLiteConnection(ConnectionString))
            {
                connection.Open();

                // 2. Start the database transaction context
                using (System.Data.SQLite.SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Setup core order header record properties
                        _Order = new clsOrder();
                        _Order.UserID = clsGlobal.CurrentUser.UserID;
                        _Order.SessionID = clsGlobal.CurrentSessionID;
                        _Order.TotalAmount = totalAmount;
                        _Order.OrderDate = DateTime.Now;

                        if (rbTakeaway.Checked)
                        {
                            _Order.OrderType = clsOrder.enOrderType.Takeaway;
                            _Order.CustomerID = null;
                            _Order.DeliveryFee = 0;
                        }
                        else if (rbDelivery.Checked)
                        {
                            _Order.OrderType = clsOrder.enOrderType.Delivery;
                            if (string.IsNullOrEmpty(_CustomerDetailsInfo.PhoneNumber))
                            {
                                ErrorFlage = 3;
                                transaction.Rollback();
                                return false;
                            }

                            _Customer = clsCustomer.FindByPhoneNumber(_CustomerDetailsInfo.PhoneNumber);
                            if (_Customer != null)
                            {
                                _Order.CustomerID = _Customer.CustomerID;
                                _Order.DeliveryFee = decimal.TryParse(lblDeliveryFee.Text, out decimal fee) ? fee : 0;
                            }
                            else
                            {
                                MessageBox.Show("برجاء إضافة بيانات العميل للطلب التوصيل", "تنبيه",
                                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                transaction.Rollback();
                                return false;
                            }
                        }

                        // 3. Save the main order record header with shared transaction link
                        if (!_Order.SaveWithTransaction(connection, transaction))
                        {
                            transaction.Rollback();
                            return false;
                        }

                        _OrderID = _Order.OrderID;

                        // 4. Save detailed meal products items from Category Cards loops
                        foreach (Control ctrl in flpProductCards.Controls)
                        {
                            if (ctrl is ctrlCategoryCard card)
                            {
                                List<clsOrderDetail> itemsToSave = card.GetSelectedItems(_OrderID);
                                foreach (clsOrderDetail detail in itemsToSave)
                                {
                                    // Pass shared transaction down to product details query stream
                                    if (!detail.SaveWithTransaction(connection, transaction))
                                    {
                                        throw new Exception("Failed to insert product item detail record.");
                                    }
                                }
                            }
                        }

                        // 5. Save detailed extra addons records
                        foreach (Control ctrl in flpAddonsContainer.Controls)
                        {
                            if (ctrl is ctrlExtraRow extraRow && extraRow.Quantity > 0)
                            {
                                clsOrderDetail detail = new clsOrderDetail();
                                detail.OrderID = _OrderID;
                                detail.ExtraID = extraRow.ExtraID;
                                detail.Quantity = extraRow.Quantity;
                                detail.UnitPrice = extraRow.Price;
                                detail.ProductID = null;
                                detail.SizeID = null;

                                // Pass shared transaction down to extra addons query stream
                                if (!detail.SaveWithTransaction(connection, transaction))
                                {
                                    throw new Exception("Failed to insert extra addon item record.");
                                }
                            }
                        }

                        // 6. Database Atomic Commit: Safely write everything to disk now
                        transaction.Commit();

                        // 7. Safe Live RAM State Update: Safe to modify since disk operations succeeded
                        if (_CurrentSession != null)
                        {
                            _CurrentSession.TotalCash += totalAmount;
                        }

                        return true;
                    }
                    catch (Exception)
                    {
                        // 🛑 Disaster Recovery: Wipe out partial changes if an issue pops up
                        transaction.Rollback();
                        return false;
                    }
                }
            }
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
            else if(ErrorFlage == 3)
            {
                MessageBox.Show("برجاء إضافة بيانات العميل للطلب التوصيل", "تنبيه",
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
            if (_SessionID == -1 || _CurrentSession == null)
            {
                _CurrentSession = new clsSession();
                _CurrentSession.UserID = clsGlobal.CurrentUser.UserID;
                _CurrentSession.StartTime = DateTime.Now;

                if (_CurrentSession.Save())
                {
                    btnStartSession.Image = Resources.session_2_64;
                    _SessionID = _CurrentSession.SessionID;
                    clsGlobal.CurrentSessionID = _CurrentSession.SessionID;

                    _SessionStartTime = _CurrentSession.StartTime;

                    // 🎯 CRITICAL FIX: Clear the exit time setting on brand new sessions immediately
                    Properties.Settings.Default.AppExitTime = DateTime.MinValue;
                    Properties.Settings.Default.Save();

                    sessionTimer.Start();
                    _EnableMainScreen(); // Now it will execute safely without flags

                    btnStartSession.Text = "إنهاء الجلسة";
                    MessageBox.Show("تم بدء الجلسة بنجاح", "أولاد علي", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("فشل بدء الجلسة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
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

            // 🏆 Math.Floor ensures we get the absolute total hours without rounding up fractions
            int totalHours = (int)Math.Floor(duration.TotalHours);

            // 🎯 Format each part perfectly: D2 ensures a leading zero if the number is less than 10 (e.g., "05")
            string hoursStr = totalHours.ToString("D2");
            string minutesStr = duration.Minutes.ToString("D2");
            string secondsStr = duration.Seconds.ToString("D2");

            // Display the final combined string to the label layout
            lblSessionTimer.Text = $"{hoursStr}:{minutesStr}:{secondsStr}";
        }

        private void rbTakeaway_CheckedChanged(object sender, EventArgs e)
        {
            llCustomerDetails.Visible = false;
            llShowCustomerDetails.Visible = false;
            llCustomerDetails.Visible = false;
            pbCancel.Visible = false;
            lblDeliveryFee.Text = "0.00";
            _CustomerDetailsInfo = default(clsGlobal.CustomerDetailsInfo);
            UpdateGrandTotal();
        }

        private void rbDelivery_CheckedChanged(object sender, EventArgs e)
        {
            llCustomerDetails.Visible = true;
            UpdateGrandTotal();
        }

        private void llCustomerDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCustomerDetailsforDelivery frm = new frmCustomerDetailsforDelivery();
            frm.DeliveryDataBack += frm_DeliveryDataBack;
            frm.ShowDialog();

            if (!string.IsNullOrEmpty(_CustomerDetailsInfo.PhoneNumber))
            {
                llShowCustomerDetails.Visible = true;
                llCustomerDetails.Visible = false;
                pbCancel.Visible = true;
            }
            UpdateGrandTotal();
        }

        public void frm_DeliveryDataBack(object sender, CustomerSavedEventArgsReturnDeliveryData e)
        {
            _CustomerDetailsInfo = e.CustomerDetailsInfo;
        }

        private void llShowCustomerDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCustomerDetailsforDelivery frm = new frmCustomerDetailsforDelivery(_CustomerDetailsInfo);
            frm.DeliveryDataBack += frm_DeliveryDataBack;
            frm.ShowDialog();
            UpdateGrandTotal();
        }


        private void pbCancel_Click(object sender, EventArgs e)
        {
            llShowCustomerDetails.Visible = false;
            llCustomerDetails.Visible = true;
            pbCancel.Visible = false;
            _CustomerDetailsInfo = default(clsGlobal.CustomerDetailsInfo);
            UpdateGrandTotal();
        }
    }
}