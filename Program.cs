using System;
using System.Windows.Forms;
using Fracter2.View;


namespace HideousWorks.Fracter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new AppRunner() );
        }
    }
}
