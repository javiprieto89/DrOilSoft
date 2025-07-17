'funciones/mecanicos.vb
Imports System.Data.SqlClient

Module mecanicos
    ' ************************************ FUNCIONES DE MECANICOS *********************
    Public Function info_mecanico(ByVal id_mecanico As Integer) As mecanico
        Dim tmp As New mecanico
        Dim dt As DataTable = GetDataTable("SELECT * FROM mecanicos WHERE id_mecanico = '" & id_mecanico.ToString & "'")
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_mecanico = .Item(0).ToString
                tmp.nombre = .Item(1).ToString
                tmp.porcentaje = .Item(2).ToString
                tmp.activo = .Item(3).ToString
            End With
        End If
        Return tmp
    End Function

    Public Function addmecanico(ByVal m As mecanico) As Boolean
        Dim sqlstr As String = "INSERT INTO mecanicos (nombre, porcentaje, activo) VALUES ('" & m.nombre & "', '" & m.porcentaje.ToString & "', '" & m.activo.ToString & "')"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function updatemecanico(ByVal m As mecanico, Optional borra As Boolean = False) As Boolean
        Dim sqlstr As String
        If borra = True Then
            sqlstr = "UPDATE mecanicos SET activo = '0' WHERE id_mecanico = '" & m.id_mecanico.ToString & "'"
        Else
            sqlstr = "UPDATE mecanicos SET nombre = '" & m.nombre & "', porcentaje = '" & m.porcentaje.ToString & "', activo = '" & m.activo.ToString & "' WHERE id_mecanico = '" & m.id_mecanico.ToString & "'"
        End If
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function borrarmecanico(ByVal m As mecanico) As Boolean
        Dim sqlstr As String = "DELETE FROM mecanicos WHERE id_mecanico = '" & m.id_mecanico.ToString & "'"
        Return ExecuteNonQuery(sqlstr)
    End Function
    ' ************************************ FUNCIONES DE MECANICOS *********************
End Module
