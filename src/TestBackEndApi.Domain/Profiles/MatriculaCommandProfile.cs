using AutoMapper;
using TestBackEndApi.Domain.Commands.Matriculas.Post;
using TestBackEndApi.Infrastructure.Data.Entities;

namespace TestBackEndApi.Domain.Profiles
{
    public class MatriculaCommandProfile : Profile
    {
        public MatriculaCommandProfile()
        {
            CreateMap<PostMatriculaCommand, MatriculaDto>().ConstructUsingServiceLocator()
                .ForMember(o => o.Ra, d => d.MapFrom(p => p.Ra))
                .ForMember(o => o.CodGrade, d => d.MapFrom(p => p.CodGrade))
                .ForMember(o => o.Turma, d => d.Ignore());

            CreateMap<DeleteMatriculaCommand, MatriculaDto>().ConstructUsingServiceLocator()
                .ForMember(o => o.Ra, d => d.MapFrom(p => p.Ra))
                .ForMember(o => o.CodGrade, d => d.MapFrom(p => p.CodGrade))
                .ForMember(o => o.Turma, d => d.Ignore());
        }
    }
}
