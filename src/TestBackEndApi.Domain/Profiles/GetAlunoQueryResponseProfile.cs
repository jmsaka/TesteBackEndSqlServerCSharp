using AutoMapper;
using TestBackEndApi.Domain.Queries.Aluno.Get;
using TestBackEndApi.Infrastructure.Data.Entities;

namespace TestBackEndApi.Domain.Profiles
{
    public class GetAlunoQueryResponseProfile : Profile
    {
        public GetAlunoQueryResponseProfile()
        {
            CreateMap<Aluno, GetAlunoQueryResponse>().ConstructUsingServiceLocator()
                .ForMember(o => o.Ra, d => d.MapFrom(p => p.Ra))
                .ForMember(o => o.Nome, d => d.MapFrom(p => p.Usuario.Nome))
                .ForMember(o => o.Cpf, d => d.MapFrom(p => p.Usuario.Cpf))
                .ForMember(o => o.Login, d => d.MapFrom(p => p.Usuario.Login))
                .ForMember(o => o.Senha, d => d.MapFrom(p => p.Usuario.Senha))
                .ForMember(o => o.Email, d => d.MapFrom(p => p.Usuario.Email));
        }
    }
}
