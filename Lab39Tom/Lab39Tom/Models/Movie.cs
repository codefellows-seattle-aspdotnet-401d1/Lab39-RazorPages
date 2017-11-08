using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab39Tom.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }

        //specifies how field name is displayed
        [Display(Name = "Release Date")]
        //specifies DataType of Date, whic removes time from DateTime
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}
