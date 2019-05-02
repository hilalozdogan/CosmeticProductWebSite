using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.IdentityCore
{
    public static class SeedIdentity
    {
        public static async Task CreateIdentityUsers(IServiceProvider serviceProvider,IConfiguration configuration)
        {

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var username = configuration["Data:AdminUser:username"];
            var email=configuration["Data:AdminUser:email"];
            var password = configuration["Data:AdminUser:password"];
            var role = configuration["Data:AdminUser:role"];

            if(await userManager.FindByNameAsync(username)==null)
            {
                if(await roleManager.FindByNameAsync(role)==null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role)); //Rol veritabanında oluştu.

                }

                ApplicationUser user = new ApplicationUser()
                {

                    UserName=username,
                    Email=email,
                    Name="Hilal",
                    SurName="Özdoğan",


                };

                IdentityResult result = await userManager.CreateAsync(user, password); // kullanıcı oluşturduk.

                if (result.Succeeded) //eğer result true ise
                {
                    await userManager.AddToRoleAsync(user, role); // kullanıcıya rol ata 
                }

            }

        }

    }
}
