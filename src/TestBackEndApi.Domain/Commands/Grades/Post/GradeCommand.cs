using MediatR;

namespace TestBackEndApi.Domain.Commands.Grades.Post
{
    public class GradeCommand : IRequest<bool>
    {
        public long CodGrade { get; set; }

        public string Turma { get; set; }

        public string Disciplina { get; set; }

        public string Curso { get; set; }

        public long CodFuncionario { get; set; }
    }
}
