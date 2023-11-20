using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesSystemTest.Models;

namespace SalesSystemTest.Data
{
    public class SalesSystemTestContext : DbContext
    {
        public SalesSystemTestContext (DbContextOptions<SalesSystemTestContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; } = default!;
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
