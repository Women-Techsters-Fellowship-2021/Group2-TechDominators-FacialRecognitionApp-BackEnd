using System.ComponentModel.DataAnnotations;

namespace FaceRecognition.DTOs
{
    public class SchoolRegistrationRequest
    {
        [Required]
        public string SchoolName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Country { get; set; }
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}