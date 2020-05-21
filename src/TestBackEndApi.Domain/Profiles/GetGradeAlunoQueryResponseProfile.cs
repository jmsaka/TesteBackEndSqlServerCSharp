using AutoMapper;
using TestBackEndApi.Domain.Queries.Grade.Get;
using TestBackEndApi.Infrastructure.Data.Entities;

namespace TestBackEndApi.Domain.Profiles
{
    public class GetGradeAlunoQueryResponseProfile : Profile
    {
        public GetGradeAlunoQueryResponseProfile()
        {
            CreateMap<Infrastructure.Data.Entities.Alunos, Queries.Grade.Get.Alunos>().ConstructUsingServiceLocator()
                .ForMember(o => o.Ra, d => d.MapFrom(p => p.Ra))
                .ForMember(o => o.Nome, d => d.MapFrom(p => p.Nome))
                .ForMember(o => o.Email, d => d.MapFrom(p => p.Email));

            CreateMap<GradeAlunoDto, GetGradeQueryResponse>().ConstructUsingServiceLocator()
                .ForMember(o => o.CodGrade, d => d.MapFrom(p => p.CodGrade))
                .ForMember(o => o.Turma, d => d.MapFrom(p => p.Turma))
                .ForMember(o => o.Disciplina, d => d.MapFrom(p => p.Disciplina))
                .ForMember(o => o.Curso, d => d.MapFrom(p => p.Curso))
                .ForMember(o => o.CodFuncionario, d => d.MapFrom(p => p.CodFuncionario))
                .ForMember(o => o.NomeProfessor, d => d.MapFrom(p => p.NomeProfessor))
                .ForMember(o => o.CpfProfessor, d => d.MapFrom(p => p.CpfProfessor))
                .ForMember(o => o.EmailProfessor, d => d.MapFrom(p => p.EmailProfessor))
                .ForMember(o => o.Alunos, d => d.MapFrom(p => p.Alunos));
        }
    }
}
