Imports System
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient

Public Class frm_reportes
    Dim esPresupuesto As Boolean = False
    Dim imprimeRemito As Boolean = True
    Dim hojaDeTrabajo As Boolean = False
    Dim p As New pedido
    Dim pp As New presupuesto
    Dim f As New FE
    Dim c As New comprobante
    Dim comando As New SqlCommand
    'Dim hojasDefaultFC As Integer = 1
    'Dim hojasDefaultRM As Integer = 1
    'Dim hojasDefaultPresupuesto As Integer = 1

    Dim id_tipoComprobante As Integer
    Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Sub New(ByVal Presupuesto As Boolean, ByVal Remito As Boolean)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.esPresupuesto = Presupuesto
        Me.imprimeRemito = Remito
    End Sub

    Sub New(ByVal hojaTrabajo As Boolean)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.hojaDeTrabajo = hojaTrabajo
    End Sub

    Private Sub frm_reportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If hojaDeTrabajo Then
            imprime_hoja_trabajo()
            Exit Sub
        End If

        Dim ds_FC_Empresa As DataSet = New DataSet("DataSetFC_empresa")
        Dim ds_FC_Cabecera As DataSet = New DataSet("DataSetFC_cabecera")
        Dim ds_FC_Detalle As DataSet = New DataSet("DataSetFC_detalle")
        Dim ds_Presupuesto_Cabecera As DataSet = New DataSet("DataSetPresupuesto_cabecera")
        Dim ds_Presupuesto_detalle As DataSet = New DataSet("DataSetPresupesto_detalle")
        Dim ds_Presupuesto_empresa As DataSet = New DataSet("DataSetPresupesto_empresa")


        Dim dt_empresa As New DataTable
        Dim dt_FC_cabecera As New DataTable
        Dim dt_FC_detalle As New DataTable
        Dim dt_Presupuesto_cabecera As New DataTable
        Dim dt_Presupuesto_detalle As New DataTable
        Dim fileName As String = ""
        Dim drNewRow As DataRow

        Dim da As New SqlDataAdapter

        Dim sqlstr As String


        If Not esPresupuesto Then
            p = info_pedido(id)
            f = info_fe(p.id_pedido)
            c = info_comprobante(f.id_comprobante)

            id_tipoComprobante = c.id_tipoComprobante
        Else
            pp = info_presupuesto(id)
        End If


        Me.ReportViewer1.ProcessingMode = ProcessingMode.Local
        Me.ReportViewer1.LocalReport.DataSources.Clear()

        If esPresupuesto Then
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "DROil.rpt_presupuesto.rdlc"
            fileName = "PS "
        Else
            Select Case id_tipoComprobante
            'Case Is = 99 'PRESUPUESTO
            '   Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "DROil.rpt_presupuesto.rdlc"
            '   fileName = "PS "
                Case Is = 1 'FACTURA A
                    Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "DROil.rpt_facturaA.rdlc"
                    fileName = "FC A "
                Case Is = 6 'FACTURA B
                    Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "DROil.rpt_facturaB.rdlc"
                    fileName = "FC B "
                Case Is = 3 'NOTA DE CREDITO A
                    Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "DROil.rpt_notaDeCreditoA.rdlc"
                    fileName = "NC A "
                Case Is = 8 'NOTA DE CREDITO B
                    Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "DROil.rpt_notaDeCreditoB.rdlc"
                    fileName = "NC B "
                Case Is = 2 'NOTA DE DEBITO A
                    Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "DROil.rpt_notaDeDebitoA.rdlc"
                    fileName = "ND A "
                Case Is = 7 'NOTA DE DEBITO B
                    Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "DROil.rpt_notaDeDebitoB.rdlc"
                    fileName = "ND B "
                Case Is = 199 'REMITO
                    Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "DROil.rpt_saleOrderRM.rdlc"
                    fileName = "RM "
            End Select
        End If

        If id_tipoComprobante = 99 Or id_tipoComprobante = 0 Or esPresupuesto Then
            fileName += pp.id_presupuesto.ToString '22092020
        Else
            fileName += f.numeroComprobante.ToString '22092020
        End If

        Me.ReportViewer1.LocalReport.DisplayName = fileName

        Try
            abrirdb(serversql, basedb, usuariodb, passdb)

            comando.CommandType = CommandType.Text
            comando.Connection = CN

            If id_tipoComprobante = 199 Then 'REMITO
                cargar_ds_Remitos()
                'ReportViewer1.PrinterSettings.Copies = hojasDefaultRM
            ElseIf c.id_tipoComprobante = 99 Or esPresupuesto Then 'PRESUPUESTO
                sqlstr = "EXEC [dbo].[presupuesto_cabecera]	@idfc = " & id.ToString
                comando.CommandText = sqlstr
                da.SelectCommand = comando
                da.Fill(ds_Presupuesto_Cabecera, "Tabla")

                dt_Presupuesto_cabecera = ds_Presupuesto_Cabecera.Tables(0)

                Me.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetPresupuesto_cabecera", dt_Presupuesto_cabecera))
                'ReportViewer1.PrinterSettings.Copies = hojasDefaultPresupuesto
            End If

            If esPresupuesto Then
                sqlstr = "EXEC	[dbo].[datos_empresa]"
                comando.CommandText = sqlstr
                da.SelectCommand = comando
                da.Fill(ds_Presupuesto_empresa, "Tabla")


                sqlstr = "EXEC	[dbo].[presupuesto_cabecera]	@idfc = " & id.ToString
                comando.CommandText = sqlstr
                da.SelectCommand = comando
                da.Fill(ds_Presupuesto_Cabecera, "Tabla")


                sqlstr = "EXEC [dbo].[presupuesto_detalle]	@idfc = " & id.ToString
                comando.CommandText = sqlstr
                da.SelectCommand = comando
                da.Fill(ds_Presupuesto_detalle, "Tabla")

                dt_empresa = ds_Presupuesto_empresa.Tables(0)
                dt_Presupuesto_cabecera = ds_Presupuesto_Cabecera.Tables(0)
                dt_Presupuesto_detalle = ds_Presupuesto_detalle.Tables(0)

                drNewRow = dt_Presupuesto_detalle.NewRow
                drNewRow.Item("item_code") = DBNull.Value
                drNewRow.Item("item_desc") = DBNull.Value
                drNewRow.Item("item_qty") = DBNull.Value
                drNewRow.Item("item_price") = DBNull.Value
                drNewRow.Item("item_subtotal") = DBNull.Value

                Do While dt_Presupuesto_detalle.Rows.Count < 36
                    dt_Presupuesto_detalle.Rows.Add()
                    dt_Presupuesto_detalle.AcceptChanges()
                Loop

                Me.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetPresupuesto_empresa", dt_empresa))
                Me.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetPresupuesto_cabecera", dt_Presupuesto_cabecera))
                Me.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetPresupuesto_detalle", dt_Presupuesto_detalle))
            ElseIf id_tipoComprobante <> 199 Then 'TODO MENOS REMITOS
                sqlstr = "EXEC	[dbo].[datos_empresa]"
                comando.CommandText = sqlstr
                da.SelectCommand = comando
                da.Fill(ds_FC_Empresa, "Tabla")


                sqlstr = "EXEC	[dbo].[factura_cabecera]	@idfc = " & id.ToString
                comando.CommandText = sqlstr
                da.SelectCommand = comando
                da.Fill(ds_FC_Cabecera, "Tabla")


                sqlstr = "EXEC [dbo].[factura_detalle]	@idfc = " & id.ToString
                comando.CommandText = sqlstr
                da.SelectCommand = comando
                da.Fill(ds_FC_Detalle, "Tabla")

                dt_empresa = ds_FC_Empresa.Tables(0)
                dt_FC_cabecera = ds_FC_Cabecera.Tables(0)
                dt_FC_detalle = ds_FC_Detalle.Tables(0)

                drNewRow = dt_FC_detalle.NewRow
                drNewRow.Item("item_code") = DBNull.Value
                drNewRow.Item("item_desc") = DBNull.Value
                drNewRow.Item("item_qty") = DBNull.Value
                drNewRow.Item("item_price") = DBNull.Value
                drNewRow.Item("item_subtotal") = DBNull.Value

                Do While dt_FC_detalle.Rows.Count < 36
                    dt_FC_detalle.Rows.Add()
                    dt_FC_detalle.AcceptChanges()
                Loop

                Me.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetFC_empresa", dt_empresa))
                Me.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetFC_cabecera", dt_FC_cabecera))
                Me.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetFC_detalle", dt_FC_detalle))
                'If id_tipoComprobante = 99 Then ReportViewer1.PrinterSettings.Copies = 2 Else ReportViewer1.PrinterSettings.Copies = 3
                'ReportViewer1.PrinterSettings.Copies = hojasDefaultFC
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            cerrardb()
        End Try

        If Not esPresupuesto Then ReportViewer1.PrinterSettings.Copies = c.cantCopy Else ReportViewer1.PrinterSettings.Copies = 1
        ReportViewer1.PrinterSettings.PrintRange = PrintRange.SomePages
        ReportViewer1.PrinterSettings.FromPage = 1
        ReportViewer1.PrinterSettings.ToPage = 1

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub frm_reportes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'If id_tipoComprobante = 199 Or id_tipoComprobante = 99 Then Exit Sub 'Si es un remito no pregunta si se quieren emitir los remitos
        If id_tipoComprobante = 1 Or id_tipoComprobante = 6 Or id_tipoComprobante = 11 Or id_tipoComprobante = 51 Then 'Solo imprime remitos si es una factura
            If imprimeRemito Then
                e.Cancel = True
                imprimirRemitos()
            End If
        End If
    End Sub

    Private Sub imprimirRemitos()
        Dim p As New pedido
        Dim f As New FE
        Dim c As New comprobante
        'Dim idRM As Integer

        'idRM = idremitoAsociado(id)
        'p = info_pedido(id)
        f = info_fe(id)
        c = info_comprobante(f.id_comprobante)

        id_tipoComprobante = 199
        'Se usa esta función para llamar a un remito cuando hay diferencia entre la dirección fiscal y la dirección de entrega
        'cargar_ds_Remitos(id, idRM)
        cargar_ds_Remitos(id)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "DROil.rpt_saleOrderRM.rdlc"

        Me.ReportViewer1.LocalReport.DisplayName = "RM " + f.numeroComprobante.ToString '22092020
        ReportViewer1.PrinterSettings.Copies = c.cantCopy
        Me.ReportViewer1.RefreshReport()
    End Sub


    'Se usa esta función para llamar a un remito cuando hay diferencia entre la dirección fiscal y la dirección de entrega
    'Private Sub cargar_ds_Remitos(Optional ByVal id_pedido As Integer = -1, Optional ByVal id_remitoAsociado As Integer = -1)

    '    Dim ds_RM_Cabecera As DataSet = New DataSet("DataSetRM_cabecera")
    '    Dim ds_RM_Detalle As DataSet = New DataSet("DataSetRM_detalle")

    '    Dim dt_RM_cabecera As New DataTable
    '    Dim dt_RM_detalle As New DataTable

    '    Dim sqlstr As String

    '    Dim da As New SqlDataAdapter

    '    If id_pedido = -1 Then id_pedido = id
    '    If id_remitoAsociado = -1 Then id_remitoAsociado = id_pedido

    '    sqlstr = "EXEC	[dbo].[remito_cabecera]	@idfc = " & id_remitoAsociado.ToString
    '    comando.CommandText = sqlstr
    '    da.SelectCommand = comando
    '    da.Fill(ds_RM_Cabecera, "Tabla")

    '    sqlstr = "EXEC [dbo].[remito_detalle]	@idfc = " & id_pedido.ToString
    '    comando.CommandText = sqlstr
    '    da.SelectCommand = comando
    '    da.Fill(ds_RM_Detalle, "Tabla")

    '    dt_RM_cabecera = ds_RM_Cabecera.Tables(0)
    '    dt_RM_detalle = ds_RM_Detalle.Tables(0)

    '    Me.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetRM_cabecera", dt_RM_cabecera))
    '    Me.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetRM_detalle", dt_RM_detalle))
    'End Sub

    Private Sub cargar_ds_Remitos(Optional ByVal id_pedido As Integer = -1)
        Dim ds_RM_Cabecera As DataSet = New DataSet("DataSetRM_cabecera")
        Dim ds_RM_Detalle As DataSet = New DataSet("DataSetRM_detalle")

        Dim dt_RM_cabecera As New DataTable
        Dim dt_RM_detalle As New DataTable

        Dim sqlstr As String

        Dim da As New SqlDataAdapter

        If id_pedido = -1 Then id_pedido = id

        sqlstr = "EXEC	[dbo].[remito_cabecera]	@idfc = " & id_pedido.ToString
        comando.CommandText = sqlstr
        da.SelectCommand = comando
        da.Fill(ds_RM_Cabecera, "Tabla")

        sqlstr = "EXEC [dbo].[remito_detalle]	@idfc = " & id_pedido.ToString
        comando.CommandText = sqlstr
        da.SelectCommand = comando
        da.Fill(ds_RM_Detalle, "Tabla")

        dt_RM_cabecera = ds_RM_Cabecera.Tables(0)
        dt_RM_detalle = ds_RM_Detalle.Tables(0)

        Me.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetRM_cabecera", dt_RM_cabecera))
        Me.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetRM_detalle", dt_RM_detalle))
    End Sub

    Private Sub imprime_hoja_trabajo(Optional ByVal id_pedido As Integer = -1)
        Dim ds_hoja_Cabecera As DataSet = New DataSet("DataSetRM_cabecera")
        Dim ds_hoja_Detalle As DataSet = New DataSet("DataSetRM_detalle")

        Dim dt_hoja_cabecera As New DataTable
        Dim dt_hoja_detalle As New DataTable

        Dim sqlstr As String
        Dim fileName As String = ""

        Dim da As New SqlDataAdapter

        If id_pedido = -1 Then id_pedido = id


        Me.ReportViewer1.ProcessingMode = ProcessingMode.Local
        Me.ReportViewer1.LocalReport.DataSources.Clear()

        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "DROil.rpt_hojaDeTrabajo.rdlc"
        fileName = "ORDEN "
        Try
            abrirdb(serversql, basedb, usuariodb, passdb)

            comando.CommandType = CommandType.Text
            comando.Connection = CN

            sqlstr = "EXEC	[dbo].[hoja_de_trabajo_cebecera] @idpedido = " & id_pedido.ToString
            comando.CommandText = sqlstr
            da.SelectCommand = comando
            da.Fill(ds_hoja_Cabecera, "Tabla")

            sqlstr = "EXEC [dbo].[hoja_de_trabajo_detalle]	@idpedido = " & id_pedido.ToString
            comando.CommandText = sqlstr
            da.SelectCommand = comando
            da.Fill(ds_hoja_Detalle, "Tabla")

            dt_hoja_cabecera = ds_hoja_Cabecera.Tables(0)
            dt_hoja_detalle = ds_hoja_Detalle.Tables(0)

            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetOrder_cabecera", dt_hoja_cabecera))
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetOrder_detalle", dt_hoja_detalle))
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            cerrardb()
        End Try


        ReportViewer1.PrinterSettings.Copies = 1
        ReportViewer1.PrinterSettings.PrintRange = PrintRange.SomePages
        ReportViewer1.PrinterSettings.FromPage = 1
        ReportViewer1.PrinterSettings.ToPage = 1

        ReportViewer1.RefreshReport()
    End Sub

    Private Sub ReportViewer1_KeyDown(sender As Object, e As KeyEventArgs) Handles ReportViewer1.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub frm_reportes_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub
End Class