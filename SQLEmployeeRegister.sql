USE [master]
GO
/****** Object:  Database [EmployeeRegister]    Script Date: 08.12.2021 00:39:46 ******/
CREATE DATABASE [EmployeeRegister]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmployeeRegister', FILENAME = N'D:\sql downland\MSSQL15.MSSQLSERVER\MSSQL\DATA\EmployeeRegister.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EmployeeRegister_log', FILENAME = N'D:\sql downland\MSSQL15.MSSQLSERVER\MSSQL\DATA\EmployeeRegister_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EmployeeRegister] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmployeeRegister].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmployeeRegister] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmployeeRegister] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmployeeRegister] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmployeeRegister] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmployeeRegister] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmployeeRegister] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmployeeRegister] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmployeeRegister] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmployeeRegister] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmployeeRegister] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmployeeRegister] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmployeeRegister] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmployeeRegister] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmployeeRegister] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmployeeRegister] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EmployeeRegister] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmployeeRegister] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmployeeRegister] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmployeeRegister] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmployeeRegister] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmployeeRegister] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmployeeRegister] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmployeeRegister] SET RECOVERY FULL 
GO
ALTER DATABASE [EmployeeRegister] SET  MULTI_USER 
GO
ALTER DATABASE [EmployeeRegister] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmployeeRegister] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EmployeeRegister] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EmployeeRegister] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EmployeeRegister] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EmployeeRegister] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'EmployeeRegister', N'ON'
GO
ALTER DATABASE [EmployeeRegister] SET QUERY_STORE = OFF
GO
USE [EmployeeRegister]
GO
/****** Object:  Table [dbo].[AppUsers]    Script Date: 08.12.2021 00:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Login] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[Role] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 08.12.2021 00:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[Idn] [int] IDENTITY(1,1) NOT NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[Idn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 08.12.2021 00:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[Idn] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[AddressD] [nvarchar](100) NULL,
	[Description] [nvarchar](300) NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[Idn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 08.12.2021 00:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[Address] [nvarchar](100) NULL,
	[FamilyStatus] [int] NULL,
	[WorkExperience] [decimal](18, 1) NULL,
	[Photo] [nvarchar](100) NULL,
	[Salary] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Contacts]  WITH CHECK ADD  CONSTRAINT [FK_Contacts_Employees] FOREIGN KEY([Idn])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[Contacts] CHECK CONSTRAINT [FK_Contacts_Employees]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [Employees-Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Idn])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [Employees-Departments]
GO
USE [master]
GO
ALTER DATABASE [EmployeeRegister] SET  READ_WRITE 
GO
