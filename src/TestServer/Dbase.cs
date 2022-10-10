using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TestServer
{
    public class TSContext : DbContext
    {
        public TSContext() : base("TSContext") { }
        public DbSet<Somemdl> Somemdls { get; set; }
    }
}
