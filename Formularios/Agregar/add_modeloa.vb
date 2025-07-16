Public Class add_modeloa

    Private Sub Add_modeloa_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Add_modeloa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form = Me

        'Cargo todas las marcas
        cargar_combo(cmb_marcas, "SELECT * FROM marcas_autos ORDER BY marca ASC", basedb, "marca", "id_marca")
        cmb_marcas.Text = "Seleccione una marca"
        If edicion = True Then
            txt_modelo.Text = edita_modeloa.modelo
        End If

        chk_activo.Checked = True
        If edicion = True Or borrado = True Then
            chk_secuencia.Enabled = False
            'Dim i As Integer

            'Selecciono la marca del modelo que se está editando en el combo

            'For i = 0 To cmb_marcas.Items.Count - 1
            '   MsgBox(cmb_marcas.Items(i).ToString & " " & info_marcaa(edita_modeloa.id_marca).marca)
            '  If cmb_marcas.Items(i).ToString = info_marcaa(edita_modeloa.id_marca).marca Then
            'cmb_marcas.SelectedIndex = i
            'Exit For
            'End If
            '   Next

            'cmb_marcas.SelectedItem = edita_modeloa.id_marca

            cmb_marcas.SelectedValue = edita_modeloa.id_marca


            txt_modelo.Text = edita_modeloa.modelo
            chk_activo.Checked = edita_modeloa.activo
        End If

        If borrado = True Then
            cmb_marcas.Enabled = False
            txt_modelo.Enabled = False
            chk_activo.Enabled = False
            cmd_ok.Visible = False
            cmd_exit.Visible = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar este modelo?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If (borrarmodeloa(edita_modeloa)) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado del modelo, ¿desea intectar desactivarlo para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updatemodeloa(edita_modeloa, True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero el modelo no se borró definitivamente." + Chr(13) +
                                "Esto posiblemente se deba a que el modelo, tiene operaciones realizadas y/o dependencias por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar el modelo, consulte con el programador")
                        End If
                    End If
                End If
            End If
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        Me.Dispose()
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If txt_modelo.Text = "" Then
            MsgBox("El campo 'Modelo' es obligatorio y está vacio")
            Exit Sub
        End If

        Dim tmp As New modelo_auto
        tmp.id_marca = CInt(traer_info(basedb, "SELECT id_marca FROM marcas_autos WHERE marca = '" + cmb_marcas.Text + "'", 0)(0, 0))
        tmp.modelo = txt_modelo.Text
        tmp.activo = chk_activo.Checked

        If edicion = True Then
            tmp.id_modelo = edita_modeloa.id_modelo
            If updatemodeloa(tmp) = False Then
                MsgBox("Hubo un problema al actualizar el modelo, consulte con su programdor", vbExclamation)
                closeandupdate(Me)
            End If
        Else
            addmodeloa(tmp)
        End If

        If chk_secuencia.Checked = True Then
            txt_modelo.Text = ""
            chk_activo.Checked = True
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub pic_search_Click(sender As Object, e As EventArgs) Handles pic_search.Click
        Dim tmp As String
        tmp = tabla
        tabla = "marcas_autos"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        If id = 0 Then Exit Sub
        cmb_marcas.SelectedIndex = cmb_marcas.FindString(info_marcaa(id).marca)
        id = 0
    End Sub
End Class
