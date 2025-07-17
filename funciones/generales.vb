Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel
Imports DROil.clsgenerales
Imports System
Imports System.IO
Imports System.Text
Imports System.Collections

Module generales
    Public CN As New SqlConnection

    '************************************* FUNCIONES GENERALES *****************************
    Public Function abrirdb(server As String, db As String, user As String, password As String) As Boolean
        Try
            CN.ConnectionString = "Server=" + server + ";Database=" + db + ";Uid=" + user + ";Password=" + password
            CN.Open()
            If CN.State = ConnectionState.Open Then Return True Else Return False
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function cerrardb()
        CN.Close()
        If CN.State = ConnectionState.Closed Then Return True Else Return False
    End Function

    Public Sub Cargar_listview(ByRef ListView As ListView, ByVal sql As String, ByVal db As String)
        Try
            'Crea y abre una nueva conexión            
            abrirdb(serversql, db, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = sql
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")

            With ListView
                .Items.Clear()
                .Columns.Clear()
                .View = View.Details
                .GridLines = True
                .FullRowSelect = True
                'Añadir los nombres de columnas
                For i As Integer = 0 To dataset.Tables("tabla").Columns.Count - 1
                    .Columns.Add(dataset.Tables("tabla").Columns(i).Caption)
                Next
            End With

            'Añadir los registros de la tabla
            With dataset.Tables("tabla")
                For i = 0 To .Rows.Count - 1
                    Dim dato As New ListViewItem(.Rows(i).Item(0).ToString)
                    'Recorrer las columnas
                    For j As Integer = 1 To .Columns.Count - 1
                        dato.SubItems.Add(.Rows(i).Item(j).ToString())
                    Next
                    ListView.Items.Add(dato)
                Next
            End With

            cerrardb()
            ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
            'Errores
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
        End Try
    End Sub


    Public Sub Cargar_listview(ByRef ListView As ListView, ByVal sql As String, ByVal db As String, ByVal desde As Integer, ByVal hasta As Integer,
                               ByRef nRegs As Integer, ByRef tPaginas As Integer, ByVal pagina As Integer, ByRef txtnPage As TextBox, ByVal orderCol As ColumnClickEventArgs)
        Try
            'Crea y abre una nueva conexión          
            ListView.BeginUpdate()
            'ListView.Visible = False
            abrirdb(serversql, db, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = sql
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")

            With ListView
                .Items.Clear()
                .Columns.Clear()
                .View = View.Details
                .GridLines = True
                .FullRowSelect = True
                'Añadir los nombres de columnas
                For i As Integer = 0 To dataset.Tables("tabla").Columns.Count - 1
                    .Columns.Add(dataset.Tables("tabla").Columns(i).Caption)
                Next
            End With

            'Añadir los registros de la tabla
            With dataset.Tables("tabla")
                Dim a As Integer = dataset.Tables("tabla").Rows.Count
                If desde > .Rows.Count Then desde = .Rows.Count
                If hasta > .Rows.Count Then hasta = .Rows.Count
                nRegs = .Rows.Count
                tPaginas = Math.Ceiling(nRegs / itXPage)
                txtnPage.Text = pagina & " / " & tPaginas
                If hasta = 0 Then
                    cerrardb()
                    ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
                    If orderCol IsNot Nothing Then ListView.ListViewItemSorter = New ListViewItemComparer(orderCol.Column)
                    'ListView.Visible = True
                    ListView.EndUpdate()
                    Exit Sub
                End If
                'Dim dato As New List(Of ListViewItem)
                For i = desde - 1 To hasta - 1
                    Dim dato As New ListViewItem(.Rows(i).Item(0).ToString)
                    'dato.Add(New ListViewItem(.Rows(i).Item(0).ToString))
                    dato.UseItemStyleForSubItems = False
                    'Recorrer las columnas
                    For j As Integer = 1 To .Columns.Count - 1
                        dato.SubItems.Add(.Rows(i).Item(j).ToString())
                        If tabla = "autos" Then
                            If dataset.Tables("Tabla").Rows(i).Item(8).ToString = "Si" Then
                                dato.SubItems.Item(0).BackColor = Color.Red
                                dato.SubItems.Item(0).Font = New Font(ListView.Font, FontStyle.Bold)
                            End If
                        ElseIf (tabla = "items" Or tabla = "items_full") And j = lightItemCol Then
                            dato.SubItems.Item(j).ForeColor = Color.Red
                            dato.SubItems.Item(j).Font = New Font(ListView.Font, FontStyle.Bold)
                            If tabla = "items" Then
                                If dataset.Tables("Tabla").Rows(i).Item(18).ToString = "Si" Then
                                    If dataset.Tables("Tabla").Rows(i).Item(4) <= dataset.Tables("Tabla").Rows(i).Item(19) Then
                                        dato.SubItems.Item(0).BackColor = clrMinimo
                                        dato.SubItems.Item(0).Font = New Font(ListView.Font, FontStyle.Bold)
                                    End If
                                ElseIf tabla = "items_full" Then
                                    dato.SubItems.Item(lightItemCol).BackColor = Color.Red
                                    dato.SubItems.Item(lightItemCol).Font = New Font(ListView.Font, FontStyle.Bold)
                                End If
                            End If
                        ElseIf tabla = "archivoConsultas" Then
                            ListView.Columns(0).Width = 50
                        ElseIf tabla = "registros_stock" And j = lightRegStock Then
                            dato.SubItems.Item(lightRegStock).BackColor = Color.Red
                            dato.SubItems.Item(lightRegStock).Font = New Font(ListView.Font, FontStyle.Bold)
                        ElseIf tabla = "pedidos" Then
                            If (activo And j = 5) Or (Not activo And j = 6) Then
                                dato.SubItems.Item(j).ForeColor = Color.Red
                                dato.SubItems.Item(j).Font = New Font(ListView.Font, FontStyle.Bold)
                                'ElseIf  Then
                                '   dato.SubItems.Item(j).ForeColor = Color.Red
                                '  dato.SubItems.Item(j).Font = New Font(ListView.Font, FontStyle.Bold)
                            End If
                        ElseIf tabla = "pedidos_hoy" Then
                            If j = 6 Then
                                dato.SubItems.Item(j).ForeColor = Color.Red
                                dato.SubItems.Item(j).Font = New Font(ListView.Font, FontStyle.Bold)
                            End If
                            If dataset.Tables("Tabla").Rows(i).Item(11).ToString = "No" Then
                                dato.SubItems.Item(0).BackColor = Color.Red
                                dato.SubItems.Item(0).Font = New Font(ListView.Font, FontStyle.Bold)
                            End If
                            'dato.SubItems.Item(j).Font = New Font(ListView.Font, FontStyle.Bold)
                            'End If
                        ElseIf tabla = "casos" Or tabla = "casos_hoy" Then
                            If activo And j = 5 Then
                                dato.SubItems.Item(j).ForeColor = Color.Red
                                dato.SubItems.Item(j).Font = New Font(ListView.Font, FontStyle.Bold)
                            ElseIf Not activo And j = 6 Then
                                dato.SubItems.Item(j).ForeColor = Color.Red
                                dato.SubItems.Item(j).Font = New Font(ListView.Font, FontStyle.Bold)
                            End If
                            'CASOS CON DEUDA
                            If dataset.Tables("tabla").Rows(i).Item(15).ToString = "Si" Then
                                dato.SubItems(0).BackColor = Color.Red
                                dato.SubItems(0).Font = New Font(ListView.Font, FontStyle.Bold)
                            End If
                            If tabla = "casos_hoy" Then
                                If dataset.Tables("tabla").Rows(i).Item(13).ToString = "False" Then
                                    dato.SubItems(0).BackColor = Color.Red
                                    dato.SubItems(0).Font = New Font(ListView.Font, FontStyle.Bold)
                                End If
                            End If
                        End If
                    Next
                    ListView.Items.Add(dato)
                Next
            End With

            cerrardb()
            ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
            If orderCol IsNot Nothing Then ListView.ListViewItemSorter = New ListViewItemComparer(orderCol.Column)
            ListView.EndUpdate()
            ListView.Visible = True
            'Errores
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
        End Try
    End Sub

    Public Sub cargar_combo(ByRef combo As ComboBox, ByVal sql As String, ByVal db As String, ByVal displaymember As String, ByVal valuemember As String, Optional ByVal predet As Integer = 0)
        'Crea y abre una nueva conexión
        abrirdb(serversql, db, usuariodb, passdb)

        Dim Dt As DataTable

        Dim Da As New SqlDataAdapter
        Dim Cmd As New SqlCommand
        Try
            With Cmd
                .CommandType = CommandType.Text
                .CommandText = sql
                .Connection = CN
            End With

            Da.SelectCommand = Cmd
            Dt = New DataTable
            Da.Fill(Dt)

            With combo
                .DataSource = Dt
                '.DisplayMember = "marca"
                '.ValueMember = "id_marca"
                .DisplayMember = displaymember
                .ValueMember = valuemember
                .SelectedIndex = predet
            End With
            cerrardb()
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            cerrardb()
        End Try
    End Sub

    Public Function traer_info(ByVal db As String, ByVal sql As String, ByVal pone_columnas As Integer) ' As String
        'Si pone_columnas = 1 Agrega los nombres de las columnas de la base al array
        'Si se pone un argumento distinto a 0 o 1, se presupone q se deben poner las columnas
        If pone_columnas <> 0 And pone_columnas <> 1 Then pone_columnas = 1

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, db, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = sql
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")

            'Las filas guardan los nombres del campo
            'Las columnas guardan la info de cada campo


            Dim cont_columnas, cont_filas As Integer

            cont_columnas = dataset.Tables("tabla").Columns.Count - 1
            cont_filas = dataset.Tables("tabla").Rows.Count - 1 'Filas DE LA BASE DE DATOS que PUEDE SER DISTINTA a la del array que lo contiene

            Dim i, j As Integer
            Dim datos(cont_filas + pone_columnas, cont_columnas) As String 'Más uno SI QUISIERA poner una fila con el nombre de las columnas

            If pone_columnas = 1 Then
                For i = 0 To cont_columnas 'Agrega el nombre de las columnas
                    datos(0, i) = dataset.Tables("tabla").Columns(i).Caption
                Next
            End If

            For i = 0 To cont_filas
                For j = 0 To cont_columnas
                    datos(cont_filas + pone_columnas, j) = dataset.Tables("tabla").Rows(i).Item(j).ToString
                Next
            Next
            cerrardb()
            Return datos
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
            Return False
        End Try
    End Function

    Public Sub closeandupdate(formulario As Form)
        'main.cmb_cat_SelectedIndexChanged(Nothing, Nothing)
        formulario.Dispose()
    End Sub

    Public Function strtoint(ByVal str As String) As Integer
        If str = "" Then
            Return 0
        Else
            Return CInt(str)
        End If
    End Function


    Public Function tablaatmppedidos(ByVal id As Integer, ByVal escaso As Boolean) As Boolean
        'Obtengo el último pedido que se generó

        Dim sql As String

        If id = 0 Then id = info_pedido().id_pedido
        sql = "UPDATE tmppedidos_items " & _
                                            "SET cantidad = src.cantidad " & _
                                            "FROM tmppedidos_items dst " & _
                                            "JOIN pedidos_detalle src " & _
                                            "ON src.id_item = dst.id_item " & _
                                            "WHERE dst.id_pedido = '" + id.ToString + "' " & _
                                            "INSERT tmppedidos_items " & _
                                            "(id_item, cantidad) " & _
                                            "SELECT id_item" & _
                                            ", cantidad, '" + id.ToString + "' " & _
                                            "FROM pedidos_detalle src " & _
                                            "WHERE NOT EXISTS " & _
                                            "( " & _
                                            "SELECT  * " & _
                                            "FROM tmppedidos_items dst " & _
                                            "WHERE src.id_item = dst.id_item)" & _
                                            "AND dst.id_pedido = '" + id.ToString + "'" & _
                                            ")"

        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlCommand(sql, CN)


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

    Public Function valida(ByVal str As String, ByVal t As Integer) As Boolean
        'Está función funciona al revez, como está preparada para asignarse directamente al handled del caracter
        'e.handled = false permite la escritura del caracter, por lo cual si devuelve true, el caracter no se escribirá
        'Todo a EXCEPCIÓN de que se valide una patente, en cuyo caso verificará que se escriban 3 letras y 3 dígitos luego, en ese caso devolverá true
        Dim chr As Char
        If t <> 4 Then
            chr = str
        End If
        Select Case t
            Case Is = 1
                'Solo letras (Nombres, apellidos, etc)
                If Char.IsLetter(chr) Then Return False
            Case Is = 2
                'Validación de teléfonos (Solo números y -)
                If Char.IsDigit(chr) Then Return False
            Case Is = 3
                'Validación de DNI (Solo números)
                If Char.IsDigit(chr) Then Return False
            Case Is = 4
                'Validación de patente (aaa###)
                If Len(str) = 6 Then
                    If Char.IsLetter(Strings.Left(str, 3)) Then
                        If Char.IsNumber(Strings.Right(str, 3)) Then
                            Return True
                        End If
                        Return False
                    End If
                    Return False
                End If
                Return False
        End Select
        If Char.IsControl(chr) Then Return False
        Return True
    End Function

    Public Sub resaltarcolumna(ByRef lsview As ListView, ByVal col As Integer, ByVal clr As Color, Optional ByVal autos As Boolean = False)
        'Coloreo el precio de lista
        Dim i As Integer
        For i = 0 To lsview.Items.Count - 1
            If autos Then
                'If lsview.Items(i).SubItems(11).Text.ToString = "False" Then
                lsview.Items(i).UseItemStyleForSubItems = False
                lsview.Items(i).SubItems(col).ForeColor = clr
                lsview.Items(i).SubItems(col).Font = New Font(lsview.Items(i).SubItems(4).Font, FontStyle.Bold)
                'End If
            Else
                lsview.Items(i).UseItemStyleForSubItems = False
                lsview.Items(i).SubItems(col).ForeColor = clr
                lsview.Items(i).SubItems(col).Font = New Font(lsview.Items(i).SubItems(4).Font, FontStyle.Bold)
            End If
        Next
        lsview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        lsview.Refresh()
    End Sub

    Public Sub resaltarcolumnaDG(ByRef dg As DataGridView, ByVal col As Integer, ByVal clr As Color)
        For Each row As DataGridViewRow In dg.Rows
            row.Cells(col).Style.ForeColor = clr
            row.Cells(col).Style.Font = New Font(dg.Font, FontStyle.Bold)
        Next
    End Sub

    Public Function sqlstrbuscar(ByVal txtsearch As String) As String
        Dim sqlstr As String = ""
        Select Case tabla
            Case "condiciones"
                sqlstr = "SELECT c.id_condicion AS 'ID', c.condicion AS 'Condición', c.vencimiento AS 'Vencimiento (días)', " +
                        "c.recargo AS 'Recargo', t.tarjeta AS 'Tarjeta', CASE WHEN c.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                            "FROM condiciones AS c " &
                            "LEFT JOIN tarjetas AS t ON c.id_tarjeta = t.id_tarjeta " &
                            "WHERE c.activo = '" + activo.ToString + "' AND t.tarjeta = '" + activo.ToString + "' " &
                            "AND (c.id_condicion LIKE '%" + txtsearch + "%' " &
                             "OR c.condicion LIKE '%" + txtsearch + "%' " &
                             "OR c.vencimiento LIKE '%" + txtsearch + "%' " &
                             "OR c.recargo LIKE '%" + txtsearch + "%' " &
                             "OR t.tarjeta LIKE '%" + txtsearch + "%') " &
                            "ORDER BY c.condicion ASC"
            Case "descuentos"
                sqlstr = "SELECT id_descuento AS 'ID', descripcion AS 'Descripción', descuento AS 'Descuento', CASE WHEN activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                            "FROM descuentos " &
                            "WHERE activo = '" + activo.ToString + "' " &
                            "AND (id_descuento LIKE '%" + txtsearch + "%' " &
                             "OR descripcion LIKE '%" + txtsearch + "%' " &
                             "OR descuento LIKE '%" + txtsearch + "%') " &
                            "ORDER BY descripcion ASC"
            Case "clientes"
                sqlstr = "SELECT c.id_cliente AS 'ID', c.dni AS 'DNI', c.nombre AS 'Nombre', c.apellido AS 'Apellido', " &
                        "c.telefono AS 'Teléfono', c.email AS 'Email', c.direccion AS 'Dirección', d.descripcion AS 'Descuento', CASE WHEN c.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                                "FROM clientes AS c " &
                                "INNER JOIN descuentos AS d ON c.id_descuento = d.id_descuento " &
                        "WHERE c.activo = '" + activo.ToString + "' " &
                        "AND (c.id_cliente LIKE '%" + txtsearch + "%' " &
                        "OR c.dni LIKE '%" + txtsearch + "%' " &
                        "OR c.nombre LIKE '%" + txtsearch + "%' " &
                        "OR c.apellido LIKE '%" + txtsearch + "%' " &
                        "OR c.telefono LIKE '%" + txtsearch + "%' " &
                        "OR c.email LIKE '%" + txtsearch + "%' " &
                        "OR c.direccion LIKE '%" + txtsearch + "%' " &
                        "OR d.descripcion LIKE '%" + txtsearch + "%') " &
                        "ORDER BY c.nombre, c.apellido ASC"
            Case Is = "vendedores"
                sqlstr = "SELECT v.id_vendedor AS 'ID', v.nombre AS 'Nombre', v.porcentaje AS 'Porcentaje', CASE WHEN v.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                    "FROM vendedores AS v " &
                    "WHERE v.activo = '" + activo.ToString + "' " &
                    "AND (v.id_vendedor LIKE '%" + txtsearch + "%' " &
                    "OR v.nombre LIKE '%" + txtsearch + "%' " &
                    "OR v.porcentaje LIKE '%" + txtsearch + "%') " &
                    "ORDER BY v.nombre ASC"
            Case Is = "mecanicos"
                sqlstr = "SELECT m.id_mecanico AS 'ID', m.nombre AS 'Nombre', m.porcentaje AS 'Porcentaje', CASE WHEN m.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                    "FROM mecanicos AS m " &
                    "WHERE activo = '" + activo.ToString + "' " &
                    "AND (m.id_mecanico LIKE '%" + txtsearch + "%' " &
                    "OR m.nombre LIKE '%" + txtsearch + "%' " &
                    "OR m.porcentaje LIKE '%" + txtsearch + "%') " &
                    "ORDER BY m.nombre ASC"
            Case Is = "estadosPedidos"
                sqlstr = "SELECT sep.id_PedidoStatus AS 'ID', sep.estado AS 'Estado', CASE WHEN sep.esFin = 1 THEN 'Si' ELSE 'No' END AS '¿Es último estado?' " &
                    "FROM sysEstado_pedidos AS sep " &
                    "WHERE sep.id_PedidoStatus LIKE '%" + txtsearch + "%' " &
                    "OR sep.estado LIKE '%" + txtsearch + "%' " &
                    "OR sep.esFin LIKE '%" + txtsearch + "%' " &
                    "ORDER BY sep.estado ASC"
            Case "marcas_autos"
                sqlstr = "SELECT id_marca AS 'ID', marca AS 'Marca', CASE WHEN activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                        "FROM marcas_autos " &
                        "WHERE activo = '" + activo.ToString + "' " &
                        "AND (id_marca LIKE '%" + txtsearch + "%' " &
                        "OR marca LIKE '%" + txtsearch + "%') " &
                        "ORDER BY marca ASC"
            Case "modelosa"
                sqlstr = "SELECT m.id_modelo AS 'ID', m.modelo AS 'Modelo', ma.marca AS 'Marca', " &
                        "CASE WHEN m.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                        "FROM modelosa AS m " &
                        "LEFT JOIN marcas_autos as ma ON m.id_marca_modelo = ma.id_marca " &
                        "WHERE m.activo = '" + activo.ToString + "' " &
                        "AND (m.id_modelo LIKE '%" + txtsearch + "%' " &
                        "OR m.modelo LIKE '%" + txtsearch + "%' " &
                        "OR ma.marca LIKE '%" + txtsearch + "%') " &
                        "ORDER BY m.modelo, ma.marca ASC"
            Case "autos"
                sqlstr = "SELECT a.id_auto AS 'ID', a.patente AS 'Patente', ma.marca AS 'Marca', mo.modelo AS 'Modelo', a.anio AS 'Año', " &
                                            "c.nombre + ' ' + c.apellido AS 'Cliente', c.telefono AS 'Teléfono', " &
                                            "CASE WHEN a.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo', CASE WHEN a.deudor = 1 THEN 'Si' ELSE 'No' END AS 'Deudor' " &
                                            "FROM autos AS a " &
                                            "LEFT JOIN clientes AS c ON a.id_cliente = c.id_cliente " &
                                            "LEFT JOIN modelosa AS mo ON a.id_modelo = mo.id_modelo " &
                                            "LEFT JOIN marcas_autos AS ma ON mo.id_marca_modelo = ma.id_marca " &
                                            "WHERE a.activo = '" + activo.ToString + "' " &
                                            "AND (a.id_auto LIKE '%" + txtsearch + "%' " &
                                            "OR a.patente LIKE '%" + txtsearch + "%' " &
                                            "OR a.anio LIKE '%" + txtsearch + "%' " &
                                            "OR c.nombre LIKE '%" + txtsearch + "%' " &
                                            "OR mo.modelo LIKE '%" + txtsearch + "%' " &
                                            "OR ma.marca LIKE '%" + txtsearch + "%' " &
                                            "OR c.apellido LIKE '%" + txtsearch + "%') " &
                                            "ORDER BY c.nombre, c.apellido, ma.marca, mo.modelo, a.patente ASC"
            Case "proveedores"
                sqlstr = "SELECT id_proveedor AS 'ID', dni AS 'DNI', nombre AS 'Nombre', telefono AS 'Teléfono', email AS 'Email', " &
                                "direccion AS 'Dirección', vendedor AS 'Vendedor', CASE WHEN activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                                "FROM proveedores " &
                            "WHERE activo = '" + activo.ToString + "' " &
                            "AND (id_proveedor LIKE '%" + txtsearch + "%' " &
                            "OR dni LIKE '%" + txtsearch + "%' " &
                            "OR nombre LIKE '%" + txtsearch + "%' " &
                            "OR telefono LIKE '%" + txtsearch + "%' " &
                            "OR email LIKE '%" + txtsearch + "%' " &
                            "OR direccion LIKE '%" + txtsearch + "%' " &
                            "OR vendedor LIKE '%" + txtsearch + "%') " &
                            "ORDER BY nombre ASC"
            Case "tipos_items"
                sqlstr = "SELECT id_tipo AS 'ID', tipo as 'Categoría', CASE WHEN activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                                "FROM tipos_items " &
                            "WHERE activo = '" + activo.ToString + "' " &
                            "AND (id_tipo LIKE '%" + txtsearch + "%' " &
                            "OR tipo LIKE '%" + txtsearch + "%') " &
                            "ORDER BY tipo ASC"
            Case "marcas_items"
                sqlstr = "SELECT id_marca AS 'ID', marca as 'Marca', CASE WHEN activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                                "FROM marcas_items " &
                            "WHERE activo = '" + activo.ToString + "' " &
                            "AND (id_marca LIKE '%" + txtsearch + "%' " &
                            "OR marca LIKE '%" + txtsearch + "%') " &
                            "ORDER BY marca ASC"
            Case "roscas"
                sqlstr = "SELECT id_rosca AS 'ID', rosca AS 'Rosca', CASE WHEN activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                                 "FROM roscas " &
                             "WHERE activo = '" + activo.ToString + "' " &
                             "AND (id_rosca LIKE '%" + txtsearch + "%' " &
                             "OR rosca LIKE '%" + txtsearch + "%') " &
                             "ORDER BY rosca ASC"
            Case "items"
                sqlstr = "SELECT i.id_item AS 'ID', i.item AS 'Item', m.marca AS 'Marca', i.descript AS 'Descripción', i.cantidad AS 'Cantidad', FORMAT(i.precio_lista, 'C', 'es-ar') AS 'Precio de lista', " &
                            "i.markup AS 'Markup', i.descuento AS 'Descuento', ti.descripcion AS 'I.V.A.', FORMAT(i.costo, 'C', 'es-ar') AS 'Costo', t.tipo AS 'Categoría', " &
                            "i.wega AS 'WEGA', i.fram AS 'FRAM', i.mann AS 'MANN', i.oem AS 'OEM', r.rosca AS 'Rosca', p.nombre AS 'Proveedor', " &
                            "CASE WHEN i.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo', CASE WHEN i.checkStock = 1 THEN 'Si' ELSE 'No' END AS 'Controla Stock', " &
                            "i.stockRepo AS 'Stock de reposición', CASE WHEN i.oferta = 1 THEN 'Si' ELSE 'No' END AS 'Artículo de oferta', i.EAN AS 'EAN', " &
                            "CASE WHEN i.ultima_modificacion IS NULL THEN 'N/A' ELSE CAST(i.ultima_modificacion AS VARCHAR(50)) END AS 'Ult. Mod.' " &
                            "FROM items AS i " &
                            "LEFT JOIN tipos_items AS t ON i.id_tipo = t.id_tipo " &
                            "LEFT JOIN marcas_items AS m ON i.id_marca = m.id_marca " &
                            "LEFT JOIN proveedores AS p ON i.id_proveedor = p.id_proveedor " &
                            "LEFT JOIN roscas AS r ON i.id_rosca = r.id_rosca " &
                            "LEFT JOIN iva AS ti ON i.id_iva = ti.id_iva " &
                            "WHERE i.activo = '" + activo.ToString + "' " &
                            "AND (i.checkStock = 1 AND (i.cantidad <= (i.stockRepo * 2))) " &
                            "AND (i.id_item LIKE '%" + txtsearch + "%' " &
                            "OR i.item LIKE '%" + txtsearch + "%' " &
                            "OR i.EAN LIKE '%" + txtsearch + "%' " &
                            "OR i.ultima_modificacion LIKE '%" + txtsearch + "%' " &
                            "OR i.descript LIKE '%" + txtsearch + "%' " &
                            "OR i.cantidad LIKE '%" + txtsearch + "%' " &
                            "OR i.costo LIKE '%" + txtsearch + "%' " &
                            "OR i.precio_lista LIKE '%" + txtsearch + "%' " &
                            "OR t.tipo LIKE '%" + txtsearch + "%' " &
                            "OR r.rosca LIKE '%" + txtsearch + "%' " &
                            "OR m.marca LIKE '%" + txtsearch + "%' " &
                            "OR p.nombre LIKE '%" + txtsearch + "%' " &
                            "OR i.wega LIKE '%" + txtsearch + "%' " &
                            "OR i.fram LIKE '%" + txtsearch + "%' " &
                            "OR i.mann LIKE '%" + txtsearch + "%' " &
                            "OR i.markup LIKE '%" + txtsearch + "%' " &
                            "OR i.descuento LIKE '%" + txtsearch + "%' " &
                            "OR i.checkStock LIKE '%" + txtsearch + "%' " &
                            "OR i.stockRepo LIKE '%" + txtsearch + "%' " &
                            "OR i.[oem] LIKE '%" + txtsearch + "%' " &
                            "OR i.oferta LIKE '%" + txtsearch + "%' " &
                            "OR ti.descripcion Like '%" + txtsearch + "%') "
                If Not stock0 Then sqlstr += "AND i.cantidad >0 "
                sqlstr += "ORDER BY i.item ASC"
            Case "items_full", "items2", "items_full_presupuesto"
                sqlstr = "SELECT i.id_item AS 'ID', i.item AS 'Item', m.marca AS 'Marca', i.descript AS 'Descripción', i.cantidad AS 'Cantidad', FORMAT(i.precio_lista, 'C', 'es-ar') AS 'Precio de lista', " &
                                    "i.markup AS 'Markup', i.descuento AS 'Descuento', ti.descripcion AS 'I.V.A.', FORMAT(i.costo, 'C', 'es-ar') AS 'Costo', t.tipo AS 'Categoría', " &
                                    "i.wega AS 'WEGA', i.fram AS 'FRAM', i.mann AS 'MANN', i.oem AS 'OEM', r.rosca AS 'Rosca', p.nombre AS 'Proveedor', CASE WHEN i.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo', " &
                                    "CASE WHEN i.checkStock = 1 THEN 'Si' ELSE 'No' END AS 'Controla Stock', i.stockRepo AS 'Stock de reposición', CASE WHEN i.oferta = 1 THEN 'Si' ELSE 'No' END AS 'Artículo de oferta', i.EAN AS 'EAN', " &
                                    "CASE WHEN i.ultima_modificacion IS NULL THEN 'N/A' ELSE CAST(i.ultima_modificacion AS VARCHAR(50)) END AS 'Ult. Mod.' " &
                            "FROM items AS i " &
                            "LEFT JOIN tipos_items AS t ON i.id_tipo = t.id_tipo " &
                            "LEFT JOIN marcas_items AS m ON i.id_marca = m.id_marca " &
                            "LEFT JOIN proveedores AS p ON i.id_proveedor = p.id_proveedor " &
                            "LEFT JOIN roscas AS r ON i.id_rosca = r.id_rosca " &
                            "LEFT JOIN iva AS ti ON i.id_iva = ti.id_iva "
                If tabla = "items2" Then
                    sqlstr += "WHERE i.activo = '1' "
                Else
                    sqlstr += "WHERE i.activo = '" + activo.ToString + "' "
                End If
                sqlstr += "AND (i.id_item LIKE '%" + txtsearch + "%' " &
                            "OR i.item LIKE '%" + txtsearch + "%' " &
                            "OR i.EAN LIKE '%" + txtsearch + "%' " &
                            "OR i.ultima_modificacion LIKE '%" + txtsearch + "%' " &
                            "OR i.descript LIKE '%" + txtsearch + "%' " &
                            "OR i.cantidad LIKE '%" + txtsearch + "%' " &
                            "OR i.costo LIKE '%" + txtsearch + "%' " &
                            "OR i.precio_lista LIKE '%" + txtsearch + "%' " &
                            "OR t.tipo LIKE '%" + txtsearch + "%' " &
                            "OR r.rosca LIKE '%" + txtsearch + "%' " &
                            "OR m.marca LIKE '%" + txtsearch + "%' " &
                            "OR p.nombre LIKE '%" + txtsearch + "%' " &
                            "OR i.wega LIKE '%" + txtsearch + "%' " &
                            "OR i.fram LIKE '%" + txtsearch + "%' " &
                            "OR i.mann LIKE '%" + txtsearch + "%' " &
                            "OR i.markup LIKE '%" + txtsearch + "%' " &
                            "OR i.descuento LIKE '%" + txtsearch + "%' " &
                            "OR i.checkStock LIKE '%" + txtsearch + "%' " &
                            "OR i.stockRepo LIKE '%" + txtsearch + "%' " &
                            "OR i.oem LIKE '%" + txtsearch + "%' " &
                            "OR i.oferta LIKE '%" + txtsearch + "%' " &
                            "OR ti.descripcion LIKE '%" + txtsearch + "%') "
                If Not stock0 Then sqlstr += "AND i.cantidad > 0 "
                ''If Not stock0 Then sqlstr += "AND i.cantidad >0 "
                sqlstr += "ORDER BY i.item ASC"
            Case "tipos_casos"
                sqlstr = "SELECT id_tipo AS 'ID', tipo AS 'Tipo', CASE WHEN activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                                "FROM tipos_casos " &
                            "WHERE activo = '" + activo.ToString + "' " &
                            "AND (id_tipo LIKE '%" + txtsearch + "%' " &
                            "OR tipo LIKE '%" + txtsearch + "%') " &
                            "ORDER BY tipo ASC"
            Case "grupoTarjetas"
                sqlstr = "SELECT g.id_grupo AS 'ID', g.grupo AS 'Grupo de tarjetas' " +
                        "FROM grupo_tarjetas AS g " +
                        "WHERE g.id_grupo LIKE '%" + txtsearch + "%' " +
                        "OR g.grupo LIKE '%" + txtsearch + "%' " +
                        "ORDER BY g.grupo ASC"
            Case "tarjetas"
                sqlstr = "SELECT t.id_tarjeta AS 'ID', t.tarjeta AS 'Nombre', t.recargo AS 'Recargo', t.cuotas AS 'Cuotas', " +
                            "g.grupo AS 'Grupo de tarjetas', CASE WHEN t.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " +
                            "FROM tarjetas AS t " +
                            "LEFT JOIN grupo_tarjetas AS g ON t.id_grupo = g.id_grupo " +
                            "WHERE t.activo = '" + activo.ToString + "' " +
                            "AND (t.id_tarjeta LIKE '%" + txtsearch + "%') " +
                            "OR t.tarjeta LIKE '%" + +txtsearch + "%' " +
                            "OR t.recargo LIKE '%" + +txtsearch + "%' " +
                            "OR t.cuotas LIKE '%" + +txtsearch + "%' " +
                            "OR g.grupo LIKE '%" + +txtsearch + "%') " +
                            "ORDER BY t.tarjeta ASC"
            Case "caja"
                sqlstr = "SELECT c.id_caja AS 'ID', c.nombre AS 'Caja', c.esCC AS 'Es cuenta corriente', CASE WHEN c.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                        "FROM cajas AS c " &
                        "WHERE c.activo = '" + activo.ToString + "' " &
                        "AND (c.id_caja LIKE '%" + txtsearch + "%' " &
                        "OR c.nombre LIKE '%" + txtsearch + "%') " &
                        "ORDER BY c.id_caja ASC"
            Case "archivoconsultas"
                sqlstr = "SELECT c.id_consulta AS 'ID', c.nombre AS 'Nombre', c.consulta AS 'Consulta SQL', CASE WHEN c.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                         "FROM consultas_personalizadas AS c " &
                         "WHERE c.activo = '" + activo.ToString + "' " &
                         "AND (c.id_consulta LIKE '%" + txtsearch + "%' " &
                         "OR c.nombre LIKE '%" + txtsearch + "%' " &
                         "OR c.consulta LIKE '%" + txtsearch + "%') " &
                         "ORDER BY c.id_consulta ASC"
            Case "items_registros_stock"
                sqlstr = "SELECT i.id_item AS 'ID', i.item AS 'Item', i.EAN AS 'EAN', i.descript AS 'Descripción', i.cantidad AS 'Cantidad', FORMAT(i.precio_lista, 'C', 'es-ar') AS 'Precio de lista', " &
                      "i.markup AS 'Markup', i.descuento AS 'Descuento', ti.descripcion AS 'I.V.A.', FORMAT(i.costo, 'C', 'es-ar') AS 'Costo', t.tipo AS 'Categoría', m.marca AS 'Marca', i.wega AS 'WEGA', " &
                      "i.fram AS 'FRAM', i.mann AS 'MANN', i.oem AS 'OEM', r.rosca AS 'Rosca', p.nombre AS 'Proveedor', CASE WHEN i.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo', " &
                      "CASE WHEN i.checkStock = 1 THEN 'Si' ELSE 'No' END AS 'Controla Stock', i.stockRepo AS 'Stock de reposición', CASE WHEN i.oferta = 1 THEN 'Si' ELSE 'No' END AS 'Artículo de oferta' " &
                  "FROM items AS i " &
                  "LEFT JOIN tipos_items AS t ON i.id_tipo = t.id_tipo " &
                  "LEFT JOIN marcas_items AS m ON i.id_marca = m.id_marca " &
                  "LEFT JOIN proveedores AS p ON i.id_proveedor = p.id_proveedor " &
                  "LEFT JOIN roscas AS r ON i.id_rosca = r.id_rosca " &
                  "LEFT JOIN iva AS ti ON i.id_iva = ti.id_iva " &
                  "WHERE i.activo = '" + activo.ToString + "' " &
                  "AND (i.id_item LIKE '%" + txtsearch + "%' " &
                  "OR i.item LIKE '%" + txtsearch + "%' " &
                  "OR i.EAN LIKE '%" + txtsearch + "%' " &
                  "OR i.descript LIKE '%" + txtsearch + "%' " &
                  "OR i.cantidad LIKE '%" + txtsearch + "%' " &
                  "OR i.costo LIKE '%" + txtsearch + "%' " &
                  "OR i.precio_lista LIKE '%" + txtsearch + "%' " &
                  "OR t.tipo LIKE '%" + txtsearch + "%' " &
                  "OR r.rosca LIKE '%" + txtsearch + "%' " &
                  "OR m.marca LIKE '%" + txtsearch + "%' " &
                  "OR p.nombre LIKE '%" + txtsearch + "%' " &
                  "OR i.wega LIKE '%" + txtsearch + "%' " &
                  "OR i.fram LIKE '%" + txtsearch + "%' " &
                  "OR i.mann LIKE '%" + txtsearch + "%' " &
                  "OR i.oem LIKE '%" + txtsearch + "%' " &
                  "OR i.markup LIKE '%" + txtsearch + "%' " &
                  "OR i.descuento LIKE '%" + txtsearch + "%' " &
                  "OR ti.descripcion LIKE '%" + txtsearch + "%') " &
                  "ORDER BY i.item ASC"
            Case "registros_stock"
                sqlstr = "SELECT rs.id_registro AS 'ID', CAST(rs.fecha AS VARCHAR(50)) AS 'Fecha FC', CAST(rs.fecha_ingreso AS VARCHAR(50)) AS 'Fecha ingreso', i.item AS 'Item', i.EAN AS 'EAN', i.descript AS 'Descripción', " &
                            "rs.cantidad AS 'Cantidad', rs.cantidad_anterior AS 'Cantidad anterior', FORMAT(rs.precio_lista, 'C', 'es-ar') AS 'Precio', FORMAT(rs.precio_lista_anterior, 'C', 'es-ar') AS 'Precio anterior', rs.markup AS 'Markup', " &
                            "rs.markup_anterior AS 'Markup anterior', rs.descuento AS 'Descuento', rs.descuento_anterior AS 'Descuento anterior', ti.descripcion AS 'I.V.A', ti.descripcion AS 'I.V.A. anterior'," &
                            "FORMAT(rs.costo, 'C', 'es-ar') AS 'Costo',  FORMAT(rs.costo_anterior, 'C', 'es-ar') AS 'Costo anterior', p.nombre AS 'Proveedor', rs.factura AS 'Factura', rs.nota AS 'Notas', CASE WHEN rs.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                            "FROM registros_stock AS rs " &
                            "LEFT JOIN items AS i ON rs.id_item = i.id_item " &
                            "LEFT JOIN proveedores AS p ON rs.id_proveedor = p.id_proveedor " &
                            "LEFT JOIN iva AS ti ON rs.id_iva = ti.id_iva " &
                            "WHERE rs.activo = '" & activo.ToString & "' " &
                            "AND (rs.id_registro LIKE '%" + txtsearch + "%' " &
                            "OR rs.fecha LIKE '%" + txtsearch + "%' " &
                            "OR rs.fecha_ingreso LIKE '%" + txtsearch + "%' " &
                            "OR i.item LIKE '%" + txtsearch + "%' " &
                            "OR i.EAN LIKE '%" + txtsearch + "%' " &
                            "OR i.descript LIKE '%" + txtsearch + "%' " &
                            "OR rs.cantidad LIKE '%" + txtsearch + "%' " &
                            "OR rs.cantidad_anterior LIKE '%" + txtsearch + "%' " &
                            "OR rs.precio_lista LIKE '%" + txtsearch + "%' " &
                            "OR rs.precio_lista_anterior LIKE '%" + txtsearch + "%' " &
                            "OR rs.markup LIKE '%" + txtsearch + "%' " &
                            "OR rs.markup_anterior LIKE '%" + txtsearch + "%' " &
                            "OR rs.descuento LIKE '%" + txtsearch + "%' " &
                            "OR rs.descuento_anterior LIKE '%" + txtsearch + "%' " &
                            "OR ti.descripcion LIKE '%" + txtsearch + "%' " &
                            "OR rs.costo LIKE '%" + txtsearch + "%' " &
                            "OR rs.costo_anterior LIKE '%" + txtsearch + "%' " &
                            "OR p.nombre LIKE '%" + txtsearch + "%' " &
                            "OR rs.factura LIKE '%" + txtsearch + "%' " &
                            "OR rs.nota LIKE '%" + txtsearch + "%') " &
                            "ORDER BY rs.id_registro DESC"
            Case "casos"
                If activo Then
                    sqlstr = "SELECT c.id_pedido AS 'ID', CAST(c.fecha AS VARCHAR(50)) AS 'Fecha', a.patente AS 'Patente', ma.modelo AS 'Modelo', cn.condicion AS 'Condición de venta', " +
                                    "FORMAT(c.total, 'C', 'es-ar') AS 'Total', FORMAT(c.total - c.montoTarjeta, 'C', 'es-ar') AS 'Monto contado', FORMAT(c.montoTarjeta, 'C', 'es-ar') AS 'Monto tarjeta', " &
                                    "tc.tipo AS 'Tipo', c.km AS 'Kilometraje', c.proximocambio AS 'Próximo cambio', cli.nombre + ' ' + cli.apellido AS 'Cliente', cli.telefono AS 'Teléfono', " &
                                    "d.descripcion AS 'Descuento', ca.nombre AS 'Caja', CASE WHEN a.deudor = 1 THEN 'Si' ELSE 'No' END AS 'Deudor', " &
                                    "v.nombre AS 'Vendedor', m.nombre AS 'Mecánico', sep.estado AS 'Estado caso', CASE WHEN c.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                                    "FROM pedidos AS c " &
                                    "INNER JOIN autos AS a ON c.id_auto = a.id_auto " &
                                    "INNER JOIN modelosa AS ma ON a.id_modelo = ma.id_modelo " &
                                    "INNER JOIN clientes AS cli ON a.id_cliente = cli.id_cliente " &
                                    "INNER JOIN tipos_casos AS tc ON c.id_tipo = tc.id_tipo " &
                                    "INNER JOIN condiciones AS cn ON c.id_condicion = cn.id_condicion " &
                                    "INNER JOIN descuentos AS d ON c.id_descuento = d.id_descuento " &
                                    "INNER JOIN cajas AS ca ON c.id_caja = ca.id_caja " &
                                    "INNER JOIN vendedores AS v ON c.id_vendedor = v.id_vendedor " &
                                    "INNER JOIN mecanicos AS m ON c.id_mecanico = m.id_mecanico " &
                                    "INNER JOIN sysEstado_pedidos AS sep ON c.id_PedidoStatus = sep.id_PedidoStatus " &
                                    "WHERE c.cerrado = '0' AND c.activo = '1' AND c.es_caso = '1' " &
                                    "AND (c.id_pedido LIKE '%" + txtsearch + "%' " &
                                    "OR c.fecha LIKE '%" + txtsearch + "%' " &
                                    "OR tc.tipo LIKE '%" + txtsearch + "%' " &
                                    "OR c.km LIKE '%" + txtsearch + "%' " &
                                    "OR c.proximocambio LIKE '%" + txtsearch + "%' " &
                                    "OR cli.nombre LIKE '%" + txtsearch + "%' " &
                                    "OR cli.apellido LIKE '%" + txtsearch + "%' " &
                                    "OR cli.telefono LIKE '%" + txtsearch + "%' " &
                                    "OR a.patente LIKE '%" + txtsearch + "%' " &
                                    "OR ma.modelo LIKE '%" + txtsearch + "%' " &
                                    "OR c.total LIKE '%" + txtsearch + "%' " &
                                    "OR (c.total - c.montoTarjeta) LIKE '%" + txtsearch + "%' " &
                                    "OR c.montoTarjeta LIKE '%" + txtsearch + "%' " &
                                    "OR cn.condicion LIKE '%" + txtsearch + "%' " &
                                    "OR d.descripcion LIKE '%" + txtsearch + "%' " &
                                    "OR v.nombre LIKE '%" + txtsearch + "%' " &
                                    "OR m.nombre LIKE '%" + txtsearch + "%' " &
                                    "OR sep.estado LIKE '%" + txtsearch + "%' " &
                                    "OR ca.nombre LIKE '%" + txtsearch + "%') " &
                                    "--OR c.litros_usados LIKE '%" + txtsearch + "%' " &
                                    "ORDER BY c.id_pedido ASC"
                Else
                    sqlstr = "SELECT c.id_pedido AS 'ID', CAST(c.fecha AS VARCHAR(50)) AS 'Fecha', CAST(c.fecha_cierre AS VARCHAR(50)) AS 'Fecha de cierre', a.patente AS 'Patente', ma.modelo AS 'Modelo', cn.condicion AS 'Condición de venta', " +
                                    "FORMAT(c.total, 'C', 'es-ar') AS 'Total', FORMAT(c.total - c.montoTarjeta, 'C', 'es-ar') AS 'Monto contado', FORMAT(c.montoTarjeta, 'C', 'es-ar') AS 'Monto tarjeta', " &
                                    "tc.tipo AS 'Tipo', c.km AS 'Kilometraje', c.proximocambio AS 'Próximo cambio', cli.nombre + ' ' + cli.apellido AS 'Cliente', cli.telefono AS 'Teléfono', " &
                                    "d.descripcion AS 'Descuento', ca.nombre AS 'Caja', CASE WHEN a.deudor = 1 THEN 'Si' ELSE 'No' END AS 'Deudor'," &
                                    "v.nombre AS 'Vendedor', m.nombre AS 'Mecánico', sep.estado AS 'Estado caso', CASE WHEN c.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                                    "FROM pedidos AS c " &
                                    "INNER JOIN autos AS a ON c.id_auto = a.id_auto " &
                                    "INNER JOIN modelosa AS ma ON a.id_modelo = ma.id_modelo " &
                                    "INNER JOIN clientes AS cli ON a.id_cliente = cli.id_cliente " &
                                    "INNER JOIN tipos_casos AS tc ON c.id_tipo = tc.id_tipo " &
                                    "INNER JOIN condiciones AS cn ON c.id_condicion = cn.id_condicion " &
                                    "INNER JOIN descuentos AS d ON c.id_descuento = d.id_descuento " &
                                    "INNER JOIN cajas AS ca ON c.id_caja = ca.id_caja " &
                                    "INNER JOIN vendedores AS v ON c.id_vendedor = v.id_vendedor " &
                                    "INNER JOIN mecanicos AS m ON c.id_mecanico = m.id_mecanico " &
                                    "INNER JOIN sysEstado_pedidos AS sep ON c.id_PedidoStatus = sep.id_PedidoStatus " &
                                    "WHERE c.cerrado = '1' AND c.activo = '0' AND c.es_caso = '1' " &
                                    "AND (c.id_pedido LIKE '%" + txtsearch + "%' " &
                                    "OR c.fecha LIKE '%" + txtsearch + "%' " &
                                    "OR tc.tipo LIKE '%" + txtsearch + "%' " &
                                    "OR c.km LIKE '%" + txtsearch + "%' " &
                                    "OR c.proximocambio LIKE '%" + txtsearch + "%' " &
                                    "OR cli.nombre LIKE '%" + txtsearch + "%' " &
                                    "OR cli.apellido LIKE '%" + txtsearch + "%' " &
                                    "OR cli.telefono LIKE '%" + txtsearch + "%' " &
                                    "OR a.patente LIKE '%" + txtsearch + "%' " &
                                    "OR ma.modelo LIKE '%" + txtsearch + "%' " &
                                    "OR c.total LIKE '%" + txtsearch + "%' " &
                                    "OR (c.total - c.montoTarjeta) LIKE '%" + txtsearch + "%' " &
                                    "OR c.montoTarjeta LIKE '%" + txtsearch + "%' " &
                                    "OR cn.condicion LIKE '%" + txtsearch + "%' " &
                                    "OR d.descripcion LIKE '%" + txtsearch + "%' " &
                                    "OR ca.nombre LIKE '%" + txtsearch + "%' " &
                                    "OR v.nombre LIKE '%" + txtsearch + "%' " &
                                    "OR m.nombre LIKE '%" + txtsearch + "%' " &
                                    "OR sep.estado LIKE '%" + txtsearch + "%' " &
                                    "OR c.fecha_cierre LIKE '%" + txtsearch + "%') " &
                                    "--OR c.litros_usados LIKE '%" + txtsearch + "%' " &
                                    "ORDER BY c.id_pedido ASC"
                End If
            Case "casos_hoy"
                If activo Then
                    sqlstr = "SELECT c.id_pedido AS 'ID', CAST(c.fecha AS VARCHAR(50)) AS 'Fecha', a.patente AS 'Patente', ma.modelo AS 'Modelo', cn.condicion AS 'Condición de venta', " +
                                    "FORMAT(c.total, 'C', 'es-ar') AS 'Total', FORMAT(c.total - c.montoTarjeta, 'C', 'es-ar') AS 'Monto contado', FORMAT(c.montoTarjeta, 'C', 'es-ar') AS 'Monto tarjeta', " &
                                    "tc.tipo AS 'Tipo', c.km AS 'Kilometraje', c.proximocambio AS 'Próximo cambio', cli.nombre + ' ' + cli.apellido AS 'Cliente', cli.telefono AS 'Teléfono', " &
                                    "d.descripcion AS 'Descuento', ca.nombre AS 'Caja', CASE WHEN a.deudor = 1 THEN 'Si' ELSE 'No' END AS 'Deudor', " &
                                    "v.nombre AS 'Vendedor', m.nombre AS 'Mecánico', sep.estado AS 'Estado caso', CASE WHEN c.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                                    "FROM pedidos AS c " &
                                    "INNER JOIN autos AS a ON c.id_auto = a.id_auto " &
                                    "INNER JOIN modelosa AS ma ON a.id_modelo = ma.id_modelo " &
                                    "INNER JOIN clientes AS cli ON a.id_cliente = cli.id_cliente " &
                                    "INNER JOIN tipos_casos AS tc ON c.id_tipo = tc.id_tipo " &
                                    "INNER JOIN condiciones AS cn ON c.id_condicion = cn.id_condicion " &
                                    "INNER JOIN descuentos AS d ON c.id_descuento = d.id_descuento " &
                                    "INNER JOIN cajas AS ca ON c.id_caja = ca.id_caja " &
                                    "INNER JOIN vendedores AS v ON c.id_vendedor = v.id_vendedor " &
                                    "INNER JOIN mecanicos AS m ON c.id_mecanico = m.id_mecanico " &
                                    "INNER JOIN sysEstado_pedidos AS sep ON c.id_PedidoStatus = sep.id_PedidoStatus " &
                                    "WHERE c.cerrado = '0' AND c.activo = '1' AND c.es_caso = '1' AND CONVERT(VARCHAR(10), c.fecha, 112) = CONVERT(VARCHAR(10), GETDATE(), 112) " &
                                    "AND (c.id_pedido LIKE '%" + txtsearch + "%' " &
                                    "OR c.fecha LIKE '%" + txtsearch + "%' " &
                                    "OR c.fecha_cierre LIKE '%" + txtsearch + "%' " &
                                    "OR tc.tipo LIKE '%" + txtsearch + "%' " &
                                    "OR c.km LIKE '%" + txtsearch + "%' " &
                                    "OR c.proximocambio LIKE '%" + txtsearch + "%' " &
                                    "OR cli.nombre LIKE '%" + txtsearch + "%' " &
                                    "OR cli.apellido LIKE '%" + txtsearch + "%' " &
                                    "OR cli.telefono LIKE '%" + txtsearch + "%' " &
                                    "OR a.patente LIKE '%" + txtsearch + "%' " &
                                    "OR ma.modelo LIKE '%" + txtsearch + "%' " &
                                    "OR c.total LIKE '%" + txtsearch + "%' " &
                                    "OR (c.total - c.montoTarjeta) LIKE '%" + txtsearch + "%' " &
                                    "OR c.montoTarjeta LIKE '%" + txtsearch + "%' " &
                                    "OR cn.condicion LIKE '%" + txtsearch + "%' " &
                                    "OR d.descripcion LIKE '%" + txtsearch + "%' " &
                                    "OR ca.nombre LIKE '%" + txtsearch + "%') " &
                                    "OR v.nombre LIKE '%" + txtsearch + "%' " &
                                    "OR m.nombre LIKE '%" + txtsearch + "%' " &
                                    "OR sep.estado LIKE '%" + txtsearch + "%' " &
                                    "--OR c.litros_usados LIKE '%" + txtsearch + "%' " &
                                    "ORDER BY c.id_pedido ASC"
                Else
                    sqlstr = "SELECT c.id_pedido AS 'ID', CAST(c.fecha AS VARCHAR(50)) AS 'Fecha', a.patente AS 'Patente', ma.modelo AS 'Modelo', cn.condicion AS 'Condición de venta', " +
                                    "FORMAT(c.total, 'C', 'es-ar') AS 'Total', FORMAT(c.total - c.montoTarjeta, 'C', 'es-ar') AS 'Monto contado', FORMAT(c.montoTarjeta, 'C', 'es-ar') AS 'Monto tarjeta', " &
                                    "tc.tipo AS 'Tipo', c.km AS 'Kilometraje', c.proximocambio AS 'Próximo cambio', cli.nombre + ' ' + cli.apellido AS 'Cliente', cli.telefono AS 'Teléfono', " &
                                    "CASE WHEN c.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo', CASE WHEN a.deudor = 1 THEN 'Si' ELSE 'No' END AS 'Deudor', " &
                                    "v.nombre AS 'Vendedor', m.nombre AS 'Mecánico', sep.estado AS 'Estado caso', ca.nombre AS 'Caja', d.descripcion AS 'Descuento' " &
                                    "FROM pedidos AS c " &
                                    "INNER JOIN autos AS a ON c.id_auto = a.id_auto " &
                                    "INNER JOIN modelosa AS ma ON a.id_modelo = ma.id_modelo " &
                                    "INNER JOIN clientes AS cli ON a.id_cliente = cli.id_cliente " &
                                    "INNER JOIN tipos_casos AS tc ON c.id_tipo = tc.id_tipo " &
                                    "INNER JOIN condiciones AS cn ON c.id_condicion = cn.id_condicion " &
                                    "INNER JOIN descuentos AS d ON p.id_descuento = d.id_descuento " &
                                    "INNER JOIN cajas AS ca ON c.id_caja = ca.id_caja " &
                                    "INNER JOIN vendedores AS v ON c.id_vendedor = v.id_vendedor " &
                                    "INNER JOIN mecanicos AS m ON c.id_mecanico = m.id_mecanico " &
                                    "INNER JOIN sysEstado_pedidos AS sep ON c.id_PedidoStatus = sep.id_PedidoStatus " &
                                    "WHERE c.cerrado = '1' AND c.activo = '0' AND c.es_caso = '1' AND CONVERT(VARCHAR(10), c.fecha, 112) = CONVERT(VARCHAR(10), GETDATE(), 112) " &
                                    "AND (c.id_pedido LIKE '%" + txtsearch + "%' " &
                                    "OR c.fecha LIKE '%" + txtsearch + "%' " &
                                    "OR tc.tipo LIKE '%" + txtsearch + "%' " &
                                    "OR c.km LIKE '%" + txtsearch + "%' " &
                                    "OR c.proximocambio LIKE '%" + txtsearch + "%' " &
                                    "OR cli.nombre LIKE '%" + txtsearch + "%' " &
                                    "OR cli.apellido LIKE '%" + txtsearch + "%' " &
                                    "OR cli.telefono LIKE '%" + txtsearch + "%' " &
                                    "OR a.patente LIKE '%" + txtsearch + "%' " &
                                    "OR ma.modelo LIKE '%" + txtsearch + "%' " &
                                    "OR c.total LIKE '%" + txtsearch + "%' " &
                                    "OR (c.total - c.montoTarjeta) LIKE '%" + txtsearch + "%' " &
                                    "OR c.montoTarjeta LIKE '%" + txtsearch + "%' " &
                                    "OR cn.condicion LIKE '%" + txtsearch + "%' " &
                                    "OR d.descripcion LIKE '%" + txtsearch + "%' " &
                                    "OR ca.nombre LIKE '%" + txtsearch + "%' " &
                                    "OR v.nombre LIKE '%" + txtsearch + "%' " &
                                    "OR m.nombre LIKE '%" + txtsearch + "%' " &
                                    "OR sep.estado LIKE '%" + txtsearch + "%' " &
                                    "OR c.fecha_cierre LIKE '%" + txtsearch + "%') " &
                                    "--OR c.litros_usados LIKE '%" + txtsearch + "%' " &
                                    "ORDER BY c.id_pedido ASC"

                End If
            Case "pedidos"
                If activo Then
                    sqlstr = "SELECT p.id_pedido AS 'ID', CAST(P.fecha AS VARCHAR(50)) AS 'Fecha', c.nombre + ' ' +  c.apellido AS 'Cliente', c.telefono AS 'Teléfono', cn.condicion AS 'Condición de venta', " &
                                "FORMAT(p.total, 'C', 'es-ar') AS 'Total', FORMAT(p.total - p.montoTarjeta, 'C', 'es-ar') AS 'Monto contado', FORMAT(p.montoTarjeta, 'C', 'es-ar') AS 'Monto tarjeta', " &
                                "ca.nombre AS 'Caja', d.descripcion AS 'Descuento', v.nombre AS 'Vendedor', CASE WHEN p.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                                "FROM pedidos AS p " &
                                "INNER JOIN clientes AS c ON p.id_cliente = c.id_cliente " &
                                "INNER JOIN condiciones AS cn ON p.id_condicion = cn.id_condicion " &
                                "INNER JOIN descuentos AS d ON p.id_descuento = d.id_descuento " &
                                "INNER JOIN cajas AS ca ON p.id_caja = ca.id_caja " &
                                "INNER JOIN vendedores AS v ON p.id_vendedor = v.id_vendedor " &
                                "WHERE p.cerrado = '0' AND p.activo = '1' AND p.es_caso = '0' " &
                                "AND (p.id_pedido LIKE '%" + txtsearch + "%' " &
                                "OR p.fecha LIKE '%" + txtsearch + "%' " &
                                "OR c.nombre LIKE '%" + txtsearch + "%' " &
                                "OR c.apellido LIKE '%" + txtsearch + "%' " &
                                "OR cn.condicion LIKE '%" + txtsearch + "%' " &
                                "OR d.descripcion LIKE '%" + txtsearch + "%' " &
                                "OR p.total LIKE '%" + txtsearch + "%' " &
                                "OR (p.total - p.montoTarjeta) LIKE '%" + txtsearch + "%' " &
                                "OR p.montoTarjeta LIKE '%" + txtsearch + "%' " &
                                "OR ca.nombre LIKE '%" + txtsearch + "%') " &
                                "OR v.nombre LIKE '%" + txtsearch + "%' " &
                                "ORDER BY p.id_pedido ASC"
                Else
                    sqlstr = "SELECT p.id_pedido AS 'ID', CAST(P.fecha AS VARCHAR(50)) AS 'Fecha', CAST(P.fecha_cierre AS VARCHAR(50)) AS 'Fecha de cierre', c.nombre + ' ' +  c.apellido AS 'Cliente', c.telefono AS 'Teléfono', cn.condicion AS 'Condición de venta', " &
                                "FORMAT(p.total, 'C', 'es-ar') AS 'Total', FORMAT(p.total - p.montoTarjeta, 'C', 'es-ar') AS 'Monto contado', FORMAT(p.montoTarjeta, 'C', 'es-ar') AS 'Monto tarjeta', " &
                                "ca.nombre AS 'Caja', d.descripcion AS 'Descuento', v.nombre AS 'Vendedor', CASE WHEN p.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                                "FROM pedidos AS p " &
                                "INNER JOIN clientes AS c ON p.id_cliente = c.id_cliente " &
                                "INNER JOIN condiciones AS cn ON p.id_condicion = cn.id_condicion " &
                                "INNER JOIN descuentos AS d ON p.id_descuento = d.id_descuento " &
                                "INNER JOIN cajas AS ca ON p.id_caja = ca.id_caja " &
                                "INNER JOIN vendedores AS v ON p.id_vendedor = v.id_vendedor " &
                                "WHERE p.cerrado = '1' AND p.activo = '0' AND p.es_caso = '0' " &
                                "AND (p.id_pedido LIKE '%" + txtsearch + "%' " &
                                "OR p.fecha LIKE '%" + txtsearch + "%' " &
                                "OR c.nombre LIKE '%" + txtsearch + "%' " &
                                "OR c.apellido LIKE '%" + txtsearch + "%' " &
                                "OR cn.condicion LIKE '%" + txtsearch + "%' " &
                                "OR d.descripcion LIKE '%" + txtsearch + "%' " &
                                "OR p.total LIKE '%" + txtsearch + "%' " &
                                "OR (p.total - p.montoTarjeta) LIKE '%" + txtsearch + "%' " &
                                "OR p.montoTarjeta LIKE '%" + txtsearch + "%' " &
                                "OR ca.nombre LIKE '%" + txtsearch + "%' " &
                                "OR v.nombre LIKE '%" + txtsearch + "%' " &
                                "OR p.fecha_cierre LIKE '%" + txtsearch + "%') " &
                                "ORDER BY p.id_pedido ASC"
                End If
            Case "pedidos_hoy"
                sqlstr = "SELECT p.id_pedido AS 'ID', CAST(p.fecha AS VARCHAR(50)) AS 'Fecha', CAST(P.fecha_cierre AS VARCHAR(50)) AS 'Fecha de cierre', c.nombre + ' ' +  c.apellido AS 'Cliente', c.telefono AS 'Teléfono', cn.condicion AS 'Condición de venta', " &
                           "FORMATp.total, 'C', 'es-ar') AS 'Total', FORMAT(p.total - p.montoTarjeta, 'C', 'es-ar') AS 'Monto contado', FORMAT(p.montoTarjeta, 'C', 'es-ar') AS 'Monto tarjeta', " &
                           "ca.nombre AS 'Caja', d.descripcion AS 'Descuento', v.nombre AS 'Vendedor', CASE WHEN p.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                           "FROM pedidos AS p " &
                           "INNER JOIN clientes AS c ON p.id_cliente = c.id_cliente " &
                           "INNER JOIN condiciones AS cn ON p.id_condicion = cn.id_condicion " &
                           "INNER JOIN descuentos AS d ON p.id_descuento = d.id_descuento " &
                           "INNER JOIN cajas AS ca ON p.id_caja = ca.id_caja " &
                           "INNER JOIN vendedores AS v ON p.id_vendedor = v.id_vendedor " &
                           "WHERE p.es_caso = '0' AND CONVERT(VARCHAR(10), p.fecha, 112) = CONVERT(VARCHAR(10), GETDATE(), 112) " &
                            "AND (p.id_pedido LIKE '%" + txtsearch + "%' " &
                                "OR p.fecha LIKE '%" + txtsearch + "%' " &
                                "OR c.nombre LIKE '%" + txtsearch + "%' " &
                                "OR c.apellido LIKE '%" + txtsearch + "%' " &
                                "OR cn.condicion LIKE '%" + txtsearch + "%' " &
                                "OR d.descripcion LIKE '%" + txtsearch + "%' " &
                                "OR p.total LIKE '%" + txtsearch + "%' " &
                                "OR (p.total - p.montoTarjeta) LIKE '%" + txtsearch + "%' " &
                                "OR p.montoTarjeta LIKE '%" + txtsearch + "%' " &
                                "OR ca.nombre LIKE '%" + txtsearch + "%' " &
                                "OR v.nombre LIKE '%" + txtsearch + "%' " &
                                "OR o.fecha_cierre LIKE '%" + txtsearch + "%') " &
                           "ORDER BY p.id_pedido ASC"
            Case "presupuestos"
                sqlstr = "SELECT p.id_presupuesto AS 'ID', CAST(p.fecha AS VARCHAR(50)) AS 'Fecha', c.nombre + ' ' +  c.apellido AS 'Cliente', c.telefono AS 'Teléfono', cn.condicion AS 'Condición de venta', " &
                 "FORMAT(p.total, 'C', 'es-ar') AS 'Total', FORMAT(p.total - p.montoTarjeta, 'C', 'es-ar') AS 'Monto contado', FORMAT(p.montoTarjeta, 'C', 'es-ar') AS 'Monto tarjeta', " &
                 "d.descripcion AS 'Descuento' " &
                 "FROM presupuestos AS p " &
                 "INNER JOIN clientes AS c ON p.id_cliente = c.id_cliente " &
                 "INNER JOIN condiciones AS cn ON p.id_condicion = cn.id_condicion " &
                 "INNER JOIN descuentos AS d ON p.id_descuento = d.id_descuento " &
                 "WHERE CONVERT(VARCHAR(10), p.fecha, 11) = CONVERT(VARCHAR(10), GETDATE(), 112) " &
                  "AND (p.id_presupuesto LIKE '%" + txtsearch + "%' " &
                      "OR p.fecha LIKE '%" + txtsearch + "%' " &
                      "OR c.nombre LIKE '%" + txtsearch + "%' " &
                      "OR c.apellido LIKE '%" + txtsearch + "%' " &
                      "OR cn.condicion LIKE '%" + txtsearch + "%' " &
                      "OR d.descripcion LIKE '%" + txtsearch + "%' " &
                      "OR p.total LIKE '%" + txtsearch + "%' " &
                      "OR (p.total - p.montoTarjeta) LIKE '%" + txtsearch + "%' " &
                      "OR p.montoTarjeta LIKE '%" + txtsearch + "%') " &
                 "ORDER BY p.id_presupuesto ASC"
            Case "comprobantes"
                sqlstr = "SELECT c.id_comprobante AS 'ID', c.comprobante AS 'Comprobante', tc.comprobante_AFIP AS 'Tipo de comprobante', c.numeroComprobante AS 'Numero de comprobante',  c.puntoVenta AS 'Punto de Venta', " &
                            "CASE WHEN c.esFiscal = '1' THEN 'Fiscal' WHEN c.esElectronica = '1' THEN 'Eletrónico' ELSE 'Manual' END AS 'Formato de comprobante', c.testing AS 'Comprobante de testeo', CASE WHEN c.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo', " &
                            "c.maxItems AS 'Máximo de items', c.cantCopy AS 'Copias' " &
                            "FROM comprobantes AS c " &
                            "INNER JOIN tipos_comprobantes AS tc ON c.id_tipoComprobante = tc.id_tipoComprobante " &
                            "WHERE c.activo = '" + activo.ToString + "' " &
                            "AND (c.id_comprobante LIKE '%" + txtsearch + "%' " &
                            "OR c.comprobante LIKE '%" + txtsearch + "%' " &
                            "OR tc.comprobante_AFIP LIKE '%" + txtsearch + "%' " &
                            "OR c.numeroComprobante LIKE '%" + txtsearch + "%' " &
                            "OR c.puntoVenta LIKE '%" + txtsearch + "%' " &
                            "OR c.testing LIKE '%" + txtsearch + "%' " &
                            "OR c.maxItems LIKE '%" + txtsearch + "%') " &
                            "ORDER BY c.comprobante ASC"
            Case "fe_pendiente"
                sqlstr = "SELECT p.id_pedido AS 'Pedido Nº', CAST(p.fecha AS VARCHAR(50)) AS 'Fecha', c.nombre + ' ' + c.apellido AS 'Cliente', d.descripcion AS 'Descuento', " +
                                "CASE WHEN p.es_caso = 1 THEN 'Si' ELSE 'No' END AS '¿Es un caso?', " +
                                "FORMAT(p.total, 'C', 'es-ar') AS 'Total' " +
                                "FROM pedidos AS p " +
                                "INNER JOIN clientes AS c ON p.id_cliente = c.id_cliente " +
                                "INNER JOIN descuentos AS d ON p.id_descuento = d.id_descuento " &
                                "WHERE p.id_pedido NOT IN (SELECT id_pedido FROM fe) " +
                                "AND YEAR(p.fecha) >= 2018 AND p.id_cliente NOT IN (27, 21, 26684, 28830, 26667) AND c.dni <> '' " +
                                "AND (p.id_pedido LIKE '%" + txtsearch + "%' " +
                                "OR p.fecha LIKE '%" + txtsearch + "%' " +
                                "OR c.nombre LIKE '%" + txtsearch + "%' " +
                                "OR c.apellido LIKE '%" + txtsearch + "%' " +
                                "OR d.descripcion LIKE '%" + txtsearch + "%' " +
                                "OR p.total LIKE '%" + txtsearch + "%') " +
                                "ORDER BY id_pedido DESC"
            Case "fe"
                sqlstr = "SELECT fe.id_pedido AS 'Pedido Nº', CAST(fe.fecha_emision AS VARCHAR(50)) AS 'Fecha de emisión', c.nombre + ' ' + c.apellido AS 'Cliente', d.descripcion AS 'Descuento', cmp.comprobante AS 'Comprobante', " +
                                "CONCAT('Nº  ', REPLICATE('0', 4 - LEN(fe.puntoVenta)), fe.puntoVenta, '-', REPLICATE('0', 8 - LEN(fe.numeroComprobante)), fe.numeroComprobante) AS 'Nº de comprobante', " +
                                "FORMAT(fe.total, 'C', 'es-ar') AS 'Total', " +
                                "fe.cae AS 'CAE' " +
                                "FROM fe AS fe " +
                                "INNER JOIN pedidos as p ON fe.id_pedido = p.id_pedido " +
                                "INNER JOIN clientes AS c ON p.id_cliente = c.id_cliente " +
                                "INNER JOIN descuentos AS d ON p.id_descuento = d.id_descuento " &
                                "INNER JOIN comprobantes AS cmp ON fe.id_comprobante = cmp.id_comprobante " +
                                "WHERE cmp.testing = 0 AND (fe.id_pedido LIKE '%" + txtsearch + "%' " +
                                "OR fe.fecha_emision LIKE '%" + txtsearch + "%' " +
                                "OR c.nombre LIKE '%" + txtsearch + "%' " +
                                "OR c.apellido LIKE '%" + txtsearch + "%' " +
                                "OR cmp.comprobante LIKE '%" + txtsearch + "%' " +
                                "OR d.descripcion LIKE '%" + txtsearch + "%' " +
                                "OR fe.puntoVenta LIKE '%" + txtsearch + "%' " +
                                "OR fe.numeroComprobante LIKE '%" + txtsearch + "%' " +
                                "OR fe.total LIKE '%" + txtsearch + "%' " +
                                "OR fe.cae LIKE '%" + txtsearch + "%') " +
                                "ORDER BY fe.id_fe DESC"
                '"ORDER BY fe.fecha_emision DESC"
        End Select
        Return sqlstr
    End Function

    Public Function info_iva(ByVal id_iva As String) As Double
        Dim sqlstr As String = "SELECT * FROM iva WHERE id_iva = '" + id_iva + "'"
        Dim porcentaje As Double

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
            porcentaje = dataset.Tables("tabla").Rows(0).Item(2)
            cerrardb()
            Return porcentaje
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
            Return "-1"
        End Try
    End Function

    Public Function ImportarDatosExcel(ByVal archivo As String, Optional ByVal hoja As String = "Hoja1") As DataTable
        'Public Function ImportarDatosExcel(ByVal archivo As String, Optional ByVal hoja As String = "Hoja1", Optional ByVal importaPrimerfila As Boolean = 1) As DataTable
        Dim dt As New DataTable("Excel")

        'Compruebo los parámetros
        If ((String.IsNullOrEmpty(archivo)) OrElse (String.IsNullOrEmpty(hoja))) Then Throw New ArgumentNullException()

        Try
            Dim extension As String = IO.Path.GetExtension(archivo)

            Dim connString As String = "Data Source=" & archivo

            If (extension = ".xls") Then
                'If importaPrimerfila Then
                connString &= ";Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties='Excel 8.0;HDR=YES;IMEX=1'"
                'Else
                '   connString &= ";Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties='Excel 8.0;HDR=NO;IMEX=1'"
                'End If
            ElseIf (extension = ".xlsx") Then
                'If importaPrimerfila Then
                connString &= ";Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1'"
                'Else
                '   connString &= ";Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 12.0 Xml;HDR=NO;IMEX=1'"
                'End If
            Else
                Throw New ArgumentException(
              "La extensión " & extension & " del archivo no está permitida.")
            End If

            Using conexion As New OleDbConnection(connString)
                Dim sql As String = "SELECT * FROM [" & hoja & "$]"
                Dim adaptador As New OleDbDataAdapter(sql, conexion)

                adaptador.Fill(dt)

                Return dt
            End Using
        Catch ex As Exception
            dt.Clear()
            MsgBox(ex.Message.ToString)
            Return dt
        End Try
    End Function

    Public Function ejecutarSQL(ByVal sqlstr As String) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

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

    Public Function ejecutarSQLconResultado(ByVal sqlstr As String) As String
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim datareader As SqlDataReader
        Dim resultado As String = ""


        mytrans = CN.BeginTransaction()

        Try

            Comando = New SqlCommand(sqlstr, CN)
            Comando.Transaction = mytrans
            Comando.ExecuteNonQuery()

            datareader = Comando.ExecuteReader()

            While datareader.Read
                resultado += datareader.GetString(0) + vbNewLine
            End While

            cerrardb()
            Return resultado
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
            Return "ERROR"
        End Try
    End Function

    Public Function extraer_numeros(ByVal texto As String) As Integer
        Dim i As Integer = 0
        Dim c As Char
        Dim numeros As String = ""

        If texto.Length = 0 Then Return 0

        For i = 0 To texto.Length - 1
            c = Microsoft.VisualBasic.Left(texto, 1)
            If IsNumeric(c) Then numeros += c
            texto = Microsoft.VisualBasic.Right(texto, texto.Length - 1)
        Next

        Return Val(numeros)
    End Function

    Public Sub cargar_datagrid(ByRef dataGrid As DataGridView, ByVal sqlstr As String, ByVal db As String)
        Try
            'Crea y abre una nueva conexión            
            abrirdb(serversql, db, usuariodb, passdb)

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
            da.Fill(dataset)
            dataGrid.DataSource = dataset.Tables(0)
            dataGrid.RowsDefaultCellStyle.BackColor = Color.White
            dataGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            cerrardb()

            'Inmovilizo las columnas
            Dim i As Integer = 0
            For Each columna As DataGridViewColumn In dataGrid.Columns
                dataGrid.Columns(columna.Name.ToString).DisplayIndex = i
                i = i + 1
            Next

            If dataGrid.Name = "dg_viewPedido" Then dataGrid.Columns(1).Visible = False
            dataGrid.Height = dataGrid.Height + 1
            dataGrid.Height = dataGrid.Height - 1
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

            dataGrid.Refresh()

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
        End Try
    End Sub

    Public Function dbBackup() As Boolean
        Try
            Dim Comando As New SqlCommand

            CN = New SqlConnection("Data Source=127.0.0.1;Database=Master;integrated security=SSPI;") 'Abro en un modo especial para poder hacer bkacup
            CN.Open()
            Comando = New SqlCommand("BACKUP DATABASE dbBackup TO DISK='D:\OneDrive\DrOil Soft\_BaseSQL\_Backup.bak'", CN)
            Comando.ExecuteNonQuery()
            Return 1 'Ok
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return 0 'Error
        End Try
    End Function

    Public Sub exportarExcel(ByVal dgview As DataGridView, ByVal rutaArchivo As String)
        'Exporta los datos de la tabla a Excel
        'Variables locales

        Dim oExcel As Object
        Dim oBook As Object
        Dim oSheet As Object
        Dim rCount As Integer
        Dim cCount As Integer
        Dim i As Integer
        Dim j As Integer

        rCount = dgview.Rows.Count
        cCount = dgview.Columns.Count

        'Start a new workbook in Excel
        oExcel = CreateObject("Excel.Application")
        oBook = oExcel.Workbooks.Add

        'Create an array with 3 columns and 100 rows
        'Dim DataArray(0 To 100, 0 To 3) As Object
        Dim columnDataArray(1, cCount)
        Dim dataArray(rCount, cCount) As Object

        'Agrego los nombres de las columnas a la primer fila
        For j = 0 To cCount - 1
            dataArray(0, j) = dgview.Columns(j).Name.ToString
        Next

        'Agrego el resto de los datos, i+1 porque la primer fila está ocupada con el nombre de las columnas
        For i = 0 To rCount - 1
            For j = 0 To cCount - 1
                dataArray(i + 1, j) = dgview.Rows(i).Cells(j).Value.ToString()
            Next
        Next

        'Add headers to the worksheet on row 1
        oSheet = oBook.Worksheets(1)

        'Transfer the array to the worksheet starting at cell A1
        oSheet.Range("A1").Resize(rCount + 1, cCount).Value = dataArray

        'Save the Workbook and Quit Excel
        oBook.SaveAs(rutaArchivo)
        oExcel.Quit()
    End Sub

    '' ********************** EXPORTAR A EXCEL ABRIENDO EL EXCEL
    'Public Sub exportarExcel(ByVal dgview As DataGridView) 
    'Dim app As Excel._Application = New Excel.Application()
    'Dim workbook As Excel._Workbook = app.Workbooks.Add(Type.Missing)
    'Dim worksheet As Microsoft.Office.Interop.Excel._Worksheet = Nothing
    'worksheet = workbook.Sheets("Hoja1")
    'worksheet = workbook.ActiveSheet
    ''Aca se agregan las cabeceras de nuestro datagrid.

    'For i As Integer = 1 To dgview.Columns.Count
    '    worksheet.Cells(1, i) = dgview.Columns(i - 1).HeaderText
    'Next

    ''Aca se ingresa el detalle recorrera la tabla celda por celda

    'For i As Integer = 0 To dgview.Rows.Count - 1
    '    For j As Integer = 0 To dgview.Columns.Count - 1
    '        worksheet.Cells(i + 2, j + 1) = dgview.Rows(i).Cells(j).Value.ToString()
    '    Next
    'Next

    ''Aca le damos el formato a nuestro excel

    'worksheet.Rows.Item(1).Font.Bold = 1
    'worksheet.Rows.Item(1).HorizontalAlignment = 3
    'worksheet.Columns.AutoFit()
    'worksheet.Columns.HorizontalAlignment = 2

    'app.Visible = True
    'app = Nothing
    'workbook = Nothing
    'worksheet = Nothing
    'FileClose(1)
    'GC.Collect()
    'End Sub
    '' ********************** EXPORTAR A EXCEL ABRIENDO EL EXCEL

    Public Sub loadStartSettings()
        Dim sqlstr As String = "SELECT * FROM configuracion"
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
            stock0 = dataset.Tables("tabla").Rows(0).Item(0).ToString
            showrpt = dataset.Tables("tabla").Rows(0).Item(1).ToString
            cerrardb()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
        End Try
    End Sub

    Public Sub updateStartSettings()
        abrirdb(serversql, basedb, usuariodb, passdb)
        Dim sqlstr As String

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand


        mytrans = CN.BeginTransaction()

        Try

            sqlstr = "UPDATE configuracion SET showStock0 = '" & Math.Abs(CInt(Not stock0)) & "', showPRN = '" & showrpt & "'"


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

    Function MyRound(Number As Double, Multiple As Double) As Double
        MyRound = Math.Round(Number / Multiple, 0) * Multiple
    End Function

    Function MyRound_2(ByVal number As Integer) As Integer
        Dim numero As Integer
        Dim numero_str As String
        Dim ultimos_dos As Integer
        Dim ultimos_dos_str As String
        'Dim entero As Integer
        'Dim entero_str As String
        'Dim ultimos_dos_enteros_str As Integer
        'Dim dec As Double
        'Dim dec_str As String
        'Dim numero_final As Double
        'Dim numero_final_str As String
        'Dim subirPrecio As Boolean = False

        numero = number
        numero_str = CStr(numero)

        'entero = Math.Truncate(number)
        'entero_str = CStr(entero)
        ultimos_dos_str = numero_str.Substring(numero_str.Length - 2)
        ultimos_dos = CInt(ultimos_dos_str)

        'dec = number - Math.Truncate(number)
        'dec_str = CStr(dec)

        'MsgBox(dec_str)
        If ultimos_dos < 24 Then
            Do Until numero Mod 50 = 0
                numero = numero - 1
            Loop
        ElseIf ultimos_dos > 24 And ultimos_dos < 49 Then
            Do Until numero Mod 50 = 0
                numero = numero + 1
            Loop
        ElseIf ultimos_dos > 50 And ultimos_dos < 74 Then
            Do Until numero Mod 50 = 0
                numero = numero - 1
            Loop
        ElseIf ultimos_dos > 75 And ultimos_dos < 99 Then
            Do Until numero Mod 50 = 0
                numero = numero + 1
            Loop
        End If

        'MsgBox(numero Mod 50)

        Return numero
        'MyRound = Math.Round(Number / Multiple, 0) * Multiple
    End Function

    Public Function obtieneValorConfig(ByVal str As String) As String
        Return Trim(Right(str, (str.Length - (InStr(str, "=") + 1))))
    End Function

    Public Function isDecimalOk(e As KeyPressEventArgs) As String
        Dim valor As String = e.KeyChar

        If InStr(1, ".," & Chr(8), e.KeyChar) Then
            If InStr(1, sepDecimal & Chr(8), e.KeyChar) Then
                valor = sepDecimal
            Else
                If sepDecimal = "." Then
                    valor = ","
                Else
                    valor = "."
                End If
            End If
        End If

        Return valor
    End Function

    Public Function esNumero(e As KeyPressEventArgs) As Boolean
        Return InStr(1, "0123456789" & Chr(8), e.KeyChar)
    End Function

    Public Function esImporte(e As KeyPressEventArgs) As Boolean
        Return InStr(1, "0123456789,." & Chr(8), e.KeyChar)
    End Function

    Public Function cantReg(ByVal db As String, ByVal sqlstr As String) As Integer
        Try
            'Crea y abre una nueva conexión            
            abrirdb(serversql, db, usuariodb, passdb)

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
            'Devuelve la cantidad de registros
            'Return dataset.Tables("tabla").Rows.Count - 1
            Return dataset.Tables("tabla").Rows.Count
            'Errores
        Catch ex As Exception
            Return -1
        Finally
            cerrardb()
        End Try
    End Function

    Public Function ConvertToInteger(ByRef value As String) As Integer
        If String.IsNullOrEmpty(value) Then
            value = "0"
        End If

        Return Convert.ToInt32(value)
    End Function

    Public Function fechaAFIP() As String
        Dim anio As String = ""
        Dim mes As String = ""
        Dim dia As String = ""
        Dim fechaFinal As String

        anio = DateTime.Now().Year
        mes = DateTime.Now().Month
        dia = DateTime.Now().Day

        If mes < 10 Then mes = "0" & mes
        If dia < 10 Then dia = "0" & dia

        fechaFinal = anio & mes & dia

        Return fechaFinal
    End Function

    Public Function fechaAFIP_fecha(ByVal fecha_afip As String) As String
        Dim fecha As String
        Dim anio As String
        Dim mes As String
        Dim dia As String

        anio = Left(fecha_afip, 4)
        mes = Mid(fecha_afip, 5, 2)
        dia = Right(fecha_afip, 2)
        fecha = anio & "/" & mes & "/" & dia
        Return fecha
    End Function

    Public Sub guardarArchivoTexto(ByVal path As String, ByVal strr As String)
        Dim fs As FileStream = File.Create(path)
        Dim str As Byte()

        str = New UTF8Encoding(True).GetBytes(strr)

        fs.Write(str, 0, str.Length)
        fs.Close()
    End Sub

    Public Function leerArchivoTexto(ByVal path As String) As String
        Dim strDesc As New Encriptar
        Dim objReader As New StreamReader(path)
        Dim str As String = ""
        'Dim arrSTR As New ArrayList
        Dim strr As String = ""
        Dim c As Integer = 0

        Do
            c = c + 1
            str = objReader.ReadLine()
            strr += str
        Loop Until str Is Nothing
        objReader.Close()

        Return strr
    End Function

    Public Function Hoy() As String
        Return Format(DateTime.Now, "dd/MM/yyyy")
    End Function

    Public Function Hoy_SoloFecha() As String
        Return Format(Date.Now, "dd/MM/yyyy")
    End Function

    Public Function Hoy_DateFormat() As Date
        Return Format(DateTime.Now, "dd/MM/yyyy")
    End Function

    Public Function Generar_ID_Unico() As String
        Dim idUnico As String

        idUnico = ejecutarSQLconResultado("SELECT CONVERT(NVARCHAR(100), NEWID())")

        Return idUnico
    End Function

    Public Function info_estadoPedido(ByVal id_PedidoStatus As Integer) As pedidosStatus

        Dim tmp As New pedidosStatus
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = "SELECT * FROM sysEstado_pedidos WHERE id_PedidoStatus = '" + id_PedidoStatus.ToString + "'"
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")
            tmp.id_PedidoStatus = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.estado = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.esFin = dataset.Tables("tabla").Rows(0).Item(2).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            tmp.estado = "error"
            cerrardb()
            Return tmp
        End Try
    End Function
    '************************************* FUNCIONES GENERALES *****************************
End Module