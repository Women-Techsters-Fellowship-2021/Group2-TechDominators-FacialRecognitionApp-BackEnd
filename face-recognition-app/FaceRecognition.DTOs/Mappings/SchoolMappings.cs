using FaceRecognition.Models;
using FaceRecognition.DTOs;

namespace FaceRecognition.DTOs
{
    public class SchoolMappings
    {
        public static SchoolResponseDTO GetUserResponse(AppUser user)
        {
            return new SchoolResponseDTO
            {
                Email = user.Email,
                SchoolName = user.SchoolName,
                Location = user.Location,
                Country = user.Country,
                Id = user.Id
            };
        }
        public static AppUser GetUser(SchoolRegistrationRequest request)
        {
            return new AppUser
            {
                Email = request.Email,
                SchoolName = request.SchoolName,
                Location = request.Location,
                UserName = string.IsNullOrWhiteSpace(request.UserName) ? request.Email : request.UserName,
                Country = request.Country
            };
        }
    }
}
// public static UserRequestDTO GetUserRequest(UserResponseDTO userResponse)
//         {
//             return new UserRequestDTO
//             {
//                 Email = userResponse.Email,
//                 Password = userResponse.Password
//             };
//         }