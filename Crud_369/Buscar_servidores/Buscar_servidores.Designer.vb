<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Buscar_servidores
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Buscar_servidores))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PanelSinServidor = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.txtcontraseña = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtusuario = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtinstancia = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panelBuscandoServidor = New System.Windows.Forms.Panel()
        Me.estado_conexion = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.estado_conexionNOEXPRESS = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelSinServidor.SuspendLayout()
        Me.panelBuscandoServidor.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(131, 140)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'PanelSinServidor
        '
        Me.PanelSinServidor.Controls.Add(Me.Button1)
        Me.PanelSinServidor.Controls.Add(Me.Panel4)
        Me.PanelSinServidor.Controls.Add(Me.txtcontraseña)
        Me.PanelSinServidor.Controls.Add(Me.Label5)
        Me.PanelSinServidor.Controls.Add(Me.Panel3)
        Me.PanelSinServidor.Controls.Add(Me.txtusuario)
        Me.PanelSinServidor.Controls.Add(Me.Label4)
        Me.PanelSinServidor.Controls.Add(Me.Panel2)
        Me.PanelSinServidor.Controls.Add(Me.txtinstancia)
        Me.PanelSinServidor.Controls.Add(Me.Label3)
        Me.PanelSinServidor.Controls.Add(Me.Label2)
        Me.PanelSinServidor.Controls.Add(Me.Label1)
        Me.PanelSinServidor.Location = New System.Drawing.Point(78, 337)
        Me.PanelSinServidor.Name = "PanelSinServidor"
        Me.PanelSinServidor.Size = New System.Drawing.Size(673, 420)
        Me.PanelSinServidor.TabIndex = 18
        Me.PanelSinServidor.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(239, 334)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(254, 47)
        Me.Button1.TabIndex = 23
        Me.Button1.Text = "Conectar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Silver
        Me.Panel4.Location = New System.Drawing.Point(238, 318)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(242, 1)
        Me.Panel4.TabIndex = 22
        '
        'txtcontraseña
        '
        Me.txtcontraseña.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtcontraseña.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtcontraseña.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.txtcontraseña.ForeColor = System.Drawing.Color.White
        Me.txtcontraseña.Location = New System.Drawing.Point(239, 289)
        Me.txtcontraseña.Name = "txtcontraseña"
        Me.txtcontraseña.Size = New System.Drawing.Size(241, 22)
        Me.txtcontraseña.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.Label5.Location = New System.Drawing.Point(122, 287)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 24)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Contraseña:"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Silver
        Me.Panel3.Location = New System.Drawing.Point(238, 274)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(242, 1)
        Me.Panel3.TabIndex = 19
        '
        'txtusuario
        '
        Me.txtusuario.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtusuario.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtusuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.txtusuario.ForeColor = System.Drawing.Color.White
        Me.txtusuario.Location = New System.Drawing.Point(239, 245)
        Me.txtusuario.Name = "txtusuario"
        Me.txtusuario.Size = New System.Drawing.Size(241, 22)
        Me.txtusuario.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.Label4.Location = New System.Drawing.Point(154, 245)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 24)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Usuario:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Silver
        Me.Panel2.Location = New System.Drawing.Point(238, 232)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(242, 1)
        Me.Panel2.TabIndex = 16
        '
        'txtinstancia
        '
        Me.txtinstancia.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtinstancia.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtinstancia.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.txtinstancia.ForeColor = System.Drawing.Color.White
        Me.txtinstancia.Location = New System.Drawing.Point(239, 203)
        Me.txtinstancia.Name = "txtinstancia"
        Me.txtinstancia.Size = New System.Drawing.Size(241, 22)
        Me.txtinstancia.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.Label3.Location = New System.Drawing.Point(148, 201)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 24)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Servidor:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Consolas", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.DarkGray
        Me.Label2.Location = New System.Drawing.Point(0, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(673, 53)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Ingrese los datos Manualmente"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Consolas", 40.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(673, 135)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Servidor"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelBuscandoServidor
        '
        Me.panelBuscandoServidor.Controls.Add(Me.estado_conexion)
        Me.panelBuscandoServidor.Location = New System.Drawing.Point(78, 178)
        Me.panelBuscandoServidor.Name = "panelBuscandoServidor"
        Me.panelBuscandoServidor.Size = New System.Drawing.Size(612, 153)
        Me.panelBuscandoServidor.TabIndex = 19
        '
        'estado_conexion
        '
        Me.estado_conexion.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.estado_conexion.Dock = System.Windows.Forms.DockStyle.Top
        Me.estado_conexion.Font = New System.Drawing.Font("Consolas", 40.0!, System.Drawing.FontStyle.Bold)
        Me.estado_conexion.ForeColor = System.Drawing.Color.White
        Me.estado_conexion.Location = New System.Drawing.Point(0, 0)
        Me.estado_conexion.Name = "estado_conexion"
        Me.estado_conexion.Size = New System.Drawing.Size(612, 139)
        Me.estado_conexion.TabIndex = 13
        Me.estado_conexion.Text = "Buscando Servidor"
        Me.estado_conexion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Consolas", 16.0!)
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(49, 28)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(259, 32)
        Me.ComboBox1.TabIndex = 20
        '
        'estado_conexionNOEXPRESS
        '
        Me.estado_conexionNOEXPRESS.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.estado_conexionNOEXPRESS.Font = New System.Drawing.Font("Consolas", 40.0!, System.Drawing.FontStyle.Bold)
        Me.estado_conexionNOEXPRESS.ForeColor = System.Drawing.Color.White
        Me.estado_conexionNOEXPRESS.Location = New System.Drawing.Point(361, 29)
        Me.estado_conexionNOEXPRESS.Name = "estado_conexionNOEXPRESS"
        Me.estado_conexionNOEXPRESS.Size = New System.Drawing.Size(612, 31)
        Me.estado_conexionNOEXPRESS.TabIndex = 21
        Me.estado_conexionNOEXPRESS.Text = "Buscando Servidor"
        Me.estado_conexionNOEXPRESS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Controls.Add(Me.estado_conexionNOEXPRESS)
        Me.Panel1.Location = New System.Drawing.Point(188, 14)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(10, 10)
        Me.Panel1.TabIndex = 22
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(41, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "usuario"
        '
        'Timer1
        '
        Me.Timer1.Interval = 10
        '
        'Buscar_servidores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1004, 700)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.panelBuscandoServidor)
        Me.Controls.Add(Me.PanelSinServidor)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Buscar_servidores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelSinServidor.ResumeLayout(False)
        Me.PanelSinServidor.PerformLayout()
        Me.panelBuscandoServidor.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PanelSinServidor As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents panelBuscandoServidor As Panel
    Friend WithEvents estado_conexion As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents estado_conexionNOEXPRESS As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents txtcontraseña As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtusuario As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtinstancia As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Timer1 As Timer
End Class
