Public Class infoagregarstock
    Private i As New item

    Private Sub infoagregarstock_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Cargo todos los proveedores
        cargar_combo(cmb_proveedor, "SELECT id_proveedor, nombre FROM proveedores ORDER BY nombre ASC", basedb, "nombre", "id_proveedor")
        cmb_proveedor.Text = "Seleccione un proveedor"

        'Cargo todos los I.V.A.
        cargar_combo(cmb_iva, "SELECT id_iva, descripcion FROM iva ORDER BY id_iva ASC", basedb, "descripcion", "id_iva")
        cmb_iva.Text = "Seleccione un % de I.V.A."

        If edicion Or edicion_item_registro_stock Then
            i = info_item(edita_item_registro_stock.id_item)
            id = i.id_item

            lbl_item.Text = i.descript
            txt_fecha.Text = DateTime.Parse(edita_item_registro_stock.fecha)
            txt_factura.Text = edita_item_registro_stock.factura
            cmb_proveedor.SelectedValue = CByte(edita_item_registro_stock.id_proveedor)
            txt_cantidad.Text = edita_item_registro_stock.cantidad
            txt_costo.Text = edita_item_registro_stock.costo
            txt_preciolista.Text = edita_item_registro_stock.precio_lista
            txt_markup.Text = edita_item_registro_stock.markup
            txt_descuento.Text = edita_item_registro_stock.descuento
            cmb_iva.SelectedValue = edita_item_registro_stock.id_iva
            txt_notas.Text = edita_item_registro_stock.nota
            chk_checkStock.Checked = edita_item_registro_stock.checkStock
            txt_stockRepo.Text = edita_item_registro_stock.stockRepo

            If edicion Then
                lbl_item.Enabled = False
                txt_fecha.Enabled = False
                txt_factura.Enabled = False
                cmb_proveedor.Enabled = False
                txt_cantidad.Enabled = False
                txt_costo.Enabled = False
                txt_preciolista.Enabled = False
                txt_markup.Enabled = False
                txt_descuento.Enabled = False
                cmb_iva.Enabled = False
                txt_notas.Enabled = False
                chk_checkStock.Enabled = False
                txt_stockRepo.Enabled = False
                cmd_ok.Text = "Aceptar"
            End If
        Else
            i = info_item(id)

            lbl_item.Text = i.descript
            txt_fecha.Text = add_stock.txt_fecha.Text
            txt_factura.Text = add_stock.txt_factura.Text
            If add_stock.cmb_proveedor.Text = "Seleccione un proveedor" Then
                cmb_proveedor.SelectedValue = i.id_proveedor
            Else
                cmb_proveedor.SelectedValue = add_stock.cmb_proveedor.SelectedValue
            End If
            cmb_iva.SelectedValue = CByte(i.id_iva)

            txt_costo.Text = i.costo.ToString
            txt_preciolista.Text = MyRound(i.precio_lista, 50).ToString
            'txt_factor.Text = i.factor.ToString
            txt_markup.Text = i.markup.ToString
            txt_descuento.Text = i.descuento.ToString
            txt_notas.Text = add_stock.txt_notas.Text

            chk_checkStock.Checked = i.checkStock
            txt_stockRepo.Text = i.stockRepo

            'Si el item se encuentra inactivo, al agregar stock se activa
            If i.activo = False Then
                If txt_notas.Text <> "" Then
                    txt_notas.Text = txt_notas.Text & vbCrLf & "ESTE ITEM SE ENCUENTRA INACTIVO, SI AGREGA STOCK SE ACTIVARÁ"
                Else
                    txt_notas.Text = "ESTE ITEM SE ENCUENTRA INACTIVO, SI AGREGA STOCK SE ACTIVARÁ"
                End If
                i.activo = True
                updateitem(i)
            End If

        End If
        Me.ActiveControl = txt_cantidad
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If edicion Then
            closeandupdate(Me)
            Exit Sub
        End If

        Dim rs As New registro_stock

        If txt_cantidad.Text = "" Then
            MsgBox("El campo 'Cantidad' no puede estar vació", vbExclamation, "Dr. Oil")
            Exit Sub
        ElseIf txt_cantidad.Text = "0" Then
            MsgBox("La cantidad ingresada no puede ser 0", vbExclamation, "Dr. Oil")
            Exit Sub
        ElseIf txt_costo.Text = "" Then
            MsgBox("El campo 'Costo' no puede estar vació", vbExclamation, "Dr. Oil")
            Exit Sub
        ElseIf txt_preciolista.Text = "" Then
            MsgBox("El campo 'Precio lista' no puede estar vació", vbExclamation, "Dr. Oil")
            Exit Sub
        ElseIf txt_markup.Text = "" Then
            MsgBox("El campo 'Markup' no puede estar vació", vbExclamation, "Dr. Oil")
            Exit Sub
        ElseIf chk_checkStock.Checked And txt_stockRepo.Text = "" Then
            MsgBox("Si quiere que se verifique el stock de este item, debe ingresar un stock mínimo de reposición", vbExclamation, "Dr. Oil")
            Exit Sub
        End If

        rs.id_item = id
        rs.fecha = txt_fecha.Text
        rs.factura = txt_factura.Text
        rs.id_proveedor = cmb_proveedor.SelectedValue
        rs.cantidad = txt_cantidad.Text
        rs.costo = txt_costo.Text
        rs.precio_lista = txt_preciolista.Text
        rs.markup = txt_markup.Text
        rs.descuento = txt_descuento.Text
        rs.id_iva = cmb_iva.SelectedValue
        rs.markup_anterior = i.markup
        rs.descuento_anterior = i.descuento
        rs.id_iva_anterior = i.id_iva
        rs.cantidad_anterior = i.cantidad
        rs.costo_anterior = i.costo
        rs.precio_lista_anterior = i.precio_lista
        'rs.factor_anterior = i.factor
        rs.nota = txt_notas.Text
        rs.checkStock = chk_checkStock.Checked
        rs.stockRepo = txt_stockRepo.Text
        rs.checkStock_anterior = i.checkStock
        rs.stockRepo_anterior = i.stockRepo

        If edicion_item_registro_stock Then
            rs.id_registro = edita_item_registro_stock.id_registro
            updatestocktmp(rs)
        Else
            addstocktmp(rs)
        End If

        closeandupdate(Me)
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    Private Sub txt_costo_LostFocus(sender As Object, e As EventArgs) Handles txt_costo.LostFocus
        calculaPrecioLista()
    End Sub

    Private Sub txt_markup_LostFocus(sender As Object, e As EventArgs) Handles txt_markup.LostFocus
        calculaPrecioLista()
    End Sub

    Private Sub txt_descuento_LostFocus(sender As Object, e As EventArgs) Handles txt_descuento.LostFocus
        calculaPrecioLista()
    End Sub

    Private Sub cmb_iva_LostFocus(sender As Object, e As EventArgs) Handles cmb_iva.LostFocus
        calculaPrecioLista()
    End Sub

    Private Sub calculaPrecioLista()
        If Not txt_costo.Text = vbNullString Then
            Dim costo As String
            Dim markup As String
            Dim descuento As String
            Dim iva As String
            Dim prclista As String

            prclista = txt_preciolista.Text
            costo = txt_costo.Text
            If InStr(txt_markup.Text, ".") > 0 Then
                markup = "1." + Microsoft.VisualBasic.Strings.Left(txt_markup.Text, (InStr(txt_markup.Text, ".") - 1))
            Else
                markup = "1." + txt_markup.Text
            End If

            iva = info_iva(cmb_iva.SelectedValue) / 100
            prclista = (CDbl(costo) * CDbl(markup))

            If txt_descuento.Text <> "" And txt_descuento.Text <> "0" Then
                descuento = (prclista * txt_descuento.Text) / 100
                prclista = CDbl(prclista - descuento)
            End If


            prclista = CDbl(prclista + (prclista * iva)).ToString

            prclista = Math.Ceiling(CDbl(prclista)).ToString

            prclista = MyRound(prclista, 50)

            txt_preciolista.Text = prclista
        End If
    End Sub
    Private Sub chk_checkStock_CheckStateChanged(sender As Object, e As EventArgs) Handles chk_checkStock.CheckStateChanged
        If chk_checkStock.Checked Then
            txt_stockRepo.Enabled = True
        Else
            txt_stockRepo.Enabled = False
        End If
    End Sub
End Class