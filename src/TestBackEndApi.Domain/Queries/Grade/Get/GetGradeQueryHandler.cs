using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TestBackEndApi.Infrastructure.Data.Interfaces;

namespace TestBackEndApi.Domain.Queries.Grade.Get
{
    public class GetGradeQueryHandler : IRequestHandler<GetGradeQuery, GetGradeQueryResponse>
    {
        private readonly IGradeRepository _repository;
        private readonly IMapper _mapper;

        public GetGradeQueryHandler(IGradeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetGradeQueryResponse> Handle(GetGradeQuery request, CancellationToken cancellationToken)
        {
            var results = await _repository.GetGradeAlunos(request.CodGrade);
            return _mapper.Map<GetGradeQueryResponse>(results);
        }
    }
}
