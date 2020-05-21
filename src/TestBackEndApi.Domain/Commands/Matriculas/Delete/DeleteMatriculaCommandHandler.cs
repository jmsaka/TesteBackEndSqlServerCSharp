using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TestBackEndApi.Infrastructure.Data.Entities;
using TestBackEndApi.Infrastructure.Data.Interfaces;

namespace TestBackEndApi.Domain.Commands.Matriculas.Post
{
    public class DeleteMatriculaCommandHandler : IRequestHandler<DeleteMatriculaCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IMatriculaRepository _repo;

        public DeleteMatriculaCommandHandler(IMapper mapper, IMatriculaRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<bool> Handle(DeleteMatriculaCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Delete(_mapper.Map<MatriculaDto>(request));
        }
    }
}
