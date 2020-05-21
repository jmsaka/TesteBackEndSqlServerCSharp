namespace TestBackEndApi.Infrastructure.Data.Entities
{
    public class Grade
    {
        public long CodGrade { get; set; }

        public string NomeCurso { get; set; }

        public string NomeDisciplina { get; set; }

        public string NomeTurma { get; set; }

        public Professor Professor { get; set; }
    }
}
