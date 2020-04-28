namespace LotusCatering.Services.Data.Tests
{
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using LotusCatering.Data;
    using LotusCatering.Data.Models;
    using LotusCatering.Data.Repositories;
    using LotusCatering.Services.Mapping;
    using LotusCatering.Web.ViewModels.Tabs;
    using Microsoft.Data.Sqlite;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class TabTests
    {
        private TabService tabService;

        private EfDeletableEntityRepository<Tab> tabRepository;
        private EfDeletableEntityRepository<Category> categoryRepository;

        private Tab testTab1;
        private Tab testTab2;
        private Tab testTab3;

        private Category testCategory1;
        private Category testCategory2;

        public TabTests()
        {
            this.InitializeMapper();
            this.InitializeDatabaseAndRepositories();
            this.SeedCategories();
            this.InitializeFields();
            this.tabService = new TabService(this.tabRepository, this.categoryRepository);
        }

        [Fact]
        public async Task TabAddAsyncShouldAdd()
        {
            await this.tabService.AddAsync(
                "Name3",
                "Image3",
                this.testCategory1.Id,
                "Description3");
            var count = this.tabRepository.All().Count();

            Assert.Equal(1, count);
        }

        [Fact]
        public async Task TabDeleteAsyncShouldDelete()
        {
            await this.SeedDatabase();

            var countBefore = this.tabRepository.All().Count();
            var response = await this.tabService.DeleteAsync(this.testTab1.Id);
            var countAfter = this.tabRepository.All().Count();

            Assert.Equal(countBefore, countAfter + 1);

            Assert.True(response);
        }

        [Fact]
        public async Task TabDeleteAsyncShouldDoNothingOnInvalidId()
        {
            await this.SeedDatabase();

            var countBefore = this.tabRepository.All().Count();
            var response = await this.tabService.DeleteAsync("invalid");
            var countAfter = this.tabRepository.All().Count();

            Assert.Equal(countBefore, countAfter);

            Assert.False(response);
        }

        [Fact]
        public async Task TabGetAllShouldReturnAll()
        {
            await this.SeedDatabase();

            var response = this.tabService.GetAll<TabIdNameViewModel>().ToArray();

            Assert.Equal(2, response.Length);
        }

        [Fact]
        public async Task TabGetAllByCategoryIdShouldReturnAll()
        {
            await this.SeedDatabase();

            var response = this.tabService.GetAll<TabIdNameViewModel>(this.testCategory1.Id).ToArray();

            Assert.Equal(2, response.Length);
        }

        [Fact]
        public async Task TabGetByIdShouldReturnProperly()
        {
            await this.SeedDatabase();

            var response = this.tabService.GetById<TabIdNameViewModel>(this.testTab1.Id);

            Assert.Equal(this.testTab1.Id, response.Id);
            Assert.Equal(this.testTab1.Name, response.Name);
        }

        [Fact]
        public async Task TabGetNameByIdShouldReturnProperly()
        {
            await this.SeedDatabase();

            var response = this.tabService.GetNameById(this.testTab1.Id);

            Assert.Equal(this.testTab1.Name, response);
        }

        [Fact]
        public async Task TabUpdateAsyncShouldUpdateData()
        {
            await this.SeedDatabase();

            const string name = "newName";
            const string description = "newDescription";
            string categoryId = this.testCategory2.Id;

            var response = await this.tabService.UpdateAsync(this.testTab1.Id, name, categoryId, description);
            var updated = this.tabService.GetById<Tab>(this.testTab1.Id);

            Assert.True(response);

            Assert.Equal(this.testTab1.Id, updated.Id);
            Assert.Equal(name, updated.Name);
            Assert.Equal(description, updated.Description);
            Assert.Equal(categoryId, updated.CategoryId);
        }

        [Fact]
        public async Task TabUpdateAsyncShouldNotUpdateWhenInvalidCategoryId()
        {
            await this.SeedDatabase();

            const string name = "newName";
            const string description = "newDescription";
            string categoryId = "invalid";

            var response = await this.tabService.UpdateAsync(this.testTab1.Id, name, categoryId, description);
            var updated = this.tabService.GetById<Tab>(this.testTab1.Id);

            Assert.False(response);

            Assert.Equal(this.testTab1.Id, updated.Id);
            Assert.NotEqual(name, updated.Name);
            Assert.NotEqual(description, updated.Description);
            Assert.NotEqual(categoryId, updated.CategoryId);
        }

        [Fact]
        public async Task TabUpdateAsyncShouldNotUpdateOnWrongId()
        {
            await this.SeedDatabase();

            const string name = "newName";
            const string description = "newDescription";

            var response = await this.tabService.UpdateAsync("43", name, this.testCategory2.Id, description);

            Assert.False(response);
        }

        [Fact]
        public async Task TabUpdateImageAsyncShouldUpdateImage()
        {
            await this.SeedDatabase();

            const string imageUrl = "newImageUrl";

            var response = await this.tabService.UpdateImageAsync(this.testTab1.Id, imageUrl);
            var updated = this.tabService.GetById<Tab>(this.testTab1.Id);

            Assert.True(response);

            Assert.Equal(imageUrl, updated.ImageUrl);
            Assert.Equal(this.testTab1.Id, updated.Id);
        }

        [Fact]
        public async Task TabUpdateImageAsyncShouldNotUpdateImageOnWrongId()
        {
            await this.SeedDatabase();

            const string imageUrl = "newImageUrl";

            var response = await this.tabService.UpdateImageAsync("invalid", imageUrl);

            Assert.False(response);
        }

        private async void SeedCategories()
        {
            this.testCategory1 = new Category
            {
                Id = "1",
                Name = "Name1",
                Description = "Description1",
                ImageUrl = "Image1",
            };

            this.testCategory2 = new Category
            {
                Id = "2",
                Name = "Name2",
                Description = "Description2",
                ImageUrl = "Image2",
            };

            await this.categoryRepository.AddAsync(this.testCategory1);
            await this.categoryRepository.AddAsync(this.testCategory2);
            await this.categoryRepository.SaveChangesAsync();
        }

        private async Task SeedDatabase()
        {
            await this.tabRepository.AddAsync(this.testTab1);
            await this.tabRepository.AddAsync(this.testTab2);
            await this.tabRepository.AddAsync(this.testTab3);
            await this.tabRepository.SaveChangesAsync();
        }

        private void InitializeDatabaseAndRepositories()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(connection);
            var dbContext = new ApplicationDbContext(options.Options);

            dbContext.Database.EnsureCreated();

            this.tabRepository = new EfDeletableEntityRepository<Tab>(dbContext);
            this.categoryRepository = new EfDeletableEntityRepository<Category>(dbContext);
        }

        private void InitializeFields()
        {
            this.testTab1 = new Tab
            {
                Id = "1",
                Name = "Name1",
                Description = "Description1",
                ImageUrl = "Image1",
                CategoryId = "1",
            };

            this.testTab2 = new Tab
            {
                Id = "2",
                Name = "Name2",
                Description = "Description2",
                ImageUrl = "Image2",
                CategoryId = "1",
            };

            this.testTab3 = new Tab
            {
                Id = "3",
                Name = "Name3",
                Description = "Description3",
                ImageUrl = "Image3",
                CategoryId = "2",
                IsDeleted = true,
            };
        }

        private void InitializeMapper() => AutoMapperConfig.
            RegisterMappings(Assembly.Load("LotusCatering.Web.ViewModels"));
    }
}
