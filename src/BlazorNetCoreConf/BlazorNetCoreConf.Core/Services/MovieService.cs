using BlazorNetCoreConf.Core.Data;
using BlazorNetCoreConf.Core.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorNetCoreConf.Core.Services
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
                var db = scope.ServiceProvider.GetRequiredService<MovieContext>();
                return Task.FromResult(db.Movies.ToList());
            }
        }

        public Task<bool> Insert(Movie movie)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<MovieContext>();
                db.Movies.Add(movie);

                return Task.FromResult(db.SaveChanges() > 0 ? true : false);
            }
        }

        public Task<bool> Delete(Movie movie)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<MovieContext>();
                db.Remove(movie);
                return Task.FromResult(db.SaveChanges() > 0 ? true : false);
            }
        }

        public Task<bool> Update(Movie movie)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<MovieContext>();
                db.Movies.Update(movie);
                return Task.FromResult(db.SaveChanges() > 0 ? true : false);
            }
        }
    }
}
