DECLARE @desde AS DATE
DECLARE @hasta AS DATE
DECLARE @id_comprobante AS INTEGER

SET @desde = '2016-07-01'
SET @hasta = '2016-08-31'
SET @id_comprobante = 1


SELECT p.fecha AS 'Fecha', p.numeroComprobante AS 'Factura Nº', p.subtotal AS 'Subtotal', p.total - p.subtotal AS 'IVA', p.total AS 'Total', c.comprobante AS 'Comprobante'
FROM pedidos AS p
INNER JOIN comprobantes AS c ON p.id_comprobante = c.id_comprobante 
WHERE @id_comprobante IS NULL AND ((@desde IS NULL AND @hasta IS NULL) 
OR	(@desde IS NULL AND p.fecha <= @hasta) 
OR	(@desde IS NOT NULL AND p.fecha >= @desde AND @hasta IS NULL)
OR  (p.fecha >= @desde AND p.fecha <= @hasta)) 
OR 
p.id_comprobante = @id_comprobante AND ((@desde IS NULL AND @hasta IS NULL) 
OR	(@desde IS NULL AND p.fecha <= @hasta) 
OR	(@desde IS NOT NULL AND p.fecha >= @desde AND @hasta IS NULL)
OR  (p.fecha >= @desde AND p.fecha <= @hasta))