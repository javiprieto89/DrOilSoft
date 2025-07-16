<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class consulta_caja
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chk_cerrados = New System.Windows.Forms.CheckBox()
        Me.chk_abiertos = New System.Windows.Forms.CheckBox()
        Me.lbl_consultar = New System.Windows.Forms.Label()
        Me.chk_casos = New System.Windows.Forms.CheckBox()
        Me.chk_pedidos = New System.Windows.Forms.CheckBox()
        Me.dtp_hasta = New System.Windows.Forms.DateTimePicker()
        Me.lbl_hasta = New System.Windows.Forms.Label()
        Me.dtp_desde = New System.Windows.Forms.DateTimePicker()
        Me.lbl_desde = New System.Windows.Forms.Label()
        Me.cmb_caja = New System.Windows.Forms.ComboBox()
        Me.psearch_caja = New System.Windows.Forms.PictureBox()
        Me.lbl_caja = New System.Windows.Forms.Label()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_consultar = New System.Windows.Forms.Button()
        Me.txt_total = New System.Windows.Forms.TextBox()
        Me.lbl_total = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lbl_contado = New System.Windows.Forms.Label()
        Me.txt_contado = New System.Windows.Forms.TextBox()
        Me.lbl_tarjeta = New System.Windows.Forms.Label()
        Me.txt_tarjeta = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.psearch_caja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chk_cerrados)
        Me.GroupBox1.Controls.Add(Me.chk_abiertos)
        Me.GroupBox1.Controls.Add(Me.lbl_consultar)
        Me.GroupBox1.Controls.Add(Me.chk_casos)
        Me.GroupBox1.Controls.Add(Me.chk_pedidos)
        Me.GroupBox1.Controls.Add(Me.dtp_hasta)
        Me.GroupBox1.Controls.Add(Me.lbl_hasta)
        Me.GroupBox1.Controls.Add(Me.dtp_desde)
        Me.GroupBox1.Controls.Add(Me.lbl_desde)
        Me.GroupBox1.Controls.Add(Me.cmb_caja)
        Me.GroupBox1.Controls.Add(Me.psearch_caja)
        Me.GroupBox1.Controls.Add(Me.lbl_caja)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(515, 242)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtro"
        '
        'chk_cerrados
        '
        Me.chk_cerrados.AutoSize = True
        Me.chk_cerrados.Location = New System.Drawing.Point(315, 199)
        Me.chk_cerrados.Name = "chk_cerrados"
        Me.chk_cerrados.Size = New System.Drawing.Size(173, 17)
        Me.chk_cerrados.TabIndex = 97
        Me.chk_cerrados.Text = "Sumar pedidos/casos cerrados"
        Me.chk_cerrados.UseVisualStyleBackColor = True
        '
        'chk_abiertos
        '
        Me.chk_abiertos.AutoSize = True
        Me.chk_abiertos.Checked = True
        Me.chk_abiertos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_abiertos.Location = New System.Drawing.Point(140, 199)
        Me.chk_abiertos.Name = "chk_abiertos"
        Me.chk_abiertos.Size = New System.Drawing.Size(169, 17)
        Me.chk_abiertos.TabIndex = 96
        Me.chk_abiertos.Text = "Sumar pedidos/casos abiertos"
        Me.chk_abiertos.UseVisualStyleBackColor = True
        '
        'lbl_consultar
        '
        Me.lbl_consultar.AutoSize = True
        Me.lbl_consultar.Location = New System.Drawing.Point(26, 164)
        Me.lbl_consultar.Name = "lbl_consultar"
        Me.lbl_consultar.Size = New System.Drawing.Size(73, 13)
        Me.lbl_consultar.TabIndex = 95
        Me.lbl_consultar.Text = "Que consultar"
        '
        'chk_casos
        '
        Me.chk_casos.AutoSize = True
        Me.chk_casos.Location = New System.Drawing.Point(315, 160)
        Me.chk_casos.Name = "chk_casos"
        Me.chk_casos.Size = New System.Drawing.Size(87, 17)
        Me.chk_casos.TabIndex = 94
        Me.chk_casos.Text = "Sumar casos"
        Me.chk_casos.UseVisualStyleBackColor = True
        '
        'chk_pedidos
        '
        Me.chk_pedidos.AutoSize = True
        Me.chk_pedidos.Checked = True
        Me.chk_pedidos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_pedidos.Location = New System.Drawing.Point(140, 164)
        Me.chk_pedidos.Name = "chk_pedidos"
        Me.chk_pedidos.Size = New System.Drawing.Size(96, 17)
        Me.chk_pedidos.TabIndex = 93
        Me.chk_pedidos.Text = "Sumar pedidos"
        Me.chk_pedidos.UseVisualStyleBackColor = True
        '
        'dtp_hasta
        '
        Me.dtp_hasta.Location = New System.Drawing.Point(151, 115)
        Me.dtp_hasta.Name = "dtp_hasta"
        Me.dtp_hasta.Size = New System.Drawing.Size(248, 20)
        Me.dtp_hasta.TabIndex = 91
        '
        'lbl_hasta
        '
        Me.lbl_hasta.AutoSize = True
        Me.lbl_hasta.Location = New System.Drawing.Point(88, 120)
        Me.lbl_hasta.Name = "lbl_hasta"
        Me.lbl_hasta.Size = New System.Drawing.Size(35, 13)
        Me.lbl_hasta.TabIndex = 92
        Me.lbl_hasta.Text = "Hasta"
        '
        'dtp_desde
        '
        Me.dtp_desde.Location = New System.Drawing.Point(151, 72)
        Me.dtp_desde.Name = "dtp_desde"
        Me.dtp_desde.Size = New System.Drawing.Size(248, 20)
        Me.dtp_desde.TabIndex = 1
        '
        'lbl_desde
        '
        Me.lbl_desde.AutoSize = True
        Me.lbl_desde.Location = New System.Drawing.Point(88, 76)
        Me.lbl_desde.Name = "lbl_desde"
        Me.lbl_desde.Size = New System.Drawing.Size(38, 13)
        Me.lbl_desde.TabIndex = 90
        Me.lbl_desde.Text = "Desde"
        '
        'cmb_caja
        '
        Me.cmb_caja.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_caja.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_caja.DisplayMember = "id_tipo"
        Me.cmb_caja.FormattingEnabled = True
        Me.cmb_caja.Location = New System.Drawing.Point(151, 28)
        Me.cmb_caja.Name = "cmb_caja"
        Me.cmb_caja.Size = New System.Drawing.Size(248, 21)
        Me.cmb_caja.TabIndex = 87
        Me.cmb_caja.ValueMember = "id_tipo"
        '
        'psearch_caja
        '
        Me.psearch_caja.Image = Global.DrOil.My.Resources.Resources.iconoLupa
        Me.psearch_caja.Location = New System.Drawing.Point(405, 27)
        Me.psearch_caja.Name = "psearch_caja"
        Me.psearch_caja.Size = New System.Drawing.Size(22, 22)
        Me.psearch_caja.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_caja.TabIndex = 89
        Me.psearch_caja.TabStop = False
        '
        'lbl_caja
        '
        Me.lbl_caja.AutoSize = True
        Me.lbl_caja.Location = New System.Drawing.Point(88, 32)
        Me.lbl_caja.Name = "lbl_caja"
        Me.lbl_caja.Size = New System.Drawing.Size(28, 13)
        Me.lbl_caja.TabIndex = 88
        Me.lbl_caja.Text = "Caja"
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(319, 408)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 10
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_consultar
        '
        Me.cmd_consultar.Location = New System.Drawing.Point(152, 408)
        Me.cmd_consultar.Name = "cmd_consultar"
        Me.cmd_consultar.Size = New System.Drawing.Size(75, 23)
        Me.cmd_consultar.TabIndex = 9
        Me.cmd_consultar.Text = "Consultar"
        Me.ToolTip1.SetToolTip(Me.cmd_consultar, "Para el cálculo, se tomára en cuenta solamente los casos o pedidos que se encuent" &
        "ren cerrados")
        Me.cmd_consultar.UseVisualStyleBackColor = True
        '
        'txt_total
        '
        Me.txt_total.BackColor = System.Drawing.Color.White
        Me.txt_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.ForeColor = System.Drawing.Color.Red
        Me.txt_total.Location = New System.Drawing.Point(112, 344)
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.Size = New System.Drawing.Size(420, 20)
        Me.txt_total.TabIndex = 11
        '
        'lbl_total
        '
        Me.lbl_total.AutoSize = True
        Me.lbl_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_total.Location = New System.Drawing.Point(14, 351)
        Me.lbl_total.Name = "lbl_total"
        Me.lbl_total.Size = New System.Drawing.Size(36, 13)
        Me.lbl_total.TabIndex = 93
        Me.lbl_total.Text = "Total"
        '
        'lbl_contado
        '
        Me.lbl_contado.AutoSize = True
        Me.lbl_contado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_contado.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_contado.Location = New System.Drawing.Point(14, 295)
        Me.lbl_contado.Name = "lbl_contado"
        Me.lbl_contado.Size = New System.Drawing.Size(47, 13)
        Me.lbl_contado.TabIndex = 95
        Me.lbl_contado.Text = "Contado"
        '
        'txt_contado
        '
        Me.txt_contado.BackColor = System.Drawing.Color.White
        Me.txt_contado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_contado.ForeColor = System.Drawing.Color.Red
        Me.txt_contado.Location = New System.Drawing.Point(112, 288)
        Me.txt_contado.Name = "txt_contado"
        Me.txt_contado.ReadOnly = True
        Me.txt_contado.Size = New System.Drawing.Size(147, 20)
        Me.txt_contado.TabIndex = 94
        '
        'lbl_tarjeta
        '
        Me.lbl_tarjeta.AutoSize = True
        Me.lbl_tarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_tarjeta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_tarjeta.Location = New System.Drawing.Point(292, 295)
        Me.lbl_tarjeta.Name = "lbl_tarjeta"
        Me.lbl_tarjeta.Size = New System.Drawing.Size(40, 13)
        Me.lbl_tarjeta.TabIndex = 97
        Me.lbl_tarjeta.Text = "Tarjeta"
        '
        'txt_tarjeta
        '
        Me.txt_tarjeta.BackColor = System.Drawing.Color.White
        Me.txt_tarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tarjeta.ForeColor = System.Drawing.Color.Red
        Me.txt_tarjeta.Location = New System.Drawing.Point(385, 288)
        Me.txt_tarjeta.Name = "txt_tarjeta"
        Me.txt_tarjeta.ReadOnly = True
        Me.txt_tarjeta.Size = New System.Drawing.Size(147, 20)
        Me.txt_tarjeta.TabIndex = 96
        '
        'consulta_caja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(546, 454)
        Me.Controls.Add(Me.lbl_tarjeta)
        Me.Controls.Add(Me.txt_tarjeta)
        Me.Controls.Add(Me.lbl_contado)
        Me.Controls.Add(Me.txt_contado)
        Me.Controls.Add(Me.lbl_total)
        Me.Controls.Add(Me.txt_total)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_consultar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "consulta_caja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Consulta de saldo en la caja"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.psearch_caja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmb_caja As ComboBox
    Friend WithEvents psearch_caja As PictureBox
    Friend WithEvents lbl_caja As Label
    Friend WithEvents dtp_hasta As DateTimePicker
    Friend WithEvents lbl_hasta As Label
    Friend WithEvents dtp_desde As DateTimePicker
    Friend WithEvents lbl_desde As Label
    Friend WithEvents cmd_exit As Button
    Friend WithEvents cmd_consultar As Button
    Friend WithEvents txt_total As TextBox
    Friend WithEvents lbl_total As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents lbl_consultar As System.Windows.Forms.Label
    Friend WithEvents chk_casos As System.Windows.Forms.CheckBox
    Friend WithEvents chk_pedidos As System.Windows.Forms.CheckBox
    Friend WithEvents chk_cerrados As System.Windows.Forms.CheckBox
    Friend WithEvents chk_abiertos As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_contado As System.Windows.Forms.Label
    Friend WithEvents txt_contado As System.Windows.Forms.TextBox
    Friend WithEvents lbl_tarjeta As System.Windows.Forms.Label
    Friend WithEvents txt_tarjeta As System.Windows.Forms.TextBox
End Class
