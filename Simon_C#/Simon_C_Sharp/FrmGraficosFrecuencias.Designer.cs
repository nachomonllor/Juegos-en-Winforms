namespace Simon_C_Sharp
{
    partial class FrmGraficosFrecuencias
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
            this.components = new System.ComponentModel.Container();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lblDesvEstandard = new System.Windows.Forms.Label();
            this.DesviacionEstandard = new System.Windows.Forms.Label();
            this.Promedio = new System.Windows.Forms.Label();
            this.lblPromedio = new System.Windows.Forms.Label();
            this.CVar = new System.Windows.Forms.Label();
            this.lblCVariacion = new System.Windows.Forms.Label();
            this.Moda1 = new System.Windows.Forms.Label();
            this.lblModa = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(26, 27);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0;
            this.zedGraphControl1.ScrollMaxX = 0;
            this.zedGraphControl1.ScrollMaxY = 0;
            this.zedGraphControl1.ScrollMaxY2 = 0;
            this.zedGraphControl1.ScrollMinX = 0;
            this.zedGraphControl1.ScrollMinY = 0;
            this.zedGraphControl1.ScrollMinY2 = 0;
            this.zedGraphControl1.Size = new System.Drawing.Size(686, 410);
            this.zedGraphControl1.TabIndex = 4;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(805, 27);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(52, 459);
            this.listBox2.TabIndex = 8;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(732, 27);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(56, 459);
            this.listBox1.TabIndex = 7;
            // 
            // lblDesvEstandard
            // 
            this.lblDesvEstandard.AutoSize = true;
            this.lblDesvEstandard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesvEstandard.Location = new System.Drawing.Point(225, 449);
            this.lblDesvEstandard.Name = "lblDesvEstandard";
            this.lblDesvEstandard.Size = new System.Drawing.Size(16, 16);
            this.lblDesvEstandard.TabIndex = 53;
            this.lblDesvEstandard.Text = "0";
            // 
            // DesviacionEstandard
            // 
            this.DesviacionEstandard.AutoSize = true;
            this.DesviacionEstandard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DesviacionEstandard.Location = new System.Drawing.Point(23, 449);
            this.DesviacionEstandard.Name = "DesviacionEstandard";
            this.DesviacionEstandard.Size = new System.Drawing.Size(161, 16);
            this.DesviacionEstandard.TabIndex = 52;
            this.DesviacionEstandard.Text = "Desviacion Estandard";
            // 
            // Promedio
            // 
            this.Promedio.AutoSize = true;
            this.Promedio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Promedio.Location = new System.Drawing.Point(23, 470);
            this.Promedio.Name = "Promedio";
            this.Promedio.Size = new System.Drawing.Size(75, 16);
            this.Promedio.TabIndex = 54;
            this.Promedio.Text = "Promedio";
            // 
            // lblPromedio
            // 
            this.lblPromedio.AutoSize = true;
            this.lblPromedio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPromedio.Location = new System.Drawing.Point(225, 470);
            this.lblPromedio.Name = "lblPromedio";
            this.lblPromedio.Size = new System.Drawing.Size(16, 16);
            this.lblPromedio.TabIndex = 55;
            this.lblPromedio.Text = "0";
            // 
            // CVar
            // 
            this.CVar.AutoSize = true;
            this.CVar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CVar.Location = new System.Drawing.Point(23, 491);
            this.CVar.Name = "CVar";
            this.CVar.Size = new System.Drawing.Size(178, 16);
            this.CVar.TabIndex = 56;
            this.CVar.Text = "Coeficiente de Variacion";
            // 
            // lblCVariacion
            // 
            this.lblCVariacion.AutoSize = true;
            this.lblCVariacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCVariacion.Location = new System.Drawing.Point(225, 491);
            this.lblCVariacion.Name = "lblCVariacion";
            this.lblCVariacion.Size = new System.Drawing.Size(16, 16);
            this.lblCVariacion.TabIndex = 57;
            this.lblCVariacion.Text = "0";
            // 
            // Moda1
            // 
            this.Moda1.AutoSize = true;
            this.Moda1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Moda1.Location = new System.Drawing.Point(492, 449);
            this.Moda1.Name = "Moda1";
            this.Moda1.Size = new System.Drawing.Size(47, 16);
            this.Moda1.TabIndex = 58;
            this.Moda1.Text = "Moda";
            // 
            // lblModa
            // 
            this.lblModa.AutoSize = true;
            this.lblModa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModa.Location = new System.Drawing.Point(554, 449);
            this.lblModa.Name = "lblModa";
            this.lblModa.Size = new System.Drawing.Size(16, 16);
            this.lblModa.TabIndex = 59;
            this.lblModa.Text = "0";
            // 
            // FrmGraficosFrecuencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 536);
            this.Controls.Add(this.lblModa);
            this.Controls.Add(this.Moda1);
            this.Controls.Add(this.lblCVariacion);
            this.Controls.Add(this.CVar);
            this.Controls.Add(this.lblPromedio);
            this.Controls.Add(this.Promedio);
            this.Controls.Add(this.lblDesvEstandard);
            this.Controls.Add(this.DesviacionEstandard);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.zedGraphControl1);
            this.Name = "FrmGraficosFrecuencias";
            this.Text = "FrmGraficosFrecuencias";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lblDesvEstandard;
        private System.Windows.Forms.Label DesviacionEstandard;
        private System.Windows.Forms.Label Promedio;
        private System.Windows.Forms.Label lblPromedio;
        private System.Windows.Forms.Label CVar;
        private System.Windows.Forms.Label lblCVariacion;
        private System.Windows.Forms.Label Moda1;
        private System.Windows.Forms.Label lblModa;
    }
}