using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using FaceRecognition.Models;
using System.Linq;

namespace FaceRecognition.DB
{
    public class Seed
    {
        public async static Task Seeder(UserManager<AppUser> userManager, RecognitionContext context)
        {
            await context.Database.EnsureCreatedAsync();

            if (!context.Users.Any())
            {
                List<AppUser> users = new List<AppUser>
                {
                    new AppUser
                    {
                        FirstName="John",
                        LastName="Smith",
                        Email="jsmith@gmail.com",
                        PhoneNumber="6758299020"
                    },
                    new AppUser
                    {
                        FirstName="Phineas",
                        LastName="Ferb",
                        Email="phfe@gmail.com",
                        PhoneNumber="6754782390"

                    }
                };
                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "P@ssW0rd");
                    // await context.SaveChangesAsync();
                }
            }
        }
    }
}