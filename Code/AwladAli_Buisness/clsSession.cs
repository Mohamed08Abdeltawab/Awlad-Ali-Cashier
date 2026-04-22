using System;
using System.Data;
using AwladAli_Data;

namespace AwladAli_Buisness
{
    public class clsSession
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int SessionID { get; set; }
        public int UserID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; } // Nullable لأنه مش موجود وقت البداية
        public decimal StartingCash { get; set; }
        public decimal FinalCash { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }

        public clsSession()
        {
            this.SessionID = -1;
            this.UserID = -1;
            this.StartTime = DateTime.Now;
            this.StartingCash = 0;
            this.IsActive = true;
            Mode = enMode.AddNew;
        }

        private clsSession(int SessionID, int UserID, DateTime StartTime, decimal StartingCash)
        {
            this.SessionID = SessionID;
            this.UserID = UserID;
            this.StartTime = StartTime;
            this.StartingCash = StartingCash;
            this.IsActive = true;
            Mode = enMode.Update;
        }

        private bool _AddNewSession()
        {
            this.SessionID = clsSessionData.AddNewSession(this.UserID, this.StartTime, this.StartingCash);
            return (this.SessionID != -1);
        }

        private bool _EndSession()
        {
            return clsSessionData.EndSession(this.SessionID, DateTime.Now, this.FinalCash, this.Notes);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewSession())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _EndSession();
            }
            return false;
        }

        // دالة للبحث عن جلسة نشطة للمستخدم الحالي
        public static clsSession GetActiveSession(int UserID)
        {
            int SessionID = -1;
            DateTime StartTime = DateTime.Now;
            decimal StartingCash = 0;

            if (clsSessionData.GetActiveSessionByUserID(UserID, ref SessionID, ref StartTime, ref StartingCash))
            {
                return new clsSession(SessionID, UserID, StartTime, StartingCash);
            }
            return null;
        }
    }
}