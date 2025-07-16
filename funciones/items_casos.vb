Imports System.Data.SqlClient

Module items_casos
    ' ************************************ FUNCIONES DE ITEMS EN CASOS Y PEDIDOS ***************************
    Public Function recargaprecios(Optional ByVal id As Integer = 0, Optional ByVal id_item As Integer = 0, Optional ByVal tabla As String = "") As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String

        If id_item = 0 Then
            If tabla = "pedidos_detalle" Then
                sqlstr = "UPDATE pedidos_detalle SET precio = " & _
                            "(SELECT precio_lista FROM items " & _
                            "WHERE pedidos_detalle.id_item = items.id_item) " & _
                            "WHERE id_pedido = '" + id.ToString + "'"
            Else
                sqlstr = "UPDATE tmppedidos_items SET precio = " & _
                            "(SELECT precio_lista FROM items " & _
                            "WHERE tmppedidos_items.id_item = items.id_item)"
            End If
        Else
            If tabla = "pedidos_detalle" Then
                sqlstr = "UPDATE pedidos_detalle SET precio = " & _
                            "(SELECT precio_lista FROM items " & _
                            "WHERE pedidos_detalle.id_item = items.id_item) " & _
                            "WHERE id_pedido = '" + id.ToString + "' AND id_item = '" + id_item.ToString + "'"
            Else
                sqlstr = "UPDATE tmppedidos_items SET precio = " & _
                            "(SELECT precio_lista FROM items " & _
                            "WHERE tmppedidos_items.id_item = items.id_item) " & _
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
End Module