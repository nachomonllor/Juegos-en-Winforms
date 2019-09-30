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
    public enum TipoOrdenamiento
    {
        Puntos, Fecha
    }

    public partial class FrmEstadisticas : Form
    {

        private List<Estadisticas> _listaDeEstadisticas;
       // private int _recordPuntos;

        public FrmEstadisticas(List<Estadisticas> lista)
        {
            InitializeComponent();

            _listaDeEstadisticas = lista;

            if (File.Exists(Inicio.Ruta))
            {
                _listaDeEstadisticas = Tetris.DeserializarListaEstadisticas(Inicio.Ruta);
            }
            CargarListBox();
            CargarComboOrdenamiento();


            this.lblPromedioPuntos.Text = CalcularPromedioPuntos().ToString("0");
            this.lblMediana.Text = CalcularMedianaPuntos().ToString("0");
            this.lblVarianza.Text = CalcularVarianzaPuntos().ToString("0");
            this.lblDesvEstandard.Text = CalcularDevEstandardPuntos().ToString("0");
            this.listBox1.Visible = false;

            ObtenerLapsosTiempoEntrePartidos();
            MostrarNumeroLineas();


            this.cboTipoOrdenamiento.SelectedIndexChanged +=
                new EventHandler(CambioComboIndiceSeleccionado);

        }

        public List<Estadisticas> ListaDeEstadisticas
        {
            get { return _listaDeEstadisticas; }
            set { _listaDeEstadisticas = value; }
        }

        private void CargarComboOrdenamiento()
        {
            this.cboTipoOrdenamiento.Items.AddRange(new string[] { "Puntos", "Fecha" });
            this.cboTipoOrdenamiento.SelectedIndex = 0;
            this.cboTipoOrdenamiento.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        public void CargarListBox()
        {
            this.lstPuntajes.Items.Clear();
            foreach (Estadisticas e in _listaDeEstadisticas )
            {
                this.lstPuntajes.Items.Add(e.ToString());
            }
        }

        private void CambioComboIndiceSeleccionado(Object sender, EventArgs e)
        {
            Ordenar();
            CargarListBox();
        }

        //ORDENO LA LISTA TOMANDO COMO PARAMETRO EL INDICE SELECCIONADO EN EL COMBO
        public void Ordenar()
        {
            OrdenarLista((TipoOrdenamiento)cboTipoOrdenamiento.SelectedIndex);
        }

        //ORDENO LA LISTA USANDO EL OBJETO COMPARISON QUE ESTA HECHO PARA ESO, EL BURBUJEO ES MAS LENTO
        public void OrdenarLista(TipoOrdenamiento tipo)
        {
            Comparison<Estadisticas> miComparador = null;
            switch (tipo)
            {
                case TipoOrdenamiento.Fecha:
                    miComparador = new Comparison<Estadisticas>(Estadisticas.OrdenarPorFecha);
                    break;
                case TipoOrdenamiento.Puntos:
                    miComparador = new Comparison<Estadisticas>(Estadisticas.OrdenarPorPuntos);
                    break;
            }
            this._listaDeEstadisticas.Sort(miComparador); //EL METODO SORT TIENE UNA SOBRECARGA DONDE RECIBE UN OBJETO COMPARISON
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

        //public void CalcularVarianza_DesvEstandard()
        //{
        //    float sumCuadrados = 0;
        //    float media = CalcularMedia();


        //    for (int i = 0; i < _listaDeAlumnos.Count; i++)
        //    {
        //        sumCuadrados += (float)Math.Pow((_listaDeAlumnos[i].Nota - media), 2);
        //    }

        //    float varianza = (sumCuadrados / _listaDeAlumnos.Count);
        //    float desviacionEstandard = (float)Math.Sqrt(varianza);

        //    Console.WriteLine("Varianza = " + varianza);
        //    Console.WriteLine("Desviacion estandard = " + desviacionEstandard);
        //}

        public double CalcularVarianzaPuntos()
        {
            double media = CalcularPromedioPuntos();
            double sumatoriaCuadrados=0;
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

 

        //EN ALGUNOS CASOS LA MEDIANA ES MAS REPRESENTATIVA QUE EL PROMEDIO:
        // http://es.wikipedia.org/wiki/Mediana_(estadística)
        private float CalcularMedianaPuntos()
        {
            float mediana = 0;
            //PRIMERO ORDENO LA LISTA POR PUNTOS
            Comparison<Estadisticas> miComparador =
                new Comparison<Estadisticas>(Estadisticas.OrdenarPorPuntos);
            List<Estadisticas> listaAux = this._listaDeEstadisticas;
            listaAux.Sort(miComparador);

            //this._recordPuntos = listaAux[0].Puntos;
            //MUESTRO EL MEJOR PUNTAJE
            this.lblRecord.Text = listaAux[0].Puntos.ToString();

           
            if (listaAux.Count == 1) //si tiene un elemento solo
            {
                return (float)(listaAux[0].Puntos);
            }
            else if (listaAux.Count > 1) //a partir de 2 elementos
            {
                int valor1 = listaAux[(int)(listaAux.Count / 2) - 1].Puntos;
                int valor2 = listaAux[(int)(listaAux.Count / 2)].Puntos;
                if (listaAux.Count % 2 == 0)
                {
                    mediana = (float)((valor1 + valor2) / 2);
                }
                else if (listaAux.Count % 2 != 0)
                {
                    mediana = (float)valor2;
                }
                return mediana;
            }
            else  //si la lista esta vacia
            {
                return 0.0f;
            }
           
        }


        //PARA MEDIR INTERVALOS DE TIEMPO USAMOS DATETIME Y TIMESPAN
        public void ObtenerLapsosTiempoEntrePartidos()
        {
            List<DateTime> fechas = new List<DateTime>();

            Comparison<Estadisticas> miComparador =
                new Comparison<Estadisticas>(Estadisticas.OrdenarPorFecha);
            List<Estadisticas> listaOrdenada = _listaDeEstadisticas;
            listaOrdenada.Sort(miComparador);

            foreach (Estadisticas e in listaOrdenada)
            {
                fechas.Add(e.FechaActual);
            }

            TimeSpan lapsoMayor = new TimeSpan();
            TimeSpan lapsoTemp = new TimeSpan();

            DateTime fechaInicio = new DateTime();
            DateTime fechaFin = new DateTime();
            bool band = false;

            //CARGO LA LISTA DE LAPSOS
            List<TimeSpan> lapsos = new List<TimeSpan>();
            for (int i = 1; i < fechas.Count; i++)
            {
                lapsos.Add(fechas[i - 1] - fechas[i]); //DIFERENCIA ENTR FECHAS INMEDIATAS

                lapsoTemp = (fechas[i - 1] - fechas[i]);

                if (band == false)
                {
                    lapsoMayor = lapsoTemp;
                    fechaInicio = fechas[i];
                    fechaFin = fechas[i - 1];
                    band = true;
                }
                if (lapsoTemp > lapsoMayor)
                {
                    lapsoMayor = lapsoTemp;
                    fechaInicio = fechas[i];
                    fechaFin = fechas[i - 1];
                }
            }

            TimeSpan sumatoria = new TimeSpan();
            foreach (TimeSpan t in lapsos)
            {
                //MessageBox.Show(t.TotalDays.ToString());
                listBox1.Items.Add(t.TotalHours.ToString("0.0") + 
                    " Horas" + " (" + t.TotalMinutes.ToString("0.0") + "minutos)");

                sumatoria += t;
            }

            double promMinutos = sumatoria.TotalMinutes / lapsos.Count;
            double promDias = sumatoria.TotalDays / lapsos.Count;
            double promHoras = sumatoria.TotalHours / lapsos.Count;

            lblFrecuencia.Text = ("Jugas al tetris en promedio cada: "
                + promMinutos.ToString("0") + " Minutos  - "
                + promHoras.ToString("0.0") + " Horas"
                + "  (" + promDias.ToString("0.00") + " Dias)");


            LapsoMayor.Text ="Lapso Mayor sin jugar: " +
                lapsoMayor.TotalHours.ToString("0.0") + " Horas"
                + "  (Fecha Inicio: " + fechaInicio.ToString()
                + " Fecha Fin: " + fechaFin.ToString() + ") ";

        }


        public void MostrarNumeroLineas()
        {
            int sumX1 = 0, sumX2 = 0, sumX3 = 0, sumX4 = 0;

            foreach (Estadisticas e in _listaDeEstadisticas)
            {
                sumX1 += e.X1;
                sumX2 += e.X2;
                sumX3 += e.X3;
                sumX4 += e.X4;
            }

            int total = sumX1 + sumX2 + sumX3 + sumX4;
            double porcentajeX1 = (sumX1 / (double)total) * 100;
            double porcentajeX2 = (sumX2 / (double)total) * 100;
            double porcentajeX3 = (sumX3 / (double)total) * 100;
            double porcentajeX4 = (sumX4 / (double)total) * 100;

            lblX1.Text = porcentajeX1.ToString("0.0") + " %";
            lblX2.Text = porcentajeX2.ToString("0.0") + " %";
            lblX3.Text = porcentajeX3.ToString("0.0") + " %";
            lblX4.Text = porcentajeX4.ToString("0.0") + " %";
        }

        private void btnMediana_Click(object sender, EventArgs e)
        {
            MessageBox.Show("En el ámbito de la estadística, "+
            "la mediana, representa el valor de la variable de posición central" +
            " en un conjunto de datos ordenados."+
            " De acuerdo con esta definición el conjunto de datos menores"+
            " o iguales que la mediana representarán el 50% de los datos,"+
            " y los que sean mayores que la mediana representarán el otro 50%"+
            " del total de datos de la muestra."+
            " La mediana coincide con el percentil 50, con el segundo cuartil"+
            " y con el quinto decil. Su cálculo no se ve afectado por valores extremos.");

        }

        private void FrmEstadisticas_Load(object sender, EventArgs e)
        {
        }








    }
}
