<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_item
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
        Me.lbl_item = New System.Windows.Forms.Label()
        Me.txt_item = New System.Windows.Forms.TextBox()
        Me.txt_desc = New System.Windows.Forms.TextBox()
        Me.lbl_desc = New System.Windows.Forms.Label()
        Me.txt_costo = New System.Windows.Forms.TextBox()
        Me.lbl_costo = New System.Windows.Forms.Label()
        Me.txt_prclista = New System.Windows.Forms.TextBox()
        Me.lbl_preciolista = New System.Windows.Forms.Label()
        Me.lbl_categoria = New System.Windows.Forms.Label()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.cmb_cat = New System.Windows.Forms.ComboBox()
        Me.cmb_marca = New System.Windows.Forms.ComboBox()
        Me.lbl_marca = New System.Windows.Forms.Label()
        Me.cmb_proveedor = New System.Windows.Forms.ComboBox()
        Me.lbl_proveedor = New System.Windows.Forms.Label()
        Me.psearch_proveedor = New System.Windows.Forms.PictureBox()
        Me.psearch_marca = New System.Windows.Forms.PictureBox()
        Me.psearch_tipo = New System.Windows.Forms.PictureBox()
        Me.chk_activo = New System.Windows.Forms.CheckBox()
        Me.txt_fram = New System.Windows.Forms.TextBox()
        Me.lbl_fram = New System.Windows.Forms.Label()
        Me.psearch_rosca = New System.Windows.Forms.PictureBox()
        Me.cmb_rosca = New System.Windows.Forms.ComboBox()
        Me.lbl_rosca = New System.Windows.Forms.Label()
        Me.txt_wega = New System.Windows.Forms.TextBox()
        Me.lbl_wega = New System.Windows.Forms.Label()
        Me.chk_rosca = New System.Windows.Forms.CheckBox()
        Me.txt_mann = New System.Windows.Forms.TextBox()
        Me.lbl_mann = New System.Windows.Forms.Label()
        Me.txt_markup = New System.Windows.Forms.TextBox()
        Me.lbl_markup = New System.Windows.Forms.Label()
        Me.psearch_iva = New System.Windows.Forms.PictureBox()
        Me.cmb_iva = New System.Windows.Forms.ComboBox()
        Me.lbl_iva = New System.Windows.Forms.Label()
        Me.txt_descuento = New System.Windows.Forms.TextBox()
        Me.lbl_descuento = New System.Windows.Forms.Label()
        Me.txt_ean = New System.Windows.Forms.TextBox()
        Me.lbl_ean = New System.Windows.Forms.Label()
        Me.chk_checkStock = New System.Windows.Forms.CheckBox()
        Me.lbl_checkStock = New System.Windows.Forms.Label()
        Me.txt_stockRepo = New System.Windows.Forms.TextBox()
        Me.lbl_stockRepo = New System.Windows.Forms.Label()
        Me.txt_oem = New System.Windows.Forms.TextBox()
        Me.lbl_oem = New System.Windows.Forms.Label()
        Me.chk_oferta = New System.Windows.Forms.CheckBox()
        Me.lbl_ultimaMod = New System.Windows.Forms.Label()
        Me.txt_dateUltimaMod = New System.Windows.Forms.TextBox()
        CType(Me.psearch_proveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.psearch_marca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.psearch_tipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.psearch_rosca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.psearch_iva, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_item
        '
        Me.lbl_item.AutoSize = True
        Me.lbl_item.Location = New System.Drawing.Point(35, 27)
        Me.lbl_item.Name = "lbl_item"
        Me.lbl_item.Size = New System.Drawing.Size(27, 13)
        Me.lbl_item.TabIndex = 0
        Me.lbl_item.Text = "Item"
        '
        'txt_item
        '
        Me.txt_item.Location = New System.Drawing.Point(137, 27)
        Me.txt_item.Name = "txt_item"
        Me.txt_item.Size = New System.Drawing.Size(259, 20)
        Me.txt_item.TabIndex = 0
        '
        'txt_desc
        '
        Me.txt_desc.Location = New System.Drawing.Point(137, 95)
        Me.txt_desc.Name = "txt_desc"
        Me.txt_desc.Size = New System.Drawing.Size(259, 20)
        Me.txt_desc.TabIndex = 2
        '
        'lbl_desc
        '
        Me.lbl_desc.AutoSize = True
        Me.lbl_desc.Location = New System.Drawing.Point(35, 96)
        Me.lbl_desc.Name = "lbl_desc"
        Me.lbl_desc.Size = New System.Drawing.Size(63, 13)
        Me.lbl_desc.TabIndex = 2
        Me.lbl_desc.Text = "Descripción"
        '
        'txt_costo
        '
        Me.txt_costo.Location = New System.Drawing.Point(137, 130)
        Me.txt_costo.Name = "txt_costo"
        Me.txt_costo.Size = New System.Drawing.Size(259, 20)
        Me.txt_costo.TabIndex = 3
        '
        'lbl_costo
        '
        Me.lbl_costo.AutoSize = True
        Me.lbl_costo.Location = New System.Drawing.Point(35, 132)
        Me.lbl_costo.Name = "lbl_costo"
        Me.lbl_costo.Size = New System.Drawing.Size(34, 13)
        Me.lbl_costo.TabIndex = 4
        Me.lbl_costo.Text = "Costo"
        '
        'txt_prclista
        '
        Me.txt_prclista.Location = New System.Drawing.Point(137, 279)
        Me.txt_prclista.Name = "txt_prclista"
        Me.txt_prclista.Size = New System.Drawing.Size(259, 20)
        Me.txt_prclista.TabIndex = 7
        '
        'lbl_preciolista
        '
        Me.lbl_preciolista.AutoSize = True
        Me.lbl_preciolista.Location = New System.Drawing.Point(35, 284)
        Me.lbl_preciolista.Name = "lbl_preciolista"
        Me.lbl_preciolista.Size = New System.Drawing.Size(73, 13)
        Me.lbl_preciolista.TabIndex = 6
        Me.lbl_preciolista.Text = "Precio de lista"
        '
        'lbl_categoria
        '
        Me.lbl_categoria.AutoSize = True
        Me.lbl_categoria.Location = New System.Drawing.Point(453, 25)
        Me.lbl_categoria.Name = "lbl_categoria"
        Me.lbl_categoria.Size = New System.Drawing.Size(54, 13)
        Me.lbl_categoria.TabIndex = 8
        Me.lbl_categoria.Text = "Categoría"
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(356, 495)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 22
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(456, 495)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 23
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Location = New System.Drawing.Point(47, 438)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(108, 17)
        Me.chk_secuencia.TabIndex = 21
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        '
        'cmb_cat
        '
        Me.cmb_cat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_cat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_cat.FormattingEnabled = True
        Me.cmb_cat.Location = New System.Drawing.Point(555, 19)
        Me.cmb_cat.Name = "cmb_cat"
        Me.cmb_cat.Size = New System.Drawing.Size(259, 21)
        Me.cmb_cat.TabIndex = 8
        '
        'cmb_marca
        '
        Me.cmb_marca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_marca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_marca.FormattingEnabled = True
        Me.cmb_marca.Location = New System.Drawing.Point(556, 54)
        Me.cmb_marca.Name = "cmb_marca"
        Me.cmb_marca.Size = New System.Drawing.Size(259, 21)
        Me.cmb_marca.TabIndex = 9
        '
        'lbl_marca
        '
        Me.lbl_marca.AutoSize = True
        Me.lbl_marca.Location = New System.Drawing.Point(454, 59)
        Me.lbl_marca.Name = "lbl_marca"
        Me.lbl_marca.Size = New System.Drawing.Size(37, 13)
        Me.lbl_marca.TabIndex = 14
        Me.lbl_marca.Text = "Marca"
        '
        'cmb_proveedor
        '
        Me.cmb_proveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_proveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_proveedor.FormattingEnabled = True
        Me.cmb_proveedor.Location = New System.Drawing.Point(555, 88)
        Me.cmb_proveedor.Name = "cmb_proveedor"
        Me.cmb_proveedor.Size = New System.Drawing.Size(259, 21)
        Me.cmb_proveedor.TabIndex = 10
        '
        'lbl_proveedor
        '
        Me.lbl_proveedor.AutoSize = True
        Me.lbl_proveedor.Location = New System.Drawing.Point(453, 92)
        Me.lbl_proveedor.Name = "lbl_proveedor"
        Me.lbl_proveedor.Size = New System.Drawing.Size(56, 13)
        Me.lbl_proveedor.TabIndex = 16
        Me.lbl_proveedor.Text = "Proveedor"
        '
        'psearch_proveedor
        '
        Me.psearch_proveedor.Image = Global.DROil.My.Resources.Resources.iconoLupa
        Me.psearch_proveedor.Location = New System.Drawing.Point(821, 88)
        Me.psearch_proveedor.Name = "psearch_proveedor"
        Me.psearch_proveedor.Size = New System.Drawing.Size(22, 22)
        Me.psearch_proveedor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_proveedor.TabIndex = 28
        Me.psearch_proveedor.TabStop = False
        '
        'psearch_marca
        '
        Me.psearch_marca.Image = Global.DROil.My.Resources.Resources.iconoLupa
        Me.psearch_marca.Location = New System.Drawing.Point(820, 54)
        Me.psearch_marca.Name = "psearch_marca"
        Me.psearch_marca.Size = New System.Drawing.Size(22, 22)
        Me.psearch_marca.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_marca.TabIndex = 27
        Me.psearch_marca.TabStop = False
        '
        'psearch_tipo
        '
        Me.psearch_tipo.Image = Global.DROil.My.Resources.Resources.iconoLupa
        Me.psearch_tipo.Location = New System.Drawing.Point(820, 19)
        Me.psearch_tipo.Name = "psearch_tipo"
        Me.psearch_tipo.Size = New System.Drawing.Size(22, 22)
        Me.psearch_tipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_tipo.TabIndex = 26
        Me.psearch_tipo.TabStop = False
        '
        'chk_activo
        '
        Me.chk_activo.AutoSize = True
        Me.chk_activo.Location = New System.Drawing.Point(47, 365)
        Me.chk_activo.Name = "chk_activo"
        Me.chk_activo.Size = New System.Drawing.Size(78, 17)
        Me.chk_activo.TabIndex = 19
        Me.chk_activo.Text = "Item activo"
        Me.chk_activo.UseVisualStyleBackColor = True
        '
        'txt_fram
        '
        Me.txt_fram.Location = New System.Drawing.Point(556, 163)
        Me.txt_fram.Name = "txt_fram"
        Me.txt_fram.Size = New System.Drawing.Size(259, 20)
        Me.txt_fram.TabIndex = 12
        '
        'lbl_fram
        '
        Me.lbl_fram.AutoSize = True
        Me.lbl_fram.Location = New System.Drawing.Point(454, 166)
        Me.lbl_fram.Name = "lbl_fram"
        Me.lbl_fram.Size = New System.Drawing.Size(37, 13)
        Me.lbl_fram.TabIndex = 48
        Me.lbl_fram.Text = "FRAM"
        '
        'psearch_rosca
        '
        Me.psearch_rosca.Image = Global.DROil.My.Resources.Resources.iconoLupa
        Me.psearch_rosca.Location = New System.Drawing.Point(821, 275)
        Me.psearch_rosca.Name = "psearch_rosca"
        Me.psearch_rosca.Size = New System.Drawing.Size(22, 22)
        Me.psearch_rosca.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_rosca.TabIndex = 47
        Me.psearch_rosca.TabStop = False
        '
        'cmb_rosca
        '
        Me.cmb_rosca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_rosca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_rosca.FormattingEnabled = True
        Me.cmb_rosca.Location = New System.Drawing.Point(581, 276)
        Me.cmb_rosca.Name = "cmb_rosca"
        Me.cmb_rosca.Size = New System.Drawing.Size(233, 21)
        Me.cmb_rosca.TabIndex = 16
        '
        'lbl_rosca
        '
        Me.lbl_rosca.AutoSize = True
        Me.lbl_rosca.Location = New System.Drawing.Point(454, 279)
        Me.lbl_rosca.Name = "lbl_rosca"
        Me.lbl_rosca.Size = New System.Drawing.Size(38, 13)
        Me.lbl_rosca.TabIndex = 45
        Me.lbl_rosca.Text = "Rosca"
        '
        'txt_wega
        '
        Me.txt_wega.Location = New System.Drawing.Point(556, 125)
        Me.txt_wega.Name = "txt_wega"
        Me.txt_wega.Size = New System.Drawing.Size(259, 20)
        Me.txt_wega.TabIndex = 11
        '
        'lbl_wega
        '
        Me.lbl_wega.AutoSize = True
        Me.lbl_wega.Location = New System.Drawing.Point(454, 128)
        Me.lbl_wega.Name = "lbl_wega"
        Me.lbl_wega.Size = New System.Drawing.Size(40, 13)
        Me.lbl_wega.TabIndex = 43
        Me.lbl_wega.Text = "WEGA"
        '
        'chk_rosca
        '
        Me.chk_rosca.AutoSize = True
        Me.chk_rosca.Location = New System.Drawing.Point(555, 280)
        Me.chk_rosca.Margin = New System.Windows.Forms.Padding(2)
        Me.chk_rosca.Name = "chk_rosca"
        Me.chk_rosca.Size = New System.Drawing.Size(15, 14)
        Me.chk_rosca.TabIndex = 15
        Me.chk_rosca.UseVisualStyleBackColor = True
        '
        'txt_mann
        '
        Me.txt_mann.Location = New System.Drawing.Point(555, 201)
        Me.txt_mann.Name = "txt_mann"
        Me.txt_mann.Size = New System.Drawing.Size(259, 20)
        Me.txt_mann.TabIndex = 13
        '
        'lbl_mann
        '
        Me.lbl_mann.AutoSize = True
        Me.lbl_mann.Location = New System.Drawing.Point(454, 204)
        Me.lbl_mann.Name = "lbl_mann"
        Me.lbl_mann.Size = New System.Drawing.Size(39, 13)
        Me.lbl_mann.TabIndex = 52
        Me.lbl_mann.Text = "MANN"
        '
        'txt_markup
        '
        Me.txt_markup.Location = New System.Drawing.Point(137, 167)
        Me.txt_markup.Name = "txt_markup"
        Me.txt_markup.Size = New System.Drawing.Size(259, 20)
        Me.txt_markup.TabIndex = 4
        '
        'lbl_markup
        '
        Me.lbl_markup.AutoSize = True
        Me.lbl_markup.Location = New System.Drawing.Point(35, 170)
        Me.lbl_markup.Name = "lbl_markup"
        Me.lbl_markup.Size = New System.Drawing.Size(60, 13)
        Me.lbl_markup.TabIndex = 54
        Me.lbl_markup.Text = "Markup (%)"
        '
        'psearch_iva
        '
        Me.psearch_iva.Image = Global.DROil.My.Resources.Resources.iconoLupa
        Me.psearch_iva.Location = New System.Drawing.Point(402, 241)
        Me.psearch_iva.Name = "psearch_iva"
        Me.psearch_iva.Size = New System.Drawing.Size(22, 22)
        Me.psearch_iva.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_iva.TabIndex = 58
        Me.psearch_iva.TabStop = False
        '
        'cmb_iva
        '
        Me.cmb_iva.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_iva.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_iva.FormattingEnabled = True
        Me.cmb_iva.Location = New System.Drawing.Point(137, 241)
        Me.cmb_iva.Name = "cmb_iva"
        Me.cmb_iva.Size = New System.Drawing.Size(259, 21)
        Me.cmb_iva.TabIndex = 6
        '
        'lbl_iva
        '
        Me.lbl_iva.AutoSize = True
        Me.lbl_iva.Location = New System.Drawing.Point(35, 246)
        Me.lbl_iva.Name = "lbl_iva"
        Me.lbl_iva.Size = New System.Drawing.Size(33, 13)
        Me.lbl_iva.TabIndex = 57
        Me.lbl_iva.Text = "I.V.A."
        '
        'txt_descuento
        '
        Me.txt_descuento.Location = New System.Drawing.Point(137, 204)
        Me.txt_descuento.Name = "txt_descuento"
        Me.txt_descuento.Size = New System.Drawing.Size(259, 20)
        Me.txt_descuento.TabIndex = 5
        '
        'lbl_descuento
        '
        Me.lbl_descuento.AutoSize = True
        Me.lbl_descuento.Location = New System.Drawing.Point(35, 208)
        Me.lbl_descuento.Name = "lbl_descuento"
        Me.lbl_descuento.Size = New System.Drawing.Size(76, 13)
        Me.lbl_descuento.TabIndex = 60
        Me.lbl_descuento.Text = "Descuento (%)"
        '
        'txt_ean
        '
        Me.txt_ean.Location = New System.Drawing.Point(137, 62)
        Me.txt_ean.Name = "txt_ean"
        Me.txt_ean.Size = New System.Drawing.Size(259, 20)
        Me.txt_ean.TabIndex = 1
        '
        'lbl_ean
        '
        Me.lbl_ean.AutoSize = True
        Me.lbl_ean.Location = New System.Drawing.Point(35, 62)
        Me.lbl_ean.Name = "lbl_ean"
        Me.lbl_ean.Size = New System.Drawing.Size(29, 13)
        Me.lbl_ean.TabIndex = 62
        Me.lbl_ean.Text = "EAN"
        '
        'chk_checkStock
        '
        Me.chk_checkStock.AutoSize = True
        Me.chk_checkStock.Location = New System.Drawing.Point(555, 313)
        Me.chk_checkStock.Margin = New System.Windows.Forms.Padding(2)
        Me.chk_checkStock.Name = "chk_checkStock"
        Me.chk_checkStock.Size = New System.Drawing.Size(15, 14)
        Me.chk_checkStock.TabIndex = 17
        Me.chk_checkStock.UseVisualStyleBackColor = True
        '
        'lbl_checkStock
        '
        Me.lbl_checkStock.AutoSize = True
        Me.lbl_checkStock.Location = New System.Drawing.Point(455, 314)
        Me.lbl_checkStock.Name = "lbl_checkStock"
        Me.lbl_checkStock.Size = New System.Drawing.Size(87, 13)
        Me.lbl_checkStock.TabIndex = 66
        Me.lbl_checkStock.Text = "¿Controla stock?"
        '
        'txt_stockRepo
        '
        Me.txt_stockRepo.Enabled = False
        Me.txt_stockRepo.Location = New System.Drawing.Point(685, 314)
        Me.txt_stockRepo.Name = "txt_stockRepo"
        Me.txt_stockRepo.Size = New System.Drawing.Size(130, 20)
        Me.txt_stockRepo.TabIndex = 18
        '
        'lbl_stockRepo
        '
        Me.lbl_stockRepo.AutoSize = True
        Me.lbl_stockRepo.Location = New System.Drawing.Point(578, 314)
        Me.lbl_stockRepo.Name = "lbl_stockRepo"
        Me.lbl_stockRepo.Size = New System.Drawing.Size(101, 13)
        Me.lbl_stockRepo.TabIndex = 68
        Me.lbl_stockRepo.Text = "Stock de reposición"
        '
        'txt_oem
        '
        Me.txt_oem.Location = New System.Drawing.Point(556, 239)
        Me.txt_oem.Name = "txt_oem"
        Me.txt_oem.Size = New System.Drawing.Size(259, 20)
        Me.txt_oem.TabIndex = 14
        '
        'lbl_oem
        '
        Me.lbl_oem.AutoSize = True
        Me.lbl_oem.Location = New System.Drawing.Point(455, 242)
        Me.lbl_oem.Name = "lbl_oem"
        Me.lbl_oem.Size = New System.Drawing.Size(31, 13)
        Me.lbl_oem.TabIndex = 70
        Me.lbl_oem.Text = "OEM"
        '
        'chk_oferta
        '
        Me.chk_oferta.AutoSize = True
        Me.chk_oferta.Location = New System.Drawing.Point(137, 365)
        Me.chk_oferta.Name = "chk_oferta"
        Me.chk_oferta.Size = New System.Drawing.Size(68, 17)
        Me.chk_oferta.TabIndex = 20
        Me.chk_oferta.Text = "Es oferta"
        Me.chk_oferta.UseVisualStyleBackColor = True
        '
        'lbl_ultimaMod
        '
        Me.lbl_ultimaMod.AutoSize = True
        Me.lbl_ultimaMod.Location = New System.Drawing.Point(449, 362)
        Me.lbl_ultimaMod.Name = "lbl_ultimaMod"
        Me.lbl_ultimaMod.Size = New System.Drawing.Size(98, 13)
        Me.lbl_ultimaMod.TabIndex = 72
        Me.lbl_ultimaMod.Text = "Última modificación"
        '
        'txt_dateUltimaMod
        '
        Me.txt_dateUltimaMod.Enabled = False
        Me.txt_dateUltimaMod.Location = New System.Drawing.Point(556, 362)
        Me.txt_dateUltimaMod.Name = "txt_dateUltimaMod"
        Me.txt_dateUltimaMod.Size = New System.Drawing.Size(130, 20)
        Me.txt_dateUltimaMod.TabIndex = 71
        '
        'add_item
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(878, 529)
        Me.Controls.Add(Me.lbl_ultimaMod)
        Me.Controls.Add(Me.txt_dateUltimaMod)
        Me.Controls.Add(Me.chk_oferta)
        Me.Controls.Add(Me.txt_oem)
        Me.Controls.Add(Me.lbl_oem)
        Me.Controls.Add(Me.lbl_stockRepo)
        Me.Controls.Add(Me.txt_stockRepo)
        Me.Controls.Add(Me.chk_checkStock)
        Me.Controls.Add(Me.lbl_checkStock)
        Me.Controls.Add(Me.txt_ean)
        Me.Controls.Add(Me.lbl_ean)
        Me.Controls.Add(Me.txt_descuento)
        Me.Controls.Add(Me.lbl_descuento)
        Me.Controls.Add(Me.psearch_iva)
        Me.Controls.Add(Me.cmb_iva)
        Me.Controls.Add(Me.lbl_iva)
        Me.Controls.Add(Me.txt_markup)
        Me.Controls.Add(Me.lbl_markup)
        Me.Controls.Add(Me.chk_activo)
        Me.Controls.Add(Me.txt_mann)
        Me.Controls.Add(Me.lbl_mann)
        Me.Controls.Add(Me.chk_rosca)
        Me.Controls.Add(Me.txt_fram)
        Me.Controls.Add(Me.lbl_fram)
        Me.Controls.Add(Me.psearch_rosca)
        Me.Controls.Add(Me.cmb_rosca)
        Me.Controls.Add(Me.lbl_rosca)
        Me.Controls.Add(Me.txt_wega)
        Me.Controls.Add(Me.lbl_wega)
        Me.Controls.Add(Me.psearch_proveedor)
        Me.Controls.Add(Me.psearch_marca)
        Me.Controls.Add(Me.psearch_tipo)
        Me.Controls.Add(Me.cmb_proveedor)
        Me.Controls.Add(Me.lbl_proveedor)
        Me.Controls.Add(Me.cmb_marca)
        Me.Controls.Add(Me.lbl_marca)
        Me.Controls.Add(Me.cmb_cat)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.lbl_categoria)
        Me.Controls.Add(Me.txt_prclista)
        Me.Controls.Add(Me.lbl_preciolista)
        Me.Controls.Add(Me.txt_costo)
        Me.Controls.Add(Me.lbl_costo)
        Me.Controls.Add(Me.txt_desc)
        Me.Controls.Add(Me.lbl_desc)
        Me.Controls.Add(Me.txt_item)
        Me.Controls.Add(Me.lbl_item)
        Me.Name = "add_item"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Insertar item"
        CType(Me.psearch_proveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.psearch_marca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.psearch_tipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.psearch_rosca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.psearch_iva, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_item As System.Windows.Forms.Label
    Friend WithEvents txt_item As System.Windows.Forms.TextBox
    Friend WithEvents txt_desc As System.Windows.Forms.TextBox
    Friend WithEvents lbl_desc As System.Windows.Forms.Label
    Friend WithEvents txt_costo As System.Windows.Forms.TextBox
    Friend WithEvents lbl_costo As System.Windows.Forms.Label
    Friend WithEvents txt_prclista As System.Windows.Forms.TextBox
    Friend WithEvents lbl_preciolista As System.Windows.Forms.Label
    Friend WithEvents lbl_categoria As System.Windows.Forms.Label
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents chk_secuencia As System.Windows.Forms.CheckBox
    Friend WithEvents cmb_cat As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_marca As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_marca As System.Windows.Forms.Label
    Friend WithEvents cmb_proveedor As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_proveedor As System.Windows.Forms.Label
    Friend WithEvents psearch_tipo As System.Windows.Forms.PictureBox
    Friend WithEvents psearch_marca As System.Windows.Forms.PictureBox
    Friend WithEvents psearch_proveedor As System.Windows.Forms.PictureBox
    Friend WithEvents chk_activo As System.Windows.Forms.CheckBox
    Friend WithEvents txt_fram As System.Windows.Forms.TextBox
    Friend WithEvents lbl_fram As System.Windows.Forms.Label
    Friend WithEvents psearch_rosca As System.Windows.Forms.PictureBox
    Friend WithEvents cmb_rosca As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_rosca As System.Windows.Forms.Label
    Friend WithEvents txt_wega As System.Windows.Forms.TextBox
    Friend WithEvents lbl_wega As System.Windows.Forms.Label
    Friend WithEvents chk_rosca As System.Windows.Forms.CheckBox
    Friend WithEvents txt_mann As System.Windows.Forms.TextBox
    Friend WithEvents lbl_mann As System.Windows.Forms.Label
    Friend WithEvents txt_markup As System.Windows.Forms.TextBox
    Friend WithEvents lbl_markup As System.Windows.Forms.Label
    Friend WithEvents psearch_iva As System.Windows.Forms.PictureBox
    Friend WithEvents cmb_iva As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_iva As System.Windows.Forms.Label
    Friend WithEvents txt_descuento As System.Windows.Forms.TextBox
    Friend WithEvents lbl_descuento As System.Windows.Forms.Label
    Friend WithEvents txt_ean As TextBox
    Friend WithEvents lbl_ean As Label
    Friend WithEvents chk_checkStock As CheckBox
    Friend WithEvents lbl_checkStock As Label
    Friend WithEvents txt_stockRepo As TextBox
    Friend WithEvents lbl_stockRepo As Label
    Friend WithEvents txt_oem As TextBox
    Friend WithEvents lbl_oem As Label
    Friend WithEvents chk_oferta As CheckBox
    Friend WithEvents lbl_ultimaMod As Label
    Friend WithEvents txt_dateUltimaMod As TextBox
End Class
