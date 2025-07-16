Imports System.Data.SqlClient
Module tarjetas

    ' ************************************ FUNCIONES DE TARJETAS DE CREDITO **********************
    Public Function info_tarjeta(ByVal id_tarjeta As Integer) As tarjeta
        Dim tmp As New tarjeta
        Dim sqlstr As String

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            sqlstr = "SELECT id_tarjeta, tarjeta, ISNULL(recargo, 0), ISNULL(cuotas, 0), ISNULL(id_grupo, 1) AS 'id_grupo', activo FROM tarjetas " &
                                "WHERE id_tarjeta = '" + id_tarjeta.ToString + "'"

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")
            tmp.id_tarjeta = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.tarjeta = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.recargo = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.cuotas = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.id_grupo = dataset.Tables("tabla").Rows(0).Item(4).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(5).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            tmp.tarjeta = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addTarjeta(ByVal t As tarjeta) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim sqlstr As String
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "INSERT INTO tarjetas (tarjeta, recargo, cuotas, id_grupo, activo) " & _
                    "VALUES ('" + t.tarjeta + "', '" + t.recargo.ToString + "', '" + t.cuotas.ToString + "', '" +
                    t.id_grupo.ToString + "', '" + t.activo.ToString + "')"

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

    Public Function updateTarjeta(ByVal t As tarjeta, Optional ByVal borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim sqlstr As String
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                sqlstr = "UPDATE tarjetas SET activo = '0' WHERE id_tarjeta = '" + t.id_tarjeta.ToString + "'"
            Else
                sqlstr = "UPDATE tarjetas SET tarjeta = '" + t.tarjeta + "', recargo = '" + t.recargo.ToString + "', " +
                            "cuotas = '" + t.cuotas.ToString + "', id_grupo = '" + t.id_grupo.ToString + "', activo = '" + t.activo.ToString + _
                            "' WHERE id_tarjeta = '" + t.id_tarjeta.ToString + "'"
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

    Public Function borrarTarjeta(ByVal t As tarjeta) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim sqlstr As String = ""
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE FROM tarjetas WHERE id_tarjeta = '" + t.id_tarjeta.ToString + "'"
            Comando = New SqlCommand(sqlstr, CN)
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
    ' ************************************ FUNCIONES DE TARJETAS DE CREDITO **********************
End Module
