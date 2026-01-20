using Microsoft.AspNetCore.Identity;
using AutoMarket.Models;

namespace AutoMarket.Data
{
    public static class RoleSeeder
{
    public static async Task Seed(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
    {
        // Create roles
        if (!await roleManager.RoleExistsAsync("Seller"))
            await roleManager.CreateAsync(new IdentityRole("Seller"));

        if (!await roleManager.RoleExistsAsync("Expert"))
            await roleManager.CreateAsync(new IdentityRole("Expert"));

        if (!await roleManager.RoleExistsAsync("Buyer"))
            await roleManager.CreateAsync(new IdentityRole("Buyer"));

        // Create admin user
        var admin = await userManager.FindByEmailAsync("admin@auto.com");
        if (admin == null)
        {
            admin = new AppUser
            {
                UserName = "admin@auto.com",
                Email = "admin@auto.com",
                Name = "Admin"
            };

            await userManager.CreateAsync(admin, "Admin@123");
            await userManager.AddToRoleAsync(admin, "Expert");
        }
    }
}

}
