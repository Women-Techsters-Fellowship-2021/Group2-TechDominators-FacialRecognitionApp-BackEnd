using FaceRecognition.Models;

namespace FaceRecognition.DTOs
{
    public class ParentMappings
    {
        public static ParentResponseDTO GetParentResponse(Parent parent)
        {
            return new ParentResponseDTO
            {
                Id = parent.Id,
                FullName = parent.FullName,
                Email = parent.Email,
                PhoneNumber = parent.PhoneNumber,
                ParentPhoto = parent.ParentPhoto
            };
        }
        public static Parent GetParent(ParentRequest request)
        {
            return new Parent
            {
                FullName = request.FullName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                ParentPhoto = request.ParentPhoto
            };
        }
    }
}

