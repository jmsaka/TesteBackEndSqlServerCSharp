using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TestBackEndApi.Infrastructure.Data.Entities;
using TestBackEndApi.Infrastructure.Data.Interfaces;

namespace TestBackEndApi.Domain.Commands.Grades.Post
{
    public class GradeCommandHandler : IRequestHandler<GradeCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IGradeRepository _repo;

        public GradeCommandHandler(IMapper mapper, IGradeRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<bool> Handle(GradeCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Insert(_mapper.Map<GradeDto>(request));
        }
    }
}
