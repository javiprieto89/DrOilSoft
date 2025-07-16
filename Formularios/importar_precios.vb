Public Class importar_precios
    Private Sub cmd_examinar_Click(sender As Object, e As EventArgs) Handles cmd_cargar.Click
        If OpenFileDialog.FileName = Nothing Then
            MsgBox("Debe elegir un archivo para poder continuar", vbOKOnly + vbExclamation, "Dr. Oil")
            Exit Sub
        End If

        Try
            Dim dt As DataTable
            dt = ImportarDatosExcel(txt_archivoSeleccionado.Text)

            If dt.Rows.Count = 0 Then
                MsgBox("Ocurrió un error al cargar el archivo de Excel, por favor consulte con el programador", vbOKOnly + vbExclamation, "Dr. Oil")
                Exit Sub
            End If

            dgv_items.Columns.Clear()

            normalizarPrecios(dt)
            dgv_items.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub OpenFileDialog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog.FileOk
        txt_archivoSeleccionado.Text = OpenFileDialog.FileName.ToString
    End Sub

    Private Sub txt_archivoSeleccionado_MouseClick(sender As Object, e As MouseEventArgs) Handles txt_archivoSeleccionado.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            OpenFileDialog.ShowDialog()
        End If
    End Sub

    Private Sub importar_precios_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub
    Private Sub cmd_importar_Click(sender As Object, e As EventArgs) Handles cmd_importar.Click

        If chk_costo.Checked = False And chk_markup.Checked = False And chk_descuento.Checked = False And chk_precioLista.Checked = False Then
            MsgBox("Debe seleccionar algo para importar/actualizar antes de poder continuar", vbOKOnly + vbExclamation, "Dr. Oil")
            Exit Sub
        End If

        If MsgBox("¿Confirma la importación/actualización de los items con los datos de la grilla?", vbYesNo + vbQuestion, "Dr. Oil") = MsgBoxResult.Yes Then
            If actualizarPrecios(Me.dgv_items, chk_costo.Checked, chk_markup.Checked, chk_descuento.Checked, chk_precioLista.Checked) Then
                MsgBox("La importación/actualización se ha completado correctamente", vbOKOnly + vbInformation, "Dr. Oil")
                closeandupdate(Me)
            Else
                MsgBox("Ha ocurrido un error al realizar la importación/actualización." & Chr(13) & "Consulte con el programador", vbOKOnly + vbCritical, "Dr. Oil")
            End If
        Else
            MsgBox("Importación/actualización cancelada", vbOKOnly + vbInformation, "Dr. Oil")
        End If
    End Sub

    Private Sub importar_precios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OpenFileDialog.FileName = Nothing
    End Sub

    Private Sub normalizarPrecios(ByRef dt As DataTable)
        For Each row As DataRow In dt.Rows
            row("precio_lista") = MyRound(row("precio_lista"), 50)
        Next
    End Sub

    Private Sub cmd_planillaEjemplo_Click(sender As Object, e As EventArgs) Handles cmd_planillaEjemplo.Click
        Dim origen As String
        Dim destino As String

        origen = Application.StartupPath + "\Planilla_Base_Importar_Precios.xls"
        destino = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\Planilla_Base_Importar_Precios.xls"
        If Not System.IO.File.Exists(origen) Then
            MsgBox("Falta la planilla base, por lo cuál no podrá ser copiada", vbCritical + vbOKOnly, "Dr. Oil")
        Else
            My.Computer.FileSystem.CopyFile(origen, destino, FileIO.UIOption.OnlyErrorDialogs, FileIO.UICancelOption.DoNothing)
            MsgBox("Se ha copiado una copia de la planilla de ejemplo en el escritorio con el nombre: Planilla_Base_Importar_Precios.xls")
        End If

    End Sub
End Class