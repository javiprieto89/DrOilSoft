Imports DrOil.clsgenerales

Public Class add_caso
    Private recargo As Double
    Private descuento As Double
    Private idAClonar As Integer
    Private idUnico As String = ""
    Private esDuplicado As Boolean = False
    Private idUsuario As Integer
    Private itemsOff() As item

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal _idUnico As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        idUnico = _idUnico
    End Sub

    Public Sub New(ByVal _idUnico As String, ByVal _esDuplicado As Boolean)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        idUnico = _idUnico
        esDuplicado = _esDuplicado
    End Sub

    Public Sub New(ByVal _idUnico As String, ByVal _esDuplicado As Boolean, ByVal _idUsuario As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        idUnico = _idUnico
        esDuplicado = _esDuplicado
        idUsuario = _idUsuario
    End Sub

    Private Sub Add_caso_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        id = 0
        clonaItemsPedido = False
        Dim c As New pedido
        edita_pedido = c
        'borro la tabla temporal
        borrar_tabla_pedidos_temporales(idUsuario, idUnico)
        'restauro los que se borraron porque no se guardaron los cambios
        activaitems("pedidos_detalle")
        closeandupdate(Me)
    End Sub

    Private Sub Add_caso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Existe_FC As Boolean
        form = Me

        idUnico = Generar_ID_Unico()
        idUsuario = usuario_logueado.id_usuario

        cargarChk()

        If edicion Or borrado Or terminaCaso Or cargaRapidaDeCaso Or esDuplicado Then
            cmb_tipocaso.SelectedValue = edita_pedido.id_tipo
            lbl_cliente.Visible = True
            lbl_modelo.Visible = True
            lbl_marca.Visible = True


            lbl_date.Text = DateTime.Parse(edita_pedido.fecha)
            chk_secuencia.Enabled = False

            Dim a As New auto
            a = info_auto(edita_pedido.id_auto)
            cmb_patente.SelectedValue = edita_pedido.id_auto

            Dim c As New cliente
            c = info_cliente(a.id_cliente)

            lbl_cliente.Text = c.nombre + " " + c.apellido


            Dim moda As New modelo_auto
            moda = info_modeloa(a.id_modelo)
            lbl_modelo.Text = moda.modelo



            lbl_marca.Text = info_marcaa(moda.id_marca).marca

            txt_km.Text = edita_pedido.km
            txt_proximocambio.Text = edita_pedido.proximocambio

            txt_notas.Text = edita_pedido.notas

            cmb_condicion.SelectedValue = edita_pedido.id_condicion
            cmb_descuento.SelectedValue = edita_pedido.id_descuento
            cmb_caja.SelectedValue = edita_pedido.id_caja

            chk_imprimirOrden.Checked = False


            'Copio el pedido a la tabla tmppedidos_tmp para hacer todas las modificaciones desde ahí y después actualizo

            Cargar_listview(lsv_item, "SELECT ci.id_item AS 'ID', i.item AS 'Item', ti.tipo AS 'Categoría', ci.cantidad AS 'Cantidad', ci.precio AS 'Precio', " &
                                    "CAST(ci.cantidad * ci.precio AS DECIMAL(18,3)) AS 'Subtotal', CASE WHEN i.oferta = 0 THEN 'No' ELSE 'Si' END AS 'Oferta' " &
                                    "FROM pedidos_detalle AS ci " &
                                    "LEFT JOIN items AS i ON ci.id_item = i.id_item " &
                                    "LEFT JOIN tipos_items AS ti ON i.id_tipo = ti.id_tipo " &
                                    "WHERE ci.activo = '1' AND ci.id_pedido = '" + edita_pedido.id_pedido.ToString + "'", basedb)
            resaltarcolumna(lsv_item, 4, Color.Red)

            txt_subTotal.Text = edita_pedido.subTotal
            txt_total.Text = edita_pedido.total

            If info_condicion(edita_pedido.id_condicion).id_tarjeta <> 1 Then
                chk_pagoCombinado.Enabled = True
                If edita_pedido.montoTarjeta <> edita_pedido.total Then chk_pagoCombinado.Checked = True
            End If

            Dim cPago As New condicion
            cPago = info_condicion(cmb_condicion.SelectedValue)

            recargo = info_tarjeta(cPago.id_tarjeta).recargo
            descuento = info_descuento(cmb_descuento.SelectedValue).descuento
            updateitems(lsv_item, txt_total, txt_subTotal, recargo, descuento, idUnico, idUsuario)
        End If



        Existe_FC = Existe_Factura(edita_pedido.id_pedido)

        If Not edita_pedido.activo Or borrado Or Existe_FC Then
            txt_km.Enabled = False
            txt_proximocambio.Enabled = False
            txt_notas.ReadOnly = True
            psearch_auto.Enabled = False
            chk_secuencia.Enabled = False
            cmd_ok.Enabled = False
            cmd_add_caso_item.Enabled = False
            cmd_recargaprecios.Enabled = False
            lsv_item.Enabled = False
            txt_total.Enabled = False
            txt_cargaEAN.Enabled = False
            'If Existe_FC Then txt_notas.Text = "ESTE PEDIDO YA HA SIDO FACTURADO Y NO PUEDE SER MODIFICADO"
            If Existe_FC Then lbl_yaFacturado.Visible = True
            txt_notas.Enabled = False
            cmb_tipocaso.Enabled = False
            cmb_patente.Enabled = False
            cmb_condicion.Enabled = False
            cmb_descuento.Enabled = False
            cmb_caja.Enabled = False
            chk_pagoCombinado.Enabled = False
            cmb_vendedor.Enabled = False
            cmb_mecanico.Enabled = False
            cmb_estadoPedido.Enabled = False
            psearch_condicion.Enabled = False
            psearch_descuento.Enabled = False
            psearch_caja.Enabled = False
            psearch_vendedor.Enabled = False
            psearch_mecanico.Enabled = False
            psearch_estadoPedido.Enabled = False
            chk_imprimirOrden.Enabled = False
        End If


        Dim id_item As String
        Dim _item As New item
        Dim cantItems As Integer
        Dim faltanItems As Boolean
        Dim msgStr As String
        Dim i As Integer = 0
        If esDuplicado Then
            'Verifico que haya stock y esten activos tdos los productos que se cargaron al caso
            cantItems = lsv_item.Items.Count - 1
            ReDim itemsOff(cantItems)
            For Each x As ListViewItem In lsv_item.Items
                id_item = lsv_item.Items(i).SubItems(0).Text.ToString
                _item = info_item(id_item)

                If Not _item.activo Or _item.cantidad <= 0 Then
                    faltanItems = True
                    itemsOff(i) = _item
                    i = i + 1

                    msgStr = "No hay stock o estan inactivos los siguientes items, por lo cual se borraran del pedido: " & vbNewLine
                    For Each __item As item In itemsOff
                        Try
                            msgStr += __item.item & " - " & __item.descript & vbNewLine

                            'Se borran de la tabla los elemenos que no estan activos o no tienen stock
                            borraritemcargado(__item.id_item, "pedidos_detalle", edita_pedido.id_pedido)
                            borraritemcargado(__item.id_item, "tmppedidos_items")
                        Catch ex As Exception
                        End Try
                    Next
                    MsgBox(msgStr, vbOKOnly + vbExclamation)
                    updateitems(lsv_item, txt_total, txt_subTotal, recargo, descuento, idUnico, idUsuario)
                    resaltarcolumna(lsv_item, 4, Color.Red)
                End If
            Next
        End If

        If borrado = True Then
            cmd_exit.Enabled = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar este caso?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If (borrarpedido(edita_pedido)) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado del caso, ¿desea intetar desactivarlo para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updatepedido(edita_pedido, True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero el caso no se borró definitivamente." + Chr(13) +
                                "Esto posiblemente se deba a que el caso, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar el caso, consulte con el programador")
                        End If
                    End If
                End If
            End If
            closeandupdate(Me)
        End If
    End Sub

    Private Sub psearch_auto_DoubleClick(sender As Object, e As EventArgs) Handles psearch_auto.DoubleClick
        'busqueda        
        Dim tmp As String
        tmp = tabla
        tabla = "autos"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        cmb_patente.SelectedIndex = cmb_patente.FindString(info_auto(id).patente)
        updateform(id)
        id = 0
    End Sub

    Private Sub updateform(Optional ByVal seleccionado As String = "")
        If seleccionado = "" Then
            seleccionado = cmb_patente.SelectedValue
        End If

        Dim a As New auto
        a = info_auto(seleccionado)

        Dim cl As New cliente
        cl = info_cliente(a.id_cliente)

        Dim moda As New modelo_auto
        moda = info_modeloa(a.id_modelo)

        Dim marcaa As New marca_auto
        marcaa = info_marcaa(moda.id_marca)

        lbl_cliente.Text = cl.nombre + " " + cl.apellido

        If a.id_descuento = id_sinDescuento Then
            cmb_descuento.SelectedValue = cl.id_descuento
        Else
            cmb_descuento.SelectedValue = a.id_descuento
        End If

        lbl_marca.Text = marcaa.marca
        lbl_modelo.Text = moda.modelo

        lbl_cliente.Visible = True
        lbl_marca.Visible = True
        lbl_modelo.Visible = True
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If cmb_patente.Text = "Seleccione una patente" Then
            MsgBox("El campo 'Patente' es obligatorio y está vacio")
            Exit Sub
        ElseIf txt_km.Text = "" Then
            MsgBox("El campo 'Kilometraje' es obligatorio y está vacio")
            Exit Sub
        ElseIf cmb_tipocaso.Text = "Seleccione un tipo de caso" Then
            MsgBox("El campo 'Tipo caso' es obligatorio y está vacio")
            Exit Sub
        ElseIf cmb_condicion.Text = "Seleccione una condición de venta" Or cmb_condicion.Text = "" Then
            MsgBox("El campo 'Condición de venta' es obligatorio y está vacio")
            Exit Sub
        ElseIf cmb_descuento.Text = "Seleccione un descuento" Or cmb_descuento.Text = "" Then
            MsgBox("El campo 'Descuento' es obligatorio y está vacio")
            Exit Sub
        ElseIf cmb_caja.Text = "Seleccione una caja" Or cmb_caja.Text = "" Then
            MsgBox("El campo 'Caja' es obligatorio y está vacio")
            Exit Sub
        End If

        Dim c As New pedido

        c.fecha = lbl_date.Text
        c.id_tipo = cmb_tipocaso.SelectedValue
        c.km = CLng(txt_km.Text)
        If txt_proximocambio.Text <> "" Then c.proximocambio = CLng(txt_proximocambio.Text)
        c.notas = txt_notas.Text
        Dim a As New auto
        a = info_auto(, cmb_patente.Text)
        c.id_auto = a.id_auto
        c.id_cliente = a.id_cliente
        c.subTotal = txt_subTotal.Text
        c.total = txt_total.Text
        c.montoTarjeta = edita_pedido.montoTarjeta
        c.esCaso = True
        c.id_condicion = cmb_condicion.SelectedValue
        c.id_descuento = cmb_descuento.SelectedValue
        c.id_caja = cmb_caja.SelectedValue
        c.id_usuario = idUsuario

        c.id_vendedor = cmb_vendedor.SelectedValue
        c.id_mecanico = cmb_mecanico.SelectedValue
        c.id_pedidoStatus = cmb_estadoPedido.SelectedValue


        Dim cp As New condicion
        cp = info_condicion(cmb_condicion.SelectedValue)

        If cp.id_tarjeta <> 1 And Not chk_pagoCombinado.Checked Then
            c.montoTarjeta = c.total
        ElseIf cp.id_tarjeta = 1 Then
            c.montoTarjeta = 0
        End If

        If edicion Or clonaItemsPedido Then
            If clonaItemsPedido Then
                c.id_pedido = idAClonar
                edita_pedido = c
            Else
                c.id_pedido = edita_pedido.id_pedido
            End If

            'If chk_pagoCombinado.Checked Then
            '    c.montoTarjeta = edita_pedido.montoTarjeta
            'Else
            '    c.montoTarjeta = 0
            'End If
            If updatepedido(c) = False Then
                MsgBox("Hubo un problema al actualizar el caso.", vbExclamation)
                'borrartbl("tmppedidos_items")
                borrar_tabla_pedidos_temporales(idUsuario, idUnico)
                closeandupdate(Me)
            End If
            'actualizar caso (items)
            'borro los items            
            borraritemcargado(, "pedidos_detalle")
            borraritemcargado(, "tmppedidos_items")
            'agrego los items
            additempedido(idUsuario, idUnico, edita_pedido.id_pedido, True)
            'borrartbl("tmppedidos_items")
            borrar_tabla_pedidos_temporales(idUsuario, idUnico)

            If chk_pagoCombinado.Checked Then
                edita_pedido = c
                add_pagoCombinado.ShowDialog()
            End If
        Else
            'Agrego el caso
            If addpedido(c) Then
                'Obtengo el ID del caso que se acaba de dar de alta
                c.id_pedido = Info_Ultimo_Pedido_Por_Usuario(idUsuario, True).id_pedido
                'Agrego los items al caso
                additempedido(idUsuario, idUnico, c.id_pedido, True)
                'borrartbl("tmppedidos_items")
                borrar_tabla_pedidos_temporales(idUsuario, idUnico)
                'c.id_pedido = info_pedido(, 1).id_pedido

                If chk_pagoCombinado.Checked Then
                    edita_pedido = c
                    add_pagoCombinado.ShowDialog()
                End If
            Else
                MsgBox("Hubo un problema al agregar el caso.", vbExclamation)
                'borrartbl("tmppedidos_items")
                borrar_tabla_pedidos_temporales(idUsuario, idUnico)
                closeandupdate(Me)
            End If
        End If

        If chk_imprimirOrden.Checked Then
            Dim esHojaDeTrabajo As Boolean = 1
            id = c.id_pedido

            Dim frm As New frm_reportes(esHojaDeTrabajo)
            frm.ShowDialog()
            id = 0
        End If

        If chk_secuencia.Checked = True Then
            cargarChk()

            lbl_cliente.Text = ""
            lbl_marca.Text = ""
            lbl_modelo.Text = ""
            txt_km.Text = ""
            txt_proximocambio.Text = ""
            txt_notas.Text = ""
            cmb_vendedor.SelectedValue = id_vendedor
            cmb_mecanico.SelectedValue = id_mecanico
            cmb_estadoPedido.SelectedValue = id_pedidoStatus
            'borrartbl("tmppedidos_items")
            borrar_tabla_pedidos_temporales(idUsuario, idUnico)
            updateitems(lsv_item, txt_total, txt_subTotal, recargo, descuento, idUnico, idUsuario)

        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_add_caso_items_Click(sender As Object, e As EventArgs) Handles cmd_add_caso_item.Click
        Dim tmpTabla As String
        Dim tmpActivo As Boolean
        tmpTabla = tabla
        tmpActivo = activo

        tabla = "items_full"
        activo = True

        agregaItem = True
        Me.Enabled = False

        'search.ShowDialog()
        Dim frm As New search(idUsuario, idUnico)
        frm.ShowDialog()

        tabla = tmpTabla
        activo = tmpActivo
        agregaItem = False

        updateitems(lsv_item, txt_total, txt_subTotal, recargo, descuento, idUnico, idUsuario)
        resaltarcolumna(lsv_item, 4, Color.Red)
        chk_imprimirOrden.Checked = True
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        If edicion And edita_pedido.activo Then
            If chk_pagoCombinado.Checked Then
                add_pagoCombinado.ShowDialog()
            End If
        End If
        closeandupdate(Me)
    End Sub

    Private Sub lsv_item_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lsv_item.ColumnClick
        Me.lsv_item.ListViewItemSorter = New ListViewItemComparer(e.Column)
    End Sub

    Private Sub lsv_item_DoubleClick(sender As Object, e As EventArgs) Handles lsv_item.DoubleClick

        Dim seleccionado As Integer = lsv_item.SelectedItems.Item(0).Text
        edita_item = info_item(seleccionado)

        'infoagregaitem.ShowDialog()
        Dim frm As New infoagregaitem(idUsuario, idUnico)
        frm.ShowDialog()

        Dim i As New item
        edita_item = i

        updateitems(lsv_item, txt_total, txt_subTotal, recargo, descuento, idUnico, idUsuario)
        resaltarcolumna(lsv_item, 4, Color.Red)
        chk_imprimirOrden.Checked = True
    End Sub

    Private Sub lsv_item_MouseDown(sender As Object, e As MouseEventArgs) Handles lsv_item.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenuStrip1.Visible = True
        End If
    End Sub

    Private Sub BorrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BorrarToolStripMenuItem.Click
        If lsv_item.SelectedIndices.Count = 0 Then Exit Sub

        Dim seleccionado As String = lsv_item.SelectedItems.Item(0).Text


        borraritemcargado(seleccionado, "pedidos_detalle", edita_pedido.id_pedido)
        borraritemcargado(seleccionado, "tmppedidos_items")

        updateitems(lsv_item, txt_total, txt_subTotal, recargo, descuento, idUnico, idUsuario)
        resaltarcolumna(lsv_item, 4, Color.Red)
    End Sub

    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        lsv_item_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub cmd_recargaprecios_Click(sender As Object, e As EventArgs) Handles cmd_recargaprecios.Click
        If MsgBox("Esta acción reestablecerá todos los precios" & vbNewLine & "¿Está seguro?", vbYesNo, "Dr. Oil") = vbYes Then
            If edita_pedido.id_pedido Then
                recargaprecios(edita_pedido.id_pedido, , "pedidos_detalle")
            Else
                recargaprecios()
            End If
            updateitems(lsv_item, txt_total, txt_subTotal, recargo, descuento, idUnico, idUsuario)
        End If
        resaltarcolumna(lsv_item, 4, Color.Red)
    End Sub

    Private Sub RecargarPrecioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecargarPrecioToolStripMenuItem.Click
        If lsv_item.SelectedIndices.Count = 0 Then Exit Sub

        Dim seleccionado As String = lsv_item.SelectedItems.Item(0).Text
        If edita_pedido.id_pedido Then
            recargaprecios(edita_pedido.id_pedido, seleccionado, "pedidos_detalle")
        Else
            recargaprecios(, seleccionado)
        End If
        updateitems(lsv_item, txt_total, txt_subTotal, recargo, descuento, idUnico, idUsuario)
        resaltarcolumna(lsv_item, 4, Color.Red)
    End Sub

    Private Sub psearch_tipocaso_DoubleClick(sender As Object, e As EventArgs) Handles psearch_tipocaso.DoubleClick
        Dim tmp As String
        tmp = tabla
        tabla = "tipos_casos"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        cmb_tipocaso.SelectedIndex = cmb_tipocaso.FindString(info_tipocaso(id).tipo)
        id = 0
    End Sub

    Private Sub cmb_patente_LostFocus(sender As Object, e As EventArgs) Handles cmb_patente.LostFocus
        Try
            If cmb_patente.Text = "" Or cmb_patente.Text = "Seleccione una patente" Then Exit Sub
            Dim id_auto As Integer

            If edicion Or borrado Then
                If info_auto(edita_pedido.id_auto).patente = cmb_patente.Text Then Exit Sub
            End If

            id_auto = CInt(traer_info(basedb, "SELECT id_auto FROM autos WHERE patente = '" + cmb_patente.Text + "'", 0)(0, 0))

            Dim a As New auto
            a = info_auto(id_auto)

            Dim cl As New cliente
            cl = info_cliente(a.id_cliente)

            Dim moda As New modelo_auto
            moda = info_modeloa(a.id_modelo)

            Dim marcaa As New marca_auto
            marcaa = info_marcaa(moda.id_marca)

            lbl_cliente.Text = cl.nombre + " " + cl.apellido

            If a.id_descuento = id_sinDescuento Then
                cmb_descuento.SelectedValue = cl.id_descuento
            Else
                cmb_descuento.SelectedValue = a.id_descuento
            End If

            lbl_marca.Text = marcaa.marca
            lbl_modelo.Text = moda.modelo

            lbl_cliente.Visible = True
            lbl_marca.Visible = True
            lbl_modelo.Visible = True
        Catch ex As Exception
            MsgBox("No se encontró un auto con esa patente", vbCritical + vbOKOnly, "DR.Oil")
            cmb_patente.Text = "Seleccione una patente"
        End Try
    End Sub

    Private Sub cmb_patente_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_patente.SelectionChangeCommitted
        updateform()
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

    'Private Sub cmb_condicion_LostFocus(sender As Object, e As EventArgs) Handles cmb_condicion.LostFocus
    'Dim c As New condicion
    'c = info_condicion(cmb_condicion.SelectedValue)
    'Try
    '    Dim id_condicion As Integer
    '    id_condicion = CInt(traer_info(basedb, "SELECT id_condicion FROM condiciones WHERE condicion = '" + cmb_condicion.Text + "'", 0)(0, 0))

    '    If c.id_tarjeta <> 1 Then
    '        chk_pagoCombinado.Enabled = True
    '    Else
    '        chk_pagoCombinado.Enabled = False
    '    End If

    '    recargo = info_condicion(id_condicion).recargo
    '    updateitems(lsv_item, txt_total, txt_subTotal, recargo, descuento)
    '    resaltarcolumna(lsv_item, 4, Color.Red)
    'Catch ex As Exception

    'End Try
    'End Sub

    Private Sub cmb_condicion_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_condicion.SelectionChangeCommitted
        Dim c As New condicion
        c = info_condicion(cmb_condicion.SelectedValue)

        If c.id_tarjeta <> 1 Then
            chk_pagoCombinado.Enabled = True
            recargo = info_tarjeta(c.id_tarjeta).recargo
        Else
            chk_pagoCombinado.Enabled = False
            recargo = c.recargo
        End If

        updateitems(lsv_item, txt_total, txt_subTotal, recargo, descuento, idUnico, idUsuario)
        resaltarcolumna(lsv_item, 4, Color.Red)
        'recargo = info_condicion(cmb_condicion.SelectedValue).recargo
        'updateitems(lsv_item, txt_total, txt_subTotal, recargo, descuento)
        'resaltarcolumna(lsv_item, 4, Color.Red)
    End Sub

    Private Sub cmb_descuento_LostFocus(sender As Object, e As EventArgs) Handles cmb_descuento.LostFocus
        Try
            Dim id_descuento As Integer
            id_descuento = CInt(traer_info(basedb, "SELECT id_descuento FROM descuentos WHERE descripcion = '" + cmb_descuento.Text + "'", 0)(0, 0))

            descuento = info_descuento(id_descuento).descuento
            updateitems(lsv_item, txt_total, txt_subTotal, recargo, descuento, idUnico, idUsuario)
            resaltarcolumna(lsv_item, 4, Color.Red)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmb_descuento_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_descuento.SelectionChangeCommitted
        descuento = info_descuento(cmb_descuento.SelectedValue).descuento
        updateitems(lsv_item, txt_total, txt_subTotal, recargo, descuento, idUnico, idUsuario)
        resaltarcolumna(lsv_item, 4, Color.Red)
    End Sub

    Private Sub lsv_item_KeyDown(sender As Object, e As KeyEventArgs) Handles lsv_item.KeyDown
        If e.KeyCode = Keys.Insert Then
            cmd_add_caso_items_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub cmb_tipocaso_KeyDown(sender As Object, e As KeyEventArgs) Handles cmb_tipocaso.KeyDown
        If e.KeyCode = Keys.Insert Then
            cmd_add_caso_items_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txt_notas_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_notas.KeyDown
        If e.KeyCode = Keys.Insert Then
            cmd_add_caso_items_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txt_proximocambio_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_proximocambio.KeyDown
        If e.KeyCode = Keys.Insert Then
            cmd_add_caso_items_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Add_caso_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Insert Then
            cmd_add_caso_items_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txt_patente_KeyDown(sender As Object, e As KeyEventArgs)
        cmb_tipocaso.Visible = False
        If e.KeyCode = 45 Then cmd_add_caso_items_Click(Nothing, Nothing)
    End Sub

    Private Sub txt_km_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_km.KeyDown
        If e.KeyCode = Keys.Insert Then
            cmd_add_caso_items_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub cmb_patente_KeyDown(sender As Object, e As KeyEventArgs) Handles cmb_patente.KeyDown
        If e.KeyCode = Keys.Insert Then
            cmd_add_caso_items_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub cmb_condicion_KeyDown(sender As Object, e As KeyEventArgs) Handles cmb_condicion.KeyDown
        If e.KeyCode = Keys.Insert Then
            cmd_add_caso_items_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub cmb_descuento_KeyDown(sender As Object, e As KeyEventArgs) Handles cmb_descuento.KeyDown
        If e.KeyCode = Keys.Insert Then
            cmd_add_caso_items_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txt_subTotal_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_subTotal.KeyDown
        If e.KeyCode = Keys.Insert Then
            cmd_add_caso_items_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txt_total_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_total.KeyDown
        If e.KeyCode = Keys.Insert Then
            cmd_add_caso_items_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub psearch_caja_Click(sender As Object, e As EventArgs) Handles psearch_caja.Click
        Dim tmp As String
        tmp = tabla
        tabla = "caja"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        cmb_caja.SelectedIndex = cmb_caja.FindString(info_caja(id).nombre)
        id = 0
    End Sub
    Private Sub cmb_caja_KeyDown(sender As Object, e As KeyEventArgs) Handles cmb_caja.KeyDown
        If e.KeyCode = Keys.Insert Then
            cmd_add_caso_items_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ImportarItemsDeUnPedidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportarItemsDeUnPedidoToolStripMenuItem.Click
        Dim tmp As String
        tmp = tabla
        tabla = "clonaItemsPedido"
        clonaItemsPedido = True
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp
        If id = 0 Then Exit Sub
        idAClonar = id
        id = 0

        Cargar_listview(lsv_item, "SELECT ci.id_item AS 'ID', i.item AS 'Item', ti.tipo AS 'Categoría', ci.cantidad AS 'Cantidad', ci.precio AS 'Precio', " & _
                                       "CAST(ci.cantidad * ci.precio AS DECIMAL(18,3)) AS 'Subtotal' " & _
                                       "FROM pedidos_detalle AS ci " & _
                                       "LEFT JOIN items AS i ON ci.id_item = i.id_item " &
                                       "LEFT JOIN tipos_items AS ti ON i.id_tipo = ti.id_tipo " & _
                                       "WHERE ci.activo = '1' AND ci.id_pedido = '" + idAClonar.ToString + "'", basedb)

        Dim c As New pedido
        c = info_pedido(idAClonar)

        cmb_condicion.SelectedValue = c.id_condicion
        txt_total.Text = c.total
        txt_subTotal.Text = c.subTotal
    End Sub

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

                'Si estoy agregando un item, puede ser que el item ya exista, por lo que lo verifio para sumarlo a la cantidad que yo ingresé
                cantidad = askitemcargado(edita_item.id_item, edita_pedido.id_pedido, "pedidos_detalle", idUsuario, idUnico)
                If cantidad = -1 Then cantidad = askitemcargado(edita_item.id_item, 1, "tmppedidos_items", idUsuario, idUnico)

                If cantidad = -1 Then cantidad = 1 Else cantidad = cantidad + 1

                'Si por ejemplo tengo 3 unidades de un item, y actualizo y pongo 2 unidades, el chequeo de stock no debería hacerse porque puede ser que el stock de ese item actualmente sea 0, y yo
                'estaría devolviendo uno. Por eso pregunto por la cantidad del item.        
                cantidadb = askitemcargado(edita_item.id_item, edita_pedido.id_pedido, "pedidos_detalle", idUsuario, idUnico)
                If cantidadb = -1 Then cantidadb = askitemcargado(edita_item.id_item, 1, "tmppedidos_items", idUsuario, idUnico)

                If edita_item.cantidad < cantidad And cantidad > cantidadb Then
                    MsgBox("No hay " + cantidad.ToString + " " + edita_item.item.ToString + " hay solo " + edita_item.cantidad.ToString + ", ingrese una nueva cantidad o cancele", vbExclamation)
                    txt_cargaEAN.Text = ""
                    Exit Sub
                End If

                precio = edita_item.precio_lista

                additempedidotmp(edita_item.id_item, cantidad, precio, idUsuario, idUnico)
                'agregaItem = True
            End If

            'infoagregaitem.ShowDialog()

            'agregaItem = False

            edita_item = i
            updateitems(lsv_item, txt_total, txt_subTotal, recargo, descuento, idUnico, idUsuario)
            resaltarcolumna(lsv_item, 4, Color.Red)
            txt_cargaEAN.Text = ""
        End If
    End Sub

    'Private Sub cmb_patente_Leave(sender As Object, e As EventArgs) Handles cmb_patente.Leave
    '    cmb_patente.Text = UCase(cmb_patente.Text)
    'End Sub

    Private Sub cargarChk()
        Dim str As String

        'Cargo todas las patentes
        str = "SELECT a.id_auto AS 'id_auto', a.patente AS 'Patente' FROM autos AS a "
        'If Not edicion And Not borrado Then str += "WHERE a.activo = '1' "
        If edita_pedido.activo Then Str += "WHERE a.activo = '1' "
        Str += "ORDER BY a.patente ASC"
        cargar_combo(cmb_patente, Str, basedb, "patente", "id_auto")

        'Cargo todos los tipos de casos
        Str = "SELECT tc.id_tipo AS 'id_tipo', tc.tipo AS 'Tipo' FROM tipos_casos AS tc "
        'If Not edicion And Not borrado Then str += "WHERE tc.activo = '1' "
        If edita_pedido.activo Then Str += "WHERE tc.activo = '1' "
        Str += "ORDER BY tc.tipo ASC"
        cargar_combo(cmb_tipocaso, Str, basedb, "tipo", "id_tipo")

        'Cargo todas las condiciones de venta
        Str = "SELECT c.id_condicion AS 'id_condicion', c.condicion AS 'Condicion' FROM condiciones AS c "
        'If Not (edicion And Not borrado And edita_pedido.activo = 1) Or edita_pedido.activo = 1 Then str += "WHERE c.activo = '1' "
        If edita_pedido.activo Then Str += "WHERE c.activo = '1' "
        Str += "ORDER BY c.condicion ASC"
        cargar_combo(cmb_condicion, Str, basedb, "condicion", "id_condicion")

        'Cargo todos los descuentos
        Str = "SELECT d.id_descuento AS 'id_descuento', d.descripcion AS 'descripcion' FROM descuentos AS d "
        'If Not edicion And Not borrado Then str += "WHERE d.activo = '1' "
        If edita_pedido.activo Then Str += "WHERE d.activo = '1' "
        Str += "ORDER BY d.descripcion ASC"
        cargar_combo(cmb_descuento, Str, basedb, "descripcion", "id_descuento")

        'Cargo todas las cajas
        Str = "SELECT c.id_caja AS 'id_caja', c.nombre AS 'nombre' FROM cajas AS c "
        'If Not edicion And Not borrado Then str += "WHERE c.activo = '1' "
        If edita_pedido.activo Then Str += "WHERE c.activo = '1' "
        Str += "ORDER BY c.nombre ASC"
        cargar_combo(cmb_caja, str, basedb, "nombre", "id_caja")

        'Cargo todos los vendedores
        str = "SELECT v.id_vendedor AS 'id_vendedor', v.nombre AS 'nombre' FROM vendedores AS v "
        str += "ORDER BY v.nombre ASC"
        cargar_combo(cmb_vendedor, str, basedb, "nombre", "id_vendedor")

        'Cargo todos los mecánicos
        str = "SELECT m.id_mecanico AS 'id_mecanico', m.nombre AS 'nombre' FROM mecanicos AS m "
        str += "ORDER BY m.nombre ASC"
        cargar_combo(cmb_mecanico, str, basedb, "nombre", "id_mecanico")

        'Cargo todos los estados de pedidos
        str = "SELECT sep.id_pedidoStatus AS 'id_pedidoStatus', sep.estado AS 'estado' FROM sysEstado_pedidos AS sep "
        str += "ORDER BY sep.estado ASC"
        cargar_combo(cmb_estadoPedido, str, basedb, "estado", "id_pedidoStatus")

        If Not edicion And Not borrado Then
            cmb_patente.Text = "Seleccione una patente"
            cmb_tipocaso.Text = "Seleccione un tipo de caso"
            'cmb_condicion.Text = "Seleccione una condición de venta"
            'cmb_descuento.Text = "Seleccione un descuento"
            lbl_date.Text = Format(DateTime.Now, "dd/MM/yyyy")
            'lbl_date.Text = Format(DateTime.Now, "MM/dd/yyyy")
            txt_subTotal.Text = "0.00"
            txt_total.Text = "0,00"
            cmb_condicion.SelectedValue = id_condicion
            cmb_descuento.SelectedValue = id_descuento
            cmb_caja.SelectedValue = id_caja
            cmb_vendedor.SelectedValue = id_vendedor
            cmb_mecanico.SelectedValue = id_mecanico
            cmb_estadoPedido.SelectedValue = id_pedidoStatus
        End If
    End Sub

    Private Sub psearch_vendedor_Click(sender As Object, e As EventArgs) Handles psearch_vendedor.Click
        Dim tmp As String
        tmp = tabla
        tabla = "vendedores"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        cmb_vendedor.SelectedIndex = cmb_vendedor.FindString(info_vendedor(id).nombre)
        id = 0
    End Sub

    Private Sub psearch_mecanico_Click(sender As Object, e As EventArgs) Handles psearch_mecanico.Click
        Dim tmp As String
        tmp = tabla
        tabla = "mecanicos"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        cmb_mecanico.SelectedIndex = cmb_mecanico.FindString(info_mecanico(id).nombre)
        id = 0
    End Sub

    Private Sub psearch_estadoPedido_Click(sender As Object, e As EventArgs) Handles psearch_estadoPedido.Click
        Dim tmp As String
        tmp = tabla
        tabla = "estadosPedidos"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        cmb_estadoPedido.SelectedIndex = cmb_estadoPedido.FindString(info_estadoPedido(id).estado)
        id = 0
    End Sub
End Class