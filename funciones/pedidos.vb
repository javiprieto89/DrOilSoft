Imports System.Data.SqlClient

Module pedidos
    ' ************************************ FUNCIONES DE PEDIDOS ***************************
    Public Function info_pedido(Optional ByVal id_pedido As String = "", Optional ByVal esCaso As Boolean = False) As pedido
        Dim tmp As New pedido
        Dim sqlstr As String
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)


            'Propiedades del SqlCommand
            Dim comando As New SqlCommand

            With comando
                .CommandType = CommandType.Text
                If id_pedido = "" Then
                    sqlstr = "SELECT TOP 1 * FROM pedidos ORDER BY id_pedido DESC"
                Else
                    sqlstr = "SELECT * FROM pedidos WHERE id_pedido = '" + id_pedido + "'"
                End If
                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")

            If esCaso Then
                tmp.id_pedido = dataset.Tables("tabla").Rows(0).Item(0).ToString
                tmp.fecha = dataset.Tables("tabla").Rows(0).Item(1).ToString
                tmp.id_auto = dataset.Tables("tabla").Rows(0).Item(3).ToString
                tmp.id_tipo = dataset.Tables("tabla").Rows(0).Item(5).ToString
                tmp.km = dataset.Tables("tabla").Rows(0).Item(6).ToString
                tmp.proximocambio = dataset.Tables("tabla").Rows(0).Item(7).ToString
                tmp.notas = dataset.Tables("tabla").Rows(0).Item(8).ToString
                tmp.id_condicion = dataset.Tables("tabla").Rows(0).Item(9).ToString
                tmp.id_descuento = dataset.Tables("tabla").Rows(0).Item(10).ToString
                tmp.id_caja = dataset.Tables("tabla").Rows(0).Item(11).ToString
                tmp.subTotal = dataset.Tables("tabla").Rows(0).Item(12).ToString
                tmp.total = dataset.Tables("tabla").Rows(0).Item(13).ToString
                tmp.activo = dataset.Tables("tabla").Rows(0).Item(14).ToString
                tmp.cerrado = dataset.Tables("tabla").Rows(0).Item(15).ToString
                tmp.montoTarjeta = dataset.Tables("tabla").Rows(0).Item(16).ToString
                tmp.fecha_cierre = dataset.Tables("tabla").Rows(0).Item(17).ToString
                tmp.id_usuario = dataset.Tables("tabla").Rows(0).Item(20).ToString
                'tmp.es_presupuesto = dataset.Tables("tabla").Rows(0).Item(21).ToString
                tmp.id_vendedor = dataset.Tables("tabla").Rows(0).Item(22).ToString
                tmp.id_mecanico = dataset.Tables("tabla").Rows(0).Item(23).ToString
                tmp.id_pedidoStatus = dataset.Tables("tabla").Rows(0).Item(24).ToString
            Else
                tmp.id_pedido = dataset.Tables("tabla").Rows(0).Item(0).ToString
                tmp.fecha = dataset.Tables("tabla").Rows(0).Item(1).ToString
                tmp.id_cliente = dataset.Tables("tabla").Rows(0).Item(2).ToString
                tmp.notas = dataset.Tables("tabla").Rows(0).Item(8).ToString
                tmp.id_condicion = dataset.Tables("tabla").Rows(0).Item(9).ToString
                tmp.id_descuento = dataset.Tables("tabla").Rows(0).Item(10).ToString
                tmp.id_caja = dataset.Tables("tabla").Rows(0).Item(11).ToString
                tmp.subTotal = dataset.Tables("tabla").Rows(0).Item(12).ToString
                tmp.total = dataset.Tables("tabla").Rows(0).Item(13).ToString
                tmp.activo = dataset.Tables("tabla").Rows(0).Item(14).ToString
                tmp.cerrado = dataset.Tables("tabla").Rows(0).Item(15).ToString
                tmp.montoTarjeta = dataset.Tables("tabla").Rows(0).Item(16).ToString
                tmp.fecha_cierre = dataset.Tables("tabla").Rows(0).Item(17).ToString
                'tmp.es_presupuesto = dataset.Tables("tabla").Rows(0).Item(21).ToString
                tmp.id_usuario = dataset.Tables("tabla").Rows(0).Item(20).ToString
                tmp.id_vendedor = dataset.Tables("tabla").Rows(0).Item(22).ToString
            End If

            'tmp.iva = dataset.Tables("tabla").Rows(0).Item(18).ToString
            'If Not Not String.IsNullOrEmpty(dataset.Tables("tabla").Rows(0).Item(19).ToString) Then tmp.id_pedidoAsociado = dataset.Tables("tabla").Rows(0).Item(19).ToString

            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            'tmp.nombre = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function Info_Ultimo_Pedido_Por_Usuario(ByVal _idUsuario As Integer, ByVal _esCaso As Boolean) As pedido
        Dim tmp As New pedido
        Dim sqlstr As String
        Dim n As Integer = 0

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)


            'Propiedades del SqlCommand
            Dim comando As New SqlCommand

            With comando
                .CommandType = CommandType.Text
                If _esCaso Then n = 1
                sqlstr = "SELECT TOP 1 * FROM pedidos WHERE id_usuario = '" + _idUsuario.ToString + "' AND es_caso = '" + n.ToString + "' ORDER BY id_pedido DESC"

                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")

            If _esCaso Then
                tmp.id_pedido = dataset.Tables("tabla").Rows(0).Item(0).ToString
                tmp.fecha = dataset.Tables("tabla").Rows(0).Item(1).ToString
                tmp.id_auto = dataset.Tables("tabla").Rows(0).Item(3).ToString
                tmp.id_tipo = dataset.Tables("tabla").Rows(0).Item(5).ToString
                tmp.km = dataset.Tables("tabla").Rows(0).Item(6).ToString
                tmp.proximocambio = dataset.Tables("tabla").Rows(0).Item(7).ToString
                tmp.notas = dataset.Tables("tabla").Rows(0).Item(8).ToString
                tmp.id_condicion = dataset.Tables("tabla").Rows(0).Item(9).ToString
                tmp.id_descuento = dataset.Tables("tabla").Rows(0).Item(10).ToString
                tmp.id_caja = dataset.Tables("tabla").Rows(0).Item(11).ToString
                tmp.subTotal = dataset.Tables("tabla").Rows(0).Item(12).ToString
                tmp.total = dataset.Tables("tabla").Rows(0).Item(13).ToString
                tmp.activo = dataset.Tables("tabla").Rows(0).Item(14).ToString
                tmp.cerrado = dataset.Tables("tabla").Rows(0).Item(15).ToString
                tmp.montoTarjeta = dataset.Tables("tabla").Rows(0).Item(16).ToString
                tmp.fecha_cierre = dataset.Tables("tabla").Rows(0).Item(17).ToString
                tmp.id_usuario = dataset.Tables("tabla").Rows(0).Item(20).ToString
                'tmp.es_presupuesto = dataset.Tables("tabla").Rows(0).Item(21).ToString
                tmp.id_vendedor = dataset.Tables("tabla").Rows(0).Item(22).ToString
                tmp.id_mecanico = dataset.Tables("tabla").Rows(0).Item(23).ToString
                tmp.id_pedidoStatus = dataset.Tables("tabla").Rows(0).Item(24).ToString
            Else
                tmp.id_pedido = dataset.Tables("tabla").Rows(0).Item(0).ToString
                tmp.fecha = dataset.Tables("tabla").Rows(0).Item(1).ToString
                tmp.id_cliente = dataset.Tables("tabla").Rows(0).Item(2).ToString
                tmp.notas = dataset.Tables("tabla").Rows(0).Item(8).ToString
                tmp.id_condicion = dataset.Tables("tabla").Rows(0).Item(9).ToString
                tmp.id_descuento = dataset.Tables("tabla").Rows(0).Item(10).ToString
                tmp.id_caja = dataset.Tables("tabla").Rows(0).Item(11).ToString
                tmp.subTotal = dataset.Tables("tabla").Rows(0).Item(12).ToString
                tmp.total = dataset.Tables("tabla").Rows(0).Item(13).ToString
                tmp.activo = dataset.Tables("tabla").Rows(0).Item(14).ToString
                tmp.cerrado = dataset.Tables("tabla").Rows(0).Item(15).ToString
                tmp.montoTarjeta = dataset.Tables("tabla").Rows(0).Item(16).ToString
                tmp.fecha_cierre = dataset.Tables("tabla").Rows(0).Item(17).ToString
                tmp.id_usuario = dataset.Tables("tabla").Rows(0).Item(20).ToString
                'tmp.es_presupuesto = dataset.Tables("tabla").Rows(0).Item(21).ToString
                tmp.id_vendedor = dataset.Tables("tabla").Rows(0).Item(22).ToString
            End If

            'tmp.iva = dataset.Tables("tabla").Rows(0).Item(18).ToString
            'If Not Not String.IsNullOrEmpty(dataset.Tables("tabla").Rows(0).Item(19).ToString) Then tmp.id_pedidoAsociado = dataset.Tables("tabla").Rows(0).Item(19).ToString

            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            'tmp.nombre = "error"
            cerrardb()
            Return tmp
        End Try
    End Function


    Public Function addpedido(p As pedido) As Boolean
        Dim sqlstr As String
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            If p.esCaso Then
                sqlstr = "SET DATEFORMAT dmy; INSERT INTO pedidos (fecha, id_tipo, km, proximocambio, notas, id_condicion, id_descuento, id_caja, " _
                            + "id_cliente, id_auto, es_caso, subtotal, total, activo, montoTarjeta, id_usuario, id_vendedor, id_mecanico, id_PedidoStatus) VALUES ('" + p.fecha.ToString + "', '" + p.id_tipo.ToString + "', '" _
                            + p.km.ToString + "', '" + p.proximocambio.ToString + "', '" + p.notas + "', '" + p.id_condicion.ToString + "', '" + p.id_descuento.ToString + "', '" _
                            + p.id_caja.ToString + "', '" + p.id_cliente.ToString + "', '" + p.id_auto.ToString + "', '" + p.esCaso.ToString + "', '" _
                            + p.subTotal.ToString + "', '" + p.total.ToString + "', '" + p.activo.ToString + "', '" + p.montoTarjeta.ToString + "', '" _
                            + p.id_usuario.ToString + "', '" + p.id_vendedor.ToString + "', '" + p.id_mecanico.ToString + "', '" + p.id_pedidoStatus.ToString + "')"
            Else
                sqlstr = "SET DATEFORMAT dmy; INSERT INTO pedidos (fecha, id_cliente, notas, id_condicion, id_descuento, id_caja, " _
                            + "subtotal, total, activo, montoTarjeta, id_usuario, id_vendedor) VALUES ('" + p.fecha.ToString + "', '" + p.id_cliente.ToString + "', '" _
                            + p.notas + "', '" + p.id_condicion.ToString + "', '" + p.id_descuento.ToString + "', '" + p.id_caja.ToString + "', '" +
                            p.subTotal.ToString + "', '" + p.total.ToString + "', '" + p.activo.ToString + "', '" + p.montoTarjeta.ToString + "', '" _
                            + p.id_usuario.ToString + "', '" + p.id_vendedor.ToString + "')"
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

    Public Function updatepedido(p As pedido, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim sqlstr As String = ""
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                sqlstr = "UPDATE pedidos SET activo = '0' WHERE id_pedido = '" + p.id_pedido.ToString + "'"
            Else
                If p.esCaso Then
                    sqlstr = "SET DATEFORMAT dmy; UPDATE pedidos SET fecha = '" + p.fecha.ToString + "', id_cliente = '" + p.id_cliente.ToString + "', " _
                        + "id_auto = '" + p.id_auto.ToString + "', id_tipo = '" + p.id_tipo.ToString + "', km = '" + p.km.ToString + "', proximocambio = '" _
                        + p.proximocambio.ToString + "', notas = '" + p.notas + "',  id_condicion = '" + p.id_condicion.ToString + "', id_descuento = '" + p.id_descuento.ToString +
                        "', id_caja = '" + p.id_caja.ToString + "', subtotal = '" + p.subTotal.ToString + "', total = '" + p.total.ToString + "', activo = '" + p.activo.ToString +
                        "', es_caso = '" + p.esCaso.ToString + "', montoTarjeta = '" + p.montoTarjeta.ToString + "', id_usuario = '" + p.id_usuario.ToString + "', id_vendedor = '" + p.id_vendedor.ToString +
                        "', id_mecanico = '" + p.id_mecanico.ToString + "', id_pedidoStatus = '" + p.id_pedidoStatus.ToString + "' WHERE id_pedido = '" + p.id_pedido.ToString + "'"
                Else
                    sqlstr = "SET DATEFORMAT dmy; UPDATE pedidos SET fecha = '" + p.fecha + "', id_cliente = '" + p.id_cliente.ToString + "', " _
                        + "notas = '" + p.notas + "', id_condicion = '" + p.id_condicion.ToString + "', id_descuento = '" _
                        + p.id_descuento.ToString + "', id_caja = '" + p.id_caja.ToString + "', subtotal = '" + p.subTotal.ToString + "', total = '" + p.total.ToString + "', activo = '" + p.activo.ToString +
                        "', montoTarjeta = '" + p.montoTarjeta.ToString + "', id_usuario = '" + p.id_usuario.ToString + "', id_vendedor = '" + p.id_vendedor.ToString + "' WHERE id_pedido = '" + p.id_pedido.ToString + "'"
                End If

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

    Public Function cierreDiario(ByVal fecha_desde As Date, ByVal fecha_hasta As Date,
                                      ByVal consulta_pedidos As Boolean, ByVal consulta_casos As Boolean) As Boolean

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String = ""
        Dim where As String = ""

        If consulta_pedidos And Not consulta_casos Then
            where = " AND es_caso = '0'"
        ElseIf Not consulta_pedidos And consulta_casos Then
            where = " AND es_caso = '1'"
        End If

        abrirdb(serversql, basedb, usuariodb, passdb)


        mytrans = CN.BeginTransaction()

        Try
            'sqlstr = "UPDATE p SET p.activo = '0', p.cerrado = '1', p.fecha_cierre = '" & Format(DateTime.Now, "MM/dd/yyyy") & "' " &
            sqlstr = "SET DATEFORMAT dmy; UPDATE p SET p.activo = '0', p.cerrado = '1', p.fecha_cierre = '" & Format(DateTime.Now, "dd/MM/yyyy") & "' " &
                        "FROM pedidos AS p " &
                        "INNER JOIN cajas AS c ON p.id_caja = c.id_caja " &
                        "WHERE c.esCC = '0' AND p.fecha BETWEEN '" + fecha_desde.ToString("yyyy/MM/dd") + "' AND '" + fecha_hasta.ToString("yyyy/MM/dd") + "' AND p.activo = 1"

            sqlstr += where

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

    Public Function borrarpedido(p As pedido) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim sqlstr As String
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE FROM registro_stockPedidos WHERE id_pedido = '" + p.id_pedido.ToString + "'; DELETE FROM pedidos_detalle WHERE id_pedido = '" + p.id_pedido.ToString + "'; DELETE FROM pedidos WHERE id_pedido = '" + p.id_pedido.ToString + "'"
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

    Public Function additempedidotmp(ByVal id_item As Integer, ByVal cantidad As Double, ByVal precio As Double,
                                   ByVal _idUsuario As Integer, ByVal _idUnico As String) As Boolean


        Dim itemtmpexiste As Boolean
        Dim sqlstr As String
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        itemtmpexiste = info_itemtmp(id_item, _idUsuario, _idUnico)

        abrirdb(serversql, basedb, usuariodb, passdb)

        mytrans = CN.BeginTransaction()

        Try

            If itemtmpexiste Then
                sqlstr = "UPDATE tmppedidos_items SET cantidad = '" + cantidad.ToString + "', precio = '" + precio.ToString _
                    + "' WHERE id_item = '" + id_item.ToString + "' AND id_usuario = '" + _idUsuario.ToString + "' AND id_unico = '" + _idUnico + "'"

            Else
                sqlstr = "INSERT INTO tmppedidos_items (id_item, cantidad, precio, id_usuario, id_unico) VALUES ('" + id_item.ToString + "', '" + cantidad.ToString _
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

    Public Function additempedido(ByVal _idUsuario As Integer, ByVal _idUnico As String, ByVal id_pedido As Integer,
                                   ByVal _esCaso As Boolean) As Boolean
        'Obtengo el último pedido que se generó
        Dim sqlstr As String

        'If id_pedido = 0 Or id_pedido = -1 Then
        '    'id_pedido = info_pedido(, esCaso).id_pedido
        '    id_pedido = Info_Ultimo_Pedido_Por_Usuario(_idUsuario, _esCaso).id_pedido
        'End If

        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "UPDATE pedidos_detalle " &
                        "SET cantidad = src.cantidad, precio = src.precio " &
                        "FROM pedidos_detalle dst " &
                        "JOIN tmppedidos_items src " &
                        "ON src.id_item = dst.id_item " &
                        "WHERE dst.id_pedido = '" + id_pedido.ToString + "' " &
                        "AND src.activo = '1' AND src.id_usuario = '" + _idUsuario.ToString + "' AND src.id_unico = '" + _idUnico + "' " &
                        "INSERT pedidos_detalle " &
                        "(id_item, cantidad, precio, id_pedido) " &
                        "SELECT id_item" &
                        ", cantidad, precio, '" + id_pedido.ToString + "' " &
                        "FROM tmppedidos_items src " &
                        "WHERE NOT EXISTS " &
                        "(" &
                        "SELECT  * " &
                        "FROM pedidos_detalle dst " &
                        "WHERE src.id_item = dst.id_item " &
                        "AND dst.id_pedido = '" + id_pedido.ToString + "'" &
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

    Public Function borrartbl(ByVal tbl As String) As Byte
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlCommand("TRUNCATE TABLE " + tbl, CN)

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

    Public Function borrar_tabla_pedidos_temporales(ByVal idUsuario As Integer, ByVal idUnico As String) As Byte
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE tmppedidos_items WHERE id_usuario = '" + idUsuario.ToString + "' AND id_unico = '" + idUnico + "'"
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

    Public Function borrar_tabla_pedidos_temporales(ByVal idUsuario As String) As Byte
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE tmppedidos_items WHERE id_usuario = '" + idUsuario + "'"
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

    Public Function info_itempedido(ByVal id_item As String, Optional ByVal esCaso As Boolean = False) As item_pedido
        Dim tmp As New item_pedido
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = "SELECT * FROM pedidos_detalle WHERE id_item = '" + id_item + "'"
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")
            tmp.id_pedido = dataset.Tables("tabla").Rows(0).Item(0).ToString
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

    Public Function cerrarpedido(ByVal p As pedido) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            'sqlstr = "UPDATE pedidos SET cerrado = '1', activo = '0', fecha_cierre = '" & Format(DateTime.Now, "MM/dd/yyyy") & "' " &
            sqlstr = "SET DATEFORMAT dmy; UPDATE pedidos SET cerrado = '1', activo = '0', fecha_cierre = '" & Format(DateTime.Now, "dd/MM/yyyy") & "' " &
                "WHERE id_pedido = '" + p.id_pedido.ToString + "'"
            Comando = New SqlCommand(sqlstr, CN)

            Comando.Transaction = mytrans
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            cerrardb()

            If showrpt Then
                id = p.id_pedido
                'frm_rptFC.ShowDialog()
                id = 0
            End If

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            cerrardb()
            Return False
        End Try
    End Function

    Public Sub resaltarPedidosInactivos(ByVal lsview As ListView, ByVal clr As Color)
        Dim i As Integer
        Dim x As Integer = 0
        For i = 0 To lsview.Items.Count - 1
            If lsview.Items(i).SubItems(9).Text.ToString = "False" Then 'Activo = False = Columna 8 = pintar
                lsview.Items(i).SubItems(0).BackColor = clr
                lsview.Items(i).SubItems(0).Font = New Font(lsview.Items(i).SubItems(4).Font, FontStyle.Bold)
            End If
        Next
        lsview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        lsview.Refresh()
    End Sub

    Public Sub resaltarCasosInactivos(ByVal lsview As ListView, ByVal clr As Color)
        Dim i As Integer
        Dim x As Integer = 0
        For i = 0 To lsview.Items.Count - 1
            If lsview.Items(i).SubItems(13).Text.ToString = "False" Then 'Activo = False = Columna 8 = pintar
                lsview.Items(i).SubItems(0).BackColor = clr
                lsview.Items(i).SubItems(0).Font = New Font(lsview.Items(i).SubItems(4).Font, FontStyle.Bold)
            End If
        Next
        lsview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        lsview.Refresh()
    End Sub

    Public Function idremitoAsociado(ByVal id_pedido As String) As Integer
        Dim sqlstr As String
        Dim idRM As Integer

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)


            'Propiedades del SqlCommand
            Dim comando As New SqlCommand

            With comando
                .CommandType = CommandType.Text
                sqlstr = "SELECT pp.id_pedido " &
                                "FROM pedidos AS p " &
                                "INNER JOIN pedidos AS pp ON p.id_pedido = pp.id_pedidoAsociado " &
                                "WHERE p.id_pedido = '" + id_pedido + "'"
                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")

            idRM = dataset.Tables("tabla").Rows(0).Item(0).ToString
            cerrardb()
            Return idRM
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            'tmp.nombre = "error"
            cerrardb()
            Return -1
        End Try
    End Function

    Public Function emiteFE(ByVal f As FE) As Boolean
        'Obtengo el último pedido que se generó
        Dim sqlstr As String

        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "SET DATEFORMAT dmy; INSERT INTO fe (id_pedido, id_comprobante, cae, fechavencimiento_cae, puntoVenta, numeroComprobante, codigoDeBarras, fecha_emision, subtotal, impuestos, total) " &
                       "VALUES('" & f.id_pedido & "', '" & f.id_comprobante.ToString & "', '" & f.cae & "', '" & f.fechavencimiento_cae & "', '" & f.puntoVenta.ToString & "', " &
                       "'" & f.numeroComprobante.ToString & "', '" & f.codigoDeBarras & "', '" & f.fecha_emision & "', '" & f.subtotal.ToString & "', '" & f.impuestos.ToString + "', '" & f.total.ToString & "')"
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

    Public Function info_preFe(ByVal id_pedido As Integer) As FE
        Dim tmp As New FE
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)


            'Propiedades del SqlCommand
            Dim comando As New SqlCommand

            With comando
                .CommandType = CommandType.Text
                .CommandText = "SELECT * FROM pedidos WHERE id_pedido = '" + id_pedido.ToString + "'"
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")

            tmp.id_pedido = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.fecha = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.total = dataset.Tables("tabla").Rows(0).Item(13).ToString

            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            'tmp.nombre = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function info_fe(ByVal id_pedido As Integer) As FE
        Dim tmp As New FE
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)


            'Propiedades del SqlCommand
            Dim comando As New SqlCommand

            With comando
                .CommandType = CommandType.Text
                .CommandText = "SELECT * FROM fe WHERE id_pedido = '" + id_pedido.ToString + "'"
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")


            tmp.id_fe = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.id_pedido = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.id_comprobante = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.cae = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.fechavencimiento_cae = dataset.Tables("tabla").Rows(0).Item(4).ToString
            tmp.puntoVenta = dataset.Tables("tabla").Rows(0).Item(5).ToString
            tmp.numeroComprobante = dataset.Tables("tabla").Rows(0).Item(6).ToString
            tmp.codigoDeBarras = dataset.Tables("tabla").Rows(0).Item(7).ToString
            tmp.fecha_emision = dataset.Tables("tabla").Rows(0).Item(8).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            'tmp.nombre = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function Existe_Factura(ByVal id_pedido As Integer) As Boolean
        Dim sqlstr As String
        sqlstr = "SELECT id_fe FROM FE WHERE id_pedido = '" + id_pedido.ToString + "'"

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
            If dataset.Tables("tabla").Rows(0).Item(0).ToString = "" Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        Finally
            cerrardb()
        End Try
    End Function

    ' ************************************ FUNCIONES DE PEDIDOS ***************************
End Module
