'funciones/cambios.vb
Imports System.Data.SqlClient

Module cambios
    Public Function haycambios() As Boolean
        Dim sqlstr As String = "SELECT TOP 1 activo FROM cambios WHERE activo = '1'"
        Dim dt As DataTable = GetDataTable(sqlstr)
        If dt.Rows.Count = 0 Then Return False
        Return CBool(dt.Rows(0).Item(0))
    End Function

    Public Function archivarcambios() As Boolean
        Dim sqlstr As String = "UPDATE cambios SET activo = '0' WHERE activo = '1'"
        Return ExecuteNonQuery(sqlstr)
    End Function
End Module
