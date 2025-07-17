CREATE TABLE vendedores(
	[id_vendedor] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[porcentaje] [int] NOT NULL,
	[activo] [bit] NOT NULL DEFAULT 'True'
	PRIMARY KEY (id_vendedor)
)

CREATE TABLE mecanicos(
	[id_mecanico] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[porcentaje] [int] NOT NULL,
	[activo] [bit] NOT NULL DEFAULT 'True'
	PRIMARY KEY (id_mecanico)
)

INSERT INTO vendedores (nombre, porcentaje) VALUES ('Predeterminado', 0)
INSERT INTO mecanicos (nombre, porcentaje) VALUES ('Predeterminado', 0)

ALTER TABLE pedidos
ADD id_vendedor INT NULL, 
id_mecanico INT NULL

ALTER TABLE pedidos
ADD CONSTRAINT FK_vendedores_pedidos FOREIGN KEY (id_vendedor)
REFERENCES vendedores (id_vendedor)

ALTER TABLE pedidos
ADD CONSTRAINT FK_mecanicos_pedidos FOREIGN KEY (id_mecanico)
REFERENCES mecanicos (id_mecanico)
