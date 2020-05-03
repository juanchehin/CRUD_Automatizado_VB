Imports System.Data.SqlClient
Imports System.Data

Imports System.Configuration
Imports System.Xml
Public Class Buscar_servidores
    Private aes As New AES()
    Dim usuario As String
    Dim bases() As String
    Dim dt As New DataTable
    Dim contraseña As String
    Dim servidor As String
    Public NIVEL As String
    Dim contador As Integer
    Dim dbcnString As String
    Private Sub Buscar_servidores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        panelBuscandoServidor.Location = New Point((Width - panelBuscandoServidor.Width) / 2, (Height - panelBuscandoServidor.Height) / 2)
        PanelSinServidor.Location = New Point((Width - PanelSinServidor.Width) / 2, (Height - PanelSinServidor.Height) / 2)
        Timer1.Start()
    End Sub
    Sub comprobar_conexion_con_usuario()
        basesDeDatosCONTRASEÑA(servidor)

        Try
            With ComboBox1
                .DataSource = dt
                .DisplayMember = "name"
            End With

        Catch ex As Exception

        End Try
        If ComboBox1.Text <> "" Then
            saveInstancia(aes.Encrypt(txtinstancia.Text.Trim, appPwdUnique, Integer.Parse("256")))
            saveusuario(aes.Encrypt(txtusuario.Text.Trim, appPwdUnique, Integer.Parse("256")))
            savecontraseña(aes.Encrypt(txtcontraseña.Text.Trim, appPwdUnique, Integer.Parse("256")))
            Dispose()
            Generador_UI.ShowDialog()

        Else
            panelBuscandoServidor.Visible = False
            PanelSinServidor.Visible = True
        End If

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
    Public Sub saveInstancia(ByVal dbcnString)
        Dim doc As XmlDocument = New XmlDocument()
        doc.Load("ConnectionString.xml")
        Dim root As XmlElement = doc.DocumentElement
        root.Attributes.Item(0).Value = dbcnString
        Dim writer As XmlTextWriter = New XmlTextWriter("ConnectionString.xml", Nothing)
        writer.Formatting = Formatting.Indented
        doc.Save(writer)
        writer.Close()
    End Sub
    Public Sub saveusuario(ByVal dbcnString)
        Dim doc As XmlDocument = New XmlDocument()
        doc.Load("usuario.xml")
        Dim root As XmlElement = doc.DocumentElement
        root.Attributes.Item(0).Value = dbcnString
        Dim writer As XmlTextWriter = New XmlTextWriter("usuario.xml", Nothing)
        writer.Formatting = Formatting.Indented
        doc.Save(writer)
        writer.Close()
    End Sub
    Public Sub savecontraseña(ByVal dbcnString)
        Dim doc As XmlDocument = New XmlDocument()
        doc.Load("contraseña.xml")
        Dim root As XmlElement = doc.DocumentElement
        root.Attributes.Item(0).Value = dbcnString
        Dim writer As XmlTextWriter = New XmlTextWriter("contraseña.xml", Nothing)
        writer.Formatting = Formatting.Indented
        doc.Save(writer)
        writer.Close()
    End Sub

    Private Function basesDeDatosCONTRASEÑA(ByVal instancia As String) As String()

        Dim basesSys() As String = {"master", "model", "msdb", "tempdb"}

        Dim sCnn As String = "Server=" & instancia & "; " &
            "database=master; integrated security=false; User=" & txtusuario.Text & "; password=" & txtcontraseña.Text


        Dim sel As String = "SELECT name FROM sysdatabases"
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
        Catch ex As Exception


        End Try
        Return Nothing

    End Function

    Private Function basesDeDatos(ByVal instancia As String) As String()
        Dim basesSys() As String = {"master", "model", "msdb", "tempdb"}
        Dim sCnn As String = "Server=" & instancia & "; " &
            "database=master; integrated security=yes"

        Dim sel As String = "SELECT name FROM sysdatabases"
        Try
            Dim da As New SqlDataAdapter(sel, sCnn)
            da.Fill(dt)
            ReDim bases(dt.Rows.Count - 1)
            Dim k As Integer = -1
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim s As String = dt.Rows(i).Item("name").ToString()
                If Array.IndexOf(basesSys, s) = -1 Then
                    k += 1
                    bases(k) = s
                End If
            Next

            If k = -1 Then Return Nothing
            ReDim Preserve bases(k)
            Return bases
        Catch ex As Exception

        End Try
        Return Nothing

    End Function

    Private Sub BunifuThinButton25_Click(sender As Object, e As EventArgs)




    End Sub
    Sub comprobar_conexion_sin_usuario_Y_CUANDO_YA_ESTA_GUARDADA_LA_CONEXION()
        basesDeDatos(servidor)
        Try
            With ComboBox1
                .DataSource = dt
                .DisplayMember = "name"
            End With

        Catch ex As Exception

        End Try
        If ComboBox1.Text <> "" Then
            Try
                saveInstancia(aes.Encrypt(servidor, appPwdUnique, Integer.Parse("256")))
                saveusuario(aes.Encrypt("NULO", appPwdUnique, Integer.Parse("256")))
                savecontraseña(aes.Encrypt("NULO", appPwdUnique, Integer.Parse("256")))
                Dispose()
                Generador_UI.ShowDialog()
            Catch ex As Exception

            End Try

        End If
    End Sub
    Sub comprobar_conexion__sin_usuario_y_si_aun_no_se_guarda_la_conexion()
        Dim servidorsql As String
        servidorsql = ".\SQLEXPRESS"
        basesDeDatos(servidorsql)

        Try
                With ComboBox1
                    .DataSource = dt
                    .DisplayMember = "name"
                End With

            Catch ex As Exception

            End Try
            If ComboBox1.Text <> "" Then
                Try
                    saveInstancia(aes.Encrypt(servidorsql, appPwdUnique, Integer.Parse("256")))
                    saveusuario(aes.Encrypt("NULO", appPwdUnique, Integer.Parse("256")))
                    savecontraseña(aes.Encrypt("NULO", appPwdUnique, Integer.Parse("256")))
                    Dispose()
                    Generador_UI.ShowDialog()
                Catch ex As Exception

                End Try
            Else

            servidorsql = "."
            basesDeDatos(servidorsql)
            Try
                With ComboBox1
                    .DataSource = dt
                    .DisplayMember = "name"
                End With

            Catch ex As Exception

            End Try
            If ComboBox1.Text <> "" Then
                Try
                    saveInstancia(aes.Encrypt(servidorsql, appPwdUnique, Integer.Parse("256")))
                    saveusuario(aes.Encrypt("NULO", appPwdUnique, Integer.Parse("256")))
                    savecontraseña(aes.Encrypt("NULO", appPwdUnique, Integer.Parse("256")))
                    Dispose()
                    Generador_UI.ShowDialog()
                Catch ex As Exception

                End Try
            Else
                panelBuscandoServidor.Visible = False
                PanelSinServidor.Visible = True
            End If

        End If


    End Sub

    Sub comprobar_conexion_estable()


        If usuario = "NULO" Then

            If ComboBox1.Text = "" Then
                    basesDeDatos(".\SQLEXPRESS")
                    Try
                        With ComboBox1
                            .DataSource = dt
                            .DisplayMember = "name"
                        End With
                    Catch ex As Exception
                    End Try
                    If ComboBox1.Text <> "" Then
                        saveInstancia(aes.Encrypt(".\SQLEXPRESS", appPwdUnique, Integer.Parse("256")))
                        saveusuario(aes.Encrypt("NULO", appPwdUnique, Integer.Parse("256")))
                        savecontraseña(aes.Encrypt("NULO", appPwdUnique, Integer.Parse("256")))
                        Dispose()
                        Generador_UI.ShowDialog()
                    Else
                        basesDeDatos(".\SQLEXPRESS3")
                        Try
                            With ComboBox1
                                .DataSource = dt
                                .DisplayMember = "name"
                            End With

                        Catch ex As Exception

                        End Try
                        If ComboBox1.Text <> "" Then
                            saveInstancia(aes.Encrypt(".\SQLEXPRESS", appPwdUnique, Integer.Parse("256")))
                            saveusuario(aes.Encrypt("NULO", appPwdUnique, Integer.Parse("256")))
                            savecontraseña(aes.Encrypt("NULO", appPwdUnique, Integer.Parse("256")))
                            Dispose()
                            Generador_UI.ShowDialog()
                        Else
                            panelBuscandoServidor.Visible = False
                            PanelSinServidor.Visible = True
                        End If

                    End If
                End If





            Else


                basesDeDatosCONTRASEÑA(servidor)
                Try
                    With ComboBox1
                        .DataSource = dt
                        .DisplayMember = "name"
                    End With
                Catch ex As Exception
                End Try
                If ComboBox1.Text <> "" Then
                    Dispose()
                    Generador_UI.ShowDialog()
                Else
                    PanelSinServidor.Visible = True
                    panelBuscandoServidor.Visible = False
                    MessageBox.Show("Sin conexion", "Conexion Fallida")
                End If

            End If





    End Sub
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
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Buscar_servidores_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        basesDeDatosCONTRASEÑA(txtinstancia.Text.Trim)

        Try
            With ComboBox1
                .DataSource = dt
                .DisplayMember = "name"
            End With

        Catch ex As Exception

        End Try
        If ComboBox1.Text <> "" Then
            saveInstancia(aes.Encrypt(txtinstancia.Text.Trim, appPwdUnique, Integer.Parse("256")))
            saveusuario(aes.Encrypt(txtusuario.Text.Trim, appPwdUnique, Integer.Parse("256")))
            savecontraseña(aes.Encrypt(txtcontraseña.Text.Trim, appPwdUnique, Integer.Parse("256")))
            Dispose()
            Generador_UI.ShowDialog()

        Else
            MessageBox.Show("Sin conexion", "Conexion Fallida")
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        contador += 1
        If contador = 40 Then
            Timer1.Stop()
            comprobar_conexiones()
        End If
    End Sub
    Sub comprobar_conexiones()
        If NIVEL = "" Then
            ReadfromXMLcontraseña()
            ReadfromXMLinstancia()
            ReadfromXMLusuario()

            If usuario = "NULO" Then
                comprobar_conexion_sin_usuario_Y_CUANDO_YA_ESTA_GUARDADA_LA_CONEXION()
                If ComboBox1.Text = "" Then
                    comprobar_conexion__sin_usuario_y_si_aun_no_se_guarda_la_conexion()
                End If
            Else
                comprobar_conexion__sin_usuario_y_si_aun_no_se_guarda_la_conexion()
                panelBuscandoServidor.Visible = True
                PanelSinServidor.Visible = False
                If ComboBox1.Text = "" Then
                    txtcontraseña.Text = contraseña
                    txtusuario.Text = usuario
                    comprobar_conexion_con_usuario()
                End If

            End If
        Else

            ReadfromXMLcontraseña()
            ReadfromXMLinstancia()
            ReadfromXMLusuario()
            panelBuscandoServidor.Visible = False
            'PanelSinServidor.Location = New Point((Width - PanelSinServidor.Width) / 2, (Height - PanelSinServidor.Height) / 2)
            PanelSinServidor.Visible = True
        End If

    End Sub
End Class