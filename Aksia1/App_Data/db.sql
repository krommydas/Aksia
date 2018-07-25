USE [master]
GO
/****** Object:  Database [Aksia]    Script Date: 31/5/2018 1:43:47 μμ ******/
CREATE DATABASE [Aksia]
 CONTAINMENT = NONE
GO
ALTER DATABASE [Aksia] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Aksia].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Aksia] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Aksia] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Aksia] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Aksia] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Aksia] SET ARITHABORT OFF 
GO
ALTER DATABASE [Aksia] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Aksia] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Aksia] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Aksia] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Aksia] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Aksia] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Aksia] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Aksia] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Aksia] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Aksia] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Aksia] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Aksia] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Aksia] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Aksia] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Aksia] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Aksia] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Aksia] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Aksia] SET RECOVERY FULL 
GO
ALTER DATABASE [Aksia] SET  MULTI_USER 
GO
ALTER DATABASE [Aksia] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Aksia] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Aksia] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Aksia] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Aksia] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Aksia', N'ON'
GO
ALTER DATABASE [Aksia] SET QUERY_STORE = OFF
GO
USE [Aksia]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Aksia]
GO
/****** Object:  Table [dbo].[Adress]    Script Date: 31/5/2018 1:43:47 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adress](
	[ID] [uniqueidentifier] NOT NULL,
	[UserID] [uniqueidentifier] NOT NULL,
	[Country] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[PostalCode] [varchar](50) NULL,
	[Street] [varchar](50) NULL,
	[Number] [varchar](10) NULL,
 CONSTRAINT [PK_Adress] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 31/5/2018 1:43:48 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [varchar](100) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Adress]  WITH CHECK ADD  CONSTRAINT [FK_Adress_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Adress] CHECK CONSTRAINT [FK_Adress_User]
GO
USE [master]
GO
ALTER DATABASE [Aksia] SET  READ_WRITE 
GO
