'funciones/tipositems.vb
Imports System.Data.SqlClient

Module tipositems
    ' ************************************ FUNCIONES DE TIPOS DE ITEMS ***********************
    Public Function info_tipoitem(ByVal id_tipo) As tipoitem
        Dim tmp As New tipoitem
        Dim sqlstr As String = "SELECT * FROM tipos_items WHERE id_tipo = '" & id_tipo.ToString & "'"
        Dim dt As DataTable = GetDataTable(sqlstr)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_tipo = .Item(0).ToString
                tmp.tipo = .Item(1).ToString
                tmp.activo = .Item(2).ToString
            End With
        End If
        Return tmp
    End Function

    Public Function addtipoitem(titem As tipoitem) As Boolean
        Dim sqlstr As String = "INSERT INTO tipos_items (tipo, activo) VALUES ('" & titem.tipo & "', '" & titem.activo.ToString & "')"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function updatetipoitem(titem As tipoitem, Optional borra As Boolean = False) As Boolean
        Dim sqlstr As String
        If borra Then
            sqlstr = "UPDATE tipos_items SET activo = '0' WHERE id_tipo = '" & titem.id_tipo.ToString & "'"
        Else
            sqlstr = "UPDATE tipos_items SET tipo = '" & titem.tipo & "', activo = '" & titem.activo.ToString & "' WHERE id_tipo = '" & titem.id_tipo.ToString & "'"
        End If
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function borrartipoitem(titem As tipoitem) As Boolean
        Dim sqlstr As String = "DELETE FROM tipos_items WHERE id_tipo = '" & titem.id_tipo.ToString & "'"
        Return ExecuteNonQuery(sqlstr)
    End Function
    ' ************************************ FUNCIONES DE TIPOS DE ITEMS ***********************
End Module
