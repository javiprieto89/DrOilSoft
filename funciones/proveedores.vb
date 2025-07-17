'funciones/proveedores.vb
Imports System.Data.SqlClient

Module proveedores
    ' ************************************ FUNCIONES DE PROVEEDORES **************************
    Public Function info_proveedor(ByVal id_proveedor As Integer) As proveedor
        Dim tmp As New proveedor
        Dim dt As DataTable = GetDataTable("SELECT * FROM proveedores WHERE id_proveedor = '" & id_proveedor.ToString & "'")
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_proveedor = .Item(0).ToString
                tmp.dni = .Item(1).ToString
                tmp.nombre = .Item(2).ToString
                tmp.telefono = .Item(3).ToString
                tmp.email = .Item(4).ToString
                tmp.direccion = .Item(5).ToString
                tmp.vendedor = .Item(6).ToString
                tmp.activo = .Item(7).ToString
            End With
        End If
        Return tmp
    End Function

    Public Function addproveedor(p As proveedor) As Boolean
        Dim sqlstr As String = "INSERT INTO proveedores (dni, nombre, telefono, email, direccion, vendedor, activo) VALUES ('" & p.dni & "', '" & p.nombre & "', '" & p.telefono & "', '" & p.email & "', '" & p.direccion & "', '" & p.vendedor & "', '" & p.activo.ToString & "')"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function updateproveedor(p As proveedor, Optional borra As Boolean = False) As Boolean
        Dim sqlstr As String
        If borra = True Then
            sqlstr = "UPDATE proveedores SET activo = '0' WHERE id_proveedor = '" & p.id_proveedor.ToString & "'"
        Else
            sqlstr = "UPDATE proveedores SET dni = '" & p.dni & "', nombre = '" & p.nombre & "', telefono = '" & p.telefono & "', email = '" & p.email & "', direccion = '" & p.direccion & "', vendedor = '" & p.vendedor & "', activo = '" & p.activo.ToString & "' WHERE id_proveedor = '" & p.id_proveedor.ToString & "'"
        End If
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function borrarproveedor(p As proveedor) As Boolean
        Dim sqlstr As String = "DELETE FROM proveedores WHERE id_proveedor = '" & p.id_proveedor.ToString & "'"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function existeproveedor(ByVal n As String) As Integer
        Dim dt As DataTable = GetDataTable("SELECT id_proveedor FROM proveedores WHERE nombre LIKE '%" & Trim(n.ToString) & "%'")
        If dt.Rows.Count = 0 Then Return -1
        Return CInt(dt.Rows(0).Item(0))
    End Function
    ' ************************************ FUNCIONES DE PROVEEDORES **************************
End Module
