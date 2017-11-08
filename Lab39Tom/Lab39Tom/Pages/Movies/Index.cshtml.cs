using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab39Tom.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab39Tom.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly Lab39Tom.Models.MovieContext _context;

        //Dependency injection to add MovieContext
        public IndexModel(Lab39Tom.Models.MovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get; set; }
        public SelectList Genres;
        public string MovieGenre { get; set; }
        //if searchString parameter contains string, filter by search string

        public async Task OnGetAsync(string movieGenre, string searchString)
        {
            //LINQ query to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            var movies = from m in _context.Movie
                         select m;

            //when request is made for page, returns list of movies
            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }
    }
}
