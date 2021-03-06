USE [master]
GO
/****** Object:  Database [spa]    Script Date: 8/09/2021 12:26:04 p. m. ******/
CREATE DATABASE [spa]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'spa', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\spa.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'spa_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\spa_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [spa] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [spa].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [spa] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [spa] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [spa] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [spa] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [spa] SET ARITHABORT OFF 
GO
ALTER DATABASE [spa] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [spa] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [spa] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [spa] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [spa] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [spa] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [spa] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [spa] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [spa] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [spa] SET  DISABLE_BROKER 
GO
ALTER DATABASE [spa] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [spa] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [spa] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [spa] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [spa] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [spa] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [spa] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [spa] SET RECOVERY FULL 
GO
ALTER DATABASE [spa] SET  MULTI_USER 
GO
ALTER DATABASE [spa] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [spa] SET DB_CHAINING OFF 
GO
ALTER DATABASE [spa] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [spa] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [spa] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [spa] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'spa', N'ON'
GO
ALTER DATABASE [spa] SET QUERY_STORE = OFF
GO
USE [spa]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 8/09/2021 12:26:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Cod_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[Fecha_Nacimiento] [smalldatetime] NULL,
	[Foto] [varchar](50) NULL,
	[Estado_Civil] [int] NULL,
	[Tiene_Hermanos] [tinyint] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Cod_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[usp_Usuario]    Script Date: 8/09/2021 12:26:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_Usuario]
/*
Creado por: Jaime Andres Ruiz
Fecha creación: 18 de febrero de 2010
Objetivo: interactua con la base de datos central que quedo en dbserver-nal
*/

@opcion tinyint = null,
@Cod_Usuario int = null,
@Nombre varchar(80) = null,
@Apellido varchar(80) = null,
@Fecha_Nacimiento smalldatetime = null,
@Estado_Civil tinyint = null,
@Tiene_Hermanos tinyint = null,
@Foto varchar(20) = null

as

if (@opcion =1)
	begin
		
		SELECT Nombre,Apellido,Fecha_Nacimiento,Estado_Civil,Tiene_Hermanos,Foto 
		FROM Usuario
		ORDER BY Nombre
	end
else
if (@opcion =2)
	begin
		SELECT Nombre,Apellido,Fecha_Nacimiento,Estado_Civil,Tiene_Hermanos,Foto 
		FROM Usuario
		where Cod_Usuario=@Cod_Usuario
	end
else
if (@opcion =3)
	begin
		INSERT INTO Usuario (Nombre,Apellido,Fecha_Nacimiento,Estado_Civil,Tiene_Hermanos,Foto) 
		VALUES (@Nombre,@Apellido,@Fecha_Nacimiento,@Estado_Civil,@Tiene_Hermanos,@Foto)
	end
else
if (@opcion =4)
	begin
		UPDATE Usuario 
		SET Nombre=@Nombre,
		Apellido=@Apellido,
		Fecha_Nacimiento=@Fecha_Nacimiento,
		Estado_Civil=@Estado_Civil,
		Tiene_Hermanos=@Tiene_Hermanos
		WHERE Cod_Usuario=@Cod_Usuario
	end
GO
USE [master]
GO
ALTER DATABASE [spa] SET  READ_WRITE 
GO
