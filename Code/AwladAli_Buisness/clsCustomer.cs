using System;
using System.Data;
using AwladAli_Data;

namespace AwladAli_Buisness
{
    public class clsCustomer
    {
        // Object modes to separate AddNew operations from Updates
        private enum enMode { AddNew = 0, Update = 1 }
        private enMode Mode = enMode.AddNew;

        // Public Properties matching the database schema
        public int CustomerID { get; private set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; private set; } = DateTime.Now;
        public bool IsActive { get; set; }
        public int? CreatedByUserID { get; set; }

        // Default Constructor for creating a new customer object
        public clsCustomer()
        {
            this.CustomerID = -1;
            this.PhoneNumber = "";
            this.FullName = "";
            this.Address = "";
            this.Notes = "";
            this.IsActive = true;
            this.CreatedByUserID = null;
            Mode = enMode.AddNew;
        }

        // Private Constructor utilized to map retrieved data into an object instance
        private clsCustomer(int customerID, string phoneNumber, string fullName, string address, string notes, bool isActive, int? createdByUserID)
        {
            this.CustomerID = customerID;
            this.PhoneNumber = phoneNumber;
            this.FullName = fullName;
            this.Address = address;
            this.Notes = notes;
            this.IsActive = isActive;
            this.CreatedByUserID = createdByUserID;
            Mode = enMode.Update;
        }

        // Internal method to handle data insertion via Data Access Layer
        private bool _AddNewCustomer()
        {
            this.CustomerID = clsCustomerData.AddNewCustomer(this.PhoneNumber, this.FullName, this.Address, this.Notes, this.IsActive, this.CreatedByUserID);
            return (this.CustomerID != -1);
        }

        // Internal method to handle data updates via Data Access Layer
        private bool _UpdateCustomer()
        {
            return clsCustomerData.UpdateCustomer(this.CustomerID, this.PhoneNumber, this.FullName, this.Address, this.Notes, this.IsActive);
        }

        // Static method to find a customer by phone number and return its object instance
        public static clsCustomer FindByPhoneNumber(string phoneNumber)
        {
            int customerID = -1;
            string fullName = "", address = "", notes = "";
            bool isActive = true;
            int? createdByUserID = null;
            DateTime createdDate = DateTime.Now;

            if (clsCustomerData.GetCustomerByPhoneNumber(phoneNumber, ref customerID, ref fullName, ref address, ref notes, ref createdDate, ref isActive, ref createdByUserID))
            {
                return new clsCustomer(customerID, phoneNumber, fullName, address, notes, isActive, createdByUserID) { CreatedDate = createdDate };
            }
            else
            {
                return null; // Customer not found
            }
        }

        // Static method to find a customer by phone number and return its object instance
        public static clsCustomer FindByCustomerID(int customerID)
        {
            string phoneNumber = "";
            string fullName = "", address = "", notes = "";
            bool isActive = true;
            int? createdByUserID = null;
            DateTime createdDate = DateTime.Now;

            if (clsCustomerData.GetCustomerInfoByID(customerID, ref phoneNumber, ref fullName, ref address, ref notes, ref createdDate, ref isActive, ref createdByUserID))
            {
                return new clsCustomer(customerID, phoneNumber, fullName, address, notes, isActive, createdByUserID) { CreatedDate = createdDate };
            }
            else
            {
                return null; // Customer not found
            }
        }

        // Smart Save method to determine whether to Insert or Update based on the object state
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCustomer())
                    {
                        Mode = enMode.Update; // Switch mode after successful database insertion
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateCustomer();
            }
            return false;
        }

        // Static method to retrieve all customers (Active & Inactive)
        public static DataTable GetAllCustomers()
        {
            return clsCustomerData.GetAllCustomers();
        }

        // Static method to retrieve active customers only for the cashier interface
        public static DataTable GetAllActiveCustomers()
        {
            return clsCustomerData.GetAllActiveCustomers();
        }

        // Static method to delete a customer safely if they have no financial records
        public static bool Delete(string phoneNumber)
        {
            // Data integrity check: prevent deleting customers associated with older invoices
            if (clsCustomerData.IsCustomerHasOrders(phoneNumber))
            {
                return false;
            }

            return clsCustomerData.DeleteCustomer(phoneNumber);
        }

        public static bool IsCustomerExist(string phoneNumber)
        {
            return clsCustomerData.IsCustomerExist(phoneNumber);
        }

        public static DataTable GetTop10CustomersByPhoneNumber(string searchText = "")
        {
            return clsCustomerData.GetTop10CustomersByPhoneNumber(searchText);
        }

        public static DataTable GetTop10CustomersByName(string searchText = "")
        {
            return clsCustomerData.GetTop10CustomersByName(searchText);
        }

        public static bool Disable(string phoneNumber)
        {
            return clsCustomerData.Disable(phoneNumber);
        }

        public static bool Activate(string phoneNumber)
        {
            return clsCustomerData.Activate(phoneNumber);
        }

    }
}