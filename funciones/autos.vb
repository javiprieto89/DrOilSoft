'funciones/autos.vb
Imports System.Data.SqlClient

Module autos
    ' ************************************ FUNCIONES DE AUTOS ***************************
    Public Function info_auto(Optional ByVal id_auto As String = "0", Optional ByVal patente As String = "") As auto
        Dim tmp As New auto
        Dim sqlstr As String = "SELECT * FROM autos WHERE id_auto = '" & id_auto & "' OR patente = '" & patente & "'"
        Dim dt As DataTable = GetDataTable(sqlstr)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_auto = .Item(0).ToString
                tmp.patente = .Item(1).ToString
                tmp.anio = .Item(2).ToString
                tmp.id_modelo = .Item(3).ToString
                tmp.id_cliente = .Item(4).ToString
                tmp.activo = .Item(5).ToString
                tmp.deudor = .Item(6).ToString
                tmp.id_descuento = .Item(7).ToString
            End With
        End If
        Return tmp
    End Function

    Public Function addauto(a As auto) As Boolean
        Dim sqlstr As String = "INSERT INTO autos (patente, anio, id_modelo, id_cliente, activo, deudor, id_descuento) VALUES ('" & a.patente & "', '" & a.anio.ToString & "', '" & a.id_modelo.ToString & "', '" & a.id_cliente.ToString & "', '" & a.activo.ToString & "', '" & a.deudor.ToString & "', '" & a.id_descuento.ToString & "')"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function updateauto(a As auto, Optional borra As Boolean = False) As Boolean
        Dim sqlstr As String
        If borra = True Then
            sqlstr = "UPDATE autos SET activo = '0' WHERE id_auto = '" & a.id_auto.ToString & "'"
        Else
            sqlstr = "UPDATE autos SET patente = '" & a.patente & "', anio = '" & a.anio.ToString & "', id_modelo = '" & a.id_modelo.ToString & "', id_cliente = '" & a.id_cliente.ToString & "', activo = '" & a.activo.ToString & "', deudor = '" & a.deudor.ToString & "', id_descuento = '" & a.id_descuento.ToString & "' WHERE id_auto = '" & a.id_auto.ToString & "'"
        End If
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function borrarauto(a As auto) As Boolean
        Dim sqlstr As String = "DELETE FROM autos WHERE id_auto = '" & a.id_auto.ToString & "'"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Sub autosConDeuda(ByVal lsview As ListView, ByVal clr As Color)
        Dim i As Integer
        Dim x As Integer = 0
        'Dim deudores(lsview.Items.Count) As Integer
        For i = 0 To lsview.Items.Count - 1
            If lsview.Items(i).SubItems(8).Text.ToString = "Si" Then
                'If info_auto(lsview.Items(i).SubItems(0).Text.ToString).deudor Then
                lsview.Items(i).SubItems(0).BackColor = clr
                lsview.Items(i).SubItems(0).Font = New Font(lsview.Items(i).SubItems(4).Font, FontStyle.Bold)
            End If
        Next
        lsview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        lsview.Refresh()
    End Sub

    Public Sub autosConDeudaDG(ByVal dg As DataGridView, ByVal clr As Color)
        For Each row As DataGridViewRow In dg.Rows
            If row.Cells.Count > 8 Then
                Dim val As Object = row.Cells(8).Value
                If val IsNot Nothing AndAlso val.ToString() = "Si" Then
                    row.Cells(0).Style.BackColor = clr
                    row.Cells(0).Style.Font = New Font(dg.Font, FontStyle.Bold)
                End If
            End If
        Next
    End Sub

    Public Function existeAuto(ByVal p As String) As Integer
        Dim sqlstr As String = "SELECT id_auto FROM autos WHERE patente = '" & Trim(p.ToString) & "'"
        Dim dt As DataTable = GetDataTable(sqlstr)
        If dt.Rows.Count = 0 Then Return -1
        Return CInt(dt.Rows(0).Item(0))
    End Function

    Public Function existeAuto(ByVal id_auto As Integer) As Boolean
        Dim sqlstr As String = "SELECT id_auto FROM autos WHERE id_auto = '" & id_auto.ToString & "'"
        Dim dt As DataTable = GetDataTable(sqlstr)
        If dt.Rows.Count = 0 Then Return False
        Return True
    End Function
    ' ************************************ FUNCIONES DE AUTOS ***************************
End Module
