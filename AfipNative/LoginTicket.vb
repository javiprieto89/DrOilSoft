'AfipNative/LoginTicket.vb'
Imports System
Imports System.Xml
Imports System.Net
Imports System.Security
Imports System.Security.Cryptography.X509Certificates
Imports System.Security.Cryptography.Pkcs
Imports System.Text

Class LoginTicket

    Public UniqueId As UInt32 ' Entero de 32 bits sin signo que identifica el requerimiento
    Public GenerationTime As DateTime ' Momento en que fue generado el requerimiento
    Public ExpirationTime As DateTime ' Momento en el que exoira la solicitud
    Public Service As String ' Identificacion del WSN para el cual se solicita el TA
    Public Sign As String ' Firma de seguridad recibida en la respuesta
    Public Token As String ' Token de seguridad recibido en la respuesta

    Public XmlLoginTicketRequest As XmlDocument = Nothing
    Public XmlLoginTicketResponse As XmlDocument = Nothing
    Public RutaDelCertificadoFirmante As String
    Public XmlStrLoginTicketRequestTemplate As String = "<loginTicketRequest><header><uniqueId></uniqueId><generationTime></generationTime><expirationTime></expirationTime></header><service></service></loginTicketRequest>"

    Private _verboseMode As Boolean = True

    Private Shared _globalUniqueID As UInt32 = 0 ' OJO! NO ES THREAD-SAFE

    ''' <summary>
    ''' Construye un Login Ticket obtenido del WSAA
    ''' </summary>
    ''' <param name="argServicio">Servicio al que se desea acceder</param>
    ''' <param name="argUrlWsaa">URL del WSAA</param>
    ''' <param name="argRutaCertX509Firmante">Ruta del certificado X509 (con clave privada) usado para firmar</param>
    ''' <param name="argPassword">Password del certificado X509 (con clave privada) usado para firmar</param>
    ''' <param name="argProxy">IP:port del proxy</param>
    ''' <param name="argProxyUser">Usuario del proxy</param>''' 
    ''' <param name="argProxyPassword">Password del proxy</param>
    ''' <param name="argVerbose">Nivel detallado de descripcion? true/false</param>
    ''' <remarks></remarks>
    Public Function ObtenerLoginTicketResponse( _
    ByVal argServicio As String, _
    ByVal argUrlWsaa As String, _
    ByVal argRutaCertX509Firmante As String, _
    ByVal argPassword As SecureString, _
    ByVal argProxy As String, _
    ByVal argProxyUser As String, _
    ByVal argProxyPassword As String, _
    ByVal argVerbose As Boolean _
    ) As String

        Me.RutaDelCertificadoFirmante = argRutaCertX509Firmante
        Me._verboseMode = argVerbose
        CertificadosX509Lib.VerboseMode = argVerbose

        Dim cmsFirmadoBase64 As String
        Dim loginTicketResponse As String
        Dim xmlNodoUniqueId As XmlNode
        Dim xmlNodoGenerationTime As XmlNode
        Dim xmlNodoExpirationTime As XmlNode
        Dim xmlNodoService As XmlNode

        ' PASO 1: Genero el Login Ticket Request
        Try
            _globalUniqueID += 1

            XmlLoginTicketRequest = New XmlDocument()
            XmlLoginTicketRequest.LoadXml(XmlStrLoginTicketRequestTemplate)

            xmlNodoUniqueId = XmlLoginTicketRequest.SelectSingleNode("//uniqueId")
            xmlNodoGenerationTime = XmlLoginTicketRequest.SelectSingleNode("//generationTime")
            xmlNodoExpirationTime = XmlLoginTicketRequest.SelectSingleNode("//expirationTime")
            xmlNodoService = XmlLoginTicketRequest.SelectSingleNode("//service")

            xmlNodoGenerationTime.InnerText = DateTime.Now.AddMinutes(-10).ToString("s")
            xmlNodoExpirationTime.InnerText = DateTime.Now.AddMinutes(+10).ToString("s")
            xmlNodoUniqueId.InnerText = CStr(_globalUniqueID)
            xmlNodoService.InnerText = argServicio
            Me.Service = argServicio

            If Me._verboseMode Then
                Console.WriteLine(XmlLoginTicketRequest.OuterXml)
            End If

        Catch excepcionAlGenerarLoginTicketRequest As Exception
            Throw New Exception("***Error GENERANDO el LoginTicketRequest : " + excepcionAlGenerarLoginTicketRequest.Message + excepcionAlGenerarLoginTicketRequest.StackTrace)
        End Try

        ' PASO 2: Firmo el Login Ticket Request
        Try
            If Me._verboseMode Then
                Console.WriteLine("***Leyendo certificado: {0}", RutaDelCertificadoFirmante)
            End If

            Dim certFirmante As X509Certificate2 = CertificadosX509Lib.ObtieneCertificadoDesdeArchivo(RutaDelCertificadoFirmante, argPassword)

            If Me._verboseMode Then
                Console.WriteLine("***Firmando: ")
                Console.WriteLine(XmlLoginTicketRequest.OuterXml)
            End If

            ' Convierto el login ticket request a bytes, para firmar
            Dim EncodedMsg As Encoding = Encoding.UTF8
            Dim msgBytes As Byte() = EncodedMsg.GetBytes(XmlLoginTicketRequest.OuterXml)

            ' Firmo el msg y paso a Base64
            Dim encodedSignedCms As Byte() = CertificadosX509Lib.FirmaBytesMensaje(msgBytes, certFirmante)
            cmsFirmadoBase64 = Convert.ToBase64String(encodedSignedCms)

        Catch excepcionAlFirmar As Exception
            Throw New Exception("***Error FIRMANDO el LoginTicketRequest : " + excepcionAlFirmar.Message)
        End Try

        ' PASO 3: Invoco al WSAA para obtener el Login Ticket Response
        Try
            If Me._verboseMode Then
                Console.WriteLine("***Llamando al WSAA en URL: {0}", argUrlWsaa)
                Console.WriteLine("***Argumento en el request:")
                Console.WriteLine(cmsFirmadoBase64)
            End If

            Dim servicioWsaa As New Wsaa.LoginCMSService()
            servicioWsaa.Url = argUrlWsaa
            If argProxy IsNot Nothing Then
                servicioWsaa.Proxy = New WebProxy(argProxy, True)
                If argProxyUser IsNot Nothing Then
                    Dim Credentials As New NetworkCredential(argProxyUser, argProxyPassword)
                    servicioWsaa.Proxy.Credentials = Credentials
                End If
            End If
            loginTicketResponse = servicioWsaa.loginCms(cmsFirmadoBase64)

            If Me._verboseMode Then
                Console.WriteLine("***LoguinTicketResponse: ")
                Console.WriteLine(loginTicketResponse)
            End If

        Catch excepcionAlInvocarWsaa As Exception
            Throw New Exception("***Error INVOCANDO al servicio WSAA : " + excepcionAlInvocarWsaa.Message)
        End Try


        ' PASO 4: Analizo el Login Ticket Response recibido del WSAA
        Try
            XmlLoginTicketResponse = New XmlDocument()
            XmlLoginTicketResponse.LoadXml(loginTicketResponse)

            Me.UniqueId = UInt32.Parse(XmlLoginTicketResponse.SelectSingleNode("//uniqueId").InnerText)
            Me.GenerationTime = DateTime.Parse(XmlLoginTicketResponse.SelectSingleNode("//generationTime").InnerText)
            Me.ExpirationTime = DateTime.Parse(XmlLoginTicketResponse.SelectSingleNode("//expirationTime").InnerText)
            Me.Sign = XmlLoginTicketResponse.SelectSingleNode("//sign").InnerText
            Me.Token = XmlLoginTicketResponse.SelectSingleNode("//token").InnerText
        Catch excepcionAlAnalizarLoginTicketResponse As Exception
            Throw New Exception("***Error ANALIZANDO el LoginTicketResponse : " + excepcionAlAnalizarLoginTicketResponse.Message)
        End Try

        Return loginTicketResponse

    End Function


End Class

''' <summary>
''' Libreria de utilidades para manejo de certificados
''' </summary>
''' <remarks></remarks>
Class CertificadosX509Lib

    Public Shared VerboseMode As Boolean = False

    ''' <summary>
    ''' Firma mensaje
    ''' </summary>
    ''' <param name="argBytesMsg">Bytes del mensaje</param>
    ''' <param name="argCertFirmante">Certificado usado para firmar</param>
    ''' <returns>Bytes del mensaje firmado</returns>
    ''' <remarks></remarks>
    Public Shared Function FirmaBytesMensaje( _
    ByVal argBytesMsg As Byte(), _
    ByVal argCertFirmante As X509Certificate2 _
    ) As Byte()
        Try
            ' Pongo el mensaje en un objeto ContentInfo (requerido para construir el obj SignedCms)
            Dim infoContenido As New ContentInfo(argBytesMsg)
            Dim cmsFirmado As New SignedCms(infoContenido)

            ' Creo objeto CmsSigner que tiene las caracteristicas del firmante
            Dim cmsFirmante As New CmsSigner(argCertFirmante)
            cmsFirmante.IncludeOption = X509IncludeOption.EndCertOnly

            If VerboseMode Then
                Console.WriteLine("***Firmando bytes del mensaje...")
            End If
            ' Firmo el mensaje PKCS #7
            cmsFirmado.ComputeSignature(cmsFirmante)

            If VerboseMode Then
                Console.WriteLine("***OK mensaje firmado")
            End If

            ' Encodeo el mensaje PKCS #7.
            Return cmsFirmado.Encode()
        Catch excepcionAlFirmar As Exception
            Throw New Exception("***Error al firmar: " & excepcionAlFirmar.Message)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Lee certificado de disco
    ''' </summary>
    ''' <param name="argArchivo">Ruta del certificado a leer.</param>
    ''' <returns>Un objeto certificado X509</returns>
    ''' <remarks></remarks>
    Public Shared Function ObtieneCertificadoDesdeArchivo( _
    ByVal argArchivo As String, _
    ByVal argPassword As SecureString _
    ) As X509Certificate2
        Dim objCert As New X509Certificate2
        Try
            If argPassword.IsReadOnly Then
                objCert.Import(My.Computer.FileSystem.ReadAllBytes(argArchivo), argPassword, X509KeyStorageFlags.PersistKeySet)
            Else
                objCert.Import(My.Computer.FileSystem.ReadAllBytes(argArchivo))
            End If
            Return objCert
        Catch excepcionAlImportarCertificado As Exception
            Throw New Exception(excepcionAlImportarCertificado.Message & " " & excepcionAlImportarCertificado.StackTrace)
            Return Nothing
        End Try
    End Function

End Class

