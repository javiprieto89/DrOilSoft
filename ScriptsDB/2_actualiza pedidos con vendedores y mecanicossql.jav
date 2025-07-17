DECLARE @id_vendedor AS INTEGER 
DECLARE @id_mecanico AS INTEGER

SELECT TOP 1 @id_vendedor = id_vendedor
FROM vendedores

SELECT TOP 1 @id_mecanico = id_mecanico
FROM mecanicos

UPDATE pedidos
SET id_vendedor = @id_vendedor, 
id_mecanico = @id_mecanico


ALTER TABLE pedidos
ALTER COLUMN id_vendedor INT NOT NULL;

ALTER TABLE pedidos
ALTER COLUMN id_mecanico INT NOT NULL;