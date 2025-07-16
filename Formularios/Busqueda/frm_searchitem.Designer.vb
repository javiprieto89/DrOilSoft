<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_searchitem
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
        Me.txt_mann = New System.Windows.Forms.TextBox()
        Me.lbl_mann = New System.Windows.Forms.Label()
        Me.txt_cantidad = New System.Windows.Forms.TextBox()
        Me.lbl_cantidad = New System.Windows.Forms.Label()
        Me.txt_fram = New System.Windows.Forms.TextBox()
        Me.lbl_fram = New System.Windows.Forms.Label()
        Me.lbl_rosca = New System.Windows.Forms.Label()
        Me.txt_wega = New System.Windows.Forms.TextBox()
        Me.lbl_wega = New System.Windows.Forms.Label()
        Me.txt_factor = New System.Windows.Forms.TextBox()
        Me.lbl_factor = New System.Windows.Forms.Label()
        Me.lbl_proveedor = New System.Windows.Forms.Label()
        Me.lbl_marca = New System.Windows.Forms.Label()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.lbl_categoria = New System.Windows.Forms.Label()
        Me.txt_prclista = New System.Windows.Forms.TextBox()
        Me.lbl_preciolista = New System.Windows.Forms.Label()
        Me.txt_costo = New System.Windows.Forms.TextBox()
        Me.lbl_costo = New System.Windows.Forms.Label()
        Me.txt_desc = New System.Windows.Forms.TextBox()
        Me.lbl_desc = New System.Windows.Forms.Label()
        Me.txt_item = New System.Windows.Forms.TextBox()
        Me.lbl_item = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.cmb_preciolista = New System.Windows.Forms.ComboBox()
        Me.cmb_marca = New System.Windows.Forms.ComboBox()
        Me.cmb_categoria = New System.Windows.Forms.ComboBox()
        Me.cmb_factor = New System.Windows.Forms.ComboBox()
        Me.cmb_costo = New System.Windows.Forms.ComboBox()
        Me.cmd_desc = New System.Windows.Forms.ComboBox()
        Me.cmb_item = New System.Windows.Forms.ComboBox()
        Me.cmb_proveedor = New System.Windows.Forms.ComboBox()
        Me.cmb_wega = New System.Windows.Forms.ComboBox()
        Me.cmb_fram = New System.Windows.Forms.ComboBox()
        Me.cmb_mann = New System.Windows.Forms.ComboBox()
        Me.cmb_rosca = New System.Windows.Forms.ComboBox()
        Me.cmb_cantidad = New System.Windows.Forms.ComboBox()
        Me.lbl_activo = New System.Windows.Forms.Label()
        Me.cmb_activo = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'txt_mann
        '
        Me.txt_mann.Location = New System.Drawing.Point(384, 429)
        Me.txt_mann.Name = "txt_mann"
        Me.txt_mann.Size = New System.Drawing.Size(259, 20)
        Me.txt_mann.TabIndex = 68
        '
        'lbl_mann
        '
        Me.lbl_mann.AutoSize = True
        Me.lbl_mann.Location = New System.Drawing.Point(39, 435)
        Me.lbl_mann.Name = "lbl_mann"
        Me.lbl_mann.Size = New System.Drawing.Size(39, 13)
        Me.lbl_mann.TabIndex = 87
        Me.lbl_mann.Text = "MANN"
        '
        'txt_cantidad
        '
        Me.txt_cantidad.Location = New System.Drawing.Point(384, 511)
        Me.txt_cantidad.Name = "txt_cantidad"
        Me.txt_cantidad.Size = New System.Drawing.Size(259, 20)
        Me.txt_cantidad.TabIndex = 71
        '
        'lbl_cantidad
        '
        Me.lbl_cantidad.AutoSize = True
        Me.lbl_cantidad.Location = New System.Drawing.Point(38, 517)
        Me.lbl_cantidad.Name = "lbl_cantidad"
        Me.lbl_cantidad.Size = New System.Drawing.Size(49, 13)
        Me.lbl_cantidad.TabIndex = 86
        Me.lbl_cantidad.Text = "Cantidad"
        '
        'txt_fram
        '
        Me.txt_fram.Location = New System.Drawing.Point(385, 388)
        Me.txt_fram.Name = "txt_fram"
        Me.txt_fram.Size = New System.Drawing.Size(259, 20)
        Me.txt_fram.TabIndex = 67
        '
        'lbl_fram
        '
        Me.lbl_fram.AutoSize = True
        Me.lbl_fram.Location = New System.Drawing.Point(39, 394)
        Me.lbl_fram.Name = "lbl_fram"
        Me.lbl_fram.Size = New System.Drawing.Size(37, 13)
        Me.lbl_fram.TabIndex = 85
        Me.lbl_fram.Text = "FRAM"
        '
        'lbl_rosca
        '
        Me.lbl_rosca.AutoSize = True
        Me.lbl_rosca.Location = New System.Drawing.Point(38, 476)
        Me.lbl_rosca.Name = "lbl_rosca"
        Me.lbl_rosca.Size = New System.Drawing.Size(38, 13)
        Me.lbl_rosca.TabIndex = 83
        Me.lbl_rosca.Text = "Rosca"
        '
        'txt_wega
        '
        Me.txt_wega.Location = New System.Drawing.Point(385, 346)
        Me.txt_wega.Name = "txt_wega"
        Me.txt_wega.Size = New System.Drawing.Size(259, 20)
        Me.txt_wega.TabIndex = 65
        '
        'lbl_wega
        '
        Me.lbl_wega.AutoSize = True
        Me.lbl_wega.Location = New System.Drawing.Point(39, 352)
        Me.lbl_wega.Name = "lbl_wega"
        Me.lbl_wega.Size = New System.Drawing.Size(40, 13)
        Me.lbl_wega.TabIndex = 82
        Me.lbl_wega.Text = "WEGA"
        '
        'txt_factor
        '
        Me.txt_factor.Location = New System.Drawing.Point(385, 143)
        Me.txt_factor.Name = "txt_factor"
        Me.txt_factor.Size = New System.Drawing.Size(259, 20)
        Me.txt_factor.TabIndex = 58
        '
        'lbl_factor
        '
        Me.lbl_factor.AutoSize = True
        Me.lbl_factor.Location = New System.Drawing.Point(39, 149)
        Me.lbl_factor.Name = "lbl_factor"
        Me.lbl_factor.Size = New System.Drawing.Size(37, 13)
        Me.lbl_factor.TabIndex = 81
        Me.lbl_factor.Text = "Factor"
        '
        'lbl_proveedor
        '
        Me.lbl_proveedor.AutoSize = True
        Me.lbl_proveedor.Location = New System.Drawing.Point(40, 310)
        Me.lbl_proveedor.Name = "lbl_proveedor"
        Me.lbl_proveedor.Size = New System.Drawing.Size(56, 13)
        Me.lbl_proveedor.TabIndex = 76
        Me.lbl_proveedor.Text = "Proveedor"
        '
        'lbl_marca
        '
        Me.lbl_marca.AutoSize = True
        Me.lbl_marca.Location = New System.Drawing.Point(39, 265)
        Me.lbl_marca.Name = "lbl_marca"
        Me.lbl_marca.Size = New System.Drawing.Size(37, 13)
        Me.lbl_marca.TabIndex = 72
        Me.lbl_marca.Text = "Marca"
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(354, 614)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 77
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(254, 614)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 75
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'lbl_categoria
        '
        Me.lbl_categoria.AutoSize = True
        Me.lbl_categoria.Location = New System.Drawing.Point(39, 224)
        Me.lbl_categoria.Name = "lbl_categoria"
        Me.lbl_categoria.Size = New System.Drawing.Size(54, 13)
        Me.lbl_categoria.TabIndex = 66
        Me.lbl_categoria.Text = "Categoría"
        '
        'txt_prclista
        '
        Me.txt_prclista.Location = New System.Drawing.Point(385, 182)
        Me.txt_prclista.Name = "txt_prclista"
        Me.txt_prclista.Size = New System.Drawing.Size(259, 20)
        Me.txt_prclista.TabIndex = 59
        '
        'lbl_preciolista
        '
        Me.lbl_preciolista.AutoSize = True
        Me.lbl_preciolista.Location = New System.Drawing.Point(39, 185)
        Me.lbl_preciolista.Name = "lbl_preciolista"
        Me.lbl_preciolista.Size = New System.Drawing.Size(73, 13)
        Me.lbl_preciolista.TabIndex = 62
        Me.lbl_preciolista.Text = "Precio de lista"
        '
        'txt_costo
        '
        Me.txt_costo.Location = New System.Drawing.Point(385, 102)
        Me.txt_costo.Name = "txt_costo"
        Me.txt_costo.Size = New System.Drawing.Size(259, 20)
        Me.txt_costo.TabIndex = 57
        '
        'lbl_costo
        '
        Me.lbl_costo.AutoSize = True
        Me.lbl_costo.Location = New System.Drawing.Point(42, 108)
        Me.lbl_costo.Name = "lbl_costo"
        Me.lbl_costo.Size = New System.Drawing.Size(34, 13)
        Me.lbl_costo.TabIndex = 60
        Me.lbl_costo.Text = "Costo"
        '
        'txt_desc
        '
        Me.txt_desc.Location = New System.Drawing.Point(385, 61)
        Me.txt_desc.Name = "txt_desc"
        Me.txt_desc.Size = New System.Drawing.Size(259, 20)
        Me.txt_desc.TabIndex = 55
        '
        'lbl_desc
        '
        Me.lbl_desc.AutoSize = True
        Me.lbl_desc.Location = New System.Drawing.Point(42, 67)
        Me.lbl_desc.Name = "lbl_desc"
        Me.lbl_desc.Size = New System.Drawing.Size(63, 13)
        Me.lbl_desc.TabIndex = 56
        Me.lbl_desc.Text = "Descripción"
        '
        'txt_item
        '
        Me.txt_item.Location = New System.Drawing.Point(385, 23)
        Me.txt_item.Name = "txt_item"
        Me.txt_item.Size = New System.Drawing.Size(259, 20)
        Me.txt_item.TabIndex = 54
        '
        'lbl_item
        '
        Me.lbl_item.AutoSize = True
        Me.lbl_item.Location = New System.Drawing.Point(42, 26)
        Me.lbl_item.Name = "lbl_item"
        Me.lbl_item.Size = New System.Drawing.Size(27, 13)
        Me.lbl_item.TabIndex = 53
        Me.lbl_item.Text = "Item"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(385, 219)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(259, 20)
        Me.TextBox1.TabIndex = 88
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(385, 260)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(259, 20)
        Me.TextBox2.TabIndex = 89
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(385, 304)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(259, 20)
        Me.TextBox3.TabIndex = 90
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(385, 470)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(259, 20)
        Me.TextBox4.TabIndex = 91
        '
        'cmb_preciolista
        '
        Me.cmb_preciolista.FormattingEnabled = True
        Me.cmb_preciolista.Location = New System.Drawing.Point(136, 181)
        Me.cmb_preciolista.Name = "cmb_preciolista"
        Me.cmb_preciolista.Size = New System.Drawing.Size(213, 21)
        Me.cmb_preciolista.TabIndex = 92
        '
        'cmb_marca
        '
        Me.cmb_marca.FormattingEnabled = True
        Me.cmb_marca.Location = New System.Drawing.Point(136, 260)
        Me.cmb_marca.Name = "cmb_marca"
        Me.cmb_marca.Size = New System.Drawing.Size(213, 21)
        Me.cmb_marca.TabIndex = 93
        '
        'cmb_categoria
        '
        Me.cmb_categoria.FormattingEnabled = True
        Me.cmb_categoria.Location = New System.Drawing.Point(136, 219)
        Me.cmb_categoria.Name = "cmb_categoria"
        Me.cmb_categoria.Size = New System.Drawing.Size(213, 21)
        Me.cmb_categoria.TabIndex = 94
        '
        'cmb_factor
        '
        Me.cmb_factor.FormattingEnabled = True
        Me.cmb_factor.Location = New System.Drawing.Point(136, 143)
        Me.cmb_factor.Name = "cmb_factor"
        Me.cmb_factor.Size = New System.Drawing.Size(213, 21)
        Me.cmb_factor.TabIndex = 95
        '
        'cmb_costo
        '
        Me.cmb_costo.FormattingEnabled = True
        Me.cmb_costo.Location = New System.Drawing.Point(136, 102)
        Me.cmb_costo.Name = "cmb_costo"
        Me.cmb_costo.Size = New System.Drawing.Size(213, 21)
        Me.cmb_costo.TabIndex = 96
        '
        'cmd_desc
        '
        Me.cmd_desc.FormattingEnabled = True
        Me.cmd_desc.Location = New System.Drawing.Point(136, 61)
        Me.cmd_desc.Name = "cmd_desc"
        Me.cmd_desc.Size = New System.Drawing.Size(213, 21)
        Me.cmd_desc.TabIndex = 97
        '
        'cmb_item
        '
        Me.cmb_item.FormattingEnabled = True
        Me.cmb_item.Location = New System.Drawing.Point(136, 23)
        Me.cmb_item.Name = "cmb_item"
        Me.cmb_item.Size = New System.Drawing.Size(213, 21)
        Me.cmb_item.TabIndex = 98
        '
        'cmb_proveedor
        '
        Me.cmb_proveedor.FormattingEnabled = True
        Me.cmb_proveedor.Location = New System.Drawing.Point(136, 304)
        Me.cmb_proveedor.Name = "cmb_proveedor"
        Me.cmb_proveedor.Size = New System.Drawing.Size(213, 21)
        Me.cmb_proveedor.TabIndex = 99
        '
        'cmb_wega
        '
        Me.cmb_wega.FormattingEnabled = True
        Me.cmb_wega.Location = New System.Drawing.Point(136, 346)
        Me.cmb_wega.Name = "cmb_wega"
        Me.cmb_wega.Size = New System.Drawing.Size(213, 21)
        Me.cmb_wega.TabIndex = 100
        '
        'cmb_fram
        '
        Me.cmb_fram.FormattingEnabled = True
        Me.cmb_fram.Location = New System.Drawing.Point(136, 388)
        Me.cmb_fram.Name = "cmb_fram"
        Me.cmb_fram.Size = New System.Drawing.Size(213, 21)
        Me.cmb_fram.TabIndex = 101
        '
        'cmb_mann
        '
        Me.cmb_mann.FormattingEnabled = True
        Me.cmb_mann.Location = New System.Drawing.Point(136, 429)
        Me.cmb_mann.Name = "cmb_mann"
        Me.cmb_mann.Size = New System.Drawing.Size(213, 21)
        Me.cmb_mann.TabIndex = 102
        '
        'cmb_rosca
        '
        Me.cmb_rosca.FormattingEnabled = True
        Me.cmb_rosca.Location = New System.Drawing.Point(136, 470)
        Me.cmb_rosca.Name = "cmb_rosca"
        Me.cmb_rosca.Size = New System.Drawing.Size(213, 21)
        Me.cmb_rosca.TabIndex = 103
        '
        'cmb_cantidad
        '
        Me.cmb_cantidad.FormattingEnabled = True
        Me.cmb_cantidad.Location = New System.Drawing.Point(136, 511)
        Me.cmb_cantidad.Name = "cmb_cantidad"
        Me.cmb_cantidad.Size = New System.Drawing.Size(213, 21)
        Me.cmb_cantidad.TabIndex = 104
        '
        'lbl_activo
        '
        Me.lbl_activo.AutoSize = True
        Me.lbl_activo.Location = New System.Drawing.Point(38, 557)
        Me.lbl_activo.Name = "lbl_activo"
        Me.lbl_activo.Size = New System.Drawing.Size(37, 13)
        Me.lbl_activo.TabIndex = 105
        Me.lbl_activo.Text = "Activo"
        '
        'cmb_activo
        '
        Me.cmb_activo.FormattingEnabled = True
        Me.cmb_activo.Location = New System.Drawing.Point(136, 557)
        Me.cmb_activo.Name = "cmb_activo"
        Me.cmb_activo.Size = New System.Drawing.Size(213, 21)
        Me.cmb_activo.TabIndex = 106
        '
        'frm_searchitem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 649)
        Me.Controls.Add(Me.cmb_activo)
        Me.Controls.Add(Me.lbl_activo)
        Me.Controls.Add(Me.cmb_cantidad)
        Me.Controls.Add(Me.cmb_rosca)
        Me.Controls.Add(Me.cmb_mann)
        Me.Controls.Add(Me.cmb_fram)
        Me.Controls.Add(Me.cmb_wega)
        Me.Controls.Add(Me.cmb_proveedor)
        Me.Controls.Add(Me.cmb_item)
        Me.Controls.Add(Me.cmd_desc)
        Me.Controls.Add(Me.cmb_costo)
        Me.Controls.Add(Me.cmb_factor)
        Me.Controls.Add(Me.cmb_categoria)
        Me.Controls.Add(Me.cmb_marca)
        Me.Controls.Add(Me.cmb_preciolista)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.txt_mann)
        Me.Controls.Add(Me.lbl_mann)
        Me.Controls.Add(Me.txt_cantidad)
        Me.Controls.Add(Me.lbl_cantidad)
        Me.Controls.Add(Me.txt_fram)
        Me.Controls.Add(Me.lbl_fram)
        Me.Controls.Add(Me.lbl_rosca)
        Me.Controls.Add(Me.txt_wega)
        Me.Controls.Add(Me.lbl_wega)
        Me.Controls.Add(Me.txt_factor)
        Me.Controls.Add(Me.lbl_factor)
        Me.Controls.Add(Me.lbl_proveedor)
        Me.Controls.Add(Me.lbl_marca)
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
        Me.Name = "frm_searchitem"
        Me.Text = "frm_searchitem"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_mann As System.Windows.Forms.TextBox
    Friend WithEvents lbl_mann As System.Windows.Forms.Label
    Friend WithEvents txt_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents lbl_cantidad As System.Windows.Forms.Label
    Friend WithEvents txt_fram As System.Windows.Forms.TextBox
    Friend WithEvents lbl_fram As System.Windows.Forms.Label
    Friend WithEvents lbl_rosca As System.Windows.Forms.Label
    Friend WithEvents txt_wega As System.Windows.Forms.TextBox
    Friend WithEvents lbl_wega As System.Windows.Forms.Label
    Friend WithEvents txt_factor As System.Windows.Forms.TextBox
    Friend WithEvents lbl_factor As System.Windows.Forms.Label
    Friend WithEvents lbl_proveedor As System.Windows.Forms.Label
    Friend WithEvents lbl_marca As System.Windows.Forms.Label
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents lbl_categoria As System.Windows.Forms.Label
    Friend WithEvents txt_prclista As System.Windows.Forms.TextBox
    Friend WithEvents lbl_preciolista As System.Windows.Forms.Label
    Friend WithEvents txt_costo As System.Windows.Forms.TextBox
    Friend WithEvents lbl_costo As System.Windows.Forms.Label
    Friend WithEvents txt_desc As System.Windows.Forms.TextBox
    Friend WithEvents lbl_desc As System.Windows.Forms.Label
    Friend WithEvents txt_item As System.Windows.Forms.TextBox
    Friend WithEvents lbl_item As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents cmb_preciolista As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_marca As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_categoria As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_factor As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_costo As System.Windows.Forms.ComboBox
    Friend WithEvents cmd_desc As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_item As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_proveedor As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_wega As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_fram As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_mann As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_rosca As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_cantidad As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_activo As System.Windows.Forms.Label
    Friend WithEvents cmb_activo As System.Windows.Forms.ComboBox
End Class
