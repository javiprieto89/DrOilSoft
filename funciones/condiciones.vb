
Imports System.Data.SqlClient
Module condiciones

    ' ************************************ FUNCIONES DE CONDICIONES DE VENTA **********************
    Public Function info_condicion(ByVal id_condicion As String) As condicion
        Dim tmp As New condicion
        Dim sqlstr As String

        Try
            sqlstr = "SELECT id_condicion, condicion, vencimiento, recargo, activo, ISNULL(id_tarjeta, 1) AS 'id_tarjeta' " +
                    "FROM condiciones " +
                    "WHERE id_condicion = '" + id_condicion.ToString + "'"

            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

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
            tmp.id_condicion = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.condicion = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.vencimiento = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.recargo = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(4).ToString
            tmp.id_tarjeta = dataset.Tables("tabla").Rows(0).Item(5).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            tmp.condicion = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addCondicion(ByVal condicion As condicion) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim sqlstr As String
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "INSERT INTO condiciones (condicion, vencimiento, recargo, activo, id_tarjeta) VALUES ('" +
                        condicion.condicion + "', '" + condicion.vencimiento.ToString + "', '" + condicion.recargo.ToString +
                        "', '" + condicion.activo.ToString + "', '" + condicion.id_tarjeta.ToString + "')"
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

    Public Function updateCondicion(ByVal condicion As condicion, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim sqlstr As String
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                sqlstr = "UPDATE condiciones SET activo = '0' WHERE id_condicion = '" + condicion.id_condicion.ToString + "'"
            Else
                sqlstr = "UPDATE condiciones SET condicion = '" + condicion.condicion + "', vencimiento = '" + condicion.vencimiento.ToString +
                            "', recargo = '" + condicion.recargo.ToString + "', activo = '" + condicion.activo.ToString + _
                            "', id_tarjeta = '" + condicion.id_tarjeta.ToString + "' " +
                            " WHERE id_condicion = '" + condicion.id_condicion.ToString + "'"
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

    Public Function borrarCondicion(condicion As condicion) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim sqlstr As String = ""
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE FROM condiciones WHERE id_condicion = '" + condicion.id_condicion.ToString + "'"
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
    ' ************************************ FUNCIONES DE CONDICIONES DE VENTA **********************
End Module
