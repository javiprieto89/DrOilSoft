<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_marcai
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
        Me.lbl_marca = New System.Windows.Forms.Label()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.txt_marca = New System.Windows.Forms.TextBox()
        Me.chk_activo = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'lbl_marca
        '
        Me.lbl_marca.AutoSize = True
        Me.lbl_marca.Location = New System.Drawing.Point(29, 34)
        Me.lbl_marca.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_marca.Name = "lbl_marca"
        Me.lbl_marca.Size = New System.Drawing.Size(47, 17)
        Me.lbl_marca.TabIndex = 0
        Me.lbl_marca.Text = "Marca"
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Location = New System.Drawing.Point(32, 110)
        Me.chk_secuencia.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(139, 21)
        Me.chk_secuencia.TabIndex = 2
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(256, 154)
        Me.cmd_exit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(100, 28)
        Me.cmd_exit.TabIndex = 4
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(125, 154)
        Me.cmd_ok.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(100, 28)
        Me.cmd_ok.TabIndex = 3
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'txt_marca
        '
        Me.txt_marca.Location = New System.Drawing.Point(104, 26)
        Me.txt_marca.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt_marca.Name = "txt_marca"
        Me.txt_marca.Size = New System.Drawing.Size(344, 22)
        Me.txt_marca.TabIndex = 0
        '
        'chk_activo
        '
        Me.chk_activo.AutoSize = True
        Me.chk_activo.Location = New System.Drawing.Point(32, 70)
        Me.chk_activo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chk_activo.Name = "chk_activo"
        Me.chk_activo.Size = New System.Drawing.Size(110, 21)
        Me.chk_activo.TabIndex = 1
        Me.chk_activo.Text = "Marca activa"
        Me.chk_activo.UseVisualStyleBackColor = True
        '
        'add_marcai
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(477, 197)
        Me.Controls.Add(Me.chk_activo)
        Me.Controls.Add(Me.txt_marca)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.lbl_marca)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "add_marcai"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Insertar marca del item"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_marca As System.Windows.Forms.Label
    Friend WithEvents chk_secuencia As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents txt_marca As System.Windows.Forms.TextBox
    Friend WithEvents chk_activo As System.Windows.Forms.CheckBox
End Class
