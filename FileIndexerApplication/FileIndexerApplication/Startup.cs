namespace FileIndexerApplication
{
    using System;
    using System.Windows.Forms;

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

            if (args != null && args.Length > 0)
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
