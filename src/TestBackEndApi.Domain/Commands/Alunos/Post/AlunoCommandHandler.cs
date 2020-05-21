using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TestBackEndApi.Infrastructure.Data.Entities;
using TestBackEndApi.Infrastructure.Data.Interfaces;

namespace TestBackEndApi.Domain.Commands.Alunos.Post
{
    public class AlunoCommandHandler : IRequestHandler<AlunoCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IAlunoRepository _repo;

        public AlunoCommandHandler(IMapper mapper, IAlunoRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public Task<bool> Handle(AlunoCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repo.Insert(_mapper.Map<AlunoDto>(request)));
        }
    }
}
