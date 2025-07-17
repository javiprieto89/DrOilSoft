'funciones/modelosautos.vb
Imports System.Data.SqlClient

Module modelosautos
    ' ************************************ FUNCIONES DE MODELOS DE AUTOS *************
    Public Function info_modeloa(ByVal id_modelo As String) As modelo_auto
        Dim tmp As New modelo_auto
        Dim dt As DataTable = GetDataTable("SELECT * FROM modelosa WHERE id_modelo = '" & id_modelo & "'")
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_modelo = .Item(0).ToString
                tmp.modelo = .Item(1).ToString
                tmp.id_marca = .Item(2).ToString
                tmp.activo = .Item(3).ToString
            End With
        End If
        Return tmp
    End Function

    Public Function addmodeloa(ByVal modelo As modelo_auto) As Boolean
        Dim sqlstr As String = "INSERT INTO modelosa (modelo, id_marca_modelo, activo) VALUES ('" & modelo.modelo & "', '" & CType(modelo.id_marca, String) & "', '" & modelo.activo.ToString & "')"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function updatemodeloa(ByVal modelo As modelo_auto, Optional borra As Boolean = False) As Boolean
        Dim sqlstr As String
        If borra = True Then
            sqlstr = "UPDATE modelosa SET activo = '0' WHERE id_modelo = '" & modelo.id_modelo.ToString & "'"
        Else
            sqlstr = "UPDATE modelosa SET modelo = '" & modelo.modelo & "', id_marca_modelo = '" & modelo.id_marca.ToString & "', activo = '" & modelo.activo.ToString & "' WHERE id_modelo = '" & modelo.id_modelo.ToString & "'"
        End If
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function borrarmodeloa(modelo As modelo_auto) As Boolean
        Dim sqlstr As String = "DELETE FROM modelosa WHERE id_modelo = '" & modelo.id_modelo.ToString & "'"
        Return ExecuteNonQuery(sqlstr)
    End Function
    ' ************************************ FUNCIONES DE MODELOS DE AUTOS *************
End Module
