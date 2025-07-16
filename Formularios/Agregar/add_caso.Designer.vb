<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class add_caso
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
        Me.components = New System.ComponentModel.Container()
        Me.lbl_fecha = New System.Windows.Forms.Label()
        Me.lbl_km = New System.Windows.Forms.Label()
        Me.lbl_patente = New System.Windows.Forms.Label()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.txt_km = New System.Windows.Forms.TextBox()
        Me.lbl_date = New System.Windows.Forms.Label()
        Me.lblcliente = New System.Windows.Forms.Label()
        Me.lblmarca = New System.Windows.Forms.Label()
        Me.lblmodelo = New System.Windows.Forms.Label()
        Me.lbl_cliente = New System.Windows.Forms.Label()
        Me.lbl_marca = New System.Windows.Forms.Label()
        Me.lbl_modelo = New System.Windows.Forms.Label()
        Me.cmd_add_caso_item = New System.Windows.Forms.Button()
        Me.txt_total = New System.Windows.Forms.TextBox()
        Me.lbl_total = New System.Windows.Forms.Label()
        Me.lsv_item = New System.Windows.Forms.ListView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BorrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecargarPrecioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportarItemsDeUnPedidoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txt_proximocambio = New System.Windows.Forms.TextBox()
        Me.lbl_proximocambio = New System.Windows.Forms.Label()
        Me.txt_notas = New System.Windows.Forms.TextBox()
        Me.lbl_notas = New System.Windows.Forms.Label()
        Me.psearch_auto = New System.Windows.Forms.PictureBox()
        Me.cmd_recargaprecios = New System.Windows.Forms.Button()
        Me.psearch_tipocaso = New System.Windows.Forms.PictureBox()
        Me.lbl_tipocaso = New System.Windows.Forms.Label()
        Me.cmb_tipocaso = New System.Windows.Forms.ComboBox()
        Me.TiposcasosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmb_patente = New System.Windows.Forms.ComboBox()
        Me.cmb_condicion = New System.Windows.Forms.ComboBox()
        Me.cmb_descuento = New System.Windows.Forms.ComboBox()
        Me.psearch_descuento = New System.Windows.Forms.PictureBox()
        Me.lbl_descuento = New System.Windows.Forms.Label()
        Me.psearch_condicion = New System.Windows.Forms.PictureBox()
        Me.lbl_condicion = New System.Windows.Forms.Label()
        Me.txt_subTotal = New System.Windows.Forms.TextBox()
        Me.lbl_subTotal = New System.Windows.Forms.Label()
        Me.cmb_caja = New System.Windows.Forms.ComboBox()
        Me.psearch_caja = New System.Windows.Forms.PictureBox()
        Me.lbl_caja = New System.Windows.Forms.Label()
        Me.chk_pagoCombinado = New System.Windows.Forms.CheckBox()
        Me.txt_cargaEAN = New System.Windows.Forms.TextBox()
        Me.lbl_cargaEAN = New System.Windows.Forms.Label()
        Me.lbl_yaFacturado = New System.Windows.Forms.Label()
        Me.cmb_vendedor = New System.Windows.Forms.ComboBox()
        Me.psearch_vendedor = New System.Windows.Forms.PictureBox()
        Me.lbl_vendedor = New System.Windows.Forms.Label()
        Me.cmb_mecanico = New System.Windows.Forms.ComboBox()
        Me.psearch_mecanico = New System.Windows.Forms.PictureBox()
        Me.lbl_mecanico = New System.Windows.Forms.Label()
        Me.cmb_estadoPedido = New System.Windows.Forms.ComboBox()
        Me.psearch_estadoPedido = New System.Windows.Forms.PictureBox()
        Me.lbl_estado = New System.Windows.Forms.Label()
        Me.chk_imprimirOrden = New System.Windows.Forms.CheckBox()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.psearch_auto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.psearch_tipocaso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TiposcasosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.psearch_descuento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.psearch_condicion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.psearch_caja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.psearch_vendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.psearch_mecanico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.psearch_estadoPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_fecha
        '
        Me.lbl_fecha.AutoSize = True
        Me.lbl_fecha.Location = New System.Drawing.Point(23, 25)
        Me.lbl_fecha.Name = "lbl_fecha"
        Me.lbl_fecha.Size = New System.Drawing.Size(40, 13)
        Me.lbl_fecha.TabIndex = 0
        Me.lbl_fecha.Text = "Fecha:"
        '
        'lbl_km
        '
        Me.lbl_km.AutoSize = True
        Me.lbl_km.Location = New System.Drawing.Point(23, 251)
        Me.lbl_km.Name = "lbl_km"
        Me.lbl_km.Size = New System.Drawing.Size(58, 13)
        Me.lbl_km.TabIndex = 1
        Me.lbl_km.Text = "Kilometraje"
        '
        'lbl_patente
        '
        Me.lbl_patente.AutoSize = True
        Me.lbl_patente.Location = New System.Drawing.Point(23, 62)
        Me.lbl_patente.Name = "lbl_patente"
        Me.lbl_patente.Size = New System.Drawing.Size(44, 13)
        Me.lbl_patente.TabIndex = 2
        Me.lbl_patente.Text = "Patente"
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Location = New System.Drawing.Point(26, 697)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(108, 17)
        Me.chk_secuencia.TabIndex = 12
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(466, 783)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(166, 29)
        Me.cmd_exit.TabIndex = 14
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(248, 783)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(166, 29)
        Me.cmd_ok.TabIndex = 13
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'txt_km
        '
        Me.txt_km.Location = New System.Drawing.Point(133, 244)
        Me.txt_km.Name = "txt_km"
        Me.txt_km.Size = New System.Drawing.Size(259, 20)
        Me.txt_km.TabIndex = 2
        '
        'lbl_date
        '
        Me.lbl_date.AutoSize = True
        Me.lbl_date.Location = New System.Drawing.Point(134, 25)
        Me.lbl_date.Name = "lbl_date"
        Me.lbl_date.Size = New System.Drawing.Size(50, 13)
        Me.lbl_date.TabIndex = 29
        Me.lbl_date.Text = "%fecha%"
        '
        'lblcliente
        '
        Me.lblcliente.AutoSize = True
        Me.lblcliente.Location = New System.Drawing.Point(23, 137)
        Me.lblcliente.Name = "lblcliente"
        Me.lblcliente.Size = New System.Drawing.Size(39, 13)
        Me.lblcliente.TabIndex = 31
        Me.lblcliente.Text = "Cliente"
        '
        'lblmarca
        '
        Me.lblmarca.AutoSize = True
        Me.lblmarca.Location = New System.Drawing.Point(23, 175)
        Me.lblmarca.Name = "lblmarca"
        Me.lblmarca.Size = New System.Drawing.Size(37, 13)
        Me.lblmarca.TabIndex = 32
        Me.lblmarca.Text = "Marca"
        '
        'lblmodelo
        '
        Me.lblmodelo.AutoSize = True
        Me.lblmodelo.Location = New System.Drawing.Point(23, 213)
        Me.lblmodelo.Name = "lblmodelo"
        Me.lblmodelo.Size = New System.Drawing.Size(42, 13)
        Me.lblmodelo.TabIndex = 33
        Me.lblmodelo.Text = "Modelo"
        '
        'lbl_cliente
        '
        Me.lbl_cliente.AutoSize = True
        Me.lbl_cliente.Location = New System.Drawing.Point(134, 137)
        Me.lbl_cliente.Name = "lbl_cliente"
        Me.lbl_cliente.Size = New System.Drawing.Size(54, 13)
        Me.lbl_cliente.TabIndex = 34
        Me.lbl_cliente.Text = "%cliente%"
        Me.lbl_cliente.Visible = False
        '
        'lbl_marca
        '
        Me.lbl_marca.AutoSize = True
        Me.lbl_marca.Location = New System.Drawing.Point(134, 169)
        Me.lbl_marca.Name = "lbl_marca"
        Me.lbl_marca.Size = New System.Drawing.Size(52, 13)
        Me.lbl_marca.TabIndex = 35
        Me.lbl_marca.Text = "%marca%"
        Me.lbl_marca.Visible = False
        '
        'lbl_modelo
        '
        Me.lbl_modelo.AutoSize = True
        Me.lbl_modelo.Location = New System.Drawing.Point(134, 201)
        Me.lbl_modelo.Name = "lbl_modelo"
        Me.lbl_modelo.Size = New System.Drawing.Size(57, 13)
        Me.lbl_modelo.TabIndex = 36
        Me.lbl_modelo.Text = "%modelo%"
        Me.lbl_modelo.Visible = False
        '
        'cmd_add_caso_item
        '
        Me.cmd_add_caso_item.Location = New System.Drawing.Point(444, 678)
        Me.cmd_add_caso_item.Name = "cmd_add_caso_item"
        Me.cmd_add_caso_item.Size = New System.Drawing.Size(129, 29)
        Me.cmd_add_caso_item.TabIndex = 8
        Me.cmd_add_caso_item.Text = "Añadir item"
        Me.cmd_add_caso_item.UseVisualStyleBackColor = True
        '
        'txt_total
        '
        Me.txt_total.Location = New System.Drawing.Point(806, 681)
        Me.txt_total.Name = "txt_total"
        Me.txt_total.Size = New System.Drawing.Size(62, 20)
        Me.txt_total.TabIndex = 11
        '
        'lbl_total
        '
        Me.lbl_total.AutoSize = True
        Me.lbl_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total.Location = New System.Drawing.Point(750, 681)
        Me.lbl_total.Name = "lbl_total"
        Me.lbl_total.Size = New System.Drawing.Size(54, 20)
        Me.lbl_total.TabIndex = 57
        Me.lbl_total.Text = "Total:"
        '
        'lsv_item
        '
        Me.lsv_item.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lsv_item.HideSelection = False
        Me.lsv_item.Location = New System.Drawing.Point(444, 52)
        Me.lsv_item.Margin = New System.Windows.Forms.Padding(2)
        Me.lsv_item.Name = "lsv_item"
        Me.lsv_item.Size = New System.Drawing.Size(425, 560)
        Me.lsv_item.TabIndex = 13
        Me.lsv_item.UseCompatibleStateImageBehavior = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditarToolStripMenuItem, Me.BorrarToolStripMenuItem, Me.RecargarPrecioToolStripMenuItem, Me.ImportarItemsDeUnPedidoToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(226, 92)
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.EditarToolStripMenuItem.Text = "Editar"
        '
        'BorrarToolStripMenuItem
        '
        Me.BorrarToolStripMenuItem.Name = "BorrarToolStripMenuItem"
        Me.BorrarToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.BorrarToolStripMenuItem.Text = "Borrar"
        '
        'RecargarPrecioToolStripMenuItem
        '
        Me.RecargarPrecioToolStripMenuItem.Name = "RecargarPrecioToolStripMenuItem"
        Me.RecargarPrecioToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.RecargarPrecioToolStripMenuItem.Text = "Recargar precio"
        '
        'ImportarItemsDeUnPedidoToolStripMenuItem
        '
        Me.ImportarItemsDeUnPedidoToolStripMenuItem.Name = "ImportarItemsDeUnPedidoToolStripMenuItem"
        Me.ImportarItemsDeUnPedidoToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.ImportarItemsDeUnPedidoToolStripMenuItem.Text = "Importar items de un pedido"
        '
        'txt_proximocambio
        '
        Me.txt_proximocambio.Location = New System.Drawing.Point(133, 283)
        Me.txt_proximocambio.Name = "txt_proximocambio"
        Me.txt_proximocambio.Size = New System.Drawing.Size(259, 20)
        Me.txt_proximocambio.TabIndex = 3
        '
        'lbl_proximocambio
        '
        Me.lbl_proximocambio.AutoSize = True
        Me.lbl_proximocambio.Location = New System.Drawing.Point(23, 289)
        Me.lbl_proximocambio.Name = "lbl_proximocambio"
        Me.lbl_proximocambio.Size = New System.Drawing.Size(81, 13)
        Me.lbl_proximocambio.TabIndex = 59
        Me.lbl_proximocambio.Text = "Próximo cambio"
        '
        'txt_notas
        '
        Me.txt_notas.Location = New System.Drawing.Point(133, 564)
        Me.txt_notas.Multiline = True
        Me.txt_notas.Name = "txt_notas"
        Me.txt_notas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_notas.Size = New System.Drawing.Size(259, 91)
        Me.txt_notas.TabIndex = 7
        '
        'lbl_notas
        '
        Me.lbl_notas.AutoSize = True
        Me.lbl_notas.Location = New System.Drawing.Point(23, 564)
        Me.lbl_notas.Name = "lbl_notas"
        Me.lbl_notas.Size = New System.Drawing.Size(35, 13)
        Me.lbl_notas.TabIndex = 61
        Me.lbl_notas.Text = "Notas"
        '
        'psearch_auto
        '
        Me.psearch_auto.Image = Global.DROil.My.Resources.Resources.iconoLupa
        Me.psearch_auto.Location = New System.Drawing.Point(398, 59)
        Me.psearch_auto.Name = "psearch_auto"
        Me.psearch_auto.Size = New System.Drawing.Size(22, 22)
        Me.psearch_auto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_auto.TabIndex = 27
        Me.psearch_auto.TabStop = False
        '
        'cmd_recargaprecios
        '
        Me.cmd_recargaprecios.Location = New System.Drawing.Point(754, 717)
        Me.cmd_recargaprecios.Name = "cmd_recargaprecios"
        Me.cmd_recargaprecios.Size = New System.Drawing.Size(114, 29)
        Me.cmd_recargaprecios.TabIndex = 10
        Me.cmd_recargaprecios.Text = "Recargar precios"
        Me.cmd_recargaprecios.UseVisualStyleBackColor = True
        '
        'psearch_tipocaso
        '
        Me.psearch_tipocaso.Image = Global.DROil.My.Resources.Resources.iconoLupa
        Me.psearch_tipocaso.Location = New System.Drawing.Point(398, 96)
        Me.psearch_tipocaso.Name = "psearch_tipocaso"
        Me.psearch_tipocaso.Size = New System.Drawing.Size(22, 22)
        Me.psearch_tipocaso.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_tipocaso.TabIndex = 64
        Me.psearch_tipocaso.TabStop = False
        '
        'lbl_tipocaso
        '
        Me.lbl_tipocaso.AutoSize = True
        Me.lbl_tipocaso.Location = New System.Drawing.Point(23, 99)
        Me.lbl_tipocaso.Name = "lbl_tipocaso"
        Me.lbl_tipocaso.Size = New System.Drawing.Size(54, 13)
        Me.lbl_tipocaso.TabIndex = 63
        Me.lbl_tipocaso.Text = "Tipo caso"
        '
        'cmb_tipocaso
        '
        Me.cmb_tipocaso.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_tipocaso.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_tipocaso.DisplayMember = "id_tipo"
        Me.cmb_tipocaso.FormattingEnabled = True
        Me.cmb_tipocaso.Location = New System.Drawing.Point(134, 97)
        Me.cmb_tipocaso.Name = "cmb_tipocaso"
        Me.cmb_tipocaso.Size = New System.Drawing.Size(259, 21)
        Me.cmb_tipocaso.TabIndex = 1
        Me.cmb_tipocaso.ValueMember = "id_tipo"
        '
        'TiposcasosBindingSource
        '
        Me.TiposcasosBindingSource.DataMember = "tipos_casos"
        '
        'cmb_patente
        '
        Me.cmb_patente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_patente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_patente.FormattingEnabled = True
        Me.cmb_patente.Location = New System.Drawing.Point(134, 57)
        Me.cmb_patente.Name = "cmb_patente"
        Me.cmb_patente.Size = New System.Drawing.Size(258, 21)
        Me.cmb_patente.TabIndex = 0
        '
        'cmb_condicion
        '
        Me.cmb_condicion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_condicion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_condicion.FormattingEnabled = True
        Me.cmb_condicion.Location = New System.Drawing.Point(133, 322)
        Me.cmb_condicion.Name = "cmb_condicion"
        Me.cmb_condicion.Size = New System.Drawing.Size(258, 21)
        Me.cmb_condicion.TabIndex = 4
        '
        'cmb_descuento
        '
        Me.cmb_descuento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_descuento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_descuento.DisplayMember = "id_tipo"
        Me.cmb_descuento.FormattingEnabled = True
        Me.cmb_descuento.Location = New System.Drawing.Point(133, 362)
        Me.cmb_descuento.Name = "cmb_descuento"
        Me.cmb_descuento.Size = New System.Drawing.Size(259, 21)
        Me.cmb_descuento.TabIndex = 5
        Me.cmb_descuento.ValueMember = "id_tipo"
        '
        'psearch_descuento
        '
        Me.psearch_descuento.Image = Global.DROil.My.Resources.Resources.iconoLupa
        Me.psearch_descuento.Location = New System.Drawing.Point(398, 362)
        Me.psearch_descuento.Name = "psearch_descuento"
        Me.psearch_descuento.Size = New System.Drawing.Size(22, 22)
        Me.psearch_descuento.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_descuento.TabIndex = 72
        Me.psearch_descuento.TabStop = False
        '
        'lbl_descuento
        '
        Me.lbl_descuento.AutoSize = True
        Me.lbl_descuento.Location = New System.Drawing.Point(23, 365)
        Me.lbl_descuento.Name = "lbl_descuento"
        Me.lbl_descuento.Size = New System.Drawing.Size(59, 13)
        Me.lbl_descuento.TabIndex = 71
        Me.lbl_descuento.Text = "Descuento"
        '
        'psearch_condicion
        '
        Me.psearch_condicion.Image = Global.DROil.My.Resources.Resources.iconoLupa
        Me.psearch_condicion.Location = New System.Drawing.Point(398, 321)
        Me.psearch_condicion.Name = "psearch_condicion"
        Me.psearch_condicion.Size = New System.Drawing.Size(22, 22)
        Me.psearch_condicion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_condicion.TabIndex = 70
        Me.psearch_condicion.TabStop = False
        '
        'lbl_condicion
        '
        Me.lbl_condicion.AutoSize = True
        Me.lbl_condicion.Location = New System.Drawing.Point(23, 327)
        Me.lbl_condicion.Name = "lbl_condicion"
        Me.lbl_condicion.Size = New System.Drawing.Size(99, 13)
        Me.lbl_condicion.TabIndex = 69
        Me.lbl_condicion.Text = "Condición de venta"
        '
        'txt_subTotal
        '
        Me.txt_subTotal.Location = New System.Drawing.Point(663, 681)
        Me.txt_subTotal.Name = "txt_subTotal"
        Me.txt_subTotal.ReadOnly = True
        Me.txt_subTotal.Size = New System.Drawing.Size(86, 20)
        Me.txt_subTotal.TabIndex = 82
        '
        'lbl_subTotal
        '
        Me.lbl_subTotal.AutoSize = True
        Me.lbl_subTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_subTotal.Location = New System.Drawing.Point(579, 681)
        Me.lbl_subTotal.Name = "lbl_subTotal"
        Me.lbl_subTotal.Size = New System.Drawing.Size(82, 20)
        Me.lbl_subTotal.TabIndex = 83
        Me.lbl_subTotal.Text = "Subtotal:"
        '
        'cmb_caja
        '
        Me.cmb_caja.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_caja.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_caja.DisplayMember = "id_tipo"
        Me.cmb_caja.FormattingEnabled = True
        Me.cmb_caja.Location = New System.Drawing.Point(133, 402)
        Me.cmb_caja.Name = "cmb_caja"
        Me.cmb_caja.Size = New System.Drawing.Size(259, 21)
        Me.cmb_caja.TabIndex = 6
        Me.cmb_caja.ValueMember = "id_tipo"
        '
        'psearch_caja
        '
        Me.psearch_caja.Image = Global.DROil.My.Resources.Resources.iconoLupa
        Me.psearch_caja.Location = New System.Drawing.Point(398, 402)
        Me.psearch_caja.Name = "psearch_caja"
        Me.psearch_caja.Size = New System.Drawing.Size(22, 22)
        Me.psearch_caja.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_caja.TabIndex = 86
        Me.psearch_caja.TabStop = False
        '
        'lbl_caja
        '
        Me.lbl_caja.AutoSize = True
        Me.lbl_caja.Location = New System.Drawing.Point(23, 403)
        Me.lbl_caja.Name = "lbl_caja"
        Me.lbl_caja.Size = New System.Drawing.Size(28, 13)
        Me.lbl_caja.TabIndex = 85
        Me.lbl_caja.Text = "Caja"
        '
        'chk_pagoCombinado
        '
        Me.chk_pagoCombinado.AutoSize = True
        Me.chk_pagoCombinado.Enabled = False
        Me.chk_pagoCombinado.Location = New System.Drawing.Point(26, 660)
        Me.chk_pagoCombinado.Name = "chk_pagoCombinado"
        Me.chk_pagoCombinado.Size = New System.Drawing.Size(106, 17)
        Me.chk_pagoCombinado.TabIndex = 11
        Me.chk_pagoCombinado.Text = "Pago combinado"
        Me.chk_pagoCombinado.UseVisualStyleBackColor = True
        '
        'txt_cargaEAN
        '
        Me.txt_cargaEAN.Location = New System.Drawing.Point(563, 631)
        Me.txt_cargaEAN.Name = "txt_cargaEAN"
        Me.txt_cargaEAN.Size = New System.Drawing.Size(305, 20)
        Me.txt_cargaEAN.TabIndex = 9
        '
        'lbl_cargaEAN
        '
        Me.lbl_cargaEAN.AutoSize = True
        Me.lbl_cargaEAN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_cargaEAN.ForeColor = System.Drawing.Color.Red
        Me.lbl_cargaEAN.Location = New System.Drawing.Point(441, 634)
        Me.lbl_cargaEAN.Name = "lbl_cargaEAN"
        Me.lbl_cargaEAN.Size = New System.Drawing.Size(116, 13)
        Me.lbl_cargaEAN.TabIndex = 91
        Me.lbl_cargaEAN.Text = "Carga rápida (EAN)"
        '
        'lbl_yaFacturado
        '
        Me.lbl_yaFacturado.AutoSize = True
        Me.lbl_yaFacturado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_yaFacturado.ForeColor = System.Drawing.Color.Red
        Me.lbl_yaFacturado.Location = New System.Drawing.Point(223, 754)
        Me.lbl_yaFacturado.Name = "lbl_yaFacturado"
        Me.lbl_yaFacturado.Size = New System.Drawing.Size(434, 13)
        Me.lbl_yaFacturado.TabIndex = 92
        Me.lbl_yaFacturado.Text = "ESTE PEDIDO YA HA SIDO FACTURADO Y NO PUEDE SER MODIFICADO"
        Me.lbl_yaFacturado.Visible = False
        '
        'cmb_vendedor
        '
        Me.cmb_vendedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_vendedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_vendedor.FormattingEnabled = True
        Me.cmb_vendedor.Location = New System.Drawing.Point(133, 440)
        Me.cmb_vendedor.Name = "cmb_vendedor"
        Me.cmb_vendedor.Size = New System.Drawing.Size(259, 21)
        Me.cmb_vendedor.TabIndex = 98
        '
        'psearch_vendedor
        '
        Me.psearch_vendedor.Image = Global.DROil.My.Resources.Resources.iconoLupa
        Me.psearch_vendedor.Location = New System.Drawing.Point(398, 440)
        Me.psearch_vendedor.Name = "psearch_vendedor"
        Me.psearch_vendedor.Size = New System.Drawing.Size(22, 22)
        Me.psearch_vendedor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_vendedor.TabIndex = 100
        Me.psearch_vendedor.TabStop = False
        '
        'lbl_vendedor
        '
        Me.lbl_vendedor.AutoSize = True
        Me.lbl_vendedor.Location = New System.Drawing.Point(23, 441)
        Me.lbl_vendedor.Name = "lbl_vendedor"
        Me.lbl_vendedor.Size = New System.Drawing.Size(53, 13)
        Me.lbl_vendedor.TabIndex = 99
        Me.lbl_vendedor.Text = "Vendedor"
        '
        'cmb_mecanico
        '
        Me.cmb_mecanico.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_mecanico.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_mecanico.FormattingEnabled = True
        Me.cmb_mecanico.Location = New System.Drawing.Point(132, 480)
        Me.cmb_mecanico.Name = "cmb_mecanico"
        Me.cmb_mecanico.Size = New System.Drawing.Size(259, 21)
        Me.cmb_mecanico.TabIndex = 101
        '
        'psearch_mecanico
        '
        Me.psearch_mecanico.Image = Global.DROil.My.Resources.Resources.iconoLupa
        Me.psearch_mecanico.Location = New System.Drawing.Point(397, 480)
        Me.psearch_mecanico.Name = "psearch_mecanico"
        Me.psearch_mecanico.Size = New System.Drawing.Size(22, 22)
        Me.psearch_mecanico.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_mecanico.TabIndex = 103
        Me.psearch_mecanico.TabStop = False
        '
        'lbl_mecanico
        '
        Me.lbl_mecanico.AutoSize = True
        Me.lbl_mecanico.Location = New System.Drawing.Point(22, 479)
        Me.lbl_mecanico.Name = "lbl_mecanico"
        Me.lbl_mecanico.Size = New System.Drawing.Size(54, 13)
        Me.lbl_mecanico.TabIndex = 102
        Me.lbl_mecanico.Text = "Mecánico"
        '
        'cmb_estadoPedido
        '
        Me.cmb_estadoPedido.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_estadoPedido.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_estadoPedido.FormattingEnabled = True
        Me.cmb_estadoPedido.Location = New System.Drawing.Point(132, 520)
        Me.cmb_estadoPedido.Name = "cmb_estadoPedido"
        Me.cmb_estadoPedido.Size = New System.Drawing.Size(259, 21)
        Me.cmb_estadoPedido.TabIndex = 104
        '
        'psearch_estadoPedido
        '
        Me.psearch_estadoPedido.Image = Global.DROil.My.Resources.Resources.iconoLupa
        Me.psearch_estadoPedido.Location = New System.Drawing.Point(397, 520)
        Me.psearch_estadoPedido.Name = "psearch_estadoPedido"
        Me.psearch_estadoPedido.Size = New System.Drawing.Size(22, 22)
        Me.psearch_estadoPedido.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_estadoPedido.TabIndex = 106
        Me.psearch_estadoPedido.TabStop = False
        '
        'lbl_estado
        '
        Me.lbl_estado.AutoSize = True
        Me.lbl_estado.Location = New System.Drawing.Point(21, 517)
        Me.lbl_estado.Name = "lbl_estado"
        Me.lbl_estado.Size = New System.Drawing.Size(40, 13)
        Me.lbl_estado.TabIndex = 105
        Me.lbl_estado.Text = "Estado"
        '
        'chk_imprimirOrden
        '
        Me.chk_imprimirOrden.AutoSize = True
        Me.chk_imprimirOrden.Checked = True
        Me.chk_imprimirOrden.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_imprimirOrden.Location = New System.Drawing.Point(26, 729)
        Me.chk_imprimirOrden.Name = "chk_imprimirOrden"
        Me.chk_imprimirOrden.Size = New System.Drawing.Size(191, 17)
        Me.chk_imprimirOrden.TabIndex = 107
        Me.chk_imprimirOrden.Text = "Imprimir orden de trabajo al guardar"
        Me.chk_imprimirOrden.UseVisualStyleBackColor = True
        '
        'add_caso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 825)
        Me.Controls.Add(Me.chk_imprimirOrden)
        Me.Controls.Add(Me.cmb_estadoPedido)
        Me.Controls.Add(Me.psearch_estadoPedido)
        Me.Controls.Add(Me.lbl_estado)
        Me.Controls.Add(Me.cmb_mecanico)
        Me.Controls.Add(Me.psearch_mecanico)
        Me.Controls.Add(Me.lbl_mecanico)
        Me.Controls.Add(Me.cmb_vendedor)
        Me.Controls.Add(Me.psearch_vendedor)
        Me.Controls.Add(Me.lbl_vendedor)
        Me.Controls.Add(Me.lbl_yaFacturado)
        Me.Controls.Add(Me.txt_cargaEAN)
        Me.Controls.Add(Me.lbl_cargaEAN)
        Me.Controls.Add(Me.chk_pagoCombinado)
        Me.Controls.Add(Me.cmb_caja)
        Me.Controls.Add(Me.psearch_caja)
        Me.Controls.Add(Me.lbl_caja)
        Me.Controls.Add(Me.txt_subTotal)
        Me.Controls.Add(Me.lbl_subTotal)
        Me.Controls.Add(Me.cmb_condicion)
        Me.Controls.Add(Me.cmb_descuento)
        Me.Controls.Add(Me.psearch_descuento)
        Me.Controls.Add(Me.lbl_descuento)
        Me.Controls.Add(Me.psearch_condicion)
        Me.Controls.Add(Me.lbl_condicion)
        Me.Controls.Add(Me.cmb_patente)
        Me.Controls.Add(Me.cmb_tipocaso)
        Me.Controls.Add(Me.psearch_tipocaso)
        Me.Controls.Add(Me.lbl_tipocaso)
        Me.Controls.Add(Me.cmd_recargaprecios)
        Me.Controls.Add(Me.txt_notas)
        Me.Controls.Add(Me.lbl_notas)
        Me.Controls.Add(Me.txt_proximocambio)
        Me.Controls.Add(Me.lbl_proximocambio)
        Me.Controls.Add(Me.txt_total)
        Me.Controls.Add(Me.lbl_total)
        Me.Controls.Add(Me.lsv_item)
        Me.Controls.Add(Me.cmd_add_caso_item)
        Me.Controls.Add(Me.lbl_modelo)
        Me.Controls.Add(Me.lbl_marca)
        Me.Controls.Add(Me.lbl_cliente)
        Me.Controls.Add(Me.lblmodelo)
        Me.Controls.Add(Me.lblmarca)
        Me.Controls.Add(Me.lblcliente)
        Me.Controls.Add(Me.lbl_date)
        Me.Controls.Add(Me.psearch_auto)
        Me.Controls.Add(Me.txt_km)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.lbl_patente)
        Me.Controls.Add(Me.lbl_km)
        Me.Controls.Add(Me.lbl_fecha)
        Me.Name = "add_caso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar caso"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.psearch_auto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.psearch_tipocaso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TiposcasosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.psearch_descuento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.psearch_condicion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.psearch_caja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.psearch_vendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.psearch_mecanico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.psearch_estadoPedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_fecha As System.Windows.Forms.Label
    Friend WithEvents lbl_km As System.Windows.Forms.Label
    Friend WithEvents lbl_patente As System.Windows.Forms.Label
    Friend WithEvents chk_secuencia As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents txt_km As System.Windows.Forms.TextBox
    Friend WithEvents psearch_auto As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_date As System.Windows.Forms.Label
    Friend WithEvents lblcliente As System.Windows.Forms.Label
    Friend WithEvents lblmarca As System.Windows.Forms.Label
    Friend WithEvents lblmodelo As System.Windows.Forms.Label
    Friend WithEvents lbl_cliente As System.Windows.Forms.Label
    Friend WithEvents lbl_marca As System.Windows.Forms.Label
    Friend WithEvents lbl_modelo As System.Windows.Forms.Label
    Friend WithEvents cmd_add_caso_item As System.Windows.Forms.Button
    Friend WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents lbl_total As System.Windows.Forms.Label
    Friend WithEvents lsv_item As System.Windows.Forms.ListView
    Friend WithEvents txt_proximocambio As System.Windows.Forms.TextBox
    Friend WithEvents lbl_proximocambio As System.Windows.Forms.Label
    Friend WithEvents txt_notas As System.Windows.Forms.TextBox
    Friend WithEvents lbl_notas As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BorrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_recargaprecios As System.Windows.Forms.Button
    Friend WithEvents RecargarPrecioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents psearch_tipocaso As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_tipocaso As System.Windows.Forms.Label
    Friend WithEvents cmb_tipocaso As System.Windows.Forms.ComboBox
    Friend WithEvents TiposcasosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents cmb_patente As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_condicion As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_descuento As System.Windows.Forms.ComboBox
    Friend WithEvents psearch_descuento As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_descuento As System.Windows.Forms.Label
    Friend WithEvents psearch_condicion As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_condicion As System.Windows.Forms.Label
    Friend WithEvents txt_subTotal As System.Windows.Forms.TextBox
    Friend WithEvents lbl_subTotal As System.Windows.Forms.Label
    Friend WithEvents cmb_caja As ComboBox
    Friend WithEvents psearch_caja As PictureBox
    Friend WithEvents lbl_caja As Label
    Friend WithEvents chk_pagoCombinado As System.Windows.Forms.CheckBox
    Friend WithEvents ImportarItemsDeUnPedidoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txt_cargaEAN As TextBox
    Friend WithEvents lbl_cargaEAN As Label
    Friend WithEvents lbl_yaFacturado As Label
    Friend WithEvents cmb_vendedor As ComboBox
    Friend WithEvents psearch_vendedor As PictureBox
    Friend WithEvents lbl_vendedor As Label
    Friend WithEvents cmb_mecanico As ComboBox
    Friend WithEvents psearch_mecanico As PictureBox
    Friend WithEvents lbl_mecanico As Label
    Friend WithEvents cmb_estadoPedido As ComboBox
    Friend WithEvents psearch_estadoPedido As PictureBox
    Friend WithEvents lbl_estado As Label
    Friend WithEvents chk_imprimirOrden As CheckBox
End Class
