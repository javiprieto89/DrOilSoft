'funciones/tiposcaso.vb
Imports System.Data.SqlClient

Module tipos_casos
    ' ************************************ FUNCIONES DE MARCAS DE AUTOS ********************
    Public Function info_tipocaso(ByVal id_tipocaso As String) As tipo_caso
        Dim tmp As New tipo_caso
        Dim sqlstr As String = "SELECT * FROM tipos_casos WHERE id_tipo = '" & id_tipocaso & "'"
        Dim dt As DataTable = GetDataTable(sqlstr)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_tipocaso = .Item(0).ToString
                tmp.tipo = .Item(1).ToString
                tmp.activo = .Item(2).ToString
            End With
        End If
        Return tmp
    End Function

    Public Function addtipocaso(tc As tipo_caso) As Boolean
        Dim sqlstr As String = "INSERT INTO tipos_casos (tipo, activo) VALUES ('" & tc.tipo & "', '" & tc.activo.ToString & "')"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function updatetipocaso(tc As tipo_caso, Optional borra As Boolean = False) As Boolean
        Dim sqlstr As String
        If borra Then
            sqlstr = "UPDATE tipos_casos SET activo = '0' WHERE id_tipo = '" & tc.id_tipocaso.ToString & "'"
        Else
            sqlstr = "UPDATE tipos_casos SET tipo = '" & tc.tipo & "', activo = '" & tc.activo.ToString & "' WHERE id_tipo = '" & tc.id_tipocaso.ToString & "'"
        End If
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function borrartipocaso(tc As tipo_caso) As Boolean
        Dim sqlstr As String = "DELETE FROM tipos_casos WHERE id_tipo = '" & tc.id_tipocaso.ToString & "'"
        Return ExecuteNonQuery(sqlstr)
    End Function
    ' ************************************ FUNCIONES DE MARCAS DE AUTOS ********************
End Module
