using System;
using System.Data;
using System.Data.SQLite;

namespace AwladAli_Data
{
    public class clsOrderDetailData
    {
        public static int AddNewOrderDetail(int OrderID, int? ProductID, int? SizeID, int Quantity, decimal UnitPrice)
        {
            int DetailID = -1;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    // Insert order details and retrieve the last inserted row ID
                    string query = @"INSERT INTO OrderDetails (OrderID, ProductID, SizeID, Quantity, UnitPrice) 
                                     VALUES (@OrderID, @ProductID, @SizeID, @Quantity, @UnitPrice);
                                     SELECT last_insert_rowid();";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OrderID", OrderID);
                        // Using DBNull if IDs are null (for Extras)
                        command.Parameters.AddWithValue("@ProductID", (object)ProductID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SizeID", (object)SizeID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Quantity", Quantity);
                        command.Parameters.AddWithValue("@UnitPrice", UnitPrice);

                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            DetailID = insertedID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log exception if necessary
            }

            return DetailID;
        }

        public static DataTable GetOrderDetailsByOrderID(int OrderID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM OrderDetails WHERE OrderID = @OrderID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OrderID", OrderID);
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex) { }

            return dt;
        }
    }
}