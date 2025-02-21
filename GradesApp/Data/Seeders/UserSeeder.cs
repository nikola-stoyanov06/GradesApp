using Microsoft.AspNetCore.Identity;

namespace GradesApp.Data.Seeders
{
    public static class UserSeeder
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            string[] roleNames = { "Admin", "Teacher", "Student" };
            foreach (var roleName in roleNames) 
            { 
                bool roleExists = await roleManager.RoleExistsAsync(roleName);
                if (!roleExists) 
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
                var adminuser = new IdentityUser
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    EmailConfirmed = true
                };
                string password = "Admin#123";
                var user = await userManager.FindByEmailAsync(adminuser.Email);
                if (user == null)
                {
                    var created = await userManager
                        .CreateAsync(adminuser, password);
                    if (created.Succeeded)
                    {
                        await userManager.AddToRoleAsync(adminuser, "Admin");
                    }
                }
            }
        }
    }
}
