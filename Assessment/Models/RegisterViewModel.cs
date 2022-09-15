

using System.ComponentModel.DataAnnotations;

namespace Assessment.Models
{
    public class RegisterViewModel 
    {
        public int Id;

        [Required]
        public string Email;

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(2)]
        public string FirstName;

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(2)]
        public string LastName;
    }
}
