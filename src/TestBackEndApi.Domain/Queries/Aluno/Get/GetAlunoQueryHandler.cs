using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TestBackEndApi.Infrastructure.Data.Interfaces;

namespace TestBackEndApi.Domain.Queries.Aluno.Get
{
    public class GetAlunoQueryHandler : IRequestHandler<GetAlunoQuery, IEnumerable<GetAlunoQueryResponse>>
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;

        public GetAlunoQueryHandler(IAlunoRepository alunoRepository, IMapper mapper)
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAlunoQueryResponse>> Handle(GetAlunoQuery request, CancellationToken cancellationToken)
        {
            var results = await _alunoRepository.GetAll();
            return _mapper.Map<IEnumerable<GetAlunoQueryResponse>>(results);
        }
    }
}
