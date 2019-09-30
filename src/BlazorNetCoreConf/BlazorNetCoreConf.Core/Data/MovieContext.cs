using BlazorNetCoreConf.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorNetCoreConf.Core.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options, IServiceScopeFactory scopeFactory) : base(options)
        {
            this.scopeFactory = scopeFactory;
        }

        private readonly IServiceScopeFactory scopeFactory;


        public DbSet<Movie> Movies { get; set; }

    }
}
