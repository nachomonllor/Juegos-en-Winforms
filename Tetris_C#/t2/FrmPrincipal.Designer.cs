namespace WindowsFormsApplication1
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.juegoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reglasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puntosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadisticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadisticasGeneralesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graficosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puntosEnFuncionDelTiempoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maximaPuntuacionDeCadaDiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.juegoToolStripMenuItem,
            this.reglasToolStripMenuItem,
            this.estadisticasToolStripMenuItem,
            this.sobreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(520, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // juegoToolStripMenuItem
            // 
            this.juegoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem});
            this.juegoToolStripMenuItem.Name = "juegoToolStripMenuItem";
            this.juegoToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.juegoToolStripMenuItem.Text = "Juego";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // reglasToolStripMenuItem
            // 
            this.reglasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.puntosToolStripMenuItem,
            this.movimientosToolStripMenuItem});
            this.reglasToolStripMenuItem.Name = "reglasToolStripMenuItem";
            this.reglasToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.reglasToolStripMenuItem.Text = "Como Jugar";
            // 
            // puntosToolStripMenuItem
            // 
            this.puntosToolStripMenuItem.Name = "puntosToolStripMenuItem";
            this.puntosToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.puntosToolStripMenuItem.Text = "Puntos";
            this.puntosToolStripMenuItem.Click += new System.EventHandler(this.puntosToolStripMenuItem_Click);
            // 
            // movimientosToolStripMenuItem
            // 
            this.movimientosToolStripMenuItem.Name = "movimientosToolStripMenuItem";
            this.movimientosToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.movimientosToolStripMenuItem.Text = "Movimientos";
            this.movimientosToolStripMenuItem.Click += new System.EventHandler(this.movimientosToolStripMenuItem_Click);
            // 
            // estadisticasToolStripMenuItem
            // 
            this.estadisticasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.estadisticasGeneralesToolStripMenuItem,
            this.graficosToolStripMenuItem});
            this.estadisticasToolStripMenuItem.Name = "estadisticasToolStripMenuItem";
            this.estadisticasToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.estadisticasToolStripMenuItem.Text = "Estadisticas";
            // 
            // estadisticasGeneralesToolStripMenuItem
            // 
            this.estadisticasGeneralesToolStripMenuItem.Name = "estadisticasGeneralesToolStripMenuItem";
            this.estadisticasGeneralesToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.estadisticasGeneralesToolStripMenuItem.Text = "Estadisticas Generales";
            this.estadisticasGeneralesToolStripMenuItem.Click += new System.EventHandler(this.estadisticasGeneralesToolStripMenuItem_Click);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.sobreToolStripMenuItem.Text = "Sobre";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // graficosToolStripMenuItem
            // 
            this.graficosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.puntosEnFuncionDelTiempoToolStripMenuItem,
            this.maximaPuntuacionDeCadaDiaToolStripMenuItem});
            this.graficosToolStripMenuItem.Name = "graficosToolStripMenuItem";
            this.graficosToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.graficosToolStripMenuItem.Text = "Graficos";
            // 
            // puntosEnFuncionDelTiempoToolStripMenuItem
            // 
            this.puntosEnFuncionDelTiempoToolStripMenuItem.Name = "puntosEnFuncionDelTiempoToolStripMenuItem";
            this.puntosEnFuncionDelTiempoToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.puntosEnFuncionDelTiempoToolStripMenuItem.Text = "Todos los Partidos";
            this.puntosEnFuncionDelTiempoToolStripMenuItem.Click += new System.EventHandler(this.puntosEnFuncionDelTiempoToolStripMenuItem_Click);
            // 
            // maximaPuntuacionDeCadaDiaToolStripMenuItem
            // 
            this.maximaPuntuacionDeCadaDiaToolStripMenuItem.Name = "maximaPuntuacionDeCadaDiaToolStripMenuItem";
            this.maximaPuntuacionDeCadaDiaToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.maximaPuntuacionDeCadaDiaToolStripMenuItem.Text = "Maxima puntuacion de cada Dia";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 266);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPrincipal";
            this.Text = "FrmPrincipal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem juegoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reglasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadisticasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem puntosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movimientosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadisticasGeneralesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graficosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem puntosEnFuncionDelTiempoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maximaPuntuacionDeCadaDiaToolStripMenuItem;
    }
}