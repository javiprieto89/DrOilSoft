Public Class ccClientes
    Private Sub ccClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Cargo el combo con todos los clientes
        cargar_combo(cmb_cliente, "SELECT c.id_cliente AS 'id_cliente', c.nombre + ' ' + c.apellido AS 'Nombre' FROM clientes AS c ORDER BY c.nombre, c.apellido ASC", basedb, "nombre", "id_cliente")
    End Sub

    Private Sub psearch_cliente_Click(sender As Object, e As EventArgs) Handles psearch_cliente.Click
        Dim tmp As String
        tmp = tabla
        tabla = "clientes"
        Me.Enabled = False
        form = Me
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        cmb_cliente.SelectedValue = id 'cmb_clientes.FindString(info_cliente(id).nombre)
        id = 0
    End Sub

    Private Sub ccClientes_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub cmd_consultar_Click(sender As Object, e As EventArgs) Handles cmd_consultar.Click
        'Dim saldo As saldoCaja

        If Not chk_pedidos.Checked And Not chk_casos.Checked Then
            MsgBox("Debe elegir o pedidos o casos para sumar y poder hacer la consulta." & Chr(13) & "Por favor seleccione 'Consultar pedidos', 'Consultar casos' o ambos si quiere.", MsgBoxStyle.Exclamation + vbOKOnly, "Dr. Oil")
            Exit Sub
        End If

        If Not chk_abiertos.Checked And Not chk_cerrados.Checked Then
            MsgBox("Debe elegir o pedidos/casos abiertos o cerrados para sumar y poder hacer la consulta." & Chr(13) & "Por favor seleccione 'Consultar pedidos/casos abiertos', 'Consultar pedidos/casos cerrados' o ambos si quiere.", MsgBoxStyle.Exclamation + vbOKOnly, "Dr. Oil")
            Exit Sub
        End If

        Dim fechaDesde As Date
        Dim fechaHasta As Date

        If chk_desdeSiempre.Checked Then
            fechaDesde = dtp_desde.MinDate
        Else
            fechaDesde = dtp_desde.Value.Date
        End If

        If chk_hastaSiempre.Checked Then
            fechaHasta = dtp_hasta.MaxDate
        Else
            fechaHasta = dtp_hasta.Value.Date
        End If


        dg_view.DataSource = consultaCcCliente(cmb_cliente.SelectedValue, fechaDesde, fechaHasta, chk_pedidos.Checked,
                                    chk_casos.Checked, chk_abiertos.Checked, chk_cerrados.Checked)

        txt_total.Text = consultaTotalCcCliente(cmb_cliente.SelectedValue, fechaDesde, fechaHasta, chk_pedidos.Checked,
                                    chk_casos.Checked, chk_abiertos.Checked, chk_cerrados.Checked)
    End Sub

    Private Sub dg_view_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dg_view.CellMouseDoubleClick
        If borrado = False Then edicion = True

        If dg_view.Rows.Count = 0 Then Exit Sub

        Dim seleccionado As String = dg_view.CurrentRow.Cells(0).Value.ToString
        Dim esCaso As Boolean = False
        If Trim(UCase(dg_view.CurrentRow.Cells(2).Value.ToString)) = "SI" Then esCaso = True


        edita_pedido = info_pedido(seleccionado, esCaso)

        If esCaso Then
            add_caso.ShowDialog()
        Else
            add_pedido.ShowDialog()
        End If


        If borrado = False Then edicion = False
    End Sub

    Private Sub chk_desdeSiempre_CheckedChanged(sender As Object, e As EventArgs) Handles chk_desdeSiempre.CheckedChanged
        If chk_desdeSiempre.Checked Then
            dtp_desde.Enabled = False
        Else
            dtp_desde.Enabled = True
        End If
    End Sub

    Private Sub chk_hastaSiempre_CheckedChanged(sender As Object, e As EventArgs) Handles chk_hastaSiempre.CheckedChanged
        If chk_hastaSiempre.Checked Then
            dtp_hasta.Enabled = False
        Else
            dtp_hasta.Enabled = True
        End If
    End Sub

    Private Sub prnDoc_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles prnDoc.PrintPage
        Dim bm As New Bitmap(dg_view.Width, dg_view.Height)
        dg_view.DrawToBitmap(bm, New Rectangle(0, 0, dg_view.Width, dg_view.Height * dg_view.RowCount))
        e.Graphics.DrawImage(bm, 0, 0)

        Dim textArea As New Rectangle(e.MarginBounds.Left, e.MarginBounds.Top, e.MarginBounds.Width, e.MarginBounds.Height)
        e.Graphics.DrawString(txt_total.Text, New Font("Consolas", 10), Brushes.Navy, textArea)

    End Sub

    Private Sub picPrn_Click(sender As Object, e As EventArgs) Handles picPrn.Click
        prnDlg.Document = prnDoc

        If prnDlg.ShowDialog = DialogResult.OK Then
            prnDoc.PrinterSettings = prnDlg.PrinterSettings
            prnDoc.Print()
        End If
    End Sub
End Class