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
        private readonly ITokenGenerator _tokenGenerator;

        public AuthenticationService(UserManager<AppUser> userManager, ITokenGenerator tokenGenerator)
        {
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;

        }

        // to login an existing user
        public async Task<SchoolResponseDTO> Login(UserLoginRequestDTO userRequest)
        {
            AppUser user = await _userManager.FindByEmailAsync(userRequest.Email);
            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, userRequest.Password))
                {
                    var response = SchoolMappings.GetUserResponse(user);
                    response.Token = await _tokenGenerator.GenerateToken(user);
                    return response;
                }
                throw new AccessViolationException("Invalid credentials");
            }
            throw new AccessViolationException("Invalid credentials");
        }


        // to create a new user
        public async Task<SchoolResponseDTO> Register(SchoolRegistrationRequest registrationRequest)
        {
            AppUser user = SchoolMappings.GetUser(registrationRequest);

            IdentityResult result = await _userManager.CreateAsync(user, registrationRequest.Password);
            if (result.Succeeded)
            {
                return SchoolMappings.GetUserResponse(user);
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
