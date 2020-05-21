using AutoMapper;
using TestBackEndApi.Domain.Commands.Professores.Post;
using TestBackEndApi.Infrastructure.Data.Entities;

namespace TestBackEndApi.Domain.Profiles
{
    public class ProfessorCommandProfile : Profile
    {
        public ProfessorCommandProfile()
        {
            CreateMap<ProfessorCommand, ProfessorDto>().ConstructUsingServiceLocator()
                .ForMember(o => o.Nome, d => d.MapFrom(p => p.Nome))
                .ForMember(o => o.Cpf, d => d.MapFrom(p => p.Cpf))
                .ForMember(o => o.Login, d => d.MapFrom(p => p.Login))
                .ForMember(o => o.Senha, d => d.MapFrom(p => p.Senha))
                .ForMember(o => o.Email, d => d.MapFrom(p => p.Email))
                .ForMember(o => o.CodFuncionario, d => d.MapFrom(p => p.Codigo));
        }
    }
}
