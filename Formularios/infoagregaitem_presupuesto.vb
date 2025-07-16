Public Class infoagregaitem_presupuesto
    Dim seleccionado As String
    Dim idUsuario As Integer
    Dim idUnico As String

    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Sub New(_idUsuario As Integer, _idUnico As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        idUsuario = _idUsuario
        idUnico = _idUnico
    End Sub

    Private Sub infoagregaitem_presupuesto_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        'closeandupdate(Me)
    End Sub

    Private Sub infoagregaitem_presupuesto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_item.Text = edita_item.item
        lbl_desc.Text = edita_item.descript
        lbl_stock.Text = edita_item.cantidad
        If agregaItem = True Then
            txt_cantidad.Text = 1
            txt_precio.Text = edita_item.precio_lista
        Else
            Dim cantidad As Double = -1
            Dim cantidadb As Double = -1
            Dim precio As Double = -1
            Dim preciob As Double = -1

            cantidadb = askitemcargado_presupuesto(edita_item.id_item, 1, "tmppresupuestos_items", idUsuario, idUnico)
            preciob = askpreciocargado_presupuesto(edita_item.id_item, 1, "tmppresupuestos_items", idUsuario, idUnico)

            cantidad = askitemcargado_presupuesto(edita_item.id_item, edita_presupuesto.id_presupuesto, "presupuestos_detalle", idUsuario, idUnico)
            precio = askpreciocargado_presupuesto(edita_item.id_item, edita_presupuesto.id_presupuesto, "presupuestos_detalle", idUsuario, idUnico)
            If precio = -1 Then precio = askpreciocargado_presupuesto(edita_item.id_item, edita_presupuesto.id_presupuesto, "tmppresupuestos_items", idUsuario, idUnico)


            If cantidadb <> -1 And cantidad <> cantidadb Or cantidad = -1 Then cantidad = cantidadb
            If preciob <> -1 And precio <> preciob Or precio = -1 Then precio = preciob

            'If cantidad = -1 Then cantidad = cantidadb
            'If precio = -1 Then precio = preciob
            txt_cantidad.Text = cantidad
            txt_precio.Text = precio
        End If
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        Dim cantidad As Double = -1
        Dim cantidadb As Double = -1
        Dim precio As Double

        If CInt(txt_cantidad.Text) = -1 Then
            closeandupdate(Me)
            Exit Sub
        End If

        If txt_cantidad.Text = 0 Then
            MsgBox("La cantidad ingresada no puede ser 0, ingrese nuevamente", vbExclamation, "Dr. Oil")
            Exit Sub
        End If

        'Si estoy agregando un item, puede ser que el item ya exista, por lo que lo verifio para sumarlo a la cantidad que yo ingresé
        If agregaItem = True Then
            cantidad = askitemcargado_presupuesto(edita_item.id_item, edita_presupuesto.id_presupuesto, "presupuestos_detalle", idUsuario, idUnico)
            If cantidad = -1 Then cantidad = askitemcargado_presupuesto(edita_item.id_item, 1, "tmppresupuestos_items", idUsuario, idUnico)
        End If

        If cantidad = -1 Then cantidad = txt_cantidad.Text Else cantidad = cantidad + txt_cantidad.Text

        'Si por ejemplo tengo 3 unidades de un item, y actualizo y pongo 2 unidades, el chequeo de stock no debería hacerse porque puede ser que el stock de ese item actualmente sea 0, y yo
        'estaría devolviendo uno. Por eso pregunto por la cantidad del item.        
        cantidadb = askitemcargado_presupuesto(edita_item.id_item, edita_presupuesto.id_presupuesto, "presupuestos_detalle", idUsuario, idUnico)
        If cantidadb = -1 Then cantidadb = askitemcargado_presupuesto(edita_item.id_item, 1, "tmppresupuestos_items", idUsuario, idUnico)

        'If edita_item.cantidad < cantidad And cantidad > cantidadb Then
        '    MsgBox("No hay " + cantidad.ToString + " " + edita_item.item.ToString + " hay solo " + edita_item.cantidad.ToString + ", ingrese una nueva cantidad o cancele", vbExclamation)
        '    Exit Sub
        'End If

        precio = txt_precio.Text


        'additempresupuestotmp(seleccionado, cantidad, precio)
        additempresupuestotmp(edita_item.id_item, cantidad, precio, idUsuario, idUnico)
        'closeandupdate(Me)
        Me.Dispose()
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        Me.Dispose()
    End Sub
End Class