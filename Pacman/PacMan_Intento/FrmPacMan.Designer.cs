namespace WindowsFormsApplication1
{
    partial class FrmPacMan
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
            this.txtIntervalo = new System.Windows.Forms.TextBox();
            this.btnIntervalo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtIntervalo
            // 
            this.txtIntervalo.Location = new System.Drawing.Point(229, 4);
            this.txtIntervalo.Name = "txtIntervalo";
            this.txtIntervalo.Size = new System.Drawing.Size(100, 20);
            this.txtIntervalo.TabIndex = 0;
            // 
            // btnIntervalo
            // 
            this.btnIntervalo.Location = new System.Drawing.Point(335, 4);
            this.btnIntervalo.Name = "btnIntervalo";
            this.btnIntervalo.Size = new System.Drawing.Size(146, 23);
            this.btnIntervalo.TabIndex = 1;
            this.btnIntervalo.Text = "Velocidad temporizador";
            this.btnIntervalo.UseVisualStyleBackColor = true;
            this.btnIntervalo.Click += new System.EventHandler(this.btnIntervalo_Click);
            // 
            // FrmPacMan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(779, 606);
            this.Controls.Add(this.btnIntervalo);
            this.Controls.Add(this.txtIntervalo);
            this.Name = "FrmPacMan";
            this.Text = "FrmPacMan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIntervalo;
        private System.Windows.Forms.Button btnIntervalo;
    }
}