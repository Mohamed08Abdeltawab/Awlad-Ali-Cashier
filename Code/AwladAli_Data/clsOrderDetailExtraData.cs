using System;
using System.Data;
using System.Data.SQLite;

namespace AwladAli_Data
{
    public class clsOrderDetailExtraData
    {
        // Add Extra to a specific Order Detail
        public static bool AddExtraToItem(int DetailID, int ExtraID)
        {
            int rowsAffected = 0;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    // Assuming you have a table named OrderDetail_Extras 
                    // with columns (DetailID, ExtraID)
                    string query = "INSERT INTO OrderDetail_Extras (DetailID, ExtraID) VALUES (@DetailID, @ExtraID)";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DetailID", DetailID);
                        command.Parameters.AddWithValue("@ExtraID", ExtraID);
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception) { }
            return (rowsAffected > 0);
        }

        // Get All Extras for a specific item in the order
        public static DataTable GetExtrasByDetailID(int DetailID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT Extras.ExtraName, Extras.Price 
                                     FROM OrderDetail_Extras 
                                     INNER JOIN Extras ON OrderDetail_Extras.ExtraID = Extras.ExtraID 
                                     WHERE OrderDetail_Extras.DetailID = @DetailID";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DetailID", DetailID);
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