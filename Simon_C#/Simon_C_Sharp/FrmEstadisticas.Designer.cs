namespace Simon_C_Sharp
{
    partial class FrmEstadisticas
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
            this.lblDesvEstandard = new System.Windows.Forms.Label();
            this.DesviacionEstandard = new System.Windows.Forms.Label();
            this.lblVarianza = new System.Windows.Forms.Label();
            this.Varianza = new System.Windows.Forms.Label();
            this.LapsoMayor = new System.Windows.Forms.Label();
            this.Record = new System.Windows.Forms.Label();
            this.lblRecord = new System.Windows.Forms.Label();
            this.lblFrecuencia = new System.Windows.Forms.Label();
            this.Mediana = new System.Windows.Forms.Label();
            this.lblMediana = new System.Windows.Forms.Label();
            this.PromedioPuntos = new System.Windows.Forms.Label();
            this.lblPromedioPuntos = new System.Windows.Forms.Label();
            this.cboTipoOrdenamiento = new System.Windows.Forms.ComboBox();
            this.lblOrdenamineto = new System.Windows.Forms.Label();
            this.lstPuntajes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblDesvEstandard
            // 
            this.lblDesvEstandard.AutoSize = true;
            this.lblDesvEstandard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesvEstandard.Location = new System.Drawing.Point(539, 225);
            this.lblDesvEstandard.Name = "lblDesvEstandard";
            this.lblDesvEstandard.Size = new System.Drawing.Size(16, 16);
            this.lblDesvEstandard.TabIndex = 49;
            this.lblDesvEstandard.Text = "0";
            // 
            // DesviacionEstandard
            // 
            this.DesviacionEstandard.AutoSize = true;
            this.DesviacionEstandard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DesviacionEstandard.Location = new System.Drawing.Point(539, 206);
            this.DesviacionEstandard.Name = "DesviacionEstandard";
            this.DesviacionEstandard.Size = new System.Drawing.Size(161, 16);
            this.DesviacionEstandard.TabIndex = 48;
            this.DesviacionEstandard.Text = "Desviacion Estandard";
            // 
            // lblVarianza
            // 
            this.lblVarianza.AutoSize = true;
            this.lblVarianza.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVarianza.Location = new System.Drawing.Point(539, 176);
            this.lblVarianza.Name = "lblVarianza";
            this.lblVarianza.Size = new System.Drawing.Size(16, 16);
            this.lblVarianza.TabIndex = 47;
            this.lblVarianza.Text = "0";
            // 
            // Varianza
            // 
            this.Varianza.AutoSize = true;
            this.Varianza.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Varianza.Location = new System.Drawing.Point(539, 158);
            this.Varianza.Name = "Varianza";
            this.Varianza.Size = new System.Drawing.Size(69, 16);
            this.Varianza.TabIndex = 46;
            this.Varianza.Text = "Varianza";
            // 
            // LapsoMayor
            // 
            this.LapsoMayor.AutoSize = true;
            this.LapsoMayor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LapsoMayor.Location = new System.Drawing.Point(23, 331);
            this.LapsoMayor.Name = "LapsoMayor";
            this.LapsoMayor.Size = new System.Drawing.Size(198, 16);
            this.LapsoMayor.TabIndex = 36;
            this.LapsoMayor.Text = "Lapso Mayor entre partidos";
            // 
            // Record
            // 
            this.Record.AutoSize = true;
            this.Record.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Record.Location = new System.Drawing.Point(539, 13);
            this.Record.Name = "Record";
            this.Record.Size = new System.Drawing.Size(110, 16);
            this.Record.TabIndex = 35;
            this.Record.Text = "Record Puntos";
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.Location = new System.Drawing.Point(539, 30);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(16, 16);
            this.lblRecord.TabIndex = 34;
            this.lblRecord.Text = "0";
            // 
            // lblFrecuencia
            // 
            this.lblFrecuencia.AutoSize = true;
            this.lblFrecuencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrecuencia.Location = new System.Drawing.Point(23, 312);
            this.lblFrecuencia.Name = "lblFrecuencia";
            this.lblFrecuencia.Size = new System.Drawing.Size(154, 16);
            this.lblFrecuencia.TabIndex = 33;
            this.lblFrecuencia.Text = "Frecuencia de Juego";
            // 
            // Mediana
            // 
            this.Mediana.AutoSize = true;
            this.Mediana.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mediana.Location = new System.Drawing.Point(539, 110);
            this.Mediana.Name = "Mediana";
            this.Mediana.Size = new System.Drawing.Size(119, 16);
            this.Mediana.TabIndex = 31;
            this.Mediana.Text = "Mediana Puntos";
            // 
            // lblMediana
            // 
            this.lblMediana.AutoSize = true;
            this.lblMediana.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMediana.Location = new System.Drawing.Point(539, 127);
            this.lblMediana.Name = "lblMediana";
            this.lblMediana.Size = new System.Drawing.Size(16, 16);
            this.lblMediana.TabIndex = 30;
            this.lblMediana.Text = "0";
            // 
            // PromedioPuntos
            // 
            this.PromedioPuntos.AutoSize = true;
            this.PromedioPuntos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PromedioPuntos.Location = new System.Drawing.Point(539, 63);
            this.PromedioPuntos.Name = "PromedioPuntos";
            this.PromedioPuntos.Size = new System.Drawing.Size(126, 16);
            this.PromedioPuntos.TabIndex = 29;
            this.PromedioPuntos.Text = "Promedio Puntos";
            // 
            // lblPromedioPuntos
            // 
            this.lblPromedioPuntos.AutoSize = true;
            this.lblPromedioPuntos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPromedioPuntos.Location = new System.Drawing.Point(539, 80);
            this.lblPromedioPuntos.Name = "lblPromedioPuntos";
            this.lblPromedioPuntos.Size = new System.Drawing.Size(16, 16);
            this.lblPromedioPuntos.TabIndex = 28;
            this.lblPromedioPuntos.Text = "0";
            // 
            // cboTipoOrdenamiento
            // 
            this.cboTipoOrdenamiento.FormattingEnabled = true;
            this.cboTipoOrdenamiento.Location = new System.Drawing.Point(26, 459);
            this.cboTipoOrdenamiento.Name = "cboTipoOrdenamiento";
            this.cboTipoOrdenamiento.Size = new System.Drawing.Size(209, 21);
            this.cboTipoOrdenamiento.TabIndex = 27;
            // 
            // lblOrdenamineto
            // 
            this.lblOrdenamineto.AutoSize = true;
            this.lblOrdenamineto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdenamineto.Location = new System.Drawing.Point(23, 438);
            this.lblOrdenamineto.Name = "lblOrdenamineto";
            this.lblOrdenamineto.Size = new System.Drawing.Size(75, 13);
            this.lblOrdenamineto.TabIndex = 26;
            this.lblOrdenamineto.Text = "Ordenar Por";
            // 
            // lstPuntajes
            // 
            this.lstPuntajes.FormattingEnabled = true;
            this.lstPuntajes.Location = new System.Drawing.Point(23, 13);
            this.lstPuntajes.Name = "lstPuntajes";
            this.lstPuntajes.Size = new System.Drawing.Size(492, 290);
            this.lstPuntajes.TabIndex = 25;
            // 
            // FrmEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 504);
            this.Controls.Add(this.lblDesvEstandard);
            this.Controls.Add(this.DesviacionEstandard);
            this.Controls.Add(this.lblVarianza);
            this.Controls.Add(this.Varianza);
            this.Controls.Add(this.LapsoMayor);
            this.Controls.Add(this.Record);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.lblFrecuencia);
            this.Controls.Add(this.Mediana);
            this.Controls.Add(this.lblMediana);
            this.Controls.Add(this.PromedioPuntos);
            this.Controls.Add(this.lblPromedioPuntos);
            this.Controls.Add(this.cboTipoOrdenamiento);
            this.Controls.Add(this.lblOrdenamineto);
            this.Controls.Add(this.lstPuntajes);
            this.Name = "FrmEstadisticas";
            this.Text = "FrmEstadisticas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDesvEstandard;
        private System.Windows.Forms.Label DesviacionEstandard;
        private System.Windows.Forms.Label lblVarianza;
        private System.Windows.Forms.Label Varianza;
        private System.Windows.Forms.Label LapsoMayor;
        private System.Windows.Forms.Label Record;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.Label lblFrecuencia;
        private System.Windows.Forms.Label Mediana;
        private System.Windows.Forms.Label lblMediana;
        private System.Windows.Forms.Label PromedioPuntos;
        private System.Windows.Forms.Label lblPromedioPuntos;
        private System.Windows.Forms.ComboBox cboTipoOrdenamiento;
        private System.Windows.Forms.Label lblOrdenamineto;
        private System.Windows.Forms.ListBox lstPuntajes;
    }
}