using AirbBNB.API.DTO;

namespace AirbBNB.API.Services
{
    public interface ITravelServices
    {
        public CreateTravelResponse CreateTravel(CreateTravelRequest request);
        public GetTravelResponse GetTravelById(string travelId);
    }
}
