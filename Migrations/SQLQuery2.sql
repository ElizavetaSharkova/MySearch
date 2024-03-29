USE [master]
GO
/****** Object:  Database [MySearch]    Script Date: 12.09.2019 8:15:03 ******/
CREATE DATABASE [MySearch]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MySearch', FILENAME = N'C:\Users\shark\MySearch.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MySearch_log', FILENAME = N'C:\Users\shark\MySearch_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MySearch] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MySearch].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MySearch] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MySearch] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MySearch] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MySearch] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MySearch] SET ARITHABORT OFF 
GO
ALTER DATABASE [MySearch] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MySearch] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MySearch] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MySearch] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MySearch] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MySearch] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MySearch] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MySearch] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MySearch] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MySearch] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MySearch] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MySearch] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MySearch] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MySearch] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MySearch] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MySearch] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [MySearch] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MySearch] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MySearch] SET  MULTI_USER 
GO
ALTER DATABASE [MySearch] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MySearch] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MySearch] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MySearch] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MySearch] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MySearch] SET QUERY_STORE = OFF
GO
USE [MySearch]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [MySearch]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12.09.2019 8:15:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestHeaders]    Script Date: 12.09.2019 8:15:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestHeaders](
	[RequestHeaderId] [int] IDENTITY(1,1) NOT NULL,
	[HeaderName] [nvarchar](max) NULL,
	[HeaderValue] [nvarchar](max) NULL,
	[engineSearchEngineId] [int] NULL,
 CONSTRAINT [PK_RequestHeaders] PRIMARY KEY CLUSTERED 
(
	[RequestHeaderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestsParameters]    Script Date: 12.09.2019 8:15:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestsParameters](
	[RequestsParameterId] [int] IDENTITY(1,1) NOT NULL,
	[ParametrName] [nvarchar](max) NULL,
	[ParametrValue] [nvarchar](max) NULL,
	[engineSearchEngineId] [int] NULL,
 CONSTRAINT [PK_RequestsParameters] PRIMARY KEY CLUSTERED 
(
	[RequestsParameterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResponseTypes]    Script Date: 12.09.2019 8:15:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResponseTypes](
	[ResponseTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](max) NULL,
	[RootElementPath] [nvarchar](max) NULL,
	[TitleElement] [nvarchar](max) NULL,
	[DescriptionElement] [nvarchar](max) NULL,
	[UrlElement] [nvarchar](max) NULL,
	[DateElement] [nvarchar](max) NULL,
 CONSTRAINT [PK_ResponseTypes] PRIMARY KEY CLUSTERED 
(
	[ResponseTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SearchEngines]    Script Date: 12.09.2019 8:15:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SearchEngines](
	[SearchEngineId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[BaseUrl] [nvarchar](max) NULL,
	[TypeResponseTypeId] [int] NULL,
	[IsDisable] [bit] NOT NULL,
 CONSTRAINT [PK_SearchEngines] PRIMARY KEY CLUSTERED 
(
	[SearchEngineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SearchRequests]    Script Date: 12.09.2019 8:15:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SearchRequests](
	[SearchRequestId] [int] IDENTITY(1,1) NOT NULL,
	[SearchString] [nvarchar](max) NULL,
	[SearchDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_SearchRequests] PRIMARY KEY CLUSTERED 
(
	[SearchRequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SearchResults]    Script Date: 12.09.2019 8:15:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SearchResults](
	[SearchResultId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Url] [nvarchar](max) NULL,
	[IndexedTime] [datetime2](7) NULL,
	[RequestSearchRequestId] [int] NULL,
	[SearchEngineId] [int] NULL,
 CONSTRAINT [PK_SearchResults] PRIMARY KEY CLUSTERED 
(
	[SearchResultId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_RequestHeaders_engineSearchEngineId]    Script Date: 12.09.2019 8:15:03 ******/
CREATE NONCLUSTERED INDEX [IX_RequestHeaders_engineSearchEngineId] ON [dbo].[RequestHeaders]
(
	[engineSearchEngineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RequestsParameters_engineSearchEngineId]    Script Date: 12.09.2019 8:15:03 ******/
CREATE NONCLUSTERED INDEX [IX_RequestsParameters_engineSearchEngineId] ON [dbo].[RequestsParameters]
(
	[engineSearchEngineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SearchEngines_TypeResponseTypeId]    Script Date: 12.09.2019 8:15:03 ******/
CREATE NONCLUSTERED INDEX [IX_SearchEngines_TypeResponseTypeId] ON [dbo].[SearchEngines]
(
	[TypeResponseTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SearchResults_RequestSearchRequestId]    Script Date: 12.09.2019 8:15:03 ******/
CREATE NONCLUSTERED INDEX [IX_SearchResults_RequestSearchRequestId] ON [dbo].[SearchResults]
(
	[RequestSearchRequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SearchResults_SearchEngineId]    Script Date: 12.09.2019 8:15:03 ******/
CREATE NONCLUSTERED INDEX [IX_SearchResults_SearchEngineId] ON [dbo].[SearchResults]
(
	[SearchEngineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SearchEngines] ADD  DEFAULT ((0)) FOR [IsDisable]
GO
ALTER TABLE [dbo].[RequestHeaders]  WITH CHECK ADD  CONSTRAINT [FK_RequestHeaders_SearchEngines_engineSearchEngineId] FOREIGN KEY([engineSearchEngineId])
REFERENCES [dbo].[SearchEngines] ([SearchEngineId])
GO
ALTER TABLE [dbo].[RequestHeaders] CHECK CONSTRAINT [FK_RequestHeaders_SearchEngines_engineSearchEngineId]
GO
ALTER TABLE [dbo].[RequestsParameters]  WITH CHECK ADD  CONSTRAINT [FK_RequestsParameters_SearchEngines_engineSearchEngineId] FOREIGN KEY([engineSearchEngineId])
REFERENCES [dbo].[SearchEngines] ([SearchEngineId])
GO
ALTER TABLE [dbo].[RequestsParameters] CHECK CONSTRAINT [FK_RequestsParameters_SearchEngines_engineSearchEngineId]
GO
ALTER TABLE [dbo].[SearchEngines]  WITH CHECK ADD  CONSTRAINT [FK_SearchEngines_ResponseTypes_TypeResponseTypeId] FOREIGN KEY([TypeResponseTypeId])
REFERENCES [dbo].[ResponseTypes] ([ResponseTypeId])
GO
ALTER TABLE [dbo].[SearchEngines] CHECK CONSTRAINT [FK_SearchEngines_ResponseTypes_TypeResponseTypeId]
GO
ALTER TABLE [dbo].[SearchResults]  WITH CHECK ADD  CONSTRAINT [FK_SearchResults_SearchEngines_SearchEngineId] FOREIGN KEY([SearchEngineId])
REFERENCES [dbo].[SearchEngines] ([SearchEngineId])
GO
ALTER TABLE [dbo].[SearchResults] CHECK CONSTRAINT [FK_SearchResults_SearchEngines_SearchEngineId]
GO
ALTER TABLE [dbo].[SearchResults]  WITH CHECK ADD  CONSTRAINT [FK_SearchResults_SearchRequests_RequestSearchRequestId] FOREIGN KEY([RequestSearchRequestId])
REFERENCES [dbo].[SearchRequests] ([SearchRequestId])
GO
ALTER TABLE [dbo].[SearchResults] CHECK CONSTRAINT [FK_SearchResults_SearchRequests_RequestSearchRequestId]
GO
USE [master]
GO
ALTER DATABASE [MySearch] SET  READ_WRITE 
GO
