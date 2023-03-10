using Microsoft.EntityFrameworkCore;
using NextBus_API.Models.Entities;

namespace NextBus_API.Data
{
    public class NextBusDbContext : DbContext
    {
        public NextBusDbContext(DbContextOptions options) : base(options)
        {

        }

        //DbSet
        public DbSet<BusOwner> BusOwners { get; set; }

        public DbSet<Conductor> Conductors { get; set; }
    }
}
