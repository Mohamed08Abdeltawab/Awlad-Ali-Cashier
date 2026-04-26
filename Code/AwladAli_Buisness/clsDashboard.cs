using AwladAli_Data;
using System;
using System.Data;

namespace AwladAli_Buisness
{
    /// <summary>
    /// Business Layer للـ Dashboard – بيتعامل مع clsDashboardData
    /// ويوفر كل البيانات المطلوبة لـ frmAdminDashBoard
    /// </summary>
    public class clsDashboard
    {
        public DateTime From { get; private set; }
        public DateTime To { get; private set; }

        public decimal TotalRevenue { get; private set; }
        public decimal TodayRevenue { get; private set; }
        public int OrdersCount { get; private set; }

        public DataTable TopProducts { get; private set; }
        public DataTable TopCategories { get; private set; }
        public DataTable TopExtras { get; private set; }
        public DataTable Orders { get; private set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 19;


        public clsDashboard(DateTime From, DateTime To)
        {
            if (From.Date > To.Date)
                throw new ArgumentException("تاريخ البداية يجب أن يكون قبل أو يساوي تاريخ النهاية.");

            this.From = From.Date;
            this.To = To.Date;

            _LoadAll();
        }

        
        private void _LoadAll()
        {
            _LoadRevenue();
            _LoadOrdersCount();
            _LoadTopProducts();
            _LoadTopCategories();
            _LoadTopExtras();
            LoadOrdersWithPagination();
        }

        private void _LoadRevenue()
        {
            decimal periodRevenue = 0;
            clsDashboardData.GetTotalRevenue(From, To, ref periodRevenue);
            TotalRevenue = periodRevenue;

            // أرباح اليوم دايماً Today → Today بغض النظر عن الفلتر
            decimal todayRev = 0;
            clsDashboardData.GetTotalRevenue(DateTime.Today, DateTime.Today, ref todayRev);
            TodayRevenue = todayRev;
        }

        private void _LoadOrdersCount()
        {
            int count = 0;
            clsDashboardData.GetOrdersCount(From, To, ref count);
            OrdersCount = count;
        }

        private void _LoadTopProducts()
        {
            TopProducts = clsDashboardData.GetTopProducts(From, To, 6);
        }

        private void _LoadTopCategories()
        {
            TopCategories = clsDashboardData.GetTopCategories(From, To, 3);
        }

        private void _LoadTopExtras()
        {
            TopExtras = clsDashboardData.GetTopExtras(From, To, 3);
        }

        public void LoadOrdersWithPagination()
        {
            // نجلب الداتا الجديدة فقط للصفحة الحالية
            DataTable NewOrders = clsDashboardData.GetOrdersByDateRangeWithPagination(From, To, PageNumber, PageSize);

            if (PageNumber == 1)
            {
                // لو إحنا في أول صفحة، نساوي الجدول بالداتا الجديدة مباشرة
                Orders = NewOrders;
            }
            else
            {
                // لو إحنا في صفحة تانية أو تالتة، ندمج الجديد مع القديم
                if (NewOrders != null && NewOrders.Rows.Count > 0)
                {
                    Orders.Merge(NewOrders);
                }
            }
        }

        public void LoadAllOrders()
        {
                Orders = clsDashboardData.GetOrdersByDateRange(From, To);
        }


        /// <summary>يرجع كائن clsDashboard لـ"اليوم" فقط</summary>
        public static clsDashboard ForToday()
            => new clsDashboard(DateTime.Today, DateTime.Today);

        /// <summary>يرجع كائن clsDashboard لآخر N يوم</summary>
        public static clsDashboard ForLastDays(int days)
        {
            if (days <= 0)
                throw new ArgumentException("عدد الأيام يجب أن يكون أكبر من صفر.");

            return new clsDashboard(DateTime.Today.AddDays(-days + 1), DateTime.Today);
        }

        /// <summary>يرجع كائن clsDashboard لكل البيانات بدون فلتر</summary>
        public static clsDashboard ForAllTime()
            => new clsDashboard(new DateTime(2000, 1, 1), DateTime.Today);

        

        /// <summary>
        /// يرجع الاسم من DataTable بناءً على الـ index (يبدأ من 0)،
        /// لو مفيش بيانات يرجع "-"
        /// </summary>
        public static string GetRankName(DataTable dt, int index,
                                         string nameColumn = "ProductName")
        {
            if (dt == null || index >= dt.Rows.Count)
                return "-";

            return dt.Rows[index][nameColumn]?.ToString() ?? "-";
        }
    }
}