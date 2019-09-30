namespace NaturePark
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
            this.LapsoMayor = new System.Windows.Forms.Label();
            this.Record = new System.Windows.Forms.Label();
            this.lblRecord = new System.Windows.Forms.Label();
            this.lblFrecuencia = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Mediana = new System.Windows.Forms.Label();
            this.lblMediana = new System.Windows.Forms.Label();
            this.PromedioPuntos = new System.Windows.Forms.Label();
            this.lblPromedioPuntos = new System.Windows.Forms.Label();
            this.cboTipoOrdenamiento = new System.Windows.Forms.ComboBox();
            this.lblOrdenamineto = new System.Windows.Forms.Label();
            this.lstPuntajes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // LapsoMayor
            // 
            this.LapsoMayor.AutoSize = true;
            this.LapsoMayor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LapsoMayor.Location = new System.Drawing.Point(34, 340);
            this.LapsoMayor.Name = "LapsoMayor";
            this.LapsoMayor.Size = new System.Drawing.Size(198, 16);
            this.LapsoMayor.TabIndex = 31;
            this.LapsoMayor.Text = "Lapso Mayor entre partidos";
            // 
            // Record
            // 
            this.Record.AutoSize = true;
            this.Record.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Record.Location = new System.Drawing.Point(579, 22);
            this.Record.Name = "Record";
            this.Record.Size = new System.Drawing.Size(110, 16);
            this.Record.TabIndex = 30;
            this.Record.Text = "Record Puntos";
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.Location = new System.Drawing.Point(579, 39);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(16, 16);
            this.lblRecord.TabIndex = 29;
            this.lblRecord.Text = "0";
            // 
            // lblFrecuencia
            // 
            this.lblFrecuencia.AutoSize = true;
            this.lblFrecuencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrecuencia.Location = new System.Drawing.Point(34, 321);
            this.lblFrecuencia.Name = "lblFrecuencia";
            this.lblFrecuencia.Size = new System.Drawing.Size(154, 16);
            this.lblFrecuencia.TabIndex = 28;
            this.lblFrecuencia.Text = "Frecuencia de Juego";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(360, 373);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(166, 56);
            this.listBox1.TabIndex = 27;
            // 
            // Mediana
            // 
            this.Mediana.AutoSize = true;
            this.Mediana.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mediana.Location = new System.Drawing.Point(579, 119);
            this.Mediana.Name = "Mediana";
            this.Mediana.Size = new System.Drawing.Size(119, 16);
            this.Mediana.TabIndex = 26;
            this.Mediana.Text = "Mediana Puntos";
            // 
            // lblMediana
            // 
            this.lblMediana.AutoSize = true;
            this.lblMediana.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMediana.Location = new System.Drawing.Point(579, 136);
            this.lblMediana.Name = "lblMediana";
            this.lblMediana.Size = new System.Drawing.Size(16, 16);
            this.lblMediana.TabIndex = 25;
            this.lblMediana.Text = "0";
            // 
            // PromedioPuntos
            // 
            this.PromedioPuntos.AutoSize = true;
            this.PromedioPuntos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PromedioPuntos.Location = new System.Drawing.Point(579, 72);
            this.PromedioPuntos.Name = "PromedioPuntos";
            this.PromedioPuntos.Size = new System.Drawing.Size(126, 16);
            this.PromedioPuntos.TabIndex = 24;
            this.PromedioPuntos.Text = "Promedio Puntos";
            // 
            // lblPromedioPuntos
            // 
            this.lblPromedioPuntos.AutoSize = true;
            this.lblPromedioPuntos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPromedioPuntos.Location = new System.Drawing.Point(579, 89);
            this.lblPromedioPuntos.Name = "lblPromedioPuntos";
            this.lblPromedioPuntos.Size = new System.Drawing.Size(16, 16);
            this.lblPromedioPuntos.TabIndex = 23;
            this.lblPromedioPuntos.Text = "0";
            // 
            // cboTipoOrdenamiento
            // 
            this.cboTipoOrdenamiento.FormattingEnabled = true;
            this.cboTipoOrdenamiento.Location = new System.Drawing.Point(37, 408);
            this.cboTipoOrdenamiento.Name = "cboTipoOrdenamiento";
            this.cboTipoOrdenamiento.Size = new System.Drawing.Size(209, 21);
            this.cboTipoOrdenamiento.TabIndex = 22;
            // 
            // lblOrdenamineto
            // 
            this.lblOrdenamineto.AutoSize = true;
            this.lblOrdenamineto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdenamineto.Location = new System.Drawing.Point(34, 387);
            this.lblOrdenamineto.Name = "lblOrdenamineto";
            this.lblOrdenamineto.Size = new System.Drawing.Size(75, 13);
            this.lblOrdenamineto.TabIndex = 21;
            this.lblOrdenamineto.Text = "Ordenar Por";
            // 
            // lstPuntajes
            // 
            this.lstPuntajes.FormattingEnabled = true;
            this.lstPuntajes.Location = new System.Drawing.Point(34, 22);
            this.lstPuntajes.Name = "lstPuntajes";
            this.lstPuntajes.Size = new System.Drawing.Size(492, 290);
            this.lstPuntajes.TabIndex = 20;
            // 
            // FrmEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 460);
            this.Controls.Add(this.LapsoMayor);
            this.Controls.Add(this.Record);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.lblFrecuencia);
            this.Controls.Add(this.listBox1);
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

        private System.Windows.Forms.Label LapsoMayor;
        private System.Windows.Forms.Label Record;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.Label lblFrecuencia;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label Mediana;
        private System.Windows.Forms.Label lblMediana;
        private System.Windows.Forms.Label PromedioPuntos;
        private System.Windows.Forms.Label lblPromedioPuntos;
        private System.Windows.Forms.ComboBox cboTipoOrdenamiento;
        private System.Windows.Forms.Label lblOrdenamineto;
        private System.Windows.Forms.ListBox lstPuntajes;
    }
}