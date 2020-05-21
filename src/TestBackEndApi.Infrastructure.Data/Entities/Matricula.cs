namespace TestBackEndApi.Infrastructure.Data.Entities
{
    public class Matricula
    {
        public Aluno Aluno { get; set; }

        public Grade Grade { get; set; }

        public string Turma { get; set; }
    }
}
