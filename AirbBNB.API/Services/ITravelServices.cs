using AirbBNB.API.DTO;
using System.Threading.Tasks;

namespace AirbBNB.API.Services
{
    public interface ITravelServices
    {
        public Task<CreateTravelResponse> CreateTravel(CreateTravelRequest request);
        public GetTravelResponse GetTravelById(string travelId);
    }
}
