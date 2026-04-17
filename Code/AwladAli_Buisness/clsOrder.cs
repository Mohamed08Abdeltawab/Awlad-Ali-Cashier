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
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public clsOrder()
        {
            this.OrderID = -1;
            this.UserID = -1;
            this.OrderDate = DateTime.Now;
            this.TotalAmount = 0;
            Mode = enMode.AddNew;
        }

        private clsOrder(int OrderID, int UserID, DateTime OrderDate, decimal TotalAmount)
        {
            this.OrderID = OrderID;
            this.UserID = UserID;
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
            this.OrderID = clsOrderData.AddNewOrder(this.UserID, this.OrderDate, this.TotalAmount);
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
    }
}