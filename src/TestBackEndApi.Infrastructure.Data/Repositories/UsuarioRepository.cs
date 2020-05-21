using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TestBackEndApi.Infrastructure.Data.Entities;
using TestBackEndApi.Infrastructure.Data.Interfaces;

namespace TestBackEndApi.Infrastructure.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDbConnection _conn;
        private readonly IDbTransaction _tran;

        public UsuarioRepository(IDbConnection conn, IDbTransaction tran = null)
        {
            _conn = conn;
            _tran = tran;
        }

        protected string InsertQuery => $"INSERT INTO [{nameof(Usuario)}] " +
            $"VALUES (@{nameof(Usuario.Nome)},@{nameof(Usuario.Cpf)},@{nameof(Usuario.Email)},@{nameof(Usuario.Login)},@{nameof(Usuario.Senha)})";

        protected string InsertQueryReturnInserted => $"INSERT INTO [{nameof(Usuario)}] OUTPUT INSERTED.* " +
            $"VALUES (@{nameof(Usuario.Nome)},@{nameof(Usuario.Cpf)},@{nameof(Usuario.Email)},@{nameof(Usuario.Login)},@{nameof(Usuario.Senha)})";

        protected string UpdateByIdQuery => $"UPDATE [{nameof(Usuario)}] " +
                                            $"SET {nameof(Usuario.Nome)}  = @{nameof(Usuario.Nome)} " +
                                            $",   {nameof(Usuario.Email)} = @{nameof(Usuario.Email)} " +
                                            $",   {nameof(Usuario.Login)} = @{nameof(Usuario.Login)} " +
                                            $",   {nameof(Usuario.Senha)} = @{nameof(Usuario.Senha)} " +
                                            $"WHERE {nameof(Usuario.Cpf)} = @{nameof(Usuario.Cpf)}";

        protected string DeleteByIdQuery => $"DELETE FROM [{nameof(Usuario)}] WHERE {nameof(Usuario.Cpf)} = @{nameof(Usuario.Cpf)}";

        protected string SelectAllQuery => $"SELECT * FROM [{nameof(Usuario)}]";

        protected string SelectByIdQuery => $"SELECT * FROM [{nameof(Usuario)}] WHERE {nameof(Usuario.Cpf)} = @{nameof(Usuario.Cpf)}";

        public async Task<IEnumerable<Usuario>> GetAll(string query)
        {
            IEnumerable<Usuario> items = null;

            query = (query.Any() ? query : SelectAllQuery);

            using (IDbConnection cn = _conn)
            {
                cn.Open();
                items = await cn.QueryAsync<Usuario>(query);
            }

            return items;
        }

        public Usuario GetSingle(string query, int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(string query, Usuario obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string query, int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(string query, Usuario obj)
        {
            throw new NotImplementedException();
        }
    }
}
