using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MinhaAppVS.Models;

namespace MinhaAppVS.Data
{
    public class MinhaAppVSContext : DbContext
    {
        public MinhaAppVSContext (DbContextOptions<MinhaAppVSContext> options)
            : base(options)
        {
        }

        public DbSet<MinhaAppVS.Models.Filme> Filme { get; set; }
    }
}
