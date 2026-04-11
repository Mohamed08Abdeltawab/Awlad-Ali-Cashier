using System;
using System.Data;
using AwladAli_Data;

namespace AwladAli_Buisness
{
    public class clsProductSize
    {
        // Enums to define the mode of the object
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        // ProductSize Properties
        public int SizeID { get; set; }
        public int ProductID { get; set; }
        public string SizeName { get; set; }
        public double Price { get; set; }

        // Navigation Property: To get the parent Product details if needed
        public clsProduct ProductInfo;

        // Default constructor for AddNew mode
        public clsProductSize()
        {
            this.SizeID = -1;
            this.ProductID = -1;
            this.SizeName = "";
            this.Price = 0.0;

            Mode = enMode.AddNew;
        }

        // Private constructor for Update mode
        private clsProductSize(int SizeID, int ProductID, string SizeName, double Price)
        {
            this.SizeID = SizeID;
            this.ProductID = ProductID;
            this.SizeName = SizeName;
            this.Price = Price;

            // Optional: Load parent product info
            this.ProductInfo = clsProduct.Find(ProductID);

            Mode = enMode.Update;
        }

        // 1. Find Size by ID
        public static clsProductSize Find(int SizeID)
        {
            int ProductID = -1;
            string SizeName = "";
            double Price = 0.0;

            if (clsProductSizeData.GetSizeByID(SizeID, ref ProductID, ref SizeName, ref Price))
            {
                return new clsProductSize(SizeID, ProductID, SizeName, Price);
            }
            else
            {
                return null;
            }
        }

        // 2. Add New Size (Internal helper)
        private bool _AddNewSize()
        {
            this.SizeID = clsProductSizeData.AddNewSize(this.ProductID, this.SizeName, this.Price);
            return (this.SizeID != -1);
        }

        // 3. Update Size (Internal helper)
        private bool _UpdateSize()
        {
            return clsProductSizeData.UpdateSize(this.SizeID, this.ProductID, this.SizeName, this.Price);
        }

        // 4. Save Method
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewSize())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateSize();
            }

            return false;
        }

        // 5. Delete Size (Static)
        public static bool DeleteSize(int SizeID)
        {
            return clsProductSizeData.DeleteSize(SizeID);
        }

        // 6. Get All Sizes for a specific product (Static)
        // This is the most used method in the Cashier screen
        public static DataTable GetProductSizes(int ProductID)
        {
            return clsProductSizeData.GetProductSizes(ProductID);
        }
    }
}