using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TestBackEndApi.Infrastructure.Data.Entities;
using TestBackEndApi.Infrastructure.Data.Interfaces;

namespace TestBackEndApi.Domain.Commands.Matriculas.Post
{
    public class PostMatriculaCommandHandler : IRequestHandler<PostMatriculaCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IMatriculaRepository _repo;

        public PostMatriculaCommandHandler(IMapper mapper, IMatriculaRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<bool> Handle(PostMatriculaCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Insert(_mapper.Map<MatriculaDto>(request));
        }
    }
}
