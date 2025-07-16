Imports System.IO

Module factura
    Private pc As String
    Private modo As String
    Private archivo_certificado As String
    Private archivo_licencia As String
    Private password_certificado As String
    Private cuit_emisor As String

    Public Function facturar(ByVal p As pedido, ByVal ff As FE, ByVal c As comprobante) As Integer
        'SI DEVUELVE 1 ESTÁ TODO OK
        'SI DEVUELVE 0 HUBO UN ERROR

        '************** FACTURA ELECTRONICA ************** 

        'Obtengo los datos del comprobante
        Dim lResultado As Boolean = False
        Dim f As New FE
        Dim cl As New cliente
        Dim fe As New WSAFIPFE.Factura

        f.subtotal = ff.subtotal
        f.impuestos = ff.impuestos
        f.total = ff.total

        If c.esPresupuesto Or c.esManual Then
            c.numeroComprobante = c.numeroComprobante + 1
            updatecomprobante(c)
            p.cerrado = True
            p.activo = False
            'p.puntoVenta = c.puntoVenta  '22092020
            'p.numeroComprobante = c.numeroComprobante

            With f
                .id_pedido = p.id_pedido
                .id_comprobante = c.id_comprobante
                .puntoVenta = c.puntoVenta
                .numeroComprobante = c.numeroComprobante
                .fecha_emision = Format(DateTime.Now, "dd/MM/yyyy")
                '.fecha_emision = Format(DateTime.Now, "MM/dd/yyyy")
            End With

            emiteFE(f)
            'updatepedido(p)
            Return 1
        End If

        'Obtengo los datos del cliente
        cl = info_cliente(p.id_cliente)

        If Not inicialesFE(c.testing) Then
            MsgBox("Hubo un problema al inicializar el webservice, puede ser un problema de certificados", vbCritical + vbOKOnly, "Centrex")
            Return 0
            Exit Function
        End If

        If fe.iniciar(modo, cuit_emisor, archivo_certificado, archivo_licencia) Then
            If Not Resultado_Ticket_acceso(fe) Then
                MsgBox(errorFE(fe, c) & vbCr & vbCr & "Error al obtener el ticket de acceso, PROBLEMA DE AFIP")
                Return 0
                Exit Function
            Else
                fe.F1CabeceraCantReg = 1
                fe.F1CabeceraPtoVta = c.puntoVenta
                fe.F1CabeceraCbteTipo = c.id_tipoComprobante  'FACTURA A/B/NC

                fe.f1Indice = 0
                fe.F1DetalleConcepto = 1
                fe.F1DetalleDocTipo = cl.id_tipoDocumento     'CUIT/CUIL/DNI
                fe.F1DetalleDocNro = cl.dni    'CUIT
                fe.F1DetalleCbteDesde = c.numeroComprobante + 1
                fe.F1DetalleCbteHasta = c.numeroComprobante + 1
                fe.F1DetalleCbteFch = fechaAFIP()
                fe.F1DetalleImpTotal = f.total
                fe.F1DetalleImpTotalConc = 0
                fe.F1DetalleImpNeto = f.subtotal
                fe.F1DetalleImpOpEx = 0
                fe.F1DetalleImpIva = f.impuestos 'p.iva
                fe.F1DetalleMonId = "PES"
                fe.F1DetalleMonCotiz = 1

                fe.F1DetalleIvaItemCantidad = 1
                fe.f1IndiceItem = 0
                '20220728
                'Select Case c.id_tipoComprobante
                '    Case Is = 1, 2, 3, 4, 5, 63, 34, 39, 60, 51, 52, 53, 54
                fe.F1DetalleIvaId = 5 'IVA 21/ IVA 10.5
                '    Case Else
                '        fe.F1DetalleIvaId = 3 'IVA 0
                'End Select

                'Ajusta el tipo de IVA del documento si no tiene IVA
                '                If f.subtotal = f.total And f.impuestos = 0 Then fe.F1DetalleIvaId = 3

                fe.F1DetalleIvaBaseImp = f.subtotal
                fe.F1DetalleIvaImporte = f.impuestos 'p.iva

                fe.ArchivoXMLRecibido = "c:\recibido.xml"
                fe.ArchivoXMLEnviado = "c:\enviado.xml"

                lResultado = fe.F1CAESolicitar()
                '     MsgBox(fe.FERespuetaDetalleMotivo)
                'fe.FECabeceraCantReg = 1
                'lResultado = fe.Registrar(c.puntoVenta, c.id_tipoComprobante, p.id_pedido)

                If lResultado And fe.F1RespuestaDetalleCae <> "" Then
                    'Si obtuvo el CAE
                    'Actualizo la DB y al pedido le pongo el CAE y la fecha de vencimiento 
                    'Dim ce As New comprobante
                    'ce = info_comprobante(p.id_comprobante)
                    c.numeroComprobante = c.numeroComprobante + 1
                    updatecomprobante(c)

                    f.id_pedido = p.id_pedido
                    f.id_comprobante = c.id_comprobante
                    f.cae = fe.F1RespuestaDetalleCae
                    f.fechavencimiento_cae = fechaAFIP_fecha(fe.F1RespuestaDetalleCAEFchVto)
                    f.puntoVenta = c.puntoVenta
                    f.numeroComprobante = c.numeroComprobante
                    f.codigoDeBarras = generarCodigoDeBarras(cuit_emisor_default, f.numeroComprobante, f.puntoVenta, f.cae, fe.F1RespuestaDetalleCAEFchVto) '22092020
                    fe.F1DetalleQRArchivo = Application.StartupPath + "\QR\" + fe.F1RespuestaDetalleCae + ".jpg"
                    fe.f1detalleqrformato = 6
                    fe.f1detalleqrresolucion = 4
                    fe.f1detalleqrtolerancia = 1
                    fe.f1detalleqrformato = 6
                    f.fecha_emision = Format(DateTime.Now, "dd/MM/yyyy")
                    'f.fecha_emision = Format(DateTime.Now, "MM/dd/yyyy")

                    p.cerrado = True
                    p.activo = False
                    'updatepedido(p)

                    emiteFE(f)
                    If fe.f1qrGenerar(99) Then
                        Guardar_QR_DB(Application.StartupPath + "\QR\" + fe.F1RespuestaDetalleCae + ".jpg", p.id_pedido)
                    End If
                    imprimirFactura(p.id_pedido, c.esPresupuesto, c.emiteRemito)
                    Return 1
                Else
                    If Not c.testing Then
                        MsgBox(errorFE(fe, c))
                        Return 0 'Si no está en modo testing devuelve error
                    End If
                End If
                'Si es un test me devuelve la información de los errores
                'Consulta del último comprobante autorizado
                'MsgBox("El número del último comprobante autorizado para: " + c.comprobante + " es: " + fe.F1CompUltimoAutorizado(c.puntoVenta, c.id_tipoComprobante).ToString)
                'MsgBox("resultado global AFIP: " + fe.F1RespuestaResultado)
                'MsgBox("es reproceso? " + fe.F1RespuestaReProceso)
                'MsgBox("registros procesados por AFIP: " + Str(fe.F1RespuestaCantidadReg))
                'MsgBox("error genérico global:" + fe.f1ErrorMsg1)
                MsgBox(errorFE(fe, c))
                If fe.F1RespuestaCantidadReg > 0 Then
                    fe.f1Indice = 0
                    MsgBox(errorFE(fe, c))
                    If fe.F1RespuestaDetalleCae = "" Then Return 0 Else Return 1
                End If
                Return 0
            End If
        Else
            MsgBox(fe.UltimoMensajeError)
            Return 0
        End If
        '************** FACTURA ELECTRONICA ************** 
    End Function

    Public Sub imprimirFactura(ByVal id_pedido As Integer, ByVal esPresupuesto As Boolean, ByVal imprimeRemito As Boolean)
        'If showrpt Then
        id = id_pedido
        Dim frm As New frm_reportes(esPresupuesto, imprimeRemito)
        frm.ShowDialog()
        id = 0
        '        End If
    End Sub

    Public Function generarCodigoDeBarras(ByVal cuit_emisor As String, ByVal numeroComprobante As String, ByVal puntoVenta As String, ByVal cae As String, ByVal _
                                            fechaVencimiento_cae As String) As String
        Dim I As Long
        Dim Cod As String
        Dim Impares As Long = 0
        Dim Pares As Long = 0
        Dim Impares3 As Long
        Dim Total As Long
        Dim digitoVerificador As Integer
        Dim codigoDeBarras As String


        Cod = cuit_emisor & numeroComprobante.ToString & puntoVenta.ToString & cae & fechaVencimiento_cae

        'Ahora analizo la cadena de caracteres:
        'Tengo que sumar todos los caracteres impares y los pares
        'Pares = 0 : Impares = 0

        For I = 1 To Cod.Length
            If I Mod 2 = 0 Then
                ' Si el valor de I es par entra por aca
                Pares = Pares + CLng(Mid(Cod, I, 1))
            Else
                'Si el valor de I es impar entra por aca
                Impares = Impares + CLng(Mid(Cod, I, 1))
            End If
        Next I

        'Me.TxtImpares.Text = Impares
        'Me.TxtPares.Text = Pares
        'Me.Txt3Impares.Text = 3 * CLng(Me.TxtImpares.Text)
        Impares3 = 3 * CLng(Impares)
        'Me.TxtTotal.Text = CLng(Me.TxtPares.Text) + CLng(Me.Txt3Impares.Text)
        Total = CLng(Pares) + CLng(Impares3)

        'Me.TxtDigito.Text = 10 - (CLng(Me.TxtTotal.Text) Mod 10)
        digitoVerificador = 10 - (CLng(Total) Mod 10)

        'Me.TxtCodBarraF.Text = Cod & Me.TxtDigito.Text
        codigoDeBarras = Cod & digitoVerificador
        Return codigoDeBarras
    End Function
    Public Function consultaUltimoComprobante(ByVal puntoVenta As String, ByVal tipoComprobante As String, ByVal esTest As Boolean) As Integer
        Dim fe As New WSAFIPFE.Factura
        Dim resultadoTicket As Boolean

        If Not inicialesFE(esTest) Then
            Return -1
        End If

        If fe.iniciar(modo, cuit_emisor, archivo_certificado, archivo_licencia) Then
            fe.ArchivoCertificadoPassword = password_certificado
            If Not fe.f1TicketEsValido Then
                resultadoTicket = fe.f1ObtenerTicketAcceso()
                If Not resultadoTicket Then
                    Return -1
                End If
            Else
                resultadoTicket = True
            End If

            If resultadoTicket Then
                Return fe.F1CompUltimoAutorizado(puntoVenta, tipoComprobante)
            Else
                Return -1
            End If
        Else
            Return -1
        End If
    End Function

    Private Function errorFE(ByVal fe As WSAFIPFE.Factura, ByVal c As comprobante) As String
        Dim errorStr As String
        errorStr = "Último comprobante autorizado para: " + c.comprobante + " es: " + fe.F1CompUltimoAutorizado(c.puntoVenta, c.id_tipoComprobante).ToString
        errorStr += vbCr + "Último comprobante en la DB: " + c.comprobante + " es: " + c.numeroComprobante.ToString
        errorStr += vbCr + "Resultado global AFIP: " + fe.F1RespuestaResultado
        errorStr += vbCr + "Es reproceso? " + fe.F1RespuestaReProceso
        errorStr += vbCr + "Registros procesados por AFIP: " + Str(fe.F1RespuestaCantidadReg)
        errorStr += vbCr + "Error genérico global:" + fe.f1ErrorMsg1
        errorStr += vbCr + "Último error informado:" + fe.UltimoMensajeError
        Return errorStr
    End Function

    Private Function inicialesFE(ByVal esTest As Boolean) As Boolean
        pc = SystemInformation.ComputerName

        If esTest Then
            modo = WSAFIPFE.Factura.modoFiscal.Test

            Select Case pc
                Case Is = "JARVIS"
                    archivo_certificado = Application.StartupPath + "\Certificados\JarvisCert.p12"
                Case Is = "SERVTEC-06"
                    archivo_certificado = Application.StartupPath + "\Certificados\JarvisCert.p12"
                Case Is = "DOCTOROIL-C"
                    archivo_certificado = Application.StartupPath + "\Certificados\DROilPCTest.pfx"
                Case Is = "DOCTOROIL-M"
                    archivo_certificado = Application.StartupPath + "\Certificados\DOCTOROIL-M_TEST.pfx"
                Case Else
                    MsgBox("PC no habilitada para emitir documentos de testing.", vbCritical + vbOKOnly, "Centrex")
                    Return False
            End Select
            archivo_licencia = ""
        Else
            modo = WSAFIPFE.Factura.modoFiscal.Fiscal
            Select Case pc
                Case Is = "JARVIS"
                    archivo_certificado = Application.StartupPath + "\Certificados\JARVIS.pfx"
                Case Is = "SERVTEC-06"
                    archivo_certificado = Application.StartupPath + "\Certificados\nohaycertificado.pfx"
                Case Is = "DOCTOROIL-C"
                    archivo_certificado = Application.StartupPath + "\Certificados\DROilPCOk.pfx"
                Case Is = "DOCTOROIL-M"
                    archivo_certificado = Application.StartupPath + "\Certificados\DOCTOROIL-M.pfx"
                Case Else
                    MsgBox("PC no habilitada para emitir documentos de testing.", vbCritical + vbOKOnly, "Centrex")
                    Return False
            End Select
            archivo_licencia = Application.StartupPath + "\Certificados\WSAFIPFE.lic"
        End If

        If Not File.Exists(archivo_certificado) Then
            MsgBox("No existe el archivo del certificado, no podrá continuar.", vbCritical + vbOKOnly, "Centrex")
            Return False
        ElseIf Not File.Exists(archivo_licencia) Then
            MsgBox("No existe el archivo de la licencia, no podrá continuar.", vbCritical + vbOKOnly, "Centrex")
            Return False
        End If

        cuit_emisor = cuit_emisor_default
        password_certificado = "Ladeda78"
        Return True
    End Function

    'Public Function facturaTest() As Integer
    '    'SI DEVUELVE 1 ESTÁ TODO OK
    '    'SI DEVUELVE 0 HUBO UN ERROR

    '    '************** FACTURA ELECTRONICA ************** 

    '    Dim modo As String
    '    Dim cuit_emisor As String
    '    Dim archivo_certificado As String
    '    Dim archivo_licencia As String
    '    Dim password_certificado As String
    '    Dim resultadoTicket As Boolean

    '    'Dim lResultado As Boolean
    '    Dim fe As New WSAFIPFE.Factura

    '    modo = WSAFIPFE.Factura.modoFiscal.Fiscal
    '    archivo_certificado = "D:\Dropbox\Golosinas Gabriel\Certificados\GGFE_produccion.pfx"
    '    archivo_licencia = "D:\Dropbox\Golosinas Gabriel\Certificados\WSAFIPFE.lic"

    '    cuit_emisor = cuit_emisor_default
    '    password_certificado = "Ladeda78"

    '    If fe.iniciar(modo, cuit_emisor, archivo_certificado, archivo_licencia) Then
    '        fe.ArchivoCertificadoPassword = password_certificado
    '        'MsgBox(fe.f1TicketHoraVencimiento)
    '        'Return 0            
    '        If Not fe.f1TicketEsValido Then
    '            resultadoTicket = fe.f1ObtenerTicketAcceso()
    '            If Not resultadoTicket Then
    '                MsgBox(fe.UltimoMensajeError)
    '                Return False
    '                Exit Function
    '            End If
    '        Else
    '            resultadoTicket = True
    '        End If
    '        Return resultadoTicket
    '    Else
    '        Return -1
    '    End If
    'End Function

    Public Function Guardar_QR_DB(ByVal archivo_imagen As String, ByVal id_pedido As Integer)
        Dim ds As New DataSet
        Dim con As New SqlClient.SqlConnection("Server=" + serversql + ";Database=" + basedb + ";Uid=" + usuariodb + ";Password=" + passdb)
        Dim img As Image
        Dim ms As New System.IO.MemoryStream
        Dim md As Byte()
        Dim sqlstr As String
        Dim param As New SqlClient.SqlParameter("@qr", SqlDbType.Image)
        con.Open()
        sqlstr = "UPDATE FE SET fc_qr = @qr WHERE id_pedido = '" + id_pedido.ToString + "'"
        Dim cmd As New SqlClient.SqlCommand(sqlstr, con)

        img = Image.FromFile(archivo_imagen)

        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
        md = ms.GetBuffer

        param.Value = md
        cmd.Parameters.Add(param)
        cmd.ExecuteNonQuery()
        con.Close()
        Return 0
    End Function

    Private Function Resultado_Ticket_acceso(ByRef fe As WSAFIPFE.Factura) As Boolean
        Dim resultadoTicket As Boolean
        fe.tls = 12
        fe.ArchivoCertificadoPassword = password_certificado

        If fe.f1TicketEsValido Then
            If My.Computer.FileSystem.FileExists(Application.StartupPath + "\ticketAccesoFE.jav") Then
                fe.f1RestaurarTicketAcceso(leerArchivoTexto(Application.StartupPath + "\ticketAccesoFE.jav"))
            End If
            Return 1
        Else
            resultadoTicket = fe.f1ObtenerTicketAcceso()
            guardarArchivoTexto(Application.StartupPath + "\ticketAccesoFE.jav", fe.f1GuardarTicketAcceso)
            If Not resultadoTicket Then
                Return 0
            Else
                Return 1
            End If
        End If
    End Function

    Public Sub Consultar_Comprobante(ByVal pVenta As Integer, ByVal tipo_comprobante As Integer, ByVal nComprobante As String)
        Dim fe As New WSAFIPFE.Factura
        Dim resultado As Boolean
        Dim respuestaCAE As String

        If Not inicialesFE(0) Then
            MsgBox("Hubo un problema al inicializar el webservice, puede ser un problema de certificados", vbCritical + vbOKOnly, "Centrex")
            Exit Sub
        End If

        If fe.iniciar(modo, cuit_emisor, archivo_certificado, archivo_licencia) Then
            If Not Resultado_Ticket_acceso(fe) Then
                MsgBox("Error al obtener el ticket de acceso, con el siguiente error: " + fe.UltimoMensajeError)
                Exit Sub
            Else
                fe.F1CabeceraCantReg = 1
                fe.f1Indice = 0
                fe.f1IndiceItem = 0
                fe.F1DetalleQRArchivo = Application.StartupPath + "\QR\" + nComprobante + ".jpg"
                fe.f1detalleqrformato = 6
                fe.f1detalleqrresolucion = 20
                fe.f1detalleqrtolerancia = 3
                fe.ArchivoXMLRecibido = "c:\recibido.xml"
                resultado = fe.F1CompConsultar(pVenta, tipo_comprobante, nComprobante)
                If fe.UltimoMensajeError = "" Then
                    respuestaCAE = "CAE consultado: " + fe.F1RespuestaDetalleCae + vbCrLf
                    respuestaCAE += "Total: " + Str(fe.F1DetalleImpTotal)
                    MsgBox(respuestaCAE, vbInformation + vbOKOnly, "Centrex")
                Else
                    MsgBox("Fallo la consulta con el siguiente error:" + fe.UltimoMensajeError)

                End If
            End If
        Else
            MsgBox("Fallo al iniciar el webservice con el siguiente error: " + fe.UltimoMensajeError)
        End If
    End Sub
    '************** FACTURA ELECTRONICA ************** 
End Module
