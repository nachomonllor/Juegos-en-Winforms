using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

    public class Pac_Man // : Control
    {

        public Posicion _posicion;
        public Color _color;
      //  private Random _r;
        public DireccionDeMovimiento _direccionActual;

        public Pac_Man()
        {
          //  _r = new Random();
            _direccionActual = new DireccionDeMovimiento();
            this._direccionActual = DireccionDeMovimiento.Detenido;
            _posicion = new Posicion();
            _posicion.X = 10;   
            _posicion.Y = 14;  
            _color = Color.Yellow;
        }        

        public bool PuedeMover(int fila, int columna, int[,] tab)
        {
            if (fila < 0 || fila >= JuegoPacMan.FILAS || 
                columna < 0 || columna >= JuegoPacMan.COLUMNAS)
                return false;

            if (tab[fila, columna] == 1)
                return false;

            return true;
        }
         
        public void MoverPacman(int[,] tab)    
        {
            switch (this._direccionActual)
            {
                case DireccionDeMovimiento.Abajo:
                    if (PuedeMover(_posicion.Y + 1, _posicion.X, tab))
                    {
                        this._posicion.Y++;
                    }
                    break;
                case DireccionDeMovimiento.Arriba:
                    if (PuedeMover(_posicion.Y - 1, _posicion.X, tab))
                    {
                        this._posicion.Y--;
                    }
                    break;
                case DireccionDeMovimiento.Derecha:
                    if (PuedeMover(_posicion.Y, _posicion.X + 1, tab))
                    {
                        this._posicion.X++;
                    }
                    else
                    {
                        if (_posicion.Y >= 8 && _posicion.Y <= 12 &&
                            _posicion.X == JuegoPacMan.COLUMNAS - 1)
                        {
                            this._posicion.X = 0;
                        }
                    }
                    break;
                case DireccionDeMovimiento.Izquierda:
                    if (PuedeMover(_posicion.Y, _posicion.X - 1, tab))
                    {
                          this._posicion.X--;
                    }
                    else
                    {
                        if (_posicion.Y >= 8 && _posicion.Y <= 12 && _posicion.X == 0)
                        {
                            this._posicion.X = JuegoPacMan.COLUMNAS - 1;
                        }
                    }

                    break;
            }

        }

        public void DibujarPacman(PaintEventArgs e)
        {
            Rectangle rect;
            SolidBrush pincel;
            Graphics g = e.Graphics;
            Color color = this._color;
            int lado = 30;
            pincel = new SolidBrush(color);

            rect = new Rectangle(_posicion.X * lado,
                _posicion.Y * lado, lado - 1, lado - 1);

            g.DrawEllipse(new Pen(pincel), rect);
            g.FillEllipse(pincel, rect);

            //g.FillRectangle(pincel, rect);
        }//-----------------------------------------


    }

}


