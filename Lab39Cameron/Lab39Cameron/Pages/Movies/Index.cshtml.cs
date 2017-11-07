using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab39Cameron.Models;

namespace Lab39Cameron.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly Lab39Cameron.Models.MovieContext _context;

        public IndexModel(Lab39Cameron.Models.MovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }

        ////Implementing Search 
        //public async Task OnGetAsync(string searchString)
        //{
        //    //Linq query to search movies 
        //    var movies = from m in _context.Movie
        //                 select m;
        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        movies = movies.Where(s => s.Title.Contains(searchString));
        //    }

        //    Movie = await movies.ToListAsync();
        //} 
    }
}
