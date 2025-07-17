Module Module1
    'Public serversql As String = "(local)\sqlexpress"
    Public serversql As String
    'Public basedb As String = "DROil"
    'Public basedb As String = "DROilTest"
    Public basedb As String
    Public usuariodb As String = "sa"
    Public passdb As String = "Ladeda78"
    Public rutaBackup As String
    Public archivoBackup As String
    Public stockMinimo As Integer
    Public sepDecimal As Char
    Public itXPage As Integer
    Public showrpt As Boolean = False
    Public stock0 As Boolean = True 'Cuando es verdadero muestra items con stock 0
    Public clonaItemsPedido As Boolean = False

    Public edicion As Boolean
    Public edicion_item_registro_stock As Boolean
    Public borrado As Boolean
    Public terminaCaso As Boolean
    Public terminarPedido As Boolean
    Public agregaItem As Boolean
    Public cargaRapidaDeCaso As Boolean
    Public pedidoACaso As Boolean
    Public busquedaAvanzada As Boolean
    'Public cantidaditem As Long
    Public id As Integer
    Public datos_consulta(,) As String
    Public tabla As String
    Public form As Form
    Public activo As Boolean = True
    Public itemsstock0 As Boolean = False

    Public edita_cliente As New cliente
    Public edita_marcaa As New marca_auto
    Public edita_marcai As New marca_item
    Public edita_auto As New auto
    Public edita_item As New item
    Public edita_proveedor As New proveedor
    Public edita_comprobante As New comprobante
    Public edita_tipoitem As New tipoitem
    Public edita_modeloa As New modelo_auto
    Public edita_rosca As New rosca
    Public edita_descuento As New descuento
    Public edita_condicion As New condicion
    Public edita_pedido As New pedido
    Public edita_presupuesto As New presupuesto
    Public edita_tipocaso As New tipo_caso
    Public edita_registro_stock As New registro_stock
    Public edita_item_registro_stock As New registro_stock
    Public edita_caja As New caja
    Public edita_tarjeta As New tarjeta
    Public edita_grupoTarjetas As New grupoTarjetas
    Public edita_consulta As New consultaP
    Public edita_impuesto As New impuesto
    Public edita_fe As New FE
    Public edita_perfil As New perfil
    Public edita_permiso As New permiso
    Public edita_usuario As New usuario
    Public edita_permiso_perfil As New perfil_permiso
    Public edita_perfil_usuario As New usuario_perfil
    Public edita_vendedor As New vendedor
    Public edita_mecanico As New mecanico

    Public busca_cliente As New cliente
    Public busca_marcaa As New marca_auto
    Public busca_marcai As New marca_item
    Public busca_auto As New auto
    Public busca_item As New item
    Public busca_proveedor As New proveedor
    Public busca_tipoitem As New tipoitem
    Public busca_modeloa As New modelo_auto
    Public busca_descuento As New descuento
    Public busca_condicion As New condicion
    Public busca_caso As New pedido
    Public busca_rosca As New rosca

    Public secuencia As Boolean = False

    Public proveedor_indefinido As Integer

    Public modificacionesDB As Boolean

    Public lightItemCol As Integer
    Public lightRegStock As Integer
    Public clrMinimo As Color

    Public cmpFacturas() As Integer = {1, 6, 11, 51}

    Public usuario_logueado As usuario
End Module
