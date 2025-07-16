<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class add_presupuesto
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
        Me.cmd_add_item = New System.Windows.Forms.Button()
        Me.lbl_date = New System.Windows.Forms.Label()
        Me.lbl_cliente = New System.Windows.Forms.Label()
        Me.lbl_fecha = New System.Windows.Forms.Label()
        Me.pic_search = New System.Windows.Forms.PictureBox()
        Me.lsv_item = New System.Windows.Forms.ListView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BorrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecargarPrecioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lbl_items = New System.Windows.Forms.Label()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.lbl_total = New System.Windows.Forms.Label()
        Me.txt_total = New System.Windows.Forms.TextBox()
        Me.cmd_recargaprecios = New System.Windows.Forms.Button()
        Me.txt_notas = New System.Windows.Forms.TextBox()
        Me.lbl_notas = New System.Windows.Forms.Label()
        Me.cmb_condicion = New System.Windows.Forms.ComboBox()
        Me.cmb_descuento = New System.Windows.Forms.ComboBox()
        Me.psearch_descuento = New System.Windows.Forms.PictureBox()
        Me.lbl_descuento = New System.Windows.Forms.Label()
        Me.psearch_condicion = New System.Windows.Forms.PictureBox()
        Me.lbl_condicion = New System.Windows.Forms.Label()
        Me.cmb_cliente = New System.Windows.Forms.ComboBox()
        Me.txt_subTotal = New System.Windows.Forms.TextBox()
        Me.lbl_subTotal = New System.Windows.Forms.Label()
        Me.cmb_caja = New System.Windows.Forms.ComboBox()
        Me.psearch_caja = New System.Windows.Forms.PictureBox()
        Me.lbl_caja = New System.Windows.Forms.Label()
        Me.chk_pagoCombinado = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.lbl_cargaEAN = New System.Windows.Forms.Label()
        Me.txt_cargaEAN = New System.Windows.Forms.TextBox()
        Me.lbl_yaFacturado = New System.Windows.Forms.Label()
        CType(Me.pic_search, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.psearch_descuento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.psearch_condicion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.psearch_caja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmd_add_item
        '
        Me.cmd_add_item.Location = New System.Drawing.Point(12, 297)
        Me.cmd_add_item.Name = "cmd_add_item"
        Me.cmd_add_item.Size = New System.Drawing.Size(69, 22)
        Me.cmd_add_item.TabIndex = 2
        Me.cmd_add_item.Text = "Añadir item"
        Me.cmd_add_item.UseVisualStyleBackColor = True
        '
        'lbl_date
        '
        Me.lbl_date.AutoSize = True
        Me.lbl_date.Location = New System.Drawing.Point(12, 11)
        Me.lbl_date.Name = "lbl_date"
        Me.lbl_date.Size = New System.Drawing.Size(50, 13)
        Me.lbl_date.TabIndex = 49
        Me.lbl_date.Text = "%fecha%"
        '
        'lbl_cliente
        '
        Me.lbl_cliente.AutoSize = True
        Me.lbl_cliente.Location = New System.Drawing.Point(12, 47)
        Me.lbl_cliente.Name = "lbl_cliente"
        Me.lbl_cliente.Size = New System.Drawing.Size(39, 13)
        Me.lbl_cliente.TabIndex = 41
        Me.lbl_cliente.Text = "Cliente"
        '
        'lbl_fecha
        '
        Me.lbl_fecha.AutoSize = True
        Me.lbl_fecha.Location = New System.Drawing.Point(12, 11)
        Me.lbl_fecha.Name = "lbl_fecha"
        Me.lbl_fecha.Size = New System.Drawing.Size(40, 13)
        Me.lbl_fecha.TabIndex = 38
        Me.lbl_fecha.Text = "Fecha:"
        '
        'pic_search
        '
        Me.pic_search.Image = Global.DROil.My.Resources.Resources.iconoLupa
        Me.pic_search.Location = New System.Drawing.Point(414, 41)
        Me.pic_search.Name = "pic_search"
        Me.pic_search.Size = New System.Drawing.Size(22, 22)
        Me.pic_search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_search.TabIndex = 48
        Me.pic_search.TabStop = False
        '
        'lsv_item
        '
        Me.lsv_item.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lsv_item.HideSelection = False
        Me.lsv_item.Location = New System.Drawing.Point(12, 72)
        Me.lsv_item.Margin = New System.Windows.Forms.Padding(2)
        Me.lsv_item.Name = "lsv_item"
        Me.lsv_item.Size = New System.Drawing.Size(421, 216)
        Me.lsv_item.TabIndex = 1
        Me.lsv_item.UseCompatibleStateImageBehavior = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditarToolStripMenuItem, Me.BorrarToolStripMenuItem, Me.RecargarPrecioToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(157, 70)
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.EditarToolStripMenuItem.Text = "Editar"
        '
        'BorrarToolStripMenuItem
        '
        Me.BorrarToolStripMenuItem.Name = "BorrarToolStripMenuItem"
        Me.BorrarToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.BorrarToolStripMenuItem.Text = "Borrar"
        '
        'RecargarPrecioToolStripMenuItem
        '
        Me.RecargarPrecioToolStripMenuItem.Name = "RecargarPrecioToolStripMenuItem"
        Me.RecargarPrecioToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.RecargarPrecioToolStripMenuItem.Text = "Recargar precio"
        '
        'lbl_items
        '
        Me.lbl_items.AutoSize = True
        Me.lbl_items.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_items.Location = New System.Drawing.Point(188, 72)
        Me.lbl_items.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_items.Name = "lbl_items"
        Me.lbl_items.Size = New System.Drawing.Size(59, 24)
        Me.lbl_items.TabIndex = 51
        Me.lbl_items.Text = "Items"
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Location = New System.Drawing.Point(15, 701)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(108, 17)
        Me.chk_secuencia.TabIndex = 11
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        '
        'lbl_total
        '
        Me.lbl_total.AutoSize = True
        Me.lbl_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total.Location = New System.Drawing.Point(289, 295)
        Me.lbl_total.Name = "lbl_total"
        Me.lbl_total.Size = New System.Drawing.Size(54, 20)
        Me.lbl_total.TabIndex = 53
        Me.lbl_total.Text = "Total:"
        '
        'txt_total
        '
        Me.txt_total.Location = New System.Drawing.Point(346, 295)
        Me.txt_total.Name = "txt_total"
        Me.txt_total.Size = New System.Drawing.Size(86, 20)
        Me.txt_total.TabIndex = 3
        '
        'cmd_recargaprecios
        '
        Me.cmd_recargaprecios.Location = New System.Drawing.Point(292, 319)
        Me.cmd_recargaprecios.Name = "cmd_recargaprecios"
        Me.cmd_recargaprecios.Size = New System.Drawing.Size(140, 22)
        Me.cmd_recargaprecios.TabIndex = 4
        Me.cmd_recargaprecios.Text = "Recargar precios"
        Me.cmd_recargaprecios.UseVisualStyleBackColor = True
        '
        'txt_notas
        '
        Me.txt_notas.Location = New System.Drawing.Point(123, 562)
        Me.txt_notas.Multiline = True
        Me.txt_notas.Name = "txt_notas"
        Me.txt_notas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_notas.Size = New System.Drawing.Size(309, 91)
        Me.txt_notas.TabIndex = 9
        '
        'lbl_notas
        '
        Me.lbl_notas.AutoSize = True
        Me.lbl_notas.Location = New System.Drawing.Point(12, 564)
        Me.lbl_notas.Name = "lbl_notas"
        Me.lbl_notas.Size = New System.Drawing.Size(35, 13)
        Me.lbl_notas.TabIndex = 70
        Me.lbl_notas.Text = "Notas"
        '
        'cmb_condicion
        '
        Me.cmb_condicion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_condicion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_condicion.FormattingEnabled = True
        Me.cmb_condicion.Location = New System.Drawing.Point(123, 435)
        Me.cmb_condicion.Name = "cmb_condicion"
        Me.cmb_condicion.Size = New System.Drawing.Size(281, 21)
        Me.cmb_condicion.TabIndex = 6
        '
        'cmb_descuento
        '
        Me.cmb_descuento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_descuento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_descuento.DisplayMember = "id_tipo"
        Me.cmb_descuento.FormattingEnabled = True
        Me.cmb_descuento.Location = New System.Drawing.Point(123, 474)
        Me.cmb_descuento.Name = "cmb_descuento"
        Me.cmb_descuento.Size = New System.Drawing.Size(281, 21)
        Me.cmb_descuento.TabIndex = 7
        Me.cmb_descuento.ValueMember = "id_tipo"
        '
        'psearch_descuento
        '
        Me.psearch_descuento.Image = Global.DROil.My.Resources.Resources.iconoLupa
        Me.psearch_descuento.Location = New System.Drawing.Point(410, 473)
        Me.psearch_descuento.Name = "psearch_descuento"
        Me.psearch_descuento.Size = New System.Drawing.Size(22, 22)
        Me.psearch_descuento.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_descuento.TabIndex = 78
        Me.psearch_descuento.TabStop = False
        '
        'lbl_descuento
        '
        Me.lbl_descuento.AutoSize = True
        Me.lbl_descuento.Location = New System.Drawing.Point(12, 478)
        Me.lbl_descuento.Name = "lbl_descuento"
        Me.lbl_descuento.Size = New System.Drawing.Size(59, 13)
        Me.lbl_descuento.TabIndex = 77
        Me.lbl_descuento.Text = "Descuento"
        '
        'psearch_condicion
        '
        Me.psearch_condicion.Image = Global.DROil.My.Resources.Resources.iconoLupa
        Me.psearch_condicion.Location = New System.Drawing.Point(410, 434)
        Me.psearch_condicion.Name = "psearch_condicion"
        Me.psearch_condicion.Size = New System.Drawing.Size(22, 22)
        Me.psearch_condicion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_condicion.TabIndex = 76
        Me.psearch_condicion.TabStop = False
        '
        'lbl_condicion
        '
        Me.lbl_condicion.AutoSize = True
        Me.lbl_condicion.Location = New System.Drawing.Point(12, 441)
        Me.lbl_condicion.Name = "lbl_condicion"
        Me.lbl_condicion.Size = New System.Drawing.Size(99, 13)
        Me.lbl_condicion.TabIndex = 75
        Me.lbl_condicion.Text = "Condición de venta"
        '
        'cmb_cliente
        '
        Me.cmb_cliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_cliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_cliente.FormattingEnabled = True
        Me.cmb_cliente.Location = New System.Drawing.Point(123, 39)
        Me.cmb_cliente.Name = "cmb_cliente"
        Me.cmb_cliente.Size = New System.Drawing.Size(281, 21)
        Me.cmb_cliente.TabIndex = 0
        '
        'txt_subTotal
        '
        Me.txt_subTotal.Location = New System.Drawing.Point(187, 295)
        Me.txt_subTotal.Name = "txt_subTotal"
        Me.txt_subTotal.ReadOnly = True
        Me.txt_subTotal.Size = New System.Drawing.Size(86, 20)
        Me.txt_subTotal.TabIndex = 80
        '
        'lbl_subTotal
        '
        Me.lbl_subTotal.AutoSize = True
        Me.lbl_subTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_subTotal.Location = New System.Drawing.Point(103, 295)
        Me.lbl_subTotal.Name = "lbl_subTotal"
        Me.lbl_subTotal.Size = New System.Drawing.Size(82, 20)
        Me.lbl_subTotal.TabIndex = 81
        Me.lbl_subTotal.Text = "Subtotal:"
        '
        'cmb_caja
        '
        Me.cmb_caja.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_caja.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_caja.DisplayMember = "id_tipo"
        Me.cmb_caja.FormattingEnabled = True
        Me.cmb_caja.Location = New System.Drawing.Point(123, 513)
        Me.cmb_caja.Name = "cmb_caja"
        Me.cmb_caja.Size = New System.Drawing.Size(281, 21)
        Me.cmb_caja.TabIndex = 8
        Me.cmb_caja.ValueMember = "id_tipo"
        '
        'psearch_caja
        '
        Me.psearch_caja.Image = Global.DROil.My.Resources.Resources.iconoLupa
        Me.psearch_caja.Location = New System.Drawing.Point(410, 512)
        Me.psearch_caja.Name = "psearch_caja"
        Me.psearch_caja.Size = New System.Drawing.Size(22, 22)
        Me.psearch_caja.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_caja.TabIndex = 85
        Me.psearch_caja.TabStop = False
        '
        'lbl_caja
        '
        Me.lbl_caja.AutoSize = True
        Me.lbl_caja.Location = New System.Drawing.Point(12, 515)
        Me.lbl_caja.Name = "lbl_caja"
        Me.lbl_caja.Size = New System.Drawing.Size(28, 13)
        Me.lbl_caja.TabIndex = 84
        Me.lbl_caja.Text = "Caja"
        '
        'chk_pagoCombinado
        '
        Me.chk_pagoCombinado.AutoSize = True
        Me.chk_pagoCombinado.Enabled = False
        Me.chk_pagoCombinado.Location = New System.Drawing.Point(15, 665)
        Me.chk_pagoCombinado.Name = "chk_pagoCombinado"
        Me.chk_pagoCombinado.Size = New System.Drawing.Size(106, 17)
        Me.chk_pagoCombinado.TabIndex = 10
        Me.chk_pagoCombinado.Text = "Pago combinado"
        Me.ToolTip1.SetToolTip(Me.chk_pagoCombinado, "Seleccione esta opción si eligió una tarjeta pero no paga la totalidad con ella")
        Me.chk_pagoCombinado.UseVisualStyleBackColor = True
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(236, 749)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 13
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(134, 749)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 12
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'lbl_cargaEAN
        '
        Me.lbl_cargaEAN.AutoSize = True
        Me.lbl_cargaEAN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_cargaEAN.ForeColor = System.Drawing.Color.Red
        Me.lbl_cargaEAN.Location = New System.Drawing.Point(12, 378)
        Me.lbl_cargaEAN.Name = "lbl_cargaEAN"
        Me.lbl_cargaEAN.Size = New System.Drawing.Size(116, 13)
        Me.lbl_cargaEAN.TabIndex = 89
        Me.lbl_cargaEAN.Text = "Carga rápida (EAN)"
        '
        'txt_cargaEAN
        '
        Me.txt_cargaEAN.Location = New System.Drawing.Point(135, 375)
        Me.txt_cargaEAN.Name = "txt_cargaEAN"
        Me.txt_cargaEAN.Size = New System.Drawing.Size(269, 20)
        Me.txt_cargaEAN.TabIndex = 5
        '
        'lbl_yaFacturado
        '
        Me.lbl_yaFacturado.AutoSize = True
        Me.lbl_yaFacturado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_yaFacturado.ForeColor = System.Drawing.Color.Red
        Me.lbl_yaFacturado.Location = New System.Drawing.Point(6, 726)
        Me.lbl_yaFacturado.Name = "lbl_yaFacturado"
        Me.lbl_yaFacturado.Size = New System.Drawing.Size(434, 13)
        Me.lbl_yaFacturado.TabIndex = 93
        Me.lbl_yaFacturado.Text = "ESTE PEDIDO YA HA SIDO FACTURADO Y NO PUEDE SER MODIFICADO"
        Me.lbl_yaFacturado.Visible = False
        '
        'add_presupuesto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(444, 788)
        Me.Controls.Add(Me.lbl_yaFacturado)
        Me.Controls.Add(Me.txt_cargaEAN)
        Me.Controls.Add(Me.lbl_cargaEAN)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.chk_pagoCombinado)
        Me.Controls.Add(Me.cmb_caja)
        Me.Controls.Add(Me.psearch_caja)
        Me.Controls.Add(Me.lbl_caja)
        Me.Controls.Add(Me.txt_subTotal)
        Me.Controls.Add(Me.lbl_subTotal)
        Me.Controls.Add(Me.cmb_cliente)
        Me.Controls.Add(Me.cmb_condicion)
        Me.Controls.Add(Me.cmb_descuento)
        Me.Controls.Add(Me.psearch_descuento)
        Me.Controls.Add(Me.lbl_descuento)
        Me.Controls.Add(Me.psearch_condicion)
        Me.Controls.Add(Me.lbl_condicion)
        Me.Controls.Add(Me.txt_notas)
        Me.Controls.Add(Me.lbl_notas)
        Me.Controls.Add(Me.cmd_recargaprecios)
        Me.Controls.Add(Me.txt_total)
        Me.Controls.Add(Me.lbl_total)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_add_item)
        Me.Controls.Add(Me.lbl_date)
        Me.Controls.Add(Me.pic_search)
        Me.Controls.Add(Me.lbl_cliente)
        Me.Controls.Add(Me.lbl_fecha)
        Me.Controls.Add(Me.lsv_item)
        Me.Controls.Add(Me.lbl_items)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "add_presupuesto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Carga de pedido"
        CType(Me.pic_search, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.psearch_descuento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.psearch_condicion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.psearch_caja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmd_add_item As System.Windows.Forms.Button
    Friend WithEvents lbl_date As System.Windows.Forms.Label
    Friend WithEvents pic_search As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_cliente As System.Windows.Forms.Label
    Friend WithEvents lbl_fecha As System.Windows.Forms.Label
    Friend WithEvents lsv_item As System.Windows.Forms.ListView
    Friend WithEvents lbl_items As System.Windows.Forms.Label
    Friend WithEvents chk_secuencia As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_total As System.Windows.Forms.Label
    Friend WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BorrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_recargaprecios As System.Windows.Forms.Button
    Friend WithEvents RecargarPrecioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txt_notas As System.Windows.Forms.TextBox
    Friend WithEvents lbl_notas As System.Windows.Forms.Label
    Friend WithEvents cmb_condicion As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_descuento As System.Windows.Forms.ComboBox
    Friend WithEvents psearch_descuento As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_descuento As System.Windows.Forms.Label
    Friend WithEvents psearch_condicion As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_condicion As System.Windows.Forms.Label
    Friend WithEvents cmb_cliente As System.Windows.Forms.ComboBox
    Friend WithEvents txt_subTotal As System.Windows.Forms.TextBox
    Friend WithEvents lbl_subTotal As System.Windows.Forms.Label
    Friend WithEvents cmb_caja As ComboBox
    Friend WithEvents psearch_caja As PictureBox
    Friend WithEvents lbl_caja As Label
    Friend WithEvents chk_pagoCombinado As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmd_exit As Button
    Friend WithEvents cmd_ok As Button
    Friend WithEvents lbl_cargaEAN As Label
    Friend WithEvents txt_cargaEAN As TextBox
    Friend WithEvents lbl_yaFacturado As Label
End Class
