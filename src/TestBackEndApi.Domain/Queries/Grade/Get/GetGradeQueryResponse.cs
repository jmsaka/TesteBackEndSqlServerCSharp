using System.Collections.Generic;

namespace TestBackEndApi.Domain.Queries.Grade.Get
{
    public class GetGradeQueryResponse
    {
        public GetGradeQueryResponse() { Alunos = new List<Alunos>(); }

        public long CodGrade { get; set; }

        public string Turma { get; set; }

        public string Disciplina { get; set; }

        public string Curso { get; set; }

        public long CodFuncionario { get; set; }

        public string NomeProfessor { get; set; }

        public long CpfProfessor { get; set; }

        public string EmailProfessor { get; set; }

        public IEnumerable<Alunos> Alunos { get; set; }
    }

    public class Alunos
    {
        public string Nome { get; set; }

        public long Ra { get; set; }

        public string Email { get; set; }
    }
}
