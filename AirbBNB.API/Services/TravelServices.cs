using AirbBNB.API.DTO;
using AirbBNB.API.Models;
using AirbBNB.API.Repositories.Interfaces;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace AirbBNB.API.Services
{
    public class TravelServices : ITravelServices
    {
        private readonly ITravelRepository _travelRepository;
        private readonly IMapper _mapper;

        public TravelServices(ITravelRepository travelRepository, IMapper mapper)
        {
            _travelRepository = travelRepository ?? throw new ArgumentNullException(nameof(travelRepository));
            _mapper = mapper;
        }

        public CreateTravelResponse CreateTravel(CreateTravelRequest request)
        {
            var travel = _mapper.Map<Travel>(request);

            _travelRepository.Add(travel);

            _travelRepository.Commit();

            var response = _mapper.Map<CreateTravelResponse>(travel);

            return response;
        }

        public GetTravelResponse GetTravelById(string travelId)
        {
            var travel = _travelRepository.FindOne(x => x.ExternalId == travelId);

            if(travel == null)
                return null;

            return _mapper.Map<GetTravelResponse>(travel);
        }
    }
}
