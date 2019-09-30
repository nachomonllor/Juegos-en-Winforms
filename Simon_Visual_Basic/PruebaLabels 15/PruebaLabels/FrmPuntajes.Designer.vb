<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPuntajes
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
        Me.lstPuntajes = New System.Windows.Forms.ListBox
        Me.cboOrdenamiento = New System.Windows.Forms.ComboBox
        Me.lblOrdenamiento = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lstPuntajes
        '
        Me.lstPuntajes.FormattingEnabled = True
        Me.lstPuntajes.Location = New System.Drawing.Point(30, 25)
        Me.lstPuntajes.Name = "lstPuntajes"
        Me.lstPuntajes.Size = New System.Drawing.Size(447, 329)
        Me.lstPuntajes.TabIndex = 0
        '
        'cboOrdenamiento
        '
        Me.cboOrdenamiento.FormattingEnabled = True
        Me.cboOrdenamiento.Location = New System.Drawing.Point(30, 396)
        Me.cboOrdenamiento.Name = "cboOrdenamiento"
        Me.cboOrdenamiento.Size = New System.Drawing.Size(201, 21)
        Me.cboOrdenamiento.TabIndex = 1
        '
        'lblOrdenamiento
        '
        Me.lblOrdenamiento.AutoSize = True
        Me.lblOrdenamiento.Location = New System.Drawing.Point(27, 380)
        Me.lblOrdenamiento.Name = "lblOrdenamiento"
        Me.lblOrdenamiento.Size = New System.Drawing.Size(64, 13)
        Me.lblOrdenamiento.TabIndex = 2
        Me.lblOrdenamiento.Text = "Ordenar Por"
        '
        'FrmPuntajes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(512, 438)
        Me.Controls.Add(Me.lblOrdenamiento)
        Me.Controls.Add(Me.cboOrdenamiento)
        Me.Controls.Add(Me.lstPuntajes)
        Me.Name = "FrmPuntajes"
        Me.Text = "FrmPuntajes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstPuntajes As System.Windows.Forms.ListBox
    Friend WithEvents cboOrdenamiento As System.Windows.Forms.ComboBox
    Friend WithEvents lblOrdenamiento As System.Windows.Forms.Label
End Class
