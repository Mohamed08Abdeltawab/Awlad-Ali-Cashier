using System;
using System.Data;
using System.Data.SQLite;

namespace AwladAli_Data
{
    public class clsCategoryData
    {
        // 1. Find Category by ID
        public static bool GetCategoryByID(int CategoryID, ref string CategoryName)
        {
            bool isFound = false;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT CategoryName FROM Categories WHERE CategoryID = @CategoryID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryID", CategoryID);
                        connection.Open();

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                CategoryName = (string)reader["CategoryName"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                isFound = false;
                // Log exception if needed
            }

            return isFound;
        }

        // 2. Add New Category
        public static int AddNewCategory(string CategoryName)
        {
            int CategoryID = -1;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"INSERT INTO Categories (CategoryName) 
                                     VALUES (@CategoryName);
                                     SELECT last_insert_rowid();";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryName", CategoryName);

                        connection.Open();

                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            CategoryID = insertedID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log exception
            }

            return CategoryID;
        }

        // 3. Update Category
        public static bool UpdateCategory(int CategoryID, string CategoryName)
        {
            int rowsAffected = 0;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"UPDATE Categories 
                                     SET CategoryName = @CategoryName 
                                     WHERE CategoryID = @CategoryID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryID", CategoryID);
                        command.Parameters.AddWithValue("@CategoryName", CategoryName);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return (rowsAffected > 0);
        }

        // 4. Delete Category
        public static bool DeleteCategory(int CategoryID)
        {
            int rowsAffected = 0;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "DELETE FROM Categories WHERE CategoryID = @CategoryID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryID", CategoryID);
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log exception
            }

            return (rowsAffected > 0);
        }

        // 5. Get All Categories
        public static DataTable GetAllCategories()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Categories";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
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
                // Log exception
            }

            return dt;
        }


        // Check if Category is linked to any products before deletion
        public static bool IsCategoryLinkedToProducts(int CategoryID)
        {
            bool isLinked = false;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    // We just need to know if at least one product exists
                    string query = "SELECT 1 FROM Products WHERE CategoryID = @CategoryID LIMIT 1";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryID", CategoryID);
                        connection.Open();
                        object result = command.ExecuteScalar();
                        isLinked = (result != null);
                    }
                }
            }
            catch (Exception) { isLinked = true; } // Safety first: if error, assume linked to prevent accidental delete
            return isLinked;
        }
    }
}