using System;
using System.Data;
using AwladAli_Data;

namespace AwladAli_Buisness
{
    public class clsOrderDetail
    {
        // Property to distinguish if row is New or Existing
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int DetailID { get; set; }
        public int OrderID { get; set; }
        public int? ProductID { get; set; }
        public int? SizeID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public clsOrderDetail()
        {
            this.DetailID = -1;
            this.OrderID = -1;
            this.ProductID = null;
            this.SizeID = null;
            this.Quantity = 0;
            this.UnitPrice = 0;
            Mode = enMode.AddNew;
        }

        // Logic to save the item to the database
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewOrderDetail())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
            }

            return false;
        }

        private bool _AddNewOrderDetail()
        {
            this.DetailID = clsOrderDetailData.AddNewOrderDetail(this.OrderID, this.ProductID, this.SizeID, this.Quantity, this.UnitPrice);
            return (this.DetailID != -1);
        }

        public static DataTable GetOrderItems(int OrderID)
        {
            return clsOrderDetailData.GetOrderDetailsByOrderID(OrderID);
        }
    }
}