using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelEn.Entities
{
    public class SeederDB
    {
        private static void SeedGame(AppDbContext context)
        {
            #region UserInfo
            User admin = new User
            {
                Login = "StepanSm",
                Email = "ivanna.pugaiko@gmail.com",
                Password = "Stepan123456",
                IsAdmin = true
            };
            var user = context.Users.SingleOrDefault(p => p.Login == admin.Login);
            if (user == null)
            {
                context.Add(admin);
                context.SaveChanges();
            }
            else
                admin.Id = user.Id;

            var extraInfo = context.UsersExtraInfo.SingleOrDefault(p => p.IdExtraInfo == admin.Id);

            UserExtraInfo adminAddInfo = new UserExtraInfo
            {
                IdExtraInfo = admin.Id,
                Name = "Stepan",
                Surname = "Smetanskyy",
                Photo = "stepanPhoto.jpg",
                BirthDate = new DateTime(1988, 4, 24),
                Gender = true
            };

            if (extraInfo == null)
            {
                context.Add(adminAddInfo);
                context.SaveChanges();
            }
            #endregion
            
        }

        public static void SeedData(IServiceProvider services, IHostingEnvironment env, IConfiguration config)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                SeederDB.SeedGame(context);
            }
        }
    }
}
