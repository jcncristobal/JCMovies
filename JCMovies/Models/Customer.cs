using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace JCMovies.Models
{
    public class Customer
    {
        [Required]
        [StringLength(255)]
        public string name { get; set; }
        public int id { get; set; }

        public bool IsSubscribedToNewsLetter  { get; set; }

        public MembershipType MembershipType { get; set; }
        public  byte MembershipTypeId { get; set; } //foreign key
        
    }
}