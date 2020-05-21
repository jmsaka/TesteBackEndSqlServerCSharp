namespace TestBackEndApi.Infrastructure.Data.Entities
{
    public class ProfessorInfoDto
    {
        public long CodFuncionario { get; set; }

        public string Nome { get; set; }

        public long Cpf { get; set; }

        public string Email { get; set; }

        public int TotalGrades { get; set; }

        public int TotalAlunos { get; set; }

        public decimal Salario { get; set; }
    }
}
