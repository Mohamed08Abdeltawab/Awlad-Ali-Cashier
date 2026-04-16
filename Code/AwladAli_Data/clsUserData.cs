using System;
using System.Data;
using System.Data.SQLite;

namespace AwladAli_Data
{
    public class clsUserData
    {
        // 1. Find User by ID
        public static bool GetUserByID(int UserID, ref string UserName, ref string Password, ref int Role)
        {
            bool isFound = false;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Users WHERE UserID = @UserID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);
                        connection.Open();

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                UserName = (string)reader["UserName"];
                                Password = (string)reader["Password"];
                                Role = Convert.ToInt32(reader["Role"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                isFound = false;
                // Log exception here if needed
            }

            return isFound;
        }

        // Find User by Username and Password (Used for Login)
        public static bool GetUserByUsernameAndPassword(string UserName, string Password,
            ref int UserID, ref int Role)
        {
            bool isFound = false;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    // Query to find a matching active user
                    string query = "SELECT UserID, Role FROM Users WHERE UserName = @UserName AND Password = @Password";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);

                        connection.Open();

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                UserID = Convert.ToInt32(reader["UserID"]);
                                Role = Convert.ToInt32(reader["Role"]);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                isFound = false;
            }

            return isFound;
        }

        // 2. Add New User
        public static int AddNewUser(string UserName, string Password, int Role)
        {
            int UserID = -1;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"INSERT INTO Users (UserName, Password, Role) 
                                     VALUES (@UserName, @Password, @Role);
                                     SELECT last_insert_rowid();";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@Role", Role);

                        connection.Open();

                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            UserID = insertedID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log exception
            }

            return UserID;
        }

        // 3. Update User
        public static bool UpdateUser(int UserID, string UserName, string Password, int Role)
        {
            int rowsAffected = 0;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"UPDATE Users 
                                     SET UserName = @UserName, 
                                         Password = @Password, 
                                         Role = @Role 
                                     WHERE UserID = @UserID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@Role", Role);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return (rowsAffected > 0);
        }

        // 4. Delete User
        public static bool DeleteUser(int UserID)
        {
            int rowsAffected = 0;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "DELETE FROM Users WHERE UserID = @UserID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log exception
            }

            return (rowsAffected > 0);
        }

        // 5. Get All Users (Returns DataTable for UI Grids)
        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT UserID, UserName,
                                      CASE Role 
                                        WHEN 0 THEN 'Admin' 
                                        WHEN 1 THEN 'Cashier' 
                                        ELSE 'Unknown' 
                                      END AS RoleName
                                        FROM Users";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        connection.Open();
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log exception
            }

            return dt;
        }

        public static bool IsUserExist(string UserName)
        {
            bool isFound = false;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    // نستخدم COUNT عشان نعرف فيه كام يوزر بالاسم ده
                    string query = "SELECT COUNT(*) FROM Users WHERE UserName = @UserName";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", UserName);
                        connection.Open();

                        // ExecuteScalar بترجع أول قيمة في أول صف (اللي هي هنا نتيجة الـ Count)
                        long count = (long)command.ExecuteScalar();

                        if (count > 0)
                        {
                            isFound = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // تسجيل الخطأ لو حصل مشكلة في الاتصال
                isFound = false;
            }

            return isFound;
        }
    }
}