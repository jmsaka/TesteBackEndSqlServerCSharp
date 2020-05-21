using AutoMapper;
using TestBackEndApi.Domain.Commands.Grades.Post;
using TestBackEndApi.Infrastructure.Data.Entities;

namespace TestBackEndApi.Domain.Profiles
{
    public class GradeCommandProfile : Profile
    {
        public GradeCommandProfile()
        {
            CreateMap<GradeCommand, GradeDto>().ConstructUsingServiceLocator()
                .ForMember(o => o.CodGrade, d => d.MapFrom(p => p.CodGrade))
                .ForMember(o => o.CodFuncionario, d => d.MapFrom(p => p.CodFuncionario))
                .ForMember(o => o.NomeCurso, d => d.MapFrom(p => p.Curso))
                .ForMember(o => o.NomeTurma, d => d.MapFrom(p => p.Turma))
                .ForMember(o => o.NomeDisciplina, d => d.MapFrom(p => p.Disciplina));
        }
    }
}
