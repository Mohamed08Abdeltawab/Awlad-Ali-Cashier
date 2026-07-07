using AwladAli.Bill;
using AwladAli.Category;
using AwladAli.Category.Extra;
using AwladAli.Customer;
using AwladAli.GlobalClasses;
using AwladAli.Login;
using AwladAli.Session;
using AwladAli.User;
using AwladAli_Buisness; // Ensure your business core namespace is linked for clsGlobal
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

            // 1. Create a specialized global culture configuration framework layout
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-GB");

            // 2. Format configuration specifications rules definition
            culture.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
            culture.DateTimeFormat.LongTimePattern = "hh:mm:ss tt";

            // 3. Inject continuous execution culture patterns into running threads
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            bool keepRunning = true;

            // 4. Master loop lifecycle architecture to safely manage continuous application restarts via logouts
            while (keepRunning)
            {
                using (frmLogin loginForm = new frmLogin())
                {
                    // Evaluate if credentials security verification returned confirmation result safely
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        // Open the master dashboard window passing the authenticated user validation context
                        frmMain mainForm = new frmMain(loginForm);
                        Application.Run(mainForm);

                        // Evaluate logout transition flag state upon the layout frame closing process
                        if (clsGlobal.IsLoggingOut)
                        {
                            keepRunning = true;
                            clsGlobal.IsLoggingOut = false; // Purge layout configuration state immediately
                        }
                        else
                        {
                            keepRunning = false; // Hard loop termination context execution if close reason is manual X click
                        }
                    }
                    else
                    {
                        keepRunning = false; // Kill loop execution context if the login dialog frame was exited
                    }
                }
            }
        }
    }
}