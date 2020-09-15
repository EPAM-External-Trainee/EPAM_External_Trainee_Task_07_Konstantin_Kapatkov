CREATE TABLE [dbo].[Examiners]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NULL,
	[Patronymic] [nvarchar](max) NULL,
	CONSTRAINT [PK_dbo.Examiners] PRIMARY KEY CLUSTERED ([Id] ASC)
)