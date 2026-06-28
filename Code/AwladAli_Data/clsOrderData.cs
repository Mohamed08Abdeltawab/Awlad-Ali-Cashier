using System;
using System.Data;
using System.Data.SQLite;

namespace AwladAli_Data
{
    public class clsOrderData
    {
        // 1. الميثود المحدثة لإضافة أوردر جديد بالأعمدة الجديدة
        public static int AddNewOrder(int UserID, int SessionID, DateTime OrderDate, decimal TotalAmount, int OrderType, int? CustomerID, decimal DeliveryFee)
        {
            int OrderID = -1;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    // Added OrderType, CustomerID, and DeliveryFee to the INSERT command
                    string query = @"INSERT INTO Orders (UserID, SessionID, OrderDate, TotalAmount, OrderType, CustomerID, DeliveryFee) 
                                     VALUES (@UserID, @SessionID, @OrderDate, @TotalAmount, @OrderType, @CustomerID, @DeliveryFee);
                                     SELECT last_insert_rowid();";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@SessionID", SessionID);
                        command.Parameters.AddWithValue("@OrderDate", OrderDate);
                        command.Parameters.AddWithValue("@TotalAmount", TotalAmount);
                        command.Parameters.AddWithValue("@OrderType", OrderType);

                        // Handle Nullable CustomerID safely (if Takeaway, it saves DBNull.Value)
                        command.Parameters.AddWithValue("@CustomerID", CustomerID.HasValue ? (object)CustomerID.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@DeliveryFee", DeliveryFee);

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

        // 2. تحديث كويري جلب الكل لتعود البيانات الجديدة مرتبة وشاملة التحديثات
        public static DataTable GetAllOrders()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    // Select all columns to ensure new features appear in the general grid
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

        // 3. تحديث ميثود الـ Pagination لتشمل كافة الأعمدة الجديدة في شاشات العرض الكبيرة
        public static DataTable GetOrdersWithPagination(int PageNumber, int PageSize)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    int offset = (PageNumber - 1) * PageSize;

                    string query = @"SELECT * FROM Orders 
                                     ORDER BY OrderDate DESC 
                                     LIMIT @PageSize OFFSET @Offset";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PageSize", PageSize);
                        command.Parameters.AddWithValue("@Offset", offset);

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

        // 4. تحديث جلب الأوردرات تلو الـ Session ليشمل البيانات الإضافية للتأكد من حسابات الطيارين والـ وردية
        public static DataTable GetAllOrdersRelatedBySessionID(int SessionID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    // Added OrderType, CustomerID, and DeliveryFee for accurate financial reporting per session
                    string query = @"SELECT SessionID, OrderID, OrderDate, TotalAmount, OrderType, CustomerID, DeliveryFee 
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
            catch (Exception) { }
            return dt;
        }

        // 5. تحديث الـ Pagination التابع للوردية (Sessions) ليعرض الفواتير بأنواعها ومصاريف شحنها دقيقة
        public static DataTable GetOrdersRelatedBySessionIDWithPagination(int SessionID, int PageNumber, int PageSize)
        {
            DataTable dt = new DataTable();
            int offset = (PageNumber - 1) * PageSize;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    // Added OrderType, CustomerID, and DeliveryFee to block query
                    string query = @"SELECT SessionID, OrderID, OrderDate, TotalAmount, OrderType, CustomerID, DeliveryFee 
                                     FROM Orders 
                                     WHERE SessionID = @SessionID 
                                     ORDER BY OrderDate DESC
                                     LIMIT @PageSize OFFSET @Offset";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SessionID", SessionID);
                        command.Parameters.AddWithValue("@PageSize", PageSize);
                        command.Parameters.AddWithValue("@Offset", offset);

                        connection.Open();

                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception) { }
            return dt;
        }

        public static int GetOrdersCountBySessionID(int SessionID)
        {
            int Count = 0;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
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

        public static DateTime GetFirstOrderDate()
        {
            DateTime FirstDate = DateTime.Now;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT MIN(OrderDate) FROM Orders";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            FirstDate = Convert.ToDateTime(result);
                        }
                    }
                }
            }
            catch (Exception) { }

            return FirstDate;
        }
    }
}