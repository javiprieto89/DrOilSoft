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

        Dim ticket As LoginTicket
        Dim urlWsaa As String = If(c.testing, "https://wsaahomo.afip.gov.ar/ws/services/LoginCms?WSDL", "https://wsaa.afip.gov.ar/ws/services/LoginCms?WSDL")
        Dim urlWsfe As String = If(c.testing, "https://wswhomo.afip.gov.ar/wsfev1/service.asmx", "https://servicios1.afip.gov.ar/wsfev1/service.asmx")

        ticket = ObtenerTicket("wsfe", urlWsaa, archivo_certificado, password_certificado)

        Dim cab As New wsfev1.FECAECabRequest
        cab.CantReg = 1
        cab.CbteTipo = c.id_tipoComprobante
        cab.PtoVta = c.puntoVenta

        Dim det As New wsfev1.FECAEDetRequest
        det.Concepto = 1
        det.DocTipo = cl.id_tipoDocumento
        det.DocNro = cl.dni
        det.CbteDesde = c.numeroComprobante + 1
        det.CbteHasta = c.numeroComprobante + 1
        det.CbteFch = fechaAFIP()
        det.ImpTotal = f.total
        det.ImpTotConc = 0
        det.ImpNeto = f.subtotal
        det.ImpOpEx = 0
        det.ImpIVA = f.impuestos
        det.MonId = "PES"
        det.MonCotiz = 1
        Dim iva As New wsfev1.AlicIva
        iva.Id = 5
        iva.BaseImp = f.subtotal
        iva.Importe = f.impuestos
        det.Iva = New wsfev1.AlicIva() {iva}

        Dim req As New wsfev1.FECAERequest
        req.FeCabReq = cab
        req.FeDetReq = New wsfev1.FECAEDetRequest() {det}

        Dim resp As wsfev1.FECAEResponse = SolicitarCAE(ticket, req, CLng(cuit_emisor), urlWsfe)

        If resp.FeCabResp IsNot Nothing AndAlso resp.FeCabResp.Resultado = "A" Then
            c.numeroComprobante = c.numeroComprobante + 1
            updatecomprobante(c)

            f.id_pedido = p.id_pedido
            f.id_comprobante = c.id_comprobante
            f.cae = resp.FeDetResp(0).CAE
            f.fechavencimiento_cae = fechaAFIP_fecha(resp.FeDetResp(0).CAEFchVto)
            f.puntoVenta = c.puntoVenta
            f.numeroComprobante = c.numeroComprobante
            f.codigoDeBarras = generarCodigoDeBarras(cuit_emisor_default, f.numeroComprobante, f.puntoVenta, f.cae, resp.FeDetResp(0).CAEFchVto)
            f.fecha_emision = Format(DateTime.Now, "dd/MM/yyyy")
            p.cerrado = True
            p.activo = False
            emiteFE(f)
            imprimirFactura(p.id_pedido, c.esPresupuesto, c.emiteRemito)
            Return 1
        Else
            MsgBox("Error al obtener CAE", vbCritical)
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

    Public Sub Consultar_Comprobante(ByVal pVenta As Integer, ByVal tipo_comprobante As Integer, ByVal nComprobante As String)
        If Not inicialesFE(False) Then
            MsgBox("Hubo un problema al inicializar el webservice, puede ser un problema de certificados", vbCritical + vbOKOnly, "Centrex")
            Exit Sub
        End If

        Dim urlWsaa As String = "https://wsaa.afip.gov.ar/ws/services/LoginCms?WSDL"
        Dim urlWsfe As String = "https://servicios1.afip.gov.ar/wsfev1/service.asmx"
        Dim ticket As LoginTicket = ObtenerTicket("wsfe", urlWsaa, archivo_certificado, password_certificado)
        Dim svc As New wsfev1.Service()
        svc.Url = urlWsfe
        Dim auth As New wsfev1.FEAuthRequest()
        auth.Token = ticket.Token
        auth.Sign = ticket.Sign
        auth.Cuit = CLng(cuit_emisor)

        Dim req As New wsfev1.FECompConsultaReq()
        req.PtoVta = pVenta
        req.CbteTipo = tipo_comprobante
        req.CbteNro = CLng(nComprobante)

        Dim resp As wsfev1.FECompConsultaResponse = svc.FECompConsultar(auth, req)

        If resp.Errors Is Nothing Then
            Dim respuestaCAE As String = "CAE consultado: " & resp.ResultGet.CodAutorizacion & vbCrLf
            respuestaCAE += "Total: " & resp.ResultGet.ImpTotal.ToString()
            MsgBox(respuestaCAE, vbInformation + vbOKOnly, "Centrex")
        Else
            MsgBox("Fallo la consulta con el siguiente error:" & resp.Errors(0).Msg)
        End If
    End Sub
    Public Function consultaUltimoComprobante(ByVal puntoVenta As String, ByVal tipoComprobante As String, ByVal esTest As Boolean) As Integer
        If Not inicialesFE(esTest) Then
            Return -1
        End If

        Dim urlWsaa As String = If(esTest, "https://wsaahomo.afip.gov.ar/ws/services/LoginCms?WSDL", "https://wsaa.afip.gov.ar/ws/services/LoginCms?WSDL")
        Dim urlWsfe As String = If(esTest, "https://wswhomo.afip.gov.ar/wsfev1/service.asmx", "https://servicios1.afip.gov.ar/wsfev1/service.asmx")
        Dim ticket As LoginTicket = ObtenerTicket("wsfe", urlWsaa, archivo_certificado, password_certificado)
        Dim svc As New wsfev1.Service()
        svc.Url = urlWsfe
        Dim auth As New wsfev1.FEAuthRequest()
        auth.Token = ticket.Token
        auth.Sign = ticket.Sign
        auth.Cuit = CLng(cuit_emisor)
        Dim resp As wsfev1.FERecuperaLastCbteResponse = svc.FECompUltimoAutorizado(auth, puntoVenta, tipoComprobante)
        Return resp.CbteNro
    End Function


    Private Function inicialesFE(ByVal esTest As Boolean) As Boolean
        pc = SystemInformation.ComputerName

        If esTest Then
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
        Else
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
        End If

        If Not File.Exists(archivo_certificado) Then
            MsgBox("No existe el archivo del certificado, no podrá continuar.", vbCritical + vbOKOnly, "Centrex")
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

    'Función de ticket y consulta de comprobantes removida al utilizar la implementacion nativa de AFIP
    '************** FACTURA ELECTRONICA ************** 
End Module
