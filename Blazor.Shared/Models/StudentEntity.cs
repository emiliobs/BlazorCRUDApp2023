using System.ComponentModel.DataAnnotations;

namespace Blazor.Shared.Models
{
    public class StudentEntity
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage ="The {0} is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The {0} is required")]

        public string LastName { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [EmailAddress(ErrorMessage = "You must enter a valid Email")]

        public string EmailAddress { get; set; }
       
        [Required(ErrorMessage = "The {0} is required")]

        public string Gender { get; set; }

        public DateTime CreateOn { get; set; }
    }
}
