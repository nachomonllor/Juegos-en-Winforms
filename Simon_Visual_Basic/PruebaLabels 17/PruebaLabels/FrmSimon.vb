Option Strict On

Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO

Public Class FrmSimon


    Private _limite As Integer
    Private _aleatorio As Random
    Private _secuenciaAleatoria As New List(Of Integer)
    Private _indiceSecuencia As Integer
    Private _tiempoRetardo As Integer = 500
    Private _contadorCorrectos As Integer
    Private _numeroUsuario As Integer
    Private _puntaje As Integer
    Public _listaDePuntaje As List(Of Puntaje)

    '   Private _archivoPuntajes As String = "C:\ListaPuntajes.xml"


    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me._listaDePuntaje = New List(Of Puntaje)
        Me._contadorCorrectos = 0
        Me._indiceSecuencia = 0
        Me._limite = 0
        Me._puntaje = 0

    End Sub


    Private Sub InicializarLabels()

        Me.LabelEspecial1.BackColor = Color.Blue
        Me.LabelEspecial2.BackColor = Color.DarkGreen
        Me.LabelEspecial3.BackColor = Color.Red
        Me.LabelEspecial4.BackColor = Color.DarkViolet

    End Sub



    Public Sub AgregarManejadoresLabels()

        AddHandler LabelEspecial1.MouseDown, AddressOf LabelsEspecial_MouseDown
        AddHandler LabelEspecial2.MouseDown, AddressOf LabelsEspecial_MouseDown
        AddHandler LabelEspecial3.MouseDown, AddressOf LabelsEspecial_MouseDown
        AddHandler LabelEspecial4.MouseDown, AddressOf LabelsEspecial_MouseDown

    End Sub

    Public Sub QuitarManejadoresLabels()

        RemoveHandler LabelEspecial1.MouseDown, AddressOf LabelsEspecial_MouseDown
        RemoveHandler LabelEspecial2.MouseDown, AddressOf LabelsEspecial_MouseDown
        RemoveHandler LabelEspecial3.MouseDown, AddressOf LabelsEspecial_MouseDown
        RemoveHandler LabelEspecial4.MouseDown, AddressOf LabelsEspecial_MouseDown

    End Sub


    Private Sub CargarSecuenciaAleatoria()

        Me._aleatorio = New Random()

        For i = 0 To 100 'CARGO LA SECUENCIA DE ALEATORIOS CON 100 NUMEROS
            Me._secuenciaAleatoria.Add(Me._aleatorio.Next(0, 4))
        Next

    End Sub


    Private Sub FrmSimon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Me.LabelEspecial1.ColorEnfocado = Color.Cyan
        Me.LabelEspecial1.ColorDesenfocado = Color.Blue

        Me.LabelEspecial2.ColorEnfocado = Color.LightGreen
        Me.LabelEspecial2.ColorDesenfocado = Color.DarkGreen

        Me.LabelEspecial3.ColorEnfocado = Color.LightPink
        Me.LabelEspecial3.ColorDesenfocado = Color.Red

        Me.LabelEspecial4.ColorEnfocado = Color.Violet
        Me.LabelEspecial4.ColorDesenfocado = Color.DarkViolet


        If File.Exists(_archivoPuntajes) Then
            DeserializarListaPuntajes(_archivoPuntajes)
        End If


        CargarSecuenciaAleatoria()
        CargarListBox()



    End Sub


    Private Sub CargarListBox()

        Me.lstSecuencia.Items.Clear()

        For Each i As Integer In Me._secuenciaAleatoria
            Select Case i
                Case 0
                    Me.lstSecuencia.Items.Add("AZUL")
                Case 1
                    Me.lstSecuencia.Items.Add("VERDE")
                Case 2
                    Me.lstSecuencia.Items.Add("ROJO")
                Case 3
                    Me.lstSecuencia.Items.Add("VIOLETA")
            End Select
        Next

    End Sub



    Private Sub Parpadear(ByVal labelEspecial As Label, ByVal colorEnfocado As Color, ByVal colorDesenfocado As Color)

        labelEspecial.BackColor = colorEnfocado
        labelEspecial.Refresh()
        Threading.Thread.Sleep(Me._tiempoRetardo)

        labelEspecial.BackColor = colorDesenfocado
        labelEspecial.Refresh()
        Threading.Thread.Sleep(Me._tiempoRetardo)

    End Sub




    Private Sub MostrarSecuencia(ByVal sender As System.Object, ByVal e As System.EventArgs)

        QuitarManejadoresLabels()
        InicializarLabels()
        MessageBox.Show("Empieza la secuencia")

        For i = 0 To Me._limite
            Select Case Me._secuenciaAleatoria(i)
                Case 0
                    Parpadear(LabelEspecial1, Color.Cyan, Color.Blue)

                Case 1
                    Parpadear(LabelEspecial2, Color.LightGreen, Color.DarkGreen)

                Case 2
                    Parpadear(LabelEspecial3, Color.LightPink, Color.Red)

                Case 3
                    Parpadear(LabelEspecial4, Color.Violet, Color.DarkViolet)
            End Select

        Next

        MessageBox.Show("Termina la secuencia, TURNO DEL USUARIO")
        AgregarManejadoresLabels()

    End Sub

    Private Sub LabelsEspecial_MouseDown(ByVal sender As System.Object, ByVal e As MouseEventArgs)     '          Handles LabelEspecial1.MouseDown, LabelEspecial2.MouseDown, LabelEspecial3.MouseDown, LabelEspecial4.MouseDown

        Select Case CType(sender, LabelEspecial).Name

            Case "LabelEspecial1"
                Me._numeroUsuario = 0
            Case "LabelEspecial2"
                Me._numeroUsuario = 1
            Case "LabelEspecial3"
                Me._numeroUsuario = 2
            Case "LabelEspecial4"
                Me._numeroUsuario = 3

        End Select

        Comparar(sender, New EventArgs)

    End Sub




    Public Sub Comparar(ByVal sender As Object, ByVal e As EventArgs)

        If _numeroUsuario = Me._secuenciaAleatoria(Me._indiceSecuencia) Then

            '   MessageBox.Show("Correcto")
            Me._contadorCorrectos += 1
            Me._indiceSecuencia += 1

            If Me._contadorCorrectos = Me._limite + 1 Then

                Me._limite += 1
                Me._puntaje += 1 'PUNTAJE VALE LO MISMO QUE LIMITE, SE PUEDE USAR "LIMITE" PARA EL PUNTAJE 
                'EMPIEZA LA SECUENCIA DESDE CERO E INCREMENTA EN UNO EL LIMITE
                Me._indiceSecuencia = 0
                Me._contadorCorrectos = 0

                '  MessageBox.Show("TURNO MAQUINA")
                MostrarSecuencia(sender, e)

            End If
        Else

            MessageBox.Show("Incorrecto")
            GuardarPuntaje()
            '------------PUNTAJE-----------
            Me._listaDePuntaje.Add(New Puntaje(Me._puntaje, Date.Now))
            Me._listaDePuntaje.Add(New Puntaje(Me._limite, Date.Now))
            '-----------------------
            Me._limite = 0
            Me._indiceSecuencia = 0
            Me._contadorCorrectos = 0
            Me._secuenciaAleatoria.RemoveRange(0, Me._secuenciaAleatoria.Count - 1)
            CargarSecuenciaAleatoria()
            CargarListBox()
            MostrarSecuencia(sender, e)

        End If

    End Sub


    Private Sub btnEmpezar_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnEmpezar.Click
        MostrarSecuencia(sender, e)
    End Sub

    Public Sub GuardarPuntaje()
        My.Computer.FileSystem.WriteAllText("C:\PuntosSimon.txt", "Puntos: " & Me._puntaje.ToString() & " - Fecha: " & Date.Now.ToString & vbCrLf, True)
    End Sub


    Private Sub btnMostrarPuntajes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrarPuntajes.Click

        Dim frm As New FrmPuntajes

        frm.ListaDePuntajes = New List(Of Puntaje)(Me._listaDePuntaje)

        'Text1.Text = FormatNumber(Text1.Text, 2)
        'PARA QUE MUESTRE SOLAMENTE 2 DECIMALES
        frm.lblPromedio.Text = FormatNumber(frm.PromedioGeneral.ToString, 2)
        frm.lblCantPartidos.Text = Me._listaDePuntaje.Count.ToString
        frm.lblMediana.Text = FormatNumber(frm.Mediana.ToString, 2)

        frm.Show()


    End Sub

 

    Public Sub CerrarAplicacion(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing

        If MessageBox.Show("Seguro quiere salir?", "Cerrando Aplicacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            SerializarListaPuntajes(_archivoPuntajes)

            Me.Dispose()

        Else
            e.Cancel = True

        End If

    End Sub

    Private Function SerializarListaPuntajes(ByVal ruta As String) As Boolean

        Dim pudo As Boolean = False

        Try
            Using escritor As New XmlTextWriter(ruta, System.Text.Encoding.UTF8)

                Dim ser As New XmlSerializer(GetType(List(Of Puntaje)))

                ser.Serialize(escritor, Me._listaDePuntaje)

                pudo = True

            End Using

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

        Return pudo

    End Function


    Private Function DeserializarListaPuntajes(ByVal ruta As String) As Boolean

        Dim pudo As Boolean = False

        Try
            Using lector As New XmlTextReader(ruta)

                Dim ser As New XmlSerializer(GetType(List(Of Puntaje)))

                Dim listaAux As List(Of Puntaje) = CType(ser.Deserialize(lector), List(Of Puntaje))

                Me._listaDePuntaje = listaAux

                pudo = True

            End Using

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

        Return pudo

    End Function




End Class




