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
                    string query = "DELETE FROM Products WHERE ProductID = @ProductID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductID", ProductID);
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception) { }

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
    }
}