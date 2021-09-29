using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FaceRecognition.Models;
using FaceRecognition.DTOs;
using FaceRecognition.BL;
using System;

namespace FaceRecognition.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;

        }
        [HttpPost]
        public async Task<ActionResult<StudentResponse>> CreateStudent(StudentRequest request)
        {
            try
            {
                var response = await _studentService.CreateStudent(request);
                // var request = SchoolMappings.GetUserRequest(response);
                return Created("~/api/v1/student/" + response.Id, response);
            }
            catch (MissingFieldException message)
            {
                return BadRequest(message.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{studentId}")]
        public async Task<ActionResult<StudentResponse>> GetStudent(string studentId)
        {
            try
            {
                var response = await _studentService.GetStudent(studentId);
                return Ok(response);
            }
            catch (AccessViolationException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Student>>> Search(string studentName)
        {
            try
            {
                var response = await _studentService.GetStudentbyName(studentName);
                return Ok(response);
            }
            catch (AccessViolationException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        // get all students registered on the system
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAllStudents(string schoolId)
        {
            try
            {
                var response = await _studentService.GetAllStudents(schoolId);
                return Ok(response);
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE student details
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteStudent(string studentId)
        {
            try
            {
                var response = await _studentService.DeleteStudent(studentId);
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // update student details
        [HttpPatch]
        public async Task<ActionResult<bool>> UpdateStudent(string studentId, UpdateStudentRequest updateStudent)
        {
            try
            {
                var response = await _studentService.UpdateStudent(studentId, updateStudent);
                return Ok(response);
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}