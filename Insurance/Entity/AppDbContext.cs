using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Insurance.Entity
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=MyDbConnection") { }

        public DbSet<Policy> Policies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Payment> Payments { get; set; }

    }
}
