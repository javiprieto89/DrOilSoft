Imports System.Data.SqlClient

Module mecanicos
    ' ************************************ FUNCIONES DE MECANICOS ***************************
    Public Function info_mecanico(ByVal id_mecanico As Integer) As mecanico
        Dim tmp As New mecanico
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = "SELECT * FROM mecanicos WHERE id_mecanico = '" + id_mecanico.ToString + "'"
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")
            tmp.id_mecanico = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.nombre = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.porcentaje = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(3).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            tmp.nombre = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addmecanico(ByVal m As mecanico) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String

        sqlstr = "INSERT INTO mecanicos (nombre, porcentaje, activo) VALUES ('" + m.nombre + "', '" + m.porcentaje.ToString + "', '" + m.activo.ToString + "')"

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlCommand(sqlstr, CN)

            Comando.Transaction = mytrans
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            cerrardb()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            cerrardb()
            Return False
        End Try
    End Function

    Public Function updatemecanico(ByVal m As mecanico, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim sqlstr As String
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                sqlstr = "UPDATE mecanicos SET activo = '0' WHERE id_mecanico = '" + m.id_mecanico.ToString + "'"
            Else
                sqlstr = "UPDATE mecanicos SET nombre = '" + m.nombre + "', porcentaje = '" + m.porcentaje.ToString + "', activo = '" + m.activo.ToString + "'" _
                                             + " WHERE id_mecanico = '" + m.id_mecanico.ToString + "'"
            End If

            Comando = New SqlCommand(sqlstr, CN)

            Comando.Transaction = mytrans
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            cerrardb()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            cerrardb()
            Return False
        End Try
    End Function

    Public Function borrarmecanico(ByVal m As mecanico) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlCommand("DELETE FROM mecanicos WHERE id_mecanico = '" + m.id_mecanico.ToString + "'", CN)
            Comando.Transaction = mytrans
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            cerrardb()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
            Return False
        End Try
    End Function
    ' ************************************ FUNCIONES DE MECANICOS ***************************
End Module
