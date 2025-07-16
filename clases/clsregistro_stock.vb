Public Class registro_stock
    Public id_registro As Integer
    Public id_ingreso As Integer
    Public fecha As String
    Public fecha_ingreso As String
    Public factura As String
    'Public archivofc As nose
    Public id_proveedor As Integer
    Public id_item As Integer
    Public cantidad As Decimal
    Public costo As Decimal
    Public precio_lista As Decimal
    Public markup As Decimal
    Public descuento As Decimal
    Public id_iva As Integer
    Public cantidad_anterior As Long
    Public costo_anterior As Decimal
    Public precio_lista_anterior As Decimal
    Public markup_anterior As Decimal
    Public descuento_anterior As Decimal
    Public id_iva_anterior As Decimal
    Public nota As String
    Public activo As Boolean
    Public checkStock As Boolean
    Public stockRepo As Integer
    Public checkStock_anterior As Boolean
    Public stockRepo_anterior As Integer
End Class
