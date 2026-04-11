using AwladAli_Buisness; // تأكد من استدعاء طبقة البيزنس الخاصة بك
using System;
using System.Data;
using System.Windows.Forms;

namespace AwladAli.Product
{
    public partial class ctrlCategoryCard : UserControl
    {
        public ctrlCategoryCard()
        {
            InitializeComponent();
        }

        /// <summary>
        /// دالة تحميل الأصناف داخل الكارت بناءً على القسم
        /// </summary>
        /// <param name="CategoryID">رقم القسم من قاعدة البيانات</param>
        /// <param name="CategoryName">اسم القسم للعرض في الهيدر</param>
        public void LoadCategoryData(int CategoryID)
        {
            // 1. جلب اسم القسم من قاعدة البيانات أولاً
            // نفترض أن عندك دالة في clsCategory بتجيب الاسم عن طريق الـ ID
            string categoryName = clsCategory.Find(CategoryID)?.CategoryName ?? "قسم غير معروف";
            lblCategoryName.Text = categoryName;

            // 2. تنظيف الحاوية
            flpItemsContainer.Controls.Clear();

            // 3. جلب الأصناف التابعة لهذا الـ ID
            DataTable dtProducts = clsProduct.GetProductsByCategory(CategoryID);

            if (dtProducts != null && dtProducts.Rows.Count > 0)
            {
                foreach (DataRow row in dtProducts.Rows)
                {
                    ctrlProductRow rowControl = new ctrlProductRow();

                    rowControl.SetInfo(
                        row["ProductName"].ToString(),
                        row["Price_S"],
                        row["Price_M"],
                        row["Price_L"],
                        row["Price_XL"]
                    );


                    flpItemsContainer.Controls.Add(rowControl);
                }
            }
        }
    }
}