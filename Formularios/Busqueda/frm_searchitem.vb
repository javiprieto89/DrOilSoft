Public Class frm_searchitem

    Private Sub frm_searchitem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ctrl As Control
        Dim combo As ComboBox

        Dim x As Integer
        For x = Me.Controls.Count - 1 To 0 Step -1
            ctrl = Me.Controls.Item(x)
            If TypeOf (ctrl) Is ComboBox Then
                combo = ctrl
                With combo
                    .Items.Add("Todos")
                    If .Name = "cmb_activo" Then
                        .Items.Add("Si")
                        .Items.Add("No")
                    Else
                        .Items.Add("Es igual a...")
                        If .Name = "cmb_costo" Or .Name = "cmb_factor" Or .Name = "cmb_preciolista" Or .Name = "cmb_cantidad" Then
                            .Items.Add("Es mayor que...")
                            .Items.Add("Es menor que...")
                            .Items.Add("Entre los valores...")

                        Else
                            .Items.Add("Comienza con...")
                            .Items.Add("Contiene...")
                            .Items.Add("Es distinto a...")
                            .Items.Add("No contiene...")
                        End If
                    End If
                    .SelectedIndex = 0
                End With
            End If
        Next
    End Sub
End Class