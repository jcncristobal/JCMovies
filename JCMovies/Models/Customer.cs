using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace JCMovies.Models
{
    public class Customer
    {
        [Required(ErrorMessage = "This is custom Error message, enter name")]
        [StringLength(255)]
        public string name { get; set; }
        public int id { get; set; }

        public bool IsSubscribedToNewsLetter  { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name="Membership Type Label")]
        public  byte MembershipTypeId { get; set; } //foreign key

        [Min18YearsIfAMember]
        [Display(Name="Date of Birth")]
        public DateTime? DateOfBirth  { get; set; }




    }
}