using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FaceRecognition.DTOs;
using FaceRecognition.BL;
using System;

namespace FaceRecognition.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userservice)
        {
            _userService = userservice;
        }
        // to retrieve a specific user  
        [HttpGet("{userId}")]
        public async Task<ActionResult<SchoolResponseDTO>> GetUser(string userId)
        {
            try
            {
                var response = await _userService.GetUser(userId);
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
        // to delete a user
        [HttpPost("Delete")]
        public async Task<ActionResult<bool>> DeleteUser(string userId)
        {
            try
            {
                var response = await _userService.DeleteUser(userId);
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
        //to update user info
        [HttpPatch]
        public async Task<ActionResult<bool>> UpdateUser(string userId, UpdateSchoolUserRequest updateUser)
        {
            try
            {
                var response = await _userService.Update(userId, updateUser);
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
    }
}