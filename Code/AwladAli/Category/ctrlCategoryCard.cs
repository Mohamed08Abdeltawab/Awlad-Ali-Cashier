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

                    // التعديل: تمرير قيمة IsNormalSize_S (التي تعبر عن أن المنتج ذو سعر ثابت)
                    // نفترض أن الـ DataTable تحتوي على عمود يحدد هل المقاس S هو المقاس العادي
                    bool isNormalSize = row["IsNormalSize_S"] != DBNull.Value && Convert.ToBoolean(row["IsNormalSize_S"]);

                    rowControl.SetInfo(
                        Convert.ToInt32(row["ProductID"]),
                        row["ProductName"].ToString(),

                        // Size S (أو Normal Size)
                        row["SizeID_S"] != DBNull.Value ? Convert.ToInt32(row["SizeID_S"]) : -1,
                        row["Price_S"],
                        isNormalSize, // الباراميتر الجديد اللي ضفناه في ctrlProductRow

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
                    allSelectedItems.AddRange(row.GetSelectedDetails(OrderID));
                }
            }

            return allSelectedItems;
        }

        // دالة إضافية لتصفير كل المنتجات في القسم (مثلاً بعد إتمام الطلب)
        public void ResetAllRows()
        {
            foreach (Control ctrl in flpItemsContainer.Controls)
            {
                if (ctrl is ctrlProductRow row)
                    row.Reset();
            }
        }
    }
}