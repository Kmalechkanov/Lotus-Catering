namespace LotusCatering.Services.Data.Tests
{
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using LotusCatering.Data;
    using LotusCatering.Data.Models;
    using LotusCatering.Data.Repositories;
    using LotusCatering.Services.Mapping;
    using LotusCatering.Web.ViewModels.Categories;
    using Microsoft.Data.Sqlite;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class CategoryTests
    {
        private CategoryService categoryService;

        private EfDeletableEntityRepository<Category> categoryRepository;

        private Category testCategory1;
        private Category testCategory2;
        private Category testCategory3;

        public CategoryTests()
        {
            this.InitializeMapper();
            this.InitializeDatabaseAndRepositories();
            this.InitializeFields();
            this.categoryService = new CategoryService(this.categoryRepository);
        }

        [Fact]
        public async Task CategoryAddAsyncShouldAdd()
        {
            await this.categoryService.AddAsync(
                "Name3",
                "Description3",
                "Image3");
            var count = this.categoryRepository.All().Count();

            Assert.Equal(1, count);
        }

        [Fact]
        public async Task CategoryDeleteAsyncShouldDelete()
        {
            await this.SeedDatabase();

            var countBefore = this.categoryRepository.All().Count();
            var response = await this.categoryService.DeleteAsync(this.testCategory1.Id);
            var countAfter = this.categoryRepository.All().Count();

            Assert.Equal(countBefore, countAfter + 1);

            Assert.True(response);
        }

        [Fact]
        public async Task CategoryDeleteAsyncShouldDoNothingOnInvalidId()
        {
            await this.SeedDatabase();

            var countBefore = this.categoryRepository.All().Count();
            var response = await this.categoryService.DeleteAsync("43");
            var countAfter = this.categoryRepository.All().Count();

            Assert.Equal(countBefore, countAfter);

            Assert.True(!response);
        }

        [Fact]
        public async Task CategoryGetAllShouldReturnAll()
        {
            await this.SeedDatabase();

            var response = this.categoryService.GetAll<CategoryIdNameViewModel>().ToArray();

            Assert.Equal(2, response.Length);
        }

        [Fact]
        public async Task CategoryGetByIdShouldReturnProperly()
        {
            await this.SeedDatabase();

            var response = this.categoryService.GetById<CategoryIdNameViewModel>(this.testCategory1.Id);

            Assert.Equal(this.testCategory1.Id, response.Id);
            Assert.Equal(this.testCategory1.Name, response.Name);
        }

        [Fact]
        public async Task CategoryGetNameByIdShouldReturnProperly()
        {
            await this.SeedDatabase();

            var response = this.categoryService.GetNameById(this.testCategory1.Id);

            Assert.Equal(this.testCategory1.Name, response);
        }

        [Fact]
        public async Task CategoryIsInvalidIdShouldReturnTrue()
        {
            await this.SeedDatabase();

            var response = this.categoryService.IsValidId(this.testCategory1.Id);

            Assert.True(response);
        }

        [Fact]
        public async Task CategoryIsInvalidIdShouldReturnFalseWhenInvalid()
        {
            await this.SeedDatabase();

            var response = this.categoryService.IsValidId("43");

            Assert.False(response);
        }

        [Fact]
        public async Task CategoryUpdateAsyncShouldUpdateData()
        {
            await this.SeedDatabase();

            const string name = "newName";
            const string description = "newDescription";

            var response = await this.categoryService.UpdateAsync(this.testCategory1.Id, name, description);
            var updated = this.categoryService.GetById<CategoryDescriptionViewModel>(this.testCategory1.Id);

            Assert.True(response);

            Assert.Equal(this.testCategory1.Id, updated.Id);
            Assert.Equal(name, updated.Name);
            Assert.Equal(description, updated.Description);
        }

        [Fact]
        public async Task CategoryUpdateAsyncShouldNotUpdateOnWrongId()
        {
            await this.SeedDatabase();

            const string name = "newName";
            const string description = "newDescription";

            var response = await this.categoryService.UpdateAsync("43", name, description);

            Assert.False(response);
        }

        [Fact]
        public async Task CategoryUpdateImageAsyncShouldUpdateImage()
        {
            await this.SeedDatabase();

            const string imageUrl = "newImageUrl";

            var response = await this.categoryService.UpdateImageAsync(this.testCategory1.Id, imageUrl);
            var updated = this.categoryService.GetById<CategoryDescriptionViewModel>(this.testCategory1.Id);

            Assert.True(response);

            Assert.Equal(imageUrl, updated.ImageUrl);
            Assert.Equal(this.testCategory1.Id, updated.Id);
        }

        [Fact]
        public async Task CategoryUpdateImageAsyncShouldNotUpdateImageOnWrongId()
        {
            await this.SeedDatabase();

            const string imageUrl = "newImageUrl";

            var response = await this.categoryService.UpdateImageAsync("43", imageUrl);

            Assert.False(response);
        }

        private void InitializeDatabaseAndRepositories()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(connection);
            var dbContext = new ApplicationDbContext(options.Options);

            dbContext.Database.EnsureCreated();

            this.categoryRepository = new EfDeletableEntityRepository<Category>(dbContext);
        }

        private void InitializeFields()
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

            this.testCategory3 = new Category
            {
                Id = "3",
                Name = "Name3",
                Description = "Description3",
                ImageUrl = "Image3",
                IsDeleted = true,
            };
        }

        private async Task SeedDatabase()
        {
            await this.categoryRepository.AddAsync(this.testCategory1);
            await this.categoryRepository.AddAsync(this.testCategory2);
            await this.categoryRepository.AddAsync(this.testCategory3);
            await this.categoryRepository.SaveChangesAsync();
        }

        private void InitializeMapper() => AutoMapperConfig.
            RegisterMappings(Assembly.Load("LotusCatering.Web.ViewModels"));
    }
}
