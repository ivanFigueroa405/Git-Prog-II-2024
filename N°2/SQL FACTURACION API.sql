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
ALTER PROCEDURE SP_ALTA_ARTICULO
@id int,
@nombre varchar (100),
@precio_unitario decimal(18,2),
@activo bit
as 
  begin 
  IF exists(SELECT id_articulo from ARTICULOS where id_articulo=@id)
  begin
   UPDATE ARTICULOS
  SET nombre=@nombre,precio_unitario=@precio_unitario,activo=@activo
  WHERE id_articulo=@id
  end
  ELSE
  BEGIN
  insert into ARTICULOS (nombre,precio_unitario,activo)
  values (@nombre,@precio_unitario,@activo)
  END
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
 
