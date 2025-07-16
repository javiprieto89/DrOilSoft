Imports DrOil.clsgenerales
Imports Microsoft.Office.Interop
Imports System.IO
Imports System.Data.SqlClient

Public Class main
    Dim desde As Integer
    Dim hasta As Integer
    Dim pagina As Integer
    Dim nRegs As Integer
    Dim tPaginas As Integer
    Dim orderCol As ColumnClickEventArgs = Nothing

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Visible = False
        Dim pc As String

        pc = SystemInformation.ComputerName

        ' ******* Configuraciones inciales *******
        Dim c As New configInit
        c.leerConfig()

        If pc = "JARVIS" Or pc = "SERVTEC-06" Or pc = "SKYNET" Or pc = "CORTANA " Then
            serversql = "127.0.0.1"
        ElseIf pc = "VM7PC" Then
            serversql = "192.168.2.100"
        End If

        'SI QUERES FORZAR EL DEPURADO
        'depuracion = True
        If Debugger.IsAttached Then
            depuracion = True
            t_reloj.Enabled = False
        End If

        ' ******* Testeos inciales *******
        If abrirdb(serversql, basedb, usuariodb, passdb) = False Then
            MsgBox("Error al abrir la Base de datos.")
            End
        End If
        cerrardb()

        proveedor_indefinido = 9999 'Proveedor por default
        id_cliente_pedido = 27 'Cliente mostrador
        id_condicion = 2 'Condición contado
        id_descuento = 2 'Sin descuento
        id_sinDescuento = 2 'Sin descuento ===> FIJO (isSysten = TRUE)
        id_caja = 1 'Caja 1
        id_vendedor = 1 'Predeterminado
        id_mecanico = 1 'Predeterminado
        id_pedidoStatus = 2 'En proceso
        id_grupoTarjeta = 1 'Sin grupo
        id_tarjeta = 1 'Sin tarjeta
        modificacionesDB = 0
        archivaringresostock()
        lightItemCol = 5
        clrMinimo = Color.Orange
        lightRegStock = 7
        'cuit_emisor_default = "20924842971" ------>>> CUIT DE NESTOR
        cuit_emisor_default = "20233695255"
        id_tipoDocumento_default = 96
        id_pais_default = 54
        id_provincia_default = 19
        configuracion_regional.cambiarIdioma()
        ' ******* Sentencias SQL específicas que se quieran ejecutar antes de iniciar la aplicación *******
        'ejecutarSQL("UPDATE pedidos SET activo = '0' WHERE id_pedido = '49123'")
        ' ******* Sentencias SQL específicas que se quieran ejecutar antes de iniciar la aplicación *******
        ' ******* Configuraciones inciales *******



        ' ******* Sentencias SQL específicas que se quieran ejecutar antes de iniciar la aplicación *******
        'ejecutarSQL("SQL")
        Try
            Dim di As DirectoryInfo = New DirectoryInfo("..\..\ScriptsDB")
            Dim fileReader As String
            Dim archivo As String
            Dim nuevoArchivo As String
            For Each fi In di.GetFiles()
                archivo = fi.DirectoryName + "\" + fi.Name
                nuevoArchivo = archivo.Substring(0, archivo.Length - 4) + ".jav"
                If Path.GetExtension(archivo) = ".sql" Then
                    fileReader = My.Computer.FileSystem.ReadAllText(archivo)
                    ejecutarSQL(fileReader)
                    Rename(archivo, nuevoArchivo)
                End If
            Next
        Catch ex As Exception
            MsgBox("Ocurrió un error al ejecutar procesos de actualización de la base de datos" & vbNewLine & "Hablé con el programador" & vbNewLine & "Se recomienda no continuar usando el sistema hasta que esta situación se corrija", vbCritical + vbOKOnly, "Computron")
        End Try
        ' ******* Sentencias SQL específicas que se quieran ejecutar antes de iniciar la aplicación *******

        If modificacionesDB And Not pc = "JARVIS" Then
            MsgBox("Se deben hacer modificaciones mayores a la base de datos para que se ajuste a la última versión del programa." & Chr(13) _
                           + "Avisele al programador, ya que puede ser que el programa no corra correctamente sin estas modificaciones", vbInformation + vbOKOnly, "Computron")
        End If

        'borrartbl("tmppedidos_items")

        loadStartSettings()
        chk_rpt.Checked = showrpt
        chk_stock0.Checked = stock0

        Dim cantUsuarios As Integer
        cantUsuarios = cantReg(basedb, "SELECT * FROM usuarios")
        If cantUsuarios = 0 Then
            Do Until cantUsuarios > 0
                If MsgBox("No tiene creado ningún usuario para loguearse en el sistema, debera crear uno." & vbCr &
                           "Presione aceptar para crear uno a continuación o salir para terminar.", vbExclamation + vbOKCancel, "Dr. Oil") = MsgBoxResult.Cancel Then
                    End
                End If
                add_usuario.ShowDialog()
                cantUsuarios = cantReg(basedb, "SELECT * FROM usuarios")
                If cantUsuarios = 0 Then
                    MsgBox("No ha creado ningún usuario, no podrá iniciar el sistema hasta que cree uno.", vbExclamation + vbOKOnly, "Dr. Oil")
                Else
                    MsgBox("El sistema se cerrará y al abrirlo deberá iniciar sesión con el usuario y clave que acaba de crear.", vbInformation + vbOKOnly, "Dr. Oil")
                    closeandupdate(Me)
                End If
            Loop
        Else
            'Loguearse en el sistema
            If pc <> "JARVISj" And pc <> "SERVTEC-06" And depuracion = False Then
                login.ShowDialog()
            Else
                usuario_logueado = info_usuario("javierp", True)
            End If
            borrar_tabla_pedidos_temporales(usuario_logueado.id_usuario)
            borrar_tabla_presupuestos_temporales(usuario_logueado.id_usuario)
            Me.Visible = True
        End If


        If haycambios() Then
            frmcambios.ShowDialog()
        End If

        'Obtiene la cotización del dolar
        t_GetDolar_Tick(Nothing, Nothing)

        cmd_add.Enabled = False
        lsview.Visible = False
        txt_search.Enabled = False
        lbl_borrarbusqueda.Enabled = False
        chk_historicos.Enabled = False

        With My.Application.Info.Version
            tss_version.Text = "Versión: " & .Major & "." & .Minor & "." & .Revision
        End With
        tss_hora.Text = "Hora: " & DateAndTime.TimeOfDay
        tss_usuario.Text = "Usuario: " & usuario_logueado.nombre
        Treev.ExpandAll()
    End Sub

    Private Sub Treev_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles Treev.NodeMouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If cmd_add.Enabled = False Then
                cmd_add.Enabled = True
                lsview.Visible = True
                txt_search.Enabled = True
                lbl_borrarbusqueda.Enabled = True
                chk_historicos.Enabled = True
                pic.Visible = False
            End If

            desde = 1
            hasta = itXPage
            pagina = 1
            tabla = e.Node.Name
            txt_search.Text = ""
            If chk_historicos.Checked Then chk_historicos.Checked = False
            actualizarlsv()

            cmd_first.Enabled = True
            cmd_prev.Enabled = True
            cmd_next.Enabled = True
            cmd_last.Enabled = True
            txt_nPage.Enabled = True
            cmd_go.Enabled = True
        End If
    End Sub

    Private Sub actualizarlsv()
        Dim sqlstr As String = ""
        'chk_stock0.Visible = False

        If txt_search.Text <> "" Then
            Dim txtsearch As String = Microsoft.VisualBasic.Replace(txt_search.Text, " ", "%")
            sqlstr = sqlstrbuscar(txtsearch)
        Else
            Select Case tabla
                Case Is = "root"
                    cmd_add.Enabled = False
                    lsview.Visible = False
                    txt_search.Enabled = False
                    lbl_borrarbusqueda.Enabled = False
                    chk_historicos.Enabled = False
                    pic.Visible = True
                Case Is = "archivos"
                    lsview.Clear()
                Case Is = "condiciones"
                    sqlstr = "SELECT c.id_condicion AS 'ID', c.condicion AS 'Condición', c.vencimiento AS 'Vencimiento (días)', " +
                                "c.recargo AS 'Recargo', t.tarjeta AS 'Tarjeta', CASE WHEN c.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                                "FROM condiciones AS c " &
                                "LEFT JOIN tarjetas AS t ON c.id_tarjeta = t.id_tarjeta " &
                                "WHERE c.activo = '" + activo.ToString + "' " &
                                "ORDER BY c.condicion ASC"
                Case Is = "descuentos"
                    sqlstr = "SELECT id_descuento AS 'ID', descripcion AS 'Descripción', descuento AS 'Descuento', CASE WHEN activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                                "FROM descuentos " &
                                "WHERE activo = '" + activo.ToString &
                                "' ORDER BY descripcion ASC"
                Case Is = "clientes"
                    sqlstr = "SELECT c.id_cliente AS 'ID', c.dni AS 'DNI', c.nombre AS 'Nombre', c.apellido AS 'Apellido', " &
                            "c.telefono AS 'Teléfono', c.email AS 'Email', c.direccion AS 'Dirección', d.descripcion AS 'Descuento', CASE WHEN c.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                                    "FROM clientes AS c " &
                                    "INNER JOIN descuentos AS d ON c.id_descuento = d.id_descuento " &
                                    "WHERE c.activo = '" + activo.ToString + "' ORDER BY c.nombre, c.apellido ASC"
                Case Is = "vendedores"
                    sqlstr = "SELECT id_vendedor AS 'ID', nombre AS 'Nombre', porcentaje AS 'Porcentaje', CASE WHEN activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                        "FROM vendedores " &
                        "WHERE activo = '" + activo.ToString + "' " &
                        "ORDER BY nombre ASC"
                Case Is = "mecanicos"
                    sqlstr = "SELECT id_mecanico AS 'ID', nombre AS 'Nombre', porcentaje AS 'Porcentaje', CASE WHEN activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                        "FROM mecanicos " &
                        "WHERE activo = '" + activo.ToString + "' " &
                        "ORDER BY nombre ASC"
                Case Is = "proveedores"
                    sqlstr = "SELECT id_proveedor AS 'ID', dni AS 'DNI', nombre AS 'Nombre', telefono AS 'Teléfono', email AS 'Email', " &
                                    "direccion AS 'Dirección', vendedor AS 'Vendedor', CASE WHEN activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo'" &
                                    "FROM proveedores " &
                                    "WHERE activo = '" + activo.ToString + "' ORDER BY nombre ASC"
                Case Is = "comprobantes"
                    sqlstr = "SELECT c.id_comprobante AS 'ID', c.comprobante AS 'Comprobante', tc.comprobante_AFIP AS 'Tipo de Comprobante', c.numeroComprobante AS 'Número de comprobante', c.puntoVenta AS 'Punto de venta', " &
                                    "CASE WHEN c.esFiscal = '1' THEN 'Fiscal' WHEN c.esElectronica = '1' THEN 'Eletrónico' ELSE 'Manual' END AS 'Formato de comprobante', c.testing AS 'Comprobante de testeo', CASE WHEN c.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo', " &
                                    "c.maxItems AS 'Máximo de items', c.cantCopy AS 'Copias' " &
                                    "FROM comprobantes AS c " &
                                    "INNER JOIN tipos_comprobantes AS tc ON c.id_tipoComprobante = tc.id_tipoComprobante " &
                                    "WHERE c.activo = '" + activo.ToString + "' ORDER BY c.comprobante ASC"
                Case Is = "marcas_autos"
                    sqlstr = "SELECT id_marca AS 'ID', marca AS 'Marca', CASE WHEN activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' FROM marcas_autos WHERE activo = '" + activo.ToString + "' ORDER BY marca ASC"
                Case Is = "modelosa"
                    sqlstr = "SELECT m.id_modelo AS 'ID', m.modelo AS 'Modelo', ma.marca AS 'Marca', " &
                                    "CASE WHEN m.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                                    "FROM modelosa AS m " &
                                    "LEFT JOIN marcas_autos AS ma ON m.id_marca_modelo = ma.id_marca " &
                                    "WHERE m.activo = '" + activo.ToString + "' " &
                                    "ORDER BY m.modelo, ma.marca ASC"
                Case Is = "autos"
                    sqlstr = "SELECT a.id_auto AS 'ID', a.patente AS 'Patente', ma.marca  AS 'Marca', mo.modelo AS 'Modelo', anio AS 'Año', c.nombre + ' ' + c.apellido AS 'Cliente', " &
                                    "c.telefono AS 'Teléfono', CASE WHEN a.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo', CASE WHEN a.deudor = 1 THEN 'Si' ELSE 'No' END AS 'Deudor' " &
                                    "FROM autos AS a " &
                                    "LEFT JOIN clientes AS c ON a.id_cliente = c.id_cliente " &
                                    "LEFT JOIN modelosa AS mo ON a.id_modelo = mo.id_modelo " &
                                    "LEFT JOIN marcas_autos AS ma ON mo.id_marca_modelo = ma.id_marca " &
                                    "WHERE a.activo = '" + activo.ToString + "' " &
                                    "ORDER BY c.nombre, c.apellido, ma.marca, mo.modelo, a.patente ASC"
                Case Is = "marcas_items"
                    sqlstr = "SELECT id_marca AS 'ID', marca as 'Marca', CASE WHEN activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                                    "FROM marcas_items " &
                                    "WHERE activo = '" + activo.ToString + "' ORDER BY marca ASC"
                Case Is = "tipos_items"
                    sqlstr = "SELECT id_tipo AS 'ID', tipo as 'Categoría', CASE WHEN activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                                    "FROM tipos_items " &
                                    "WHERE activo = '" + activo.ToString + "' ORDER BY tipo ASC"
                Case Is = "roscas"
                    sqlstr = "SELECT id_rosca AS 'ID', rosca AS 'Rosca', CASE WHEN activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' FROM roscas where activo = '" + activo.ToString + "' ORDER BY rosca ASC"
                Case Is = "items"
                    sqlstr = "SELECT i.id_item AS 'ID', i.item AS 'Item', m.marca AS 'Marca', i.descript AS 'Descripción', i.cantidad AS 'Cantidad', FORMAT(i.precio_lista, 'C', 'es-ar') AS 'Precio de lista', " &
                                    "i.markup AS 'Markup', i.descuento AS 'Descuento', ti.descripcion AS 'I.V.A.', FORMAT(i.costo, 'C', 'es-ar') AS 'Costo', t.tipo AS 'Categoría', " &
                                    "i.wega AS 'WEGA', i.fram AS 'FRAM', i.mann AS 'MANN', i.oem AS 'OEM', r.rosca AS 'Rosca', p.nombre AS 'Proveedor', " &
                                    "CASE WHEN i.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo', CASE WHEN i.checkStock = 1 THEN 'Si' ELSE 'No' END AS 'Controla Stock', " &
                                    "i.stockRepo AS 'Stock de reposición', CASE WHEN i.oferta = 1 THEN 'Si' ELSE 'No' END AS 'Artículo de oferta', i.EAN AS 'EAN',  " &
                                    "CASE WHEN i.ultima_modificacion IS NULL THEN 'N/A' ELSE CAST(i.ultima_modificacion AS VARCHAR(50)) END AS 'Ult. Mod.' " &
                                    "FROM items AS i " &
                                    "LEFT JOIN tipos_items AS t ON i.id_tipo = t.id_tipo " &
                                    "LEFT JOIN marcas_items AS m ON i.id_marca = m.id_marca " &
                                    "LEFT JOIN roscas AS r ON i.id_rosca = r.id_rosca " &
                                    "LEFT JOIN proveedores AS p ON i.id_proveedor = p.id_proveedor " &
                                    "LEFT JOIN iva AS ti ON i.id_iva = ti.id_iva " &
                                    "WHERE i.activo = '" + activo.ToString + "' " &
                                    "AND i.checkStock = 1 AND i.cantidad <= (i.stockRepo * 2) " &
                                    "ORDER BY i.item ASC"
                Case Is = "items_full"
                    chk_stock0.Visible = True
                    sqlstr = "SELECT i.id_item AS 'ID', i.item AS 'Item', m.marca AS 'Marca', i.descript AS 'Descripción', i.cantidad AS 'Cantidad', FORMAT(i.precio_lista, 'C', 'es-ar') AS 'Precio de lista', " &
                                    "i.markup AS 'Markup', i.descuento AS 'Descuento', ti.descripcion AS 'I.V.A.', FORMAT(i.costo, 'C', 'es-ar') AS 'Costo', t.tipo AS 'Categoría', " &
                                    "i.wega AS 'WEGA', i.fram AS 'FRAM', i.mann AS 'MANN', i.oem AS 'OEM', r.rosca AS 'Rosca', p.nombre AS 'Proveedor', CASE WHEN i.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo', " &
                                    "CASE WHEN i.checkStock = 1 THEN 'Si' ELSE 'No' END AS 'Controla Stock', i.stockRepo AS 'Stock de reposición', CASE WHEN i.oferta = 1 THEN 'Si' ELSE 'No' END AS 'Artículo de oferta', i.EAN AS 'EAN', " &
                                    "CASE WHEN i.ultima_modificacion IS NULL THEN 'N/A' ELSE CAST(i.ultima_modificacion AS VARCHAR(50)) END AS 'Ult. Mod.' " &
                                    "FROM items AS i " &
                                    "LEFT JOIN tipos_items AS t ON i.id_tipo = t.id_tipo " &
                                    "LEFT JOIN marcas_items AS m ON i.id_marca = m.id_marca " &
                                    "LEFT JOIN roscas AS r ON i.id_rosca = r.id_rosca " &
                                    "LEFT JOIN proveedores AS p ON i.id_proveedor = p.id_proveedor " &
                                    "LEFT JOIN iva AS ti ON i.id_iva = ti.id_iva " &
                                    "WHERE i.activo = '" + activo.ToString + "' "
                    If Not stock0 Then sqlstr += "AND i.cantidad > 0 "
                    sqlstr += "ORDER BY i.item ASC"
                Case Is = "tipos_casos"
                    sqlstr = "SELECT tc.id_tipo AS 'ID', tc.tipo AS 'Tipo', COUNT(p.id_tipo) AS 'Contador de casos', CASE WHEN tc.activo =1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                                    "FROM tipos_casos AS tc " &
                                    "LEFT JOIN pedidos AS p ON tc.id_tipo = p.id_tipo " &
                                    "WHERE tc.activo = '" + activo.ToString + "' " &
                                    "GROUP BY tc.id_tipo, tc.tipo, tc.activo, p.id_tipo " &
                                    "ORDER BY tc.tipo ASC"
                Case Is = "grupoTarjetas"
                    sqlstr = "SELECT g.id_grupo AS 'ID', g.grupo AS 'Grupo de tarjetas' " +
                            "FROM grupo_tarjetas AS g " +
                            "ORDER BY g.grupo ASC"
                Case Is = "tarjetas"
                    sqlstr = "SELECT t.id_tarjeta AS 'ID', t.tarjeta AS 'Nombre', t.recargo AS 'Recargo', t.cuotas AS 'Cuotas', " +
                                "g.grupo AS 'Grupo de tarjetas', CASE WHEN t.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " +
                                "FROM tarjetas AS t " +
                                "LEFT JOIN grupo_tarjetas AS g ON t.id_grupo = g.id_grupo " +
                                "WHERE t.activo = '" + activo.ToString + "' " +
                                "ORDER BY t.tarjeta ASC"
                Case Is = "caja"
                    sqlstr = "SELECT c.id_caja AS 'ID', c.nombre AS 'Caja', c.esCC AS 'Es cuenta corriente', CASE WHEN c.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                            "FROM cajas AS c " &
                            "WHERE c.activo = '" + activo.ToString + "' " &
                            "ORDER BY c.id_caja ASC"
                Case Is = "ccClientes"
                    ccClientes.ShowDialog()
                Case Is = "archivoconsultas"
                    sqlstr = "SELECT c.id_consulta AS 'ID', c.nombre AS 'Nombre', c.consulta AS 'Consulta SQL', CASE WHEN c.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                             "FROM consultas_personalizadas AS c " &
                             "WHERE c.activo = '" + activo.ToString + "' " &
                             "ORDER BY c.id_consulta ASC"
                Case Is = "registros_stock"
                    If activo Then
                        sqlstr = "SELECT rs.id_registro AS 'ID', CAST(rs.fecha AS VARCHAR(50)) AS 'Fecha FC', CAST(rs.fecha_ingreso AS VARCHAR(50)) AS 'Fecha ingreso', i.item AS 'Item', i.EAN AS 'EAN', i.descript AS 'Descripción', " &
                                    "rs.cantidad AS 'Cantidad', rs.cantidad_anterior AS 'Cantidad anterior', FORMAT(rs.precio_lista, 'C', 'es-ar') AS 'Precio', FORMAT(rs.precio_lista_anterior, 'C', 'es-ar') AS 'Precio anterior', rs.markup AS 'Markup', rs.descuento AS 'Descuento', " &
                                    "ti.descripcion AS 'I.V.A.', rs.markup_anterior AS 'Markup anterior', rs.descuento_anterior AS 'Descuento anterior', ti.descripcion AS 'I.V.A. anterior', FORMAT(rs.costo, 'C', 'es-ar') AS 'Costo',  " &
                                    "FORMAT(rs.costo_anterior, 'C', 'es-ar') AS 'Costo anterior', p.nombre AS 'Proveedor', rs.factura AS 'Factura', rs.nota AS 'Notas', CASE WHEN rs.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                                    "FROM registros_stock AS rs " &
                                    "LEFT JOIN items AS i ON rs.id_item = i.id_item " &
                                    "LEFT JOIN proveedores AS p ON rs.id_proveedor = p.id_proveedor " &
                                    "LEFT JOIN iva AS ti ON rs.id_iva = ti.id_iva " &
                                    "WHERE rs.activo = '1' AND rs.fecha_ingreso = CONVERT (date, SYSDATETIME()) " &
                                    "ORDER BY rs.id_registro ASC"
                    Else
                        sqlstr = "SELECT rs.id_registro AS 'ID', CAST(rs.fecha AS VARCHAR(50)) AS 'Fecha FC', CAST(rs.fecha_ingreso AS VARCHAR(50)) AS 'Fecha ingreso', i.item AS 'Item', i.EAN AS 'EAN', i.descript AS 'Descripción', " &
                                    "rs.cantidad AS 'Cantidad', rs.cantidad_anterior AS 'Cantidad anterior', rs.precio_lista AS 'Precio', rs.precio_lista_anterior AS 'Precio anterior', rs.markup AS 'Markup', " &
                                    "rs.markup_anterior AS 'Markup anterior', rs.descuento AS 'Descuento', rs.descuento_anterior AS 'Descuento anterior', ti.descripcion AS 'I.V.A.', ti.descripcion AS 'I.V.A. anterior', rs.costo AS 'Costo', " &
                                    "rs.costo_anterior AS 'Costo anterior', p.nombre AS 'Proveedor', rs.factura AS 'Factura', rs.nota AS 'Notas', CASE WHEN rs.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                                    "FROM registros_stock AS rs " &
                                    "LEFT JOIN items AS i ON rs.id_item = i.id_item " &
                                    "LEFT JOIN proveedores AS p ON rs.id_proveedor = p.id_proveedor " &
                                    "LEFT JOIN iva AS ti ON rs.id_iva = ti.id_iva " &
                                    "WHERE rs.activo = '0' " &
                                    "ORDER BY rs.id_registro DESC"
                    End If
                Case Is = "nuevopedido"
                    add_pedido.ShowDialog()
                Case Is = "nuevocaso"
                    add_caso.ShowDialog()
                Case Is = "pedidos"
                    If activo Then
                        sqlstr = "SELECT p.id_pedido AS 'ID', CAST(p.fecha AS VARCHAR(50)) AS 'Fecha', c.nombre + ' ' +  c.apellido AS 'Cliente', c.telefono AS 'Teléfono', cn.condicion AS 'Condición de venta', " &
                                           "FORMAT(p.total, 'C', 'es-ar') AS 'Total', FORMAT(p.total - p.montoTarjeta, 'C', 'es-ar') AS 'Monto contado', FORMAT(p.montoTarjeta, 'C', 'es-ar') AS 'Monto tarjeta', " &
                                           "ca.nombre AS 'Caja', d.descripcion AS 'Descuento', v.nombre AS 'Vendedor', CASE WHEN p.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                                           "FROM pedidos AS p " &
                                           "INNER JOIN clientes AS c ON p.id_cliente = c.id_cliente " &
                                           "INNER JOIN condiciones AS cn ON p.id_condicion = cn.id_condicion " &
                                           "INNER JOIN descuentos AS d ON p.id_descuento = d.id_descuento " &
                                           "INNER JOIN cajas AS ca ON p.id_caja = ca.id_caja " &
                                           "INNER JOIN vendedores AS v ON p.id_vendedor = v.id_vendedor " &
                                           "WHERE p.cerrado = '0' AND p.activo = '1' AND p.es_caso = '0' " &
                                           "ORDER BY p.id_pedido ASC"
                    Else
                        sqlstr = "SELECT p.id_pedido AS 'ID', CAST(P.fecha AS VARCHAR(50)) AS 'Fecha', CAST(P.fecha_cierre AS VARCHAR(50)) AS 'Fecha de cierre', c.nombre + ' ' +  c.apellido AS 'Cliente', c.telefono AS 'Teléfono', cn.condicion AS 'Condición de venta', " &
                                     "FORMAT(p.total, 'C', 'es-ar') AS 'Total', FORMAT(p.total - p.montoTarjeta, 'C', 'es-ar') AS 'Monto contado', FORMAT(p.montoTarjeta, 'C', 'es-ar') AS 'Monto tarjeta', " &
                                     "ca.nombre AS 'Caja', d.descripcion AS 'Descuento', v.nombre AS 'Vendedor', p.activo AS 'Activo' " &
                                     "FROM pedidos AS p " &
                                     "INNER JOIN clientes AS c ON p.id_cliente = c.id_cliente " &
                                     "INNER JOIN condiciones AS cn ON p.id_condicion = cn.id_condicion " &
                                     "INNER JOIN descuentos AS d ON p.id_descuento = d.id_descuento " &
                                     "INNER JOIN cajas AS ca ON p.id_caja = ca.id_caja " &
                                     "INNER JOIN vendedores AS v ON p.id_vendedor = v.id_vendedor " &
                                     "WHERE p.cerrado = '1' AND p.activo = '0' AND p.es_caso = '0' " &
                                     "ORDER BY p.id_pedido DESC"
                    End If
                Case Is = "pedidos_hoy"
                    sqlstr = "SELECT p.id_pedido AS 'ID', CAST(p.fecha AS VARCHAR(50)) AS 'Fecha', CAST(P.fecha_cierre AS VARCHAR(50)) AS 'Fecha de cierre', c.nombre + ' ' +  c.apellido AS 'Cliente', c.telefono AS 'Teléfono', cn.condicion AS 'Condición de venta', " &
                               "FORMAT(p.total, 'C', 'es-ar') AS 'Total', FORMAT(p.total - p.montoTarjeta, 'C', 'es-ar') AS 'Monto contado', FORMAT(p.montoTarjeta, 'C', 'es-ar') AS 'Monto tarjeta', " &
                               "ca.nombre AS 'Caja', d.descripcion AS 'Descuento', v.nombre AS 'Vendedor', CASE WHEN p.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                               "FROM pedidos AS p " &
                               "INNER JOIN clientes AS c ON p.id_cliente = c.id_cliente " &
                               "INNER JOIN condiciones AS cn ON p.id_condicion = cn.id_condicion " &
                               "INNER JOIN descuentos AS d ON p.id_descuento = d.id_descuento " &
                               "INNER JOIN cajas AS ca ON p.id_caja = ca.id_caja " &
                               "INNER JOIN vendedores AS v ON p.id_vendedor = v.id_vendedor " &
                               "WHERE p.es_caso = '0' AND CONVERT(VARCHAR(10), p.fecha, 112) = CONVERT(VARCHAR(10), GETDATE(), 112) " &
                               "ORDER BY p.id_pedido ASC"

                Case Is = "casos"
                    If activo Then
                        sqlstr = "SELECT c.id_pedido AS 'ID', CAST(c.fecha AS VARCHAR(50)) AS 'Fecha', a.patente AS 'Patente', ma.modelo AS 'Modelo', cn.condicion AS 'Condición de venta', " +
                                    "FORMAT(c.total, 'C', 'es-ar') AS 'Total', FORMAT(c.total - c.montoTarjeta, 'C', 'es-ar') AS 'Monto contado', FORMAT(c.montoTarjeta, 'C', 'es-ar') AS 'Monto tarjeta', " &
                                    "tc.tipo AS 'Tipo', c.km AS 'Kilometraje', c.proximocambio AS 'Próximo cambio', cli.nombre + ' ' + cli.apellido AS 'Cliente', cli.telefono AS 'Teléfono', " &
                                    "d.descripcion AS 'Descuento', ca.nombre AS 'Caja', CASE WHEN a.deudor = 1 THEN 'Si' ELSE 'No' END AS 'Deudor', " &
                                    "v.nombre AS 'Vendedor', m.nombre AS 'Mecánico', sep.estado AS 'Estado caso', CASE WHEN c.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                                    "FROM pedidos AS c " &
                                    "INNER JOIN autos AS a ON c.id_auto = a.id_auto " &
                                    "INNER JOIN modelosa AS ma ON a.id_modelo = ma.id_modelo " &
                                    "INNER JOIN clientes AS cli ON a.id_cliente = cli.id_cliente " &
                                    "INNER JOIN tipos_casos AS tc ON c.id_tipo = tc.id_tipo " &
                                    "INNER JOIN condiciones AS cn ON c.id_condicion = cn.id_condicion " &
                                    "INNER JOIN descuentos AS d ON c.id_descuento = d.id_descuento " &
                                    "INNER JOIN cajas AS ca ON c.id_caja = ca.id_caja " &
                                    "INNER JOIN vendedores AS v ON c.id_vendedor = v.id_vendedor " &
                                    "INNER JOIN mecanicos AS m ON c.id_mecanico = m.id_mecanico " &
                                    "INNER JOIN sysEstado_pedidos AS sep ON c.id_PedidoStatus = sep.id_PedidoStatus " &
                                    "WHERE c.cerrado = '0' AND c.activo = '1' AND c.es_caso = '1' " &
                                    "ORDER BY c.id_pedido ASC"
                    Else
                        sqlstr = "SELECT c.id_pedido AS 'ID', CAST(c.fecha AS VARCHAR(50)) AS 'Fecha', CAST(c.fecha_cierre AS VARCHAR(50)) AS 'Fecha de cierre', a.patente AS 'Patente', ma.modelo AS 'Modelo', cn.condicion AS 'Condición de venta', " +
                                    "FORMAT(c.total, 'C', 'es-ar') AS 'Total', FORMAT(c.total - c.montoTarjeta, 'C', 'es-ar') AS 'Monto contado', FORMAT(c.montoTarjeta, 'C', 'es-ar') AS 'Monto tarjeta', " &
                                    "tc.tipo AS 'Tipo', c.km AS 'Kilometraje', c.proximocambio AS 'Próximo cambio', cli.nombre + ' ' + cli.apellido AS 'Cliente', cli.telefono AS 'Teléfono', " &
                                    "d.descripcion AS 'Descuento', ca.nombre AS 'Caja', CASE WHEN a.deudor = 1 THEN 'Si' ELSE 'No' END AS 'Deudor', " &
                                    "v.nombre AS 'Vendedor', m.nombre AS 'Mecánico', sep.estado AS 'Estado caso', CASE WHEN c.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                                    "FROM pedidos AS c " &
                                    "INNER JOIN autos AS a ON c.id_auto = a.id_auto " &
                                    "INNER JOIN modelosa AS ma ON a.id_modelo = ma.id_modelo " &
                                    "INNER JOIN clientes AS cli ON a.id_cliente = cli.id_cliente " &
                                    "INNER JOIN tipos_casos AS tc ON c.id_tipo = tc.id_tipo " &
                                    "INNER JOIN condiciones AS cn ON c.id_condicion = cn.id_condicion " &
                                    "INNER JOIN descuentos AS d ON c.id_descuento = d.id_descuento " &
                                    "INNER JOIN cajas AS ca ON c.id_caja = ca.id_caja " &
                                    "INNER JOIN vendedores AS v ON c.id_vendedor = v.id_vendedor " &
                                    "INNER JOIN mecanicos AS m ON c.id_mecanico = m.id_mecanico " &
                                    "INNER JOIN sysEstado_pedidos AS sep ON c.id_PedidoStatus = sep.id_PedidoStatus " &
                                    "WHERE c.cerrado = '1' AND c.activo = '0' AND c.es_caso = '1' " &
                                    "ORDER BY c.id_pedido DESC"
                    End If
                Case Is = "casos_hoy"
                    sqlstr = "SELECT c.id_pedido AS 'ID', CAST(c.fecha AS VARCHAR(50)) AS 'Fecha', a.patente AS 'Patente', ma.modelo AS 'Modelo', cn.condicion AS 'Condición de venta', " +
                                    "FORMAT(c.total, 'C', 'es-ar') AS 'Total', FORMAT(c.total - c.montoTarjeta, 'C', 'es-ar') AS 'Monto contado', FORMAT(c.montoTarjeta, 'C', 'es-ar') AS 'Monto tarjeta', " &
                                    "tc.tipo AS 'Tipo', c.km AS 'Kilometraje', c.proximocambio AS 'Próximo cambio', cli.nombre + ' ' + cli.apellido AS 'Cliente', cli.telefono AS 'Teléfono', " &
                                    "d.descripcion AS 'Descuento', ca.nombre AS 'Caja', CASE WHEN a.deudor = 1 THEN 'Si' ELSE 'No' END AS 'Deudor', " &
                                    "v.nombre As 'Vendedor', m.nombre AS 'Mecánico', sep.estado AS 'Estado caso', Case WHEN c.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " &
                                    "FROM pedidos AS c " &
                                    "INNER JOIN autos AS a ON c.id_auto = a.id_auto " &
                                    "INNER JOIN modelosa AS ma ON a.id_modelo = ma.id_modelo " &
                                    "INNER JOIN clientes AS cli ON a.id_cliente = cli.id_cliente " &
                                    "INNER JOIN tipos_casos AS tc ON c.id_tipo = tc.id_tipo " &
                                    "INNER JOIN condiciones AS cn ON c.id_condicion = cn.id_condicion " &
                                    "INNER JOIN descuentos AS d ON c.id_descuento = d.id_descuento " &
                                    "INNER JOIN cajas AS ca ON c.id_caja = ca.id_caja " &
                                    "INNER JOIN vendedores AS v ON c.id_vendedor = v.id_vendedor " &
                                    "INNER JOIN mecanicos AS m ON c.id_mecanico = m.id_mecanico " &
                                    "INNER JOIN sysEstado_pedidos AS sep ON c.id_PedidoStatus = sep.id_PedidoStatus " &
                                    "WHERE c.es_caso = '1' " &
                                    "AND CONVERT(VARCHAR(10), c.fecha, 112) = CONVERT(VARCHAR(10), GETDATE(), 112) " &
                                    "ORDER BY c.id_pedido ASC"
                Case Is = "presupuestos"
                    sqlstr = "SELECT p.id_presupuesto AS 'ID', CAST(p.fecha AS VARCHAR(50)) AS 'Fecha', c.nombre + ' ' +  c.apellido AS 'Cliente', " &
                                   "c.telefono AS 'Teléfono', cn.condicion AS 'Condición de venta', " &
                                   "FORMAT(p.total, 'C', 'es-ar') AS 'Total', FORMAT(p.total - p.montoTarjeta, 'C', 'es-ar') AS 'Monto contado', FORMAT(p.montoTarjeta, 'C', 'es-ar') AS 'Monto tarjeta', " &
                                   "d.descripcion AS 'Descuento' " &
                                   "FROM presupuestos AS p " &
                                   "INNER JOIN clientes AS c ON p.id_cliente = c.id_cliente " &
                                   "INNER JOIN condiciones AS cn ON p.id_condicion = cn.id_condicion " &
                                   "INNER JOIN descuentos AS d ON p.id_descuento = d.id_descuento " &
                                   "WHERE CONVERT(VARCHAR(10), p.fecha, 112) = CONVERT(VARCHAR(10), GETDATE(), 112) " &
                                   "ORDER BY p.id_presupuesto ASC"
                Case Is = "fe_pendiente"
                    sqlstr = "SELECT p.id_pedido AS 'Pedido Nº', CAST(p.fecha AS VARCHAR(50)) AS 'Fecha', c.nombre + ' ' + c.apellido AS 'Cliente', d.descripcion AS 'Descuento', " +
                                "CASE WHEN p.es_caso = 1 THEN 'Si' ELSE 'No' END AS '¿Es un caso?', " +
                                "FORMAT(p.total, 'C', 'es-ar') AS 'Total' " +
                                "FROM pedidos AS p " +
                                "INNER JOIN clientes AS c ON p.id_cliente = c.id_cliente " +
                                "INNER JOIN descuentos AS d ON p.id_descuento = d.id_descuento " +
                                "WHERE p.id_pedido NOT IN (SELECT id_pedido FROM fe) " +
                                "AND YEAR(p.fecha) >= 2018 AND p.id_cliente NOT IN (27, 21, 26684, 28830, 26667) AND c.dni <> '' " +
                                "ORDER BY id_pedido DESC"
                Case Is = "fe"
                    sqlstr = "SELECT fe.id_pedido AS 'Pedido Nº', CAST(fe.fecha_emision AS VARCHAR(50)) AS 'Fecha de emisión', c.nombre + ' ' + c.apellido AS 'Cliente', d.descripcion AS 'Descuento', cmp.comprobante AS 'Comprobante', " +
                                "CONCAT('Nº  ', REPLICATE('0', 4 - LEN(fe.puntoVenta)), fe.puntoVenta, '-', REPLICATE('0', 8 - LEN(fe.numeroComprobante)), fe.numeroComprobante) AS 'Nº de comprobante', " +
                                "FORMAT(fe.total, 'C', 'es-ar') AS 'Total', " +
                                "fe.cae AS 'CAE' " +
                                "FROM fe AS fe " +
                                "INNER JOIN pedidos as p ON fe.id_pedido = p.id_pedido " +
                                "INNER JOIN clientes AS c ON p.id_cliente = c.id_cliente " +
                                "INNER JOIN comprobantes AS cmp ON fe.id_comprobante = cmp.id_comprobante " +
                                "INNER JOIN descuentos AS d ON p.id_descuento = d.id_descuento " &
                                "WHERE cmp.testing = 0 " +
                                "ORDER BY fe.id_fe DESC"
                                '"ORDER BY fe.fecha_emision DESC"
                Case Is = "consulta_caja"
                    consulta_caja.ShowDialog()
                    Exit Sub
                Case Is = "cpersonalizadas"
                    grilla_resultados.ShowDialog()
                    Exit Sub
                Case Is = "ultimoComprobante"
                    frm_ultimo_comprobante.ShowDialog()
                    Exit Sub
                Case Is = "info_fc"
                    info_fc.ShowDialog()
                    Exit Sub
                Case Is = "exportSiap"
                    frm_exportaSiap.ShowDialog()
                Case Is = "permisos"
                    sqlstr = "SELECT p.id_permiso AS 'ID', p.nombre AS 'Permiso' " +
                                "FROM permisos AS p " +
                                "ORDER BY p.nombre ASC"
                Case Is = "perfiles"
                    sqlstr = "SELECT p.id_perfil AS 'ID', p.nombre AS 'Perfil', CASE WHEN p.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " +
                                "FROM perfiles AS p " +
                                "ORDER BY p.nombre ASC"
                Case Is = "usuarios"
                    sqlstr = "SELECT u.id_usuario AS 'ID', u.usuario AS 'Usuario', u.nombre AS 'Nombre', CASE WHEN u.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " +
                                "FROM usuarios AS u " +
                                "ORDER BY u.nombre ASC"
                Case Is = "configuracion"
                    config.ShowDialog()
                    Exit Sub
                Case Is = "acercade"
                    frmacercade.ShowDialog()
                    Exit Sub
            End Select
        End If

        If sqlstr <> "" Then
            If tabla = "clientes" Then
                cargar_datagrid(dgv_main, sqlstr, basedb)
                dgv_main.Visible = True
                lsview.Visible = False
            Else
                Cargar_listview(lsview, sqlstr, basedb, desde, hasta, nRegs, tPaginas, pagina, txt_nPage, orderCol)
                dgv_main.Visible = False
                lsview.Visible = True
            End If
            'If tabla = "autos" Then
            ' autosConDeuda(lsview, Color.Red)
            'ElseIf tabla = "items" Then
            'resaltarcolumna(lsview, lightItemCol, Color.Red)
            'pintaStockItems(lsview, Color.Orange)
            'ElseIf tabla = "items_full" Then
            'resaltarcolumna(lsview, lightItemCol, Color.Red)
            If tabla = "archivoConsultas" Then
                lsview.Columns(0).Width = 50
                'ElseIf tabla = "registros_stock" Then
                ' resaltarcolumna(lsview, lightRegStock, Color.Red)
                'ElseIf tabla = "pedidos" Then
                'If activo Then
                'resaltarcolumna(lsview, 5, Color.Red)
                'Else
                '    resaltarcolumna(lsview, 6, Color.Red)
                'End If
                'ElseIf tabla = "pedidos_hoy" Then
                'resaltarcolumna(lsview, 6, Color.Red)
                'resaltarPedidosInactivos(lsview, Color.Red)
                'ElseIf tabla = "casos" Or tabla = "casos_hoy" Then
                'If activo Then
                '    resaltarcolumna(lsview, 5, Color.Red, 1)
                'Else
                '    resaltarcolumna(lsview, 6, Color.Red, 1)
                'End If
                'casosConDeuda(lsview, Color.Red)
                'lsview.Columns(13).Width = 0
                'lsview.Columns(14).Width = 0
                ' If tabla = "casos_hoy" Then resaltarCasosInactivos(lsview, Color.Red)
            End If
            lsview.Visible = True
        End If
    End Sub

    Private Sub txt_search_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_search.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            Dim txtsearch As String = Microsoft.VisualBasic.Replace(txt_search.Text, " ", "%")
            Dim sqlstr As String = sqlstrbuscar(txtsearch)

            'Cargar_listview(lsview, sqlstr, basedb)
            desde = 1
            pagina = 1
            Cargar_listview(lsview, sqlstr, basedb, desde, hasta, nRegs, tPaginas, pagina, txt_nPage, orderCol)
            'If tabla = "items" Then resaltarcolumna(lsview, lightItemCol, Color.Red)
            'If tabla = "autos" Then
            '    autosConDeuda(lsview, Color.Red)
            'ElseIf tabla = "items" Then
            '    resaltarcolumna(lsview, lightItemCol, Color.Red)
            '    pintaStockItems(lsview, Color.Orange)
            'ElseIf tabla = "items_full" Then
            '    resaltarcolumna(lsview, lightItemCol, Color.Red)
            'ElseIf tabla = "registros_stock" Then
            '    resaltarcolumna(lsview, lightRegStock, Color.Red)
            'ElseIf tabla = "pedidos" Or tabla = "pedidos_hoy" Then
            '    resaltarcolumna(lsview, 4, Color.Red)
            '    If tabla = "pedidos_hoy" Then resaltarPedidosInactivos(lsview, Color.Red)

            'ElseIf tabla = "casos" Or tabla = "casos_hoy" Then
            '    resaltarcolumna(lsview, 5, Color.Red, 1)
            '    casosConDeuda(lsview, Color.Red)
            'End If
        End If
    End Sub

    Private Sub cmd_add_Click(sender As Object, e As EventArgs) Handles cmd_add.Click
        Select Case tabla
            Case Is = "condiciones"
                add_condicion.ShowDialog()
            Case Is = "descuentos"
                add_descuento.ShowDialog()
            Case Is = "clientes"
                add_cliente.ShowDialog()
            Case Is = "vendedores"
                add_vendedor.ShowDialog()
            Case Is = "mecanicos"
                add_mecanico.ShowDialog()
            Case Is = "marcas_autos"
                add_marcaa.ShowDialog()
            Case Is = "modelosa"
                add_modeloa.ShowDialog()
            Case Is = "autos"
                add_auto.ShowDialog()
            Case Is = "proveedores"
                add_proveedor.ShowDialog()
            Case Is = "tipos_items"
                add_tipoitem.ShowDialog()
            Case Is = "marcas_items"
                add_marcai.ShowDialog()
            Case Is = "roscas"
                add_rosca.ShowDialog()
            Case Is = "items", "items_full"
                add_item.ShowDialog()
            Case Is = "tipos_casos"
                add_tipocaso.ShowDialog()
            Case Is = "grupoTarjetas"
                add_grupoTarjetas.ShowDialog()
            Case Is = "tarjetas"
                add_tarjeta.ShowDialog()
            Case Is = "caja"
                add_caja.ShowDialog()
            Case Is = "archivoconsultas"
                add_consulta.ShowDialog()
            Case Is = "registros_stock"
                tabla = "items_registros_stock"
                add_stock.ShowDialog()
                tabla = "registros_stock"
            Case Is = "casos", "casos_hoy"
                add_caso.ShowDialog()
            Case Is = "presupuestos"
                add_presupuesto.ShowDialog()
            Case Is = "pedidos", "pedidos_hoy"
                add_pedido.ShowDialog()
            Case Is = "comprobantes"
                add_comprobante.ShowDialog()
            Case Is = "permisos"
                add_permiso.ShowDialog()
            Case Is = "perfiles"
                add_perfil.ShowDialog()
            Case Is = "usuarios"
                add_usuario.ShowDialog()
            Case Is = "permisos_a_perfiles"
                add_permisos_perfiles.ShowDialog()
            Case Is = "perfiles_a_usuarios"
                add_usuarios_perfiles.ShowDialog()
        End Select
        actualizarlsv()
    End Sub

    Private Sub lsview_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lsview.ColumnClick
        orderCol = e
        Me.lsview.ListViewItemSorter = New ListViewItemComparer(e.Column)
    End Sub

    Private Sub listview_DoubleClick(sender As Object, e As EventArgs) Handles lsview.DoubleClick
        If borrado = False Then edicion = True

        Dim seleccionado As String
        If dgv_main.Visible Then
            If dgv_main.Rows.Count = 0 Then Exit Sub
            seleccionado = dgv_main.CurrentRow.Cells(0).Value.ToString()
        Else
            If lsview.SelectedIndices.Count = 0 Then Exit Sub
            seleccionado = lsview.SelectedItems.Item(0).Text
        End If
        Select Case tabla
            Case "condiciones"
                edita_condicion = info_condicion(seleccionado)
                add_condicion.ShowDialog()
            Case "descuentos"
                edita_descuento = info_descuento(seleccionado)
                add_descuento.ShowDialog()
            Case "clientes"
                edita_cliente = info_cliente(seleccionado)
                add_cliente.ShowDialog()
            Case "vendedores"
                edita_vendedor = info_vendedor(seleccionado)
                add_vendedor.ShowDialog()
            Case "mecanicos"
                edita_mecanico = info_mecanico(seleccionado)
                add_mecanico.ShowDialog()
            Case "marcas_autos"
                edita_marcaa = info_marcaa(seleccionado)
                add_marcaa.ShowDialog()
            Case "modelosa"
                edita_modeloa = info_modeloa(seleccionado)
                add_modeloa.ShowDialog()
            Case "autos"
                edita_auto = info_auto(seleccionado)
                add_auto.ShowDialog()
            Case "proveedores"
                edita_proveedor = info_proveedor(seleccionado)
                add_proveedor.ShowDialog()
            Case "tipos_items"
                edita_tipoitem = info_tipoitem(seleccionado)
                add_tipoitem.ShowDialog()
            Case "marcas_items"
                edita_marcai = info_marcai(seleccionado)
                add_marcai.ShowDialog()
            Case "roscas"
                edita_rosca = info_rosca(seleccionado)
                add_rosca.ShowDialog()
            Case "items", "items_full"
                edita_item = info_item(CInt(seleccionado))
                add_item.ShowDialog()
            Case "tipos_casos"
                edita_tipocaso = info_tipocaso(seleccionado)
                add_tipocaso.ShowDialog()
            Case "grupoTarjetas"
                edita_grupoTarjetas = info_grupoTarjetas(seleccionado)
                add_grupoTarjetas.ShowDialog()
            Case "tarjetas"
                edita_tarjeta = info_tarjeta(seleccionado)
                add_tarjeta.ShowDialog()
            Case "caja"
                edita_caja = info_caja(seleccionado)
                add_caja.ShowDialog()
            Case "archivoconsultas"
                edita_consulta = info_consulta(seleccionado)
                add_consulta.ShowDialog()
            Case "registros_stock"
                edita_registro_stock = info_registro_stock(seleccionado)
                add_stock.ShowDialog()
            Case "casos", "casos_hoy"
                edita_pedido = info_pedido(seleccionado, True)
                edita_pedido.id_usuario = usuario_logueado.id_usuario
                If terminaCaso = True Then edicion = False
                add_caso.ShowDialog()
                edita_pedido = New pedido
            Case "pedidos", "pedidos_hoy"
                edita_pedido = info_pedido(seleccionado)
                edita_pedido.id_usuario = usuario_logueado.id_usuario
                add_pedido.ShowDialog()
            Case "presupuestos"
                id = seleccionado

                imprimirFactura(id, True, False)
            Case "comprobantes"
                edita_comprobante = info_comprobante(seleccionado)
                add_comprobante.ShowDialog()
            Case "fe_pendiente"
                edita_fe = info_preFe(seleccionado)
                'edita_pedido = info_pedido(seleccionado)
                pre_fe.ShowDialog()
            Case "fe"
                id = seleccionado

                imprimirFactura(id, False, False)
            Case "permisos"
                edita_permiso = info_permiso(seleccionado)
                add_permiso.ShowDialog()
            Case "perfiles"
                edita_perfil = info_perfil(seleccionado)
                add_perfil.ShowDialog()
            Case "usuarios"
                edita_usuario = info_usuario(seleccionado)
                add_usuario.ShowDialog()
            Case "permisos_a_perfiles"
                'edita_permiso_perfil = info_permiso_perfil
                MsgBox("La relación entre un permiso y un perfil no puede editarse", vbExclamation + vbOKOnly, "Dr. Oil")
            Case "perfiles_a_usuarios"
                MsgBox("La relación entre un usuario y un perfil no puede editarse", vbExclamation + vbOKOnly, "Dr. Oil")
        End Select
        If borrado = False Then edicion = False
        actualizarlsv()
    End Sub
    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        listview_DoubleClick(Nothing, Nothing)
        actualizarlsv()
    End Sub

    Private Sub BorrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BorrarToolStripMenuItem.Click
        'borrar el item
        borrado = True
        listview_DoubleClick(Nothing, Nothing)
        borrado = False
        actualizarlsv()
    End Sub

    Private Sub TerminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TerminarToolStripMenuItem.Click
        If MsgBox("¿Está seguro de que desea cerrar el caso?", vbYesNo + vbQuestion, "DrOil") = MsgBoxResult.Yes Then
            Dim seleccionado As String = lsview.SelectedItems.Item(0).Text
            Dim c As New pedido
            c.id_pedido = seleccionado
            cerrarpedido(c)
        End If
        actualizarlsv()
    End Sub

    Private Sub lsview_MouseDown(sender As Object, e As MouseEventArgs) Handles lsview.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            cms_general.Items(0).Visible = True
            cms_general.Items(2).Visible = False
            cms_general.Items(3).Visible = False
            cms_general.Items(4).Visible = False
            cms_general.Items(5).Visible = False
            cms_general.Items(6).Visible = False

            If chk_historicos.Checked = True Then
                If tabla = "casos" Or tabla = "casos_hoy" Then
                    cms_general.Items(0).Text = "Ver caso"
                    'cms_general.Items(5).Visible = True
                    cms_general.Items(6).Visible = True
                ElseIf tabla = "pedidos" Or tabla = "pedidos_hoy" Then
                    cms_general.Items(0).Text = "Ver pedido"
                    'cms_general.Items(5).Visible = True
                ElseIf tabla = "registros_stock" Then
                    cms_general.Items(0).Text = "Ver ingreso"
                End If

                If tabla = "items" Then
                    cms_general.Items(4).Text = "Activar item"
                    cms_general.Items(4).Visible = True
                    'cms_general.Items(5).Visible = False
                    Exit Sub
                Else
                    cms_general.Items(4).Visible = False
                    Exit Sub
                End If
                cms_general.Items(1).Visible = False
                'Exit Sub
            Else
                If tabla = "registros_stock" Then
                    cms_general.Items(0).Text = "Ver ingreso"
                    cms_general.Items(1).Visible = False
                Else
                    cms_general.Items(0).Text = "Editar"
                    cms_general.Items(1).Visible = True
                    If tabla = "items" Then
                        cms_general.Items(4).Text = "Desactivar item"
                        cms_general.Items(4).Visible = True
                        'cms_general.Items(5).Visible = False
                    Else
                        cms_general.Items(4).Visible = False
                    End If
                End If
            End If

            If tabla = "casos" Or tabla = "casos_hoy" Then
                cms_general.Items(2).Visible = True
                cms_general.Items(6).Visible = True
            ElseIf tabla = "pedidos" Or tabla = "pedidos_hoy" Then
                cms_general.Items(3).Visible = True
                'cms_general.Items(4).Visible = True
            ElseIf tabla = "autos" Then
                'cms_general.Items(4).Visible = True
            ElseIf tabla = "fe" Or tabla = "fe_pendiente" Then
                cms_general.Items(0).Visible = False
                cms_general.Items(1).Visible = False
                cms_general.Items(2).Visible = False
            End If
        End If
    End Sub

    Private Sub chk_historicos_CheckedChanged(sender As Object, e As EventArgs) Handles chk_historicos.CheckedChanged
        If activo Then
            activo = False
        Else
            activo = True
        End If
        cmd_add.Enabled = activo
        actualizarlsv()
    End Sub

    Private Sub TerminarPedidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TerminarPedidoToolStripMenuItem.Click
        If MsgBox("¿Está seguro de que desea cerrar el pedido?", vbYesNo + vbQuestion, "DrOil") = MsgBoxResult.Yes Then
            Dim seleccionado As String = lsview.SelectedItems.Item(0).Text
            Dim p As New pedido
            p.id_pedido = seleccionado
            cerrarpedido(p)
        End If
        actualizarlsv()
    End Sub

    Private Sub lbl_borrarbusqueda_DoubleClick1(sender As Object, e As EventArgs) Handles lbl_borrarbusqueda.DoubleClick
        txt_search.Text = ""
        actualizarlsv()
    End Sub

    Private Sub CrearCasoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim seleccionado As String = lsview.SelectedItems.Item(0).Text

        If tabla = "pedidos" Or tabla = "pedidos_hoy" Then
            pedidoACaso = True
        Else
            cargaRapidaDeCaso = True
            edita_pedido.id_tipo = 1
            edita_pedido.id_auto = info_auto(seleccionado).id_auto
            edita_pedido.fecha = Format(DateTime.Now, "dd/MM/yyyy")
            'edita_pedido.fecha = Format(DateTime.Now, "MM/dd/yyyy")
            edita_pedido.id_condicion = 2
            edita_pedido.id_descuento = 2
            add_caso.ShowDialog()
            cargaRapidaDeCaso = False
        End If
        actualizarlsv()
    End Sub

    Private Sub cmd_caso_Click(sender As Object, e As EventArgs) Handles cmd_caso.Click
        add_caso.ShowDialog()
        actualizarlsv()
    End Sub

    Private Sub cmd_pedido_Click(sender As Object, e As EventArgs) Handles cmd_pedido.Click
        add_pedido.ShowDialog()
        'Dim i As Form
        'i = New add_pedido
        'i.Show()
        actualizarlsv()
    End Sub

    Private Sub cmd_addcliente_Click(sender As Object, e As EventArgs) Handles cmd_addcliente.Click
        add_cliente.ShowDialog()
        actualizarlsv()
    End Sub

    Private Sub cmd_addauto_Click(sender As Object, e As EventArgs) Handles cmd_addauto.Click
        add_auto.ShowDialog()
        actualizarlsv()
    End Sub

    'Private Sub pic_search_Click(sender As Object, e As EventArgs) Handles pic_search.Click
    '    Dim sqlstr As String = ""
    '    busquedaAvanzada = True
    '    Select Case tabla
    '        Case Is = "clientes"
    '            add_cliente.ShowDialog()
    '            With edita_cliente
    '                sqlstr = "SELECT id_cliente AS 'ID', dni AS 'DNI', nombre AS 'Nombre', apellido AS 'Apellido', " &
    '                        "telefono AS 'Teléfono', direccion AS 'Dirección', activo AS 'Activo' " &
    '                                "FROM clientes " &
    '                        "WHERE " &
    '                        "activo = '" + .activo.ToString + "'"
    '                If .id_cliente <> 0 Then sqlstr = sqlstr + " AND (id_cliente LIKE '%" + .id_cliente.ToString + "%'"
    '                If .dni <> "" Then sqlstr = sqlstr + " AND dni LIKE '%" + .dni.ToString + "%'"
    '                If .nombre <> "" Then sqlstr = sqlstr + " AND nombre LIKE '%" + .nombre + "%'"
    '                If .apellido <> "" Then sqlstr = sqlstr + " AND apellido LIKE '%" + .apellido + "%'"
    '                If .telefono <> "" Then sqlstr = sqlstr + " AND telefono LIKE '%" + .telefono + "%'"
    '                If .direccion <> "" Then sqlstr = sqlstr + "AND direccion LIKE '%" + .direccion + "%')"
    '                sqlstr = sqlstr + "ORDER BY nombre, apellido ASC"
    '            End With
    '        Case Else
    '            Dim txtsearch As String = Microsoft.VisualBasic.Replace(txt_search.Text, " ", "%")
    '    End Select

    '    'cargar_listview(lsview, sqlstr, basedb)
    '    actualizarlsv()
    '    If tabla = "items" Then resaltarcolumna(lsview, lightItemCol, Color.Red)
    '    busquedaAvanzada = False
    'End Sub

    Private Sub DeshabilitarItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeshabilitarItemToolStripMenuItem.Click
        'Desactivar/activar item

        Dim seleccionado As Integer = lsview.SelectedItems.Item(0).Text
        Dim i As New item
        i = info_item(seleccionado)

        If chk_historicos.Checked Then
            i.activo = True   'Activo
        Else
            i.activo = False 'Desactivo
        End If

        updateitem(i)
        actualizarlsv()
    End Sub

    Private Sub chk_rpt_CheckedChanged(sender As Object, e As EventArgs) Handles chk_rpt.CheckedChanged
        showrpt = chk_rpt.Checked
        updateStartSettings()
    End Sub

    Private Sub MostrarFacturaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MostrarFacturaToolStripMenuItem.Click
        Dim seleccionado As String
        seleccionado = lsview.SelectedItems.Item(0).Text
        'Dim p As New pedido

        'If p.esCaso Then
        '    p = info_pedido(seleccionado, True)
        'Else
        '    p = info_pedido(seleccionado)
        'End If

        'id = p.id_pedido
        imprimirFactura(seleccionado, False, False)
        'CERRADO 
        'frm_rptFC.ShowDialog()
    End Sub

    Private Sub Treev_MouseClick(sender As Object, e As MouseEventArgs) Handles Treev.MouseClick
        cms_importar_exportar.Visible = False
        If (Treev.SelectedNode.Name = "items" Or Treev.SelectedNode.Name = "items_full") And e.Button = Windows.Forms.MouseButtons.Right Then
            Treev.ContextMenuStrip = Me.cms_importar_exportar
        Else
            Treev.ContextMenuStrip = Nothing
        End If
    End Sub

    Private Sub ImportarPreciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportarPreciosToolStripMenuItem.Click
        importar_precios.ShowDialog()
        actualizarlsv()
    End Sub

    Private Sub ExportarPreciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportarPreciosToolStripMenuItem.Click
        exportar_precios.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles t_reloj.Tick
        'tss_hora.Text = "Hora: " & Hour() & ":" & Minute() & ":" & Second()
        tss_hora.Text = "Hora: " & DateAndTime.TimeOfDay
    End Sub

    Private Sub chk_stock0_CheckedChanged(sender As Object, e As EventArgs) Handles chk_stock0.CheckedChanged
        stock0 = Not chk_stock0.Checked
    End Sub

    Private Sub main_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        detectaTeclas(e)
    End Sub

    Private Sub Treev_KeyUp(sender As Object, e As KeyEventArgs) Handles Treev.KeyUp
        detectaTeclas(e)
    End Sub

    Private Sub lsview_KeyUp(sender As Object, e As KeyEventArgs) Handles lsview.KeyUp
        detectaTeclas(e)
    End Sub

    Private Sub txt_search_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_search.KeyUp
        detectaTeclas(e)
    End Sub

    Private Sub chk_historicos_KeyUp(sender As Object, e As KeyEventArgs) Handles chk_historicos.KeyUp
        detectaTeclas(e)
    End Sub

    Private Sub chk_rpt_KeyUp(sender As Object, e As KeyEventArgs) Handles chk_rpt.KeyUp
        detectaTeclas(e)
    End Sub

    Private Sub chk_stock0_KeyUp(sender As Object, e As KeyEventArgs) Handles chk_stock0.KeyUp
        detectaTeclas(e)
    End Sub

    Private Sub pic_search_KeyUp(sender As Object, e As KeyEventArgs) Handles pic_search.KeyUp
        detectaTeclas(e)
    End Sub

    Private Sub lbl_borrarbusqueda_KeyUp(sender As Object, e As KeyEventArgs) Handles lbl_borrarbusqueda.KeyUp
        detectaTeclas(e)
    End Sub

    Private Sub cmd_add_KeyUp(sender As Object, e As KeyEventArgs) Handles cmd_add.KeyUp
        detectaTeclas(e)
    End Sub
    Private Sub cmd_pedido_KeyUp(sender As Object, e As KeyEventArgs) Handles cmd_pedido.KeyUp
        detectaTeclas(e)
    End Sub
    Private Sub cmd_caso_KeyUp(sender As Object, e As KeyEventArgs) Handles cmd_caso.KeyUp
        detectaTeclas(e)
    End Sub

    Private Sub cmd_addcliente_KeyUp(sender As Object, e As KeyEventArgs) Handles cmd_addcliente.KeyUp
        detectaTeclas(e)
    End Sub

    Private Sub cmd_addauto_KeyUp(sender As Object, e As KeyEventArgs) Handles cmd_addauto.KeyUp
        detectaTeclas(e)
    End Sub

    Private Sub ss_info_KeyUp(sender As Object, e As KeyEventArgs) Handles ss_info.KeyUp
        detectaTeclas(e)
    End Sub

    Private Sub pic_KeyUp(sender As Object, e As KeyEventArgs) Handles pic.KeyUp
        detectaTeclas(e)
    End Sub

    Private Sub lblbusqueda_KeyUp(sender As Object, e As KeyEventArgs) Handles lblbusqueda.KeyUp
        detectaTeclas(e)
    End Sub

    Private Sub detectaTeclas(e As KeyEventArgs)
        If e.KeyCode = Keys.F1 Then
            add_pedido.ShowDialog()
            actualizarlsv()
        ElseIf e.KeyCode = Keys.F2 Then
            add_caso.ShowDialog()
            actualizarlsv()
        ElseIf e.KeyCode = Keys.F3 Then
            add_cliente.ShowDialog()
            actualizarlsv()
        ElseIf e.KeyCode = Keys.F4 Then
            add_auto.ShowDialog()
            actualizarlsv()
        ElseIf e.KeyCode = Keys.F5 Then
            Dim tmp As String
            'Dim historico As Boolean
            'historico = chk_historicos.Checked
            'activo = True
            form = Me
            tmp = tabla
            tabla = "items2"
            form.Enabled = False
            search.ShowDialog()
            tabla = tmp

            id = 0
            'activo = historico
        ElseIf e.KeyCode = Keys.F12 Then
            add_presupuesto.ShowDialog()
            actualizarlsv()
        End If
    End Sub

    Private Sub txt_searchEAN_Enter(sender As Object, e As EventArgs) Handles txt_searchEAN.Enter
        txt_searchEAN.Text = ""
    End Sub

    Private Sub txt_searchEAN_Leave(sender As Object, e As EventArgs) Handles txt_searchEAN.Leave
        txt_searchEAN.Text = "EAN"
    End Sub

    Private Sub txt_searchEAN_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_searchEAN.KeyDown
        Dim id_item As Integer
        Dim i As New item

        If e.KeyCode = Keys.Enter Then
            id_item = existeitemEAN(txt_searchEAN.Text)
            If id_item = -1 Then
                MsgBox("Ese EAN no existe", vbCritical + vbOKOnly, "DROil")
            Else
                edita_item = info_item(id_item)
                With edita_item
                    MsgBox(" ******* INFORMACION RAPIDA *******" & vbNewLine & vbNewLine +
                           "Código: " & .item & vbNewLine +
                           "Descripción: " & .descript & vbNewLine +
                           "Stock: " & .cantidad & vbNewLine +
                           "Precio: " & .precio_lista, vbOKOnly + vbInformation, "DR.Oil")
                End With
                edita_item = i
            End If

            txt_searchEAN.Text = ""
        End If
    End Sub

    Private Sub cmd_first_Click(sender As Object, e As EventArgs) Handles cmd_first.Click
        desde = 1
        hasta = itXPage
        pagina = 1
        actualizarlsv()
    End Sub

    Private Sub cmd_prev_Click(sender As Object, e As EventArgs) Handles cmd_prev.Click
        If pagina = 1 Then Exit Sub
        desde -= itXPage
        hasta -= itXPage
        pagina -= 1
        actualizarlsv()
    End Sub

    Private Sub Cmd_next_Click(sender As Object, e As EventArgs) Handles cmd_next.Click
        If pagina = Math.Ceiling(nRegs / itXPage) Then Exit Sub
        desde += itXPage
        hasta += itXPage
        pagina += 1
        actualizarlsv()
    End Sub

    Private Sub Cmd_go_Click(sender As Object, e As EventArgs) Handles cmd_go.Click
        'pagina = Strings.Left(txt_nPage.Text, InStr(txt_nPage.Text, " / "))
        pagina = txt_nPage.Text
        If pagina > tPaginas Then pagina = tPaginas
        desde = pagina * itXPage
        hasta = desde + itXPage
        actualizarlsv()
    End Sub

    Private Sub cmd_last_Click(sender As Object, e As EventArgs) Handles cmd_last.Click
        pagina = tPaginas
        desde = nRegs - itXPage
        hasta = nRegs
        actualizarlsv()
    End Sub

    Private Sub txt_nPage_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_nPage.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cmd_go_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txt_nPage_Click(sender As Object, e As EventArgs) Handles txt_nPage.Click
        txt_nPage.Text = ""
    End Sub

    Private Sub t_GetDolar_Tick(sender As Object, e As EventArgs) Handles t_GetDolar.Tick
        'Exit Sub
        GetDolar()

        cotizaOficial = LeeDolar(DOLAR_OFICIAL)
        cotizaBlue = LeeDolar(DOLAR_BLUE)
        tss_dolar.Text = "Dolar oficial: " & cotizaOficial.venta.ToString & " - Dolar Blue: " & cotizaBlue.venta.ToString
    End Sub

    Private Sub DuplicarCasoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DuplicarCasoToolStripMenuItem.Click
        Duplicar_caso()
    End Sub

    Private Sub Duplicar_caso()
        'Dim sqlstr As String = ""
        Dim seleccionado As String
        Dim idUnico As String

        'Dim p As New pedido
        'p = info_pedido(seleccionado)
        'id = p.id_pedido
        seleccionado = lsview.SelectedItems.Item(0).Text

        idUnico = Generar_ID_Unico()

        duplicarCaso(seleccionado)
        'Treev.SelectedNode = Treev.Nodes("root").Nodes("ventas").Nodes("pedidos")
        'chk_historicos.Checked = False
        'actualizarlsv()
        edita_pedido = info_pedido(, True)
        'caso_a_casoTmp(edita_pedido.id_pedido, usuario_logueado.id_usuario, idUnico)
        edicion = True

        Dim addCaso As New add_caso(idUnico, 1, usuario_logueado.id_usuario)
        addCaso.ShowDialog()
        'add_pedido.ShowDialog()
        edicion = False
        actualizarlsv()
    End Sub

    Private Sub dgv_main_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_main.CellDoubleClick
        listview_DoubleClick(sender, e)
    End Sub

    Private Sub dgv_main_MouseDown(sender As Object, e As MouseEventArgs) Handles dgv_main.MouseDown
        lsview_MouseDown(sender, e)
    End Sub

    'Private Sub txt_nPage_Leave(sender As Object, e As EventArgs) Handles txt_nPage.Leave
    '    txt_nPage.Text = pagina & " / " & tPaginas
    'End Sub

End Class