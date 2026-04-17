using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace AwladAli_Data
{
    public class clsOrderData
    {
        public static int AddNewOrder(int UserID, decimal TotalAmount)
        {
            int OrderID = -1;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    // Insert the main order record
                    // OrderDate is handled by the DEFAULT CURRENT_TIMESTAMP in SQLite
                    string query = @"INSERT INTO Orders (UserID, TotalAmount) 
                                     VALUES (@UserID, @TotalAmount);
                                     SELECT last_insert_rowid();";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);
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

            try
            {
                // استخدام Using للـ Connection يضمن إغلاقه تلقائياً
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    // كود الـ SQL بيمسح من التفاصيل أولاً (Child) ثم الأوردر (Parent)
                    string query = @"DELETE FROM OrderDetails WHERE OrderID = @OrderID;
                             DELETE FROM Orders WHERE OrderID = @OrderID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OrderID", OrderID);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // English comment: Log your error here for debugging
                return false;
            }

            // rowsAffected المفروض تكون أكبر من 0 لو تم مسح الأوردر أو تفاصيله
            return (rowsAffected > 0);
        }
    }
}