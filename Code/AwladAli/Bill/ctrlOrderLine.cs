using AwladAli_Buisness;
using System;
using System.Windows.Forms;

namespace AwladAli.Bill
{
    public partial class ctrlOrderLine : UserControl
    {
        private int _OrderDetailID = -1;
        private clsOrderDetail _OrderDetail;

        public ctrlOrderLine()
        {
            InitializeComponent();
        }

        public int OrderDetailID => _OrderDetailID;

        // Load data using only the OrderDetailID from Database
        public void LoadData(int OrderDetailID)
        {
            _OrderDetailID = OrderDetailID;
            _OrderDetail = clsOrderDetail.Find(_OrderDetailID);

            if (_OrderDetail != null)
            {
                _FillDataToLabels();
            }
        }

        private void _FillDataToLabels()
        {
            string finalDisplayName = "";

            // Case 1: The item is a Main Product
            if (_OrderDetail.ProductID != null)
            {
                clsProduct product = clsProduct.Find((int)_OrderDetail.ProductID);
                finalDisplayName = (product != null) ? product.ProductName : "Unknown Product";

                // Append size if exists (e.g., Burger (Large))
                if (_OrderDetail.SizeID != null)
                {
                    clsProductSize size = clsProductSize.Find((int)_OrderDetail.SizeID);
                    if (size != null)
                    {
                        if(size.SizeName == "Normal")
                        {
                            size.SizeName = ""; // Don't show "Normal" size in the display name
                        }
                        finalDisplayName =$"{size.SizeName} " + finalDisplayName;
                    }
                }
            }
            // Case 2: The item is an Extra (Addition)
            else if (_OrderDetail.ExtraID != null)
            {
                clsExtra extra = clsExtra.Find((int)_OrderDetail.ExtraID);
                finalDisplayName = (extra != null) ? extra.ExtraName : "Unknown Extra";
            }
            else
            {
                finalDisplayName = "Miscellaneous Item";
            }

            // Display gathered information to UI Labels
            lblProductName.Text = finalDisplayName;
            lblQuantity.Text = _OrderDetail.Quantity.ToString();
            lblPriceFor1.Text = _OrderDetail.UnitPrice.ToString("0.00");

            // Total price for this line
            decimal totalLinePrice = _OrderDetail.Quantity * _OrderDetail.UnitPrice;
            lblPriceForQuantity.Text = totalLinePrice.ToString("0.00");
        }

        // Property to get the numeric total of this row
        public decimal TotalLinePrice
        {
            get
            {
                return (_OrderDetail != null) ? (_OrderDetail.Quantity * _OrderDetail.UnitPrice) : 0;
            }
        }

    }
}