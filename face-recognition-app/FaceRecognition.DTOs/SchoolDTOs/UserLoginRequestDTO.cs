using System.ComponentModel.DataAnnotations;

namespace FaceRecognition.DTOs
{
    public class UserLoginRequestDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}