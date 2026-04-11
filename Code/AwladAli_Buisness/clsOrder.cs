using System;
using System.Collections.Generic;
using System.Data;
using AwladAli_Data;

namespace AwladAli_Buisness
{
    public class clsOrder
    {
        // Internal class to represent an item in the cart
        public class clsOrderItem
        {
            public int ProductID { get; set; }
            public int SizeID { get; set; }
            public int Quantity { get; set; }
            public double UnitPrice { get; set; }

            // List of Extra IDs for this specific item
            public List<int> SelectedExtraIDs = new List<int>();
        }

        // Order Properties
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }

        // The "Shopping Cart" list
        public List<clsOrderItem> Items = new List<clsOrderItem>();

        public clsOrder()
        {
            this.OrderID = -1;
            this.UserID = -1;
            this.TotalAmount = 0;
            this.OrderDate = DateTime.Now;
        }

        // --- Main Operations ---

        // Save Method: This handles the Header, the Details, and the Extras
        public bool Save()
        {
            // 1. Save the Main Order Header
            this.OrderID = clsOrderData.AddNewOrder(this.UserID, this.TotalAmount);

            if (this.OrderID == -1) return false;

            // 2. Loop through each item in the order
            foreach (var item in Items)
            {
                // Save the detail and get its unique DetailID
                int detailID = clsOrderData.AddOrderDetailAndGetID(
                    this.OrderID,
                    item.ProductID,
                    item.SizeID,
                    item.Quantity,
                    item.UnitPrice
                );

                if (detailID == -1) return false;

                // 3. Save Extras for this specific detail (if any)
                foreach (int extraID in item.SelectedExtraIDs)
                {
                    if (!clsOrderDetailExtraData.AddExtraToItem(detailID, extraID))
                    {
                        // In a real system, we would use Transactions to rollback here
                        return false;
                    }
                }
            }

            return true;
        }

        // Static method for reporting
        public static DataTable GetAllOrders()
        {
            return clsOrderData.GetAllOrders();
        }
    }
}