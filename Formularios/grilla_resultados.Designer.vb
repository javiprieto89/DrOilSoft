<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class grilla_resultados
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
        Me.lbl_consultas = New System.Windows.Forms.Label()
        Me.cmd_ejecutar = New System.Windows.Forms.Button()
        Me.cmb_consultas = New System.Windows.Forms.ComboBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cmb_cliente = New System.Windows.Forms.ComboBox()
        Me.lbl_cliente = New System.Windows.Forms.Label()
        Me.cmb_item = New System.Windows.Forms.ComboBox()
        Me.lbl_item = New System.Windows.Forms.Label()
        Me.pic_search_cliente = New System.Windows.Forms.PictureBox()
        Me.pic_search_item = New System.Windows.Forms.PictureBox()
        Me.chk_hasta = New System.Windows.Forms.CheckBox()
        Me.chk_desde = New System.Windows.Forms.CheckBox()
        Me.dtp_hasta = New System.Windows.Forms.DateTimePicker()
        Me.dtp_desde = New System.Windows.Forms.DateTimePicker()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dg_view = New System.Windows.Forms.DataGridView()
        Me.lbl_exportar = New System.Windows.Forms.Label()
        Me.pExport = New System.Windows.Forms.PictureBox()
        Me.sfd = New System.Windows.Forms.SaveFileDialog()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.pic_search_cliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_search_item, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dg_view, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pExport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_consultas
        '
        Me.lbl_consultas.AutoSize = True
        Me.lbl_consultas.Location = New System.Drawing.Point(21, 32)
        Me.lbl_consultas.Name = "lbl_consultas"
        Me.lbl_consultas.Size = New System.Drawing.Size(53, 13)
        Me.lbl_consultas.TabIndex = 0
        Me.lbl_consultas.Text = "Consultas"
        '
        'cmd_ejecutar
        '
        Me.cmd_ejecutar.Location = New System.Drawing.Point(840, 29)
        Me.cmd_ejecutar.Name = "cmd_ejecutar"
        Me.cmd_ejecutar.Size = New System.Drawing.Size(142, 21)
        Me.cmd_ejecutar.TabIndex = 3
        Me.cmd_ejecutar.Text = "Ejecutar consulta"
        Me.cmd_ejecutar.UseVisualStyleBackColor = True
        '
        'cmb_consultas
        '
        Me.cmb_consultas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_consultas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_consultas.FormattingEnabled = True
        Me.cmb_consultas.Location = New System.Drawing.Point(98, 29)
        Me.cmb_consultas.Name = "cmb_consultas"
        Me.cmb_consultas.Size = New System.Drawing.Size(736, 21)
        Me.cmb_consultas.TabIndex = 55
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(24, 80)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(949, 589)
        Me.TabControl1.TabIndex = 132
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cmb_cliente)
        Me.TabPage1.Controls.Add(Me.lbl_cliente)
        Me.TabPage1.Controls.Add(Me.cmb_item)
        Me.TabPage1.Controls.Add(Me.lbl_item)
        Me.TabPage1.Controls.Add(Me.pic_search_cliente)
        Me.TabPage1.Controls.Add(Me.pic_search_item)
        Me.TabPage1.Controls.Add(Me.chk_hasta)
        Me.TabPage1.Controls.Add(Me.chk_desde)
        Me.TabPage1.Controls.Add(Me.dtp_hasta)
        Me.TabPage1.Controls.Add(Me.dtp_desde)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(941, 563)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Filtros"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'cmb_cliente
        '
        Me.cmb_cliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_cliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_cliente.FormattingEnabled = True
        Me.cmb_cliente.Location = New System.Drawing.Point(70, 106)
        Me.cmb_cliente.Name = "cmb_cliente"
        Me.cmb_cliente.Size = New System.Drawing.Size(592, 21)
        Me.cmb_cliente.TabIndex = 144
        Me.cmb_cliente.Text = "Seleccione un cliente"
        '
        'lbl_cliente
        '
        Me.lbl_cliente.AutoSize = True
        Me.lbl_cliente.Location = New System.Drawing.Point(15, 114)
        Me.lbl_cliente.Name = "lbl_cliente"
        Me.lbl_cliente.Size = New System.Drawing.Size(39, 13)
        Me.lbl_cliente.TabIndex = 146
        Me.lbl_cliente.Text = "Cliente"
        '
        'cmb_item
        '
        Me.cmb_item.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_item.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_item.FormattingEnabled = True
        Me.cmb_item.Location = New System.Drawing.Point(70, 64)
        Me.cmb_item.Name = "cmb_item"
        Me.cmb_item.Size = New System.Drawing.Size(592, 21)
        Me.cmb_item.TabIndex = 143
        Me.cmb_item.Text = "Seleccione un item"
        '
        'lbl_item
        '
        Me.lbl_item.AutoSize = True
        Me.lbl_item.Location = New System.Drawing.Point(15, 72)
        Me.lbl_item.Name = "lbl_item"
        Me.lbl_item.Size = New System.Drawing.Size(27, 13)
        Me.lbl_item.TabIndex = 145
        Me.lbl_item.Text = "Item"
        '
        'pic_search_cliente
        '
        Me.pic_search_cliente.Image = Global.DrOil.My.Resources.Resources.iconoLupa
        Me.pic_search_cliente.Location = New System.Drawing.Point(691, 106)
        Me.pic_search_cliente.Name = "pic_search_cliente"
        Me.pic_search_cliente.Size = New System.Drawing.Size(22, 22)
        Me.pic_search_cliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_search_cliente.TabIndex = 142
        Me.pic_search_cliente.TabStop = False
        '
        'pic_search_item
        '
        Me.pic_search_item.Image = Global.DrOil.My.Resources.Resources.iconoLupa
        Me.pic_search_item.Location = New System.Drawing.Point(691, 64)
        Me.pic_search_item.Name = "pic_search_item"
        Me.pic_search_item.Size = New System.Drawing.Size(22, 22)
        Me.pic_search_item.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_search_item.TabIndex = 141
        Me.pic_search_item.TabStop = False
        '
        'chk_hasta
        '
        Me.chk_hasta.AutoSize = True
        Me.chk_hasta.Location = New System.Drawing.Point(382, 24)
        Me.chk_hasta.Name = "chk_hasta"
        Me.chk_hasta.Size = New System.Drawing.Size(54, 17)
        Me.chk_hasta.TabIndex = 135
        Me.chk_hasta.Text = "Hasta"
        Me.chk_hasta.UseVisualStyleBackColor = True
        '
        'chk_desde
        '
        Me.chk_desde.AutoSize = True
        Me.chk_desde.Location = New System.Drawing.Point(18, 24)
        Me.chk_desde.Name = "chk_desde"
        Me.chk_desde.Size = New System.Drawing.Size(57, 17)
        Me.chk_desde.TabIndex = 134
        Me.chk_desde.Text = "Desde"
        Me.chk_desde.UseVisualStyleBackColor = True
        '
        'dtp_hasta
        '
        Me.dtp_hasta.Enabled = False
        Me.dtp_hasta.Location = New System.Drawing.Point(465, 21)
        Me.dtp_hasta.Name = "dtp_hasta"
        Me.dtp_hasta.Size = New System.Drawing.Size(248, 20)
        Me.dtp_hasta.TabIndex = 133
        '
        'dtp_desde
        '
        Me.dtp_desde.Enabled = False
        Me.dtp_desde.Location = New System.Drawing.Point(92, 21)
        Me.dtp_desde.Name = "dtp_desde"
        Me.dtp_desde.Size = New System.Drawing.Size(248, 20)
        Me.dtp_desde.TabIndex = 132
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dg_view)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(941, 563)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Resultado"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dg_view
        '
        Me.dg_view.AllowUserToAddRows = False
        Me.dg_view.AllowUserToDeleteRows = False
        Me.dg_view.AllowUserToOrderColumns = True
        Me.dg_view.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_view.Location = New System.Drawing.Point(6, 6)
        Me.dg_view.MultiSelect = False
        Me.dg_view.Name = "dg_view"
        Me.dg_view.ReadOnly = True
        Me.dg_view.RowHeadersVisible = False
        Me.dg_view.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_view.Size = New System.Drawing.Size(929, 551)
        Me.dg_view.TabIndex = 59
        '
        'lbl_exportar
        '
        Me.lbl_exportar.AutoSize = True
        Me.lbl_exportar.Location = New System.Drawing.Point(434, 720)
        Me.lbl_exportar.Name = "lbl_exportar"
        Me.lbl_exportar.Size = New System.Drawing.Size(135, 13)
        Me.lbl_exportar.TabIndex = 128
        Me.lbl_exportar.Text = "Exportar resultados a Excel"
        Me.lbl_exportar.Visible = False
        '
        'pExport
        '
        Me.pExport.Image = Global.DrOil.My.Resources.Resources.iconoExcel
        Me.pExport.Location = New System.Drawing.Point(436, 675)
        Me.pExport.Name = "pExport"
        Me.pExport.Size = New System.Drawing.Size(55, 42)
        Me.pExport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pExport.TabIndex = 129
        Me.pExport.TabStop = False
        '
        'grilla_resultados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1003, 735)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.pExport)
        Me.Controls.Add(Me.lbl_exportar)
        Me.Controls.Add(Me.cmb_consultas)
        Me.Controls.Add(Me.cmd_ejecutar)
        Me.Controls.Add(Me.lbl_consultas)
        Me.Name = "grilla_resultados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Consultas personalizadas"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.pic_search_cliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_search_item, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dg_view, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pExport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_consultas As System.Windows.Forms.Label
    Friend WithEvents cmd_ejecutar As System.Windows.Forms.Button
    Friend WithEvents cmb_consultas As System.Windows.Forms.ComboBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents chk_hasta As CheckBox
    Friend WithEvents chk_desde As CheckBox
    Friend WithEvents dtp_hasta As DateTimePicker
    Friend WithEvents dtp_desde As DateTimePicker
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents pic_search_cliente As PictureBox
    Friend WithEvents pic_search_item As PictureBox
    Friend WithEvents lbl_exportar As Label
    Friend WithEvents pExport As PictureBox
    Friend WithEvents dg_view As DataGridView
    Friend WithEvents sfd As SaveFileDialog
    Friend WithEvents cmb_cliente As ComboBox
    Friend WithEvents lbl_cliente As Label
    Friend WithEvents cmb_item As ComboBox
    Friend WithEvents lbl_item As Label
End Class
