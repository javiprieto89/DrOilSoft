Public Class grilla_resultados

    Private Sub grilla_resultados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Cargo todas las consultas
        cargar_combo(cmb_consultas, "SELECT id_consulta, nombre FROM consultas_personalizadas ORDER BY nombre ASC", basedb, "nombre", "id_consulta")
        cmb_consultas.SelectedValue = 0
        cmb_consultas.Text = "Elija una consulta..."

        'Cargo todos los items
        cargar_combo(cmb_item, "SELECT i.id_item, i.descript FROM items AS i ORDER BY i.descript ASC", basedb, "descript", "id_item")
        cmb_item.SelectedValue = 0
        cmb_item.Text = "Elija un item..."

        'Cargo todos los clientes
        cargar_combo(cmb_cliente, "SELECT c.id_cliente AS 'id_cliente', c.nombre + ' ' + c.apellido AS 'Nombre' FROM clientes AS c ORDER BY c.nombre, c.apellido ASC", basedb, "nombre", "id_cliente")
        cmb_cliente.SelectedValue = 0
        cmb_cliente.Text = "Elija un cliente..."

        form = Me
    End Sub

    Private Sub cmd_ejecutar_Click(sender As Object, e As EventArgs) Handles cmd_ejecutar.Click
        Dim c As New consultaP
        Dim cabeceraStr As String

        If Not checkFilters() Then Exit Sub

        c = info_consulta(cmb_consultas.SelectedValue)

        cabeceraStr = cabecera(dtp_desde.Value.Date, dtp_hasta.Value.Date, , cmb_item.SelectedValue, cmb_cliente.SelectedValue)

        c.consulta = cabeceraStr + c.consulta

        cargar_datagrid(dg_view, c.consulta, basedb)
        TabControl1.SelectedIndex = 1
    End Sub


    Private Sub pic_search_item_Click(sender As Object, e As EventArgs) Handles pic_search_item.Click
        Dim tmp As String
        tmp = tabla
        tabla = "items2"
        form.Enabled = False
        search.ShowDialog()
        tabla = tmp

        cmb_item.SelectedValue = id
        id = 0
    End Sub

    Private Sub pic_search_cliente_Click(sender As Object, e As EventArgs) Handles pic_search_cliente.Click
        Dim tmp As String
        tmp = tabla
        tabla = "clientes"
        form.Enabled = False
        search.ShowDialog()
        tabla = tmp

        cmb_cliente.SelectedValue = id
        id = 0
    End Sub

    Private Sub pExport_MouseHover(sender As Object, e As EventArgs) Handles pExport.MouseHover
        lbl_exportar.Visible = True
    End Sub

    Private Sub pExport_MouseLeave(sender As Object, e As EventArgs) Handles pExport.MouseLeave
        lbl_exportar.Visible = False
    End Sub

    Private Sub pExport_Click(sender As Object, e As EventArgs) Handles pExport.Click
        Dim rutaArchivo As String

        With sfd
            .AddExtension = True
            .CheckFileExists = False
            .CheckPathExists = True
            .Filter = "Excel Worksheets 2007 (*.xlsx)|*.xlsx"
            .DefaultExt = "xls"
            .InitialDirectory = "C:\"
            .ShowDialog()
            rutaArchivo = .FileName
            If rutaArchivo = "" Then
                MsgBox("Exportación cancelada.", vbInformation + vbOKOnly, "DROil")
                Exit Sub
            End If
        End With

        exportarExcel(dg_view, rutaArchivo)
        MsgBox("Archivo exportado a: " + sfd.FileName, vbInformation + vbOKOnly, "DROil")
    End Sub

    Private Sub chk_desde_CheckedChanged(sender As Object, e As EventArgs) Handles chk_desde.CheckedChanged
        dtp_desde.Enabled = chk_desde.Checked
    End Sub

    Private Sub chk_hasta_CheckedChanged(sender As Object, e As EventArgs) Handles chk_hasta.CheckedChanged
        dtp_hasta.Enabled = chk_hasta.Checked
    End Sub

    Private Function checkFilters() As Boolean
        Dim ok As Boolean = True

        If cmb_consultas.SelectedValue = 0 Then
            MsgBox("Debe elegir una consulta para ejecutar", vbExclamation + vbOKOnly, "DROil")
            ok = False
        End If

        If dtp_desde.Value.Date > dtp_hasta.Value.Date Then
            MsgBox("La fecha 'Desde' no puede ser superior a 'Hasta'", vbExclamation, "DROil")
            ok = False
        End If

        Return ok
    End Function

    Private Function cabecera(ByVal fecha_desde As Date, ByVal fecha_hasta As Date, Optional ByVal id_comprobante As Integer = -1,
                              Optional ByVal id_item As Integer = -1, Optional ByVal id_cliente As Integer = -1) As String
        Dim cabeceraStr As String

        cabeceraStr = "DECLARE @desde AS DATE " &
                        "DECLARE @hasta AS DATE " &
                        "DECLARE @id_comprobante AS INTEGER " &
                        "DECLARE @id_item AS INTEGER " &
                        "DECLARE @id_cliente AS INTEGER "

        If chk_desde.Checked Then
            cabeceraStr += " SET @desde = '" + fecha_desde.ToString("yyyy/MM/dd") + "' "
        Else
            cabeceraStr += " SET @desde = NULL "
        End If

        If chk_hasta.Checked Then
            cabeceraStr += " SET @hasta = '" + fecha_hasta.ToString("yyyy/MM/dd") + "' "
        Else
            cabeceraStr += " SET @hasta = NULL "
        End If

        If Not chk_desde.Checked And Not chk_hasta.Checked Then
            cabeceraStr += " SET @desde = NULL SET @hasta = NULL "
        End If

        If id_comprobante <> -1 And id_comprobante <> 0 Then
            cabeceraStr += "SET @id_comprobante = '" + id_comprobante.ToString + "' "
        Else
            cabeceraStr += "SET @id_comprobante = NULL "
        End If

        If id_item <> -1 And id_item <> 0 Then
            cabeceraStr += "SET @id_item = '" + id_item.ToString + "' "
        Else
            cabeceraStr += "SET @id_item = NULL "
        End If

        If id_cliente <> -1 And id_cliente <> 0 Then
            cabeceraStr += "SET @id_cliente = '" + id_cliente.ToString + "' "
        Else
            cabeceraStr += "SET @id_cliente = NULL "
        End If


        Return cabeceraStr
    End Function
End Class