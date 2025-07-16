Imports System.Data.SqlClient

Module descuentos

    ' ************************************ FUNCIONES DE DESCUENTOS **********************
    Public Function info_descuento(ByVal id_descuento) As descuento
        Dim tmp As New descuento

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = "SELECT * FROM descuentos WHERE id_descuento = '" + id_descuento.ToString + "'"
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")
            tmp.id_descuento = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.descript = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.descuento = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.isSystem = dataset.Tables("tabla").Rows(0).Item(4).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            tmp.descript = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addDescuento(descuento As descuento) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim sqlstr As String
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "INSERT INTO descuentos (descripcion, descuento, activo) VALUES ('" + descuento.descript + "', '" + descuento.descuento.ToString + "', '" + descuento.activo.ToString + "')"
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

    Public Function updateDescuento(descuento As descuento, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim sqlstr As String
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                sqlstr = "UPDATE descuentos SET activo = '0' WHERE id_descuento = '" + descuento.id_descuento.ToString + "'"
            Else
                sqlstr = "UPDATE descuentos SET descripcion = '" + descuento.descript + "', descuento = '" + descuento.descuento.ToString + "', activo = '" + descuento.activo.ToString + _
                                                       "' WHERE id_descuento = '" + descuento.id_descuento.ToString + "'"
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

    Public Function borrarDescuento(descuento As descuento) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim sqlstr As String = ""
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE FROM descuentos WHERE id_descuento = '" + descuento.id_descuento.ToString + "'"
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
    ' ************************************ FUNCIONES DE DESCUENTOS **********************
End Module
