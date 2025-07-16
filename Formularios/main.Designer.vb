<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class main
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Condiciones de venta")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Descuentos")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Clientes")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Vendedores")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mecanicos")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Proveedores")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Comprobantes")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Marcas")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Modelos")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Autos")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Autos", New System.Windows.Forms.TreeNode() {TreeNode8, TreeNode9, TreeNode10})
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Marcas")
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Categorías")
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Roscas")
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Items/C.Stock")
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Items/Full")
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Items", New System.Windows.Forms.TreeNode() {TreeNode12, TreeNode13, TreeNode14, TreeNode15, TreeNode16})
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tipos de casos")
        Dim TreeNode19 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Casos/Pedidos", New System.Windows.Forms.TreeNode() {TreeNode18})
        Dim TreeNode20 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Grupo de tarjetas")
        Dim TreeNode21 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tarjetas de crédito")
        Dim TreeNode22 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tarjetas de crédito", New System.Windows.Forms.TreeNode() {TreeNode20, TreeNode21})
        Dim TreeNode23 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Caja")
        Dim TreeNode24 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consultas personalizadas")
        Dim TreeNode25 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Archivos", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4, TreeNode5, TreeNode6, TreeNode7, TreeNode11, TreeNode17, TreeNode19, TreeNode22, TreeNode23, TreeNode24})
        Dim TreeNode26 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Stock")
        Dim TreeNode27 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ajustes", New System.Windows.Forms.TreeNode() {TreeNode26})
        Dim TreeNode28 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Nuevo pedido")
        Dim TreeNode29 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Nuevo caso")
        Dim TreeNode30 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Pedidos")
        Dim TreeNode31 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Pedidos del día")
        Dim TreeNode32 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Casos")
        Dim TreeNode33 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Casos del día")
        Dim TreeNode34 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Presupuestos")
        Dim TreeNode35 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Facturas por emitir")
        Dim TreeNode36 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Facturas emitidas")
        Dim TreeNode37 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Facturas", New System.Windows.Forms.TreeNode() {TreeNode35, TreeNode36})
        Dim TreeNode38 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ventas", New System.Windows.Forms.TreeNode() {TreeNode28, TreeNode29, TreeNode30, TreeNode31, TreeNode32, TreeNode33, TreeNode34, TreeNode37})
        Dim TreeNode39 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Caja")
        Dim TreeNode40 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CC Clientes")
        Dim TreeNode41 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Personalizadas")
        Dim TreeNode42 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Exportaciones S.I.A.p")
        Dim TreeNode43 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Último comprobante")
        Dim TreeNode44 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Información factura")
        Dim TreeNode45 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Total facturado")
        Dim TreeNode46 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Factura electrónica", New System.Windows.Forms.TreeNode() {TreeNode43, TreeNode44, TreeNode45})
        Dim TreeNode47 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consultas", New System.Windows.Forms.TreeNode() {TreeNode39, TreeNode40, TreeNode41, TreeNode42, TreeNode46})
        Dim TreeNode48 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Permisos")
        Dim TreeNode49 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Pefiles")
        Dim TreeNode50 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Usuarios")
        Dim TreeNode51 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Seguridad", New System.Windows.Forms.TreeNode() {TreeNode48, TreeNode49, TreeNode50})
        Dim TreeNode52 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Configuración")
        Dim TreeNode53 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Asignar permisos a perfiles")
        Dim TreeNode54 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Asignar perfiles a usuarios")
        Dim TreeNode55 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Configuración", New System.Windows.Forms.TreeNode() {TreeNode51, TreeNode52, TreeNode53, TreeNode54})
        Dim TreeNode56 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Acerca de...")
        Dim TreeNode57 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Dr. Oil", New System.Windows.Forms.TreeNode() {TreeNode25, TreeNode27, TreeNode38, TreeNode47, TreeNode55, TreeNode56})
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(main))
        Me.cmd_add = New System.Windows.Forms.Button()
        Me.lsview = New System.Windows.Forms.ListView()
        Me.cms_general = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BorrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TerminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TerminarPedidoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeshabilitarItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MostrarFacturaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DuplicarCasoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblbusqueda = New System.Windows.Forms.Label()
        Me.txt_search = New System.Windows.Forms.TextBox()
        Me.chk_historicos = New System.Windows.Forms.CheckBox()
        Me.lbl_borrarbusqueda = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Treev = New System.Windows.Forms.TreeView()
        Me.cms_importar_exportar = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ImportarPreciosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportarPreciosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_caso = New System.Windows.Forms.Button()
        Me.cmd_pedido = New System.Windows.Forms.Button()
        Me.cmd_addcliente = New System.Windows.Forms.Button()
        Me.cmd_addauto = New System.Windows.Forms.Button()
        Me.chk_rpt = New System.Windows.Forms.CheckBox()
        Me.tooltip_advanceseach = New System.Windows.Forms.ToolTip(Me.components)
        Me.ss_info = New System.Windows.Forms.StatusStrip()
        Me.tss_version = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tss_hora = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tss_usuario = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tss_dolar = New System.Windows.Forms.ToolStripStatusLabel()
        Me.t_reloj = New System.Windows.Forms.Timer(Me.components)
        Me.chk_stock0 = New System.Windows.Forms.CheckBox()
        Me.txt_searchEAN = New System.Windows.Forms.TextBox()
        Me.cmd_first = New System.Windows.Forms.Button()
        Me.cmd_prev = New System.Windows.Forms.Button()
        Me.cmd_next = New System.Windows.Forms.Button()
        Me.cmd_last = New System.Windows.Forms.Button()
        Me.txt_nPage = New System.Windows.Forms.TextBox()
        Me.cmd_go = New System.Windows.Forms.Button()
        Me.t_GetDolar = New System.Windows.Forms.Timer(Me.components)
        Me.pic_search = New System.Windows.Forms.PictureBox()
        Me.pic = New System.Windows.Forms.PictureBox()
        Me.cms_general.SuspendLayout()
        Me.cms_importar_exportar.SuspendLayout()
        Me.ss_info.SuspendLayout()
        CType(Me.pic_search, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmd_add
        '
        Me.cmd_add.Location = New System.Drawing.Point(11, 918)
        Me.cmd_add.Name = "cmd_add"
        Me.cmd_add.Size = New System.Drawing.Size(202, 42)
        Me.cmd_add.TabIndex = 3
        Me.cmd_add.Text = "Agregar"
        Me.cmd_add.UseVisualStyleBackColor = True
        '
        'lsview
        '
        Me.lsview.ContextMenuStrip = Me.cms_general
        Me.lsview.HideSelection = False
        Me.lsview.Location = New System.Drawing.Point(265, 88)
        Me.lsview.Name = "lsview"
        Me.lsview.Size = New System.Drawing.Size(1398, 802)
        Me.lsview.TabIndex = 2
        Me.lsview.UseCompatibleStateImageBehavior = False
        '
        'cms_general
        '
        Me.cms_general.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cms_general.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditarToolStripMenuItem, Me.BorrarToolStripMenuItem, Me.TerminarToolStripMenuItem, Me.TerminarPedidoToolStripMenuItem, Me.DeshabilitarItemToolStripMenuItem, Me.MostrarFacturaToolStripMenuItem, Me.DuplicarCasoToolStripMenuItem})
        Me.cms_general.Name = "ContextMenuStrip"
        Me.cms_general.Size = New System.Drawing.Size(156, 158)
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.EditarToolStripMenuItem.Text = "Editar"
        '
        'BorrarToolStripMenuItem
        '
        Me.BorrarToolStripMenuItem.Name = "BorrarToolStripMenuItem"
        Me.BorrarToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.BorrarToolStripMenuItem.Text = "Borrar"
        '
        'TerminarToolStripMenuItem
        '
        Me.TerminarToolStripMenuItem.Name = "TerminarToolStripMenuItem"
        Me.TerminarToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.TerminarToolStripMenuItem.Text = "Cerrar caso"
        Me.TerminarToolStripMenuItem.Visible = False
        '
        'TerminarPedidoToolStripMenuItem
        '
        Me.TerminarPedidoToolStripMenuItem.Name = "TerminarPedidoToolStripMenuItem"
        Me.TerminarPedidoToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.TerminarPedidoToolStripMenuItem.Text = "Cerrar pedido"
        '
        'DeshabilitarItemToolStripMenuItem
        '
        Me.DeshabilitarItemToolStripMenuItem.Name = "DeshabilitarItemToolStripMenuItem"
        Me.DeshabilitarItemToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.DeshabilitarItemToolStripMenuItem.Text = "Desactivar item"
        '
        'MostrarFacturaToolStripMenuItem
        '
        Me.MostrarFacturaToolStripMenuItem.Name = "MostrarFacturaToolStripMenuItem"
        Me.MostrarFacturaToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.MostrarFacturaToolStripMenuItem.Text = "Mostrar factura"
        Me.MostrarFacturaToolStripMenuItem.Visible = False
        '
        'DuplicarCasoToolStripMenuItem
        '
        Me.DuplicarCasoToolStripMenuItem.Name = "DuplicarCasoToolStripMenuItem"
        Me.DuplicarCasoToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.DuplicarCasoToolStripMenuItem.Text = "Duplicar caso"
        '
        'lblbusqueda
        '
        Me.lblbusqueda.AutoSize = True
        Me.lblbusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbusqueda.Location = New System.Drawing.Point(13, 29)
        Me.lblbusqueda.Name = "lblbusqueda"
        Me.lblbusqueda.Size = New System.Drawing.Size(63, 13)
        Me.lblbusqueda.TabIndex = 18
        Me.lblbusqueda.Text = "Búsqueda"
        '
        'txt_search
        '
        Me.txt_search.Location = New System.Drawing.Point(91, 26)
        Me.txt_search.Name = "txt_search"
        Me.txt_search.Size = New System.Drawing.Size(1528, 20)
        Me.txt_search.TabIndex = 1
        '
        'chk_historicos
        '
        Me.chk_historicos.AutoSize = True
        Me.chk_historicos.Location = New System.Drawing.Point(11, 65)
        Me.chk_historicos.Margin = New System.Windows.Forms.Padding(2)
        Me.chk_historicos.Name = "chk_historicos"
        Me.chk_historicos.Size = New System.Drawing.Size(136, 17)
        Me.chk_historicos.TabIndex = 20
        Me.chk_historicos.Text = "Ver históricos/inactivos"
        Me.chk_historicos.UseVisualStyleBackColor = True
        '
        'lbl_borrarbusqueda
        '
        Me.lbl_borrarbusqueda.AutoSize = True
        Me.lbl_borrarbusqueda.Location = New System.Drawing.Point(1624, 33)
        Me.lbl_borrarbusqueda.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_borrarbusqueda.Name = "lbl_borrarbusqueda"
        Me.lbl_borrarbusqueda.Size = New System.Drawing.Size(12, 13)
        Me.lbl_borrarbusqueda.TabIndex = 21
        Me.lbl_borrarbusqueda.Text = "x"
        Me.ToolTip1.SetToolTip(Me.lbl_borrarbusqueda, "Borrar búsqueda")
        '
        'Treev
        '
        Me.Treev.Location = New System.Drawing.Point(11, 88)
        Me.Treev.Margin = New System.Windows.Forms.Padding(2)
        Me.Treev.Name = "Treev"
        TreeNode1.Name = "condiciones"
        TreeNode1.Text = "Condiciones de venta"
        TreeNode2.Name = "descuentos"
        TreeNode2.Text = "Descuentos"
        TreeNode3.Name = "clientes"
        TreeNode3.Text = "Clientes"
        TreeNode4.Name = "vendedores"
        TreeNode4.Text = "Vendedores"
        TreeNode5.Name = "mecanicos"
        TreeNode5.Text = "Mecanicos"
        TreeNode6.Name = "proveedores"
        TreeNode6.Text = "Proveedores"
        TreeNode7.Name = "comprobantes"
        TreeNode7.Text = "Comprobantes"
        TreeNode8.Name = "marcas_autos"
        TreeNode8.Text = "Marcas"
        TreeNode9.Name = "modelosa"
        TreeNode9.Text = "Modelos"
        TreeNode10.Name = "autos"
        TreeNode10.Text = "Autos"
        TreeNode11.Name = "archivoautos"
        TreeNode11.Text = "Autos"
        TreeNode12.Name = "marcas_items"
        TreeNode12.Text = "Marcas"
        TreeNode13.Name = "tipos_items"
        TreeNode13.Text = "Categorías"
        TreeNode14.Name = "roscas"
        TreeNode14.Text = "Roscas"
        TreeNode15.Name = "items"
        TreeNode15.Text = "Items/C.Stock"
        TreeNode16.Name = "items_full"
        TreeNode16.Text = "Items/Full"
        TreeNode17.Name = "archivoitems"
        TreeNode17.Text = "Items"
        TreeNode18.Name = "tipos_casos"
        TreeNode18.Text = "Tipos de casos"
        TreeNode19.Name = "archivopedidoscasos"
        TreeNode19.Text = "Casos/Pedidos"
        TreeNode20.Name = "grupoTarjetas"
        TreeNode20.Text = "Grupo de tarjetas"
        TreeNode21.Name = "tarjetas"
        TreeNode21.Text = "Tarjetas de crédito"
        TreeNode22.Name = "archivoTarjetas"
        TreeNode22.Text = "Tarjetas de crédito"
        TreeNode23.Name = "caja"
        TreeNode23.Text = "Caja"
        TreeNode24.Name = "archivoconsultas"
        TreeNode24.Text = "Consultas personalizadas"
        TreeNode25.Name = "archivos"
        TreeNode25.Text = "Archivos"
        TreeNode26.Name = "registros_stock"
        TreeNode26.Text = "Stock"
        TreeNode27.Name = "ajustes"
        TreeNode27.Text = "Ajustes"
        TreeNode28.Name = "nuevopedido"
        TreeNode28.Text = "Nuevo pedido"
        TreeNode29.Name = "nuevocaso"
        TreeNode29.Text = "Nuevo caso"
        TreeNode30.Name = "pedidos"
        TreeNode30.Text = "Pedidos"
        TreeNode31.Name = "pedidos_hoy"
        TreeNode31.Text = "Pedidos del día"
        TreeNode32.Name = "casos"
        TreeNode32.Text = "Casos"
        TreeNode33.Name = "casos_hoy"
        TreeNode33.Text = "Casos del día"
        TreeNode34.Name = "presupuestos"
        TreeNode34.Text = "Presupuestos"
        TreeNode35.Name = "fe_pendiente"
        TreeNode35.Text = "Facturas por emitir"
        TreeNode36.Name = "fe"
        TreeNode36.Text = "Facturas emitidas"
        TreeNode37.Name = "facturacion"
        TreeNode37.Text = "Facturas"
        TreeNode38.Name = "ventas"
        TreeNode38.Text = "Ventas"
        TreeNode39.Name = "consulta_caja"
        TreeNode39.Text = "Caja"
        TreeNode40.Name = "ccClientes"
        TreeNode40.Text = "CC Clientes"
        TreeNode41.Name = "cpersonalizadas"
        TreeNode41.Text = "Personalizadas"
        TreeNode42.Name = "exportSiap"
        TreeNode42.Text = "Exportaciones S.I.A.p"
        TreeNode43.Name = "ultimoComprobante"
        TreeNode43.Text = "Último comprobante"
        TreeNode44.Name = "info_fc"
        TreeNode44.Text = "Información factura"
        TreeNode45.Name = "totalFacturado"
        TreeNode45.Text = "Total facturado"
        TreeNode46.Name = "consultasFE"
        TreeNode46.Text = "Factura electrónica"
        TreeNode47.Name = "consultas"
        TreeNode47.Text = "Consultas"
        TreeNode48.Name = "permisos"
        TreeNode48.Text = "Permisos"
        TreeNode49.Name = "perfiles"
        TreeNode49.Text = "Pefiles"
        TreeNode50.Name = "usuarios"
        TreeNode50.Text = "Usuarios"
        TreeNode51.Name = "seguridad"
        TreeNode51.Text = "Seguridad"
        TreeNode52.Name = "configuracion"
        TreeNode52.Text = "Configuración"
        TreeNode53.Name = "permisos_a_perfiles"
        TreeNode53.Text = "Asignar permisos a perfiles"
        TreeNode54.Name = "perfiles_a_usuarios"
        TreeNode54.Text = "Asignar perfiles a usuarios"
        TreeNode55.Name = "cfg_menu"
        TreeNode55.Text = "Configuración"
        TreeNode56.Name = "acercade"
        TreeNode56.Text = "Acerca de..."
        TreeNode57.Name = "root"
        TreeNode57.Text = "Dr. Oil"
        Me.Treev.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode57})
        Me.Treev.Size = New System.Drawing.Size(234, 802)
        Me.Treev.TabIndex = 23
        '
        'cms_importar_exportar
        '
        Me.cms_importar_exportar.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cms_importar_exportar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportarPreciosToolStripMenuItem, Me.ExportarPreciosToolStripMenuItem})
        Me.cms_importar_exportar.Name = "ContextMenuStrip1"
        Me.cms_importar_exportar.Size = New System.Drawing.Size(162, 48)
        '
        'ImportarPreciosToolStripMenuItem
        '
        Me.ImportarPreciosToolStripMenuItem.Name = "ImportarPreciosToolStripMenuItem"
        Me.ImportarPreciosToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.ImportarPreciosToolStripMenuItem.Text = "Importar precios"
        '
        'ExportarPreciosToolStripMenuItem
        '
        Me.ExportarPreciosToolStripMenuItem.Name = "ExportarPreciosToolStripMenuItem"
        Me.ExportarPreciosToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.ExportarPreciosToolStripMenuItem.Text = "Exportar precios"
        '
        'cmd_caso
        '
        Me.cmd_caso.Location = New System.Drawing.Point(658, 918)
        Me.cmd_caso.Name = "cmd_caso"
        Me.cmd_caso.Size = New System.Drawing.Size(191, 42)
        Me.cmd_caso.TabIndex = 26
        Me.cmd_caso.Text = "Nuevo caso (F2)"
        Me.cmd_caso.UseVisualStyleBackColor = True
        '
        'cmd_pedido
        '
        Me.cmd_pedido.Location = New System.Drawing.Point(265, 918)
        Me.cmd_pedido.Name = "cmd_pedido"
        Me.cmd_pedido.Size = New System.Drawing.Size(191, 42)
        Me.cmd_pedido.TabIndex = 25
        Me.cmd_pedido.Text = "Nuevo pedido (F1)"
        Me.cmd_pedido.UseVisualStyleBackColor = True
        '
        'cmd_addcliente
        '
        Me.cmd_addcliente.Location = New System.Drawing.Point(1046, 918)
        Me.cmd_addcliente.Name = "cmd_addcliente"
        Me.cmd_addcliente.Size = New System.Drawing.Size(191, 42)
        Me.cmd_addcliente.TabIndex = 28
        Me.cmd_addcliente.Text = "Nuevo cliente (F3)"
        Me.cmd_addcliente.UseVisualStyleBackColor = True
        '
        'cmd_addauto
        '
        Me.cmd_addauto.Location = New System.Drawing.Point(1472, 918)
        Me.cmd_addauto.Name = "cmd_addauto"
        Me.cmd_addauto.Size = New System.Drawing.Size(191, 42)
        Me.cmd_addauto.TabIndex = 27
        Me.cmd_addauto.Text = "Nuevo auto (F4)"
        Me.cmd_addauto.UseVisualStyleBackColor = True
        '
        'chk_rpt
        '
        Me.chk_rpt.AutoSize = True
        Me.chk_rpt.Location = New System.Drawing.Point(152, 65)
        Me.chk_rpt.Name = "chk_rpt"
        Me.chk_rpt.Size = New System.Drawing.Size(108, 17)
        Me.chk_rpt.TabIndex = 50
        Me.chk_rpt.Text = "Mostrar impresión"
        Me.chk_rpt.UseVisualStyleBackColor = True
        '
        'tooltip_advanceseach
        '
        Me.tooltip_advanceseach.ForeColor = System.Drawing.Color.Red
        '
        'ss_info
        '
        Me.ss_info.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ss_info.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tss_version, Me.ToolStripStatusLabel1, Me.tss_hora, Me.ToolStripStatusLabel2, Me.tss_usuario, Me.ToolStripStatusLabel3, Me.tss_dolar})
        Me.ss_info.Location = New System.Drawing.Point(0, 1001)
        Me.ss_info.Name = "ss_info"
        Me.ss_info.Size = New System.Drawing.Size(1690, 22)
        Me.ss_info.TabIndex = 52
        Me.ss_info.Text = "StatusStrip1"
        '
        'tss_version
        '
        Me.tss_version.Name = "tss_version"
        Me.tss_version.Size = New System.Drawing.Size(65, 17)
        Me.tss_version.Text = "%versión%"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(4, 17)
        '
        'tss_hora
        '
        Me.tss_hora.Name = "tss_hora"
        Me.tss_hora.Size = New System.Drawing.Size(51, 17)
        Me.tss_hora.Text = "%hora%"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(4, 17)
        '
        'tss_usuario
        '
        Me.tss_usuario.Name = "tss_usuario"
        Me.tss_usuario.Size = New System.Drawing.Size(66, 17)
        Me.tss_usuario.Text = "%usuario%"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(4, 17)
        '
        'tss_dolar
        '
        Me.tss_dolar.Name = "tss_dolar"
        Me.tss_dolar.Size = New System.Drawing.Size(54, 17)
        Me.tss_dolar.Text = "%dolar%"
        '
        't_reloj
        '
        Me.t_reloj.Interval = 1000
        '
        'chk_stock0
        '
        Me.chk_stock0.AutoSize = True
        Me.chk_stock0.Location = New System.Drawing.Point(265, 65)
        Me.chk_stock0.Name = "chk_stock0"
        Me.chk_stock0.Size = New System.Drawing.Size(166, 17)
        Me.chk_stock0.TabIndex = 53
        Me.chk_stock0.Text = "No mostrar artículos sin stock"
        Me.chk_stock0.UseVisualStyleBackColor = True
        '
        'txt_searchEAN
        '
        Me.txt_searchEAN.ForeColor = System.Drawing.Color.Red
        Me.txt_searchEAN.Location = New System.Drawing.Point(453, 62)
        Me.txt_searchEAN.Name = "txt_searchEAN"
        Me.txt_searchEAN.Size = New System.Drawing.Size(272, 20)
        Me.txt_searchEAN.TabIndex = 54
        Me.txt_searchEAN.Text = "EAN"
        '
        'cmd_first
        '
        Me.cmd_first.Enabled = False
        Me.cmd_first.Location = New System.Drawing.Point(1403, 65)
        Me.cmd_first.Name = "cmd_first"
        Me.cmd_first.Size = New System.Drawing.Size(29, 20)
        Me.cmd_first.TabIndex = 55
        Me.cmd_first.Text = "|<<"
        Me.cmd_first.UseVisualStyleBackColor = True
        '
        'cmd_prev
        '
        Me.cmd_prev.Enabled = False
        Me.cmd_prev.Location = New System.Drawing.Point(1438, 65)
        Me.cmd_prev.Name = "cmd_prev"
        Me.cmd_prev.Size = New System.Drawing.Size(40, 20)
        Me.cmd_prev.TabIndex = 56
        Me.cmd_prev.Text = "<<"
        Me.cmd_prev.UseVisualStyleBackColor = True
        '
        'cmd_next
        '
        Me.cmd_next.Enabled = False
        Me.cmd_next.Location = New System.Drawing.Point(1484, 65)
        Me.cmd_next.Name = "cmd_next"
        Me.cmd_next.Size = New System.Drawing.Size(40, 20)
        Me.cmd_next.TabIndex = 57
        Me.cmd_next.Text = ">>"
        Me.cmd_next.UseVisualStyleBackColor = True
        '
        'cmd_last
        '
        Me.cmd_last.Enabled = False
        Me.cmd_last.Location = New System.Drawing.Point(1530, 65)
        Me.cmd_last.Name = "cmd_last"
        Me.cmd_last.Size = New System.Drawing.Size(29, 20)
        Me.cmd_last.TabIndex = 58
        Me.cmd_last.Text = ">>|"
        Me.cmd_last.UseVisualStyleBackColor = True
        '
        'txt_nPage
        '
        Me.txt_nPage.Enabled = False
        Me.txt_nPage.Location = New System.Drawing.Point(1565, 65)
        Me.txt_nPage.Name = "txt_nPage"
        Me.txt_nPage.Size = New System.Drawing.Size(63, 20)
        Me.txt_nPage.TabIndex = 59
        '
        'cmd_go
        '
        Me.cmd_go.Enabled = False
        Me.cmd_go.Location = New System.Drawing.Point(1634, 65)
        Me.cmd_go.Name = "cmd_go"
        Me.cmd_go.Size = New System.Drawing.Size(29, 20)
        Me.cmd_go.TabIndex = 60
        Me.cmd_go.Text = "Ir"
        Me.cmd_go.UseVisualStyleBackColor = True
        '
        't_GetDolar
        '
        Me.t_GetDolar.Interval = 300000
        '
        'pic_search
        '
        Me.pic_search.Image = Global.DROil.My.Resources.Resources.iconoLupa
        Me.pic_search.Location = New System.Drawing.Point(1641, 29)
        Me.pic_search.Name = "pic_search"
        Me.pic_search.Size = New System.Drawing.Size(22, 22)
        Me.pic_search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_search.TabIndex = 49
        Me.pic_search.TabStop = False
        Me.pic_search.Visible = False
        '
        'pic
        '
        Me.pic.Image = Global.DROil.My.Resources.Resources.droillogo
        Me.pic.Location = New System.Drawing.Point(669, 234)
        Me.pic.Margin = New System.Windows.Forms.Padding(2)
        Me.pic.Name = "pic"
        Me.pic.Size = New System.Drawing.Size(576, 500)
        Me.pic.TabIndex = 24
        Me.pic.TabStop = False
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1690, 1023)
        Me.Controls.Add(Me.cmd_go)
        Me.Controls.Add(Me.txt_nPage)
        Me.Controls.Add(Me.cmd_last)
        Me.Controls.Add(Me.cmd_next)
        Me.Controls.Add(Me.cmd_prev)
        Me.Controls.Add(Me.cmd_first)
        Me.Controls.Add(Me.txt_searchEAN)
        Me.Controls.Add(Me.chk_stock0)
        Me.Controls.Add(Me.ss_info)
        Me.Controls.Add(Me.chk_rpt)
        Me.Controls.Add(Me.pic_search)
        Me.Controls.Add(Me.cmd_addcliente)
        Me.Controls.Add(Me.cmd_addauto)
        Me.Controls.Add(Me.cmd_caso)
        Me.Controls.Add(Me.cmd_pedido)
        Me.Controls.Add(Me.pic)
        Me.Controls.Add(Me.Treev)
        Me.Controls.Add(Me.lbl_borrarbusqueda)
        Me.Controls.Add(Me.chk_historicos)
        Me.Controls.Add(Me.txt_search)
        Me.Controls.Add(Me.lblbusqueda)
        Me.Controls.Add(Me.lsview)
        Me.Controls.Add(Me.cmd_add)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DrOil"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.cms_general.ResumeLayout(False)
        Me.cms_importar_exportar.ResumeLayout(False)
        Me.ss_info.ResumeLayout(False)
        Me.ss_info.PerformLayout()
        CType(Me.pic_search, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    'Friend WithEvents DrOil As WindowsApplication1.DrOil
    Friend WithEvents cmd_add As System.Windows.Forms.Button
    Friend WithEvents lsview As System.Windows.Forms.ListView
    'Friend WithEvents ClienteTableAdapter1 As WindowsApplication1.Database1DataSetTableAdapters.clienteTableAdapter
    'Friend WithEvents Database1DataSet As WindowsApplication1.Database1DataSet
    Friend Shadows WithEvents cms_general As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BorrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblbusqueda As System.Windows.Forms.Label
    Friend WithEvents txt_search As System.Windows.Forms.TextBox
    Friend WithEvents TerminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chk_historicos As System.Windows.Forms.CheckBox
    Friend WithEvents TerminarPedidoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lbl_borrarbusqueda As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Treev As System.Windows.Forms.TreeView
    Friend WithEvents pic As System.Windows.Forms.PictureBox
    Friend WithEvents cmd_caso As System.Windows.Forms.Button
    Friend WithEvents cmd_pedido As System.Windows.Forms.Button
    Friend WithEvents cmd_addcliente As System.Windows.Forms.Button
    Friend WithEvents cmd_addauto As System.Windows.Forms.Button
    Friend WithEvents pic_search As System.Windows.Forms.PictureBox
    Friend WithEvents DeshabilitarItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chk_rpt As System.Windows.Forms.CheckBox
    Friend WithEvents tooltip_advanceseach As System.Windows.Forms.ToolTip
    Friend WithEvents MostrarFacturaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cms_importar_exportar As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ImportarPreciosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportarPreciosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ss_info As System.Windows.Forms.StatusStrip
    Friend WithEvents tss_version As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tss_hora As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents t_reloj As System.Windows.Forms.Timer
    Friend WithEvents chk_stock0 As System.Windows.Forms.CheckBox
    Friend WithEvents txt_searchEAN As TextBox
    Friend WithEvents cmd_first As Button
    Friend WithEvents cmd_prev As Button
    Friend WithEvents cmd_next As Button
    Friend WithEvents cmd_last As Button
    Friend WithEvents txt_nPage As TextBox
    Friend WithEvents cmd_go As Button
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents tss_usuario As ToolStripStatusLabel
    Friend WithEvents t_GetDolar As Timer
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents tss_dolar As ToolStripStatusLabel
    Friend WithEvents DuplicarCasoToolStripMenuItem As ToolStripMenuItem
End Class
