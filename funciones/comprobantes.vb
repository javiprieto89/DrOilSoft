'funciones/comprobantes.vb
Imports System.Data
Imports System.Data.SqlClient

Module comprobantes
    ' ************************************ FUNCIONES DE COMPROBANTES ************

    Public Function info_comprobante(ByVal id_comprobante As String) As comprobante
        Dim tmp As New comprobante
        Dim sqlstr As String = "SELECT id_comprobante, comprobante, id_tipoComprobante, numeroComprobante, puntoVenta, ISNULL(esFiscal, 0), ISNULL(esElectronica, 0), ISNULL(esManual, 0), ISNULL(esPresupuesto, 0), activo, testing, maxItems, emiteRemito, cantCopy FROM comprobantes WHERE id_comprobante = '" & id_comprobante & "'"
        Dim dt As DataTable = GetDataTable(sqlstr)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_comprobante = .Item(0).ToString
                tmp.comprobante = .Item(1).ToString
                tmp.id_tipoComprobante = .Item(2).ToString
                tmp.numeroComprobante = .Item(3).ToString
                tmp.puntoVenta = .Item(4).ToString
                tmp.esFiscal = .Item(5).ToString
                tmp.esElectronica = .Item(6).ToString
                tmp.esManual = .Item(7).ToString
                tmp.esPresupuesto = .Item(8).ToString
                tmp.activo = .Item(9).ToString
                tmp.testing = .Item(10).ToString
                tmp.maxItems = .Item(11).ToString
                tmp.emiteRemito = .Item(12).ToString
                tmp.cantCopy = .Item(13).ToString
            End With
        End If
        Return tmp
    End Function

    Public Function addcomprobante(ByVal c As comprobante) As Boolean
        Dim sqlstr As String = "INSERT INTO comprobantes (comprobante, id_tipoComprobante, numeroComprobante, puntoVenta, esFiscal, esElectronica, esManual, esPresupuesto, activo, testing, maxItems, emiteRemito, cantCopy) VALUES ('" & c.comprobante & "', '" & c.id_tipoComprobante.ToString & "', '" & c.numeroComprobante.ToString & "', '" & c.puntoVenta.ToString & "', '" & c.esFiscal.ToString & "', '" & c.esElectronica.ToString & "', '" & c.esManual.ToString & "', '" & c.esPresupuesto.ToString & "', '" & c.activo.ToString & "', '" & c.testing.ToString & "', '" & c.maxItems.ToString & "', '" & c.emiteRemito.ToString & "', '" & c.cantCopy.ToString & "')"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function updatecomprobante(ByVal c As comprobante, Optional ByVal borra As Boolean = False) As Boolean
        Dim sqlstr As String
        If borra = True Then
            sqlstr = "UPDATE comprobantes SET activo = '0' WHERE id_id_comprobante = '" & c.id_comprobante.ToString & "'"
        Else
            sqlstr = "UPDATE comprobantes SET comprobante = '" & c.comprobante & "', id_tipoComprobante = '" & c.id_tipoComprobante.ToString & "', numeroComprobante = '" & c.numeroComprobante.ToString & "', puntoVenta = '" & c.puntoVenta.ToString & "', esFiscal = '" & c.esFiscal.ToString & "', esElectronica = '" & c.esElectronica.ToString & "', esManual = '" & c.esManual.ToString & "', esPresupuesto = '" & c.esPresupuesto.ToString & "', activo = '" & c.activo.ToString & "', testing = '" & c.testing.ToString & "', maxItems = '" & c.maxItems.ToString & "', emiteRemito = '" & c.emiteRemito.ToString & "', cantCopy = '" & c.cantCopy.ToString & "' WHERE id_comprobante = '" & c.id_comprobante.ToString & "'"
        End If
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function borrarcomprobante(ByVal c As comprobante) As Boolean
        Dim sqlstr As String = "DELETE FROM comprobantes WHERE id_comprobante = '" & c.id_comprobante.ToString & "'"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function estaComprobanteDefault(ByVal condicion As String, ByVal id_comprobanteDefault As Integer) As Boolean
        Dim sqlstr As String = "SELECT id_comprobante FROM comprobantes WHERE activo = '1' AND (id_tipoComprobante " & condicion & " (1, 2, 3, 4, 5, 63, 34, 39, 60) OR id_tipoComprobante IN (0, 99, 199)) AND id_comprobante = " & id_comprobanteDefault.ToString
        Dim dt As DataTable = GetDataTable(sqlstr)
        Return dt.Rows.Count > 0
    End Function
    ' ************************************ FUNCIONES DE COMPROBANTES ************
End Module
