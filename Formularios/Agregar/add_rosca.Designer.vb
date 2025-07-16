<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_rosca
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
        Me.txt_rosca = New System.Windows.Forms.TextBox()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.lbl_rosca = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'chk_activo
        '
        Me.chk_activo.AutoSize = True
        Me.chk_activo.Location = New System.Drawing.Point(32, 64)
        Me.chk_activo.Margin = New System.Windows.Forms.Padding(4)
        Me.chk_activo.Name = "chk_activo"
        Me.chk_activo.Size = New System.Drawing.Size(111, 21)
        Me.chk_activo.TabIndex = 1
        Me.chk_activo.Text = "Rosca activa"
        Me.chk_activo.UseVisualStyleBackColor = True
        '
        'txt_rosca
        '
        Me.txt_rosca.Location = New System.Drawing.Point(104, 20)
        Me.txt_rosca.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_rosca.Name = "txt_rosca"
        Me.txt_rosca.Size = New System.Drawing.Size(344, 22)
        Me.txt_rosca.TabIndex = 0
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Location = New System.Drawing.Point(32, 104)
        Me.chk_secuencia.Margin = New System.Windows.Forms.Padding(4)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(139, 21)
        Me.chk_secuencia.TabIndex = 2
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(253, 148)
        Me.cmd_exit.Margin = New System.Windows.Forms.Padding(4)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(100, 28)
        Me.cmd_exit.TabIndex = 4
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(123, 148)
        Me.cmd_ok.Margin = New System.Windows.Forms.Padding(4)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(100, 28)
        Me.cmd_ok.TabIndex = 3
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'lbl_rosca
        '
        Me.lbl_rosca.AutoSize = True
        Me.lbl_rosca.Location = New System.Drawing.Point(29, 28)
        Me.lbl_rosca.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_rosca.Name = "lbl_rosca"
        Me.lbl_rosca.Size = New System.Drawing.Size(48, 17)
        Me.lbl_rosca.TabIndex = 18
        Me.lbl_rosca.Text = "Rosca"
        '
        'add_rosca
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(477, 197)
        Me.Controls.Add(Me.chk_activo)
        Me.Controls.Add(Me.txt_rosca)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.lbl_rosca)
        Me.Name = "add_rosca"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agregar rosca"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chk_activo As System.Windows.Forms.CheckBox
    Friend WithEvents txt_rosca As System.Windows.Forms.TextBox
    Friend WithEvents chk_secuencia As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents lbl_rosca As System.Windows.Forms.Label
End Class
