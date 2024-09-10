CREATE database  FACTURACION 
go
use FACTURACION
go
create TABLE CLIENTES 
(id_cliente int identity(1,1),
nombre varchar (100) not null,
apellido varchar(100) not null,
calle varchar(100),
altura varchar(100)
constraint pk_cliente primary key (id_cliente)
)

CREATE TABLE ARTICULOS
(id_articulo int identity(1,1),
nombre varchar (100)not null,
precio_unitario decimal(18,2)
constraint pk_articulos primary key(id_articulo)
)
CREATE TABLE FORMAS_PAGOS
(id_forma_pago int identity(1,1),
nombre varchar (100)
constraint pk_formas_pagos primary key (id_forma_pago)
)
create TABLE FACTURAS
(nro_factura int identity(1,1),
fecha date not null,
forma_pago int ,
cliente int
constraint pk_facturas  primary key (nro_factura)
constraint fk_facturas_formaPago foreign key (forma_pago) references FORMAS_PAGOS (id_forma_pago),
constraint fk_detalles_clientes foreign key (cliente) references CLIENTES(id_cliente)
)
create table DETALLES_FACTURAS
(id_detalle int ,
nro_factura int ,
articulo int ,
cantdad int 
constraint pk_detalle  primary key (id_detalle,nro_factura)
constraint fk_detalles_facturas foreign key (nro_factura) references FACTURAS (nro_factura),
constraint fk_detalles_articulos foreign key (articulo) references ARTICULOS (id_articulo)
)


--PROCEDIMIENTOS ALMACENADOS--

--CREAR CLIENTE--
CREATE PROCEDURE SP_CREAR_CLIENTE
@NOMBRE VARCHAR(100),
@APELLIDO VARCHAR(100),
@CALLE VARCHAR(100),
@ALTURA VARCHAR(100)
AS 
	  BEGIN
	INSERT INTO CLIENTES(nombre,apellido,calle,altura)
	VALUES(@NOMBRE,@APELLIDO,@CALLE,@ALTURA)
       END
	
	INSERT INTO CLIENTES(nombre,apellido,calle,altura) VALUES('JHFHF','JDJ','DJJD','2222')
	SELECT * FROM CLIENTES
CREATE PROCEDURE SP_BAJA_CLIENTE
@ID INT
AS
   BEGIN
   DELETE CLIENTES
   WHERE id_cliente=@ID
END

CREATE PROCEDURE SP_CONSULTAR_POR_CLIENTE
@ID INT 
AS  
   BEGIN
   SELECT *
   FROM CLIENTES
   WHERE id_cliente=@ID
END

CREATE PROCEDURE SP_CONSULTAR_CLIENTES
AS 
   BEGIN
   SELECT id_cliente,nombre,apellido,calle,altura
   FROM CLIENTES
END

------SP FACTURAS-------
CREATE PROCEDURE SP_ALTA_ARTICULO
@nombre varchar (100),
@precio_unitario decimal(18,2)
as 
  begin 
  insert into ARTICULOS (nombre,precio_unitario)
  values (@nombre,@precio_unitario)
  end

  CREATE PROCEDURE SP_CONSULTAR_ARTICULOS
  AS
  BEGIN
  select id_articulo,nombre,precio_unitario from ARTICULOS
  END

  ----INSERTS DE PRUEBA---
  INSERT INTO FORMAS_PAGOS(nombre)
  VALUES('EFECTIVO')
  INSERT INTO FORMAS_PAGOS(nombre)
  VALUES ('TARJETA CREDITO')
  INSERT INTO FORMAS_PAGOS(nombre)
  VALUES ('TARJETA DEBITO')

  --SP_FORMAS_PAGO--
  CREATE PROCEDURE SP_OBTENER_FORMAPAGO
  AS
  BEGIN
     SELECT id_forma_pago,nombre
	 FROM FORMAS_PAGOS
	 END
	 --SP_MAESTRO--
CREATE PROCEDURE SP_INSERTAR_MAESTRO
@forma_pago int ,
@cliente int,
@nro_factura INT OUTPUT
AS 
  BEGIN 
   INSERT INTO FACTURAS(fecha,forma_pago,cliente) VALUEs(Getdate(),@forma_pago,@cliente)
   SET @nro_factura=SCOPE_IDENTITY();
END
GO
	 ---SP_DETALLE---
create PROCEDURE SP_INSERTAR_DETALLES
@id_detalle int ,
@id int ,
@articulo int ,
@cantidad int 
AS 
BEGIN 
     INSERT INTO DETALLES_FACTURAS(id_detalle,nro_factura,articulo,cantdad)
	 VALUES(@id_detalle,@id,@articulo,@cantidad)
 END

 --SP_OBTENER_FACTURA
CREATE PROCEDURE SP_OBTENER_FACTURA
 AS 
  BEGIN 
 SELECT F.nro_factura 'FACTURA',
 F.fecha 'FECHA',
  FP.nombre 'FORMA_PAGO',
  C.nombre 'CLIENTE'
  FROM FACTURAS F
  JOIN CLIENTES C ON C.id_cliente=F.cliente
  JOIN FORMAS_PAGOS FP ON FP.id_forma_pago=F.forma_pago
  END

   CREATE PROCEDURE SP_OBTENER_DETALLE
 AS 
  BEGIN 
  SELECT DF.id_detalle 'DETALLE',
  F.nro_factura 'IDFD',
  A.nombre 'ARTICULO'
  FROM FACTURAS F
  JOIN DETALLES_FACTURAS DF ON DF.nro_factura=F.nro_factura
  JOIN ARTICULOS A ON A.id_articulo=DF.articulo
  END



  create procedure SP_Prueba
  as 
   begin 
   select nro_factura,fecha,forma_pago,cliente
   from FACTURAS
   end
 insert into FACTURAS(fecha,forma_pago,cliente) VALUES(GETDATE(),2,'ksk')
 select* from FACTURAS

