Public Class pre_fe
    Public comprobanteSeleccionado As comprobante
    Dim c As New cliente

    Private Sub pre_fe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_date.Text = Format(DateTime.Now, "dd/MM/yyyy")

        'Cargo el pedido
        edita_pedido = info_pedido(edita_fe.id_pedido)

        'Cargo el cliente
        c = info_cliente(edita_pedido.id_cliente)
        lbl_cliente.Text = "Cliente: " + c.nombre + " " + c.apellido

        cargarChk()

        cargar_datagrid(dgv_item, "SELECT pit.id_item AS 'ID', i.item AS 'Item', ti.tipo AS 'Categoría', pit.cantidad AS 'Cantidad', pit.precio AS 'Precio', " &
                    "CAST(pit.cantidad * pit.precio AS DECIMAL(18,3)) AS 'Subtotal', CASE WHEN i.oferta = 0 THEN 'No' ELSE 'Si' END AS 'Oferta' " &
                   "FROM pedidos_detalle AS pit " &
                    "LEFT JOIN items AS i ON pit.id_item = i.id_item " &
                    "LEFT JOIN tipos_items AS ti ON i.id_tipo = ti.id_tipo " &
                    "WHERE pit.activo = '1' AND pit.id_pedido = '" + edita_pedido.id_pedido.ToString + "'", basedb)
        resaltarcolumnaDG(dgv_item, 4, Color.Red)

        txt_notas.Text = edita_pedido.notas
        cmb_condicion.SelectedValue = edita_pedido.id_condicion
        cmb_descuento.SelectedValue = edita_pedido.id_descuento
        cmb_caja.SelectedValue = edita_pedido.id_caja


        '20220728

        'If c.esInscripto Then
        '    edita_fe.subtotal = Math.Round(edita_pedido.total / 1.21, 2)
        '    edita_fe.impuestos = Math.Round(edita_pedido.total - (edita_pedido.total / 1.21), 2)
        'Else
        '    edita_fe.subtotal = edita_pedido.total
        '    edita_fe.impuestos = 0
        '    edita_fe.total = edita_pedido.total
        'End If

        edita_fe.subtotal = Math.Round(edita_pedido.total / 1.21, 2)
        edita_fe.impuestos = Math.Round(edita_pedido.total - (edita_pedido.total / 1.21), 2)
        edita_fe.total = edita_pedido.total

        txt_subTotal.Text = edita_fe.subtotal
        txt_impuestos.Text = edita_fe.impuestos
        txt_total.Text = edita_fe.total

        If info_condicion(edita_pedido.id_condicion).id_tarjeta <> 1 Then
            'chk_pagoCombinado.Enabled = True
            If edita_pedido.montoTarjeta <> edita_pedido.total Then chk_pagoCombinado.Checked = True
        End If

        Dim cn As New condicion
        cn = info_condicion(cmb_condicion.SelectedValue)

        cmb_comprobante.SelectedValue = -1

        'recargo = info_tarjeta(c.id_tarjeta).recargo
        'descuento = info_descuento(cmb_descuento.SelectedValue).descuento
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    Private Sub cargarChk()
        Dim str As String
        Dim condicion As String

        'Cargo todos los comprobantes
        'str = "SELECT c.id_comprobante AS 'id_comprobante', c.comprobante AS 'Comprobante' FROM comprobantes AS c WHERE c.activo = '1' "
        'str += "ORDER BY c.comprobante ASC"
        'cargar_combo(cmb_comprobante, str, basedb, "comprobante", "id_comprobante")

        If c.id_tipoDocumento = 80 And c.esInscripto Then
            condicion = "IN"
        Else
            condicion = "Not IN"
        End If

        str = "SELECT c.id_comprobante AS 'id_comprobante', c.comprobante AS 'comprobante' " &
                            "FROM comprobantes AS c " &
                            "WHERE c.activo = '1' AND (c.id_tipoComprobante " + condicion + " (1, 2, 3, 4, 5, 63, 34, 39, 60) OR c.id_tipoComprobante IN (0, 99, 199)) " &
                            "ORDER BY c.comprobante ASC"

        cargar_combo(cmb_comprobante, str, basedb, "comprobante", "id_comprobante")
        cmb_comprobante.SelectedValue = -1
        cmb_comprobante.Text = "Elija un comprobante..."

        'Cargo todas las condiciones de venta
        str = "SELECT c.id_condicion AS 'id_condicion', c.condicion AS 'Condicion' FROM condiciones AS c WHERE c.activo = '1' "
        str += "ORDER BY c.condicion ASC"
        cargar_combo(cmb_condicion, str, basedb, "condicion", "id_condicion")

        'Cargo todos los descuentos
        str = "SELECT d.id_descuento AS 'id_descuento', d.descripcion AS 'descripcion' FROM descuentos AS d WHERE d.activo = '1' "
        str += "ORDER BY d.descripcion ASC"
        cargar_combo(cmb_descuento, str, basedb, "descripcion", "id_descuento")

        'Cargo todas las cajas
        str = "SELECT c.id_caja AS 'id_caja', c.nombre AS 'nombre' FROM cajas AS c WHERE c.activo = '1' "
        str += "ORDER BY c.nombre ASC"
        cargar_combo(cmb_caja, str, basedb, "nombre", "id_caja")
    End Sub

    Public Sub checkCustNoTaxNumber()
        Select Case comprobanteSeleccionado.id_tipoComprobante
            Case Is = 1, 2, 3, 6, 7, 8, 4, 5, 9, 10, 63, 64, 34, 35, 39, 40, 60, 61, 11, 12, 13, 15, 49, 51, 52, 53, 54
                If c.dni = "" Then
                    cmd_emitir.Enabled = False
                    lbl_noTaxNumber.Visible = True
                Else
                    cmd_emitir.Enabled = True
                    lbl_noTaxNumber.Visible = False
                End If
            Case Else
                cmd_emitir.Enabled = True
                lbl_noTaxNumber.Visible = False
        End Select
    End Sub

    Private Sub cmb_comprobante_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_comprobante.SelectionChangeCommitted
        comprobanteSeleccionado = info_comprobante(cmb_comprobante.SelectedValue)
        checkCustNoTaxNumber()
    End Sub

    Private Sub cmd_emitir_Click(sender As Object, e As EventArgs) Handles cmd_emitir.Click
        If cmb_comprobante.SelectedValue = -1 Or cmb_comprobante.SelectedValue Is Nothing Then
            MsgBox("Para poder facturar debe elegir un tipo de documento", vbExclamation + vbOKOnly, "Dr. Oil")
            Exit Sub
        End If

        If facturar(edita_pedido, edita_fe, info_comprobante(cmb_comprobante.SelectedValue)) Then
            imprimirFactura(edita_pedido.id_pedido, 0, chk_remitos.Checked)
        Else
            MsgBox("Ha ocurrido un error al facturar", vbExclamation, "DR.Oil")
        End If

        closeandupdate(Me)
        'emitir = False
    End Sub

    Private Sub pic_searchComprobante_Click(sender As Object, e As EventArgs) Handles pic_searchComprobante.Click
        'busqueda
        Dim tmp As String

        tmp = tabla
        tabla = "comprobantes"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        cmb_comprobante.SelectedValue = id
    End Sub
End Class