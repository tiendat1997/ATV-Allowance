USE [master]
GO
/****** Object:  Database [ATVAllowance]    Script Date: 05/10/2019 11:17:10 SA ******/
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
ALTER DATABASE [ATVAllowance] SET READ_COMMITTED_SNAPSHOT OFF 
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
/****** Object:  Table [dbo].[Article]    Script Date: 05/10/2019 11:17:11 SA ******/
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
 CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArticleEmployee]    Script Date: 05/10/2019 11:17:11 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticleEmployee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArticleId] [int] NULL,
	[EmployeeId] [int] NULL,
 CONSTRAINT [PK_ArticleEmployee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArticlePointType]    Script Date: 05/10/2019 11:17:11 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticlePointType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArticleTypeId] [int] NOT NULL,
	[PointTypeId] [int] NOT NULL,
 CONSTRAINT [PK_ArticlePointType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArticleType]    Script Date: 05/10/2019 11:17:11 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticleType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Code] [varchar](10) NULL,
 CONSTRAINT [PK_ArticleType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BusinessLog]    Script Date: 05/10/2019 11:17:11 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[ActorId] [int] NOT NULL,
	[TypeId] [int] NOT NULL,
 CONSTRAINT [PK_BusinessLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Configuration]    Script Date: 05/10/2019 11:17:11 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Configuration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Month] [int] NULL,
	[Year] [int] NULL,
 CONSTRAINT [PK_Configuration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Criteria]    Script Date: 05/10/2019 11:17:11 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Criteria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[ArticleTypeId] [int] NULL,
	[Unit] [int] NULL,
 CONSTRAINT [PK_Criteria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CriteriaValue]    Script Date: 05/10/2019 11:17:11 SA ******/
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
 CONSTRAINT [PK_CriteriaValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Deduction]    Script Date: 05/10/2019 11:17:11 SA ******/
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
 CONSTRAINT [PK_Deduction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeductionType]    Script Date: 05/10/2019 11:17:11 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeductionType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](20) NULL,
	[Amount] [float] NULL,
 CONSTRAINT [PK_DeductionType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 05/10/2019 11:17:11 SA ******/
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
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuItem]    Script Date: 05/10/2019 11:17:11 SA ******/
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
 CONSTRAINT [PK_MenuItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Organization]    Script Date: 05/10/2019 11:17:11 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organization](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Organization] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Point]    Script Date: 05/10/2019 11:17:11 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Point](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArticleEmployeeId] [int] NULL,
	[Point] [int] NULL,
	[Type] [int] NULL,
 CONSTRAINT [PK_Point] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PointType]    Script Date: 05/10/2019 11:17:11 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PointType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Code] [varchar](50) NULL,
 CONSTRAINT [PK_PointType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 05/10/2019 11:17:11 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Code] [varchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 05/10/2019 11:17:11 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Role_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleHasMenuItem]    Script Date: 05/10/2019 11:17:11 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleHasMenuItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[MenuItemId] [int] NOT NULL,
 CONSTRAINT [PK_RoleHasMenuItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemLog]    Script Date: 05/10/2019 11:17:11 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[Date] [datetime] NOT NULL,
	[TypeId] [int] NOT NULL,
 CONSTRAINT [PK_SystemLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 05/10/2019 11:17:11 SA ******/
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
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ArticlePointType] ON 

INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (8, 3, 1)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (9, 3, 2)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (10, 3, 3)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (11, 3, 4)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (12, 1, 1)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (13, 1, 5)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (14, 1, 6)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (15, 1, 7)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (16, 1, 8)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (17, 1, 9)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (18, 2, 1)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (19, 2, 10)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (20, 2, 11)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (21, 2, 5)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (22, 2, 12)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (23, 2, 13)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (24, 4, 1)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (25, 4, 2)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (26, 4, 3)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (27, 4, 4)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (28, 4, 14)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (29, 4, 15)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (30, 4, 14)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (31, 4, 15)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (32, 5, 16)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (33, 5, 17)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (34, 5, 18)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (35, 5, 19)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (36, 5, 20)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (37, 6, 21)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (38, 6, 22)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (39, 6, 23)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (40, 6, 24)
SET IDENTITY_INSERT [dbo].[ArticlePointType] OFF
SET IDENTITY_INSERT [dbo].[ArticleType] ON 

INSERT [dbo].[ArticleType] ([Id], [Name], [Code]) VALUES (1, N'Phát thanh', N'PT')
INSERT [dbo].[ArticleType] ([Id], [Name], [Code]) VALUES (2, N'Phát thanh trực tiếp', N'PTTT')
INSERT [dbo].[ArticleType] ([Id], [Name], [Code]) VALUES (3, N'Thời sự', N'TS')
INSERT [dbo].[ArticleType] ([Id], [Name], [Code]) VALUES (4, N'Thông tin ngày mới', N'TTNM')
INSERT [dbo].[ArticleType] ([Id], [Name], [Code]) VALUES (5, N'Biên soạn thông tin ngày mới', N'BS-TTNM')
INSERT [dbo].[ArticleType] ([Id], [Name], [Code]) VALUES (6, N'Khối hậu kỳ biên soạn thông tin ngày mới', N'HK-TTNM')
SET IDENTITY_INSERT [dbo].[ArticleType] OFF
SET IDENTITY_INSERT [dbo].[Configuration] ON 

INSERT [dbo].[Configuration] ([Id], [Month], [Year]) VALUES (3, 10, 2019)
INSERT [dbo].[Configuration] ([Id], [Month], [Year]) VALUES (4, 1, 2019)
INSERT [dbo].[Configuration] ([Id], [Month], [Year]) VALUES (5, 9, 2019)
SET IDENTITY_INSERT [dbo].[Configuration] OFF
SET IDENTITY_INSERT [dbo].[Criteria] ON 

INSERT [dbo].[Criteria] ([Id], [DisplayName], [ArticleTypeId], [Unit]) VALUES (1, N'Tăng (+) giảm (-) cho PV, BTV', 3, 1)
INSERT [dbo].[Criteria] ([Id], [DisplayName], [ArticleTypeId], [Unit]) VALUES (2, N'Tăng (+) giảm (-) cho CTV', 3, 1)
INSERT [dbo].[Criteria] ([Id], [DisplayName], [ArticleTypeId], [Unit]) VALUES (3, N'Biên tập CTTS', 3, 1)
INSERT [dbo].[Criteria] ([Id], [DisplayName], [ArticleTypeId], [Unit]) VALUES (4, N'Phát thanh viên', 3, 1)
INSERT [dbo].[Criteria] ([Id], [DisplayName], [ArticleTypeId], [Unit]) VALUES (5, N'Kỹ thuật dựng', 3, 1)
INSERT [dbo].[Criteria] ([Id], [DisplayName], [ArticleTypeId], [Unit]) VALUES (6, N'TP trực CTTS', 3, 2)
INSERT [dbo].[Criteria] ([Id], [DisplayName], [ArticleTypeId], [Unit]) VALUES (7, N'Phóng viên trực dựng', 3, 2)
INSERT [dbo].[Criteria] ([Id], [DisplayName], [ArticleTypeId], [Unit]) VALUES (8, N'Số ngày', 3, 5)
INSERT [dbo].[Criteria] ([Id], [DisplayName], [ArticleTypeId], [Unit]) VALUES (9, N'Khoản đánh máy vi tính', 3, 3)
INSERT [dbo].[Criteria] ([Id], [DisplayName], [ArticleTypeId], [Unit]) VALUES (10, N'với số tiền', 3, 4)
INSERT [dbo].[Criteria] ([Id], [DisplayName], [ArticleTypeId], [Unit]) VALUES (11, N'list', 3, 4)
SET IDENTITY_INSERT [dbo].[Criteria] OFF
SET IDENTITY_INSERT [dbo].[CriteriaValue] ON 

INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (145, 1, 20, NULL, 3)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (146, 2, 10, NULL, 3)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (147, 3, 10, NULL, 3)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (148, 4, 0, NULL, 3)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (149, 5, 0, NULL, 3)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (150, 6, 0, NULL, 3)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (151, 7, 0, NULL, 3)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (152, 8, 0, NULL, 3)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (153, 9, 2, NULL, 3)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (154, 10, 100000, NULL, 3)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (155, 11, 300000, NULL, 3)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (156, 1, 0, NULL, 4)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (157, 2, 0, NULL, 4)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (158, 3, 0, NULL, 4)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (159, 4, 0, NULL, 4)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (160, 5, 0, NULL, 4)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (161, 6, 0, NULL, 4)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (162, 7, 0, NULL, 4)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (163, 8, 0, NULL, 4)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (164, 9, 0, NULL, 4)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (165, 10, 0, NULL, 4)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (166, 11, 0, NULL, 4)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (167, 1, 10, NULL, 5)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (168, 2, 30, NULL, 5)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (169, 3, 15, NULL, 5)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (170, 4, 9, NULL, 5)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (171, 5, 9, NULL, 5)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (172, 6, 10.5, NULL, 5)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (173, 7, 7.5, NULL, 5)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (174, 8, 30, NULL, 5)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (175, 9, 1, NULL, 5)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (176, 10, 440, NULL, 5)
INSERT [dbo].[CriteriaValue] ([Id], [CriteriaId], [Value], [Unit], [ConfigurationId]) VALUES (177, 11, 330, NULL, 5)
SET IDENTITY_INSERT [dbo].[CriteriaValue] OFF
SET IDENTITY_INSERT [dbo].[DeductionType] ON 

INSERT [dbo].[DeductionType] ([Id], [Code], [Amount]) VALUES (1, N'None', 0)
INSERT [dbo].[DeductionType] ([Id], [Code], [Amount]) VALUES (2, N'A', 60)
INSERT [dbo].[DeductionType] ([Id], [Code], [Amount]) VALUES (3, N'B', 86)
SET IDENTITY_INSERT [dbo].[DeductionType] OFF
SET IDENTITY_INSERT [dbo].[MenuItem] ON 

INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (5, N'In ấn', 0, NULL, 2)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (6, N'In Thời sự', 1, N'In ấn', 0)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (7, N'In Phát thanh ', 1, N'In ấn', 1)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (8, N'In Phát thanh trực tiếp', 1, N'In ấn', 2)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (9, N'Quản lý chung', 0, NULL, 1)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (10, N'Quản lý nhân viên', 1, N'Quản lý chung', 1)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (11, N'Quản lý chỉ tiêu', 1, N'Quản lý chung', 2)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (12, N'Quản lý đơn vị', 1, N'Quản lý chung', 3)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (13, N'Quản lý loại tin', 1, N'Quản lý chung', 4)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (14, N'Quản lý giảm trừ', 1, N'Quản lý chung', 5)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (15, N'Nhập liệu', 0, NULL, 0)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (18, N'Nhập Tin thời sự hàng ngày', 1, N'Nhập liệu', 0)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (19, N'Nhập Tin, PS ttnm', 1, N'Nhập liệu', 1)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (20, N'Nhập Tin phát thanh', 1, N'Nhập liệu', 2)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (21, N'Nhập Tin phát thanh tt', 1, N'Nhập liệu', 3)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (22, N'Nhập Thù lao biên soạn tnnm', 1, N'Nhập liệu', 4)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (23, N'Xem nhanh tin', 1, N'Quản lý chung', 0)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (25, N'Nhập Khối hậu kỳ biên soạn tnnm', 1, N'Nhập liệu', 5)
SET IDENTITY_INSERT [dbo].[MenuItem] OFF
SET IDENTITY_INSERT [dbo].[Organization] ON 

INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (22, N'Phòng Phát Thanh', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (23, N'Phòng KTPT', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (24, N'Phòng Thời Sự', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (25, N'Phòng Dân Tộc', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (26, N'Phòng Phim Tài Liệu', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (27, N'Phòng Kinh Tế TPLX', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (28, N'Phòng Chuyên Mục và Khoa Giáo', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (29, N'Phòng Chuyên Mục', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (30, N'Phòng Văn Nghệ - TT', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (31, N'Phòng TCHC', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (32, N'Phòng Chương Trình', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (33, N'Phòng VN - Giải Trí', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (34, N'Phòng GD-ĐT Tân Châu', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (35, N'Sở GD-ĐT AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (36, N'Sở Công thương AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (37, N'Sở Y Tế AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (38, N'Sở NN&PTNT AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (39, N'Sở KH và CN tỉnh AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (40, N'Sở GTVT AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (41, N'Sở Công Thương', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (42, N'Sở Nội Vụ AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (43, N'Sở LĐTBXH AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (44, N'Sở TNMT AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (45, N'Sở VHTTDL AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (46, N'CC Đo lường chất lượng AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (47, N'CC Kiểm Lâm AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (48, N'CC QL ATVSTP AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (49, N'CC QL TT AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (50, N'CC BVTV AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (51, N'CC DS&KHHGD AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (52, N'Đài TT TP Long Xuyên', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (53, N'Đài TT Thoại Sơn', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (54, N'Đại TT An Phú', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (55, N'Đài TT Châu Thành', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (56, N'Đài TT TP Châu Đốc', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (57, N'Đài TT Tân Châu', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (58, N'Đài TT Phú Tân', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (59, N'Đài TT Chợ Mới', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (60, N'Đài Ba Tri - Bến Tre', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (61, N'Đài PTTH Cà Mau', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (62, N'Đài PTTH Lâm Đồng', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (63, N'Đài TT Tịnh Biên', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (64, N'Đài TH Cần Thơ', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (65, N'Đài TT Châu Phú', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (66, N'Đài TT Tịnh Biên', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (67, N'TT VH Thoại Sơn', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (68, N'TT GTVL AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (69, N'TT VH Châu Thành', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (70, N'TT VH TPLX', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (71, N'TT Xúc Tiến TM&ĐT', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (72, N'TT TT GDSK AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (73, N'TT VH tỉnh AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (74, N'TT Thành Ủy Long Xuyên', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (75, N'TT VH Phú Tân', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (76, N'TT VH-TT TPLX', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (77, N'TT TTSK tỉnh AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (78, N'TT PC HIV tỉnh AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (79, N'TT Khí Tượng Thủy Văn', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (80, N'TT CSSKSS AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (81, N'TTYT huyện Chợ Mới', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (82, N'TT PC HIV/AIDS và Lao', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (83, N'TTYTDP tỉnh AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (84, N'Hội người cao tuổi', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (85, N'Hội Nông Dân tỉnh AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (86, N'Hội LHPN tỉnh AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (87, N'Hội VHNT tỉnh AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (88, N'Hội CTĐ AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (89, N'Đội CLB tỉnh AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (90, N'Hội Điôxin AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (91, N'HĐND tỉnh AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (92, N'Hội Khuyến Học', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (93, N'Hội LHPN Mỹ Khánh TPLX', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (94, N'HĐND An Phú', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (95, N'Hiệp hội DN tỉnh AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (96, N'HĐND Tân Châu', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (97, N'CA Thoại Sơn', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (98, N'CA AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (99, N'CA TPLX', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (100, N'BCHQS tỉnh AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (101, N'BCH TK Cứu Nạn AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (102, N'BCH BĐBP tỉnh AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (103, N'Ban VH Mỹ Xuyên TPLX', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (104, N'Ban quản lý các KCN tỉnh AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (105, N'Ban ATGT tỉnh AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (106, N'Ban TG Trung ương', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (107, N'Ban Tuyên Giáo Tỉnh Ủy AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (108, N'Ban Dân Văn Tỉnh Ủy AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (109, N'BVĐK Nhật Tân', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (110, N'BVĐK AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (111, N'Ngân hàng NN tỉnh AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (112, N'Ngân hàng Đại Tính', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (113, N'Cty CP Cơ Khí AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (114, N'Cty Rồng Việt - TPHCM', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (115, N'Cty Bayer CropScience VN', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (116, N'Cty TNHH Thuận An', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (117, N'Cty TNHH 1 TV XSKT AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (118, N'Tập Đoàn Sao Mai', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (119, N'Trường ĐHAG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (120, N'Trường MNSN Tinh Hoa', 1)
GO
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (121, N'UBND tỉnh AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (122, N'UBMTTQ VN tỉnh AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (123, N'UBND huyện An Phú', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (124, N'UBND TX Tân Châu', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (125, N'Đồn Biên Phòng AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (126, N'Báo AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (127, N'BĐBP AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (128, N'Bảo hiểm XH AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (129, N'Cục Hải Quan AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (130, N'VTV Cần Thơ', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (131, N'Tỉnh đoàn AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (132, N'Kiên Giang', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (133, N'Chi Lăng - Tịnh Biên', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (134, N'Bộ CHQS tỉnh AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (135, N'Huyện Đoàn Thoại Sơn', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (136, N'Huyện Châu Thành', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (137, N'Sa Đéc -  Đồng Tháp', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (138, N'Đội Điều Tra Liên Ngành AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (139, N'Đồng Tháp', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (140, N'Phường Bình Khánh - AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (141, N'Thông Tấn Xã Việt Nam', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (142, N'Huyện Ủy Tri Tôn', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (143, N'Bộ Xây Dựng', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (144, N'Đoàn B30', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (145, N'Tỉnh Tiền Giang', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (146, N'Tỉnh Đoàn AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (147, N'Xã Vĩnh Trạch - Thoại Sơn', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (148, N'Tổ Vệ Tinh - Phòng CT', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (149, N'Đội tuyển AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (150, N'Cục thuế AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (151, N'Liên Đoàn Lao Động tỉnh AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (152, N'Đài Khí Tượng Thủy Văn tỉnh AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (153, N'Huyện Đoàn An Phú', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (154, N'Khoảng sản và tài nguyên nước', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (155, N'Huyện Đoàn Tri Tôn', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (156, N'Cty Thu mua - TĐ Metro Cash & Carry', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (157, N'Siêu thị Tứ Sơn', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (158, N'Nhà Thiếu Nhi tỉnh AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (159, N'Đội chuyên trách K37', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (160, N'Trung Đoàn Giang Thuyền 962', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (161, N'Thư viên tỉnh AG', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (162, N'CT XDNTM', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (163, N'Bạc Liêu', 1)
SET IDENTITY_INSERT [dbo].[Organization] OFF
SET IDENTITY_INSERT [dbo].[PointType] ON 

INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (1, N'Tin', N'Tin')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (2, N'Phóng sự', N'PS')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (3, N'Quay tin', N'QTin')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (4, N'Quay phóng sự', N'QPs')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (5, N'Phỏng vấn, Phát biểu', N'Pv_Pb')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (6, N'Trả lời thư', N'Tlt')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (7, N'Soạn dựng', N'Sd')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (8, N'Chuyên đề, Chuyên mục', N'Cd_Cm')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (9, N'Bài', N'Bai')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (10, N'Tường thuật, Ghi nhanh', N'TTh_Gnh')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (11, N'Chuyên đề', N'CDe')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (12, N'Biên soạn, Dẫn chương trình', N'Bs_DCT')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (13, N'Biên tập, Đạo diễn', N'Bt_Dd')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (14, N'Tư liệu tin', N'Tl_Tin')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (15, N'Tổng hợp', N'Thop')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (16, N'Biên soạn tin trong nước', N'Bs_TTN')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (17, N'Biên soạn Sapo Ct và tin trong tỉnh', N'Bs_Sapo')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (18, N'Kiểm thính', N'KThinh')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (19, N'Thu file', N'TFile')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (20, N'Biên tập và duyệt', N'Bt_Duyet')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (21, N'Dẫn chương trình', N'DCT')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (22, N'Kỹ thuật dựng', N'KTD')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (23, N'Thu chương trình', N'TCT')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (24, N'Kiểm tra, tổng hợp TL', N'KT_TH')
SET IDENTITY_INSERT [dbo].[PointType] OFF
SET IDENTITY_INSERT [dbo].[Position] ON 

INSERT [dbo].[Position] ([Id], [Name], [Code]) VALUES (1, N'Phóng viên', N'PV')
INSERT [dbo].[Position] ([Id], [Name], [Code]) VALUES (2, N'Biên t?p viên', N'BTV')
INSERT [dbo].[Position] ([Id], [Name], [Code]) VALUES (3, N'Phát thanh viên', N'PTV')
INSERT [dbo].[Position] ([Id], [Name], [Code]) VALUES (4, N'C?ng tác viên', N'CTV')
SET IDENTITY_INSERT [dbo].[Position] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'admin')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (2, N'staff')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[RoleHasMenuItem] ON 

INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (5, 2, 5)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (6, 2, 6)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (7, 2, 7)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (8, 2, 8)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (9, 2, 9)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (10, 2, 10)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (11, 2, 11)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (12, 2, 12)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (13, 2, 13)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (14, 2, 14)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (15, 2, 15)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (16, 2, 18)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (17, 2, 19)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (18, 2, 20)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (19, 2, 21)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (20, 2, 22)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (21, 2, 23)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (22, 2, 25)
SET IDENTITY_INSERT [dbo].[RoleHasMenuItem] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Username], [Password], [Code], [Name], [RoleId], [StatusId], [LastLoginTime], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (3, N'admin', N'ABEaDKz5yOzdvn2l6pc2iwzT8yPwXc/6Ikb8kxy1Qt6ejj8ZWwdws1F5PLbrIFIqWQ==', N'AD0001', N'Admin', 1, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([Id], [Username], [Password], [Code], [Name], [RoleId], [StatusId], [LastLoginTime], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (4, N'staff', N'ABEaDKz5yOzdvn2l6pc2iwzT8yPwXc/6Ikb8kxy1Qt6ejj8ZWwdws1F5PLbrIFIqWQ==', N'NV0002', N'Admin', 2, 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Article]  WITH CHECK ADD  CONSTRAINT [FK_Article_ArticleType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[ArticleType] ([Id])
GO
ALTER TABLE [dbo].[Article] CHECK CONSTRAINT [FK_Article_ArticleType]
GO
ALTER TABLE [dbo].[ArticleEmployee]  WITH CHECK ADD  CONSTRAINT [FK_ArticleEmployee_Article] FOREIGN KEY([ArticleId])
REFERENCES [dbo].[Article] ([Id])
GO
ALTER TABLE [dbo].[ArticleEmployee] CHECK CONSTRAINT [FK_ArticleEmployee_Article]
GO
ALTER TABLE [dbo].[ArticleEmployee]  WITH CHECK ADD  CONSTRAINT [FK_ArticleEmployee_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[ArticleEmployee] CHECK CONSTRAINT [FK_ArticleEmployee_Employee]
GO
ALTER TABLE [dbo].[ArticlePointType]  WITH CHECK ADD  CONSTRAINT [FK_ArticlePointType_ArticleType] FOREIGN KEY([ArticleTypeId])
REFERENCES [dbo].[ArticleType] ([Id])
GO
ALTER TABLE [dbo].[ArticlePointType] CHECK CONSTRAINT [FK_ArticlePointType_ArticleType]
GO
ALTER TABLE [dbo].[ArticlePointType]  WITH CHECK ADD  CONSTRAINT [FK_ArticlePointType_PointType] FOREIGN KEY([PointTypeId])
REFERENCES [dbo].[PointType] ([Id])
GO
ALTER TABLE [dbo].[ArticlePointType] CHECK CONSTRAINT [FK_ArticlePointType_PointType]
GO
ALTER TABLE [dbo].[Criteria]  WITH CHECK ADD  CONSTRAINT [FK_Criteria_ArticleType] FOREIGN KEY([ArticleTypeId])
REFERENCES [dbo].[ArticleType] ([Id])
GO
ALTER TABLE [dbo].[Criteria] CHECK CONSTRAINT [FK_Criteria_ArticleType]
GO
ALTER TABLE [dbo].[CriteriaValue]  WITH CHECK ADD  CONSTRAINT [FK_CriteriaValue_Configuration] FOREIGN KEY([ConfigurationId])
REFERENCES [dbo].[Configuration] ([Id])
GO
ALTER TABLE [dbo].[CriteriaValue] CHECK CONSTRAINT [FK_CriteriaValue_Configuration]
GO
ALTER TABLE [dbo].[CriteriaValue]  WITH CHECK ADD  CONSTRAINT [FK_CriteriaValue_Criteria] FOREIGN KEY([CriteriaId])
REFERENCES [dbo].[Criteria] ([Id])
GO
ALTER TABLE [dbo].[CriteriaValue] CHECK CONSTRAINT [FK_CriteriaValue_Criteria]
GO
ALTER TABLE [dbo].[Deduction]  WITH CHECK ADD  CONSTRAINT [FK_Deduction_ArticleType] FOREIGN KEY([ArticleTypeId])
REFERENCES [dbo].[ArticleType] ([Id])
GO
ALTER TABLE [dbo].[Deduction] CHECK CONSTRAINT [FK_Deduction_ArticleType]
GO
ALTER TABLE [dbo].[Deduction]  WITH CHECK ADD  CONSTRAINT [FK_Deduction_DeductionType] FOREIGN KEY([DeductionTypeId])
REFERENCES [dbo].[DeductionType] ([Id])
GO
ALTER TABLE [dbo].[Deduction] CHECK CONSTRAINT [FK_Deduction_DeductionType]
GO
ALTER TABLE [dbo].[Deduction]  WITH CHECK ADD  CONSTRAINT [FK_Deduction_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Deduction] CHECK CONSTRAINT [FK_Deduction_Employee]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Organization] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organization] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Organization]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Position] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Role]
GO
ALTER TABLE [dbo].[Point]  WITH CHECK ADD  CONSTRAINT [FK_Point_ArticleEmployee] FOREIGN KEY([ArticleEmployeeId])
REFERENCES [dbo].[ArticleEmployee] ([Id])
GO
ALTER TABLE [dbo].[Point] CHECK CONSTRAINT [FK_Point_ArticleEmployee]
GO
ALTER TABLE [dbo].[Point]  WITH CHECK ADD  CONSTRAINT [FK_Point_PointType] FOREIGN KEY([Type])
REFERENCES [dbo].[PointType] ([Id])
GO
ALTER TABLE [dbo].[Point] CHECK CONSTRAINT [FK_Point_PointType]
GO
ALTER TABLE [dbo].[RoleHasMenuItem]  WITH CHECK ADD  CONSTRAINT [FK_RoleHasMenuItem_MenuItem] FOREIGN KEY([MenuItemId])
REFERENCES [dbo].[MenuItem] ([Id])
GO
ALTER TABLE [dbo].[RoleHasMenuItem] CHECK CONSTRAINT [FK_RoleHasMenuItem_MenuItem]
GO
ALTER TABLE [dbo].[RoleHasMenuItem]  WITH CHECK ADD  CONSTRAINT [FK_RoleHasMenuItem_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[RoleHasMenuItem] CHECK CONSTRAINT [FK_RoleHasMenuItem_Role]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [ATVAllowance] SET  READ_WRITE 
GO
