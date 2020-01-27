USE [master]
GO
/****** Object:  Database [ATVAllowance]    Script Date: 27/01/2020 11:15:02 SA ******/
CREATE DATABASE [ATVAllowance]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ATVAllowance', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ATVAllowance.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ATVAllowance_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ATVAllowance_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ATVAllowance] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ATVAllowance].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ATVAllowance] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ATVAllowance] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ATVAllowance] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ATVAllowance] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ATVAllowance] SET ARITHABORT OFF 
GO
ALTER DATABASE [ATVAllowance] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ATVAllowance] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ATVAllowance] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ATVAllowance] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ATVAllowance] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ATVAllowance] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ATVAllowance] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ATVAllowance] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ATVAllowance] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ATVAllowance] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ATVAllowance] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ATVAllowance] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ATVAllowance] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ATVAllowance] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ATVAllowance] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ATVAllowance] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ATVAllowance] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ATVAllowance] SET RECOVERY FULL 
GO
ALTER DATABASE [ATVAllowance] SET  MULTI_USER 
GO
ALTER DATABASE [ATVAllowance] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ATVAllowance] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ATVAllowance] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ATVAllowance] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ATVAllowance] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ATVAllowance', N'ON'
GO
ALTER DATABASE [ATVAllowance] SET QUERY_STORE = OFF
GO
USE [ATVAllowance]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 27/01/2020 11:15:02 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Article]    Script Date: 27/01/2020 11:15:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Article](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](200) NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Date] [date] NOT NULL,
	[TypeId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Article] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArticleEmployee]    Script Date: 27/01/2020 11:15:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticleEmployee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArticleId] [int] NULL,
	[EmployeeId] [int] NULL,
 CONSTRAINT [PK_dbo.ArticleEmployee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArticlePointType]    Script Date: 27/01/2020 11:15:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticlePointType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArticleTypeId] [int] NOT NULL,
	[PointTypeId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ArticlePointType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArticleType]    Script Date: 27/01/2020 11:15:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticleType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Code] [varchar](10) NULL,
 CONSTRAINT [PK_dbo.ArticleType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BusinessLog]    Script Date: 27/01/2020 11:15:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[ActorId] [int] NOT NULL,
	[Type] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NOT NULL,
	[LoggedOnDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.BusinessLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Configuration]    Script Date: 27/01/2020 11:15:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Configuration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Month] [int] NULL,
	[Year] [int] NULL,
 CONSTRAINT [PK_dbo.Configuration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Criteria]    Script Date: 27/01/2020 11:15:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Criteria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[ArticleTypeId] [int] NULL,
	[Unit] [int] NULL,
 CONSTRAINT [PK_dbo.Criteria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CriteriaValue]    Script Date: 27/01/2020 11:15:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CriteriaValue](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CriteriaId] [int] NULL,
	[Value] [float] NULL,
	[Unit] [int] NULL,
	[ConfigurationId] [int] NULL,
 CONSTRAINT [PK_dbo.CriteriaValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Deduction]    Script Date: 27/01/2020 11:15:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deduction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Month] [int] NULL,
	[Year] [int] NULL,
	[DeductionTypeId] [int] NULL,
	[EmployeeId] [int] NULL,
	[ArticleTypeId] [int] NULL,
 CONSTRAINT [PK_dbo.Deduction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeductionType]    Script Date: 27/01/2020 11:15:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeductionType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](20) NULL,
	[Amount] [float] NULL,
 CONSTRAINT [PK_dbo.DeductionType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 27/01/2020 11:15:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NULL,
	[Name] [nvarchar](max) NULL,
	[RoleId] [int] NULL,
	[OrganizationId] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[Title] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuItem]    Script Date: 27/01/2020 11:15:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Level] [int] NOT NULL,
	[ParentName] [nvarchar](30) NULL,
	[Order] [int] NOT NULL,
 CONSTRAINT [PK_dbo.MenuItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Organization]    Script Date: 27/01/2020 11:15:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organization](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_dbo.Organization] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Point]    Script Date: 27/01/2020 11:15:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Point](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArticleEmployeeId] [int] NULL,
	[Point] [int] NULL,
	[Type] [int] NULL,
 CONSTRAINT [PK_dbo.Point] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PointType]    Script Date: 27/01/2020 11:15:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PointType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Code] [varchar](50) NULL,
 CONSTRAINT [PK_dbo.PointType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 27/01/2020 11:15:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Code] [varchar](50) NULL,
 CONSTRAINT [PK_dbo.Position] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 27/01/2020 11:15:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_dbo.Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleHasMenuItem]    Script Date: 27/01/2020 11:15:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleHasMenuItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[MenuItemId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.RoleHasMenuItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemLog]    Script Date: 27/01/2020 11:15:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Caller] [nvarchar](max) NULL,
	[Level] [nvarchar](max) NULL,
	[Type] [nvarchar](max) NULL,
	[Message] [nvarchar](max) NULL,
	[StackTrace] [nvarchar](max) NULL,
	[InnerException] [nvarchar](max) NULL,
	[AdditionalInfo] [nvarchar](max) NULL,
	[LoggedOnDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.SystemLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 27/01/2020 11:15:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
	[Code] [nvarchar](6) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[LastLoginTime] [datetime] NULL,
	[CreateDate] [datetime] NULL,
	[LastUpdateDate] [datetime] NULL,
	[LastUpdateBy] [int] NULL,
 CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_TypeId]    Script Date: 27/01/2020 11:15:03 SA ******/
CREATE NONCLUSTERED INDEX [IX_TypeId] ON [dbo].[Article]
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ArticleId]    Script Date: 27/01/2020 11:15:03 SA ******/
CREATE NONCLUSTERED INDEX [IX_ArticleId] ON [dbo].[ArticleEmployee]
(
	[ArticleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeId]    Script Date: 27/01/2020 11:15:03 SA ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeId] ON [dbo].[ArticleEmployee]
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ArticleTypeId]    Script Date: 27/01/2020 11:15:03 SA ******/
CREATE NONCLUSTERED INDEX [IX_ArticleTypeId] ON [dbo].[ArticlePointType]
(
	[ArticleTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PointTypeId]    Script Date: 27/01/2020 11:15:03 SA ******/
CREATE NONCLUSTERED INDEX [IX_PointTypeId] ON [dbo].[ArticlePointType]
(
	[PointTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ArticleTypeId]    Script Date: 27/01/2020 11:15:03 SA ******/
CREATE NONCLUSTERED INDEX [IX_ArticleTypeId] ON [dbo].[Criteria]
(
	[ArticleTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ConfigurationId]    Script Date: 27/01/2020 11:15:03 SA ******/
CREATE NONCLUSTERED INDEX [IX_ConfigurationId] ON [dbo].[CriteriaValue]
(
	[ConfigurationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CriteriaId]    Script Date: 27/01/2020 11:15:03 SA ******/
CREATE NONCLUSTERED INDEX [IX_CriteriaId] ON [dbo].[CriteriaValue]
(
	[CriteriaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ArticleTypeId]    Script Date: 27/01/2020 11:15:03 SA ******/
CREATE NONCLUSTERED INDEX [IX_ArticleTypeId] ON [dbo].[Deduction]
(
	[ArticleTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DeductionTypeId]    Script Date: 27/01/2020 11:15:03 SA ******/
CREATE NONCLUSTERED INDEX [IX_DeductionTypeId] ON [dbo].[Deduction]
(
	[DeductionTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeId]    Script Date: 27/01/2020 11:15:03 SA ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeId] ON [dbo].[Deduction]
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrganizationId]    Script Date: 27/01/2020 11:15:03 SA ******/
CREATE NONCLUSTERED INDEX [IX_OrganizationId] ON [dbo].[Employee]
(
	[OrganizationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoleId]    Script Date: 27/01/2020 11:15:03 SA ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[Employee]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ArticleEmployeeId]    Script Date: 27/01/2020 11:15:03 SA ******/
CREATE NONCLUSTERED INDEX [IX_ArticleEmployeeId] ON [dbo].[Point]
(
	[ArticleEmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Type]    Script Date: 27/01/2020 11:15:03 SA ******/
CREATE NONCLUSTERED INDEX [IX_Type] ON [dbo].[Point]
(
	[Type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_MenuItemId]    Script Date: 27/01/2020 11:15:03 SA ******/
CREATE NONCLUSTERED INDEX [IX_MenuItemId] ON [dbo].[RoleHasMenuItem]
(
	[MenuItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoleId]    Script Date: 27/01/2020 11:15:03 SA ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[RoleHasMenuItem]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoleId]    Script Date: 27/01/2020 11:15:03 SA ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[User]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BusinessLog] ADD  DEFAULT (getutcdate()) FOR [LoggedOnDate]
GO
ALTER TABLE [dbo].[SystemLog] ADD  DEFAULT (getutcdate()) FOR [LoggedOnDate]
GO
ALTER TABLE [dbo].[Article]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Article_dbo.ArticleType_TypeId] FOREIGN KEY([TypeId])
REFERENCES [dbo].[ArticleType] ([Id])
GO
ALTER TABLE [dbo].[Article] CHECK CONSTRAINT [FK_dbo.Article_dbo.ArticleType_TypeId]
GO
ALTER TABLE [dbo].[ArticleEmployee]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ArticleEmployee_dbo.Article_ArticleId] FOREIGN KEY([ArticleId])
REFERENCES [dbo].[Article] ([Id])
GO
ALTER TABLE [dbo].[ArticleEmployee] CHECK CONSTRAINT [FK_dbo.ArticleEmployee_dbo.Article_ArticleId]
GO
ALTER TABLE [dbo].[ArticleEmployee]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ArticleEmployee_dbo.Employee_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[ArticleEmployee] CHECK CONSTRAINT [FK_dbo.ArticleEmployee_dbo.Employee_EmployeeId]
GO
ALTER TABLE [dbo].[ArticlePointType]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ArticlePointType_dbo.ArticleType_ArticleTypeId] FOREIGN KEY([ArticleTypeId])
REFERENCES [dbo].[ArticleType] ([Id])
GO
ALTER TABLE [dbo].[ArticlePointType] CHECK CONSTRAINT [FK_dbo.ArticlePointType_dbo.ArticleType_ArticleTypeId]
GO
ALTER TABLE [dbo].[ArticlePointType]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ArticlePointType_dbo.PointType_PointTypeId] FOREIGN KEY([PointTypeId])
REFERENCES [dbo].[PointType] ([Id])
GO
ALTER TABLE [dbo].[ArticlePointType] CHECK CONSTRAINT [FK_dbo.ArticlePointType_dbo.PointType_PointTypeId]
GO
ALTER TABLE [dbo].[Criteria]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Criteria_dbo.ArticleType_ArticleTypeId] FOREIGN KEY([ArticleTypeId])
REFERENCES [dbo].[ArticleType] ([Id])
GO
ALTER TABLE [dbo].[Criteria] CHECK CONSTRAINT [FK_dbo.Criteria_dbo.ArticleType_ArticleTypeId]
GO
ALTER TABLE [dbo].[CriteriaValue]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CriteriaValue_dbo.Configuration_ConfigurationId] FOREIGN KEY([ConfigurationId])
REFERENCES [dbo].[Configuration] ([Id])
GO
ALTER TABLE [dbo].[CriteriaValue] CHECK CONSTRAINT [FK_dbo.CriteriaValue_dbo.Configuration_ConfigurationId]
GO
ALTER TABLE [dbo].[CriteriaValue]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CriteriaValue_dbo.Criteria_CriteriaId] FOREIGN KEY([CriteriaId])
REFERENCES [dbo].[Criteria] ([Id])
GO
ALTER TABLE [dbo].[CriteriaValue] CHECK CONSTRAINT [FK_dbo.CriteriaValue_dbo.Criteria_CriteriaId]
GO
ALTER TABLE [dbo].[Deduction]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Deduction_dbo.ArticleType_ArticleTypeId] FOREIGN KEY([ArticleTypeId])
REFERENCES [dbo].[ArticleType] ([Id])
GO
ALTER TABLE [dbo].[Deduction] CHECK CONSTRAINT [FK_dbo.Deduction_dbo.ArticleType_ArticleTypeId]
GO
ALTER TABLE [dbo].[Deduction]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Deduction_dbo.DeductionType_DeductionTypeId] FOREIGN KEY([DeductionTypeId])
REFERENCES [dbo].[DeductionType] ([Id])
GO
ALTER TABLE [dbo].[Deduction] CHECK CONSTRAINT [FK_dbo.Deduction_dbo.DeductionType_DeductionTypeId]
GO
ALTER TABLE [dbo].[Deduction]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Deduction_dbo.Employee_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Deduction] CHECK CONSTRAINT [FK_dbo.Deduction_dbo.Employee_EmployeeId]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Employee_dbo.Organization_OrganizationId] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organization] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_dbo.Employee_dbo.Organization_OrganizationId]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Employee_dbo.Position_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Position] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_dbo.Employee_dbo.Position_RoleId]
GO
ALTER TABLE [dbo].[Point]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Point_dbo.ArticleEmployee_ArticleEmployeeId] FOREIGN KEY([ArticleEmployeeId])
REFERENCES [dbo].[ArticleEmployee] ([Id])
GO
ALTER TABLE [dbo].[Point] CHECK CONSTRAINT [FK_dbo.Point_dbo.ArticleEmployee_ArticleEmployeeId]
GO
ALTER TABLE [dbo].[Point]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Point_dbo.PointType_Type] FOREIGN KEY([Type])
REFERENCES [dbo].[PointType] ([Id])
GO
ALTER TABLE [dbo].[Point] CHECK CONSTRAINT [FK_dbo.Point_dbo.PointType_Type]
GO
ALTER TABLE [dbo].[RoleHasMenuItem]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RoleHasMenuItem_dbo.MenuItem_MenuItemId] FOREIGN KEY([MenuItemId])
REFERENCES [dbo].[MenuItem] ([Id])
GO
ALTER TABLE [dbo].[RoleHasMenuItem] CHECK CONSTRAINT [FK_dbo.RoleHasMenuItem_dbo.MenuItem_MenuItemId]
GO
ALTER TABLE [dbo].[RoleHasMenuItem]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RoleHasMenuItem_dbo.Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[RoleHasMenuItem] CHECK CONSTRAINT [FK_dbo.RoleHasMenuItem_dbo.Role_RoleId]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_dbo.User_dbo.Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_dbo.User_dbo.Role_RoleId]
GO
/****** Object:  StoredProcedure [dbo].[InsertBusinessLog]    Script Date: 27/01/2020 11:15:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertBusinessLog]
    @actorId [int],
    @message [nvarchar](max),
    @type [nvarchar](max),
    @status [nvarchar](max)
AS
BEGIN
    insert into [dbo].[BusinessLog]
    (
    	                    [ActorId],
    	                    [Message],
    	                    [Type],
    	                    [Status]
    )
    values
    (
    	                    @actorId,
    	                    @message,
    	                    @type,
    	                    @status
    )
END
GO
/****** Object:  StoredProcedure [dbo].[InsertSystemLog]    Script Date: 27/01/2020 11:15:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertSystemLog]
    @level [nvarchar](max),
    @caller [nvarchar](max),
    @type [nvarchar](max),
    @message [nvarchar](max),
    @stackTrace [nvarchar](max),
    @innerException [nvarchar](max),
    @additionalInfo [nvarchar](max)
AS
BEGIN
    insert into [dbo].[SystemLog]
    (
    	                    [Level],
    	                    [Caller],
    	                    [Type],
    	                    [Message],
    	                    [StackTrace],
    	                    [InnerException],
    	                    [AdditionalInfo]
    )
    values
    (
    	                    @level,
    	                    @caller,
    	                    @type,
    	                    @message,
    	                    @stackTrace,
    	                    @innerException,
    	                    @additionalInfo
    )
END
GO
USE [master]
GO
ALTER DATABASE [ATVAllowance] SET  READ_WRITE 
GO
