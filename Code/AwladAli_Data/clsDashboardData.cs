using AwladAli_Data;
using System;
using System.Data;
using System.Data.SQLite;

namespace AwladAli_DataAccess
{
    public class clsDashboardData
    {
        
        private static string _ToSQLiteDate(DateTime date)
        {
            return date.Date.ToString("yyyy-MM-dd");
        }

        
        public static bool GetTotalRevenue(DateTime From, DateTime To,
                                           ref decimal TotalRevenue)
        {
            bool isFound = false;

            string sql = @"
                SELECT IFNULL(SUM(TotalAmount), 0)
                FROM   Orders
                WHERE  DATE(OrderDate) BETWEEN @From AND @To";

            using (SQLiteConnection conn = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@From", _ToSQLiteDate(From));
                cmd.Parameters.AddWithValue("@To", _ToSQLiteDate(To));

                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    TotalRevenue = Convert.ToDecimal(result);
                    isFound = true;
                }
            }

            return isFound;
        }

        
        public static bool GetOrdersCount(DateTime From, DateTime To,
                                          ref int OrdersCount)
        {
            bool isFound = false;

            string sql = @"
                SELECT COUNT(*)
                FROM   Orders
                WHERE  DATE(OrderDate) BETWEEN @From AND @To";

            using (SQLiteConnection conn = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@From", _ToSQLiteDate(From));
                cmd.Parameters.AddWithValue("@To", _ToSQLiteDate(To));

                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    OrdersCount = Convert.ToInt32(result);
                    isFound = true;
                }
            }

            return isFound;
        }

        
        public static DataTable GetTopProducts(DateTime From, DateTime To,
                                               int TopCount = 6)
        {
            DataTable dt = new DataTable();

            string sql = $@"
                SELECT P.ProductName,
                       COUNT(OD.ProductID) AS OrderCount
                FROM   OrderDetails OD
                       INNER JOIN Products P ON P.ProductID = OD.ProductID
                       INNER JOIN Orders   O ON O.OrderID   = OD.OrderID
                WHERE  DATE(O.OrderDate) BETWEEN @From AND @To
                GROUP  BY P.ProductName
                ORDER  BY OrderCount DESC
                LIMIT  {TopCount}";

            using (SQLiteConnection conn = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@From", _ToSQLiteDate(From));
                cmd.Parameters.AddWithValue("@To", _ToSQLiteDate(To));
                conn.Open();
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                    da.Fill(dt);
            }

            return dt;
        }

        
        public static DataTable GetTopCategories(DateTime From, DateTime To,
                                                 int TopCount = 3)
        {
            DataTable dt = new DataTable();

            string sql = $@"
                SELECT C.CategoryName,
                       COUNT(OD.ProductID) AS OrderCount
                FROM   OrderDetails OD
                       INNER JOIN Products   P ON P.ProductID  = OD.ProductID
                       INNER JOIN Categories C ON C.CategoryID = P.CategoryID
                       INNER JOIN Orders     O ON O.OrderID    = OD.OrderID
                WHERE  DATE(O.OrderDate) BETWEEN @From AND @To
                GROUP  BY C.CategoryName
                ORDER  BY OrderCount DESC
                LIMIT  {TopCount}";

            using (SQLiteConnection conn = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@From", _ToSQLiteDate(From));
                cmd.Parameters.AddWithValue("@To", _ToSQLiteDate(To));
                conn.Open();
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                    da.Fill(dt);
            }

            return dt;
        }

        
        public static DataTable GetTopExtras(DateTime From, DateTime To,
                                             int TopCount = 3)
        {
            DataTable dt = new DataTable();

            string sql = $@"
                SELECT E.ExtraName,
                       COUNT(OD.ExtraID) AS OrderCount
                FROM   OrderDetails OD
                       INNER JOIN Extras E ON E.ExtraID = OD.ExtraID
                       INNER JOIN Orders O ON O.OrderID = OD.OrderID
                WHERE  OD.ExtraID IS NOT NULL
                  AND  DATE(O.OrderDate) BETWEEN @From AND @To
                GROUP  BY E.ExtraName
                ORDER  BY OrderCount DESC
                LIMIT  {TopCount}";

            using (SQLiteConnection conn = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@From", _ToSQLiteDate(From));
                cmd.Parameters.AddWithValue("@To", _ToSQLiteDate(To));
                conn.Open();
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                    da.Fill(dt);
            }

            return dt;
        }

        
        public static DataTable GetOrdersByDateRange(DateTime From, DateTime To)
        {
            DataTable dt = new DataTable();

            string sql = @"
                SELECT O.OrderID,
                       O.UserID,
                       O.OrderDate,
                       O.TotalAmount
                FROM   Orders O
                WHERE  DATE(O.OrderDate) BETWEEN @From AND @To
                ORDER  BY O.OrderDate DESC";

            using (SQLiteConnection conn = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@From", _ToSQLiteDate(From));
                cmd.Parameters.AddWithValue("@To", _ToSQLiteDate(To));
                conn.Open();
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                    da.Fill(dt);
            }

            return dt;
        }
    }
}