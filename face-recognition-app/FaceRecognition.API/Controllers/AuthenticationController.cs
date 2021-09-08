using System;
using FaceRecognition.BL;
using FaceRecognition.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FaceRecognition.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        // POST method for logging in users
        [HttpPost("login")]
        public async Task<ActionResult<UserResponseDTO>> LoginUser(UserRequestDTO userRequest)
        {
            try
            {
                var response = await _authenticationService.Login(userRequest);
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

        // POST method for registering users
        [HttpPost]
        public async Task<ActionResult<UserResponseDTO>> Register(RegistrationRequest registrationRequest)
        {
            try
            {
                var response = await _authenticationService.Register(registrationRequest);
                var request = UserMappings.GetUserRequest(response);
                return CreatedAtAction(nameof(LoginUser), new { userRequest = request }, request);
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
    }
}