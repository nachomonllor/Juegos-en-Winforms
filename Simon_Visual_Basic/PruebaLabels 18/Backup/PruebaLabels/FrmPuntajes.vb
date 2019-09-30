Option Strict On

Public Enum TipoOrdenamiento
    Puntos
    Fecha
End Enum

Public Class FrmPuntajes

    Private _listaDePuntajes As List(Of Puntaje)

    Public Property ListaDePuntajes() As List(Of Puntaje)
        Get
            Return Me._listaDePuntajes
        End Get
        Set(ByVal value As List(Of Puntaje))
            Me._listaDePuntajes = value
        End Set
    End Property


    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ' Me._listaDePuntajes = New List(Of Puntaje)


    End Sub


    Private Sub FrmPuntajes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CargarComboOrdenamiento()
        Me.cboOrdenamiento.SelectedIndex = 0
        Me.cboOrdenamiento.DropDownStyle = ComboBoxStyle.DropDownList

    End Sub


    Public Sub CargarComboOrdenamiento()

        For Each e As TipoOrdenamiento In [Enum].GetValues(GetType(TipoOrdenamiento))
            Me.cboOrdenamiento.Items.Add(e)
        Next

    End Sub


    Public Sub CargarListBox()

        Me.lstPuntajes.Items.Clear()

        For Each p As Puntaje In Me._listaDePuntajes
            Me.lstPuntajes.Items.Add(p)
        Next

    End Sub



    Private Sub CambioConboIndiceSeleccionado(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOrdenamiento.SelectedIndexChanged

        Ordenar()
        CargarListBox()

    End Sub


    Public Sub Ordenar()

        OrdenarLista(CType(Me.cboOrdenamiento.SelectedItem, TipoOrdenamiento))

    End Sub

    Public Sub OrdenarLista(ByVal tipo As TipoOrdenamiento)

        Dim miComparador As Comparison(Of Puntaje) = Nothing

        Select Case tipo

            Case TipoOrdenamiento.Fecha
                miComparador = New Comparison(Of Puntaje)(AddressOf Puntaje.OrdenarPorFecha)

            Case TipoOrdenamiento.Puntos
                miComparador = New Comparison(Of Puntaje)(AddressOf Puntaje.OrdenarPorPuntos)

        End Select

        Me._listaDePuntajes.Sort(miComparador)

    End Sub


    Private Function CalcularPromedio() As Double

        Dim promedio As Double
        Dim sumatoriaPuntajes As Double

        For Each p As Puntaje In Me._listaDePuntajes
            sumatoriaPuntajes += p.Puntos
        Next

        promedio = CType(sumatoriaPuntajes / Me._listaDePuntajes.Count, Double)

        Return promedio

    End Function

    Public ReadOnly Property PromedioGeneral() As Double
        Get
            Return Me.CalcularPromedio()
        End Get
    End Property


    Public Function CalcularMediana() As Single

        Dim mediana As Single = 0

        Dim miComparador As New Comparison(Of Puntaje)(AddressOf Puntaje.OrdenarPorPuntos)
        Dim listaAux As List(Of Puntaje) = Me._listaDePuntajes

        listaAux.Sort(miComparador)


        If listaAux.Count > 1 Then

            Dim valor1 As Integer = listaAux(CInt(listaAux.Count / 2) - 1).Puntos

            Dim valor2 As Integer = listaAux(CInt(listaAux.Count / 2)).Puntos

            If listaAux.Count Mod 2 = 0 Then

                mediana = CType((valor1 + valor2) / 2, Single)

            ElseIf listaAux.Count Mod 2 <> 0 Then

                mediana = CType(valor2, Single)

            End If

            Return mediana

        Else

            Return CType(listaAux(0).Puntos, Single)

        End If

    End Function


    Public ReadOnly Property Mediana() As Single
        Get
            Return Me.CalcularMediana()
        End Get
    End Property


 
End Class