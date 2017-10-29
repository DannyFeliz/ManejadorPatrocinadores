USE [ManejadorPatrocinadores]
GO
/****** Object:  Table [dbo].[cadenas_programas_radio]    Script Date: 29/10/2017 04:16:05 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cadenas_programas_radio](
	[id] [int] NOT NULL,
	[programa_radio] [int] NOT NULL,
	[cadena_radio] [int] NOT NULL,
 CONSTRAINT [PK_cadena_programa_radio] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[cadenas_radio]    Script Date: 29/10/2017 04:16:05 p.m. ******/
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
 CONSTRAINT [PK_cadena_radio] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[directores]    Script Date: 29/10/2017 04:16:05 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[directores](
	[id] [int] NOT NULL,
	[nombre] [varchar](75) NOT NULL,
 CONSTRAINT [PK_directores] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[emisoras_radio]    Script Date: 29/10/2017 04:16:05 p.m. ******/
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
/****** Object:  Table [dbo].[empresas_medios]    Script Date: 29/10/2017 04:16:05 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[empresas_medios](
	[nif] [int] NOT NULL,
	[nombre] [varchar](75) NOT NULL,
	[direccion_postal] [varchar](100) NOT NULL,
	[director] [varchar](50) NOT NULL,
 CONSTRAINT [PK_empresa_medios] PRIMARY KEY CLUSTERED 
(
	[nif] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[patrocinadores]    Script Date: 29/10/2017 04:16:05 p.m. ******/
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
/****** Object:  Table [dbo].[programas_radio]    Script Date: 29/10/2017 04:16:05 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[programas_radio](
	[nif] [int] NOT NULL,
	[nombre] [varchar](75) NOT NULL,
	[encargado] [varchar](45) NOT NULL,
 CONSTRAINT [PK_programa_radio] PRIMARY KEY CLUSTERED 
(
	[nif] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[publicidades]    Script Date: 29/10/2017 04:16:05 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[insertar_emisora_radio]    Script Date: 29/10/2017 04:16:05 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[lista_emisoras_radios]    Script Date: 29/10/2017 04:16:05 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[lista_emisoras_radios] AS
	SELECT [nfi]
		  ,[nombre]
		  ,[direccion_postal]
		  ,[director]
		  ,[banda_hertziana]
		  ,[provincia]
	  FROM [ManejadorPatrocinadores].[dbo].[emisoras_radio];
GO
