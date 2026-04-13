using AwladAli_Buisness;
using System;
using System.Windows.Forms;

namespace AwladAli.Bill
{
    public partial class ctrlOrderLine : UserControl
    {
        private int _OrderDetailsID; 
        clsOrder _Order;
        public ctrlOrderLine()
        {
            InitializeComponent();
        }

        // دالة لتحميل بيانات السطر في الفاتورة
        // سنمرر لها اسم المنتج، الكمية، وسعر الوحدة
        public void LoadData(string productName, short quantity, decimal unitPrice)
        {
            lblProductName.Text = productName;
            lblQuantity.Text = quantity.ToString(); // الكمية
            lblPriceFor1.Text = unitPrice.ToString("0.00"); // سعر الواحد

            // حساب الإجمالي للسطر (الكمية * سعر الوحدة)
            decimal totalLinePrice = quantity * unitPrice;
            lblPriceForQuantity.Text = totalLinePrice.ToString("0.00"); // السعر الإجمالي
        }

        // خاصية للحصول على إجمالي السطر لو احتجت تجمعهم برمجياً في شاشة الفاتورة
        public decimal TotalLinePrice
        {
            get
            {
                decimal price;
                return decimal.TryParse(lblPriceForQuantity.Text, out price) ? price : 0;
            }
        }
    }
}