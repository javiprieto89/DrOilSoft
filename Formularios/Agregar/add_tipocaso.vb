Public Class add_tipocaso
    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If txt_tipocaso.Text = "" Then
            MsgBox("El campo 'tipocaso' es obligatorio y está vacio")
        End If

        Dim tmp As New tipo_caso

        tmp.tipo = txt_tipocaso.Text
        tmp.activo = chk_activo.Checked

        If edicion = True Then
            tmp.id_tipocaso = edita_tipocaso.id_tipocaso
            If updatetipocaso(tmp) = False Then
                MsgBox("Hubo un problema al actualizar la tipocaso, consulte con su programdor", vbExclamation)
                closeandupdate(Me)
            End If
        Else
            addtipocaso(tmp)
        End If

        If chk_secuencia.Checked = True Then
            txt_tipocaso.Text = ""
            chk_activo.Checked = True
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    Private Sub Add_tipocaso_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub Add_tipocaso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chk_activo.Checked = True
        If edicion = True Or borrado = True Then
            chk_secuencia.Enabled = False
            txt_tipocaso.Text = edita_tipocaso.tipo
            chk_activo.Checked = edita_tipocaso.activo
        End If

        If borrado = True Then
            txt_tipocaso.Enabled = False
            chk_activo.Enabled = False
            cmd_ok.Visible = False
            cmd_exit.Visible = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar esta tipocaso?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If (borrartipocaso(edita_tipocaso)) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado de la tipocaso, ¿desea intectar desactivarlo para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updatetipocaso(edita_tipocaso, True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero la marca no se borró definitivamente." + Chr(13) +
                                "Esto posiblemente se deba a que la tipocaso, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar la tipocaso, consulte con el programador")
                        End If
                    End If
                End If
            End If
            closeandupdate(Me)
        End If
    End Sub
End Class