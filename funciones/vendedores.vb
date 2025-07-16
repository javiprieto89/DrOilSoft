Imports System.Data.SqlClient

Module vendedores
    ' ************************************ FUNCIONES DE VENDEDORES ***************************
    Public Function info_vendedor(ByVal id_vendedor As Integer) As vendedor
        Dim tmp As New vendedor
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = "SELECT * FROM vendedores WHERE id_vendedor = '" + id_vendedor.ToString + "'"
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")
            tmp.id_vendedor = dataset.Tables("tabla").Rows(0).Item(0).ToString
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

    Public Function addVendedor(ByVal v As vendedor) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String

        sqlstr = "INSERT INTO vendedores (nombre, porcentaje, activo) VALUES ('" + v.nombre + "', '" + v.porcentaje.ToString + "', '" + v.activo.ToString + "')"

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

    Public Function updateVendedor(ByVal v As vendedor, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim sqlstr As String
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                sqlstr = "UPDATE vendedores SET activo = '0' WHERE id_vendedor = '" + v.id_vendedor.ToString + "'"
            Else
                sqlstr = "UPDATE vendedores SET nombre = '" + v.nombre + "', porcentaje = '" + v.porcentaje.ToString + "', activo = '" + v.activo.ToString + "'" _
                                             + " WHERE id_vendedor = '" + v.id_vendedor.ToString + "'"
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

    Public Function borrarVendedor(ByVal v As vendedor) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlCommand("DELETE FROM vendedores WHERE id_vendedor = '" + v.id_vendedor.ToString + "'", CN)
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
    ' ************************************ FUNCIONES DE VENDEDORES ***************************
End Module
