using System.Collections.Generic;
using System.Threading.Tasks;
using TestBackEndApi.Infrastructure.Data.Entities;

namespace TestBackEndApi.Infrastructure.Data.Interfaces
{
    public interface IMatriculaRepository
    {
        Task<IEnumerable<Matricula>> GetAll();

        Task<bool> Insert(MatriculaDto obj);

        Task<bool> Delete(MatriculaDto obj);
    }
}