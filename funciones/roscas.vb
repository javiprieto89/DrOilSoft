'funciones/roscas.vb
Imports System.Data.SqlClient

Module roscas
    ' ************************************ FUNCIONES DE MARCAS DE AUTOS ********************
    Public Function info_rosca(ByVal id_rosca As String) As rosca
        Dim tmp As New rosca
        Dim dt As DataTable = GetDataTable("SELECT * FROM roscas WHERE id_rosca = '" & id_rosca & "'")
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_rosca = .Item(0).ToString
                tmp.rosca = .Item(1).ToString
                tmp.activo = .Item(2).ToString
            End With
        End If
        Return tmp
    End Function

    Public Function addrosca(r As rosca) As Boolean
        Dim sqlstr As String = "INSERT INTO roscas (rosca, activo) VALUES ('" & r.rosca & "', '" & r.activo.ToString & "')"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function updaterosca(r As rosca, Optional borra As Boolean = False) As Boolean
        Dim sqlstr As String
        If borra = True Then
            sqlstr = "UPDATE roscas SET activo = '0' WHERE id_rosca = '" & r.id_rosca.ToString & "'"
        Else
            sqlstr = "UPDATE roscas SET rosca = '" & r.rosca & "', activo = '" & r.activo.ToString & "' WHERE id_rosca = '" & r.id_rosca.ToString & "'"
        End If
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function borrarrosca(r As rosca) As Boolean
        Dim sqlstr As String = "DELETE FROM roscas WHERE id_rosca = '" & r.id_rosca.ToString & "'"
        Return ExecuteNonQuery(sqlstr)
    End Function
    ' ************************************ FUNCIONES DE MARCAS DE AUTOS ********************
End Module
