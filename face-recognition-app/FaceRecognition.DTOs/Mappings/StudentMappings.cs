using FaceRecognition.Models;

namespace FaceRecognition.DTOs
{
    public class StudentMappings
    {
        public static StudentResponse GetStudentResponse(Student student)
        {
            return new StudentResponse
            {
                Id = student.Id,
                FullName = student.FullName,
                Age = student.Age,
                Class = student.Class,
                Address = student.Address,
                Country = student.Country,
                StudentPhoto = student.StudentPhoto
            };
        }
        public static Student GetStudent(StudentRequest request)
        {
            return new Student
            {
                FullName = request.FullName,
                Age = request.Age,
                Class = request.Class,
                Address = request.Address,
                Country = request.Country,
                StudentPhoto = request.StudentPhoto
            };
        }
    }
}