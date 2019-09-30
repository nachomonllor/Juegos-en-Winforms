using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubeCrash_Celdas
{
    public class Tablero
    {

        private int _filas;
        private int _columnas;
        private int _cantidadColores;
        private Celda[,] _matriz;
        private List<Celda> _grupoCeldasSeleccionadas;
        private Random _r;

        public Tablero(int filas, int columnas, int cantidadColores)
        {
            this._r = new Random();
            this._filas = filas;
            this._columnas = columnas;
            this._cantidadColores = cantidadColores;
            this._matriz = new Celda[filas, columnas];
            this._grupoCeldasSeleccionadas = new List<Celda>();
        
        }  //-------------------------------------------------------

        public int Filas
        {
            get { return _filas; }
            set { _filas = value; }
        }

        public int Columnas
        {
            get { return _columnas; }
            set { _columnas = value; }
        }

        public int CantidadColores
        {
            get { return _cantidadColores; }
            set { _cantidadColores = value; }
        }

        public Celda[,] Matriz
        {
            get { return _matriz; }
            set { _matriz = value; }
        }

        public void Inicializar()
        {
            for (int i = 0; i < _filas; i++)
                for (int j = 0; j < _columnas; j++)
                    _matriz[i, j] = new Celda(i, j, _r.Next(_cantidadColores));
        }

        public bool EsCeldaValida(int fila, int columna)
        {
            if (fila < 0 || fila >= _filas || columna < 0 || columna >= _columnas)
                return false;
            return true;
        }

        private List<Celda> ObtenerCeldasVecinas(Celda c)
        {
            List<Celda> lista = new List<Celda>();
            int fila = c.Fila;
            int columna = c.Columna;

            if (EsCeldaValida(fila - 1, columna) && _matriz[fila - 1, columna] != null)
                lista.Add(_matriz[fila - 1, columna]);

            if (EsCeldaValida(fila, columna - 1) && _matriz[fila, columna - 1] != null)
                lista.Add(_matriz[fila, columna - 1]);

            if (EsCeldaValida(fila, columna + 1) && _matriz[fila, columna + 1] != null)
                lista.Add(_matriz[fila, columna + 1]);

            if (EsCeldaValida(fila + 1, columna) && _matriz[fila + 1, columna] != null)
                lista.Add(_matriz[fila + 1, columna]);

            return lista;
        }

        public void Seleccionar(Celda c)
        {
            _grupoCeldasSeleccionadas.Add(c);
            List<Celda> lista = ObtenerCeldasVecinas(c);
            if (lista.Count == 0) return;

            for (int i = 0; i < lista.Count; i++)
            {
                if ( (lista[i].IndiceColor == c.IndiceColor) &&
                       !this._grupoCeldasSeleccionadas.Contains(lista[i]))
                {
                    Seleccionar(lista[i]);
                }
            }

        } //--------------------------------------------------

        public List<Celda> GrupoCeldasSeleccionadas
        {
            get
            {
                if (_grupoCeldasSeleccionadas.Count < 3)
                    _grupoCeldasSeleccionadas.Clear();
                return _grupoCeldasSeleccionadas;
            }

        }//---------------------------------------

        //public void Eliminar(ArrayList unArray)
        //{
        //    if (unArray.Count > 0)
        //    {
        //        _pilaDeshacer.Push(ObtenerArrayDeColor());
        //        //borrar la pila deshacer
        //        _pilaRehacer.Clear();
        //        foreach (Celda c in unArray)
        //        {
        //            _tablero[c.Fila, c.Columna] = null;
        //        }
        //        Sincronizar();
        //        this._totalPuntaje += ObtenerPuntaje(unArray.Count);
        //        this._seleccionado.Clear();
        //    }
        //}

        public void Eliminar(List<Celda> celdas)
        {
            if (celdas.Count > 0)
            {
                for (int i = 0; i < celdas.Count; i++)
                {
                    _matriz[celdas[i].Fila, celdas[i].Columna] = null;
                }
                Sincronizar();
                //  this._grupoCeldasSeleccionadas.Clear();
            }

        }  //-------------------------------------

        public void Sincronizar()
        {
            for (int veces = 0; veces < _filas; veces++)
            {
                for (int i = 0; i < _filas - 1; i++)
                {
                    for (int j = 0; j < _columnas; j++)
                    {
                        Celda c = _matriz[i, j];
                        if (c != null)
                        {
                            Celda celdaAbajo = _matriz[c.Fila + 1, c.Columna];
                            if (celdaAbajo == null)
                            {
                                this._matriz[c.Fila + 1, c.Columna] = c;
                                this._matriz[c.Fila, c.Columna] = null;
                                c.Fila++;

                            }
                        }
                    }
                }
            }

            //PARA JUNTAR EL TABLERO
            for (int veces = 0; veces < _columnas; veces++)
            {
                for (int i = 1; i < _columnas; i++)
                {
                    if (EsColumnaVacia(i))
                        MoverColumna(i);
                }
            }

        } //--------------------------------

        private bool EsColumnaVacia(int columna)
        {
            //CON FIJARME EN LA ULTIMA FILA ES SUFICIENTE
            if (_matriz[_filas - 1, columna] != null) return false;
            return true;
        }


        private void MoverColumna(int columna)
        {
            for (int i = 0; i < _filas; i++)
            {
                Celda c = _matriz[i, columna - 1];
                if (c != null)
                {
                    c.Columna = columna;
                    _matriz[i, columna] = c;
                    _matriz[i, columna - 1] = null;
                }
            }
        }




 



    }//--------------------------------

}
