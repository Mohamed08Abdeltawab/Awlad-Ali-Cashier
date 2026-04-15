using AwladAli_Buisness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AwladAli.Product
{
    public partial class ctrlCategoryCard : UserControl
    {
        public event Action OnOrderChanged;

        public ctrlCategoryCard()
        {
            InitializeComponent();
        }

        public void LoadCategoryData(int CategoryID)
        {
            // 1. جلب اسم القسم
            string categoryName = clsCategory.Find(CategoryID)?.CategoryName ?? "قسم غير معروف";
            lblCategoryName.Text = categoryName;

            // 2. تنظيف الحاوية
            flpItemsContainer.Controls.Clear();

            // 3. جلب الأصناف التابعة لهذا القسم
            DataTable dtProducts = clsProduct.GetProductsByCategory(CategoryID);

            if (dtProducts != null && dtProducts.Rows.Count > 0)
            {
                foreach (DataRow row in dtProducts.Rows)
                {
                    ctrlProductRow rowControl = new ctrlProductRow();

                    // هنا التعديل: بنمرر الـ IDs والأسعار مع بعض
                    // تأكد أن أسماء الأعمدة (SizeID_S, SizeID_M, إلخ) تطابق ما يخرج من الـ Database Query عندك
                    rowControl.SetInfo(
                        Convert.ToInt32(row["ProductID"]),
                        row["ProductName"].ToString(),

                        // Size S
                        row["SizeID_S"] != DBNull.Value ? Convert.ToInt32(row["SizeID_S"]) : -1,
                        row["Price_S"],

                        // Size M
                        row["SizeID_M"] != DBNull.Value ? Convert.ToInt32(row["SizeID_M"]) : -1,
                        row["Price_M"],

                        // Size L
                        row["SizeID_L"] != DBNull.Value ? Convert.ToInt32(row["SizeID_L"]) : -1,
                        row["Price_L"],

                        // Size XL
                        row["SizeID_XL"] != DBNull.Value ? Convert.ToInt32(row["SizeID_XL"]) : -1,
                        row["Price_XL"]
);

                    rowControl.OnPriceChanged += () => OnOrderChanged?.Invoke();
                    flpItemsContainer.Controls.Add(rowControl);
                }
            }
        }

        public decimal GetCategoryTotal()
        {
            decimal total = 0;
            foreach (Control ctrl in flpItemsContainer.Controls)
            {
                if (ctrl is ctrlProductRow row)
                    total += row.GetRowTotal();
            }
            return total;
        }

        public List<clsOrderDetail> GetSelectedItems(int OrderID)
        {
            List<clsOrderDetail> allSelectedItems = new List<clsOrderDetail>();

            foreach (Control ctrl in flpItemsContainer.Controls)
            {
                if (ctrl is ctrlProductRow row)
                {
                    // استدعاء الدالة اللي عملناها في ctrlProductRow لاستخراج كل الأحجام المختارة
                    allSelectedItems.AddRange(row.GetSelectedDetails(OrderID));
                }
            }

            return allSelectedItems;
        }
    }
}