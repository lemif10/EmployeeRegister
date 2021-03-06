USE [EmployeeRegister]
GO
/****** Object:  Table [dbo].[AppUsers]    Script Date: 12.12.2021 01:40:19 ******/
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
/****** Object:  Table [dbo].[Contacts]    Script Date: 12.12.2021 01:40:19 ******/
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
/****** Object:  Table [dbo].[Departments]    Script Date: 12.12.2021 01:40:19 ******/
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
/****** Object:  Table [dbo].[Employees]    Script Date: 12.12.2021 01:40:19 ******/
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
SET IDENTITY_INSERT [dbo].[AppUsers] ON 

INSERT [dbo].[AppUsers] ([Id], [Email], [Login], [Password], [Role]) VALUES (10, N'misshelin1983@gmail.com', N'o.cactus', N'gnzLDuqKcGxMNKFokfhOew==', 2)
INSERT [dbo].[AppUsers] ([Id], [Email], [Login], [Password], [Role]) VALUES (6, N'lemif10084444444@yandex.ru', N'Lemif10', N'gnzLDuqKcGxMNKFokfhOew==', 2)
SET IDENTITY_INSERT [dbo].[AppUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[Contacts] ON 

INSERT [dbo].[Contacts] ([Idn], [PhoneNumber], [Email]) VALUES (7, N'+375291073818', N'lemif1008@yandex.ru')
INSERT [dbo].[Contacts] ([Idn], [PhoneNumber], [Email]) VALUES (9, N'+375291042344', N'user@mail.ru')
INSERT [dbo].[Contacts] ([Idn], [PhoneNumber], [Email]) VALUES (10, N' +375339576218', N'akazaNceva764@gmail.com')
INSERT [dbo].[Contacts] ([Idn], [PhoneNumber], [Email]) VALUES (11, N'+375294017385', N'kolka_intelektual54@gmail.com')
INSERT [dbo].[Contacts] ([Idn], [PhoneNumber], [Email]) VALUES (12, N'+375291930829', N'krasnopoloskin1@gmail.com')
INSERT [dbo].[Contacts] ([Idn], [PhoneNumber], [Email]) VALUES (13, N' +375294492615', N'evgeshkap882@gmail.com')
INSERT [dbo].[Contacts] ([Idn], [PhoneNumber], [Email]) VALUES (14, N' +375299137243', N'lemif1008@yandex.ru')
INSERT [dbo].[Contacts] ([Idn], [PhoneNumber], [Email]) VALUES (15, N'+375291004703', N'prostoludin@gmail.com')
INSERT [dbo].[Contacts] ([Idn], [PhoneNumber], [Email]) VALUES (16, N' +375298264111', N'markusha3333@gmail.com')
INSERT [dbo].[Contacts] ([Idn], [PhoneNumber], [Email]) VALUES (17, N'+375447223015', N'semechkin26@gmail.com')
SET IDENTITY_INSERT [dbo].[Contacts] OFF
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([Idn], [Name], [PhoneNumber], [AddressD], [Description]) VALUES (1, N'ПолесГУ', N'+375294944944', N'Ул. Пушкина 4, Пинск', N'Очень сомнительное место)')
INSERT [dbo].[Departments] ([Idn], [Name], [PhoneNumber], [AddressD], [Description]) VALUES (2, N'Лицей№2', N'+375298838832', N'Ул. Гагарина 58, Могилёв', N'Оценка данного места 8 из 10')
INSERT [dbo].[Departments] ([Idn], [Name], [PhoneNumber], [AddressD], [Description]) VALUES (9, N'Библиотека: "Заря"', N'+375293442144', N'Ул. Гагарина 41, Могилёв', N'Тут молчат...')
INSERT [dbo].[Departments] ([Idn], [Name], [PhoneNumber], [AddressD], [Description]) VALUES (10, N'Кафе: "Чашка"', N'+375291384544', N'Ул. Пушкина 109, Могилёв                  ', N'Кафешка в которой пьют из чашки')
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([Id], [FullName], [DepartmentId], [Address], [FamilyStatus], [WorkExperience], [Photo], [Salary]) VALUES (7, N'Dima Burak', 1, N'Ул. Пушкина 4, Пинск', 0, CAST(32.0 AS Decimal(18, 1)), NULL, CAST(421.00 AS Decimal(18, 2)))
INSERT [dbo].[Employees] ([Id], [FullName], [DepartmentId], [Address], [FamilyStatus], [WorkExperience], [Photo], [Salary]) VALUES (9, N'Danila Kovalev', 1, N'ул. Золотые горы 43, Где-то', 0, CAST(3.6 AS Decimal(18, 1)), NULL, CAST(600.00 AS Decimal(18, 2)))
INSERT [dbo].[Employees] ([Id], [FullName], [DepartmentId], [Address], [FamilyStatus], [WorkExperience], [Photo], [Salary]) VALUES (10, N'Alesya Kazantseva', 10, N'ул. Лесная 24, Тюмень', 1, CAST(20.3 AS Decimal(18, 1)), NULL, CAST(736.00 AS Decimal(18, 2)))
INSERT [dbo].[Employees] ([Id], [FullName], [DepartmentId], [Address], [FamilyStatus], [WorkExperience], [Photo], [Salary]) VALUES (11, N' Kolya Iskhakov', 1, N'ул. Придорожная 8, Магнитогорск', 0, CAST(2.8 AS Decimal(18, 1)), NULL, CAST(1663.40 AS Decimal(18, 2)))
INSERT [dbo].[Employees] ([Id], [FullName], [DepartmentId], [Address], [FamilyStatus], [WorkExperience], [Photo], [Salary]) VALUES (12, N'Senya Krasnopoloskin', 9, N'ул. Дунника 51, Мурманск', 0, CAST(14.0 AS Decimal(18, 1)), NULL, CAST(1319.20 AS Decimal(18, 2)))
INSERT [dbo].[Employees] ([Id], [FullName], [DepartmentId], [Address], [FamilyStatus], [WorkExperience], [Photo], [Salary]) VALUES (13, N' Evgeniya Pozner', 10, N'ул. Садовая 19, Урюпинс', 2, CAST(12.8 AS Decimal(18, 1)), NULL, CAST(1537.10 AS Decimal(18, 2)))
INSERT [dbo].[Employees] ([Id], [FullName], [DepartmentId], [Address], [FamilyStatus], [WorkExperience], [Photo], [Salary]) VALUES (14, N'Elena Passa', 2, N'ул. Гайдунова 93, Саратов', 1, CAST(18.5 AS Decimal(18, 1)), NULL, CAST(2372.40 AS Decimal(18, 2)))
INSERT [dbo].[Employees] ([Id], [FullName], [DepartmentId], [Address], [FamilyStatus], [WorkExperience], [Photo], [Salary]) VALUES (15, N'Borislav Chekh', 2, N'ул. Этикетная 93, Изяславль', 0, CAST(8.8 AS Decimal(18, 1)), NULL, CAST(442.60 AS Decimal(18, 2)))
INSERT [dbo].[Employees] ([Id], [FullName], [DepartmentId], [Address], [FamilyStatus], [WorkExperience], [Photo], [Salary]) VALUES (16, N' Mark Ilyin', 9, N' ул. Широкая 5, Пенкино', 1, CAST(1.5 AS Decimal(18, 1)), NULL, CAST(532.80 AS Decimal(18, 2)))
INSERT [dbo].[Employees] ([Id], [FullName], [DepartmentId], [Address], [FamilyStatus], [WorkExperience], [Photo], [Salary]) VALUES (17, N'Semyon Semechkin', 1, N' ул. Циалковского 26, Мосты', 2, CAST(41.0 AS Decimal(18, 1)), NULL, CAST(882.10 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Employees] OFF
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
