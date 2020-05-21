using System.Collections.Generic;
using System.Threading.Tasks;
using TestBackEndApi.Infrastructure.Data.Entities;

namespace TestBackEndApi.Infrastructure.Data.Interfaces
{
    public interface IAlunoRepository
    {
        Task<IEnumerable<Aluno>> GetAll();

        bool Insert(AlunoDto obj);
    }
}