using AwladAli_Data;
using System;
using System.Data;

namespace AwladAli_Buisness
{
    public class clsEmployee
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal DailyWage { get; set; }
        public bool IsActive { get; set; }

        // 1. Default Constructor (For AddNew Mode)
        public clsEmployee()
        {
            this.EmployeeID = -1;
            this.FullName = "";
            this.PhoneNumber = "";
            this.DailyWage = 0.00m;
            this.IsActive = true;

            Mode = enMode.AddNew;
        }

        // 2. Private Constructor (For Loading Existing Data)
        private clsEmployee(int employeeID, string fullName, string phoneNumber, decimal dailyWage, bool isActive)
        {
            this.EmployeeID = employeeID;
            this.FullName = fullName;
            this.PhoneNumber = phoneNumber;
            this.DailyWage = dailyWage;
            this.IsActive = isActive;

            Mode = enMode.Update;
        }

        // 3. Find Employee By ID (Returns Object or Null)
        public static clsEmployee Find(int employeeID)
        {
            string fullName = "";
            string phoneNumber = "";
            decimal dailyWage = 0.00m;
            bool isActive = true;

            if (clsEmployeeData.GetEmployeeInfoByID(employeeID, ref fullName, ref phoneNumber, ref dailyWage, ref isActive))
            {
                return new clsEmployee(employeeID, fullName, phoneNumber, dailyWage, isActive);
            }
            else
            {
                return null; // Employee not found
            }
        }

        // 4. Add New Employee Function (Internal)
        private bool _AddNewEmployee()
        {
            this.EmployeeID = clsEmployeeData.AddNewEmployee(this.FullName, this.PhoneNumber, this.DailyWage, this.IsActive);
            return (this.EmployeeID != -1);
        }

        // 5. Update Employee Function (Internal)
        private bool _UpdateEmployee()
        {
            return clsEmployeeData.UpdateEmployee(this.EmployeeID, this.FullName, this.PhoneNumber, this.DailyWage, this.IsActive);
        }

        // 6. The Master Save Method
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewEmployee())
                    {
                        Mode = enMode.Update; // Switch mode after successful insert
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateEmployee();
            }

            return false;
        }

        // 7. Static Method to Get All Employees
        public static DataTable GetAllEmployees()
        {
            return clsEmployeeData.GetAllEmployees();
        }
    }
}
