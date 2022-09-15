using System.ComponentModel.DataAnnotations;

namespace RegisterApi.Models
{
    public class Register
    {
        public int Id;
        [Required]
        public string Email;
        [Required]
        public string FirstName;
        [Required]
        public string LastName;
    }
}
