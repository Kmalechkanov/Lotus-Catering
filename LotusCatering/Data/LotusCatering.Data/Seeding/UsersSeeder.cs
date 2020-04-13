namespace LotusCatering.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using LotusCatering.Common;
    using LotusCatering.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class UsersSeeder : ISeeder
    {
        private readonly IConfiguration configuration;

        public UsersSeeder()
        {
            this.configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.Production.json")
            .Build();
        }

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            await SeedUserAsync(userManager, roleManager, GlobalConstants.DataSeeding.AdministratorName, GlobalConstants.DataSeeding.AdministratorEmail, this.configuration["Seeding:AdministratorPassword"], GlobalConstants.AdministratorRoleName);
            await SeedUserAsync(userManager, roleManager, GlobalConstants.DataSeeding.ModeratorName, GlobalConstants.DataSeeding.ModeratorEmail, this.configuration["Seeding:ModeratorPassword"], GlobalConstants.ModeratorRoleName);
            await SeedUserAsync(userManager, roleManager, GlobalConstants.DataSeeding.UserName, GlobalConstants.DataSeeding.UserEmail, this.configuration["Seeding:UserPassword"], string.Empty);
        }

        private static async Task SeedUserAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, string name, string email, string password, string roleName)
        {
            var user = await userManager.FindByEmailAsync(email);
            var newUser = new ApplicationUser { UserName = name, Email = email, EmailConfirmed = true };

            if (user == null)
            {
                var userResult = await userManager.CreateAsync(newUser, password);

                if (!userResult.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, userResult.Errors.Select(e => e.Description)));
                }

                var role = await roleManager.FindByNameAsync(roleName);

                if (role != null)
                {
                    if (!userManager.Users.Any(x => x.Roles.Any(x => x.RoleId == role.Id)))
                    {
                        await userManager.AddToRoleAsync(newUser, roleName);
                    }
                }

            }
        }
    }
}
