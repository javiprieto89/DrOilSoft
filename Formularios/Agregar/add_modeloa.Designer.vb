<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_modeloa
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
        Me.txt_modelo = New System.Windows.Forms.TextBox()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.lbl_marca = New System.Windows.Forms.Label()
        Me.lbl_modelo = New System.Windows.Forms.Label()
        Me.cmb_marcas = New System.Windows.Forms.ComboBox()
        Me.pic_search = New System.Windows.Forms.PictureBox()
        Me.chk_activo = New System.Windows.Forms.CheckBox()
        CType(Me.pic_search, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_modelo
        '
        Me.txt_modelo.Location = New System.Drawing.Point(73, 58)
        Me.txt_modelo.Name = "txt_modelo"
        Me.txt_modelo.Size = New System.Drawing.Size(259, 20)
        Me.txt_modelo.TabIndex = 1
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Location = New System.Drawing.Point(25, 115)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(108, 17)
        Me.chk_secuencia.TabIndex = 3
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(203, 155)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 5
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(105, 155)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 4
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'lbl_marca
        '
        Me.lbl_marca.AutoSize = True
        Me.lbl_marca.Location = New System.Drawing.Point(23, 23)
        Me.lbl_marca.Name = "lbl_marca"
        Me.lbl_marca.Size = New System.Drawing.Size(37, 13)
        Me.lbl_marca.TabIndex = 17
        Me.lbl_marca.Text = "Marca"
        '
        'lbl_modelo
        '
        Me.lbl_modelo.AutoSize = True
        Me.lbl_modelo.Location = New System.Drawing.Point(22, 61)
        Me.lbl_modelo.Name = "lbl_modelo"
        Me.lbl_modelo.Size = New System.Drawing.Size(42, 13)
        Me.lbl_modelo.TabIndex = 22
        Me.lbl_modelo.Text = "Modelo"
        '
        'cmb_marcas
        '
        Me.cmb_marcas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_marcas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_marcas.FormattingEnabled = True
        Me.cmb_marcas.Location = New System.Drawing.Point(73, 15)
        Me.cmb_marcas.Name = "cmb_marcas"
        Me.cmb_marcas.Size = New System.Drawing.Size(259, 21)
        Me.cmb_marcas.TabIndex = 0
        '
        'pic_search
        '
        Me.pic_search.Image = Global.DrOil.My.Resources.Resources.iconoLupa
        Me.pic_search.Location = New System.Drawing.Point(338, 14)
        Me.pic_search.Name = "pic_search"
        Me.pic_search.Size = New System.Drawing.Size(22, 22)
        Me.pic_search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_search.TabIndex = 25
        Me.pic_search.TabStop = False
        '
        'chk_activo
        '
        Me.chk_activo.AutoSize = True
        Me.chk_activo.Location = New System.Drawing.Point(25, 92)
        Me.chk_activo.Name = "chk_activo"
        Me.chk_activo.Size = New System.Drawing.Size(126, 17)
        Me.chk_activo.TabIndex = 2
        Me.chk_activo.Text = "Marca de autos ctiva"
        Me.chk_activo.UseVisualStyleBackColor = True
        '
        'add_modeloa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(382, 209)
        Me.Controls.Add(Me.chk_activo)
        Me.Controls.Add(Me.pic_search)
        Me.Controls.Add(Me.cmb_marcas)
        Me.Controls.Add(Me.lbl_modelo)
        Me.Controls.Add(Me.txt_modelo)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.lbl_marca)
        Me.Name = "add_modeloa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Insertar modelo"
        CType(Me.pic_search, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_modelo As System.Windows.Forms.TextBox
    Friend WithEvents chk_secuencia As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents lbl_marca As System.Windows.Forms.Label
    Friend WithEvents lbl_modelo As System.Windows.Forms.Label
    Friend WithEvents cmb_marcas As System.Windows.Forms.ComboBox
    Friend WithEvents pic_search As System.Windows.Forms.PictureBox
    Friend WithEvents chk_activo As System.Windows.Forms.CheckBox
End Class
