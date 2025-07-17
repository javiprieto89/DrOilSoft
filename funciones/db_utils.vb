'funciones/db_utils.vb

Imports System.Data
Imports System.Data.SqlClient

Module DbUtils
    'Devuelve un DataTable con el resultado de la consulta SQL indicada
    Public Function GetDataTable(ByVal sql As String) As DataTable
        Dim dt As New DataTable()
        Try
            abrirdb(serversql, basedb, usuariodb, passdb)
            Dim da As New SqlDataAdapter(sql, CN)
            da.Fill(dt)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            cerrardb()
        End Try
        Return dt
    End Function

    'Ejecuta un comando SQL y devuelve True si no hubo errores
    Public Function ExecuteNonQuery(ByVal sql As String) As Boolean
        Try
            abrirdb(serversql, basedb, usuariodb, passdb)
            Dim cmd As New SqlCommand(sql, CN)
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return False
        Finally
            cerrardb()
        End Try
    End Function

    'Ejecuta un comando SQL y devuelve el primer valor resultante
    Public Function ExecuteScalar(ByVal sql As String) As Object
        Dim res As Object = Nothing
        Try
            abrirdb(serversql, basedb, usuariodb, passdb)
            Dim cmd As New SqlCommand(sql, CN)
            res = cmd.ExecuteScalar()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            cerrardb()
        End Try
        Return res
    End Function
End Module