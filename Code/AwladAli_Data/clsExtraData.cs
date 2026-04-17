using System;
using System.Data;
using System.Data.SQLite;

namespace AwladAli_Data
{
    public class clsExtraData
    {
        // 1. Get Extra Info by ID
        public static bool GetExtraByID(int ExtraID, ref string ExtraName, ref decimal Price)
        {
            bool isFound = false;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Extras WHERE ExtraID = @ExtraID";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ExtraID", ExtraID);
                        connection.Open();
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                ExtraName = (string)reader["ExtraName"];
                                Price = Convert.ToDecimal(reader["Price"]);
                            }
                        }
                    }
                }
            }
            catch (Exception) { isFound = false; }
            return isFound;
        }

        // 2. Add New Extra
        public static int AddNewExtra(string ExtraName, decimal Price)
        {
            int ExtraID = -1;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "INSERT INTO Extras (ExtraName, Price) VALUES (@ExtraName, @Price); SELECT last_insert_rowid();";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ExtraName", ExtraName);
                        command.Parameters.AddWithValue("@Price", Price);
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                            ExtraID = insertedID;
                    }
                }
            }
            catch (Exception) { }
            return ExtraID;
        }

        // 3. Update Extra
        public static bool UpdateExtra(int ExtraID, string ExtraName, decimal Price)
        {
            int rowsAffected = 0;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "UPDATE Extras SET ExtraName = @ExtraName, Price = @Price WHERE ExtraID = @ExtraID";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ExtraID", ExtraID);
                        command.Parameters.AddWithValue("@ExtraName", ExtraName);
                        command.Parameters.AddWithValue("@Price", Price);
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception) { return false; }
            return (rowsAffected > 0);
        }

        // 4. Delete Extra
        public static bool DeleteExtra(int ExtraID)
        {
            int rowsAffected = 0;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "DELETE FROM Extras WHERE ExtraID = @ExtraID";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ExtraID", ExtraID);
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception) { }
            return (rowsAffected > 0);
        }

        // 5. Get All Extras
        public static DataTable GetAllExtras()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Extras";
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