using System;
using System.Data;
using System.Data.SQLite;

namespace AwladAli_Data
{
    public class clsProductSizeData
    {
        // 1. Find Size by ID
        public static bool GetSizeByID(int SizeID, ref int ProductID, ref string SizeName, ref double Price)
        {
            bool isFound = false;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM ProductSizes WHERE SizeID = @SizeID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SizeID", SizeID);
                        connection.Open();

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                ProductID = Convert.ToInt32(reader["ProductID"]);
                                SizeName = (string)reader["SizeName"];
                                Price = Convert.ToDouble(reader["Price"]);
                            }
                        }
                    }
                }
            }
            catch (Exception) { isFound = false; }

            return isFound;
        }

        // 2. Add New Size/Price
        public static int AddNewSize(int ProductID, string SizeName, double Price)
        {
            int SizeID = -1;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"INSERT INTO ProductSizes (ProductID, SizeName, Price) 
                                     VALUES (@ProductID, @SizeName, @Price);
                                     SELECT last_insert_rowid();";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductID", ProductID);
                        command.Parameters.AddWithValue("@SizeName", SizeName);
                        command.Parameters.AddWithValue("@Price", Price);

                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            SizeID = insertedID;
                        }
                    }
                }
            }
            catch (Exception) { }

            return SizeID;
        }

        // 3. Update Size/Price
        public static bool UpdateSize(int SizeID, int ProductID, string SizeName, double Price)
        {
            int rowsAffected = 0;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"UPDATE ProductSizes 
                                     SET ProductID = @ProductID, 
                                         SizeName = @SizeName, 
                                         Price = @Price 
                                     WHERE SizeID = @SizeID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SizeID", SizeID);
                        command.Parameters.AddWithValue("@ProductID", ProductID);
                        command.Parameters.AddWithValue("@SizeName", SizeName);
                        command.Parameters.AddWithValue("@Price", Price);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception) { return false; }

            return (rowsAffected > 0);
        }

        // 4. Delete Size
        public static bool DeleteSize(int SizeID)
        {
            int rowsAffected = 0;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "DELETE FROM ProductSizes WHERE SizeID = @SizeID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SizeID", SizeID);
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception) { }

            return (rowsAffected > 0);
        }

        // 5. Get All Sizes for a Specific Product (Very important for UI)
        public static DataTable GetProductSizes(int ProductID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM ProductSizes WHERE ProductID = @ProductID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductID", ProductID);
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