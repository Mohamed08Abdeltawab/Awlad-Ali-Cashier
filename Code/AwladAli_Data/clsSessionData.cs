using System;
using System.Data;
using System.Data.SQLite;

namespace AwladAli_Data
{
    public class clsSessionData
    {
        public static bool GetSessionInfoByID(int SessionID, ref int UserID, ref DateTime StartTime,
                                             ref object EndTime, ref decimal TotalCash, ref bool IsActive, ref int DurationInSeconds)
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
                                isFound = true;

                                UserID = Convert.ToInt32(reader["UserID"]);
                                StartTime = Convert.ToDateTime(reader["StartTime"]);
                                EndTime = (reader["EndTime"] == DBNull.Value) ? null : reader["EndTime"];
                                TotalCash = Convert.ToDecimal(reader["TotalCash"]);
                                IsActive = Convert.ToBoolean(reader["IsActive"]);

                                // 🎯 CRITICAL SYNC: Fetch the cumulative duration count cleanly from the database
                                DurationInSeconds = Convert.ToInt32(reader["DurationInSeconds"]);
                            }
                        }
                    }
                }
            }
            catch (Exception) { isFound = false; }

            return isFound;
        }

        public static int AddNewSession(int UserID, DateTime StartTime)
        {
            int SessionID = -1;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    // 🎯 CRITICAL SYNC: Initialize DurationInSeconds explicitly to 0 on new row entries
                    string query = @"INSERT INTO Sessions (UserID, StartTime, IsActive, TotalCash, DurationInSeconds) 
                                     VALUES (@UserID, @StartTime, 1, 0, 0);
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

        // 🎯 CRITICAL SYNC: Overloaded Update method to persist live counter ticks tracking smoothly
        public static bool EndSession(int SessionID, DateTime EndTime, decimal TotalCash, int DurationInSeconds)
        {
            int rowsAffected = 0;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"UPDATE Sessions 
                                     SET EndTime = @EndTime, 
                                         TotalCash = @TotalCash, 
                                         IsActive = 0,
                                         DurationInSeconds = @DurationInSeconds
                                     WHERE SessionID = @SessionID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SessionID", SessionID);
                        command.Parameters.AddWithValue("@EndTime", EndTime);
                        command.Parameters.AddWithValue("@TotalCash", TotalCash);
                        command.Parameters.AddWithValue("@DurationInSeconds", DurationInSeconds);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception) { return false; }
            return (rowsAffected > 0);
        }

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

        public static bool CloseAnyActiveSession()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
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
            catch (Exception) { }
            return dt;
        }

        public static DataTable GetSessionsWithPagination(int PageNumber, int PageSize)
        {
            DataTable dt = new DataTable();
            int offset = (PageNumber - 1) * PageSize;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT Sessions.SessionID, 
                                            Users.UserName, 
                                            (SELECT COUNT(*) FROM Orders WHERE Orders.SessionID = Sessions.SessionID) AS OrdersCount,
                                            Sessions.StartTime, 
                                            Sessions.EndTime, 
                                            Sessions.TotalCash, 
                                            CASE WHEN Sessions.IsActive = 1 THEN 'نشطة' ELSE 'مغلقة' END AS IsActive
                                     FROM Sessions 
                                     INNER JOIN Users ON Sessions.UserID = Users.UserID
                                     ORDER BY Sessions.SessionID DESC
                                     LIMIT @PageSize OFFSET @Offset";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PageSize", PageSize);
                        command.Parameters.AddWithValue("@Offset", offset);

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

        public static bool GetAnyActiveSessionWithUserInfo(ref int sessionID, ref int userID, ref DateTime startTime, ref decimal totalCash, ref bool isActive, ref int durationInSeconds)
        {
            bool isFound = false;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    // 🎯 CRITICAL SYNC: Added S.DurationInSeconds field mapping validation
                    string selectQuery = @"SELECT S.SessionID, S.UserID, S.StartTime, S.TotalCash, S.IsActive, S.DurationInSeconds
                                           FROM Sessions S
                                           WHERE S.EndTime IS NULL AND S.IsActive = 1 
                                           ORDER BY S.SessionID DESC LIMIT 1;";

                    using (SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, connection))
                    {
                        using (SQLiteDataReader reader = selectCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                sessionID = Convert.ToInt32(reader["SessionID"]);
                                userID = Convert.ToInt32(reader["UserID"]);
                                startTime = Convert.ToDateTime(reader["StartTime"]);
                                totalCash = Convert.ToDecimal(reader["TotalCash"]);
                                isActive = Convert.ToInt32(reader["IsActive"]) == 1;
                                durationInSeconds = Convert.ToInt32(reader["DurationInSeconds"]);
                            }
                        }
                    }

                    if (isFound)
                    {
                        string cleanUpQuery = @"UPDATE Sessions 
                                                SET EndTime = @EndTime, IsActive = 0 
                                                WHERE EndTime IS NULL AND IsActive = 1 AND SessionID != @CurrentSessionID;";

                        using (SQLiteCommand cleanUpCommand = new SQLiteCommand(cleanUpQuery, connection))
                        {
                            cleanUpCommand.Parameters.AddWithValue("@CurrentSessionID", sessionID);
                            cleanUpCommand.Parameters.AddWithValue("@EndTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                            cleanUpCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception) { isFound = false; }
            return isFound;
        }
    }
}