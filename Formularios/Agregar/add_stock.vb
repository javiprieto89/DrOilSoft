Public Class add_stock
    Public ingreso_guardado As Boolean

    Private Sub updateform()
        Dim sqlstr As String
        If edicion Then
            sqlstr = "SELECT rs.id_registro AS 'ID', i.item AS 'Item', i.EAN AS 'EAN', i.descript AS 'Descripción', rs.factura AS 'Factura', rs.fecha AS 'Fecha', rs.cantidad AS 'Cantidad', rs.costo AS 'Costo', " &
                        "rs.precio_lista AS 'Precio de lista', rs.markup AS 'Markup', rs.descuento AS 'Descuento', ti.descripcion AS 'I.V.A.', rs.nota AS 'Notas' " &
                        "FROM registros_stock AS rs " &
                        "LEFT JOIN items AS i ON rs.id_item = i.id_item " &
                        "LEFT JOIN iva AS ti ON rs.id_iva = ti.id_iva " &
                        "WHERE rs.id_ingreso = '" + edita_registro_stock.id_ingreso.ToString + "' " &
                        "ORDER BY rs.id_ingreso ASC"
        Else
            sqlstr = "SELECT rstmp.id_registrotmp AS 'ID', i.item AS 'Item', i.EAN AS 'EAN', i.descript AS 'Descripción', rstmp.factura AS 'Factura', rstmp.fecha AS 'Fecha', rstmp.cantidad AS 'Cantidad', rstmp.costo AS 'Costo', " &
                    "rstmp.precio_lista AS 'Precio de lista', rstmp.markup AS 'Markup', rstmp.descuento AS 'Descuento', ti.descripcion AS 'I.V.A.', rstmp.nota AS 'Notas' " &
                    "FROM tmpregistros_stock AS rstmp " &
                    "LEFT JOIN items AS i ON rstmp.id_item = i.id_item " &
                    "LEFT JOIN iva as ti ON rstmp.id_iva = ti.id_iva " &
                    "WHERE rstmp.activo = '1' " &
                    "ORDER BY rstmp.id_ingreso ASC"
        End If


        Cargar_listview(lsv_items, sqlstr, basedb)
        resaltarcolumna(lsv_items, lightRegStock, Color.Red)
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If edicion = False Then
            If MsgBox("Se modificarán todos los items anteriormente cargados. ¿Está seguro de que desea continuar?", vbYesNo + vbQuestion, "Dr. Oil") = vbYes Then
                addstock()
                borrartbl("tmpregistros_stock")
                MsgBox("Se actualizaron los items correctamente", vbOK, "Dr. Oil")
                ingreso_guardado = True
            Else
                'MsgBox("Operación cancelada.", vbOKOnly + vbInformation, "Dr. Oil")
                Exit Sub
            End If
        End If

        closeandupdate(Me)
    End Sub

    Private Sub Add_stock_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If ingreso_guardado Then Exit Sub
        If edicion = False Then
            If MsgBox("Eliminará el ingreso, por lo cual no se contabilizará. ¿Deseá continuar?", vbYesNo + vbQuestion) = vbNo Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Add_stock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form = Me
        'Cargo todos los proveedores
        cargar_combo(cmb_proveedor, "SELECT id_proveedor, nombre FROM proveedores ORDER BY nombre ASC", basedb, "nombre", "id_proveedor")

        If edicion Then
            txt_fecha.Text = DateTime.Parse(edita_registro_stock.fecha)
            lbl_fecha_ingreso.Text = DateTime.Parse(edita_registro_stock.fecha_ingreso)
            txt_factura.Text = edita_registro_stock.factura
            cmb_proveedor.SelectedValue = CByte(edita_registro_stock.id_proveedor)
            txt_fecha.Enabled = False
            txt_factura.Enabled = False
            txt_notas.Enabled = False
            cmb_proveedor.Enabled = False
            psearch_proveedor.Enabled = False
            cmd_additem.Enabled = False
        Else
            cmb_proveedor.Text = "Seleccione un proveedor"
            txt_fecha.Text = Format(DateTime.Now, "dd/MM/yyyy")
            lbl_fecha_ingreso.Text = Format(DateTime.Now, "dd/MM/yyyy")
            'txt_fecha.Text = Format(DateTime.Now, "MM/dd/yyyy")
            'lbl_fecha_ingreso.Text = Format(DateTime.Now, "MM/dd/yyyy")
            'cmb_proveedor.SelectedValue = proveedor_indefinido
            borrartbl("tmpregistros_stock")
        End If
        updateform()
    End Sub

    Private Sub cmd_additem_Click(sender As Object, e As EventArgs) Handles cmd_additem.Click
        Enabled = False
        search.ShowDialog()

        If id = 0 Then Exit Sub
        infoagregarstock.ShowDialog()
        updateform()
        If secuencia Then cmd_additem_Click(Nothing, Nothing)
    End Sub

    Private Sub cmd_cancel_Click(sender As Object, e As EventArgs) Handles cmd_cancel.Click
        If edicion = False Then
            If MsgBox("Eliminará el ingreso, por lo cual no se contabilizará. ¿Deseá continuar?", vbYesNo + vbQuestion) = vbYes Then
                ingreso_guardado = True
                closeandupdate(Me)
            End If
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub psearch_proveedor_Click(sender As Object, e As EventArgs) Handles psearch_proveedor.Click
        Dim tmp As String
        tmp = tabla
        tabla = "proveedores"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        If id Then
            cmb_proveedor.SelectedIndex = cmb_proveedor.FindString(info_proveedor(id).nombre)
        Else
            cmb_proveedor.Text = "Seleccione un proveedor"
        End If
        id = 0
    End Sub

    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        lsv_items_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub lsv_items_DoubleClick(sender As Object, e As EventArgs) Handles lsv_items.DoubleClick
        If edicion = True Then Exit Sub
        If lsv_items.SelectedIndices.Count = 0 Then Exit Sub

        Dim seleccionado As String = lsv_items.SelectedItems.Item(0).Text

        edicion_item_registro_stock = True
        edita_item_registro_stock = info_registro_stocktmp(seleccionado)
        infoagregarstock.ShowDialog()
        updateform()
        edicion_item_registro_stock = False
    End Sub

    Private Sub lsv_items_MouseDown(sender As Object, e As MouseEventArgs) Handles lsv_items.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If edicion = True Then
                ContextMenuStrip1.Enabled = False
            End If
        End If
    End Sub

    Private Sub BorrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BorrarToolStripMenuItem.Click
        'borrar item de tmp
        If lsv_items.SelectedIndices.Count = 0 Then Exit Sub

        Dim seleccionado As String = lsv_items.SelectedItems.Item(0).Text
        If MsgBox("¿Está seguro de borrar el item: " + info_item(info_registro_stocktmp(seleccionado).id_item).item + "?", vbYesNo + vbQuestion) = vbYes Then
            borraritemregistrostocktmp(info_registro_stocktmp(seleccionado))
        End If
        updateform()
    End Sub

    Private Sub lbl_fecha_ingreso_MouseEnter(sender As Object, e As EventArgs) Handles lbl_fecha_ingreso.MouseEnter
        lbl_tooltip.Visible = True
    End Sub

    Private Sub lbl_fecha_ingreso_MouseLeave(sender As Object, e As EventArgs) Handles lbl_fecha_ingreso.MouseLeave
        lbl_tooltip.Visible = False
    End Sub

End Class