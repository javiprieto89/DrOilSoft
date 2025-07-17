Imports System.Data.SqlClient

Module autos
    ' ************************************ FUNCIONES DE AUTOS ***************************
    Public Function info_auto(Optional ByVal id_auto As String = "0", Optional ByVal patente As String = "") As auto
        Dim tmp As New auto
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = "SELECT * FROM autos WHERE id_auto = '" + id_auto + "' OR patente = '" + patente + "'"
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")
            tmp.id_auto = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.patente = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.anio = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.id_modelo = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.id_cliente = dataset.Tables("tabla").Rows(0).Item(4).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(5).ToString
            tmp.deudor = dataset.Tables("tabla").Rows(0).Item(6).ToString
            tmp.id_descuento = dataset.Tables("tabla").Rows(0).Item(7).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            tmp.patente = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addauto(a As auto) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String

        sqlstr = "INSERT INTO autos (patente, anio, id_modelo, id_cliente, activo, deudor, id_descuento) VALUES ('" + a.patente + "', '" + a.anio.ToString + "', '" _
                                               + a.id_modelo.ToString + "', '" + a.id_cliente.ToString + "', '" + a.activo.ToString + "', '" + a.deudor.ToString + "', '" + a.id_descuento.ToString + "')"

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

    Public Function updateauto(a As auto, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim sqlstr As String
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                sqlstr = "UPDATE autos SET activo = '0' WHERE id_auto = '" + a.id_auto.ToString + "'"
            Else
                sqlstr = "UPDATE autos SET patente = '" + a.patente + "', anio = '" + a.anio.ToString + "', id_modelo = '" + a.id_modelo.ToString + "', id_cliente = '" _
                                              + a.id_cliente.ToString + "', activo = '" + a.activo.ToString + "', deudor = '" + a.deudor.ToString + "', id_descuento = '" + a.id_descuento.ToString +
                                             "' WHERE id_auto = '" + a.id_auto.ToString + "'"
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

    Public Function borrarauto(a As auto) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlCommand("DELETE FROM autos WHERE id_auto = '" + a.id_auto.ToString + "'", CN)
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

    Public Sub autosConDeuda(ByVal lsview As ListView, ByVal clr As Color)
        Dim i As Integer
        Dim x As Integer = 0
        'Dim deudores(lsview.Items.Count) As Integer
        For i = 0 To lsview.Items.Count - 1
            If lsview.Items(i).SubItems(8).Text.ToString = "Si" Then
                'If info_auto(lsview.Items(i).SubItems(0).Text.ToString).deudor Then
                lsview.Items(i).SubItems(0).BackColor = clr
                lsview.Items(i).SubItems(0).Font = New Font(lsview.Items(i).SubItems(4).Font, FontStyle.Bold)
            End If
        Next
        lsview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        lsview.Refresh()
    End Sub

    Public Sub autosConDeudaDG(ByVal dg As DataGridView, ByVal clr As Color)
        For Each row As DataGridViewRow In dg.Rows
            If row.Cells(8).Value.ToString() = "Si" Then
                row.Cells(0).Style.BackColor = clr
                row.Cells(0).Style.Font = New Font(dg.Font, FontStyle.Bold)
            End If
        Next
    End Sub

    Public Function existeAuto(ByVal p As String) As Integer
        Dim tmp As New auto

        Dim sqlstr As String
        sqlstr = "SELECT id_auto FROM autos WHERE patente = '" + Trim(p.ToString) + "'"

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
            tmp.id_auto = dataset.Tables("tabla").Rows(0).Item(0).ToString
            If tmp.id_auto = 0 Then
                cerrardb()
                Return -1
            End If
            cerrardb()
            Return tmp.id_auto
        Catch ex As Exception
            tmp.patente = "error"
            cerrardb()
            Return -1
        End Try
    End Function

    Public Function existeAuto(ByVal id_auto As Integer) As Boolean
        Dim tmp As New auto

        Dim sqlstr As String
        sqlstr = "SELECT id_auto FROM autos WHERE id_auto = '" + id_auto.ToString + "'"

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
            tmp.id_auto = dataset.Tables("tabla").Rows(0).Item(0).ToString
            If tmp.id_auto = 0 Then
                cerrardb()
                Return False
            End If
            cerrardb()
            Return True
        Catch ex As Exception
            tmp.patente = "error"
            cerrardb()
            Return False
        End Try
    End Function
    ' ************************************ FUNCIONES DE AUTOS ***************************
End Module
