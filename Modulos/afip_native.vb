'Modulos/afip_native.vb
Imports System.Security
Module afip_native
    Public Function ObtenerTicket(service As String, url As String, cert As String, password As String) As LoginTicket
        Dim ss As New SecureString()
        For Each ch As Char In password
            ss.AppendChar(ch)
        Next
        ss.MakeReadOnly()
        Dim lt As New LoginTicket()
        lt.ObtenerLoginTicketResponse(service, url, cert, ss, Nothing, Nothing, Nothing, False)
        Return lt
    End Function

    Public Function SolicitarCAE(lt As LoginTicket, req As wsfev1.FECAERequest, cuit As Long, url As String) As wsfev1.FECAEResponse
        Dim svc As New wsfev1.Service()
        svc.Url = url
        Dim auth As New wsfev1.FEAuthRequest()
        auth.Token = lt.Token
        auth.Sign = lt.Sign
        auth.Cuit = cuit
        Return svc.FECAESolicitar(auth, req)
    End Function
End Module
