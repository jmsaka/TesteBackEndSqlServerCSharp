CREATE TABLE [dbo].[Matricula](
	[Ra] [bigint] NOT NULL,
	[CodGrade] [bigint] NOT NULL,
	[Turma] [varchar](255) NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Matricula]  WITH CHECK ADD  CONSTRAINT [FK_Matricula_Aluno] FOREIGN KEY([Ra])
REFERENCES [dbo].[Aluno] ([Ra])
GO

ALTER TABLE [dbo].[Matricula] CHECK CONSTRAINT [FK_Matricula_Aluno]
GO

ALTER TABLE [dbo].[Matricula]  WITH CHECK ADD  CONSTRAINT [FK_Matricula_Grade] FOREIGN KEY([CodGrade])
REFERENCES [dbo].[Grade] ([CodGrade])
GO

ALTER TABLE [dbo].[Matricula] CHECK CONSTRAINT [FK_Matricula_Grade]
GO


