using System.Threading.Tasks;
using TestBackEndApi.Infrastructure.Data.Entities;

namespace TestBackEndApi.Infrastructure.Data.Interfaces
{
    public interface IProfessorRepository
    {
        Task<ProfessorInfoDto> GetInfo(string cpf);

        bool Insert(ProfessorDto obj);
    }
}