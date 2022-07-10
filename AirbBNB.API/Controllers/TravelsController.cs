using System;
using AirbBNB.API.DTO;
using AirbBNB.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace AirbBNB.API.Controllers
{
    [ApiController]
    [Route("core/v1/travels")]
    public class TravelsController : ControllerBase
    {
        private readonly ITravelServices _travelServices;
        
        public TravelsController(ITravelServices travelServices)
        {
            _travelServices = travelServices ?? throw new ArgumentNullException(nameof(travelServices));
        }
        
        [HttpPost]
        public IActionResult CreateTravel([FromBody] CreateTravelRequest request)
        {
            var response = _travelServices.CreateTravel(request);
            
            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetTravenlById([FromBody] string tranvelId)
        {
            var response = _travelServices.GetTravelById(tranvelId);

            if(response == null)
                return NotFound();

            return Ok(response);
        }
    }
}