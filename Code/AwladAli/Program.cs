using AwladAli.Bill;
using AwladAli.Category;
using AwladAli.Category.Extra;
using AwladAli.Login;
using AwladAli.Session;
using AwladAli.User;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AwladAli
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. إنشاء ثقافة جديدة (مثلاً العربية مصر أو الإنجليزية بريطانيا لأنهم بيدعموا dd-MM-yyyy)
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-GB");

            // 2. تخصيص تنسيق التاريخ والوقت داخل هذه الثقافة بالشكل الذي تريده تماماً
            culture.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
            culture.DateTimeFormat.LongTimePattern = "hh:mm:ss tt"; // تنسيق الوقت 12 ساعة (AM/PM)

            // 3. تطبيق الثقافة على البرنامج بالكامل (كل الـ Threads والواجهات)
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            // للمشاريع الحديثة في دوت نت يفضل إضافة هذا السطر أيضاً:
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            Application.Run(new frmLogin());
        }
    }
}
