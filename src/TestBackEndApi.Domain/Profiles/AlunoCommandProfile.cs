using AutoMapper;
using TestBackEndApi.Domain.Commands.Alunos.Post;
using TestBackEndApi.Infrastructure.Data.Entities;

namespace TestBackEndApi.Domain.Profiles
{
    public class AlunoCommandProfile : Profile
    {
        public AlunoCommandProfile()
        {
            CreateMap<AlunoCommand, AlunoDto>().ConstructUsingServiceLocator()
                .ForMember(o => o.Nome, d => d.MapFrom(p => p.Nome))
                .ForMember(o => o.Cpf, d => d.MapFrom(p => p.Cpf))
                .ForMember(o => o.Login, d => d.MapFrom(p => p.Login))
                .ForMember(o => o.Senha, d => d.MapFrom(p => p.Senha))
                .ForMember(o => o.Email, d => d.MapFrom(p => p.Email))
                .ForMember(o => o.Ra, d => d.MapFrom(p => p.Ra));
        }
    }
}
