CREATE TABLE [dbo].[GroupSpecialties]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.GroupSpecialties] PRIMARY KEY CLUSTERED ([Id] ASC)
)