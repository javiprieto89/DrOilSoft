<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class config
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
        Me.tctrl = New System.Windows.Forms.TabControl()
        Me.tconfrgl = New System.Windows.Forms.TabPage()
        Me.gb_pager = New System.Windows.Forms.GroupBox()
        Me.txt_itPerPage = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdb_coma = New System.Windows.Forms.RadioButton()
        Me.rdb_punto = New System.Windows.Forms.RadioButton()
        Me.lbl_decimal = New System.Windows.Forms.Label()
        Me.tpedidos = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbl_pclientes = New System.Windows.Forms.Label()
        Me.cmb_clientes = New System.Windows.Forms.ComboBox()
        Me.chk_cliente = New System.Windows.Forms.CheckBox()
        Me.tBackup = New System.Windows.Forms.TabPage()
        Me.lbl_nombreBackup = New System.Windows.Forms.Label()
        Me.txt_nombreBackup = New System.Windows.Forms.TextBox()
        Me.cmd_abrirCarpeta = New System.Windows.Forms.Button()
        Me.cmd_elegirRuta = New System.Windows.Forms.Button()
        Me.txt_rutaBackup = New System.Windows.Forms.TextBox()
        Me.lbl_ruta = New System.Windows.Forms.Label()
        Me.tsql = New System.Windows.Forms.TabPage()
        Me.txtserver = New System.Windows.Forms.TextBox()
        Me.txtuser = New System.Windows.Forms.TextBox()
        Me.txtpassword = New System.Windows.Forms.TextBox()
        Me.lblpassword = New System.Windows.Forms.Label()
        Me.txtdb = New System.Windows.Forms.TextBox()
        Me.lblruta = New System.Windows.Forms.Label()
        Me.lblusuario = New System.Windows.Forms.Label()
        Me.lbldb = New System.Windows.Forms.Label()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.tctrl.SuspendLayout()
        Me.tconfrgl.SuspendLayout()
        Me.gb_pager.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tpedidos.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tBackup.SuspendLayout()
        Me.tsql.SuspendLayout()
        Me.SuspendLayout()
        '
        'tctrl
        '
        Me.tctrl.Controls.Add(Me.tconfrgl)
        Me.tctrl.Controls.Add(Me.tpedidos)
        Me.tctrl.Controls.Add(Me.tBackup)
        Me.tctrl.Controls.Add(Me.tsql)
        Me.tctrl.Location = New System.Drawing.Point(9, 22)
        Me.tctrl.Margin = New System.Windows.Forms.Padding(2)
        Me.tctrl.Name = "tctrl"
        Me.tctrl.SelectedIndex = 0
        Me.tctrl.Size = New System.Drawing.Size(816, 447)
        Me.tctrl.TabIndex = 6
        '
        'tconfrgl
        '
        Me.tconfrgl.BackColor = System.Drawing.SystemColors.Control
        Me.tconfrgl.Controls.Add(Me.gb_pager)
        Me.tconfrgl.Controls.Add(Me.GroupBox1)
        Me.tconfrgl.Location = New System.Drawing.Point(4, 22)
        Me.tconfrgl.Margin = New System.Windows.Forms.Padding(2)
        Me.tconfrgl.Name = "tconfrgl"
        Me.tconfrgl.Padding = New System.Windows.Forms.Padding(2)
        Me.tconfrgl.Size = New System.Drawing.Size(808, 421)
        Me.tconfrgl.TabIndex = 0
        Me.tconfrgl.Text = "Miscelaneas"
        '
        'gb_pager
        '
        Me.gb_pager.Controls.Add(Me.txt_itPerPage)
        Me.gb_pager.Controls.Add(Me.Label1)
        Me.gb_pager.Location = New System.Drawing.Point(19, 146)
        Me.gb_pager.Margin = New System.Windows.Forms.Padding(2)
        Me.gb_pager.Name = "gb_pager"
        Me.gb_pager.Padding = New System.Windows.Forms.Padding(2)
        Me.gb_pager.Size = New System.Drawing.Size(756, 61)
        Me.gb_pager.TabIndex = 1
        Me.gb_pager.TabStop = False
        Me.gb_pager.Text = "Paginador"
        '
        'txt_itPerPage
        '
        Me.txt_itPerPage.Location = New System.Drawing.Point(173, 25)
        Me.txt_itPerPage.Name = "txt_itPerPage"
        Me.txt_itPerPage.Size = New System.Drawing.Size(132, 20)
        Me.txt_itPerPage.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 28)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cantidad de items por página"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdb_coma)
        Me.GroupBox1.Controls.Add(Me.rdb_punto)
        Me.GroupBox1.Controls.Add(Me.lbl_decimal)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 16)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(756, 106)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Configuración regional"
        '
        'rdb_coma
        '
        Me.rdb_coma.AutoSize = True
        Me.rdb_coma.Enabled = False
        Me.rdb_coma.Location = New System.Drawing.Point(41, 76)
        Me.rdb_coma.Margin = New System.Windows.Forms.Padding(2)
        Me.rdb_coma.Name = "rdb_coma"
        Me.rdb_coma.Size = New System.Drawing.Size(52, 17)
        Me.rdb_coma.TabIndex = 2
        Me.rdb_coma.Text = "Coma"
        Me.rdb_coma.UseVisualStyleBackColor = True
        '
        'rdb_punto
        '
        Me.rdb_punto.AutoSize = True
        Me.rdb_punto.Checked = True
        Me.rdb_punto.Location = New System.Drawing.Point(41, 54)
        Me.rdb_punto.Margin = New System.Windows.Forms.Padding(2)
        Me.rdb_punto.Name = "rdb_punto"
        Me.rdb_punto.Size = New System.Drawing.Size(53, 17)
        Me.rdb_punto.TabIndex = 1
        Me.rdb_punto.TabStop = True
        Me.rdb_punto.Text = "Punto"
        Me.rdb_punto.UseVisualStyleBackColor = True
        '
        'lbl_decimal
        '
        Me.lbl_decimal.AutoSize = True
        Me.lbl_decimal.Location = New System.Drawing.Point(24, 28)
        Me.lbl_decimal.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_decimal.Name = "lbl_decimal"
        Me.lbl_decimal.Size = New System.Drawing.Size(95, 13)
        Me.lbl_decimal.TabIndex = 0
        Me.lbl_decimal.Text = "Separador decimal"
        '
        'tpedidos
        '
        Me.tpedidos.BackColor = System.Drawing.SystemColors.Control
        Me.tpedidos.Controls.Add(Me.GroupBox2)
        Me.tpedidos.Location = New System.Drawing.Point(4, 22)
        Me.tpedidos.Margin = New System.Windows.Forms.Padding(2)
        Me.tpedidos.Name = "tpedidos"
        Me.tpedidos.Padding = New System.Windows.Forms.Padding(2)
        Me.tpedidos.Size = New System.Drawing.Size(808, 421)
        Me.tpedidos.TabIndex = 1
        Me.tpedidos.Text = "Pedidos"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_pclientes)
        Me.GroupBox2.Controls.Add(Me.cmb_clientes)
        Me.GroupBox2.Controls.Add(Me.chk_cliente)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(14, 14)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(756, 106)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cliente predeterminado en pedidos"
        '
        'lbl_pclientes
        '
        Me.lbl_pclientes.AutoSize = True
        Me.lbl_pclientes.Location = New System.Drawing.Point(17, 58)
        Me.lbl_pclientes.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_pclientes.Name = "lbl_pclientes"
        Me.lbl_pclientes.Size = New System.Drawing.Size(39, 13)
        Me.lbl_pclientes.TabIndex = 2
        Me.lbl_pclientes.Text = "Cliente"
        '
        'cmb_clientes
        '
        Me.cmb_clientes.FormattingEnabled = True
        Me.cmb_clientes.Location = New System.Drawing.Point(60, 58)
        Me.cmb_clientes.Margin = New System.Windows.Forms.Padding(2)
        Me.cmb_clientes.Name = "cmb_clientes"
        Me.cmb_clientes.Size = New System.Drawing.Size(269, 21)
        Me.cmb_clientes.TabIndex = 1
        '
        'chk_cliente
        '
        Me.chk_cliente.AutoSize = True
        Me.chk_cliente.Location = New System.Drawing.Point(20, 30)
        Me.chk_cliente.Margin = New System.Windows.Forms.Padding(2)
        Me.chk_cliente.Name = "chk_cliente"
        Me.chk_cliente.Size = New System.Drawing.Size(158, 17)
        Me.chk_cliente.TabIndex = 0
        Me.chk_cliente.Text = "Usar cliente predeterminado"
        Me.chk_cliente.UseVisualStyleBackColor = True
        '
        'tBackup
        '
        Me.tBackup.BackColor = System.Drawing.SystemColors.Control
        Me.tBackup.Controls.Add(Me.lbl_nombreBackup)
        Me.tBackup.Controls.Add(Me.txt_nombreBackup)
        Me.tBackup.Controls.Add(Me.cmd_abrirCarpeta)
        Me.tBackup.Controls.Add(Me.cmd_elegirRuta)
        Me.tBackup.Controls.Add(Me.txt_rutaBackup)
        Me.tBackup.Controls.Add(Me.lbl_ruta)
        Me.tBackup.Location = New System.Drawing.Point(4, 22)
        Me.tBackup.Margin = New System.Windows.Forms.Padding(2)
        Me.tBackup.Name = "tBackup"
        Me.tBackup.Size = New System.Drawing.Size(808, 421)
        Me.tBackup.TabIndex = 2
        Me.tBackup.Text = "Backup"
        '
        'lbl_nombreBackup
        '
        Me.lbl_nombreBackup.AutoSize = True
        Me.lbl_nombreBackup.Enabled = False
        Me.lbl_nombreBackup.Location = New System.Drawing.Point(25, 61)
        Me.lbl_nombreBackup.Name = "lbl_nombreBackup"
        Me.lbl_nombreBackup.Size = New System.Drawing.Size(155, 13)
        Me.lbl_nombreBackup.TabIndex = 7
        Me.lbl_nombreBackup.Text = "Nombre del archivo del backup"
        '
        'txt_nombreBackup
        '
        Me.txt_nombreBackup.Enabled = False
        Me.txt_nombreBackup.Location = New System.Drawing.Point(215, 58)
        Me.txt_nombreBackup.Name = "txt_nombreBackup"
        Me.txt_nombreBackup.Size = New System.Drawing.Size(248, 20)
        Me.txt_nombreBackup.TabIndex = 6
        '
        'cmd_abrirCarpeta
        '
        Me.cmd_abrirCarpeta.Enabled = False
        Me.cmd_abrirCarpeta.Location = New System.Drawing.Point(565, 17)
        Me.cmd_abrirCarpeta.Margin = New System.Windows.Forms.Padding(2)
        Me.cmd_abrirCarpeta.Name = "cmd_abrirCarpeta"
        Me.cmd_abrirCarpeta.Size = New System.Drawing.Size(84, 21)
        Me.cmd_abrirCarpeta.TabIndex = 5
        Me.cmd_abrirCarpeta.Text = "Abrir carpeta actual"
        Me.cmd_abrirCarpeta.UseVisualStyleBackColor = True
        '
        'cmd_elegirRuta
        '
        Me.cmd_elegirRuta.Enabled = False
        Me.cmd_elegirRuta.Location = New System.Drawing.Point(477, 17)
        Me.cmd_elegirRuta.Margin = New System.Windows.Forms.Padding(2)
        Me.cmd_elegirRuta.Name = "cmd_elegirRuta"
        Me.cmd_elegirRuta.Size = New System.Drawing.Size(84, 21)
        Me.cmd_elegirRuta.TabIndex = 2
        Me.cmd_elegirRuta.Text = "Elegir carpeta"
        Me.cmd_elegirRuta.UseVisualStyleBackColor = True
        '
        'txt_rutaBackup
        '
        Me.txt_rutaBackup.Enabled = False
        Me.txt_rutaBackup.Location = New System.Drawing.Point(215, 18)
        Me.txt_rutaBackup.Name = "txt_rutaBackup"
        Me.txt_rutaBackup.Size = New System.Drawing.Size(248, 20)
        Me.txt_rutaBackup.TabIndex = 1
        '
        'lbl_ruta
        '
        Me.lbl_ruta.AutoSize = True
        Me.lbl_ruta.Enabled = False
        Me.lbl_ruta.Location = New System.Drawing.Point(25, 25)
        Me.lbl_ruta.Name = "lbl_ruta"
        Me.lbl_ruta.Size = New System.Drawing.Size(176, 13)
        Me.lbl_ruta.TabIndex = 0
        Me.lbl_ruta.Text = "Ruta donde se almacena el backup"
        '
        'tsql
        '
        Me.tsql.BackColor = System.Drawing.SystemColors.Control
        Me.tsql.Controls.Add(Me.txtserver)
        Me.tsql.Controls.Add(Me.txtuser)
        Me.tsql.Controls.Add(Me.txtpassword)
        Me.tsql.Controls.Add(Me.lblpassword)
        Me.tsql.Controls.Add(Me.txtdb)
        Me.tsql.Controls.Add(Me.lblruta)
        Me.tsql.Controls.Add(Me.lblusuario)
        Me.tsql.Controls.Add(Me.lbldb)
        Me.tsql.Location = New System.Drawing.Point(4, 22)
        Me.tsql.Margin = New System.Windows.Forms.Padding(2)
        Me.tsql.Name = "tsql"
        Me.tsql.Size = New System.Drawing.Size(808, 421)
        Me.tsql.TabIndex = 3
        Me.tsql.Text = "SQL"
        '
        'txtserver
        '
        Me.txtserver.Location = New System.Drawing.Point(148, 65)
        Me.txtserver.Margin = New System.Windows.Forms.Padding(2)
        Me.txtserver.Name = "txtserver"
        Me.txtserver.Size = New System.Drawing.Size(305, 20)
        Me.txtserver.TabIndex = 7
        '
        'txtuser
        '
        Me.txtuser.Location = New System.Drawing.Point(148, 98)
        Me.txtuser.Margin = New System.Windows.Forms.Padding(2)
        Me.txtuser.Name = "txtuser"
        Me.txtuser.Size = New System.Drawing.Size(305, 20)
        Me.txtuser.TabIndex = 6
        '
        'txtpassword
        '
        Me.txtpassword.Location = New System.Drawing.Point(148, 130)
        Me.txtpassword.Margin = New System.Windows.Forms.Padding(2)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.Size = New System.Drawing.Size(305, 20)
        Me.txtpassword.TabIndex = 5
        '
        'lblpassword
        '
        Me.lblpassword.AutoSize = True
        Me.lblpassword.Location = New System.Drawing.Point(17, 134)
        Me.lblpassword.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblpassword.Name = "lblpassword"
        Me.lblpassword.Size = New System.Drawing.Size(61, 13)
        Me.lblpassword.TabIndex = 4
        Me.lblpassword.Text = "Contraseña"
        '
        'txtdb
        '
        Me.txtdb.Location = New System.Drawing.Point(148, 34)
        Me.txtdb.Margin = New System.Windows.Forms.Padding(2)
        Me.txtdb.Name = "txtdb"
        Me.txtdb.Size = New System.Drawing.Size(305, 20)
        Me.txtdb.TabIndex = 3
        '
        'lblruta
        '
        Me.lblruta.AutoSize = True
        Me.lblruta.Location = New System.Drawing.Point(17, 69)
        Me.lblruta.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblruta.Name = "lblruta"
        Me.lblruta.Size = New System.Drawing.Size(81, 13)
        Me.lblruta.TabIndex = 2
        Me.lblruta.Text = "Ruta al servidor"
        '
        'lblusuario
        '
        Me.lblusuario.AutoSize = True
        Me.lblusuario.Location = New System.Drawing.Point(17, 102)
        Me.lblusuario.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblusuario.Name = "lblusuario"
        Me.lblusuario.Size = New System.Drawing.Size(43, 13)
        Me.lblusuario.TabIndex = 1
        Me.lblusuario.Text = "Usuario"
        '
        'lbldb
        '
        Me.lbldb.AutoSize = True
        Me.lbldb.Location = New System.Drawing.Point(17, 37)
        Me.lbldb.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbldb.Name = "lbldb"
        Me.lbldb.Size = New System.Drawing.Size(96, 13)
        Me.lbldb.TabIndex = 0
        Me.lbldb.Text = "Nombre de la base"
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(429, 512)
        Me.cmd_exit.Margin = New System.Windows.Forms.Padding(2)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(134, 28)
        Me.cmd_exit.TabIndex = 5
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(271, 512)
        Me.cmd_ok.Margin = New System.Windows.Forms.Padding(2)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(134, 28)
        Me.cmd_ok.TabIndex = 4
        Me.cmd_ok.Text = "Aceptar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'config
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 563)
        Me.Controls.Add(Me.tctrl)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "config"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Configuración"
        Me.tctrl.ResumeLayout(False)
        Me.tconfrgl.ResumeLayout(False)
        Me.gb_pager.ResumeLayout(False)
        Me.gb_pager.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tpedidos.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tBackup.ResumeLayout(False)
        Me.tBackup.PerformLayout()
        Me.tsql.ResumeLayout(False)
        Me.tsql.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tctrl As TabControl
    Friend WithEvents tconfrgl As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rdb_coma As RadioButton
    Friend WithEvents rdb_punto As RadioButton
    Friend WithEvents lbl_decimal As Label
    Friend WithEvents tpedidos As TabPage
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lbl_pclientes As Label
    Friend WithEvents cmb_clientes As ComboBox
    Friend WithEvents chk_cliente As CheckBox
    Friend WithEvents tBackup As TabPage
    Friend WithEvents lbl_nombreBackup As Label
    Friend WithEvents txt_nombreBackup As TextBox
    Friend WithEvents cmd_abrirCarpeta As Button
    Friend WithEvents cmd_elegirRuta As Button
    Friend WithEvents txt_rutaBackup As TextBox
    Friend WithEvents lbl_ruta As Label
    Friend WithEvents tsql As TabPage
    Friend WithEvents txtserver As TextBox
    Friend WithEvents txtuser As TextBox
    Friend WithEvents txtpassword As TextBox
    Friend WithEvents lblpassword As Label
    Friend WithEvents txtdb As TextBox
    Friend WithEvents lblruta As Label
    Friend WithEvents lblusuario As Label
    Friend WithEvents lbldb As Label
    Friend WithEvents cmd_exit As Button
    Friend WithEvents cmd_ok As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents gb_pager As GroupBox
    Friend WithEvents txt_itPerPage As TextBox
    Friend WithEvents Label1 As Label
End Class
