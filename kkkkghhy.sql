USE [DIPLOM_LIZA]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 22.06.2023 12:53:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Region] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NOT NULL,
	[PostalCode] [nvarchar](max) NOT NULL,
	[Street] [nvarchar](max) NOT NULL,
	[House] [int] NOT NULL,
	[Housing] [nvarchar](max) NOT NULL,
	[Apartament] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Educations]    Script Date: 22.06.2023 12:53:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Educations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Educations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FamilyStatuses]    Script Date: 22.06.2023 12:53:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FamilyStatuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_FamilyStatuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genders]    Script Date: 22.06.2023 12:53:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Genders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INNs]    Script Date: 22.06.2023 12:53:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INNs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_INNs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobTitles]    Script Date: 22.06.2023 12:53:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobTitles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_JobTitles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobVacancys]    Script Date: 22.06.2023 12:53:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobVacancys](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Earnings] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_JobVacancys] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MilitryDuties]    Script Date: 22.06.2023 12:53:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MilitryDuties](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_MilitryDuties] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Passports]    Script Date: 22.06.2023 12:53:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passports](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Series] [int] NOT NULL,
	[Number] [int] NOT NULL,
	[IssuedBy] [nvarchar](max) NOT NULL,
	[IssuedByDate] [nvarchar](max) NOT NULL,
	[Registration] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Passports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlaceOfStudys]    Script Date: 22.06.2023 12:53:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlaceOfStudys](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Speciality] [nvarchar](max) NOT NULL,
	[EducationId] [int] NOT NULL,
 CONSTRAINT [PK_PlaceOfStudys] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questionnares]    Script Date: 22.06.2023 12:53:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questionnares](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[MiddleName] [nvarchar](max) NOT NULL,
	[Photo] [nvarchar](max) NOT NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[MeetingDate] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[WorkExperienceId] [int] NULL,
	[FamilyStatusId] [int] NOT NULL,
	[MilitryDutyId] [int] NOT NULL,
	[GenderId] [int] NOT NULL,
	[JobVacancyId] [int] NOT NULL,
	[PlaceOfStudyId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Recommendations] [nvarchar](max) NULL,
	[Skills] [nvarchar](max) NULL,
	[PersonalQualities] [nvarchar](max) NOT NULL,
	[AboutMe] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Questionnares] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 22.06.2023 12:53:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SNILSs]    Script Date: 22.06.2023 12:53:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SNILSs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_SNILSs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staffs]    Script Date: 22.06.2023 12:53:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staffs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[MiddleName] [nvarchar](max) NOT NULL,
	[Photo] [nvarchar](max) NOT NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[EnrollmentDate] [datetime2](7) NOT NULL,
	[PassportId] [int] NULL,
	[AddressId] [int] NOT NULL,
	[SNILSId] [int] NOT NULL,
	[INNId] [int] NOT NULL,
	[FamilyStatusId] [int] NOT NULL,
	[MilitryDutyId] [int] NOT NULL,
	[GenderId] [int] NOT NULL,
	[JobTitleId] [int] NOT NULL,
	[PlaceOfStudyId] [int] NOT NULL,
 CONSTRAINT [PK_Staffs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 22.06.2023 12:53:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkExperiences]    Script Date: 22.06.2023 12:53:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkExperiences](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SpaseOfWork] [nvarchar](max) NOT NULL,
	[HoursWorked] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_WorkExperiences] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Addresses] ON 

INSERT [dbo].[Addresses] ([Id], [Region], [City], [PostalCode], [Street], [House], [Housing], [Apartament]) VALUES (1, N'Ростовская область', N'Волгодонск', N'347386', N'Апрельская', 12, N'-', N'-')
INSERT [dbo].[Addresses] ([Id], [Region], [City], [PostalCode], [Street], [House], [Housing], [Apartament]) VALUES (2, N'Ростовская область', N'Волгодонск', N'307589', N'Черникова', 22, N'-', N'4')
INSERT [dbo].[Addresses] ([Id], [Region], [City], [PostalCode], [Street], [House], [Housing], [Apartament]) VALUES (3, N'Ростовская область', N'Волгодонск', N'347956', N'Натальина роща', 5, N'-', N'-')
INSERT [dbo].[Addresses] ([Id], [Region], [City], [PostalCode], [Street], [House], [Housing], [Apartament]) VALUES (4, N'Ростовская область', N'Волгодонск', N'365256', N'Васильковая', 23, N'-', N'-')
INSERT [dbo].[Addresses] ([Id], [Region], [City], [PostalCode], [Street], [House], [Housing], [Apartament]) VALUES (5, N'Ростовская область', N'Волгодонск', N'347386', N'Энтузиастов', 53, N'а', N'75')
INSERT [dbo].[Addresses] ([Id], [Region], [City], [PostalCode], [Street], [House], [Housing], [Apartament]) VALUES (6, N'Ростовская область', N'Волгодонск', N'345256', N'К.Маркса', 52, N'-', N'1')
INSERT [dbo].[Addresses] ([Id], [Region], [City], [PostalCode], [Street], [House], [Housing], [Apartament]) VALUES (16, N'Ростовская', N'Волгодонск', N'563258', N'Апрельская', 10, N'-', N'-')
INSERT [dbo].[Addresses] ([Id], [Region], [City], [PostalCode], [Street], [House], [Housing], [Apartament]) VALUES (17, N'Ростовская', N'Волгодонск', N'563258', N'Апрельская', 10, N'', N'')
INSERT [dbo].[Addresses] ([Id], [Region], [City], [PostalCode], [Street], [House], [Housing], [Apartament]) VALUES (19, N'dw', N'fsdagsad', N'gsadg', N'gdsagf', 3, N'-', N'-')
SET IDENTITY_INSERT [dbo].[Addresses] OFF
GO
SET IDENTITY_INSERT [dbo].[Educations] ON 

INSERT [dbo].[Educations] ([Id], [Title]) VALUES (1, N'Среднее общее')
INSERT [dbo].[Educations] ([Id], [Title]) VALUES (2, N'Среднее профессиональное')
INSERT [dbo].[Educations] ([Id], [Title]) VALUES (3, N'Среднее общее')
INSERT [dbo].[Educations] ([Id], [Title]) VALUES (4, N'Среднее профессиональное неполное')
INSERT [dbo].[Educations] ([Id], [Title]) VALUES (5, N'Высшее')
INSERT [dbo].[Educations] ([Id], [Title]) VALUES (6, N'Высшее неполное')
SET IDENTITY_INSERT [dbo].[Educations] OFF
GO
SET IDENTITY_INSERT [dbo].[FamilyStatuses] ON 

INSERT [dbo].[FamilyStatuses] ([Id], [Title]) VALUES (1, N'Не замужем')
INSERT [dbo].[FamilyStatuses] ([Id], [Title]) VALUES (2, N'Не женат')
INSERT [dbo].[FamilyStatuses] ([Id], [Title]) VALUES (3, N'Замужем')
INSERT [dbo].[FamilyStatuses] ([Id], [Title]) VALUES (4, N'Женат')
INSERT [dbo].[FamilyStatuses] ([Id], [Title]) VALUES (5, N'Гражданский брак')
SET IDENTITY_INSERT [dbo].[FamilyStatuses] OFF
GO
SET IDENTITY_INSERT [dbo].[Genders] ON 

INSERT [dbo].[Genders] ([Id], [Title]) VALUES (1, N'Муж')
INSERT [dbo].[Genders] ([Id], [Title]) VALUES (2, N'Жен')
SET IDENTITY_INSERT [dbo].[Genders] OFF
GO
SET IDENTITY_INSERT [dbo].[INNs] ON 

INSERT [dbo].[INNs] ([Id], [Title]) VALUES (1, N'12547560003')
INSERT [dbo].[INNs] ([Id], [Title]) VALUES (2, N'58900360025')
INSERT [dbo].[INNs] ([Id], [Title]) VALUES (3, N'80000654789')
INSERT [dbo].[INNs] ([Id], [Title]) VALUES (4, N'54445880003')
INSERT [dbo].[INNs] ([Id], [Title]) VALUES (5, N'11200065890')
INSERT [dbo].[INNs] ([Id], [Title]) VALUES (6, N'58823659855')
INSERT [dbo].[INNs] ([Id], [Title]) VALUES (7, N'42352523525')
INSERT [dbo].[INNs] ([Id], [Title]) VALUES (8, N'99999999999')
INSERT [dbo].[INNs] ([Id], [Title]) VALUES (9, N'5896523002')
SET IDENTITY_INSERT [dbo].[INNs] OFF
GO
SET IDENTITY_INSERT [dbo].[JobTitles] ON 

INSERT [dbo].[JobTitles] ([Id], [Title]) VALUES (1, N'Разработчик')
INSERT [dbo].[JobTitles] ([Id], [Title]) VALUES (2, N'Тех. поддержка')
INSERT [dbo].[JobTitles] ([Id], [Title]) VALUES (3, N'Менеджер по продажам')
INSERT [dbo].[JobTitles] ([Id], [Title]) VALUES (4, N'Финансовый департамент')
INSERT [dbo].[JobTitles] ([Id], [Title]) VALUES (5, N'Маркетинг')
INSERT [dbo].[JobTitles] ([Id], [Title]) VALUES (6, N'Отдел кадров')
INSERT [dbo].[JobTitles] ([Id], [Title]) VALUES (7, N'Менеджер по закупкам')
INSERT [dbo].[JobTitles] ([Id], [Title]) VALUES (8, N'Контроль кажества')
SET IDENTITY_INSERT [dbo].[JobTitles] OFF
GO
SET IDENTITY_INSERT [dbo].[JobVacancys] ON 

INSERT [dbo].[JobVacancys] ([Id], [Title], [Earnings], [Description]) VALUES (1, N'Главный бухгалтер', N'от 45.560 до вычета налогов', N'Ведение налогового и бухгалтерского учета. ООО на ОСН. Оптовая торговля, производство. Численность сотрудников до 10-ти человек.')
INSERT [dbo].[JobVacancys] ([Id], [Title], [Earnings], [Description]) VALUES (2, N'Специалист технической поддержки на чатах (удаленно)', N'от 41 500 до 51 000 руб. до вычета налогов', N'Помогать Клиентам в чатах, мессенджерах по базовым техническим вопросам.Консультировать Клиентов по продуктам и услугам компании.Формировать позитивный настрой от общения')
INSERT [dbo].[JobVacancys] ([Id], [Title], [Earnings], [Description]) VALUES (3, N'Инженер-программист', N'от 30 000 до 35 000 руб. на руки', N'участие в разработке программного обеспечения; написание десктоповых приложений на С#; оптимизация существующего кода.')
INSERT [dbo].[JobVacancys] ([Id], [Title], [Earnings], [Description]) VALUES (4, N'Уборщик', N'1000', N'Убирать')
SET IDENTITY_INSERT [dbo].[JobVacancys] OFF
GO
SET IDENTITY_INSERT [dbo].[MilitryDuties] ON 

INSERT [dbo].[MilitryDuties] ([Id], [Title]) VALUES (1, N'Служил')
INSERT [dbo].[MilitryDuties] ([Id], [Title]) VALUES (2, N'Не служил')
INSERT [dbo].[MilitryDuties] ([Id], [Title]) VALUES (3, N'Не годен')
INSERT [dbo].[MilitryDuties] ([Id], [Title]) VALUES (4, N'Не обязана')
SET IDENTITY_INSERT [dbo].[MilitryDuties] OFF
GO
SET IDENTITY_INSERT [dbo].[Passports] ON 

INSERT [dbo].[Passports] ([Id], [Series], [Number], [IssuedBy], [IssuedByDate], [Registration]) VALUES (1, 6017, 145236, N'ГУ МВД РОССИИ ПО РОСТОВСКОЙ ОБЛАСТИ', N'12.01.2023', N'ул. Апрельская д. 12')
INSERT [dbo].[Passports] ([Id], [Series], [Number], [IssuedBy], [IssuedByDate], [Registration]) VALUES (2, 6017, 123456, N'ГУ МВД РОССИИ ПО РОСТОВСКОЙ ОБЛАСТИ', N'21.03.2021', N'ул. Черникова д. 22, кв. 4')
INSERT [dbo].[Passports] ([Id], [Series], [Number], [IssuedBy], [IssuedByDate], [Registration]) VALUES (3, 6017, 789456, N'ГУ МВД РОССИИ ПО РОСТОВСКОЙ ОБЛАСТИ', N'05.01.2022', N'ул. Натальина роща д. 5')
INSERT [dbo].[Passports] ([Id], [Series], [Number], [IssuedBy], [IssuedByDate], [Registration]) VALUES (4, 6017, 654123, N'ГУ МВД РОССИИ ПО РОСТОВСКОЙ ОБЛАСТИ', N'12.08.2019', N'ул. Васильковая д. 23')
INSERT [dbo].[Passports] ([Id], [Series], [Number], [IssuedBy], [IssuedByDate], [Registration]) VALUES (5, 6017, 987456, N'ГУ МВД РОССИИ ПО РОСТОВСКОЙ ОБЛАСТИ', N'12.02.2023', N'ул. Энтузиастов д. 53а, кв. 75')
INSERT [dbo].[Passports] ([Id], [Series], [Number], [IssuedBy], [IssuedByDate], [Registration]) VALUES (6, 6017, 654258, N'ГУ МВД РОССИИ ПО РОСТОВСКОЙ ОБЛАСТИ', N'15.09.2020', N'ул. Карла Маркса д. 52, кв. 1')
INSERT [dbo].[Passports] ([Id], [Series], [Number], [IssuedBy], [IssuedByDate], [Registration]) VALUES (7, 6125, 956852, N'полицией', N'21-10-2012', N'Маршала-Кошевого 37, квартира 5')
SET IDENTITY_INSERT [dbo].[Passports] OFF
GO
SET IDENTITY_INSERT [dbo].[PlaceOfStudys] ON 

INSERT [dbo].[PlaceOfStudys] ([Id], [Title], [Speciality], [EducationId]) VALUES (1, N'ДГТУ', N'Программист', 6)
INSERT [dbo].[PlaceOfStudys] ([Id], [Title], [Speciality], [EducationId]) VALUES (2, N'ДГТУ', N'Психолог', 5)
INSERT [dbo].[PlaceOfStudys] ([Id], [Title], [Speciality], [EducationId]) VALUES (3, N'ВТИТБиД', N'Пррограммист', 2)
INSERT [dbo].[PlaceOfStudys] ([Id], [Title], [Speciality], [EducationId]) VALUES (4, N'МИФИ', N'Программист', 1)
INSERT [dbo].[PlaceOfStudys] ([Id], [Title], [Speciality], [EducationId]) VALUES (5, N'ВИТИ НИЯУ МИФИ', N'Сестренское дело', 2)
INSERT [dbo].[PlaceOfStudys] ([Id], [Title], [Speciality], [EducationId]) VALUES (6, N'ДГТУ', N'граф. дизайнер', 1)
INSERT [dbo].[PlaceOfStudys] ([Id], [Title], [Speciality], [EducationId]) VALUES (7, N'ВТИТБиД', N'Дизайнер', 1)
SET IDENTITY_INSERT [dbo].[PlaceOfStudys] OFF
GO
SET IDENTITY_INSERT [dbo].[Questionnares] ON 

INSERT [dbo].[Questionnares] ([Id], [FirstName], [LastName], [MiddleName], [Photo], [DateOfBirth], [Email], [Status], [MeetingDate], [Phone], [WorkExperienceId], [FamilyStatusId], [MilitryDutyId], [GenderId], [JobVacancyId], [PlaceOfStudyId], [UserId], [Recommendations], [Skills], [PersonalQualities], [AboutMe]) VALUES (1, N'Никитин', N'Марк', N'Артемьивич', N'\Resources\Pictures\_man.png', CAST(N'2000-10-10T00:00:00.0000000' AS DateTime2), N'Tima@gmail.com', N'Принято', N'05.06.2023', N'89996968580', 1, 2, 1, 1, 1, 1, 2, N'нет', N'знание одного или нескольких иностранных языков, подтвержденное тестами и экзаменами; владение языками программирования;', N'честность; ответственность; прилежность и организованность;', N'правлял рестораном на 60 посадочных мест и увеличил рейтинг отзывов клиентов с 4.2 до 4.7 в течении 6 месяцев. Контролировал поставщиков и заказы, тем самым сократил затраты на 30% в месяц.')
INSERT [dbo].[Questionnares] ([Id], [FirstName], [LastName], [MiddleName], [Photo], [DateOfBirth], [Email], [Status], [MeetingDate], [Phone], [WorkExperienceId], [FamilyStatusId], [MilitryDutyId], [GenderId], [JobVacancyId], [PlaceOfStudyId], [UserId], [Recommendations], [Skills], [PersonalQualities], [AboutMe]) VALUES (2, N'Седова', N'Виктория', N'Сергеевна', N'\Resources\Pictures\_woman.png', CAST(N'1999-10-21T00:00:00.0000000' AS DateTime2), N'ashka@gmail.com', N'Рассматривается', N'-', N'89281144447', 2, 3, 4, 2, 2, 4, 3, N'нет', N'знание одного или нескольких иностранных языков, подтвержденное тестами и экзаменами; владение языками программирования;', N'честность; ответственность; прилежность и организованность;', N'правлял рестораном на 60 посадочных мест и увеличил рейтинг отзывов клиентов с 4.2 до 4.7 в течении 6 месяцев. Контролировал поставщиков и заказы, тем самым сократил затраты на 30% в месяц.')
INSERT [dbo].[Questionnares] ([Id], [FirstName], [LastName], [MiddleName], [Photo], [DateOfBirth], [Email], [Status], [MeetingDate], [Phone], [WorkExperienceId], [FamilyStatusId], [MilitryDutyId], [GenderId], [JobVacancyId], [PlaceOfStudyId], [UserId], [Recommendations], [Skills], [PersonalQualities], [AboutMe]) VALUES (3, N'Попова', N'Александра', N'Григорьевна', N'\Resources\Pictures\_woman1.png', CAST(N'1988-05-02T00:00:00.0000000' AS DateTime2), N'Sashka@gmail.com', N'Рассматривается', N'-', N'89885145717', 3, 1, 4, 2, 3, 3, 4, N'нет', N'знание одного или нескольких иностранных языков, подтвержденное тестами и экзаменами; владение языками программирования;', N'честность; ответственность; прилежность и организованность;', N'правлял рестораном на 60 посадочных мест и увеличил рейтинг отзывов клиентов с 4.2 до 4.7 в течении 6 месяцев. Контролировал поставщиков и заказы, тем самым сократил затраты на 30% в месяц.')
SET IDENTITY_INSERT [dbo].[Questionnares] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Title]) VALUES (1, N'Сотрудник')
INSERT [dbo].[Roles] ([Id], [Title]) VALUES (2, N'Соискатель')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[SNILSs] ON 

INSERT [dbo].[SNILSs] ([Id], [Title]) VALUES (1, N'12547560003')
INSERT [dbo].[SNILSs] ([Id], [Title]) VALUES (2, N'58900360025')
INSERT [dbo].[SNILSs] ([Id], [Title]) VALUES (3, N'80000654789')
INSERT [dbo].[SNILSs] ([Id], [Title]) VALUES (4, N'54445880003')
INSERT [dbo].[SNILSs] ([Id], [Title]) VALUES (5, N'11200065890')
INSERT [dbo].[SNILSs] ([Id], [Title]) VALUES (6, N'58823659855')
INSERT [dbo].[SNILSs] ([Id], [Title]) VALUES (7, N'5412365895')
SET IDENTITY_INSERT [dbo].[SNILSs] OFF
GO
SET IDENTITY_INSERT [dbo].[Staffs] ON 

INSERT [dbo].[Staffs] ([Id], [FirstName], [LastName], [MiddleName], [Photo], [DateOfBirth], [Email], [Phone], [EnrollmentDate], [PassportId], [AddressId], [SNILSId], [INNId], [FamilyStatusId], [MilitryDutyId], [GenderId], [JobTitleId], [PlaceOfStudyId]) VALUES (1, N'Морозова', N'Милана', N'Федоровна', N'\Resources\Pictures\_woman.png', CAST(N'2023-06-04T18:08:29.6848245' AS DateTime2), N'morlan@mail.ru', N'89886958523', CAST(N'2023-06-04T18:08:29.6848257' AS DateTime2), 1, 1, 1, 1, 1, 4, 2, 2, 1)
INSERT [dbo].[Staffs] ([Id], [FirstName], [LastName], [MiddleName], [Photo], [DateOfBirth], [Email], [Phone], [EnrollmentDate], [PassportId], [AddressId], [SNILSId], [INNId], [FamilyStatusId], [MilitryDutyId], [GenderId], [JobTitleId], [PlaceOfStudyId]) VALUES (2, N'Соловьева', N'Майа', N'Львовна', N'\Resources\Pictures\_woman1.png', CAST(N'2023-06-04T18:08:41.2831703' AS DateTime2), N'solka@gmail.com', N'89284758965', CAST(N'2023-06-04T18:08:41.2831709' AS DateTime2), 2, 2, 2, 2, 1, 4, 2, 7, 1)
INSERT [dbo].[Staffs] ([Id], [FirstName], [LastName], [MiddleName], [Photo], [DateOfBirth], [Email], [Phone], [EnrollmentDate], [PassportId], [AddressId], [SNILSId], [INNId], [FamilyStatusId], [MilitryDutyId], [GenderId], [JobTitleId], [PlaceOfStudyId]) VALUES (3, N'Алексеева', N'Амина', N'Олеговна', N'\Resources\Pictures\_woman2.png', CAST(N'2023-06-04T18:08:52.4832668' AS DateTime2), N'aminka_vitminka@gmail.com', N'89965232222', CAST(N'2023-06-04T18:08:52.4832671' AS DateTime2), 3, 3, 3, 3, 3, 4, 2, 5, 1)
INSERT [dbo].[Staffs] ([Id], [FirstName], [LastName], [MiddleName], [Photo], [DateOfBirth], [Email], [Phone], [EnrollmentDate], [PassportId], [AddressId], [SNILSId], [INNId], [FamilyStatusId], [MilitryDutyId], [GenderId], [JobTitleId], [PlaceOfStudyId]) VALUES (4, N'Елисеева', N'Алиса', N'Николаевна', N'\Resources\Pictures\_woman.png', CAST(N'2023-06-04T18:09:06.2536494' AS DateTime2), N'sosiska@mail.ru', N'89284563256', CAST(N'2023-06-04T18:09:06.2536497' AS DateTime2), 4, 4, 4, 4, 3, 4, 2, 6, 1)
INSERT [dbo].[Staffs] ([Id], [FirstName], [LastName], [MiddleName], [Photo], [DateOfBirth], [Email], [Phone], [EnrollmentDate], [PassportId], [AddressId], [SNILSId], [INNId], [FamilyStatusId], [MilitryDutyId], [GenderId], [JobTitleId], [PlaceOfStudyId]) VALUES (5, N'Кузнецов', N'Михаил', N'Львович', N'\Resources\Pictures\_man1.png', CAST(N'2023-06-04T18:09:18.6936803' AS DateTime2), N'mishkaaaaa@mail.ru', N'89564525758', CAST(N'2023-06-04T18:09:18.6936807' AS DateTime2), 5, 5, 5, 5, 2, 1, 1, 1, 1)
INSERT [dbo].[Staffs] ([Id], [FirstName], [LastName], [MiddleName], [Photo], [DateOfBirth], [Email], [Phone], [EnrollmentDate], [PassportId], [AddressId], [SNILSId], [INNId], [FamilyStatusId], [MilitryDutyId], [GenderId], [JobTitleId], [PlaceOfStudyId]) VALUES (7, N'Зинаида', N'Зимина', N'Олеговна', N'\Resources\Pictures\_woman.png', CAST(N'1986-05-14T00:00:00.0000000' AS DateTime2), N'ZINAAAA123@gmail.com', N'89185236589', CAST(N'2023-06-22T11:21:26.7388762' AS DateTime2), 7, 16, 7, 9, 5, 4, 2, 2, 7)
SET IDENTITY_INSERT [dbo].[Staffs] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Login], [Password], [FirstName], [LastName], [RoleId]) VALUES (1, N'User11', N'User11', N'Крылова', N'Александра', 1)
INSERT [dbo].[Users] ([Id], [Login], [Password], [FirstName], [LastName], [RoleId]) VALUES (2, N'User2', N'User2', N'Никитин', N'Марк', 2)
INSERT [dbo].[Users] ([Id], [Login], [Password], [FirstName], [LastName], [RoleId]) VALUES (3, N'User3', N'User3', N'Седова', N'Виктория', 2)
INSERT [dbo].[Users] ([Id], [Login], [Password], [FirstName], [LastName], [RoleId]) VALUES (4, N'User4', N'User4', N'Попова', N'Александра', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[WorkExperiences] ON 

INSERT [dbo].[WorkExperiences] ([Id], [SpaseOfWork], [HoursWorked]) VALUES (1, N'ООО "Топ компания"', N'1 год 3 месяца')
INSERT [dbo].[WorkExperiences] ([Id], [SpaseOfWork], [HoursWorked]) VALUES (2, N'ООО "Капитан"', N'9 месяцев')
INSERT [dbo].[WorkExperiences] ([Id], [SpaseOfWork], [HoursWorked]) VALUES (3, N'ООО "Ромашка"', N'1 год 5 месяцев')
INSERT [dbo].[WorkExperiences] ([Id], [SpaseOfWork], [HoursWorked]) VALUES (4, N'tasgt', N'awsetwqerst')
INSERT [dbo].[WorkExperiences] ([Id], [SpaseOfWork], [HoursWorked]) VALUES (5, N'gsadfg', N'sdgasg')
INSERT [dbo].[WorkExperiences] ([Id], [SpaseOfWork], [HoursWorked]) VALUES (6, N'fgdssfg', N'sdfggdsfsg')
INSERT [dbo].[WorkExperiences] ([Id], [SpaseOfWork], [HoursWorked]) VALUES (7, N'sgfasdf', N'gsadfgdsfg')
INSERT [dbo].[WorkExperiences] ([Id], [SpaseOfWork], [HoursWorked]) VALUES (8, N'123', N'asd')
SET IDENTITY_INSERT [dbo].[WorkExperiences] OFF
GO
ALTER TABLE [dbo].[PlaceOfStudys]  WITH CHECK ADD  CONSTRAINT [FK_PlaceOfStudys_Educations_EducationId] FOREIGN KEY([EducationId])
REFERENCES [dbo].[Educations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlaceOfStudys] CHECK CONSTRAINT [FK_PlaceOfStudys_Educations_EducationId]
GO
ALTER TABLE [dbo].[Questionnares]  WITH CHECK ADD  CONSTRAINT [FK_Questionnares_FamilyStatuses_FamilyStatusId] FOREIGN KEY([FamilyStatusId])
REFERENCES [dbo].[FamilyStatuses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Questionnares] CHECK CONSTRAINT [FK_Questionnares_FamilyStatuses_FamilyStatusId]
GO
ALTER TABLE [dbo].[Questionnares]  WITH CHECK ADD  CONSTRAINT [FK_Questionnares_Genders_GenderId] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Genders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Questionnares] CHECK CONSTRAINT [FK_Questionnares_Genders_GenderId]
GO
ALTER TABLE [dbo].[Questionnares]  WITH CHECK ADD  CONSTRAINT [FK_Questionnares_JobVacancys_JobVacancyId] FOREIGN KEY([JobVacancyId])
REFERENCES [dbo].[JobVacancys] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Questionnares] CHECK CONSTRAINT [FK_Questionnares_JobVacancys_JobVacancyId]
GO
ALTER TABLE [dbo].[Questionnares]  WITH CHECK ADD  CONSTRAINT [FK_Questionnares_MilitryDuties_MilitryDutyId] FOREIGN KEY([MilitryDutyId])
REFERENCES [dbo].[MilitryDuties] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Questionnares] CHECK CONSTRAINT [FK_Questionnares_MilitryDuties_MilitryDutyId]
GO
ALTER TABLE [dbo].[Questionnares]  WITH CHECK ADD  CONSTRAINT [FK_Questionnares_PlaceOfStudys_PlaceOfStudyId] FOREIGN KEY([PlaceOfStudyId])
REFERENCES [dbo].[PlaceOfStudys] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Questionnares] CHECK CONSTRAINT [FK_Questionnares_PlaceOfStudys_PlaceOfStudyId]
GO
ALTER TABLE [dbo].[Questionnares]  WITH CHECK ADD  CONSTRAINT [FK_Questionnares_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Questionnares] CHECK CONSTRAINT [FK_Questionnares_Users_UserId]
GO
ALTER TABLE [dbo].[Questionnares]  WITH CHECK ADD  CONSTRAINT [FK_Questionnares_WorkExperiences_WorkExperienceId] FOREIGN KEY([WorkExperienceId])
REFERENCES [dbo].[WorkExperiences] ([Id])
GO
ALTER TABLE [dbo].[Questionnares] CHECK CONSTRAINT [FK_Questionnares_WorkExperiences_WorkExperienceId]
GO
ALTER TABLE [dbo].[Staffs]  WITH CHECK ADD  CONSTRAINT [FK_Staffs_Addresses_AddressId] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Staffs] CHECK CONSTRAINT [FK_Staffs_Addresses_AddressId]
GO
ALTER TABLE [dbo].[Staffs]  WITH CHECK ADD  CONSTRAINT [FK_Staffs_FamilyStatuses_FamilyStatusId] FOREIGN KEY([FamilyStatusId])
REFERENCES [dbo].[FamilyStatuses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Staffs] CHECK CONSTRAINT [FK_Staffs_FamilyStatuses_FamilyStatusId]
GO
ALTER TABLE [dbo].[Staffs]  WITH CHECK ADD  CONSTRAINT [FK_Staffs_Genders_GenderId] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Genders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Staffs] CHECK CONSTRAINT [FK_Staffs_Genders_GenderId]
GO
ALTER TABLE [dbo].[Staffs]  WITH CHECK ADD  CONSTRAINT [FK_Staffs_INNs_INNId] FOREIGN KEY([INNId])
REFERENCES [dbo].[INNs] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Staffs] CHECK CONSTRAINT [FK_Staffs_INNs_INNId]
GO
ALTER TABLE [dbo].[Staffs]  WITH CHECK ADD  CONSTRAINT [FK_Staffs_JobTitles_JobTitleId] FOREIGN KEY([JobTitleId])
REFERENCES [dbo].[JobTitles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Staffs] CHECK CONSTRAINT [FK_Staffs_JobTitles_JobTitleId]
GO
ALTER TABLE [dbo].[Staffs]  WITH CHECK ADD  CONSTRAINT [FK_Staffs_MilitryDuties_MilitryDutyId] FOREIGN KEY([MilitryDutyId])
REFERENCES [dbo].[MilitryDuties] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Staffs] CHECK CONSTRAINT [FK_Staffs_MilitryDuties_MilitryDutyId]
GO
ALTER TABLE [dbo].[Staffs]  WITH CHECK ADD  CONSTRAINT [FK_Staffs_Passports_PassportId] FOREIGN KEY([PassportId])
REFERENCES [dbo].[Passports] ([Id])
GO
ALTER TABLE [dbo].[Staffs] CHECK CONSTRAINT [FK_Staffs_Passports_PassportId]
GO
ALTER TABLE [dbo].[Staffs]  WITH CHECK ADD  CONSTRAINT [FK_Staffs_PlaceOfStudys_PlaceOfStudyId] FOREIGN KEY([PlaceOfStudyId])
REFERENCES [dbo].[PlaceOfStudys] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Staffs] CHECK CONSTRAINT [FK_Staffs_PlaceOfStudys_PlaceOfStudyId]
GO
ALTER TABLE [dbo].[Staffs]  WITH CHECK ADD  CONSTRAINT [FK_Staffs_SNILSs_SNILSId] FOREIGN KEY([SNILSId])
REFERENCES [dbo].[SNILSs] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Staffs] CHECK CONSTRAINT [FK_Staffs_SNILSs_SNILSId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles_RoleId]
GO
