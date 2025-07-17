Imports System.Data.SqlClient

Module casos
    ' ************************************ FUNCIONES DE CASOS Y PEDIDOS ***************************
    Public Function askitemcargado(ByVal id_item As Integer, ByVal id As Integer, ByVal tabla As String, ByVal _idUsuario As Integer, ByVal _idUnico As String) As Double
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            Dim sql As String

            If tabla = "pedidos_detalle" Then
                sql = "SELECT cantidad FROM pedidos_detalle WHERE id_item = '" + id_item.ToString + "' AND id_pedido = '" + id.ToString + "'"
            Else
                sql = "SELECT cantidad FROM tmppedidos_items WHERE id_item = '" + id_item.ToString + "' AND id_usuario = '" + _idUsuario.ToString _
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
            cerrardb()
            Return cantidad
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            'tmp.nombre = "error"
            'si no hay stock devuelve -1
            cerrardb()
            Return -1
        End Try
    End Function

    Public Function askpreciocargado(ByVal id_item As Integer, ByVal id As Integer, ByVal tabla As String, ByVal _idUsuario As Integer, ByVal _idUnico As String) As Double
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            Dim sql As String

            If tabla = "pedidos_detalle" Then
                sql = "SELECT precio FROM pedidos_detalle WHERE id_item = '" + id_item.ToString + "' AND id_pedido = '" + id.ToString + "'"
            Else
                sql = "SELECT precio FROM tmppedidos_items WHERE id_item = '" + id_item.ToString + "' AND id_usuario = '" + _idUsuario.ToString _
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

    Public Sub casosConDeuda(ByVal lsview As ListView, ByVal clr As Color)
        Dim i As Integer
        Dim x As Integer = 0
        Dim deudores(lsview.Items.Count) As Integer
        For i = 0 To lsview.Items.Count - 1
            'If lsview.Items(i).SubItems(14).Text.ToString = "True" Then 'Deudor = True = Columna 14 = pintar
            If lsview.Items(i).SubItems(15).Text.ToString = "Si" Then 'Deudor = True = Columna 14 = pintar
                lsview.Items(i).SubItems(0).BackColor = clr
                lsview.Items(i).SubItems(0).Font = New Font(lsview.Items(i).SubItems(4).Font, FontStyle.Bold)
            End If
        Next
        lsview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        lsview.Refresh()
    End Sub

    Public Sub casosConDeudaDG(ByVal dg As DataGridView, ByVal clr As Color)
        For Each row As DataGridViewRow In dg.Rows
            If row.Cells(15).Value.ToString() = "Si" Then
                row.Cells(0).Style.BackColor = clr
                row.Cells(0).Style.Font = New Font(dg.Font, FontStyle.Bold)
            End If
        Next
    End Sub

    Public Function duplicarCaso(ByVal id As Integer) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        Dim sqlstr As String = ""

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "SET DATEFORMAT dmy;
                        INSERT INTO pedidos (
                                                fecha
                                                , id_cliente
                                                , id_auto
                                                , es_caso 
                                                , id_tipo
                                                , km
                                                , proximocambio
                                                , notas
                                                , id_condicion
                                                , id_descuento
                                                , id_caja
                                                , subTotal
                                                , total
                                                , activo
                                                , cerrado
                                                , montoTarjeta
                                                , iva
                                                , id_usuario
                                                , es_presupuesto
                                                , id_vendedor
                                                , id_mecanico
                                                , id_pedidoStatus
                                            ) 
                        SELECT '" & Format(DateTime.Now, "dd/MM/yyyy") & "'
                                                , id_cliente
                                                , id_auto
                                                , es_caso 
                                                , id_tipo
                                                , km
                                                , proximocambio
                                                , notas
                                                , id_condicion
                                                , id_descuento
                                                , id_caja
                                                , subTotal
                                                , total
                                                , 1
                                                , 0
                                                , montoTarjeta
                                                , iva
                                                , " + usuario_logueado.id_usuario.ToString + "
                                                , es_presupuesto
                                                , id_vendedor
                                                , id_mecanico
                                                , id_pedidoStatus
                        FROM pedidos 
                        WHERE id_pedido = '" + id.ToString + "'; 
                        DECLARE @nuevo_id_pedido AS INTEGER; 
                        SET @nuevo_id_pedido = (SELECT TOP 1 id_pedido FROM pedidos WHERE id_usuario = " + usuario_logueado.id_usuario.ToString + " ORDER BY id_pedido DESC);
                        INSERT INTO pedidos_detalle (id_item, cantidad, precio, id_pedido)
                        SELECT pd.id_item, pd.cantidad, i.precio_lista, @nuevo_id_pedido
                        FROM pedidos_detalle AS pd
                        INNER JOIN items AS i ON pd.id_item = i.id_item 
                        WHERE pd.id_pedido = '" + id.ToString + "'"


            Comando = New SqlClient.SqlCommand(sqlstr, CN)
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

    Public Function caso_a_casoTmp(ByVal id_caso As Integer, ByVal _idUsuario As Integer, ByVal _idUnico As String) As Boolean
        Dim sqlstr As String
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "INSERT INTO tmppedidos_items (id_pedidoItem, id_pedido, id_item, cantidad, precio, activo, descript, id_usuario, id_unico) " _
                               + "SELECT id_pedidoItem, id_pedido, id_item, cantidad, precio, activo, descript, '" + _idUsuario.ToString + "', '" + _idUnico + "' " _
                               + "FROM pedidos_detalle " _
                               + "WHERE id_pedido = '" + id_caso.ToString + "'"
            Comando = New SqlClient.SqlCommand(sqlstr, CN)

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

    Public Sub importarItemsDePedido(ByVal id_pedido As Integer)
       
    End Sub
End Module