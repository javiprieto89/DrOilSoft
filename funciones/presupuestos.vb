'funciones/presupuestos.vb
Imports System.Data.SqlClient

Module presupuestos
    '' ************************************ FUNCIONES DE PRESUPUESTOS ***************************
    Public Function info_presupuesto(Optional ByVal id_presupuesto As String = "") As presupuesto
        Dim tmp As New presupuesto
        Dim sqlstr As String
        If id_presupuesto = "" Then
            sqlstr = "SELECT TOP 1 * FROM presupuestos ORDER BY id_presupuesto DESC"
        Else
            sqlstr = "SELECT * FROM presupuestos WHERE id_presupuesto = '" & id_presupuesto & "'"
        End If
        Dim dt As DataTable = GetDataTable(sqlstr)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_presupuesto = .Item(0).ToString
                tmp.fecha = .Item(1).ToString
                tmp.id_cliente = .Item(2).ToString
                tmp.notas = .Item(3).ToString
                tmp.id_condicion = .Item(4).ToString
                tmp.id_descuento = .Item(5).ToString
                tmp.subTotal = .Item(6).ToString
                tmp.total = .Item(7).ToString
                tmp.montoTarjeta = .Item(8).ToString
                tmp.id_usuario = .Item(10).ToString
            End With
        End If
        Return tmp
    End Function

    Public Sub updateitems_presupuesto(ByVal lsv As ListView, ByVal txt_total As TextBox, ByVal txt_subtotal As TextBox, ByVal recargo As Double,
                       ByVal descuento As Double, ByVal idUnico As String, ByVal idUsuario As Integer)
        Cargar_listview(lsv, "SELECT ci.id_item AS 'ID', i.item AS 'Item', tim.tipo AS 'Categoria', ci.cantidad AS 'Cantidad', ci.precio AS 'Precio', " &
                             "CAST(ci.cantidad * ci.precio AS DECIMAL(18,3)) AS 'Subtotal', CASE WHEN i.oferta = 0 THEN 'No' ELSE 'Si' END AS 'Oferta' " &
                            "FROM presupuestos_detalle AS ci " &
                            "LEFT JOIN items AS i ON ci.id_item = i.id_item " &
                            "LEFT JOIN tipos_items AS tim ON i.id_tipo = tim.id_tipo " &
                            "WHERE ci.activo = '1' AND ci.id_item NOT IN (SELECT id_item FROM tmppresupuestos_items) " &
                            "AND ci.id_presupuesto = '" + edita_presupuesto.id_presupuesto.ToString + "' " &
                            "UNION " &
                            "SELECT ti.id_item AS 'ID', i.item AS 'Item', tim.tipo AS 'Categoría', ti.cantidad AS 'Cantidad', ti.precio AS 'Precio', " &
                            "CAST(ti.cantidad * ti.precio AS DECIMAL(18,3)) AS 'Subtotal', CASE WHEN i.oferta = 0 THEN 'No' ELSE 'Si' END AS 'Oferta'  " &
                            "FROM tmppresupuestos_items AS ti " &
                            "LEFT JOIN items AS i ON ti.id_item = i.id_item " &
                            "LEFT JOIN tipos_items AS tim ON i.id_tipo = tim.id_tipo " &
                            "WHERE ti.activo = '1' AND id_usuario = '" + idUsuario.ToString + "' AND id_unico = '" + idUnico + "'", basedb)

        lsv.Columns(6).Width = 0

        'Actualizo total
        Dim total_conDescuento As Double
        Dim total_sinDescuento As Double
        Dim total As Double
        Dim subtotal As Double
        Dim c As Integer

        'Sumo el total de los items a los que se les aplica el descuento y a los que no por separado
        For c = 0 To lsv.Items.Count - 1
            If lsv.Items(c).SubItems(6).Text = "No" Then
                total_conDescuento = total_conDescuento + (lsv.Items(c).SubItems(4).Text * lsv.Items(c).SubItems(3).Text)
            Else
                total_sinDescuento = total_sinDescuento + (lsv.Items(c).SubItems(4).Text * lsv.Items(c).SubItems(3).Text)
            End If
        Next

        'Tomo en cuenta el recargo por la condición de venta y el descuento
        recargo = recargo / 100
        descuento = 1 - (descuento / 100)
        subtotal = Math.Ceiling(total_conDescuento + total_sinDescuento)

        'total = Math.Ceiling((total + (total * recargo)) * descuento)v
        total = Math.Ceiling(((total_conDescuento + (total_conDescuento * recargo)) * descuento) + (total_sinDescuento + (total_sinDescuento * recargo)))
        txt_subtotal.Text = subtotal
        txt_total.Text = total
    End Sub

    Public Function Info_Ultimo_presupuesto_Por_Usuario(ByVal _idUsuario As Integer) As presupuesto
        Dim tmp As New presupuesto
        Dim sqlstr As String = "SELECT TOP 1 * FROM presupuestos WHERE id_usuario = '" & _idUsuario.ToString & "' ORDER BY id_presupuesto DESC"
        Dim dt As DataTable = GetDataTable(sqlstr)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_presupuesto = .Item(0).ToString
                tmp.fecha = .Item(1).ToString
                tmp.id_cliente = .Item(2).ToString
                tmp.notas = .Item(3).ToString
                tmp.id_condicion = .Item(4).ToString
                tmp.id_descuento = .Item(5).ToString
                tmp.subTotal = .Item(6).ToString
                tmp.total = .Item(7).ToString
                tmp.montoTarjeta = .Item(8).ToString
                tmp.id_usuario = .Item(10).ToString
            End With
        End If
        Return tmp
    End Function


    Public Function addpresupuesto(p As presupuesto) As Boolean
        Dim sqlstr As String = "SET DATEFORMAT dmy; INSERT INTO presupuestos (fecha, id_cliente, notas, id_condicion, id_descuento, subtotal, total, montoTarjeta, id_usuario) VALUES ('" & p.fecha.ToString & "', '" & p.id_cliente.ToString & "', '" & p.notas & "', '" & p.id_condicion.ToString & "', '" & p.id_descuento.ToString & "', '" & p.subTotal.ToString & "', '" & p.total.ToString & "', '" & p.montoTarjeta.ToString & "', '" & p.id_usuario.ToString & "')"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function updatepresupuesto(p As presupuesto, Optional borra As Boolean = False) As Boolean
        Dim sqlstr As String
        If borra = True Then
            sqlstr = "UPDATE presupuestos SET activo = '0' WHERE id_presupuesto = '" & p.id_presupuesto.ToString & "'"
        Else
            sqlstr = "SET DATEFORMAT dmy; UPDATE presupuestos SET fecha = '" & p.fecha & "', id_cliente = '" & p.id_cliente.ToString & "', notas = '" & p.notas & "', id_condicion = '" & p.id_condicion.ToString & "', id_descuento = '" & p.id_descuento.ToString & "', subtotal = '" & p.subTotal.ToString & "', total = '" & p.total.ToString & "', montoTarjeta = '" & p.montoTarjeta.ToString & "', id_usuario = '" & p.id_usuario.ToString & "' WHERE id_presupuesto = '" & p.id_presupuesto.ToString & "'"
        End If
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function borrarpresupuesto(p As presupuesto) As Boolean
        Dim sqlstr As String = "DELETE FROM presupuestos_detalle WHERE id_presupuesto = '" & p.id_presupuesto.ToString & "'; DELETE FROM presupuestos WHERE id_presupuesto = '" & p.id_presupuesto.ToString & "'"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function additempresupuestotmp(ByVal id_item As Integer, ByVal cantidad As Double, ByVal precio As Double,
                                   ByVal _idUsuario As Integer, ByVal _idUnico As String) As Boolean


        Dim itemtmpexiste As Boolean
        Dim sqlstr As String
        itemtmpexiste = info_itemtmp_presupuesto(id_item, _idUsuario, _idUnico)
        If itemtmpexiste Then
            sqlstr = "UPDATE tmppresupuestos_items SET cantidad = '" & cantidad.ToString & "', precio = '" & precio.ToString & "' WHERE id_item = '" & id_item.ToString & "' AND id_usuario = '" & _idUsuario.ToString & "' AND id_unico = '" & _idUnico & "'"
        Else
            sqlstr = "INSERT INTO tmppresupuestos_items (id_item, cantidad, precio, id_usuario, id_unico) VALUES ('" & id_item.ToString & "', '" & cantidad.ToString & "', '" & precio.ToString & "', '" & _idUsuario.ToString & "', '" & _idUnico & "')"
        End If
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function additempresupuesto(ByVal _idUsuario As Integer, ByVal _idUnico As String, ByVal id_presupuesto As Integer,
                                   ByVal _esCaso As Boolean) As Boolean
        'Obtengo el último presupuesto que se generó
        Dim sqlstr As String

        'If id_presupuesto = 0 Or id_presupuesto = -1 Then
        '    'id_presupuesto = info_presupuesto(, esCaso).id_presupuesto
        '    id_presupuesto = Info_Ultimo_presupuesto_Por_Usuario(_idUsuario, _esCaso).id_presupuesto
        'End If

        Dim sqlstr As String = "UPDATE presupuestos_detalle " &
                        "SET cantidad = src.cantidad, precio = src.precio " &
                        "FROM presupuestos_detalle dst " &
                        "JOIN tmppresupuestos_items src " &
                        "ON src.id_item = dst.id_item " &
                        "WHERE dst.id_presupuesto = '" + id_presupuesto.ToString + "' " &
                        "AND src.activo = '1' AND src.id_usuario = '" + _idUsuario.ToString + "' AND src.id_unico = '" + _idUnico + "' " &
                        "INSERT presupuestos_detalle " &
                        "(id_item, cantidad, precio, id_presupuesto) " &
                        "SELECT id_item" &
                        ", cantidad, precio, '" + id_presupuesto.ToString + "' " &
                        "FROM tmppresupuestos_items src " &
                        "WHERE NOT EXISTS " &
                        "(" &
                        "SELECT  * " &
                        "FROM presupuestos_detalle dst " &
                        "WHERE src.id_item = dst.id_item " &
                        "AND dst.id_presupuesto = '" + id_presupuesto.ToString + "'" &
                        ") " &
                        "AND src.activo = '1' AND src.id_usuario = '" + _idUsuario.ToString + "' AND src.id_unico = '" + _idUnico + "' "
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function borrar_tabla_presupuestos_temporales(ByVal idUsuario As Integer, ByVal idUnico As String) As Byte
        Dim sqlstr As String = "DELETE tmppresupuestos_items WHERE id_usuario = '" & idUsuario.ToString & "' AND id_unico = '" & idUnico & "'"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function borrar_tabla_presupuestos_temporales(ByVal idUsuario As String) As Byte
        Dim sqlstr As String = "DELETE tmppresupuestos_items WHERE id_usuario = '" & idUsuario & "'"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function info_itempresupuesto(ByVal id_item As String, Optional ByVal esCaso As Boolean = False) As item_presupuesto
        Dim tmp As New item_presupuesto
        Dim dt As DataTable = GetDataTable("SELECT * FROM presupuestos_detalle WHERE id_item = '" & id_item & "'")
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_presupuesto = .Item(0).ToString
                tmp.id_item = .Item(1).ToString
                tmp.cantidad = .Item(2).ToString
                tmp.precio = .Item(3).ToString
                tmp.activo = .Item(4).ToString
            End With
        End If
        Return tmp
    End Function

    Public Function askitemcargado_presupuesto(ByVal id_item As Integer, ByVal id As Integer, ByVal tabla As String, ByVal _idUsuario As Integer, ByVal _idUnico As String) As Double
        Dim sql As String
        If tabla = "presupuestos_detalle" Then
            sql = "SELECT cantidad FROM presupuestos_detalle WHERE id_item = '" & id_item.ToString & "' AND id_presupuesto = '" & id.ToString & "'"
        Else
            sql = "SELECT cantidad FROM tmppresupuestos_items WHERE id_item = '" & id_item.ToString & "' AND id_usuario = '" & _idUsuario.ToString & "' AND id_unico = '" & _idUnico & "'"
        End If
        Dim dt As DataTable = GetDataTable(sql)
        If dt.Rows.Count = 0 Then Return -1
        Return CDbl(dt.Rows(0).Item(0))
    End Function

    Public Function askpreciocargado_presupuesto(ByVal id_item As Integer, ByVal id As Integer, ByVal tabla As String, ByVal _idUsuario As Integer, ByVal _idUnico As String) As Double
        Dim sql As String
        If tabla = "presupuestos_detalle" Then
            sql = "SELECT precio FROM presupuestos_detalle WHERE id_item = '" & id_item.ToString & "' AND id_presupuesto = '" & id.ToString & "'"
        Else
            sql = "SELECT precio FROM tmppresupuestos_items WHERE id_item = '" & id_item.ToString & "' AND id_usuario = '" & _idUsuario.ToString & "' AND id_unico = '" & _idUnico & "'"
        End If
        Dim dt As DataTable = GetDataTable(sql)
        If dt.Rows.Count = 0 Then Return -1
        Return CDbl(dt.Rows(0).Item(0))
    End Function

    Public Function recargaprecios_presupuesto(Optional ByVal id As Integer = 0, Optional ByVal id_item As Integer = 0, Optional ByVal tabla As String = "") As Boolean
        Dim sqlstr As String

        If id_item = 0 Then
            If tabla = "presupuestos_detalle" Then
                sqlstr = "UPDATE presupuestos_detalle SET precio = " &
                            "(SELECT precio_lista FROM items " &
                            "WHERE presupuestos_detalle.id_item = items.id_item) " &
                            "WHERE id_presupuesto = '" + id.ToString + "'"
            Else
                sqlstr = "UPDATE tmppresupuestos_items SET precio = " &
                            "(SELECT precio_lista FROM items " &
                            "WHERE tmppresupuestos_items.id_item = items.id_item)"
            End If
        Else
            If tabla = "presupuestos_detalle" Then
                sqlstr = "UPDATE presupuestos_detalle SET precio = " &
                            "(SELECT precio_lista FROM items " &
                            "WHERE presupuestos_detalle.id_item = items.id_item) " &
                            "WHERE id_presupuesto = '" + id.ToString + "' AND id_item = '" + id_item.ToString + "'"
            Else
                sqlstr = "UPDATE tmppresupuestos_items SET precio = " &
                            "(SELECT precio_lista FROM items " &
                            "WHERE tmppresupuestos_items.id_item = items.id_item) " &
                            "WHERE id_item = '" + id_item.ToString + "'"
            End If
        End If


        Dim ok As Boolean = ExecuteNonQuery(sqlstr)
        If ok AndAlso id <> 0 And tabla <> "" Then
            If recargaprecios(, id_item) = False Then Return False
        End If
        Return ok
    End Function

    Public Function info_itemtmp_presupuesto(ByVal _idItem As Integer, ByVal _idUsuario As Integer, ByVal _idUnico As String) As Boolean
        Dim sqlstr As String = "SELECT * FROM tmppresupuestos_items WHERE id_item = '" & _idItem.ToString & "' AND id_usuario = '" & _idUsuario.ToString & "' AND id_unico = '" & _idUnico & "'"
        Dim dt As DataTable = GetDataTable(sqlstr)
        Return dt.Rows.Count > 0
    End Function
    '' ************************************ FUNCIONES DE PRESUPUESTOS ***************************
End Module
