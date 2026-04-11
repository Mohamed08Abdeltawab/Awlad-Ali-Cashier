using System;
using System.Data;
using AwladAli_Data;

namespace AwladAli_Buisness
{
    public class clsProduct
    {
        // Enums to define the mode of the object
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        // Product Properties
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }

        // Navigation Property: To get Category details easily
        public clsCategory CategoryInfo;

        // Default constructor for AddNew mode
        public clsProduct()
        {
            this.ProductID = -1;
            this.CategoryID = -1;
            this.ProductName = "";

            Mode = enMode.AddNew;
        }

        // Private constructor for Update mode
        private clsProduct(int ProductID, int CategoryID, string ProductName)
        {
            this.ProductID = ProductID;
            this.CategoryID = CategoryID;
            this.ProductName = ProductName;

            // Load Category Information
            this.CategoryInfo = clsCategory.Find(CategoryID);

            Mode = enMode.Update;
        }

        // 1. Find Product by ID
        public static clsProduct Find(int ProductID)
        {
            int CategoryID = -1;
            string ProductName = "";

            if (clsProductData.GetProductByID(ProductID, ref CategoryID, ref ProductName))
            {
                return new clsProduct(ProductID, CategoryID, ProductName);
            }
            else
            {
                return null;
            }
        }

        // 2. Add New Product (Internal helper)
        private bool _AddNewProduct()
        {
            this.ProductID = clsProductData.AddNewProduct(this.CategoryID, this.ProductName);
            return (this.ProductID != -1);
        }

        // 3. Update Product (Internal helper)
        private bool _UpdateProduct()
        {
            return clsProductData.UpdateProduct(this.ProductID, this.CategoryID, this.ProductName);
        }

        // 4. Save Method: Routes to Add or Update
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewProduct())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateProduct();
            }

            return false;
        }

        // 5. Delete Product (Static)
        public static bool DeleteProduct(int ProductID)
        {
            return clsProductData.DeleteProduct(ProductID);
        }

        // 6. Get All Products (Static)
        public static DataTable GetAllProducts()
        {
            return clsProductData.GetAllProducts();
        }

        // 7. Check if Category has any Products (Helper for Category Delete logic)
        public static bool DoesCategoryHaveProducts(int CategoryID)
        {
            return clsCategoryData.IsCategoryLinkedToProducts(CategoryID);
        }
    }
}