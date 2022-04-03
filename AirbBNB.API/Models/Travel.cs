using System;
using AirbBNB.API.Models.Seedwork;

namespace AirbBNB.API.Models
{
    public class Travel
    {
        public Travel(string origin, string destiny, DateTime departing,
        DateTime returning, int amount)
        {
            ExternalId = Code.Create("tra_");
            Origin = origin;
            Destiny = destiny;
            Departing = departing;
            Returning = returning;
            Amount = amount;
        }
        
        public int Id { get; set; }
        public string ExternalId { get; set; }
        public string Origin { get; set; }
        public string Destiny { get; set; }
        public DateTime Departing { get; set; }
        public DateTime Returning { get; set; }
        public int Amount { get; set; }
    }
}