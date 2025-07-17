'funciones/permisos.vb
Imports System.Data.SqlClient

Module permisos
    ' ************************************ FUNCIONES DE PERMISOS ********************
    Public Function info_permiso(ByVal id_permiso As String) As permiso
        Dim tmp As New permiso
        Dim dt As DataTable = GetDataTable("SELECT * FROM permisos WHERE id_permiso = '" & id_permiso & "'")
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_permiso = .Item(0).ToString
                tmp.nombre = .Item(1).ToString
            End With
        End If
        Return tmp
    End Function

    Public Function addpermiso(ByVal p As permiso) As Boolean
        Dim sqlstr As String = "INSERT INTO permisos (nombre) VALUES ('" & p.nombre & "')"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function updatepermiso(ByVal p As permiso, Optional borra As Boolean = False) As Boolean
        Dim sqlstr As String
        If borra = True Then
            sqlstr = "UPDATE permisos SET activo = '0' WHERE id_permiso = '" & p.id_permiso.ToString & "'"
        Else
            sqlstr = "UPDATE permisos SET nombre = '" & p.nombre & "' WHERE id_permiso = '" & p.id_permiso.ToString & "'"
        End If
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function borrarpermiso(ByVal p As permiso) As Boolean
        Dim sqlstr As String = "DELETE FROM permisos WHERE id_permiso = '" & p.id_permiso.ToString & "'"
        Return ExecuteNonQuery(sqlstr)
    End Function
    ' ************************************ FUNCIONES DE PERMISOS ********************
End Module

