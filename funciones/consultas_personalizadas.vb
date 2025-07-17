'funciones/consultas_personalizadas.vb
Imports System.Data.SqlClient
Module consultas
    ' ************************************ FUNCIONES DE CONSULTAS PERSONALIZADAS **********************

    Public Function info_consulta(ByVal id_consulta As Integer) As consultaP
        Dim tmp As New consultaP
        Dim sqlstr As String = "SELECT c.id_consulta, c.nombre, c.consulta, c.activo FROM consultas_personalizadas AS c WHERE c.id_consulta = '" & id_consulta.ToString & "'"
        Dim dt As DataTable = GetDataTable(sqlstr)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_consulta = .Item(0).ToString
                tmp.nombre = .Item(1).ToString
                tmp.consulta = .Item(2).ToString
                tmp.activo = .Item(3).ToString
            End With
        End If
        Return tmp
    End Function

    Public Function addConsulta(ByVal c As consultaP) As Boolean
        Dim sqlstr As String = "INSERT INTO consultas_personalizadas (nombre, consulta, activo) VALUES ('" & c.nombre & "', '" & c.consulta & "', '" & c.activo.ToString & "')"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function updateConsulta(ByVal c As consultaP, Optional borra As Boolean = False) As Boolean
        Dim sqlstr As String
        If borra = True Then
            sqlstr = "UPDATE consultas_personalizadas SET activo = '0' WHERE id_consulta = '" & c.id_consulta.ToString & "'"
        Else
            sqlstr = "UPDATE consultas_personalizadas SET nombre = '" & c.nombre & "', consulta = '" & c.consulta & "', activo = '" & c.activo.ToString & "' WHERE id_consulta = '" & c.id_consulta.ToString & "'"
        End If
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function borrarConsulta(ByVal c As consultaP) As Boolean
        Dim sqlstr As String = "DELETE FROM consultas_personalizadas WHERE id_consulta = '" & c.id_consulta.ToString & "'"
        Return ExecuteNonQuery(sqlstr)
    End Function
    ' ************************************ FUNCIONES DE CONSULTAS PERSONALIZADAS **********************
End Module
