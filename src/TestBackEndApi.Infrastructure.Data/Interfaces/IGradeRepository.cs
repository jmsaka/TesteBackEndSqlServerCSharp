using System.Collections.Generic;
using System.Threading.Tasks;
using TestBackEndApi.Infrastructure.Data.Entities;

namespace TestBackEndApi.Infrastructure.Data.Interfaces
{
    public interface IGradeRepository
    {
        Task<IEnumerable<Grade>> GetAll();

        Task<bool> Insert(GradeDto obj);

        Task<GradeAlunoDto> GetGradeAlunos(long codGrade);
    }
}