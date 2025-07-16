Public Class add_presupuesto
    Private recargo As Double
    Private descuento As Double
    Private idUnico As String
    Private idUsuario As Integer
    'Private es_presupuesto As Boolean = False

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub


    Private Sub cmd_add_item_Click(sender As Object, e As EventArgs) Handles cmd_add_item.Click
        Dim tmpTabla As String
        Dim tmpActivo As Boolean

        tmpTabla = tabla
        tmpActivo = activo
        tabla = "items_full_presupuesto"
        activo = True

        agregaItem = True
        Me.Enabled = False

        'search.ShowDialog()
        Dim frm As New search(idUsuario, idUnico)
        frm.ShowDialog()

        tabla = tmpTabla
        activo = tmpActivo
        agregaItem = False
        updateitems_presupuesto(lsv_item, txt_total, txt_subTotal, recargo, descuento, idUnico, idUsuario)
        resaltarcolumna(lsv_item, 4, Color.Red)
    End Sub

    Private Sub Add_presupuesto_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        id = 0
        Dim pe As New presupuesto
        edita_presupuesto = pe
        'borro la tabla temporal
        borrar_tabla_presupuestos_temporales(idUsuario, idUnico)
        'restauro los que se borraron porque no se guardaron los cambios
        activaitems("presupuestos_detalle")
        closeandupdate(Me)
    End Sub

    Private Sub Add_presupuesto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim str As String
        Dim Existe_FC As Boolean
        form = Me

        idUnico = Generar_ID_Unico()
        idUsuario = usuario_logueado.id_usuario

        cargarChk()

        If edicion Or borrado Then
            'cargo fecha de presupuesto
            'cargo cliente del presupuesto 
            'cargo items
            'cargo total
            'inhabilito carga secuencial

            lbl_date.Text = DateTime.Parse(edita_presupuesto.fecha)

            Dim cl As New cliente
            cl = info_cliente(edita_presupuesto.id_cliente)

            cmb_cliente.SelectedValue = edita_presupuesto.id_cliente


            Cargar_listview(lsv_item, "SELECT pit.id_item AS 'ID', i.item AS 'Item', ti.tipo AS 'Categoría', pit.cantidad AS 'Cantidad', pit.precio AS 'Precio', " &
                         "CAST(pit.cantidad * pit.precio AS DECIMAL(18,3)) AS 'Subtotal', CASE WHEN i.oferta = 0 THEN 'No' ELSE 'Si' END AS 'Oferta' " &
                        "FROM presupuestos_detalle AS pit " &
                         "LEFT JOIN items AS i ON pit.id_item = i.id_item " &
                         "LEFT JOIN tipos_items AS ti ON i.id_tipo = ti.id_tipo " &
                         "WHERE pit.activo = '1' AND pit.id_presupuesto = '" + edita_presupuesto.id_presupuesto.ToString + "'", basedb)
            resaltarcolumna(lsv_item, 4, Color.Red)

            txt_notas.Text = edita_presupuesto.notas
            cmb_condicion.SelectedValue = edita_presupuesto.id_condicion
            cmb_descuento.SelectedValue = edita_presupuesto.id_descuento

            txt_subTotal.Text = edita_presupuesto.subTotal
            txt_total.Text = edita_presupuesto.total
            chk_secuencia.Enabled = False

            'If info_condicion(edita_presupuesto.id_condicion).id_tarjeta <> 1 Then
            '    chk_pagoCombinado.Enabled = True
            '    If edita_presupuesto.montoTarjeta <> edita_presupuesto.total Then chk_pagoCombinado.Checked = True
            'End If

            Dim c As New condicion
            c = info_condicion(cmb_condicion.SelectedValue)

            recargo = info_tarjeta(c.id_tarjeta).recargo
            descuento = info_descuento(cmb_descuento.SelectedValue).descuento
            'es_presupuesto = edita_presupuesto.es_presupuesto
        End If

        Existe_FC = Existe_Factura(edita_presupuesto.id_presupuesto)

        'If Not edita_presupuesto.activo Or borrado Then
        '    cmb_cliente.Enabled = False
        '    pic_search.Enabled = False
        '    lsv_item.Enabled = False
        '    txt_total.Enabled = False
        '    txt_cargaEAN.Enabled = False
        '    If Existe_FC Then lbl_yaFacturado.Visible = True
        '    'If Existe_FC Then txt_notas.Text = "ESTE presupuesto YA HA SIDO FACTURADO Y NO PUEDE SER MODIFICADO"
        '    txt_notas.Enabled = False
        '    cmd_add_item.Enabled = False
        '    cmd_ok.Enabled = False
        '    cmd_recargaprecios.Enabled = False
        '    cmb_condicion.Enabled = False
        '    cmb_descuento.Enabled = False
        '    cmb_caja.Enabled = False
        '    chk_pagoCombinado.Enabled = False
        'End If

        If borrado = True Then
            cmd_exit.Enabled = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar este presupuesto?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If borrarpresupuesto(edita_presupuesto) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado del presupuesto, ¿desea intetar desactivarlo para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updatepresupuesto(edita_presupuesto, True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero el presupuesto no se borró definitivamente." + Chr(13) +
                                "Esto posiblemente se deba a que el presupuesto, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar el presupuesto.")
                        End If
                    End If
                End If
            End If
            closeandupdate(Me)
        End If
        Me.SelectNextControl(cmb_cliente, True, True, True, True)
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        'If edicion And edita_presupuesto.activo Then
        '    If chk_pagoCombinado.Checked Then
        '        add_pagoCombinado.ShowDialog()
        '    End If
        'End If
        closeandupdate(Me)
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If cmb_cliente.Text = "Seleccione un cliente" Or cmb_cliente.Text = "" Then
            MsgBox("El campo 'Cliente' es obligatorio y está vacio")
            Exit Sub
        ElseIf lsv_item.Items.Count = 0 Then
            MsgBox("No hay items cargados")
            Exit Sub
        ElseIf cmb_condicion.Text = "Seleccione una condición de venta" Or cmb_condicion.Text = "" Then
            MsgBox("El campo 'Condición de venta' es obligatorio y está vacio")
            Exit Sub
        ElseIf cmb_descuento.Text = "Seleccione una descuento" Or cmb_descuento.Text = "" Then
            MsgBox("El campo 'Descuento' es obligatorio y está vacio")
            Exit Sub
            'ElseIf cmb_caja.Text = "Seleccione una caja" Or cmb_caja.Text = "" Then
            '    MsgBox("El campo 'Caja' es obligatorio y está vacio")
            '    Exit Sub
        End If

        Dim p As New presupuesto

        p.id_presupuesto = -1
        p.id_cliente = cmb_cliente.SelectedValue
        p.fecha = lbl_date.Text
        p.notas = txt_notas.Text
        p.id_condicion = cmb_condicion.SelectedValue
        p.id_descuento = cmb_descuento.SelectedValue
        'p.id_caja = cmb_caja.SelectedValue
        p.subTotal = txt_subTotal.Text
        p.total = txt_total.Text
        p.montoTarjeta = edita_presupuesto.montoTarjeta
        'p.activo = True
        p.id_usuario = idUsuario

        Dim cp As New condicion
        cp = info_condicion(cmb_condicion.SelectedValue)

        'If cp.id_tarjeta <> 1 And Not chk_pagoCombinado.Checked Then
        '    p.montoTarjeta = p.total
        'ElseIf cp.id_tarjeta = 1 Then
        '    p.montoTarjeta = 0
        'End If

        If edicion = True Then
            'actualizar cliente
            p.id_presupuesto = edita_presupuesto.id_presupuesto
            'If chk_pagoCombinado.Checked Then
            '    p.montoTarjeta = edita_presupuesto.montoTarjeta
            'Else
            '    p.montoTarjeta = 0
            'End If

            If updatepresupuesto(p) = False Then
                MsgBox("Hubo un problema al actualizar el presupuesto.", vbExclamation)
                closeandupdate(Me)
            End If
            'actualizar presupuesto (items)
            'borro los items            
            borraritemcargado(, "presupuestos_detalle")
            borraritemcargado(, "tmppresupuestos_items")
            'agrego los items
            additempresupuesto(idUsuario, idUnico, edita_presupuesto.id_presupuesto, False)

            'borrartbl("tmppresupuestos_items")
            borrar_tabla_presupuestos_temporales(idUsuario, idUnico)

            'If chk_pagoCombinado.Checked Then
            '    edita_presupuesto = p
            '    add_pagoCombinado.ShowDialog()
            'End If
        Else
            'Agrego el presupuesto
            If addpresupuesto(p) Then
                'Obtengo el ID del presupuesto que se acaba de dar de alta
                p.id_presupuesto = Info_Ultimo_presupuesto_Por_Usuario(idUsuario).id_presupuesto
                'Agrego los items al presupuesto
                additempresupuesto(idUsuario, idUnico, p.id_presupuesto, False)
                'borrartbl("tmppresupuestos_items")
                borrar_tabla_presupuestos_temporales(idUsuario, idUnico)
                'p.id_presupuesto = info_presupuesto().id_presupuesto
                'If chk_pagoCombinado.Checked Then
                '    edita_presupuesto = p
                '    add_pagoCombinado.ShowDialog()
                'End If
                imprimirFactura(p.id_presupuesto, True, False)
            Else
                MsgBox("Hubo un problema al agregar el presupuesto.", vbExclamation)
                'borrartbl("tmppresupuestos_items")
                borrar_tabla_presupuestos_temporales(idUsuario, idUnico)
                closeandupdate(Me)
            End If
        End If

        If chk_secuencia.Checked = True Then
            'txt_cliente.Text = ""
            cmb_cliente.SelectedValue = id_cliente_pedido
            lbl_date.Text = Format(DateTime.Now, "dd/MM/yyyy")
            'lbl_date.Text = Format(DateTime.Now, "MM/dd/yyyy")
            txt_total.Text = ""
            lsv_item.Clear()

            cargarChk()

            cmb_condicion.SelectedValue = id_condicion
            cmb_descuento.SelectedValue = id_descuento
            cmb_cliente.SelectedValue = id_cliente_pedido
            'cmb_caja.SelectedValue = id_caja

            'borrartbl("tmppresupuestos_items")
            borrar_tabla_presupuestos_temporales(idUsuario, idUnico)
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub txt_total_TextChanged(sender As Object, e As EventArgs) Handles txt_total.TextChanged
        'If InStr(txt_total.Text, "$") = 0 Then txt_total.Text = "$ " + txt_total.Text
    End Sub

    Private Sub updateform(Optional ByVal seleccionado As String = "")
        If seleccionado = "" Then seleccionado = cmb_cliente.SelectedValue

        Dim c As New cliente
        c = info_cliente(seleccionado)
    End Sub

    Private Sub lsview_cliente_DoubleClick(sender As Object, e As EventArgs)
        updateform()
    End Sub

    Private Sub pic_search_Click(sender As Object, e As EventArgs) Handles pic_search.Click
        'busqueda
        Dim tmp As String
        tmp = tabla
        tabla = "clientes"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        updateform(id)
    End Sub

    Private Sub lsv_item_DoubleClick(sender As Object, e As EventArgs) Handles lsv_item.DoubleClick
        Dim seleccionado As Integer = lsv_item.SelectedItems.Item(0).Text
        edita_item = info_item(seleccionado)

        'infoagregaitem.ShowDialog()
        Dim frm As New infoagregaitem_presupuesto(idUsuario, idUnico)
        frm.ShowDialog()

        Dim i As New item
        edita_item = i

        updateitems_presupuesto(lsv_item, txt_total, txt_subTotal, recargo, descuento, idUnico, idUsuario)
        resaltarcolumna(lsv_item, 4, Color.Red)
    End Sub

    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        lsv_item_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub BorrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BorrarToolStripMenuItem.Click
        If lsv_item.SelectedIndices.Count = 0 Then Exit Sub

        Dim seleccionado As String = lsv_item.SelectedItems.Item(0).Text


        borraritemcargado(seleccionado, "presupuestos_detalle", edita_presupuesto.id_presupuesto)
        borraritemcargado(seleccionado, "tmppresupuestos_items")

        updateitems_presupuesto(lsv_item, txt_total, txt_subTotal, recargo, descuento, idUnico, idUsuario)
        resaltarcolumna(lsv_item, 4, Color.Red)
    End Sub

    Private Sub cmd_recargaprecios_Click(sender As Object, e As EventArgs) Handles cmd_recargaprecios.Click
        If MsgBox("Esta acción reestablecerá todos los precios" & vbNewLine & "¿Está seguro?", vbYesNo, "Dr. Oil") = vbYes Then
            If edita_presupuesto.id_presupuesto Then
                recargaprecios_presupuesto(edita_presupuesto.id_presupuesto, , "presupuestos_detalle")
            Else
                recargaprecios_presupuesto()
            End If
            updateitems_presupuesto(lsv_item, txt_total, txt_subTotal, recargo, descuento, idUnico, idUsuario)
        End If
        resaltarcolumna(lsv_item, 4, Color.Red)
    End Sub

    Private Sub RecargarPrecioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecargarPrecioToolStripMenuItem.Click
        If lsv_item.SelectedIndices.Count = 0 Then Exit Sub

        Dim seleccionado As String = lsv_item.SelectedItems.Item(0).Text
        If edita_presupuesto.id_presupuesto Then
            recargaprecios(edita_presupuesto.id_presupuesto, seleccionado, "presupuestos_detalle")
        Else
            recargaprecios(, seleccionado)
        End If
        updateitems_presupuesto(lsv_item, txt_total, txt_subTotal, recargo, descuento, idUnico, idUsuario)
        resaltarcolumna(lsv_item, 4, Color.Red)
    End Sub

    Private Sub cmb_condicion_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_condicion.SelectionChangeCommitted
        Dim c As New condicion
        c = info_condicion(cmb_condicion.SelectedValue)

        If c.id_tarjeta <> 1 Then
            'chk_pagoCombinado.Enabled = True
            recargo = info_tarjeta(c.id_tarjeta).recargo
        Else
            'chk_pagoCombinado.Enabled = False
            recargo = c.recargo
        End If

        updateitems_presupuesto(lsv_item, txt_total, txt_subTotal, recargo, descuento, idUnico, idUsuario)
        resaltarcolumna(lsv_item, 4, Color.Red)

    End Sub

    'Private Sub cmb_condicion_LostFocus(sender As Object, e As EventArgs) Handles cmb_condicion.LostFocus
    '    Try
    '        Dim id_condicion As Integer
    '        id_condicion = CInt(traer_info(basedb, "SELECT id_condicion FROM condiciones WHERE condicion = '" + cmb_condicion.Text + "'", 0)(0, 0))

    '        recargo = info_condicion(id_condicion).recargo
    '        updateitems_presupuesto(lsv_item, txt_total, txt_subTotal, recargo, descuento)
    '        resaltarcolumna(lsv_item, 4, Color.Red)
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub cmb_descuento_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_descuento.SelectionChangeCommitted
        descuento = info_descuento(cmb_descuento.SelectedValue).descuento
        updateitems_presupuesto(lsv_item, txt_total, txt_subTotal, recargo, descuento, idUnico, idUsuario)
        resaltarcolumna(lsv_item, 4, Color.Red)
    End Sub

    Private Sub cmb_descuento_LostFocus(sender As Object, e As EventArgs) Handles cmb_descuento.LostFocus
        Try
            Dim id_descuento As Integer
            id_descuento = CInt(traer_info(basedb, "SELECT id_descuento FROM descuentos WHERE descripcion = '" + cmb_descuento.Text + "'", 0)(0, 0))

            descuento = info_descuento(id_descuento).descuento
            updateitems_presupuesto(lsv_item, txt_total, txt_subTotal, recargo, descuento, idUnico, idUsuario)
            resaltarcolumna(lsv_item, 4, Color.Red)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Add_presupuesto_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Insert Then
            cmd_add_item_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub cmb_cliente_KeyDown(sender As Object, e As KeyEventArgs) Handles cmb_cliente.KeyDown
        If e.KeyCode = Keys.Insert Then
            cmd_add_item_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txt_subTotal_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_subTotal.KeyDown
        If e.KeyCode = Keys.Insert Then
            cmd_add_item_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txt_total_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_total.KeyDown
        If e.KeyCode = Keys.Insert Then
            cmd_add_item_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub cmb_condicion_KeyDown(sender As Object, e As KeyEventArgs) Handles cmb_condicion.KeyDown
        If e.KeyCode = Keys.Insert Then
            cmd_add_item_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub cmb_descuento_KeyDown(sender As Object, e As KeyEventArgs) Handles cmb_descuento.KeyDown
        If e.KeyCode = Keys.Insert Then
            cmd_add_item_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txt_notas_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_notas.KeyDown
        If e.KeyCode = Keys.Insert Then
            cmd_add_item_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub lsv_item_KeyDown(sender As Object, e As KeyEventArgs) Handles lsv_item.KeyDown
        If e.KeyCode = Keys.Insert Then
            cmd_add_item_Click(Nothing, Nothing)
        End If
    End Sub

    'Private Sub cmb_caja_KeyDown(sender As Object, e As KeyEventArgs) Handles cmb_caja.KeyDown
    '    If e.KeyCode = Keys.Insert Then
    '        cmd_add_item_Click(Nothing, Nothing)
    '    End If
    'End Sub

    Private Sub psearch_descuento_Click(sender As Object, e As EventArgs) Handles psearch_descuento.Click
        Dim tmp As String
        tmp = tabla
        tabla = "descuentos"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        cmb_descuento.SelectedIndex = cmb_descuento.FindString(info_descuento(id).descuento)
        id = 0
    End Sub

    Private Sub psearch_condicion_Click(sender As Object, e As EventArgs) Handles psearch_condicion.Click
        Dim tmp As String
        tmp = tabla
        tabla = "condiciones"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        cmb_condicion.SelectedIndex = cmb_condicion.FindString(info_condicion(id).condicion)
        id = 0
    End Sub

    'Private Sub psearch_caja_Click(sender As Object, e As EventArgs) Handles psearch_caja.Click
    '    Dim tmp As String
    '    tmp = tabla
    '    tabla = "caja"
    '    Me.Enabled = False
    '    search.ShowDialog()
    '    tabla = tmp

    '    'Establezco la opción del combo
    '    cmb_caja.SelectedIndex = cmb_caja.FindString(info_caja(id).nombre)
    '    id = 0
    'End Sub

    Private Sub cmb_condicion_Validated(sender As Object, e As EventArgs) Handles cmb_condicion.Validated
        cmb_condicion_SelectionChangeCommitted(Nothing, Nothing)
    End Sub

    Private Sub txt_cargaEAN_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_cargaEAN.KeyDown
        Dim cantidad As Double = -1
        Dim cantidadb As Double = -1
        Dim precio As Double
        Dim id_item As Integer = -1
        Dim i As New item

        If e.KeyCode = Keys.Enter Then
            If txt_cargaEAN.Text = "" Then
                MsgBox("Debe ingresar un EAN", vbCritical + vbOKOnly, "DROil")
            End If

            id_item = existeitemEAN(txt_cargaEAN.Text)
            If id_item = -1 Then
                MsgBox("Ese EAN no existe", vbCritical + vbOKOnly, "DROil")
                txt_cargaEAN.Text = ""
                Exit Sub
            Else
                edita_item = info_item(id_item)

                Activar_Item_Temporal_Cargado(edita_item.id_item, idUsuario, idUnico, edita_presupuesto.id_presupuesto)
                'Si estoy agregando un item, puede ser que el item ya exista, por lo que lo verifio para sumarlo a la cantidad que yo ingresé
                cantidad = askitemcargado_presupuesto(edita_item.id_item, edita_presupuesto.id_presupuesto, "presupuestos_detalle", idUsuario, idUnico)
                If cantidad = -1 Then cantidad = askitemcargado_presupuesto(edita_item.id_item, 1, "tmppresupuestos_items", idUsuario, idUnico)

                If cantidad = -1 Then cantidad = 1 Else cantidad = cantidad + 1

                'Si por ejemplo tengo 3 unidades de un item, y actualizo y pongo 2 unidades, el chequeo de stock no debería hacerse porque puede ser que el stock de ese item actualmente sea 0, y yo
                'estaría devolviendo uno. Por eso pregunto por la cantidad del item.        
                cantidadb = askitemcargado_presupuesto(edita_item.id_item, edita_presupuesto.id_presupuesto, "presupuestos_detalle", idUsuario, idUnico)
                If cantidadb = -1 Then cantidadb = askitemcargado_presupuesto(edita_item.id_item, 1, "tmppresupuestos_items", idUsuario, idUnico)

                If edita_item.cantidad < cantidad And cantidad > cantidadb Then
                    MsgBox("No hay " + cantidad.ToString + " " + edita_item.item.ToString + " hay solo " + edita_item.cantidad.ToString + ", ingrese una nueva cantidad o cancele", vbExclamation)
                    txt_cargaEAN.Text = ""
                    Exit Sub
                End If

                precio = edita_item.precio_lista

                additempresupuestotmp(edita_item.id_item, cantidad, precio, idUsuario, idUnico)
                'agregaItem = True
            End If

            'infoagregaitem.ShowDialog()

            'agregaItem = False

            edita_item = i
            updateitems_presupuesto(lsv_item, txt_total, txt_subTotal, recargo, descuento, idUnico, idUsuario)
            resaltarcolumna(lsv_item, 4, Color.Red)
            txt_cargaEAN.Text = ""
        End If
    End Sub

    Private Sub cmb_cliente_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_cliente.SelectionChangeCommitted
        Dim c As cliente
        c = info_cliente(cmb_cliente.SelectedValue)

        cmb_descuento.SelectedValue = c.id_descuento
    End Sub

    Private Sub cargarChk()
        Dim str As String

        'Cargo el combo con todos los clientes
        str = "SELECT c.id_cliente AS 'id_cliente', c.nombre + ' ' + c.apellido AS 'Nombre' FROM clientes AS c WHERE c.activo = '1' ORDER BY c.nombre, c.apellido ASC"
        cargar_combo(cmb_cliente, str, basedb, "nombre", "id_cliente")

        'Cargo todas las condiciones de venta
        str = "SELECT c.id_condicion AS 'id_condicion', c.condicion AS 'Condicion' FROM condiciones AS c WHERE c.activo = '1' ORDER BY c.condicion ASC"
        cargar_combo(cmb_condicion, str, basedb, "condicion", "id_condicion")

        'Cargo todos los descuentos
        str = "SELECT d.id_descuento AS 'id_descuento', d.descripcion AS 'descripcion' FROM descuentos AS d WHERE d.activo = '1' ORDER BY d.descripcion ASC"
        cargar_combo(cmb_descuento, str, basedb, "descripcion", "id_descuento")

        'Cargo todas las cajas
        'str = "SELECT c.id_caja AS 'id_caja', c.nombre AS 'nombre' FROM cajas AS c "
        'If edita_presupuesto.activo Then str += "WHERE c.activo = '1' "
        'str += "ORDER BY c.nombre ASC"
        'cargar_combo(cmb_caja, str, basedb, "nombre", "id_caja")

        If Not edicion And Not borrado Then
            lbl_date.Text = Format(DateTime.Now, "dd/MM/yyyy")
            'lbl_date.Text = Format(DateTime.Now, "MM/dd/yyyy")
            txt_subTotal.Text = "0.00"
            txt_total.Text = "0,00"
            If cmb_cliente.Items.Count = 0 Then
                MsgBox("Ha ocurrido un error, no se encuentra el cliente predeterminado", vbAbort)
                Exit Sub
            End If

            'cmb_condicion.Text = "Seleccione una condición de venta"
            'cmb_descuento.Text = "Seleccione un descuento"
            cmb_cliente.SelectedValue = id_cliente_pedido
            cmb_condicion.SelectedValue = id_condicion
            cmb_descuento.SelectedValue = id_descuento
            'cmb_caja.SelectedValue = id_caja
        End If
    End Sub
End Class