using AwladAli_Buisness;
using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32; // Required for Registry

namespace AwladAli.GlobalClasses
{
    internal static class clsGlobal
    {
        public static clsUser CurrentUser;
        public static int CurrentSessionID = -1;

        // Registry Path for storing credentials
        private static string _RegistryPath = @"HKEY_CURRENT_USER\Software\AwladAli_Cashier";

        // 1. Hashing Password

        // 2. Remember Credentials in Registry + Log to Event Log
        public static bool RememberUsernameAndPassword(string Username)
        {
            try
            {
                if (string.IsNullOrEmpty(Username))
                {
                    // If user unchecked "Remember Me", clear registry values
                    Registry.SetValue(_RegistryPath, "Username", "", RegistryValueKind.String);

                    LogException("User credentials cleared from Registry.", EventLogEntryType.Information);
                    return true;
                }

                // Save to Registry
                Registry.SetValue(_RegistryPath, "Username", Username, RegistryValueKind.String);

                // Log this action to Windows Event Log
                LogException($"Credentials for user [{Username}] saved to Registry successfully.", EventLogEntryType.Information);

                return true;
            }
            catch (Exception ex)
            {
                LogException($"Registry Write Error: {ex.Message}", EventLogEntryType.Error);
                return false;
            }
        }

        // 3. Get Credentials from Registry
        public static bool GetStoredCredential(ref string Username)
        {
            try
            {
                string storedUser = Registry.GetValue(_RegistryPath, "Username", null) as string;

                if (!string.IsNullOrEmpty(storedUser))
                {
                    Username = storedUser;
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogException($"Registry Read Error: {ex.Message}", EventLogEntryType.Error);
            }
            return false;
        }

        // 4. Windows Event Log (Centralized Logging)
        public static void LogException(string message, EventLogEntryType type)
        {
            // نستخدم المصدر "Application" وهو متاح لأي برنامج دون صلاحيات أدمن
            string sourceName = "Application";

            try
            {
                // نكتب مباشرة دون محاولة CreateEventSource
                EventLog.WriteEntry(sourceName, "AwladAli_App: " + message, type);
            }
            catch
            {
                // إذا فشل الويندوز تماماً، نلجأ لخطة بديلة مثل حفظها في ملف بسيط
            }
        }


        // 5. Common Message Boxes (UI Consistency)
        public static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowInfoMessage(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

}