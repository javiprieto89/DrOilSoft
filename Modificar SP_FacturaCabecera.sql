USE [dbKiosco]
GO
/****** Object:  StoredProcedure [dbo].[factura_cabecera]    Script Date: 31/08/16 12:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[factura_cabecera]
	-- Add the parameters for the stored procedure here
	@idfc INTEGER
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT CONVERT(NVARCHAR(20), p.fecha, 103) AS 'order_date', c.razon_social AS 'cust_name', 
		dbo.mascaraCUIT(c.taxNumber) AS 'cust_taxNumber', c.direccion_fiscal AS 'cust_address', 
		(CASE WHEN c.esInscripto = '1'  THEN 'Responsable Inscripto' END) AS 'inscripto', pro.provincia AS 'provincia', c.localidad_fiscal AS 'localidad',
		 CONCAT('$', dbo.milesArgentinos(CONVERT(VARCHAR(50), CAST(p.subTotal AS MONEY),1))) AS 'subtotal', 
		 CONCAT('$', dbo.milesArgentinos(CONVERT(VARCHAR(50), CAST(p.iva AS MONEY),1))) AS 'iva',
		 CONCAT('$', dbo.milesArgentinos(CONVERT(VARCHAR(50), CAST(p.total AS MONEY),1))) AS 'total',
		 p.nota1 AS 'nota1', p.nota2 AS 'nota2',
		 CONCAT('Nº  ', REPLICATE('0', 4 - LEN(p.puntoVenta)), p.puntoVenta, '-', REPLICATE('0', 8 - LEN(p.numeroComprobante)), p.numeroComprobante) AS 'numeroFC',
		 p.cae AS 'CAE', CONVERT(NVARCHAR(20), p.fechaVencimiento_cae,103) AS 'vencimiento_cae', p.numeroComprobante AS 'numeroComprobante', 
		 ISNULL(p.idPresupuesto, 1) AS 'idpresupuesto', p.codigoDeBarras AS 'codigoDeBarras',
		 pp.numeroComprobante AS 'numeroComprobanteRemito'
	FROM pedidos AS p			
	INNER JOIN clientes AS c ON p.id_cliente = c.id_cliente
	INNER JOIN provincias AS pro ON c.id_provincia_fiscal = pro.id_provincia	
	LEFT JOIN pedidos AS pp ON p.id_pedido = pp.id_pedidoAsociado 
	WHERE p.id_pedido = @idfc	
END