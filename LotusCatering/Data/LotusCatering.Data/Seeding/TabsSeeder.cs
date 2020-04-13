namespace LotusCatering.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using LotusCatering.Data.Models;

    public class TabsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            await SeedTab(dbContext, "Солени хапки", "Постни", "Примерно описание", "categories/1edbc4abcb626f73b0dd762b8");
            await SeedTab(dbContext, "Солени хапки", "Местни", "Примерно описание", "categories/1edbc4abcb626f73b0dd762b8");
            await SeedTab(dbContext, "Солени хапки", "Свежи", "Примерно описание", "categories/1edbc4abcb626f73b0dd762b8");
            await SeedTab(dbContext, "Солени хапки", "Веган", "Примерно описание", "categories/1edbc4abcb626f73b0dd762b8");
            await SeedTab(dbContext, "Солени хапки", "Фюжън", "Примерно описание", "categories/1edbc4abcb626f73b0dd762b8");
            await SeedTab(dbContext, "Сладки хапки", "Петифури", "Примерно описание", "categories/1edbc4abcb626f73b0dd762b8");
            await SeedTab(dbContext, "Сладки хапки", "Къп кейк", "Примерно описание", "categories/1edbc4abcb626f73b0dd762b8");
            await SeedTab(dbContext, "Сладки хапки", "Тарталетки", "Примерно описание", "categories/1edbc4abcb626f73b0dd762b8");
            await SeedTab(dbContext, "Сладки хапки", "Профитероли", "Примерно описание", "categories/1edbc4abcb626f73b0dd762b8");
        }

        private static async Task SeedTab(ApplicationDbContext dbContext, string categoryName, string name, string description, string imageUrl)
        {
            if (!dbContext.Tabs.Any(x => x.Name == name))
            {
                var categoryId = dbContext.Categories.FirstOrDefault(c => c.Name == categoryName).Id;

                if (categoryId == null)
                {
                    return;
                }

                await dbContext.Tabs.AddAsync(
                    new Tab
                    {
                        Name = name,
                        Description = description,
                        ImageUrl = imageUrl,
                        CategoryId = categoryId,
                    });
            }
        }
    }
}
