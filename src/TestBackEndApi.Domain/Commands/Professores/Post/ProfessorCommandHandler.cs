using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TestBackEndApi.Infrastructure.Data.Entities;
using TestBackEndApi.Infrastructure.Data.Interfaces;

namespace TestBackEndApi.Domain.Commands.Professores.Post
{
    public class ProfessorCommandHandler : IRequestHandler<ProfessorCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IProfessorRepository _repo;

        public ProfessorCommandHandler(IMapper mapper, IProfessorRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public Task<bool> Handle(ProfessorCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repo.Insert(_mapper.Map<ProfessorDto>(request)));
        }
    }
}
