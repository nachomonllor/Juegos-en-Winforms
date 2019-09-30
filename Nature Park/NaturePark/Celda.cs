using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaturePark
{
    public class Celda
    {
        private int _fila;
        private int _columna;
        private int _color;

        public Celda(int fila, int columna, int color)
        {
            this._fila = fila;
            this._columna = columna;
            this._color = color;
        }

        public int Fila
        {
            get { return _fila; }
            set { _fila = value; }
        }

        public int Columna
        {
            get { return _columna; }
            set { _columna = value; }
        }

        public int ColorDeCelda
        {
            get { return _color; }
            set { _color = value; }
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("({0}, {1}) = {2}", _fila, _columna, _color);

            return sb.ToString();
        }
            






    }
}
