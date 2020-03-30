using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarioMain.Utils;
using System.Windows.Forms;

namespace MarioMain
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApiHelper.InitializeClient();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
