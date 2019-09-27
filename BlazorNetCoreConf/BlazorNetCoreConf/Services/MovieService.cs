using BlazorNetCoreConf.Data;
using BlazorNetCoreConf.Data.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorNetCoreConf.Services
{
    public class MovieService
    {
        private readonly IServiceScopeFactory scopeFactory;

        public MovieService(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }

        public Task<List<Movie>> Get()
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<BlazorContext>();
                return Task.FromResult(db.Movies.ToList());
            }
        }

        public Task<bool> Insert(Movie movie)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<BlazorContext>();
                db.Movies.Add(movie);

                return Task.FromResult(db.SaveChanges() > 0 ? true : false);
            }
        }

        public Task<bool> Delete(Movie movie)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<BlazorContext>();
                db.Remove(movie);
                return Task.FromResult(db.SaveChanges() > 0 ? true : false);
            }
        }

        public Task<bool> Update(Movie movie)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<BlazorContext>();
                db.Movies.Update(movie);
                return Task.FromResult(db.SaveChanges() > 0 ? true : false);
            }
        }

    }
}
