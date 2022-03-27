using System;
using System.Threading.Tasks;
using AirbBNB.API.Attributes;
using AirbBNB.API.Database;
using AirbBNB.API.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirbBNB.API.Controllers
{
    [ApiController]
    [Route("core/v1/travels")]
    public class TravelsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AirBnbContext _context; 
        
        public TravelsController(IMapper mapper, AirBnbContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateTravel([FromBody] CreateTravelRequest request)
        {
            var travel = _mapper.Map<Travel>(request);

            await _context.AddAsync(travel);

            var response = _mapper.Map<CreateTravelResponse>(travel);
            
            return Ok(response);
        }
    }
}