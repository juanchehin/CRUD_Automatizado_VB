Imports System.Runtime.InteropServices
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Xml
Imports System.IO
Imports System.Threading
Imports System.Management

Public Class Generador_UI
    Private aes As New AES()
    Dim estado_conexion As String
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub
    Public tituloProcedimiento As String
    Public funcion As String
    Public valores As String
    Public largo As Integer
    Public TABLA As String
    Private Sub BunifuGradientPanel2_Paint(sender As Object, e As PaintEventArgs)

    End Sub
    Sub editar_vb()
        Dim PROCESO As String = "Public Sub " + "editar_" + TABLA + vbCr
        Dim nombre_scrypt As String = "Editar_" + TABLA
        Dim L1 As String = PROCESO + "Try" + vbCr
        Dim L2 As String = "abrir()" + vbCr
        Dim L3 As String = "Dim cmd As New SqlCommand" + vbCr
        Dim L4 As String = "cmd = New SqlCommand(" + labelComillas.Text + nombre_scrypt + labelComillas.Text + ", conexion)" + vbCr
        Dim L5 As String = "cmd.CommandType = 4" + vbCr
        txtEditarVb.Text = L1 + L2 + L3 + L4 + L5

        For Each row As DataGridViewRow In datalistadoEstructura.Rows
            Dim parametros As String = Convert.ToString(row.Cells("Parametros").Value)
            Dim parametros2 As String = Convert.ToString(row.Cells("Parametros").Value)

            Dim Tipo As String = Convert.ToString(row.Cells("Tipo").Value)
            If Tipo <> "image" Then
                parametros = "@" + parametros
                Dim cmdparametro As String = "cmd.Parameters.AddWithValue(" + labelComillas.Text + parametros + labelComillas.Text + ", txt" + parametros2 + ".Text)"
                txtEditarVb.Text = txtEditarVb.Text + vbCr + cmdparametro
            End If



        Next

        For Each row As DataGridViewRow In datalistadoEstructura.Rows
            Dim parametros As String = Convert.ToString(row.Cells("Parametros").Value)
            Dim parametros2 As String = Convert.ToString(row.Cells("Parametros").Value)
            Dim Tipo As String = Convert.ToString(row.Cells("Tipo").Value)

            If Tipo = "image" Then
                parametros = "@" + parametros
                Dim L6 As String = "Dim ms As New IO.MemoryStream()" + vbCr
                Dim L7 As String = "AQUI_el_nombre_de_TU_PICTUREBOX.Image.Save(ms, AQUI_el_nombre_de_TU_PICTUREBOX.Image.RawFormat)" + vbCr
                Dim L8 As String = "cmd.Parameters.AddWithValue(" + labelComillas.Text + parametros + labelComillas.Text + ", ms.GetBuffer)" + vbCr

                Dim LUNIDOS As String = vbCr + L6 + L7 + L8
                txtEditarVb.Text = txtEditarVb.Text + LUNIDOS
            End If


        Next
        Dim L9 As String = vbCr + "cmd.ExecuteNonQuery()" + vbCr
        Dim L10 As String = "Cerrar()" + vbCr
        Dim L11 As String = "Catch ex As Exception" + vbCr
        Dim L12 As String = "MsgBox(ex.Message)" + vbCr
        Dim L13 As String = "End Try"
        txtEditarVb.Text = txtEditarVb.Text + L9 + L10 + L11 + L12 + L13 + vbCr + "End Sub"

    End Sub
    Sub insertar_vb()
        Dim PROCESO As String = "Public Sub " + "Insertar_" + TABLA + vbCr
        Dim nombre_scrypt As String = "Insertar_" + TABLA
        Dim L1 As String = PROCESO + "Try" + vbCr
        Dim L2 As String = "abrir()" + vbCr
        Dim L3 As String = "Dim cmd As New SqlCommand" + vbCr
        Dim L4 As String = "cmd = New SqlCommand(" + labelComillas.Text + nombre_scrypt + labelComillas.Text + ", conexion)" + vbCr
        Dim L5 As String = "cmd.CommandType = 4" + vbCr
        txtInsertarVb.Text = L1 + L2 + L3 + L4 + L5

        For Each row As DataGridViewRow In datalistadoEstructura.Rows
            Dim parametros As String = Convert.ToString(row.Cells("Parametros").Value)
            Dim parametros2 As String = Convert.ToString(row.Cells("Parametros").Value)
            Dim Enumeracion As Integer = Convert.ToInt32(row.Cells("Enumeracion").Value)
            If Enumeracion > 1 Then
                Dim Tipo As String = Convert.ToString(row.Cells("Tipo").Value)
                If Tipo <> "Image" Then
                    parametros = "@" + parametros
                    Dim cmdparametro As String = "cmd.Parameters.AddWithValue(" + labelComillas.Text + parametros + labelComillas.Text + ", txt" + parametros2 + ".Text)"
                    txtInsertarVb.Text = txtInsertarVb.Text + vbCr + cmdparametro
                End If
            End If


        Next

        For Each row As DataGridViewRow In datalistadoEstructura.Rows
            Dim parametros As String = Convert.ToString(row.Cells("Parametros").Value)
            Dim parametros2 As String = Convert.ToString(row.Cells("Parametros").Value)
            Dim Tipo As String = Convert.ToString(row.Cells("Tipo").Value)
            Dim Enumeracion As Integer = Convert.ToInt32(row.Cells("Enumeracion").Value)
            If Enumeracion > 1 Then
                If Tipo = "image" Then
                    parametros = "@" + parametros
                    Dim L6 As String = "Dim ms As New IO.MemoryStream()" + vbCr
                    Dim L7 As String = "AQUI_el_nombre_de_TU_PICTUREBOX.Image.Save(ms, AQUI_el_nombre_de_TU_PICTUREBOX.Image.RawFormat)" + vbCr
                    Dim L8 As String = "cmd.Parameters.AddWithValue(" + labelComillas.Text + parametros + labelComillas.Text + ", ms.GetBuffer)" + vbCr

                    Dim LUNIDOS As String = vbCr + L6 + L7 + L8
                    txtInsertarVb.Text = txtInsertarVb.Text + LUNIDOS
                End If
            End If

        Next
        Dim L9 As String = vbCr + "cmd.ExecuteNonQuery()" + vbCr
        Dim L10 As String = "Cerrar()" + vbCr
        Dim L11 As String = "Catch ex As Exception" + vbCr
        Dim L12 As String = "MsgBox(ex.Message)" + vbCr
        Dim L13 As String = "End Try"
        txtInsertarVb.Text = txtInsertarVb.Text + L9 + L10 + L11 + L12 + L13 + vbCr + "End Sub"


    End Sub
    Dim id As String

    Sub editar()
        use = "USE " + txtbasededatos.Text + vbCr + "GO" + vbCr
        tituloProcedimiento = "CREATE PROC editar_" & TABLA
        txtEditar.Text = use + tituloProcedimiento
        For Each row As DataGridViewRow In datalistadoEstructura.Rows
            Dim parametros As String = Convert.ToString(row.Cells("Parametros").Value)
            Dim Tipo As String = Convert.ToString(row.Cells("Tipo").Value)
            Dim longitud As String = Convert.ToString(row.Cells("Longitud").Value)
            Dim Enumeracion As Integer = Convert.ToInt32(row.Cells("Enumeracion").Value)

            Dim longitudNumericaEntera As String = Convert.ToString(row.Cells("column1").Value)
            Dim longitudNumericaDecimal As String = Convert.ToString(row.Cells("column2").Value)



            If Enumeracion = 1 Then
                id = parametros
            End If
            If longitud = "-1" Then longitud = "MAX"
            Dim Longitud_completa As String
            Longitud_completa = "(" & longitud + ")"
            If longitud = "" Then
                If Tipo = "numeric" Or Tipo = "decimal" Then
                    Dim longitud_para_numericos As String
                    longitud_para_numericos = "(" & longitudNumericaEntera & "," & longitudNumericaDecimal & ")"
                    parametros = "@" + parametros + " As " + Tipo + longitud_para_numericos + ","
                Else
                    parametros = "@" + parametros + " As " + Tipo + ","

                End If

            ElseIf longitud <> "" And Tipo <> "image" Then
                parametros = "@" + parametros + " As " + Tipo + Longitud_completa + ","
            ElseIf longitud <> "" And Tipo = "image" Then
                parametros = "@" + parametros + " As " + Tipo + ","
            End If
            txtEditar.Text = txtEditar.Text + vbCr + parametros

        Next
        largo = txtEditar.Text.Length
        txtEditar.Text = Mid(txtEditar.Text, 1, largo - 1)
        txtEditar.Text = txtEditar.Text + vbCr + "As" + vbCr


        funcion = "UPDATE " + TABLA + " Set" + vbCr


        txtEditar.Text = txtEditar.Text + funcion
        For Each row As DataGridViewRow In datalistadoEstructura.Rows
            Dim parametros As String = Convert.ToString(row.Cells("Parametros").Value)
            Dim Enumeracion As Integer = Convert.ToInt32(row.Cells("Enumeracion").Value)
            If Enumeracion > 1 Then
                parametros = parametros + "=@" + parametros + ","
                txtEditar.Text = txtEditar.Text + vbCr + parametros
            End If
        Next
        largo = txtEditar.Text.Length
        txtEditar.Text = Mid(txtEditar.Text, 1, largo - 1) + vbCr + "Where " + id + "=" + "@" + id
    End Sub
    Dim use As String
    Sub InsertarSQLServer()
        use = "USE " + txtbasededatos.Text + vbCr + "GO" + vbCr
        tituloProcedimiento = "CREATE PROC insertar_" & TABLA
        txtInsertarSQLServer.Text = use + tituloProcedimiento
        For Each row As DataGridViewRow In datalistadoEstructura.Rows
            Dim parametros As String = Convert.ToString(row.Cells("Parametros").Value)
            Dim Tipo As String = Convert.ToString(row.Cells("Tipo").Value)
            Dim longitud As String = Convert.ToString(row.Cells("Longitud").Value)
            Dim Enumeracion As Integer = Convert.ToInt32(row.Cells("Enumeracion").Value)

            Dim longitudNumericaEntera As String = Convert.ToString(row.Cells("column1").Value)
            Dim longitudNumericaDecimal As String = Convert.ToString(row.Cells("column2").Value)



            If Enumeracion > 1 Then
                If longitud = "-1" Then longitud = "MAX"
                Dim Longitud_completa As String
                Longitud_completa = "(" & longitud + ")"
                If longitud = "" Then
                    If Tipo = "numeric" Or Tipo = "decimal" Then
                        Dim longitud_para_numericos As String
                        longitud_para_numericos = "(" & longitudNumericaEntera & "," & longitudNumericaDecimal & ")"
                        parametros = "@" + parametros + " As " + Tipo + longitud_para_numericos + ","
                    Else
                        parametros = "@" + parametros + " As " + Tipo + ","

                    End If

                ElseIf longitud <> "" And Tipo <> "image" Then
                        parametros = "@" + parametros + " As " + Tipo + Longitud_completa + ","
                    ElseIf longitud <> "" And Tipo = "image" Then
                    parametros = "@" + parametros + " As " + Tipo + ","
                End If
                txtInsertarSQLServer.Text = txtInsertarSQLServer.Text + vbCr + parametros
            End If
        Next
        largo = txtInsertarSQLServer.Text.Length
        txtInsertarSQLServer.Text = Mid(txtInsertarSQLServer.Text, 1, largo - 1)
        txtInsertarSQLServer.Text = txtInsertarSQLServer.Text + vbCr + "As" + vbCr

        If EvitarRepeticionesSQLServer.Checked = True Then
            If lblRepeticionesSQLServer2.Text <> "" Then
                Dim condicional As String
                Dim elseSQL As String
                Dim errorSQL As String
                Dim condicional_completa As String
                condicional = vbCr + lblRepeticionesSQLServer1.Text + lblRepeticionesSQLServer2.Text + ")" + vbCr
                errorSQL = "RAISERROR (" + "'" + txtErrorSQLServer.Text + "'" + ", 16,1)" + vbCr
                elseSQL = "Else" + vbCr
                condicional_completa = condicional + errorSQL + elseSQL
                funcion = condicional_completa + "INSERT INTO " + TABLA + vbCr
            Else
                MessageBox.Show("Ingrese los parametros a validar")
            End If

        Else
            funcion = "INSERT INTO " + TABLA + vbCr
        End If

        txtInsertarSQLServer.Text = txtInsertarSQLServer.Text + funcion
        txtInsertarSQLServer.Text = txtInsertarSQLServer.Text + "Values ("
        For Each row As DataGridViewRow In datalistadoEstructura.Rows
            Dim parametros As String = Convert.ToString(row.Cells("Parametros").Value)
            Dim Enumeracion As Integer = Convert.ToInt32(row.Cells("Enumeracion").Value)
            If Enumeracion > 1 Then
                parametros = "@" + parametros + ","
                txtInsertarSQLServer.Text = txtInsertarSQLServer.Text + vbCr + parametros
            End If
        Next
        largo = txtInsertarSQLServer.Text.Length
        txtInsertarSQLServer.Text = Mid(txtInsertarSQLServer.Text, 1, largo - 1)
        txtInsertarSQLServer.Text = txtInsertarSQLServer.Text + ")"
    End Sub
    Sub eliminar()
        use = "USE " + txtbasededatos.Text + vbCr + "GO" + vbCr

        tituloProcedimiento = use + "CREATE PROC eliminar_" & TABLA + vbCr
        txtEliminar.Text = tituloProcedimiento

        For Each row As DataGridViewRow In datalistadoEstructura.Rows

            Dim parametros As String = Convert.ToString(row.Cells("Parametros").Value)
            Dim Tipo As String = Convert.ToString(row.Cells("Tipo").Value)

            Dim Enumeracion As Integer = Convert.ToInt32(row.Cells("Enumeracion").Value)

            If Enumeracion = 1 Then
                Dim parametro_puro = parametros
                parametros = "@" + parametros + " As " + Tipo + vbCr
                txtEliminar.Text = txtEliminar.Text + parametros + vbCr + "As" + vbCr
                funcion = "DELETE FROM " + TABLA + vbCr
                txtEliminar.Text = txtEliminar.Text + funcion
                txtEliminar.Text = txtEliminar.Text + "WHERE " + parametro_puro & "=@" + parametro_puro
            End If
        Next
    End Sub

    Dim bases() As String
    Dim dt As New DataTable

    Private Function basesDeDatos(ByVal instancia As String) As String()
        ' Las bases de datos de SQL Server
        Dim basesSys() As String = {"master", "model", "msdb", "tempdb"}
        ' Usamos la seguridad integrada de Windows
        Dim sCnn As String = "Server=" & instancia & "; " &
            "database=master; integrated security=yes"

        ' La orden T-SQL para recuperar las bases de master
        Dim sel As String = "Select name FROM sysdatabases"
        Try
            Dim da As New SqlDataAdapter(sel, sCnn)
            da.Fill(dt)
            ReDim bases(dt.Rows.Count - 1)
            Dim k As Integer = -1
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim s As String = dt.Rows(i).Item("name").ToString()
                ' Solo asignar las bases que no son del sistema
                If Array.IndexOf(basesSys, s) = -1 Then
                    k += 1
                    bases(k) = s
                End If
            Next

            If k = -1 Then Return Nothing
            ReDim Preserve bases(k)
            Return bases
            estado_conexion = "CONECTADO"

        Catch ex As Exception
            estado_conexion = "NO CONECTADO"

        End Try
        Return Nothing

    End Function
    Dim dbcnString As String
    Dim SERVIDOR As String
    Dim usuario As String
    Dim contraseña As String

    Public Sub ReadfromXMLinstancia()

        Try
            Dim doc As XmlDocument = New XmlDocument()
            doc.Load("ConnectionString.xml")
            Dim root As XmlElement = doc.DocumentElement
            dbcnString = root.Attributes.Item(0).Value
            SERVIDOR = (aes.Decrypt(dbcnString, appPwdUnique, Integer.Parse("256")))

        Catch ex As System.Security.Cryptography.CryptographicException


        End Try
    End Sub
    Public Sub ReadfromXMLusuario()

        Try
            Dim doc As XmlDocument = New XmlDocument()
            doc.Load("usuario.xml")
            Dim root As XmlElement = doc.DocumentElement
            dbcnString = root.Attributes.Item(0).Value
            usuario = (aes.Decrypt(dbcnString, appPwdUnique, Integer.Parse("256")))

        Catch ex As System.Security.Cryptography.CryptographicException


        End Try
    End Sub
    Public Sub ReadfromXMLcontraseña()

        Try
            Dim doc As XmlDocument = New XmlDocument()
            doc.Load("contraseña.xml")
            Dim root As XmlElement = doc.DocumentElement
            dbcnString = root.Attributes.Item(0).Value
            contraseña = (aes.Decrypt(dbcnString, appPwdUnique, Integer.Parse("256")))

        Catch ex As System.Security.Cryptography.CryptographicException


        End Try
    End Sub

    Private Sub Generador_UI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReadfromXMLusuario()
        If usuario = "NULO" Then
            ReadfromXMLinstancia()
            basesDeDatos(SERVIDOR)
            Multilinea(datalistado_TABLAS)
            datalistado_TABLAS.Columns(0).Width = datalistado_TABLAS.Width - 50
            With txtbasededatos
                .DataSource = dt
                .DisplayMember = "name"
            End With
        Else
            ReadfromXMLinstancia()
            ReadfromXMLcontraseña()
            ReadfromXMLusuario()
            basesDeDatosCONTRASEÑA(SERVIDOR)

            Multilinea(datalistado_TABLAS)
            datalistado_TABLAS.Columns(0).Width = datalistado_TABLAS.Width - 50
            With txtbasededatos
                .DataSource = dt
                .DisplayMember = "name"
            End With
        End If
        indicador = "SQLSERVER"
        PanelBienvenida.Visible = True
        PanelBienvenida.Dock = DockStyle.Fill
        PanelSQLServer.Dock = DockStyle.Fill
        PanelCsharp.Dock = DockStyle.Fill
        PanelVb.Dock = DockStyle.Fill
        Me.FormBorderStyle = FormBorderStyle.None
    End Sub
    Private Function basesDeDatosCONTRASEÑA(ByVal instancia As String) As String()
        ' Las bases de datos de SQL Server
        Dim basesSys() As String = {"master", "model", "msdb", "tempdb"}
        ' Usamos la seguridad integrada de Windows
        Dim sCnn As String = "Server=" & instancia & "; " &
            "database=master; integrated security=False; User=" & usuario & "; password=" & contraseña

        ' La orden T-SQL para recuperar las bases de master
        Dim sel As String = "Select name FROM sysdatabases"
        Try
            Dim da As New SqlDataAdapter(sel, sCnn)
            da.Fill(dt)
            ReDim bases(dt.Rows.Count - 1)
            Dim k As Integer = -1
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim s As String = dt.Rows(i).Item("name").ToString()
                ' Solo asignar las bases que no son del sistema
                If Array.IndexOf(basesSys, s) = -1 Then
                    k += 1
                    bases(k) = s
                End If
            Next

            If k = -1 Then Return Nothing
            ReDim Preserve bases(k)
            Return bases
            estado_conexion = "CONECTADO"
        Catch ex As Exception
            estado_conexion = "NO CONECTADO"

        End Try
        Return Nothing

    End Function

    Sub mostrar_tablas_de_bd()

        datalistado_TABLAS.Rows.Clear()
        'Me.ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        'Cargar el Combo con las tablas existentes en SQL
        Dim ltDataTable As DataTable
        Dim laRestricciones() As String = {Nothing}
        Dim msCadenaSQL As String = "Data Source=" & SERVIDOR & ";Initial Catalog=" & txtbasededatos.Text & ";Integrated Security=True"
        Try
            Using loConexionSql As New SqlConnection(msCadenaSQL)
                loConexionSql.Open()
                ltDataTable = loConexionSql.GetSchema(SqlClientMetaDataCollectionNames.Tables, laRestricciones)
                For liFilas As Integer = 0 To ltDataTable.Rows.Count - 1
                    Me.datalistado_TABLAS.Rows.Add(ltDataTable.Rows(liFilas).Item("TABLE_NAME").ToString())
                Next
            End Using
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Sub mostrar_tablas_de_bd_CON_CONTRASEÑA()

        datalistado_TABLAS.Rows.Clear()
        'Me.ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        'Cargar el Combo con las tablas existentes en SQL
        Dim ltDataTable As DataTable
        Dim laRestricciones() As String = {Nothing}
        Dim msCadenaSQL As String = "Data Source=" & SERVIDOR & ";Initial Catalog=" & txtbasededatos.Text & ";Integrated Security=False; " & "User Id=" & usuario & ";Password=" & contraseña
        Try
            Using loConexionSql As New SqlConnection(msCadenaSQL)
                loConexionSql.Open()
                ltDataTable = loConexionSql.GetSchema(SqlClientMetaDataCollectionNames.Tables, laRestricciones)
                For liFilas As Integer = 0 To ltDataTable.Rows.Count - 1
                    Me.datalistado_TABLAS.Rows.Add(ltDataTable.Rows(liFilas).Item("TABLE_NAME").ToString())
                Next
            End Using
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs)



    End Sub




    Sub mostrarsql()
        use = "USE " + txtbasededatos.Text + vbCr + "GO" + vbCr

        tituloProcedimiento = use + "CREATE PROC mostrar_" & TABLA
        txtMostrar.Text = tituloProcedimiento

        txtMostrar.Text = txtMostrar.Text + vbCr + "As" + vbCr
        funcion = "Select * FROM " + TABLA + vbCr
        txtMostrar.Text = txtMostrar.Text + funcion



    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtbasededatos.SelectedIndexChanged

        If usuario = "NULO" Then
            mostrar_tablas_de_bd()
        Else
            mostrar_tablas_de_bd_CON_CONTRASEÑA()
        End If

    End Sub


    Private Sub psEstructura_Tabla(ByVal strTabla As String)
        Dim msCadenaSQL As String = "Data Source=" & SERVIDOR & ";Initial Catalog=" & txtbasededatos.Text & ";Integrated Security=True"
        If indicador_de_parametros = "CSHARP" Then
            Me.datalistadoEstructuraCONParametros.Rows.Clear()
        Else
            Me.datalistadoEstructura.Rows.Clear()
        End If
        Try
            Dim conConexion As New SqlConnection(msCadenaSQL)
            Dim coSQL As New SqlCommand("Select *” _
                                        & “ FROM INFORMATION_SCHEMA.” _
                                        & “COLUMNS WHERE TABLE_NAME='" & strTabla & "'", conConexion)
            Dim drColumnas As SqlDataReader
            conConexion.Open()
            drColumnas = coSQL.ExecuteReader
            While drColumnas.Read
                If indicador_de_parametros = "CSHARP" Then
                    With Me.datalistadoEstructuraCONParametros
                        .Rows.Add(drColumnas("COLUMN_NAME"), drColumnas("DATA_TYPE"), drColumnas("CHARACTER_MAXIMUM_LENGTH"), drColumnas("NUMERIC_PRECISION"), drColumnas("NUMERIC_SCALE"), drColumnas.Item(5).ToString, drColumnas.Item(1).ToString, drColumnas.Item(2).ToString, drColumnas.Item(3).ToString, drColumnas.Item(4).ToString, drColumnas.Item(5).ToString, drColumnas.Item(7).ToString, drColumnas.Item(8).ToString, drColumnas.Item(9).ToString, drColumnas.Item(10).ToString, drColumnas.Item(11).ToString, drColumnas.Item(12).ToString)
                    End With
                Else
                    With Me.datalistadoEstructura
                        .Rows.Add(drColumnas("COLUMN_NAME"), drColumnas("DATA_TYPE"), drColumnas("CHARACTER_MAXIMUM_LENGTH"), drColumnas("NUMERIC_PRECISION"), drColumnas("NUMERIC_SCALE"), drColumnas.Item(5).ToString, drColumnas.Item(1).ToString, drColumnas.Item(2).ToString, drColumnas.Item(3).ToString, drColumnas.Item(4).ToString, drColumnas.Item(5).ToString, drColumnas.Item(7).ToString, drColumnas.Item(8).ToString, drColumnas.Item(9).ToString, drColumnas.Item(10).ToString, drColumnas.Item(11).ToString, drColumnas.Item(12).ToString)
                    End With
                End If

            End While
            drColumnas.Close()
            conConexion.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message,
            “Mensaje”, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub psEstructura_Tabla_CON_CONTRASEÑA(ByVal strTabla As String)
        Dim msCadenaSQL As String = "Data Source=" & SERVIDOR & ";Initial Catalog=" & txtbasededatos.Text & ";Integrated Security=false; " & "User Id=" & usuario & ";Password=" & contraseña

        Me.datalistadoEstructura.Rows.Clear()
        Try
            Dim conConexion As New SqlConnection(msCadenaSQL)
            Dim coSQL As New SqlCommand("SELECT COLUMN_NAME,DATA_TYPE,” _
                                        & “CHARACTER_MAXIMUM_LENGTH,IS_NULLABLE FROM INFORMATION_SCHEMA.” _
                                        & “COLUMNS WHERE TABLE_NAME='" & strTabla & "'", conConexion)
            Dim drColumnas As SqlDataReader
            conConexion.Open()
            drColumnas = coSQL.ExecuteReader
            While drColumnas.Read

                With Me.datalistadoEstructura



                    .Rows.Add(drColumnas("COLUMN_NAME"), drColumnas("DATA_TYPE"))

                End With


            End While
            drColumnas.Close()
            conConexion.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message,
            “Mensaje”, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub datalistado_Parametros_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistado_TABLAS.CellClick


    End Sub

    Dim contador As Integer

    Sub SQLServer()
        btnSQLSERVER.BackColor = Color.DodgerBlue
        btnVb.BackColor = Color.FromArgb(45, 45, 48)
        btnCsharp.BackColor = Color.FromArgb(45, 45, 48)
        TSQLvolver.Visible = False
        EvitarRepeticionesSQLServer.Checked = False
        PanelSQLServer.Visible = True
        PanelCsharp.Visible = False


        InsertarSQLServer()
        editar()
        mostrarsql()
        eliminar()
        crudSQLCompleto()







    End Sub
    Sub crudSQLCompleto()
        txtCrudSQLCompleto.Text = txtInsertarSQLServer.Text + vbCr + vbCr + txtEditar.Text + vbCr + vbCr + txtMostrar.Text + vbCr + vbCr + txtEliminar.Text
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistadoEstructura.CellContentClick

    End Sub

    Private Sub Panel9_Paint(sender As Object, e As PaintEventArgs)

    End Sub
    Dim indicador As String
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnSQLSERVER.Click
        indicador = "SQLSERVER"


        PanelSQLServer.Visible = True
        PanelVb.Visible = False

        contador = 0
        TABLA = Me.datalistado_TABLAS.SelectedCells.Item(0).Value
        If usuario = "NULO" Then
            Call Me.psEstructura_Tabla(TABLA)
        Else
            Call Me.psEstructura_Tabla_CON_CONTRASEÑA(TABLA)
        End If
        SQLServer()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnVb.Click
        indicador = "VB"


        PanelSQLServer.Visible = False
        PanelCsharp.Visible = False
        PanelVb.Visible = True



        Try
            TABLA = Me.datalistado_TABLAS.SelectedCells.Item(0).Value

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        If usuario = "NULO" Then
            Call Me.psEstructura_Tabla(TABLA)
        Else
            Call Me.psEstructura_Tabla_CON_CONTRASEÑA(TABLA)
        End If
        VisualBasic()
    End Sub
    Sub VisualBasic()
        btnVb.BackColor = Color.DodgerBlue
        btnSQLSERVER.BackColor = Color.FromArgb(45, 45, 48)
        btnCsharp.BackColor = Color.FromArgb(45, 45, 48)
        mostrar_vb()
        insertar_vb()
        editar_vb()
    End Sub

    Sub mostrar_vb()
        Dim L1 As String
        L1 = "Public Sub " + "mostrar_" + TABLA + "_en_datagridview" + vbCr
        Dim L2 As String = "Dim dt As New DataTable" + vbCr
        Dim L3 As String = "Dim da As SqlDataAdapter" + vbCr
        Dim L4 As String = "Try" + vbCr
        Dim L5 As String = "abrir()" + vbCr
        Dim nombre_scrypt2 As String = "mostrar_" + TABLA
        Dim L6 As String = "da = New SqlDataAdapter(" + labelComillas.Text + nombre_scrypt2 + labelComillas.Text + ", conexion)" + vbCr
        Dim L7 As String = "da.Fill(dt)" + vbCr
        Dim L8 As String = "Tu_datagridview.DataSource = dt" + vbCr
        Dim L9 As String = "Cerrar()" + vbCr
        Dim L10 As String = "Catch ex As Exception" + vbCr
        Dim L11 As String = "MessageBox.Show(ex.StackTrace)" + vbCr
        Dim L12 As String = "End Try"
        txtMostrarVb.Text = L1 + L2 + L3 + L4 + L5 + L6 + L7 + L8 + L9 + L10 + L11 + L12 + vbCr + "End Sub"
    End Sub
    Private Sub chekCombo_OnChange(sender As Object, e As EventArgs)
        'If chekCombo.Checked = True Then
        '    chekDataGrid.Checked = False
        '    chekVariable.Checked = False
        'Else
        '    chekDataGrid.Checked = True
        '    chekVariable.Checked = False
        'End If
    End Sub

    Private Sub chekDataGrid_OnChange(sender As Object, e As EventArgs)
        'If chekDataGrid.Checked = True Then
        '    chekCombo.Checked = False
        '    chekVariable.Checked = False
        'Else
        '    chekCombo.Checked = True
        '    chekVariable.Checked = False
        'End If
    End Sub

    Private Sub chekVariable_OnChange(sender As Object, e As EventArgs)
        'If chekVariable.Checked = True Then
        '    chekCombo.Checked = False
        '    chekDataGrid.Checked = False
        'Else
        '    chekDataGrid.Checked = True
        '    chekVariable.Checked = False
        'End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnCsharp.Click
        Try
            indicador = "C#"


            Try

                PanelSQLServer.Visible = False
                PanelCsharp.Visible = True
                PanelVb.Visible = False
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try


            contador = 0
            Try
                TABLA = Me.datalistado_TABLAS.SelectedCells.Item(0).Value

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            If usuario = "NULO" Then
                Call Me.psEstructura_Tabla(TABLA)
            Else
                Call Me.psEstructura_Tabla_CON_CONTRASEÑA(TABLA)
            End If
            csharp()
        Catch ex As Exception

        End Try


    End Sub
    Sub mostrar_datagridview_C_sharp()
        Dim proceso As String
        Dim L4 As String
        proceso = "Private void " + "mostrar_en_Datagridview_" + TABLA + "(" + ")" + vbCr + "{" + vbCr

        Dim nombre_scrypt2 As String = "mostrar_" + TABLA
        Dim L1 As String = proceso + "Try" + vbCr + "{" + vbCr
        Dim Indicar_parametro = "da.SelectCommand.CommandType = CommandType.StoredProcedure;"
        Dim L2 As String = "CONEXION.CONEXIONMAESTRA.abrir();" + vbCr





        If ConParametrosCsharp.Checked = True Then

            For Each row As DataGridViewRow In datalistadoEstructuraCONParametros.Rows

                Dim seleccionados As Integer = datalistadoEstructuraCONParametros.Rows.Cast(Of DataGridViewRow).
                                            Where(Function(x) x.Cells("Marcar").Value = True).
                                            ToList().
                                            Count
                If seleccionados > 0 Then
                    L4 = "da = New SqlDataAdapter(" + labelComillas.Text + nombre_scrypt2 + labelComillas.Text + ", CONEXION.CONEXIONMAESTRA.conectar);" + vbCr + Indicar_parametro + vbCr
                Else
                    L4 = "da = New SqlDataAdapter(" + labelComillas.Text + nombre_scrypt2 + labelComillas.Text + ", CONEXION.CONEXIONMAESTRA.conectar);" + vbCr

                End If

            Next

        Else
            L4 = "da = New SqlDataAdapter(" + labelComillas.Text + nombre_scrypt2 + labelComillas.Text + ", CONEXION.CONEXIONMAESTRA.conectar);" + vbCr
        End If

        'Dim L5 As String = "cmd.CommandType = CommandType.StoredProcedure;"
        txtMostrarCsharp.Text = L1 + L2 + L4
        If ConParametrosCsharp.Checked = True Then
            For Each row As DataGridViewRow In datalistadoEstructuraCONParametros.Rows
                Dim Marcar As Boolean = False
                Marcar = Convert.ToBoolean(row.Cells("Marcar").Value)
                If (Marcar) Then
                    Dim parametros As String = Convert.ToString(row.Cells("Parametros2").Value)
                    Dim parametros2 As String = Convert.ToString(row.Cells("Parametros2").Value)
                    Dim Tipo As String = Convert.ToString(row.Cells("Tipo2").Value)
                    If Tipo <> "image" Then
                        parametros = "@" + parametros
                        Dim cmdparametro As String = "cmd.Parameters.AddWithValue(" + labelComillas.Text + parametros + labelComillas.Text + ", txt" + parametros2 + ".Text);"
                        txtMostrarCsharp.Text = txtMostrarCsharp.Text + vbCr + cmdparametro
                    End If
                End If
            Next
            Dim L5 As String = "da.Fill(dt);" + vbCr + "Tu_Datagridview.DataSource = dt;" + vbCr + "CONEXION.CONEXIONMAESTRA.Cerrar();" + vbCr
            Dim L6 As String = "}" + vbCr + "catch (Exception ex)" + vbCr + "{" + vbCr + "MessageBox.Show(ex.StackTrace);" + vbCr + "}" + vbCr + "}"
            txtMostrarCsharp.Text = txtMostrarCsharp.Text + vbCr + L5 + L6
        Else
            Dim L5 As String = "da.Fill(dt);" + vbCr + "Tu_Datagridview.DataSource = dt;" + vbCr + "CONEXION.CONEXIONMAESTRA.Cerrar();" + vbCr
            Dim L6 As String = "}" + vbCr + "catch (Exception ex)" + vbCr + "{" + vbCr + "MessageBox.Show(ex.StackTrace);" + vbCr + "}" + vbCr + "}"
            txtMostrarCsharp.Text = txtMostrarCsharp.Text + L5 + L6
        End If






        'Dim proceso As String
        'proceso = "Private void " + "mostrar_en_Datagridview_" + TABLA + "(" + ")" + vbCr + "{" + vbCr

        'Dim nombre_scrypt2 As String = "mostrar_" + TABLA
        'Dim L1 As String = proceso + "Try" + vbCr
        'Dim Llave1 As String = "{" + vbCr + "DataTable dt = New DataTable();" + vbCr + "SqlDataAdapter da;" + vbCr
        'Dim L2 As String = "CONEXION.CONEXIONMAESTRA.abrir();" + vbCr
        'Dim Indicar_parametro = "da.SelectCommand.CommandType = CommandType.StoredProcedure;"
        'Dim L4 As String

        'If ConParametrosCsharp.Checked = True Then
        '    L4 = "da = New SqlDataAdapter(" + labelComillas.Text + nombre_scrypt2 + labelComillas.Text + ", CONEXION.CONEXIONMAESTRA.conectar);" + vbCr + Indicar_parametro + vbCr


        '    For Each row As DataGridViewRow In datalistadoEstructuraCONParametros.Rows

        '        'Dim seleccionados As Integer = datalistadoEstructuraCONParametros.Rows.Cast(Of DataGridViewRow).
        '        '                            Where(Function(x) x.Cells("Marcar").Value = True).
        '        '                            ToList().
        '        '                            Count

        '        'If seleccionados = 0 Then
        '        '    'MessageBox.Show("Seleccine por lo menos una casilla.")
        '        '    'Salimos
        '        'Else
        '        'Label14.Text = seleccionados
        '        Dim parametros As String = Convert.ToString(row.Cells("Parametros2").Value)
        '            Dim parametros2 As String = Convert.ToString(row.Cells("Parametros2").Value)
        '            Dim Tipo As String = Convert.ToString(row.Cells("Tipo2").Value)
        '        'If Tipo <> "image" Then
        '        parametros = "@" + parametros
        '                Dim cmdparametro As String = "da.SelectCommand.Parameters.AddWithValue(" + labelComillas.Text + parametros + labelComillas.Text + ", txt" + parametros2 + ".Text);"
        '        txtMostrarCsharp.Text = vbCr + cmdparametro
        '        'End If
        '        'End If

        '        'Hay uno o más seleccionados
        '        'seguimos...


        '    Next
        '    'Dim L5 As String = "da.Fill(dt);" + vbCr + "Tu_Datagridview.DataSource = dt;" + vbCr + "CONEXION.CONEXIONMAESTRA.Cerrar();" + vbCr
        '    'Dim L6 As String = "}" + vbCr + "catch (Exception ex)" + vbCr + "{" + vbCr + "MessageBox.Show(ex.StackTrace);" + vbCr + "}" + vbCr + "}"

        '    'txtMostrarCsharp.Text = txtMostrarCsharp.Text + vbCr + L5 + L6
        'Else
        '    'L4 = "da = New SqlDataAdapter(" + labelComillas.Text + nombre_scrypt2 + labelComillas.Text + ", CONEXION.CONEXIONMAESTRA.conectar);" + vbCr

        '    'Dim L5 As String = "da.Fill(dt);" + vbCr + "Tu_Datagridview.DataSource = dt;" + vbCr + "CONEXION.CONEXIONMAESTRA.Cerrar();" + vbCr
        '    'Dim L6 As String = "}" + vbCr + "catch (Exception ex)" + vbCr + "{" + vbCr + "MessageBox.Show(ex.StackTrace);" + vbCr + "}" + vbCr + "}"

        '    'txtMostrarCsharp.Text = L1 + Llave1 + L2 + L4 + vbCr + L5 + L6
        'End If

    End Sub
    Sub insertar_C_sharp()
        Dim proceso As String
        proceso = "private void " + "Insertar_" + TABLA + "(" + ")" + vbCr + "{" + vbCr

        Dim nombre_scrypt2 As String = "Insertar_" + TABLA
        Dim L1 As String = proceso + "try" + vbCr + "{" + vbCr

        Dim L2 As String = "CONEXION.CONEXIONMAESTRA.abrir();" + vbCr
        'Dim L3 As String = "Dim cmd As New SqlCommand" + vbCr
        Dim L4 As String = "SqlCommand cmd = new SqlCommand(" + labelComillas.Text + nombre_scrypt2 + labelComillas.Text + ", CONEXION.CONEXIONMAESTRA.conectar);" + vbCr
        Dim L5 As String = "cmd.CommandType = CommandType.StoredProcedure;"
        txtInsertarCsharp.Text = L1 + L2 + L4 + L5

        For Each row As DataGridViewRow In datalistadoEstructura.Rows
            Dim parametros As String = Convert.ToString(row.Cells("Parametros").Value)
            Dim parametros2 As String = Convert.ToString(row.Cells("Parametros").Value)
            Dim Tipo As String = Convert.ToString(row.Cells("Tipo").Value)
            Dim Enumeracion As Integer = Convert.ToInt32(row.Cells("Enumeracion").Value)
            If Enumeracion > 1 Then
                If Tipo <> "image" Then
                    parametros = "@" + parametros
                    Dim cmdparametro As String = "cmd.Parameters.AddWithValue(" + labelComillas.Text + parametros + labelComillas.Text + ", txt" + parametros2 + ".Text);"
                    txtInsertarCsharp.Text = txtInsertarCsharp.Text + vbCr + cmdparametro
                End If
            End If

        Next

        For Each row As DataGridViewRow In datalistadoEstructura.Rows
            Dim parametros As String = Convert.ToString(row.Cells("Parametros").Value)
            Dim parametros2 As String = Convert.ToString(row.Cells("Parametros").Value)
            Dim Tipo As String = Convert.ToString(row.Cells("Tipo").Value)

            If Tipo = "image" Then
                parametros = "@" + parametros
                Dim L6 As String = "System.IO.MemoryStream ms = new System.IO.MemoryStream();" + vbCr
                Dim L7 As String = "AQUI_el_nombre_de_TU_PICTUREBOX.Image.Save(ms, AQUI_el_nombre_de_TU_PICTUREBOX.Image.RawFormat);" + vbCr
                Dim L8 As String = "cmd.Parameters.AddWithValue(" + labelComillas.Text + parametros + labelComillas.Text + ", ms.GetBuffer());" + vbCr

                Dim LUNIDOS As String = vbCr + L6 + L7 + L8
                txtInsertarCsharp.Text = txtInsertarCsharp.Text + LUNIDOS
            End If
        Next
        Dim L9 As String = vbCr + "cmd.ExecuteNonQuery();" + vbCr
        Dim L10 As String = "CONEXION.CONEXIONMAESTRA.Cerrar();" + vbCr
        Dim llave2 As String = "}" + vbCr
        Dim L11 As String = llave2 + "catch (Exception ex)" + vbCr
        Dim llave3 As String = "{" + vbCr
        Dim L12 As String = "MessageBox.Show(ex.Message);" + vbCr
        Dim L13 As String = "}"
        txtInsertarCsharp.Text = txtInsertarCsharp.Text + L9 + L10 + L11 + llave3 + L12 + L13 + vbCr + "}"



    End Sub
    Sub editar_C_sharp()
        Dim proceso As String
        proceso = "Private void " + "editar" + TABLA + "(" + ")" + vbCr + "{" + vbCr

        Dim nombre_scrypt2 As String = "editar_" + TABLA
        Dim L1 As String = proceso + "Try" + vbCr + "{" + vbCr
        Dim L2 As String = "CONEXION.CONEXIONMAESTRA.abrir();" + vbCr
        'Dim L3 As String = "Dim cmd As New SqlCommand" + vbCr
        Dim L4 As String = "SqlCommand cmd = New SqlCommand(" + labelComillas.Text + nombre_scrypt2 + labelComillas.Text + ", CONEXION.CONEXIONMAESTRA.conectar);" + vbCr
        Dim L5 As String = "cmd.CommandType = CommandType.StoredProcedure;"
        txtEditarCsharp.Text = L1 + L2 + L4 + L5

        For Each row As DataGridViewRow In datalistadoEstructura.Rows
            Dim parametros As String = Convert.ToString(row.Cells("Parametros").Value)
            Dim parametros2 As String = Convert.ToString(row.Cells("Parametros").Value)
            Dim Tipo As String = Convert.ToString(row.Cells("Tipo").Value)
            If Tipo <> "image" Then
                parametros = "@" + parametros
                Dim cmdparametro As String = "cmd.Parameters.AddWithValue(" + labelComillas.Text + parametros + labelComillas.Text + ", txt" + parametros2 + ".Text);"
                txtEditarCsharp.Text = txtEditarCsharp.Text + vbCr + cmdparametro
            End If
        Next

        For Each row As DataGridViewRow In datalistadoEstructura.Rows
            Dim parametros As String = Convert.ToString(row.Cells("Parametros").Value)
            Dim parametros2 As String = Convert.ToString(row.Cells("Parametros").Value)
            Dim Tipo As String = Convert.ToString(row.Cells("Tipo").Value)

            If Tipo = "image" Then
                parametros = "@" + parametros
                Dim L6 As String = "System.IO.MemoryStream ms = New System.IO.MemoryStream();" + vbCr
                Dim L7 As String = "AQUI_el_nombre_de_TU_PICTUREBOX.Image.Save(ms, AQUI_el_nombre_de_TU_PICTUREBOX.Image.RawFormat);" + vbCr
                Dim L8 As String = "cmd.Parameters.AddWithValue(" + labelComillas.Text + parametros + labelComillas.Text + ", ms.GetBuffer());" + vbCr

                Dim LUNIDOS As String = vbCr + L6 + L7 + L8
                txtEditarCsharp.Text = txtEditarCsharp.Text + LUNIDOS
            End If
        Next
        Dim L9 As String = vbCr + "cmd.ExecuteNonQuery();" + vbCr
        Dim L10 As String = "CONEXION.CONEXIONMAESTRA.Cerrar();" + vbCr
        Dim llave2 As String = "}" + vbCr
        Dim L11 As String = llave2 + "catch (Exception ex)" + vbCr
        Dim llave3 As String = "{" + vbCr
        Dim L12 As String = "MessageBox.Show(ex.Message);" + vbCr
        Dim L13 As String = "}"
        txtEditarCsharp.Text = txtEditarCsharp.Text + L9 + L10 + L11 + llave3 + L12 + L13 + vbCr + "}"


    End Sub


    Private Sub datalistado_TABLAS_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistado_TABLAS.CellDoubleClick
        Try
            TABLA = Me.datalistado_TABLAS.SelectedCells.Item(0).Value
            PanelTABLET.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        If usuario = "NULO" Then
            Call Me.psEstructura_Tabla(TABLA)
        Else
            Call Me.psEstructura_Tabla_CON_CONTRASEÑA(TABLA)
        End If
        PanelBienvenida.Visible = False
        PanelBienvenida.Dock = DockStyle.None
        If indicador = "SQLSERVER" Then
            SQLServer()
        ElseIf indicador = "C#"
            csharp()
        ElseIf indicador = "VB"
            VisualBasic()
        End If

    End Sub
    Sub csharp()
        btnCsharp.BackColor = Color.DodgerBlue
        btnVb.BackColor = Color.FromArgb(45, 45, 48)
        btnSQLSERVER.BackColor = Color.FromArgb(45, 45, 48)
        ConParametrosCsharp.Checked = False
        PanelSQLServer.Visible = False
        PanelCsharp.Visible = True

        insertar_C_sharp()
        editar_C_sharp()
        mostrar_datagridview_C_sharp()
    End Sub
    Private Sub TimerSQL_Tick(sender As Object, e As EventArgs)
        SQLServer()

    End Sub


    Dim ruta As String

    Sub ejecutar_scryt_crearProcedimientos_almacenados()

        ruta = Path.Combine(Directory.GetCurrentDirectory(), "CRUD369" & ".txt")

        Dim fi As FileInfo = New FileInfo(ruta)
        Dim sw As StreamWriter

        Try
            If File.Exists(ruta) = False Then

                sw = File.CreateText(ruta)
                sw.WriteLine(txtCrear_procedimientos.Text)
                sw.Flush()
                sw.Close()
            ElseIf File.Exists(ruta) = True Then
                File.Delete(ruta)
                sw = File.CreateText(ruta)
                sw.WriteLine(txtCrear_procedimientos.Text)
                sw.Flush()
                sw.Close()
            End If
        Catch ex As Exception

        End Try

        Try
            Dim Pross As Process = New Process

            Pross.StartInfo.FileName = "sqlcmd"
            Pross.StartInfo.Arguments = " -S " & SERVIDOR & " -i " & "CRUD369" & ".txt"
            Pross.Start()
            MessageBox.Show("Proceso ejecutado", "Listo")
        Catch ex As Exception
            MessageBox.Show("Error al ejecutar", "Listo")

        End Try


    End Sub

    Private Sub datalistadoEstructura_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistadoEstructura.CellClick

    End Sub



    Private Sub Temporizador_Tick(sender As Object, e As EventArgs)

    End Sub



    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub datalistado_TABLAS_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistado_TABLAS.CellContentClick

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Clipboard.SetText(txtEditar.Text)

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        InsertarSQLServer()
        Clipboard.SetText(txtEliminar.Text)

    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Clipboard.SetText(txtMostrar.Text)

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        txtCrear_procedimientos.Text = txtEditar.Text
        ejecutar_scryt_crearProcedimientos_almacenados()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        txtCrear_procedimientos.Text = txtMostrar.Text
        ejecutar_scryt_crearProcedimientos_almacenados()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        txtCrear_procedimientos.Text = txtEliminar.Text
        ejecutar_scryt_crearProcedimientos_almacenados()
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Clipboard.SetText(txtMostrar.Text + vbCr + txtInsertarSQLServer.Text + vbCr + txtEditar.Text + vbCr + txtEliminar.Text)
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        InsertarSQLServer()
        txtCrear_procedimientos.Text = txtInsertarSQLServer.Text + vbCr + "GO" + vbCr + txtEditar.Text + vbCr + "GO" + vbCr + txtMostrar.Text + vbCr + "GO" + vbCr + txtEliminar.Text
        ejecutar_scryt_crearProcedimientos_almacenados()
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Buscar_servidores.NIVEL = "CAMBIAR CONEXION"
        Dispose()
        Buscar_servidores.ShowDialog()
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs)
        System.Diagnostics.Process.Start("https://forms.gle/Nn7y85nGPfMNJHff9")

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        'MascaraPrueba.Show()
        MascaraPrueba.Opacity = 50
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Clipboard.SetText(txtMostrarVb.Text)
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Clipboard.SetText(txtInsertarVb.Text)
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Clipboard.SetText(txtEditarVb.Text)
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        mostrar_datagridview_C_sharp()
        Clipboard.SetText(txtMostrarCsharp.Text)

    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        Clipboard.SetText(txtInsertarCsharp.Text)

    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        Clipboard.SetText(txtEditarCsharp.Text)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub
    Dim indicador_de_parametros As String
    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles ConParametrosCsharp.CheckedChanged
        If ConParametrosCsharp.Checked = True Then
            PanelParametros.Visible = True
            indicador_de_parametros = "CSHARP"
            If usuario = "NULO" Then
                Call Me.psEstructura_Tabla(TABLA)
            Else
                Call Me.psEstructura_Tabla_CON_CONTRASEÑA(TABLA)
            End If
            mostrar_datagridview_C_sharp()
        Else
            mostrar_datagridview_C_sharp()
            PanelParametros.Visible = False

        End If
    End Sub

    Private Sub datalistadoEstructuraCONParametros_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistadoEstructuraCONParametros.CellContentClick
        'If e.ColumnIndex = Me.datalistadoEstructuraCONParametros.Columns.Item("Marcar").Index Then
        '    Dim chkcell As DataGridViewCheckBoxCell = Me.datalistadoEstructuraCONParametros.Rows(e.RowIndex).Cells("Eliminar")
        '    chkcell.Value = Not chkcell.Value
        'End If
    End Sub

    Private Sub datalistadoEstructuraCONParametros_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistadoEstructuraCONParametros.CellClick
        Try
            For Each row As DataGridViewRow In datalistadoEstructuraCONParametros.Rows
                If (row.Cells("Marcar").Value = True) Then
                    mostrar_datagridview_C_sharp()
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message & " " & ex.StackTrace)
        End Try



    End Sub

    Private Sub EvitarRepeticionesSQLServer_CheckedChanged(sender As Object, e As EventArgs) Handles EvitarRepeticionesSQLServer.CheckedChanged
        If EvitarRepeticionesSQLServer.Checked = True Then
            lblRepeticionesSQLServer1.Text = "if EXISTS (SELECT * FROM " + TABLA + " Where "
            PanelRepeticiones.Visible = True
        Else
            PanelRepeticiones.Visible = False
        End If
    End Sub
    'PALABRAS CLAVE. SE PODRIA USAR UN ARCHIVO DE TEXTO

    Private Declare Function LockWindowUpdate Lib "user32" (ByVal hWnd As Integer) As Integer 'BLOQUEA AL REPINTADO DEL TEXTO PARA EVITAR PARPADEO
    Sub cambiar_color_rojo_sql()
        Dim i As Integer
        Dim medida_de_texto = CStr(Len(txtErrorSQLServer.Text))
        Dim cadena As String = txtInsertarSQLServer.Text
        For i = 0 To txtInsertarSQLServer.TextLength - 1
            If cadena.Substring(i, 1) = "'" Then
                txtInsertarSQLServer.Select(i, 1)
                txtInsertarSQLServer.SelectionColor = Color.FromArgb(214, 157, 133)
                i = i + 1
            End If
        Next
        For i = 0 To txtInsertarSQLServer.TextLength - medida_de_texto
            If cadena.Substring(i, medida_de_texto) = txtErrorSQLServer.Text Then
                txtInsertarSQLServer.Select(i, medida_de_texto)
                txtInsertarSQLServer.SelectionColor = Color.FromArgb(214, 157, 133)
                i = i + 1
            End If
        Next
    End Sub
    Sub cambiar_color_azules_sql()
        Dim CLAVESAZULES = {"CREATE PROC", "Where", "USE", "GO", "As", "INSERT INTO", "Values", "Else", "RAISERROR", "if", "SELECT", "FROM"}

        Try
            LockWindowUpdate(txtInsertarSQLServer.Handle.ToInt32) 'BLOQUEA AL REPINTADO DEL TEXTO PARA EVITAR PARPADEO

            'PONE TODO EL TEXTO EN EL COLOR POR DEFECTO(FORECOLOR)
            txtInsertarSQLServer.SelectionStart = 0
            txtInsertarSQLServer.SelectionLength = txtInsertarSQLServer.TextLength
            txtInsertarSQLServer.SelectionColor = txtInsertarSQLServer.ForeColor

            For Each CLAVE In CLAVESAZULES 'COMPRUEBA CADA UNA DE LAS PALABRAS CLAVE
                Dim INDEX As Integer = 0 'INICIA LA BUSQUEDA DE LA CLAVE DESDE LA POSICION 0 DEL TEXTO
                While INDEX <= txtInsertarSQLServer.Text.LastIndexOf(CLAVE) 'RECORRE TODO EL TEXTO BUSCANDO LA PALABRA CLAVE
                    txtInsertarSQLServer.Find(CLAVE, INDEX, txtInsertarSQLServer.TextLength, RichTextBoxFinds.WholeWord) 'CUANDO LA ENCUENTRA LA SELECCIONA Y....
                    txtInsertarSQLServer.SelectionColor = Color.FromArgb(80, 156, 210) '... LE PONE EL COLOR INDICADO
                    INDEX = txtInsertarSQLServer.Text.IndexOf(CLAVE, INDEX) + 1 'AVANZA A LA SIGUIENTE UBICACION DE LA PALABRA CLAVE
                End While
            Next

            'CUANDO HA TERMINADO DE BUSCAR TODAS LAS PALABRAS VUELVE A LA SITUACION NORMAL (AL FINAL DEL TEXTO)
            txtInsertarSQLServer.SelectionStart = txtInsertarSQLServer.TextLength
            txtInsertarSQLServer.SelectionColor = txtInsertarSQLServer.ForeColor

            LockWindowUpdate(0) 'DESBLOQUEA EL REPINTADO DEL TEXTO Y PERMITE VER LOS COLORES APLICADOS

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        For Each row As DataGridViewRow In datalistadoEstructura.Rows
            Dim tipo As String = Convert.ToString(row.Cells("Parametros").Value)
            ComboBox1.Items.Add(tipo)
        Next


    End Sub

    Private Sub txtInsertar_TextChanged(sender As Object, e As EventArgs) Handles txtInsertarSQLServer.TextChanged
        'If Me.txtInsertar.TextLength >= 10 Then
        '    Me.txtInsertar.Select()
        '    Me.txtInsertar.SelectionColor = Color.Blue
        'Else
        '    Me.txtInsertar.Select()
        '    Me.txtInsertar.SelectionColor = Color.Red
        'End If

    End Sub



    Private Sub ToolStripButton2_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        InsertarSQLServer()
        Clipboard.SetText(txtInsertarSQLServer.Text)
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        InsertarSQLServer()
        txtCrear_procedimientos.Text = txtInsertarSQLServer.Text
        ejecutar_scryt_crearProcedimientos_almacenados()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles TSQLver.Click
        InsertarSQLServer()
        cambiar_color_azules_sql()
        cambiar_color_rojo_sql()
        PanelVerInsertarSQLserver.Visible = True
        PanelVerInsertarSQLserver.Dock = DockStyle.Fill
        TSQLver.Visible = False
        TSQLvolver.Visible = True

    End Sub

    Private Sub TSQLvolver_Click(sender As Object, e As EventArgs) Handles TSQLvolver.Click
        PanelVerInsertarSQLserver.Visible = False
        PanelVerInsertarSQLserver.Dock = DockStyle.None
        TSQLver.Visible = True
        TSQLvolver.Visible = False

    End Sub



    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        lblRepeticionesSQLServer2.Text = lblRepeticionesSQLServer2.Text.Replace("#", ComboBox1.Text)
        ComboBox1.Visible = False
        lblRepeticionesSQLServer2.Focus()


    End Sub
    Dim CLAVES = {"and", "AND", "And", "Or", "or", "OR"}
    Private Sub lblRepeticionesSQLServer2_TextChanged(sender As Object, e As EventArgs) Handles lblRepeticionesSQLServer2.TextChanged
        'txtRuta.Text = FolderBrowserDialog1.SelectedPath
        Dim texto As String = lblRepeticionesSQLServer2.Text
        If (texto.Contains("#")) Then
            For Each row As DataGridViewRow In datalistadoEstructura.Rows
                Dim tipo As String = Convert.ToString(row.Cells("Parametros").Value)
                ComboBox1.Items.Add(tipo)
            Next
            ComboBox1.Visible = True
        Else
            'txtRuta.Text = FolderBrowserDialog1.SelectedPath

        End If

        Try

            'LockWindowUpdate(lblRepeticionesSQLServer2.Handle.ToInt32) 'BLOQUEA AL REPINTADO DEL TEXTO PARA EVITAR PARPADEO

            'PONE TODO EL TEXTO EN EL COLOR POR DEFECTO(FORECOLOR)
            lblRepeticionesSQLServer2.SelectionStart = 0
            lblRepeticionesSQLServer2.SelectionLength = lblRepeticionesSQLServer2.TextLength
            lblRepeticionesSQLServer2.SelectionColor = lblRepeticionesSQLServer2.ForeColor

            For Each CLAVE In CLAVES 'COMPRUEBA CADA UNA DE LAS PALABRAS CLAVE

                Dim INDEX As Integer = 0 'INICIA LA BUSQUEDA DE LA CLAVE DESDE LA POSICION 0 DEL TEXTO

                While INDEX <= lblRepeticionesSQLServer2.Text.LastIndexOf(CLAVE) 'RECORRE TODO EL TEXTO BUSCANDO LA PALABRA CLAVE

                    lblRepeticionesSQLServer2.Find(CLAVE, INDEX, lblRepeticionesSQLServer2.TextLength, RichTextBoxFinds.WholeWord) 'CUANDO LA ENCUENTRA LA SELECCIONA Y....
                    lblRepeticionesSQLServer2.SelectionColor = Color.Cyan   '... LE PONE EL COLOR INDICADO
                    INDEX = lblRepeticionesSQLServer2.Text.IndexOf(CLAVE, INDEX) + 1 'AVANZA A LA SIGUIENTE UBICACION DE LA PALABRA CLAVE

                End While
            Next

            'CUANDO HA TERMINADO DE BUSCAR TODAS LAS PALABRAS VUELVE A LA SITUACION NORMAL (AL FINAL DEL TEXTO)
            lblRepeticionesSQLServer2.SelectionStart = lblRepeticionesSQLServer2.TextLength
            lblRepeticionesSQLServer2.SelectionColor = lblRepeticionesSQLServer2.ForeColor

            LockWindowUpdate(0) 'DESBLOQUEA EL REPINTADO DEL TEXTO Y PERMITE VER LOS COLORES APLICADOS

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub btnRestaurar_Click(sender As Object, e As EventArgs)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.WindowState = FormWindowState.Normal
        btnRestaurar.Visible = False
        btnMaximizar.Visible = True
        Me.FormBorderStyle = FormBorderStyle.None

    End Sub

    Private Sub btnMaximizar_Click(sender As Object, e As EventArgs)

        Me.FormBorderStyle = FormBorderStyle.FixedDialog


        btnMaximizar.Visible = False
        btnRestaurar.Visible = True
        Me.WindowState = FormWindowState.Maximized
        Me.FormBorderStyle = FormBorderStyle.None
    End Sub

    Private Sub btnMinimizar_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Panel28_Paint(sender As Object, e As PaintEventArgs) Handles Panel28.Paint

    End Sub

    Private Sub Panel28_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel28.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
    Sub maximizar()
        Me.FormBorderStyle = FormBorderStyle.FixedDialog


        btnMaximizar.Visible = False
        btnRestaurar.Visible = True
        Me.WindowState = FormWindowState.Maximized
        Me.FormBorderStyle = FormBorderStyle.None
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles btnMaximizar.Click
        maximizar()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles btnRestaurar.Click
        restaurar()
    End Sub
    Sub restaurar()
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.WindowState = FormWindowState.Normal
        btnRestaurar.Visible = False
        btnMaximizar.Visible = True
        Me.FormBorderStyle = FormBorderStyle.None
    End Sub
    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        System.Diagnostics.Process.Start("https://forms.gle/Nn7y85nGPfMNJHff9")

    End Sub

    Private Sub Panel29_Paint(sender As Object, e As PaintEventArgs) Handles Panel29.Paint

    End Sub

    Private Sub Panel29_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel29.MouseMove
        mover()
    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click

    End Sub

    Private Sub Label20_MouseMove(sender As Object, e As MouseEventArgs) Handles Label20.MouseMove
        mover()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        En_construccion.ShowDialog()
    End Sub

    Private Sub AcercaDeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDeToolStripMenuItem.Click
        Acerca_de.ShowDialog()


    End Sub

    Private Sub PanelCsharp_Paint(sender As Object, e As PaintEventArgs) Handles PanelCsharp.Paint

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        En_construccion.ShowDialog()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        En_construccion.ShowDialog()
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        En_construccion.ShowDialog()
    End Sub

    Private Sub Panel35_Paint(sender As Object, e As PaintEventArgs) Handles Panel35.Paint

    End Sub
    Sub mover()
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
        'restaurar()
    End Sub
    Private Sub Panel35_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel35.MouseMove
        mover()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        System.Diagnostics.Process.Start("https://www.udemy.com/course/professional-sales-system-in-c-and-sqlserver/?couponCode=F9CD76AF37D1FA2E7B2D")

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        End
    End Sub

    Private Sub Panel26_Paint(sender As Object, e As PaintEventArgs) Handles Panel26.Paint

    End Sub

    Private Sub Panel35_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel35.MouseClick
        ''restaurar()
    End Sub
End Class