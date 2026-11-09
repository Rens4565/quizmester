using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizmester
{
    // This class starts the application and stores session-wide user information.
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Enable the standard Windows Forms visual style before opening the first form.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Registration is the first screen shown when the application starts.
            Application.Run(new RegisterForm());

        }
        // These values are available to all forms while the application is running.
        public static string CurrentUser = "";
        public static bool IsAdmin = false;
    }
}
