using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaturePark
{
    public  class Pieza
    {

        private List<int[,]> _figura1;
        private List<int[,]> _figura2;
        private List<int[,]> _figura3;
        private List<int[,]> _figura4;
        private List<int[,]> _figura5;
        private List<int[,]> _figura6;
        private List<int[,]> _figura7;
        private List<int[,]> _figura8;
        private List<int[,]> _figura9;
        private List<int[,]> _figura10;

        private List<int[,]> _piedraL;      //11
        private List<int[,]> _piedraLinea;  //12

        private int[,] _bombaColumnas;      //13
        private int[,] _bombaColor;         //14

        private int[,] _bombaAdyacentes; //15


        public int _indiceRotacion;

        //private int _fila;
        //private int _columna;
        //private int _color;

 
        public Pieza()
        {

            this._indiceRotacion = 0;
            //FIGURA 1
            this._figura1 = new List<int[,]>();
            this._figura1.Add(new int[,]  /**/
            {                             /**/
                 {0,1},                   /**/
                 {2,1},                   /**/
                                          /**/
            });                           /**/
            this._figura1.Add(new int[,]
            {
                 {0,1},
                 {1,2},
            });
            this._figura1.Add(new int[,]
            {
                 {0,2},
                 {1,1},
            });

            //FIGURA 2
            this._figura2 = new List<int[,]>();
            this._figura2.Add(new int[,]
            {
                 {0,3},
                 {4,3}
            });
            this._figura2.Add(new int[,]
            {
                 {0,3},
                 {3,4}
            });
            this._figura2.Add(new int[,]
            {
                 {0,4},
                 {3,3}
            });


            //FIGURA 3
            this._figura3 = new List<int[,]>();
            _figura3.Add(new int[,]
            {
                 {3,3},
                 {0,4}
            });
            _figura3.Add(new int[,]
            {
                 {3,4},
                 {0,3}
            });
            _figura3.Add(new int[,]
            {
                 {4,3},
                 {0,3}
            });

            //FIGURA 4
            this._figura4 = new List<int[,]>();
            this._figura4.Add(new int[,]
            {
                {0,1},
                {3,2}
            });
            this._figura4.Add(new int[,]
            {
                {0,3},
                {2,1}
            });
            this._figura4.Add(new int[,]
            {
                {0,2},
                {1,3}
            });


            //FIGURA 5
            this._figura5 = new List<int[,]>();
            this._figura5.Add(new int[,]
            {
                {3,3}  ///UNA SOLA POSICION PARA ESTA PIEZA
            });

            //FIGURA 6
            this._figura6 = new List<int[,]>();
            this._figura6.Add(new int[,]
            {
                 {4,5}
            });
            this._figura6.Add(new int[,]
            {
                 {5,4}
            });


            //FIGURA 7
            this._figura7 = new List<int[,]>();
            this._figura7.Add(new int[,]
            {
                 {6},
                 {7}
            });
            this._figura7.Add(new int[,]
            {
                 {7},
                 {6}
            });

            //FIGURA 8
            this._figura8 = new List<int[,]>();
            this._figura8.Add(new int[,]
            {
                {5,5,5} //UNA POSICION
            });

            //FIGURA 9
            this._figura9 = new List<int[,]>();
            this._figura9.Add(new int[,]
            {
                {2,3,4}
            });
            this._figura9.Add(new int[,]
            {
                {4,2,3}
            });
            this._figura9.Add(new int[,]
            {
                {3,4,2}
            });

            //FIGURA 10
            this._figura10 = new List<int[,]>();
            this._figura10.Add(new int[,]
            {
                 {4},    
                 {5},   
                 {6}
            });
            this._figura10.Add(new int[,]
            {
                 {6},    
                 {4},   
                 {5}
            });
            this._figura10.Add(new int[,]
            {
                 {5},    
                 {6},   
                 {4}
            });


            //PIEDRA LINEA   //  11
            this._piedraLinea = new List<int[,]>(); 
            this._piedraLinea.Add(new int[,]
            {
                {-1,-1,-1,-1}
            });

            //PIEDRA L     // 12 
            this._piedraL = new List<int[,]>();
            this._piedraL.Add(new int[,]
            {
                {-1,  0},
                {-1, -1}
            });

            //BOMBA DE COLOR   //13
            this._bombaColor = new int[,]
            {
                {-2}
            };

            //BOMBA DE COLUMNAS   //14
            this._bombaColumnas = new int[,]
            {
                {-3}
            };

            this._bombaAdyacentes = new int[,]
            {
                {-4}
            };



        }



        public int[,] ObtenerPieza(int indicePieza)
        {
            if (indicePieza == 0)
            {
                if (_indiceRotacion >= _figura1.Count) _indiceRotacion = 0;
                return _figura1[_indiceRotacion];

            }
            if (indicePieza == 1)
            {
                if (_indiceRotacion >= _figura2.Count) _indiceRotacion = 0;
                return _figura2[_indiceRotacion];

            }
            if (indicePieza == 2)
            {
                if (_indiceRotacion >= _figura3.Count) _indiceRotacion = 0;
                return _figura3[_indiceRotacion];
            }


            if (indicePieza == 3)
            {
                if (_indiceRotacion >= _figura4.Count) _indiceRotacion = 0;
                return _figura4[_indiceRotacion];

            }
            if (indicePieza == 4)
            {
                //if (_indiceRotacion == _figura5.Count) _indiceRotacion = 0;
                return _figura5[0];

            }
            if (indicePieza == 5)
            {
                if (_indiceRotacion >= _figura6.Count) _indiceRotacion = 0;
                return _figura6[_indiceRotacion];
            }

            if (indicePieza == 6)
            {
                if (_indiceRotacion >= _figura7.Count) _indiceRotacion = 0;
                return _figura7[_indiceRotacion];
            }
            if (indicePieza == 7)
            {
                //if (_indiceRotacion == _figura8.Count) _indiceRotacion = 0;
                return _figura8[0];
            }
            if (indicePieza == 8)
            {
                if (_indiceRotacion >= _figura9.Count) _indiceRotacion = 0;
                return _figura9[_indiceRotacion];
            }

            if (indicePieza == 9)
            {
                if (_indiceRotacion >= _figura10.Count) _indiceRotacion = 0;
                return _figura10[_indiceRotacion];
            }

            /// /////////////////// PIEDRAS Y BOMBAS/////////////////////////

            if (indicePieza == 10)
            {
                return _piedraLinea[0];
            }
            if (indicePieza == 11)
            {
                return _piedraL[0];
            }

            if (indicePieza == 12)
            {
                return _bombaColor;
            }

            if (indicePieza == 13)
            {
                return _bombaColumnas;
            }

            if (indicePieza == 14)
            {
                return _bombaAdyacentes;
            }


            return null;
        }






    }
}
