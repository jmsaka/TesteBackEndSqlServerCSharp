using MediatR;

namespace TestBackEndApi.Domain.Queries.Professor.Get
{
    public class GetProfessorQuery : IRequest<GetProfessorQueryResponse>
    {
        public string Cpf { get; set; }
    }
}
