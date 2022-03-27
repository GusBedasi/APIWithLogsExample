using System;

namespace AirbBNB.API
{
    public class Travel
    {
        public Travel(string origin, string destiny, DateTime departing,
        DateTime returning, int amount)
        {
            Origin = origin;
            Destiny = destiny;
            Departing = departing;
            Returning = returning;
            Amount = amount;
        }
        
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destiny { get; set; }
        public DateTime Departing { get; set; }
        public DateTime Returning { get; set; }
        public int Amount { get; set; }
    }
}