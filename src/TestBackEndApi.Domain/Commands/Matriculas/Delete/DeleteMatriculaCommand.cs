using MediatR;

namespace TestBackEndApi.Domain.Commands.Matriculas.Post
{
    public class DeleteMatriculaCommand : IRequest<bool>
    {
        public long CodGrade { get; set; }

        public long Ra { get; set; }
    }
}
