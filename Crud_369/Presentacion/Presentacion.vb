Public Class Presentacion
    Private Sub Presentacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Timer1.Start()

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)



    End Sub
    Dim contador As Integer
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        contador += 1
        If contador = 30 Then

        ElseIf contador = 32 Then
            Timer1.Stop()
            Dispose()
            Buscar_servidores.ShowDialog()
        End If
    End Sub

End Class