'funciones/consultasSIAP.vb
Imports System.Data.SqlClient
Module consultasSIAP
    ' ************************************ FUNCIONES DE CONSULTAS DE SIAP ****************
    Public Function info_consultaSIAP(ByVal id_consulta As Integer) As consultaSIAP
        Dim tmp As New consultaSIAP
        Dim sqlstr As String = "SELECT c.id_consultaSiap, c.nombre, c.consulta, c.excel, c.txt, c.activo FROM consultas_SIAP AS c WHERE c.id_consultaSiap = '" & id_consulta.ToString & "'"
        Dim dt As DataTable = GetDataTable(sqlstr)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_consulta = .Item(0).ToString
                tmp.nombre = .Item(1).ToString
                tmp.consulta = .Item(2).ToString
                tmp.excel = .Item(3).ToString
                tmp.txt = .Item(4).ToString
                tmp.activo = .Item(5).ToString
            End With
        End If
        Return tmp
    End Function
    ' ************************************ FUNCIONES DE CONSULTAS DE SIAP ****************
End Module
