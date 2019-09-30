using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public enum DireccionDeMovimiento
    {
        Izquierda,
        Derecha,
        Arriba,
        Abajo,
        Detenido //SOLO PARA EL COMIENZO, PERMITE QUE EL FANTASMA ESTE QUIETO
    }

    public class Fantasma
    {

        public Posicion _posicion;
        private Color _color;
        public DireccionDeMovimiento _direccionActual;
        public List<DireccionDeMovimiento> _direccionesDisponibles;


        public Fantasma(Color colorFantasma)
        {
            _posicion = new Posicion();
            _posicion.X = 10;
            _posicion.Y = 10;
            _color = colorFantasma;
            this._direccionActual = new DireccionDeMovimiento();
            this._direccionesDisponibles = new List<DireccionDeMovimiento>();
        }

        public Color ColorFantasma
        {
            get { return _color; }
        }

        //GUARDO LAS DIRECCIONES DISPONIBLES EN UNA LISTA
        //Y DE AHI LAS SELECCIONO ALEATORIAMENTE
        //YA QUE SI NO HAGO ESTO , Y SELECCIONO UNA DIRECCION ALEATORIA SIN VERIFICAR PRIMERO
        //EN CADA TICK DEL TIMER BUSCA MOVER, PERO SI NO ESTA APROBADO EL MOVIMIENTO PORQUE HAY PARED,
        //O PORQUE SE SALE DE LA MATRIZ EL FANTASMA SE QUEDA PARADO Y NO SE MUEVE HASTA
        //QUE SE SELECCIONE UNA DIRECCION VALIDA 
        //ASI DE ESTA FORMA (EVALUANDOLA PRIMERO) SE MUEVEN CONSTANTEMENTE Y SOLUCIONA EL PROBLEMA
        
        public void ObtenerDireccionesDisponibles(int[,] tab)
        {
            this._direccionesDisponibles = new List<DireccionDeMovimiento>();

            /// ----------  ---- ABAJO----------------------
            if (this._posicion.Y + 1 < JuegoPacMan.FILAS &&
                tab[this._posicion.Y + 1, this._posicion.X] != 1)
            {
                this._direccionesDisponibles.Add(DireccionDeMovimiento.Abajo);
            }
            //------PARA QUE NO VUELVA A ENTRAR EN LA CASA DE LOS FANTASMAS-------
            if (this._posicion.Y == 8 && this._posicion.X == 10)
            {
                this._direccionesDisponibles.Remove(DireccionDeMovimiento.Abajo);
            }

            //////--------------ARRIBA--------------
            if (this._posicion.Y - 1 >= 0 &&
                tab[this._posicion.Y - 1, this._posicion.X] != 1)
            {
                this._direccionesDisponibles.Add(DireccionDeMovimiento.Arriba);
            }
            /////-------------------DERECHA---------
            if (this._posicion.X + 1 < JuegoPacMan.COLUMNAS &&
                tab[this._posicion.Y, this._posicion.X + 1] != 1)
            {
                this._direccionesDisponibles.Add(DireccionDeMovimiento.Derecha);
            }
            ///// -------------IZQUIERDA-------------
            if (this._posicion.X - 1 >= 0 &&
                tab[this._posicion.Y, this._posicion.X - 1] != 1)
            {
                this._direccionesDisponibles.Add(DireccionDeMovimiento.Izquierda);
            }

        }//---------------------------------------------------------------------

        //EL NUMERO ALEATORIO NO LO INGRESO DESDE ESTA CLASE PORQUE NO FUNCIONARIA
        // ( O SEA NO USO UN ATRIBUTO RANDOM EN ESTA CLASE )
        public void ObtenerDireccionAleatoria(int dirAleatoria) 
        {
            this._direccionActual = this._direccionesDisponibles[dirAleatoria];
        }

        public void MoverFantasma(int[,] tab)
        {
            switch (this._direccionActual)
            {
                case DireccionDeMovimiento.Abajo:
                    this._posicion.Y++;
                    break;
                case DireccionDeMovimiento.Arriba:
                    this._posicion.Y--;
                    break;
                case DireccionDeMovimiento.Derecha:
                    this._posicion.X++;
                    break;
                case DireccionDeMovimiento.Izquierda:
                    this._posicion.X--;
                    break;
            }
        }


        //PARAM hayEnergia: para saber si lo tengo que pintar normal o comible, en marron
        public void DibujarFantasma(PaintEventArgs e, bool hayEnergia)
        {
            int lado = 30;
            Rectangle rect;
            SolidBrush pincel;
            Graphics g = e.Graphics;
            Color color = Color.Brown; //SI EL FANTASMA ES COMIBLE DEJO EL COLOR MARRON DE INICIO

            //SI EL FANTASMA ESTA NORMAL, 
            //CARGO AL COLOR CON EL COLOR PASADO POR EL CONSTRUCTOR
            if (hayEnergia == false)
            {
                color = this.ColorFantasma;
            } //sino, queda con el color de inicio
 
            pincel = new SolidBrush(color);
            rect = new Rectangle(_posicion.X * lado,
                _posicion.Y * lado, lado - 1, lado - 1);

            g.FillRectangle(pincel, rect);
        }


    }

}


