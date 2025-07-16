<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmcambios
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
        Me.lsv_cambios = New System.Windows.Forms.ListView()
        Me.cmdcontinuar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lsv_cambios
        '
        Me.lsv_cambios.Location = New System.Drawing.Point(13, 13)
        Me.lsv_cambios.Margin = New System.Windows.Forms.Padding(4)
        Me.lsv_cambios.Name = "lsv_cambios"
        Me.lsv_cambios.Size = New System.Drawing.Size(1145, 413)
        Me.lsv_cambios.TabIndex = 3
        Me.lsv_cambios.UseCompatibleStateImageBehavior = False
        '
        'cmdcontinuar
        '
        Me.cmdcontinuar.Location = New System.Drawing.Point(458, 446)
        Me.cmdcontinuar.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdcontinuar.Name = "cmdcontinuar"
        Me.cmdcontinuar.Size = New System.Drawing.Size(255, 52)
        Me.cmdcontinuar.TabIndex = 5
        Me.cmdcontinuar.Text = "Continuar"
        Me.cmdcontinuar.UseVisualStyleBackColor = True
        '
        'frmcambios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1171, 520)
        Me.Controls.Add(Me.cmdcontinuar)
        Me.Controls.Add(Me.lsv_cambios)
        Me.Name = "frmcambios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Últimos Cambios - Dr. Oil"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lsv_cambios As System.Windows.Forms.ListView
    Friend WithEvents cmdcontinuar As System.Windows.Forms.Button
End Class
