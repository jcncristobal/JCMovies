using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JCMovies.Models
{
    public class Min18YearsIfAMember: ValidationAttribute 
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           // return base.IsValid(value, validationContext);
            var customer = (Customer)validationContext.ObjectInstance;
            //if (customer.MembershipTypeId == 1 || customer.MembershipTypeId == 0)

            if (customer.MembershipTypeId == MembershipType.Unknown  || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.DateOfBirth == null)
                return new ValidationResult("Birthdate is required, custom error");


            var age = DateTime.Today.Year - customer.DateOfBirth.Value.Year;

            return age > 18 ? 
                ValidationResult.Success :
                new ValidationResult("Customer should be at least 18");

        }
    }
}