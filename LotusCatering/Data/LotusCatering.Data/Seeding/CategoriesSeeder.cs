namespace LotusCatering.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using LotusCatering.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            await SeedCategory(dbContext, "Солени хапки", "Примерно описание", "categories/1edbc4abcb626f73b0dd762b8");
            await SeedCategory(dbContext, "Сладки хапки", "Примерно описание", "categories/1edbc4abcb626f73b0dd762b8");
        }

        private static async Task SeedCategory(ApplicationDbContext dbContext, string name, string description, string imageUrl)
        {
            if (!dbContext.Categories.Any(x => x.Name == name))
            {
                await dbContext.Categories.AddAsync(
                    new Category
                    {
                        Name = name,
                        Description = description,
                        ImageUrl = imageUrl,
                    });
            }
        }
    }
}
