CREATE OR ALTER PROCEDURE Enturmacao @TotalAlunos Integer
AS
DECLARE @guid VARCHAR(MAX);  
DECLARE @MaxAlunos Integer = @TotalAlunos;  
DECLARE @CodGrade Bigint;
DECLARE @Quantidade Bigint;
DECLARE @QtdTurmas Bigint;
DECLARE @Turma VARCHAR(MAX);

-- Para executar => exec Enturmacao 10

BEGIN
	SET NOCOUNT ON;

	-- Pega o total de matrículas e identifica a quantidade de turmas
	-- Se encontrar esse cenário, seta o guid para uma turma com os 10 primeiros alunos
	DECLARE mat_cursor CURSOR FOR
		select CodGrade, 
			   Count(CodGrade) Quantidade, 
			   IIF((Count(CodGrade) % @MaxAlunos = 0), Count(CodGrade) / @MaxAlunos, Count(CodGrade) % @MaxAlunos) Turmas
		  from Matricula
         where Turma is null
		 group by CodGrade
		having Count(CodGrade) >= @MaxAlunos;

	OPEN mat_cursor

	FETCH NEXT FROM mat_cursor INTO @CodGrade, @Quantidade, @QtdTurmas

	WHILE @@FETCH_STATUS = 0  
	BEGIN 
		SELECT @guid = CONVERT(varchar(255), NEWID()) 

		update top (@MaxAlunos) Matricula set Turma = @guid where Turma is null

		FETCH NEXT FROM mat_cursor INTO @CodGrade, @Quantidade, @QtdTurmas
	END

	CLOSE mat_cursor  
    DEALLOCATE mat_cursor 

	-- Pega o total de matrículas com turmas setadas e que tenha menos de 10 alunos 
	-- (isso para o caso de ter ocorrido exclusão pela api de deleção de turmas)
	-- Seta para null para no próximo cadastro as turmas serem geradas
	DECLARE mat_cursor CURSOR FOR
		select CodGrade, Turma,
			   Count(Turma) Quantidade
		  from Matricula
         where Turma is not null
		 group by CodGrade, Turma
		having Count(Turma) < @MaxAlunos;

	OPEN mat_cursor

	FETCH NEXT FROM mat_cursor INTO @CodGrade, @Turma, @Quantidade

	WHILE @@FETCH_STATUS = 0  
	BEGIN 
		update top (@Quantidade) Matricula set Turma = null where Turma = @Turma

		FETCH NEXT FROM mat_cursor INTO @CodGrade, @Turma, @Quantidade
	END

	CLOSE mat_cursor  
    DEALLOCATE mat_cursor 

END;