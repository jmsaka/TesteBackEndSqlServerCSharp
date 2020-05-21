using System.Collections.Generic;
using System.Threading.Tasks;
using TestBackEndApi.Infrastructure.Data.Entities;

namespace TestBackEndApi.Infrastructure.Data.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAll(string query);

        Usuario GetSingle(string query, int id);

        bool Insert(string query, Usuario obj);

        bool Delete(string query, int id);

        bool Update(string query, Usuario obj);
    }
}