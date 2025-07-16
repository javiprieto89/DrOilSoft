<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_pagoCombinado
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
        Me.lbl_condicion = New System.Windows.Forms.Label()
        Me.lbl_montoContado = New System.Windows.Forms.Label()
        Me.lbl_montoTarjeta = New System.Windows.Forms.Label()
        Me.lbl_total = New System.Windows.Forms.Label()
        Me.txt_condicion = New System.Windows.Forms.TextBox()
        Me.txt_montoTarjeta = New System.Windows.Forms.TextBox()
        Me.txt_total = New System.Windows.Forms.TextBox()
        Me.txt_montoContado = New System.Windows.Forms.TextBox()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.txt_recargo = New System.Windows.Forms.TextBox()
        Me.lbl_recargo = New System.Windows.Forms.Label()
        Me.lbl_montoConRecargo = New System.Windows.Forms.Label()
        Me.txt_montoConRecargo = New System.Windows.Forms.TextBox()
        Me.txt_descuento = New System.Windows.Forms.TextBox()
        Me.lbl_descuento = New System.Windows.Forms.Label()
        Me.txt_subtotal = New System.Windows.Forms.TextBox()
        Me.lbl_subtotal = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbl_condicion
        '
        Me.lbl_condicion.AutoSize = True
        Me.lbl_condicion.Location = New System.Drawing.Point(23, 31)
        Me.lbl_condicion.Name = "lbl_condicion"
        Me.lbl_condicion.Size = New System.Drawing.Size(99, 13)
        Me.lbl_condicion.TabIndex = 12
        Me.lbl_condicion.Text = "Condición de venta"
        '
        'lbl_montoContado
        '
        Me.lbl_montoContado.AutoSize = True
        Me.lbl_montoContado.Location = New System.Drawing.Point(23, 69)
        Me.lbl_montoContado.Name = "lbl_montoContado"
        Me.lbl_montoContado.Size = New System.Drawing.Size(93, 13)
        Me.lbl_montoContado.TabIndex = 14
        Me.lbl_montoContado.Text = "Monto en efectivo"
        '
        'lbl_montoTarjeta
        '
        Me.lbl_montoTarjeta.Location = New System.Drawing.Point(23, 130)
        Me.lbl_montoTarjeta.Name = "lbl_montoTarjeta"
        Me.lbl_montoTarjeta.Size = New System.Drawing.Size(111, 29)
        Me.lbl_montoTarjeta.TabIndex = 15
        Me.lbl_montoTarjeta.Text = "Monto tarjeta sin recargo aplicado"
        '
        'lbl_total
        '
        Me.lbl_total.AutoSize = True
        Me.lbl_total.Location = New System.Drawing.Point(23, 256)
        Me.lbl_total.Name = "lbl_total"
        Me.lbl_total.Size = New System.Drawing.Size(31, 13)
        Me.lbl_total.TabIndex = 16
        Me.lbl_total.Text = "Total"
        '
        'txt_condicion
        '
        Me.txt_condicion.Location = New System.Drawing.Point(160, 28)
        Me.txt_condicion.Name = "txt_condicion"
        Me.txt_condicion.ReadOnly = True
        Me.txt_condicion.Size = New System.Drawing.Size(295, 20)
        Me.txt_condicion.TabIndex = 0
        '
        'txt_montoTarjeta
        '
        Me.txt_montoTarjeta.Location = New System.Drawing.Point(160, 130)
        Me.txt_montoTarjeta.Name = "txt_montoTarjeta"
        Me.txt_montoTarjeta.ReadOnly = True
        Me.txt_montoTarjeta.Size = New System.Drawing.Size(295, 20)
        Me.txt_montoTarjeta.TabIndex = 2
        '
        'txt_total
        '
        Me.txt_total.Location = New System.Drawing.Point(160, 245)
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.Size = New System.Drawing.Size(295, 20)
        Me.txt_total.TabIndex = 3
        '
        'txt_montoContado
        '
        Me.txt_montoContado.Location = New System.Drawing.Point(160, 64)
        Me.txt_montoContado.Name = "txt_montoContado"
        Me.txt_montoContado.Size = New System.Drawing.Size(295, 20)
        Me.txt_montoContado.TabIndex = 1
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(174, 307)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(111, 33)
        Me.cmd_ok.TabIndex = 4
        Me.cmd_ok.Text = "Aceptar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'txt_recargo
        '
        Me.txt_recargo.Location = New System.Drawing.Point(160, 169)
        Me.txt_recargo.Name = "txt_recargo"
        Me.txt_recargo.ReadOnly = True
        Me.txt_recargo.Size = New System.Drawing.Size(53, 20)
        Me.txt_recargo.TabIndex = 17
        '
        'lbl_recargo
        '
        Me.lbl_recargo.AutoSize = True
        Me.lbl_recargo.Location = New System.Drawing.Point(23, 175)
        Me.lbl_recargo.Name = "lbl_recargo"
        Me.lbl_recargo.Size = New System.Drawing.Size(48, 13)
        Me.lbl_recargo.TabIndex = 18
        Me.lbl_recargo.Text = "Recargo"
        '
        'lbl_montoConRecargo
        '
        Me.lbl_montoConRecargo.Location = New System.Drawing.Point(244, 166)
        Me.lbl_montoConRecargo.Name = "lbl_montoConRecargo"
        Me.lbl_montoConRecargo.Size = New System.Drawing.Size(98, 27)
        Me.lbl_montoConRecargo.TabIndex = 19
        Me.lbl_montoConRecargo.Text = "Monto tarjeta con recargo aplicado"
        '
        'txt_montoConRecargo
        '
        Me.txt_montoConRecargo.Location = New System.Drawing.Point(368, 166)
        Me.txt_montoConRecargo.Name = "txt_montoConRecargo"
        Me.txt_montoConRecargo.ReadOnly = True
        Me.txt_montoConRecargo.Size = New System.Drawing.Size(87, 20)
        Me.txt_montoConRecargo.TabIndex = 20
        '
        'txt_descuento
        '
        Me.txt_descuento.Location = New System.Drawing.Point(160, 97)
        Me.txt_descuento.Name = "txt_descuento"
        Me.txt_descuento.ReadOnly = True
        Me.txt_descuento.Size = New System.Drawing.Size(295, 20)
        Me.txt_descuento.TabIndex = 21
        '
        'lbl_descuento
        '
        Me.lbl_descuento.AutoSize = True
        Me.lbl_descuento.Location = New System.Drawing.Point(23, 104)
        Me.lbl_descuento.Name = "lbl_descuento"
        Me.lbl_descuento.Size = New System.Drawing.Size(59, 13)
        Me.lbl_descuento.TabIndex = 22
        Me.lbl_descuento.Text = "Descuento"
        '
        'txt_subtotal
        '
        Me.txt_subtotal.Location = New System.Drawing.Point(160, 207)
        Me.txt_subtotal.Name = "txt_subtotal"
        Me.txt_subtotal.ReadOnly = True
        Me.txt_subtotal.Size = New System.Drawing.Size(295, 20)
        Me.txt_subtotal.TabIndex = 23
        '
        'lbl_subtotal
        '
        Me.lbl_subtotal.AutoSize = True
        Me.lbl_subtotal.Location = New System.Drawing.Point(23, 218)
        Me.lbl_subtotal.Name = "lbl_subtotal"
        Me.lbl_subtotal.Size = New System.Drawing.Size(46, 13)
        Me.lbl_subtotal.TabIndex = 24
        Me.lbl_subtotal.Text = "Subtotal"
        '
        'add_pagoCombinado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 362)
        Me.ControlBox = False
        Me.Controls.Add(Me.txt_subtotal)
        Me.Controls.Add(Me.lbl_subtotal)
        Me.Controls.Add(Me.txt_descuento)
        Me.Controls.Add(Me.lbl_descuento)
        Me.Controls.Add(Me.txt_montoConRecargo)
        Me.Controls.Add(Me.lbl_montoConRecargo)
        Me.Controls.Add(Me.txt_recargo)
        Me.Controls.Add(Me.lbl_recargo)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.txt_montoContado)
        Me.Controls.Add(Me.txt_total)
        Me.Controls.Add(Me.txt_montoTarjeta)
        Me.Controls.Add(Me.txt_condicion)
        Me.Controls.Add(Me.lbl_total)
        Me.Controls.Add(Me.lbl_montoTarjeta)
        Me.Controls.Add(Me.lbl_montoContado)
        Me.Controls.Add(Me.lbl_condicion)
        Me.Name = "add_pagoCombinado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Pago combinado"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_condicion As System.Windows.Forms.Label
    Friend WithEvents lbl_montoContado As System.Windows.Forms.Label
    Friend WithEvents lbl_montoTarjeta As System.Windows.Forms.Label
    Friend WithEvents lbl_total As System.Windows.Forms.Label
    Friend WithEvents txt_condicion As System.Windows.Forms.TextBox
    Friend WithEvents txt_montoTarjeta As System.Windows.Forms.TextBox
    Friend WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents txt_montoContado As System.Windows.Forms.TextBox
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents txt_recargo As System.Windows.Forms.TextBox
    Friend WithEvents lbl_recargo As System.Windows.Forms.Label
    Friend WithEvents lbl_montoConRecargo As System.Windows.Forms.Label
    Friend WithEvents txt_montoConRecargo As System.Windows.Forms.TextBox
    Friend WithEvents txt_descuento As TextBox
    Friend WithEvents lbl_descuento As Label
    Friend WithEvents txt_subtotal As TextBox
    Friend WithEvents lbl_subtotal As Label
End Class
