<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_descuento
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
        Me.chk_activo = New System.Windows.Forms.CheckBox()
        Me.txt_descript = New System.Windows.Forms.TextBox()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.lbl_descript = New System.Windows.Forms.Label()
        Me.txt_descuento = New System.Windows.Forms.TextBox()
        Me.lbl_descuento = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'chk_activo
        '
        Me.chk_activo.AutoSize = True
        Me.chk_activo.Location = New System.Drawing.Point(28, 111)
        Me.chk_activo.Name = "chk_activo"
        Me.chk_activo.Size = New System.Drawing.Size(110, 17)
        Me.chk_activo.TabIndex = 2
        Me.chk_activo.Text = "Descuento activo"
        Me.chk_activo.UseVisualStyleBackColor = True
        '
        'txt_descript
        '
        Me.txt_descript.Location = New System.Drawing.Point(98, 29)
        Me.txt_descript.Name = "txt_descript"
        Me.txt_descript.Size = New System.Drawing.Size(259, 20)
        Me.txt_descript.TabIndex = 0
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Location = New System.Drawing.Point(28, 143)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(108, 17)
        Me.chk_secuencia.TabIndex = 3
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(196, 179)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 5
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(98, 179)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 4
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'lbl_descript
        '
        Me.lbl_descript.AutoSize = True
        Me.lbl_descript.Location = New System.Drawing.Point(20, 36)
        Me.lbl_descript.Name = "lbl_descript"
        Me.lbl_descript.Size = New System.Drawing.Size(63, 13)
        Me.lbl_descript.TabIndex = 6
        Me.lbl_descript.Text = "Descripción"
        '
        'txt_descuento
        '
        Me.txt_descuento.Location = New System.Drawing.Point(98, 67)
        Me.txt_descuento.Name = "txt_descuento"
        Me.txt_descuento.Size = New System.Drawing.Size(259, 20)
        Me.txt_descuento.TabIndex = 1
        '
        'lbl_descuento
        '
        Me.lbl_descuento.AutoSize = True
        Me.lbl_descuento.Location = New System.Drawing.Point(20, 74)
        Me.lbl_descuento.Name = "lbl_descuento"
        Me.lbl_descuento.Size = New System.Drawing.Size(76, 13)
        Me.lbl_descuento.TabIndex = 12
        Me.lbl_descuento.Text = "Descuento (%)"
        '
        'add_descuento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 230)
        Me.Controls.Add(Me.txt_descuento)
        Me.Controls.Add(Me.lbl_descuento)
        Me.Controls.Add(Me.chk_activo)
        Me.Controls.Add(Me.txt_descript)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.lbl_descript)
        Me.Name = "add_descuento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agregar descuento"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chk_activo As System.Windows.Forms.CheckBox
    Friend WithEvents txt_descript As System.Windows.Forms.TextBox
    Friend WithEvents chk_secuencia As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents lbl_descript As System.Windows.Forms.Label
    Friend WithEvents txt_descuento As System.Windows.Forms.TextBox
    Friend WithEvents lbl_descuento As System.Windows.Forms.Label
End Class
