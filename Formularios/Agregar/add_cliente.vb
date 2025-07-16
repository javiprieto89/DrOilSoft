Public Class add_cliente
    Private nCliente As Integer
    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If busquedaAvanzada Then
            With edita_cliente
                .nombre = Trim(txt_nombre.Text)
                .apellido = Trim(txt_apellido.Text)
                .dni = txt_dni.Text
                .telefono = txt_tel.Text
                .email = txt_email.Text
                .direccion = txt_direccion.Text
                .activo = chk_activo.Checked
                .id_descuento = cmb_descuento.SelectedValue
            End With
            closeandupdate(Me)
            Exit Sub
        End If

        If txt_nombre.Text = "" Then
            MsgBox("El campo 'Nombre' es obligatorio y está vacio")
            Exit Sub
        End If

        Dim cl As New cliente

        With cl
            .nombre = Trim(txt_nombre.Text)
            .apellido = Trim(txt_apellido.Text)
            .dni = txt_dni.Text
            .telefono = txt_tel.Text
            .email = txt_email.Text
            .direccion = txt_direccion.Text
            .activo = chk_activo.Checked
            .id_pais = cmb_paisFiscal.SelectedValue
            .id_provincia = cmb_provinciaFiscal.SelectedValue
            .id_descuento = cmb_descuento.SelectedValue
            .esInscripto = chk_esInscripto.Checked
            .id_tipoDocumento = cmb_tipoDocumento.SelectedValue
            .localidad = txt_localidadFiscal.Text
            .cp = txt_cpFiscal.Text
        End With

        If edicion = True Then
            cl.id_cliente = edita_cliente.id_cliente
            If updatecliente(cl) = False Then
                MsgBox("Hubo un problema al actualizar el cliente, consulte con su programdor", vbExclamation)
                closeandupdate(Me)
            End If
        Else
            If nCliente = -1 Or cl.dni = "" Then
                If addcliente(cl) = False Then
                    MsgBox("Hubo un problema al dar de alta el cliente, consulte con su programdor", vbExclamation)
                    closeandupdate(Me)
                End If
            Else
                cl.id_cliente = nCliente
                If updatecliente(cl) = False Then
                    MsgBox("Hubo un problema al actualizar el cliente, consulte con su programdor", vbExclamation)
                    closeandupdate(Me)
                End If
            End If
        End If

        If chk_secuencia.Checked = True Then
            txt_nombre.Text = ""
            txt_apellido.Text = ""
            txt_dni.Text = ""
            txt_tel.Text = ""
            txt_email.Text = ""
            txt_direccion.Text = ""
            chk_activo.Checked = True
            cmb_paisFiscal.SelectedValue = id_pais_default
            cmb_provinciaFiscal.SelectedValue = id_provincia_default
            cmb_descuento.SelectedValue = id_sinDescuento
            chk_esInscripto.Checked = False
            cmb_tipoDocumento.SelectedValue = id_tipoDocumento_default
            txt_localidadFiscal.Text = ""
            txt_cpFiscal.Text = ""
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    Private Sub txt_dni_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_dni.KeyPress
        'e.Handled = valida(e.KeyChar, 2)
    End Sub

    Private Sub Add_cliente_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub Add_cliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Cargo todos los paises de dirección fiscal
        cargar_combo(cmb_paisFiscal, "SELECT id_pais, pais FROM paises ORDER BY pais ASC", basedb, "pais", "id_pais")

        'Cargo todas las provincias de direccion fiscal
        cargar_combo(cmb_provinciaFiscal, "SELECT id_provincia, provincia FROM provincias WHERE id_pais = '" + cmb_paisFiscal.SelectedValue.ToString + "' ORDER BY provincia ASC", basedb, "provincia", "id_provincia")
        cmb_provinciaFiscal.SelectedValue = id_provincia_default

        'Cargo todos los descuentos
        cargar_combo(cmb_descuento, "SELECT d.id_descuento AS 'id_descuento', d.descripcion AS 'descripcion' FROM descuentos AS d WHERE d.activo = '1' ORDER BY d.descripcion ASC", basedb, "descripcion", "id_descuento")
        cmb_descuento.SelectedValue = id_sinDescuento

        'Cargo todos los tipos de documentos
        cargar_combo(cmb_tipoDocumento, "SELECT id_tipoDocumento, documento FROM tipos_documentos ORDER BY documento ASC", basedb, "documento", "id_tipoDocumento")
        cmb_tipoDocumento.SelectedValue = id_tipoDocumento_default
        cmb_tipoDocumento_SelectionChangeCommitted(Nothing, Nothing)

        If busquedaAvanzada Then
            Me.Text = "Buscar clientes"
            cmd_ok.Text = "Buscar"
            chk_secuencia.Visible = False
            chk_activo.Checked = True
            Exit Sub
        End If

        chk_activo.Checked = True
        If edicion = True Or borrado = True Then
            chk_secuencia.Enabled = False
            txt_nombre.Text = edita_cliente.nombre
            txt_apellido.Text = edita_cliente.apellido
            txt_direccion.Text = edita_cliente.direccion
            txt_tel.Text = edita_cliente.telefono
            txt_email.Text = edita_cliente.email
            txt_dni.Text = edita_cliente.dni
            chk_activo.Checked = edita_cliente.activo
            cmb_tipoDocumento.SelectedValue = edita_cliente.id_tipoDocumento
            cmb_descuento.SelectedValue = edita_cliente.id_descuento
            cmb_paisFiscal.SelectedValue = edita_cliente.id_pais
            cmb_provinciaFiscal.SelectedValue = edita_cliente.id_provincia
            chk_esInscripto.Checked = edita_cliente.esInscripto
            txt_localidadFiscal.Text = edita_cliente.localidad
            txt_cpFiscal.Text = edita_cliente.cp
        End If

        If borrado = True Then
            txt_nombre.Enabled = False
            txt_apellido.Enabled = False
            txt_direccion.Enabled = False
            txt_tel.Enabled = False
            txt_email.Enabled = False
            txt_dni.Enabled = False
            chk_activo.Enabled = False
            cmd_ok.Visible = False
            cmd_exit.Visible = False
            cmb_descuento.Enabled = False
            cmb_paisFiscal.Enabled = False
            cmb_provinciaFiscal.Enabled = False
            chk_esInscripto.Enabled = False
            txt_localidadFiscal.Enabled = False
            txt_cpFiscal.Enabled = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar este cliente?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If (borrarcliente(edita_cliente)) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado del cliente, ¿desea intectar desactivarlo para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updatecliente(edita_cliente, True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero el cliente no se borró definitivamente." + Chr(13) +
                                "Esto posiblemente se deba a que el cliente, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar el cliente, consulte con el programador")
                        End If
                    End If
                End If
            End If
            closeandupdate(Me)
        End If
    End Sub

    Private Sub txt_dni_LostFocus(sender As Object, e As EventArgs) Handles txt_dni.LostFocus
        Dim cl As cliente
        If txt_dni.Text <> "" Then
            nCliente = existecliente(txt_dni.Text)
        Else
            Exit Sub
        End If

        If nCliente <> -1 Then
            cl = info_cliente(nCliente)
            With cl
                txt_nombre.Text = .nombre
                txt_apellido.Text = .apellido
                txt_tel.Text = .telefono
                txt_email.Text = .email
                txt_direccion.Text = .direccion
                chk_activo.Checked = .activo
                cmb_descuento.SelectedValue = .id_descuento
                cmb_tipoDocumento.SelectedValue = .id_tipoDocumento
                cmb_tipoDocumento_SelectionChangeCommitted(Nothing, Nothing)
            End With
        End If
    End Sub
    Private Sub cmb_tipoDocumento_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_tipoDocumento.SelectionChangeCommitted
        If cmb_tipoDocumento.SelectedValue = 80 Then
            chk_esInscripto.Checked = True
        Else
            chk_esInscripto.Checked = False
        End If
    End Sub
End Class