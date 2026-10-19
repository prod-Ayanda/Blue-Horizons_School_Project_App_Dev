using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PROJECTT.Services;

namespace PROJECTT
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

            try
            {
                FileService.EnsureDataFolder();
                SeedService.SeedIfEmpty();

                Application.Run(new Welcome()); // Or whichever form loads first
            }
            catch (Exception ex)
            {
                // This will pop up a window showing the EXACT error message and line number before it dies
                MessageBox.Show("Fatal Crash Catch: " + ex.ToString(), "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


    }
}
