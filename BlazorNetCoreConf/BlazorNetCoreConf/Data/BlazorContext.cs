
using BlazorNetCoreConf.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorNetCoreConf.Data
{
    public class BlazorContext : DbContext
    {
        public BlazorContext(DbContextOptions<BlazorContext> options) : base(options)
        { }

        public DbSet<Movie> Movies { get; set; }

    }
}
