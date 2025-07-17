'funciones/stock.vb
Imports System.Data
Imports System.Data.SqlClient

Module stock
    ' ************************************ FUNCIONES DE STOCK ***************************
    Public Function info_registro_stock(ByVal id_rs As Integer) As registro_stock
        Dim tmp As New registro_stock
        Dim sqlstr As String = "SELECT * FROM registros_stock WHERE id_registro = '" & id_rs.ToString & "'"
        Dim dt As DataTable = GetDataTable(sqlstr)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_registro = .Item(0).ToString
                tmp.id_ingreso = .Item(1).ToString
                tmp.fecha = .Item(2).ToString
                tmp.fecha_ingreso = .Item(3).ToString
                tmp.factura = .Item(4).ToString
                tmp.id_proveedor = .Item(6).ToString
                tmp.id_item = .Item(7).ToString
                tmp.cantidad = .Item(8).ToString
                tmp.costo = .Item(9).ToString
                tmp.precio_lista = .Item(10).ToString
                tmp.markup = .Item(11).ToString
                tmp.descuento = .Item(12).ToString
                tmp.id_iva = .Item(13).ToString
                tmp.cantidad_anterior = .Item(14).ToString
                tmp.costo_anterior = .Item(15).ToString
                tmp.precio_lista_anterior = .Item(16).ToString
                tmp.markup_anterior = .Item(17).ToString
                tmp.descuento_anterior = .Item(18).ToString
                tmp.id_iva_anterior = .Item(19).ToString
                tmp.nota = .Item(20).ToString
                tmp.activo = .Item(21).ToString
                tmp.checkStock = .Item(22).ToString
                tmp.stockRepo = .Item(23).ToString
                tmp.checkStock_anterior = .Item(24).ToString
                tmp.stockRepo_anterior = .Item(25).ToString
            End With
        End If
        Return tmp
    End Function

    Public Function info_registro_stocktmp(ByVal id_rs As Integer) As registro_stock
        Dim tmp As New registro_stock
        Dim sqlstr As String = "SELECT * FROM tmpregistros_stock WHERE id_registrotmp = '" & id_rs.ToString & "'"
        Dim dt As DataTable = GetDataTable(sqlstr)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_registro = .Item(0).ToString
                tmp.id_ingreso = .Item(1).ToString
                tmp.fecha = .Item(2).ToString
                tmp.fecha_ingreso = .Item(3).ToString
                tmp.factura = .Item(4).ToString
                tmp.id_proveedor = .Item(6).ToString
                tmp.id_item = .Item(7).ToString
                tmp.cantidad = .Item(8).ToString
                tmp.costo = .Item(9).ToString
                tmp.precio_lista = .Item(10).ToString
                tmp.markup = .Item(11).ToString
                tmp.descuento = .Item(12).ToString
                tmp.id_iva = .Item(13).ToString
                tmp.cantidad_anterior = .Item(14).ToString
                tmp.costo_anterior = .Item(15).ToString
                tmp.precio_lista_anterior = .Item(16).ToString
                tmp.markup_anterior = .Item(17).ToString
                tmp.descuento_anterior = .Item(18).ToString
                tmp.id_iva_anterior = .Item(19).ToString
                tmp.nota = .Item(20).ToString
                tmp.activo = .Item(21).ToString
                tmp.checkStock = .Item(22).ToString
                tmp.stockRepo = .Item(23).ToString
                tmp.checkStock_anterior = .Item(24).ToString
                tmp.stockRepo_anterior = .Item(25).ToString
            End With
        End If
        Return tmp
    End Function

    Public Function addstocktmp(ByVal rs As registro_stock) As Boolean
        Dim sqlstr As String = "SET DATEFORMAT dmy; INSERT INTO tmpregistros_stock (fecha, factura, id_proveedor, id_item, cantidad, costo, precio_lista, markup, descuento, id_iva, cantidad_anterior, " &
                "costo_anterior, precio_lista_anterior, markup_anterior, descuento_anterior, id_iva_anterior, nota, checkStock, stockRepo, checkStock_anterior, stockRepo_anterior) " &
                "VALUES ('" & rs.fecha.ToString & "', '" & rs.factura.ToString & "', '" & rs.id_proveedor.ToString & "', '" & rs.id_item.ToString & "', '" & rs.cantidad.ToString & "', '" & rs.costo.ToString & "', '" &
                rs.precio_lista.ToString & "', '" & rs.markup.ToString & "', '" & rs.descuento.ToString & "', '" & rs.id_iva.ToString & "', '" & rs.cantidad_anterior.ToString & "', '" & rs.costo_anterior.ToString & "', '" &
                rs.precio_lista_anterior.ToString & "', '" & rs.markup_anterior.ToString & "', '" & rs.descuento_anterior.ToString & "', '" & rs.id_iva_anterior.ToString & "', '" & rs.nota & "', '" &
                rs.checkStock.ToString & "', '" & rs.stockRepo.ToString & "', '" & rs.checkStock_anterior.ToString & "', '" & rs.stockRepo_anterior.ToString & "')"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function updatestocktmp(ByVal rs As registro_stock) As Boolean
        Dim sqlstr As String = "SET DATEFORMAT dmy; UPDATE tmpregistros_stock SET fecha = '" & rs.fecha.ToString & "', factura = '" & rs.factura.ToString & "', id_proveedor = '" & rs.id_proveedor.ToString & "', " &
                "id_item = '" & rs.id_item.ToString & "', cantidad = '" & rs.cantidad.ToString & "', costo = '" & rs.costo.ToString & "', precio_lista = '" & rs.precio_lista.ToString & "', " &
                "markup = '" & rs.markup.ToString & "', descuento = '" & rs.descuento.ToString & "', id_iva = '" & rs.id_iva.ToString & "', nota = '" & rs.nota & "', " &
                "checkStock = '" & rs.checkStock.ToString & "', stockRepo = '" & rs.stockRepo.ToString & "', checkStock_anterior = '" & rs.checkStock_anterior.ToString & "', stockRepo_anterior = '" & rs.stockRepo_anterior.ToString & "' " &
                "WHERE id_registrotmp = '" & rs.id_registro.ToString & "'"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function addstock() As Boolean
        Dim sqlstr As String = "SET DATEFORMAT dmy; INSERT INTO registros_stock (id_ingreso, fecha, factura, id_proveedor, id_item, cantidad, costo, precio_lista, markup, descuento, id_iva, " &
                        "cantidad_anterior, costo_anterior, precio_lista_anterior, markup_anterior, descuento_anterior, id_iva_anterior, nota, checkStock, stockRepo, checkStock_anterior, stockRepo_anterior) " &
                        "SELECT id_ingreso, fecha, factura, id_proveedor, id_item, cantidad, costo, precio_lista, markup, descuento, id_iva, cantidad_anterior, " &
                        "costo_anterior, precio_lista_anterior, markup_anterior, descuento_anterior, id_iva_anterior, nota, checkStock, stockRepo, checkStock_anterior, stockRepo_anterior " &
                        "FROM tmpregistros_stock"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function borraritemregistrostocktmp(rs As registro_stock) As Boolean
        Dim sqlstr As String = "DELETE FROM tmpregistros_stock WHERE id_registrotmp = '" & rs.id_registro.ToString & "'"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Sub archivaringresostock()
        Dim sqlstr As String = "UPDATE registros_stock SET activo = 0 WHERE fecha_ingreso <> CONVERT (date, SYSDATETIME())"
        ExecuteNonQuery(sqlstr)
    End Sub
    ' ************************************ FUNCIONES DE STOCK ***************************
End Module
