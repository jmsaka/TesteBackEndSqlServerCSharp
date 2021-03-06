CREATE TABLE [dbo].[Usuario](
	[Nome] [varchar](255) NOT NULL,
	[Cpf] [bigint] NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[Login] [varchar](255) NOT NULL,
	[Senha] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Usuario_1] PRIMARY KEY CLUSTERED 
(
	[Cpf] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


