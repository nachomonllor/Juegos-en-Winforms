namespace Simon_C_Sharp
{
    partial class FrmSimon
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
            this.lstSecuencia = new System.Windows.Forms.ListBox();
            this.btnEmpezar = new System.Windows.Forms.Button();
            this.labelEspecial4 = new Simon_C_Sharp.LabelEspecial();
            this.labelEspecial3 = new Simon_C_Sharp.LabelEspecial();
            this.labelEspecial2 = new Simon_C_Sharp.LabelEspecial();
            this.labelEspecial1 = new Simon_C_Sharp.LabelEspecial();
            this.SuspendLayout();
            // 
            // lstSecuencia
            // 
            this.lstSecuencia.FormattingEnabled = true;
            this.lstSecuencia.Location = new System.Drawing.Point(393, 24);
            this.lstSecuencia.Name = "lstSecuencia";
            this.lstSecuencia.Size = new System.Drawing.Size(79, 368);
            this.lstSecuencia.TabIndex = 8;
            // 
            // btnEmpezar
            // 
            this.btnEmpezar.Location = new System.Drawing.Point(97, 368);
            this.btnEmpezar.Name = "btnEmpezar";
            this.btnEmpezar.Size = new System.Drawing.Size(208, 42);
            this.btnEmpezar.TabIndex = 9;
            this.btnEmpezar.Text = "Empezar";
            this.btnEmpezar.UseVisualStyleBackColor = true;
            this.btnEmpezar.Click += new System.EventHandler(this.btnEmpezar_Click_1);
            // 
            // labelEspecial4
            // 
            this.labelEspecial4.BackColor = System.Drawing.Color.DarkViolet;
            this.labelEspecial4.ColorDesenfocado = System.Drawing.Color.Empty;
            this.labelEspecial4.ColorEnfocado = System.Drawing.Color.Empty;
            this.labelEspecial4.Location = new System.Drawing.Point(205, 184);
            this.labelEspecial4.Name = "labelEspecial4";
            this.labelEspecial4.Size = new System.Drawing.Size(150, 150);
            this.labelEspecial4.TabIndex = 12;
            // 
            // labelEspecial3
            // 
            this.labelEspecial3.BackColor = System.Drawing.Color.Red;
            this.labelEspecial3.ColorDesenfocado = System.Drawing.Color.Empty;
            this.labelEspecial3.ColorEnfocado = System.Drawing.Color.Empty;
            this.labelEspecial3.Location = new System.Drawing.Point(45, 184);
            this.labelEspecial3.Name = "labelEspecial3";
            this.labelEspecial3.Size = new System.Drawing.Size(150, 150);
            this.labelEspecial3.TabIndex = 11;
            // 
            // labelEspecial2
            // 
            this.labelEspecial2.BackColor = System.Drawing.Color.DarkGreen;
            this.labelEspecial2.ColorDesenfocado = System.Drawing.Color.Empty;
            this.labelEspecial2.ColorEnfocado = System.Drawing.Color.Empty;
            this.labelEspecial2.Location = new System.Drawing.Point(205, 24);
            this.labelEspecial2.Name = "labelEspecial2";
            this.labelEspecial2.Size = new System.Drawing.Size(150, 150);
            this.labelEspecial2.TabIndex = 10;
            // 
            // labelEspecial1
            // 
            this.labelEspecial1.BackColor = System.Drawing.Color.Blue;
            this.labelEspecial1.ColorDesenfocado = System.Drawing.Color.Empty;
            this.labelEspecial1.ColorEnfocado = System.Drawing.Color.Empty;
            this.labelEspecial1.Location = new System.Drawing.Point(45, 24);
            this.labelEspecial1.Name = "labelEspecial1";
            this.labelEspecial1.Size = new System.Drawing.Size(150, 150);
            this.labelEspecial1.TabIndex = 0;
            // 
            // FrmSimon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(704, 517);
            this.Controls.Add(this.labelEspecial4);
            this.Controls.Add(this.labelEspecial3);
            this.Controls.Add(this.labelEspecial2);
            this.Controls.Add(this.btnEmpezar);
            this.Controls.Add(this.lstSecuencia);
            this.Controls.Add(this.labelEspecial1);
            this.Name = "FrmSimon";
            this.Text = "FrmSimon";
            this.Load += new System.EventHandler(this.FrmSimon_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private LabelEspecial labelEspecial1;
        internal System.Windows.Forms.ListBox lstSecuencia;
        private System.Windows.Forms.Button btnEmpezar;
        private LabelEspecial labelEspecial2;
        private LabelEspecial labelEspecial3;
        private LabelEspecial labelEspecial4;
    }
}