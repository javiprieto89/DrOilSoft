'funciones/tarjetas.vb
Imports System.Data.SqlClient
Module tarjetas

    ' ************************************ FUNCIONES DE TARJETAS DE CREDITO **********************
    Public Function info_tarjeta(ByVal id_tarjeta As Integer) As tarjeta
        Dim tmp As New tarjeta
        Dim sqlstr As String = "SELECT id_tarjeta, tarjeta, ISNULL(recargo, 0), ISNULL(cuotas, 0), ISNULL(id_grupo, 1) AS 'id_grupo', activo FROM tarjetas WHERE id_tarjeta = '" & id_tarjeta.ToString & "'"
        Dim dt As DataTable = GetDataTable(sqlstr)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_tarjeta = .Item(0).ToString
                tmp.tarjeta = .Item(1).ToString
                tmp.recargo = .Item(2).ToString
                tmp.cuotas = .Item(3).ToString
                tmp.id_grupo = .Item(4).ToString
                tmp.activo = .Item(5).ToString
            End With
        End If
        Return tmp
    End Function

    Public Function addTarjeta(ByVal t As tarjeta) As Boolean
        Dim sqlstr As String = "INSERT INTO tarjetas (tarjeta, recargo, cuotas, id_grupo, activo) VALUES ('" & t.tarjeta & "', '" & t.recargo.ToString & "', '" & t.cuotas.ToString & "', '" & t.id_grupo.ToString & "', '" & t.activo.ToString & "')"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function updateTarjeta(ByVal t As tarjeta, Optional ByVal borra As Boolean = False) As Boolean
        Dim sqlstr As String
        If borra Then
            sqlstr = "UPDATE tarjetas SET activo = '0' WHERE id_tarjeta = '" & t.id_tarjeta.ToString & "'"
        Else
            sqlstr = "UPDATE tarjetas SET tarjeta = '" & t.tarjeta & "', recargo = '" & t.recargo.ToString & "', cuotas = '" & t.cuotas.ToString & "', id_grupo = '" & t.id_grupo.ToString & "', activo = '" & t.activo.ToString & "' WHERE id_tarjeta = '" & t.id_tarjeta.ToString & "'"
        End If
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function borrarTarjeta(ByVal t As tarjeta) As Boolean
        Dim sqlstr As String = "DELETE FROM tarjetas WHERE id_tarjeta = '" & t.id_tarjeta.ToString & "'"
        Return ExecuteNonQuery(sqlstr)
    End Function
    ' ************************************ FUNCIONES DE TARJETAS DE CREDITO **********************
End Module
