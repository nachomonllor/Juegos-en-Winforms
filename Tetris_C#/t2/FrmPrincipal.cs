using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace WindowsFormsApplication1
{

    public partial class FrmPrincipal : Form
    {
        private List<Estadisticas> _listaDeEstadisticas;

        public FrmPrincipal()
        {
            InitializeComponent();

            _listaDeEstadisticas = new List<Estadisticas>(Tetris.DeserializarListaEstadisticas(Inicio.Ruta));

            //if (File.Exists(Ruta))
            //{
            //    _listaDeEstadisticas = DeserializarListaPuntajes(Ruta);
            //}
            //ASOCIO EL METODO AL EVENTO FORMCLOSING
            this.FormClosing += new FormClosingEventHandler(CerrandoAplicacion);
        }


        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTetris frmTetris = new FrmTetris();
            frmTetris.ShowDialog();
        }

        private void puntosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Puntuacion: \n1 linea = 10 puntos" +
                       "\n2 lineas = 40 puntos" +
                       "\n3 lineas = 90 puntos" +
                       "\n4 lineas = 160 puntos" +
                       "\n Caida libre = en funcion de la altura (1 pto. por cada celda)");
        }

        private void movimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Moviminetos: " +
                     "\nJ = izquierda" +
                     "\nK = caer" +
                     "\nL = derecha" +
                     "\nI = Rotar");
        }

        public void CerrandoAplicacion(Object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Seguro quiere salir?", "Cerrando Aplicacion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               // NO ==> ///// SerializarListaEstadisticas("C:\\Tetris.xml");
                this.Dispose();
            }
            else
            {
                e.Cancel = true;
            }
        }

        //private void estadisticasToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    FrmEstadisticas frmEstadisticas = new FrmEstadisticas(_listaDeEstadisticas);
            
        //    //frmEstadisticas.ListaDeEstadisticas = new List<Estadisticas>(_listaDeEstadisticas);

        //    frmEstadisticas.ShowDialog();
        //}

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 sobre = new AboutBox1();
           
            sobre.ShowDialog();
        }

        private void estadisticasGeneralesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEstadisticas frmEstadisticas = new FrmEstadisticas(_listaDeEstadisticas);

            //frmEstadisticas.ListaDeEstadisticas = new List<Estadisticas>(_listaDeEstadisticas);

            frmEstadisticas.ShowDialog();
        }

        private void puntosEnFuncionDelTiempoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGraficos frmGraficos = new FrmGraficos(_listaDeEstadisticas);
            frmGraficos.ShowDialog();

        }





    }

}
