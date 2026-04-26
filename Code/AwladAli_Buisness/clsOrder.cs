using System;
using System.Data;
using AwladAli_Data;

namespace AwladAli_Buisness
{
    public class clsOrder
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int SessionID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public clsOrder()
        {
            this.OrderID = -1;
            this.UserID = -1;
            SessionID = -1;
            this.OrderDate = DateTime.Now;
            this.TotalAmount = 0;
            Mode = enMode.AddNew;
        }

        private clsOrder(int OrderID, int UserID, int SessionID, DateTime OrderDate, decimal TotalAmount)
        {
            this.OrderID = OrderID;
            this.UserID = UserID;
            this.SessionID = SessionID;
            this.OrderDate = OrderDate;
            this.TotalAmount = TotalAmount;
            Mode = enMode.Update;
        }

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
                    Convert.ToDecimal(row["TotalAmount"])
                );
            }
            return null;
        }

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

        private bool _AddNewOrder()
        {
            this.OrderID = clsOrderData.AddNewOrder(this.UserID, this.SessionID, this.OrderDate, this.TotalAmount);
            return (this.OrderID != -1);
        }

        public static DataTable GetAllOrders()
        {
            return clsOrderData.GetAllOrders();
        }

        public static bool DeleteOrder(int OrderID)
        {
            // نطلب من طبقة البيانات تنفيذ الحذف
            return clsOrderData.DeleteOrder(OrderID);
        }

        public static DataTable GetAllOrdersRelatedBySessionID(int SessionID)
        {
            return clsOrderData.GetAllOrdersRelatedBySessionID(SessionID);
        }

        public static int GetOrdersCountBySessionID(int SessionID)
        {
            return clsOrderData.GetOrdersCountBySessionID(SessionID);
        }

        public static DateTime GetFirstOrderDate()
        {
            return clsOrderData.GetFirstOrderDate();
        }

        public static DataTable GetOrdersWithPagination(int PageNumber, int PageSize)
        {
            return clsOrderData.GetOrdersWithPagination(PageNumber, PageSize);
        }
    }
}