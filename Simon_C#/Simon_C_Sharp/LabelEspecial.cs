using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Simon_C_Sharp
{
    public class LabelEspecial : Label
    {
        private Color _colorEnfocado;
        private Color _colorDesenfocado;

        public LabelEspecial()
        {
            this.MouseDown += new MouseEventHandler(Presionar);
            this.MouseUp += new MouseEventHandler(Soltar);
        }

        public Color ColorEnfocado
        {
            get { return _colorEnfocado; }
            set { _colorEnfocado = value; }
        }

        public Color ColorDesenfocado
        {
            get { return _colorDesenfocado; }
            set { _colorDesenfocado = value; }
        }

        public void Presionar(Object sender, EventArgs e)
        {
            this.BackColor = this._colorEnfocado;
        }

        public void Soltar(Object sender, EventArgs e)
        {
            this.BackColor = this._colorDesenfocado;
        }


    }
}
