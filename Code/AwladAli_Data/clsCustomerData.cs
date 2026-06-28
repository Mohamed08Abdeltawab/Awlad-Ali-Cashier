using System;
using System.Data;
using System.Data.SQLite;

namespace AwladAli_Data
{
    public class clsCustomerData
    {
        /// <summary>
        /// Adds a new customer to the database and returns the new CustomerID.
        /// </summary>
        public static int AddNewCustomer(string phoneNumber, string fullName, string address, string notes, bool isActive, int? createdByUserID)
        {
            int customerID = -1;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"INSERT INTO Customers (PhoneNumber, FullName, Address, Notes, IsActive, CreatedByUserID) 
                                    VALUES (@PhoneNumber, @FullName, @Address, @Notes, @IsActive, @CreatedByUserID);
                                    SELECT last_insert_rowid();";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber.Trim());
                        command.Parameters.AddWithValue("@FullName", fullName.Trim());
                        command.Parameters.AddWithValue("@Address", address.Trim());

                        // Handle nullable Notes
                        command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(notes) ? (object)DBNull.Value : notes.Trim());
                        command.Parameters.AddWithValue("@IsActive", isActive ? 1 : 0);

                        // Handle nullable CreatedByUserID
                        command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID.HasValue ? (object)createdByUserID.Value : DBNull.Value);

                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            customerID = insertedID;
                        }
                    }
                }
            }
            catch (Exception) { customerID = -1; }

            return customerID;
        }

        /// <summary>
        /// Updates an existing customer's data in the database.
        /// </summary>
        public static bool UpdateCustomer(int customerID, string phoneNumber, string fullName, string address, string notes, bool isActive)
        {
            int rowsAffected = 0;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"UPDATE Customers 
                                     SET PhoneNumber = @PhoneNumber, 
                                         FullName = @FullName, 
                                         Address = @Address, 
                                         Notes = @Notes,
                                         IsActive = @IsActive
                                     WHERE CustomerID = @CustomerID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", customerID);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber.Trim());
                        command.Parameters.AddWithValue("@FullName", fullName.Trim());
                        command.Parameters.AddWithValue("@Address", address.Trim());
                        command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(notes) ? (object)DBNull.Value : notes.Trim());
                        command.Parameters.AddWithValue("@IsActive", isActive ? 1 : 0);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception) { return false; }

            return (rowsAffected > 0);
        }

        /// <summary>
        /// Finds a customer by their phone number and retrieves their details.
        /// </summary>
        public static bool GetCustomerByPhoneNumber(string phoneNumber, ref int customerID, ref string fullName, ref string address, ref string notes, ref bool isActive, ref int? createdByUserID)
        {
            bool isFound = false;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Customers WHERE PhoneNumber = @PhoneNumber";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber.Trim());

                        connection.Open();
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                customerID = Convert.ToInt32(reader["CustomerID"]);
                                fullName = Convert.ToString(reader["FullName"]);
                                address = Convert.ToString(reader["Address"]);
                                notes = reader["Notes"] != DBNull.Value ? Convert.ToString(reader["Notes"]) : "";
                                isActive = Convert.ToInt32(reader["IsActive"]) == 1;

                                // Retrieve CreatedByUserID safely if it's not null
                                createdByUserID = reader["CreatedByUserID"] != DBNull.Value ? (int?)Convert.ToInt32(reader["CreatedByUserID"]) : null;
                            }
                        }
                    }
                }
            }
            catch (Exception) { isFound = false; }

            return isFound;
        }

        /// <summary>
        /// Retrieves all customers from the database (Active and Inactive) with their status formatted.
        /// </summary>
        public static DataTable GetAllCustomers()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT CustomerID, PhoneNumber, FullName, Address, Notes, 
                                     CASE WHEN IsActive = 1 THEN 'نشط' ELSE 'غير نشط' END AS IsActive, 
                                     CreatedByUserID, CreatedDate FROM Customers ORDER BY CustomerID DESC";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
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

        /// <summary>
        /// Retrieves only active customers from the database for the cashier interface.
        /// </summary>
        public static DataTable GetAllActiveCustomers()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT CustomerID, PhoneNumber, FullName, Address, Notes FROM Customers WHERE IsActive = 1 ORDER BY CustomerID DESC";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
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

        /// <summary>
        /// Deletes a customer permanently from the database.
        /// </summary>
        public static bool DeleteCustomer(int customerID)
        {
            int rowsAffected = 0;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "DELETE FROM Customers WHERE CustomerID = @CustomerID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", customerID);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception) { return false; }

            return (rowsAffected > 0);
        }

        /// <summary>
        /// Checks if a customer is linked to any existing orders in the system.
        /// </summary>
        public static bool IsCustomerHasOrders(int customerID)
        {
            bool hasOrders = false;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT COUNT(*) FROM Orders WHERE CustomerID = @CustomerID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", customerID);
                        connection.Open();

                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int count))
                        {
                            hasOrders = (count > 0);
                        }
                    }
                }
            }
            catch (Exception) { }
            return hasOrders;
        }
    }
}