Public Class add_mecanico
    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If Not CheckRequiredField(txt_nombre, "Nombre") Then Exit Sub
        If Not CheckRequiredField(txt_porcentaje, "Porcentaje") Then Exit Sub

        Dim tmp As New mecanico

        tmp.nombre = txt_nombre.Text
        tmp.porcentaje = Val(txt_porcentaje.Text)
        tmp.activo = chk_activo.Checked

        If edicion = True Then
            tmp.id_mecanico = edita_mecanico.id_mecanico
            If updatemecanico(tmp) = False Then
                MsgBox("Hubo un problema al actualizar el mecánico, consulte con su programdor", vbExclamation)
                closeandupdate(Me)
            End If
        Else
            addmecanico(tmp)
        End If

        If chk_secuencia.Checked = True Then
            txt_nombre.Text = ""
            chk_activo.Checked = True
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    Private Sub Add_mecanico_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub Add_mecanico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chk_activo.Checked = True
        If edicion = True Or borrado = True Then
            chk_secuencia.Enabled = False
            txt_nombre.Text = edita_mecanico.nombre
            txt_porcentaje.Text = edita_vendedor.porcentaje.ToString
            chk_activo.Checked = edita_mecanico.activo
        End If

        If borrado = True Then
            txt_nombre.Enabled = False
            txt_porcentaje.Enabled = False
            chk_activo.Enabled = False
            cmd_ok.Visible = False
            cmd_exit.Visible = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar este mecánico?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If (borrarmecanico(edita_mecanico)) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado del mecánico, ¿desea intectar desactivarlo para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updatemecanico(edita_mecanico, True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero el mecánico no se borró definitivamente." + Chr(13) +
                                "Esto posiblemente se deba a que el mecánico, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar el mecánico, consulte con el programador")
                        End If
                    End If
                End If
            End If
            closeandupdate(Me)
        End If
    End Sub
End Class