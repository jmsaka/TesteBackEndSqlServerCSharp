using AutoMapper;
using TestBackEndApi.Infrastructure.Data.Entities;

namespace TestBackEndApi.Domain.Profiles
{
    public class ProfessorDtoProfile : Profile
    {
        public ProfessorDtoProfile()
        {
            CreateMap<ProfessorDto, Usuario>().ConstructUsingServiceLocator()
                .ForMember(o => o.Nome, d => d.MapFrom(p => p.Nome))
                .ForMember(o => o.Cpf, d => d.MapFrom(p => p.Cpf))
                .ForMember(o => o.Login, d => d.MapFrom(p => p.Login))
                .ForMember(o => o.Senha, d => d.MapFrom(p => p.Senha))
                .ForMember(o => o.Email, d => d.MapFrom(p => p.Email));

            CreateMap<ProfessorDto, Professor>().ConstructUsingServiceLocator()
                .ForMember(o => o.CodFuncionario, d => d.MapFrom(p => p.CodFuncionario))
                .ForMember(o => o.Usuario, d => d.MapFrom(p => new Usuario()
                {
                    Nome = p.Nome,
                    Cpf = p.Cpf,
                    Login = p.Login,
                    Senha = p.Senha,
                    Email = p.Email
                }));
        }
    }
}
