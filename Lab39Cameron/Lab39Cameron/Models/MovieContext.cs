using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab39Cameron.Models
{
    public class MovieContext : DbContext
    {
        //Database added within Model Folder. ?
        public MovieContext(DbContextOptions<MovieContext>options)
            :base(options)
        {

        }

        //Sets DB Table for Movie
        public DbSet<Movie> Movie { get; set; }
    }
}
