using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FrmPacMan : Form
    {
        private JuegoPacMan _juegoPacMan;

        public FrmPacMan()
        {
            InitializeComponent();
            _juegoPacMan = new JuegoPacMan();
            Resize+=new EventHandler(FrmPacMan_Resize);

            ClientSize = new Size(640, 640);
            this.Controls.Add(_juegoPacMan);
            _juegoPacMan.Empezar();
           // this.btnIntervalo.Enabled = false;
           // this.txtIntervalo.Enabled = false;
            this.btnIntervalo.Visible = false;
            this.txtIntervalo.Visible = false;

        }

        public void FrmPacMan_Resize(Object sender, EventArgs e)
        {
            this._juegoPacMan.Size = ClientSize;
        }

        private void btnIntervalo_Click(object sender, EventArgs e)
        {
            this._juegoPacMan._temporizador.Interval = int.Parse(this.txtIntervalo.Text);
        }




    }
}
