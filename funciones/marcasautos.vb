'funciones/marcasautos.vb
Imports System.Data.SqlClient

Module marcasautos
    ' ************************************ FUNCIONES DE MARCAS DE AUTOS ************
    Public Function info_marcaa(ByVal id_marca As String) As marca_auto
        Dim tmp As New marca_auto
        Dim dt As DataTable = GetDataTable("SELECT * FROM marcas_autos WHERE id_marca = '" & id_marca & "'")
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_marca = .Item(0).ToString
                tmp.marca = .Item(1).ToString
                tmp.activo = .Item(2).ToString
            End With
        End If
        Return tmp
    End Function

    Public Function addmarcaa(marcaa As marca_auto) As Boolean
        Dim sqlstr As String = "INSERT INTO marcas_autos (marca, activo) VALUES ('" & marcaa.marca & "', '" & marcaa.activo.ToString & "')"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function updatemarcaa(marcaa As marca_auto, Optional borra As Boolean = False) As Boolean
        Dim sqlstr As String
        If borra = True Then
            sqlstr = "UPDATE marcas_autos SET activo = '0' WHERE id_marca = '" & marcaa.id_marca.ToString & "'"
        Else
            sqlstr = "UPDATE marcas_autos SET marca = '" & marcaa.marca & "', activo = '" & marcaa.activo.ToString & "' WHERE id_marca = '" & marcaa.id_marca.ToString & "'"
        End If
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function borrarmarcaa(marcaa As marca_auto) As Boolean
        Dim sqlstr As String = "DELETE FROM marcas_autos WHERE id_marca = '" & marcaa.id_marca.ToString & "'"
        Return ExecuteNonQuery(sqlstr)
    End Function
    ' ************************************ FUNCIONES DE MARCAS DE AUTOS ************
End Module
