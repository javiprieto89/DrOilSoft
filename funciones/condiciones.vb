'funciones/condiciones.vb
Imports System.Data.SqlClient
Module condiciones

    ' ************************************ FUNCIONES DE CONDICIONES DE VENTA **************
    Public Function info_condicion(ByVal id_condicion As String) As condicion
        Dim tmp As New condicion
        Dim sqlstr As String = "SELECT id_condicion, condicion, vencimiento, recargo, activo, ISNULL(id_tarjeta, 1) AS 'id_tarjeta' FROM condiciones WHERE id_condicion = '" & id_condicion & "'"
        Dim dt As DataTable = GetDataTable(sqlstr)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_condicion = .Item(0).ToString
                tmp.condicion = .Item(1).ToString
                tmp.vencimiento = .Item(2).ToString
                tmp.recargo = .Item(3).ToString
                tmp.activo = .Item(4).ToString
                tmp.id_tarjeta = .Item(5).ToString
            End With
        End If
        Return tmp
    End Function

    Public Function addCondicion(ByVal condicion As condicion) As Boolean
        Dim sqlstr As String = "INSERT INTO condiciones (condicion, vencimiento, recargo, activo, id_tarjeta) VALUES ('" & condicion.condicion & "', '" & condicion.vencimiento.ToString & "', '" & condicion.recargo.ToString & "', '" & condicion.activo.ToString & "', '" & condicion.id_tarjeta.ToString & "')"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function updateCondicion(ByVal condicion As condicion, Optional borra As Boolean = False) As Boolean
        Dim sqlstr As String
        If borra = True Then
            sqlstr = "UPDATE condiciones SET activo = '0' WHERE id_condicion = '" & condicion.id_condicion.ToString & "'"
        Else
            sqlstr = "UPDATE condiciones SET condicion = '" & condicion.condicion & "', vencimiento = '" & condicion.vencimiento.ToString & "', recargo = '" & condicion.recargo.ToString & "', activo = '" & condicion.activo.ToString & "', id_tarjeta = '" & condicion.id_tarjeta.ToString & "' WHERE id_condicion = '" & condicion.id_condicion.ToString & "'"
        End If
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function borrarCondicion(condicion As condicion) As Boolean
        Dim sqlstr As String = "DELETE FROM condiciones WHERE id_condicion = '" & condicion.id_condicion.ToString & "'"
        Return ExecuteNonQuery(sqlstr)
    End Function
    ' ************************************ FUNCIONES DE CONDICIONES DE VENTA **************
End Module
