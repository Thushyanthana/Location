using Location.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Location.DatabaseContext
{
    public class LocationDBContext:DbContext
    {

        public LocationDBContext(DbContextOptions options):base(options)
        {
                
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Region> Regions { get; set; }
        

    }
}
