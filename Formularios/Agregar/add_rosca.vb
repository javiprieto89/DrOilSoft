Public Class add_rosca
    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If txt_rosca.Text = "" Then
            MsgBox("El campo 'Rosca' es obligatorio y está vacio")
        End If

        Dim tmp As New rosca

        tmp.rosca = txt_rosca.Text
        tmp.activo = chk_activo.Checked

        If edicion = True Then
            tmp.id_rosca = edita_rosca.id_rosca
            If updaterosca(tmp) = False Then
                MsgBox("Hubo un problema al actualizar la rosca, consulte con su programdor", vbExclamation)
                closeandupdate(Me)
            End If
        Else
            addrosca(tmp)
        End If

        If chk_secuencia.Checked = True Then
            txt_rosca.Text = ""
            chk_activo.Checked = True
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    Private Sub Add_rosca_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub Add_rosca_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chk_activo.Checked = True
        If edicion = True Or borrado = True Then
            chk_secuencia.Enabled = False
            txt_rosca.Text = edita_rosca.rosca
            chk_activo.Checked = edita_rosca.activo
        End If

        If borrado = True Then
            txt_rosca.Enabled = False
            chk_activo.Enabled = False
            cmd_ok.Visible = False
            cmd_exit.Visible = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar esta rosca?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If (borrarrosca(edita_rosca)) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado de la rosca, ¿desea intectar desactivarlo para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updaterosca(edita_rosca, True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero la marca no se borró definitivamente." + Chr(13) +
                                "Esto posiblemente se deba a que la rosca, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar la rosca, consulte con el programador")
                        End If
                    End If
                End If
            End If
            closeandupdate(Me)
        End If
    End Sub
End Class