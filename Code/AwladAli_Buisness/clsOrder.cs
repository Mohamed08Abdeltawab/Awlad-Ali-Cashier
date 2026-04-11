using System;
using System.Collections.Generic;
using System.Data;
using AwladAli_Data;

namespace AwladAli_Buisness
{
    public class clsOrder
    {
        // Internal class to hold item details before saving
        public class clsOrderItem
        {
            public int ProductID { get; set; }
            public int SizeID { get; set; }
            public int Quantity { get; set; }
            public double UnitPrice { get; set; }
        }

        // Order Properties
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }

        // List to hold order items (The Shopping Cart)
        public List<clsOrderItem> OrderItems = new List<clsOrderItem>();

        public clsOrder()
        {
            this.OrderID = -1;
            this.UserID = -1;
            this.TotalAmount = 0;
        }

        // The Master Save Method
        public bool Save()
        {
            // 1. Save the Main Order first
            this.OrderID = clsOrderData.AddNewOrder(this.UserID, this.TotalAmount);

            if (this.OrderID == -1) return false;

            // 2. Save each item in the OrderItems list
            foreach (var item in OrderItems)
            {
                if (!clsOrderData.AddOrderDetail(this.OrderID, item.ProductID, item.SizeID, item.Quantity, item.UnitPrice))
                {
                    // In a real professional system, we would use a "Transaction" here
                    // to rollback if one item fails, but for now this works!
                    return false;
                }
            }

            return true;
        }

        public static DataTable GetAllOrders() => clsOrderData.GetAllOrders();
    }
}