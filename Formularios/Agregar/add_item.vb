Public Class add_item
    Private cantidad As Decimal = 0 'Para guardar la cantidad original si edito el item

    Private Sub Add_item_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub Add_item_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form = Me

        chk_activo.Checked = True
        txt_markup.Text = 1

        'Cargo todas las categorias
        cargar_combo(cmb_cat, "SELECT id_tipo, tipo FROM tipos_items ORDER BY tipo ASC", basedb, "tipo", "id_tipo")

        'Cargo todas las marcas
        cargar_combo(cmb_marca, "SELECT id_marca, marca FROM marcas_items ORDER BY marca ASC", basedb, "marca", "id_marca")

        'Cargo todos los proveedores
        cargar_combo(cmb_proveedor, "SELECT id_proveedor, nombre FROM proveedores ORDER BY nombre ASC", basedb, "nombre", "id_proveedor")

        'Cargo todas las roscas
        cargar_combo(cmb_rosca, "SELECT id_rosca, rosca FROM roscas ORDER BY rosca ASC", basedb, "rosca", "id_rosca")

        'Cargo todos los I.V.A.
        cargar_combo(cmb_iva, "SELECT id_iva, descripcion FROM iva ORDER BY id_iva ASC", basedb, "descripcion", "id_iva")

        If edicion = True Or borrado = True Then
            chk_secuencia.Enabled = False
            txt_item.Text = edita_item.item
            txt_ean.Text = edita_item.EAN
            txt_desc.Text = edita_item.descript
            cantidad = edita_item.cantidad
            txt_costo.Text = edita_item.costo
            txt_prclista.Text = edita_item.precio_lista
            txt_wega.Text = edita_item.wega
            txt_fram.Text = edita_item.fram
            txt_mann.Text = edita_item.mann
            txt_markup.Text = edita_item.markup
            txt_descuento.Text = edita_item.descuento

            cmb_cat.SelectedValue = edita_item.id_tipo
            cmb_marca.SelectedValue = edita_item.id_marca
            cmb_proveedor.SelectedValue = edita_item.id_proveedor
            cmb_iva.SelectedValue = edita_item.id_iva

            If edita_item.id_rosca = 0 Then
                chk_rosca.Checked = False
                cmb_rosca.Text = ""
                cmb_rosca.Enabled = False
                psearch_rosca.Enabled = False
            Else
                chk_rosca.Checked = True
                cmb_rosca.SelectedValue = edita_item.id_rosca
            End If

            chk_activo.Checked = edita_item.activo
            chk_checkStock.Checked = edita_item.checkStock
            txt_stockRepo.Text = edita_item.stockRepo
            chk_oferta.Checked = edita_item.oferta
            txt_oem.Text = edita_item.oem
            txt_dateUltimaMod.Text = info_item_ultima_mod(edita_item.id_item.ToString)
            If txt_dateUltimaMod.Text = "0" Or txt_dateUltimaMod.Text = "error" Then txt_dateUltimaMod.Text = "N/A"
        Else
            cmb_cat.Text = "Seleccione una categoría"
            cmb_marca.Text = "Seleccione una marca"
            cmb_proveedor.Text = "Seleccione un proveedor"
            cmb_rosca.Text = "Seleccione una rosca"
            cmb_iva.Text = "Seleccione un % de I.V.A."
            txt_stockRepo.Text = 0
        End If

        If borrado = True Then
            txt_item.Enabled = False
            txt_ean.Enabled = False
            txt_desc.Enabled = False
            txt_costo.Enabled = False
            txt_prclista.Enabled = False
            txt_wega.Enabled = False
            txt_fram.Enabled = False
            txt_mann.Enabled = False
            txt_markup.Enabled = False
            txt_descuento.Enabled = False
            cmb_iva.Enabled = False
            cmb_cat.Enabled = False
            cmb_marca.Enabled = False
            cmb_proveedor.Enabled = False
            cmb_rosca.Enabled = False
            chk_activo.Enabled = False
            chk_rosca.Enabled = False
            chk_checkStock.Enabled = False
            chk_oferta.Enabled = False
            txt_stockRepo.Enabled = False
            txt_oem.Enabled = False
            psearch_marca.Enabled = False
            psearch_proveedor.Enabled = False
            psearch_tipo.Enabled = False
            psearch_rosca.Enabled = False
            cmd_ok.Visible = False
            cmd_exit.Visible = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar este item?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If (borraritem(edita_item)) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado del item, ¿desea intectar desactivarlo para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updatecliente(edita_cliente, True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero el item no se borró definitivamente." + Chr(13) +
                                "Esto posiblemente se deba a que el item, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar el item, consulte con el programador")
                        End If
                    End If
                End If
            End If
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If txt_item.Text = "" Then
            MsgBox("El campo 'Item' es obligatorio y está vacio", vbExclamation, "Dr. Oil")
            Exit Sub
        ElseIf txt_desc.Text = "" Then
            MsgBox("El campo 'Descripción' es obligatorio y está vacio", vbExclamation, "Dr. Oil")
            Exit Sub
        ElseIf txt_costo.Text = "" Then
            MsgBox("El campo 'Costo' es obligatorio y está vacio", vbExclamation, "Dr. Oil")
            Exit Sub
        ElseIf txt_prclista.Text = "" Then
            MsgBox("El campo 'Precio de lista' es obligatorio y está vacio", vbExclamation, "Dr. Oil")
            Exit Sub
        ElseIf lbl_markup.Text = "" Then
            MsgBox("El campo 'Markup' es obligatorio y está vacio", vbExclamation, "Dr. Oil")
            Exit Sub
        ElseIf cmb_iva.Text = "Seleccione un % de I.V.A." Or cmb_iva.Text = "" Then
            MsgBox("Debe seleccionar un % de I.V.A.", vbExclamation, "Dr. Oil")
            Exit Sub
        ElseIf cmb_cat.Text = "Seleccione una categoría" Or cmb_cat.Text = "" Then
            MsgBox("Debe seleccionar una categoría", vbExclamation, "Dr. Oil")
            Exit Sub
        ElseIf cmb_marca.Text = "Seleccione una marca" Or cmb_marca.Text = "" Then
            MsgBox("Debe seleccionar una marca", vbExclamation, "Dr. Oil")
            Exit Sub
        ElseIf cmb_proveedor.Text = "Seleccione un proveedor" Or cmb_proveedor.Text = "" Then
            MsgBox("Debe seleccionar un proveedor", vbExclamation, "Dr. Oil")
            Exit Sub
        ElseIf chk_checkStock.Checked And txt_stockRepo.Text = "" Then
            MsgBox("Si quiere que se verifique el stock de este item, debe ingresar un stock mínimo de reposición", vbExclamation, "Dr. Oil")
            Exit Sub
        End If

        Dim tmp As New item
        With tmp
            .item = txt_item.Text
            .EAN = txt_ean.Text
            .descript = txt_desc.Text
            .cantidad = cantidad
            .costo = txt_costo.Text
            .precio_lista = txt_prclista.Text
            .markup = txt_markup.Text
            .descuento = txt_descuento.Text
            .id_iva = cmb_iva.SelectedValue
            '.id_tipo = CInt(cmb_cat.SelectedItem(0).ToString)
            '.id_marca = CInt(cmb_marca.SelectedItem(0).ToString)
            '.id_proveedor = CInt(cmb_proveedor.SelectedItem(0).ToString)
            .id_tipo = cmb_cat.SelectedValue
            .id_marca = cmb_marca.SelectedValue
            .id_proveedor = cmb_proveedor.SelectedValue
            .wega = txt_wega.Text
            .fram = txt_fram.Text
            .mann = txt_mann.Text
            .oem = txt_oem.Text
            If chk_rosca.Checked = True Then .id_rosca = CInt(cmb_rosca.SelectedItem(0).ToString)
            .activo = chk_activo.Checked
            .checkStock = chk_checkStock.Checked
            .stockRepo = ConvertToInteger(txt_stockRepo.Text)
            .oferta = chk_oferta.Checked
            'If txt_dateUltimaMod.Text = "N/A" Then txt_dateUltimaMod.Text = Hoy_SoloFecha()
            txt_dateUltimaMod.Text = Hoy_SoloFecha()
        End With

        If edicion = True Then
            tmp.id_item = edita_item.id_item
            tmp.ultima_modificacion = Hoy()
            If updateitem(tmp) = False Then
                MsgBox("Hubo un problema al actualizar el item, consulte con su programdor", vbExclamation)
                'closeandupdate(Me)
                add_item_FormClosed(Nothing, Nothing)
            End If
            If update_item_fecha_Ultima_mod(edita_item.id_item.ToString, txt_dateUltimaMod.Text) = False Then
                MsgBox("Hubo un problema al actualizar el item, consulte con su programdor", vbExclamation)
                'closeandupdate(Me)
                Add_item_FormClosed(Nothing, Nothing)
            End If
        Else
            additem(tmp)
        End If

        If chk_secuencia.Checked = True Then
            txt_item.Text = ""
            txt_ean.Text = ""
            txt_desc.Text = ""
            'txt_cantidad.Text = ""
            txt_costo.Text = ""
            txt_prclista.Text = ""
            txt_wega.Text = ""
            txt_fram.Text = ""
            txt_mann.Text = ""
            txt_oem.Text = ""
            txt_markup.Text = 0
            txt_descuento.Text = 0
            'Cargo todas las categorias
            cargar_combo(cmb_cat, "SELECT id_tipo, tipo FROM tipos_items ORDER BY tipo ASC", basedb, "tipo", "id_tipo")
            cmb_cat.Text = "Seleccione una categoría"

            'Cargo todas las marcas
            cargar_combo(cmb_marca, "SELECT id_marca, marca FROM marcas_items ORDER BY marca ASC", basedb, "marca", "id_marca")
            cmb_marca.Text = "Seleccione una marca"

            'Cargo todos los proveedores
            cargar_combo(cmb_proveedor, "SELECT id_proveedor, nombre FROM proveedores ORDER BY nombre ASC", basedb, "nombre", "id_proveedor")
            cmb_proveedor.Text = "Seleccione un proveedor"

            'Cargo todas las roscas
            cargar_combo(cmb_rosca, "SELECT id_rosca, rosca FROM roscas ORDER BY rosca ASC", basedb, "rosca", "id_rosca")
            cmb_rosca.Text = "Seleccione una rosca"

            'Cargo todos los I.V.A.
            cargar_combo(cmb_iva, "SELECT id_iva, descripcion FROM iva ORDER BY id_iva ASC", basedb, "descripcion", "id_iva")
            cmb_iva.Text = "Seleccione un % de I.V.A."
            chk_activo.Checked = True
            chk_checkStock.Checked = False
            chk_oferta.Checked = False
            txt_stockRepo.Text = 0
        Else
            'closeandupdate(Me)
            add_item_FormClosed(Nothing, Nothing)
        End If
    End Sub

    Private Sub psearch_marca_Click(sender As Object, e As EventArgs) Handles psearch_marca.Click
        Dim tmp As String
        tmp = tabla
        tabla = "marcas_items"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        cmb_marca.SelectedValue = id
        id = 0
    End Sub

    Private Sub psearch_proveedor_Click(sender As Object, e As EventArgs) Handles psearch_proveedor.Click
        Dim tmp As String
        tmp = tabla
        tabla = "proveedores"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        cmb_proveedor.SelectedValue = id
        id = 0
    End Sub

    Private Sub psearch_tipo_Click(sender As Object, e As EventArgs) Handles psearch_tipo.Click
        Dim tmp As String
        tmp = tabla
        tabla = "tipos_items"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        cmb_cat.SelectedValue = id
        id = 0
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        'closeandupdate(Me)
        add_item_FormClosed(Nothing, Nothing)
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

    Private Sub chk_rosca_CheckedChanged(sender As Object, e As EventArgs) Handles chk_rosca.CheckedChanged
        If chk_rosca.Checked = True Then
            cmb_rosca.Enabled = True
            psearch_rosca.Enabled = True
            cargar_combo(cmb_rosca, "SELECT r.id_rosca AS 'ID', r.rosca AS 'Rosca' FROM roscas AS r ORDER BY r.rosca ASC", basedb, "Rosca", "ID")
        Else
            cmb_rosca.Enabled = False
            psearch_rosca.Enabled = False
            cmb_rosca.Text = ""
            'cmb_rosca.Items.Clear()
        End If
    End Sub

    Private Sub psearch_rosca_DoubleClick(sender As Object, e As EventArgs) Handles psearch_rosca.DoubleClick
        Dim tmp As String
        tmp = tabla
        tabla = "roscas"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        'cmb_rosca.SelectedIndex = cmb_rosca.FindString(info_rosca(id).rosca)
        cmb_rosca.SelectedValue = id
        'cmb_cat.SelectedIndex = id
        id = 0
    End Sub

    Private Sub psearch_iva_Click(sender As Object, e As EventArgs) Handles psearch_iva.Click
        Dim tmp As String
        tmp = tabla
        tabla = "iva"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        cmb_iva.SelectedValue = id
        id = 0
    End Sub

    Private Sub calculaPrecioLista()
        If Not txt_costo.Text = vbNullString Then
            Dim costo As String
            Dim markup As String
            Dim descuento As String
            Dim iva As String
            Dim prclista As String

            prclista = txt_prclista.Text
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

            txt_prclista.Text = MyRound(prclista, 50)
            'txt_prclista.Text = MyRound_2(prclista)
        End If
    End Sub

    Private Sub txt_stockRepo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_stockRepo.KeyPress
        If Not esNumero(e) Then
            e.KeyChar = ""
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