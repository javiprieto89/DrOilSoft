Public Class exportar_precios
    Private Class sqlstr
        Private inicio_sqlstr As String
        Private costo_sqlstr As String
        Private markup_sqlstr As String
        Private descuento_sqlstr As String
        Private precio_lista_sqlstr As String
        Private fin_sqlstr As String

        Private costo As Boolean
        Private markup As Boolean
        Private descuento As Boolean
        Private precio_lista As Boolean


        Public Sub New(ByVal c As Boolean, m As Boolean, d As Boolean, pl As Boolean, txtsearch As String)
            inicio_sqlstr = "SELECT i.item"
            costo_sqlstr = ", i.costo"
            markup_sqlstr = ", i.markup"
            descuento_sqlstr = ", i.descuento"
            precio_lista_sqlstr = ", i.precio_lista"
            fin_sqlstr = " FROM items AS i " &
                "LEFT JOIN tipos_items AS t ON i.id_tipo = t.id_tipo " &
                "LEFT JOIN marcas_items AS m ON i.id_marca = m.id_marca " &
                "LEFT JOIN proveedores AS p ON i.id_proveedor = p.id_proveedor " &
                "LEFT JOIN roscas AS r ON i.id_rosca = r.id_rosca " &
                "LEFT JOIN iva AS ti ON i.id_iva = ti.id_iva " &
                "WHERE i.activo = '" + activo.ToString + "' "
            If Not itemsstock0 Then
                fin_sqlstr += "AND i.cantidad > 0 "
            End If
            fin_sqlstr += "AND (i.id_item LIKE '%" + txtsearch + "%' " &
                            "OR i.item LIKE '%" + txtsearch + "%' " &
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
                            "OR ti.descripcion LIKE '%" + txtsearch + "%') " &
                            "ORDER BY i.item ASC"



            costo = c
            markup = m
            descuento = d
            precio_lista = pl
        End Sub

        Public Sub New()

        End Sub

        Public Property setCosto As Boolean
            Get
                Return costo
            End Get
            Set(value As Boolean)
                costo = value
            End Set
        End Property

        Public Property setMarkup As Boolean
            Get
                Return markup
            End Get
            Set(value As Boolean)
                markup = value
            End Set
        End Property

        Public Property setDescuento As Boolean
            Get
                Return descuento
            End Get
            Set(value As Boolean)
                descuento = value
            End Set
        End Property

        Public Property setPrecioLista As Boolean
            Get
                Return precio_lista
            End Get
            Set(value As Boolean)
                precio_lista = value
            End Set
        End Property

        Public Function cadenaSql() As String
            Dim sqlstr As String
            sqlstr = inicio_sqlstr

            If costo Then
                sqlstr += costo_sqlstr
            End If

            If markup Then
                sqlstr += markup_sqlstr
            End If

            If descuento Then
                sqlstr += descuento_sqlstr
            End If

            If precio_lista Then
                sqlstr += precio_lista_sqlstr
            End If

            sqlstr += fin_sqlstr
            Return sqlstr
        End Function
    End Class
    Private str As New sqlstr(1, 1, 1, 1, main.txt_search.Text)

    Private Sub exportar_precios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actualizar()
    End Sub

    Private Sub cmd_exportar_Click(sender As Object, e As EventArgs) Handles cmd_exportar.Click
        Dim rutaArchivo As String

        With SaveFileDialog1
            .AddExtension = True
            .CheckFileExists = False
            .CheckPathExists = True
            .Filter = "Excel Worksheets 2007 (*.xlsx)|*.xlsx"
            .DefaultExt = "xls"
            .InitialDirectory = "C:\"
            .ShowDialog()
            rutaArchivo = .FileName
            If rutaArchivo = "" Then
                MsgBox("Exportación cancelada.", vbInformation + vbOKOnly, "DROil")
                Exit Sub
            End If
        End With

        exportarExcel(dgv_items, rutaArchivo)
        MsgBox("Archivo exportado a: " + SaveFileDialog1.FileName, vbInformation + vbOKOnly, "DROil")
    End Sub

    Private Sub chk_costo_Click(sender As Object, e As EventArgs) Handles chk_costo.Click
        str.setCosto = chk_costo.Checked
        actualizar()
    End Sub

    Private Sub chk_markup_Click(sender As Object, e As EventArgs) Handles chk_markup.Click
        str.setMarkup = chk_markup.Checked
        actualizar()
    End Sub

    Private Sub chk_descuento_Click(sender As Object, e As EventArgs) Handles chk_descuento.Click
        str.setDescuento = chk_descuento.Checked
        actualizar()
    End Sub

    Private Sub chk_precioLista_Click(sender As Object, e As EventArgs) Handles chk_precioLista.Click
        str.setPrecioLista = chk_precioLista.Checked
        actualizar()
    End Sub

    Private Sub actualizar()
        dgv_items.DataSource = Nothing
        dgv_items.Rows.Clear()
        dgv_items.Columns.Clear()

        cargar_datagrid(dgv_items, str.cadenaSql, basedb)
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub
End Class