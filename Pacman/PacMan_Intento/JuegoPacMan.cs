using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{

    public struct Posicion
    {
        public int X;
        public int Y;

        //--------TAMBIEN PUEDE HACERSE CON SOBRECARGA DE OPERADORES---------------
        //public static bool operator ==(Posicion p1, Posicion p2)
        //{
        //    if (p1.X == p2.X && p1.Y == p2.Y)
        //        return true;
        //    return false;
        //}
        //public static bool operator !=(Posicion p1, Posicion p2)
        //{
        //    return !(p1 == p2);
        //}
    }

    public class JuegoPacMan : Control
    {

        public static int FILAS;
        public static int COLUMNAS;


        //public Pac_Man _pacMan;
        public Pac_Man _ElPacMan;
        public Timer _temporizador;
        private Random _r;
        //private Fantasma[] _fantasmas = new Fantasma[4]; //ARRAY DE FANTASMAS
        private List<Fantasma> _fantasmas; //ARRAY DE FANTASMAS

        private Color[] _colores = {   Color.Red,
                                       Color.Green,
                                       Color.Blue,
                                       Color.Cyan,
                                       Color.Magenta,
                                       Color.LightGreen,
                                       Color.Beige,
                                       Color.Violet,
                                       Color.Orange,
                                       Color.Brown,                                
                                   };

        private int _cantidadDeComida;


        //---------------------
        private int _ticksFantasmasDebiles;
        private bool _banderaTicks;

        private bool _pastillaNorOeste; //MARCO LAS PASTILLAS QUE YA FUERON COMIDAS
        private bool _pastillaNorEste;
        private bool _pastillaSurOeste;
        private bool _pastillaSureste;

        //---------------------



        public JuegoPacMan()
        {
            this._r = new Random();
            this._temporizador = new Timer();

            FILAS = _tablero.GetLength(0);
            COLUMNAS = _tablero.GetLength(1);


            this._ticksFantasmasDebiles = 0;
            this._banderaTicks = false;
            this._pastillaSurOeste = true;
            this._pastillaSureste = true;
            this._pastillaNorOeste = true;
            this._pastillaNorEste = true;

            //  BorrarTablero();

            //  CARGO LA CANT DE COMIDA
            this._cantidadDeComida = CargarComida();


            // INICIALIZO EL ARRAY DE FANTASMAS
            this._fantasmas = new List<Fantasma>();
            //for (int i = 0; i < 4; i++) //4 fantasmas
            //{
            //    this._fantasmas[i] = new Fantasma(_colores[i]);
            //}
            this._fantasmas.Add(new Fantasma(_colores[0]));
            this._fantasmas.Add(new Fantasma(_colores[1]));
            this._fantasmas.Add(new Fantasma(_colores[2]));
            this._fantasmas.Add(new Fantasma(_colores[3]));


            this._ElPacMan = new Pac_Man();
            this.PreviewKeyDown += new PreviewKeyDownEventHandler(PacMan_PreviewKeyDown);

            this._temporizador.Tick += new EventHandler(Temporizador_Tick);
            this._temporizador.Interval = 50;


            //DOBLE BUFFER = REPINTADO SOBRE LO QUE YA ESTA, (NO BORRA ANTES). 
            //SIRVE PARA EVITAR EL PARPADEO
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);

        }

        public int[,] _tablero =
        {
             {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
             {1,4,0,0,2,0,0,0,0,2,1,2,0,0,0,0,2,0,0,4,1},
             {1,0,1,1,0,1,1,1,1,0,1,0,1,1,1,1,0,1,1,0,1},
             {1,0,1,1,2,0,0,2,1,2,0,2,1,2,0,0,2,1,1,0,1},
             {1,2,0,0,0,0,0,2,1,0,1,0,1,2,0,0,0,0,0,2,1},
             {1,1,1,1,0,1,1,0,1,0,1,0,1,0,1,1,0,1,1,1,1},
             {1,2,0,0,2,2,1,2,0,2,1,2,0,2,1,2,2,0,0,2,1},
             {1,1,1,1,1,0,1,1,1,0,1,0,1,1,1,0,1,1,1,1,1}, //
             {2,2,0,2,1,0,1,2,0,2,2,2,0,2,1,0,1,2,0,2,2},
             {2,2,1,1,1,0,1,0,1,1,0,1,1,0,1,0,1,1,1,2,2},
             {2,2,0,0,0,2,0,2,1,2,2,2,1,2,0,2,0,0,0,2,2},
             {2,2,1,1,1,0,1,0,1,1,1,1,1,0,1,0,1,1,1,2,2},
             {2,2,0,2,1,0,1,2,0,2,2,2,0,2,1,0,1,2,0,2,2},
             {1,1,1,1,1,0,1,1,1,0,0,0,1,1,1,0,1,1,1,1,1}, //
             {1,2,2,0,2,2,1,2,0,2,2,2,0,2,1,2,2,0,2,2,1},
             {1,0,0,1,0,1,1,0,1,1,1,1,1,0,1,1,0,1,0,0,1},
             {1,2,2,1,2,0,0,2,1,2,0,2,1,2,0,0,2,1,2,2,1},
             {1,0,1,1,1,1,1,0,1,0,1,0,1,0,1,1,1,1,1,0,1},
             {1,4,0,0,0,0,0,2,0,2,1,2,0,2,0,0,0,0,0,4,1},
             {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},

        };





        //VERIFICA SI EL PACMAN COMIO LA ENERGIA DE LAS ESQUINAS
        public void VerificarEnergia()
        {
            //PASTILLA DE LA ESQUINA NOROESTE
            if (this._ElPacMan._posicion.Y == 1 && this._ElPacMan._posicion.X == 1 && _pastillaNorOeste == true)  //ESQUINA NOROESTE
            {
                this._banderaTicks = true;
                this._pastillaNorOeste = false;
            }

            //PASTILLA DE LA ESQUINA NORESTE
            if (this._ElPacMan._posicion.Y == 1 && this._ElPacMan._posicion.X == 19 && _pastillaNorEste == true)  //ESQUINA NORESTE
            {
                this._banderaTicks = true;
                this._pastillaNorEste = false;
            }
            //PASTILLA DE LA ESQUINA SUROESTE
            if (this._ElPacMan._posicion.Y == 18 && this._ElPacMan._posicion.X == 1 && this._pastillaSurOeste == true)  //ESQUINA SUROESTE
            {
                this._banderaTicks = true;
                this._pastillaSurOeste = false;
            }
            //PASTILLA DE LA ESQUINA SURESTE
            if (this._ElPacMan._posicion.Y == 18 && this._ElPacMan._posicion.X == 19 && this._pastillaSureste == true)// ESQUINA SURESTE
            {
                this._banderaTicks = true;
                this._pastillaSureste = false;
            }
        }

        //EVENTO TICK DEL TIMER
        private void Temporizador_Tick(Object sender, EventArgs e)
        {
            this._ElPacMan.MoverPacman(_tablero);
            VerificarEnergia(); //SI COMIO UNA ENERGIA PONE LA BANDERA A TRUE

            for (int i = 0; i < _fantasmas.Count; i++)
            {
                if (VerificarContacto(_fantasmas[i]))
                {
                    if (this._banderaTicks == false)
                    {
                        this._temporizador.Stop();
                        MessageBox.Show("Contacto");
                    }
                    else
                    {  
                        //SI HAY CONTACTO Y LOS FANTASMAS ESTAN MARRONES,
                        //ELIMINO ESE FANTASMA DEL ARRAY
                        this._fantasmas.RemoveAt(i);

                    }
                }
            }

            //CUENTO EL TIEMPO EN QUE LOS FANTASMAS VAN A ESTAR COMIBLES
            if (this._banderaTicks == true)
            {
                this._ticksFantasmasDebiles++;
            }
            //25 TICKS DESPUES DE COMER LA PASTILLA LOS FANTASMAS VAN A ESTAR COMIBLES
            if (this._ticksFantasmasDebiles == 25) 
            {
                // SI LLEGO A LOS 25 SE TERMINO EL EFECTO DE ESA PASTILLA Y LOS FANTASMAS VUELVEN A ESTAR DE COLORES Y ASESINOS
                this._banderaTicks = false; 
                this._ticksFantasmasDebiles = 0;
            }


            ////////////-------COMER--------////////////////
            if (this._tablero[_ElPacMan._posicion.Y, _ElPacMan._posicion.X] == 2 || //
                 this._tablero[_ElPacMan._posicion.Y, _ElPacMan._posicion.X] == 3 ||
                 this._tablero[_ElPacMan._posicion.Y, _ElPacMan._posicion.X] == 4)
            {

                this._tablero[_ElPacMan._posicion.Y, _ElPacMan._posicion.X] *= (-1);
                this._cantidadDeComida--;
                if (this._cantidadDeComida <= 0)
                {
                    this._temporizador.Stop();
                    MessageBox.Show("NIVEL COMPLETO !!");
                }
            }

            //-------------------BUCLE PARA MOVER FANTASMAS---------------
            for (int i = 0; i < this._fantasmas.Count; i++)
            {
                //--------PARA QUE EL FANTASMA PASE DEL OTRO LADO-----------------
                if (_fantasmas[i]._posicion.Y >= 8 && _fantasmas[i]._posicion.Y <= 12)
                {
                    if (_fantasmas[i]._posicion.X == JuegoPacMan.COLUMNAS - 1)
                    {
                        _fantasmas[i]._posicion.X = 0;
                    }
                    else if (_fantasmas[i]._posicion.X == 0)
                    {
                        _fantasmas[i]._posicion.X = JuegoPacMan.COLUMNAS - 1;
                    }
                }

                //------------SELECCIONA PARA DONDE PUEDEN MOVER LOS FANTASMAS-------------------------------------------
                if ((_tablero[_fantasmas[i]._posicion.Y, _fantasmas[i]._posicion.X] == 2) ||
                      _tablero[_fantasmas[i]._posicion.Y, _fantasmas[i]._posicion.X] == -2 ||
                      _tablero[_fantasmas[i]._posicion.Y, _fantasmas[i]._posicion.X] == 4 ||
                   (_tablero[_fantasmas[i]._posicion.Y, _fantasmas[i]._posicion.X] == -4))
                {
                    _fantasmas[i].ObtenerDireccionesDisponibles(_tablero);
                    _fantasmas[i].ObtenerDireccionAleatoria(_r.Next(0, _fantasmas[i]._direccionesDisponibles.Count));
                }

                ////MUEVE CADA FANTASMA
                _fantasmas[i].MoverFantasma(_tablero);

                ///----------MARCA POR DONDE PASARON FANTASMAS---------------------------
                //if (_tablero[unFantasma._posicion.Y, unFantasma._posicion.X] == 0)
                //{
                //    this._tablero[unFantasma._posicion.Y, unFantasma._posicion.X] = 5;
                //}
                //else if (_tablero[unFantasma._posicion.Y, unFantasma._posicion.X] == 2)
                //{
                //    this._tablero[unFantasma._posicion.Y, unFantasma._posicion.X] = -2;
                //}

                //----------------VERIFICAR CONTACTO---------------------
                if (VerificarContacto(_fantasmas[i]))
                {
                    if (this._banderaTicks == false)
                    {
                        this._temporizador.Stop();
                        MessageBox.Show("Contacto");
                    }
                    else
                    {
                        //   unFantasma = null;
                        this._fantasmas.RemoveAt(i);

                    }
                }

            } //FIN NUEVO FOR

            Refresh();
        } /// FIN EVENTO TICK


        public void Empezar()
        {
            _temporizador.Interval = 220;
            _temporizador.Start();
        }


        //------------------ CARGAR Y CONTAR COMIDA----------------------
        // 2 = COMIDA Y "PUNTO O CELDA DE DESICION" PARA LOS FANTASMAS (SELECCIONA DEL ENUMERADO LA DIRECCION)
        // 3 = SOLO COMIDA
        // 4 = PASTILLA Y CELDA DE DESICION PARA LOS FANTASMAS,
        //(AHI SELECCIONA UNA DIRECCION DE MOV DEL ENUMERADO ALEATORIAMENTE)
        public int CargarComida()
        {
            int cant = 0;
            for (int i = 0; i < FILAS; i++)
            {
                for (int j = 0; j < COLUMNAS; j++)
                {
                    if (_tablero[i, j] == 0)
                    {
                        _tablero[i, j] = 3;
                    }
                    if (_tablero[i, j] == 2 || _tablero[i, j] == 3 || _tablero[i, j] == 4)
                    {
                        cant++;
                    }
                }
            }
            return cant;
        }
      



        //private void BorrarTablero()
        //{
        //    for (int i = 0; i < FILAS; i++)
        //    {
        //        for (int j = 0; j < COLUMNAS; j++)
        //        {
        //            _tablero[i, j] = 0;
        //        }
        //    }
        //}


        public void DibujarTablero(PaintEventArgs e)
        {
            int lado = 30;
            Rectangle rect;
            SolidBrush pincelBlanco = new SolidBrush(Color.White);
            SolidBrush pincelGris = new SolidBrush(Color.Gray);
            Graphics g = e.Graphics;

            for (int i = 0; i < _tablero.GetLength(0); i++)
            {
                for (int j = 0; j < _tablero.GetLength(1); j++)
                {
                    if (_tablero[i, j] == 1)
                    {
                        rect = new Rectangle(j * lado, i * lado, lado - 1, lado - 1);
                        g.FillRectangle(pincelBlanco, rect);

                    }

                    //----------DIBUJA POR DONDE PASARON LOS FANTASMAS-(PARA COMPROBAR LA MOVILIDAD)-----
                    //if (_tablero[i, j] == 5 || _tablero [i,j]== (-2)   )
                    //{
                    //    rect = new Rectangle(j * lado, i * lado, lado - 1, lado - 1);
                    //    g.FillRectangle(new SolidBrush(Color.Gray), rect);

                    //}
                    //---------------------------------------------------


                    //-------------------DIBUJAR COMIDA---------------------------
                    if (_tablero[i, j] == 2 || _tablero[i, j] == 3)
                    {
                        rect = new Rectangle(j * 30 + 10, i * 30 + 10,
                            lado - 25, lado - 25);

                        g.DrawEllipse(new Pen(pincelBlanco), rect);
                        g.FillEllipse(pincelBlanco, rect);
                    }
                    //-----------------DIBUJAR ENERGIA--------------------------
                    if (_tablero[i, j] == 4)
                    {
                        rect = new Rectangle(j * 30 + 10, i * 30 + 10,
                            lado - 20, lado - 20);

                        g.DrawEllipse(new Pen(pincelBlanco), rect);
                        g.FillEllipse(pincelBlanco, rect);

                    }
                }
            }
        }

        //----DIBUJA CADA FANTASMA DEL ARRAY CON SU POSICION RESPECTIVA------
        public void DibujarFantasmas(PaintEventArgs e)
        {
            foreach (Fantasma unFantasma in this._fantasmas)
            {
                unFantasma.DibujarFantasma(e, this._banderaTicks);
            }
        }

        bool VerificarContacto(Fantasma unFantasma)
        {
            if (unFantasma._posicion.X == this._ElPacMan._posicion.X &&
                unFantasma._posicion.Y == this._ElPacMan._posicion.Y)
            {
                return true;
            }
            return false;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            DibujarTablero(e);

            DibujarFantasmas(e);

            this._ElPacMan.DibujarPacman(e);
        }

        //-----------------CAPTURA TECLADO PARA MOVER AL PACMAN---------------
        public void PacMan_PreviewKeyDown(Object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:

                    this._ElPacMan._direccionActual = DireccionDeMovimiento.Arriba;
                    break;
                case Keys.Down:

                    this._ElPacMan._direccionActual = DireccionDeMovimiento.Abajo;
                    break;
                case Keys.Right:

                    this._ElPacMan._direccionActual = DireccionDeMovimiento.Derecha;
                    break;
                case Keys.Left:

                    this._ElPacMan._direccionActual = DireccionDeMovimiento.Izquierda;
                    break;
            }

            Refresh();
        }//--------------------------------------------------//



    }



}


             //ESTE FOREACH LO REEMPLACE POR UN FOR, 
             //PORQUE SINO NO PUEDO ELIMINAR LOS FANTASMAS
            //( unFantasma = null no es valido en C#,
            //pero si borrarlo con: _fantasmas.Remove(_fantasmas[i])
            //o _fantasmas.RemoveAt(i)

            //foreach (Fantasma unFantasma in _fantasmas)
            //{
            //    //--------PARA QUE EL FANTASMA PASE DEL OTRO LADO-----------------
            //    if (unFantasma._posicion.Y >= 8 && unFantasma._posicion.Y <= 12)
            //    {
            //        if (unFantasma._posicion.X == JuegoPacMan.COLUMNAS - 1)
            //        {
            //            unFantasma._posicion.X = 0;
            //        }
            //        else if (unFantasma._posicion.X == 0)
            //        {
            //            unFantasma._posicion.X = JuegoPacMan.COLUMNAS - 1;
            //        }
            //    }

            //    //-------------------------------------------------------
            //    if ((_tablero[unFantasma._posicion.Y, unFantasma._posicion.X] == 2) ||
            //          _tablero[unFantasma._posicion.Y, unFantasma._posicion.X] == -2 ||
            //          _tablero[unFantasma._posicion.Y, unFantasma._posicion.X] == 4 ||
            //       (_tablero[unFantasma._posicion.Y, unFantasma._posicion.X] == -4))
            //    {
            //        unFantasma.ObtenerDireccionesDisponibles(_tablero);
            //        unFantasma.ObtenerDireccionAleatoria(_r.Next(0, unFantasma._direccionesDisponibles.Count));
            //    }

            //    ////MUEVE CADA FANTASMA
            //    unFantasma.MoverFantasma(_tablero);


            //    ///----------MARCA POR DONDE PASARON FANTASMAS---------------------------
            //    //if (_tablero[unFantasma._posicion.Y, unFantasma._posicion.X] == 0)
            //    //{
            //    //    this._tablero[unFantasma._posicion.Y, unFantasma._posicion.X] = 5;
            //    //}
            //    //else if (_tablero[unFantasma._posicion.Y, unFantasma._posicion.X] == 2)
            //    //{
            //    //    this._tablero[unFantasma._posicion.Y, unFantasma._posicion.X] = -2;
            //    //}

            //    //----------------VERIFICAR CONTACTO---------------------
            //    if (VerificarContacto(unFantasma))
            //    {
            //        if (this._banderaTicks == false)
            //        {
            //            this._temporizador.Stop();
            //            MessageBox.Show("Contacto");
            //        }
            //        else
            //        {
            //         //   unFantasma = null;


            //        }

            //    }
            //} //FIN FOREACH