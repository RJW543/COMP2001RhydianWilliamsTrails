using System;
using System.ComponentModel.DataAnnotations;

namespace CombinedTrailsApp.Models
{
    public class UserVal
    {
        [Key]
        public string Email { get; set; }

        public string Photo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Additional properties
        public string AboutMe { get; set; }
        public int LocationID { get; set; }
        public string Units { get; set; }
        public string ActivityTimePref { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

        // Assuming Dob is a date of birth
        public DateTime Dob { get; set; }

        public int LanguageID { get; set; }
    }
}