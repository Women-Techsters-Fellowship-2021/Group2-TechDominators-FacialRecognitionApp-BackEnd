using System.Threading.Tasks;
using FaceRecognition.Models;

namespace FaceRecognition.BL
{
    public interface ITokenGenerator
    {
        Task<string> GenerateToken(AppUser user);
    }

}