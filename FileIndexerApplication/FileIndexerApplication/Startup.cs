using System;
using System.Windows.Forms;

namespace FileIndexerApplication
{
    static class Startup
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length > 0)
            {
                Application.Run(new FileIndexerMainForm(args[0]));
            }
            else
            {
                Application.Run(new FileIndexerMainForm());
            }
        }
    }
}
