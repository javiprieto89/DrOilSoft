Public Class pedido
    Public id_pedido As Integer
    Public fecha As String
    Public id_cliente As Integer
    Public id_auto As Integer
    Public esCaso As Boolean = False
    Public id_tipo As Integer
    Public km As Long
    Public proximocambio As Long
    Public notas As String
    Public id_condicion As Integer
    Public id_descuento As Integer
    Public id_caja As Integer
    Public subTotal As Double
    Public total As Double
    Public activo As Boolean = True
    Public cerrado As Boolean = True
    Public montoTarjeta As Double
    Public fecha_cierre As String
    Public iva As Double
    Public id_pedidoAsociado As Integer
    Public id_usuario As Integer
    Public id_vendedor As Integer
    Public id_mecanico As Integer
    Public id_pedidoStatus As Integer
    'Public es_presupuesto As Boolean

    'Public id_comprobante As Integer
    'Public cae As String
    'Public fechaVencimiento_cae As String
    'Public puntoVenta As Integer
    'Public numeroComprobante As Integer
    'Public codigoDeBarras As String
    'Public esTest As Boolean
    'Public id_vendedor As Integer
    'Public id_listaPrecio As Integer
    'Public idPresupuesto As Integer
End Class
