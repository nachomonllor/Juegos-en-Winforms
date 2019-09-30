using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simon_C_Sharp
{
    public class Estadisticas
    {
        private int _puntos;
        private DateTime _fechaActual;

        //CONSTRUCTOR PARA LA DESERIALIZACION
        public Estadisticas() { }

        public Estadisticas(int puntos, DateTime fechaActual)
        {
            this._puntos = puntos;
            this._fechaActual = fechaActual;
        }

        public int Puntos
        {
            get { return _puntos; }
            set { _puntos = value; }
        }

        public DateTime FechaActual
        {
            get { return _fechaActual; }
            set { _fechaActual = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Puntos = " + this._puntos);
            sb.Append("  -  Fecha: " + _fechaActual.ToString());
            return sb.ToString();
        }

        public static int OrdenarPorPuntos(Estadisticas uno, Estadisticas dos)
        {
            return dos._puntos.CompareTo(uno._puntos);
        }

        public static int OrdenarPorFecha(Estadisticas uno, Estadisticas dos)
        {
            return dos._fechaActual.CompareTo(uno._fechaActual);
        }

    }
}
