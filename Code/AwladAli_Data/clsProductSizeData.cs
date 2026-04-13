using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace AwladAli_Data
{
    public class clsProductSizeData
    {
        // 1. Find Size by ID
        public static bool GetSizeByID(int SizeID, ref int ProductID, ref string SizeName, ref decimal Price)
        {
            bool isFound = false;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM ProductSizes WHERE SizeID = @SizeID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SizeID", SizeID);
                        connection.Open();

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                ProductID = Convert.ToInt32(reader["ProductID"]);
                                SizeName = (string)reader["SizeName"];
                                Price = Convert.ToDecimal(reader["Price"]);
                            }
                        }
                    }
                }
            }
            catch (Exception) { isFound = false; }

            return isFound;
        }

        // 2. Add New Size/Price
        public static int AddNewSize(int ProductID, string SizeName, decimal Price)
        {
            int SizeID = -1;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"INSERT INTO ProductSizes (ProductID, SizeName, Price) 
                                     VALUES (@ProductID, @SizeName, @Price);
                                     SELECT last_insert_rowid();";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductID", ProductID);
                        command.Parameters.AddWithValue("@SizeName", SizeName);
                        command.Parameters.AddWithValue("@Price", Price);

                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            SizeID = insertedID;
                        }
                    }
                }
            }
            catch (Exception) { }

            return SizeID;
        }

        // 3. Update Size/Price
        public static bool UpdateSize(int SizeID, int ProductID, string SizeName, decimal Price)
        {
            int rowsAffected = 0;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"UPDATE ProductSizes 
                                     SET ProductID = @ProductID, 
                                         SizeName = @SizeName, 
                                         Price = @Price 
                                     WHERE SizeID = @SizeID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SizeID", SizeID);
                        command.Parameters.AddWithValue("@ProductID", ProductID);
                        command.Parameters.AddWithValue("@SizeName", SizeName);
                        command.Parameters.AddWithValue("@Price", Price);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception) { return false; }

            return (rowsAffected > 0);
        }

        // 4. Delete Size
        public static bool DeleteSize(int SizeID)
        {
            int rowsAffected = 0;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "DELETE FROM ProductSizes WHERE SizeID = @SizeID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SizeID", SizeID);
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception) { }

            return (rowsAffected > 0);
        }

        // 5. Get All Sizes for a Specific Product (Very important for UI)
        public static DataTable GetProductSizes(int ProductID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM ProductSizes WHERE ProductID = @ProductID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductID", ProductID);
                        connection.Open();
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows) dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception) { }

            return dt;
        }


        public static DataTable GetPricesByProductID(int ProductID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    // بنجيب اسم المقاس والسعر للمنتج ده
                    string query = "SELECT SizeName, Price FROM ProductSizes WHERE ProductID = @ProductID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductID", ProductID);
                        connection.Open();

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // ممكن تسجل الخطأ هنا لو حبيت
            }

            return dt;
        }


        public static bool UpdateProductPrices(int ProductID, string PriceS, string PriceM, string PriceL, string PriceXL)
        {
            int rowsAffected = 0;

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();
                // نستخدم Transaction لضمان سلامة البيانات
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // الخطوة 1: مسح كل الأسعار القديمة للمنتج ده
                        string deleteQuery = "DELETE FROM ProductSizes WHERE ProductID = @ProductID";
                        using (SQLiteCommand deleteCmd = new SQLiteCommand(deleteQuery, connection, transaction))
                        {
                            deleteCmd.Parameters.AddWithValue("@ProductID", ProductID);
                            deleteCmd.ExecuteNonQuery();
                        }

                        // الخطوة 2: إضافة الأسعار الجديدة (فقط لو الخانة مش فاضية)
                        string insertQuery = "INSERT INTO ProductSizes (ProductID, SizeName, Price) VALUES (@ProductID, @SizeName, @Price)";

                        // هنحط الأسعار في Dictionary عشان نلف عليهم بسهولة
                        var prices = new Dictionary<string, string> {
                    { "S", PriceS }, { "M", PriceM }, { "L", PriceL }, { "XL", PriceXL }
                };

                        foreach (var item in prices)
                        {
                            if (!string.IsNullOrWhiteSpace(item.Value))
                            {
                                using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, connection, transaction))
                                {
                                    insertCmd.Parameters.AddWithValue("@ProductID", ProductID);
                                    insertCmd.Parameters.AddWithValue("@SizeName", item.Key);
                                    insertCmd.Parameters.AddWithValue("@Price", decimal.Parse(item.Value));
                                    rowsAffected += insertCmd.ExecuteNonQuery();
                                }
                            }
                        }

                        transaction.Commit(); // تنفيذ كل العمليات بنجاح
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback(); // تراجع عن كل شيء في حالة حدوث أي خطأ
                        return false;
                    }
                }
            }
        }
    }
}