﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_condicion
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
        Me.chk_activo = New System.Windows.Forms.CheckBox()
        Me.txt_condicion = New System.Windows.Forms.TextBox()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.lbl_condicion = New System.Windows.Forms.Label()
        Me.txt_vencimiento = New System.Windows.Forms.TextBox()
        Me.lbl_vencimiento = New System.Windows.Forms.Label()
        Me.pic_search = New System.Windows.Forms.PictureBox()
        Me.cmb_tarjeta = New System.Windows.Forms.ComboBox()
        Me.lbl_tarjeta = New System.Windows.Forms.Label()
        CType(Me.pic_search, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_recargo
        '
        Me.txt_recargo.Location = New System.Drawing.Point(174, 100)
        Me.txt_recargo.Name = "txt_recargo"
        Me.txt_recargo.Size = New System.Drawing.Size(259, 20)
        Me.txt_recargo.TabIndex = 2
        '
        'lbl_recargo
        '
        Me.lbl_recargo.AutoSize = True
        Me.lbl_recargo.Location = New System.Drawing.Point(20, 104)
        Me.lbl_recargo.Name = "lbl_recargo"
        Me.lbl_recargo.Size = New System.Drawing.Size(65, 13)
        Me.lbl_recargo.TabIndex = 20
        Me.lbl_recargo.Text = "Recargo (%)"
        '
        'chk_activo
        '
        Me.chk_activo.AutoSize = True
        Me.chk_activo.Location = New System.Drawing.Point(23, 189)
        Me.chk_activo.Name = "chk_activo"
        Me.chk_activo.Size = New System.Drawing.Size(105, 17)
        Me.chk_activo.TabIndex = 3
        Me.chk_activo.Text = "Condición activa"
        Me.chk_activo.UseVisualStyleBackColor = True
        '
        'txt_condicion
        '
        Me.txt_condicion.Location = New System.Drawing.Point(174, 36)
        Me.txt_condicion.Name = "txt_condicion"
        Me.txt_condicion.Size = New System.Drawing.Size(259, 20)
        Me.txt_condicion.TabIndex = 0
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Location = New System.Drawing.Point(23, 221)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(108, 17)
        Me.chk_secuencia.TabIndex = 4
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(195, 259)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 6
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(97, 259)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 5
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'lbl_condicion
        '
        Me.lbl_condicion.AutoSize = True
        Me.lbl_condicion.Location = New System.Drawing.Point(20, 36)
        Me.lbl_condicion.Name = "lbl_condicion"
        Me.lbl_condicion.Size = New System.Drawing.Size(54, 13)
        Me.lbl_condicion.TabIndex = 14
        Me.lbl_condicion.Text = "Condición"
        '
        'txt_vencimiento
        '
        Me.txt_vencimiento.Location = New System.Drawing.Point(174, 68)
        Me.txt_vencimiento.Name = "txt_vencimiento"
        Me.txt_vencimiento.Size = New System.Drawing.Size(259, 20)
        Me.txt_vencimiento.TabIndex = 1
        '
        'lbl_vencimiento
        '
        Me.lbl_vencimiento.AutoSize = True
        Me.lbl_vencimiento.Location = New System.Drawing.Point(20, 70)
        Me.lbl_vencimiento.Name = "lbl_vencimiento"
        Me.lbl_vencimiento.Size = New System.Drawing.Size(95, 13)
        Me.lbl_vencimiento.TabIndex = 22
        Me.lbl_vencimiento.Text = "Vencimiento (días)"
        '
        'pic_search
        '
        Me.pic_search.Image = Global.DrOil.My.Resources.Resources.iconoLupa
        Me.pic_search.Location = New System.Drawing.Point(439, 131)
        Me.pic_search.Name = "pic_search"
        Me.pic_search.Size = New System.Drawing.Size(22, 22)
        Me.pic_search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_search.TabIndex = 28
        Me.pic_search.TabStop = False
        '
        'cmb_tarjeta
        '
        Me.cmb_tarjeta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_tarjeta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_tarjeta.FormattingEnabled = True
        Me.cmb_tarjeta.Location = New System.Drawing.Point(174, 132)
        Me.cmb_tarjeta.Name = "cmb_tarjeta"
        Me.cmb_tarjeta.Size = New System.Drawing.Size(259, 21)
        Me.cmb_tarjeta.TabIndex = 26
        '
        'lbl_tarjeta
        '
        Me.lbl_tarjeta.AutoSize = True
        Me.lbl_tarjeta.Location = New System.Drawing.Point(20, 138)
        Me.lbl_tarjeta.Name = "lbl_tarjeta"
        Me.lbl_tarjeta.Size = New System.Drawing.Size(136, 13)
        Me.lbl_tarjeta.TabIndex = 27
        Me.lbl_tarjeta.Text = "Tarjeta de crédito asociada"
        '
        'add_condicion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 294)
        Me.Controls.Add(Me.pic_search)
        Me.Controls.Add(Me.cmb_tarjeta)
        Me.Controls.Add(Me.lbl_tarjeta)
        Me.Controls.Add(Me.txt_vencimiento)
        Me.Controls.Add(Me.lbl_vencimiento)
        Me.Controls.Add(Me.txt_recargo)
        Me.Controls.Add(Me.lbl_recargo)
        Me.Controls.Add(Me.chk_activo)
        Me.Controls.Add(Me.txt_condicion)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.lbl_condicion)
        Me.Name = "add_condicion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agregar condición"
        CType(Me.pic_search, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_recargo As System.Windows.Forms.TextBox
    Friend WithEvents lbl_recargo As System.Windows.Forms.Label
    Friend WithEvents chk_activo As System.Windows.Forms.CheckBox
    Friend WithEvents txt_condicion As System.Windows.Forms.TextBox
    Friend WithEvents chk_secuencia As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents lbl_condicion As System.Windows.Forms.Label
    Friend WithEvents txt_vencimiento As System.Windows.Forms.TextBox
    Friend WithEvents lbl_vencimiento As System.Windows.Forms.Label
    Friend WithEvents pic_search As System.Windows.Forms.PictureBox
    Friend WithEvents cmb_tarjeta As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_tarjeta As System.Windows.Forms.Label
End Class
