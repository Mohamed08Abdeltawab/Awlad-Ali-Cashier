using System;
using System.Data;
using System.Data.SQLite;
namespace AwladAli_Data
{
    public static class clsEmployeeData
    {
        // 1. Find Employee By ID
        public static bool GetEmployeeInfoByID(int employeeID, ref string fullName, ref string phoneNumber, ref decimal dailyWage, ref bool isActive)
        {
            bool isFound = false;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Employees WHERE EmployeeID = @EmployeeID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeID);
                        connection.Open();

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                fullName = Convert.ToString(reader["FullName"]);
                                phoneNumber = reader["PhoneNumber"] != DBNull.Value ? Convert.ToString(reader["PhoneNumber"]) : "";
                                dailyWage = Convert.ToDecimal(reader["DailyWage"]);

                                isActive = Convert.ToInt32(reader["IsActive"]) == 1;
                            }
                        }
                    }
                }
            }
            catch (Exception) { isFound = false; }
            return isFound;
        }

        // 2. Add New Employee (Returns the New ID)
        public static int AddNewEmployee(string fullName, string phoneNumber, decimal dailyWage, bool isActive)
        {
            int employeeID = -1;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"INSERT INTO Employees (FullName, PhoneNumber, DailyWage, IsActive) 
                                 VALUES (@FullName, @PhoneNumber, @DailyWage, @IsActive);
                                 SELECT last_insert_rowid();"; // لجلب الـ ID الجديد فوراً

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FullName", fullName);
                        command.Parameters.AddWithValue("@PhoneNumber", string.IsNullOrEmpty(phoneNumber) ? (object)DBNull.Value : phoneNumber);
                        command.Parameters.AddWithValue("@DailyWage", dailyWage);
                        command.Parameters.AddWithValue("@IsActive", isActive ? 1 : 0);

                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            employeeID = insertedID;
                        }
                    }
                }
            }
            catch (Exception) { employeeID = -1; }
            return employeeID;
        }

        // 3. Update Employee Info
        public static bool UpdateEmployee(int employeeID, string fullName, string phoneNumber, decimal dailyWage, bool isActive)
        {
            int rowsAffected = 0;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"UPDATE Employees 
                                 SET FullName = @FullName, 
                                     PhoneNumber = @PhoneNumber, 
                                     DailyWage = @DailyWage, 
                                     IsActive = @IsActive 
                                 WHERE EmployeeID = @EmployeeID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeID);
                        command.Parameters.AddWithValue("@FullName", fullName);
                        command.Parameters.AddWithValue("@PhoneNumber", string.IsNullOrEmpty(phoneNumber) ? (object)DBNull.Value : phoneNumber);
                        command.Parameters.AddWithValue("@DailyWage", dailyWage);
                        command.Parameters.AddWithValue("@IsActive", isActive ? 1 : 0);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception) { return false; }
            return (rowsAffected > 0);
        }

        // 4. Get All Employees (To Fill ComboBox or DataGridView)
        public static DataTable GetAllEmployees()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT EmployeeID, FullName, PhoneNumber, DailyWage, IsActive FROM Employees ORDER BY FullName ASC";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        connection.Open();
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception) { }
            return dt;
        }
    }
}
