using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab39Tom.Models;

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

        public IList<Movie> Movie { get;set; }

        //when request is made for page, returns list of movies
        public async Task OnGetAsync(string searchString)
        {
            //LINQ query to select movies
            var movies = from m in _context.Movie
                         select m;
            //if searchString parameter contains string, filter by search string
            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            Movie = await movies.ToListAsync();
        }
    }
}
