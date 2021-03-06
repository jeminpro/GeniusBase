USE [master]
GO
/****** Object:  Database [GeniusBase]    Script Date: 30/08/2018 22:49:08 ******/
CREATE DATABASE [GeniusBase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GeniusBase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\GeniusBase.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GeniusBase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\GeniusBase_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [GeniusBase] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GeniusBase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GeniusBase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GeniusBase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GeniusBase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GeniusBase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GeniusBase] SET ARITHABORT OFF 
GO
ALTER DATABASE [GeniusBase] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [GeniusBase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GeniusBase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GeniusBase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GeniusBase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GeniusBase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GeniusBase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GeniusBase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GeniusBase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GeniusBase] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GeniusBase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GeniusBase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GeniusBase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GeniusBase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GeniusBase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GeniusBase] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [GeniusBase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GeniusBase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GeniusBase] SET  MULTI_USER 
GO
ALTER DATABASE [GeniusBase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GeniusBase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GeniusBase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GeniusBase] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [GeniusBase] SET DELAYED_DURABILITY = DISABLED 
GO
USE [GeniusBase]
GO
/****** Object:  Schema [post]    Script Date: 30/08/2018 22:49:08 ******/
CREATE SCHEMA [post]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 30/08/2018 22:49:08 ******/
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
/****** Object:  Table [post].[Article]    Script Date: 30/08/2018 22:49:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [post].[Article](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedOn] [datetime2](7) NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[UrlIdentifier] [nvarchar](200) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[PlainContent] [nvarchar](max) NULL,
	[IsDraft] [bit] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Views] [int] NOT NULL,
	[FirstPublishedDate] [datetime2](7) NOT NULL,
	[ArchivedDate] [datetime2](7) NOT NULL,
	[ArticleTagId] [int] NULL,
 CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [post].[ArticleHistory]    Script Date: 30/08/2018 22:49:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [post].[ArticleHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedOn] [datetime2](7) NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ArticleId] [int] NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[CategoryId] [int] NOT NULL,
	[IsDraft] [bit] NOT NULL,
 CONSTRAINT [PK_ArticleHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [post].[ArticleTag]    Script Date: 30/08/2018 22:49:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [post].[ArticleTag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedOn] [datetime2](7) NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ArticleId] [int] NOT NULL,
	[TagId] [int] NOT NULL,
 CONSTRAINT [PK_ArticleTag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [post].[Category]    Script Date: 30/08/2018 22:49:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [post].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedOn] [datetime2](7) NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[CategoryName] [nvarchar](30) NOT NULL,
	[CategoryIdentifier] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [post].[Tag]    Script Date: 30/08/2018 22:49:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [post].[Tag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedOn] [datetime2](7) NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[TagName] [nvarchar](30) NOT NULL,
	[ArticleHistoryId] [int] NULL,
	[ArticleId] [int] NULL,
 CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_Article_ArticleTagId]    Script Date: 30/08/2018 22:49:09 ******/
CREATE NONCLUSTERED INDEX [IX_Article_ArticleTagId] ON [post].[Article]
(
	[ArticleTagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Article_CategoryId]    Script Date: 30/08/2018 22:49:09 ******/
CREATE NONCLUSTERED INDEX [IX_Article_CategoryId] ON [post].[Article]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Article_UrlIdentifier]    Script Date: 30/08/2018 22:49:09 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Article_UrlIdentifier] ON [post].[Article]
(
	[UrlIdentifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ArticleHistory_CategoryId]    Script Date: 30/08/2018 22:49:09 ******/
CREATE NONCLUSTERED INDEX [IX_ArticleHistory_CategoryId] ON [post].[ArticleHistory]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ArticleTag_ArticleId]    Script Date: 30/08/2018 22:49:09 ******/
CREATE NONCLUSTERED INDEX [IX_ArticleTag_ArticleId] ON [post].[ArticleTag]
(
	[ArticleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ArticleTag_TagId]    Script Date: 30/08/2018 22:49:09 ******/
CREATE NONCLUSTERED INDEX [IX_ArticleTag_TagId] ON [post].[ArticleTag]
(
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Category_CategoryIdentifier]    Script Date: 30/08/2018 22:49:09 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Category_CategoryIdentifier] ON [post].[Category]
(
	[CategoryIdentifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tag_ArticleHistoryId]    Script Date: 30/08/2018 22:49:09 ******/
CREATE NONCLUSTERED INDEX [IX_Tag_ArticleHistoryId] ON [post].[Tag]
(
	[ArticleHistoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tag_ArticleId]    Script Date: 30/08/2018 22:49:09 ******/
CREATE NONCLUSTERED INDEX [IX_Tag_ArticleId] ON [post].[Tag]
(
	[ArticleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [post].[Article]  WITH CHECK ADD  CONSTRAINT [FK_Article_ArticleTag_ArticleTagId] FOREIGN KEY([ArticleTagId])
REFERENCES [post].[ArticleTag] ([Id])
GO
ALTER TABLE [post].[Article] CHECK CONSTRAINT [FK_Article_ArticleTag_ArticleTagId]
GO
ALTER TABLE [post].[Article]  WITH CHECK ADD  CONSTRAINT [FK_Article_Category_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [post].[Category] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [post].[Article] CHECK CONSTRAINT [FK_Article_Category_CategoryId]
GO
ALTER TABLE [post].[ArticleHistory]  WITH CHECK ADD  CONSTRAINT [FK_ArticleHistory_Category_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [post].[Category] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [post].[ArticleHistory] CHECK CONSTRAINT [FK_ArticleHistory_Category_CategoryId]
GO
ALTER TABLE [post].[ArticleTag]  WITH CHECK ADD  CONSTRAINT [FK_ArticleTag_Article_ArticleId] FOREIGN KEY([ArticleId])
REFERENCES [post].[Article] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [post].[ArticleTag] CHECK CONSTRAINT [FK_ArticleTag_Article_ArticleId]
GO
ALTER TABLE [post].[ArticleTag]  WITH CHECK ADD  CONSTRAINT [FK_ArticleTag_Tag_TagId] FOREIGN KEY([TagId])
REFERENCES [post].[Tag] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [post].[ArticleTag] CHECK CONSTRAINT [FK_ArticleTag_Tag_TagId]
GO
ALTER TABLE [post].[Tag]  WITH CHECK ADD  CONSTRAINT [FK_Tag_Article_ArticleId] FOREIGN KEY([ArticleId])
REFERENCES [post].[Article] ([Id])
GO
ALTER TABLE [post].[Tag] CHECK CONSTRAINT [FK_Tag_Article_ArticleId]
GO
ALTER TABLE [post].[Tag]  WITH CHECK ADD  CONSTRAINT [FK_Tag_ArticleHistory_ArticleHistoryId] FOREIGN KEY([ArticleHistoryId])
REFERENCES [post].[ArticleHistory] ([Id])
GO
ALTER TABLE [post].[Tag] CHECK CONSTRAINT [FK_Tag_ArticleHistory_ArticleHistoryId]
GO
USE [master]
GO
ALTER DATABASE [GeniusBase] SET  READ_WRITE 
GO
