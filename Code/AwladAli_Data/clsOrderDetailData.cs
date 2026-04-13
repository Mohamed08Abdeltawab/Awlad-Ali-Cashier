using System;
using System.Data;
using System.Data.SQLite;

namespace AwladAli_Data
{
    public class clsOrderDetailData
    {
        /// <summary>
        /// Adds a new order detail record to the database.
        /// Handles ProductID, SizeID, and ExtraID as nullable fields.
        /// </summary>
        public static int AddNewOrderDetail(int OrderID, int? ProductID, int? SizeID, int Quantity, decimal UnitPrice, int? ExtraID)
        {
            int DetailID = -1;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    // Query to insert detail and get the last generated ID (last_insert_rowid)
                    string query = @"INSERT INTO OrderDetails (OrderID, ProductID, SizeID, Quantity, UnitPrice, ExtraID) 
                                     VALUES (@OrderID, @ProductID, @SizeID, @Quantity, @UnitPrice, @ExtraID);
                                     SELECT last_insert_rowid();";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OrderID", OrderID);

                        // Handling Nullable types for SQLite using DBNull.Value
                        command.Parameters.AddWithValue("@ProductID", (object)ProductID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SizeID", (object)SizeID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ExtraID", (object)ExtraID ?? DBNull.Value);

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
                // Exception logging can be implemented here
            }

            return DetailID;
        }

        /// <summary>
        /// Retrieves all detail lines associated with a specific Order ID.
        /// </summary>
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

        /// <summary>
        /// Retrieves a single record from OrderDetails by its primary key (DetailID).
        /// </summary>
        public static DataRow GetOrderDetailByID(int DetailID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM OrderDetails WHERE DetailID = @DetailID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DetailID", DetailID);
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex) { }

            return (dt.Rows.Count > 0) ? dt.Rows[0] : null;
        }
    }
}