using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace NaturePark
{

    public struct Posicion
    {
        public int X;
        public int Y;
    }

    public class NaturePark : Control
    {


        private Posicion _posicion;
        private Random _r;

        public int FILAS = 8, COL = 12;
        private int[,] _tablero;
        private System.Windows.Forms.Timer _temporizador;
        public int _lado = 40;

        private int _indiceFigura;
        private int[,] _figuraActual;
        private Pieza _piezaSeleccionada;
        private int _celdasEliminadas;


        private int[] _celdasEliminadasVector = { 200,  350, 500, 600, 750, 1500, 2000, 2400, 2800, 3000 };
        private int[] _intervalosTiempo =       {1800, 1100, 900, 550, 400,  350,  300,  200,  160,   50 };
        private int _indiceTiempos = 0;

        public List<Estadisticas> _listaDeEstadisticas;

        private int[,] _tabAux =
        {
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,2,0,0,0},
            {0,0,1,0,0,0},
            {0,0,2,0,3,0},
            {0,0,1,0,5,0},
            {0,1,5,0,6,0},
            {0,5,2,5,2,0},
            {0,5,4,2,4,2},
        };

        void CargarTablero()
        {
            for (int i = 0; i < _tabAux.GetLength(0); i++)
            {
                for (int j = 0; j < _tabAux.GetLength(1); j++)
                {
                    _tablero[j, i] = _tabAux[i, j];
                }
            }
        }



        public NaturePark()
        {
            if (File.Exists(Inicio.Ruta))
            {
                _listaDeEstadisticas = NaturePark.DeserializarListaDeEstadisticas(Inicio.Ruta);
            }
            else
            {
                _listaDeEstadisticas = new List<Estadisticas>();
            }

            this._piezaSeleccionada = new Pieza();
            _temporizador = new System.Windows.Forms.Timer();
            _tablero = new int[FILAS, COL];
            this._celdasEliminadas = 0;

            ////////////////////////////////
            //CargarTablero();
            ////////////////////////////////

            _r = new Random();
            _posicion = new Posicion();
            _posicion.X = 3;
            _posicion.Y = 3;

            _temporizador.Tick += new EventHandler(Temporizador_Tick);
            _temporizador.Interval = 1000;

            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);

        }

        public void Temporizador_Tick(Object sender, EventArgs e)
        {
            MoverAbajo();

            if (!VerificarColision(_figuraActual, _posicion.X, _posicion.Y))
            {
                Detener();
                // /////////////////////AGREGO LAS ESTADISTICAS DE ESTE PARTIDO A LA LISTA DE ESTADISTICAS
                _listaDeEstadisticas.Add(new Estadisticas(this._celdasEliminadas, DateTime.Now));
                    SerializarListaEstadisticas(Inicio.Ruta);
                /////////////////////////////
                    MessageBox.Show("Perdiste, no hay mas espacio");
                //if (_puntos < 1500)
                //    MessageBox.Show("Perdiste, no hay mas espacio\nPuntos = " + _puntos + " (un poco flojo)");
                //if (_puntos >= 1500 && _puntos < 9000)
                //    MessageBox.Show("Perdiste, no hay mas espacio\nPuntos = " + _puntos + " (jugas Tetris bastante bien)");
                //if (_puntos >= 9000 && _puntos < 40000)
                //    MessageBox.Show("Perdiste, no hay mas espacio\nPuntos = " + _puntos + " (jugas Tetris epselente)");
                //else if (_puntos >= 40000)
                //    MessageBox.Show("Perdiste, no hay mas espacio\nPuntos = " + _puntos + " (Tetris Master, jugas como un chino nerd sin amigos)");
            }
            Refresh();

        } /////////////////fin funcion /////////////

        public void Detener()
        {
            _temporizador.Stop();
        }

        private void FijarPieza()
        {
            for (int i = 0; i < _figuraActual.GetLength(0); i++)
            {
                for (int j = 0; j < _figuraActual.GetLength(1); j++)
                {
                    if (_figuraActual[i, j] != 0)
                    {
                        _tablero[_posicion.X + i, _posicion.Y + j] = _figuraActual[i, j];
                    }
                }
            }
        }

        public void Caer()
        {
            while (MoverAbajo()) ;
            Refresh();
        }

        //BAJAR CELDAS ARTIFICIALMENTE, ARTIFICIOSAMENTE =========> CORREGIR !
        public void BajarCeldas(int[,] tab)
        {
            for (int col = COL - 1; col >= 0; col--)
            {
                for (int fila = 0; fila < FILAS; fila++)
                {
                    if (tab[fila, col] != 0)
                    {
                        while (PuedeBajar(tab, fila, col))
                        {
                            tab[fila, col + 1] = tab[fila, col];
                            tab[fila, col] = 0;
                            col++;
                        }
                    }
                    // Refresh();
                    //Thread.Sleep(100);               
                }
            }
            Refresh();

        }

        private bool PuedeBajar(int[,] tab, int fila, int col)
        {
            if ((col >= 0 && col < COL - 1) && tab[fila, col + 1] == 0)
                return true;
            return false;
        }
        /***************************************************************/



        public void ObtenerFigura()
        {
            double frecuencia = _r.NextDouble();


            if (frecuencia < 0.9)//SI LA FRECUENCIA ES MENOR A 0.9 BUSCAR NUEVA PIEZA
            {
                _indiceFigura = _r.Next(0, 10);
            }

            _indiceFigura = _r.Next(0, 15); //BUSCAMOS EL INDICE DE LA PIEZA
            _figuraActual = _piezaSeleccionada.ObtenerPieza(_indiceFigura);
        }

        public void Rotar()
        {
            this._piezaSeleccionada._indiceRotacion++; //SE POSICIONA EN FIGURA ROTADA QUE LE SIGUA A LA ACTUAL
            _figuraActual = _piezaSeleccionada.ObtenerPieza(_indiceFigura);

            Refresh();
        }



        public bool MoverAbajo()
        {
            //SI APRUEBA EL MOVIMIENTO MUEVE ABAJO
            if (VerificarColision(_figuraActual, _posicion.X, _posicion.Y + 1))
            {
                _posicion.Y++;
                return true; //CORTO LA FUNCION
            }
            //SI NO APRUEBA:
            /* 1. */
            FijarPieza();
            /* 2. */



            if (_indiceFigura == 12)
            {
                _tablero[_posicion.X, _posicion.Y] = 0;

                int px = _posicion.X;
                int py = _posicion.Y + 1;

                if (py < COL)
                {
                    //                 MessageBox.Show("Indice = " + _indiceFigura + " X = " + px +
                    //                  " Y = " + py + " Color = " + _tablero[px, py]);
                    // EliminarColor(_tablero[px, py]);
                    // private void EliminarColor(int color)


                    EliminarColor(_tablero[px, py]);

                    //}
                }

                Refresh();
            }

            if (_indiceFigura == 13)
            {
                EliminarColumna();
                Refresh();
            }

            if (_indiceFigura == 14)
            {
                int px = _posicion.X;
                int py = _posicion.Y;

                EliminarAdyacentes(px, py);

                Refresh();
            }



            BajarCeldas(_tablero);
            // Thread.Sleep(300);
            // Refresh();
            while (EliminarGruposCompletos())
            { /* 3. */
                BajarCeldas(_tablero);
                Thread.Sleep(300);
                Refresh();
            }
            //BajarCeldas(_tablero);

            Empezar();  //OBTIENE EL NUEVO INDICE
            return false;
        }


        public void MoverDerecha()
        {
            if (VerificarColision(_figuraActual, _posicion.X + 1, _posicion.Y))
            {
                _posicion.X++;
            }
            Refresh();
        }

        public void MoverIzquierda()
        {
            if (VerificarColision(_figuraActual, _posicion.X - 1, _posicion.Y))
            {
                _posicion.X--;
            }
            Refresh();
        }


        private bool VerificarColision(int[,] fig, int x, int y)
        {
            //PARA APROBAR O NO UN MOVIMIENTO
            for (int i = 0; i < _figuraActual.GetLength(0); i++)
            {
                for (int j = 0; j < _figuraActual.GetLength(1); j++)
                {
                    int rx = i + x;
                    int ry = j + y;

                    //1. QUE LA CELDA DE LA FIGURA CAIGA AFUERA DE LA MATRIZ 
                    if ((rx < 0 || rx >= FILAS || ry < 0 || ry >= COL) && fig[i, j] != 0)
                    { return false; }
                    //2. QUE LA CELDA CAIGA ADENTRO PERO:
                    if (!(rx < 0 || rx >= FILAS || ry < 0 || ry >= COL))
                    {
                        //QUE LA CELDA DE LA FIGURA ESTE OCUPADA 
                        //Y EN LA MISMA POSICION QUE LA CELDA DEL TABLERO TAMBIEN OCUPADA
                        if (_tablero[rx, ry] != 0 && fig[i, j] != 0)
                            return false;
                    }
                }
            }
            return true;
        }


        public bool EsCeldaValida(int fila, int columna)
        {
            if (fila < 0 || fila >= FILAS || columna < 0 || columna >= COL)
            {
                return false;
            }
            if (_tablero[fila, columna] == 0)
            {
                return false;
            }
            if (_tablero[fila, columna] == -1)
            {
                return false;
            }

            return true;
        }


        public bool EliminarGruposCompletos()
        {
            bool elimino = false;

            List<Celda> celdasABorrar = new List<Celda>();

            for (int i = 0; i < FILAS; i++)
            {
                for (int j = 0; j < COL; j++)
                {
                    Celda c = new Celda(i, j, _tablero[i, j]);
                    List<Celda> vecinas = ObtenerCeldasVecinas(c);

                    //PASO LA CELDA ACTUAL Y A SUS VECINAS A LA LISTA A BORRAR
                    for (int k = 0; k < vecinas.Count; k++)
                    {
                        if (!celdasABorrar.Contains(vecinas[k]))
                        {
                            celdasABorrar.Add(vecinas[k]);
                        }
                    }
                }
            }

            if (celdasABorrar.Count > 2) elimino = true;

            //UNA VEZ QUE OBTENGO LA LISTA DE CELDAS A BORRAR LAS BORRO DEL TABLERO
            foreach (Celda unaCelda in celdasABorrar)
            {
                _tablero[unaCelda.Fila, unaCelda.Columna] = 0;
            }

            //EL DISTINC NO VA A HACER FALTA YA QUE CELDAS A BORRAR SE COARGA SI NO CONTIENE vecinas[k]
            //  List<Celda> celdas = listaRetorno.Distinct(new MiComparador()).ToList();

            this._celdasEliminadas += celdasABorrar.Count;

            //    MessageBox.Show("Celdas eliminadas = " + celdasABorrar.Count);

            return elimino;

        }


        private List<Celda> ObtenerCeldasVecinas(Celda c)
        {

            List<Celda> celdasABorrar = new List<Celda>();


            int fila = c.Fila;
            int columna = c.Columna;


            //////////////////////---------////////
            ////-------NORTE Y SUR---------//////////
            //////////////////////---------////////
            List<Celda> lista = new List<Celda>();
            lista.Add(c);

            //ME FIJO HACIA EL NORTE
            if (EsCeldaValida(fila - 1, columna))
            {    //COMPARACION DEL COLOR CON LA CELDA ACTUAL
                if (_tablero[fila, columna] == _tablero[fila - 1, columna])
                {
                    lista.Add(new Celda(fila - 1, columna, _tablero[fila - 1, columna]));
                }
            }
            ///Y LO CONECTO CON EL SUR
            if (EsCeldaValida(fila + 1, columna))
            {
                if (_tablero[fila, columna] == _tablero[fila + 1, columna])
                {
                    lista.Add(new Celda(fila + 1, columna, _tablero[fila + 1, columna]));
                }
            }

            //ENTONCES COMPRUEBO SI HAY MAS DE 2
            //SI HAY MAS DE 2 LAS AGREGO A LA LISTA DE CELDAS A BORRAR
            if (lista.Count > 2)
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    celdasABorrar.Add(lista[i]);
                }

            }

            ///////////////////////////////////
            //////OESTE Y ESTE////////////////
            ///////////////////////////////////
            List<Celda> listaOesteEste = new List<Celda>();
            listaOesteEste.Add(c);

            /////----------ME FIJO HACIA EL OESTE------------
            if (EsCeldaValida(fila, columna - 1))
            {
                if (_tablero[fila, columna] == _tablero[fila, columna - 1])
                {
                    listaOesteEste.Add(new Celda(fila, columna - 1, _tablero[fila, columna - 1]));
                }
            }

            /////--------------ME FIJO HACIA EL ESTE---------------
            if (EsCeldaValida(fila, columna + 1))
            {
                if (_tablero[fila, columna] == _tablero[fila, columna + 1])
                {
                    listaOesteEste.Add(new Celda(fila, columna + 1, _tablero[fila, columna + 1]));
                }
            }

            if (listaOesteEste.Count > 2)
            {
                for (int i = 0; i < listaOesteEste.Count; i++)
                {
                    celdasABorrar.Add(listaOesteEste[i]);
                }
            }

            //////////////////////////////////////
            ///------NOROESTE - SURESTE-----------
            //////////////////////////////////////
            List<Celda> listaNorOesteSurEste = new List<Celda>();
            listaNorOesteSurEste.Add(c);
            //ME FIJO HACIA EL NOROESTE
            if (EsCeldaValida(fila - 1, columna - 1))
            {
                if (_tablero[fila, columna] == _tablero[fila - 1, columna - 1])
                {
                    listaNorOesteSurEste.Add(new Celda(fila - 1, columna - 1, _tablero[fila - 1, columna - 1]));
                }
            }

            //ME FIJO HACIA EL SURESTE
            if (EsCeldaValida(fila + 1, columna + 1))
            {
                if (_tablero[fila, columna] == _tablero[fila + 1, columna + 1])
                {
                    listaNorOesteSurEste.Add(new Celda(fila + 1, columna + 1, _tablero[fila + 1, columna + 1]));
                }
            }

            if (listaNorOesteSurEste.Count > 2)
            {
                for (int i = 0; i < listaNorOesteSurEste.Count; i++)
                {
                    celdasABorrar.Add(listaNorOesteSurEste[i]);
                }
            }

            //// /////////////////////////////////////
            //----------SUROESTE - NORESTE
            //////////////////////////////////////////
            List<Celda> listaSurOesteNorEste = new List<Celda>();
            listaSurOesteNorEste.Add(c);

            //ME FIJO HACIA EL SUROESTE
            if (EsCeldaValida(fila + 1, columna - 1))
            {
                if (_tablero[fila, columna] == _tablero[fila + 1, columna - 1])
                {
                    listaSurOesteNorEste.Add(new Celda(fila + 1, columna - 1, _tablero[fila + 1, columna - 1]));
                }
            }

            //ME FIJO HACIA EL NORESTE
            if (EsCeldaValida(fila - 1, columna + 1))
            {
                if (_tablero[fila, columna] == _tablero[fila - 1, columna + 1])
                {
                    listaSurOesteNorEste.Add(new Celda(fila - 1, columna + 1, _tablero[fila - 1, columna + 1]));
                }
            }


            if (listaSurOesteNorEste.Count > 2)
            {
                for (int i = 0; i < listaSurOesteNorEste.Count; i++)
                {
                    celdasABorrar.Add(listaSurOesteNorEste[i]);
                }
            }

            //SE BORRAN CUANDO TENGO TODAS LAS QUE TENGO QUE BORRAR REUNIDAS,
            //YA QUE SI POR EJ BORRO UNA FILA, SI POR EJEMPLO ESA FILA FORMARA UNA CRUZ
            //SI YO BORRO LA FILA A LA COLUMNA LE QUEDAN 2 Y NO PODRIA BORRARSE DESPUES
            return celdasABorrar;

        }



        public void Empezar()
        {

            ObtenerFigura(); //CARGO LA FIGURA A LA MATRIZ CON LA LISTA
            _posicion.X = 3; // SETEO LA POSICION INICIAL DE LA PIEZA
            _posicion.Y = 0;

            // _temporizador.Interval = 1800;
            //  _temporizador.Start(); //INICIO EL TEMP


            _temporizador.Interval = _intervalosTiempo[_indiceTiempos];

            if (_indiceTiempos + 1 < this._celdasEliminadasVector.Length
                && (_celdasEliminadas > this._celdasEliminadasVector[_indiceTiempos]))
            {
                _indiceTiempos++;
            }

            _temporizador.Start(); //INICIO EL TEMP

        }


        public void DibujarCuadricula(PaintEventArgs e)
        {
            // int lado = 50;
            Rectangle rect;
            SolidBrush pincel = new SolidBrush(Color.Black);
            Graphics gr = e.Graphics;

            for (int i = 0; i < FILAS; i++)
            {
                for (int j = 0; j < COL; j++)
                {
                    rect = new Rectangle(i * _lado,
                        j * _lado, _lado - 1, _lado - 1);
                    gr.FillRectangle(pincel, rect);
                }
            }


            //MOSTRAR PUNTAJE ACUMULADO
            FontFamily tipografia = new FontFamily("Times New Roman");
            Font font = new Font(tipografia, 15, FontStyle.Bold, GraphicsUnit.Pixel);
            PointF pointF = new PointF(Width - 60, 0);
            SolidBrush solidBrush = new SolidBrush(Color.White);
            gr.DrawString(this._celdasEliminadas.ToString(), font, solidBrush, pointF);
            //  gr.DrawString(this._lineasCompletas.ToString(), font, solidBrush, new Point(Width - 60, 20));
            //  gr.DrawString(this._intervalosTiempo[_indiceTiempos].ToString(), font, solidBrush, new Point(Width - 60, 40));

        }



        public void DibujarTablero(PaintEventArgs e)
        {
            //  int lado = 50;
            Rectangle rect;
            SolidBrush pincel;// = new SolidBrush(_color [_indiceFigura]);
            Graphics gr = e.Graphics;
            Color colorCelda = new Color();

            for (int i = 0; i < FILAS; i++)
            {
                for (int j = 0; j < COL; j++)
                {
                    if (_tablero[i, j] != 0)
                    {
                        rect = new Rectangle(i * _lado,
                              j * _lado, _lado - 1, _lado - 1);

                        if (_tablero[i, j] == 1)
                            colorCelda = Color.Blue;
                        if (_tablero[i, j] == 2)
                            colorCelda = Color.Green;
                        if (_tablero[i, j] == 3)
                            colorCelda = Color.Yellow;
                        if (_tablero[i, j] == 4)
                            colorCelda = Color.Red;
                        if (_tablero[i, j] == 5)
                            colorCelda = Color.Violet;
                        if (_tablero[i, j] == 6)
                            colorCelda = Color.Cyan;
                        if (_tablero[i, j] == 7)
                            colorCelda = Color.DarkOrange;



                        if (_tablero[i, j] == -1)
                            colorCelda = Color.LightGray;
                        if (_tablero[i, j] == -2) //BOMBA DE COLOR
                            colorCelda = Color.Aqua;
                        if (_tablero[i, j] == -3)
                            colorCelda = Color.YellowGreen;
                        if (_tablero[i, j] == -4)
                            colorCelda = Color.Coral;

                        pincel = new SolidBrush(colorCelda);

                        if (_tablero[i, j] > 0)
                        {
                            gr.FillRectangle(pincel, rect);
                        }
                        else
                        {
                            gr.DrawEllipse(new Pen(pincel), rect);
                            gr.FillEllipse(pincel, rect);
                        }



                    }
                }
            }

        }



        public void DibujarPieza(PaintEventArgs e)
        {
            Rectangle rect;
            Graphics gr = e.Graphics;
            SolidBrush pincel;
            Color colorCelda = new Color();
            //int lado=50;

            for (int i = 0; i < _figuraActual.GetLength(0); i++)
            {
                for (int j = 0; j < _figuraActual.GetLength(1); j++)
                {
                    if (_figuraActual[i, j] != 0)
                    {
                        rect = new Rectangle((_posicion.X + i) * _lado,
                            (_posicion.Y + j) * _lado, _lado - 1, _lado - 1);

                        if (_figuraActual[i, j] == 1)
                            colorCelda = Color.Blue;
                        if (_figuraActual[i, j] == 2)
                            colorCelda = Color.Green;
                        if (_figuraActual[i, j] == 3)
                            colorCelda = Color.Yellow;
                        if (_figuraActual[i, j] == 4)
                            colorCelda = Color.Red;
                        if (_figuraActual[i, j] == 5)
                            colorCelda = Color.Violet;
                        if (_figuraActual[i, j] == 6)
                            colorCelda = Color.Cyan;
                        if (_figuraActual[i, j] == 7)
                            colorCelda = Color.Orange;


                        if (_figuraActual[i, j] == -1)
                            colorCelda = Color.LightGray;
                        if (_figuraActual[i, j] == -2) //BOMBA DE COLOR
                            colorCelda = Color.Aqua;
                        if (_figuraActual[i, j] == -3)
                            colorCelda = Color.YellowGreen;
                        if (_figuraActual[i, j] == -4)
                            colorCelda = Color.Coral;


                        pincel = new SolidBrush(colorCelda);

                        if (_figuraActual[i, j] > 0)
                        {
                            gr.FillRectangle(pincel, rect);
                        }
                        else
                        {
                            gr.DrawEllipse(new Pen(pincel), rect);
                            gr.FillEllipse(pincel, rect);
                        }


                    }

                }

            }

        }


        protected override void OnPaint(PaintEventArgs e)
        {
            DibujarCuadricula(e);
            DibujarTablero(e);
            DibujarPieza(e);
        }



        public void EliminarColumna()  ///////////////////////////
        {
            int eliminadas = 0;
            int columna = _posicion.X;
            //      MessageBox.Show("Columna: " + columna);
            for (int i = 0; i < COL; i++)
            {
                _tablero[columna, i] = 0;
                eliminadas++;
            }

            this._celdasEliminadas += eliminadas;
        }   ////////////////////  //////////////////////////


        private void EliminarColor(int color)
        {
            int eliminadas = 0;
            for (int i = 0; i < FILAS; i++)
            {
                for (int j = 0; j < COL; j++)
                {
                    if (_tablero[i, j] == color)
                    {
                        _tablero[i, j] = 0;
                        eliminadas++;
                    }
                }
            }

            this._celdasEliminadas += eliminadas;
        }

        bool SePuedeEliminar(int fila, int columna)
        {
            if (fila < 0 || fila > FILAS - 1 || columna < 0 || columna > COL - 1)
                return false;
            if (_tablero[fila, columna] == 0)
                return false;
            return true;
        }

        private void EliminarAdyacentes(int fila, int columna)
        {
            ////////////////////////////////
            /////// NO HACE FALTA HACER TODO ESTO
            /////////////////////////////////
            int eliminadas = 0;

            if (SePuedeEliminar(fila - 1, columna - 1))
            {
                _tablero[fila - 1, columna - 1] = 0; eliminadas++;
            }

            if (SePuedeEliminar(fila, columna - 1))
            {
                _tablero[fila, columna - 1] = 0; eliminadas++;
            }
            if (SePuedeEliminar(fila + 1, columna - 1))
            {
                _tablero[fila + 1, columna - 1] = 0; eliminadas++;
            }

            if (SePuedeEliminar(fila + 1, columna))
            {
                _tablero[fila + 1, columna] = 0; eliminadas++;
            }

            if (SePuedeEliminar(fila + 1, columna + 1))
            {
                _tablero[fila + 1, columna + 1] = 0; eliminadas++;
            }
            if (SePuedeEliminar(fila, columna + 1))
            {
                _tablero[fila, columna + 1] = 0; eliminadas++;
            }
            if (SePuedeEliminar(fila - 1, columna + 1))
            {
                _tablero[fila - 1, columna + 1] = 0; eliminadas++;
            }

            if (SePuedeEliminar(fila - 1, columna))
            {
                _tablero[fila - 1, columna] = 0; eliminadas++;
            }

            if (SePuedeEliminar(fila, columna))
            {
                _tablero[fila, columna] = 0; eliminadas++;
            }


            this._celdasEliminadas += eliminadas; //SUMO LAS CELDAS QUE SE ELIMINARON
        }


        #region Serializacion y Deserializacion
        ///SERIALIZACION Y DESERIALIZACION
        ///
        private bool SerializarListaEstadisticas(string ruta)
        {
            bool pudo = false;
            try
            {
                using (XmlTextWriter escritor = new XmlTextWriter(ruta, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(List<Estadisticas>));
                    ser.Serialize(escritor, this._listaDeEstadisticas);
                    pudo = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "\tError al serializar");
            }

            return pudo;
        }

        public static List<Estadisticas> DeserializarListaDeEstadisticas(string ruta)
        {
            List<Estadisticas> listaAux = new List<Estadisticas>();
            try
            {
                using (XmlTextReader lector =
                    new XmlTextReader(ruta))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(List<Estadisticas>));
                    listaAux = (List<Estadisticas>)ser.Deserialize(lector);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return listaAux;

        }




        #endregion




    }

}



    //public class MiComparador : EqualityComparer<Celda>
    //{
    //    public override bool Equals(Celda obj1, Celda obj2)
    //    {
    //        if (obj1.Fila == obj2.Fila && obj1.Columna == obj2.Columna)
    //            return true;
    //        return false;
    //    }
    //    public override int GetHashCode(Celda obj)
    //    {
    //        if (obj == null) return 0;
    //        return 1;
    //    }

    //}


//  //// //INTENTO BAJAR CELDAS ////////////////////=> funciona para el cube crash,
                                        //pero aca el tablero esta rotado 90 grados, por eso no funciona
//public void BajarCeldas(int[,] tab)
//{
//    for (int col = 0; col < COL; col++)
//    {
//        for (int fila = FILAS - 1; fila >= 0; fila--)
//        {
//            if (tab[fila, col] != 0)
//            {
//                while (PuedeBajar(tab, fila, col))
//                {
//                    tab[fila + 1, col] = tab[fila, col];
//                    tab[fila, col] = 0;
//                    fila++;
//                }
//            }
//        }
//    }

//    Refresh();
//}

/*

    Public Function VerificarHorizontales(ByVal estado As Estado) As Boolean

        Dim banderaGanador As Boolean = True

        For i As Integer = 0 To 2

            For j As Integer = 0 To 2

                If Me._arrBotones(i, j).EstadoBoton <> estado Then
                    banderaGanador = False
                    Exit For
                End If

            Next

            If banderaGanador = True Then

                For j As Integer = 0 To 2
                    Me._arrBotones(i, j).ForeColor = Color.Red
                Next

                DeshabilitarTodosLosBotones()
                Return True

            End If

            banderaGanador = True

        Next

        Return False

    End Function


    Public Function VerificarVerticales(ByVal estado As Estado) As Boolean

        Dim banderaGanador As Boolean = True

        For j As Integer = 0 To Me._arrBotones.GetLength(1) - 1

            For i As Integer = 0 To Me._arrBotones.GetLength(0) - 1

                If Me._arrBotones(i, j).EstadoBoton <> estado Then
                    banderaGanador = False
                    Exit For
                End If
            Next

            If banderaGanador = True Then

                For i As Integer = 0 To Me._arrBotones.GetLength(0) - 1
                    Me._arrBotones(i, j).ForeColor = Color.Red
                Next

                DeshabilitarTodosLosBotones()
                Return True

            End If

            banderaGanador = True

        Next

        Return False

    End Function



    Public Function VerificarDiagonalPrincipal(ByVal estado As Estado) As Boolean

        Dim banderaGanador As Boolean = True

        Dim i As Integer

        For i = 0 To Me._arrBotones.GetLength(0) - 1
            For j As Integer = 0 To Me._arrBotones.GetLength(1) - 1
                'CUANDO I=J ESTAS PARADO EN LA DIAGONAL PRINCIPAL
                If i = j Then

                    If Me._arrBotones(i, j).EstadoBoton <> estado Then
                        banderaGanador = False
                        Exit For
                    End If

                End If
            Next
        Next

        If banderaGanador = True Then

            'RECORRO OTRA VEZ LA MATRIZ PERO SABIENDO QUE LA DIAGONAL PRINCIPAL TIENE EL MISMO ESTADO
            For i = 0 To Me._arrBotones.GetLength(0) - 1
                For j As Integer = 0 To Me._arrBotones.GetLength(1) - 1
                    If i = j Then
                        Me._arrBotones(i, j).ForeColor = Color.Red
                    End If
                Next
            Next


            DeshabilitarTodosLosBotones()
            Return True


        End If


        Return False

    End Function


    Public Function VerificarDiagonalSecundaria(ByVal estado As Estado) As Boolean

        Dim banderaGanador As Boolean = True

        For i As Integer = 0 To Me._arrBotones.GetLength(0) - 1

            For j As Integer = 0 To Me._arrBotones.GetLength(1) - 1

                'LA PROPIEDAD DE LA DIAGONAL SECUNDARIA (EN UNA MATRIZ CUADRADA) 
                'ES QUE LA SUMA DE SU FILA Y SU COLUMNA DAN EL TAMAÑO DE UNA FILA O CULUMNA
                If (i + j) = (Me._arrBotones.GetLength(0) - 1) Then

                    If Me._arrBotones(i, j).EstadoBoton <> estado Then
                        banderaGanador = False
                        Exit For
                    End If

                End If

            Next

        Next

        If banderaGanador = True Then

            For i As Integer = 0 To Me._arrBotones.GetLength(0) - 1
                For j As Integer = 0 To Me._arrBotones.GetLength(1) - 1
                    If (i + j) = (Me._arrBotones.GetLength(0) - 1) Then
                        Me._arrBotones(i, j).ForeColor = Color.Red
                    End If
                Next
            Next


            DeshabilitarTodosLosBotones()
            Return True

        End If


        Return False

    End Function

 
*/

/*  //OBTENER CELDAS VECINAS
private List<Celda> ObtenerCeldasVecinas(Celda c)
        {
            List<Celda> celdasABorrar = new List<Celda>();


            int fila = c.Fila;
            int columna = c.Columna;


            //////////////////////---------////////
            ////-------NORTE Y SUR---------//////////
            //////////////////////---------////////
            List<Celda> lista = new List<Celda>();
            lista.Add(c);

            //ME FIJO HACIA EL NORTE
            if (EsCeldaValida(fila - 1, columna))
            {    //COMPARACION DEL COLOR CON LA CELDA ACTUAL
                if (_tablero[fila, columna] == _tablero[fila - 1, columna])
                {
                    lista.Add(new Celda(fila - 1, columna, _tablero[fila - 1, columna]));
                }
            }
            ///Y LO CONECTO CON EL SUR
            if (EsCeldaValida(fila + 1, columna))
            {
                if (_tablero[fila, columna] == _tablero[fila + 1, columna])
                {
                    lista.Add(new Celda(fila + 1, columna, _tablero[fila + 1, columna]));
                }
            }

            //ENTONCES COMPRUEBO SI HAY MAS DE 2
            //SI HAY MAS DE 2 LAS AGREGO A LA LISTA DE CELDAS A BORRAR
            if (lista.Count > 2)
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    celdasABorrar.Add(lista[i]);
                }

            }

            ///////////////////////////////////
            //////OESTE Y ESTE////////////////
            ///////////////////////////////////
            List<Celda> listaOesteEste = new List<Celda>();
            listaOesteEste.Add(c);

            /////----------ME FIJO HACIA EL OESTE------------
            if (EsCeldaValida(fila, columna - 1))
            {
                if (_tablero[fila, columna] == _tablero[fila, columna - 1])
                {
                    listaOesteEste.Add(new Celda(fila, columna - 1, _tablero[fila, columna - 1]));
                }
            }

            /////--------------ME FIJO HACIA EL ESTE---------------
            if (EsCeldaValida(fila, columna + 1))
            {
                if (_tablero[fila, columna] == _tablero[fila, columna + 1])
                {
                    listaOesteEste.Add(new Celda(fila, columna + 1, _tablero[fila, columna + 1]));
                }
            }

            if (listaOesteEste.Count > 2)
            {
                for (int i = 0; i < listaOesteEste.Count; i++)
                {
                    celdasABorrar.Add(listaOesteEste[i]);
                }
            }

            //////////////////////////////////////
            ///------NOROESTE - SURESTE-----------
            //////////////////////////////////////
            List<Celda> listaNorOesteSurEste = new List<Celda>();
            listaNorOesteSurEste.Add(c);
            //ME FIJO HACIA EL NOROESTE
            if (EsCeldaValida(fila - 1, columna - 1))
            {
                if (_tablero[fila, columna] == _tablero[fila - 1, columna - 1])
                {
                    listaNorOesteSurEste.Add(new Celda(fila - 1, columna - 1, _tablero[fila - 1, columna - 1]));
                }
            }

            //ME FIJO HACIA EL SURESTE
            if (EsCeldaValida(fila + 1, columna + 1))
            {
                if (_tablero[fila, columna] == _tablero[fila + 1, columna + 1])
                {
                    listaNorOesteSurEste.Add(new Celda(fila + 1, columna + 1, _tablero[fila + 1, columna + 1]));
                }
            }

            if (listaNorOesteSurEste.Count > 2)
            {
                for (int i = 0; i < listaNorOesteSurEste.Count; i++)
                {
                    celdasABorrar.Add(listaNorOesteSurEste[i]);
                }
            }

            //// /////////////////////////////////////
            //----------SUROESTE - NORESTE
            //////////////////////////////////////////
            List<Celda> listaSurOesteNorEste = new List<Celda>();
            listaSurOesteNorEste.Add(c);

            //ME FIJO HACIA EL SUROESTE
            if (EsCeldaValida(fila + 1, columna - 1))
            {
                if (_tablero[fila, columna] == _tablero[fila + 1, columna - 1])
                {
                    listaSurOesteNorEste.Add(new Celda(fila + 1, columna - 1, _tablero[fila + 1, columna - 1]));
                }
            }

            //ME FIJO HACIA EL NORESTE
            if (EsCeldaValida(fila - 1, columna + 1))
            {
                if (_tablero[fila, columna] == _tablero[fila - 1, columna + 1])
                {
                    listaSurOesteNorEste.Add(new Celda(fila - 1, columna + 1, _tablero[fila - 1, columna + 1]));
                }
            }


            if (listaSurOesteNorEste.Count > 2)
            {
                for (int i = 0; i < listaSurOesteNorEste.Count; i++)
                {
                    celdasABorrar.Add(listaSurOesteNorEste[i]);
                }
            }

            //SE BORRAN CUANDO TENGO TODAS LAS QUE TENGO QUE BORRAR REUNIDAS,
            //YA QUE SI POR EJ BORRO UNA FILA, SI POR EJEMPLO ESA FILA FORMARA UNA CRUZ
            //SI YO BORRO LA FILA A LA COLUMNA LE QUEDAN 2 Y NO PODRIA BORRARSE DESPUES
            return celdasABorrar;

        }





*/

