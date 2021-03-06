USE [ManejadorPatrocinadores]
GO
/****** Object:  Table [dbo].[cadenas_programas_radio]    Script Date: 02/11/2017 05:34:42 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cadenas_programas_radio](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[programa_radio] [int] NOT NULL,
	[cadena_radio] [int] NOT NULL,
 CONSTRAINT [PK_cadena_programa_radio] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[cadenas_radio]    Script Date: 02/11/2017 05:34:42 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cadenas_radio](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre_representativo] [varchar](70) NOT NULL,
	[sede_central] [int] NOT NULL,
	[director] [varchar](50) NOT NULL,
	[empresa_medios] [int] NOT NULL,
	[duracion] [varchar](50) NULL,
 CONSTRAINT [PK_cadena_radio] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[directores]    Script Date: 02/11/2017 05:34:42 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[directores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](75) NOT NULL,
 CONSTRAINT [PK_directores] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[emisoras_radio]    Script Date: 02/11/2017 05:34:42 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[emisoras_radio](
	[nfi] [int] NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[direccion_postal] [varchar](100) NOT NULL,
	[director] [varchar](50) NOT NULL,
	[banda_hertziana] [varchar](50) NOT NULL,
	[provincia] [varchar](75) NOT NULL,
 CONSTRAINT [PK_emisora_radio] PRIMARY KEY CLUSTERED 
(
	[nfi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[empresas_medios]    Script Date: 02/11/2017 05:34:42 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[empresas_medios](
	[nif] [int] NOT NULL,
	[nombre] [varchar](75) NOT NULL,
	[direccion_postal] [varchar](100) NOT NULL,
	[director] [int] NOT NULL,
 CONSTRAINT [PK_empresa_medios] PRIMARY KEY CLUSTERED 
(
	[nif] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[patrocinadores]    Script Date: 02/11/2017 05:34:42 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[patrocinadores](
	[numero_contrato] [int] NOT NULL,
	[nombre] [varchar](75) NOT NULL,
	[duracion_contrato] [int] NOT NULL,
	[importe_contrato] [decimal](9, 2) NOT NULL,
 CONSTRAINT [PK_patrocinador] PRIMARY KEY CLUSTERED 
(
	[numero_contrato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[programas_radio]    Script Date: 02/11/2017 05:34:42 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[programas_radio](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](75) NOT NULL,
	[encargado] [varchar](45) NOT NULL,
	[dia] [int] NOT NULL,
	[hora_inicio] [time](7) NOT NULL,
	[hora_fin] [time](7) NULL,
 CONSTRAINT [PK_programa_radio] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[publicidades]    Script Date: 02/11/2017 05:34:42 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[publicidades](
	[id] [int] NOT NULL,
	[programa_radio] [int] NOT NULL,
	[segundos] [int] NOT NULL,
	[patrocinador] [int] NOT NULL,
	[precio_segundo] [decimal](9, 2) NOT NULL,
	[costo] [decimal](9, 2) NOT NULL,
 CONSTRAINT [PK_publicidad] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  StoredProcedure [dbo].[insertar_cadena_radio]    Script Date: 02/11/2017 05:34:42 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Script for SelectTopNRows command from SSMS  ******/



CREATE PROCEDURE [dbo].[insertar_cadena_radio]
	@nombre_representativo varchar(70), @sede_central int, @director varchar(50), @empresa_medios int, @duracion varchar(50)
	AS
	INSERT INTO cadenas_radio(nombre_representativo, sede_central, director, empresa_medios, duracion) 
	output inserted.id
	VALUES(@nombre_representativo, @sede_central, @director, @empresa_medios, @duracion);

GO
/****** Object:  StoredProcedure [dbo].[insertar_cadenas_programas_radio]    Script Date: 02/11/2017 05:34:42 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/****** Script for SelectTopNRows command from SSMS  ******/



CREATE PROCEDURE [dbo].[insertar_cadenas_programas_radio]
	@programa_radio int, @cadena_radio int
	AS
	INSERT INTO cadenas_programas_radio(programa_radio, cadena_radio) 
	VALUES(@programa_radio, @cadena_radio);


GO
/****** Object:  StoredProcedure [dbo].[insertar_director]    Script Date: 02/11/2017 05:34:42 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/****** Script for SelectTopNRows command from SSMS  ******/



CREATE PROCEDURE [dbo].[insertar_director]
	@nombre varchar(75)
	AS
	INSERT INTO directores(nombre) 
	VALUES(@nombre);


GO
/****** Object:  StoredProcedure [dbo].[insertar_emisora_radio]    Script Date: 02/11/2017 05:34:42 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/



CREATE PROCEDURE [dbo].[insertar_emisora_radio]
	@nfi int, @nombre varchar(100), @direccion varchar(100), @director varchar(50), @banda varchar(50), @provincia varchar(75)  
	AS
	INSERT INTO emisoras_radio(nfi, nombre, direccion_postal, director, banda_hertziana, provincia) 
	VALUES(@nfi, @nombre, @direccion, @director, @banda, @provincia);
	

GO
/****** Object:  StoredProcedure [dbo].[insertar_empresa_medios]    Script Date: 02/11/2017 05:34:42 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/****** Script for SelectTopNRows command from SSMS  ******/



CREATE PROCEDURE [dbo].[insertar_empresa_medios]
	@nif int, @nombre varchar(75), @direccion_postal varchar(100), @director varchar(50)
	AS
	INSERT INTO empresas_medios(nif, nombre, direccion_postal, director) 
	VALUES(@nif, @nombre, @direccion_postal, @director);


GO
/****** Object:  StoredProcedure [dbo].[insertar_patrocinador]    Script Date: 02/11/2017 05:34:42 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertar_patrocinador]
	@numero_contrato int, @nombre varchar(100), @duracion_contrato int, @importe_contrato decimal(9,2) 
	AS
	INSERT INTO patrocinadores(numero_contrato, nombre, duracion_contrato, importe_contrato) 
	VALUES(@numero_contrato, @nombre, @duracion_contrato, @importe_contrato);

GO
/****** Object:  StoredProcedure [dbo].[insertar_programa_radio]    Script Date: 02/11/2017 05:34:42 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertar_programa_radio]
@dia int, @hora_inicio time(7), @hora_fin time(7), @nombre varchar(100), @responsable varchar(100)
AS
INSERT INTO programas_radio(dia, hora_inicio, hora_fin, nombre, encargado) 
VALUES(@dia, @hora_inicio, @hora_fin, @nombre, @responsable);

GO
/****** Object:  StoredProcedure [dbo].[insertar_publicidad]    Script Date: 02/11/2017 05:34:42 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertar_publicidad]
	@programa_radio int, @segundos int, @patrocinador int, @precio_segundo decimal(9,2), @costo decimal(9,2)
	AS
	INSERT INTO publicidades(programa_radio, segundos, patrocinador, precio_segundo, costo) 
	VALUES(@programa_radio, @segundos, @patrocinador, @precio_segundo, @costo);

GO
/****** Object:  StoredProcedure [dbo].[lista_cadenas_radios]    Script Date: 02/11/2017 05:34:42 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[lista_cadenas_radios] AS
SELECT c.id
      ,[nombre_representativo]
      ,[sede_central]
      ,d.id as director
	  ,d.nombre as director_nombre
      ,[empresa_medios]
	  ,e.nombre as sede_central_nombre
	  ,em.nombre as empresa_medios_nombre
	  ,c.duracion 
  FROM [ManejadorPatrocinadores].[dbo].[cadenas_radio] as c
  JOIN directores d on d.id = c.director
  JOIN emisoras_radio e on e.nfi = c.sede_central
  JOIN empresas_medios em on em.nif = c.empresa_medios;
GO
/****** Object:  StoredProcedure [dbo].[lista_directores]    Script Date: 02/11/2017 05:34:42 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[lista_directores] AS
	SELECT [id]
      ,[nombre]
  FROM [ManejadorPatrocinadores].[dbo].[directores]


GO
/****** Object:  StoredProcedure [dbo].[lista_directores_relaciones]    Script Date: 02/11/2017 05:34:42 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[lista_directores_relaciones] AS
	SELECT d.id, d.nombre, er.nombre as emisora_radio, cr.nombre_representativo as cadena_radio, em.nombre as empresa_medios
FROM directores d
LEFT OUTER JOIN emisoras_radio er on er.director = d.id
LEFT OUTER JOIN cadenas_radio cr on cr.director = d.id
LEFT OUTER JOIN empresas_medios em on em.director = d.id




GO
/****** Object:  StoredProcedure [dbo].[lista_emisoras_radios]    Script Date: 02/11/2017 05:34:42 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[lista_emisoras_radios] AS
	SELECT [nfi]
		  ,e.nombre
		  ,[direccion_postal]
		  ,[director]
		  ,d.nombre as nombre_director
		  ,[banda_hertziana]
		  ,[provincia]
	  FROM [ManejadorPatrocinadores].[dbo].[emisoras_radio] e
	  JOIN directores d on d.id = e.director
	  ;
GO
/****** Object:  StoredProcedure [dbo].[lista_empresas_medios]    Script Date: 02/11/2017 05:34:42 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[lista_empresas_medios] AS
	SELECT [nif]
      ,e.nombre
	  ,[direccion_postal]
	  ,[director]
	  , d.nombre as director_nombre
  FROM [ManejadorPatrocinadores].[dbo].[empresas_medios] e
  JOIN directores d on d.id = e.director;
  

GO
/****** Object:  StoredProcedure [dbo].[lista_patrocinadores]    Script Date: 02/11/2017 05:34:42 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[lista_patrocinadores] AS
	SELECT [numero_contrato]
		,[nombre]
		,duracion_contrato
		,importe_contrato
	FROM [ManejadorPatrocinadores].[dbo].[patrocinadores];


GO
/****** Object:  StoredProcedure [dbo].[lista_programa_radio]    Script Date: 02/11/2017 05:34:42 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[lista_programa_radio] AS
	SELECT [id]
		,[nombre]
		,encargado
		,dia
		,hora_inicio
		,hora_fin
	FROM [ManejadorPatrocinadores].[dbo].[programas_radio];

GO
/****** Object:  StoredProcedure [dbo].[lista_publicidad]    Script Date: 02/11/2017 05:34:42 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[lista_publicidad] AS
	SELECT [id]
		,[programa_radio]
		,[segundos]
		,patrocinador
		,precio_segundo
		,costo
	FROM [ManejadorPatrocinadores].[dbo].[publicidades];

GO
/****** Object:  StoredProcedure [dbo].[ultima_cadena_radio_id]    Script Date: 02/11/2017 05:34:42 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ultima_cadena_radio_id] as
	SELECT TOP (1) [id]
  FROM [ManejadorPatrocinadores].[dbo].[cadenas_radio]
  order by id desc
  ;
GO
