<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_proveedor
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
        Me.txt_nombre = New System.Windows.Forms.TextBox()
        Me.txt_dni = New System.Windows.Forms.TextBox()
        Me.lbl_dni = New System.Windows.Forms.Label()
        Me.txt_tel = New System.Windows.Forms.TextBox()
        Me.lbl_tel = New System.Windows.Forms.Label()
        Me.txt_direccion = New System.Windows.Forms.TextBox()
        Me.lbl_direccion = New System.Windows.Forms.Label()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.chk_activo = New System.Windows.Forms.CheckBox()
        Me.txt_vendedor = New System.Windows.Forms.TextBox()
        Me.lbl_vendedor = New System.Windows.Forms.Label()
        Me.txt_email = New System.Windows.Forms.TextBox()
        Me.lbl_email = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbl_nombre
        '
        Me.lbl_nombre.AutoSize = True
        Me.lbl_nombre.Location = New System.Drawing.Point(41, 29)
        Me.lbl_nombre.Name = "lbl_nombre"
        Me.lbl_nombre.Size = New System.Drawing.Size(44, 13)
        Me.lbl_nombre.TabIndex = 0
        Me.lbl_nombre.Text = "Nombre"
        '
        'txt_nombre
        '
        Me.txt_nombre.Location = New System.Drawing.Point(104, 26)
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.Size = New System.Drawing.Size(163, 20)
        Me.txt_nombre.TabIndex = 0
        '
        'txt_dni
        '
        Me.txt_dni.Location = New System.Drawing.Point(104, 69)
        Me.txt_dni.Name = "txt_dni"
        Me.txt_dni.Size = New System.Drawing.Size(163, 20)
        Me.txt_dni.TabIndex = 1
        '
        'lbl_dni
        '
        Me.lbl_dni.AutoSize = True
        Me.lbl_dni.Location = New System.Drawing.Point(41, 72)
        Me.lbl_dni.Name = "lbl_dni"
        Me.lbl_dni.Size = New System.Drawing.Size(56, 13)
        Me.lbl_dni.TabIndex = 4
        Me.lbl_dni.Text = "DNI/CUIT"
        '
        'txt_tel
        '
        Me.txt_tel.Location = New System.Drawing.Point(104, 117)
        Me.txt_tel.Name = "txt_tel"
        Me.txt_tel.Size = New System.Drawing.Size(163, 20)
        Me.txt_tel.TabIndex = 2
        '
        'lbl_tel
        '
        Me.lbl_tel.AutoSize = True
        Me.lbl_tel.Location = New System.Drawing.Point(41, 120)
        Me.lbl_tel.Name = "lbl_tel"
        Me.lbl_tel.Size = New System.Drawing.Size(49, 13)
        Me.lbl_tel.TabIndex = 6
        Me.lbl_tel.Text = "Teléfono"
        '
        'txt_direccion
        '
        Me.txt_direccion.Location = New System.Drawing.Point(104, 204)
        Me.txt_direccion.Name = "txt_direccion"
        Me.txt_direccion.Size = New System.Drawing.Size(163, 20)
        Me.txt_direccion.TabIndex = 3
        '
        'lbl_direccion
        '
        Me.lbl_direccion.AutoSize = True
        Me.lbl_direccion.Location = New System.Drawing.Point(41, 207)
        Me.lbl_direccion.Name = "lbl_direccion"
        Me.lbl_direccion.Size = New System.Drawing.Size(52, 13)
        Me.lbl_direccion.TabIndex = 8
        Me.lbl_direccion.Text = "Dirección"
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(58, 378)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 7
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(157, 378)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 8
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Location = New System.Drawing.Point(43, 333)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(108, 17)
        Me.chk_secuencia.TabIndex = 6
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        '
        'chk_activo
        '
        Me.chk_activo.AutoSize = True
        Me.chk_activo.Location = New System.Drawing.Point(43, 297)
        Me.chk_activo.Name = "chk_activo"
        Me.chk_activo.Size = New System.Drawing.Size(107, 17)
        Me.chk_activo.TabIndex = 5
        Me.chk_activo.Text = "Proovedor activo"
        Me.chk_activo.UseVisualStyleBackColor = True
        '
        'txt_vendedor
        '
        Me.txt_vendedor.Location = New System.Drawing.Point(104, 248)
        Me.txt_vendedor.Name = "txt_vendedor"
        Me.txt_vendedor.Size = New System.Drawing.Size(163, 20)
        Me.txt_vendedor.TabIndex = 4
        '
        'lbl_vendedor
        '
        Me.lbl_vendedor.AutoSize = True
        Me.lbl_vendedor.Location = New System.Drawing.Point(41, 252)
        Me.lbl_vendedor.Name = "lbl_vendedor"
        Me.lbl_vendedor.Size = New System.Drawing.Size(53, 13)
        Me.lbl_vendedor.TabIndex = 10
        Me.lbl_vendedor.Text = "Vendedor"
        '
        'txt_email
        '
        Me.txt_email.Location = New System.Drawing.Point(104, 161)
        Me.txt_email.Name = "txt_email"
        Me.txt_email.Size = New System.Drawing.Size(163, 20)
        Me.txt_email.TabIndex = 11
        '
        'lbl_email
        '
        Me.lbl_email.AutoSize = True
        Me.lbl_email.Location = New System.Drawing.Point(41, 164)
        Me.lbl_email.Name = "lbl_email"
        Me.lbl_email.Size = New System.Drawing.Size(32, 13)
        Me.lbl_email.TabIndex = 12
        Me.lbl_email.Text = "Email"
        '
        'add_proveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(308, 431)
        Me.Controls.Add(Me.txt_email)
        Me.Controls.Add(Me.lbl_email)
        Me.Controls.Add(Me.txt_vendedor)
        Me.Controls.Add(Me.lbl_vendedor)
        Me.Controls.Add(Me.chk_activo)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.txt_direccion)
        Me.Controls.Add(Me.lbl_direccion)
        Me.Controls.Add(Me.txt_tel)
        Me.Controls.Add(Me.lbl_tel)
        Me.Controls.Add(Me.txt_dni)
        Me.Controls.Add(Me.lbl_dni)
        Me.Controls.Add(Me.txt_nombre)
        Me.Controls.Add(Me.lbl_nombre)
        Me.Name = "add_proveedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Insertar Proveedor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_nombre As System.Windows.Forms.Label
    Friend WithEvents txt_nombre As System.Windows.Forms.TextBox
    Friend WithEvents txt_dni As System.Windows.Forms.TextBox
    Friend WithEvents lbl_dni As System.Windows.Forms.Label
    Friend WithEvents txt_tel As System.Windows.Forms.TextBox
    Friend WithEvents lbl_tel As System.Windows.Forms.Label
    Friend WithEvents txt_direccion As System.Windows.Forms.TextBox
    Friend WithEvents lbl_direccion As System.Windows.Forms.Label
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents chk_secuencia As System.Windows.Forms.CheckBox
    Friend WithEvents chk_activo As System.Windows.Forms.CheckBox
    Friend WithEvents txt_vendedor As System.Windows.Forms.TextBox
    Friend WithEvents lbl_vendedor As System.Windows.Forms.Label
    Friend WithEvents txt_email As TextBox
    Friend WithEvents lbl_email As Label
End Class
