using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using FaceRecognition.Models;
using FaceRecognition.DTOs;

namespace FaceRecognition.BL
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        // to retrieve a specific user
        public async Task<SchoolResponseDTO> GetUser(string userId)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var response = SchoolMappings.GetUserResponse(user);
                return response;
            }
            throw new ArgumentException("Resource not found");
        }

        // to delete a user
        public async Task<bool> DeleteUser(string userId)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return true;
                }
                string errors = string.Empty;
                foreach (var error in result.Errors)
                {
                    errors += error.Description + Environment.NewLine;
                }
                throw new MissingFieldException(errors);
            }
            throw new ArgumentNullException("Resource not found");
        }

        //to update user info
        public async Task<bool> Update(string userId, UpdateSchoolUserRequest updateUser)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.SchoolName = string.IsNullOrWhiteSpace(updateUser.SchoolName) ? user.SchoolName : updateUser.SchoolName;
                user.Location = string.IsNullOrWhiteSpace(updateUser.Location) ? user.Location : updateUser.Location;
                user.Country = string.IsNullOrWhiteSpace(updateUser.Country) ? user.Country : updateUser.Country;
                user.Email = string.IsNullOrWhiteSpace(updateUser.Email) ? user.Email : updateUser.Email;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return true;
                }
                string errors = string.Empty;
                foreach (var error in result.Errors)
                {
                    errors += error.Description + Environment.NewLine;
                }
                throw new MissingFieldException(errors);
            }
            throw new ArgumentNullException("Resource not found");
        }

    }
}