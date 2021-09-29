using System;
using System.Linq;
using FaceRecognition.DB;
using FaceRecognition.DTOs;
using FaceRecognition.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace FaceRecognition.BL
{
    public class StudentService : IStudentService
    {
        private readonly RecognitionContext _context;
        public StudentService(RecognitionContext context)
        {
            _context = context;
        }

        //    adds new student
        public async Task<StudentResponse> CreateStudent(StudentRequest request)
        {
            Student student = StudentMappings.GetStudent(request);
            await _context.AddAsync(student);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
            {
                throw new ArgumentException("Cannot create student at this time");
            }
            return StudentMappings.GetStudentResponse(student);
        }


        //   gets a particular student using the id
        public async Task<StudentResponse> GetStudent(string studentId)
        {
            Student student = await _context.Students
            .FirstOrDefaultAsync(student => student.Id == studentId);
            if (student is null)
            {
                throw new ArgumentNullException("Resource does not exist");
            }
            return StudentMappings.GetStudentResponse(student);
        }
        //   gets a particular student using their name
        public async Task<IEnumerable<Student>> GetStudentbyName(string studentName)
        {
            IQueryable<Student> query = _context.Students.Include(emp => emp.Parents);

            if (query != null)
            {
                if (!String.IsNullOrEmpty(studentName))
                {
                    query = query.Where(e => e.FullName.Contains(studentName));
                    return await query.ToListAsync();
                }
                throw new ArgumentNullException("Resource does not exist");
            }

            throw new ArgumentNullException("Resource does not exist");
        }


        // get all students registered on the system
        public async Task<List<Student>> GetAllStudents(string schoolId)
        {
            return await _context.Students.Where(student => student.SchoolId == schoolId).ToListAsync();
        }

        // remove student
        public async Task<bool> DeleteStudent(string studentId)
        {
            Student student = await _context.Students
            .FirstOrDefaultAsync(student => student.Id == studentId);
            if (student is null)
            {
                throw new ArgumentNullException("Resource does not exist");
            }

            _context.Remove(student);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
            {
                throw new ArgumentException("Cannot remove student at this time");
            }
            return true;
        }

        // update student details
        public async Task<bool> UpdateStudent(string studentId, UpdateStudentRequest updateStudent)
        {
            Student student = await _context.Students
            .FirstOrDefaultAsync(student => student.Id == studentId);
            if (student != null)
            {
                student.FullName = string.IsNullOrWhiteSpace(updateStudent.FullName) ? student.FullName : updateStudent.FullName;
                student.Address = string.IsNullOrWhiteSpace(updateStudent.Address) ? student.Address : updateStudent.Address;
                _context.Update(student);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                throw new ArgumentException("Cannot update student at this time");

            }
            throw new ArgumentNullException("Resource does not exist");
        }

    }
}