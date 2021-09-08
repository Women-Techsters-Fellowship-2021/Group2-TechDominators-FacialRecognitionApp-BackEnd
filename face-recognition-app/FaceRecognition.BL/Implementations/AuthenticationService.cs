using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using FaceRecognition.Models;
using FaceRecognition.DTOs;

namespace FaceRecognition.BL
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;

        public AuthenticationService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;

        }

        // to login an existing user
        public async Task<UserResponseDTO> Login(UserRequestDTO userRequest)
        {
            AppUser user = await _userManager.FindByEmailAsync(userRequest.Email);
            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, userRequest.Password))
                {
                    var response = UserMappings.GetUserResponse(user);
                }
                throw new AccessViolationException("Invalid credentials");
            }
            throw new AccessViolationException("Invalid credentials");
        }

        // to create a new user
        public async Task<UserResponseDTO> Register(RegistrationRequest registrationRequest)
        {
            AppUser user = UserMappings.GetUser(registrationRequest);

            IdentityResult result = await _userManager.CreateAsync(user, registrationRequest.Password);
            if (result.Succeeded)
            {
                return UserMappings.GetUserResponse(user);
            }
            string errors = string.Empty;
            foreach (var error in result.Errors)
            {
                errors += error.Description + Environment.NewLine;
            }
            throw new MissingFieldException(errors);
        }
    }
}