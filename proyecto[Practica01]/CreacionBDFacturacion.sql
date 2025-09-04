create database facturacion
go
use facturacion
go

create table formasPagos(
id_forma_pago int identity (1,1),
formaPago varchar(30)
constraint PK_formaPago primary key(id_forma_pago)
)

create table articulos(
id_articulo int identity(1,1),
nombre varchar(100),
precioUnitario float,
estaActivo bit,
stock int,
constraint PK_articulos primary key(id_articulo)
)
create table clientes(
id_cliente int identity (1,1),
nombre varchar(100),
apellido varchar(100),
email varchar(100)
constraint PK_clientes primary key(id_cliente)
)
create table facturas(
id_factura int identity (1,1),
fecha datetime,
id_forma_pago int,
id_cliente int
constraint PK_facturas primary key(id_factura)
constraint FK_facturas_formas_pago foreign key(id_forma_pago)
								   references formasPagos(id_forma_pago),
constraint FK_facturas_clientes foreign key(id_cliente)
								   references clientes(id_cliente)
)

create table detallesFacturas(
id_detalleFactura int identity (1,1),
id_articulo int,
id_factura int,
cantidad int,
precio float
constraint PK_detallesFacturas primary key(id_detalleFactura)
constraint FK_detallesFacturas_articulos foreign key(id_articulo)
										 references articulos(id_articulo),
constraint FK_detallesFacturas_facturas foreign key(id_factura)
										 references facturas(id_factura)
)


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SP_GUARDAR_ARTICULO
@id_articulo int ,
@nombre varchar(100),
@precioUnitario float,
@stock int
AS
BEGIN 
	IF @id_articulo = 0
		BEGIN
			insert into articulos (nombre,precioUnitario, stock, estaActivo) 
						   values (@nombre,@precioUnitario,@stock, 1)	
		END
	ELSE
		BEGIN
			update articulos 
			set nombre= @nombre,
			precioUnitario=@precioUnitario,
			stock= @stock 
			where id_articulo=@id_articulo
		END
END
--insert detalle
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SP_INSERTAR_DETALLE

	@id_articulo int,
	@id_factura int,
	@cantidad int,
	@precio float

AS
BEGIN
	INSERT INTO detallesFacturas( id_articulo, id_factura, cantidad, precio)
					     VALUES ( @id_articulo, @id_factura, @cantidad, @precio);
	
END
GO
--insert factura
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SP_RECUPERAR_FACTURA_POR_ID
	@id_factura int
AS
BEGIN
	SELECT f.*, df.precio, df.cantidad, a.*
	  FROM facturas as f
	  INNER JOIN detallesFacturas as df ON df.id_factura =f.id_factura
	  INNER JOIN articulos as a ON (a.id_articulo = df.id_articulo)
	  WHERE f.id_factura = @id_factura;
END
GO
--recuperar facturas 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SP_RECUPERAR_FACTURAS
AS
BEGIN
	SELECT f.*, df.precio, df.cantidad, a.*
	  FROM facturas as f
	  INNER JOIN detallesFacturas as df ON df.id_factura =f.id_factura
	  INNER JOIN articulos as a ON (a.id_articulo = df.id_articulo)
	  ORDER BY f.id_factura;
END
GO

--recuperar producto por codigo
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SP_RECUPERAR_ARTICULO_POR_CODIGO
	@id_articulo int
AS
BEGIN
	SELECT * FROM articulos WHERE id_articulo = @id_articulo;
END
GO

--recuperar todos los articulos
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_RECUPERAR_ARTICULOS
AS
BEGIN
	SELECT * FROM articulos
END
GO

--eliminacion logica articulo
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SP_REGISTRAR_BAJA_ARTICULOS
	@id_articulo int 

AS
BEGIN
	UPDATE articulos SET estaActivo  = 0 WHERE id_articulo = @id_articulo;
END
GO
-- ISNTERTS
INSERT INTO formasPagos (formaPago) VALUES ('Efectivo');
INSERT INTO formasPagos (formaPago) VALUES ('Tarjeta de Crédito');
INSERT INTO formasPagos (formaPago) VALUES ('Tarjeta de Débito');
INSERT INTO formasPagos (formaPago) VALUES ('Transferencia Bancaria');
INSERT INTO clientes (nombre, apellido, email) VALUES ('Juan', 'Pérez', 'juan.perez@mail.com');
INSERT INTO clientes (nombre, apellido, email) VALUES ('María', 'Gómez', 'maria.gomez@mail.com');
INSERT INTO clientes (nombre, apellido, email) VALUES ('Carlos', 'López', 'carlos.lopez@mail.com');
INSERT INTO clientes (nombre, apellido, email) VALUES ('Ana', 'Martínez', 'ana.martinez@mail.com');
INSERT INTO articulos (nombre, precioUnitario, estaActivo, stock) 
VALUES ('Laptop Lenovo', 350000, 1, 10);

INSERT INTO articulos (nombre, precioUnitario, estaActivo, stock) 
VALUES ('Mouse Logitech', 15000, 1, 50);

INSERT INTO articulos (nombre, precioUnitario, estaActivo, stock) 
VALUES ('Teclado Mecánico', 25000, 1, 30);

INSERT INTO articulos (nombre, precioUnitario, estaActivo, stock) 
VALUES ('Monitor Samsung 24"', 120000, 1, 15);
INSERT INTO articulos (nombre, precioUnitario, estaActivo, stock) 
VALUES ('eliminenlooo', 50000, 1, 12);
INSERT INTO facturas (fecha, id_forma_pago, id_cliente) 
VALUES (GETDATE(), 2, 1);

INSERT INTO facturas (fecha, id_forma_pago, id_cliente) 
VALUES (GETDATE(), 1, 2);

INSERT INTO facturas (fecha, id_forma_pago, id_cliente) 
VALUES (GETDATE(), 3, 3);
-- Factura 1
INSERT INTO detallesFacturas (id_articulo, id_factura, cantidad, precio)
VALUES (1, 1, 1, 350000); -- 1 Laptop

INSERT INTO detallesFacturas (id_articulo, id_factura, cantidad, precio)
VALUES (2, 1, 2, 15000); -- 2 Mouse

-- Factura 2
INSERT INTO detallesFacturas (id_articulo, id_factura, cantidad, precio)
VALUES (3, 2, 1, 25000); -- 1 Teclado

-- Factura 3
INSERT INTO detallesFacturas (id_articulo, id_factura, cantidad, precio)
VALUES (4, 3, 2, 120000); -- 2 Monitores
