Imports System.Data
Imports System.Data.SqlClient

Module stock
    ' ************************************ FUNCIONES DE STOCK ***************************
    Public Function info_registro_stock(ByVal id_rs As Integer) As registro_stock
        Dim tmp As New registro_stock
        Dim sqlstr As String

        sqlstr = "SELECT * FROM registros_stock WHERE id_registro = '" + id_rs.ToString + "'"
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
            tmp.id_registro = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.id_ingreso = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.fecha = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.fecha_ingreso = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.factura = dataset.Tables("tabla").Rows(0).Item(4).ToString
            'tmp.archivofc = dataset.Tables("tabla").Rows(0).Item(5).ToString
            tmp.id_proveedor = dataset.Tables("tabla").Rows(0).Item(6).ToString
            tmp.id_item = dataset.Tables("tabla").Rows(0).Item(7).ToString
            tmp.cantidad = dataset.Tables("tabla").Rows(0).Item(8).ToString
            tmp.costo = dataset.Tables("tabla").Rows(0).Item(9).ToString
            tmp.precio_lista = dataset.Tables("tabla").Rows(0).Item(10).ToString
            tmp.markup = dataset.Tables("tabla").Rows(0).Item(11).ToString
            tmp.descuento = dataset.Tables("tabla").Rows(0).Item(12).ToString
            tmp.id_iva = dataset.Tables("tabla").Rows(0).Item(13).ToString
            tmp.cantidad_anterior = dataset.Tables("tabla").Rows(0).Item(14).ToString
            tmp.costo_anterior = dataset.Tables("tabla").Rows(0).Item(15).ToString
            tmp.precio_lista_anterior = dataset.Tables("tabla").Rows(0).Item(16).ToString
            tmp.markup_anterior = dataset.Tables("tabla").Rows(0).Item(17).ToString
            tmp.descuento_anterior = dataset.Tables("tabla").Rows(0).Item(18).ToString
            tmp.id_iva_anterior = dataset.Tables("tabla").Rows(0).Item(19).ToString
            tmp.nota = dataset.Tables("tabla").Rows(0).Item(20).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(21).ToString
            tmp.checkStock = dataset.Tables("tabla").Rows(0).Item(22).ToString
            tmp.stockRepo = dataset.Tables("tabla").Rows(0).Item(23).ToString
            tmp.checkStock_anterior = dataset.Tables("tabla").Rows(0).Item(24).ToString
            tmp.stockRepo_anterior = dataset.Tables("tabla").Rows(0).Item(25).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function info_registro_stocktmp(ByVal id_rs As Integer) As registro_stock
        Dim tmp As New registro_stock
        Dim sqlstr As String

        sqlstr = "SELECT * FROM tmpregistros_stock WHERE id_registrotmp = '" + id_rs.ToString + "'"
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
            tmp.id_registro = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.id_ingreso = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.fecha = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.fecha_ingreso = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.factura = dataset.Tables("tabla").Rows(0).Item(4).ToString
            'tmp.archivofc = dataset.Tables("tabla").Rows(0).Item(5).ToString
            tmp.id_proveedor = dataset.Tables("tabla").Rows(0).Item(6).ToString
            tmp.id_item = dataset.Tables("tabla").Rows(0).Item(7).ToString
            tmp.cantidad = dataset.Tables("tabla").Rows(0).Item(8).ToString
            tmp.costo = dataset.Tables("tabla").Rows(0).Item(9).ToString
            tmp.precio_lista = dataset.Tables("tabla").Rows(0).Item(10).ToString
            tmp.markup = dataset.Tables("tabla").Rows(0).Item(11).ToString
            tmp.descuento = dataset.Tables("tabla").Rows(0).Item(12).ToString
            tmp.id_iva = dataset.Tables("tabla").Rows(0).Item(13).ToString
            tmp.cantidad_anterior = dataset.Tables("tabla").Rows(0).Item(14).ToString
            tmp.costo_anterior = dataset.Tables("tabla").Rows(0).Item(15).ToString
            tmp.precio_lista_anterior = dataset.Tables("tabla").Rows(0).Item(16).ToString
            tmp.markup_anterior = dataset.Tables("tabla").Rows(0).Item(17).ToString
            tmp.descuento_anterior = dataset.Tables("tabla").Rows(0).Item(18).ToString
            tmp.id_iva_anterior = dataset.Tables("tabla").Rows(0).Item(19).ToString
            tmp.nota = dataset.Tables("tabla").Rows(0).Item(20).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(21).ToString
            tmp.checkStock = dataset.Tables("tabla").Rows(0).Item(22).ToString
            tmp.stockRepo = dataset.Tables("tabla").Rows(0).Item(23).ToString
            tmp.checkStock_anterior = dataset.Tables("tabla").Rows(0).Item(24).ToString
            tmp.stockRepo_anterior = dataset.Tables("tabla").Rows(0).Item(25).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addstocktmp(ByVal rs As registro_stock) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "SET DATEFORMAT dmy; INSERT INTO tmpregistros_stock (fecha, factura, id_proveedor, id_item, cantidad, costo, precio_lista, markup, descuento, id_iva, cantidad_anterior, " &
                "costo_anterior, precio_lista_anterior, markup_anterior, descuento_anterior, id_iva_anterior, nota, checkStock, stockRepo, checkStock_anterior, stockRepo_anterior) " &
                "VALUES ('" + rs.fecha.ToString + "', '" + rs.factura.ToString + "', '" + rs.id_proveedor.ToString + "', '" + rs.id_item.ToString + "', '" + rs.cantidad.ToString + "', '" + rs.costo.ToString + "', '" &
                rs.precio_lista.ToString + "', '" + rs.markup.ToString + "', '" + rs.descuento.ToString + "', '" + rs.id_iva.ToString + "', '" + rs.cantidad_anterior.ToString + "', '" + rs.costo_anterior.ToString + "', '" &
                rs.precio_lista_anterior.ToString + "', '" + rs.markup_anterior.ToString + "', '" + rs.descuento_anterior.ToString + "', '" + rs.id_iva_anterior.ToString + "', '" + rs.nota + "', '" &
                rs.checkStock.ToString + "', '" + rs.stockRepo.ToString + "', '" + rs.checkStock_anterior.ToString + "', '" + rs.stockRepo_anterior.ToString + "')"

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

    Public Function updatestocktmp(ByVal rs As registro_stock) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        sqlstr = "SET DATEFORMAT dmy; UPDATE tmpregistros_stock SET fecha = '" + rs.fecha.ToString + "', factura = '" + rs.factura.ToString + "', id_proveedor = '" + rs.id_proveedor.ToString + "', " &
                "id_item = '" + rs.id_item.ToString + "', cantidad = '" + rs.cantidad.ToString + "', costo = '" + rs.costo.ToString + "', precio_lista = '" + rs.precio_lista.ToString + "', " &
                "markup = '" + rs.markup.ToString + "', descuento = '" + rs.descuento.ToString + "', id_iva = '" + rs.id_iva.ToString + "', nota = '" + rs.nota + "', " &
                "checkStock = '" + rs.checkStock.ToString + "', stockRepo = '" + rs.stockRepo.ToString + "', checkStock_anterior = '" + rs.checkStock_anterior.ToString + "', stockRepo_anterior = '" + rs.stockRepo_anterior.ToString + "' " &
                "WHERE id_registrotmp = '" + rs.id_registro.ToString + "'"

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

    Public Function addstock() As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "SET DATEFORMAT dmy; INSERT INTO registros_stock (id_ingreso, fecha, factura, id_proveedor, id_item, cantidad, costo, precio_lista, markup, descuento, id_iva, " &
                        "cantidad_anterior, costo_anterior, precio_lista_anterior, markup_anterior, descuento_anterior, id_iva_anterior, nota, checkStock, stockRepo, checkStock_anterior, stockRepo_anterior) " &
                        "SELECT id_ingreso, fecha, factura, id_proveedor, id_item, cantidad, costo, precio_lista, markup, descuento, id_iva, cantidad_anterior, " &
                        "costo_anterior, precio_lista_anterior, markup_anterior, descuento_anterior, id_iva_anterior, nota, checkStock, stockRepo, checkStock_anterior, stockRepo_anterior " &
                        "FROM tmpregistros_stock"

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

    Public Function borraritemregistrostocktmp(rs As registro_stock) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlCommand("DELETE FROM tmpregistros_stock WHERE id_registrotmp = '" + rs.id_registro.ToString + "'", CN)
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

    Public Sub archivaringresostock()
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "UPDATE registros_stock " & _
                        "SET activo = 0 " & _
                        "WHERE fecha_ingreso <> CONVERT (date, SYSDATETIME())"

            Comando = New SqlCommand(sqlstr, CN)

            Comando.Transaction = mytrans
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            cerrardb()
        Catch ex As Exception
            MsgBox(ex.Message)
            cerrardb()
        End Try
    End Sub
    ' ************************************ FUNCIONES DE STOCK ***************************
End Module
