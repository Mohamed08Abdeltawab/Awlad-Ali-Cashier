using AwladAli.Category.Extra;
using AwladAli.GlobalClasses;
using AwladAli.Login;
using AwladAli.Product; 
using AwladAli_Buisness; 
using System;
using System.Data;
using System.Windows.Forms;

namespace AwladAli
{
    public partial class frmMain : Form
    {
        frmLogin _frmLogin;

        public frmMain(frmLogin frm)
        {
            InitializeComponent();
            this._frmLogin = frm;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblUsername.Text = clsGlobal.CurrentUser.UserName;
            _LoadRestaurantMenu();
            _LoadExtraAddons();
        }

        private void _LoadRestaurantMenu()
        {
            flpProductCards.Controls.Clear();

            
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
    }
}