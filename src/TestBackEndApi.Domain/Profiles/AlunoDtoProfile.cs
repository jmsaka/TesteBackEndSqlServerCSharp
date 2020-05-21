using AutoMapper;
using TestBackEndApi.Infrastructure.Data.Entities;

namespace TestBackEndApi.Domain.Profiles
{
    public class AlunoDtoProfile : Profile
    {
        public AlunoDtoProfile()
        {
            CreateMap<AlunoDto, Usuario>().ConstructUsingServiceLocator()
                .ForMember(o => o.Nome, d => d.MapFrom(p => p.Nome))
                .ForMember(o => o.Cpf, d => d.MapFrom(p => p.Cpf))
                .ForMember(o => o.Login, d => d.MapFrom(p => p.Login))
                .ForMember(o => o.Senha, d => d.MapFrom(p => p.Senha))
                .ForMember(o => o.Email, d => d.MapFrom(p => p.Email));

            CreateMap<AlunoDto, Aluno>().ConstructUsingServiceLocator()
                .ForMember(o => o.Ra, d => d.MapFrom(p => p.Ra))
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
