'funciones/gruposTarjetas.vb
Imports System.Data.SqlClient

Module gruposTarjetas
    ' ************************************ FUNCIONES DE CAJAS ********************
    Public Function info_grupoTarjetas(ByVal id_grupo As String) As grupoTarjetas
        Dim tmp As New grupoTarjetas
        Dim sqlstr As String = "SELECT id_grupo, grupo FROM grupo_tarjetas WHERE id_grupo = '" & id_grupo & "'"
        Dim dt As DataTable = GetDataTable(sqlstr)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_grupo = .Item(0).ToString
                tmp.grupo = .Item(1).ToString
            End With
        End If
        Return tmp
    End Function

    Public Function addGrupoTarjetas(ByVal g As grupoTarjetas) As Boolean
        Dim sqlstr As String = "INSERT INTO grupo_tarjetas (grupo) VALUES ('" & g.grupo & "')"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function updateGrupoTarjetas(ByVal g As grupoTarjetas, Optional borra As Boolean = False) As Boolean
        Dim sqlstr As String = "UPDATE grupo_tarjetas SET grupo = '" & g.grupo & "' WHERE id_grupo = '" & g.id_grupo.ToString & "'"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function borrarGrupoTarjetas(ByVal g As grupoTarjetas) As Boolean
        Dim sqlstr As String = "DELETE FROM grupo_tarjetas WHERE id_grupo = '" & g.id_grupo.ToString & "'"
        Return ExecuteNonQuery(sqlstr)
    End Function
    ' ************************************ FUNCIONES DE CAJAS ********************
End Module
