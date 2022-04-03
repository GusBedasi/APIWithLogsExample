using AirbBNB.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AirbBNB.API.Database
{
    public class AirBnbContext : DbContext
    {
        public AirBnbContext(DbContextOptions<AirBnbContext> options)
        : base(options)
        { }
        
        public DbSet<Travel> Travels { get; set; }
    }
}