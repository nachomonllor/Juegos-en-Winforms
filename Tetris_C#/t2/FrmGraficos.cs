﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ZedGraph;

namespace WindowsFormsApplication1
{
    public partial class FrmGraficos : Form
    {

 
        private List<Estadisticas> _listaDeEstadisticas;
       // private List<int> _puntos;

        public FrmGraficos(List<Estadisticas > lista)
        {
            InitializeComponent();
            _listaDeEstadisticas = lista;
            if (File.Exists(Inicio.Ruta))
            {
                _listaDeEstadisticas = Tetris.DeserializarListaEstadisticas(Inicio.Ruta);
            }

           // this._puntos = new List<int>();
            //for (int i = 0; i < _listaDeEstadisticas.Count ; i++)
            //{
            //    this._puntos.Add(_listaDeEstadisticas[i].Puntos);
            //}

            double[] x = new double[_listaDeEstadisticas.Count];
            double[] y = new double[_listaDeEstadisticas.Count];

            for (int i = 0; i < _listaDeEstadisticas.Count; i++)
            {
                x[i] = i;
                y[i] = _listaDeEstadisticas[i].Puntos;
            }

            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.Title.Text = "Puntos en funcion del tiempo";
            zedGraphControl1.GraphPane.XAxis.Title.Text = "Tiempo";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "Puntos";

            GraphPane myPane = zedGraphControl1.GraphPane;
            PointPairList spl1 = new PointPairList(x, y);
            LineItem myCurve1 = myPane.AddCurve("Puntos", spl1, Color.Blue, SymbolType.None);

            myCurve1.Line.Width = 2.0F; //GROSOR DE LA LINEA

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            zedGraphControl1.Refresh();

        }

 


    }
}