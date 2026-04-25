using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace AwladAli_Data
{
    public class clsOrderData
    {
        public static int AddNewOrder(int UserID, int SessionID, DateTime OrderDate, decimal TotalAmount)
        {
            int OrderID = -1;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    // Insert the main order record
                    // OrderDate is handled by the DEFAULT CURRENT_TIMESTAMP in SQLite
                    string query = @"INSERT INTO Orders (UserID ,OrderDate, TotalAmount,SessionID) 
                                     VALUES (@UserID, @OrderDate, @TotalAmount, @SessionID);
                                     SELECT last_insert_rowid();";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@SessionID", SessionID);
                        command.Parameters.AddWithValue("@OrderDate", OrderDate);
                        command.Parameters.AddWithValue("@TotalAmount", TotalAmount);

                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            OrderID = insertedID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Error handling logic
            }

            return OrderID;
        }

        public static DataRow GetOrderInfoByID(int OrderID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Orders WHERE OrderID = @OrderID";
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

            return (dt.Rows.Count > 0) ? dt.Rows[0] : null;
        }

        public static DataTable GetAllOrders()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Orders ORDER BY OrderDate DESC";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
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


        public static bool DeleteOrder(int OrderID)
        {
            int rowsAffected = 0;
            // ✅ FIX — atomic transaction, same pattern as DeleteProduct
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string deleteDetailsQuery = "DELETE FROM OrderDetails WHERE OrderID = @OrderID";
                        using (var cmd1 = new SQLiteCommand(deleteDetailsQuery, connection, transaction))
                        {
                            cmd1.Parameters.AddWithValue("@OrderID", OrderID);
                            cmd1.ExecuteNonQuery();
                        }

                        string deleteOrderQuery = "DELETE FROM Orders WHERE OrderID = @OrderID";
                        using (var cmd2 = new SQLiteCommand(deleteOrderQuery, connection, transaction))
                        {
                            cmd2.Parameters.AddWithValue("@OrderID", OrderID);
                            rowsAffected = cmd2.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }

            return (rowsAffected > 0);
        }


        public static DataTable GetAllOrdersRelatedBySessionID(int SessionID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    // Query to get SessionID, OrderID, and TotalAmount for a specific session
                    string query = @"SELECT SessionID, OrderID, OrderDate, TotalAmount 
                             FROM Orders 
                             WHERE SessionID = @SessionID 
                             ORDER BY OrderDate DESC";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SessionID", SessionID);
                        connection.Open();

                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Handle exception or log error
            }
            return dt;
        }

        public static int GetOrdersCountBySessionID(int SessionID)
        {
            int Count = 0;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    // نستخدم COUNT(*) لجلب عدد الصفوف فقط (أداء عالي)
                    string query = "SELECT COUNT(*) FROM Orders WHERE SessionID = @SessionID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SessionID", SessionID);
                        connection.Open();

                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int c))
                        {
                            Count = c;
                        }
                    }
                }
            }
            catch (Exception) { Count = 0; }
            return Count;
        }
    }
}