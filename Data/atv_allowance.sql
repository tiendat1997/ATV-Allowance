USE [master]
GO
/****** Object:  Database [ATVAllowance]    Script Date: 18/09/2019 9:19:16 SA ******/
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
/****** Object:  Table [dbo].[Article]    Script Date: 18/09/2019 9:19:17 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Article](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](200) NULL,
	[Title] [nvarchar](max) NULL,
	[Date] [date] NOT NULL,
	[TypeId] [int] NOT NULL,
 CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArticleEmployee]    Script Date: 18/09/2019 9:19:17 SA ******/
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
/****** Object:  Table [dbo].[ArticlePointType]    Script Date: 18/09/2019 9:19:17 SA ******/
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
/****** Object:  Table [dbo].[ArticleType]    Script Date: 18/09/2019 9:19:17 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticleType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
 CONSTRAINT [PK_ArticleType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BusinessLog]    Script Date: 18/09/2019 9:19:17 SA ******/
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
/****** Object:  Table [dbo].[Configuration]    Script Date: 18/09/2019 9:19:17 SA ******/
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
/****** Object:  Table [dbo].[Criteria]    Script Date: 18/09/2019 9:19:17 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Criteria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NOT NULL,
	[ArticleTypeId] [int] NOT NULL,
	[Unit] [int] NULL,
 CONSTRAINT [PK_Criteria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CriteriaValue]    Script Date: 18/09/2019 9:19:17 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CriteriaValue](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CriteriaId] [int] NULL,
	[Value] [float] NULL,
	[ConfigurationId] [int] NULL,
 CONSTRAINT [PK_CriteriaValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Deduction]    Script Date: 18/09/2019 9:19:18 SA ******/
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
 CONSTRAINT [PK_Deduction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeductionType]    Script Date: 18/09/2019 9:19:18 SA ******/
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
/****** Object:  Table [dbo].[Employee]    Script Date: 18/09/2019 9:19:18 SA ******/
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
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuItem]    Script Date: 18/09/2019 9:19:18 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Level] [int] NOT NULL,
	[ParentName] [nvarchar](30) NULL,
	[Order] [int] NOT NULL,
 CONSTRAINT [PK_MenuItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Organization]    Script Date: 18/09/2019 9:19:18 SA ******/
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
/****** Object:  Table [dbo].[Point]    Script Date: 18/09/2019 9:19:18 SA ******/
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
/****** Object:  Table [dbo].[PointType]    Script Date: 18/09/2019 9:19:18 SA ******/
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
/****** Object:  Table [dbo].[Position]    Script Date: 18/09/2019 9:19:18 SA ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 18/09/2019 9:19:18 SA ******/
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
/****** Object:  Table [dbo].[RoleHasMenuItem]    Script Date: 18/09/2019 9:19:18 SA ******/
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
/****** Object:  Table [dbo].[SystemLog]    Script Date: 18/09/2019 9:19:18 SA ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 18/09/2019 9:19:18 SA ******/
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
SET IDENTITY_INSERT [dbo].[Article] ON 

INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (2, NULL, N'AG công nhận thêm 6 xã đạt chuẩn NTM', CAST(N'2019-09-12' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (4, NULL, N'Tôi là ai đây nè đang chơi đùa gì vậy', CAST(N'2019-09-13' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (5, NULL, N'Hello there baby', CAST(N'2019-09-13' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (6, NULL, N'Tôi là ai chốn này', CAST(N'2019-09-14' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (7, NULL, N'Hello baby', CAST(N'2019-09-13' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (8, NULL, N'Hú ba', CAST(N'2019-09-13' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (9, NULL, N'Hú bi baba', CAST(N'2019-09-14' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (10, NULL, N'Hùa theo à', CAST(N'2019-09-13' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (11, NULL, N'Hùa theo à', CAST(N'2019-09-15' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (12, NULL, N'Hùa theo nè', CAST(N'2019-09-15' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (13, NULL, N'Tôi là ai trong cuộc đời này', CAST(N'2019-09-16' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (14, NULL, N'Hello there baby I love you', CAST(N'2019-09-16' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (15, NULL, N'Tôi là ai trong cuộc đời này', CAST(N'2019-09-13' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (16, NULL, N'Tồi nè', CAST(N'2019-09-13' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (17, NULL, N'Tui nè baby', CAST(N'2019-09-13' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (18, NULL, N'Hú ba bibi', CAST(N'2019-09-13' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (19, NULL, NULL, CAST(N'0001-01-01' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (20, NULL, NULL, CAST(N'0001-01-01' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (21, NULL, N'Ngày này tôi đi', CAST(N'2019-09-13' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (22, NULL, N'Hehe hú ba', CAST(N'0001-01-01' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (23, NULL, N'Chú ba hai', CAST(N'2019-09-17' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (24, NULL, N'asfasdf', CAST(N'2019-09-17' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (25, NULL, N'Just for fun nè', CAST(N'2019-09-17' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (26, NULL, N'Just 2', CAST(N'2019-09-17' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (27, NULL, N'Just 10', CAST(N'2019-09-17' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (28, NULL, N'Mệt vl', CAST(N'2019-09-17' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (29, NULL, N'avc', CAST(N'2019-09-17' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (30, NULL, N'Chán', CAST(N'2019-09-17' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (31, NULL, N'đụ mẹ', CAST(N'2019-09-17' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (32, NULL, N'móa', CAST(N'2019-09-17' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (33, NULL, N'abcd', CAST(N'2019-09-17' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (34, NULL, N'Có một con chuồn chuồn trong đất', CAST(N'2019-09-17' AS Date), 1)
INSERT [dbo].[Article] ([Id], [Code], [Title], [Date], [TypeId]) VALUES (35, NULL, N'Tôi là ai trong cuộc đời này 2', CAST(N'2019-09-17' AS Date), 1)
SET IDENTITY_INSERT [dbo].[Article] OFF
SET IDENTITY_INSERT [dbo].[ArticleEmployee] ON 

INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (3, 19, 8)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (4, 19, 5)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (5, 24, 8)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (6, 24, 8)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (7, 24, 8)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (8, 23, 4)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (9, 25, 3)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (10, 25, 5)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (11, 25, 5)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (12, 25, 8)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (26, 26, 5)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (31, 25, 6)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (32, 25, 6)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (33, 25, 6)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (34, 25, 6)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (35, 24, 6)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (36, 24, 6)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (37, 28, 5)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (38, 28, 8)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (39, 28, 8)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (45, 28, 6)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (46, 23, 3)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (47, 23, 8)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (48, 23, 5)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (49, 23, 6)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (50, 23, 12)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (51, 23, 13)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (52, 23, 9)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (53, 23, 6)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (54, 23, 6)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (55, 23, 12)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (56, 23, 12)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (57, 23, 7)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (58, 23, 7)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (59, 23, 8)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (60, 23, 8)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (61, 23, 8)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (62, 23, 8)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (71, 23, 8)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (72, 23, 5)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (74, 29, 12)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (88, 31, 8)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (89, 31, 5)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (90, 31, 3)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (92, 31, 3)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (106, 32, 10)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (107, 33, 6)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (109, 35, 5)
INSERT [dbo].[ArticleEmployee] ([Id], [ArticleId], [EmployeeId]) VALUES (110, 26, 4)
SET IDENTITY_INSERT [dbo].[ArticleEmployee] OFF
SET IDENTITY_INSERT [dbo].[ArticlePointType] ON 

INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (1, 1, 1)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (2, 1, 2)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (3, 1, 3)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (4, 1, 4)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (5, 2, 1)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (6, 2, 5)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (7, 2, 6)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (8, 2, 7)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (9, 2, 8)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (10, 2, 9)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (11, 3, 1)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (12, 3, 10)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (13, 3, 11)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (14, 3, 5)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (15, 3, 12)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (16, 3, 13)
SET IDENTITY_INSERT [dbo].[ArticlePointType] OFF
SET IDENTITY_INSERT [dbo].[ArticleType] ON 

INSERT [dbo].[ArticleType] ([Id], [Name]) VALUES (1, N'Thời sự hằng ngày')
INSERT [dbo].[ArticleType] ([Id], [Name]) VALUES (2, N'Phát thanh')
INSERT [dbo].[ArticleType] ([Id], [Name]) VALUES (3, N'Phát thanh trực tiếp')
SET IDENTITY_INSERT [dbo].[ArticleType] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([Id], [Code], [Name], [RoleId], [OrganizationId], [IsActive]) VALUES (3, N'TUANPV', N'Phan Văn Tuấn', 2, 1, 1)
INSERT [dbo].[Employee] ([Id], [Code], [Name], [RoleId], [OrganizationId], [IsActive]) VALUES (4, N'DATTTD', N'TRẦN TIẾN ĐẠT Đạt', 2, 1, 1)
INSERT [dbo].[Employee] ([Id], [Code], [Name], [RoleId], [OrganizationId], [IsActive]) VALUES (5, N'NGOCNT', N'Nguyễn Thúy Ngọc', 1, 1, 1)
INSERT [dbo].[Employee] ([Id], [Code], [Name], [RoleId], [OrganizationId], [IsActive]) VALUES (6, N'TIENT', N'Trần Tiến', 1, 1, 1)
INSERT [dbo].[Employee] ([Id], [Code], [Name], [RoleId], [OrganizationId], [IsActive]) VALUES (7, N'THANGNV', N'Nguyễn Việt Thắng', 1, 1, 1)
INSERT [dbo].[Employee] ([Id], [Code], [Name], [RoleId], [OrganizationId], [IsActive]) VALUES (8, N'DATTNT', N'Trần Nguyễn Tiến Đạt', 2, 1, 1)
INSERT [dbo].[Employee] ([Id], [Code], [Name], [RoleId], [OrganizationId], [IsActive]) VALUES (9, N'HUNGNV', N'Nguyễn Việt Hùng', 3, 2, 1)
INSERT [dbo].[Employee] ([Id], [Code], [Name], [RoleId], [OrganizationId], [IsActive]) VALUES (10, N'EMPVT', N'Phan Văn Tài Em', 4, 1, 1)
INSERT [dbo].[Employee] ([Id], [Code], [Name], [RoleId], [OrganizationId], [IsActive]) VALUES (11, N'HUNGSA', N'Siêu Anh Hùng', 1, 1, 1)
INSERT [dbo].[Employee] ([Id], [Code], [Name], [RoleId], [OrganizationId], [IsActive]) VALUES (12, N'HETLA', N'Tôi Là Ai He', 3, 1, 1)
INSERT [dbo].[Employee] ([Id], [Code], [Name], [RoleId], [OrganizationId], [IsActive]) VALUES (13, N'EMT', N'Tuấn Em', 3, 1, 1)
INSERT [dbo].[Employee] ([Id], [Code], [Name], [RoleId], [OrganizationId], [IsActive]) VALUES (14, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Employee] ([Id], [Code], [Name], [RoleId], [OrganizationId], [IsActive]) VALUES (15, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Employee] ([Id], [Code], [Name], [RoleId], [OrganizationId], [IsActive]) VALUES (16, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Employee] ([Id], [Code], [Name], [RoleId], [OrganizationId], [IsActive]) VALUES (17, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Employee] ([Id], [Code], [Name], [RoleId], [OrganizationId], [IsActive]) VALUES (18, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Employee] ([Id], [Code], [Name], [RoleId], [OrganizationId], [IsActive]) VALUES (19, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Employee] ([Id], [Code], [Name], [RoleId], [OrganizationId], [IsActive]) VALUES (20, NULL, NULL, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[MenuItem] ON 

INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (1, N'Quản lý tin', 0, NULL, 0)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (2, N'Tin Thời sự hằng ngày', 1, N'Quản lý tin', 0)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (3, N'Tin Phát thanh', 1, N'Quản lý tin', 1)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (4, N'Tin Phát thanh trực tiếp', 1, N'Quản lý tin', 2)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (5, N'In ấn', 0, NULL, 1)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (6, N'In Thời sự', 1, N'In ấn', 0)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (7, N'In Phát thanh ', 1, N'In ấn', 1)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (8, N'In Phát thanh trực tiếp', 1, N'In ấn', 2)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (9, N'Quản lý chung', 0, NULL, 2)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (10, N'Quản lý nhân viên', 1, N'Quản lý chung', 0)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (11, N'Quản lý chỉ tiêu', 1, N'Quản lý chung', 1)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (12, N'Quản lý đơn vị', 1, N'Quản lý chung', 2)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (13, N'Quản lý loại tin', 1, N'Quản lý chung', 3)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (14, N'Quản lý giảm trừ', 1, N'Quản lý chung', 4)
SET IDENTITY_INSERT [dbo].[MenuItem] OFF
SET IDENTITY_INSERT [dbo].[Organization] ON 

INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (1, N'Đài phát thanh', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (2, N'Phòng chương trình 2', 1)
INSERT [dbo].[Organization] ([Id], [Name], [IsActive]) VALUES (3, N'Phòng kế toán', 1)
SET IDENTITY_INSERT [dbo].[Organization] OFF
SET IDENTITY_INSERT [dbo].[Point] ON 

INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (1, 3, 2, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (2, 3, 2, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (3, 3, 2, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (4, 3, 2, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (5, 4, 3, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (6, 4, 3, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (7, 4, 3, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (8, 4, 3, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (9, 5, 0, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (10, 5, 0, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (11, 5, 0, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (12, 5, 0, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (13, 6, 3, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (14, 6, 4, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (15, 6, 5, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (16, 6, 6, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (17, 7, 3, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (18, 7, 4, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (19, 7, 5, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (20, 7, 6, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (21, 8, 2, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (22, 8, 3, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (23, 8, 4, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (24, 8, 5, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (25, 9, 2, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (26, 9, 2, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (27, 9, 2, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (28, 9, 2, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (29, 10, 2, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (30, 10, 3, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (31, 10, 3, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (32, 10, 3, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (33, 11, 2, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (34, 11, 3, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (35, 11, 3, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (36, 11, 3, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (37, 12, 3, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (38, 12, 3, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (39, 12, 3, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (40, 12, 3, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (93, 26, 10, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (94, 26, 10, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (95, 26, 10, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (96, 26, 10, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (113, 31, 2, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (114, 31, 0, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (115, 31, 0, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (116, 31, 0, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (117, 32, 2, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (118, 32, 0, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (119, 32, 0, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (120, 32, 0, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (121, 33, 0, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (122, 33, 2, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (123, 33, 2, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (124, 33, 2, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (125, 34, 0, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (126, 34, 2, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (127, 34, 2, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (128, 34, 2, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (129, 35, 2, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (130, 35, 2, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (131, 35, 2, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (132, 35, 0, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (133, 36, 0, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (134, 36, 0, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (135, 36, 0, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (136, 36, 0, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (137, 37, 2, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (138, 37, 2, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (139, 37, 3, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (140, 37, 3, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (141, 38, 2, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (142, 38, 2, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (143, 38, 2, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (144, 38, 2, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (145, 39, 2, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (146, 39, 2, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (147, 39, 2, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (148, 39, 2, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (169, 45, 0, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (170, 45, 0, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (171, 45, 0, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (172, 45, 0, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (173, 46, 0, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (174, 46, 0, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (175, 46, 0, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (176, 46, 0, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (177, 47, 0, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (178, 47, 0, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (179, 47, 0, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (180, 47, 0, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (181, 48, 0, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (182, 48, 0, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (183, 48, 0, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (184, 48, 0, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (185, 49, 0, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (186, 49, 0, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (187, 49, 0, 3)
GO
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (188, 49, 0, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (189, 50, 0, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (190, 50, 0, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (191, 50, 0, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (192, 50, 0, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (193, 51, 0, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (194, 51, 0, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (195, 51, 2, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (196, 51, 2, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (197, 52, 0, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (198, 52, 0, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (199, 52, 0, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (200, 52, 0, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (201, 53, 0, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (202, 53, 0, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (203, 53, 0, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (204, 53, 0, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (205, 54, 0, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (206, 54, 0, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (207, 54, 0, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (208, 54, 0, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (209, 55, 0, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (210, 55, 0, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (211, 55, 0, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (212, 55, 0, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (213, 56, 0, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (214, 56, 0, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (215, 56, 0, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (216, 56, 0, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (217, 57, 0, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (218, 57, 0, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (219, 57, 0, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (220, 57, 0, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (221, 58, 0, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (222, 58, 0, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (223, 58, 0, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (224, 58, 0, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (225, 59, 0, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (226, 59, 0, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (227, 59, 0, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (228, 59, 0, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (229, 60, 0, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (230, 60, 0, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (231, 60, 0, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (232, 60, 0, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (233, 61, 0, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (234, 61, 0, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (235, 61, 0, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (236, 61, 0, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (237, 62, 0, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (238, 62, 0, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (239, 62, 0, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (240, 62, 0, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (273, 71, 0, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (274, 71, 0, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (275, 71, 0, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (276, 71, 3, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (277, 72, 0, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (278, 72, 0, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (279, 72, 0, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (280, 72, 0, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (285, 74, 0, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (286, 74, 0, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (287, 74, 0, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (288, 74, 0, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (341, 88, 0, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (342, 88, 0, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (343, 88, 0, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (344, 88, 4, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (345, 89, 0, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (346, 89, 0, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (347, 89, 3, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (348, 89, 2, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (349, 90, 0, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (350, 90, 0, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (351, 90, 0, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (352, 90, 2, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (357, 92, 0, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (358, 92, 22, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (359, 92, 2, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (360, 92, 3, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (413, 106, 0, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (414, 106, 0, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (415, 106, 0, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (416, 106, 0, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (417, 107, 0, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (418, 107, 0, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (419, 107, 2, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (420, 107, 3, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (425, 109, 3, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (426, 109, 3, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (427, 109, 3, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (428, 109, 3, 4)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (429, 110, 2, 1)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (430, 110, 2, 2)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (431, 110, 2, 3)
INSERT [dbo].[Point] ([Id], [ArticleEmployeeId], [Point], [Type]) VALUES (432, 110, 2, 4)
SET IDENTITY_INSERT [dbo].[Point] OFF
SET IDENTITY_INSERT [dbo].[PointType] ON 

INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (1, N'Tin', N'Tin')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (2, N'Phóng sự', N'PS')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (3, N'Quay tin', N'QTin')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (4, N'Quay phóng sự', N'QPs')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (5, N'Phỏng vấn/Phát biểu', N'Pv_Pb')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (6, N'Trả lời thư', N'Tlt')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (7, N'Soạn dựng', N'Sd')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (8, N'Chuyên đề/Chuyên mục', N'Cd_Cm')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (9, N'Bài', N'Bai')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (10, N'Tường thuật/Ghi nhanh', N'TTh_Gnh')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (11, N'Chuyên đề', N'CDe')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (12, N'Biên soạn/Dẫn CT', N'Bs_DCT')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (13, N'Biên tập/Đạo diễn', N'Bt_Dd')
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

INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (1, 2, 1)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (2, 2, 2)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (3, 2, 3)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (4, 2, 4)
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
