using System;
using System.Data.Entity;

namespace MobileHIS
{
    public class Entities : DbContext
    {
        public Entities() :base("EntitiesContext") { }
        public DbSet<Car> Cars { get; set; }
    }
}
