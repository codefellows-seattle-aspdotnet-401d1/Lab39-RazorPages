using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Models.MovieContext _context;

        public IndexModel(RazorPagesMovie.Models.MovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }
        //contains the list of genres
        public SelectList Genres;
        //contains the specific genre the user selects
        public string MovieGenre
        {
            get; set;
        }

        //adding search capability to the index page that enables searching movies by name or genre
        public async Task OnGetAsync(string movieGenre, string searchString)
        {
            //use LINQ to get a list of genres
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            //LINQ query to select movies
            var movies = from m in _context.Movie
                         select m;

            //if searchString contains a string, the movies query is modified to filter on the search string
            if(!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            //the selectlist of genres is created by projecting the distint genres
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
