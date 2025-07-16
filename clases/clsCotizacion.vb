
Public Class Rootobject
    Public Property GetCotizacion() As Cotizacion
End Class

Public Class Cotizacion
    Public Property moneda As String
    Public Property casa As String
    Public Property nombre As String
    Public Property compra As Double
    Public Property venta As Double
    Public Property fechaActualizacion As String
End Class

Public Class Root
    Public Property cotizacion As List(Of Cotizacion)
End Class
