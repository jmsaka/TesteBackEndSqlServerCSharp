namespace TestBackEndApi.Infrastructure.Data.Entities
{
    public class ProfessorDto
    {
        public string Nome { get; set; }

        public long Cpf { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public string Email { get; set; }

        public long CodFuncionario { get; set; }
    }
}
