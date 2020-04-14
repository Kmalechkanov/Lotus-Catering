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
            await SeedTab(dbContext, "Солени хапки", "Постни", "Примерно описание", "tabs/ckqudfmcsm5zwp8jb2wt");
            await SeedTab(dbContext, "Солени хапки", "Местни", "Примерно описание", "tabs/ckqudfmcsm5zwp8jb2wt");
            await SeedTab(dbContext, "Солени хапки", "Свежи", "Примерно описание", "tabs/ckqudfmcsm5zwp8jb2wt");
            await SeedTab(dbContext, "Солени хапки", "Веган", "Примерно описание", "tabs/ckqudfmcsm5zwp8jb2wt");
            await SeedTab(dbContext, "Солени хапки", "Фюжън", "Примерно описание", "tabs/ckqudfmcsm5zwp8jb2wt");
            await SeedTab(dbContext, "Сладки хапки", "Петифури", "Примерно описание", "tabs/ckqudfmcsm5zwp8jb2wt");
            await SeedTab(dbContext, "Сладки хапки", "Къп кейк", "Примерно описание", "tabs/ckqudfmcsm5zwp8jb2wt");
            await SeedTab(dbContext, "Сладки хапки", "Тарталетки", "Примерно описание", "tabs/ckqudfmcsm5zwp8jb2wt");
            await SeedTab(dbContext, "Сладки хапки", "Профитероли", "Примерно описание", "tabs/ckqudfmcsm5zwp8jb2wt");
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
