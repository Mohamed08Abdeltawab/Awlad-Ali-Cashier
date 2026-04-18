using System;
using System.Data;
using AwladAli_Data;

namespace AwladAli_Buisness
{
    public class clsProductSize
    {
        public int SizeID { get; set; }
        public int ProductID { get; set; }
        public string SizeName { get; set; }
        public decimal Price { get; set; }
        // الخاصية الجديدة
        public bool IsNormalSize { get; set; }

        public clsProduct ProductInfo;

        public clsProductSize()
        {
            this.SizeID = -1;
            this.ProductID = -1;
            this.SizeName = "";
            this.Price = 0.0m;
            this.IsNormalSize = false;
        }

        private clsProductSize(int SizeID, int ProductID, string SizeName, decimal Price, bool IsNormalSize)
        {
            this.SizeID = SizeID;
            this.ProductID = ProductID;
            this.SizeName = SizeName;
            this.Price = Price;
            this.IsNormalSize = IsNormalSize;

            this.ProductInfo = clsProduct.Find(ProductID);
        }

        public static clsProductSize Find(int SizeID)
        {
            int ProductID = -1;
            string SizeName = "";
            decimal Price = 0.0m;
            bool IsNormalSize = false;

            if (clsProductSizeData.GetSizeByID(SizeID, ref ProductID, ref SizeName, ref Price, ref IsNormalSize))
            {
                return new clsProductSize(SizeID, ProductID, SizeName, Price, IsNormalSize);
            }
            return null;
        }

        private bool _AddNewSize()
        {
            this.SizeID = clsProductSizeData.AddNewSize(this.ProductID, this.SizeName, this.Price, this.IsNormalSize);
            return (this.SizeID != -1);
        }



        public bool Save()
        {
            if (_AddNewSize())
            {
                return true;
            }
            return false;
        }

        public static bool DeleteSize(int SizeID)
        {
            return clsProductSizeData.DeleteSize(SizeID);
        }

        public static DataTable GetProductSizes(int ProductID)
        {
            return clsProductSizeData.GetProductSizes(ProductID);
        }

        public static DataTable GetPricesByProductID(int ProductID)
        {
            return clsProductSizeData.GetPricesByProductID(ProductID);
        }

        // التحديث الهام للدالة اللي بتستخدمها في شاشة الإضافة والتعديل
        public static bool UpdateProductPrices(int ProductID, bool IsNormalSize, string PriceNormal, string S, string M, string L, string XL)
        {
            return clsProductSizeData.UpdateProductPrices(ProductID, IsNormalSize, PriceNormal, S, M, L, XL);
        }
    }
}