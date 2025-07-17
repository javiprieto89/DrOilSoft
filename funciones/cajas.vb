'funciones/cajas.vb
Imports System.Data.SqlClient

Module cajas
    ' ************************************ FUNCIONES DE CAJAS ********************
    Public Function info_caja(ByVal id_caja As String) As caja
        Dim tmp As New caja
        Dim sqlstr As String = "SELECT * FROM cajas WHERE id_caja = '" & id_caja & "'"
        Dim dt As DataTable = GetDataTable(sqlstr)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_caja = .Item(0).ToString
                tmp.nombre = .Item(1).ToString
                tmp.esCC = .Item(2).ToString
                tmp.activo = .Item(3).ToString
            End With
        End If
        Return tmp
    End Function

    Public Function addCaja(ByVal c As caja) As Boolean
        Dim sqlstr As String = "INSERT INTO cajas (nombre, esCC, activo) VALUES ('" & c.nombre & "', '" & c.esCC.ToString & "', '" & c.activo.ToString & "')"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function updateCaja(ByVal c As caja, Optional borra As Boolean = False) As Boolean
        Dim sqlstr As String
        If borra = True Then
            sqlstr = "UPDATE cajas SET activo = '0' WHERE id_caja = '" & c.id_caja.ToString & "'"
        Else
            sqlstr = "UPDATE cajas SET nombre = '" & c.nombre & "', esCC = '" & c.esCC.ToString & "', activo = '" & c.activo.ToString & "' WHERE id_caja = '" & c.id_caja.ToString & "'"
        End If
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function borrarCaja(ByVal c As caja) As Boolean
        Dim sqlstr As String = "DELETE FROM cajas WHERE id_caja = '" & c.id_caja.ToString & "'"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function consultaSaldoCaja(ByVal id_caja As Integer, ByVal fecha_desde As Date, ByVal fecha_hasta As Date, _
                                      ByVal consulta_pedidos As Boolean, ByVal consulta_casos As Boolean, _
                                      ByVal consulta_abiertos As Boolean, ByVal consulta_cerrados As Boolean) As saldoCaja
        Dim saldo As New saldoCaja
        Dim sqlstr As String
        Dim where As String = ""
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
        sqlstr = "SELECT ISNULL((SUM(p.total) - SUM(p.montoTarjeta)),0) AS 'Contado', ISNULL(SUM(p.montoTarjeta),0) AS 'Tarjeta', " & _
                        "ISNULL(SUM(p.total), 0) AS 'Total' " & _
                        "FROM pedidos As p " & _
                        "INNER JOIN cajas AS c ON p.id_caja = c.id_caja " & _
                        "WHERE c.esCC = '0' AND p.fecha BETWEEN '" + fecha_desde.ToString("yyyy/MM/dd") + "' AND '" + fecha_hasta.ToString("yyyy/MM/dd") + "' " & _
                        "AND p.id_caja = '" + id_caja.ToString + "'"
        sqlstr += where
        Dim dt As DataTable = GetDataTable(sqlstr)
        If dt.Rows.Count > 0 Then
            saldo.contado = dt.Rows(0).Item(0).ToString
            saldo.tarjeta = dt.Rows(0).Item(1).ToString
            saldo.total = dt.Rows(0).Item(2).ToString
        End If
        Return saldo
    End Function

    ' ************************************ FUNCIONES DE CAJAS ********************
End Module
