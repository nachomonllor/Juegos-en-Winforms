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
    public partial class FrmNaturePark : Form
    {
        private NaturePark _nPark;

        public FrmNaturePark ()
        {
            InitializeComponent();
            _nPark = new NaturePark();
            Resize += new EventHandler(FrmTetris_Resize);

            this.KeyPreview = true;
           _nPark.PreviewKeyDown+=new PreviewKeyDownEventHandler(_nPark_PreviewKeyDown);
           
            ClientSize = new Size(_nPark.FILAS * _nPark._lado, _nPark.COL * _nPark._lado);

            this.Controls.Add(_nPark);

            //// MessageBox.Show("FILAS: " + _tetris.FILAS * 20 + "COLS: " + _tetris.COL * 20);
            _nPark.Empezar();

        }


        public void _nPark_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    _nPark.MoverIzquierda();
                    break;
                case Keys.Right:
                    _nPark.MoverDerecha();
                    break;
                case Keys.Space :
                    _nPark.Caer();
                    break;
                case Keys.Up :
                    _nPark.Rotar();
                    break; 
            }

        }

        public void FrmTetris_Resize(Object sender, EventArgs e)
        {
            this._nPark.Size = ClientSize;
        }


    }//FIN CLASE


}
