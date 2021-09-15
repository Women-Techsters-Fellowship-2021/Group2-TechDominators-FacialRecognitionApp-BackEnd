using System.Threading.Tasks;
using FaceRecognition.DTOs;

namespace FaceRecognition.BL
{
    public interface IAuthenticationService
    {
        Task<UserResponseDTO> Login(UserRequestDTO userRequest);
        Task<UserResponseDTO> Register(RegistrationRequest registrationRequest);
    }

}