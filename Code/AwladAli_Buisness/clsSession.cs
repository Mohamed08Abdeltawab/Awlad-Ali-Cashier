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
        public DateTime? EndTime { get; set; }
        public decimal TotalCash { get; set; }
        public bool IsActive { get; set; }

        public clsSession()
        {
            this.SessionID = -1;
            this.UserID = -1;
            this.StartTime = DateTime.Now;
            this.TotalCash = 0;
            this.IsActive = true;
            Mode = enMode.AddNew;
        }

        // Constructor خاص لبناء الكائن عند العثور عليه
        private clsSession(int SessionID, int UserID, DateTime StartTime, DateTime? EndTime, decimal TotalCash, bool IsActive)
        {
            this.SessionID = SessionID;
            this.UserID = UserID;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.TotalCash = TotalCash;
            this.IsActive = IsActive;
            this.Mode = enMode.Update;
        }

        public static clsSession Find(int SessionID)
        {
            int UserID = -1;
            DateTime StartTime = DateTime.Now;
            object EndTime = null;
            decimal TotalCash = 0;
            bool IsActive = false;

            if (clsSessionData.GetSessionInfoByID(SessionID, ref UserID, ref StartTime, ref EndTime, ref TotalCash, ref IsActive))
            {
                // Return an object of the class with the data found in the database
                return new clsSession(SessionID, UserID, StartTime, (DateTime?)EndTime, TotalCash, IsActive);
            }
            else
            {
                return null;
            }
        }

        // 1. دالة بدء الجلسة
        private bool _AddNewSession()
        {
            // قبل البدء، نغلق أي جلسة "تائهة" لهذا المستخدم لضمان سلامة البيانات
            clsSessionData.CloseAnyActiveSession();

            this.SessionID = clsSessionData.AddNewSession(this.UserID, this.StartTime);
            return (this.SessionID != -1);
        }

        // 2. دالة إنهاء الجلسة
        private bool _EndSession()
        {
            // تحديث إجمالي المبيعات من جدول الطلبات قبل الإغلاق
            this.TotalCash = clsSessionData.GetTotalSalesBySessionID(this.SessionID);
            
            return clsSessionData.EndSession(this.SessionID, DateTime.Now, this.TotalCash);
        }

        // 3. دالة الحفظ الذكية
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

        // دالة مساعدة لحساب المبيعات الحالية (بدون إغلاق الجلسة) لغرض العرض في الـ UI
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