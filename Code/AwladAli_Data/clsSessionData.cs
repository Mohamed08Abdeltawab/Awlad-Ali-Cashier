using System;
using System.Data;
using System.Data.SQLite;

namespace AwladAli_Data
{
    public class clsSessionData
    {
        // 1. Add New Session
        public static int AddNewSession(int UserID, DateTime StartTime, decimal StartingCash)
        {
            int SessionID = -1;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"INSERT INTO Sessions (UserID, StartTime, StartingCash, IsActive) 
                                     VALUES (@UserID, @StartTime, @StartingCash, 1);
                                     SELECT last_insert_rowid();";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@StartTime", StartTime);
                        command.Parameters.AddWithValue("@StartingCash", StartingCash);

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

        // 2. End Session (Update EndTime and FinalCash)
        public static bool EndSession(int SessionID, DateTime EndTime, decimal FinalCash, string Notes)
        {
            int rowsAffected = 0;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"UPDATE Sessions 
                                     SET EndTime = @EndTime, 
                                         FinalCash = @FinalCash, 
                                         Notes = @Notes, 
                                         IsActive = 0 
                                     WHERE SessionID = @SessionID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SessionID", SessionID);
                        command.Parameters.AddWithValue("@EndTime", EndTime);
                        command.Parameters.AddWithValue("@FinalCash", FinalCash);
                        command.Parameters.AddWithValue("@Notes", Notes);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception) { return false; }
            return (rowsAffected > 0);
        }

        // 3. Get Active Session for User (عشان لو البرنامج قفل وفتح يعرف إن فيه جلسة شغالة)
        public static bool GetActiveSessionByUserID(int UserID, ref int SessionID, ref DateTime StartTime, ref decimal StartingCash)
        {
            bool isFound = false;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Sessions WHERE UserID = @UserID AND IsActive = 1 LIMIT 1";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);
                        connection.Open();
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                SessionID = Convert.ToInt32(reader["SessionID"]);
                                StartTime = Convert.ToDateTime(reader["StartTime"]);
                                StartingCash = Convert.ToDecimal(reader["StartingCash"]);
                            }
                        }
                    }
                }
            }
            catch (Exception) { isFound = false; }
            return isFound;
        }
    }
}