'funciones/items.vb
﻿Imports System.Data.SqlClient

Module mitem
    ' ************************************ FUNCIONES DE ITEMS ***************************
    Public Function info_item(ByVal id_item As String) As item
        Dim tmp As New item
        Dim sqlstr As String = "SELECT * FROM items WHERE id_item = '" & id_item & "'"
        Dim dt As DataTable = GetDataTable(sqlstr)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_item = .Item(0).ToString
                tmp.item = .Item(1).ToString
                tmp.descript = .Item(2).ToString
                tmp.cantidad = .Item(3).ToString
                tmp.costo = .Item(4).ToString
                tmp.precio_lista = .Item(5).ToString
                tmp.id_tipo = .Item(6).ToString
                tmp.id_marca = .Item(7).ToString
                tmp.id_proveedor = .Item(8).ToString
                tmp.wega = .Item(9).ToString
                tmp.fram = .Item(10).ToString
                tmp.mann = .Item(11).ToString
                If .Item(12).ToString <> "" Then tmp.id_rosca = .Item(12).ToString
                tmp.markup = .Item(13).ToString
                tmp.descuento = .Item(14).ToString
                tmp.id_iva = .Item(15).ToString
                tmp.activo = .Item(16).ToString
                tmp.EAN = .Item(17).ToString
                tmp.checkStock = .Item(18).ToString
                tmp.stockRepo = .Item(19).ToString
                tmp.oferta = .Item(20).ToString
                tmp.oem = .Item(21).ToString
            End With
        End If
        Return tmp
    End Function

    Public Function info_itemtmp(ByVal _idItem As Integer, ByVal _idUsuario As Integer, ByVal _idUnico As String) As Boolean
        Dim sqlstr As String = "SELECT * FROM tmppedidos_items WHERE id_item = '" & _idItem.ToString & "' AND id_usuario = '" & _idUsuario.ToString & "' AND id_unico = '" & _idUnico & "'"
        Dim dt As DataTable = GetDataTable(sqlstr)
        Return dt.Rows.Count > 0
    End Function

    Public Function additem(it As item) As Boolean
        Dim sqlstr As String
        If it.id_rosca = 0 Then
            sqlstr = "INSERT INTO items (item, descript, cantidad, costo, precio_lista, id_tipo, id_marca, id_proveedor, wega, fram, mann, markup, descuento, id_iva, activo, EAN, checkStock, stockRepo, oferta, oem) VALUES ('" & it.item & "', '" & it.descript & "', '" & it.cantidad & "', '" & it.costo & "', '" & it.precio_lista & "', '" & it.id_tipo & "', '" & it.id_marca & "', '" & it.id_proveedor & "', '" & it.wega & "', '" & it.fram & "', '" & it.mann & "', '" & it.markup & "', '" & it.descuento & "', '" & it.id_iva & "', '" & it.activo & "', '" & it.EAN & "', '" & it.checkStock & "', '" & it.stockRepo & "', '" & it.oferta & "', '" & it.oem & "')"
        Else
            sqlstr = "INSERT INTO items (item, descript, cantidad, costo, precio_lista, id_tipo, id_marca, id_proveedor, wega, fram, mann, id_rosca, markup, descuento, id_iva, activo, EAN, checkStock, stockRepo, oferta, oem) VALUES ('" & it.item & "', '" & it.descript & "', '" & it.cantidad & "', '" & it.costo & "', '" & it.precio_lista & "', '" & it.id_tipo & "', '" & it.id_marca & "', '" & it.id_proveedor & "', '" & it.wega & "', '" & it.fram & "', '" & it.mann & "', '" & it.id_rosca & "', '" & it.markup & "', '" & it.descuento & "', '" & it.id_iva & "', '" & it.activo & "', '" & it.EAN & "', '" & it.checkStock & "', '" & it.stockRepo & "', '" & it.oferta & "', '" & it.oem & "')"
        End If
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function updateitem(it As item, Optional borra As Boolean = False) As Boolean
        Dim sqlstr As String
        If borra Then
            sqlstr = "UPDATE items SET activo = '0' WHERE id_item = '" & it.id_item.ToString & "'"
        Else
            If it.id_rosca = 0 Then
                sqlstr = "SET DATEFORMAT dmy; UPDATE items SET item = '" & it.item & "', descript = '" & it.descript & "', cantidad = '" & it.cantidad.ToString & "', costo = '" & it.costo.ToString & "', precio_lista = '" & it.precio_lista.ToString & "', id_tipo = '" & it.id_tipo.ToString & "', id_marca = '" & it.id_marca.ToString & "', id_proveedor = '" & it.id_proveedor.ToString & "', wega = '" & it.wega & "', fram = '" & it.fram & "', mann = '" & it.mann & "', markup = '" & it.markup.ToString & "', descuento = '" & it.descuento.ToString & "', id_iva = '" & it.id_iva.ToString & "', activo = '" & it.activo.ToString & "', ean = '" & it.EAN & "', checkStock = '" & it.checkStock.ToString & "', stockRepo = '" & it.stockRepo.ToString & "', oferta = '" & it.oferta.ToString & "', oem = '" & it.oem & "', ultima_modificacion = '" & it.ultima_modificacion.ToString & "' WHERE id_item = '" & it.id_item.ToString & "'"
            Else
                sqlstr = "SET DATEFORMAT dmy; UPDATE items SET item = '" & it.item & "', descript = '" & it.descript & "', cantidad = '" & it.cantidad.ToString & "', costo = '" & it.costo.ToString & "', precio_lista = '" & it.precio_lista.ToString & "', id_tipo = '" & it.id_tipo.ToString & "', id_marca = '" & it.id_marca.ToString & "', id_proveedor =  '" & it.id_proveedor.ToString & "', wega = '" & it.wega & "', fram = '" & it.fram & "', mann = '" & it.mann & "', id_rosca = '" & it.id_rosca.ToString & "', markup = '" & it.markup.ToString & "', descuento ='" & it.descuento.ToString & "', id_iva = '" & it.id_iva.ToString & "', activo = '" & it.activo.ToString & "', ean = '" & it.EAN & "', checkStock = '" & it.checkStock.ToString & "', stockRepo = '" & it.stockRepo.ToString & "', oferta = '" & it.oferta.ToString & "', oem = '" & it.oem & "', ultima_modificacion = '" & it.ultima_modificacion.ToString & "' WHERE id_item = '" & it.id_item.ToString & "'"
            End If
        End If
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function borraritem(it As item) As Boolean
        Dim sqlstr As String = "DELETE FROM items WHERE id_item = '" & it.id_item.ToString & "'"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function existeitem(ByVal i As String) As Integer
        Dim tmp As New item

        Dim sqlstr As String
        sqlstr = "SELECT id_item FROM items WHERE item LIKE '%" + i.ToString + "%'"

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")
            tmp.id_item = dataset.Tables("tabla").Rows(0).Item(0).ToString
            If tmp.id_item = 0 Then Return -1
            cerrardb()
            Return tmp.id_item
        Catch ex As Exception
            tmp.item = "error"
            cerrardb()
            Return -1
        End Try
    End Function

    Public Function existeitemEAN(ByVal e As String) As Integer
        Dim tmp As New item

        Dim sqlstr As String
        sqlstr = "SELECT id_item FROM items WHERE EAN = '" + e + "'"

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")
            tmp.id_item = dataset.Tables("tabla").Rows(0).Item(0).ToString
            If tmp.id_item = 0 Then Return -1
            cerrardb()
            Return tmp.id_item
        Catch ex As Exception
            tmp.item = "error"
            cerrardb()
            Return -1
        End Try
    End Function

    Public Function actualizarPrecios(ByVal dgv As DataGridView, ByVal actualizaCosto As Boolean, actualizaMarkup As Boolean, actualizaDescuento As Boolean,
                                         ByVal actualizaPrecioLista As Boolean) As Boolean

        If Not actualizaCosto And Not actualizaMarkup And Not actualizaDescuento And Not actualizaPrecioLista Then Return False

        Dim sqlstr As String

        sqlstr = "SET DATEFORMAT dmy; UPDATE items SET ultima_modificacion = '" + Hoy_SoloFecha() + "', "

        If actualizaCosto Then
            sqlstr += " costo = @costo,"
        End If

        If actualizaMarkup Then
            sqlstr += " markup = @markup,"
        End If

        If actualizaDescuento Then
            sqlstr += " descuento = @descuento,"
        End If

        If actualizaPrecioLista Then
            sqlstr += " precio_lista = @precio_lista,"
        End If

        sqlstr = sqlstr.Substring(0, sqlstr.Length - 1)

        sqlstr += " WHERE item = @item"

        'Crea y abre una nueva conexión
        abrirdb(serversql, basedb, usuariodb, passdb)
        Dim comando As New SqlCommand(sqlstr, CN)

        Try
            For Each row As DataGridViewRow In dgv.Rows
                comando.Parameters.Clear()

                comando.Parameters.AddWithValue("@item", Convert.ToString(row.Cells("item").Value))
                If actualizaCosto Then comando.Parameters.AddWithValue("@costo", Convert.ToString(row.Cells("costo").Value))
                If actualizaMarkup Then comando.Parameters.AddWithValue("@markup", Convert.ToString(row.Cells("markup").Value))
                If actualizaDescuento Then comando.Parameters.AddWithValue("@descuento", Convert.ToString(row.Cells("descuento").Value))
                If actualizaPrecioLista Then comando.Parameters.AddWithValue("@precio_lista", Convert.ToString(row.Cells("precio_lista").Value))

                comando.ExecuteNonQuery()
            Next
            Return True
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return False
        Finally
            cerrardb()
        End Try
    End Function

    'Public Sub pintaStockItems(ByVal lsview As ListView, ByVal clrAdvertencia As Color, ByVal clrMinimo As Color)
    Public Sub pintaStockItems(ByVal lsview As ListView, ByVal clrMinimo As Color)
        Dim i As Integer
        Dim x As Integer = 0
        Dim stock As Integer
        Dim stockRepo As Integer
        Dim colCheckStock As Boolean

        For i = 0 To lsview.Items.Count - 1
            stock = lsview.Items(i).SubItems(4).Text.ToString
            stockRepo = lsview.Items(i).SubItems(19).Text.ToString
            If LCase(lsview.Items(i).SubItems(18).Text.ToString) = "si" Then
                colCheckStock = True
            Else
                colCheckStock = False
            End If
            If colCheckStock Then
                If stock <= stockRepo Then
                    'If stock > 0 And stock <= stockRepo Then
                    lsview.Items(i).SubItems(0).BackColor = clrMinimo
                    lsview.Items(i).SubItems(0).Font = New Font(lsview.Items(i).SubItems(4).Font, FontStyle.Bold)
                    'ElseIf stock > stockRepo And stock <= stockRepo * 2 Then
                    '   lsview.Items(i).SubItems(0).BackColor = clrAdvertencia
                    '  lsview.Items(i).SubItems(0).Font = New Font(lsview.Items(i).SubItems(4).Font, FontStyle.Bold)
                End If
            End If
        Next
        lsview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        lsview.Refresh()
    End Sub

    Public Sub pintaStockItemsDG(ByVal dg As DataGridView, ByVal clrMinimo As Color)
        For Each row As DataGridViewRow In dg.Rows
            If row.Cells.Count > 19 Then
                Dim stock As Integer = CInt(row.Cells(4).Value)
                Dim stockRepo As Integer = CInt(row.Cells(19).Value)
                Dim controlaStock As Boolean = LCase(row.Cells(18).Value.ToString) = "si"
                If controlaStock AndAlso stock <= stockRepo Then
                    row.Cells(0).Style.BackColor = clrMinimo
                    row.Cells(0).Style.Font = New Font(dg.Font, FontStyle.Bold)
                End If
            End If
        Next
    End Sub

    Public Function infoItem_lastItem() As item
        Dim tmp As New item
        Dim i As New item
        Dim sqlstr As String = "SELECT TOP 1 * FROM items ORDER BY id_item DESC"
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")
            tmp.id_item = dataset.Tables("tabla").Rows(0).Item(0).ToString
            cerrardb()

            i = info_item(tmp.id_item)
            Return i
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.descript = "error"
            cerrardb()
            Return tmp
        End Try
    End Function


    Public Sub borraritemcargado(Optional ByVal id_item As Integer = 0, Optional ByVal tabla As String = "", Optional ByVal id_poc As Integer = 0)
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String = ""


        mytrans = CN.BeginTransaction()

        Try
            If id_item = 0 Then
                sqlstr = "DELETE FROM " + tabla + " WHERE activo = '0'"
            Else
                If tabla = "pedidos_detalle" Then
                    'sqlstr = "DELETE pedidos_detalle WHERE id_item = '" + id_item.ToString + "' AND id_pedido = '" + id_poc.ToString + "'"
                    sqlstr = "UPDATE pedidos_detalle SET activo = '0' WHERE id_item = '" + id_item.ToString + "' AND id_pedido = '" + id_poc.ToString + "'"
                ElseIf tabla = "presupuestos_detalle" Then
                    sqlstr = "UPDATE presupuestos_detalle SET activo = '0' WHERE id_item = '" + id_item.ToString + "' AND id_presupuesto = '" + id_poc.ToString + "'"
                ElseIf tabla = "tmppedidos_items" Then
                    'sqlstr = "DELETE tmppedidos_items WHERE id_item = '" + id_item.ToString + "'"
                    sqlstr = "UPDATE tmppedidos_items SET activo = '0' WHERE id_item = '" + id_item.ToString + "'"
                ElseIf tabla = "tmppresupuestos_items" Then
                    sqlstr = "UPDATE tmppresupuestos_items SET activo = '0' WHERE id_item = '" + id_item.ToString + "'"
                End If
            End If

            Comando = New SqlCommand(sqlstr, CN)
            Comando.Transaction = mytrans
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            cerrardb()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
        End Try
    End Sub

    Public Sub Borrar_Item_Temporal_Cargado(ByVal _idItem As Integer, ByVal _idUsuario As Integer, ByVal _idUnico As String, Optional ByVal _idPedido As Integer = 0)
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String = ""


        mytrans = CN.BeginTransaction()

        Try

            If _idPedido <> 0 Then
                sqlstr = "UPDATE pedidos_detalle SET activo = '0' WHERE id_item = '" + _idItem.ToString + "' AND id_pedido = '" + _idPedido.ToString + "'"
            Else
                sqlstr = "UPDATE tmppedidos_items SET activo = '0' WHERE id_item = '" + _idItem.ToString + "' AND id_usuario = '" +
                _idUsuario.ToString + "' AND id_unico = '" + _idUnico + "'"
            End If


            Comando = New SqlCommand(sqlstr, CN)
            Comando.Transaction = mytrans
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            cerrardb()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
        End Try
    End Sub

    Public Sub Activar_Item_Temporal_Cargado(ByVal _idItem As Integer, ByVal _idUsuario As Integer, ByVal _idUnico As String, Optional ByVal _idPedido As Integer = 0)
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String = ""


        mytrans = CN.BeginTransaction()

        Try

            If _idPedido <> 0 Then
                sqlstr = "UPDATE pedidos_detalle SET cantidad = CASE activo WHEN 0 THEN 0 ELSE cantidad END, activo = 1 WHERE id_item = '" + _idItem.ToString + "' AND id_pedido = '" + _idPedido.ToString + "'"
            Else
                sqlstr = "UPDATE tmppedidos_items SET cantidad = CASE activo WHEN 0 THEN 0 ELSE cantidad END, activo = 1 WHERE id_item = '" + _idItem.ToString + "' AND id_usuario = '" +
                _idUsuario.ToString + "' AND id_unico = '" + _idUnico + "'"
            End If


            Comando = New SqlCommand(sqlstr, CN)
            Comando.Transaction = mytrans
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            cerrardb()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
        End Try
    End Sub

    Public Sub activaitems(ByVal tabla As String)
        Dim sqlstr As String

        sqlstr = "UPDATE " + tabla + " SET activo = '1' WHERE activo = '0'"

        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlCommand(sqlstr, CN)


            Comando.Transaction = mytrans
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            cerrardb()
        Catch ex As Exception
            MsgBox(ex.Message)
            cerrardb()
        End Try
    End Sub

    Public Sub updateitems(ByVal lsv As ListView, ByVal txt_total As TextBox, ByVal txt_subtotal As TextBox, ByVal recargo As Double,
                           ByVal descuento As Double, ByVal idUnico As String, ByVal idUsuario As Integer)
        Cargar_listview(lsv, "SELECT ci.id_item AS 'ID', i.item AS 'Item', tim.tipo AS 'Categoria', ci.cantidad AS 'Cantidad', ci.precio AS 'Precio', " &
                             "CAST(ci.cantidad * ci.precio AS DECIMAL(18,3)) AS 'Subtotal', CASE WHEN i.oferta = 0 THEN 'No' ELSE 'Si' END AS 'Oferta' " &
                            "FROM pedidos_detalle AS ci " &
                            "LEFT JOIN items AS i ON ci.id_item = i.id_item " &
                            "LEFT JOIN tipos_items AS tim ON i.id_tipo = tim.id_tipo " &
                            "WHERE ci.activo = '1' AND ci.id_item NOT IN (SELECT id_item FROM tmppedidos_items) " &
                            "AND ci.id_pedido = '" + edita_pedido.id_pedido.ToString + "' " &
                            "UNION " &
                            "SELECT ti.id_item AS 'ID', i.item AS 'Item', tim.tipo AS 'Categoría', ti.cantidad AS 'Cantidad', ti.precio AS 'Precio', " &
                            "CAST(ti.cantidad * ti.precio AS DECIMAL(18,3)) AS 'Subtotal', CASE WHEN i.oferta = 0 THEN 'No' ELSE 'Si' END AS 'Oferta'  " &
                            "FROM tmppedidos_items AS ti " &
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

        total_conDescuento = 0
        total_sinDescuento = 0

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

    Public Function info_item_ultima_mod(ByVal id_item As String) As String
        Dim ultima_mod As String
        Dim sqlstr As String = "SELECT ultima_modificacion FROM items WHERE id_item = '" + id_item + "'"
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")
            ultima_mod = dataset.Tables("tabla").Rows(0).Item(0).ToString
            If ultima_mod = "" Then ultima_mod = "error"
            cerrardb()
            Return ultima_mod
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            ultima_mod = "error"
            Return ultima_mod
        Finally
            cerrardb()
        End Try
    End Function

    Public Function update_item_fecha_Ultima_mod(ByVal id_item As String, ByVal fecha As String) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "SET DATEFORMAT dmy; UPDATE items SET ultima_modificacion = '" + fecha + "' WHERE id_item = '" + id_item.ToString + "'"

            Comando = New SqlCommand(sqlstr, CN)
            Comando.Transaction = mytrans
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            cerrardb()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            cerrardb()
        End Try
    End Function
    ' ************************************ FUNCIONES DE ITEMS ***************************
End Module
