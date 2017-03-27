using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JCMovies.Models
{
    public class Rental
    {

        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
        public int ID { get; set; }
        [Required]
        public Movie Movie { get; set; }
        [Required]
        public Customer Customer { get; set; }
    }
}