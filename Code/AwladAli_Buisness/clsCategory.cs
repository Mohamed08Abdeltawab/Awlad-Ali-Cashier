using System;
using System.Data;
using AwladAli_Data;

namespace AwladAli_Buisness
{
    public class clsCategory
    {
        // Enums to define the mode of the object
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        // Category Properties
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        // Default constructor for AddNew mode
        public clsCategory()
        {
            this.CategoryID = -1;
            this.CategoryName = "";

            Mode = enMode.AddNew;
        }

        // Private constructor for Update mode
        private clsCategory(int CategoryID, string CategoryName)
        {
            this.CategoryID = CategoryID;
            this.CategoryName = CategoryName;

            Mode = enMode.Update;
        }

        // 1. Find Category by ID
        public static clsCategory Find(int CategoryID)
        {
            string CategoryName = "";

            if (clsCategoryData.GetCategoryByID(CategoryID, ref CategoryName))
            {
                return new clsCategory(CategoryID, CategoryName);
            }
            else
            {
                return null;
            }
        }

        // 2. Add New Category (Internal helper)
        private bool _AddNewCategory()
        {
            this.CategoryID = clsCategoryData.AddNewCategory(this.CategoryName);
            return (this.CategoryID != -1);
        }

        // 3. Update Category (Internal helper)
        private bool _UpdateCategory()
        {
            return clsCategoryData.UpdateCategory(this.CategoryID, this.CategoryName);
        }

        // 4. Save Method: Managed logic for Add/Update
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCategory())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateCategory();
            }

            return false;
        }

        // 5. Delete Category (Static)
        public static bool DeleteCategory(int CategoryID)
        {
            // Logic: Refuse deletion if there are products under this category
            if (clsCategoryData.IsCategoryLinkedToProducts(CategoryID))
            {
                // You can also throw a custom exception here to be caught in UI
                return false;
            }

            return clsCategoryData.DeleteCategory(CategoryID);
        }

        // 6. Get All Categories (Static)
        public static DataTable GetAllCategories()
        {
            return clsCategoryData.GetAllCategories();
        }
    }
}