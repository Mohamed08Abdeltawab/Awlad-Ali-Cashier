using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace AwladAli_Data
{
    public class clsProductSizeData
    {
        // 1. Get Size By ID (Updated to include IsNormalSize)
        public static bool GetSizeByID(int SizeID, ref int ProductID, ref string SizeName, ref decimal Price, ref bool IsNormalSize)
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
                                IsNormalSize = Convert.ToBoolean(reader["IsNormalSize"]);
                            }
                        }
                    }
                }
            }
            catch (Exception) { isFound = false; }
            return isFound;
        }

        // 2. Add New Size (Updated to include IsNormalSize)
        public static int AddNewSize(int ProductID, string SizeName, decimal Price, bool IsNormalSize)
        {
            int SizeID = -1;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"INSERT INTO ProductSizes (ProductID, SizeName, Price, IsNormalSize) 
                                     VALUES (@ProductID, @SizeName, @Price, @IsNormalSize);
                                     SELECT last_insert_rowid();";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductID", ProductID);
                        command.Parameters.AddWithValue("@SizeName", SizeName);
                        command.Parameters.AddWithValue("@Price", Price);
                        command.Parameters.AddWithValue("@IsNormalSize", IsNormalSize ? 1 : 0);

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

        // 3. Update Product Prices (النسخة النهائية اللي بتدعم الحجم العادي)
        public static bool UpdateProductPrices(int ProductID, bool IsNormalSize, string PriceNormal, string PriceS, string PriceM, string PriceL, string PriceXL)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // الخطوة 1: مسح كل الأحجام القديمة للمنتج
                        string deleteQuery = "DELETE FROM ProductSizes WHERE ProductID = @ProductID";
                        using (SQLiteCommand deleteCmd = new SQLiteCommand(deleteQuery, connection, transaction))
                        {
                            deleteCmd.Parameters.AddWithValue("@ProductID", ProductID);
                            deleteCmd.ExecuteNonQuery();
                        }

                        // الخطوة 2: إضافة السعر بناءً على اختيار الـ Normal Size
                        string insertQuery = "INSERT INTO ProductSizes (ProductID, SizeName, Price, IsNormalSize) VALUES (@ProductID, @SizeName, @Price, @IsNormalSize)";

                        if (IsNormalSize)
                        {
                            // حفظ حجم واحد فقط كـ Normal
                            if (!string.IsNullOrWhiteSpace(PriceNormal))
                            {
                                using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, connection, transaction))
                                {
                                    insertCmd.Parameters.AddWithValue("@ProductID", ProductID);
                                    insertCmd.Parameters.AddWithValue("@SizeName", "Normal");
                                    insertCmd.Parameters.AddWithValue("@Price", decimal.Parse(PriceNormal));
                                    insertCmd.Parameters.AddWithValue("@IsNormalSize", 1);
                                    insertCmd.ExecuteNonQuery();
                                }
                            }
                        }
                        else
                        {
                            // حفظ الأحجام المتعددة (S, M, L, XL)
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
                                        insertCmd.Parameters.AddWithValue("@IsNormalSize", 0);
                                        insertCmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
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
                    string query = "SELECT SizeName, Price, IsNormalSize FROM ProductSizes WHERE ProductID = @ProductID";
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


    }
}