Imports System.Data.SqlClient

Module marcasautos
    ' ************************************ FUNCIONES DE MARCAS DE AUTOS ********************
    Public Function info_marcaa(ByVal id_marca As String) As marca_auto
        Dim tmp As New marca_auto
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = "SELECT * FROM marcas_autos WHERE id_marca = '" + id_marca + "'"
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")
            tmp.id_marca = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.marca = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(2).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.marca = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addmarcaa(marcaa As marca_auto) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlCommand("INSERT INTO marcas_autos (marca, activo) VALUES ('" + marcaa.marca + "', '" + marcaa.activo.ToString + "')", CN)

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

    Public Function updatemarcaa(marcaa As marca_auto, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                Comando = New SqlCommand("UPDATE marcas_autos SET activo = '0' WHERE id_marca = '" + marcaa.id_marca.ToString + "'", CN)
            Else
                Comando = New SqlCommand("UPDATE marcas_autos SET marca = '" + marcaa.marca + "', activo = '" + marcaa.activo.ToString +
                                               "' WHERE id_marca = '" + marcaa.id_marca.ToString + "'", CN)
            End If

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

    Public Function borrarmarcaa(marcaa As marca_auto) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlCommand("DELETE FROM marcas_autos WHERE id_marca = '" + marcaa.id_marca.ToString + "'", CN)
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
    ' ************************************ FUNCIONES DE MARCAS DE AUTOS ********************
End Module
