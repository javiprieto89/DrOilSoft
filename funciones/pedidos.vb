'funciones/pedidos.vb
Imports System.Data.SqlClient

Module pedidos
    ' ************************************ FUNCIONES DE PEDIDOS *******************

    Public Function info_pedido(Optional ByVal id_pedido As String = "", Optional ByVal esCaso As Boolean = False) As pedido
        Dim tmp As New pedido
        Dim sqlstr As String
        If id_pedido = "" Then
            sqlstr = "SELECT TOP 1 * FROM pedidos ORDER BY id_pedido DESC"
        Else
            sqlstr = "SELECT * FROM pedidos WHERE id_pedido = '" & id_pedido & "'"
        End If
        Dim dt As DataTable = GetDataTable(sqlstr)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                If esCaso Then
                    tmp.id_pedido = .Item(0).ToString
                    tmp.fecha = .Item(1).ToString
                    tmp.id_auto = .Item(3).ToString
                    tmp.id_tipo = .Item(5).ToString
                    tmp.km = .Item(6).ToString
                    tmp.proximocambio = .Item(7).ToString
                    tmp.notas = .Item(8).ToString
                    tmp.id_condicion = .Item(9).ToString
                    tmp.id_descuento = .Item(10).ToString
                    tmp.id_caja = .Item(11).ToString
                    tmp.subTotal = .Item(12).ToString
                    tmp.total = .Item(13).ToString
                    tmp.activo = .Item(14).ToString
                    tmp.cerrado = .Item(15).ToString
                    tmp.montoTarjeta = .Item(16).ToString
                    tmp.fecha_cierre = .Item(17).ToString
                    tmp.id_usuario = .Item(20).ToString
                    tmp.id_vendedor = .Item(22).ToString
                    tmp.id_mecanico = .Item(23).ToString
                    tmp.id_pedidoStatus = .Item(24).ToString
                Else
                    tmp.id_pedido = .Item(0).ToString
                    tmp.fecha = .Item(1).ToString
                    tmp.id_cliente = .Item(2).ToString
                    tmp.notas = .Item(8).ToString
                    tmp.id_condicion = .Item(9).ToString
                    tmp.id_descuento = .Item(10).ToString
                    tmp.id_caja = .Item(11).ToString
                    tmp.subTotal = .Item(12).ToString
                    tmp.total = .Item(13).ToString
                    tmp.activo = .Item(14).ToString
                    tmp.cerrado = .Item(15).ToString
                    tmp.montoTarjeta = .Item(16).ToString
                    tmp.fecha_cierre = .Item(17).ToString
                    tmp.id_usuario = .Item(20).ToString
                    tmp.id_vendedor = .Item(22).ToString
                End If
            End With
        End If
        Return tmp
    End Function

    Public Function Info_Ultimo_Pedido_Por_Usuario(ByVal _idUsuario As Integer, ByVal _esCaso As Boolean) As pedido
        Dim tmp As New pedido
        Dim n As Integer = If(_esCaso, 1, 0)
        Dim sqlstr As String = "SELECT TOP 1 * FROM pedidos WHERE id_usuario = '" & _idUsuario.ToString & "' AND es_caso = '" & n.ToString & "' ORDER BY id_pedido DESC"
        Dim dt As DataTable = GetDataTable(sqlstr)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                If _esCaso Then
                    tmp.id_pedido = .Item(0).ToString
                    tmp.fecha = .Item(1).ToString
                    tmp.id_auto = .Item(3).ToString
                    tmp.id_tipo = .Item(5).ToString
                    tmp.km = .Item(6).ToString
                    tmp.proximocambio = .Item(7).ToString
                    tmp.notas = .Item(8).ToString
                    tmp.id_condicion = .Item(9).ToString
                    tmp.id_descuento = .Item(10).ToString
                    tmp.id_caja = .Item(11).ToString
                    tmp.subTotal = .Item(12).ToString
                    tmp.total = .Item(13).ToString
                    tmp.activo = .Item(14).ToString
                    tmp.cerrado = .Item(15).ToString
                    tmp.montoTarjeta = .Item(16).ToString
                    tmp.fecha_cierre = .Item(17).ToString
                    tmp.id_usuario = .Item(20).ToString
                    tmp.id_vendedor = .Item(22).ToString
                    tmp.id_mecanico = .Item(23).ToString
                    tmp.id_pedidoStatus = .Item(24).ToString
                Else
                    tmp.id_pedido = .Item(0).ToString
                    tmp.fecha = .Item(1).ToString
                    tmp.id_cliente = .Item(2).ToString
                    tmp.notas = .Item(8).ToString
                    tmp.id_condicion = .Item(9).ToString
                    tmp.id_descuento = .Item(10).ToString
                    tmp.id_caja = .Item(11).ToString
                    tmp.subTotal = .Item(12).ToString
                    tmp.total = .Item(13).ToString
                    tmp.activo = .Item(14).ToString
                    tmp.cerrado = .Item(15).ToString
                    tmp.montoTarjeta = .Item(16).ToString
                    tmp.fecha_cierre = .Item(17).ToString
                    tmp.id_usuario = .Item(20).ToString
                    tmp.id_vendedor = .Item(22).ToString
                End If
            End With
        End If
        Return tmp
    End Function

    Public Function addpedido(p As pedido) As Boolean
        Dim sqlstr As String
        If p.esCaso Then
            sqlstr = "SET DATEFORMAT dmy; INSERT INTO pedidos (fecha, id_tipo, km, proximocambio, notas, id_condicion, id_descuento, id_caja, id_cliente, id_auto, es_caso, subtotal, total, activo, montoTarjeta, id_usuario, id_vendedor, id_mecanico, id_PedidoStatus) VALUES ('" & p.fecha.ToString & "', '" & p.id_tipo.ToString & "', '" & p.km.ToString & "', '" & p.proximocambio.ToString & "', '" & p.notas & "', '" & p.id_condicion.ToString & "', '" & p.id_descuento.ToString & "', '" & p.id_caja.ToString & "', '" & p.id_cliente.ToString & "', '" & p.id_auto.ToString & "', '" & p.esCaso.ToString & "', '" & p.subTotal.ToString & "', '" & p.total.ToString & "', '" & p.activo.ToString & "', '" & p.montoTarjeta.ToString & "', '" & p.id_usuario.ToString & "', '" & p.id_vendedor.ToString & "', '" & p.id_mecanico.ToString & "', '" & p.id_pedidoStatus.ToString & "')"
        Else
            sqlstr = "SET DATEFORMAT dmy; INSERT INTO pedidos (fecha, id_cliente, notas, id_condicion, id_descuento, id_caja, subtotal, total, activo, montoTarjeta, id_usuario, id_vendedor) VALUES ('" & p.fecha.ToString & "', '" & p.id_cliente.ToString & "', '" & p.notas & "', '" & p.id_condicion.ToString & "', '" & p.id_descuento.ToString & "', '" & p.id_caja.ToString & "', '" & p.subTotal.ToString & "', '" & p.total.ToString & "', '" & p.activo.ToString & "', '" & p.montoTarjeta.ToString & "', '" & p.id_usuario.ToString & "', '" & p.id_vendedor.ToString & "')"
        End If
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function updatepedido(p As pedido, Optional borra As Boolean = False) As Boolean
        Dim sqlstr As String
        If borra Then
            sqlstr = "UPDATE pedidos SET activo = '0' WHERE id_pedido = '" & p.id_pedido.ToString & "'"
        Else
            If p.esCaso Then
                sqlstr = "SET DATEFORMAT dmy; UPDATE pedidos SET fecha = '" & p.fecha.ToString & "', id_cliente = '" & p.id_cliente.ToString & "', id_auto = '" & p.id_auto.ToString & "', id_tipo = '" & p.id_tipo.ToString & "', km = '" & p.km.ToString & "', proximocambio = '" & p.proximocambio.ToString & "', notas = '" & p.notas & "',  id_condicion = '" & p.id_condicion.ToString & "', id_descuento = '" & p.id_descuento.ToString & "', id_caja = '" & p.id_caja.ToString & "', subtotal = '" & p.subTotal.ToString & "', total = '" & p.total.ToString & "', activo = '" & p.activo.ToString & "', es_caso = '" & p.esCaso.ToString & "', montoTarjeta = '" & p.montoTarjeta.ToString & "', id_usuario = '" & p.id_usuario.ToString & "', id_vendedor = '" & p.id_vendedor.ToString & "', id_mecanico = '" & p.id_mecanico.ToString & "', id_pedidoStatus = '" & p.id_pedidoStatus.ToString & "' WHERE id_pedido = '" & p.id_pedido.ToString & "'"
            Else
                sqlstr = "SET DATEFORMAT dmy; UPDATE pedidos SET fecha = '" & p.fecha & "', id_cliente = '" & p.id_cliente.ToString & "', notas = '" & p.notas & "', id_condicion = '" & p.id_condicion.ToString & "', id_descuento = '" & p.id_descuento.ToString & "', id_caja = '" & p.id_caja.ToString & "', subtotal = '" & p.subTotal.ToString & "', total = '" & p.total.ToString & "', activo = '" & p.activo.ToString & "', montoTarjeta = '" & p.montoTarjeta.ToString & "', id_usuario = '" & p.id_usuario.ToString & "', id_vendedor = '" & p.id_vendedor.ToString & "' WHERE id_pedido = '" & p.id_pedido.ToString & "'"
            End If
        End If
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function cierreDiario(ByVal fecha_desde As Date, ByVal fecha_hasta As Date, ByVal consulta_pedidos As Boolean, ByVal consulta_casos As Boolean) As Boolean
        Dim where As String = ""
        If consulta_pedidos And Not consulta_casos Then
            where = " AND es_caso = '0'"
        ElseIf Not consulta_pedidos And consulta_casos Then
            where = " AND es_caso = '1'"
        End If
        Dim sqlstr As String = "SET DATEFORMAT dmy; UPDATE p SET p.activo = '0', p.cerrado = '1', p.fecha_cierre = '" & Format(DateTime.Now, "dd/MM/yyyy") & "' FROM pedidos AS p INNER JOIN cajas AS c ON p.id_caja = c.id_caja WHERE c.esCC = '0' AND p.fecha BETWEEN '" & fecha_desde.ToString("yyyy/MM/dd") & "' AND '" & fecha_hasta.ToString("yyyy/MM/dd") & "' AND p.activo = 1" & where
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function borrarpedido(p As pedido) As Boolean
        Dim sqlstr As String = "DELETE FROM registro_stockPedidos WHERE id_pedido = '" & p.id_pedido.ToString & "'; DELETE FROM pedidos_detalle WHERE id_pedido = '" & p.id_pedido.ToString & "'; DELETE FROM pedidos WHERE id_pedido = '" & p.id_pedido.ToString & "'"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function additempedidotmp(ByVal id_item As Integer, ByVal cantidad As Double, ByVal precio As Double, ByVal _idUsuario As Integer, ByVal _idUnico As String) As Boolean
        Dim exists As Boolean = info_itemtmp(id_item, _idUsuario, _idUnico)
        Dim sqlstr As String
        If exists Then
            sqlstr = "UPDATE tmppedidos_items SET cantidad = '" & cantidad.ToString & "', precio = '" & precio.ToString & "' WHERE id_item = '" & id_item.ToString & "' AND id_usuario = '" & _idUsuario.ToString & "' AND id_unico = '" & _idUnico & "'"
        Else
            sqlstr = "INSERT INTO tmppedidos_items (id_item, cantidad, precio, id_usuario, id_unico) VALUES ('" & id_item.ToString & "', '" & cantidad.ToString & "', '" & precio.ToString & "', '" & _idUsuario.ToString & "', '" & _idUnico & "')"
        End If
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function additempedido(ByVal _idUsuario As Integer, ByVal _idUnico As String, ByVal id_pedido As Integer, ByVal _esCaso As Boolean) As Boolean
        Dim sqlstr As String = "UPDATE pedidos_detalle SET cantidad = src.cantidad, precio = src.precio FROM pedidos_detalle dst JOIN tmppedidos_items src ON src.id_item = dst.id_item WHERE dst.id_pedido = '" & id_pedido.ToString & "' AND src.activo = '1' AND src.id_usuario = '" & _idUsuario.ToString & "' AND src.id_unico = '" & _idUnico & "' INSERT pedidos_detalle (id_item, cantidad, precio, id_pedido) SELECT id_item, cantidad, precio, '" & id_pedido.ToString & "' FROM tmppedidos_items src WHERE NOT EXISTS (SELECT * FROM pedidos_detalle dst WHERE src.id_item = dst.id_item AND dst.id_pedido = '" & id_pedido.ToString & "') AND src.activo = '1' AND src.id_usuario = '" & _idUsuario.ToString & "' AND src.id_unico = '" & _idUnico & "'"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function borrartbl(ByVal tbl As String) As Byte
        Dim sqlstr As String = "TRUNCATE TABLE " & tbl
        Return If(ExecuteNonQuery(sqlstr), 1, 0)
    End Function

    Public Function borrar_tabla_pedidos_temporales(ByVal idUsuario As Integer, ByVal idUnico As String) As Byte
        Dim sqlstr As String = "DELETE tmppedidos_items WHERE id_usuario = '" & idUsuario.ToString & "' AND id_unico = '" & idUnico & "'"
        Return If(ExecuteNonQuery(sqlstr), 1, 0)
    End Function

    Public Function borrar_tabla_pedidos_temporales(ByVal idUsuario As String) As Byte
        Dim sqlstr As String = "DELETE tmppedidos_items WHERE id_usuario = '" & idUsuario & "'"
        Return If(ExecuteNonQuery(sqlstr), 1, 0)
    End Function

    Public Function info_itempedido(ByVal id_item As String, Optional ByVal esCaso As Boolean = False) As item_pedido
        Dim tmp As New item_pedido
        Dim sqlstr As String = "SELECT * FROM pedidos_detalle WHERE id_item = '" & id_item & "'"
        Dim dt As DataTable = GetDataTable(sqlstr)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_pedido = .Item(0).ToString
                tmp.id_item = .Item(1).ToString
                tmp.cantidad = .Item(2).ToString
                tmp.precio = .Item(3).ToString
                tmp.activo = .Item(4).ToString
            End With
        End If
        Return tmp
    End Function

    Public Function cerrarpedido(ByVal p As pedido) As Boolean
        Dim sqlstr As String = "SET DATEFORMAT dmy; UPDATE pedidos SET cerrado = '1', activo = '0', fecha_cierre = '" & Format(DateTime.Now, "dd/MM/yyyy") & "' WHERE id_pedido = '" & p.id_pedido.ToString & "'"
        If ExecuteNonQuery(sqlstr) Then
            If showrpt Then
                id = p.id_pedido
                id = 0
            End If
            Return True
        End If
        Return False
    End Function

    Public Function idremitoAsociado(ByVal id_pedido As String) As Integer
        Dim sqlstr As String = "SELECT pp.id_pedido FROM pedidos AS p INNER JOIN pedidos AS pp ON p.id_pedido = pp.id_pedidoAsociado WHERE p.id_pedido = '" & id_pedido & "'"
        Dim dt As DataTable = GetDataTable(sqlstr)
        If dt.Rows.Count = 0 Then Return -1
        Return CInt(dt.Rows(0).Item(0))
    End Function

    Public Function emiteFE(ByVal f As FE) As Boolean
        Dim sqlstr As String = "SET DATEFORMAT dmy; INSERT INTO fe (id_pedido, id_comprobante, cae, fechavencimiento_cae, puntoVenta, numeroComprobante, codigoDeBarras, fecha_emision, subtotal, impuestos, total) VALUES('" & f.id_pedido & "', '" & f.id_comprobante.ToString & "', '" & f.cae & "', '" & f.fechavencimiento_cae & "', '" & f.puntoVenta.ToString & "', '" & f.numeroComprobante.ToString & "', '" & f.codigoDeBarras & "', '" & f.fecha_emision & "', '" & f.subtotal.ToString & "', '" & f.impuestos.ToString & "', '" & f.total.ToString & "')"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function info_preFe(ByVal id_pedido As Integer) As FE
        Dim tmp As New FE
        Dim dt As DataTable = GetDataTable("SELECT * FROM pedidos WHERE id_pedido = '" & id_pedido.ToString & "'")
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_pedido = .Item(0).ToString
                tmp.fecha = .Item(1).ToString
                tmp.total = .Item(13).ToString
            End With
        End If
        Return tmp
    End Function

    Public Function info_fe(ByVal id_pedido As Integer) As FE
        Dim tmp As New FE
        Dim dt As DataTable = GetDataTable("SELECT * FROM fe WHERE id_pedido = '" & id_pedido.ToString & "'")
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_fe = .Item(0).ToString
                tmp.id_pedido = .Item(1).ToString
                tmp.id_comprobante = .Item(2).ToString
                tmp.cae = .Item(3).ToString
                tmp.fechavencimiento_cae = .Item(4).ToString
                tmp.puntoVenta = .Item(5).ToString
                tmp.numeroComprobante = .Item(6).ToString
                tmp.codigoDeBarras = .Item(7).ToString
                tmp.fecha_emision = .Item(8).ToString
            End With
        End If
        Return tmp
    End Function

    Public Function Existe_Factura(ByVal id_pedido As Integer) As Boolean
        Dim sqlstr As String = "SELECT id_fe FROM FE WHERE id_pedido = '" & id_pedido.ToString & "'"
        Dim dt As DataTable = GetDataTable(sqlstr)
        Return dt.Rows.Count > 0
    End Function

    ' ************************************ FUNCIONES DE PEDIDOS *******************
End Module
