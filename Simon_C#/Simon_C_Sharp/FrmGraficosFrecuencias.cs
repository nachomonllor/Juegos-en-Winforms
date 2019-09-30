using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ZedGraph;

namespace Simon_C_Sharp
{

    public partial class FrmGraficosFrecuencias : Form
    {

        private List<Estadisticas> _listaDeEstadisticas;
        private double[] x;
        private double[] y;

        public FrmGraficosFrecuencias()
        {

            InitializeComponent();

            if (File.Exists(Program._archivoPuntajes))
            {
                _listaDeEstadisticas = FrmSimon.DeserializarListaEstadisticas(Program._archivoPuntajes);
            }
            else
            {
                _listaDeEstadisticas = new List<Estadisticas>();
            }

            if (_listaDeEstadisticas.Count > 0)
            {
                _listaDeEstadisticas.Sort(Estadisticas.OrdenarPorPuntos);
                // _listaDeEstadisticas.Reverse();

                // int tam = _listaDeEstadisticas.Count;
                int puntajeMayor = _listaDeEstadisticas[0].Puntos;

                y = new double[puntajeMayor + 1]; //para 1000 partidos
                for (int i = 0; i < puntajeMayor + 1; i++)
                {
                    y[i] = i;
                }

                foreach (int i in y)
                {
                    listBox1.Items.Add(i);
                }

                x = new double[500]; //PORQUE USA COMO INDICE AL PUNTAJE, POR SI LLEGA A 500 PUNTOS

                CargarFrecuenciasPuntuaciones();

                this.lblPromedio.Text = CalcularPromedioPuntos().ToString("0.0");

                foreach (int i in x)
                {
                    listBox2.Items.Add(i);
                }

            } //-------------------------


            //------------------------
            zedGraphControl1.GraphPane.Title.Text = "Frecuencias de puntuaciones";
            zedGraphControl1.GraphPane.XAxis.Title.Text = "Puntos";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "Cantidad de Partidos";

            GraphPane myPane = zedGraphControl1.GraphPane;
            PointPairList spl1 = new PointPairList(y, x);
            //  LineItem myCurve1 = myPane.AddCurve("Puntos", spl1, Color.Blue, SymbolType.None);
            // LineItem myCurve1 = myPane.AddCurve("Puntos", spl1, Color.Blue, SymbolType.None);
            BarItem uno = myPane.AddBar("Puntos", y, x, Color.Red);

            // myCurve1.Line.Width = 3.0F; //GROSOR DE LA LINEA

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            zedGraphControl1.Refresh();
            //-------------------------

           // this.lblVarianza.Text = CalcularVarianzaPuntos().ToString("0");
            this.lblDesvEstandard.Text = CalcularDevEstandardPuntos().ToString("0");
            this.lblCVariacion.Text = ObtenerCoeficienteVariacion().ToString("0") + " %";

            String moda="";

            if (Moda() == 0)
            {
                moda = "No hay Moda";
            }
            else if (Moda() > 0)
            {
                moda = Moda().ToString();
            }

            this.lblModa.Text = moda;    
        } //--------------------

 
        public void CargarFrecuenciasPuntuaciones()
        {
            for (int i = 0; i < _listaDeEstadisticas.Count; i++)
            {
                int puntos = _listaDeEstadisticas[i].Puntos;

                x[puntos]++;
            }

            bool bandera = false;
            double mayor = 0;
          //  int moda = 0, moda2 = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (bandera == false)
                {
                    mayor = x[i];
             //       moda = i;
                    bandera = true;
                }
                if (x[i] > mayor)
                {
                    mayor = x[i];
              //      moda = i;
                }
                if (x[i] == mayor)
                {
             //       moda2 = i;
                }
            }

         //   return moda;
        }


        private double CalcularPromedioPuntos()
        {
            double promedio;
            double sumatoriaPuntajes = 0;
            foreach (Estadisticas e in this._listaDeEstadisticas)
            {
                sumatoriaPuntajes += e.Puntos;
            }
            promedio = (Double)(sumatoriaPuntajes / _listaDeEstadisticas.Count);
            return promedio;
        }



        public double CalcularVarianzaPuntos()
        {
            double media = CalcularPromedioPuntos();
            double sumatoriaCuadrados = 0;
            foreach (Estadisticas e in _listaDeEstadisticas)
            {
                sumatoriaCuadrados += Math.Pow((e.Puntos - media), 2);
            }
            double varianza = (sumatoriaCuadrados / _listaDeEstadisticas.Count);
            return varianza;
        }

        public double CalcularDevEstandardPuntos()
        {
            return Math.Sqrt(CalcularVarianzaPuntos()); //raiz cuadrada de la varianza
        }


        //El coeficiente de variación es la relación entre la desviación típica
        //de una muestra y su media.
        //El coeficiente de variación se suele expresar en porcentajes:

        //C.V = o / x * 100

        public double ObtenerCoeficienteVariacion()
        {
            return (CalcularDevEstandardPuntos() / CalcularPromedioPuntos()) * 100;
        }




        public float Moda()
        {

            float[] vector = new float[_listaDeEstadisticas.Count];

            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = _listaDeEstadisticas[i].Puntos;
            }
            
            int n = vector.Length;

            float moda = 0;
            int maxim = 0, minim = 0;
            float t = 0;
            for (int i = 0; i < n; i++)
            {
                minim = 0;
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        if (vector[i] == vector[j])
                        { 
                            minim++; 
                        }
                    }
                }
                if (minim > maxim)
                {
                    maxim = minim;
                    t = vector[i];
                }
            }
            minim = 0;
            if (maxim == minim)
            {
               // Console.WriteLine("No hay moda");
                return 0;
            }
            else
            {
                for (int k = 0; k < n; k++)
                {
                    if (t == vector[k])
                    {
                        moda = vector[k];

                    }
                }
                return moda;
            }
        }




    }//-------------------
}


//public void CargarCantidadesIntervalosX(int tamVector)
//{
//    //recorre cada elemento de la lista
//    for (int i = 0; i < _listaDeEstadisticas.Count; i++)
//    {
//        int puntos = _listaDeEstadisticas[i].Puntos;
//        for (int indice = 0; indice <= tamVector; indice++) //150
//        {
//            if ((puntos >= indice) && (puntos < (indice + 1)))
//            {
//                x[indice]++;
//            }
//        }
//    }
//}

//public void CargarCantidadesPuntos()
//{
//    for (int i = 0; i < _listaDeEstadisticas.Count; i++)
//    {
//        int puntos = _listaDeEstadisticas[i].Puntos;
//    }
//}


//public int[] MostrarVecesQueSeRepiten()
//{
//    int[] vectorRepeticiones = new int[20];

//    for (int i = 0; i < _datos.Count; i++)
//    {
//        vectorRepeticiones[_datos[i]]++;
//    }

//    Console.WriteLine();
//    for (int i = 0; i < vectorRepeticiones.Length; i++)
//    {
//        Console.WriteLine("El num {0} se repite {1} veces", i, vectorRepeticiones[i]);
//    }

//    return vectorRepeticiones;
//}

//public void CargarCantidadesIntervalosX(int tamVector)
//{
//    //recorre cada elemento de la lista
//    for (int i = 0; i < _listaDeEstadisticas.Count; i++)
//    {
//        int puntos = _listaDeEstadisticas[i].Puntos;
//        for (int indice = 0; indice <= tamVector; indice++) //150
//        {
//            if ((puntos >= indice) && (puntos < (indice + 1)))
//            {
//                x[indice]++;
//            }
//        }
//    }
//}


