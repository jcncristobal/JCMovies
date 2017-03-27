using JCMovies.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JCMovies.Dtos
{
    public class CustomerDto
    {
        [Required(ErrorMessage = "This is custom Error message, enter name")]
        [StringLength(255)]
        public string name { get; set; }
        public int id { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipTypeDto  MembershipType { get; set; }
        public byte MembershipTypeId { get; set; } //foreign key

      public DateTime? DateOfBirth { get; set; }



    }
}