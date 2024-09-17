create  database FacturacionApi
go
use FacturacionApi
go
CREATE TABLE ARTICULOS
(id_articulo int identity(1,1),
nombre varchar (100)not null,
precio_unitario decimal(18,2),
activo bit
constraint pk_articulos primary key(id_articulo)
)
CREATE PROCEDURE SP_ALTA_ARTICULO
@id int,
@nombre varchar (100),
@precio_unitario decimal(18,2),
@activo bit
as 
  begin 
  insert into ARTICULOS (nombre,precio_unitario,activo)
  values (@nombre,@precio_unitario,@activo)
  END


alter PROCEDURE SP_CONSULTAR_ARTICULOS
  AS
  BEGIN
  select id_articulo,nombre,precio_unitario,activo from ARTICULOS
  END

  create procedure SP_ELIMINAR_ARTICULO
  @id int
  as
  begin 
  update ARTICULOS 
  SET activo=0
  WHERE id_articulo=@id
  end

 --EJECUTA UN BORRADO LOGICO

CREATE PROCEDURE SP_EDITAR_ARTICULO
 @id int,
@nombre varchar (100),
@precio_unitario decimal(18,2),
@activo bit
 AS
 BEGIN
   UPDATE ARTICULOS
  SET nombre=@nombre,precio_unitario=@precio_unitario,activo=@activo
  WHERE id_articulo=@id
  end
 
