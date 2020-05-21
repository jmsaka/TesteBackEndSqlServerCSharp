using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;
using TestBackEndApi.Infrastructure.Data.Interfaces;

namespace TestBackEndApi.Domain.Queries.Professor.Get
{
    public class GetProfessorQueryHandler : IRequestHandler<GetProfessorQuery, GetProfessorQueryResponse>
    {
        private readonly IProfessorRepository _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly decimal SALARIO;
        private readonly decimal BONUS;
        private readonly int TOTAL_ALUNOS_POR_TURMA;

        public GetProfessorQueryHandler(IProfessorRepository repository, IMapper mapper, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _configuration = configuration;
            this.SALARIO = decimal.Parse(_configuration.GetSection("ParameterSettings").GetSection("Salario").Value);
            this.BONUS = decimal.Parse(_configuration.GetSection("ParameterSettings").GetSection("Bonus").Value);
            this.TOTAL_ALUNOS_POR_TURMA = int.Parse(_configuration.GetSection("ParameterSettings").GetSection("TotalAlunosPorTurma").Value);
        }

        public async Task<GetProfessorQueryResponse> Handle(GetProfessorQuery request, CancellationToken cancellationToken)
        {
            var professor = await _repository.GetInfo(request.Cpf);

            if (professor != null)
            {
                professor.Salario = (((professor.TotalAlunos / this.TOTAL_ALUNOS_POR_TURMA) * professor.TotalGrades) * BONUS) + SALARIO;
            }

            return _mapper.Map<GetProfessorQueryResponse>(professor);
        }
    }
}
