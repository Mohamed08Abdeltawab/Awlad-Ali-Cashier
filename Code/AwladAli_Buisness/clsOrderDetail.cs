using System;
using System.Data;
using AwladAli_Data;

namespace AwladAli_Buisness
{
    public class clsOrderDetail
    {
        // Enum to manage data state
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int DetailID { get; set; }
        public int OrderID { get; set; }
        public int? ProductID { get; set; }
        public int? SizeID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int? ExtraID { get; set; } // Added to support Extras as independent items

        // Default Constructor for creating new records
        public clsOrderDetail()
        {
            this.DetailID = -1;
            this.OrderID = -1;
            this.ProductID = null;
            this.SizeID = null;
            this.Quantity = 0;
            this.UnitPrice = 0;
            this.ExtraID = null;
            Mode = enMode.AddNew;
        }

        // Private Constructor for internal use (loading from DB)
        private clsOrderDetail(int DetailID, int OrderID, int? ProductID, int? SizeID, int Quantity, decimal UnitPrice, int? ExtraID)
        {
            this.DetailID = DetailID;
            this.OrderID = OrderID;
            this.ProductID = ProductID;
            this.SizeID = SizeID;
            this.Quantity = Quantity;
            this.UnitPrice = UnitPrice;
            this.ExtraID = ExtraID;
            Mode = enMode.Update;
        }

        // Add a new detail record to the database
        private bool _AddNewOrderDetail()
        {
            // Now passing ExtraID to the DataAccess layer
            this.DetailID = clsOrderDetailData.AddNewOrderDetail(this.OrderID, this.ProductID, this.SizeID, this.Quantity, this.UnitPrice, this.ExtraID);
            return (this.DetailID != -1);
        }

        // Placeholder for Update logic if needed in the future
        private bool _UpdateOrderDetail()
        {
            // Implementation can be added here if you decide to allow editing saved orders
            return false;
        }

        // Finds a record and returns an object of this class
        public static clsOrderDetail Find(int DetailID)
        {
            DataRow row = clsOrderDetailData.GetOrderDetailByID(DetailID);

            if (row != null)
            {
                return new clsOrderDetail(
                    Convert.ToInt32(row["DetailID"]),
                    Convert.ToInt32(row["OrderID"]),
                    row["ProductID"] != DBNull.Value ? (int?)Convert.ToInt32(row["ProductID"]) : null,
                    row["SizeID"] != DBNull.Value ? (int?)Convert.ToInt32(row["SizeID"]) : null,
                    Convert.ToInt32(row["Quantity"]),
                    Convert.ToDecimal(row["UnitPrice"]),
                    row["ExtraID"] != DBNull.Value ? (int?)Convert.ToInt32(row["ExtraID"]) : null
                );
            }
            return null;
        }

        // Main Save method to handle both Add and Update modes
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
                    return false;

                case enMode.Update:
                    return _UpdateOrderDetail();
            }

            return false;
        }

        public static DataTable GetOrderItems(int OrderID)
        {
            return clsOrderDetailData.GetOrderDetailsByOrderID(OrderID);
        }

        public static DataTable GetOrderItemsForPrinting(int OrderID)
        {
            return clsOrderDetailData.GetOrderItemsForPrinting(OrderID);
        }
    }
}