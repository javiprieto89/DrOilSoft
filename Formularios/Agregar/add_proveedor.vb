Public Class add_proveedor
    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If Not CheckRequiredField(txt_nombre, "Nombre") Then Exit Sub

        Dim p As New proveedor

        p.nombre = txt_nombre.Text
        p.dni = txt_dni.Text
        p.telefono = txt_tel.Text
        p.email = txt_email.Text
        p.direccion = txt_direccion.Text
        p.vendedor = txt_vendedor.Text
        p.activo = chk_activo.Checked

        If edicion = True Then
            p.id_proveedor = edita_proveedor.id_proveedor
            If updateproveedor(p) = False Then
                MsgBox("Hubo un problema al actualizar el proveedor, consulte con su programdor", vbExclamation)
                closeandupdate(Me)
            End If
        Else
            addproveedor(p)
        End If

        If chk_secuencia.Checked = True Then
            txt_nombre.Text = ""
            txt_dni.Text = ""
            txt_tel.Text = ""
            txt_email.Text = ""
            txt_direccion.Text = ""
            txt_vendedor.Text = ""
            chk_activo.Checked = True
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    Private Sub txt_dni_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_dni.KeyPress
        If (Char.IsControl(e.KeyChar)) = False Then
            If Char.IsDigit(e.KeyChar) = False Then
                e.KeyChar = ""
            End If
        End If
    End Sub

    Private Sub Add_proveedor_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub Add_proveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chk_activo.Checked = True
        If edicion = True Or borrado = True Then
            chk_secuencia.Enabled = False
            txt_nombre.Text = edita_proveedor.nombre
            txt_direccion.Text = edita_proveedor.direccion
            txt_tel.Text = edita_proveedor.telefono
            txt_email.Text = edita_proveedor.email
            txt_dni.Text = edita_proveedor.dni
            txt_vendedor.Text = edita_proveedor.vendedor
            chk_activo.Checked = edita_proveedor.activo
        End If

        If borrado = True Then
            txt_nombre.Enabled = False
            txt_direccion.Enabled = False
            txt_tel.Enabled = False
            txt_email.Enabled = False
            txt_dni.Enabled = False
            chk_activo.Enabled = False
            txt_vendedor.Enabled = False
            cmd_ok.Visible = False
            cmd_exit.Visible = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar este proveedor?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If (borrarproveedor(edita_proveedor)) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado del proveedor, ¿desea intectar desactivarlo para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updateproveedor(edita_proveedor, True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero el proveedor no se borró definitivamente." + Chr(13) +
                                "Esto posiblemente se deba a que el proveedor, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar el proveedor, consulte con el programador")
                        End If
                    End If
                End If
            End If
            closeandupdate(Me)
        End If
    End Sub
End Class