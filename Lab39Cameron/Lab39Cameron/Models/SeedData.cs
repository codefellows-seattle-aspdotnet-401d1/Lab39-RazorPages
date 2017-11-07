using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab39Cameron.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            //dependency injection to bring in the movie db
            using (var context = new MovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MovieContext>>()))
            {
                if (context.Movie.Any())
                {
                    return;
                }

                //Add data to database based off movie model
                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Price = 7.99M
                    },

                     new Movie
                     {
                         Title = "Man on Fire",
                         ReleaseDate = DateTime.Parse("2005-2-12"),
                         Genre = "Action",
                         Price = 7.99M
                     }

                    );
                context.SaveChanges();

            }
        }
    }
}
