using System;
using System.Data;
using System.Data.SQLite;

namespace AwladAli_Data
{
    public static class clsEmployeeTransactionData
    {
        // 1. Add New Transaction (Returns the New Transaction ID)
        public static int AddNewTransaction(int employeeID, int sessionID, int transactionType, decimal amount, DateTime transactionDate, string notes, int createdByUserID)
        {
            int transactionID = -1;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"INSERT INTO EmployeeTransactions 
                                 (EmployeeID, SessionID, TransactionType, Amount, TransactionDate, Notes, CreatedByUserID) 
                                 VALUES 
                                 (@EmployeeID, @SessionID, @TransactionType, @Amount, @TransactionDate, @Notes, @CreatedByUserID);
                                 SELECT last_insert_rowid();";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeID);
                        command.Parameters.AddWithValue("@SessionID", sessionID);
                        command.Parameters.AddWithValue("@TransactionType", transactionType);
                        command.Parameters.AddWithValue("@Amount", amount);

                        // Format DateTime to standard SQLite string format
                        command.Parameters.AddWithValue("@TransactionDate", transactionDate.ToString("yyyy-MM-dd HH:mm:ss"));

                        // Handle nullable notes
                        command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(notes) ? (object)DBNull.Value : notes);

                        command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            transactionID = insertedID;
                        }
                    }
                }
            }
            catch (Exception) { transactionID = -1; }
            return transactionID;
        }

        // 2. Get All Transactions For a Specific Employee (For DataGridView)
        public static DataTable GetTransactionsByEmployeeID(int employeeID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    // Join with Users table to get the name of the user who created the transaction
                    string query = @"SELECT 
                                    ET.TransactionID, 
                                    ET.TransactionType, 
                                    ET.Amount, 
                                    ET.TransactionDate, 
                                    ET.Notes, 
                                    U.FullName AS CreatedBy
                                 FROM EmployeeTransactions ET
                                 INNER JOIN Users U ON ET.CreatedByUserID = U.UserID
                                 WHERE ET.EmployeeID = @EmployeeID
                                 ORDER BY ET.TransactionDate DESC";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeID);

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

        // 3. Get Net Balance for an Employee (Total Earnings - Total Deductions & Advances)
        public static decimal GetEmployeeNetBalance(int employeeID)
        {
            decimal netBalance = 0;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    // Calculation Logic:
                    // TransactionType 3 (Bonus) & 4 (Payout logic depending on how you use it) increases or decreases.
                    // Assuming: (Bonus) increases debt to employee, (Advance 1 + Deduction 2 + Payout 4) decreases it.
                    // We will calculate total Additions and total Subtractions.

                    string query = @"SELECT 
                                    SUM(CASE WHEN TransactionType = 3 THEN Amount ELSE 0 END) - 
                                    SUM(CASE WHEN TransactionType IN (1, 2, 4) THEN Amount ELSE 0 END) AS NetBalance
                                 FROM EmployeeTransactions
                                 WHERE EmployeeID = @EmployeeID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeID);

                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != DBNull.Value && result != null)
                        {
                            netBalance = Convert.ToDecimal(result);
                        }
                    }
                }
            }
            catch (Exception) { netBalance = 0; }
            return netBalance;
        }
    }
}
