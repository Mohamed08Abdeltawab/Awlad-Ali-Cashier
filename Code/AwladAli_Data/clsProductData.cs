using System;
using System.Data;
using System.Data.SQLite;

namespace AwladAli_Data
{
    public class clsProductData
    {
        // 1. Find Product by ID
        public static bool GetProductByID(int ProductID, ref int CategoryID, ref string ProductName)
        {
            bool isFound = false;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Products WHERE ProductID = @ProductID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductID", ProductID);
                        connection.Open();

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                CategoryID = Convert.ToInt32(reader["CategoryID"]);
                                ProductName = (string)reader["ProductName"];
                            }
                        }
                    }
                }
            }
            catch (Exception) { isFound = false; }

            return isFound;
        }

        // 2. Add New Product
        public static int AddNewProduct(int CategoryID, string ProductName)
        {
            int ProductID = -1;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"INSERT INTO Products (CategoryID, ProductName) 
                                     VALUES (@CategoryID, @ProductName);
                                     SELECT last_insert_rowid();";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryID", CategoryID);
                        command.Parameters.AddWithValue("@ProductName", ProductName);

                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            ProductID = insertedID;
                        }
                    }
                }
            }
            catch (Exception) { }

            return ProductID;
        }

        // 3. Update Product
        public static bool UpdateProduct(int ProductID, int CategoryID, string ProductName)
        {
            int rowsAffected = 0;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"UPDATE Products 
                                     SET CategoryID = @CategoryID, 
                                         ProductName = @ProductName 
                                     WHERE ProductID = @ProductID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductID", ProductID);
                        command.Parameters.AddWithValue("@CategoryID", CategoryID);
                        command.Parameters.AddWithValue("@ProductName", ProductName);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception) { return false; }

            return (rowsAffected > 0);
        }

        // 4. Delete Product
        public static bool DeleteProduct(int ProductID)
        {
            int rowsAffected = 0;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    // استخدام Transaction لضمان مسح الأحجام والمنتج كعملية واحدة
                    using (var transaction = connection.BeginTransaction())
                    {
                        // 1. مسح الأحجام المرتبطة بالمنتج أولاً (Child Table)
                        string deleteSizesQuery = "DELETE FROM ProductSizes WHERE ProductID = @ProductID";
                        using (SQLiteCommand cmdSizes = new SQLiteCommand(deleteSizesQuery, connection, transaction))
                        {
                            cmdSizes.Parameters.AddWithValue("@ProductID", ProductID);
                            cmdSizes.ExecuteNonQuery();
                        }

                        // 2. مسح المنتج نفسه (Parent Table)
                        string deleteProductQuery = "DELETE FROM Products WHERE ProductID = @ProductID";
                        using (SQLiteCommand cmdProduct = new SQLiteCommand(deleteProductQuery, connection, transaction))
                        {
                            cmdProduct.Parameters.AddWithValue("@ProductID", ProductID);
                            rowsAffected = cmdProduct.ExecuteNonQuery();
                        }

                        // تأكيد تنفيذ العمليتين
                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                // English comment: Log your error using clsGlobal.LogException(ex.Message, ...)
                return false;
            }

            return (rowsAffected > 0);
        }

        // 5. Get All Products (Joining with Category Name for better UI display)
        public static DataTable GetAllProducts()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    // We join with Categories to show the Name instead of just ID in the Grid
                    string query = @"SELECT Products.ProductID, Products.ProductName, Categories.CategoryName 
                                     FROM Products 
                                     INNER JOIN Categories ON Products.CategoryID = Categories.CategoryID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        connection.Open();
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows) dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception) { }

            return dt;
        }



        public static DataTable GetProductsByCategoryWithPrices(int CategoryID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    // Query Pivot مطورة لجلب الأكلة، أسعارها، وحالة "الحجم العادي"
                    string query = @"
                                    SELECT 
                                        p.ProductID, 
                                        p.ProductName,
                                        MAX(CASE WHEN ps.SizeName = 'Normal' OR ps.SizeName = 'S' THEN ps.SizeID END) AS SizeID_S,
                                        MAX(CASE WHEN ps.SizeName = 'Normal' OR ps.SizeName = 'S' THEN ps.Price END) AS Price_S,
                                        MAX(CASE WHEN ps.SizeName = 'Normal' OR ps.SizeName = 'S' THEN ps.IsNormalSize END) AS IsNormalSize_S,

                                        MAX(CASE WHEN ps.SizeName = 'M' THEN ps.SizeID END) AS SizeID_M,
                                        MAX(CASE WHEN ps.SizeName = 'M' THEN ps.Price END) AS Price_M,
                                        MAX(CASE WHEN ps.SizeName = 'L' THEN ps.SizeID END) AS SizeID_L,
                                        MAX(CASE WHEN ps.SizeName = 'L' THEN ps.Price END) AS Price_L,
                                        MAX(CASE WHEN ps.SizeName = 'XL' THEN ps.SizeID END) AS SizeID_XL,
                                        MAX(CASE WHEN ps.SizeName = 'XL' THEN ps.Price END) AS Price_XL
                                    FROM Products p
                                    LEFT JOIN ProductSizes ps ON p.ProductID = ps.ProductID
                                    WHERE p.CategoryID = @CategoryID
                                    GROUP BY p.ProductID, p.ProductName;";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryID", CategoryID);
                        connection.Open();

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // تسجيل الخطأ بشكل احترافي
                // clsErrorHandler.Log(ex); 
                Console.WriteLine("Error: " + ex.Message);
            }

            return dt;
        }


        public static DataTable GetAllProductsByCategory(int CategoryID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    // Query مطورة لسحب الأسعار مع حالة "الحجم العادي"
                    string query = @"
                                    SELECT 
                                        P.ProductID, 
                                        P.ProductName,
                                        IFNULL(S.Price, 0) AS Small,
                                        IFNULL(S.IsNormalSize, 0) AS IsNormalSize, 
                                        IFNULL(M.Price, 0) AS Medium,
                                        IFNULL(L.Price, 0) AS Large,
                                        IFNULL(XL.Price, 0) AS XLarge
                                    FROM Products P
                                    LEFT JOIN ProductSizes S ON P.ProductID = S.ProductID AND (S.SizeName = 'S' OR S.SizeName = 'Normal')
                                    LEFT JOIN ProductSizes M ON P.ProductID = M.ProductID AND M.SizeName = 'M'
                                    LEFT JOIN ProductSizes L ON P.ProductID = L.ProductID AND L.SizeName = 'L'
                                    LEFT JOIN ProductSizes XL ON P.ProductID = XL.ProductID AND XL.SizeName = 'XL'
                                    WHERE P.CategoryID = @CategoryID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryID", CategoryID);
                        connection.Open();

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // يفضل دائماً تسجيل الخطأ لسهولة التتبع
                Console.WriteLine("Error in GetAllProductsByCategory: " + ex.Message);
            }

            return dt;
        }
    }
}
