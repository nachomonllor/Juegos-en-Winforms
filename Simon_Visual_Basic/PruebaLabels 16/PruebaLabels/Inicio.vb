Module Inicio

    '  Public _archivoPuntajes As String = "C:\ListaPuntajes.xml"

    Public _archivoPuntajes As String = Application.StartupPath & "\ListaPuntajes.xml"



    Sub Main()

        Try
            Dim frm As New FrmSimon

            Application.Run(frm)


        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try



    End Sub





End Module
