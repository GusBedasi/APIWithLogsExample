using System;

namespace AirbBNB.API.DTO
{
    public class CreateTravelRequest
    {
        public string Origin { get; set; }
        public string Destiny { get; set; }
        public DateTime Departing { get; set; }
        public DateTime Returning { get; set; }
        public int Amount { get; set; }
    }
}