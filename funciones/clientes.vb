Imports System.Data
Imports System.Data.SqlClient

Module clientes
    ' ************************************ FUNCIONES DE CLIENTES ***************************
    Public Function info_cliente(ByVal id_cliente As String) As cliente
        Dim tmp As New cliente
        Dim sqlstr As String
		Dim dt As DataTable = GetDataTable("SELECT * FROM clientes WHERE id_cliente = '" & id_cliente & "'")

        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_cliente = .Item(0).ToString
                tmp.dni = .Item(1).ToString
                tmp.nombre = .Item(2).ToString
                tmp.apellido = .Item(3).ToString
                tmp.telefono = .Item(4).ToString
                tmp.email = .Item(5).ToString
                tmp.direccion = .Item(6).ToString
                tmp.activo = .Item(7).ToString
                tmp.id_pais = .Item(8).ToString
                tmp.id_provincia = .Item(9).ToString
                tmp.id_descuento = .Item(10).ToString
                tmp.esInscripto = .Item(11).ToString
                tmp.id_tipoDocumento = .Item(12).ToString
                tmp.localidad = .Item(13).ToString
                tmp.cp = .Item(14).ToString
            End With
		End If
        Return tmp
    End Function

    Public Function addcliente(ByVal cl As cliente) As Boolean
        Dim sqlstr As String = "INSERT INTO clientes (dni, nombre, apellido, telefono, email, direccion, activo, id_pais, id_provincia, id_descuento, esInscripto, id_tipoDocumento, localidad, cp) " &
                              "VALUES ('" & cl.dni & "', '" & cl.nombre & "', '" & cl.apellido & "', '" & cl.telefono & "', '" & cl.telefono & "', '" & cl.direccion & "', '" & cl.activo.ToString & "', '" & cl.id_pais.ToString & "', '" & cl.id_provincia.ToString & "', '" & cl.id_descuento.ToString & "', '" & cl.esInscripto.ToString & "', '" & cl.id_tipoDocumento.ToString & "', '" & cl.localidad & "', '" & cl.cp & "')"


        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function updatecliente(cl As cliente, Optional borra As Boolean = False) As Boolean
        Dim sqlstr As String
       
	    If borra = True Then
            sqlstr = "UPDATE clientes SET activo = '0' WHERE id_cliente = '" & cl.id_cliente.ToString & "'"
        Else
            sqlstr = "UPDATE clientes SET dni = '" & cl.dni & "', nombre = '" & cl.nombre & "', apellido = '" & cl.apellido & "', telefono = '" _
                      & cl.telefono & "', email = '" & cl.email & "', direccion = '" & cl.direccion & "', activo = '" & cl.activo.ToString & "', id_pais = '" & cl.id_pais.ToString & "', " _
                      & " id_provincia = '" & cl.id_provincia.ToString & "', id_descuento = '" & cl.id_descuento.ToString & "', esInscripto = '" & cl.esInscripto.ToString & "', " _
                      & " id_tipoDocumento = '" & cl.id_tipoDocumento.ToString & "', localidad = '" & cl.localidad & "', cp = '" & cl.cp & "'" _
                      & " WHERE id_cliente = '" & cl.id_cliente.ToString & "'"
        End If

        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function borrarcliente(cl As cliente) As Boolean
        Dim sqlstr As String = "DELETE FROM clientes WHERE id_cliente = '" & cl.id_cliente.ToString & "'"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function existecliente(ByVal n As String, Optional ByVal a As String = "") As Integer
       Dim sqlstr As String = "SELECT id_cliente FROM clientes WHERE nombre + apellido LIKE '%" & Trim(n.ToString) & Trim(a.ToString) & "%'"
       Dim dt As DataTable = GetDataTable(sqlstr)
       If dt.Rows.Count = 0 Then Return -1
       Return CInt(dt.Rows(0).Item(0))
    End Function

    Public Function existecliente(ByVal taxNumber As String) As Integer
        Dim sqlstr As String = "SELECT id_cliente FROM clientes WHERE dni = '" & Trim(taxNumber.ToString) & "'"
        Dim dt As DataTable = GetDataTable(sqlstr)
		
        If dt.Rows.Count = 0 Then Return -1
        Return CInt(dt.Rows(0).Item(0))
    End Function

    Public Function consultaCcCliente(ByVal id_cliente As Integer, ByVal fecha_desde As Date, ByVal fecha_hasta As Date,
                                    ByVal consulta_pedidos As Boolean, ByVal consulta_casos As Boolean,
                                    ByVal consulta_abiertos As Boolean, ByVal consulta_cerrados As Boolean) As DataTable
        Dim sqlstr As String
        Dim where As String = ""
        Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
        Dim dt As New DataTable 'Crear nuevo dataset

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            If consulta_pedidos And Not consulta_casos Then
                where = " AND p.es_caso = '0'"
            ElseIf Not consulta_pedidos And consulta_casos Then
                where = " AND p.es_caso = '1'"
            End If

            If consulta_abiertos And Not consulta_cerrados Then
                where += " AND p.activo = '1' AND p.cerrado = '0'"
            ElseIf Not consulta_abiertos And consulta_cerrados Then
                where += " AND p.activo = '0' AND p.cerrado = '1'"
            End If

            sqlstr = "SET DATEFORMAT mdy; SELECT p.id_pedido AS 'ID', CAST(p.fecha AS VARCHAR(50)) AS 'Fecha', (CASE p.es_caso WHEN 1 THEN 'Si' ELSE 'No' END) AS '¿Es caso?', tc.tipo AS 'Tipo', CONCAT('$ ', p.total) AS 'Total' " &
                        "FROM pedidos As p " &
                        "LEFT JOIN tipos_casos AS tc ON p.id_tipo = tc.id_tipo " &
                        "WHERE p.fecha BETWEEN '" + fecha_desde.ToString("MM/dd/yyyy") + "' AND '" + fecha_hasta.ToString("MM/dd/yyyy") + "' " &
                        "AND p.id_cliente = '" + id_cliente.ToString + "'"
            sqlstr += where

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = sqlstr
                .Connection = CN
            End With

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return dt
        Finally
            cerrardb()
        End Try
    End Function
    Public Function consultaTotalCcCliente(ByVal id_cliente As Integer, ByVal fecha_desde As Date, ByVal fecha_hasta As Date,
                                    ByVal consulta_pedidos As Boolean, ByVal consulta_casos As Boolean,
                                    ByVal consulta_abiertos As Boolean, ByVal consulta_cerrados As Boolean) As String
        Dim sqlstr As String
        Dim where As String = ""
        Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
        Dim dt As New DataTable 'Crear nuevo dataset

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            If consulta_pedidos And Not consulta_casos Then
                where = " AND p.es_caso = '0'"
            ElseIf Not consulta_pedidos And consulta_casos Then
                where = " AND p.es_caso = '1'"
            End If

            If consulta_abiertos And Not consulta_cerrados Then
                where += " AND p.activo = '1' AND p.cerrado = '0'"
            ElseIf Not consulta_abiertos And consulta_cerrados Then
                where += " AND p.activo = '0' AND p.cerrado = '1'"
            End If

            sqlstr = "SET DATEFORMAT mdy; SELECT CONCAT('$ ', SUM(p.total)) AS 'Total' " &
                        "FROM pedidos As p " &
                        "WHERE p.fecha BETWEEN '" + fecha_desde.ToString("MM/dd/yyyy") + "' AND '" + fecha_hasta.ToString("MM/dd/yyyy") + "' " &
                        "AND p.id_cliente = '" + id_cliente.ToString + "'"
            sqlstr += where

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = sqlstr
                .Connection = CN
            End With

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dt)
            Return dt.Rows(0).Item(0).ToString
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return ""
        Finally
            cerrardb()
        End Try
    End Function
    ' ************************************ FUNCIONES DE CLIENTES ***************************
End Module
