using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Simon_C_Sharp
{
    public partial class FrmPrincipal : Form
    {
        private List<Estadisticas> _listaDeEstadisticas;

        public FrmPrincipal()
        {
            InitializeComponent();

            //InitializeComponent();
            //_listaDeEstadisticas = new List<Estadisticas>(Tetris.DeserializarListaEstadisticas(Inicio.Ruta));
            _listaDeEstadisticas = new List<Estadisticas>(FrmSimon.DeserializarListaEstadisticas(Program._archivoPuntajes));
 
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSimon frmSimon = new FrmSimon();
            frmSimon.ShowDialog();

        }

        private void estadisticasGeneralesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEstadisticas frmEstadisticas = new FrmEstadisticas(_listaDeEstadisticas);
            frmEstadisticas.ShowDialog();
        }

        private void frecuenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGraficosFrecuencias frmFrecuencias = new FrmGraficosFrecuencias();
            frmFrecuencias.ShowDialog();
        }

        private void puntosEnFuncionDelTiempoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPartidosTiempo frmPartidosTiempo = new FrmPartidosTiempo(_listaDeEstadisticas);
            frmPartidosTiempo.ShowDialog();
        }


       




    }
}
