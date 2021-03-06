USE [master]
GO
/****** Object:  Database [MovieWebsiteManager]    Script Date: 29/02/2020 8:20:27 am ******/
CREATE DATABASE [MovieWebsiteManager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WebsiteManager', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS2016\MSSQL\DATA\WebsiteManager.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WebsiteManager_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS2016\MSSQL\DATA\WebsiteManager_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MovieWebsiteManager] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MovieWebsiteManager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MovieWebsiteManager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MovieWebsiteManager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MovieWebsiteManager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MovieWebsiteManager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MovieWebsiteManager] SET ARITHABORT OFF 
GO
ALTER DATABASE [MovieWebsiteManager] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MovieWebsiteManager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MovieWebsiteManager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MovieWebsiteManager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MovieWebsiteManager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MovieWebsiteManager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MovieWebsiteManager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MovieWebsiteManager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MovieWebsiteManager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MovieWebsiteManager] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MovieWebsiteManager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MovieWebsiteManager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MovieWebsiteManager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MovieWebsiteManager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MovieWebsiteManager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MovieWebsiteManager] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MovieWebsiteManager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MovieWebsiteManager] SET RECOVERY FULL 
GO
ALTER DATABASE [MovieWebsiteManager] SET  MULTI_USER 
GO
ALTER DATABASE [MovieWebsiteManager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MovieWebsiteManager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MovieWebsiteManager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MovieWebsiteManager] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MovieWebsiteManager] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MovieWebsiteManager', N'ON'
GO
ALTER DATABASE [MovieWebsiteManager] SET QUERY_STORE = OFF
GO
USE [MovieWebsiteManager]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 29/02/2020 8:20:27 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[acc_id] [int] IDENTITY(1,1) NOT NULL,
	[acc_username] [nvarchar](30) NOT NULL,
	[acc_password] [nvarchar](30) NOT NULL,
	[acc_level] [int] NOT NULL,
	[acc_status] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[acc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Actor]    Script Date: 29/02/2020 8:20:27 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actor](
	[a_id] [int] IDENTITY(1,1) NOT NULL,
	[a_name] [nvarchar](30) NOT NULL,
	[a_age] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[a_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActorInMovie]    Script Date: 29/02/2020 8:20:27 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActorInMovie](
	[a_id] [int] NOT NULL,
	[m_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[a_id] ASC,
	[m_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 29/02/2020 8:20:27 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[c_id] [int] IDENTITY(1,1) NOT NULL,
	[c_name] [nvarchar](30) NOT NULL,
	[c_email] [nvarchar](30) NOT NULL,
	[c_gender] [int] NOT NULL,
	[acc_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[c_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 29/02/2020 8:20:27 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[country_id] [int] IDENTITY(1,1) NOT NULL,
	[country_name] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[country_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Director]    Script Date: 29/02/2020 8:20:28 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Director](
	[d_id] [int] IDENTITY(1,1) NOT NULL,
	[d_name] [nvarchar](30) NOT NULL,
	[d_age] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[d_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DirectorInMovie]    Script Date: 29/02/2020 8:20:28 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DirectorInMovie](
	[m_id] [int] NOT NULL,
	[d_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[d_id] ASC,
	[m_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FavoriteMovie]    Script Date: 29/02/2020 8:20:28 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FavoriteMovie](
	[c_id] [int] NOT NULL,
	[m_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[c_id] ASC,
	[m_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 29/02/2020 8:20:28 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[g_id] [int] IDENTITY(1,1) NOT NULL,
	[g_name] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[g_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GenreInMovie]    Script Date: 29/02/2020 8:20:28 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GenreInMovie](
	[g_id] [int] NOT NULL,
	[m_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[g_id] ASC,
	[m_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 29/02/2020 8:20:28 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie](
	[m_id] [int] IDENTITY(1,1) NOT NULL,
	[m_name] [nvarchar](50) NOT NULL,
	[m_year] [int] NOT NULL,
	[m_views] [int] NOT NULL,
	[m_trailer] [nvarchar](100) NOT NULL,
	[m_thumbnail] [nvarchar](50) NOT NULL,
	[s_id] [int] NOT NULL,
	[country_id] [int] NOT NULL,
	[m_description] [nvarchar](500) NOT NULL,
	[m_duration] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[m_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Studio]    Script Date: 29/02/2020 8:20:28 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Studio](
	[s_id] [int] IDENTITY(1,1) NOT NULL,
	[s_name] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[s_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([acc_id], [acc_username], [acc_password], [acc_level], [acc_status]) VALUES (1, N'admin', N'admin123', 2, N'1')
INSERT [dbo].[Account] ([acc_id], [acc_username], [acc_password], [acc_level], [acc_status]) VALUES (2, N'test123456', N'123456', 0, N'1')
INSERT [dbo].[Account] ([acc_id], [acc_username], [acc_password], [acc_level], [acc_status]) VALUES (3, N'toiLaAccTest', N'123456', 0, N'1')
INSERT [dbo].[Account] ([acc_id], [acc_username], [acc_password], [acc_level], [acc_status]) VALUES (5, N'user', N'user', 0, N'1')
INSERT [dbo].[Account] ([acc_id], [acc_username], [acc_password], [acc_level], [acc_status]) VALUES (6, N'mod', N'mod', 1, N'1')
INSERT [dbo].[Account] ([acc_id], [acc_username], [acc_password], [acc_level], [acc_status]) VALUES (7, N'test01', N'test12', 0, N'1')
INSERT [dbo].[Account] ([acc_id], [acc_username], [acc_password], [acc_level], [acc_status]) VALUES (8, N'test012', N'123456', 0, N'1')
INSERT [dbo].[Account] ([acc_id], [acc_username], [acc_password], [acc_level], [acc_status]) VALUES (9, N'mod', N'mod', 1, N'1')
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[Actor] ON 

INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (1, N'Samuel L. Jackson', 70)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (2, N'Tom Cruise', 57)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (3, N'Adam Sendler', 52)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (4, N'Johnny Depp', 56)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (5, N'Leonardo Dicaprio', 44)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (6, N'Matt Damon', 48)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (7, N'Brad Pitt', 55)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (8, N'Robert Pattinson', 33)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (9, N'Daniel Craig', 51)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (10, N'Jim Carrey', 57)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (11, N'Mark Wahlberg', 48)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (14, N'Christopher Robert Evans', 38)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (15, N'Mark Ruffalo', 51)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (16, N'Christopher Hemsworth', 35)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (17, N'Scarlett Ingrid Johansson', 34)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (18, N'Ken Watanabe', 59)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (19, N'Joseph Gordon-Levitt', 38)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (20, N'Elijah Wood', 38)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (21, N'Ian McKellen', 80)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (22, N'Liv Tyler', 42)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (23, N'Martin Freeman', 47)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (24, N'Richard Armitage', 47)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (25, N'Daniel Radcliffe', 29)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (26, N'Rupert Grint', 30)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (27, N'Emma Watson', 29)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (28, N'Matthew McConaughey', 49)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (29, N'Anne Hathaway', 36)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (30, N'Brie Larson', 29)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (31, N'Jason Momoa', 39)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (32, N'Amber Heard', 33)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (33, N'Keanu Reeves', 54)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (34, N'Tom Holland ', 23)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (35, N'Jake Gyllenhaal', 38)
INSERT [dbo].[Actor] ([a_id], [a_name], [a_age]) VALUES (48, N'Hieu Thanh', 20)
SET IDENTITY_INSERT [dbo].[Actor] OFF
INSERT [dbo].[ActorInMovie] ([a_id], [m_id]) VALUES (1, 6)
INSERT [dbo].[ActorInMovie] ([a_id], [m_id]) VALUES (1, 21)
INSERT [dbo].[ActorInMovie] ([a_id], [m_id]) VALUES (5, 7)
INSERT [dbo].[ActorInMovie] ([a_id], [m_id]) VALUES (14, 6)
INSERT [dbo].[ActorInMovie] ([a_id], [m_id]) VALUES (15, 6)
INSERT [dbo].[ActorInMovie] ([a_id], [m_id]) VALUES (16, 6)
INSERT [dbo].[ActorInMovie] ([a_id], [m_id]) VALUES (17, 6)
INSERT [dbo].[ActorInMovie] ([a_id], [m_id]) VALUES (18, 7)
INSERT [dbo].[ActorInMovie] ([a_id], [m_id]) VALUES (19, 7)
INSERT [dbo].[ActorInMovie] ([a_id], [m_id]) VALUES (20, 15)
INSERT [dbo].[ActorInMovie] ([a_id], [m_id]) VALUES (21, 15)
INSERT [dbo].[ActorInMovie] ([a_id], [m_id]) VALUES (21, 16)
INSERT [dbo].[ActorInMovie] ([a_id], [m_id]) VALUES (22, 15)
INSERT [dbo].[ActorInMovie] ([a_id], [m_id]) VALUES (23, 16)
INSERT [dbo].[ActorInMovie] ([a_id], [m_id]) VALUES (24, 16)
INSERT [dbo].[ActorInMovie] ([a_id], [m_id]) VALUES (26, 25)
INSERT [dbo].[ActorInMovie] ([a_id], [m_id]) VALUES (28, 20)
INSERT [dbo].[ActorInMovie] ([a_id], [m_id]) VALUES (29, 20)
INSERT [dbo].[ActorInMovie] ([a_id], [m_id]) VALUES (30, 21)
INSERT [dbo].[ActorInMovie] ([a_id], [m_id]) VALUES (31, 22)
INSERT [dbo].[ActorInMovie] ([a_id], [m_id]) VALUES (32, 22)
INSERT [dbo].[ActorInMovie] ([a_id], [m_id]) VALUES (33, 23)
INSERT [dbo].[ActorInMovie] ([a_id], [m_id]) VALUES (33, 24)
INSERT [dbo].[ActorInMovie] ([a_id], [m_id]) VALUES (34, 25)
INSERT [dbo].[ActorInMovie] ([a_id], [m_id]) VALUES (48, 38)
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([c_id], [c_name], [c_email], [c_gender], [acc_id]) VALUES (2, N'toi la acc test', N'toila@acc.test', 1, 3)
INSERT [dbo].[Client] ([c_id], [c_name], [c_email], [c_gender], [acc_id]) VALUES (4, N'Toi la user', N'user@user.com', 1, 5)
INSERT [dbo].[Client] ([c_id], [c_name], [c_email], [c_gender], [acc_id]) VALUES (5, N'Mod', N'mod@mod.com', 1, 6)
INSERT [dbo].[Client] ([c_id], [c_name], [c_email], [c_gender], [acc_id]) VALUES (6, N'ads asdas', N'abc@abc.sdf', 1, 7)
INSERT [dbo].[Client] ([c_id], [c_name], [c_email], [c_gender], [acc_id]) VALUES (7, N'ads asdas', N'abc@abc.sdf', 1, 8)
INSERT [dbo].[Client] ([c_id], [c_name], [c_email], [c_gender], [acc_id]) VALUES (8, N'Mod', N'mod@mod.com', 1, 6)
INSERT [dbo].[Client] ([c_id], [c_name], [c_email], [c_gender], [acc_id]) VALUES (9, N'Admin', N'admin@admin.com', 1, 1)
SET IDENTITY_INSERT [dbo].[Client] OFF
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([country_id], [country_name]) VALUES (1, N'Vietnam')
INSERT [dbo].[Country] ([country_id], [country_name]) VALUES (2, N'U.S.A')
INSERT [dbo].[Country] ([country_id], [country_name]) VALUES (3, N'India')
INSERT [dbo].[Country] ([country_id], [country_name]) VALUES (4, N'China')
INSERT [dbo].[Country] ([country_id], [country_name]) VALUES (5, N'Korea')
INSERT [dbo].[Country] ([country_id], [country_name]) VALUES (6, N'Thailand')
INSERT [dbo].[Country] ([country_id], [country_name]) VALUES (7, N'Japan')
SET IDENTITY_INSERT [dbo].[Country] OFF
SET IDENTITY_INSERT [dbo].[Director] ON 

INSERT [dbo].[Director] ([d_id], [d_name], [d_age]) VALUES (3, N'Steven Spielberg', 72)
INSERT [dbo].[Director] ([d_id], [d_name], [d_age]) VALUES (4, N'Quentin Tarantino', 56)
INSERT [dbo].[Director] ([d_id], [d_name], [d_age]) VALUES (5, N'Clint Eastwood', 89)
INSERT [dbo].[Director] ([d_id], [d_name], [d_age]) VALUES (6, N'Woody Allen', 83)
INSERT [dbo].[Director] ([d_id], [d_name], [d_age]) VALUES (7, N'Athony Russo', 49)
INSERT [dbo].[Director] ([d_id], [d_name], [d_age]) VALUES (8, N'Joseph Russo', 48)
INSERT [dbo].[Director] ([d_id], [d_name], [d_age]) VALUES (9, N'Christopher Nolan', 48)
INSERT [dbo].[Director] ([d_id], [d_name], [d_age]) VALUES (10, N'Peter Jackson', 57)
INSERT [dbo].[Director] ([d_id], [d_name], [d_age]) VALUES (11, N'Chris Columbus', 60)
INSERT [dbo].[Director] ([d_id], [d_name], [d_age]) VALUES (12, N'Anna Boden', 42)
INSERT [dbo].[Director] ([d_id], [d_name], [d_age]) VALUES (13, N'Ryan Fleck', 42)
INSERT [dbo].[Director] ([d_id], [d_name], [d_age]) VALUES (14, N'James Wan', 42)
INSERT [dbo].[Director] ([d_id], [d_name], [d_age]) VALUES (15, N'Chad Stahelski', 50)
INSERT [dbo].[Director] ([d_id], [d_name], [d_age]) VALUES (16, N'Jon Watts', 38)
INSERT [dbo].[Director] ([d_id], [d_name], [d_age]) VALUES (17, N'Hieu Thanh', 20)
SET IDENTITY_INSERT [dbo].[Director] OFF
INSERT [dbo].[DirectorInMovie] ([m_id], [d_id]) VALUES (6, 7)
INSERT [dbo].[DirectorInMovie] ([m_id], [d_id]) VALUES (6, 8)
INSERT [dbo].[DirectorInMovie] ([m_id], [d_id]) VALUES (7, 9)
INSERT [dbo].[DirectorInMovie] ([m_id], [d_id]) VALUES (20, 9)
INSERT [dbo].[DirectorInMovie] ([m_id], [d_id]) VALUES (15, 10)
INSERT [dbo].[DirectorInMovie] ([m_id], [d_id]) VALUES (16, 10)
INSERT [dbo].[DirectorInMovie] ([m_id], [d_id]) VALUES (21, 12)
INSERT [dbo].[DirectorInMovie] ([m_id], [d_id]) VALUES (21, 13)
INSERT [dbo].[DirectorInMovie] ([m_id], [d_id]) VALUES (22, 14)
INSERT [dbo].[DirectorInMovie] ([m_id], [d_id]) VALUES (23, 15)
INSERT [dbo].[DirectorInMovie] ([m_id], [d_id]) VALUES (24, 15)
INSERT [dbo].[DirectorInMovie] ([m_id], [d_id]) VALUES (25, 16)
INSERT [dbo].[DirectorInMovie] ([m_id], [d_id]) VALUES (38, 17)
INSERT [dbo].[FavoriteMovie] ([c_id], [m_id]) VALUES (4, 20)
INSERT [dbo].[FavoriteMovie] ([c_id], [m_id]) VALUES (4, 23)
INSERT [dbo].[FavoriteMovie] ([c_id], [m_id]) VALUES (9, 15)
INSERT [dbo].[FavoriteMovie] ([c_id], [m_id]) VALUES (9, 16)
INSERT [dbo].[FavoriteMovie] ([c_id], [m_id]) VALUES (9, 20)
INSERT [dbo].[FavoriteMovie] ([c_id], [m_id]) VALUES (9, 21)
INSERT [dbo].[FavoriteMovie] ([c_id], [m_id]) VALUES (9, 23)
SET IDENTITY_INSERT [dbo].[Genre] ON 

INSERT [dbo].[Genre] ([g_id], [g_name]) VALUES (1, N'Sci-Fi')
INSERT [dbo].[Genre] ([g_id], [g_name]) VALUES (2, N'Horror')
INSERT [dbo].[Genre] ([g_id], [g_name]) VALUES (3, N'Action')
INSERT [dbo].[Genre] ([g_id], [g_name]) VALUES (4, N'Thriller')
INSERT [dbo].[Genre] ([g_id], [g_name]) VALUES (5, N'Adventure')
INSERT [dbo].[Genre] ([g_id], [g_name]) VALUES (6, N'Drama')
INSERT [dbo].[Genre] ([g_id], [g_name]) VALUES (7, N'Fantasy')
INSERT [dbo].[Genre] ([g_id], [g_name]) VALUES (8, N'Epic')
INSERT [dbo].[Genre] ([g_id], [g_name]) VALUES (9, N'Superhero')
SET IDENTITY_INSERT [dbo].[Genre] OFF
INSERT [dbo].[GenreInMovie] ([g_id], [m_id]) VALUES (1, 6)
INSERT [dbo].[GenreInMovie] ([g_id], [m_id]) VALUES (1, 7)
INSERT [dbo].[GenreInMovie] ([g_id], [m_id]) VALUES (1, 20)
INSERT [dbo].[GenreInMovie] ([g_id], [m_id]) VALUES (1, 21)
INSERT [dbo].[GenreInMovie] ([g_id], [m_id]) VALUES (3, 6)
INSERT [dbo].[GenreInMovie] ([g_id], [m_id]) VALUES (3, 7)
INSERT [dbo].[GenreInMovie] ([g_id], [m_id]) VALUES (3, 23)
INSERT [dbo].[GenreInMovie] ([g_id], [m_id]) VALUES (3, 24)
INSERT [dbo].[GenreInMovie] ([g_id], [m_id]) VALUES (5, 15)
INSERT [dbo].[GenreInMovie] ([g_id], [m_id]) VALUES (5, 16)
INSERT [dbo].[GenreInMovie] ([g_id], [m_id]) VALUES (6, 38)
INSERT [dbo].[GenreInMovie] ([g_id], [m_id]) VALUES (7, 15)
INSERT [dbo].[GenreInMovie] ([g_id], [m_id]) VALUES (7, 16)
INSERT [dbo].[GenreInMovie] ([g_id], [m_id]) VALUES (8, 15)
INSERT [dbo].[GenreInMovie] ([g_id], [m_id]) VALUES (8, 16)
INSERT [dbo].[GenreInMovie] ([g_id], [m_id]) VALUES (9, 21)
INSERT [dbo].[GenreInMovie] ([g_id], [m_id]) VALUES (9, 22)
INSERT [dbo].[GenreInMovie] ([g_id], [m_id]) VALUES (9, 25)
SET IDENTITY_INSERT [dbo].[Movie] ON 

INSERT [dbo].[Movie] ([m_id], [m_name], [m_year], [m_views], [m_trailer], [m_thumbnail], [s_id], [country_id], [m_description], [m_duration]) VALUES (6, N'Avengers: Endgame', 2019, 12, N'https://www.youtube.com/watch?v=TcMBFSGVi1c', N'Avengers_Endgame_poster.jpg', 7, 2, N'Thanos died, Iron man died, Black Window died. This is really sad', 181)
INSERT [dbo].[Movie] ([m_id], [m_name], [m_year], [m_views], [m_trailer], [m_thumbnail], [s_id], [country_id], [m_description], [m_duration]) VALUES (7, N'Inception', 2010, 12, N'https://www.youtube.com/watch?v=8hP9D6kZseM', N'Inception_(2010)_theatrical_poster.jpg', 3, 2, N'The film stars Leonardo DiCaprio as a professional thief who steals information by infiltrating the subconscious, and is offered a chance to have his criminal history erased as payment for the implantation of another person''s idea into a target''s subconscious', 148)
INSERT [dbo].[Movie] ([m_id], [m_name], [m_year], [m_views], [m_trailer], [m_thumbnail], [s_id], [country_id], [m_description], [m_duration]) VALUES (15, N'The Lord of the Rings: The Return of the King', 2003, 16, N'https://www.youtube.com/watch?v=y2rYRu8UW8M', N'Lord_of_the_Rings_-_The_Return_of_the_King.jpg', 8, 2, N'In the film, Frodo Baggins, Sam and Gollum are making their final way toward Mount Doom in Mordor in order to destroy the One Ring, unbeknownst to Gollum''s dark intentions, while Gandalf, Aragorn, Legolas and the rest are joining forces together against Sauron and his legions in Minas Tirith.', 200)
INSERT [dbo].[Movie] ([m_id], [m_name], [m_year], [m_views], [m_trailer], [m_thumbnail], [s_id], [country_id], [m_description], [m_duration]) VALUES (16, N'The Hobbit: The Battle of the Five Armies ', 2014, 17, N'https://www.youtube.com/watch?v=ZSzeFFsKEt4', N'The_Hobbit_-_The_Battle_of_the_Five_Armies.jpg', 8, 2, N'The Hobbit: The Battle of the Five Armies is a 2014 epic high fantasy action adventure film directed by Peter Jackson and written by Jackson, Fran Walsh, Philippa Boyens, and Guillermo del Toro. It is the third and final installment in Peter Jackson''s three-part film adaptation based on the novel The Hobbit by J. R. R. Tolkien, following An Unexpected Journey (2012) and The Desolation of Smaug (2013), and together they act as a prequel to Jackson''s The Lord of the Rings film trilogy.', 144)
INSERT [dbo].[Movie] ([m_id], [m_name], [m_year], [m_views], [m_trailer], [m_thumbnail], [s_id], [country_id], [m_description], [m_duration]) VALUES (20, N'Interstellar', 2014, 18, N'https://www.youtube.com/watch?v=0vxOhd4qlnA', N'Interstellar_film_poster.jpg', 3, 2, N'Set in a dystopian future where humanity is struggling to survive, the film follows a group of astronauts who travel through a wormhole near Saturn in search of a new home for humanity.', 169)
INSERT [dbo].[Movie] ([m_id], [m_name], [m_year], [m_views], [m_trailer], [m_thumbnail], [s_id], [country_id], [m_description], [m_duration]) VALUES (21, N'Captain Marvel', 2019, 12, N'https://www.youtube.com/watch?v=Z1BCujX3pw8', N'captainMarvel.jpg', 7, 2, N'Set in 1995, the story follows Danvers as she becomes Captain Marvel after Earth is caught in the center of a galactic conflict between two alien civilizations', 124)
INSERT [dbo].[Movie] ([m_id], [m_name], [m_year], [m_views], [m_trailer], [m_thumbnail], [s_id], [country_id], [m_description], [m_duration]) VALUES (22, N'Aquaman', 2018, 12, N'https://www.youtube.com/watch?v=WDkg3h8PCVU', N'aquaman.jpg', 3, 2, N'In the film, the titular character learns he is the heir to the underwater kingdom of Atlantis and must step forward to lead his people against his half-brother, Orm, who seeks to unite the seven underwater kingdoms against the surface world', 143)
INSERT [dbo].[Movie] ([m_id], [m_name], [m_year], [m_views], [m_trailer], [m_thumbnail], [s_id], [country_id], [m_description], [m_duration]) VALUES (23, N'John Wick', 2014, 19, N'https://www.youtube.com/watch?v=2AUmvWm5ZDQ', N'John_Wick_TeaserPoster.jpg', 9, 2, N'The story focuses on John Wick (Reeves), searching for the men who broke into his home, stole his vintage car and killed his puppy, which was a last gift to him from his recently deceased wife', 101)
INSERT [dbo].[Movie] ([m_id], [m_name], [m_year], [m_views], [m_trailer], [m_thumbnail], [s_id], [country_id], [m_description], [m_duration]) VALUES (24, N'John Wick: Chapter 3 – Parabellum', 2019, 1, N'https://www.youtube.com/watch?v=pU8-7BX9uxs', N'John_Wick_Chapter_3_Parabellum.png', 9, 2, N'In the film which takes place one hour after the events of the previous film, ex-hitman John Wick finds himself on the run from legions of assassins after a $14 million contract is put on his head due to his recent actions.', 131)
INSERT [dbo].[Movie] ([m_id], [m_name], [m_year], [m_views], [m_trailer], [m_thumbnail], [s_id], [country_id], [m_description], [m_duration]) VALUES (25, N'Spider-Man: Far From Home', 2019, 1, N'https://www.youtube.com/watch?v=Nt9L1jCKGnE', N'Spider-Man_Far_From_Home_poster.jpg', 7, 2, N'By October 2016, discussions had begun for a sequel to Spider-Man: Homecoming, with a release date ', 129)
INSERT [dbo].[Movie] ([m_id], [m_name], [m_year], [m_views], [m_trailer], [m_thumbnail], [s_id], [country_id], [m_description], [m_duration]) VALUES (38, N'Life of Thanh #2', 2020, 0, N'Not supported in Lite version', N'Not supported in Lite version', 10, 1, N'The story about a simple life of Hieu Thanh', 112)
SET IDENTITY_INSERT [dbo].[Movie] OFF
SET IDENTITY_INSERT [dbo].[Studio] ON 

INSERT [dbo].[Studio] ([s_id], [s_name]) VALUES (1, N'Disney')
INSERT [dbo].[Studio] ([s_id], [s_name]) VALUES (2, N'Universal')
INSERT [dbo].[Studio] ([s_id], [s_name]) VALUES (3, N'Warner Bros. Pictures')
INSERT [dbo].[Studio] ([s_id], [s_name]) VALUES (4, N'20th Century Fox')
INSERT [dbo].[Studio] ([s_id], [s_name]) VALUES (5, N'Sony Pictures')
INSERT [dbo].[Studio] ([s_id], [s_name]) VALUES (6, N'Paramount Pictures')
INSERT [dbo].[Studio] ([s_id], [s_name]) VALUES (7, N'Marvel Studio')
INSERT [dbo].[Studio] ([s_id], [s_name]) VALUES (8, N'New Line Cinema')
INSERT [dbo].[Studio] ([s_id], [s_name]) VALUES (9, N'Lionsgate Movies')
INSERT [dbo].[Studio] ([s_id], [s_name]) VALUES (10, N'Hieu Thanh Universal')
SET IDENTITY_INSERT [dbo].[Studio] OFF
ALTER TABLE [dbo].[ActorInMovie]  WITH CHECK ADD FOREIGN KEY([a_id])
REFERENCES [dbo].[Actor] ([a_id])
GO
ALTER TABLE [dbo].[ActorInMovie]  WITH CHECK ADD FOREIGN KEY([m_id])
REFERENCES [dbo].[Movie] ([m_id])
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD FOREIGN KEY([acc_id])
REFERENCES [dbo].[Account] ([acc_id])
GO
ALTER TABLE [dbo].[DirectorInMovie]  WITH CHECK ADD FOREIGN KEY([d_id])
REFERENCES [dbo].[Director] ([d_id])
GO
ALTER TABLE [dbo].[DirectorInMovie]  WITH CHECK ADD FOREIGN KEY([m_id])
REFERENCES [dbo].[Movie] ([m_id])
GO
ALTER TABLE [dbo].[FavoriteMovie]  WITH CHECK ADD FOREIGN KEY([c_id])
REFERENCES [dbo].[Client] ([c_id])
GO
ALTER TABLE [dbo].[FavoriteMovie]  WITH CHECK ADD FOREIGN KEY([m_id])
REFERENCES [dbo].[Movie] ([m_id])
GO
ALTER TABLE [dbo].[GenreInMovie]  WITH CHECK ADD FOREIGN KEY([g_id])
REFERENCES [dbo].[Genre] ([g_id])
GO
ALTER TABLE [dbo].[GenreInMovie]  WITH CHECK ADD FOREIGN KEY([m_id])
REFERENCES [dbo].[Movie] ([m_id])
GO
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD FOREIGN KEY([country_id])
REFERENCES [dbo].[Country] ([country_id])
GO
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD FOREIGN KEY([s_id])
REFERENCES [dbo].[Studio] ([s_id])
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [check_acc_status] CHECK  (([acc_status]=(0) OR [acc_status]=(1)))
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [check_acc_status]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD CHECK  (([acc_level]>=(0) AND [acc_level]<=(2)))
GO
ALTER TABLE [dbo].[Actor]  WITH CHECK ADD CHECK  (([a_age]>(0)))
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD CHECK  (([c_gender]=(0) OR [c_gender]=(1)))
GO
ALTER TABLE [dbo].[Director]  WITH CHECK ADD CHECK  (([d_age]>(0)))
GO
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD CHECK  (([m_duration]>(0)))
GO
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD  CONSTRAINT [CK__Movie__m_views__5441852A] CHECK  (([m_views]>=(0)))
GO
ALTER TABLE [dbo].[Movie] CHECK CONSTRAINT [CK__Movie__m_views__5441852A]
GO
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD CHECK  (([m_year]>=(1888)))
GO
USE [master]
GO
ALTER DATABASE [MovieWebsiteManager] SET  READ_WRITE 
GO
