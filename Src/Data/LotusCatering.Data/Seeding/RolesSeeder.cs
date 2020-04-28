namespace LotusCatering.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using LotusCatering.Common;
    using LotusCatering.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class RolesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            await SeedRole(roleManager, GlobalConstants.AdministratorRoleName);
            await SeedRole(roleManager, GlobalConstants.ModeratorRoleName);
        }

        private static async Task SeedRole(RoleManager<ApplicationRole> roleManager, string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                var result = await roleManager.CreateAsync(new ApplicationRole(roleName));

                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
