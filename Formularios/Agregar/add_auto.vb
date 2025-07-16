Public Class add_auto
    Private nAuto As Integer
    Private id_cliente As Integer = -1
    Private id_marca As Integer = -1
    Private id_modelo As Integer = -1

    Private Sub Add_auto_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub Add_auto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form = Me
        Dim c As cliente

        'Cargo todos los clientes
        cargar_combo(cmb_clientes, "SELECT id_cliente, nombre + ' ' + apellido AS 'Nombre' FROM clientes WHERE activo = '1' ORDER BY nombre, apellido ASC", basedb, "nombre", "id_cliente")
        cmb_clientes.SelectedValue = -1
        'Cargo todas las marcas
        cargar_combo(cmb_marcas, "SELECT id_marca, marca FROM marcas_autos WHERE activo = '1' ORDER BY marca ASC", basedb, "marca", "id_marca")
        cmb_marcas.SelectedValue = -1
        'Cargo todos los modelos de la marca seleccionada 
        'cargar_combo(cmb_clientes, "SELECT id_cliente, nombre + ' ' + apellido AS 'Nombre' FROM clientes", basedb, "nombre", "id_cliente")

        'Cargo todos los descuentos
        cargar_combo(cmb_descuento, "SELECT d.id_descuento AS 'id_descuento', d.descripcion AS 'descripcion' FROM descuentos AS d WHERE d.activo = '1' ORDER BY d.descripcion ASC", basedb, "descripcion", "id_descuento")
        cmb_descuento.SelectedValue = id_sinDescuento

        chk_activo.Checked = True
        If edicion = True Or borrado = True Then
            chk_secuencia.Enabled = False
            If edita_auto.id_cliente <> 0 Then
                cmb_clientes.SelectedValue = edita_auto.id_cliente
            Else
                cmb_clientes.Text = "Seleccione un cliente"
            End If
            txt_patente.Text = edita_auto.patente
            If edita_auto.id_modelo <> 0 Then
                cmb_marcas.SelectedValue = info_modeloa(edita_auto.id_modelo).id_marca
            Else
                cmb_marcas.Text = "Seleccione una marca"
            End If
            'Cargo todos los modelos de la marca seleccionada 
            If edita_auto.id_modelo <> 0 Then
                cargar_combo(cmb_modelos, "SELECT moda.id_modelo AS 'ID', moda.modelo AS 'Modelo' " &
                "FROM modelosa AS moda " &
                "LEFT JOIN marcas_autos AS mara ON moda.id_marca_modelo = mara.id_marca " &
                        "WHERE mara.id_marca = '" + cmb_marcas.SelectedItem(0).ToString + "' ORDER BY moda.modelo ASC", basedb, "modelo", "id")
                'cmb_modelos.SelectedValue = CByte(edita_auto.id_modelo) 'Desborda byte
                cmb_modelos.SelectedValue = edita_auto.id_modelo
            Else
                cmb_modelos.Text = "Seleccione un modelo"
            End If

            If edita_auto.id_descuento <> 0 Then
                If edita_auto.id_descuento = id_sinDescuento Then
                    c = info_cliente(edita_auto.id_cliente)
                    cmb_descuento.SelectedValue = c.id_descuento
                Else
                    cmb_descuento.SelectedValue = edita_auto.id_descuento
                End If
            Else
                    cmb_descuento.Text = "Seleccione un modelo"
            End If

            txt_anio.Text = edita_auto.anio
            chk_activo.Checked = edita_auto.activo
            chk_deudor.Checked = edita_auto.deudor
        Else
            cmb_clientes.Text = "Seleccione un cliente"
            cmb_marcas.Text = "Seleccione una marca"
            cmb_modelos.Text = "Seleccione un modelo"
            cmb_descuento.Text = "Seleccione un descuento"
        End If

        If borrado = True Then
            cmb_clientes.Enabled = False
            txt_patente.Enabled = False
            cmb_marcas.Enabled = False
            cmb_modelos.Enabled = False
            txt_anio.Enabled = False
            chk_activo.Enabled = False
            cmd_ok.Visible = False
            cmd_exit.Visible = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar este auto?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If (borrarauto(edita_auto)) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado del auto, ¿desea intectar desactivarlo para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updateauto(edita_auto, True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero el auto no se borró definitivamente." + Chr(13) +
                                "Esto posiblemente se deba a que el auto, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar el auto, consulte con el programador")
                        End If
                    End If
                End If
            End If
            closeandupdate(Me)
        End If
    End Sub

    Private Sub pic_clsearch_Click(sender As Object, e As EventArgs) Handles pic_cliSearch.Click
        Dim tmp As String
        tmp = tabla
        tabla = "clientes"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        cmb_clientes.SelectedValue = id
        id = 0
        cmb_clientes_SelectionChangeCommitted(Nothing, Nothing)
    End Sub

    Private Sub cmb_marcas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_marcas.KeyPress
        e.Handled = False
    End Sub

    Private Sub cmb_marcas_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_marcas.SelectionChangeCommitted
        Dim sqlstr As String

        sqlstr = "SELECT moda.id_modelo AS 'ID', moda.modelo AS 'Modelo' " &
                    "FROM modelosa AS moda " &
                    "LEFT JOIN marcas_autos AS mara ON moda.id_marca_modelo = mara.id_marca " &
                    "WHERE moda.activo = 1 AND mara.id_marca = '" + cmb_marcas.SelectedItem(0).ToString + "' ORDER BY moda.modelo ASC"

        cargar_combo(cmb_modelos, sqlstr, basedb, "modelo", "id")
        cmb_modelos.Text = "Seleccione un modelo"
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If txt_patente.Text = "" Then
            MsgBox("El campo 'Patente' es obligatorio y está vacio")
            Exit Sub
        ElseIf cmb_clientes.Text = "Seleccione un cliente" Then
            MsgBox("El campo 'Cliente' es obligatorio y está vacio")
            Exit Sub
        ElseIf cmb_marcas.Text = "Seleccione una marca" Then
            MsgBox("El campo 'Marcas' es obligatorio y está vacio")
            Exit Sub
        ElseIf cmb_modelos.Text = "Seleccione un modelo" Then
            MsgBox("El campo 'Modelos' es obligatorio y está vacio")
            Exit Sub
        ElseIf cmb_descuento.Text = "Seleccione un descuento" Then
            MsgBox("El campo 'Descuentos' es obligatorio y está vacio")
            'ElseIf valida(txt_patente.Text, 4) = False Then
            '   MsgBox("La patente ingresada no es válida")
            '   Exit Sub
        End If

        Dim tmp As New auto

        If cmb_clientes.Text <> "Seleccione un cliente" Then tmp.id_cliente = CInt(cmb_clientes.SelectedItem(0).ToString)
        If cmb_modelos.Text <> "Seleccione un modelo" Then tmp.id_modelo = CInt(cmb_modelos.SelectedItem(0).ToString)
        If txt_anio.Text <> "" Then tmp.anio = CInt(txt_anio.Text)
        tmp.patente = txt_patente.Text
        tmp.activo = chk_activo.Checked
        tmp.deudor = chk_deudor.Checked
        tmp.id_descuento = cmb_descuento.SelectedValue

        If edicion = True Or nAuto <> -1 Then
            If nAuto = -1 Then
                tmp.id_auto = edita_auto.id_auto
            Else
                tmp.id_auto = nAuto
            End If
            If updateauto(tmp) = False Then
                MsgBox("Hubo un problema al actualizar el auto, consulte con su programdor", vbExclamation)
                closeandupdate(Me)
            End If
        Else
            If addauto(tmp) = False Then
                MsgBox("Hubo un problema al dar de alta el auto, consulte con su programdor", vbExclamation)
                closeandupdate(Me)
            End If
        End If

        If chk_secuencia.Checked = True Then
            'Cargo todos los clientes
            cargar_combo(cmb_clientes, "SELECT id_cliente, nombre + ' ' + apellido AS 'Nombre' FROM clientes ORDER BY nombre, apellido ASC", basedb, "nombre", "id_cliente")
            cmb_clientes.Text = "Seleccione un cliente"
            'Cargo todas las marcas
            cargar_combo(cmb_marcas, "SELECT id_marca, marca FROM marcas_autos ORDER BY marca ASC", basedb, "marca", "id_marca")
            cmb_marcas.Text = "Seleccione una marca"
            cmb_modelos.Text = "Seleccione un modelo"
            'Cargo todos los modelos de la marca seleccionada 
            'cargar_combo(cmb_clientes, "SELECT id_cliente, nombre + ' ' + apellido AS 'Nombre' FROM clientes", basedb, "nombre", "id_cliente")
            'Cargo todos los descuentos
            cargar_combo(cmb_descuento, "SELECT d.id_descuento AS 'id_descuento', d.descripcion AS 'descripcion' FROM descuentos AS d WHERE d.activo = '1' ORDER BY d.descripcion ASC", basedb, "descripcion", "id_descuento")
            cmb_descuento.SelectedValue = id_descuento
            cmb_descuento.Text = "Seleccione un descuento"
            txt_patente.Text = ""
            txt_anio.Text = ""
            chk_activo.Checked = True
            chk_deudor.Checked = False
        Else
            closeandupdate(Me)
        End If

    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        ' closeandupdate(Me)
        add_auto_FormClosed(Nothing, Nothing)
    End Sub

    Private Sub cmb_clientes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_clientes.KeyPress
        e.Handled = False
        'e.Handled = valida(e.KeyChar, 1)
    End Sub

    Private Sub cmb_modelos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_modelos.KeyPress
        e.Handled = False
    End Sub

    Private Sub txt_anio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_anio.KeyPress
        e.Handled = valida(e.KeyChar, 3)
    End Sub

    Private Sub cmb_marcas_LostFocus(sender As Object, e As EventArgs) Handles cmb_marcas.LostFocus
        '    If InStr(cmb_modelos.Text, "Seleccione") > 0 Then
        '        cargar_combo(cmb_modelos, "SELECT moda.id_modelo AS 'ID', moda.modelo AS 'Modelo' " &
        '       "FROM modelosa AS moda " &
        '       "LEFT JOIN marcas_autos AS mara ON moda.id_marca_modelo = mara.id_marca " &
        '               "WHERE mara.marca = '" + cmb_marcas.Text + "' ORDER BY moda.modelo ASC", basedb, "modelo", "id")
        '        cmb_modelos.Text = "Seleccione un modelo"
        '        cmb_modelos.SelectionLength = "Seleccione un modelo".Length
        '    End If
        '    cmb_modelos.SelectedValue = -1
    End Sub

    Private Sub txt_patente_LostFocus(sender As Object, e As EventArgs) Handles txt_patente.LostFocus
        Dim a As auto
        Dim c As cliente

        If txt_patente.Text <> "" Then
            nAuto = existeAuto(txt_patente.Text)
        Else
            Exit Sub
        End If

        If nAuto <> -1 Then
            a = info_auto(nAuto)
            c = info_cliente(a.id_cliente)

            With a
                cmb_clientes.SelectedValue = .id_cliente
                cmb_marcas.SelectedValue = info_modeloa(.id_modelo).id_marca

                cargar_combo(cmb_modelos, "SELECT moda.id_modelo AS 'ID', moda.modelo AS 'Modelo' " &
                "FROM modelosa AS moda " &
                "LEFT JOIN marcas_autos AS mara ON moda.id_marca_modelo = mara.id_marca " &
                        "WHERE mara.id_marca = '" + cmb_marcas.SelectedItem(0).ToString + "' ORDER BY moda.modelo ASC", basedb, "modelo", "id")

                'cmb_marcas_LostFocus(Nothing, Nothing)
                cmb_modelos.SelectedValue = .id_modelo
                txt_anio.Text = .anio
                chk_activo.Checked = .activo
                chk_deudor.Checked = .deudor
                If .id_descuento = id_sinDescuento Then
                    cmb_descuento.SelectedValue = c.id_descuento
                Else
                    cmb_descuento.SelectedValue = .id_descuento
                End If
            End With
        End If
    End Sub

    Private Sub cmb_clientes_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_clientes.SelectionChangeCommitted
        Dim c As cliente

        c = info_cliente(cmb_clientes.SelectedValue)
        If c.nombre <> "error" Then
            id_cliente = c.id_cliente
        Else
            Exit Sub
        End If

        cmb_clientes.Text = c.nombre + " " + c.apellido

        cmb_descuento.SelectedValue = 1
        cmb_descuento.SelectedValue = c.id_descuento
    End Sub

    Private Sub pick_descSearch_Click(sender As Object, e As EventArgs) Handles pick_descSearch.Click
        Dim tmp As String
        tmp = tabla
        tabla = "descuentos"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        cmb_descuento.SelectedValue = id
        id = 0
    End Sub

    Private Sub pic_modeloSearch_Click(sender As Object, e As EventArgs) Handles pic_modeloSearch.Click
        Dim tmp As String

        If cmb_marcas.SelectedValue = -1 Or cmb_marcas.SelectedValue = Nothing Then
            MsgBox("Primero debe elegir una marca", vbExclamation + vbOKOnly, "DR.Oil")
            Exit Sub
        End If

        Dim srch As New search(cmb_marcas.SelectedValue)


        tmp = tabla
        tabla = "modelosa"
        Me.Enabled = False

        srch.ShowDialog()
        srch.Dispose()

        'Establezco la opción del combo
        cmb_modelos.SelectedValue = id
        id = 0
    End Sub

    Private Sub pic_marcaSearch_Click(sender As Object, e As EventArgs) Handles pic_marcaSearch.Click
        Dim tmp As String
        tmp = tabla
        tabla = "marcas_autos"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        cmb_marcas.SelectedValue = id
        id = 0
    End Sub

    Private Sub cmb_modelos_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_modelos.SelectionChangeCommitted
        Dim ma As marca_auto

        If cmb_marcas.SelectedValue <> Nothing Then
            ma = info_marcaa(cmb_marcas.SelectedValue)

            cmb_marcas.Text = ma.marca
        End If
    End Sub


    Private Sub cmb_marcas_Enter(sender As Object, e As EventArgs) Handles cmb_marcas.Enter
        If cmb_clientes.SelectedValue <> Nothing Then
            cmb_clientes_SelectionChangeCommitted(Nothing, Nothing)
        End If
    End Sub

    Private Sub cmb_modelos_Enter(sender As Object, e As EventArgs) Handles cmb_modelos.Enter
        Dim sqlstr As String

        If Not (cmb_modelos.SelectedValue Is Nothing) Then Exit Sub

        sqlstr = "SELECT moda.id_modelo AS 'ID', moda.modelo AS 'Modelo' " &
                    "FROM modelosa AS moda " &
                    "LEFT JOIN marcas_autos AS mara ON moda.id_marca_modelo = mara.id_marca " &
                    "WHERE moda.activo = 1 AND mara.id_marca = '" + cmb_marcas.SelectedItem(0).ToString + "' ORDER BY moda.modelo ASC"

        cargar_combo(cmb_modelos, sqlstr, basedb, "modelo", "id")
        cmb_modelos.Text = "Seleccione un modelo"
    End Sub

    Private Sub txt_patente_Leave(sender As Object, e As EventArgs) Handles txt_patente.Leave
        txt_patente.Text = UCase(txt_patente.Text)
    End Sub


    'Private Sub cmb_modelos_LostFocus(sender As Object, e As EventArgs) Handles cmb_modelos.LostFocus
    '    Dim modeloA As New modelo_auto
    '    Dim id_modeloA As Integer

    '    Try
    '        id_modeloA = CInt(traer_info(basedb, "SELECT id_modelo FROM modelosa WHERE modelo = '" + cmb_modelos.Text + "'", 0)(0, 0))

    '        modeloA = info_modeloa(id_modeloA)



    '    Catch ex As Exception

    '    End Try
    'End Sub
End Class