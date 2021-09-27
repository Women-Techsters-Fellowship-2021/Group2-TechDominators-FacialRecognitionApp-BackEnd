// using FaceRecognition.Models;
// using Microsoft.AspNetCore.Identity;

// namespace FaceRecognition.DTOs
// {
//     public class UserMappings
//     {
//         public static UserResponseDTO GetUserResponse(AppUser user)
//         {
//             return new UserResponseDTO
//             {
//                 Email = user.Email,
//                 FirstName = user.FirstName,
//                 LastName = user.LastName,
//                 PhoneNumber = user.PhoneNumber,
//                 Id = user.Id
//             };
//         }
//         public static AppUser GetUser(RegistrationRequest request)
//         {
//             return new AppUser
//             {
//                 Email = request.Email,
//                 FirstName = request.FirstName,
//                 LastName = request.LastName,
//                 UserName = string.IsNullOrWhiteSpace(request.UserName) ? request.Email : request.UserName,
//                 PhoneNumber = request.PhoneNumber
//             };
//         }
//         public static UserRequestDTO GetUserRequest(UserResponseDTO userResponse)
//         {
//             return new UserRequestDTO
//             {
//                 Email = userResponse.Email,
//                 Password = userResponse.Password
//             };
//         }
//     }
// }