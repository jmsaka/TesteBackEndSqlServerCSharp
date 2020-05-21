using AutoMapper;
using TestBackEndApi.Domain.Queries.Professor.Get;
using TestBackEndApi.Infrastructure.Data.Entities;

namespace TestBackEndApi.Domain.Profiles
{
    public class GetProfessorQueryResponseProfile : Profile
    {
        public GetProfessorQueryResponseProfile()
        {
            CreateMap<ProfessorInfoDto, GetProfessorQueryResponse>().ConstructUsingServiceLocator();
        }
    }
}
