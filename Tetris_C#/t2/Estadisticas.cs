using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    [Serializable]
    public class Estadisticas
    {
        private int _puntos;
        private DateTime _fechaActual;
        private int _x1, _x2, _x3, _x4;

        //CONSTRUCTOR SIN PARAMETROS REQUERIDO PARA LA SERIALIZACION XML
        public Estadisticas() { }

        //public Estadisticas(int puntos, DateTime fecha)
        //{
        //    this._puntos = puntos;
        //    this._fechaActual = fecha;
        //}

        public Estadisticas(int puntos, DateTime fecha, int x1, int x2, int x3, int x4)
        {
            this._puntos = puntos;
            this._fechaActual = fecha;
            this._x1 = x1;
            this._x2 = x2;
            this._x3 = x3;
            this._x4 = x4;
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

        public int X1
        {
            get { return _x1; }
            set { _x1 = value; }
        }
        public int X2
        {
            get { return _x2; }
            set { _x2 = value; }
        }
        public int X3
        {
            get { return _x3; }
            set { _x3 = value; }
        }
        public int X4
        {
            get { return _x4; }
            set { _x4 = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Puntos: " + _puntos);
            if (_puntos == 0)
                sb.Append("\t\t");
            else
                sb.Append("\t");
            sb.Append("Fecha: " + _fechaActual.ToString());
            sb.Append("\t\t");
            sb.Append("X1= " + _x1 
                + ", X2= " + _x2
                + ", X3= " + _x3 
                + ", X4= " + _x4);
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
