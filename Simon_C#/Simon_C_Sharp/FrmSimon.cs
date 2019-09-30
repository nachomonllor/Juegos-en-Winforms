using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Xml.Serialization;
using System.Xml;

namespace Simon_C_Sharp
{
    public partial class FrmSimon : Form 
    {

        private int _limite;
        private Random _aleatorio;
        private List<int> _secuenciaAleatoria;
        private int _indiceSecuencia;
        private int _tiempoRetardo;
        private int _contadorCorrectos;
        private int _numeroUsuario;  
        private int _puntaje;
        private List<Estadisticas> _listaDeEstadisticas;

        public FrmSimon()
        {
            InitializeComponent();

            this._tiempoRetardo = 300;

            this._listaDeEstadisticas = new List<Estadisticas>();
            this._secuenciaAleatoria = new List<int>();

            this.FormClosing += new FormClosingEventHandler(CerrandoAplicacion);

            labelEspecial1.ColorEnfocado = Color.Cyan;
            labelEspecial1.ColorDesenfocado = Color.Blue;

            labelEspecial2.ColorEnfocado = Color.LightGreen;
            labelEspecial2.ColorDesenfocado = Color.DarkGreen;

            labelEspecial3.ColorEnfocado = Color.LightPink;
            labelEspecial3.ColorDesenfocado = Color.Red;

            labelEspecial4.ColorEnfocado = Color.Violet;
            labelEspecial4.ColorDesenfocado = Color.DarkViolet;

            if (File.Exists(Program._archivoPuntajes))
            {
                _listaDeEstadisticas = DeserializarListaEstadisticas(Program._archivoPuntajes);
            }
            CargarSecuenciaAleatoria();
            CargarListBox();

        }

        private void FrmSimon_Load(object sender, EventArgs e)
        {
        }
 
        private void InicializarLabels()
        {
            labelEspecial1.BackColor = Color.Blue;
            labelEspecial2.BackColor = Color.DarkGreen;
            labelEspecial3.BackColor = Color.Red;
            labelEspecial4.BackColor = Color.DarkViolet;
        }

        public void AgregarManejadoresLabels()
        {
            foreach (Control c in this.Controls)
            {
                if (c is LabelEspecial)
                {
                    c.MouseDown += new MouseEventHandler(LabelsEspecial_MouseDown);
                }
            }
        }

        public void QuitarManejadoresLabels()
        {
            foreach (Control c in this.Controls)
            {
                if (c is LabelEspecial)
                {
                    c.MouseDown -= new MouseEventHandler(LabelsEspecial_MouseDown);
                }
            }
        
        }
 
        private void CargarSecuenciaAleatoria()
        {
            this._aleatorio = new Random();

            for (int i = 0; i < 100; i++)
            {
                _secuenciaAleatoria.Add(_aleatorio.Next(0, 4));
            }

        }
 
        private void CargarListBox()
        {
            this.lstSecuencia.Items.Clear();

            foreach (int i in this._secuenciaAleatoria)
            {
                switch (i)
                {
                    case 0:
                        this.lstSecuencia.Items.Add("AZUL");
                        break;
                    case 1:
                        this.lstSecuencia.Items.Add("VERDE");
                        break;
                    case 2:
                        this.lstSecuencia.Items.Add("ROJO");
                        break;
                    case 3:
                        this.lstSecuencia.Items.Add("VIOLETA");
                        break;
                }
            }  
        }  


        private void Parpadear(LabelEspecial labelEspecial, Color colorEnfocado, Color colorDesenfocado)
        {
            labelEspecial.BackColor = colorEnfocado;
            labelEspecial.Refresh();
            Thread.Sleep(this._tiempoRetardo);

            labelEspecial.BackColor = colorDesenfocado;
            labelEspecial.Refresh();
            Thread.Sleep(this._tiempoRetardo);
        }
 
        public void MostrarSecuencia(Object sender, EventArgs e)
        {
            QuitarManejadoresLabels();
            InicializarLabels();
            MessageBox.Show("Empieza la secuencia");

            for (int i = 0; i <= _limite; i++)
            {
                if (_secuenciaAleatoria[i] == 0) Parpadear(labelEspecial1, this.labelEspecial1.ColorEnfocado, this.labelEspecial1.ColorDesenfocado);
                if (_secuenciaAleatoria[i] == 1) Parpadear(labelEspecial2, this.labelEspecial2.ColorEnfocado, this.labelEspecial2.ColorDesenfocado);
                if (_secuenciaAleatoria[i] == 2) Parpadear(labelEspecial3, this.labelEspecial3.ColorEnfocado, this.labelEspecial3.ColorDesenfocado);
                if (_secuenciaAleatoria[i] == 3) Parpadear(labelEspecial4, this.labelEspecial4.ColorEnfocado, this.labelEspecial4.ColorDesenfocado);
            }
            MessageBox.Show("Termina la secuencia, TURNO DEL USUARIO");
            AgregarManejadoresLabels();
        }

             
        private void LabelsEspecial_MouseDown(Object sender, MouseEventArgs e)
        {
            switch (((LabelEspecial)sender).Name)
            {
                case "labelEspecial1":
                    _numeroUsuario = 0; break;
                case "labelEspecial2":
                    _numeroUsuario = 1; break;
                case "labelEspecial3":
                    _numeroUsuario = 2; break;
                case "labelEspecial4":
                    _numeroUsuario = 3; break;
            }
 
            Comparar(sender, new EventArgs());   
        }//----------------

        public void Comparar(Object sender, EventArgs e)
        {
            if (_numeroUsuario == this._secuenciaAleatoria[_indiceSecuencia])
            {
                _contadorCorrectos++;
                _indiceSecuencia++;

                if (_contadorCorrectos == _limite + 1)
                {
                    _limite++;
                    _puntaje++;

                    _indiceSecuencia = 0;
                    _contadorCorrectos = 0;
                    // MessageBox.Show("TURNO MAQUINA")
                    MostrarSecuencia(sender, e);
                }//fin if
            }   
            else
            {
                MessageBox.Show("Incorrecto");
                GuardarPuntaje();

                //------------PUNTAJE-----------
              // this._listaDeEstadisticas .Add(new Estadisticas(_puntaje, DateTime.Now));
               this._listaDeEstadisticas.Add(new Estadisticas(_limite, DateTime.Now));
                //-----------------------

                _limite = 0;
                _indiceSecuencia = 0;
                _contadorCorrectos = 0;
                _secuenciaAleatoria.RemoveRange(0, _secuenciaAleatoria.Count - 1);
                CargarSecuenciaAleatoria();
                CargarListBox();
                MostrarSecuencia(sender, e);

            }
        } //---    


        private void btnEmpezar_Click_1(Object sender, EventArgs e)
        {
            MostrarSecuencia(sender, e);
        }
         
 
        private void GuardarPuntaje()
        {
            // My.Computer.FileSystem.WriteAllText("C:\PuntosSimon.txt", "Puntos: " & Me._puntaje.ToString() & " - Fecha: " & Date.Now.ToString & vbCrLf, True)
        }
   
        private bool SerializarListaPuntajes(String ruta)
        {
            bool pudo = false;
            try
            {
                using (XmlTextWriter escritor =
                    new XmlTextWriter(ruta, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(List<Estadisticas>));
                    ser.Serialize(escritor, this._listaDeEstadisticas);
                    pudo = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return pudo;
        }

        public static List<Estadisticas> DeserializarListaEstadisticas(String ruta)
        {
            List<Estadisticas> listaAux = new List<Estadisticas>();
            try
            {
                using (XmlTextReader lector = new XmlTextReader(ruta))
                {
                    XmlSerializer ser =
                        new XmlSerializer(typeof(List<Estadisticas>));
                    listaAux = (List<Estadisticas>)ser.Deserialize(lector);
                    //this._listaDeEstadisticas = listaAux;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return listaAux;
        }

        public void CerrandoAplicacion(Object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Seguro quiere salir ?", "Cerrando aplicacion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                 SerializarListaPuntajes(Program._archivoPuntajes);
              //  this.Dispose();
            }
            else
            {
                e.Cancel = true;
            }
        }

 
    } //----------------------------------------------------------------
}
 