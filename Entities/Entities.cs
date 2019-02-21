using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MobileHis.Entities
{
    public partial class Entities : DbContext
    {
        public Entities() : base("Entities")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public virtual DbSet<Account> Account { get; set; }
    }
}