USE [dbKiosco]
GO
/****** Object:  StoredProcedure [dbo].[factura_cabecera]    Script Date: 02/09/16 14:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ventasPorComprobante]
	-- Add the parameters for the stored procedure here
	@desde AS DATE,
	@hasta AS DATE,
	@id_comprobante AS INTEGER
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT p.fecha AS 'Fecha', p.numeroComprobante AS 'Factura Nº', p.subtotal AS 'Subtotal', p.total - p.subtotal AS 'IVA', p.total AS 'Total', c.comprobante AS 'Comprobante'
	FROM pedidos AS p
	INNER JOIN comprobantes AS c ON p.id_comprobante = c.id_comprobante 
	WHERE @id_comprobante IS NULL AND ((@desde IS NULL AND @hasta IS NULL) 
	OR	(@desde IS NULL AND p.fecha <= @hasta) 
	OR	(@desde IS NOT NULL AND p.fecha >= @desde AND @hasta IS NULL)
	OR  (p.fecha >= @desde AND p.fecha <= @hasta)) 
	OR 
	(p.id_comprobante = 1 AND ((@desde IS NULL AND @hasta IS NULL) 
	OR	(@desde IS NULL AND p.fecha <= @hasta) 
	OR	(@desde IS NOT NULL AND p.fecha >= @desde AND @hasta IS NULL)
	OR  (p.fecha >= @desde AND p.fecha <= @hasta)))
END