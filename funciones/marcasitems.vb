'funciones/marcasitems.vb
Imports System.Data.SqlClient

Module marcasitems

    ' ************************************ FUNCIONES DE MARCAS DE ITEMS **************
    Public Function info_marcai(ByVal id_marca) As marca_item
        Dim tmp As New marca_item
        Dim dt As DataTable = GetDataTable("SELECT * FROM marcas_items WHERE id_marca = '" & id_marca.ToString & "'")
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_marca = .Item(0).ToString
                tmp.marca = .Item(1).ToString
                tmp.activo = .Item(2).ToString
            End With
        End If
        Return tmp
    End Function

    Public Function addmarcai(marcai As marca_item) As Boolean
        Dim sqlstr As String = "INSERT INTO marcas_items (marca, activo) VALUES ('" & marcai.marca & "', '" & marcai.activo.ToString & "')"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function updatemarcai(marcai As marca_item, Optional borra As Boolean = False) As Boolean
        Dim sqlstr As String
        If borra = True Then
            sqlstr = "UPDATE marcas_items SET activo = '0' WHERE id_marca = '" & marcai.id_marca.ToString & "'"
        Else
            sqlstr = "UPDATE marcas_items SET marca = '" & marcai.marca & "', activo = '" & marcai.activo.ToString & "' WHERE id_marca = '" & marcai.id_marca.ToString & "'"
        End If
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function borrarmarcai(marcai As marca_item) As Boolean
        Dim sqlstr As String = "DELETE FROM marcas_items WHERE id_marca = '" & marcai.id_marca.ToString & "'"
        Return ExecuteNonQuery(sqlstr)
    End Function
    ' ************************************ FUNCIONES DE MARCAS DE ITEMS **************
End Module
