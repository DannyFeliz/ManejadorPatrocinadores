
CREATE PROCEDURE lista_emisoras_radios AS
	SELECT [nfi]
		  ,[nombre]
		  ,[direccion_postal]
		  ,[director]
		  ,[banda_hertziana]
		  ,[provincia]
	  FROM [ManejadorPatrocinadores].[dbo].[emisora_radio];


CREATE PROCEDURE insertar_emisora_radio
	@nfi int, @nombre varchar, @direccion varchar, @director varchar, @banda varchar, @provincia varchar
	AS
	INSERT INTO emisora_radio(nfi, nombre, direccion_postal, director, banda_hertziana, provincia) 
	VALUES(@nfi, @nombre, @direccion, @director, @banda, @provincia);
	