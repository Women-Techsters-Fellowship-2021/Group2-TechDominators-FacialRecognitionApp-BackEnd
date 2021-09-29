using System.Threading.Tasks;
using FaceRecognition.DTOs;

namespace FaceRecognition.BL
{
    public interface IUserService
    {
        Task<bool> DeleteUser(string userId);
        Task<SchoolResponseDTO> GetUser(string userId);
        Task<bool> Update(string userId, UpdateSchoolUserRequest updateUser);

    }
}