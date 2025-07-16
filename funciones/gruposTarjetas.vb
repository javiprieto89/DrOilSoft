Imports System.Data.SqlClient

Module gruposTarjetas
    ' ************************************ FUNCIONES DE CAJAS ********************
    Public Function info_grupoTarjetas(ByVal id_grupo As String) As grupoTarjetas
        Dim tmp As New grupoTarjetas
        Dim sqlstr As String

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            sqlstr = "SELECT id_grupo, grupo FROM grupo_tarjetas WHERE id_grupo = '" + id_grupo + "'"

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
            tmp.id_grupo = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.grupo = dataset.Tables("tabla").Rows(0).Item(1).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.grupo = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addGrupoTarjetas(ByVal g As grupoTarjetas) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "INSERT INTO grupo_tarjetas (grupo) VALUES ('" + g.grupo + "')"

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

    Public Function updateGrupoTarjetas(ByVal g As grupoTarjetas, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "UPDATE grupo_tarjetas SET grupo = '" + g.grupo + "' WHERE id_grupo = '" + g.id_grupo.ToString + "'"

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

    Public Function borrarGrupoTarjetas(ByVal g As grupoTarjetas) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE FROM grupo_tarjetas WHERE id_grupo = '" + g.id_grupo.ToString + "'"

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
    ' ************************************ FUNCIONES DE CAJAS ********************
End Module
