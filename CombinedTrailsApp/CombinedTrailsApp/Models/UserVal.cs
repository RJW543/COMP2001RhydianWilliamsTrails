// User class with FirstName and LastName properties
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
    }
}