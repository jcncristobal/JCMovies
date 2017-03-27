using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JCMovies.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [Display(Name ="Movie Title") ]
        public string name  { get; set; }


        [Display(Name="Movie Type")]
        public string type { get; set; }

        [Display(Name = "Movie Genre")]
        [Required]
        public string genre { get; set; }


        [Display(Name = "Movie Release Date")]
        public DateTime  ReleaseDate { get; set; }

        [Display(Name = "Movie Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Stocks Remaining")]
        public int Stocks { get; set; }

        [Display(Name = "No of Available")]
        public int NumberAvailable { get; set; }
    }
}