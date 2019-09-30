namespace WindowsFormsApplication1
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
            this.lstPuntajes = new System.Windows.Forms.ListBox();
            this.lblOrdenamineto = new System.Windows.Forms.Label();
            this.cboTipoOrdenamiento = new System.Windows.Forms.ComboBox();
            this.lblPromedioPuntos = new System.Windows.Forms.Label();
            this.PromedioPuntos = new System.Windows.Forms.Label();
            this.Mediana = new System.Windows.Forms.Label();
            this.lblMediana = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lblFrecuencia = new System.Windows.Forms.Label();
            this.Record = new System.Windows.Forms.Label();
            this.lblRecord = new System.Windows.Forms.Label();
            this.LapsoMayor = new System.Windows.Forms.Label();
            this.X1 = new System.Windows.Forms.Label();
            this.lblX1 = new System.Windows.Forms.Label();
            this.X2 = new System.Windows.Forms.Label();
            this.lblX2 = new System.Windows.Forms.Label();
            this.X3 = new System.Windows.Forms.Label();
            this.lblX3 = new System.Windows.Forms.Label();
            this.X4 = new System.Windows.Forms.Label();
            this.lblX4 = new System.Windows.Forms.Label();
            this.btnMediana = new System.Windows.Forms.Button();
            this.Varianza = new System.Windows.Forms.Label();
            this.lblVarianza = new System.Windows.Forms.Label();
            this.DesviacionEstandard = new System.Windows.Forms.Label();
            this.lblDesvEstandard = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstPuntajes
            // 
            this.lstPuntajes.FormattingEnabled = true;
            this.lstPuntajes.Location = new System.Drawing.Point(31, 22);
            this.lstPuntajes.Name = "lstPuntajes";
            this.lstPuntajes.Size = new System.Drawing.Size(492, 290);
            this.lstPuntajes.TabIndex = 0;
            // 
            // lblOrdenamineto
            // 
            this.lblOrdenamineto.AutoSize = true;
            this.lblOrdenamineto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdenamineto.Location = new System.Drawing.Point(31, 447);
            this.lblOrdenamineto.Name = "lblOrdenamineto";
            this.lblOrdenamineto.Size = new System.Drawing.Size(75, 13);
            this.lblOrdenamineto.TabIndex = 1;
            this.lblOrdenamineto.Text = "Ordenar Por";
            // 
            // cboTipoOrdenamiento
            // 
            this.cboTipoOrdenamiento.FormattingEnabled = true;
            this.cboTipoOrdenamiento.Location = new System.Drawing.Point(34, 468);
            this.cboTipoOrdenamiento.Name = "cboTipoOrdenamiento";
            this.cboTipoOrdenamiento.Size = new System.Drawing.Size(209, 21);
            this.cboTipoOrdenamiento.TabIndex = 2;
            // 
            // lblPromedioPuntos
            // 
            this.lblPromedioPuntos.AutoSize = true;
            this.lblPromedioPuntos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPromedioPuntos.Location = new System.Drawing.Point(547, 89);
            this.lblPromedioPuntos.Name = "lblPromedioPuntos";
            this.lblPromedioPuntos.Size = new System.Drawing.Size(16, 16);
            this.lblPromedioPuntos.TabIndex = 3;
            this.lblPromedioPuntos.Text = "0";
            // 
            // PromedioPuntos
            // 
            this.PromedioPuntos.AutoSize = true;
            this.PromedioPuntos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PromedioPuntos.Location = new System.Drawing.Point(547, 72);
            this.PromedioPuntos.Name = "PromedioPuntos";
            this.PromedioPuntos.Size = new System.Drawing.Size(126, 16);
            this.PromedioPuntos.TabIndex = 4;
            this.PromedioPuntos.Text = "Promedio Puntos";
            // 
            // Mediana
            // 
            this.Mediana.AutoSize = true;
            this.Mediana.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mediana.Location = new System.Drawing.Point(547, 119);
            this.Mediana.Name = "Mediana";
            this.Mediana.Size = new System.Drawing.Size(119, 16);
            this.Mediana.TabIndex = 6;
            this.Mediana.Text = "Mediana Puntos";
            // 
            // lblMediana
            // 
            this.lblMediana.AutoSize = true;
            this.lblMediana.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMediana.Location = new System.Drawing.Point(547, 136);
            this.lblMediana.Name = "lblMediana";
            this.lblMediana.Size = new System.Drawing.Size(16, 16);
            this.lblMediana.TabIndex = 5;
            this.lblMediana.Text = "0";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(357, 433);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(166, 56);
            this.listBox1.TabIndex = 7;
            // 
            // lblFrecuencia
            // 
            this.lblFrecuencia.AutoSize = true;
            this.lblFrecuencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrecuencia.Location = new System.Drawing.Point(31, 321);
            this.lblFrecuencia.Name = "lblFrecuencia";
            this.lblFrecuencia.Size = new System.Drawing.Size(154, 16);
            this.lblFrecuencia.TabIndex = 8;
            this.lblFrecuencia.Text = "Frecuencia de Juego";
            // 
            // Record
            // 
            this.Record.AutoSize = true;
            this.Record.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Record.Location = new System.Drawing.Point(547, 22);
            this.Record.Name = "Record";
            this.Record.Size = new System.Drawing.Size(110, 16);
            this.Record.TabIndex = 10;
            this.Record.Text = "Record Puntos";
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.Location = new System.Drawing.Point(547, 39);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(16, 16);
            this.lblRecord.TabIndex = 9;
            this.lblRecord.Text = "0";
            // 
            // LapsoMayor
            // 
            this.LapsoMayor.AutoSize = true;
            this.LapsoMayor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LapsoMayor.Location = new System.Drawing.Point(31, 340);
            this.LapsoMayor.Name = "LapsoMayor";
            this.LapsoMayor.Size = new System.Drawing.Size(198, 16);
            this.LapsoMayor.TabIndex = 11;
            this.LapsoMayor.Text = "Lapso Mayor entre partidos";
            // 
            // X1
            // 
            this.X1.AutoSize = true;
            this.X1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.X1.Location = new System.Drawing.Point(562, 424);
            this.X1.Name = "X1";
            this.X1.Size = new System.Drawing.Size(37, 16);
            this.X1.TabIndex = 13;
            this.X1.Text = "X1 =";
            // 
            // lblX1
            // 
            this.lblX1.AutoSize = true;
            this.lblX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblX1.Location = new System.Drawing.Point(611, 424);
            this.lblX1.Name = "lblX1";
            this.lblX1.Size = new System.Drawing.Size(16, 16);
            this.lblX1.TabIndex = 12;
            this.lblX1.Text = "0";
            // 
            // X2
            // 
            this.X2.AutoSize = true;
            this.X2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.X2.Location = new System.Drawing.Point(562, 444);
            this.X2.Name = "X2";
            this.X2.Size = new System.Drawing.Size(37, 16);
            this.X2.TabIndex = 15;
            this.X2.Text = "X2 =";
            // 
            // lblX2
            // 
            this.lblX2.AutoSize = true;
            this.lblX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblX2.Location = new System.Drawing.Point(611, 444);
            this.lblX2.Name = "lblX2";
            this.lblX2.Size = new System.Drawing.Size(16, 16);
            this.lblX2.TabIndex = 14;
            this.lblX2.Text = "0";
            // 
            // X3
            // 
            this.X3.AutoSize = true;
            this.X3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.X3.Location = new System.Drawing.Point(562, 464);
            this.X3.Name = "X3";
            this.X3.Size = new System.Drawing.Size(37, 16);
            this.X3.TabIndex = 17;
            this.X3.Text = "X3 =";
            // 
            // lblX3
            // 
            this.lblX3.AutoSize = true;
            this.lblX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblX3.Location = new System.Drawing.Point(611, 464);
            this.lblX3.Name = "lblX3";
            this.lblX3.Size = new System.Drawing.Size(16, 16);
            this.lblX3.TabIndex = 16;
            this.lblX3.Text = "0";
            // 
            // X4
            // 
            this.X4.AutoSize = true;
            this.X4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.X4.Location = new System.Drawing.Point(562, 484);
            this.X4.Name = "X4";
            this.X4.Size = new System.Drawing.Size(37, 16);
            this.X4.TabIndex = 19;
            this.X4.Text = "X4 =";
            // 
            // lblX4
            // 
            this.lblX4.AutoSize = true;
            this.lblX4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblX4.Location = new System.Drawing.Point(611, 484);
            this.lblX4.Name = "lblX4";
            this.lblX4.Size = new System.Drawing.Size(16, 16);
            this.lblX4.TabIndex = 18;
            this.lblX4.Text = "0";
            // 
            // btnMediana
            // 
            this.btnMediana.Location = new System.Drawing.Point(672, 112);
            this.btnMediana.Name = "btnMediana";
            this.btnMediana.Size = new System.Drawing.Size(113, 23);
            this.btnMediana.TabIndex = 20;
            this.btnMediana.Text = "Que es la mediana";
            this.btnMediana.UseVisualStyleBackColor = true;
            this.btnMediana.Click += new System.EventHandler(this.btnMediana_Click);
            // 
            // Varianza
            // 
            this.Varianza.AutoSize = true;
            this.Varianza.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Varianza.Location = new System.Drawing.Point(547, 167);
            this.Varianza.Name = "Varianza";
            this.Varianza.Size = new System.Drawing.Size(69, 16);
            this.Varianza.TabIndex = 21;
            this.Varianza.Text = "Varianza";
            // 
            // lblVarianza
            // 
            this.lblVarianza.AutoSize = true;
            this.lblVarianza.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVarianza.Location = new System.Drawing.Point(547, 185);
            this.lblVarianza.Name = "lblVarianza";
            this.lblVarianza.Size = new System.Drawing.Size(16, 16);
            this.lblVarianza.TabIndex = 22;
            this.lblVarianza.Text = "0";
            // 
            // DesviacionEstandard
            // 
            this.DesviacionEstandard.AutoSize = true;
            this.DesviacionEstandard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DesviacionEstandard.Location = new System.Drawing.Point(547, 215);
            this.DesviacionEstandard.Name = "DesviacionEstandard";
            this.DesviacionEstandard.Size = new System.Drawing.Size(161, 16);
            this.DesviacionEstandard.TabIndex = 23;
            this.DesviacionEstandard.Text = "Desviacion Estandard";
            // 
            // lblDesvEstandard
            // 
            this.lblDesvEstandard.AutoSize = true;
            this.lblDesvEstandard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesvEstandard.Location = new System.Drawing.Point(547, 234);
            this.lblDesvEstandard.Name = "lblDesvEstandard";
            this.lblDesvEstandard.Size = new System.Drawing.Size(16, 16);
            this.lblDesvEstandard.TabIndex = 24;
            this.lblDesvEstandard.Text = "0";
            // 
            // FrmEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 515);
            this.Controls.Add(this.lblDesvEstandard);
            this.Controls.Add(this.DesviacionEstandard);
            this.Controls.Add(this.lblVarianza);
            this.Controls.Add(this.Varianza);
            this.Controls.Add(this.btnMediana);
            this.Controls.Add(this.X4);
            this.Controls.Add(this.lblX4);
            this.Controls.Add(this.X3);
            this.Controls.Add(this.lblX3);
            this.Controls.Add(this.X2);
            this.Controls.Add(this.lblX2);
            this.Controls.Add(this.X1);
            this.Controls.Add(this.lblX1);
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
            this.Load += new System.EventHandler(this.FrmEstadisticas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstPuntajes;
        private System.Windows.Forms.Label lblOrdenamineto;
        private System.Windows.Forms.ComboBox cboTipoOrdenamiento;
        private System.Windows.Forms.Label lblPromedioPuntos;
        private System.Windows.Forms.Label PromedioPuntos;
        private System.Windows.Forms.Label Mediana;
        private System.Windows.Forms.Label lblMediana;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lblFrecuencia;
        private System.Windows.Forms.Label Record;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.Label LapsoMayor;
        private System.Windows.Forms.Label X1;
        private System.Windows.Forms.Label lblX1;
        private System.Windows.Forms.Label X2;
        private System.Windows.Forms.Label lblX2;
        private System.Windows.Forms.Label X3;
        private System.Windows.Forms.Label lblX3;
        private System.Windows.Forms.Label X4;
        private System.Windows.Forms.Label lblX4;
        private System.Windows.Forms.Button btnMediana;
        private System.Windows.Forms.Label Varianza;
        private System.Windows.Forms.Label lblVarianza;
        private System.Windows.Forms.Label DesviacionEstandard;
        private System.Windows.Forms.Label lblDesvEstandard;
    }
}