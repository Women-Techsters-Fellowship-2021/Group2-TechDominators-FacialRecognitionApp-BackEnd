using System.Threading.Tasks;
using FaceRecognition.DTOs;
using FaceRecognition.Models;
using System.Collections.Generic;

namespace FaceRecognition.BL
{
    public interface IStudentService
    {
        Task<Student> CreateStudent(StudentRequest request);
        Task<bool> DeleteStudent(string studentId);
        Task<List<Student>> GetAllStudents(string schoolId);
        Task<Student> GetStudent(string studentId);
        Task<bool> UpdateStudent(string studentId, UpdateStudentRequest updateStudent);

    }
}