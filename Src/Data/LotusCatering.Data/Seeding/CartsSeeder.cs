namespace LotusCatering.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using LotusCatering.Common;
    using LotusCatering.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class CartsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await SeedCartAsync(userManager, dbContext, GlobalConstants.DataSeeding.UserName, "Хапка 1");
            await SeedCartAsync(userManager, dbContext, GlobalConstants.DataSeeding.UserName, "Хапка 2");
            await SeedCartAsync(userManager, dbContext, GlobalConstants.DataSeeding.UserName, "Хапка 3");
            await SeedCartAsync(userManager, dbContext, GlobalConstants.DataSeeding.UserName, "Хапка 4");
            await SeedCartAsync(userManager, dbContext, GlobalConstants.DataSeeding.UserName, "Хапка 5");
            await SeedCartAsync(userManager, dbContext, GlobalConstants.DataSeeding.UserName, "Хапка 6");
            await SeedCartAsync(userManager, dbContext, GlobalConstants.DataSeeding.UserName, "Хапка 7");
        }

        private static async Task SeedCartAsync(UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext, string userName, string itemName)
        {
            var user = await userManager.FindByNameAsync(userName);
            var random = new Random();

            if (user != null)
            {
                var itemId = dbContext.Items.FirstOrDefault(i => i.Name == itemName).Id;
                var cartId = user.Cart.Id;
                var randomQuantity = random.Next(1, 30) * 10;

                if (itemId != null)
                {
                    await dbContext.CartItems.AddAsync(new CartItem
                    {
                        CartId = cartId,
                        ItemId = itemId,
                        Quantity = randomQuantity,
                    });
                }
            }
        }
    }
}
