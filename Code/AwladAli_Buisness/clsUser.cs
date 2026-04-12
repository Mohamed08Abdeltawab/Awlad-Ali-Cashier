using System;
using System.Data;
using AwladAli_Data;

namespace AwladAli_Buisness
{
    public class clsUser
    {
        // Enums to define the mode of the object
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        // User Properties
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

        // Default constructor for AddNew mode
        public clsUser()
        {
            this.UserID = -1;
            this.UserName = "";
            this.Password = "";
            this.Role = -1;

            Mode = enMode.AddNew;
        }

        // Private constructor for Update mode (used internally by Find method)
        private clsUser(int UserID, string UserName, string Password, int Role)
        {
            this.UserID = UserID;
            this.UserName = UserName;
            this.Password = Password;
            this.Role = Role;

            Mode = enMode.Update;
        }

        // 1. Find User by ID
        public static clsUser Find(int UserID)
        {
            string UserName = "";
            string Password = "";
            int Role = -1;

            if (clsUserData.GetUserByID(UserID, ref UserName, ref Password, ref Role))
            {
                return new clsUser(UserID, UserName, Password, Role);
            }
            else
            {
                return null;
            }
        }

        // Static method to find a user for Login purposes
        public static clsUser FindByUsernameAndPassword(string UserName, string Password)
        {
            int UserID = -1;
            int Role = -1;

            // We pass UserName and Password (the Hashed one) to Data Layer
            if (clsUserData.GetUserByUsernameAndPassword(UserName, Password, ref UserID, ref Role))
            {
                // If found, we return a full user object using our existing constructor
                return new clsUser(UserID, UserName, Password, Role);
            }
            else
            {
                return null;
            }
        }

        // 2. Add New User (Internal helper)
        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(this.UserName, this.Password, this.Role);
            return (this.UserID != -1);
        }

        // 3. Update User (Internal helper)
        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(this.UserID, this.UserName, this.Password, this.Role);
        }

        // 4. Save Method: Routes to Add or Update based on Mode
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update; // Change mode after successful save
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateUser();
            }

            return false;
        }

        // 5. Delete User (Static)
        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }

        // 6. Get All Users (Static)
        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public static bool IsUserExist(string UserName)
        {
            return clsUserData.IsUserExist(UserName);
        }
    }
}