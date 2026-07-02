using AwladAli_Data;
using System;
using System.Data;

namespace AwladAli_Buisness
{
    public class clsEmployeeTransaction
    {
        public enum enMode { AddNew = 0 }
        public enMode Mode = enMode.AddNew;

        public int TransactionID { get; set; }
        public int EmployeeID { get; set; }
        public int SessionID { get; set; }
        public int TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        // 1. Default Constructor (For creating a new transaction)
        public clsEmployeeTransaction()
        {
            this.TransactionID = -1;
            this.EmployeeID = -1;
            this.SessionID = -1;
            this.TransactionType = 1; // Default to Advance
            this.Amount = 0.00m;
            this.TransactionDate = DateTime.Now;
            this.Notes = "";
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        // 2. Internal function to save to database
        private bool _AddNewTransaction()
        {
            this.TransactionID = clsEmployeeTransactionData.AddNewTransaction(
                this.EmployeeID,
                this.SessionID,
                this.TransactionType,
                this.Amount,
                this.TransactionDate,
                this.Notes,
                this.CreatedByUserID
            );

            return (this.TransactionID != -1);
        }

        // 3. Master Save Method
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    return _AddNewTransaction();
            }
            return false;
        }

        // 4. Static Method to Get All Transactions for a single Employee
        public static DataTable GetTransactionsByEmployeeID(int employeeID)
        {
            return clsEmployeeTransactionData.GetTransactionsByEmployeeID(employeeID);
        }

        // 5. Static Method to get the current financial balance of an employee
        public static decimal GetEmployeeNetBalance(int employeeID)
        {
            return clsEmployeeTransactionData.GetEmployeeNetBalance(employeeID);
        }
    }
}
