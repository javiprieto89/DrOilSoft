'funciones/descuentos.vb
Imports System.Data.SqlClient

Module descuentos

    ' ************************************ FUNCIONES DE DESCUENTOS ***************
    Public Function info_descuento(ByVal id_descuento) As descuento
        Dim tmp As New descuento
        Dim sqlstr As String = "SELECT * FROM descuentos WHERE id_descuento = '" & id_descuento.ToString & "'"
        Dim dt As DataTable = GetDataTable(sqlstr)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_descuento = .Item(0).ToString
                tmp.descript = .Item(1).ToString
                tmp.descuento = .Item(2).ToString
                tmp.activo = .Item(3).ToString
                tmp.isSystem = .Item(4).ToString
            End With
        End If
        Return tmp
    End Function

    Public Function addDescuento(descuento As descuento) As Boolean
        Dim sqlstr As String = "INSERT INTO descuentos (descripcion, descuento, activo) VALUES ('" & descuento.descript & "', '" & descuento.descuento.ToString & "', '" & descuento.activo.ToString & "')"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function updateDescuento(descuento As descuento, Optional borra As Boolean = False) As Boolean
        Dim sqlstr As String
        If borra = True Then
            sqlstr = "UPDATE descuentos SET activo = '0' WHERE id_descuento = '" & descuento.id_descuento.ToString & "'"
        Else
            sqlstr = "UPDATE descuentos SET descripcion = '" & descuento.descript & "', descuento = '" & descuento.descuento.ToString & "', activo = '" & descuento.activo.ToString & "' WHERE id_descuento = '" & descuento.id_descuento.ToString & "'"
        End If
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function borrarDescuento(descuento As descuento) As Boolean
        Dim sqlstr As String = "DELETE FROM descuentos WHERE id_descuento = '" & descuento.id_descuento.ToString & "'"
        Return ExecuteNonQuery(sqlstr)
    End Function
    ' ************************************ FUNCIONES DE DESCUENTOS ***************
End Module
