using System;
using System.Data;
using AwladAli_Data;

namespace AwladAli_Buisness
{
    public class clsOrder
    {
        // Object modes to distinguish between inserting a new order or updating an existing one
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        // Enhanced: Fixed spelling to 'Delivery' 
        public enum enOrderType { Takeaway = 1, Delivery = 2 };

        // Properties matching the updated database schema
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int SessionID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        // Smart Change: Use the enum type directly for cleaner UI integration
        public enOrderType OrderType { get; set; }
        public int? CustomerID { get; set; } // Nullable int because Takeaway orders do not require a customer
        public decimal DeliveryFee { get; set; }

        // Default Constructor for creating a new order instance
        public clsOrder()
        {
            this.OrderID = -1;
            this.UserID = -1;
            this.SessionID = -1;
            this.OrderDate = DateTime.Now;
            this.TotalAmount = 0;
            this.OrderType = enOrderType.Takeaway; // Clean and expressive assignment
            this.CustomerID = null; // Takeaway orders store NULL in the database
            this.DeliveryFee = 0;
            Mode = enMode.AddNew;
        }

        // Private Constructor utilized to load and map database rows into object properties
        private clsOrder(int OrderID, int UserID, int SessionID, DateTime OrderDate, decimal TotalAmount, int OrderType, int? CustomerID, decimal DeliveryFee)
        {
            this.OrderID = OrderID;
            this.UserID = UserID;
            this.SessionID = SessionID;
            this.OrderDate = OrderDate;
            this.TotalAmount = TotalAmount;

            // Cast the integer from database safely back to our descriptive Enum
            this.OrderType = (enOrderType)OrderType;
            this.CustomerID = CustomerID;
            this.DeliveryFee = DeliveryFee;
            Mode = enMode.Update;
        }

        // Static method to look up an order by ID and retrieve its full instance
        public static clsOrder Find(int OrderID)
        {
            DataRow row = clsOrderData.GetOrderInfoByID(OrderID);
            if (row != null)
            {
                return new clsOrder(
                    Convert.ToInt32(row["OrderID"]),
                    Convert.ToInt32(row["UserID"]),
                    Convert.ToInt32(row["SessionID"]),
                    Convert.ToDateTime(row["OrderDate"]),
                    Convert.ToDecimal(row["TotalAmount"]),
                    Convert.ToInt32(row["OrderType"]),
                    row["CustomerID"] != DBNull.Value ? (int?)Convert.ToInt32(row["CustomerID"]) : null,
                    Convert.ToDecimal(row["DeliveryFee"])
                );
            }
            return null;
        }

        // Smart Save method to manage data flow to database layer based on object mode
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewOrder())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;
            }
            return false;
        }

        // Internal method to trigger the insertion in Data Access Layer with the new features
        private bool _AddNewOrder()
        {
            // Cast 'OrderType' Enum into (int) right here before passing to the Data Layer
            this.OrderID = clsOrderData.AddNewOrder(
                this.UserID,
                this.SessionID,
                this.OrderDate,
                this.TotalAmount,
                (int)this.OrderType,
                this.CustomerID,
                this.DeliveryFee
            );

            return (this.OrderID != -1);
        }

        // Static method to pull all records from the orders repository
        public static DataTable GetAllOrders()
        {
            return clsOrderData.GetAllOrders();
        }

        // Static method to erase an order with its inner records inside an atomic transaction
        public static bool DeleteOrder(int OrderID)
        {
            return clsOrderData.DeleteOrder(OrderID);
        }

        // Static method to get all invoices linked to a specific financial shift
        public static DataTable GetAllOrdersRelatedBySessionID(int SessionID)
        {
            return clsOrderData.GetAllOrdersRelatedBySessionID(SessionID);
        }

        // Static method to fetch paginated datasets under a single shift window
        public static DataTable GetOrdersRelatedBySessionIDWithPagination(int SessionID, int PageNumber, int PageSize)
        {
            return clsOrderData.GetOrdersRelatedBySessionIDWithPagination(SessionID, PageNumber, PageSize);
        }

        // Static method to pull total counts for specific shift metrics
        public static int GetOrdersCountBySessionID(int SessionID)
        {
            return clsOrderData.GetOrdersCountBySessionID(SessionID);
        }

        // Static method to identify the minimum date log inside the order stream
        public static DateTime GetFirstOrderDate()
        {
            return clsOrderData.GetFirstOrderDate();
        }

        public static bool IsOrderExist(int OrderID)
        {
            return clsOrderData.IsOrderExist(OrderID);
        }
    }
}