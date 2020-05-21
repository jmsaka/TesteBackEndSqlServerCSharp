using MediatR;

namespace TestBackEndApi.Domain.Queries.Grade.Get
{
    public class GetGradeQuery : IRequest<GetGradeQueryResponse>
    {
        public long CodGrade { get; set; }
    }
}
