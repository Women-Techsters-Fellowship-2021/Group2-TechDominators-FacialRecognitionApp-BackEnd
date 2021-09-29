using System.Collections.Generic;
using System.Threading.Tasks;
using FaceRecognition.Models;
using FaceRecognition.DTOs;

namespace FaceRecognition.BL
{
    public interface IParentService
    {
        Task<ParentResponseDTO> CreateParent(ParentRequest request);
        Task<bool> DeleteParent(string parentId);
        Task<List<Parent>> GetAllParents(string studentId);
        Task<ParentResponseDTO> GetParent(string parentId);
        Task<ParentResponseDTO> GetParentByEmail(string email);

    }
}