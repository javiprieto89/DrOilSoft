'funciones/impuestos.vb
Imports System.Data.SqlClient

Module impuestos

    ' ************************************ FUNCIONES DE IMPUESTOS ************************
    Public Function info_impuesto(ByVal id_impuesto) As impuesto
        Dim tmp As New impuesto
        Dim sqlstr As String = "SELECT id_impuesto, nombre, porcentaje, activo FROM impuestos WHERE id_impuesto = '" & id_impuesto.ToString & "'"
        Dim dt As DataTable = GetDataTable(sqlstr)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_impuesto = .Item(0).ToString
                tmp.nombre = .Item(1).ToString
                tmp.porcentaje = .Item(2).ToString
                tmp.activo = .Item(3).ToString
            End With
        End If
        Return tmp
    End Function

    Public Function addImpuesto(impuesto As impuesto) As Boolean
        Dim sqlstr As String = "INSERT INTO impuestos (nombre, porcentaje, activo) VALUES('" & impuesto.nombre & "', '" & impuesto.porcentaje.ToString & "', '" & impuesto.activo.ToString & "')"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function updateImpuesto(impuesto As impuesto, Optional borra As Boolean = False) As Boolean
        Dim sqlstr As String
        If borra Then
            sqlstr = "UPDATE impuestos SET activo = '0' WHERE id_impuesto = '" & impuesto.id_impuesto.ToString & "'"
        Else
            sqlstr = "UPDATE impuestos SET nombre = '" & impuesto.nombre & "', porcentaje = '" & impuesto.porcentaje.ToString & "', activo = '" & impuesto.activo.ToString & "' WHERE id_impuesto = '" & impuesto.id_impuesto.ToString & "'"
        End If
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function borrarImpuesto(impuesto As impuesto) As Boolean
        Dim sqlstr As String = "DELETE FROM impuestos WHERE id_impuesto = '" & impuesto.id_impuesto.ToString & "'"
        Return ExecuteNonQuery(sqlstr)
    End Function
    ' ************************************ FUNCIONES DE IMPUESTOS ************************
End Module
