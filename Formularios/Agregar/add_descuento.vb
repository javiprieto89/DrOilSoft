Public Class add_descuento
    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If txt_descript.Text = "" Then
            MsgBox("El campo 'Descripcion' es obligatorio y está vacio")
            Exit Sub
        ElseIf txt_descuento.Text = "" Then
            MsgBox("El campo 'Descuento' es obligatorio y está vacio")
            Exit Sub
        End If

        Dim tmp As New descuento

        tmp.descript = txt_descript.Text
        tmp.descuento = txt_descuento.Text
        tmp.activo = chk_activo.Checked
        tmp.isSystem = 0

        If edicion = True Then
            tmp.id_descuento = edita_descuento.id_descuento
            If updatedescuento(tmp) = False Then
                MsgBox("Hubo un problema al actualizar el descuento, consulte con su programdor", vbExclamation)
                closeandupdate(Me)
            End If
        Else
            adddescuento(tmp)
        End If

        If chk_secuencia.Checked = True Then
            txt_descript.Text = ""
            txt_descuento.Text = ""
            chk_activo.Checked = True
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

    Private Sub Add_descuento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chk_activo.Checked = True
        If edicion = True Or borrado = True Then
            chk_secuencia.Enabled = False
            txt_descript.Text = edita_descuento.descript
            txt_descuento.Text = edita_descuento.descuento
            chk_activo.Checked = edita_descuento.activo
            If edita_descuento.isSystem Then
                MsgBox("No se puede actualizar este descuento porque es un descuento generado automáticamente por el sistema y borrarlo afectaria el correcto funcionamiento del mismo.", vbCritical + vbOKOnly, "DR.Oil")
                closeandupdate(Me)
                Exit Sub
            End If
        End If

        If borrado = True Then
            txt_descript.Enabled = False
            txt_descuento.Enabled = False
            chk_activo.Enabled = False
            cmd_ok.Visible = False
            cmd_exit.Visible = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar este descuento?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If (borrarDescuento(edita_descuento)) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado del descuento, ¿desea intectar desactivarlo para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updateDescuento(edita_descuento, True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero el descuento no se borró definitivamente." + Chr(13) +
                                "Esto posiblemente se deba a que el descuento, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar el descuento, consulte con el programador")
                        End If
                    End If
                End If
            End If
            closeandupdate(Me)
        End If
    End Sub
End Class