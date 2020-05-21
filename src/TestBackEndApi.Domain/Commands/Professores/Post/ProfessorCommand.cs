using MediatR;

namespace TestBackEndApi.Domain.Commands.Professores.Post
{
    public class ProfessorCommand : IRequest<bool>
    {
        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public string Email { get; set; }

        public long Codigo { get; set; }
    }
}
