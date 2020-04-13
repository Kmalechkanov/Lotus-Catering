namespace LotusCatering.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    public class ApplicationDbContextSeeder
    {
        private readonly IConfiguration configuration;

        public ApplicationDbContextSeeder(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger(typeof(ApplicationDbContextSeeder));

            var seeders = new List<ISeeder>
            {
                new RolesSeeder(),
                new UsersSeeder(),
                new CategoriesSeeder(),
                new TabsSeeder(),
                new ItemsSeeder(),
                new CartsSeeder(),
            };

            string configrationString;

            foreach (var seeder in seeders)
            {
                configrationString = "Seeding:" + seeder.GetType().Name;
                var result = this.configuration[configrationString];
                if (this.configuration[configrationString] == "False")
                {
                    continue;
                }

                await seeder.SeedAsync(dbContext, serviceProvider);
                logger.LogInformation($"Seeder {seeder.GetType().Name} done.");

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
