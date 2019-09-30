using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CubeCrash_Celdas
{
    public partial class Form1 : Form
    {

        private Tablero _tablero;
        private int _filas = 12;
        private int _columnas = 13;
        private int TAM = 40;
        private Color[] _coloresNormales;
        private Color[] _coloresSeleccionados;


        public Form1()
        {
            InitializeComponent();
            _coloresNormales = new Color[] { Color.DarkRed, Color.Green, Color.Blue, Color.DarkMagenta, Color.Teal };
            //VECTOR PARALELO AL DE COLORES NORMALES
            _coloresSeleccionados = new Color[] { Color.Red, Color.LightGreen, Color.Cyan, Color.Magenta, Color.MediumTurquoise };

            _tablero = new Tablero(_filas, _columnas, _coloresNormales.Length - 2);
            _tablero.Inicializar();

            this.MouseDown += new MouseEventHandler(Mouse_Down);
            this.MouseMove += new MouseEventHandler(Form1_MouseMove);

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DibujarTablero();
        }

        public void DibujarCuadrado(Rectangle rect, Celda celda, bool estaSeleccionado)
        {
            Color color = Color.Black;
            Graphics gr = this.CreateGraphics();

            if (celda != null)
            {
                if (!estaSeleccionado)
                    color = _coloresNormales[celda.IndiceColor];
                else
                    color = _coloresSeleccionados[celda.IndiceColor];
            }

            SolidBrush pincel = new SolidBrush(color);
            gr.FillRectangle(pincel, rect);

            pincel.Dispose();
            gr.Dispose();

        }  //---------------------------------------------------------------
           

        public void DibujarTablero() //------------------------------
        {
            int x = 0;
            int y = 0;

            List<Celda> celdas = _tablero.GrupoCeldasSeleccionadas;

            for (int i = 0; i < _filas; i++)
            {
                for (int j = 0; j < _columnas; j++)
                {
                    Celda celda = _tablero.Matriz[i, j];
                    Rectangle rect = new Rectangle(x, y, TAM - 2, TAM - 2);
                    //  if (celda != null)
                    //{
                    if (celdas.Contains(celda))
                        DibujarCuadrado(rect, celda, true);
   
                    else
                        DibujarCuadrado(rect, celda, false);
                    //}
                    //   else
                    //{
                    // DibujarCuadrado(rect, 0, false, true);
                    //     DibujarCuadrado(rect, celda, false);
                    //}
                    x += TAM;
                }

                y += TAM;
                x = 0;
            }
        } //-------------------------------------------

        public void Form1_MouseMove(Object sender, MouseEventArgs e)
        {
            if (e.X < 0 || e.X >= TAM * _columnas || e.Y < 0 || e.Y >= TAM * _filas) return;

            int fila = (int)e.Y / TAM;
            int columna = (int)e.X / TAM;

            Celda celdaActual = _tablero.Matriz[fila, columna];

            if (celdaActual != null)
            {
                _tablero.GrupoCeldasSeleccionadas.Clear();
                _tablero.Seleccionar(celdaActual);
            }

            DibujarTablero(); 
        }//--------------------------------------------


        public void Mouse_Down(Object sender, MouseEventArgs e)
        {
            if (e.X < 0 || e.X >= TAM * _columnas || e.Y < 0 || e.Y >= TAM * _filas) return;

            int fila = (int)e.Y / TAM;
            int columna = (int)e.X / TAM;

            List<Celda> selected = this._tablero.GrupoCeldasSeleccionadas;
            Celda currentCell = _tablero.Matriz[fila, columna];
            if (currentCell != null)
            {
                if (selected.Contains(currentCell))
                {
                    this._tablero.Eliminar(selected);
                }
                else
                {
                    _tablero.GrupoCeldasSeleccionadas.Clear();
                    _tablero.Seleccionar(currentCell);
                }
            }
            else { }

            DibujarTablero();   

            //if (this._tablero.JuegoTerminado())
            //{
            //}

        }//----------------------------------------------------------




    }
}



//public void DibujarCuadrado(int x, int y, int i, int j, bool estaSeleccionado)
//{
//    Color color;
//    Graphics gr = this.CreateGraphics();

//    Rectangle rect = new Rectangle(x, y, TAM - 2, TAM - 2);

//    int indice = _tablero.Matriz[i, j].IndiceColor;
//    if (!estaSeleccionado)
//    {
//        color = _coloresNormales[indice];
//    }
//    else
//    {
//        color = _coloresSeleccionados[indice];
//    }

//    SolidBrush pincel = new SolidBrush(color);
//    gr.FillRectangle(pincel, rect);

//    pincel.Dispose();
//    gr.Dispose();

//}

//public void DibujarCuadrado(Rectangle rect, int indice, bool estaSeleccionado, bool esCeldaNula)
//{
//    Color color;
//    Graphics gr = this.CreateGraphics();

//    if (!esCeldaNula)
//    {
//        if (!estaSeleccionado)
//            color = _coloresNormales[indice];
//        else
//            color = _coloresSeleccionados[indice];
//    }
//    else
//    {
//        color = Color.Black;
//    }
//    SolidBrush pincel = new SolidBrush(color);
//    gr.FillRectangle(pincel, rect);

//    pincel.Dispose();
//    gr.Dispose();
//}



