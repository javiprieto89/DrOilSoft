<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class exportar_precios
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
        Me.cmd_exportar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chk_precioLista = New System.Windows.Forms.CheckBox()
        Me.chk_descuento = New System.Windows.Forms.CheckBox()
        Me.chk_markup = New System.Windows.Forms.CheckBox()
        Me.chk_costo = New System.Windows.Forms.CheckBox()
        Me.dgv_items = New System.Windows.Forms.DataGridView()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_items, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(325, 531)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 14
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_exportar
        '
        Me.cmd_exportar.Location = New System.Drawing.Point(227, 531)
        Me.cmd_exportar.Name = "cmd_exportar"
        Me.cmd_exportar.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exportar.TabIndex = 13
        Me.cmd_exportar.Text = "Exportar"
        Me.cmd_exportar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chk_precioLista)
        Me.GroupBox1.Controls.Add(Me.chk_descuento)
        Me.GroupBox1.Controls.Add(Me.chk_markup)
        Me.GroupBox1.Controls.Add(Me.chk_costo)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(605, 67)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seleccione que desea exportar"
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
        'dgv_items
        '
        Me.dgv_items.AllowUserToAddRows = False
        Me.dgv_items.AllowUserToDeleteRows = False
        Me.dgv_items.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.dgv_items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_items.Location = New System.Drawing.Point(17, 126)
        Me.dgv_items.MultiSelect = False
        Me.dgv_items.Name = "dgv_items"
        Me.dgv_items.ReadOnly = True
        Me.dgv_items.Size = New System.Drawing.Size(605, 367)
        Me.dgv_items.TabIndex = 11
        '
        'exportar_precios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 590)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_exportar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgv_items)
        Me.Name = "exportar_precios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Exportar precios"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgv_items, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents cmd_exportar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_precioLista As System.Windows.Forms.CheckBox
    Friend WithEvents chk_descuento As System.Windows.Forms.CheckBox
    Friend WithEvents chk_markup As System.Windows.Forms.CheckBox
    Friend WithEvents chk_costo As System.Windows.Forms.CheckBox
    Friend WithEvents dgv_items As System.Windows.Forms.DataGridView
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
End Class
