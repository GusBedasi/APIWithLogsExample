using AirbBNB.API.DTO;
using AutoMapper;

namespace AirbBNB.API.Mapper
{
    public class DTOToDomainProfileMapping : Profile
    {
        public DTOToDomainProfileMapping()
        {
            CreateMap<CreateTravelRequest, Travel>();
            CreateMap<Travel, CreateTravelResponse>();
        }
    }
}