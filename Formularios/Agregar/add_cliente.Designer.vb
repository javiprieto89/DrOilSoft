<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_cliente
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
        Me.lbl_nombre = New System.Windows.Forms.Label()
        Me.txt_nombre = New System.Windows.Forms.TextBox()
        Me.txt_apellido = New System.Windows.Forms.TextBox()
        Me.lbl_apellido = New System.Windows.Forms.Label()
        Me.txt_dni = New System.Windows.Forms.TextBox()
        Me.lbl_dni = New System.Windows.Forms.Label()
        Me.txt_tel = New System.Windows.Forms.TextBox()
        Me.lbl_tel = New System.Windows.Forms.Label()
        Me.txt_direccion = New System.Windows.Forms.TextBox()
        Me.lbl_direccion = New System.Windows.Forms.Label()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.chk_activo = New System.Windows.Forms.CheckBox()
        Me.cmb_descuento = New System.Windows.Forms.ComboBox()
        Me.psearch_descuento = New System.Windows.Forms.PictureBox()
        Me.lbl_descuento = New System.Windows.Forms.Label()
        Me.lbl_cpFiscal = New System.Windows.Forms.Label()
        Me.txt_cpFiscal = New System.Windows.Forms.TextBox()
        Me.cmb_paisFiscal = New System.Windows.Forms.ComboBox()
        Me.lbl_paisFiscal = New System.Windows.Forms.Label()
        Me.cmb_provinciaFiscal = New System.Windows.Forms.ComboBox()
        Me.lbl_provinciaFiscal = New System.Windows.Forms.Label()
        Me.lbl_localidadFiscal = New System.Windows.Forms.Label()
        Me.txt_localidadFiscal = New System.Windows.Forms.TextBox()
        Me.chk_esInscripto = New System.Windows.Forms.CheckBox()
        Me.cmb_tipoDocumento = New System.Windows.Forms.ComboBox()
        Me.lbl_tipoDocumento = New System.Windows.Forms.Label()
        Me.lbl_email = New System.Windows.Forms.Label()
        Me.txt_email = New System.Windows.Forms.TextBox()
        CType(Me.psearch_descuento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_nombre
        '
        Me.lbl_nombre.AutoSize = True
        Me.lbl_nombre.Location = New System.Drawing.Point(27, 110)
        Me.lbl_nombre.Name = "lbl_nombre"
        Me.lbl_nombre.Size = New System.Drawing.Size(44, 13)
        Me.lbl_nombre.TabIndex = 0
        Me.lbl_nombre.Text = "Nombre"
        '
        'txt_nombre
        '
        Me.txt_nombre.Location = New System.Drawing.Point(148, 107)
        Me.txt_nombre.MaxLength = 45
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.Size = New System.Drawing.Size(163, 20)
        Me.txt_nombre.TabIndex = 2
        '
        'txt_apellido
        '
        Me.txt_apellido.Location = New System.Drawing.Point(148, 150)
        Me.txt_apellido.MaxLength = 45
        Me.txt_apellido.Name = "txt_apellido"
        Me.txt_apellido.Size = New System.Drawing.Size(163, 20)
        Me.txt_apellido.TabIndex = 3
        '
        'lbl_apellido
        '
        Me.lbl_apellido.AutoSize = True
        Me.lbl_apellido.Location = New System.Drawing.Point(27, 157)
        Me.lbl_apellido.Name = "lbl_apellido"
        Me.lbl_apellido.Size = New System.Drawing.Size(44, 13)
        Me.lbl_apellido.TabIndex = 2
        Me.lbl_apellido.Text = "Apellido"
        '
        'txt_dni
        '
        Me.txt_dni.Location = New System.Drawing.Point(148, 25)
        Me.txt_dni.MaxLength = 13
        Me.txt_dni.Name = "txt_dni"
        Me.txt_dni.Size = New System.Drawing.Size(163, 20)
        Me.txt_dni.TabIndex = 0
        '
        'lbl_dni
        '
        Me.lbl_dni.AutoSize = True
        Me.lbl_dni.Location = New System.Drawing.Point(27, 29)
        Me.lbl_dni.Name = "lbl_dni"
        Me.lbl_dni.Size = New System.Drawing.Size(85, 13)
        Me.lbl_dni.TabIndex = 4
        Me.lbl_dni.Text = "CUIT/CUIL/DNI"
        '
        'txt_tel
        '
        Me.txt_tel.Location = New System.Drawing.Point(148, 198)
        Me.txt_tel.MaxLength = 45
        Me.txt_tel.Name = "txt_tel"
        Me.txt_tel.Size = New System.Drawing.Size(163, 20)
        Me.txt_tel.TabIndex = 4
        '
        'lbl_tel
        '
        Me.lbl_tel.AutoSize = True
        Me.lbl_tel.Location = New System.Drawing.Point(27, 205)
        Me.lbl_tel.Name = "lbl_tel"
        Me.lbl_tel.Size = New System.Drawing.Size(49, 13)
        Me.lbl_tel.TabIndex = 6
        Me.lbl_tel.Text = "Teléfono"
        '
        'txt_direccion
        '
        Me.txt_direccion.Location = New System.Drawing.Point(490, 149)
        Me.txt_direccion.MaxLength = 200
        Me.txt_direccion.Name = "txt_direccion"
        Me.txt_direccion.Size = New System.Drawing.Size(163, 20)
        Me.txt_direccion.TabIndex = 8
        '
        'lbl_direccion
        '
        Me.lbl_direccion.AutoSize = True
        Me.lbl_direccion.Location = New System.Drawing.Point(397, 157)
        Me.lbl_direccion.Name = "lbl_direccion"
        Me.lbl_direccion.Size = New System.Drawing.Size(52, 13)
        Me.lbl_direccion.TabIndex = 8
        Me.lbl_direccion.Text = "Dirección"
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(273, 443)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 14
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(371, 443)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 15
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Location = New System.Drawing.Point(30, 395)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(108, 17)
        Me.chk_secuencia.TabIndex = 13
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        '
        'chk_activo
        '
        Me.chk_activo.AutoSize = True
        Me.chk_activo.Location = New System.Drawing.Point(30, 361)
        Me.chk_activo.Name = "chk_activo"
        Me.chk_activo.Size = New System.Drawing.Size(90, 17)
        Me.chk_activo.TabIndex = 12
        Me.chk_activo.Text = "Cliente activo"
        Me.chk_activo.UseVisualStyleBackColor = True
        '
        'cmb_descuento
        '
        Me.cmb_descuento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_descuento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_descuento.DisplayMember = "id_tipo"
        Me.cmb_descuento.FormattingEnabled = True
        Me.cmb_descuento.Location = New System.Drawing.Point(490, 24)
        Me.cmb_descuento.Name = "cmb_descuento"
        Me.cmb_descuento.Size = New System.Drawing.Size(163, 21)
        Me.cmb_descuento.TabIndex = 5
        Me.cmb_descuento.ValueMember = "id_tipo"
        '
        'psearch_descuento
        '
        Me.psearch_descuento.Image = Global.DROil.My.Resources.Resources.iconoLupa
        Me.psearch_descuento.Location = New System.Drawing.Point(659, 24)
        Me.psearch_descuento.Name = "psearch_descuento"
        Me.psearch_descuento.Size = New System.Drawing.Size(22, 22)
        Me.psearch_descuento.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_descuento.TabIndex = 81
        Me.psearch_descuento.TabStop = False
        '
        'lbl_descuento
        '
        Me.lbl_descuento.AutoSize = True
        Me.lbl_descuento.Location = New System.Drawing.Point(396, 24)
        Me.lbl_descuento.Name = "lbl_descuento"
        Me.lbl_descuento.Size = New System.Drawing.Size(59, 13)
        Me.lbl_descuento.TabIndex = 80
        Me.lbl_descuento.Text = "Descuento"
        '
        'lbl_cpFiscal
        '
        Me.lbl_cpFiscal.AutoSize = True
        Me.lbl_cpFiscal.Location = New System.Drawing.Point(396, 250)
        Me.lbl_cpFiscal.Name = "lbl_cpFiscal"
        Me.lbl_cpFiscal.Size = New System.Drawing.Size(21, 13)
        Me.lbl_cpFiscal.TabIndex = 98
        Me.lbl_cpFiscal.Text = "CP"
        '
        'txt_cpFiscal
        '
        Me.txt_cpFiscal.Location = New System.Drawing.Point(490, 243)
        Me.txt_cpFiscal.MaxLength = 200
        Me.txt_cpFiscal.Name = "txt_cpFiscal"
        Me.txt_cpFiscal.Size = New System.Drawing.Size(163, 20)
        Me.txt_cpFiscal.TabIndex = 10
        '
        'cmb_paisFiscal
        '
        Me.cmb_paisFiscal.FormattingEnabled = True
        Me.cmb_paisFiscal.Location = New System.Drawing.Point(490, 66)
        Me.cmb_paisFiscal.Name = "cmb_paisFiscal"
        Me.cmb_paisFiscal.Size = New System.Drawing.Size(163, 21)
        Me.cmb_paisFiscal.TabIndex = 6
        '
        'lbl_paisFiscal
        '
        Me.lbl_paisFiscal.AutoSize = True
        Me.lbl_paisFiscal.Location = New System.Drawing.Point(396, 70)
        Me.lbl_paisFiscal.Name = "lbl_paisFiscal"
        Me.lbl_paisFiscal.Size = New System.Drawing.Size(29, 13)
        Me.lbl_paisFiscal.TabIndex = 97
        Me.lbl_paisFiscal.Text = "País"
        '
        'cmb_provinciaFiscal
        '
        Me.cmb_provinciaFiscal.FormattingEnabled = True
        Me.cmb_provinciaFiscal.Location = New System.Drawing.Point(490, 106)
        Me.cmb_provinciaFiscal.Name = "cmb_provinciaFiscal"
        Me.cmb_provinciaFiscal.Size = New System.Drawing.Size(163, 21)
        Me.cmb_provinciaFiscal.TabIndex = 7
        '
        'lbl_provinciaFiscal
        '
        Me.lbl_provinciaFiscal.AutoSize = True
        Me.lbl_provinciaFiscal.Location = New System.Drawing.Point(396, 110)
        Me.lbl_provinciaFiscal.Name = "lbl_provinciaFiscal"
        Me.lbl_provinciaFiscal.Size = New System.Drawing.Size(51, 13)
        Me.lbl_provinciaFiscal.TabIndex = 95
        Me.lbl_provinciaFiscal.Text = "Provincia"
        '
        'lbl_localidadFiscal
        '
        Me.lbl_localidadFiscal.AutoSize = True
        Me.lbl_localidadFiscal.Location = New System.Drawing.Point(396, 205)
        Me.lbl_localidadFiscal.Name = "lbl_localidadFiscal"
        Me.lbl_localidadFiscal.Size = New System.Drawing.Size(53, 13)
        Me.lbl_localidadFiscal.TabIndex = 96
        Me.lbl_localidadFiscal.Text = "Localidad"
        '
        'txt_localidadFiscal
        '
        Me.txt_localidadFiscal.Location = New System.Drawing.Point(490, 197)
        Me.txt_localidadFiscal.MaxLength = 200
        Me.txt_localidadFiscal.Name = "txt_localidadFiscal"
        Me.txt_localidadFiscal.Size = New System.Drawing.Size(163, 20)
        Me.txt_localidadFiscal.TabIndex = 9
        '
        'chk_esInscripto
        '
        Me.chk_esInscripto.AutoSize = True
        Me.chk_esInscripto.Location = New System.Drawing.Point(30, 326)
        Me.chk_esInscripto.Name = "chk_esInscripto"
        Me.chk_esInscripto.Size = New System.Drawing.Size(130, 17)
        Me.chk_esInscripto.TabIndex = 11
        Me.chk_esInscripto.Text = "Responsable inscripto"
        Me.chk_esInscripto.UseVisualStyleBackColor = True
        '
        'cmb_tipoDocumento
        '
        Me.cmb_tipoDocumento.FormattingEnabled = True
        Me.cmb_tipoDocumento.Location = New System.Drawing.Point(148, 67)
        Me.cmb_tipoDocumento.Name = "cmb_tipoDocumento"
        Me.cmb_tipoDocumento.Size = New System.Drawing.Size(163, 21)
        Me.cmb_tipoDocumento.TabIndex = 1
        '
        'lbl_tipoDocumento
        '
        Me.lbl_tipoDocumento.AutoSize = True
        Me.lbl_tipoDocumento.Location = New System.Drawing.Point(27, 70)
        Me.lbl_tipoDocumento.Name = "lbl_tipoDocumento"
        Me.lbl_tipoDocumento.Size = New System.Drawing.Size(99, 13)
        Me.lbl_tipoDocumento.TabIndex = 101
        Me.lbl_tipoDocumento.Text = "Tipo de documento"
        '
        'lbl_email
        '
        Me.lbl_email.AutoSize = True
        Me.lbl_email.Location = New System.Drawing.Point(27, 250)
        Me.lbl_email.Name = "lbl_email"
        Me.lbl_email.Size = New System.Drawing.Size(32, 13)
        Me.lbl_email.TabIndex = 103
        Me.lbl_email.Text = "Email"
        '
        'txt_email
        '
        Me.txt_email.Location = New System.Drawing.Point(148, 243)
        Me.txt_email.MaxLength = 200
        Me.txt_email.Name = "txt_email"
        Me.txt_email.Size = New System.Drawing.Size(163, 20)
        Me.txt_email.TabIndex = 102
        '
        'add_cliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(718, 487)
        Me.Controls.Add(Me.lbl_email)
        Me.Controls.Add(Me.txt_email)
        Me.Controls.Add(Me.cmb_tipoDocumento)
        Me.Controls.Add(Me.lbl_tipoDocumento)
        Me.Controls.Add(Me.chk_esInscripto)
        Me.Controls.Add(Me.lbl_cpFiscal)
        Me.Controls.Add(Me.txt_cpFiscal)
        Me.Controls.Add(Me.cmb_paisFiscal)
        Me.Controls.Add(Me.lbl_paisFiscal)
        Me.Controls.Add(Me.cmb_provinciaFiscal)
        Me.Controls.Add(Me.lbl_provinciaFiscal)
        Me.Controls.Add(Me.lbl_localidadFiscal)
        Me.Controls.Add(Me.txt_localidadFiscal)
        Me.Controls.Add(Me.cmb_descuento)
        Me.Controls.Add(Me.psearch_descuento)
        Me.Controls.Add(Me.lbl_descuento)
        Me.Controls.Add(Me.chk_activo)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.txt_direccion)
        Me.Controls.Add(Me.lbl_direccion)
        Me.Controls.Add(Me.txt_tel)
        Me.Controls.Add(Me.lbl_tel)
        Me.Controls.Add(Me.txt_dni)
        Me.Controls.Add(Me.lbl_dni)
        Me.Controls.Add(Me.txt_apellido)
        Me.Controls.Add(Me.lbl_apellido)
        Me.Controls.Add(Me.txt_nombre)
        Me.Controls.Add(Me.lbl_nombre)
        Me.Name = "add_cliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Insertar cliente"
        CType(Me.psearch_descuento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_nombre As System.Windows.Forms.Label
    Friend WithEvents txt_nombre As System.Windows.Forms.TextBox
    Friend WithEvents txt_apellido As System.Windows.Forms.TextBox
    Friend WithEvents lbl_apellido As System.Windows.Forms.Label
    Friend WithEvents txt_dni As System.Windows.Forms.TextBox
    Friend WithEvents lbl_dni As System.Windows.Forms.Label
    Friend WithEvents txt_tel As System.Windows.Forms.TextBox
    Friend WithEvents lbl_tel As System.Windows.Forms.Label
    Friend WithEvents txt_direccion As System.Windows.Forms.TextBox
    Friend WithEvents lbl_direccion As System.Windows.Forms.Label
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents chk_secuencia As System.Windows.Forms.CheckBox
    Friend WithEvents chk_activo As System.Windows.Forms.CheckBox
    Friend WithEvents cmb_descuento As ComboBox
    Friend WithEvents psearch_descuento As PictureBox
    Friend WithEvents lbl_descuento As Label
    Friend WithEvents lbl_cpFiscal As Label
    Friend WithEvents txt_cpFiscal As TextBox
    Friend WithEvents cmb_paisFiscal As ComboBox
    Friend WithEvents lbl_paisFiscal As Label
    Friend WithEvents cmb_provinciaFiscal As ComboBox
    Friend WithEvents lbl_provinciaFiscal As Label
    Friend WithEvents lbl_localidadFiscal As Label
    Friend WithEvents txt_localidadFiscal As TextBox
    Friend WithEvents chk_esInscripto As CheckBox
    Friend WithEvents cmb_tipoDocumento As ComboBox
    Friend WithEvents lbl_tipoDocumento As Label
    Friend WithEvents lbl_email As Label
    Friend WithEvents txt_email As TextBox
End Class
