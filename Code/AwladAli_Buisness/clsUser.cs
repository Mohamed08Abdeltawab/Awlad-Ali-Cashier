using System;
using System.Data;
using AwladAli_Data;

namespace AwladAli_Buisness
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public bool IsActive { get; set; } // الخاصية الجديدة

        public clsUser()
        {
            this.UserID = -1;
            this.UserName = "";
            this.Password = "";
            this.Role = -1;
            this.IsActive = true; // القيمة الافتراضية لأي يوزر جديد

            Mode = enMode.AddNew;
        }

        private clsUser(int UserID, string UserName, string Password, int Role, bool IsActive)
        {
            this.UserID = UserID;
            this.UserName = UserName;
            this.Password = Password;
            this.Role = Role;
            this.IsActive = IsActive;

            Mode = enMode.Update;
        }

        public static clsUser Find(int UserID)
        {
            string UserName = "";
            string Password = "";
            int Role = -1;
            bool IsActive = false;

            // تم تحديث استدعاء الداتا لير لاستقبال IsActive
            if (clsUserData.GetUserByID(UserID, ref UserName, ref Password, ref Role, ref IsActive))
            {
                return new clsUser(UserID, UserName, Password, Role, IsActive);
            }
            else
            {
                return null;
            }
        }

        public static clsUser FindByUsernameAndPassword(string UserName, string Password)
        {
            int UserID = -1;
            int Role = -1;
            // لاحظ أن GetUserByUsernameAndPassword في الداتا لير تفحص IsActive = 1 تلقائياً
            if (clsUserData.GetUserByUsernameAndPassword(UserName, Password, ref UserID, ref Role))
            {
                // بما أنه سجل دخول، فهو بالتأكيد Active
                return new clsUser(UserID, UserName, Password, Role, true);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewUser()
        {
            // إرسال IsActive للداتا لير عند الإضافة
            this.UserID = clsUserData.AddNewUser(this.UserName, this.Password, this.Role, this.IsActive);
            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            // إرسال IsActive للداتا لير عند التحديث
            return clsUserData.UpdateUser(this.UserID, this.UserName, this.Password, this.Role, this.IsActive);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
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

        public static bool DeactivateUser(int UserID)
        {
            // تذكر أن هذه الدالة في الداتا لير أصبحت تقوم بعمل Update IsActive = 0
            return clsUserData.DeactivateUser(UserID);
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }
        
        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public static bool IsUserExist(string UserName)
        {
            return clsUserData.IsUserExist(UserName);
        }

        public static bool IsUserAdmin(int UserID)
        {
            return clsUserData.IsUserAdmin(UserID);
        }

        public static bool IsUserActive(int UserID)
        {
            return clsUserData.IsUserActive(UserID);
        }

    }
}