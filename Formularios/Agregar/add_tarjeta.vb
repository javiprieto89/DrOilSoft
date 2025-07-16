Public Class add_tarjeta
    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If txt_nombre.Text = "" Then
            MsgBox("El campo 'Nombre' es obligatorio y está vacio")
            Exit Sub
        ElseIf txt_recargo.Text = "" Then
            MsgBox("El campo 'Recargo' es obligatorio y está vacio")
            Exit Sub
        ElseIf txt_cuotas.Text = "" Then
            MsgBox("El campo 'Cuotas' es obligatorio y está vacio")
            Exit Sub
        End If

        Dim tmp As New tarjeta

        tmp.tarjeta = txt_nombre.Text
        tmp.recargo = txt_recargo.Text
        tmp.cuotas = txt_cuotas.Text
        tmp.id_grupo = cmb_grupoTarjetas.SelectedValue
        tmp.activo = chk_activo.Checked

        If edicion = True Then
            tmp.id_tarjeta = edita_tarjeta.id_tarjeta
            If updateTarjeta(tmp) = False Then
                MsgBox("Hubo un problema al actualizar la tarjeta, consulte con su programdor", vbExclamation)
                closeandupdate(Me)
            End If
        Else
            addTarjeta(tmp)
        End If

        If chk_secuencia.Checked = True Then
            txt_nombre.Text = ""
            txt_recargo.Text = ""
            txt_cuotas.Text = ""
            cmb_grupoTarjetas.SelectedValue = id_grupoTarjeta
            chk_activo.Checked = True
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    Private Sub Add_tarjeta_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub Add_tarjeta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Cargo todos los grupos de tarjetas
        cargar_combo(cmb_grupoTarjetas, "SELECT id_grupo, grupo FROM grupo_tarjetas ORDER BY grupo ASC", basedb, "grupo", "id_grupo")
        cmb_grupoTarjetas.SelectedValue = id_grupoTarjeta


        chk_activo.Checked = True
        If edicion = True Or borrado = True Then
            chk_secuencia.Enabled = False
            txt_nombre.Text = edita_tarjeta.tarjeta
            txt_recargo.Text = edita_tarjeta.recargo
            txt_cuotas.Text = edita_tarjeta.cuotas
            cmb_grupoTarjetas.SelectedValue = edita_tarjeta.id_grupo
            chk_activo.Checked = edita_tarjeta.activo
        End If

        If borrado = True Then
            txt_nombre.Enabled = False
            txt_recargo.Enabled = False
            txt_cuotas.Enabled = False
            cmb_grupoTarjetas.Enabled = False
            chk_activo.Enabled = False
            cmd_ok.Visible = False
            cmd_exit.Visible = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar esta tarjeta?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If (borrarTarjeta(edita_tarjeta)) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado de la tarjeta, ¿desea intectar desactivarlo para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updateTarjeta(edita_tarjeta, True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero la tarjeta no se borró definitivamente." + Chr(13) +
                                "Esto posiblemente se deba a que la tarjeta, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar la tarjeta, consulte con el programador")
                        End If
                    End If
                End If
            End If
            closeandupdate(Me)
        End If
    End Sub
End Class