using AwladAli_Data;
using System;
using System.Data;
using System.Data.SQLite;

namespace AwladAli_Buisness
{
    public class clsSession
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int SessionID { get; set; }
        public int UserID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal TotalCash { get; set; }
        public bool IsActive { get; set; }

        // 🎯 CRITICAL SYNC: Numeric counter property to track live active duration seamlessly
        public int DurationInSeconds { get; set; }

        public clsSession()
        {
            this.SessionID = -1;
            this.UserID = -1;
            this.StartTime = DateTime.Now;
            this.EndTime = null;
            this.TotalCash = 0;
            this.IsActive = true;
            this.DurationInSeconds = 0;
            Mode = enMode.AddNew;
        }

        private clsSession(int SessionID, int UserID, DateTime StartTime, DateTime? EndTime, decimal TotalCash, bool IsActive, int DurationInSeconds)
        {
            this.SessionID = SessionID;
            this.UserID = UserID;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.TotalCash = TotalCash;
            this.IsActive = IsActive;
            this.DurationInSeconds = DurationInSeconds;
            this.Mode = enMode.Update;
        }

        public static clsSession Find(int SessionID)
        {
            int UserID = -1;
            DateTime StartTime = DateTime.Now;
            object EndTime = null;
            decimal TotalCash = 0;
            bool IsActive = false;
            int DurationInSeconds = 0;

            if (clsSessionData.GetSessionInfoByID(SessionID, ref UserID, ref StartTime, ref EndTime, ref TotalCash, ref IsActive, ref DurationInSeconds))
            {
                return new clsSession(SessionID, UserID, StartTime, (DateTime?)EndTime, TotalCash, IsActive, DurationInSeconds);
            }
            else
            {
                return null;
            }
        }

        public static clsSession FindAnyActiveSessionWithUserInfo()
        {
            int sessionID = -1;
            int userID = -1;
            DateTime startTime = DateTime.Now;
            decimal totalCash = 0.00m;
            bool isActive = false;
            int durationInSeconds = 0;

            if (clsSessionData.GetAnyActiveSessionWithUserInfo(ref sessionID, ref userID, ref startTime, ref totalCash, ref isActive, ref durationInSeconds))
            {
                clsSession session = new clsSession(sessionID, userID, startTime, null, totalCash, isActive, durationInSeconds);
                return session;
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewSession()
        {
            clsSessionData.CloseAnyActiveSession();

            this.SessionID = clsSessionData.AddNewSession(this.UserID, this.StartTime);
            return (this.SessionID != -1);
        }

        // 🎯 NEW BUSINESS METHOD: To update live cash and seconds without closing the shift
        public bool UpdateSessionProgress()
        {
            // Reuse your existing EndSession data method, but pass NULL for EndTime, and keep IsActive as 1
            // Wait, your EndSession data method forces IsActive = 0. Let's make a dedicated minor update query or adjust it!

            // Instead of making a new data layer function, let's look at how we can update the row cleanly:
            return clsSessionData.UpdateLiveSessionCounters(this.SessionID, this.TotalCash, this.DurationInSeconds);
        }

        private bool _EndSession()
        {
            this.TotalCash = clsSessionData.GetTotalSalesBySessionID(this.SessionID);

            // 🎯 CRITICAL SYNC: Pass the tracked DurationInSeconds down to the database update stream
            return clsSessionData.EndSession(this.SessionID, DateTime.Now, this.TotalCash, this.DurationInSeconds);
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

        public decimal GetCurrentSales()
        {
            return clsSessionData.GetTotalSalesBySessionID(this.SessionID);
        }

        public static void CloseAnyActiveSession()
        {
            clsSessionData.CloseAnyActiveSession();
        }

        public static DataTable GetAllSessions()
        {
            return clsSessionData.GetAllSessions();
        }

        public static DataTable GetSessionsWithPagination(int PageNumber, int PageSize)
        {
            return clsSessionData.GetSessionsWithPagination(PageNumber, PageSize);
        }
    }
}