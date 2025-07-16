<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class add_auto
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lbl_cliente = New System.Windows.Forms.Label()
        Me.lbl_patente = New System.Windows.Forms.Label()
        Me.lbl_marca = New System.Windows.Forms.Label()
        Me.lbl_modelo = New System.Windows.Forms.Label()
        Me.pic_modeloSearch = New System.Windows.Forms.PictureBox()
        Me.pic_marcaSearch = New System.Windows.Forms.PictureBox()
        Me.pic_cliSearch = New System.Windows.Forms.PictureBox()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.txt_patente = New System.Windows.Forms.TextBox()
        Me.cmb_marcas = New System.Windows.Forms.ComboBox()
        Me.cmb_modelos = New System.Windows.Forms.ComboBox()
        Me.cmb_clientes = New System.Windows.Forms.ComboBox()
        Me.txt_anio = New System.Windows.Forms.TextBox()
        Me.lbl_anio = New System.Windows.Forms.Label()
        Me.chk_activo = New System.Windows.Forms.CheckBox()
        Me.chk_deudor = New System.Windows.Forms.CheckBox()
        Me.cmb_descuento = New System.Windows.Forms.ComboBox()
        Me.pick_descSearch = New System.Windows.Forms.PictureBox()
        Me.lbl_descuento = New System.Windows.Forms.Label()
        CType(Me.pic_modeloSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_marcaSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_cliSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pick_descSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_cliente
        '
        Me.lbl_cliente.AutoSize = True
        Me.lbl_cliente.Location = New System.Drawing.Point(19, 67)
        Me.lbl_cliente.Name = "lbl_cliente"
        Me.lbl_cliente.Size = New System.Drawing.Size(39, 13)
        Me.lbl_cliente.TabIndex = 0
        Me.lbl_cliente.Text = "Cliente"
        '
        'lbl_patente
        '
        Me.lbl_patente.AutoSize = True
        Me.lbl_patente.Location = New System.Drawing.Point(19, 27)
        Me.lbl_patente.Name = "lbl_patente"
        Me.lbl_patente.Size = New System.Drawing.Size(44, 13)
        Me.lbl_patente.TabIndex = 2
        Me.lbl_patente.Text = "Patente"
        '
        'lbl_marca
        '
        Me.lbl_marca.AutoSize = True
        Me.lbl_marca.Location = New System.Drawing.Point(19, 107)
        Me.lbl_marca.Name = "lbl_marca"
        Me.lbl_marca.Size = New System.Drawing.Size(37, 13)
        Me.lbl_marca.TabIndex = 3
        Me.lbl_marca.Text = "Marca"
        '
        'lbl_modelo
        '
        Me.lbl_modelo.AutoSize = True
        Me.lbl_modelo.Location = New System.Drawing.Point(19, 147)
        Me.lbl_modelo.Name = "lbl_modelo"
        Me.lbl_modelo.Size = New System.Drawing.Size(42, 13)
        Me.lbl_modelo.TabIndex = 4
        Me.lbl_modelo.Text = "Modelo"
        '
        'pic_modeloSearch
        '
        Me.pic_modeloSearch.Image = Global.DrOil.My.Resources.Resources.iconoLupa
        Me.pic_modeloSearch.Location = New System.Drawing.Point(369, 149)
        Me.pic_modeloSearch.Name = "pic_modeloSearch"
        Me.pic_modeloSearch.Size = New System.Drawing.Size(22, 22)
        Me.pic_modeloSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_modeloSearch.TabIndex = 26
        Me.pic_modeloSearch.TabStop = False
        '
        'pic_marcaSearch
        '
        Me.pic_marcaSearch.Image = Global.DrOil.My.Resources.Resources.iconoLupa
        Me.pic_marcaSearch.Location = New System.Drawing.Point(369, 107)
        Me.pic_marcaSearch.Name = "pic_marcaSearch"
        Me.pic_marcaSearch.Size = New System.Drawing.Size(22, 22)
        Me.pic_marcaSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_marcaSearch.TabIndex = 27
        Me.pic_marcaSearch.TabStop = False
        '
        'pic_cliSearch
        '
        Me.pic_cliSearch.Image = Global.DrOil.My.Resources.Resources.iconoLupa
        Me.pic_cliSearch.Location = New System.Drawing.Point(369, 68)
        Me.pic_cliSearch.Name = "pic_cliSearch"
        Me.pic_cliSearch.Size = New System.Drawing.Size(22, 22)
        Me.pic_cliSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_cliSearch.TabIndex = 29
        Me.pic_cliSearch.TabStop = False
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Location = New System.Drawing.Point(75, 333)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(108, 17)
        Me.chk_secuencia.TabIndex = 8
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(217, 372)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 10
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(119, 372)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 9
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'txt_patente
        '
        Me.txt_patente.Location = New System.Drawing.Point(83, 24)
        Me.txt_patente.Name = "txt_patente"
        Me.txt_patente.Size = New System.Drawing.Size(265, 20)
        Me.txt_patente.TabIndex = 0
        '
        'cmb_marcas
        '
        Me.cmb_marcas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_marcas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_marcas.FormattingEnabled = True
        Me.cmb_marcas.Location = New System.Drawing.Point(83, 108)
        Me.cmb_marcas.Name = "cmb_marcas"
        Me.cmb_marcas.Size = New System.Drawing.Size(265, 21)
        Me.cmb_marcas.TabIndex = 2
        '
        'cmb_modelos
        '
        Me.cmb_modelos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_modelos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_modelos.FormattingEnabled = True
        Me.cmb_modelos.Location = New System.Drawing.Point(83, 150)
        Me.cmb_modelos.Name = "cmb_modelos"
        Me.cmb_modelos.Size = New System.Drawing.Size(265, 21)
        Me.cmb_modelos.TabIndex = 3
        '
        'cmb_clientes
        '
        Me.cmb_clientes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_clientes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_clientes.FormattingEnabled = True
        Me.cmb_clientes.Location = New System.Drawing.Point(83, 68)
        Me.cmb_clientes.Name = "cmb_clientes"
        Me.cmb_clientes.Size = New System.Drawing.Size(265, 21)
        Me.cmb_clientes.TabIndex = 1
        '
        'txt_anio
        '
        Me.txt_anio.Location = New System.Drawing.Point(83, 192)
        Me.txt_anio.Name = "txt_anio"
        Me.txt_anio.Size = New System.Drawing.Size(265, 20)
        Me.txt_anio.TabIndex = 4
        '
        'lbl_anio
        '
        Me.lbl_anio.AutoSize = True
        Me.lbl_anio.Location = New System.Drawing.Point(19, 192)
        Me.lbl_anio.Name = "lbl_anio"
        Me.lbl_anio.Size = New System.Drawing.Size(26, 13)
        Me.lbl_anio.TabIndex = 37
        Me.lbl_anio.Text = "Año"
        '
        'chk_activo
        '
        Me.chk_activo.AutoSize = True
        Me.chk_activo.Location = New System.Drawing.Point(75, 295)
        Me.chk_activo.Name = "chk_activo"
        Me.chk_activo.Size = New System.Drawing.Size(80, 17)
        Me.chk_activo.TabIndex = 6
        Me.chk_activo.Text = "Auto activo"
        Me.chk_activo.UseVisualStyleBackColor = True
        '
        'chk_deudor
        '
        Me.chk_deudor.AutoSize = True
        Me.chk_deudor.Location = New System.Drawing.Point(199, 295)
        Me.chk_deudor.Name = "chk_deudor"
        Me.chk_deudor.Size = New System.Drawing.Size(102, 17)
        Me.chk_deudor.TabIndex = 7
        Me.chk_deudor.Text = "Auto con deuda"
        Me.chk_deudor.UseVisualStyleBackColor = True
        '
        'cmb_descuento
        '
        Me.cmb_descuento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_descuento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_descuento.DisplayMember = "id_tipo"
        Me.cmb_descuento.FormattingEnabled = True
        Me.cmb_descuento.Location = New System.Drawing.Point(83, 234)
        Me.cmb_descuento.Name = "cmb_descuento"
        Me.cmb_descuento.Size = New System.Drawing.Size(265, 21)
        Me.cmb_descuento.TabIndex = 5
        Me.cmb_descuento.ValueMember = "id_tipo"
        '
        'pick_descSearch
        '
        Me.pick_descSearch.Image = Global.DrOil.My.Resources.Resources.iconoLupa
        Me.pick_descSearch.Location = New System.Drawing.Point(369, 234)
        Me.pick_descSearch.Name = "pick_descSearch"
        Me.pick_descSearch.Size = New System.Drawing.Size(22, 22)
        Me.pick_descSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pick_descSearch.TabIndex = 84
        Me.pick_descSearch.TabStop = False
        '
        'lbl_descuento
        '
        Me.lbl_descuento.AutoSize = True
        Me.lbl_descuento.Location = New System.Drawing.Point(19, 234)
        Me.lbl_descuento.Name = "lbl_descuento"
        Me.lbl_descuento.Size = New System.Drawing.Size(59, 13)
        Me.lbl_descuento.TabIndex = 83
        Me.lbl_descuento.Text = "Descuento"
        '
        'add_auto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(410, 418)
        Me.Controls.Add(Me.cmb_descuento)
        Me.Controls.Add(Me.pick_descSearch)
        Me.Controls.Add(Me.lbl_descuento)
        Me.Controls.Add(Me.chk_deudor)
        Me.Controls.Add(Me.chk_activo)
        Me.Controls.Add(Me.txt_anio)
        Me.Controls.Add(Me.lbl_anio)
        Me.Controls.Add(Me.cmb_clientes)
        Me.Controls.Add(Me.cmb_modelos)
        Me.Controls.Add(Me.cmb_marcas)
        Me.Controls.Add(Me.txt_patente)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.pic_cliSearch)
        Me.Controls.Add(Me.pic_marcaSearch)
        Me.Controls.Add(Me.pic_modeloSearch)
        Me.Controls.Add(Me.lbl_modelo)
        Me.Controls.Add(Me.lbl_marca)
        Me.Controls.Add(Me.lbl_patente)
        Me.Controls.Add(Me.lbl_cliente)
        Me.Name = "add_auto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Insertar auto"
        CType(Me.pic_modeloSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_marcaSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_cliSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pick_descSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_cliente As System.Windows.Forms.Label
    Friend WithEvents lbl_patente As System.Windows.Forms.Label
    Friend WithEvents lbl_marca As System.Windows.Forms.Label
    Friend WithEvents lbl_modelo As System.Windows.Forms.Label
    Friend WithEvents pic_modeloSearch As System.Windows.Forms.PictureBox
    Friend WithEvents pic_marcaSearch As System.Windows.Forms.PictureBox
    Friend WithEvents pic_cliSearch As System.Windows.Forms.PictureBox
    Friend WithEvents chk_secuencia As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents txt_patente As System.Windows.Forms.TextBox
    Friend WithEvents cmb_marcas As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_modelos As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_clientes As System.Windows.Forms.ComboBox
    Friend WithEvents txt_anio As System.Windows.Forms.TextBox
    Friend WithEvents lbl_anio As System.Windows.Forms.Label
    Friend WithEvents chk_activo As System.Windows.Forms.CheckBox
    Friend WithEvents chk_deudor As System.Windows.Forms.CheckBox
    Friend WithEvents cmb_descuento As ComboBox
    Friend WithEvents pick_descSearch As PictureBox
    Friend WithEvents lbl_descuento As Label
End Class
