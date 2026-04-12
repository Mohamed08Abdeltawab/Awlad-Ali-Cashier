using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class clsCryptography
{
    // ملاحظة: المفتاح لازم يكون 32 حرف لضمان تشفير AES-256 قوي
    private static readonly string _key = "A6Z8W9q2!xR_AwladAli_Project2026";
    // الـ IV لازم يكون 16 حرف
    private static readonly string _iv = "1234567890123456";

    // 1. دالة التشفير (تحويل كلمة السر لنص غير مفهوم)
    public static string Encrypt(string plainText)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(_key);
            aes.IV = Encoding.UTF8.GetBytes(_iv);

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }
    }

    // 2. دالة فك التشفير (ترجيع النص لأصله)
    public static string Decrypt(string cipherText)
    {
        try
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(_key);
                aes.IV = Encoding.UTF8.GetBytes(_iv);

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }
        catch
        {
            // في حالة لو النص المرسل مش مشفر أو المفتاح غلط
            return "Error: Invalid Cipher Text";
        }
    }
}