using System;
using System.Data;
using System.Data.SQLite;

namespace AwladAli_Data
{
    public class clsSessionData
    {
        public static bool GetSessionInfoByID(int SessionID, ref int UserID, ref DateTime StartTime,
                                      ref object EndTime, ref decimal TotalCash, ref bool IsActive)
        {
            bool isFound = false;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Sessions WHERE SessionID = @SessionID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SessionID", SessionID);
                        connection.Open();

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                isFound = true;

                                UserID = Convert.ToInt32(reader["UserID"]);
                                StartTime = Convert.ToDateTime(reader["StartTime"]);

                                // EndTime might be NULL if the session is still active
                                EndTime = (reader["EndTime"] == DBNull.Value) ? null : reader["EndTime"];

                                TotalCash = Convert.ToDecimal(reader["TotalCash"]);
                                IsActive = Convert.ToBoolean(reader["IsActive"]);
                            }
                        }
                    }
                }
            }
            catch (Exception) { isFound = false; }

            return isFound;
        }

        // 1. إضافة جلسة جديدة (فقط UserID و StartTime)
        public static int AddNewSession(int UserID, DateTime StartTime)
        {
            int SessionID = -1;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    // الحقول بناءً على جدولك الجديد: UserID, StartTime والـ Default بتاع IsActive هو 1
                    string query = @"INSERT INTO Sessions (UserID, StartTime, IsActive, TotalCash) 
                                     VALUES (@UserID, @StartTime, 1, 0);
                                     SELECT last_insert_rowid();";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@StartTime", StartTime);

                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int id))
                        {
                            SessionID = id;
                        }
                    }
                }
            }
            catch (Exception) { SessionID = -1; }
            return SessionID;
        }

        // 2. إنهاء الجلسة (تحديث EndTime و TotalCash وإغلاق الحالة)
        public static bool EndSession(int SessionID, DateTime EndTime, decimal TotalCash)
        {
            int rowsAffected = 0;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"UPDATE Sessions 
                                     SET EndTime = @EndTime, 
                                         TotalCash = @TotalCash, 
                                         IsActive = 0 
                                     WHERE SessionID = @SessionID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SessionID", SessionID);
                        command.Parameters.AddWithValue("@EndTime", EndTime);
                        command.Parameters.AddWithValue("@TotalCash", TotalCash);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception) { return false; }
            return (rowsAffected > 0);
        }

        // 3. حساب إجمالي مبيعات الجلسة من جدول الطلبات
        public static decimal GetTotalSalesBySessionID(int SessionID)
        {
            decimal TotalSales = 0;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT SUM(TotalAmount) FROM Orders WHERE SessionID = @SessionID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SessionID", SessionID);
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && decimal.TryParse(result.ToString(), out decimal sum))
                        {
                            TotalSales = sum;
                        }
                    }
                }
            }
            catch (Exception) { TotalSales = 0; }
            return TotalSales;
        }

        // 4. دالة طوارئ: إغلاق أي جلسة مفتوحة للمستخدم (تستدعى عند فتح البرنامج)
        // دي عشان لو النور قطع والبرنامج فتح تاني، يصفر الجلسة القديمة قبل ما يبدأ جديدة
        public static bool CloseAnyActiveSession()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    // أي جلسة IsActive فيها بـ 1 هنخليها 0 ونضع وقت النهاية "الآن"
                    string query = @"UPDATE Sessions 
                                     SET IsActive = 0, EndTime = @EndTime 
                                     WHERE IsActive = 1";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EndTime", DateTime.Now);
                        connection.Open();
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch { return false; }
        }


        public static DataTable GetAllSessions()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    // JOIN بجلب اسم المستخدم من جدول Users لظهوره في الجريد
                    string query = @"SELECT Sessions.SessionID, 
                                     Users.UserName, 
                                     (SELECT COUNT(*) FROM Orders WHERE Orders.SessionID = Sessions.SessionID) AS OrdersCount,
                                     Sessions.StartTime, 
                                     Sessions.EndTime, 
                                     Sessions.TotalCash, 
                                     CASE WHEN Sessions.IsActive = 1 THEN 'نشطة' ELSE 'مغلقة' END AS IsActive
                              FROM Sessions 
                              INNER JOIN Users ON Sessions.UserID = Users.UserID
                              ORDER BY Sessions.SessionID DESC";

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
            catch (Exception) { /* Handle Exception */ }
            return dt;
        }
    }
}