using AutoMapper;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TestBackEndApi.Infrastructure.Data.Entities;
using TestBackEndApi.Infrastructure.Data.Interfaces;

namespace TestBackEndApi.Infrastructure.Data.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly IDbConnection _conn;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly int TOTAL_ALUNOS_POR_TURMA;

        public MatriculaRepository(IDbConnection conn, IMapper mapper, IConfiguration configuration)
        {
            _conn = conn;
            _mapper = mapper;
            _configuration = configuration;
            this.TOTAL_ALUNOS_POR_TURMA = int.Parse(_configuration.GetSection("ParameterSettings").GetSection("TotalAlunosPorTurma").Value);
        }

        protected string SelectAllQuery => $"SELECT * FROM [{nameof(Matricula)}]";

        protected string DeleteQuery => $"DELETE FROM [{nameof(Matricula)}] " +
            $"WHERE {nameof(MatriculaDto.CodGrade)} = @{nameof(MatriculaDto.CodGrade)} AND {nameof(MatriculaDto.Ra)} = @{nameof(MatriculaDto.Ra)}";

        protected string InsertQuery => $"INSERT INTO [{nameof(Matricula)}] " +
            $"VALUES (@{nameof(MatriculaDto.Ra)}, @{nameof(MatriculaDto.CodGrade)}, @{nameof(MatriculaDto.Turma)})";

        protected string SelectQueryGradeExiste => $"SELECT * FROM [{nameof(Grade)}] WHERE {nameof(Grade.CodGrade)} = @{nameof(Grade.CodGrade)}";

        protected string SelectQueryAlunoExiste => $"SELECT * FROM [{nameof(Aluno)}] WHERE {nameof(Aluno.Ra)} = @{nameof(Aluno.Ra)}";

        private async Task<IEnumerable<Matricula>> GetAll(string query)
        {
            IEnumerable<Matricula> items = null;

            using (IDbConnection cn = _conn)
            {
                cn.Open();
                items = await cn.QueryAsync<Matricula>(query);
            }

            return items;
        }

        public async Task<IEnumerable<Matricula>> GetAll()
        {
            return await GetAll(SelectAllQuery);
        }

        public async Task<bool> Insert(MatriculaDto obj)
        {
            bool result = false;

            using (var cn = _conn)
            {
                cn.Open();

                bool grade = await cn.ExecuteScalarAsync<bool>(SelectQueryGradeExiste, new { obj.CodGrade });

                bool aluno = await cn.ExecuteScalarAsync<bool>(SelectQueryAlunoExiste, new { obj.Ra });

                if (grade && aluno) result = (await cn.ExecuteAsync(InsertQuery, obj) > 0);

                await cn.QueryAsync("Enturmacao", new { TotalAlunos = TOTAL_ALUNOS_POR_TURMA }, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public async Task<bool> Delete(MatriculaDto obj)
        {
            bool result = false;

            using (var cn = _conn)
            {
                cn.Open();

                result = (await cn.ExecuteAsync(DeleteQuery, obj) > 0);
            }

            return result;
        }
    }
}
