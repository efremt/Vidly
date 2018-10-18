using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")] //To override default error message
        [StringLength(255)]
        public String Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfaMember]
        public DateTime? Birthdate { get; set; }
        
    }
}
/*
 * Data Annotations for validation
 * [Required]
 * [StringLength(255)]
 * [Rang(1,10)]
 * [Compare("OtherProperty")]
 * [Phone]
 * [EmailAddress]
 * [Url]
 * [RegularExpression("...")]
 */