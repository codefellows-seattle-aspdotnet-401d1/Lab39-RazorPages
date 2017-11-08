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

        [Required, StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        //specifies how field name is displayed
        [Display(Name = "Release Date")]
        //specifies DataType of Date, whic removes time from DateTime
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$"), Required, StringLength(30)]
        public string Genre { get; set; }

        [Range(1, 100), DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$"), StringLength(5)]
        public string Rating { get; set; }
    }
}
