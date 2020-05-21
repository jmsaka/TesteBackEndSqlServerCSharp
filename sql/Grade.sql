CREATE TABLE [dbo].[Grade](
	[CodGrade] [bigint] NOT NULL,
	[NomeCurso] [varchar](255) NOT NULL,
	[NomeDisciplina] [varchar](255) NOT NULL,
	[NomeTurma] [varchar](255) NOT NULL,
	[CodFuncionario] [bigint] NOT NULL,
 CONSTRAINT [PK_Grade] PRIMARY KEY CLUSTERED 
(
	[CodGrade] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Grade]  WITH CHECK ADD  CONSTRAINT [FK_Grade_Professor] FOREIGN KEY([CodFuncionario])
REFERENCES [dbo].[Professor] ([CodFuncionario])
GO

ALTER TABLE [dbo].[Grade] CHECK CONSTRAINT [FK_Grade_Professor]
GO


