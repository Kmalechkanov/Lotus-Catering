namespace LotusCatering.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using LotusCatering.Data.Models;

    public class ItemsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
                await RepeatSeed(dbContext, "Постни", "Хапка", "Примерно описание", "categories/1edbc4abcb626f73b0dd762b8", 8);
                await RepeatSeed(dbContext, "Местни", "Хапка", "Примерно описание", "categories/1edbc4abcb626f73b0dd762b8", 10);
                await RepeatSeed(dbContext, "Свежи", "Хапка", "Примерно описание", "categories/1edbc4abcb626f73b0dd762b8", 24);
                await RepeatSeed(dbContext, "Веган", "Хапка", "Примерно описание", "categories/1edbc4abcb626f73b0dd762b8", 2);
                await RepeatSeed(dbContext, "Фюжън", "Хапка", "Примерно описание", "categories/1edbc4abcb626f73b0dd762b8", 6);
                await RepeatSeed(dbContext, "Петифури", "Хапка", "Примерно описание", "categories/1edbc4abcb626f73b0dd762b8", 4);
                await RepeatSeed(dbContext, "Къп кейк", "Хапка", "Примерно описание", "categories/1edbc4abcb626f73b0dd762b8", 3);
                await RepeatSeed(dbContext, "Тарталетки", "Хапкa", "Примерно описание", "categories/1edbc4abcb626f73b0dd762b8", 10);
                await RepeatSeed(dbContext, "Профитероли", "Хапка", "Примерно описание", "categories/1edbc4abcb626f73b0dd762b8", 8);
        }

        private static async Task SeedItem(ApplicationDbContext dbContext, string tabName, string name, string description, string imageUrl, double price)
        {
            if (!dbContext.Items.Any(x => x.Name == name))
            {
                var tabId = dbContext.Tabs.FirstOrDefault(t => t.Name == tabName).Id;

                if (tabId == null)
                {
                    return;
                }

                await dbContext.Items.AddAsync(
                    new Item
                    {
                        Name = name,
                        Description = description,
                        ImageUrl = imageUrl,
                        TabId = tabId,
                        Price = price,
                    });
            }
        }

        private static async Task RepeatSeed(ApplicationDbContext dbContext, string tabName, string name, string description, string imageUrl, int times)
        {
            var random = new Random();
            double randomPrice;

            for (int i = 0; i < times; i++)
            {
                randomPrice = random.Next(100, 4000) / 100;
                await SeedItem(dbContext, tabName, name + " " + (i + 1), description, imageUrl, randomPrice);
            }
        }
    }
}
