using System.Threading.Tasks;
using FaceRecognition.DTOs;

namespace FaceRecognition.BL
{
    public interface IAuthenticationService
    {
        Task<SchoolResponseDTO> Login(UserLoginRequestDTO userRequest);
        Task<SchoolResponseDTO> Register(SchoolRegistrationRequest registrationRequest);
    }

}