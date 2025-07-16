<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pre_fe
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
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_emitir = New System.Windows.Forms.Button()
        Me.chk_pagoCombinado = New System.Windows.Forms.CheckBox()
        Me.cmb_caja = New System.Windows.Forms.ComboBox()
        Me.lbl_caja = New System.Windows.Forms.Label()
        Me.txt_subTotal = New System.Windows.Forms.TextBox()
        Me.lbl_subTotal = New System.Windows.Forms.Label()
        Me.cmb_condicion = New System.Windows.Forms.ComboBox()
        Me.cmb_descuento = New System.Windows.Forms.ComboBox()
        Me.lbl_descuento = New System.Windows.Forms.Label()
        Me.lbl_condicion = New System.Windows.Forms.Label()
        Me.txt_notas = New System.Windows.Forms.TextBox()
        Me.lbl_notas = New System.Windows.Forms.Label()
        Me.txt_total = New System.Windows.Forms.TextBox()
        Me.lbl_total = New System.Windows.Forms.Label()
        Me.lbl_date = New System.Windows.Forms.Label()
        Me.lbl_cliente = New System.Windows.Forms.Label()
        Me.lbl_fecha = New System.Windows.Forms.Label()
        Me.dgv_item = New System.Windows.Forms.DataGridView()
        Me.cmb_comprobante = New System.Windows.Forms.ComboBox()
        Me.pic_searchComprobante = New System.Windows.Forms.PictureBox()
        Me.lbl_comprobante = New System.Windows.Forms.Label()
        Me.lbl_items = New System.Windows.Forms.Label()
        Me.txt_impuestos = New System.Windows.Forms.TextBox()
        Me.lbl_impuestos = New System.Windows.Forms.Label()
        Me.chk_remitos = New System.Windows.Forms.CheckBox()
        Me.lbl_noTaxNumber = New System.Windows.Forms.Label()
        CType(Me.pic_searchComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(304, 755)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(133, 51)
        Me.cmd_exit.TabIndex = 103
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_emitir
        '
        Me.cmd_emitir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_emitir.Location = New System.Drawing.Point(153, 755)
        Me.cmd_emitir.Name = "cmd_emitir"
        Me.cmd_emitir.Size = New System.Drawing.Size(133, 51)
        Me.cmd_emitir.TabIndex = 102
        Me.cmd_emitir.Text = "Emitir factura"
        Me.cmd_emitir.UseVisualStyleBackColor = True
        '
        'chk_pagoCombinado
        '
        Me.chk_pagoCombinado.AutoSize = True
        Me.chk_pagoCombinado.Enabled = False
        Me.chk_pagoCombinado.Location = New System.Drawing.Point(14, 705)
        Me.chk_pagoCombinado.Name = "chk_pagoCombinado"
        Me.chk_pagoCombinado.Size = New System.Drawing.Size(106, 17)
        Me.chk_pagoCombinado.TabIndex = 100
        Me.chk_pagoCombinado.Text = "Pago combinado"
        Me.chk_pagoCombinado.UseVisualStyleBackColor = True
        '
        'cmb_caja
        '
        Me.cmb_caja.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_caja.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_caja.DisplayMember = "id_tipo"
        Me.cmb_caja.Enabled = False
        Me.cmb_caja.FormattingEnabled = True
        Me.cmb_caja.Location = New System.Drawing.Point(121, 516)
        Me.cmb_caja.Name = "cmb_caja"
        Me.cmb_caja.Size = New System.Drawing.Size(455, 21)
        Me.cmb_caja.TabIndex = 98
        Me.cmb_caja.ValueMember = "id_tipo"
        '
        'lbl_caja
        '
        Me.lbl_caja.AutoSize = True
        Me.lbl_caja.Location = New System.Drawing.Point(10, 518)
        Me.lbl_caja.Name = "lbl_caja"
        Me.lbl_caja.Size = New System.Drawing.Size(28, 13)
        Me.lbl_caja.TabIndex = 117
        Me.lbl_caja.Text = "Caja"
        '
        'txt_subTotal
        '
        Me.txt_subTotal.Location = New System.Drawing.Point(121, 403)
        Me.txt_subTotal.Name = "txt_subTotal"
        Me.txt_subTotal.ReadOnly = True
        Me.txt_subTotal.Size = New System.Drawing.Size(89, 20)
        Me.txt_subTotal.TabIndex = 115
        '
        'lbl_subTotal
        '
        Me.lbl_subTotal.AutoSize = True
        Me.lbl_subTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_subTotal.Location = New System.Drawing.Point(14, 403)
        Me.lbl_subTotal.Name = "lbl_subTotal"
        Me.lbl_subTotal.Size = New System.Drawing.Size(82, 20)
        Me.lbl_subTotal.TabIndex = 116
        Me.lbl_subTotal.Text = "Subtotal:"
        '
        'cmb_condicion
        '
        Me.cmb_condicion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_condicion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_condicion.Enabled = False
        Me.cmb_condicion.FormattingEnabled = True
        Me.cmb_condicion.Location = New System.Drawing.Point(121, 438)
        Me.cmb_condicion.Name = "cmb_condicion"
        Me.cmb_condicion.Size = New System.Drawing.Size(455, 21)
        Me.cmb_condicion.TabIndex = 96
        '
        'cmb_descuento
        '
        Me.cmb_descuento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_descuento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_descuento.DisplayMember = "id_tipo"
        Me.cmb_descuento.Enabled = False
        Me.cmb_descuento.FormattingEnabled = True
        Me.cmb_descuento.Location = New System.Drawing.Point(121, 477)
        Me.cmb_descuento.Name = "cmb_descuento"
        Me.cmb_descuento.Size = New System.Drawing.Size(455, 21)
        Me.cmb_descuento.TabIndex = 97
        Me.cmb_descuento.ValueMember = "id_tipo"
        '
        'lbl_descuento
        '
        Me.lbl_descuento.AutoSize = True
        Me.lbl_descuento.Location = New System.Drawing.Point(10, 481)
        Me.lbl_descuento.Name = "lbl_descuento"
        Me.lbl_descuento.Size = New System.Drawing.Size(59, 13)
        Me.lbl_descuento.TabIndex = 113
        Me.lbl_descuento.Text = "Descuento"
        '
        'lbl_condicion
        '
        Me.lbl_condicion.AutoSize = True
        Me.lbl_condicion.Location = New System.Drawing.Point(10, 444)
        Me.lbl_condicion.Name = "lbl_condicion"
        Me.lbl_condicion.Size = New System.Drawing.Size(99, 13)
        Me.lbl_condicion.TabIndex = 111
        Me.lbl_condicion.Text = "Condición de venta"
        '
        'txt_notas
        '
        Me.txt_notas.Enabled = False
        Me.txt_notas.Location = New System.Drawing.Point(121, 565)
        Me.txt_notas.Multiline = True
        Me.txt_notas.Name = "txt_notas"
        Me.txt_notas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_notas.Size = New System.Drawing.Size(455, 91)
        Me.txt_notas.TabIndex = 99
        '
        'lbl_notas
        '
        Me.lbl_notas.AutoSize = True
        Me.lbl_notas.Location = New System.Drawing.Point(10, 567)
        Me.lbl_notas.Name = "lbl_notas"
        Me.lbl_notas.Size = New System.Drawing.Size(35, 13)
        Me.lbl_notas.TabIndex = 110
        Me.lbl_notas.Text = "Notas"
        '
        'txt_total
        '
        Me.txt_total.Location = New System.Drawing.Point(490, 403)
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.Size = New System.Drawing.Size(86, 20)
        Me.txt_total.TabIndex = 93
        '
        'lbl_total
        '
        Me.lbl_total.AutoSize = True
        Me.lbl_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total.Location = New System.Drawing.Point(430, 403)
        Me.lbl_total.Name = "lbl_total"
        Me.lbl_total.Size = New System.Drawing.Size(54, 20)
        Me.lbl_total.TabIndex = 109
        Me.lbl_total.Text = "Total:"
        '
        'lbl_date
        '
        Me.lbl_date.AutoSize = True
        Me.lbl_date.Location = New System.Drawing.Point(10, 14)
        Me.lbl_date.Name = "lbl_date"
        Me.lbl_date.Size = New System.Drawing.Size(50, 13)
        Me.lbl_date.TabIndex = 107
        Me.lbl_date.Text = "%fecha%"
        '
        'lbl_cliente
        '
        Me.lbl_cliente.AutoSize = True
        Me.lbl_cliente.Location = New System.Drawing.Point(12, 98)
        Me.lbl_cliente.Name = "lbl_cliente"
        Me.lbl_cliente.Size = New System.Drawing.Size(54, 13)
        Me.lbl_cliente.TabIndex = 105
        Me.lbl_cliente.Text = "%cliente%"
        '
        'lbl_fecha
        '
        Me.lbl_fecha.AutoSize = True
        Me.lbl_fecha.Location = New System.Drawing.Point(10, 14)
        Me.lbl_fecha.Name = "lbl_fecha"
        Me.lbl_fecha.Size = New System.Drawing.Size(40, 13)
        Me.lbl_fecha.TabIndex = 104
        Me.lbl_fecha.Text = "Fecha:"
        '
        'dgv_item
        '
        Me.dgv_item.AllowUserToAddRows = False
        Me.dgv_item.AllowUserToDeleteRows = False
        Me.dgv_item.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.dgv_item.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_item.Location = New System.Drawing.Point(13, 145)
        Me.dgv_item.Margin = New System.Windows.Forms.Padding(2)
        Me.dgv_item.MultiSelect = False
        Me.dgv_item.Name = "dgv_item"
        Me.dgv_item.ReadOnly = True
        Me.dgv_item.RowHeadersVisible = False
        Me.dgv_item.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_item.Size = New System.Drawing.Size(563, 238)
        Me.dgv_item.TabIndex = 91
        '
        'cmb_comprobante
        '
        Me.cmb_comprobante.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_comprobante.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_comprobante.FormattingEnabled = True
        Me.cmb_comprobante.Location = New System.Drawing.Point(12, 60)
        Me.cmb_comprobante.Name = "cmb_comprobante"
        Me.cmb_comprobante.Size = New System.Drawing.Size(525, 21)
        Me.cmb_comprobante.TabIndex = 119
        '
        'pic_searchComprobante
        '
        Me.pic_searchComprobante.Image = Global.DROil.My.Resources.Resources.iconoLupa
        Me.pic_searchComprobante.Location = New System.Drawing.Point(554, 59)
        Me.pic_searchComprobante.Name = "pic_searchComprobante"
        Me.pic_searchComprobante.Size = New System.Drawing.Size(22, 22)
        Me.pic_searchComprobante.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_searchComprobante.TabIndex = 121
        Me.pic_searchComprobante.TabStop = False
        '
        'lbl_comprobante
        '
        Me.lbl_comprobante.AutoSize = True
        Me.lbl_comprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_comprobante.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_comprobante.Location = New System.Drawing.Point(9, 44)
        Me.lbl_comprobante.Name = "lbl_comprobante"
        Me.lbl_comprobante.Size = New System.Drawing.Size(160, 13)
        Me.lbl_comprobante.TabIndex = 120
        Me.lbl_comprobante.Text = "ELIJA UN COMPROBANTE"
        '
        'lbl_items
        '
        Me.lbl_items.AutoSize = True
        Me.lbl_items.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_items.Location = New System.Drawing.Point(265, 110)
        Me.lbl_items.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_items.Name = "lbl_items"
        Me.lbl_items.Size = New System.Drawing.Size(59, 24)
        Me.lbl_items.TabIndex = 122
        Me.lbl_items.Text = "Items"
        '
        'txt_impuestos
        '
        Me.txt_impuestos.Location = New System.Drawing.Point(329, 403)
        Me.txt_impuestos.Name = "txt_impuestos"
        Me.txt_impuestos.ReadOnly = True
        Me.txt_impuestos.Size = New System.Drawing.Size(86, 20)
        Me.txt_impuestos.TabIndex = 123
        '
        'lbl_impuestos
        '
        Me.lbl_impuestos.AutoSize = True
        Me.lbl_impuestos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_impuestos.Location = New System.Drawing.Point(222, 403)
        Me.lbl_impuestos.Name = "lbl_impuestos"
        Me.lbl_impuestos.Size = New System.Drawing.Size(98, 20)
        Me.lbl_impuestos.TabIndex = 124
        Me.lbl_impuestos.Text = "Impuestos:"
        '
        'chk_remitos
        '
        Me.chk_remitos.AutoSize = True
        Me.chk_remitos.Location = New System.Drawing.Point(153, 705)
        Me.chk_remitos.Name = "chk_remitos"
        Me.chk_remitos.Size = New System.Drawing.Size(87, 17)
        Me.chk_remitos.TabIndex = 125
        Me.chk_remitos.Text = "Emitir remitos"
        Me.chk_remitos.UseVisualStyleBackColor = True
        '
        'lbl_noTaxNumber
        '
        Me.lbl_noTaxNumber.AutoSize = True
        Me.lbl_noTaxNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_noTaxNumber.ForeColor = System.Drawing.Color.Red
        Me.lbl_noTaxNumber.Location = New System.Drawing.Point(9, 674)
        Me.lbl_noTaxNumber.Name = "lbl_noTaxNumber"
        Me.lbl_noTaxNumber.Size = New System.Drawing.Size(571, 13)
        Me.lbl_noTaxNumber.TabIndex = 686
        Me.lbl_noTaxNumber.Text = "El cliente no tiene cargado el DNI/CUIT/CUIL por lo cual no se pueden emitir docu" &
    "mentos oficiales"
        Me.lbl_noTaxNumber.Visible = False
        '
        'pre_fe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(589, 818)
        Me.Controls.Add(Me.lbl_noTaxNumber)
        Me.Controls.Add(Me.chk_remitos)
        Me.Controls.Add(Me.txt_impuestos)
        Me.Controls.Add(Me.lbl_impuestos)
        Me.Controls.Add(Me.lbl_items)
        Me.Controls.Add(Me.cmb_comprobante)
        Me.Controls.Add(Me.pic_searchComprobante)
        Me.Controls.Add(Me.lbl_comprobante)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_emitir)
        Me.Controls.Add(Me.chk_pagoCombinado)
        Me.Controls.Add(Me.cmb_caja)
        Me.Controls.Add(Me.lbl_caja)
        Me.Controls.Add(Me.txt_subTotal)
        Me.Controls.Add(Me.lbl_subTotal)
        Me.Controls.Add(Me.cmb_condicion)
        Me.Controls.Add(Me.cmb_descuento)
        Me.Controls.Add(Me.lbl_descuento)
        Me.Controls.Add(Me.lbl_condicion)
        Me.Controls.Add(Me.txt_notas)
        Me.Controls.Add(Me.lbl_notas)
        Me.Controls.Add(Me.txt_total)
        Me.Controls.Add(Me.lbl_total)
        Me.Controls.Add(Me.lbl_date)
        Me.Controls.Add(Me.lbl_cliente)
        Me.Controls.Add(Me.lbl_fecha)
        Me.Controls.Add(Me.dgv_item)
        Me.Name = "pre_fe"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Preparar factura"
        CType(Me.pic_searchComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmd_exit As Button
    Friend WithEvents cmd_emitir As Button
    Friend WithEvents chk_pagoCombinado As CheckBox
    Friend WithEvents cmb_caja As ComboBox
    Friend WithEvents lbl_caja As Label
    Friend WithEvents txt_subTotal As TextBox
    Friend WithEvents lbl_subTotal As Label
    Friend WithEvents cmb_condicion As ComboBox
    Friend WithEvents cmb_descuento As ComboBox
    Friend WithEvents lbl_descuento As Label
    Friend WithEvents lbl_condicion As Label
    Friend WithEvents txt_notas As TextBox
    Friend WithEvents lbl_notas As Label
    Friend WithEvents txt_total As TextBox
    Friend WithEvents lbl_total As Label
    Friend WithEvents lbl_date As Label
    Friend WithEvents lbl_cliente As Label
    Friend WithEvents lbl_fecha As Label
    Friend WithEvents dgv_item As DataGridView
    Friend WithEvents cmb_comprobante As ComboBox
    Friend WithEvents pic_searchComprobante As PictureBox
    Friend WithEvents lbl_comprobante As Label
    Friend WithEvents lbl_items As Label
    Friend WithEvents txt_impuestos As TextBox
    Friend WithEvents lbl_impuestos As Label
    Friend WithEvents chk_remitos As CheckBox
    Friend WithEvents lbl_noTaxNumber As Label
End Class
