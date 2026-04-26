using System;
using System.Data;
using System.Data.SQLite;

namespace AwladAli_Data
{
    public class clsUserData
    {
        // 1. Find User by ID (Updated to include IsActive)
        public static bool GetUserByID(int UserID, ref string UserName, ref string Password, ref int Role, ref bool IsActive)
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
                                // تحويل الـ 0/1 من SQLite إلى bool
                                IsActive = Convert.ToBoolean(reader["IsActive"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                isFound = false;
            }

            return isFound;
        }

        // Find User by Username and Password (Updated to ONLY allow Active Users for Login)
        public static bool GetUserByUsernameAndPassword(string UserName, string Password,
            ref int UserID, ref int Role)
        {
            bool isFound = false;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    // أضفنا شرط IsActive = 1 لضمان عدم دخول المستخدمين المعطلين
                    string query = "SELECT UserID, Role FROM Users WHERE UserName = @UserName AND Password = @Password AND IsActive = 1";

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

        // 2. Add New User (Updated to include IsActive)
        public static int AddNewUser(string UserName, string Password, int Role, bool IsActive)
        {
            int UserID = -1;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"INSERT INTO Users (UserName, Password, Role, IsActive) 
                                     VALUES (@UserName, @Password, @Role, @IsActive);
                                     SELECT last_insert_rowid();";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@Role", Role);
                        command.Parameters.AddWithValue("@IsActive", IsActive ? 1 : 0);

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
            }

            return UserID;
        }

        // 3. Update User (Updated to include IsActive)
        public static bool UpdateUser(int UserID, string UserName, string Password, int Role, bool IsActive)
        {
            int rowsAffected = 0;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"UPDATE Users 
                                     SET UserName = @UserName, 
                                         Password = @Password, 
                                         Role = @Role,
                                         IsActive = @IsActive
                                     WHERE UserID = @UserID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@Role", Role);
                        command.Parameters.AddWithValue("@IsActive", IsActive ? 1 : 0);

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

        public static bool ActivateUser(int UserID)
        {
            int rowsAffected = 0;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    // تحويل المستخدم لحالة نشط  
                    string query = "UPDATE Users SET IsActive = 1 WHERE UserID = @UserID";

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
            }

            return (rowsAffected > 0);
        }


        // 4. Deactivate User (Updated to Soft Delete / Deactivate)
        // بدل ما نمسح، هنغير الحالة لـ 0 عشان نحافظ على الـ Integrity
        public static bool DeactivateUser(int UserID)
        {
            int rowsAffected = 0;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    // تحويل المستخدم لحالة غير نشط بدل الحذف
                    string query = "UPDATE Users SET IsActive = 0 WHERE UserID = @UserID AND UserID <> 1";//<> not equal 

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
            }

            return (rowsAffected > 0);
        }


        public static bool DeleteUser(int UserID)
        {
            int rowsAffected = 0;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    // أضفنا شرط "UserID <> 1" كحماية نهائية حتى لو تم استدعاء الدالة بالخطأ
                    string query = "DELETE FROM Users WHERE UserID = @UserID AND UserID <> 1 and UserID <> @UserID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);
                        connection.Open();

                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return (rowsAffected > 0);
        }


        // 5. Get All Users (Updated to show IsActive status in UI)
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
                                      END AS RoleName,
                                      CASE IsActive
                                        WHEN 1 THEN 'Active'
                                        ELSE 'Inactive'
                                      END AS Status
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
                    string query = "SELECT COUNT(*) FROM Users WHERE UserName = @UserName";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", UserName);
                        connection.Open();
                        long count = (long)command.ExecuteScalar();
                        if (count > 0) isFound = true;
                    }
                }
            }
            catch (Exception ex) { isFound = false; }
            return isFound;
        }

        public static bool IsUserAdmin(int UserID)
        {
            bool isAdmin = false;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = @"SELECT 1 FROM Users Where UserID = @UserID AND Role = 0 LIMIT 1";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);
                        object result = command.ExecuteScalar();
                        if (result != null) isAdmin = true;
                    }
                }
            }
            catch (Exception ex) { }
            return isAdmin;
        }

        public static int GetActiveAdminsCount()
        {
            int Count = 0;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    // نعد فقط المستخدمين الأدمن (Role=0) والنشطين (IsActive=1)
                    string query = "SELECT COUNT(*) FROM Users WHERE Role = 0 AND IsActive = 1";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int c))
                        {
                            Count = c;
                        }
                    }
                }
            }
            catch (Exception)
            {
                Count = 0;
            }

            return Count;
        }

    }
}