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
        public async Task<UserResponseDTO> GetUser(string userId)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var response = UserMappings.GetUserResponse(user);
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
        public async Task<bool> Update(string userId, UpdateUserRequest updateUser)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.FirstName = string.IsNullOrWhiteSpace(updateUser.FirstName) ? user.FirstName : updateUser.FirstName;
                user.LastName = string.IsNullOrWhiteSpace(updateUser.LastName) ? user.LastName : updateUser.LastName;
                user.PhoneNumber = string.IsNullOrWhiteSpace(updateUser.PhoneNumber) ? user.PhoneNumber : updateUser.PhoneNumber;

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