'funciones/vendedores.vb
Imports System.Data.SqlClient

Module vendedores
    ' ************************************ FUNCIONES DE VENDEDORES ***************************
    Public Function info_vendedor(ByVal id_vendedor As Integer) As vendedor
        Dim tmp As New vendedor
        Dim sqlstr As String = "SELECT * FROM vendedores WHERE id_vendedor = '" & id_vendedor.ToString & "'"
        Dim dt As DataTable = GetDataTable(sqlstr)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_vendedor = .Item(0).ToString
                tmp.nombre = .Item(1).ToString
                tmp.porcentaje = .Item(2).ToString
                tmp.activo = .Item(3).ToString
            End With
        End If
        Return tmp
    End Function

    Public Function addVendedor(ByVal v As vendedor) As Boolean
        Dim sqlstr As String = "INSERT INTO vendedores (nombre, porcentaje, activo) VALUES ('" & v.nombre & "', '" & v.porcentaje.ToString & "', '" & v.activo.ToString & "')"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function updateVendedor(ByVal v As vendedor, Optional borra As Boolean = False) As Boolean
        Dim sqlstr As String
        If borra Then
            sqlstr = "UPDATE vendedores SET activo = '0' WHERE id_vendedor = '" & v.id_vendedor.ToString & "'"
        Else
            sqlstr = "UPDATE vendedores SET nombre = '" & v.nombre & "', porcentaje = '" & v.porcentaje.ToString & "', activo = '" & v.activo.ToString & "' WHERE id_vendedor = '" & v.id_vendedor.ToString & "'"
        End If
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function borrarVendedor(ByVal v As vendedor) As Boolean
        Dim sqlstr As String = "DELETE FROM vendedores WHERE id_vendedor = '" & v.id_vendedor.ToString & "'"
        Return ExecuteNonQuery(sqlstr)
    End Function
    ' ************************************ FUNCIONES DE VENDEDORES ***************************
End Module
