Option Strict On

Public Class Puntaje


    Private _puntos As Integer
    Private _fechaActual As Date

    'CONTRUCTOR NECESARIO PARA LA SERIALIZACION EN XML
    Public Sub New()
    End Sub

    'Y USO ESTE PARA GUARDAR EN LA LISTA
    Public Sub New(ByVal puntos As Integer, ByVal fechaActual As Date)

        Me._puntos = puntos
        Me._fechaActual = fechaActual

    End Sub


    Public Property Puntos() As Integer
        Get
            Return Me._puntos
        End Get
        Set(ByVal value As Integer)
            Me._puntos = value
        End Set
    End Property

    Public Property FechaActual() As Date
        Get
            Return Me._fechaActual
        End Get
        Set(ByVal value As Date)
            Me._fechaActual = value
        End Set
    End Property


    Public Overrides Function ToString() As String

        Dim sb As New System.Text.StringBuilder

        sb.Append("Puntos: " & Me._puntos)
        sb.Append("  -  Fecha: " & Me._fechaActual.ToString)

        Return sb.ToString

    End Function

    Public Shared Function OrdenarPorPuntos(ByVal uno As Puntaje, ByVal dos As Puntaje) As Integer
        Return dos._puntos.CompareTo(uno._puntos)
    End Function

    Public Shared Function OrdenarPorFecha(ByVal uno As Puntaje, ByVal dos As Puntaje) As Integer
        Return dos._fechaActual.CompareTo(uno._fechaActual)
    End Function




End Class
