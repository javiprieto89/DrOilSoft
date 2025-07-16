Public Class add_condicion
    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If txt_condicion.Text = "" Then
            MsgBox("El campo 'Condicion' es obligatorio y está vacio")
            Exit Sub
        ElseIf txt_vencimiento.Text = "" Then
            MsgBox("El campo 'Vencimiento' es obligatorio y está vacio")
            Exit Sub
        ElseIf txt_recargo.Text = "" Then
            MsgBox("El campo 'Recargo' es obligatorio y está vacio")
            Exit Sub
        End If

        Dim tmp As New condicion

        tmp.condicion = txt_condicion.Text
        tmp.vencimiento = txt_vencimiento.Text
        tmp.recargo = txt_recargo.Text
        tmp.activo = chk_activo.Checked
        tmp.id_tarjeta = cmb_tarjeta.SelectedValue

        If edicion = True Then
            tmp.id_condicion = edita_condicion.id_condicion
            If updateCondicion(tmp) = False Then
                MsgBox("Hubo un problema al actualizar la condicion, consulte con su programdor", vbExclamation)
                closeandupdate(Me)
            End If
        Else
            addCondicion(tmp)
        End If

        If chk_secuencia.Checked = True Then
            txt_condicion.Text = ""
            txt_vencimiento.Text = ""
            txt_recargo.Text = ""
            chk_activo.Checked = True
            cmb_tarjeta.SelectedValue = id_tarjeta
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    Private Sub Add_marcai_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub Add_condicion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Cargo todas las tarjetas de crédito
        cargar_combo(cmb_tarjeta, "SELECT id_tarjeta, tarjeta FROM tarjetas ORDER BY tarjeta ASC", basedb, "tarjeta", "id_tarjeta")
        cmb_tarjeta.SelectedValue = id_tarjeta

        chk_activo.Checked = True
        If edicion = True Or borrado = True Then
            chk_secuencia.Enabled = False
            txt_condicion.Text = edita_condicion.condicion
            txt_vencimiento.Text = edita_condicion.vencimiento
            txt_recargo.Text = edita_condicion.recargo
            chk_activo.Checked = edita_condicion.activo
            cmb_tarjeta.SelectedValue = edita_condicion.id_tarjeta
        End If

        If borrado = True Then
            txt_condicion.Enabled = False
            txt_vencimiento.Enabled = False
            txt_recargo.Enabled = False
            chk_activo.Enabled = False
            cmd_ok.Visible = False
            cmd_exit.Visible = False
            cmb_tarjeta.Enabled = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar esta condición?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If (borrarCondicion(edita_condicion)) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado de la condición, ¿desea intectar desactivarlo para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updateCondicion(edita_condicion, True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero la condición no se borró definitivamente." + Chr(13) +
                                "Esto posiblemente se deba a que la condición, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar la condición, consulte con el programador")
                        End If
                    End If
                End If
            End If
            closeandupdate(Me)
        End If
    End Sub
End Class