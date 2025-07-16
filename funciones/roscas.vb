Imports System.Data.SqlClient

Module roscas
    ' ************************************ FUNCIONES DE MARCAS DE AUTOS ********************
    Public Function info_rosca(ByVal id_rosca As String) As rosca
        Dim tmp As New rosca
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = "SELECT * FROM roscas WHERE id_rosca = '" + id_rosca + "'"
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")
            tmp.id_rosca = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.rosca = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(2).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.rosca = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addrosca(r As rosca) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlCommand("INSERT INTO roscas (rosca, activo) VALUES ('" + r.rosca + "', '" + r.activo.ToString + "')", CN)

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

    Public Function updaterosca(r As rosca, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                Comando = New SqlCommand("UPDATE roscas SET activo = '0' WHERE id_rosca = '" + r.id_rosca.ToString + "'", CN)
            Else
                Comando = New SqlCommand("UPDATE roscas SET rosca = '" + r.rosca + "', activo = '" + r.activo.ToString + _
                                               "' WHERE id_rosca = '" + r.id_rosca.ToString + "'", CN)
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

    Public Function borrarrosca(r As rosca) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlCommand("DELETE FROM roscas WHERE id_rosca = '" + r.id_rosca.ToString + "'", CN)
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
