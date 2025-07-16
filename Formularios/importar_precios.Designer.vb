<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class importar_precios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(importar_precios))
        Me.dgv_items = New System.Windows.Forms.DataGridView()
        Me.item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.costo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.markup = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.precio_lista = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lbl_nota = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chk_precioLista = New System.Windows.Forms.CheckBox()
        Me.chk_descuento = New System.Windows.Forms.CheckBox()
        Me.chk_markup = New System.Windows.Forms.CheckBox()
        Me.chk_costo = New System.Windows.Forms.CheckBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_importar = New System.Windows.Forms.Button()
        Me.txt_archivoSeleccionado = New System.Windows.Forms.TextBox()
        Me.cmd_cargar = New System.Windows.Forms.Button()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.cmd_planillaEjemplo = New System.Windows.Forms.Button()
        CType(Me.dgv_items, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv_items
        '
        Me.dgv_items.AllowUserToAddRows = False
        Me.dgv_items.AllowUserToDeleteRows = False
        Me.dgv_items.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.dgv_items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_items.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.item, Me.costo, Me.markup, Me.descuento, Me.precio_lista})
        Me.dgv_items.Location = New System.Drawing.Point(27, 307)
        Me.dgv_items.MultiSelect = False
        Me.dgv_items.Name = "dgv_items"
        Me.dgv_items.ReadOnly = True
        Me.dgv_items.Size = New System.Drawing.Size(599, 367)
        Me.dgv_items.TabIndex = 0
        '
        'item
        '
        Me.item.Frozen = True
        Me.item.HeaderText = "Item"
        Me.item.Name = "item"
        Me.item.ReadOnly = True
        Me.item.Width = 52
        '
        'costo
        '
        Me.costo.Frozen = True
        Me.costo.HeaderText = "Costo"
        Me.costo.Name = "costo"
        Me.costo.ReadOnly = True
        Me.costo.Width = 59
        '
        'markup
        '
        Me.markup.Frozen = True
        Me.markup.HeaderText = "Markup"
        Me.markup.Name = "markup"
        Me.markup.ReadOnly = True
        Me.markup.Width = 68
        '
        'descuento
        '
        Me.descuento.Frozen = True
        Me.descuento.HeaderText = "Descuento"
        Me.descuento.Name = "descuento"
        Me.descuento.ReadOnly = True
        Me.descuento.Width = 84
        '
        'precio_lista
        '
        Me.precio_lista.Frozen = True
        Me.precio_lista.HeaderText = "Precio de lista"
        Me.precio_lista.Name = "precio_lista"
        Me.precio_lista.ReadOnly = True
        Me.precio_lista.Width = 98
        '
        'lbl_nota
        '
        Me.lbl_nota.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_nota.ForeColor = System.Drawing.Color.Red
        Me.lbl_nota.Location = New System.Drawing.Point(18, 9)
        Me.lbl_nota.Name = "lbl_nota"
        Me.lbl_nota.Size = New System.Drawing.Size(611, 153)
        Me.lbl_nota.TabIndex = 1
        Me.lbl_nota.Text = resources.GetString("lbl_nota.Text")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmd_planillaEjemplo)
        Me.GroupBox1.Controls.Add(Me.chk_precioLista)
        Me.GroupBox1.Controls.Add(Me.chk_descuento)
        Me.GroupBox1.Controls.Add(Me.chk_markup)
        Me.GroupBox1.Controls.Add(Me.chk_costo)
        Me.GroupBox1.Location = New System.Drawing.Point(21, 179)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(605, 67)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seleccione que desea importar"
        '
        'chk_precioLista
        '
        Me.chk_precioLista.AutoSize = True
        Me.chk_precioLista.Checked = True
        Me.chk_precioLista.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_precioLista.Location = New System.Drawing.Point(293, 31)
        Me.chk_precioLista.Name = "chk_precioLista"
        Me.chk_precioLista.Size = New System.Drawing.Size(92, 17)
        Me.chk_precioLista.TabIndex = 3
        Me.chk_precioLista.Text = "Precio de lista"
        Me.chk_precioLista.UseVisualStyleBackColor = True
        '
        'chk_descuento
        '
        Me.chk_descuento.AutoSize = True
        Me.chk_descuento.Checked = True
        Me.chk_descuento.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_descuento.Location = New System.Drawing.Point(189, 31)
        Me.chk_descuento.Name = "chk_descuento"
        Me.chk_descuento.Size = New System.Drawing.Size(78, 17)
        Me.chk_descuento.TabIndex = 2
        Me.chk_descuento.Text = "Descuento"
        Me.chk_descuento.UseVisualStyleBackColor = True
        '
        'chk_markup
        '
        Me.chk_markup.AutoSize = True
        Me.chk_markup.Checked = True
        Me.chk_markup.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_markup.Location = New System.Drawing.Point(101, 31)
        Me.chk_markup.Name = "chk_markup"
        Me.chk_markup.Size = New System.Drawing.Size(62, 17)
        Me.chk_markup.TabIndex = 1
        Me.chk_markup.Text = "Markup"
        Me.chk_markup.UseVisualStyleBackColor = True
        '
        'chk_costo
        '
        Me.chk_costo.AutoSize = True
        Me.chk_costo.Checked = True
        Me.chk_costo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_costo.Location = New System.Drawing.Point(22, 31)
        Me.chk_costo.Name = "chk_costo"
        Me.chk_costo.Size = New System.Drawing.Size(53, 17)
        Me.chk_costo.TabIndex = 0
        Me.chk_costo.Text = "Costo"
        Me.chk_costo.UseVisualStyleBackColor = True
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(335, 691)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 10
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_importar
        '
        Me.cmd_importar.Location = New System.Drawing.Point(237, 691)
        Me.cmd_importar.Name = "cmd_importar"
        Me.cmd_importar.Size = New System.Drawing.Size(75, 23)
        Me.cmd_importar.TabIndex = 9
        Me.cmd_importar.Text = "Importar"
        Me.cmd_importar.UseVisualStyleBackColor = True
        '
        'txt_archivoSeleccionado
        '
        Me.txt_archivoSeleccionado.Location = New System.Drawing.Point(27, 268)
        Me.txt_archivoSeleccionado.Name = "txt_archivoSeleccionado"
        Me.txt_archivoSeleccionado.Size = New System.Drawing.Size(518, 20)
        Me.txt_archivoSeleccionado.TabIndex = 12
        Me.txt_archivoSeleccionado.Text = "Haga click aquí para seleccionar el archivo a importar"
        '
        'cmd_cargar
        '
        Me.cmd_cargar.Location = New System.Drawing.Point(551, 265)
        Me.cmd_cargar.Name = "cmd_cargar"
        Me.cmd_cargar.Size = New System.Drawing.Size(75, 23)
        Me.cmd_cargar.TabIndex = 13
        Me.cmd_cargar.Text = "Cargar"
        Me.cmd_cargar.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.DefaultExt = "xls"
        '
        'cmd_planillaEjemplo
        '
        Me.cmd_planillaEjemplo.Location = New System.Drawing.Point(420, 25)
        Me.cmd_planillaEjemplo.Name = "cmd_planillaEjemplo"
        Me.cmd_planillaEjemplo.Size = New System.Drawing.Size(166, 23)
        Me.cmd_planillaEjemplo.TabIndex = 14
        Me.cmd_planillaEjemplo.Text = "Descargar planilla de ejemplo"
        Me.cmd_planillaEjemplo.UseVisualStyleBackColor = True
        '
        'importar_precios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(647, 726)
        Me.Controls.Add(Me.cmd_cargar)
        Me.Controls.Add(Me.txt_archivoSeleccionado)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_importar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbl_nota)
        Me.Controls.Add(Me.dgv_items)
        Me.Name = "importar_precios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Importación/actualización de precios"
        CType(Me.dgv_items, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_items As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_nota As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_precioLista As System.Windows.Forms.CheckBox
    Friend WithEvents chk_descuento As System.Windows.Forms.CheckBox
    Friend WithEvents chk_markup As System.Windows.Forms.CheckBox
    Friend WithEvents chk_costo As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents cmd_importar As System.Windows.Forms.Button
    Friend WithEvents txt_archivoSeleccionado As System.Windows.Forms.TextBox
    Friend WithEvents cmd_cargar As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents costo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents markup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descuento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents precio_lista As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmd_planillaEjemplo As Button
End Class
