<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSimon
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lstSecuencia = New System.Windows.Forms.ListBox
        Me.btnEmpezar = New System.Windows.Forms.Button
        Me.LabelEspecial4 = New PruebaLabels.LabelEspecial
        Me.LabelEspecial3 = New PruebaLabels.LabelEspecial
        Me.LabelEspecial2 = New PruebaLabels.LabelEspecial
        Me.LabelEspecial1 = New PruebaLabels.LabelEspecial
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.btnMostrarPuntajes = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstSecuencia
        '
        Me.lstSecuencia.FormattingEnabled = True
        Me.lstSecuencia.Location = New System.Drawing.Point(375, 89)
        Me.lstSecuencia.Name = "lstSecuencia"
        Me.lstSecuencia.Size = New System.Drawing.Size(79, 368)
        Me.lstSecuencia.TabIndex = 7
        '
        'btnEmpezar
        '
        Me.btnEmpezar.Location = New System.Drawing.Point(48, 416)
        Me.btnEmpezar.Name = "btnEmpezar"
        Me.btnEmpezar.Size = New System.Drawing.Size(294, 40)
        Me.btnEmpezar.TabIndex = 6
        Me.btnEmpezar.Text = "Empezar"
        Me.btnEmpezar.UseVisualStyleBackColor = True
        '
        'LabelEspecial4
        '
        Me.LabelEspecial4.BackColor = System.Drawing.Color.DarkViolet
        Me.LabelEspecial4.ColorDesenfocado = System.Drawing.Color.Empty
        Me.LabelEspecial4.ColorEnfocado = System.Drawing.Color.Empty
        Me.LabelEspecial4.Location = New System.Drawing.Point(202, 249)
        Me.LabelEspecial4.Name = "LabelEspecial4"
        Me.LabelEspecial4.Size = New System.Drawing.Size(140, 143)
        Me.LabelEspecial4.TabIndex = 11
        Me.LabelEspecial4.Text = "LabelEspecial4"
        '
        'LabelEspecial3
        '
        Me.LabelEspecial3.BackColor = System.Drawing.Color.Red
        Me.LabelEspecial3.ColorDesenfocado = System.Drawing.Color.Empty
        Me.LabelEspecial3.ColorEnfocado = System.Drawing.Color.Empty
        Me.LabelEspecial3.Location = New System.Drawing.Point(45, 249)
        Me.LabelEspecial3.Name = "LabelEspecial3"
        Me.LabelEspecial3.Size = New System.Drawing.Size(140, 143)
        Me.LabelEspecial3.TabIndex = 10
        Me.LabelEspecial3.Text = "LabelEspecial3"
        '
        'LabelEspecial2
        '
        Me.LabelEspecial2.BackColor = System.Drawing.Color.DarkGreen
        Me.LabelEspecial2.ColorDesenfocado = System.Drawing.Color.Empty
        Me.LabelEspecial2.ColorEnfocado = System.Drawing.Color.Empty
        Me.LabelEspecial2.Location = New System.Drawing.Point(202, 92)
        Me.LabelEspecial2.Name = "LabelEspecial2"
        Me.LabelEspecial2.Size = New System.Drawing.Size(140, 143)
        Me.LabelEspecial2.TabIndex = 9
        Me.LabelEspecial2.Text = "LabelEspecial2"
        '
        'LabelEspecial1
        '
        Me.LabelEspecial1.BackColor = System.Drawing.Color.Blue
        Me.LabelEspecial1.ColorDesenfocado = System.Drawing.Color.Empty
        Me.LabelEspecial1.ColorEnfocado = System.Drawing.Color.Empty
        Me.LabelEspecial1.Location = New System.Drawing.Point(45, 92)
        Me.LabelEspecial1.Name = "LabelEspecial1"
        Me.LabelEspecial1.Size = New System.Drawing.Size(140, 143)
        Me.LabelEspecial1.TabIndex = 8
        Me.LabelEspecial1.Text = "LabelEspecial1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnMostrarPuntajes})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(535, 24)
        Me.MenuStrip1.TabIndex = 12
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btnMostrarPuntajes
        '
        Me.btnMostrarPuntajes.Name = "btnMostrarPuntajes"
        Me.btnMostrarPuntajes.Size = New System.Drawing.Size(101, 20)
        Me.btnMostrarPuntajes.Text = "Mostrar Puntajes"
        '
        'FrmSimon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(535, 497)
        Me.Controls.Add(Me.LabelEspecial4)
        Me.Controls.Add(Me.LabelEspecial3)
        Me.Controls.Add(Me.LabelEspecial2)
        Me.Controls.Add(Me.LabelEspecial1)
        Me.Controls.Add(Me.lstSecuencia)
        Me.Controls.Add(Me.btnEmpezar)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmSimon"
        Me.Text = "FrmSimon"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstSecuencia As System.Windows.Forms.ListBox
    Friend WithEvents btnEmpezar As System.Windows.Forms.Button
    Friend WithEvents LabelEspecial1 As PruebaLabels.LabelEspecial
    Friend WithEvents LabelEspecial2 As PruebaLabels.LabelEspecial
    Friend WithEvents LabelEspecial3 As PruebaLabels.LabelEspecial
    Friend WithEvents LabelEspecial4 As PruebaLabels.LabelEspecial
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnMostrarPuntajes As System.Windows.Forms.ToolStripMenuItem
End Class
