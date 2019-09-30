using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class FrmTetris : Form
    {
        private Tetris _tetris;

        public FrmTetris()
        {
            InitializeComponent();

            _tetris = new Tetris();

          //  _tetris.KeyPress += new KeyPressEventHandler(Tetris_KeyPress);

            _tetris.PreviewKeyDown += new PreviewKeyDownEventHandler(PresionTeclas);
           
            Resize += new EventHandler(FrmTetris_Resize);
            ClientSize = new Size(_tetris.FILAS * 30, _tetris.COL * 30);

            this.Controls.Add(_tetris);

            // MessageBox.Show("FILAS: " + _tetris.FILAS * 20 + "COLS: " + _tetris.COL * 20);
            _tetris.Empezar();

        }
  
     

        public void PresionTeclas(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    _tetris.Rotar();
                    break;
                case Keys.Left:
                    _tetris.MoverIzquierda();
                    break;
                case Keys.Right :
                    _tetris.MoverDerecha();
                    break;
                case Keys.Space :
                    _tetris.Caer();
                    break;

            }
        }


        public void FrmTetris_Resize(Object sender, EventArgs e)
        {
            _tetris.Size = ClientSize;

        }

        private void FrmTetris_Load(object sender, EventArgs e) { }

    }//fin clase FormTetris

    //public void Tetris_KeyPress(Object sender, KeyPressEventArgs e)
    //{
    //    if (e.KeyChar == 'j' || e.KeyChar == 'J') _tetris.MoverIzquierda();
    //    if (e.KeyChar == 'k' || e.KeyChar == 'K') _tetris.Caer();
    //    if (e.KeyChar == 'l' || e.KeyChar == 'L') _tetris.MoverDerecha();
    //    if (e.KeyChar == 'i' || e.KeyChar == 'I') _tetris.Rotar();

    //    e.Handled = true;
    //}


    public struct Posicion
    {
        public int X;
        public int Y;
    }

    [Serializable]
    public class Tetris : Control
    {
        private Posicion _posicion;
        private int _indiceFigura;
        private int[,] _figuraActual;
        private Timer _temporizador;
        private Color[] _color;
        private Color[] _claros;
        private List<int[,]> _figuras;
        private Random _r;
        public int FILAS = 10,
            COL = 20;
        private int[,] _tablero;
        private int _puntos;  /*******************************/ 
        private int _lineasCompletas;
        private int _intervaloTiempo;

        //VECTORES PARA LA VELOCIDAD DE CAIDA 
        //EL INTERVALO DEL TEMPORIZADOR ESTA DEFINIDO EN FUNCION DE LA CANTIDAD DE LINEAS ELIMINADAS
        //POR ESO HICE ESTOS DOS VECTORES PARALELOS: a "x" lineas eliminadas le corresponde "y" tiempo
        private int[] _lineasVector = { 20, 40, 80, 100, 150, 200, 230, 270, 290, 400 };
        private int [] _intervalosTiempo = { 1000, 800, 600, 550, 400, 350, 300, 200, 160, 50 };
        private int _indiceTiempos = 0;

        //private bool _estaFuncionando;
        // /// PARA ESTADISTICAS
        public List<Estadisticas> _listaDeEstadisticas;
        public int _x1, _x2, _x3, _x4;


      //  public string Ruta = Application.StartupPath + "\\Tetris.xml";

        public Tetris()
        {
            if (File.Exists(Inicio.Ruta))
            {
                _listaDeEstadisticas = Tetris.DeserializarListaEstadisticas(Inicio.Ruta);
            }
            else
            {
                _listaDeEstadisticas = new List<Estadisticas>();
            }

            //  _estaFuncionando = true;
            _x1 = _x2 = _x3 = _x4 = 0;
            _puntos = 0;
            
            _lineasCompletas = 0;

            //for (int i = 0; i < _intervalosTiempo.Length; i++)
            //{
            //    _intervalosTiempo[i] -= (int)(_intervalosTiempo[0] * 0.5);
            //}

            _intervaloTiempo = _intervalosTiempo [0]; //INICIAMOS EL INTERVALO PARA LA CAIDA DE LA PIEZA A UN SEGUNDO


            _tablero = new int[FILAS, COL];
            _r = new Random();
            _posicion = new Posicion();
            _posicion.X = 4;
            _posicion.Y = 0;
            _temporizador = new Timer();
            _color = new Color[] { Color.Red, Color.Green, Color.Blue, Color.DarkSalmon, Color.Violet, Color.DarkOrange, Color.DeepPink };
            _claros = new Color[] { Color.Pink, Color.LightGreen, Color.Cyan, Color.Yellow, Color.Magenta, Color.Orange, Color.Fuchsia };
            _figuras = new List<int[,]>();

            //AGREGO TODAS LAS FIGURAS A LA LISTA
            _figuras.Add(new int[,]
            {
                {1,0,0},
                {1,0,0},
                {1,1,0}
            });
            _figuras.Add(new int[,]
            {
                {0,1,0},
                {0,1,0},
                {1,1,0}
            });
            _figuras.Add(new int[,]
            {
                {0,0,0},
                {0,1,0},
                {1,1,1}
            });

            _figuras.Add(new int[,]
            {
                {0,0,0},
                {0,1,1},
                {1,1,0}
            });
            _figuras.Add(new int[,]
            {
                {0,0,0},
                {1,1,0},
                {0,1,1}
            });
            _figuras.Add(new int[,]
            {
                {1,1},
                {1,1},
            });
            _figuras.Add(new int[,]
            {
                {1,0,0,0},
                {1,0,0,0},
                {1,0,0,0},
                {1,0,0,0}

            });

            //INDICO EL METODO ASOCIADO AL EVENTO TICK DEL TEMPORIZADOR 
            _temporizador.Tick += new EventHandler(Temporizador_Tick);
            _temporizador.Interval = _intervaloTiempo;


            //PARA QUE NO SE NOTEN LOS BARRIDOS CUANDO SE LIMPIA LA PANTALLA
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }


        //EL TEMPORIZADOR ES COMO UN METRONOMO,  
        //CADA CIERTO INTERVALO DE TIEMPO EJECUTA UNA ACCION
        public void Temporizador_Tick(Object sender, EventArgs e)//RECIBE UN OBJETO Y UN EVENTO POR PARAMETRO
        {
            MoverAbajo(); // MUEVA ABAJO EN CADA TICK
            //SI NO PUEDE MOVER: DETIENE EL TEMP
            if (!VerificarColision(_figuraActual, _posicion.X, _posicion.Y))
            {
                Detener();

                // /////////////////////AGREGO LAS ESTADISTICAS DE ESTE PARTIDO A LA LISTA DE ESTADISTICAS
                _listaDeEstadisticas.Add(new Estadisticas(_puntos, DateTime.Now, this._x1, this._x2, this._x3, this._x4));
                SerializarListaEstadisticas(Inicio.Ruta );
                /////////////////////////////

                if (_puntos < 1500)
                    MessageBox.Show("Perdiste, no hay mas espacio\nPuntos = " + _puntos + " (un poco flojo)");
                if (_puntos >= 1500 && _puntos < 9000)
                    MessageBox.Show("Perdiste, no hay mas espacio\nPuntos = " + _puntos + " (jugas Tetris bastante bien)");
                if (_puntos >= 9000 && _puntos < 40000)
                    MessageBox.Show("Perdiste, no hay mas espacio\nPuntos = " + _puntos + " (jugas Tetris epselente)");
                else if (_puntos >= 40000)
                    MessageBox.Show("Perdiste, no hay mas espacio\nPuntos = " + _puntos + " (Tetris Master, jugas como un chino nerd sin amigos)");
            }
            Refresh();
        }

        public void Detener()
        {
            //  _estaFuncionando = false;
            _temporizador.Stop();
        }

        //COPIA EL CONTENIDO DE LA PIEZA AL TABLERO
        void FijarPieza()
        {
            int tam = _figuraActual.GetLength(0);

            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam; j++)
                {
                    if (_figuraActual[i, j] != 0)
                    {
                        _tablero[_posicion.X + i, _posicion.Y + j] = _indiceFigura + 1;// _figuraActual[i, j];
                    }
                }
            }
        }

        //MIENTRAS MOVER ABAJO ES TRUE DESPLAZA LA PIEZA UNA POSICION ABAJO
        public void Caer()
        {
            while (MoverAbajo())
            {
                this._puntos++; //UN PUNTO POR CADA CELDA QUE BAJA
            }

            //this._puntos += 5; //LA CAIDA LIBRE ES PREMIADA PORQUE ES ARRIESGADA

            Refresh();
        }

        private void EliminarLineasCompletas()
        {
            //RECORRO TODO EL TABLERO
            int contador = 0;
            for (int j = 0; j < COL; j++)
            {
                bool completa = true; //BUSCO QUE HAYA UNA VACIA
                for (int i = 0; i < FILAS; i++)
                {
                    if (_tablero[i, j] == 0) completa = false;
                }
                if (completa == true) //SI NO HAY VACIA
                {
                    contador++;
                    for (int k = j; k > 0; k--)
                        for (int i = 0; i < FILAS; i++)
                            _tablero[i, k] = _tablero[i, k - 1];
                }
                completa = true;
            }

            /////////// CONTADORES DE LINEAS JUNTAS ELIMINADAS///////////////////
            if (contador == 1) this._x1++;
            if (contador == 2) this._x2++;
            if (contador == 3) this._x3++;
            if (contador == 4) this._x4++;
            /////////////////////////////////////////////////////////////////////

            this._puntos += (int)Math.Pow(contador, 2) * 10;
            this._lineasCompletas += contador; //POR AHORA LO USO PARA SABER SI HAY QUE AUMENTAR LA VELOCIDAD (REDUCIR Interval DEL TEMPORIZADOR)
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
            FijarPieza();//1. FIJA LA PIEZA AL TABLERO
            EliminarLineasCompletas();//2.SE FIJA SI SE FORMARON LINEAS COMPLETAS, DE SER ASI LAS ELIMINA
            Empezar(); //3.INICIA EL TEMPORIZADOR Y SETEA LA POSICION INICIAL DE LA NUEVA PIEZA
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

        public void Rotar()
        {
            int tam = _figuraActual.GetLength(0);
            int[,] auxiliar = new int[tam, tam];

            if (tam != 4)
            {
                for (int i = 0; i < tam; i++)
                    for (int j = 0; j < tam; j++)
                        auxiliar[j, tam - i - 1] = _figuraActual[i, j];
            }
            else
            {
                //EL MISMO ALGORITMO QUE SE USA PARA HALLAR LA MATRIZ TRANSPUESTA
                for (int i = 0; i < tam; i++)
                    for (int j = tam - 1; j >= 0; j--)
                        auxiliar[i, j] = _figuraActual[j, i];
            }

            //EL AUXILIAR ES LA FIGURA ROTADA, ME FIJO SI APRUEBA
            if (VerificarColision(auxiliar, _posicion.X, _posicion.Y))
            {
                Copiar(auxiliar);
            }
            Refresh();

        }

        public void Copiar(int[,] aux)
        {
            int tam = _figuraActual.GetLength(0);
            for (int i = 0; i < tam; i++)
                for (int j = 0; j < tam; j++)
                    _figuraActual[i, j] = aux[i, j];
        }

        private bool VerificarColision(int[,] fig, int x, int y)
        {
            int tam = fig.GetLength(0);

            //PARA APROBAR O NO UN MOVIMIENTO:
            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam; j++)
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

        //LE PASO A LA MATRIZ QUE CONTIENE A LA FIGURA ACTUAL
        //(QUE ES CON LA QUE VAMOS A TRABAJAR) UNA DE LAS FIGURAS CARGADAS EN LA LISTA,
        //SELECCIONADA ALEATORIAMENTE.
        //EL MISMO INDICE LO USO PARA SELECCIONAR EL COLOR DEL ARRAY DE COLORES
        //DE ESTA FORMA A CADA PIEZA LE CORRESPONDERA UN SOLO COLOR
        public void ObtenerFigura()
        {
            _indiceFigura = _r.Next(0, _figuras.Count);
            _figuraActual = _figuras[_indiceFigura];
        }

        public void Empezar()
        {
            // this._estaFuncionando = true;
            // if(_estaFuncionando )
            ObtenerFigura(); //CARGO LA FIGURA A LA MATRIZ CON LA LISTA

            _posicion.X = 3; // SETEO LA POSICION INICIAL DE LA PIEZA
            _posicion.Y = 0;

            _temporizador.Interval = _intervalosTiempo[_indiceTiempos];

            if (_indiceTiempos + 1 < _lineasVector.Length && (_lineasCompletas > _lineasVector[_indiceTiempos]))
            {
                _indiceTiempos++;
            }

            _temporizador.Start(); //INICIO EL TEMP
        }

        public void DibujarCuadricula(PaintEventArgs e)
        {
            int tam = _figuraActual.GetLength(0);
            int lado = 30;
            Rectangle rect;
            SolidBrush pincel = new SolidBrush(Color.Black);
            Graphics gr = e.Graphics;

            for (int i = 0; i < FILAS; i++)
            {
                for (int j = 0; j < COL; j++)
                {
                    rect = new Rectangle(i * lado,
                        j * lado, lado - 1, lado - 1);
                    gr.FillRectangle(pincel, rect);
                }
            }

            //MOSTRAR PUNTAJE ACUMULADO
            FontFamily tipografia = new FontFamily("Times New Roman");
            Font font = new Font(tipografia, 15, FontStyle.Bold, GraphicsUnit.Pixel);
            PointF pointF = new PointF(Width - 60, 0);
            SolidBrush solidBrush = new SolidBrush(Color.White);
            gr.DrawString(_puntos.ToString(), font, solidBrush, pointF);
            //  gr.DrawString(this._lineasCompletas.ToString(), font, solidBrush, new Point(Width - 60, 20));
            //  gr.DrawString(this._intervalosTiempo[_indiceTiempos].ToString(), font, solidBrush, new Point(Width - 60, 40));

        }


        public void DibujarTablero(PaintEventArgs e)
        {
            int tam = _figuraActual.GetLength(0);
            int lado = 30;
            Rectangle rect;
            SolidBrush pincel;// = new SolidBrush(_color [_indiceFigura]);
            Graphics gr = e.Graphics;

            for (int i = 0; i < FILAS; i++)
            {
                for (int j = 0; j < COL; j++)
                {
                    if (_tablero[i, j] != 0)
                    {
                        rect = new Rectangle(i * lado,
                            j * lado, lado - 1, lado - 1);

                        // _claros = new Color[] { Color.Pink, Color.LightGreen, Color.Cyan, Color.Yellow, Color.Magenta, Color.Orange, Color.Fuchsia };
                        Color unColor;
                        switch (_tablero[i, j])
                        {
                            case 1:
                                unColor = Color.Pink; break;
                            case 2:
                                unColor = Color.LightGreen; break;
                            case 3:
                                unColor = Color.Cyan; break;
                            case 4:
                                unColor = Color.Yellow; break;
                            case 5:
                                unColor = Color.Magenta; break;
                            case 6:
                                unColor = Color.Orange; break;
                            case 7:
                                unColor = Color.Fuchsia; break;
                            default:
                                unColor = Color.Black; break;

                        }
                        pincel = new SolidBrush(unColor);
                        gr.FillRectangle(pincel, rect);
                    }
                }
            }

        }

        public void DibujarPieza(PaintEventArgs e)
        {
            int tam = _figuraActual.GetLength(0);
            int lado = 30;
            Rectangle rect;
            Rectangle rectChico;
            SolidBrush pincel = new SolidBrush(_color[_indiceFigura]);
            SolidBrush pinClaros = new SolidBrush(_claros[_indiceFigura]);
            Graphics gr = e.Graphics;

            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam; j++)
                {
                    if (_figuraActual[i, j] != 0)
                    {
                        rect = new Rectangle((_posicion.X + i) * lado,
                            (_posicion.Y + j) * lado, lado - 1, lado - 1);

                        rectChico = new Rectangle((_posicion.X + i) * (lado) + 5,
                            (_posicion.Y + j) * (lado) + 5, lado - 10, lado - 10);

                        gr.FillRectangle(pincel, rect);
                        gr.FillRectangle(pinClaros, rectChico);
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

        public static List<Estadisticas> DeserializarListaEstadisticas(string ruta)
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


    }//fin clase tetris


}


//PUNTOS PODRIA SER:
//1 linea = 1(2)= 1 * 10 = 10
//2 lineas = 2(2)=4 * 10 = 40
//3 lineas = 3(2)=9  * 10 = 90
//4 lineas = 4(2)=16 * 10 = 160

//como es mas dificil y menos probable hacer 4 lineas juntas,
//entonces es mas premiado 