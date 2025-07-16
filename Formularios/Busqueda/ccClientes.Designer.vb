<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ccClientes
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
        Me.cmb_cliente = New System.Windows.Forms.ComboBox()
        Me.dg_view = New System.Windows.Forms.DataGridView()
        Me.cmd_consultar = New System.Windows.Forms.Button()
        Me.lbl_cliente = New System.Windows.Forms.Label()
        Me.dtp_hasta = New System.Windows.Forms.DateTimePicker()
        Me.lbl_hasta = New System.Windows.Forms.Label()
        Me.dtp_desde = New System.Windows.Forms.DateTimePicker()
        Me.lbl_desde = New System.Windows.Forms.Label()
        Me.chk_cerrados = New System.Windows.Forms.CheckBox()
        Me.chk_abiertos = New System.Windows.Forms.CheckBox()
        Me.chk_casos = New System.Windows.Forms.CheckBox()
        Me.chk_pedidos = New System.Windows.Forms.CheckBox()
        Me.chk_hastaSiempre = New System.Windows.Forms.CheckBox()
        Me.chk_desdeSiempre = New System.Windows.Forms.CheckBox()
        Me.lbl_total = New System.Windows.Forms.Label()
        Me.txt_total = New System.Windows.Forms.TextBox()
        Me.prnDoc = New System.Drawing.Printing.PrintDocument()
        Me.prnDlg = New System.Windows.Forms.PrintDialog()
        Me.picPrn = New System.Windows.Forms.PictureBox()
        Me.psearch_cliente = New System.Windows.Forms.PictureBox()
        CType(Me.dg_view, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPrn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.psearch_cliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmb_cliente
        '
        Me.cmb_cliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_cliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_cliente.FormattingEnabled = True
        Me.cmb_cliente.Location = New System.Drawing.Point(85, 21)
        Me.cmb_cliente.Name = "cmb_cliente"
        Me.cmb_cliente.Size = New System.Drawing.Size(248, 21)
        Me.cmb_cliente.TabIndex = 59
        '
        'dg_view
        '
        Me.dg_view.AllowUserToAddRows = False
        Me.dg_view.AllowUserToDeleteRows = False
        Me.dg_view.AllowUserToOrderColumns = True
        Me.dg_view.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_view.Location = New System.Drawing.Point(24, 224)
        Me.dg_view.MultiSelect = False
        Me.dg_view.Name = "dg_view"
        Me.dg_view.ReadOnly = True
        Me.dg_view.RowHeadersVisible = False
        Me.dg_view.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_view.Size = New System.Drawing.Size(958, 428)
        Me.dg_view.TabIndex = 8
        '
        'cmd_consultar
        '
        Me.cmd_consultar.Location = New System.Drawing.Point(25, 138)
        Me.cmd_consultar.Name = "cmd_consultar"
        Me.cmd_consultar.Size = New System.Drawing.Size(142, 21)
        Me.cmd_consultar.TabIndex = 6
        Me.cmd_consultar.Text = "Ejecutar consulta"
        Me.cmd_consultar.UseVisualStyleBackColor = True
        '
        'lbl_cliente
        '
        Me.lbl_cliente.AutoSize = True
        Me.lbl_cliente.Location = New System.Drawing.Point(21, 24)
        Me.lbl_cliente.Name = "lbl_cliente"
        Me.lbl_cliente.Size = New System.Drawing.Size(39, 13)
        Me.lbl_cliente.TabIndex = 56
        Me.lbl_cliente.Text = "Cliente"
        '
        'dtp_hasta
        '
        Me.dtp_hasta.Enabled = False
        Me.dtp_hasta.Location = New System.Drawing.Point(85, 98)
        Me.dtp_hasta.Name = "dtp_hasta"
        Me.dtp_hasta.Size = New System.Drawing.Size(248, 20)
        Me.dtp_hasta.TabIndex = 95
        Me.dtp_hasta.TabStop = False
        '
        'lbl_hasta
        '
        Me.lbl_hasta.AutoSize = True
        Me.lbl_hasta.Location = New System.Drawing.Point(22, 98)
        Me.lbl_hasta.Name = "lbl_hasta"
        Me.lbl_hasta.Size = New System.Drawing.Size(35, 13)
        Me.lbl_hasta.TabIndex = 96
        Me.lbl_hasta.Text = "Hasta"
        '
        'dtp_desde
        '
        Me.dtp_desde.Enabled = False
        Me.dtp_desde.Location = New System.Drawing.Point(85, 62)
        Me.dtp_desde.Name = "dtp_desde"
        Me.dtp_desde.Size = New System.Drawing.Size(248, 20)
        Me.dtp_desde.TabIndex = 93
        Me.dtp_desde.TabStop = False
        '
        'lbl_desde
        '
        Me.lbl_desde.AutoSize = True
        Me.lbl_desde.Location = New System.Drawing.Point(22, 62)
        Me.lbl_desde.Name = "lbl_desde"
        Me.lbl_desde.Size = New System.Drawing.Size(38, 13)
        Me.lbl_desde.TabIndex = 94
        Me.lbl_desde.Text = "Desde"
        '
        'chk_cerrados
        '
        Me.chk_cerrados.AutoSize = True
        Me.chk_cerrados.Location = New System.Drawing.Point(692, 98)
        Me.chk_cerrados.Name = "chk_cerrados"
        Me.chk_cerrados.Size = New System.Drawing.Size(187, 17)
        Me.chk_cerrados.TabIndex = 5
        Me.chk_cerrados.Text = "Consultar pedidos/casos cerrados"
        Me.chk_cerrados.UseVisualStyleBackColor = True
        '
        'chk_abiertos
        '
        Me.chk_abiertos.AutoSize = True
        Me.chk_abiertos.Checked = True
        Me.chk_abiertos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_abiertos.Location = New System.Drawing.Point(491, 98)
        Me.chk_abiertos.Name = "chk_abiertos"
        Me.chk_abiertos.Size = New System.Drawing.Size(183, 17)
        Me.chk_abiertos.TabIndex = 3
        Me.chk_abiertos.Text = "Consultar pedidos/casos abiertos"
        Me.chk_abiertos.UseVisualStyleBackColor = True
        '
        'chk_casos
        '
        Me.chk_casos.AutoSize = True
        Me.chk_casos.Checked = True
        Me.chk_casos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_casos.Location = New System.Drawing.Point(692, 62)
        Me.chk_casos.Name = "chk_casos"
        Me.chk_casos.Size = New System.Drawing.Size(101, 17)
        Me.chk_casos.TabIndex = 4
        Me.chk_casos.Text = "Consultar casos"
        Me.chk_casos.UseVisualStyleBackColor = True
        '
        'chk_pedidos
        '
        Me.chk_pedidos.AutoSize = True
        Me.chk_pedidos.Checked = True
        Me.chk_pedidos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_pedidos.Location = New System.Drawing.Point(491, 62)
        Me.chk_pedidos.Name = "chk_pedidos"
        Me.chk_pedidos.Size = New System.Drawing.Size(110, 17)
        Me.chk_pedidos.TabIndex = 2
        Me.chk_pedidos.Text = "Consultar pedidos"
        Me.chk_pedidos.UseVisualStyleBackColor = True
        '
        'chk_hastaSiempre
        '
        Me.chk_hastaSiempre.AutoSize = True
        Me.chk_hastaSiempre.Checked = True
        Me.chk_hastaSiempre.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_hastaSiempre.Location = New System.Drawing.Point(339, 98)
        Me.chk_hastaSiempre.Name = "chk_hastaSiempre"
        Me.chk_hastaSiempre.Size = New System.Drawing.Size(87, 17)
        Me.chk_hastaSiempre.TabIndex = 1
        Me.chk_hastaSiempre.Text = "Hasta el final"
        Me.chk_hastaSiempre.UseVisualStyleBackColor = True
        '
        'chk_desdeSiempre
        '
        Me.chk_desdeSiempre.AutoSize = True
        Me.chk_desdeSiempre.Checked = True
        Me.chk_desdeSiempre.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_desdeSiempre.Location = New System.Drawing.Point(339, 62)
        Me.chk_desdeSiempre.Name = "chk_desdeSiempre"
        Me.chk_desdeSiempre.Size = New System.Drawing.Size(116, 17)
        Me.chk_desdeSiempre.TabIndex = 0
        Me.chk_desdeSiempre.Text = "Desde el comienzo"
        Me.chk_desdeSiempre.UseVisualStyleBackColor = True
        '
        'lbl_total
        '
        Me.lbl_total.AutoSize = True
        Me.lbl_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_total.Location = New System.Drawing.Point(24, 191)
        Me.lbl_total.Name = "lbl_total"
        Me.lbl_total.Size = New System.Drawing.Size(94, 13)
        Me.lbl_total.TabIndex = 107
        Me.lbl_total.Text = "Total facturado"
        '
        'txt_total
        '
        Me.txt_total.BackColor = System.Drawing.Color.White
        Me.txt_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.ForeColor = System.Drawing.Color.Red
        Me.txt_total.Location = New System.Drawing.Point(124, 188)
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.Size = New System.Drawing.Size(248, 20)
        Me.txt_total.TabIndex = 7
        '
        'prnDoc
        '
        '
        'prnDlg
        '
        Me.prnDlg.UseEXDialog = True
        '
        'picPrn
        '
        Me.picPrn.Image = Global.DrOil.My.Resources.Resources.icono_impresora
        Me.picPrn.Location = New System.Drawing.Point(955, 191)
        Me.picPrn.Name = "picPrn"
        Me.picPrn.Size = New System.Drawing.Size(27, 27)
        Me.picPrn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picPrn.TabIndex = 109
        Me.picPrn.TabStop = False
        '
        'psearch_cliente
        '
        Me.psearch_cliente.Image = Global.DrOil.My.Resources.Resources.iconoLupa
        Me.psearch_cliente.Location = New System.Drawing.Point(339, 20)
        Me.psearch_cliente.Name = "psearch_cliente"
        Me.psearch_cliente.Size = New System.Drawing.Size(22, 22)
        Me.psearch_cliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_cliente.TabIndex = 103
        Me.psearch_cliente.TabStop = False
        '
        'ccClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1003, 672)
        Me.Controls.Add(Me.picPrn)
        Me.Controls.Add(Me.lbl_total)
        Me.Controls.Add(Me.txt_total)
        Me.Controls.Add(Me.chk_desdeSiempre)
        Me.Controls.Add(Me.chk_hastaSiempre)
        Me.Controls.Add(Me.psearch_cliente)
        Me.Controls.Add(Me.chk_cerrados)
        Me.Controls.Add(Me.chk_abiertos)
        Me.Controls.Add(Me.chk_casos)
        Me.Controls.Add(Me.chk_pedidos)
        Me.Controls.Add(Me.dtp_hasta)
        Me.Controls.Add(Me.lbl_hasta)
        Me.Controls.Add(Me.dtp_desde)
        Me.Controls.Add(Me.lbl_desde)
        Me.Controls.Add(Me.cmb_cliente)
        Me.Controls.Add(Me.dg_view)
        Me.Controls.Add(Me.cmd_consultar)
        Me.Controls.Add(Me.lbl_cliente)
        Me.Name = "ccClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cuenta corriente de clientes"
        CType(Me.dg_view, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPrn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.psearch_cliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmb_cliente As ComboBox
    Friend WithEvents dg_view As DataGridView
    Friend WithEvents cmd_consultar As Button
    Friend WithEvents lbl_cliente As Label
    Friend WithEvents dtp_hasta As DateTimePicker
    Friend WithEvents lbl_hasta As Label
    Friend WithEvents dtp_desde As DateTimePicker
    Friend WithEvents lbl_desde As Label
    Friend WithEvents chk_cerrados As CheckBox
    Friend WithEvents chk_abiertos As CheckBox
    Friend WithEvents chk_casos As CheckBox
    Friend WithEvents chk_pedidos As CheckBox
    Friend WithEvents psearch_cliente As PictureBox
    Friend WithEvents chk_hastaSiempre As CheckBox
    Friend WithEvents chk_desdeSiempre As CheckBox
    Friend WithEvents lbl_total As Label
    Friend WithEvents txt_total As TextBox
    Friend WithEvents prnDoc As Printing.PrintDocument
    Friend WithEvents prnDlg As PrintDialog
    Friend WithEvents picPrn As PictureBox
End Class
