Public Class consulta_caja
    Private Sub psearch_caja_Click(sender As Object, e As EventArgs) Handles psearch_caja.Click
        Dim tmp As String
        tmp = tabla
        tabla = "caja"
        Me.Enabled = False
        form = Me
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        cmb_caja.SelectedIndex = cmb_caja.FindString(info_caja(id).nombre)
        id = 0
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub
    Private Sub consulta_caja_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub cmd_consultar_Click(sender As Object, e As EventArgs) Handles cmd_consultar.Click
        Dim saldo As saldoCaja

        If Not chk_pedidos.Checked And Not chk_casos.Checked Then
            MsgBox("Debe elegir o pedidos o casos para sumar y poder hacer la consulta." & Chr(13) & "Por favor seleccione 'Sumar pedidos', 'Sumar casos' o ambos si quiere.", MsgBoxStyle.Exclamation + vbOKOnly, "Dr. Oil")
            Exit Sub
        End If

        If Not chk_abiertos.Checked And Not chk_cerrados.Checked Then
            MsgBox("Debe elegir o pedidos/casos abiertos o cerrados para sumar y poder hacer la consulta." & Chr(13) & "Por favor seleccione 'Sumar pedidos/casos abiertos', 'Sumar pedidos/casos cerrados' o ambos si quiere.", MsgBoxStyle.Exclamation + vbOKOnly, "Dr. Oil")
            Exit Sub
        End If

        saldo = consultaSaldoCaja(cmb_caja.SelectedValue, dtp_desde.Value.Date, dtp_hasta.Value.Date, chk_pedidos.Checked,
                                    chk_casos.Checked, chk_abiertos.Checked, chk_cerrados.Checked)

        If saldo.contado = -9999999 Then
            MsgBox("Ha ocurrido un error al obtener el saldo de caja, consulte con el programador", vbOKOnly + vbExclamation, "Dr. Oil")
        Else
            txt_contado.Text = "$ " + saldo.contado.ToString
            txt_tarjeta.Text = "$ " + saldo.tarjeta.ToString
            txt_total.Text = "$ " + saldo.total.ToString
        End If

        If MsgBox("¿Desea realizar el cierre diario?", vbQuestion + vbYesNo, "Dr. Oil") = vbYes Then
            If cierreDiario(dtp_desde.Value.Date, dtp_hasta.Value.Date, chk_pedidos.Checked, chk_casos.Checked) Then
                MsgBox("Se ha realizado correctamente el cierre diario", vbInformation + vbOKOnly, "Dr. Oil")
            Else
                MsgBox("Ha ocurrido un error al realizar el cierre diario." & Chr(13) & "Consulte con el programador.", vbExclamation + vbOKOnly, "Dr. Oil")
            End If
        End If
    End Sub


    Private Sub consulta_caja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Cargo todas las cajas
        cargar_combo(cmb_caja, "SELECT c.id_caja AS 'id_caja', c.nombre AS 'nombre' FROM cajas AS c WHERE c.activo = '1' ORDER BY c.nombre ASC", basedb, "nombre", "id_caja")

        'dtp_desde.CustomFormat = "MM dd yyyy"
        'dtp_hasta.CustomFormat = "MM dd yyyy"
    End Sub
End Class