using AirbBNB.API.Database;
using AirbBNB.API.Models;
using AirbBNB.API.Repositories.Interfaces;
using System;

namespace AirbBNB.API.Repositories
{
    public class TravelRepository : BaseRepository<Travel>, ITravelRepository
    {
        public TravelRepository(AirBnbContext context)
            : base(context)
        { }
    }
}
