Imports System.Data.SqlClient

Module modelosautos
    ' ************************************ FUNCIONES DE MODELOS DE AUTOS ********************
    Public Function info_modeloa(ByVal id_modelo As String) As modelo_auto
        Dim tmp As New modelo_auto
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = "SELECT * FROM modelosa WHERE id_modelo = '" + id_modelo + "'"
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")
            tmp.id_modelo = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.modelo = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.id_marca = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(3).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addmodeloa(ByVal modelo As modelo_auto) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlCommand("INSERT INTO modelosa (modelo, id_marca_modelo, activo) VALUES ('" + modelo.modelo + "', '" + CType(modelo.id_marca, String) +
            "', '" + modelo.activo.ToString + "')", CN)

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

    Public Function updatemodeloa(ByVal modelo As modelo_auto, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                sqlstr = "UPDATE modelosa SET activo = '0' WHERE id_modelo = '" + modelo.id_modelo.ToString + "'"
            Else
                sqlstr = "UPDATE modelosa SET modelo = '" + modelo.modelo + "', id_marca_modelo = '" + modelo.id_marca.ToString + "', activo = '" + modelo.activo.ToString _
                            + "' WHERE id_modelo = '" + modelo.id_modelo.ToString + "'"
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

    Public Function borrarmodeloa(modelo As modelo_auto) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlCommand("DELETE FROM modelosa WHERE id_modelo = '" + modelo.id_modelo.ToString + "'", CN)
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
    ' ************************************ FUNCIONES DE MODELOS DE AUTOS ********************
End Module
