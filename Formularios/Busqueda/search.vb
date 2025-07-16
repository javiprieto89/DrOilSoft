Imports DROil.clsgenerales

Public Class search
    Dim stock0_local As Boolean
    Public Overridable Property SelectedIndex As Integer
    Dim id_marca As Integer = -1
    Dim idUsuario As Integer
    Dim idUnico As String

    Dim desde As Integer
    Dim hasta As Integer
    Dim pagina As Integer
    Dim nRegs As Integer
    Dim tPaginas As Integer
    Dim orderCol As ColumnClickEventArgs = Nothing

    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        stock0_local = main.chk_stock0.Checked
        chk_stock0.Checked = stock0_local
    End Sub

    Sub New(ByVal idMarca As Integer)

        ' Esta llamada es exigida por el diseñador.

        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        id_marca = idMarca
        stock0_local = main.chk_stock0.Checked
        chk_stock0.Checked = stock0_local
    End Sub

    Sub New(ByVal _idUsuario As Integer, ByVal _idUnico As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        idUsuario = _idUsuario
        idUnico = _idUnico
    End Sub

    Protected Overrides Sub Finalize()
        Dispose(False)
        MyBase.Finalize()
    End Sub

    Private Sub search_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        form.Enabled = True
        closeandupdate(Me)
        stock0 = stock0_local
    End Sub

    Private Sub search_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        form.Enabled = True
        closeandupdate(Me)
    End Sub

    Private Sub search_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        desde = 1
        hasta = itXPage
        pagina = 1

        actualizarlsv()
    End Sub

    Private Sub actualizarlsv()
        If txt_search.Text <> "" Then
            actualizarlsv_Search()
            Exit Sub
        End If

        Dim sqlstr As String = ""
        stock0_local = stock0


        Select Case tabla
            Case Is = "condiciones"
                sqlstr = "SELECT id_condicion AS 'ID', condicion AS 'Condición', vencimiento AS 'Vencimiento (días)', recargo AS 'Recargo', activo AS 'Activo' " &
                            "FROM condiciones " &
                            "WHERE activo = '" + activo.ToString + "' ORDER BY condicion ASC"
            Case Is = "descuentos"
                sqlstr = "SELECT id_descuento AS 'ID', descripcion AS 'Descripción', descuento AS 'Descuento', activo AS 'Activo' " &
                            "FROM descuentos " &
                            "WHERE activo = '" + activo.ToString + "' ORDER BY descripcion ASC"
            Case Is = "clientes"
                sqlstr = "SELECT id_cliente AS 'ID', dni AS 'DNI', nombre AS 'Nombre', apellido AS 'Apellido', " &
                        "telefono AS 'Teléfono', direccion AS 'Dirección', activo AS 'Activo' " &
                                "FROM clientes " &
                                "WHERE activo = '1' " &
                                "ORDER BY nombre, apellido ASC"
            Case Is = "vendedores"
                sqlstr = "SELECT id_vendedor AS 'ID', nombre AS 'Nombre', porcentaje AS 'Porcentaje', CASE WHEN activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                    "FROM vendedores " &
                    "WHERE activo = '" + activo.ToString + "' " &
                    "ORDER BY nombre ASC"
            Case Is = "mecanicos"
                sqlstr = "SELECT id_mecanico AS 'ID', nombre AS 'Nombre', porcentaje AS 'Porcentaje', CASE WHEN activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                    "FROM mecanicos " &
                    "WHERE activo = '" + activo.ToString + "' " &
                    "ORDER BY nombre ASC"
            Case Is = "estadosPedidos"
                sqlstr = "SELECT id_PedidoStatus AS 'ID', estado AS 'Estado', CASE WHEN esFin = 1 THEN 'Si' ELSE 'No' END AS '¿Es último estado?' " &
                    "FROM sysEstado_pedidos " &
                    "ORDER BY estado ASC"
            Case Is = "marcas_autos"
                sqlstr = "SELECT id_marca AS 'ID', marca AS 'Marca', activo AS 'Activo' FROM marcas_autos WHERE activo = '1' ORDER BY marca ASC"
            Case Is = "modelosa"
                If id_marca = -1 Then
                    sqlstr = "SELECT m.id_modelo AS 'ID', m.modelo AS 'Modelo', ma.marca AS 'Marca', " &
                                "m.activo AS 'Activo' " &
                                "FROM modelosa AS m " &
                                "LEFT JOIN marcas_autos AS ma ON m.id_marca_modelo = ma.id_marca " &
                                "WHERE m.activo = '1' " &
                                "ORDER BY m.modelo, ma.marca ASC"
                Else
                    sqlstr = "SELECT m.id_modelo AS 'ID', m.modelo AS 'Modelo', ma.marca AS 'Marca', " &
                               "m.activo AS 'Activo' " &
                               "FROM modelosa AS m " &
                               "LEFT JOIN marcas_autos AS ma ON m.id_marca_modelo = ma.id_marca " &
                               "WHERE m.activo = '1' AND m.id_marca_modelo = '" + id_marca.ToString + "' " &
                               "ORDER BY m.modelo, ma.marca ASC"
                End If
            Case Is = "autos"
                sqlstr = "SELECT a.id_auto AS 'ID', a.patente AS 'Patente', ma.marca AS 'Marca', mo.modelo AS 'Modelo', anio AS 'Año', c.nombre + ' ' + c.apellido AS 'Cliente', " &
                                "c.telefono AS 'Teléfono', a.activo AS 'Activo' " &
                                "FROM autos AS a " &
                                "LEFT JOIN clientes AS c ON a.id_cliente = c.id_cliente " &
                                "LEFT JOIN modelosa AS mo ON a.id_modelo = mo.id_modelo " &
                                "LEFT JOIN marcas_autos AS ma ON mo.id_marca_modelo = ma.id_marca " &
                                "WHERE a.activo = '1' " &
                                "ORDER BY c.nombre, c.apellido, ma.marca, mo.modelo, a.patente"
            Case Is = "proveedores"
                sqlstr = "SELECT id_proveedor AS 'ID', dni AS 'DNI', nombre AS 'Nombre', telefono AS 'Teléfono', " &
                                "direccion AS 'Dirección', vendedor AS 'Vendedor', activo AS 'Activo'" &
                                "FROM proveedores " &
                                "WHERE activo = '1' " &
                                "ORDER BY nombre ASC"
            Case Is = "tipos_items"
                sqlstr = "SELECT id_tipo AS 'ID', tipo as 'Categoría', activo AS 'Activo' " &
                                "FROM tipos_items " &
                                "WHERE activo = '1' " &
                                "ORDER BY tipo ASC"
            Case Is = "marcas_items"
                sqlstr = "SELECT id_marca AS 'ID', marca as 'Marca', activo AS 'Activo' " &
                                "FROM marcas_items " &
                                "WHERE activo = '1' " &
                                "ORDER BY marca ASC"
            Case Is = "roscas"
                sqlstr = "SELECT id_rosca AS 'ID', rosca AS 'Rosca', activo AS 'Activo' FROM roscas WHERE activo = '1' ORDER BY rosca ASC"
            Case Is = "items", "items2"
                sqlstr = "SELECT i.id_item AS 'ID', i.item AS 'Item', m.marca AS 'Marca', i.descript AS 'Descripción', i.cantidad AS 'Cantidad', i.precio_lista AS 'Precio de lista', " &
                                    "i.markup AS 'Markup', i.descuento AS 'Descuento', ti.descripcion AS 'I.V.A.', i.costo AS 'Costo', t.tipo AS 'Categoría', " &
                                    "i.wega AS 'WEGA', i.fram AS 'FRAM', i.mann AS 'MANN', i.oem AS 'OEM', r.rosca AS 'Rosca', p.nombre AS 'Proveedor', " &
                                    "i.activo AS 'Activo', i.checkStock AS 'Controla Stock', i.stockRepo AS 'Stock de reposición', i.oferta AS 'Artículo de oferta', i.EAN AS 'EAN', " &
                                    "CASE WHEN i.ultima_modificacion IS NULL THEN 'N/A' ELSE CAST(i.ultima_modificacion AS VARCHAR(50)) END AS 'Ult. Mod.' " &
                                    "FROM items AS i " &
                                "LEFT JOIN tipos_items AS t ON i.id_tipo = t.id_tipo " &
                                "LEFT JOIN marcas_items AS m ON i.id_marca = m.id_marca " &
                                "LEFT JOIN roscas AS r ON i.id_rosca = r.id_rosca " &
                                "LEFT JOIN proveedores AS p ON i.id_proveedor = p.id_proveedor " &
                                "LEFT JOIN iva AS ti ON i.id_iva = ti.id_iva " &
                                "WHERE i.activo = '1' "
                If chk_stock0.Checked Then
                    sqlstr = sqlstr + "AND i.cantidad > 0 "
                End If
                sqlstr = sqlstr + "ORDER BY i.item ASC"
            Case Is = "items_full", "items_full_presupuesto"
                chk_stock0.Visible = True
                sqlstr = "SELECT i.id_item AS 'ID', i.item AS 'Item', m.marca AS 'Marca', i.descript AS 'Descripción', i.cantidad AS 'Cantidad', i.precio_lista AS 'Precio de lista', " &
                                    "i.markup AS 'Markup', i.descuento AS 'Descuento', ti.descripcion AS 'I.V.A.', i.costo AS 'Costo', t.tipo AS 'Categoría', " &
                                    "i.wega AS 'WEGA', i.fram AS 'FRAM', i.mann AS 'MANN', i.oem AS 'OEM', r.rosca AS 'Rosca', p.nombre AS 'Proveedor', i.activo AS 'Activo', " &
                                    "i.checkStock AS 'Controla Stock', i.stockRepo AS 'Stock de reposición', i.oferta AS 'Artículo de oferta', i.EAN AS 'EAN', " &
                                    "CASE WHEN i.ultima_modificacion IS NULL THEN 'N/A' ELSE CAST(i.ultima_modificacion AS VARCHAR(50)) END AS 'Ult. Mod.' " &
                                    "FROM items AS i " &
                                    "LEFT JOIN tipos_items AS t ON i.id_tipo = t.id_tipo " &
                                    "LEFT JOIN marcas_items AS m ON i.id_marca = m.id_marca " &
                                    "LEFT JOIN roscas AS r ON i.id_rosca = r.id_rosca " &
                                    "LEFT JOIN proveedores AS p ON i.id_proveedor = p.id_proveedor " &
                                    "LEFT JOIN iva AS ti ON i.id_iva = ti.id_iva " &
                                    "WHERE i.activo = '" + activo.ToString + "' "
                If Not stock0 Then sqlstr += "AND i.cantidad >0 "
                sqlstr += "ORDER BY i.item ASC"
                'Case Is = "items_full_presupuesto"
            Case Is = "tipos_casos"
                sqlstr = "SELECT id_tipo AS 'ID', tipo AS 'Tipo', activo AS 'Activo' FROM tipos_casos WHERE activo = '1' ORDER BY tipo ASC"
            Case Is = "grupoTarjetas"
                sqlstr = "SELECT g.id_grupo AS 'ID', g.grupo AS 'Grupo de tarjetas' " +
                        "FROM grupo_tarjetas AS g " +
                        "ORDER BY g.grupo ASC"
            Case Is = "tarjetas"
                sqlstr = "SELECT t.id_tarjeta AS 'ID', t.tarjeta AS 'Nombre', t.recargo AS 'Recargo', t.cuotas AS 'Cuotas', " +
                            "g.grupo AS 'Grupo de tarjetas', t.activo AS 'Activo' " +
                            "FROM tarjetas AS t " +
                            "LEFT JOIN grupo_tarjetas AS g ON t.id_grupo = g.id_grupo " +
                            "WHERE t.activo = '" + activo.ToString + "' " +
                            "ORDER BY t.tarjeta ASC"
            Case Is = "caja"
                sqlstr = "SELECT c.id_caja AS 'ID', c.nombre AS 'Caja', c.activo AS 'Activo' " &
                        "FROM cajas AS c " &
                        "WHERE c.activo = '" + activo.ToString + "' " &
                        "ORDER BY c.id_caja ASC"
            Case Is = "archivoconsultas"
                sqlstr = "SELECT c.id_consulta AS 'ID', c.nombre AS 'Nombre', c.consulta AS 'Consulta SQL', c.activo AS 'Activo' " &
                         "FROM consultas_personalizadas AS c " &
                         "WHERE c.activo = '" + activo.ToString + "' " &
                         "ORDER BY c.id_consulta ASC"
            Case Is = "items_registros_stock"
                chk_secuencia.Visible = True
                chk_secuencia.Checked = secuencia
                sqlstr = "SELECT i.id_item AS 'ID', i.item AS 'Item', i.EAN AS 'EAN', i.descript AS 'Descripción', i.cantidad AS 'Cantidad', i.precio_lista AS 'Precio de lista', " &
                                "i.markup AS 'Markup', i.descuento AS 'Descuento', ti.descripcion AS 'I.V.A.', i.costo AS 'Costo', t.tipo AS 'Categoría', m.marca AS 'Marca', " &
                                "i.wega AS 'WEGA', i.fram AS 'FRAM', i.mann AS 'MANN', i.oem AS 'OEM', r.rosca AS 'Rosca', i.oem AS 'OEM', p.nombre AS 'Proveedor', i.activo AS 'Activo', " &
                                "i.checkStock AS 'Controla Stock', i.stockRepo AS 'Stock de reposición', i.oferta AS 'Artículo de oferta' " &
                                "FROM items AS i " &
                                "LEFT JOIN tipos_items AS t ON i.id_tipo = t.id_tipo " &
                                "LEFT JOIN marcas_items AS m ON i.id_marca = m.id_marca " &
                                "LEFT JOIN roscas AS r ON i.id_rosca = r.id_rosca " &
                                "LEFT JOIN proveedores AS p ON i.id_proveedor = p.id_proveedor " &
                                "LEFT JOIN iva AS ti ON i.id_iva = ti.id_iva " &
                                "ORDER BY i.item DESC"
            Case Is = "casos"
                If activo Then
                    sqlstr = "SELECT c.id_pedido AS 'ID', CAST(c.fecha AS VARCHAR(50)) AS 'Fecha', tc.tipo AS 'Tipo', c.km AS 'Kilometraje', c.proximocambio AS 'Próximo cambio', " &
                                "cli.nombre + ' ' + cli.apellido AS 'Cliente', cli.telefono AS 'Teléfono', a.patente AS 'Patente', ma.modelo AS 'Modelo', c.total AS 'Total', " &
                                "v.nombre AS 'Vendedor', m.nombre AS 'Mecánico', sep.estado AS 'Estado caso', c.activo AS 'Activo' " &
                                "FROM pedidos AS c " &
                                "LEFT JOIN autos AS a ON c.id_auto = a.id_auto " &
                                "LEFT JOIN modelosa AS ma ON a.id_modelo = ma.id_modelo " &
                                "LEFT JOIN clientes AS cli ON a.id_cliente = cli.id_cliente " &
                                "LEFT JOIN tipos_casos AS tc ON c.id_tipo = tc.id_tipo " &
                                "LEFT JOIN vendedores AS v ON p.id_vendedor = v.id_vendedor " &
                                "LEFT JOIN mecanicos AS m ON p.id_mecanico = m.id_mecanico " &
                                "LEFT JOIN sysEstado_pedidos AS sep ON p.id_PedidoStatus = sep.id_PedidoStatus " &
                                "WHERE c.cerrado = '0' AND c.activo = '1' AND c.es_caso = '1' " &
                                "ORDER BY cli.nombre, cli.apellido, c.id_pedido ASC"
                Else
                    sqlstr = "SELECT c.id_pedido AS 'ID', CAST(c.fecha AS VARCHAR(50)) AS 'Fecha', tc.tipo AS 'Tipo', c.km AS 'Kilometraje', c.proximocambio AS 'Próximo cambio', " &
                                "cli.nombre + ' ' + cli.apellido AS 'Cliente', cli.telefono AS 'Teléfono', a.patente AS 'Patente', ma.modelo AS 'Modelo', c.total AS 'Total', " &
                                "v.nombre AS 'Vendedor', m.nombre AS 'Mecánico', sep.estado AS 'Estado caso', c.activo AS 'Activo' " &
                                "FROM pedidos AS c " &
                                "LEFT JOIN autos AS a ON c.id_auto = a.id_auto " &
                                "LEFT JOIN modelosa AS ma ON a.id_modelo = ma.id_modelo " &
                                "LEFT JOIN clientes AS cli ON a.id_cliente = cli.id_cliente " &
                                "LEFT JOIN tipos_casos AS tc ON c.id_tipo = tc.id_tipo " &
                                "LEFT JOIN vendedores AS v ON p.id_vendedor = v.id_vendedor " &
                                "LEFT JOIN mecanicos AS m ON p.id_mecanico = m.id_mecanico " &
                                "LEFT JOIN sysEstado_pedidos AS sep ON p.id_PedidoStatus = sep.id_PedidoStatus " &
                                "WHERE c.cerrado = '1' AND c.activo = '0' AND c.es_caso = '1' " &
                                "ORDER BY cli.nombre, cli.apellido, c.id_pedido ASC"
                End If
            Case Is = "pedidos_detalle"
                sqlstr = "SELECT ci.id_pedido AS 'Caso', i.item AS 'Item', ci.cantidad AS 'Cantidad', ci.activo AS 'Activo' " &
                                "FROM pedidos_detalle AS ci " &
                                "LEFT JOIN items AS i ON ci.id_item = i.id_item " &
                                "WHERE ci.activo = '1' AND ci.id_pedido = '" + id.ToString + "' " &
                                "ORDER BY i.item ASC"
            Case Is = "pedidos", "clonaItemsPedido"
                If activo Then
                    sqlstr = "SELECT p.id_pedido AS 'ID', CAST(p.fecha AS VARCHAR(50)) AS 'Fecha', c.nombre + ' ' +  c.apellido AS 'Cliente', " &
                                        "p.total AS 'Total', p.activo AS 'Activo' " &
                                        "FROM pedidos AS p " &
                                        "LEFT JOIN clientes AS c ON p.id_cliente = c.id_cliente " &
                                        "WHERE p.cerrado = '0' AND p.activo = '1' AND p.es_caso = '0' "
                Else
                    sqlstr = "SELECT p.id_pedido AS 'ID', CAST(p.fecha AS VARCHAR(50)) AS 'Fecha', c.nombre + ' ' +  c.apellido AS 'Cliente', " &
                                        "p.total AS 'Total', p.activo AS 'Activo' " &
                                        "FROM pedidos AS p " &
                                        "LEFT JOIN clientes AS c ON p.id_cliente = c.id_cliente " &
                                        "WHERE p.cerrado = '1' AND p.activo = '0' AND p.es_caso = '0' "

                End If

                If tabla = "pedidos" Then
                    sqlstr += "ORDER BY c.nombre, c.apellido, p.id_pedido ASC"
                Else
                    sqlstr += "ORDER BY p.id_pedido DESC"
                End If
            Case Is = "pedidos_detalle"
                sqlstr = "SELECT pi.id_pedido AS 'Caso', i.item AS 'Item', pi.cantidad AS 'Cantidad', pi.activo AS 'Activo' " &
                                "FROM pedidos_detalle AS pi " &
                                "LEFT JOIN items AS i ON ci.id_item = i.id_item " &
                                "WHERE ci.activo = '1' AND ci.id_pedido = '" + id.ToString + "' " &
                                "ORDER BY i.item ASC"
            Case Is = "iva"
                sqlstr = "SELECT i.id_iva AS 'ID', i.descripcion AS 'Descripción', i.porcentaje AS 'Porcentaje' " &
                            "FROM iva AS i " &
                            "ORDER BY i.id_iva ASC"
            Case Is = "comprobantes"
                sqlstr = "SELECT c.id_comprobante AS 'ID', c.comprobante AS 'Comprobante', tc.comprobante_AFIP AS 'Tipo de Comprobante', c.numeroComprobante AS 'Número de comprobante', c.puntoVenta AS 'Punto de venta', " &
                                "CASE WHEN c.esFiscal = '1' THEN 'Fiscal' WHEN c.esElectronica = '1' THEN 'Eletrónico' ELSE 'Manual' END AS 'Formato de comprobante', c.testing AS 'Comprobante de testeo', c.activo AS 'Activo', " &
                                "c.maxItems AS 'Máximo de items', c.cantCopy AS 'Copias' " &
                                "FROM comprobantes AS c " &
                                "INNER JOIN tipos_comprobantes AS tc ON c.id_tipoComprobante = tc.id_tipoComprobante " &
                                "WHERE c.activo = '1' ORDER BY c.comprobante ASC"
        End Select

        If sqlstr = "" Then
            Exit Sub
        Else
            'Cargar_listview(lsview, sqlstr, basedb)
            Cargar_listview(lsview, sqlstr, basedb, desde, hasta, nRegs, tPaginas, pagina, txt_nPage, orderCol)
        End If

        If tabla = "items" Or tabla = "items_full" Then
            chk_secuencia.Visible = True
            resaltarcolumna(lsview, lightItemCol, Color.Red)
            chk_stock0.Visible = True
        ElseIf tabla = "registros_stock" Then
            resaltarcolumna(lsview, 4, Color.Red)
        ElseIf tabla = "items_registros_stock" Then
            resaltarcolumna(lsview, lightItemCol, Color.Red)
        ElseIf tabla = "pedidos" Then
            resaltarcolumna(lsview, 3, Color.Red)
        ElseIf tabla = "casos" Then
            resaltarcolumna(lsview, 9, Color.Red)
        ElseIf tabla = "items2" Then
            resaltarcolumna(lsview, lightItemCol, Color.Red)
            chk_stock0.Visible = True
        End If

        If lsview.Items.Count > 0 Then
            lsview.Items(0).Focused = True
            lsview.Items(0).Selected = True
        End If
    End Sub

    Private Sub txt_search_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_search.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            desde = 1
            hasta = itXPage
            pagina = 1

            actualizarlsv_Search()
        End If
    End Sub

    Private Sub actualizarlsv_Search()
        Dim txtsearch As String
        Dim sqlstr As String

        txtsearch = Microsoft.VisualBasic.Replace(txt_search.Text, " ", "%")
        sqlstr = sqlstrbuscar(txtsearch)

        'Cargar_listview(lsview, sqlstr, basedb)
        Cargar_listview(lsview, sqlstr, basedb, desde, hasta, nRegs, tPaginas, pagina, txt_nPage, orderCol)
        If tabla = "items" Or tabla = "registros_stock" Or tabla = "items_registros_stock" Or tabla = "items2" Then resaltarcolumna(lsview, lightItemCol, Color.Red)
    End Sub

    Private Sub lsview_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lsview.ColumnClick
        orderCol = e
        Me.lsview.ListViewItemSorter = New ListViewItemComparer(e.Column)
    End Sub

    Private Sub lsview_DoubleClick(sender As Object, e As EventArgs) Handles lsview.DoubleClick
        cmd_ok_Click(Nothing, Nothing)
    End Sub

    Private Sub lsview_MouseDown(sender As Object, e As MouseEventArgs) Handles lsview.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If tabla = "pedidos_detalle" Then

            End If
        End If
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        Dim seleccionado As String = lsview.SelectedItems.Item(0).Text
        Dim i As New item

        id = CInt(seleccionado)

        If tabla = "items" Or tabla = "items_full" Then
            edita_item = info_item(CInt(seleccionado))
            Dim frm As New infoagregaitem(idUsuario, idUnico)
            frm.ShowDialog()
            'infoagregaitem.ShowDialog()
            edita_item = i

            If chk_secuencia.Checked = True Then
                search_Load(Nothing, Nothing)
                Exit Sub
            End If
        ElseIf tabla = "items_full_presupuesto" Then
            edita_item = info_item(CInt(seleccionado))
            Dim frm As New infoagregaitem_presupuesto(idUsuario, idUnico)
            frm.ShowDialog()
            'infoagregaitem.ShowDialog()
            edita_item = i

            If chk_secuencia.Checked = True Then
                search_Load(Nothing, Nothing)
                Exit Sub
            End If
        ElseIf tabla = "items2" Then
            edita_item = info_item(CInt(seleccionado))
            With edita_item
                MsgBox(" ******* INFORMACION RAPIDA *******" & vbNewLine & vbNewLine +
                       "Código: " & .item & vbNewLine +
                       "Descripción: " & .descript & vbNewLine +
                       "Stock: " & .cantidad & vbNewLine +
                       "Precio: " & .precio_lista, vbOKOnly + vbInformation, "DR.Oil")
            End With
        ElseIf clonaItemsPedido Then

        End If


        secuencia = chk_secuencia.Checked 'Para el ingreso secuencial de stocks de items

        form.Enabled = True
        closeandupdate(Me)
    End Sub

    Private Sub lbl_borrarbusqueda_DoubleClick(sender As Object, e As EventArgs) Handles lbl_borrarbusqueda.DoubleClick
        txt_search.Text = ""
        Dim sqlstr As String = sqlstrbuscar("")

        'Cargar_listview(lsview, sqlstr, basedb)
        Cargar_listview(lsview, sqlstr, basedb, desde, hasta, nRegs, tPaginas, pagina, txt_nPage, orderCol)
        If tabla = "items" Or tabla = "registros_stock" Then resaltarcolumna(lsview, lightItemCol, Color.Red)
    End Sub

    Private Sub chk_stock0_CheckedChanged(sender As Object, e As EventArgs) Handles chk_stock0.CheckedChanged
        If chk_stock0.Checked Then
            stock0 = False
            itemsstock0 = False
        Else
            stock0 = True
            itemsstock0 = True
        End If
        If txt_search.Text <> "" Then
            Dim txtsearch As String
            Dim sqlstr As String

            txtsearch = Microsoft.VisualBasic.Replace(txt_search.Text, " ", "%")
            sqlstr = sqlstrbuscar(txtsearch)

            'Cargar_listview(lsview, sqlstr, basedb)
            Cargar_listview(lsview, sqlstr, basedb, desde, hasta, nRegs, tPaginas, pagina, txt_nPage, orderCol)
            If tabla = "items" Or tabla = "registros_stock" Or tabla = "items_registros_stock" Then resaltarcolumna(lsview, lightItemCol, Color.Red)
        Else
            search_Load(Nothing, Nothing)
        End If
    End Sub

    Private Sub cmd_first_Click(sender As Object, e As EventArgs) Handles cmd_first.Click
        desde = 1
        hasta = itXPage
        pagina = 1
        actualizarlsv()
    End Sub

    Private Sub cmd_prev_Click(sender As Object, e As EventArgs) Handles cmd_prev.Click
        If pagina = 1 Then Exit Sub
        desde -= itXPage
        hasta -= itXPage
        pagina -= 1
        actualizarlsv()
    End Sub

    Private Sub Cmd_next_Click(sender As Object, e As EventArgs) Handles cmd_next.Click
        If pagina = Math.Ceiling(nRegs / itXPage) Then Exit Sub
        desde += itXPage
        hasta += itXPage
        pagina += 1
        actualizarlsv()
    End Sub

    Private Sub Cmd_go_Click(sender As Object, e As EventArgs) Handles cmd_go.Click
        pagina = txt_nPage.Text
        If pagina > tPaginas Then pagina = tPaginas
        desde = pagina * itXPage
        hasta = desde + itXPage
        actualizarlsv()
    End Sub

    Private Sub cmd_last_Click(sender As Object, e As EventArgs) Handles cmd_last.Click
        pagina = tPaginas
        desde = nRegs - itXPage
        hasta = nRegs
        actualizarlsv()
    End Sub
End Class