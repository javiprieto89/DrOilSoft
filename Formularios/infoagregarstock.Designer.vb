<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class infoagregarstock
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
        Me.lblitem = New System.Windows.Forms.Label()
        Me.lbl_item = New System.Windows.Forms.Label()
        Me.lbl_costo = New System.Windows.Forms.Label()
        Me.lbl_cantidad = New System.Windows.Forms.Label()
        Me.lbl_factura = New System.Windows.Forms.Label()
        Me.lbl_fecha = New System.Windows.Forms.Label()
        Me.txt_fecha = New System.Windows.Forms.TextBox()
        Me.txt_costo = New System.Windows.Forms.TextBox()
        Me.txt_cantidad = New System.Windows.Forms.TextBox()
        Me.txt_factura = New System.Windows.Forms.TextBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.lbl_proveedor = New System.Windows.Forms.Label()
        Me.psearch_proveedor = New System.Windows.Forms.PictureBox()
        Me.cmb_proveedor = New System.Windows.Forms.ComboBox()
        Me.lbl_preciolista = New System.Windows.Forms.Label()
        Me.txt_preciolista = New System.Windows.Forms.TextBox()
        Me.lbl_notas = New System.Windows.Forms.Label()
        Me.txt_notas = New System.Windows.Forms.TextBox()
        Me.lbl_markup = New System.Windows.Forms.Label()
        Me.txt_markup = New System.Windows.Forms.TextBox()
        Me.lbl_iva = New System.Windows.Forms.Label()
        Me.cmb_iva = New System.Windows.Forms.ComboBox()
        Me.psearch_iva = New System.Windows.Forms.PictureBox()
        Me.lbl_descuento = New System.Windows.Forms.Label()
        Me.txt_descuento = New System.Windows.Forms.TextBox()
        Me.lbl_stockRepo = New System.Windows.Forms.Label()
        Me.txt_stockRepo = New System.Windows.Forms.TextBox()
        Me.chk_checkStock = New System.Windows.Forms.CheckBox()
        Me.lbl_checkStock = New System.Windows.Forms.Label()
        CType(Me.psearch_proveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.psearch_iva, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblitem
        '
        Me.lblitem.AutoSize = True
        Me.lblitem.Location = New System.Drawing.Point(26, 24)
        Me.lblitem.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblitem.Name = "lblitem"
        Me.lblitem.Size = New System.Drawing.Size(27, 13)
        Me.lblitem.TabIndex = 0
        Me.lblitem.Text = "Item"
        '
        'lbl_item
        '
        Me.lbl_item.AutoSize = True
        Me.lbl_item.Location = New System.Drawing.Point(115, 25)
        Me.lbl_item.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_item.Name = "lbl_item"
        Me.lbl_item.Size = New System.Drawing.Size(42, 13)
        Me.lbl_item.TabIndex = 1
        Me.lbl_item.Text = "%item%"
        '
        'lbl_costo
        '
        Me.lbl_costo.AutoSize = True
        Me.lbl_costo.Location = New System.Drawing.Point(26, 204)
        Me.lbl_costo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_costo.Name = "lbl_costo"
        Me.lbl_costo.Size = New System.Drawing.Size(34, 13)
        Me.lbl_costo.TabIndex = 3
        Me.lbl_costo.Text = "Costo"
        '
        'lbl_cantidad
        '
        Me.lbl_cantidad.AutoSize = True
        Me.lbl_cantidad.Location = New System.Drawing.Point(26, 168)
        Me.lbl_cantidad.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_cantidad.Name = "lbl_cantidad"
        Me.lbl_cantidad.Size = New System.Drawing.Size(49, 13)
        Me.lbl_cantidad.TabIndex = 4
        Me.lbl_cantidad.Text = "Cantidad"
        '
        'lbl_factura
        '
        Me.lbl_factura.AutoSize = True
        Me.lbl_factura.Location = New System.Drawing.Point(26, 96)
        Me.lbl_factura.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_factura.Name = "lbl_factura"
        Me.lbl_factura.Size = New System.Drawing.Size(43, 13)
        Me.lbl_factura.TabIndex = 5
        Me.lbl_factura.Text = "Factura"
        '
        'lbl_fecha
        '
        Me.lbl_fecha.AutoSize = True
        Me.lbl_fecha.Location = New System.Drawing.Point(26, 60)
        Me.lbl_fecha.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_fecha.Name = "lbl_fecha"
        Me.lbl_fecha.Size = New System.Drawing.Size(37, 13)
        Me.lbl_fecha.TabIndex = 7
        Me.lbl_fecha.Text = "Fecha"
        '
        'txt_fecha
        '
        Me.txt_fecha.Location = New System.Drawing.Point(115, 59)
        Me.txt_fecha.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_fecha.Name = "txt_fecha"
        Me.txt_fecha.Size = New System.Drawing.Size(180, 20)
        Me.txt_fecha.TabIndex = 0
        '
        'txt_costo
        '
        Me.txt_costo.Location = New System.Drawing.Point(115, 198)
        Me.txt_costo.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_costo.Name = "txt_costo"
        Me.txt_costo.Size = New System.Drawing.Size(180, 20)
        Me.txt_costo.TabIndex = 4
        '
        'txt_cantidad
        '
        Me.txt_cantidad.Location = New System.Drawing.Point(115, 163)
        Me.txt_cantidad.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_cantidad.Name = "txt_cantidad"
        Me.txt_cantidad.Size = New System.Drawing.Size(180, 20)
        Me.txt_cantidad.TabIndex = 3
        '
        'txt_factura
        '
        Me.txt_factura.Location = New System.Drawing.Point(115, 94)
        Me.txt_factura.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_factura.Name = "txt_factura"
        Me.txt_factura.Size = New System.Drawing.Size(180, 20)
        Me.txt_factura.TabIndex = 1
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(182, 560)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 11
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(84, 560)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 10
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'lbl_proveedor
        '
        Me.lbl_proveedor.AutoSize = True
        Me.lbl_proveedor.Location = New System.Drawing.Point(26, 132)
        Me.lbl_proveedor.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_proveedor.Name = "lbl_proveedor"
        Me.lbl_proveedor.Size = New System.Drawing.Size(56, 13)
        Me.lbl_proveedor.TabIndex = 16
        Me.lbl_proveedor.Text = "Proveedor"
        '
        'psearch_proveedor
        '
        Me.psearch_proveedor.Image = Global.DrOil.My.Resources.Resources.iconoLupa
        Me.psearch_proveedor.Location = New System.Drawing.Point(302, 128)
        Me.psearch_proveedor.Name = "psearch_proveedor"
        Me.psearch_proveedor.Size = New System.Drawing.Size(22, 22)
        Me.psearch_proveedor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_proveedor.TabIndex = 72
        Me.psearch_proveedor.TabStop = False
        '
        'cmb_proveedor
        '
        Me.cmb_proveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_proveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_proveedor.FormattingEnabled = True
        Me.cmb_proveedor.Location = New System.Drawing.Point(115, 129)
        Me.cmb_proveedor.Name = "cmb_proveedor"
        Me.cmb_proveedor.Size = New System.Drawing.Size(180, 21)
        Me.cmb_proveedor.TabIndex = 2
        '
        'lbl_preciolista
        '
        Me.lbl_preciolista.AutoSize = True
        Me.lbl_preciolista.Location = New System.Drawing.Point(24, 355)
        Me.lbl_preciolista.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_preciolista.Name = "lbl_preciolista"
        Me.lbl_preciolista.Size = New System.Drawing.Size(58, 13)
        Me.lbl_preciolista.TabIndex = 2
        Me.lbl_preciolista.Text = "Precio lista"
        '
        'txt_preciolista
        '
        Me.txt_preciolista.Location = New System.Drawing.Point(116, 355)
        Me.txt_preciolista.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_preciolista.Name = "txt_preciolista"
        Me.txt_preciolista.Size = New System.Drawing.Size(179, 20)
        Me.txt_preciolista.TabIndex = 8
        '
        'lbl_notas
        '
        Me.lbl_notas.AutoSize = True
        Me.lbl_notas.Location = New System.Drawing.Point(24, 439)
        Me.lbl_notas.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_notas.Name = "lbl_notas"
        Me.lbl_notas.Size = New System.Drawing.Size(35, 13)
        Me.lbl_notas.TabIndex = 73
        Me.lbl_notas.Text = "Notas"
        '
        'txt_notas
        '
        Me.txt_notas.Location = New System.Drawing.Point(116, 439)
        Me.txt_notas.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_notas.Multiline = True
        Me.txt_notas.Name = "txt_notas"
        Me.txt_notas.Size = New System.Drawing.Size(179, 88)
        Me.txt_notas.TabIndex = 9
        Me.txt_notas.WordWrap = False
        '
        'lbl_markup
        '
        Me.lbl_markup.AutoSize = True
        Me.lbl_markup.Location = New System.Drawing.Point(26, 244)
        Me.lbl_markup.Name = "lbl_markup"
        Me.lbl_markup.Size = New System.Drawing.Size(60, 13)
        Me.lbl_markup.TabIndex = 76
        Me.lbl_markup.Text = "Markup (%)"
        '
        'txt_markup
        '
        Me.txt_markup.Location = New System.Drawing.Point(116, 237)
        Me.txt_markup.Name = "txt_markup"
        Me.txt_markup.Size = New System.Drawing.Size(179, 20)
        Me.txt_markup.TabIndex = 5
        '
        'lbl_iva
        '
        Me.lbl_iva.AutoSize = True
        Me.lbl_iva.Location = New System.Drawing.Point(26, 319)
        Me.lbl_iva.Name = "lbl_iva"
        Me.lbl_iva.Size = New System.Drawing.Size(33, 13)
        Me.lbl_iva.TabIndex = 77
        Me.lbl_iva.Text = "I.V.A."
        '
        'cmb_iva
        '
        Me.cmb_iva.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_iva.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_iva.FormattingEnabled = True
        Me.cmb_iva.Location = New System.Drawing.Point(116, 315)
        Me.cmb_iva.Name = "cmb_iva"
        Me.cmb_iva.Size = New System.Drawing.Size(179, 21)
        Me.cmb_iva.TabIndex = 7
        '
        'psearch_iva
        '
        Me.psearch_iva.Enabled = False
        Me.psearch_iva.Image = Global.DrOil.My.Resources.Resources.iconoLupa
        Me.psearch_iva.Location = New System.Drawing.Point(302, 310)
        Me.psearch_iva.Name = "psearch_iva"
        Me.psearch_iva.Size = New System.Drawing.Size(22, 22)
        Me.psearch_iva.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_iva.TabIndex = 78
        Me.psearch_iva.TabStop = False
        '
        'lbl_descuento
        '
        Me.lbl_descuento.AutoSize = True
        Me.lbl_descuento.Location = New System.Drawing.Point(26, 283)
        Me.lbl_descuento.Name = "lbl_descuento"
        Me.lbl_descuento.Size = New System.Drawing.Size(76, 13)
        Me.lbl_descuento.TabIndex = 80
        Me.lbl_descuento.Text = "Descuento (%)"
        '
        'txt_descuento
        '
        Me.txt_descuento.Location = New System.Drawing.Point(116, 279)
        Me.txt_descuento.Name = "txt_descuento"
        Me.txt_descuento.Size = New System.Drawing.Size(179, 20)
        Me.txt_descuento.TabIndex = 6
        '
        'lbl_stockRepo
        '
        Me.lbl_stockRepo.AutoSize = True
        Me.lbl_stockRepo.Location = New System.Drawing.Point(136, 397)
        Me.lbl_stockRepo.Name = "lbl_stockRepo"
        Me.lbl_stockRepo.Size = New System.Drawing.Size(101, 13)
        Me.lbl_stockRepo.TabIndex = 84
        Me.lbl_stockRepo.Text = "Stock de reposición"
        '
        'txt_stockRepo
        '
        Me.txt_stockRepo.Enabled = False
        Me.txt_stockRepo.Location = New System.Drawing.Point(243, 397)
        Me.txt_stockRepo.Name = "txt_stockRepo"
        Me.txt_stockRepo.Size = New System.Drawing.Size(52, 20)
        Me.txt_stockRepo.TabIndex = 82
        '
        'chk_checkStock
        '
        Me.chk_checkStock.AutoSize = True
        Me.chk_checkStock.Location = New System.Drawing.Point(116, 397)
        Me.chk_checkStock.Margin = New System.Windows.Forms.Padding(2)
        Me.chk_checkStock.Name = "chk_checkStock"
        Me.chk_checkStock.Size = New System.Drawing.Size(15, 14)
        Me.chk_checkStock.TabIndex = 81
        Me.chk_checkStock.UseVisualStyleBackColor = True
        '
        'lbl_checkStock
        '
        Me.lbl_checkStock.AutoSize = True
        Me.lbl_checkStock.Location = New System.Drawing.Point(24, 397)
        Me.lbl_checkStock.Name = "lbl_checkStock"
        Me.lbl_checkStock.Size = New System.Drawing.Size(87, 13)
        Me.lbl_checkStock.TabIndex = 83
        Me.lbl_checkStock.Text = "¿Controla stock?"
        '
        'infoagregarstock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(341, 620)
        Me.Controls.Add(Me.lbl_stockRepo)
        Me.Controls.Add(Me.txt_stockRepo)
        Me.Controls.Add(Me.chk_checkStock)
        Me.Controls.Add(Me.lbl_checkStock)
        Me.Controls.Add(Me.txt_descuento)
        Me.Controls.Add(Me.lbl_descuento)
        Me.Controls.Add(Me.psearch_iva)
        Me.Controls.Add(Me.cmb_iva)
        Me.Controls.Add(Me.lbl_iva)
        Me.Controls.Add(Me.txt_markup)
        Me.Controls.Add(Me.lbl_markup)
        Me.Controls.Add(Me.txt_notas)
        Me.Controls.Add(Me.lbl_notas)
        Me.Controls.Add(Me.psearch_proveedor)
        Me.Controls.Add(Me.cmb_proveedor)
        Me.Controls.Add(Me.lbl_proveedor)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.txt_factura)
        Me.Controls.Add(Me.txt_cantidad)
        Me.Controls.Add(Me.txt_costo)
        Me.Controls.Add(Me.txt_preciolista)
        Me.Controls.Add(Me.txt_fecha)
        Me.Controls.Add(Me.lbl_fecha)
        Me.Controls.Add(Me.lbl_factura)
        Me.Controls.Add(Me.lbl_cantidad)
        Me.Controls.Add(Me.lbl_costo)
        Me.Controls.Add(Me.lbl_preciolista)
        Me.Controls.Add(Me.lbl_item)
        Me.Controls.Add(Me.lblitem)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "infoagregarstock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Actualizar stock"
        CType(Me.psearch_proveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.psearch_iva, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblitem As System.Windows.Forms.Label
    Friend WithEvents lbl_item As System.Windows.Forms.Label
    Friend WithEvents lbl_costo As System.Windows.Forms.Label
    Friend WithEvents lbl_cantidad As System.Windows.Forms.Label
    Friend WithEvents lbl_factura As System.Windows.Forms.Label
    Friend WithEvents lbl_fecha As System.Windows.Forms.Label
    Friend WithEvents txt_fecha As System.Windows.Forms.TextBox
    Friend WithEvents txt_costo As System.Windows.Forms.TextBox
    Friend WithEvents txt_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents txt_factura As System.Windows.Forms.TextBox
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents lbl_proveedor As System.Windows.Forms.Label
    Friend WithEvents psearch_proveedor As System.Windows.Forms.PictureBox
    Friend WithEvents cmb_proveedor As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_preciolista As System.Windows.Forms.Label
    Friend WithEvents txt_preciolista As System.Windows.Forms.TextBox
    Friend WithEvents lbl_notas As System.Windows.Forms.Label
    Friend WithEvents txt_notas As System.Windows.Forms.TextBox
    Friend WithEvents lbl_markup As System.Windows.Forms.Label
    Friend WithEvents txt_markup As System.Windows.Forms.TextBox
    Friend WithEvents lbl_iva As System.Windows.Forms.Label
    Friend WithEvents cmb_iva As System.Windows.Forms.ComboBox
    Friend WithEvents psearch_iva As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_descuento As System.Windows.Forms.Label
    Friend WithEvents txt_descuento As System.Windows.Forms.TextBox
    Friend WithEvents lbl_stockRepo As Label
    Friend WithEvents txt_stockRepo As TextBox
    Friend WithEvents chk_checkStock As CheckBox
    Friend WithEvents lbl_checkStock As Label
End Class
