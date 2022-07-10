using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace saft
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>


        public static bool argsProvided = false;
        public static string inFile = "";
        public static string streamFolder = "";
        [STAThread]
        static void Main(string[] args)
        {

            if (args.Length >= 2)
            {
                argsProvided = true;
                inFile = args[0];
                streamFolder = args[1];
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());
        }
    }
}
