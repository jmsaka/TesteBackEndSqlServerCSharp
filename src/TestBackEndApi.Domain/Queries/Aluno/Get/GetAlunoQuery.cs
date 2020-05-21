using MediatR;
using System.Collections.Generic;

namespace TestBackEndApi.Domain.Queries.Aluno.Get
{
    public class GetAlunoQuery : IRequest<IEnumerable<GetAlunoQueryResponse>>
    {
    }
}
