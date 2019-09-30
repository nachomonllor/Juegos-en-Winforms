Option Strict On

Public Class LabelEspecial
    Inherits Label


    Private _colorEnfocado As Color
    Private _colorDesenfocado As Color

    Public Property ColorEnfocado() As Color
        Get
            Return Me._colorEnfocado
        End Get
        Set(ByVal value As Color)
            Me._colorEnfocado = value
        End Set
    End Property


    Public Property ColorDesenfocado() As Color
        Get
            Return Me._colorDesenfocado
        End Get
        Set(ByVal value As Color)
            Me._colorDesenfocado = value
        End Set
    End Property


    Public Sub Presionar(ByVal sender As Object, ByVal e As EventArgs) Handles Me.MouseDown
        Me.BackColor = Me._colorEnfocado
    End Sub

    Public Sub Soltar(ByVal sender As Object, ByVal e As EventArgs) Handles Me.MouseUp
        Me.BackColor = Me._colorDesenfocado
    End Sub








End Class
