Public Class add_pagoCombinado
    Private c As New condicion
    Private t As New tarjeta

    Private Sub Add_pagoCombinado_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub Add_pagoCombinado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim recargo_tarjeta As Double
        Dim descuento As Double

        c = info_condicion(edita_pedido.id_condicion)
        t = info_tarjeta(c.id_tarjeta)
        descuento = info_descuento(edita_pedido.id_descuento).descuento
        descuento = (edita_pedido.subTotal * (descuento / 100))

        txt_condicion.Text = info_condicion(edita_pedido.id_condicion).condicion
        txt_recargo.Text = t.recargo.ToString & "%"
        txt_descuento.Text = descuento.ToString

        If edita_pedido.montoTarjeta <> 0 Then
            txt_montoContado.Text = edita_pedido.total - edita_pedido.montoTarjeta
            recargo_tarjeta = recargoTarjeta(t.recargo, edita_pedido.montoTarjeta)
            'recargo_tarjeta = Math.Ceiling(recargo_tarjeta * descuento)
            txt_montoTarjeta.Text = recargo_tarjeta
            txt_montoConRecargo.Text = edita_pedido.montoTarjeta
        Else
            txt_montoContado.Text = "0"
            txt_montoTarjeta.Text = edita_pedido.subTotal
            txt_montoConRecargo.Text = edita_pedido.total
        End If
        txt_subtotal.Text = edita_pedido.subTotal
        txt_total.Text = edita_pedido.total

        If edicion And Not edita_pedido.activo Then txt_montoContado.Enabled = False
    End Sub

    Private Sub txt_montoContado_LostFocus(sender As Object, e As EventArgs) Handles txt_montoContado.LostFocus
        Dim montoContado As Double
        Dim montoTarjeta_sinRecargo As Double
        Dim montoTarjeta_conRecargo As Double
        Dim descuento As Double
        Dim total As Double

        Try
            montoContado = txt_montoContado.Text
        Catch ex As Exception
            montoContado = 0
        End Try

        descuento = txt_descuento.Text
        montoTarjeta_sinRecargo = edita_pedido.subTotal - montoContado - descuento
        montoTarjeta_conRecargo = ((t.recargo * montoTarjeta_sinRecargo) / 100) + montoTarjeta_sinRecargo
        total = montoContado + montoTarjeta_conRecargo

        txt_montoTarjeta.Text = montoTarjeta_sinRecargo
        txt_montoConRecargo.Text = montoTarjeta_conRecargo
        txt_total.Text = total

        If montoContado > total Then
            MsgBox("La suma del monto pagado en contado, no puede superar el monto total de la operación", vbOKOnly + vbExclamation, "Dr. Oil")
            txt_montoContado.Text = 0
            Exit Sub
        ElseIf montoTarjeta_sinRecargo = 0 Then
            MsgBox("La suma del monto pagado en tarjeta, no puede ser 0", vbOKOnly + vbExclamation, "Dr. Oil")
            Exit Sub
        ElseIf montoContado + montoTarjeta_conRecargo > total Then
            MsgBox("La suma del monto pagado en contado y el monto pagado en tarjeta, no puede superar el monto total de la operación", vbOKOnly + vbExclamation, "Dr. Oil")
            Exit Sub
        End If
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        ' If edicion And edita_pedido.activo Then
        edita_pedido.montoTarjeta = txt_montoConRecargo.Text
        edita_pedido.total = txt_total.Text
        updatepedido(edita_pedido)
        'End If
        closeandupdate(Me)
    End Sub

    Private Function recargoTarjeta(ByVal r As Double, ByVal total As Double) As Double
        Dim divisor_descuento As Double
        Dim recargo_tarjeta As Double

        If r > 10 Then
            divisor_descuento = Val("1." & extraer_numeros(r.ToString))
        Else
            divisor_descuento = Val("1.0" & extraer_numeros(r.ToString))
        End If

        recargo_tarjeta = total / divisor_descuento
        Return Math.Ceiling(recargo_tarjeta)
    End Function
End Class