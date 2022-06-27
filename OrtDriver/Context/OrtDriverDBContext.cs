using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrtDriver.Models;

namespace OrtDriver.Context
{
    public class OrtDriverDBContext : DbContext
    {
        public OrtDriverDBContext(DbContextOptions<OrtDriverDBContext> options) : base(options)
        {
        }

        public DbSet<Conductor> Conductores { get; set; }
        public DbSet<Viaje> Viajes { get; set; }

    }
}