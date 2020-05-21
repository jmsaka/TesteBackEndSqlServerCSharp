using AutoMapper;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Threading.Tasks;
using TestBackEndApi.Infrastructure.Data.Entities;
using TestBackEndApi.Infrastructure.Data.Interfaces;

namespace TestBackEndApi.Infrastructure.Data.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly IDbConnection _conn;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly int TOTAL_ALUNOS_POR_TURMA;

        public ProfessorRepository(IDbConnection conn, IMapper mapper, IConfiguration configuration)
        {
            _conn = conn;
            _mapper = mapper;
            _configuration = configuration;
            this.TOTAL_ALUNOS_POR_TURMA = int.Parse(_configuration.GetSection("ParameterSettings").GetSection("TotalAlunosPorTurma").Value);
        }

        protected string InsertQueryReturnInserted => $"INSERT INTO [{nameof(Usuario)}] " +
            $"VALUES (@{nameof(Usuario.Nome)},@{nameof(Usuario.Cpf)},@{nameof(Usuario.Email)},@{nameof(Usuario.Login)},@{nameof(Usuario.Senha)})";

        protected string SelectInfoQuery => $"SELECT T.CodFuncionario, T.Nome, T.Cpf, T.Email, SUM(T.Alunos) AS TotalAlunos, SUM(T.Grades) AS TotalGrades " +
            $" FROM (SELECT P.CodFuncionario, U.Nome, P.Cpf, U.Email, G.CodGrade, Count(G.CodGrade) Alunos, " +
            $" IIF((Count(M.Turma) <= {this.TOTAL_ALUNOS_POR_TURMA}), 1, IIF((Count(G.CodGrade) % {this.TOTAL_ALUNOS_POR_TURMA} = 0)," +
            $" Count(G.CodGrade) / {this.TOTAL_ALUNOS_POR_TURMA}, Count(G.CodGrade) % {this.TOTAL_ALUNOS_POR_TURMA}))  Grades " +
            $" FROM Matricula M INNER JOIN Grade G ON G.CodGrade = M.CodGrade INNER JOIN Professor P ON P.CodFuncionario = G.CodFuncionario " +
            $" INNER JOIN Usuario U ON U.Cpf = P.Cpf WHERE P.Cpf = @{nameof(Usuario.Cpf)} GROUP BY " +
            $" P.CodFuncionario, U.Nome, G.CodGrade, P.Cpf, U.Email) T GROUP BY T.CodFuncionario, T.Nome, T.Cpf, T.Email";

        protected string InsertQuery => $"INSERT INTO [{nameof(Professor)}] " +
            $"VALUES (@{nameof(Professor.CodFuncionario)}, @{nameof(Usuario.Cpf)})";

        public async Task<ProfessorInfoDto> GetInfo(string cpf)
        {
            using (IDbConnection cn = _conn)
            {
                cn.Open();
                var professor = await cn.QueryFirstOrDefaultAsync<ProfessorInfoDto>(SelectInfoQuery, new { cpf });



                return professor;
            }


        }

        public bool Insert(ProfessorDto obj)
        {
            using (var cn = _conn)
            {
                cn.Open();

                using (IDbTransaction _tran = cn.BeginTransaction())
                {
                    try
                    {
                        int result = cn.Execute(InsertQueryReturnInserted, obj, transaction: _tran);

                        if (result <= 0) throw new Exception("Erro ao gravar Usuário");

                        result = cn.Execute(InsertQuery, new { obj.CodFuncionario, obj.Cpf }, transaction: _tran);

                        if (result <= 0) throw new Exception("Erro ao gravar Professor");

                        _tran.Commit();
                    }
                    catch
                    {
                        _tran.Rollback();
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
