using AutoMapper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TestBackEndApi.Infrastructure.Data.Entities;
using TestBackEndApi.Infrastructure.Data.Interfaces;

namespace TestBackEndApi.Infrastructure.Data.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly IDbConnection _conn;
        private readonly IMapper _mapper;

        public AlunoRepository(IDbConnection conn, IMapper mapper)
        {
            _conn = conn;
            _mapper = mapper;
        }

        protected string InsertQueryReturnInserted => $"INSERT INTO [{nameof(Usuario)}] " + // OUTPUT INSERTED.* " +
            $"VALUES (@{nameof(Usuario.Nome)},@{nameof(Usuario.Cpf)},@{nameof(Usuario.Email)},@{nameof(Usuario.Login)},@{nameof(Usuario.Senha)})";

        protected string SelectAllQuery => $"SELECT U.Nome, U.Cpf, U.Login, U.Senha, U.Email, A.Ra " +
            $" FROM Usuario U INNER JOIN Aluno A ON A.Cpf = U.Cpf";

        protected string InsertQuery => $"INSERT INTO [{nameof(Aluno)}] " +
            $"VALUES (@{nameof(Aluno.Ra)}, @{nameof(Usuario.Cpf)})";

        private async Task<IEnumerable<Aluno>> GetAll(string query)
        {
            IEnumerable<Aluno> items = null;

            using (IDbConnection cn = _conn)
            {
                cn.Open();
                items = _mapper.Map<IEnumerable<Aluno>>(await cn.QueryAsync<AlunoDto>(query));
            }

            return items;
        }

        public async Task<IEnumerable<Aluno>> GetAll()
        {
            return await GetAll(SelectAllQuery);
        }

        public bool Insert(AlunoDto obj)
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

                        result = cn.Execute(InsertQuery, new { obj.Ra, obj.Cpf }, transaction: _tran);

                        if (result <= 0) throw new Exception("Erro ao gravar Aluno");

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
