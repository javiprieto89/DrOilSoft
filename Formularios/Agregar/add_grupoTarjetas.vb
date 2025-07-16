Public Class add_grupoTarjetas
    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If txt_grupo.Text = "" Then
            MsgBox("El campo 'Grupo' es obligatorio y está vacio")
        End If

        Dim tmp As New grupoTarjetas

        tmp.grupo = txt_grupo.Text

        If edicion = True Then
            tmp.id_grupo = edita_grupoTarjetas.id_grupo
            If updateGrupoTarjetas(tmp) = False Then
                MsgBox("Hubo un problema al actualizar el grupo de tarjetas, consulte con su programdor", vbExclamation)
                closeandupdate(Me)
            End If
        Else
            addGrupoTarjetas(tmp)
        End If

        If chk_secuencia.Checked = True Then
            txt_grupo.Text = ""
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    Private Sub Add_grupoTarjeta_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub Add_grupoTarjeta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If edicion = True Or borrado = True Then
            chk_secuencia.Enabled = False
            txt_grupo.Text = edita_grupoTarjetas.grupo
        End If

        If borrado = True Then
            txt_grupo.Enabled = False
            cmd_ok.Visible = False
            cmd_exit.Visible = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar este grupo?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If (borrarGrupoTarjetas(edita_grupoTarjetas)) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado del grupo, ¿desea intectar desactivarlo para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updateGrupoTarjetas(edita_grupoTarjetas, True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero el grupo no se borró definitivamente." + Chr(13) +
                                "Esto posiblemente se deba a que el grupo, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar el grupo, consulte con el programador")
                        End If
                    End If
                End If
            End If
            closeandupdate(Me)
        End If
    End Sub
End Class