using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;




namespace MoviesMoo.Models
{
    public class MinAge18YearsOldAttribute : ValidationAttribute
    {
        


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customers=(Customers)validationContext.ObjectInstance;

            if (customers.MembershipID == 1)
               return ValidationResult.Success;

            if (customers.Birthdate == null)
                return new ValidationResult("Birth Date is required");

            var age = DateTime.Today.Year - customers.Birthdate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("shoul by at lest 18 years old to go a membership");


        }

        
    }
}