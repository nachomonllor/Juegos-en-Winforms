using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Inicio
    {
        public static string Ruta = Application.StartupPath + "\\Tetris.xml";


        public static void Main(string[] vector)
        {
            try
            {
                Application.Run(new FrmPrincipal());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }

    }
}
