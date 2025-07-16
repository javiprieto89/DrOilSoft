<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_vendedor
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
        Me.lbl_nombre = New System.Windows.Forms.Label()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.txt_nombre = New System.Windows.Forms.TextBox()
        Me.chk_activo = New System.Windows.Forms.CheckBox()
        Me.txt_porcentaje = New System.Windows.Forms.TextBox()
        Me.lbl_porcentaje = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbl_nombre
        '
        Me.lbl_nombre.AutoSize = True
        Me.lbl_nombre.Location = New System.Drawing.Point(35, 29)
        Me.lbl_nombre.Name = "lbl_nombre"
        Me.lbl_nombre.Size = New System.Drawing.Size(44, 13)
        Me.lbl_nombre.TabIndex = 0
        Me.lbl_nombre.Text = "Nombre"
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Location = New System.Drawing.Point(37, 136)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(108, 17)
        Me.chk_secuencia.TabIndex = 3
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(205, 172)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 5
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(107, 172)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 4
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'txt_nombre
        '
        Me.txt_nombre.Location = New System.Drawing.Point(107, 22)
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.Size = New System.Drawing.Size(259, 20)
        Me.txt_nombre.TabIndex = 0
        '
        'chk_activo
        '
        Me.chk_activo.AutoSize = True
        Me.chk_activo.Location = New System.Drawing.Point(37, 104)
        Me.chk_activo.Name = "chk_activo"
        Me.chk_activo.Size = New System.Drawing.Size(104, 17)
        Me.chk_activo.TabIndex = 2
        Me.chk_activo.Text = "Vendedor activo"
        Me.chk_activo.UseVisualStyleBackColor = True
        '
        'txt_porcentaje
        '
        Me.txt_porcentaje.Location = New System.Drawing.Point(109, 62)
        Me.txt_porcentaje.Name = "txt_porcentaje"
        Me.txt_porcentaje.Size = New System.Drawing.Size(259, 20)
        Me.txt_porcentaje.TabIndex = 1
        '
        'lbl_porcentaje
        '
        Me.lbl_porcentaje.AutoSize = True
        Me.lbl_porcentaje.Location = New System.Drawing.Point(35, 69)
        Me.lbl_porcentaje.Name = "lbl_porcentaje"
        Me.lbl_porcentaje.Size = New System.Drawing.Size(69, 13)
        Me.lbl_porcentaje.TabIndex = 6
        Me.lbl_porcentaje.Text = "Porcentaje %"
        '
        'add_vendedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(402, 217)
        Me.Controls.Add(Me.txt_porcentaje)
        Me.Controls.Add(Me.lbl_porcentaje)
        Me.Controls.Add(Me.chk_activo)
        Me.Controls.Add(Me.txt_nombre)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.lbl_nombre)
        Me.Name = "add_vendedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Insertar vendedor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_nombre As System.Windows.Forms.Label
    Friend WithEvents chk_secuencia As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents txt_nombre As System.Windows.Forms.TextBox
    Friend WithEvents chk_activo As System.Windows.Forms.CheckBox
    Friend WithEvents txt_porcentaje As TextBox
    Friend WithEvents lbl_porcentaje As Label
End Class
