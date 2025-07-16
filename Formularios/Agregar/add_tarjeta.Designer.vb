<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_tarjeta
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
        Me.txt_recargo = New System.Windows.Forms.TextBox()
        Me.lbl_recargo = New System.Windows.Forms.Label()
        Me.txt_cuotas = New System.Windows.Forms.TextBox()
        Me.lbl_cuotas = New System.Windows.Forms.Label()
        Me.chk_activo = New System.Windows.Forms.CheckBox()
        Me.txt_nombre = New System.Windows.Forms.TextBox()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.lbl_nombre = New System.Windows.Forms.Label()
        Me.pic_search = New System.Windows.Forms.PictureBox()
        Me.cmb_grupoTarjetas = New System.Windows.Forms.ComboBox()
        Me.lbl_grupo_tarjetas = New System.Windows.Forms.Label()
        CType(Me.pic_search, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_recargo
        '
        Me.txt_recargo.Location = New System.Drawing.Point(119, 57)
        Me.txt_recargo.Name = "txt_recargo"
        Me.txt_recargo.Size = New System.Drawing.Size(259, 20)
        Me.txt_recargo.TabIndex = 24
        '
        'lbl_recargo
        '
        Me.lbl_recargo.AutoSize = True
        Me.lbl_recargo.Location = New System.Drawing.Point(18, 59)
        Me.lbl_recargo.Name = "lbl_recargo"
        Me.lbl_recargo.Size = New System.Drawing.Size(65, 13)
        Me.lbl_recargo.TabIndex = 32
        Me.lbl_recargo.Text = "Recargo (%)"
        '
        'txt_cuotas
        '
        Me.txt_cuotas.Location = New System.Drawing.Point(119, 93)
        Me.txt_cuotas.Name = "txt_cuotas"
        Me.txt_cuotas.Size = New System.Drawing.Size(259, 20)
        Me.txt_cuotas.TabIndex = 25
        '
        'lbl_cuotas
        '
        Me.lbl_cuotas.AutoSize = True
        Me.lbl_cuotas.Location = New System.Drawing.Point(18, 94)
        Me.lbl_cuotas.Name = "lbl_cuotas"
        Me.lbl_cuotas.Size = New System.Drawing.Size(40, 13)
        Me.lbl_cuotas.TabIndex = 31
        Me.lbl_cuotas.Text = "Cuotas"
        '
        'chk_activo
        '
        Me.chk_activo.AutoSize = True
        Me.chk_activo.Location = New System.Drawing.Point(21, 164)
        Me.chk_activo.Name = "chk_activo"
        Me.chk_activo.Size = New System.Drawing.Size(91, 17)
        Me.chk_activo.TabIndex = 26
        Me.chk_activo.Text = "Tarjeta activa"
        Me.chk_activo.UseVisualStyleBackColor = True
        '
        'txt_nombre
        '
        Me.txt_nombre.Location = New System.Drawing.Point(119, 21)
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.Size = New System.Drawing.Size(259, 20)
        Me.txt_nombre.TabIndex = 23
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Location = New System.Drawing.Point(21, 203)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(108, 17)
        Me.chk_secuencia.TabIndex = 27
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(224, 242)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 29
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(126, 242)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 28
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'lbl_nombre
        '
        Me.lbl_nombre.AutoSize = True
        Me.lbl_nombre.Location = New System.Drawing.Point(18, 24)
        Me.lbl_nombre.Name = "lbl_nombre"
        Me.lbl_nombre.Size = New System.Drawing.Size(44, 13)
        Me.lbl_nombre.TabIndex = 30
        Me.lbl_nombre.Text = "Nombre"
        '
        'pic_search
        '
        Me.pic_search.Image = Global.DrOil.My.Resources.Resources.iconoLupa
        Me.pic_search.Location = New System.Drawing.Point(384, 128)
        Me.pic_search.Name = "pic_search"
        Me.pic_search.Size = New System.Drawing.Size(22, 22)
        Me.pic_search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_search.TabIndex = 35
        Me.pic_search.TabStop = False
        '
        'cmb_grupoTarjetas
        '
        Me.cmb_grupoTarjetas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_grupoTarjetas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_grupoTarjetas.FormattingEnabled = True
        Me.cmb_grupoTarjetas.Location = New System.Drawing.Point(119, 129)
        Me.cmb_grupoTarjetas.Name = "cmb_grupoTarjetas"
        Me.cmb_grupoTarjetas.Size = New System.Drawing.Size(259, 21)
        Me.cmb_grupoTarjetas.TabIndex = 33
        '
        'lbl_grupo_tarjetas
        '
        Me.lbl_grupo_tarjetas.AutoSize = True
        Me.lbl_grupo_tarjetas.Location = New System.Drawing.Point(18, 129)
        Me.lbl_grupo_tarjetas.Name = "lbl_grupo_tarjetas"
        Me.lbl_grupo_tarjetas.Size = New System.Drawing.Size(88, 13)
        Me.lbl_grupo_tarjetas.TabIndex = 34
        Me.lbl_grupo_tarjetas.Text = "Grupo de tarjetas"
        '
        'add_tarjeta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(425, 287)
        Me.Controls.Add(Me.pic_search)
        Me.Controls.Add(Me.cmb_grupoTarjetas)
        Me.Controls.Add(Me.lbl_grupo_tarjetas)
        Me.Controls.Add(Me.txt_recargo)
        Me.Controls.Add(Me.lbl_recargo)
        Me.Controls.Add(Me.txt_cuotas)
        Me.Controls.Add(Me.lbl_cuotas)
        Me.Controls.Add(Me.chk_activo)
        Me.Controls.Add(Me.txt_nombre)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.lbl_nombre)
        Me.Name = "add_tarjeta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agregar tarjeta"
        CType(Me.pic_search, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_recargo As System.Windows.Forms.TextBox
    Friend WithEvents lbl_recargo As System.Windows.Forms.Label
    Friend WithEvents txt_cuotas As System.Windows.Forms.TextBox
    Friend WithEvents lbl_cuotas As System.Windows.Forms.Label
    Friend WithEvents chk_activo As System.Windows.Forms.CheckBox
    Friend WithEvents txt_nombre As System.Windows.Forms.TextBox
    Friend WithEvents chk_secuencia As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents lbl_nombre As System.Windows.Forms.Label
    Friend WithEvents pic_search As System.Windows.Forms.PictureBox
    Friend WithEvents cmb_grupoTarjetas As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_grupo_tarjetas As System.Windows.Forms.Label
End Class
