Public Class Class2
    '  use = "USE " + txtbasededatos.Text + vbCr + "GO" + vbCr
    '    tituloProcedimiento = use + "CREATE PROC editar_" & TABLA
    '    txtEditar.Text = tituloProcedimiento
    '    For Each row As DataGridViewRow In datalistadoEstructura.Rows
    'Dim parametros As String = Convert.ToString(row.Cells("Parametros").Value)
    'Dim Tipo As String = Convert.ToString(row.Cells("Tipo").Value)

    '        parametros = "@" + parametros + " As " + Tipo + ","
    '        txtEditar.Text = txtEditar.Text + vbCr + parametros         
    '    Next
    '    largo = txtEditar.Text.Length
    '    txtEditar.Text = Mid(txtEditar.Text, 1, largo - 1)
    '    txtEditar.Text = txtEditar.Text + vbCr + "As" + vbCr
    '    funcion = "UPDATE " + TABLA + " Set"
    '    txtEditar.Text = txtEditar.Text + funcion
    '    For Each row As DataGridViewRow In datalistadoEstructura.Rows
    'Dim parametros As String = Convert.ToString(row.Cells("Parametros").Value)
    'Dim Enumeracion As Integer = Convert.ToInt32(row.Cells("Enumeracion").Value)
    'If Enumeracion = 1 Then
    '            id = parametros
    '        End If
    'If Enumeracion > 1 Then
    '            parametros = parametros + "=@" + parametros + ","
    '            txtEditar.Text = txtEditar.Text + vbCr + parametros
    '        End If
    'Next
    '    largo = txtEditar.Text.Length
    '    txtEditar.Text = Mid(txtEditar.Text, 1, largo - 1) + vbCr + "Where " + id + "=" + "@" + id

End Class
