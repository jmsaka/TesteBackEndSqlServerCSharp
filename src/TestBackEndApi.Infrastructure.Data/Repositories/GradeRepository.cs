using AutoMapper;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TestBackEndApi.Infrastructure.Data.Entities;
using TestBackEndApi.Infrastructure.Data.Interfaces;

namespace TestBackEndApi.Infrastructure.Data.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly IDbConnection _conn;
        private readonly IMapper _mapper;

        public GradeRepository(IDbConnection conn, IMapper mapper)
        {
            _conn = conn;
            _mapper = mapper;
        }

        protected string SelectAllQuery => $"SELECT * FROM [{nameof(Grade)}]";

        protected string InsertQuery => $"INSERT INTO [{nameof(Grade)}] " +
            $"VALUES (@{nameof(Grade.CodGrade)}, @{nameof(Grade.NomeCurso)}, @{nameof(Grade.NomeDisciplina)}, @{nameof(Grade.NomeTurma)}, @{nameof(Professor.CodFuncionario)})";

        protected string SelectQueryProfessorExiste => $"SELECT * FROM [{nameof(Professor)}] WHERE {nameof(Professor.CodFuncionario)} = @{nameof(Professor.CodFuncionario)}";

        protected string SelectQueryAlunos =>
            $"SELECT U.{nameof(Usuario.Nome)}, A.{nameof(Aluno.Ra)}, U.{nameof(Usuario.Email)} " +
            $" FROM {nameof(Matricula)} M INNER JOIN {nameof(Aluno)} A ON A.{nameof(Aluno.Ra)} = M.{nameof(Aluno.Ra)} " +
            $" INNER JOIN {nameof(Usuario)} U ON U.{nameof(Usuario.Cpf)} = A.{nameof(Usuario.Cpf)} " +
            $"WHERE M.{nameof(Grade.CodGrade)} = @{nameof(Grade.CodGrade)}";

        protected string SelectQueryGradeAluno =>
            $"SELECT {nameof(Grade.CodGrade)}, {nameof(Grade.NomeTurma)} AS Turma, {nameof(Grade.NomeDisciplina)} AS Disciplina, " +
            $" {nameof(Grade.NomeCurso)} AS Curso, G.{nameof(Professor.CodFuncionario)}, U.{nameof(Usuario.Nome)} AS NomeProfessor, " +
            $" U.{nameof(Usuario.Cpf)} AS CpfProfessor, U.{nameof(Usuario.Email)} AS EmailProfessor" +
            $" FROM {nameof(Grade)} G INNER JOIN {nameof(Professor)} P ON P.{nameof(Professor.CodFuncionario)} = G.{nameof(Professor.CodFuncionario)} " +
            $" INNER JOIN {nameof(Usuario)} U ON U.{nameof(Usuario.Cpf)} = P.{nameof(Usuario.Cpf)} " +
            $" WHERE G.{nameof(Grade.CodGrade)} = @{nameof(Grade.CodGrade)}";

        private async Task<IEnumerable<Grade>> GetAll(string query)
        {
            IEnumerable<Grade> items = null;

            using (IDbConnection cn = _conn)
            {
                cn.Open();
                items = await cn.QueryAsync<Grade>(query);
            }

            return items;
        }

        public async Task<GradeAlunoDto> GetGradeAlunos(long codGrade)
        {
            GradeAlunoDto gradeAlunos = new GradeAlunoDto();

            using (IDbConnection cn = _conn)
            {
                cn.Open();
                var alunos = await cn.QueryAsync<Alunos>(SelectQueryAlunos, new { codGrade });

                if (alunos != null)
                    gradeAlunos = await cn.QueryFirstOrDefaultAsync<GradeAlunoDto>(SelectQueryGradeAluno, new { codGrade });

                if (gradeAlunos != null)
                    gradeAlunos.Alunos = alunos;
            }

            return gradeAlunos;
        }

        public async Task<IEnumerable<Grade>> GetAll()
        {
            return await GetAll(SelectAllQuery);
        }

        public async Task<bool> Insert(GradeDto obj)
        {
            bool result = false;

            using (var cn = _conn)
            {
                cn.Open();

                result = await cn.ExecuteScalarAsync<bool>(SelectQueryProfessorExiste, new { obj.CodFuncionario });

                if (result) result = (await cn.ExecuteAsync(InsertQuery, obj) > 0);
            }

            return result;
        }
    }
}
