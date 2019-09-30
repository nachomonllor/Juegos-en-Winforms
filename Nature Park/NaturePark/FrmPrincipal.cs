using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NaturePark
{
    public partial class FrmPrincipal : Form
    {
        private List<Estadisticas> _listaDeEstadisticas;

        public FrmPrincipal()
        {
            InitializeComponent();

            this._listaDeEstadisticas = new List<Estadisticas>(NaturePark.DeserializarListaDeEstadisticas(Inicio.Ruta)  );

            this.FormClosing+= new FormClosingEventHandler(CerrandoAplicacion);

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNaturePark frmNaturePark = new FrmNaturePark();
            frmNaturePark.ShowDialog();
        }

        private void puntosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void movimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Moviminetos: " +
                     "\nflecha izquierda = izquierda" +
                     "\nbarra espaciadora = caer" +
                     "\nflecha derecha = derecha" +
                     "\nflecha arriba = Rotar");
        }

        public void CerrandoAplicacion(Object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Seguro quiere salir ?", "Cerrando Aplicacion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 sobre = new AboutBox1();
            sobre.ShowDialog();
        }

        private void estadisticasGeneralesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEstadisticas frmEstadisticas = new FrmEstadisticas(_listaDeEstadisticas);
            frmEstadisticas.ShowDialog();
        }

        private void PuntosEnFuncionDelTiempo_Click(object sender, EventArgs e)
        {
            FrmGraficos frmGraficos = new FrmGraficos(_listaDeEstadisticas);
            frmGraficos.ShowDialog();
        }

        












    }
}
