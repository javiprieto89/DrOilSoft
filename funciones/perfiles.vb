'funciones/perfiles.vb
Imports System.Data.SqlClient
Module perfiles
    ' ************************************ FUNCIONES DE PERFILES ********************
    Public Function info_perfil(ByVal id_perfil As String) As perfil
        Dim tmp As New perfil
        Dim dt As DataTable = GetDataTable("SELECT * FROM perfiles WHERE id_perfil = '" & id_perfil & "'")
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_perfil = .Item(0).ToString
                tmp.nombre = .Item(1).ToString
                tmp.activo = .Item(2).ToString
            End With
        End If
        Return tmp
    End Function

    Public Function addperfil(ByVal p As perfil) As Boolean
        Dim sqlstr As String = "INSERT INTO perfiles (nombre, activo) VALUES ('" & p.nombre & "', '" & p.activo.ToString & "')"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function updateperfil(ByVal p As perfil, Optional borra As Boolean = False) As Boolean
        Dim sqlstr As String
        If borra = True Then
            sqlstr = "UPDATE perfiles SET activo = '0' WHERE id_perfil = '" & p.id_perfil.ToString & "'"
        Else
            sqlstr = "UPDATE perfiles SET nombre = '" & p.nombre & "', activo = '" & p.activo.ToString & "' WHERE id_perfil = '" & p.id_perfil.ToString & "'"
        End If
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function borrarperfil(ByVal p As perfil) As Boolean
        Dim sqlstr As String = "DELETE FROM perfiles WHERE id_perfil = '" & p.id_perfil.ToString & "'"
        Return ExecuteNonQuery(sqlstr)
    End Function
    ' ************************************ FUNCIONES DE PERFILES ********************
End Module
