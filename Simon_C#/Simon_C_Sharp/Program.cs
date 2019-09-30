using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Simon_C_Sharp
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        /// 

        public static string _archivoPuntajes = "C:\\simon_C.xml";


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmPrincipal());
        }
    }
}
