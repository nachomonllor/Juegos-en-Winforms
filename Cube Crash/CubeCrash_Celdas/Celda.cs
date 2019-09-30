using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubeCrash_Celdas
{
    public class Celda
    {
        private int _fila;
        private int _columna;
        private int _indiceColor;

        public Celda(int fila, int columna, int indiceColor)
        {
            this._fila = fila;
            this._columna = columna;
            this._indiceColor = indiceColor;
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

        public int IndiceColor
        {
            get { return _indiceColor; }
            set { _indiceColor = value; }
        }
 


    }
}
