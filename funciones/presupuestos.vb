Imports System.Data.SqlClient

Module presupuestos
    '' ************************************ FUNCIONES DE PRESUPUESTOS ***************************
    Public Function info_presupuesto(Optional ByVal id_presupuesto As String = "") As presupuesto
        Dim tmp As New presupuesto
        Dim sqlstr As String
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)


            'Propiedades del SqlCommand
            Dim comando As New SqlCommand

            With comando
                .CommandType = CommandType.Text
                If id_presupuesto = "" Then
                    sqlstr = "SELECT TOP 1 * FROM presupuestos ORDER BY id_presupuesto DESC"
                Else
                    sqlstr = "SELECT * FROM presupuestos WHERE id_presupuesto = '" + id_presupuesto + "'"
                End If
                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")

            tmp.id_presupuesto = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.fecha = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.id_cliente = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.notas = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.id_condicion = dataset.Tables("tabla").Rows(0).Item(4).ToString
            tmp.id_descuento = dataset.Tables("tabla").Rows(0).Item(5).ToString
            tmp.subTotal = dataset.Tables("tabla").Rows(0).Item(6).ToString
            tmp.total = dataset.Tables("tabla").Rows(0).Item(7).ToString
            tmp.montoTarjeta = dataset.Tables("tabla").Rows(0).Item(8).ToString
            'tmp.iva = dataset.Tables("tabla").Rows(0).Item(9).ToString
            tmp.id_usuario = dataset.Tables("tabla").Rows(0).Item(10).ToString

            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            'tmp.nombre = "error"
            cerrardb()
            Return tmp
        End Try
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
        Dim sqlstr As String
        Dim n As Integer = 0

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)


            'Propiedades del SqlCommand
            Dim comando As New SqlCommand

            With comando
                .CommandType = CommandType.Text
                sqlstr = "SELECT TOP 1 * FROM presupuestos WHERE id_usuario = '" + _idUsuario.ToString + "' ORDER BY id_presupuesto DESC"

                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")


            tmp.id_presupuesto = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.fecha = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.id_cliente = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.notas = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.id_condicion = dataset.Tables("tabla").Rows(0).Item(4).ToString
            tmp.id_descuento = dataset.Tables("tabla").Rows(0).Item(5).ToString
            tmp.subTotal = dataset.Tables("tabla").Rows(0).Item(6).ToString
            tmp.total = dataset.Tables("tabla").Rows(0).Item(7).ToString
            tmp.montoTarjeta = dataset.Tables("tabla").Rows(0).Item(8).ToString
            'tmp.iva = dataset.Tables("tabla").Rows(0).Item(9).ToString
            tmp.id_usuario = dataset.Tables("tabla").Rows(0).Item(10).ToString

            'tmp.iva = dataset.Tables("tabla").Rows(0).Item(18).ToString
            'If Not Not String.IsNullOrEmpty(dataset.Tables("tabla").Rows(0).Item(19).ToString) Then tmp.id_presupuestoAsociado = dataset.Tables("tabla").Rows(0).Item(19).ToString

            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            'tmp.nombre = "error"
            cerrardb()
            Return tmp
        End Try
    End Function


    Public Function addpresupuesto(p As presupuesto) As Boolean
        Dim sqlstr As String
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try

            sqlstr = "SET DATEFORMAT dmy; INSERT INTO presupuestos (fecha, id_cliente, notas, id_condicion, id_descuento, " _
                           + "subtotal, total, montoTarjeta, id_usuario) VALUES ('" + p.fecha.ToString + "', '" + p.id_cliente.ToString + "', '" _
                           + p.notas + "', '" + p.id_condicion.ToString + "', '" + p.id_descuento.ToString + "', '" +
                           p.subTotal.ToString + "', '" + p.total.ToString + "', '" + p.montoTarjeta.ToString + "', '" _
                           + p.id_usuario.ToString + "')"

            Comando = New SqlCommand(sqlstr, CN)

            Comando.Transaction = mytrans
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            cerrardb()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            cerrardb()
            Return False
        End Try
    End Function

    Public Function updatepresupuesto(p As presupuesto, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim sqlstr As String = ""
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                sqlstr = "UPDATE presupuestos SET activo = '0' WHERE id_presupuesto = '" + p.id_presupuesto.ToString + "'"
            Else

                sqlstr = "SET DATEFORMAT dmy; UPDATE presupuestos SET fecha = '" + p.fecha + "', id_cliente = '" + p.id_cliente.ToString + "', " _
                        + "notas = '" + p.notas + "', id_condicion = '" + p.id_condicion.ToString + "', id_descuento = '" _
                        + p.id_descuento.ToString + "', subtotal = '" + p.subTotal.ToString + "', total = '" + p.total.ToString + "' " +
                        "', montoTarjeta = '" + p.montoTarjeta.ToString + "', id_usuario = '" + p.id_usuario.ToString + "' " +
                        "WHERE id_presupuesto = '" + p.id_presupuesto.ToString + "'"
            End If

            Comando = New SqlCommand(sqlstr, CN)
            Comando.Transaction = mytrans
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            cerrardb()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            cerrardb()
            Return False
        End Try
    End Function

    Public Function borrarpresupuesto(p As presupuesto) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim sqlstr As String
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE FROM presupuestos_detalle WHERE id_presupuesto = '" + p.id_presupuesto.ToString + "'; DELETE FROM presupuestos WHERE id_presupuesto = '" + p.id_presupuesto.ToString + "'"
            Comando = New SqlCommand(sqlstr, CN)
            Comando.Transaction = mytrans
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            cerrardb()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
            Return False
        End Try
    End Function

    Public Function additempresupuestotmp(ByVal id_item As Integer, ByVal cantidad As Double, ByVal precio As Double,
                                   ByVal _idUsuario As Integer, ByVal _idUnico As String) As Boolean


        Dim itemtmpexiste As Boolean
        Dim sqlstr As String
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        itemtmpexiste = info_itemtmp_presupuesto(id_item, _idUsuario, _idUnico)

        abrirdb(serversql, basedb, usuariodb, passdb)

        mytrans = CN.BeginTransaction()

        Try

            If itemtmpexiste Then
                sqlstr = "UPDATE tmppresupuestos_items SET cantidad = '" + cantidad.ToString + "', precio = '" + precio.ToString _
                    + "' WHERE id_item = '" + id_item.ToString + "' AND id_usuario = '" + _idUsuario.ToString + "' AND id_unico = '" + _idUnico + "'"

            Else
                sqlstr = "INSERT INTO tmppresupuestos_items (id_item, cantidad, precio, id_usuario, id_unico) VALUES ('" + id_item.ToString + "', '" + cantidad.ToString _
                    + "', '" + precio.ToString + "', '" + _idUsuario.ToString + "', '" + _idUnico + "')"
            End If

            Comando = New SqlCommand(sqlstr, CN)

            Comando.Transaction = mytrans
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            cerrardb()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            cerrardb()
            Return False
        End Try
    End Function

    Public Function additempresupuesto(ByVal _idUsuario As Integer, ByVal _idUnico As String, ByVal id_presupuesto As Integer,
                                   ByVal _esCaso As Boolean) As Boolean
        'Obtengo el último presupuesto que se generó
        Dim sqlstr As String

        'If id_presupuesto = 0 Or id_presupuesto = -1 Then
        '    'id_presupuesto = info_presupuesto(, esCaso).id_presupuesto
        '    id_presupuesto = Info_Ultimo_presupuesto_Por_Usuario(_idUsuario, _esCaso).id_presupuesto
        'End If

        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "UPDATE presupuestos_detalle " &
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
            Comando = New SqlCommand(sqlstr, CN)

            Comando.Transaction = mytrans
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            cerrardb()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            cerrardb()
            Return False
        End Try
    End Function

    Public Function borrar_tabla_presupuestos_temporales(ByVal idUsuario As Integer, ByVal idUnico As String) As Byte
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE tmppresupuestos_items WHERE id_usuario = '" + idUsuario.ToString + "' AND id_unico = '" + idUnico + "'"
            Comando = New SqlCommand(sqlstr, CN)

            Comando.Transaction = mytrans
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            cerrardb()

            Return True

        Catch ex As Exception
            MsgBox(ex.Message)
            cerrardb()
            Return False
        End Try
    End Function

    Public Function borrar_tabla_presupuestos_temporales(ByVal idUsuario As String) As Byte
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE tmppresupuestos_items WHERE id_usuario = '" + idUsuario + "'"
            Comando = New SqlCommand(sqlstr, CN)

            Comando.Transaction = mytrans
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            cerrardb()

            Return True

        Catch ex As Exception
            MsgBox(ex.Message)
            cerrardb()
            Return False
        End Try
    End Function

    Public Function info_itempresupuesto(ByVal id_item As String, Optional ByVal esCaso As Boolean = False) As item_presupuesto
        Dim tmp As New item_presupuesto
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = "SELECT * FROM presupuestos_detalle WHERE id_item = '" + id_item + "'"
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")
            tmp.id_presupuesto = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.id_item = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.cantidad = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.precio = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(4).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            'tmp.descript = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function askitemcargado_presupuesto(ByVal id_item As Integer, ByVal id As Integer, ByVal tabla As String, ByVal _idUsuario As Integer, ByVal _idUnico As String) As Double
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            Dim sql As String

            If tabla = "presupuestos_detalle" Then
                sql = "SELECT cantidad FROM presupuestos_detalle WHERE id_item = '" + id_item.ToString + "' AND id_presupuesto = '" + id.ToString + "'"
            Else
                sql = "SELECT cantidad FROM tmppresupuestos_items WHERE id_item = '" + id_item.ToString + "' AND id_usuario = '" + _idUsuario.ToString _
                        + "' AND id_unico = '" + _idUnico + "'"
            End If

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand

            With comando
                .CommandType = CommandType.Text
                .CommandText = sql
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")

            Dim cantidad As Double
            cantidad = dataset.Tables("tabla").Rows(0).Item(0).ToString
            Return cantidad
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            'tmp.nombre = "error"
            'si no hay stock devuelve -1
            Return -1
        Finally
            cerrardb()
        End Try
    End Function

    Public Function askpreciocargado_presupuesto(ByVal id_item As Integer, ByVal id As Integer, ByVal tabla As String, ByVal _idUsuario As Integer, ByVal _idUnico As String) As Double
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            Dim sql As String

            If tabla = "presupuestos_detalle" Then
                sql = "SELECT precio FROM presupuestos_detalle WHERE id_item = '" + id_item.ToString + "' AND id_presupuesto = '" + id.ToString + "'"
            Else
                sql = "SELECT precio FROM tmppresupuestos_items WHERE id_item = '" + id_item.ToString + "' AND id_usuario = '" + _idUsuario.ToString _
                    + "' AND id_unico = '" + _idUnico + "'"
            End If

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand

            With comando
                .CommandType = CommandType.Text
                .CommandText = sql
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")

            Dim precio As Double
            precio = dataset.Tables("tabla").Rows(0).Item(0).ToString
            cerrardb()
            Return precio
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            'tmp.nombre = "error"
            'si no hay stock devuelve -1
            cerrardb()
            Return -1
        End Try
    End Function

    Public Function recargaprecios_presupuesto(Optional ByVal id As Integer = 0, Optional ByVal id_item As Integer = 0, Optional ByVal tabla As String = "") As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
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


        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlCommand(sqlstr, CN)
            Comando.Transaction = mytrans
            Comando.ExecuteNonQuery()
            mytrans.Commit()
            cerrardb()
            If id <> 0 And tabla <> "" Then
                If recargaprecios(, id_item) = False Then Return False
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
            Return False
        End Try
    End Function

    Public Function info_itemtmp_presupuesto(ByVal _idItem As Integer, ByVal _idUsuario As Integer, ByVal _idUnico As String) As Boolean
        Dim sqlstr As String
        Dim tmp As New item
        Dim comando As New SqlCommand
        Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
        Dim dataset As New DataSet 'Crear nuevo dataset

        Try

            sqlstr = "SELECT * FROM tmppresupuestos_items WHERE id_item = '" + _idItem.ToString + "' AND id_usuario = '" _
                    + _idUsuario.ToString + "' AND id_unico = '" + _idUnico + "'"

            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand

            With comando
                .CommandType = CommandType.Text
                .CommandText = sqlstr
                .Connection = CN
            End With

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")
            tmp.id_item = dataset.Tables("tabla").Rows(0).Item(0).ToString
            cerrardb()
            Return True
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            'tmp.descript = "error"
            cerrardb()
            Return False
        End Try
    End Function
    '' ************************************ FUNCIONES DE PRESUPUESTOS ***************************
End Module
