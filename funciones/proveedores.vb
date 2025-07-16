Imports System.Data.SqlClient

Module proveedores
    ' ************************************ FUNCIONES DE PROVEEDORES **************************
    Public Function info_proveedor(ByVal id_proveedor As Integer) As proveedor
        Dim tmp As New proveedor
        Dim sqlstr As String

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            sqlstr = "SELECT * FROM proveedores WHERE id_proveedor = '" + id_proveedor.ToString + "'"
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
            tmp.id_proveedor = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.dni = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.nombre = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.telefono = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.email = dataset.Tables("tabla").Rows(0).Item(4).ToString
            tmp.direccion = dataset.Tables("tabla").Rows(0).Item(5).ToString
            tmp.vendedor = dataset.Tables("tabla").Rows(0).Item(6).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(7).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.nombre = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addproveedor(p As proveedor) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        sqlstr = "INSERT INTO proveedores (dni, nombre, telefono, email, direccion, vendedor, activo) VALUES ('" + p.dni + "', '" + p.nombre _
                                        + "', '" + p.telefono + "', '" + p.email + "', '" + p.direccion + "', '" + p.vendedor + "', '" + p.activo.ToString + "')"
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

    Public Function updateproveedor(p As proveedor, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                sqlstr = "UPDATE proveedores SET activo = '0' WHERE id_proveedor = '" + p.id_proveedor.ToString + "'"
            Else
                sqlstr = "UPDATE proveedores SET dni = '" + p.dni + "', nombre = '" + p.nombre + "', telefono = '" _
                                               + p.telefono + "', email = '" + p.email + "', direccion = '" + p.direccion + "', vendedor = '" + p.vendedor + "', activo = '" + p.activo.ToString +
                                               "' WHERE id_proveedor = '" + p.id_proveedor.ToString + "'"
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

    Public Function borrarproveedor(p As proveedor) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        sqlstr = "DELETE FROM proveedores WHERE id_proveedor = '" + p.id_proveedor.ToString + "'"

        Try
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

    Public Function existeproveedor(ByVal n As String) As Integer
        Dim tmp As New proveedor

        Dim sqlstr As String
        sqlstr = "SELECT id_proveedor FROM proveedores WHERE nombre LIKE '%" + Trim(n.ToString) + "%'"

        Try
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
            tmp.id_proveedor = dataset.Tables("tabla").Rows(0).Item(0).ToString
            If tmp.id_proveedor = 0 Then Return -1
            cerrardb()
            Return tmp.id_proveedor
        Catch ex As Exception
            'tmp.nombre = "error"
            cerrardb()
            Return -1
        End Try
    End Function
    ' ************************************ FUNCIONES DE PROVEEDORES **************************
End Module
